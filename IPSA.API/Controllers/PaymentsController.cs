using AutoMapper;
using IPSA.API.Repositories;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentsRepository paymentsRepository, IMapper mapper) : ControllerBase
    {
        private readonly IPaymentsRepository _paymentsRepository = paymentsRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetAllPayments()
        {
            try
            {
                var payments = await _paymentsRepository.GetAllPaymentsList();
                if (payments is null)
                {
                    return NotFound("Список городов пуст");
                }
                else
                {
                    return Ok(payments);
                }
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
                await _paymentsRepository.AddNewPayment(newPayment);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении платежа в базу");
            }
        }
        
    }
}
