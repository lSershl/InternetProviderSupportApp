using IPSA.API.Repositories.Contracts;
using IPSA.API.Services.Contarcts;
using IPSA.Models;

namespace IPSA.API.Services
{
    public class TariffFeeService(IDailyFeesRepository dailyFeesRepository, IScheduledMonthlyFeesRepository scheduledMonthlyFeesRepository) : ITariffFeeService
    {
        private readonly IDailyFeesRepository _dailyFeesRepository = dailyFeesRepository;
        private readonly IScheduledMonthlyFeesRepository _monthlyFeesRepository = scheduledMonthlyFeesRepository;

        public List<MonthlyFee> CheckIncompleteMonthlyFees()
        {
            var monthlyFees = _monthlyFeesRepository.GetScheduledFeesListForToday().Where(x => x.IsCompleted.Equals(false)).ToList();
            return monthlyFees;
        }

        public Task CollectMonthlyFees(List<MonthlyFee> monthlyFees)
        {
            _monthlyFeesRepository.CompleteScheduledMonthlyFees(monthlyFees);
            return Task.CompletedTask;
        }

        public Task CollectDailyFees()
        {
            _dailyFeesRepository.CompleteDailyFees();
            return Task.CompletedTask;
        }

        public List<MonthlyFee> CheckCompletedMonthlyFeesForRemoval()
        {
            var oldMonthlyFees = _monthlyFeesRepository.GetCompletedMonthlyFeesOfLastMonth();
            return oldMonthlyFees;
        }

        public Task RemoveCompletedMonthlyFeesOfLastMonth(List<MonthlyFee> oldMonthlyFees)
        {
            foreach (var fee in oldMonthlyFees)
            {
                _monthlyFeesRepository.RemoveScheduledMonthlyFee(fee.Id);
            }
            return Task.CompletedTask;
        }
    }
}
