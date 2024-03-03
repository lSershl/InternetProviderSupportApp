namespace IPSA.Models
{
    public class DailyFee
    {
        public int Id { get; set; }
        public int ConnectedTariffId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public bool IsCompleted { get; set; }

        public ConnectedTariff ConnectedTariff { get; set; } = null!;
    }
}
