using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class DailyFeesRepository(AppDbContext appDbContext) : IDailyFeesRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public Task FormDailyFeesForToday()
        {
            var listOfDailyPricedConnectedTariffs = _appDbContext.ConnectedTariffs
                .Where(c => c.IsBlocked.Equals(false) && (c.TariffId == _appDbContext.Tariffs.First(t => t.Id == c.TariffId && t.PricingModel.Equals("Посуточный")).Id)).ToList();
            foreach (var ct in listOfDailyPricedConnectedTariffs)
            {
                DailyFee dailyFee = new DailyFee
                {
                    ConnectedTariffId = ct.Id,
                    Amount = _appDbContext.Tariffs.First(t => t.Id == ct.TariffId).DailyPrice,
                    Date = DateOnly.FromDateTime(DateTime.Today),
                    IsCompleted = false
                };
                AddDailyFee(dailyFee);
            }
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public List<DailyFee> GetDailyFeesForToday()
        {
            var dailyFeesList = _appDbContext.DailyFees.Where(x => x.Date == DateOnly.FromDateTime(DateTime.Today)).ToList();
            return dailyFeesList;
        }

        public List<DailyFee> GetOldCompletedDailyFees()
        {
            var oldDailyFeesList = _appDbContext.DailyFees.Where(x => (x.Date < DateOnly.FromDateTime(DateTime.Today)) && (x.IsCompleted.Equals(true))).ToList();
            return oldDailyFeesList;
        }

        public Task AddDailyFee(DailyFee dailyFee)
        {
            _appDbContext.DailyFees.Add(dailyFee);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveDailyFee(int dailyFeeId)
        {
            var feeToRemove = _appDbContext.DailyFees.First(f => f.Id == dailyFeeId);
            if (feeToRemove is not null)
            {
                _appDbContext.DailyFees.Remove(feeToRemove);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Запланированного списания платы с данным Id не существует");
            }
        }

        public Task CompleteDailyFees(List<DailyFee> dailyFees)
        {
            foreach (var fee in dailyFees)
            {
                var connectedTariff = _appDbContext.ConnectedTariffs.First(ct => ct.Id == fee.ConnectedTariffId);
                var abonent = _appDbContext.Abonents.First(a => a.Id == connectedTariff!.AbonentId);
                if (abonent.Balance >= fee.Amount)
                {
                    abonent.Balance -= fee.Amount;
                }
                else
                {
                    connectedTariff!.IsBlocked = true;
                    connectedTariff!.IsAutoblocked = true;
                    _appDbContext.ConnectedTariffs.Update(connectedTariff);
                }
                _appDbContext.Abonents.Update(abonent);
                fee.IsCompleted = true;
                _appDbContext.DailyFees.Update(fee);
            }

            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
