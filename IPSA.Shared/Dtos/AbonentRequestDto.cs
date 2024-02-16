namespace IPSA.Shared.Dtos
{
    public class AbonentRequestDto
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateOnly CompletionDate { get; set; }
        public required string CompletionTimePeriod { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
    }
}
