using IPSA.Models;

namespace IPSA.API.Services.Contarcts
{
    public interface ITariffFeeService
    {
        List<MonthlyFee> CheckIncompleteMonthlyFees();
        Task CheckDailyFees();
        Task CollectFees();
    }
}
