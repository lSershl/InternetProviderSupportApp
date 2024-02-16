using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class AbonentRequestRepository(AppDbContext appDbContext) : IAbonentRequestRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<AbonentRequest> GetAllAbonentsRequestsList()
        {
            var abonRequests = _appDbContext.AbonentRequests.ToList();
            return abonRequests;
        }

        public List<AbonentRequest> GetRequestsListByDate(DateOnly date)
        {
            var abonRequests = _appDbContext.AbonentRequests.Where(d => d.CompletionDate == date).ToList();
            return abonRequests;
        }

        public List<AbonentRequest> GetRequestsListByAbonent(int abonId)
        {
            var abonRequests = _appDbContext.AbonentRequests.Where(r => r.AbonentId == abonId).ToList();
            return abonRequests;
        }

        public AbonentRequest GetRequestById(int requestId)
        {
            var abonRequest = _appDbContext.AbonentRequests.First(r => r.Id == requestId);
            return abonRequest!;
        }

        public Task CreateAbonentRequest(AbonentRequest abonentRequest)
        {
            _appDbContext.AbonentRequests.Add(abonentRequest);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAbonentRequest(AbonentRequest abonentRequest)
        {
            _appDbContext.AbonentRequests.Update(abonentRequest);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
