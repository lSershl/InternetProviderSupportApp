using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using Microsoft.EntityFrameworkCore;

namespace IPSA.API.Repositories
{
    public class PaymentsRepository(AppDbContext appDbContext) : IPaymentsRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public async Task<List<Payment>> GetAllPaymentsList()
        {
            var payments = await _appDbContext.Payments.ToListAsync();
            return payments;
        }

        public async Task<Payment> GetPayment(int paymentId)
        {
            var payment = _appDbContext.Payments.FirstOrDefault(p => p.Id == paymentId);
            return payment!;
        }

        public Task AddNewPayment(Payment payment)
        {
            _appDbContext.Payments.Add(payment);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task CancelPayment(int paymentId)
        {
            var paymentToDelete = _appDbContext.Payments.FirstOrDefault(p => p.Id == paymentId);
            if (paymentToDelete is not null)
            {
                _appDbContext.Payments.Remove(paymentToDelete);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Платёж не существует");
            }
        }
    }
}
