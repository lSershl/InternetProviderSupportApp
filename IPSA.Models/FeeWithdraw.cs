namespace IPSA.Models
{
    public class FeeWithdraw
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int ConnectedTariffId { get; set; }
        public required string Type { get; set; }
        public required string PricingModel { get; set; }
        public decimal Amount { get; set; }
        public DateTime CompletionDateTime { get; set; }

        public Abonent Abonent { get; set; } = null!;
        public ConnectedTariff ConnTariff { get; set; } = null!;
    }
}
