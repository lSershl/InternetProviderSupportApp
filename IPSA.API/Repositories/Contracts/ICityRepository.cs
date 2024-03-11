using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface ICityRepository
    {
        List<City> GetCitiesList();
    }
}
