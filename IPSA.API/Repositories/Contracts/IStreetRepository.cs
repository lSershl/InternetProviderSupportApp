using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IStreetRepository
    {
        List<Street> GetAllStreetsList();
        List<Street> GetStreetsListByCity(int cityId);
    }
}
