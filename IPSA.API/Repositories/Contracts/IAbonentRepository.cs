using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonentRepository
    {
        Task<IEnumerable<Abonent>> GetAllAbonents();
        Task<Abonent> GetAbonent(int id);
        Task<Task> AddNewAbonent(Abonent newAbonent);
        Task UpdateAbonent(Abonent updAbonent);
    }
}
