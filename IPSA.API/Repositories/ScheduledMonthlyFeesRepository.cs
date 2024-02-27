using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using System.ComponentModel.Design;

namespace IPSA.API.Repositories
{
    public class ScheduledMonthlyFeesRepository(AppDbContext appDbContext) : IScheduledMonthlyFeesRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<MonthlyFee> GetScheduledFeesListForToday()
        {
            var monthlyFeesList = _appDbContext.MonthlyFees.Where(x => x.ScheduledDay == DateOnly.FromDateTime(DateTime.UtcNow)).ToList();
            return monthlyFeesList;
        }

        public Task CompleteScheduledMonthlyFees(List<MonthlyFee> scheduledFees)
        {
            foreach (var fee in scheduledFees)
            {
                if (fee.IsCompleted is false)
                {
                    var abonentForFeeCollection = _appDbContext.Abonents.First(a => a.Id == _appDbContext.ConnectedTariffs.First(t => t.Id == fee.ConnectedTariffId).AbonentId);
                    abonentForFeeCollection.Balance -= fee.Amount;
                    if (abonentForFeeCollection.Balance >= 0)
                    {
                        _appDbContext.Abonents.Update(abonentForFeeCollection);
                        fee.IsCompleted = true;
                    }
                    _appDbContext.MonthlyFees.Update(fee);
                }
            }
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task AddNewScheduledMonthlyFee(MonthlyFee monthlyFee)
        {
            _appDbContext.MonthlyFees.Add(monthlyFee);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveScheduledMonthlyFee(int monthlyFeeId)
        {
            var feeToRemove = _appDbContext.MonthlyFees.FirstOrDefault(f => f.Id == monthlyFeeId);
            if (feeToRemove is not null)
            {
                _appDbContext.MonthlyFees.Remove(feeToRemove);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Запланированного списание с данным Id не существует");
            }
        }

        
    }
}
