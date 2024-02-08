namespace IPSA.Shared.Dtos
{
    public class SearchAbonentFilter
    {
        public int? AbonentId { get; set; } = null;
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? City { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string? House { get; set; } = string.Empty;
        public string? Apartment { get; set; } = string.Empty;
    }
}
