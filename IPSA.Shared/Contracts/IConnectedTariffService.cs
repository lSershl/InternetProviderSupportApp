using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IConnectedTariffService
    {
        Task<List<ConnectedTariffDto>> GetConnectedTariffsListByAbonent(int abonId);
        Task<ServiceResponse> AddNewConnectedTariff(ConnectedTariffDto connTariffDto);
        Task<ServiceResponse> BlockAllAbonentConnectedTariffs(int abonId);
        Task<ServiceResponse> BlockConnectedTariff(int connTariffId);
        Task<ServiceResponse> UnblockConnectedTariff(int connTariffId);
        Task<ServiceResponse> DeleteConnectedTariff(int connTariffId);
        Task<ServiceResponse> DeleteAllConnectedTariffsForAbonent(int abonentId);
    }
}
