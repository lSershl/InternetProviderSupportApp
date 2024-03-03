using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IScheduledMonthlyFeesRepository
    {
        List<MonthlyFee> GetScheduledFeesListForToday();
        List<MonthlyFee> GetCompletedMonthlyFeesOfLastMonth();
        MonthlyFee GetNextScheduledMonthlyFeeForConnectedTariff(int connTariffId);
        Task CompleteScheduledMonthlyFees(List<MonthlyFee> scheduledFees);
        Task AddNewScheduledMonthlyFee(MonthlyFee monthlyFee);
        Task RemoveScheduledMonthlyFee(int monthlyFeeId);
    }
}
