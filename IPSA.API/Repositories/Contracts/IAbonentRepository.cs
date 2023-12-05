using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonentRepository
    {
        Task<IEnumerable<Abonent>> GetAllAbonents();
        Task<Abonent> GetAbonent(int id);
    }
}
