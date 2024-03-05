namespace IPSA.Shared.Dtos
{
    public class FeeWithdrawRecordDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? PricingModel { get; set; }
        public decimal Amount { get; set; }
        public DateTime CompletionDateTime { get; set; }
    }
}
