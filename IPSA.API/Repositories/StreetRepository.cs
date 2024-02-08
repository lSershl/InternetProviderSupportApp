using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSA.API.Repositories
{
    public class StreetRepository(AppDbContext appDbContext) : IStreetRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        public async Task<List<Street>> GetAllStreetsList()
        {
            var streets = await _appDbContext.Streets.ToListAsync();
            return streets;
        }

        public async Task<List<Street>> GetStreetsListByCity(int cityId)
        {
            var streets = await _appDbContext.Streets.Where(x => x.CityId == cityId).ToListAsync();
            return streets;
        }
    }
}
