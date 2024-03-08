using IPSA.Models;
using IPSA.Shared.Dtos;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonentRepository
    {
        IEnumerable<Abonent> GetAllAbonents();
        Abonent GetAbonent(int id);
        IEnumerable<Abonent> GetAbonentsByFilter(SearchAbonentFilter filter);
        Task<Task> AddNewAbonent(Abonent newAbonent);
        Task UpdateAbonent(Abonent updAbonent);
    }
}
