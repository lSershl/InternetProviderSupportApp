using IPSA.Models;

namespace IPSA.Web.Services.Contracts
{
    public interface IAbonentService
    {
        Task<IEnumerable<Abonent>> GetAllAbonents();
        Task<Abonent> GetAbonent(int id);
    }
}
