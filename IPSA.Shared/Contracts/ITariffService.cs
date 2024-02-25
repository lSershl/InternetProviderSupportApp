using IPSA.Shared.Dtos;

namespace IPSA.Shared.Contracts
{
    public interface ITariffService
    {
        Task<List<TariffDto>> GetTariffsList(); 
    }
}
