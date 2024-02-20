using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IAbonentRequestService
    {
        Task<List<AbonentRequestDto>> GetAllAbonentsRequests();
        Task<List<AbonentRequestDto>> GetAbonentRequests(int abonId);
        Task<List<AbonentRequestDto>> GetAbonentRequestsByDate(DateDto dateDto);
        Task<List<AbonentRequestDto>> GetAbonentRequestsByDatePeriod(DatePeriodDto datePeriodDto);
        Task<AbonentRequestDto> GetAbonentRequestById(int requestId);
        Task<ServiceResponse> CreateAbonentRequest(AbonentRequestDto abonentRequestDto);
        Task<ServiceResponse> UpdateAbonentRequest(AbonentRequestDto abonentRequestDto);
    }
}
