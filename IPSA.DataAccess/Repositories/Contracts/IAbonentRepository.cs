using IPSA.Models;

namespace IPSA.DataAccess.Repositories.Contracts
{
    public interface IAbonentRepository
    {
        Task<IEnumerable<Abonent>> GetAllAbonents();
        Task<Abonent> GetAbonent(int id);
    }
}
