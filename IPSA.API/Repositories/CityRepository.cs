using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSA.API.Repositories
{
    public class CityRepository(AppDbContext appDbContext) : ICityRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        public List<City> GetCitiesList()
        {
            var cities = _appDbContext.Cities.ToList();
            return cities;
        }
    }
}
