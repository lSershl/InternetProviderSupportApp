using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public string? PaymentType { get; set; }
        public string? Comment { get; set; }
        public decimal Amount { get; set; }
        public bool Cancelled { get; set; }
    }
}
