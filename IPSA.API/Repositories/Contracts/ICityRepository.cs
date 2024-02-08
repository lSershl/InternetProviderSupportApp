using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface ICityRepository
    {
        Task<List<City>> GetCitiesList();
    }
}
