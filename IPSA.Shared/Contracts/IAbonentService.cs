using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IAbonentService
    {
        Task<IEnumerable<AbonentReadDto>> GetAllAbonents();
        Task<AbonentReadDto> GetAbonent(int id);
        Task<ServiceResponse> AddNewAbonent(AbonentCreateDto abonentCreateDto);
    }
}
