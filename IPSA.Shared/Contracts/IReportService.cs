using IPSA.Shared.Dtos;

namespace IPSA.Shared.Contracts
{
    public interface IReportService
    {
        Task<List<PaymentDto>> GetPaymentRecordsByAbonent(int abonId, DatePeriodDto datePeriodDto);
        Task<List<FeeWithdrawRecordDto>> GetFeeWithdrawRecordsByAbonent(int abonId, DatePeriodDto datePeriodDto);
    }
}
