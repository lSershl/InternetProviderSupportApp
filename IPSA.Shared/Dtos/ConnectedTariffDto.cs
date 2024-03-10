using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class ConnectedTariffDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int AbonentId { get; set; }
        [Required]
        public int TariffId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? IpAddress { get; set; }
        [Required]
        public string? LinkToHardware { get; set; }
        [Required]
        public string? PricingModel { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAutoblocked { get; set; }
    }
}
