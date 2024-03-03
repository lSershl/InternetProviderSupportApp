using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IDailyFeesRepository
    {
        Task FormDailyFeesForToday();
        List<DailyFee> GetDailyFeesForToday();
        List<DailyFee> GetOldCompletedDailyFees();
        Task AddDailyFee(DailyFee dailyFee);
        Task RemoveDailyFee(int dailyFeeId);
        Task CompleteDailyFees(List<DailyFee> dailyFees);
    }
}
