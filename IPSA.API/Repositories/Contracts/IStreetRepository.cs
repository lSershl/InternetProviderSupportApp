using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IStreetRepository
    {
        Task<List<Street>> GetAllStreetsList();
        Task<List<Street>> GetStreetsListByCity(int cityId);
    }
}
