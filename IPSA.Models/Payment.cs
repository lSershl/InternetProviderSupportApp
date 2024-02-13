using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public required int AbonentId { get; set; }
        public required int ManagerId { get; set; }
        public required DateTime PaymentDateTime { get; set; }
        public required string PaymentType { get; set; }
        public string? Comment { get; set; }
        public required decimal Amount { get; set; }
        public required bool Cancelled { get; set;} = false;
    }
}
