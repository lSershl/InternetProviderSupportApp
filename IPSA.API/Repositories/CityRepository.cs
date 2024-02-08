using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSA.API.Repositories
{
    public class CityRepository(AppDbContext appDbContext) : ICityRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        public async Task<List<City>> GetCitiesList()
        {
            var cities = await _appDbContext.Cities.ToListAsync();
            return cities;
        }
    }
}
