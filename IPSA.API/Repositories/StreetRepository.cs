using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class StreetRepository(AppDbContext appDbContext) : IStreetRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<Street> GetAllStreetsList()
        {
            var streets = _appDbContext.Streets.ToList();
            return streets;
        }

        public List<Street> GetStreetsListByCity(int cityId)
        {
            var streets = _appDbContext.Streets.Where(x => x.CityId == cityId).ToList();
            return streets;
        }
    }
}
