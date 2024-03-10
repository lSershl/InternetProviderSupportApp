﻿using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ConnectedTariffsController(
        IAbonentRepository abonentRepository,
        IConnectedTariffsRepository connectedTariffsRepository, 
        ITariffRepository tariffRepository, 
        IFeeWithdrawRepository feeWithdrawRepository,
        IScheduledMonthlyFeesRepository scheduledMonthlyFeesRepository,
        IMapper mapper) : ControllerBase
    {
        private readonly IAbonentRepository _abonentRepository = abonentRepository;
        private readonly IConnectedTariffsRepository _connectedTariffsRepository = connectedTariffsRepository;
        private readonly ITariffRepository _tariffRepository = tariffRepository;
        private readonly IFeeWithdrawRepository _feeWithdrawRepository = feeWithdrawRepository;
        private readonly IScheduledMonthlyFeesRepository _monthlyFeesRepository = scheduledMonthlyFeesRepository;
        private readonly IMapper _mapper = mapper;

        private const string MonthlyPricingModel = "Месячный";

        [HttpGet("Abonent/{abonId:int}")]
        public async Task<ActionResult<List<ConnectedTariffDto>>> GetConnectedTariffsByAbonent(int abonId)
        {
            try
            {
                List<ConnectedTariffDto> resultingList = new();
                var abonConnTariffs = _connectedTariffsRepository.GetConnectedTariffsListByAbonent(abonId);

                if (abonConnTariffs is null)
                {
                    return NoContent();
                }
                else
                {
                    foreach (var connTariff in abonConnTariffs)
                    {
                        ConnectedTariffDto resultingListItem = new();
                        Tariff tariff = _tariffRepository.GetTariffById(connTariff.TariffId);

                        resultingListItem.Id = connTariff.Id;
                        resultingListItem.Name = tariff.Name;
                        resultingListItem.IpAddress = connTariff.IpAddress;
                        resultingListItem.LinkToHardware = connTariff.LinkToHardware;
                        resultingListItem.PricingModel = tariff.PricingModel;
                        resultingListItem.MonthlyPrice = tariff.MonthlyPrice;
                        resultingListItem.DailyPrice = tariff.DailyPrice;
                        resultingListItem.IsBlocked = connTariff.IsBlocked;
                        resultingListItem.IsAutoblocked = connTariff.IsAutoblocked;

                        resultingList.Add(resultingListItem);
                    }
                }

                return Ok(resultingList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewConnectedTariff(ConnectedTariffDto connTariffDto)
        {
            try
            {
                if (connTariffDto is null)
                {
                    return BadRequest("Ошибка. Подключаемый тариф/услуга не содержит данных.");
                }

                var newConnTariff = _mapper.Map<ConnectedTariff>(connTariffDto);
                newConnTariff.CreationDateTime = DateTime.UtcNow;
                _connectedTariffsRepository.AddConnectedTariff(newConnTariff);
                string tariffPricingModel = _tariffRepository.GetTariffsList().First(x => x.Id == connTariffDto.TariffId).PricingModel;
                decimal amount = 0m;
                if (tariffPricingModel == MonthlyPricingModel)
                {
                    amount = connTariffDto.MonthlyPrice;
                }
                else
                {
                    amount = connTariffDto.DailyPrice;
                }
                var newFeeWithdraw = new FeeWithdraw()
                    { 
                        AbonentId = connTariffDto.AbonentId,
                        ConnectedTariffId = connTariffDto.Id,
                        Type = "Списание",
                        PricingModel = tariffPricingModel,
                        Amount = amount,
                        CompletionDateTime = DateTime.UtcNow
                    };
                _feeWithdrawRepository.AddNewFeeWithdrawRecord(newFeeWithdraw);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении тарифа/услуги в базу");
            }
        }

        [HttpGet("Abonent/{abonId:int}/BlockAll")]
        public async Task<ActionResult> BlockAllAbonentTariffs(int abonId)
        {
            try
            {
                var connTariffsList = _connectedTariffsRepository.GetConnectedTariffsListByAbonent(abonId);
                foreach (var connTariff in connTariffsList)
                {
                    BlockConnectedTariff(connTariff.Id);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке заблокировать услуги");
            }
        }

        [HttpGet("Block/{connTariffId:int}")]
        public async Task<ActionResult> BlockConnectedTariffByRequest(int connTariffId)
        {
            try
            {
                BlockConnectedTariff(connTariffId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке заблокировать услугу");
            }
        }

        private void BlockConnectedTariff(int connTariffId)
        {
            var connectedTariff = _connectedTariffsRepository.GetConnectedTariffById(connTariffId);
            var tariff = _tariffRepository.GetTariffById(connectedTariff.TariffId);
            var lastFeeWithdraw = _feeWithdrawRepository.GetWithdrawsListByAbonent(connectedTariff.AbonentId).OrderBy(x => x.CompletionDateTime).LastOrDefault(x => x.ConnectedTariffId == connTariffId);
            var nextMonthlyFee = _monthlyFeesRepository.GetNextScheduledMonthlyFeeForConnectedTariff(connTariffId);

            if (tariff.PricingModel == MonthlyPricingModel)
            {
                var refund = _feeWithdrawRepository.CalculateRefundAmount(lastFeeWithdraw);
                _feeWithdrawRepository.ApplyRefund(lastFeeWithdraw.AbonentId, refund);
                FeeWithdraw refundRecord = new FeeWithdraw()
                {
                    AbonentId = lastFeeWithdraw.AbonentId,
                    ConnectedTariffId = lastFeeWithdraw.ConnectedTariffId,
                    Type = "Возврат",
                    PricingModel = lastFeeWithdraw.PricingModel,
                    Amount = refund,
                    CompletionDateTime = DateTime.UtcNow
                };
                _feeWithdrawRepository.AddNewFeeWithdrawRecord(refundRecord);
            }
            _connectedTariffsRepository.BlockConnectedTariff(connTariffId);
            
            _monthlyFeesRepository.RemoveScheduledMonthlyFee(nextMonthlyFee.Id);
        }

        [HttpGet("Unblock/{connTariffId:int}")]
        public async Task<ActionResult> UnblockConnectedTariff(int connTariffId)
        {
            try
            {
                var connectedTariff = _connectedTariffsRepository.GetConnectedTariffById(connTariffId);
                var tariff = _tariffRepository.GetTariffById(connectedTariff.TariffId);
                var abonent = _abonentRepository.GetAbonent(connectedTariff.AbonentId);

                if (tariff.PricingModel == MonthlyPricingModel)
                {
                    if (abonent.Balance < tariff.MonthlyPrice)
                        return BadRequest("Недостаточно средств на балансе для оплаты тарифа");

                    ApplyFeeWithdrawAfterUnblock(connectedTariff, tariff);
                }
                else
                {
                    if (abonent.Balance < tariff.DailyPrice)
                        return BadRequest("Недостаточно средств на балансе для оплаты тарифа");

                    ApplyFeeWithdrawAfterUnblock(connectedTariff, tariff);
                }

                var newMonthlyFee = new MonthlyFee
                {   
                    ConnectedTariffId = connTariffId,
                    Amount = tariff.MonthlyPrice,
                    ScheduledDate = DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(1)),
                    IsCompleted = false
                };
                _monthlyFeesRepository.AddNewScheduledMonthlyFee(newMonthlyFee);
                _connectedTariffsRepository.UnblockConnectedTariff(connTariffId);
                
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке разблокировать услугу");
            }
        }
        private void ApplyFeeWithdrawAfterUnblock(ConnectedTariff connectedTariff, Tariff tariff)
        {
            decimal amount = 0;
            if (tariff.PricingModel == MonthlyPricingModel)
            {
                amount = tariff.MonthlyPrice;
            }
            else
            {
                amount = tariff.DailyPrice;
            }
            var newFeeWithdraw = new FeeWithdraw()
            {
                AbonentId = connectedTariff.AbonentId,
                ConnectedTariffId = connectedTariff.Id,
                Type = "Списание",
                PricingModel = tariff.PricingModel,
                Amount = amount,
                CompletionDateTime = DateTime.UtcNow
            };
            _feeWithdrawRepository.ApplyBalanceWithdraw(newFeeWithdraw);
            _feeWithdrawRepository.AddNewFeeWithdrawRecord(newFeeWithdraw);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConnectedTariff(int connTariffId)
        {
            try
            {
                var connTariff = _connectedTariffsRepository.GetConnectedTariffById(connTariffId);
                var lastFeeWithdraw = _feeWithdrawRepository.GetWithdrawsListByAbonent(connTariff.AbonentId).OrderBy(x => x.CompletionDateTime).LastOrDefault(x => x.ConnectedTariffId == connTariffId);
                _connectedTariffsRepository.DeleteConnectedTariff(connTariffId);
                var refund = _feeWithdrawRepository.CalculateRefundAmount(lastFeeWithdraw);
                _feeWithdrawRepository.ApplyRefund(lastFeeWithdraw.AbonentId, refund);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке отключить услугу");
            }
        }

        
    }
}
