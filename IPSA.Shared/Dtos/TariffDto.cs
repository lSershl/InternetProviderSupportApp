using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class TariffDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public string? PricingModel { get; set; }
        [Required]
        public decimal MonthlyPrice { get; set; }
        [Required]
        public decimal DailyPrice { get; set; }
        public string? Description { get; set; }
    }
}
