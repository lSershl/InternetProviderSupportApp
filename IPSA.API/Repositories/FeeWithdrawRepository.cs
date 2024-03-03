using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class FeeWithdrawRepository(AppDbContext appDbContext) : IFeeWithdrawRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public FeeWithdraw GetWithdrawById(int feeWithdrawId)
        {
            var feeWithdraw = _appDbContext.FeeWithdraws.First(x => x.Id == feeWithdrawId);
            return feeWithdraw;
        }

        public List<FeeWithdraw> GetWithdrawsListByAbonent(int abonId)
        {
            var feeWithdrawsList = _appDbContext.FeeWithdraws.Where(x => x.AbonentId == abonId).ToList();
            return feeWithdrawsList;
        }

        public Task AddNewFeeWithdrawRecord(FeeWithdraw feeWithdraw)
        {
            _appDbContext.FeeWithdraws.Add(feeWithdraw);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task ApplyBalanceWithdraw(FeeWithdraw feeWithdraw)
        {
            var abonent = _appDbContext.Abonents.First(a => a.Id == feeWithdraw.AbonentId);
            abonent.Balance -= feeWithdraw.Amount;
            _appDbContext.Update(abonent);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public decimal CalculateRefundAmount(FeeWithdraw feeWithdraw)
        {
            DateTime now = DateTime.UtcNow;
            var nextScheduledMonthlyFee = _appDbContext.MonthlyFees.First(mf => mf.ConnectedTariffId == feeWithdraw.ConnectedTariffId && mf.IsCompleted.Equals(false));

            if ((now.Day - feeWithdraw.CompletionDateTime.Day) <= 0)
            {
                return feeWithdraw.Amount;
            }

            TimeSpan remainingDays = nextScheduledMonthlyFee.ScheduledDate.ToDateTime(TimeOnly.MinValue) - now;
            decimal refund = (feeWithdraw.Amount / 30) * remainingDays.Days;
            return refund;
        }

        public Task ApplyRefund(int abonId, decimal amount)
        {
            var abonent = _appDbContext.Abonents.First(a => a.Id.Equals(abonId));
            abonent.Balance += amount;
            _appDbContext.Update(abonent);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
