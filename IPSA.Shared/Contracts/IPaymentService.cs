using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAllPaymentsList();
        Task<PaymentDto> GetPayment(int paymentId);
        Task<ServiceResponse> AddNewPayment(PaymentDto paymentDto);
    }
}
