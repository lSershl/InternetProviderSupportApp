namespace IPSA.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required string Type { get; set; }
        public required string PricingModel { get; set; }
        public required decimal MonthlyPrice { get; set; }
        public required decimal DailyPrice { get; set; }
        public string? Description { get; set; }
        public required bool Archived { get; set;} = false;

        public List<ConnectedTariff> ConnectedTariffs { get; set; } = new();
    }
}
