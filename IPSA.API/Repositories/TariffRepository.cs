using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class TariffRepository(AppDbContext appDbContext) : ITariffRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<Tariff> GetTariffsList()
        {
            var tariffsList = _appDbContext.Tariffs.ToList();
            return tariffsList;
        }

        public Tariff GetTariffById(int tariffId)
        {
            var tariff = _appDbContext.Tariffs.First(x => x.Id == tariffId);
            return tariff;
        }

        public Task AddTariff(Tariff tariff)
        {
            _appDbContext.Tariffs.Add(tariff);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task PutTariffInArchive(int tariffId)
        {
            var tariffToArchive = _appDbContext.Tariffs.First(t => t.Id == tariffId);
            if (tariffToArchive is not null)
            {
                tariffToArchive.Archived = true;
                _appDbContext.Tariffs.Update(tariffToArchive);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Такого тарифа не существует");
            }
        }
    }
}
