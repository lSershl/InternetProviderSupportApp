using IPSA.Models;

namespace IPSA.API.Services.Contarcts
{
    public interface ITariffFeeService
    {
        List<MonthlyFee> CheckIncompleteMonthlyFees();
        List<MonthlyFee> CheckCompletedMonthlyFeesForRemoval();
        Task RemoveCompletedMonthlyFeesOfLastMonth(List<MonthlyFee> oldMonthlyFees);
        Task CollectMonthlyFees(List<MonthlyFee> monthlyFees);
        Task FormDailyFeesForToday();
        List<DailyFee> CheckIncompleteDailyFees();
        List<DailyFee> CheckCompletedDailyFeesForRemoval();
        Task RemoveCompletedDailyFees(List<DailyFee> oldDailyFees);
        Task CollectDailyFees(List<DailyFee> dailyFees);
    }
}
