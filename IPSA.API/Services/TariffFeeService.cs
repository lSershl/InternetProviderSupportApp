using IPSA.API.Services.Contarcts;
using IPSA.Models;

namespace IPSA.API.Services
{
    public class TariffFeeService : ITariffFeeService
    {
        public Task CheckDailyFees()
        {
            throw new NotImplementedException();
        }

        public List<MonthlyFee> CheckIncompleteMonthlyFees()
        {
            throw new NotImplementedException();
        }

        public Task CollectFees()
        {
            throw new NotImplementedException();
        }
    }
}
