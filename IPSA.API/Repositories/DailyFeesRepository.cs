using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;

namespace IPSA.API.Repositories
{
    public class DailyFeesRepository(AppDbContext appDbContext) : IDailyFeesRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public Task CompleteDailyFees()
        {
            var listOfConnectedTariffs = _appDbContext.ConnectedTariffs
                .Where(c => c.IsBlocked.Equals(false) && (c.TariffId == _appDbContext.Tariffs.First(t => t.Id == c.TariffId && t.PricingModel.Equals("Посуточный")).Id)).ToList();

            foreach (var ct in listOfConnectedTariffs)
            {
                var abonent = _appDbContext.Abonents.First(a => a.Id == ct.AbonentId);
                decimal dailyFee = _appDbContext.Tariffs.First(t => t.Id == ct.TariffId).DailyPrice;
                if (abonent.Balance >= dailyFee)
                {
                    abonent.Balance -= dailyFee;
                }
                else
                {
                    ct.IsBlocked = true;
                    _appDbContext.ConnectedTariffs.Update(ct);
                }
                _appDbContext.Abonents.Update(abonent);
            }

            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
