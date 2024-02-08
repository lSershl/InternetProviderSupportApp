using IPSA.Shared.Dtos;

namespace IPSA.Shared.Contracts
{
    public interface ICityService
    {
        Task<List<CityReadDto>> GetCitiesList();
    }
}
