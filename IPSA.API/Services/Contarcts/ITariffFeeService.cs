using IPSA.Models;

namespace IPSA.API.Services.Contarcts
{
    public interface ITariffFeeService
    {
        List<MonthlyFee> CheckIncompleteMonthlyFees();
        Task CollectMonthlyFees(List<MonthlyFee> monthlyFees);
        List<MonthlyFee> CheckCompletedMonthlyFeesForRemoval();
        Task RemoveCompletedMonthlyFeesOfLastMonth(List<MonthlyFee> oldMonthlyFees);
        Task CollectDailyFees();
    }
}
