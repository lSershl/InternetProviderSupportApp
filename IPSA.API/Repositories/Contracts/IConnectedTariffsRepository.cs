using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IConnectedTariffsRepository
    {
        List<ConnectedTariff> GetConnectedTariffsListByAbonent(int abonId);
        ConnectedTariff GetConnectedTariffById(int connTariffId);
        Task CheckBalanceAndRemoveAutoblocksAfterPeayment(int abonentId);
        int AddConnectedTariff(ConnectedTariff connTariff);
        Task BlockConnectedTariff(int connTariffId);
        Task UnblockConnectedTariff(int connTariffId);
        Task DeleteConnectedTariff(int connTariffId);
    }
}
