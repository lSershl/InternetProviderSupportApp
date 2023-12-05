using IPSA.DataAccess.Data;
using IPSA.DataAccess.Repositories.Contracts;
using IPSA.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSA.DataAccess.Repositories
{
    public class AbonentRepository : IAbonentRepository
    {
        private readonly AppDbContext _appDbContext;

        public AbonentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

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

        
    }
}
