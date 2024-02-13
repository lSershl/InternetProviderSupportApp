using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPaymentsList();
        List<Payment> GetPaymentsListByAbonent(int abonId);
        Payment GetPaymentById(int paymentId);
        Task AddNewPayment(Payment payment);
        Task CancelPayment(int paymentId);
    }
}
