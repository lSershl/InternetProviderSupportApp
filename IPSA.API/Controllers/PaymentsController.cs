using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentRepository paymentRepository, IMapper mapper) : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetAllPayments()
        {
            try
            {
                var payments = _paymentRepository.GetAllPaymentsList();
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

        [HttpGet("Abonent/{abonId:int}")]
        public async Task<ActionResult<List<Payment>>> GetAbonentPaymentsList(int abonId)
        {
            try
            {
                var abonPayments = _paymentRepository.GetPaymentsListByAbonent(abonId);

                if (abonPayments is null)
                {
                    return NoContent();
                }

                return Ok(abonPayments);
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
