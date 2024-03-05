using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class ReportsController(IFeeWithdrawRepository feeWithdrawRepository, IPaymentRepository paymentRepository, IMapper mapper) : ControllerBase
    {
        private readonly IFeeWithdrawRepository _feeWithdrawRepository = feeWithdrawRepository;
        private readonly IPaymentRepository _paymentRepository = paymentRepository;
        private readonly IMapper _mapper = mapper;

        [HttpPut("Abonent/{abonId:int}/FeeWithdraws")]
        public async Task<ActionResult<List<FeeWithdrawRecordDto>>> GetFeeWithdrawsReport(int abonId, DatePeriodDto datePeriodDto)
        {
            try
            {
                DateTime start = datePeriodDto.StartDate.ToDateTime(TimeOnly.MinValue);
                DateTime end = datePeriodDto.EndDate.ToDateTime(TimeOnly.MaxValue);
                var feeWithdraws = _feeWithdrawRepository.GetWithdrawsListByAbonent(abonId).Where(x => x.CompletionDateTime > start && x.CompletionDateTime < end);

                if (feeWithdraws is null)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<FeeWithdrawRecordDto>>(feeWithdraws);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPut("Abonent/{abonId:int}/Payments")]
        public async Task<ActionResult<List<PaymentDto>>> GetPaymentsReport(int abonId, DatePeriodDto datePeriodDto)
        {
            try
            {
                DateTime start = datePeriodDto.StartDate.ToDateTime(TimeOnly.MinValue);
                DateTime end = datePeriodDto.EndDate.ToDateTime(TimeOnly.MaxValue);
                var payments = _paymentRepository.GetPaymentsListByAbonent(abonId).Where(x => x.PaymentDateTime > start && x.PaymentDateTime < end);

                if (payments is null)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<PaymentDto>>(payments);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }
    }
}
