using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ConnectedTariffsController(IConnectedTariffsRepository connectedTariffsRepository, ITariffRepository tariffRepository, IMapper mapper) : ControllerBase
    {
        private readonly IConnectedTariffsRepository _connectedTariffsRepository = connectedTariffsRepository;
        private readonly ITariffRepository _tariffRepository = tariffRepository;
        private readonly IMapper _mapper = mapper;

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
                _connectedTariffsRepository.AddConnectedTariff(newConnTariff);
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
                    _connectedTariffsRepository.BlockConnectedTariff(connTariff.Id);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке заблокировать услуги");
            }
        }

        [HttpGet("Block/{connTariffId:int}")]
        public async Task<ActionResult> BlockConnectedTariff(int connTariffId)
        {
            try
            {
                _connectedTariffsRepository.BlockConnectedTariff(connTariffId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке заблокировать услугу");
            }
        }

        [HttpGet("Unblock/{connTariffId:int}")]
        public async Task<ActionResult> UnblockConnectedTariff(int connTariffId)
        {
            try
            {
                _connectedTariffsRepository.UnblockConnectedTariff(connTariffId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке разблокировать услугу");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConnectedTariff(int connTariffId)
        {
            try
            {
                _connectedTariffsRepository.DeleteConnectedTariff(connTariffId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке отключить услугу");
            }
        }
    }
}
