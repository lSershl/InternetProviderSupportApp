using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class AbonentCreateDto
    {
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string BirthPlace { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string PhoneNumberForSending { get; set; } = string.Empty;
        public string? Email { get; set; }
        [Required]
        public string PassportSeries { get; set; } = string.Empty;
        [Required]
        public string PassportNumber { get; set; } = string.Empty;
        [Required]
        public string PassportRegistration { get; set; } = string.Empty;
        [Required]
        public DateOnly PassportRegDate { get; set; }
        [Required]
        public string RegistrationAddress { get; set; } = string.Empty;
        public string? RegistrationZipCode { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string House { get; set; } = string.Empty;
        [Required]
        public string Apartment { get; set; } = string.Empty;
        [Required]
        public string HouseEntranceNumber { get; set; } = string.Empty;
        [Required]
        public string HouseFloorNumber { get; set; } = string.Empty;
        public string? AddressZipCode { get; set; }
        public string? SecretPhrase { get; set; }
        [Required]
        public bool SMSSending { get; set; } = false;
        public decimal Balance { get; init; } = 0;
    }
}
