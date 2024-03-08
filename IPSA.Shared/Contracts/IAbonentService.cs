using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IAbonentService
    {
        Task<IEnumerable<AbonentReadDto>> GetAllAbonents();
        Task<AbonentReadDto> GetAbonent(int abonId);
        Task<IEnumerable<AbonentReadDto>> GetAbonentsByFilter(SearchAbonentFilter filter);
        Task<AbonentCreateDto> GetAbonentForEdit(int abonId);
        Task<ServiceResponse> AddNewAbonent(AbonentCreateDto abonentCreateDto);
        Task<ServiceResponse> UpdateAbonent(int abonId, AbonentCreateDto abonentToUpdateDto);
        Task<ServiceResponse> ApplyPaymentToAbonentBalance(PaymentDto paymentDto);
    }
}
