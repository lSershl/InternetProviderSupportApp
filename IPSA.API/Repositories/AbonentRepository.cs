using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace IPSA.API.Repositories
{
    public class AbonentRepository(AppDbContext appDbContext) : IAbonentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public IEnumerable<Abonent> GetAllAbonents()
        {
            var abonents = _appDbContext.Abonents.ToList();
            return abonents;
        }

        public Abonent GetAbonent(int id)
        {
            var abonent = _appDbContext.Abonents.First(a => a.Id == id);
            return abonent;
        }

        public IEnumerable<Abonent> GetAbonentsByFilter(SearchAbonentFilter filter)
        {
            var result = _appDbContext.Abonents.AsEnumerable();
            if (filter is not null)
            {
                if (filter.AbonentId.HasValue)
                    result = result.Where(x => x.Id == filter.AbonentId);
                if (!string.IsNullOrEmpty(filter.LastName))
                    result = result.Where(x => x.LastName.ToLower().Contains(filter.LastName.ToLower()));
                if (!string.IsNullOrEmpty(filter.FirstName))
                    result = result.Where(x => x.FirstName.ToLower().Contains(filter.FirstName.ToLower()));
                if (!string.IsNullOrEmpty(filter.Surname))
                    result = result.Where(x => x.Surname.ToLower().Contains(filter.Surname.ToLower()));
                if (!string.IsNullOrEmpty(filter.PhoneNumber))
                    result = result.Where(x => x.PhoneNumber.ToLower().Contains(filter.PhoneNumber.ToLower()));
                if (!string.IsNullOrEmpty(filter.City))
                    result = result.Where(x => x.City.ToLower().Contains(filter.City.ToLower()));
                if (!string.IsNullOrEmpty(filter.Street))
                    result = result.Where(x => x.Street.ToLower().Contains(filter.Street.ToLower()));
                if (!string.IsNullOrEmpty(filter.House))
                    result = result.Where(x => x.House.ToLower().Contains(filter.House.ToLower()));
                if (!string.IsNullOrEmpty(filter.Apartment))
                    result = result.Where(x => x.Apartment.ToLower().Contains(filter.Apartment.ToLower()));
            }
            return result;
        }

        public async Task<Task> AddNewAbonent(Abonent newAbonent)
        {
            await _appDbContext.Abonents.AddAsync(newAbonent);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAbonent(Abonent updAbonent)
        {
            _appDbContext.Abonents.Update(updAbonent);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
