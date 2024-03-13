using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class PaymentRepository(AppDbContext appDbContext) : IPaymentRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<Payment> GetAllPaymentsList()
        {
            var payments = _appDbContext.Payments.ToList();
            return payments;
        }

        public List<Payment> GetPaymentsListByAbonent(int abonId)
        {
            var payments = _appDbContext.Payments.Where(x => x.AbonentId == abonId).ToList();
            return payments;
        }

        public Payment GetPaymentById(int paymentId)
        {
            var payment = _appDbContext.Payments.First(p => p.Id == paymentId);
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
            var paymentToCancel = _appDbContext.Payments.First(p => p.Id == paymentId);
            if (paymentToCancel is not null)
            {
                paymentToCancel.Cancelled = true;
                _appDbContext.Payments.Update(paymentToCancel);

                var abonent = _appDbContext.Abonents.Where(a => a.Id == paymentToCancel.AbonentId).First();
                abonent.Balance = abonent.Balance - paymentToCancel.Amount;
                _appDbContext.Abonents.Update(abonent);

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
