using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonentRepository
    {
        IEnumerable<Abonent> GetAllAbonents();
        Abonent GetAbonent(int id);
        Task<Task> AddNewAbonent(Abonent newAbonent);
        Task UpdateAbonent(Abonent updAbonent);
    }
}
