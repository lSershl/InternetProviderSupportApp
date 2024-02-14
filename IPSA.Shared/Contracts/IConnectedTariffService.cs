using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IConnectedTariffService
    {
        Task<List<ConnectedTariffDto>> GetConnectedTariffsListByAbonent(int abonId);
        Task<ServiceResponse> AddNewConnectedTariff(ConnectedTariffDto connTariffDto);
    }
}
