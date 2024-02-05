
namespace IPSA.Shared.Dtos
{
    public class AbonentReadDto
    {
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string HouseEntranceNumber { get; set; } = string.Empty;
        public string HouseFloorNumber { get; set; } = string.Empty;
        public string? SecretPhrase { get; set; }
        public decimal Balance { get; init; }
    }
}
