using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class ConnectedTariffDto
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int TariffId { get; set; }
        public string? Name { get; set; }
        public string? IpAddress { get; set; }
        public string? LinkToHardware { get; set; }
        public string? PricingModel { get; set; }
        public decimal MonthlyPrice { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsAutoblocked { get; set; }
    }
}
