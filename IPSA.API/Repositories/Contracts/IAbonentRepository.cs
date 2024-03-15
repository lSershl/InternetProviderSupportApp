using IPSA.Models;
using IPSA.Shared.Dtos;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonentRepository
    {
        IEnumerable<Abonent> GetAllAbonents();
        IEnumerable<Abonent> GetAbonentsByFilter(SearchAbonentFilter filter);
        Abonent GetAbonent(int id);
        Task AddNewAbonent(Abonent newAbonent);
        Task UpdateAbonent(Abonent updAbonent);
    }
}
