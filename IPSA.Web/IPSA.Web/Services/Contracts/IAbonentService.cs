using IPSA.Web.Dtos;

namespace IPSA.Web.Services.Contracts
{
    public interface IAbonentService
    {
        Task<IEnumerable<AbonentReadDto>> GetAllAbonents();
        Task<AbonentReadDto> GetAbonent(int id);
        Task AddNewAbonent(AbonentCreateDto abonentCreateDto);
    }
}
