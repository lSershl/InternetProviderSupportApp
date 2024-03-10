using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class ConnectedTariffsRepository(AppDbContext appDbContext) : IConnectedTariffsRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private const string MonthlyPricingModel = "Месячный";

        public List<ConnectedTariff> GetConnectedTariffsListByAbonent(int abonId)
        {
            var connectedTariffs = _appDbContext.ConnectedTariffs.Where(x => x.AbonentId == abonId).ToList();
            return connectedTariffs;
        }

        public ConnectedTariff GetConnectedTariffById(int connTariffId)
        {
            var connectedTariff = _appDbContext.ConnectedTariffs.First(p => p.Id == connTariffId);
            return connectedTariff!;
        }

        public Task AddConnectedTariff(ConnectedTariff connTariff)
        {
            _appDbContext.ConnectedTariffs.Add(connTariff);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task BlockConnectedTariff(int connTariffId)
        {
            var connTariffToBlock = _appDbContext.ConnectedTariffs.First(ct => ct.Id == connTariffId);
            if (connTariffToBlock is not null)
            {
                connTariffToBlock.IsBlocked = true;
                connTariffToBlock.IsAutoblocked = false;
                _appDbContext.ConnectedTariffs.Update(connTariffToBlock);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Указанной подключенной услуги не существует");
            }
        }

        public Task CheckBalanceAndRemoveAutoblocksAfterPeayment(int abonentId)
        {
            Abonent abonent = _appDbContext.Abonents.First(a => a.Id == abonentId);
            List<ConnectedTariff> autoblockedConnTariffs = _appDbContext.ConnectedTariffs
                .Where(ct => ct.AbonentId == abonentId && ct.IsAutoblocked.Equals(true)).ToList();
            foreach (var ct in autoblockedConnTariffs)
            {
                var tariff = _appDbContext.Tariffs.First(t => t.Id == ct.Id);
                if (tariff.PricingModel == MonthlyPricingModel)
                {
                    if (tariff.MonthlyPrice <= abonent.Balance)
                    {
                        abonent.Balance -= tariff.MonthlyPrice;
                        ct.IsBlocked = false;
                        ct.IsAutoblocked = false;
                        _appDbContext.Update(ct);
                    }
                    else continue;
                }
                else
                {
                    if (tariff.DailyPrice <= abonent.Balance)
                    {
                        abonent.Balance -= tariff.DailyPrice;
                        ct.IsBlocked = false;
                        ct.IsAutoblocked = false;
                        _appDbContext.Update(ct);
                    }
                    else continue;
                }

            }
            _appDbContext.Update(abonent);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UnblockConnectedTariff(int connTariffId)
        {
            var connTariffToUnblock = _appDbContext.ConnectedTariffs.First(ct => ct.Id == connTariffId);
            if (connTariffToUnblock is not null)
            {
                connTariffToUnblock.IsBlocked = false;
                connTariffToUnblock.IsAutoblocked = false;
                _appDbContext.ConnectedTariffs.Update(connTariffToUnblock);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Указанной подключенной услуги не существует");
            }
        }

        public Task DeleteConnectedTariff(int connTariffId)
        {
            var connTariffToDelete = _appDbContext.ConnectedTariffs.First(t => t.Id == connTariffId);
            if (connTariffToDelete is not null)
            {
                _appDbContext.ConnectedTariffs.Remove(connTariffToDelete);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Указанной подключенной услуги не существует");
            }
        }
    }
}
