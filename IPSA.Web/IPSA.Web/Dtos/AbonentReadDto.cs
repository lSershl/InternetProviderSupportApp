
namespace IPSA.Web.Dtos
{
    public class AbonentReadDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string HouseEntranceNumber { get; set; }
        public string HouseFloorNumber { get; set; }
        public string? SecretPhrase { get; set; }
        public decimal Balance { get; init; }
    }
}
