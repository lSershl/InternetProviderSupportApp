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

        public Task FormDailyFeesForToday()
        {
            _dailyFeesRepository.FormDailyFeesForToday();
            return Task.CompletedTask;
        }

        public List<DailyFee> CheckIncompleteDailyFees()
        {
            var dailyFees = _dailyFeesRepository.GetDailyFeesForToday().Where(f => f.IsCompleted.Equals(false)).ToList();
            return dailyFees;
        }

        public List<DailyFee> CheckCompletedDailyFeesForRemoval()
        {
            var oldDailyFees = _dailyFeesRepository.GetOldCompletedDailyFees();
            return oldDailyFees;
        }

        public Task RemoveCompletedDailyFees(List<DailyFee> oldDailyFees)
        {
            foreach (var fee in oldDailyFees)
            {
                _dailyFeesRepository.RemoveDailyFee(fee.Id);
            }
            return Task.CompletedTask;
        }

        public Task CollectDailyFees(List<DailyFee> dailyFees)
        {
            _dailyFeesRepository.CompleteDailyFees(dailyFees);
            return Task.CompletedTask;
        }
    }
}
