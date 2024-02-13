using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class PaymentDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AbonentId { get; set; }
        public int? ManagerId { get; set; }
        [Required]
        public DateTime PaymentDateTime { get; set; }
        [Required]
        public string? PaymentType { get; set; }
        public string? Comment { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public bool Cancelled { get; set; }
    }
}
