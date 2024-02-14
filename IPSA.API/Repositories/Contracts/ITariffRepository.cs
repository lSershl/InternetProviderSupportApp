using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface ITariffRepository
    {
        List<Tariff> GetTariffsList();
        Tariff GetTariffById(int tariffId);
        Task AddTariff(Tariff tariff);
        Task PutTariffInArchive(int tariffId);
    }
}
