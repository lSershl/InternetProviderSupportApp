namespace IPSA.Shared.Dtos
{
    public class SearchAbonentFilter
    {
        public int? AbonentId { get; set; } = null;
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? Surname { get; set; } = null;
        public string? PhoneNumber { get; set; } = null;
        public string? City { get; set; } = null;
        public string? Street { get; set; } = null;
        public string? House { get; set; } = null;
        public string? Apartment { get; set; } = null;
    }
}
