using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPSA.Models
{
    public class Abonent
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string BirthPlace { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PhoneNumberForSending { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string PassportSeries { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string PassportRegistration { get; set; } = string.Empty;
        public DateOnly PassportRegDate { get; set; }
        public string RegistrationAddress { get; set; } = string.Empty;
        public string? RegistrationZipCode { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string House { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;
        public string HouseEntranceNumber { get; set; } = string.Empty;
        public string HouseFloorNumber { get; set; } = string.Empty;
        public string? AddressZipCode { get; set; }
        public string? SecretPhrase { get; set; }
        public bool SMSSending { get; set; } = false;
        public decimal Balance { get; set; } = 0;
    }
}
