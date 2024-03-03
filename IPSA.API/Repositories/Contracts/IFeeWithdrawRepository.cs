using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IFeeWithdrawRepository
    {
        List<FeeWithdraw> GetWithdrawsListByAbonent(int abonId);
        FeeWithdraw GetWithdrawById(int feeWithdrawId);
        Task AddNewFeeWithdrawRecord(FeeWithdraw feeWithdraw);
        Task ApplyBalanceWithdraw(FeeWithdraw feeWithdraw);
        decimal CalculateRefundAmount(FeeWithdraw feeWithdraw);
        Task ApplyRefund(int abonId, decimal amount);
    }
}
