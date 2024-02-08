using IPSA.Shared.Dtos;

namespace IPSA.Shared.Contracts
{
    public interface IStreetService
    {
        Task<List<StreetReadDto>> GetAllStreetsList();
        Task<List<StreetReadDto>> GetStreetsListByCity(int cityId);
    }
}
