using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IPaymentsRepository
    {
        Task<List<Payment>> GetAllPaymentsList();
        Task<Payment> GetPayment(int id);
        Task AddNewPayment(Payment payment);
        Task CancelPayment(int paymentId);
    }
}
