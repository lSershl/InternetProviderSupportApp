using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPSA.Models
{
    //[Table("Abonents", Schema = "public")]
    public class Abonent
    {
        [Key]
        public required int Id { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required DateOnly DateOfBirth { get; set; }
        public required string BirthPlace { get; set; }
        public required string PhoneNumber { get; set; }
        public required string PhoneNumberForSending { get; set; }
        public string? Email { get; set; }
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
        public required bool SMSSending { get; set; } = false;
        public required decimal Balance { get; init; } = 0;
    }
}
