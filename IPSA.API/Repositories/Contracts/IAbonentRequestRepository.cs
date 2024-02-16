using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonentRequestRepository
    {
        List<AbonentRequest> GetAllAbonentsRequestsList();
        List<AbonentRequest> GetRequestsListByDate(DateOnly date);
        List<AbonentRequest> GetRequestsListByAbonent(int abonId);
        AbonentRequest GetRequestById(int requestId);
        Task CreateAbonentRequest(AbonentRequest abonentRequest);
        Task UpdateAbonentRequest(AbonentRequest abonentRequest);
    }
}
