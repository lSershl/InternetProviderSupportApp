using System.ComponentModel.DataAnnotations;

namespace IPSA.API.Dtos
{
    public class AbonentCreateDto
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PhoneNumberForSending { get; set; }
        public string? Email { get; set; }
        [Required]
        public string PassportSeries { get; set; }
        [Required]
        public string PassportNumber { get; set; }
        [Required]
        public string PassportRegistration { get; set; }
        [Required]
        public DateOnly PassportRegDate { get; set; }
        [Required]
        public string RegistrationAddress { get; set; }
        public string? RegistrationZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string House { get; set; }
        [Required]
        public string Apartment { get; set; }
        [Required]
        public string HouseEntranceNumber { get; set; }
        [Required]
        public string HouseFloorNumber { get; set; }
        public string? AddressZipCode { get; set; }
        public string? SecretPhrase { get; set; }
        [Required]
        public bool SMSSending { get; set; } = false;
        public decimal Balance { get; init; } = 0;
    }
}
