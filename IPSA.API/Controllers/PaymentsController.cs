﻿using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentRepository paymentRepository, IConnectedTariffsRepository connectedTariffsRepository, IMapper mapper) : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IConnectedTariffsRepository _connectedTariffsRepository = connectedTariffsRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> GetAllPaymentsList()
        {
            try
            {
                var payments = _paymentRepository.GetAllPaymentsList();
                if (payments is null)
                {
                    return NotFound("Список платежей пуст");
                }
                else
                {
                    var result = _mapper.Map<PaymentDto>(payments);
                    return Ok(payments);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpGet("Abonent/{abonId:int}")]
        public async Task<ActionResult<List<PaymentDto>>> GetAbonentPaymentsList(int abonId)
        {
            try
            {
                var abonPayments = _paymentRepository.GetPaymentsListByAbonent(abonId);

                if (abonPayments is null)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<PaymentDto>>(abonPayments);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewPayment(PaymentDto paymentDto)
        {
            try
            {
                if (paymentDto is null)
                {
                    return BadRequest("Ошибка. Платёж не содержит данных.");
                }

                var newPayment = _mapper.Map<Payment>(paymentDto);
                await _paymentRepository.AddNewPayment(newPayment);
                await _connectedTariffsRepository.CheckBalanceAndRemoveAutoblocksAfterPeayment(paymentDto.AbonentId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении платежа в базу");
            }
        }

        [HttpPatch("CancelPayment/{paymentId:int}")]
        public async Task<ActionResult> CancelPayment(int paymentId)
        {
            try
            {
                await _paymentRepository.CancelPayment(paymentId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке отменить платёж");
            }
        }
        
    }
}
