using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IDailyFeesRepository
    {
        Task CompleteDailyFees();
    }
}
