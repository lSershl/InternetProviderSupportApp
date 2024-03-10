using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class ScheduledMonthlyFeesRepository(AppDbContext appDbContext) : IScheduledMonthlyFeesRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<MonthlyFee> GetScheduledFeesListForToday()
        {
            var monthlyFeesList = _appDbContext.MonthlyFees.Where(x => x.ScheduledDate == DateOnly.FromDateTime(DateTime.UtcNow)).ToList();
            return monthlyFeesList;
        }

        public List<MonthlyFee> GetCompletedMonthlyFeesOfLastMonth()
        {
            var lastMonth = DateOnly.FromDateTime(DateTime.UtcNow).AddMonths(-1).Month;
            var oldMonthlyFeesList = _appDbContext.MonthlyFees.Where(x => x.ScheduledDate.Month.Equals(lastMonth)).ToList();
            return oldMonthlyFeesList;
        }

        public MonthlyFee GetNextScheduledMonthlyFeeForConnectedTariff(int connTariffId)
        {
            return _appDbContext.MonthlyFees.First(x => x.ConnectedTariffId == connTariffId && x.IsCompleted.Equals(false));
        }

        public Task CompleteScheduledMonthlyFees(List<MonthlyFee> scheduledFees)
        {
            foreach (var fee in scheduledFees)
            {
                if (fee.IsCompleted is false)
                {
                    var abonentForFeeCollection = _appDbContext.Abonents.First(a => a.Id == _appDbContext.ConnectedTariffs.First(t => t.Id == fee.ConnectedTariffId).AbonentId);
                    if (abonentForFeeCollection.Balance >= fee.Amount)
                    {
                        abonentForFeeCollection.Balance -= fee.Amount;
                        _appDbContext.Abonents.Update(abonentForFeeCollection);
                        fee.IsCompleted = true;
                        var nextFee = fee;
                        nextFee.Id = 0;
                        nextFee.IsCompleted = false;
                        nextFee.ScheduledDate = fee.ScheduledDate.AddMonths(1);
                        AddNewScheduledMonthlyFee(nextFee);
                    }
                    else
                    {
                        var connTariffForBlock = _appDbContext.ConnectedTariffs.First(ct => ct.Id == fee.ConnectedTariffId);
                        connTariffForBlock.IsBlocked = true;
                        connTariffForBlock.IsAutoblocked = true;
                        _appDbContext.ConnectedTariffs.Update(connTariffForBlock);
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
                throw new NullReferenceException("Запланированного списания платы с данным Id не существует");
            }
        }

        
    }
}
