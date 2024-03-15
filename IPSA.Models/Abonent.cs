using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPSA.Models
{
    public class Abonent
    {
        public int Id { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string BirthPlace { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PhoneNumberForSending { get; set; }
        public required string? Email { get; set; }
        public required string PassportSeries { get; set; }
        public required string PassportNumber { get; set; }
        public required string PassportRegistration { get; set; }
        public required DateOnly PassportRegDate { get; set; }
        public required string RegistrationAddress { get; set; }
        public string? RegistrationZipCode { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string House { get; set; }
        public required string Apartment { get; set; }
        public required string HouseEntranceNumber { get; set; }
        public required string HouseFloorNumber { get; set; }
        public string? AddressZipCode { get; set; }
        public string? SecretPhrase { get; set; }
        public bool SMSSending { get; set; } = false;
        public decimal Balance { get; set; } = 0;

        public List<ConnectedTariff> ConnectedTariffs { get; set; } = new();
        public List<AbonentRequest> AbonentRequests { get; set; } = new();
    }
}
