using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSA.API.Repositories
{
    public class AbonentRepository(AppDbContext appDbContext) : IAbonentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<IEnumerable<Abonent>> GetAllAbonents()
        {
            var abonents = await _appDbContext.Abonents.ToListAsync();
            return abonents;
        }

        public async Task<Abonent> GetAbonent(int id)
        {
            var abonent = await _appDbContext.Abonents.SingleOrDefaultAsync(a => a.Id == id);
            return abonent;
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
