using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class AbonentCreateDto
    {
        [Required (ErrorMessage = "Обязательное поле")]
        [MaxLength(50, ErrorMessage = "Фамилия не должна быть длиннее 50 символов")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(50, ErrorMessage = "Имя не должно быть длиннее 50 символов")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(50, ErrorMessage = "Отчество не должно быть длиннее 50 символов")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? BirthPlace { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? PhoneNumberForSending { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(4)]
        public string? PassportSeries { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(6)]
        public string? PassportNumber { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? PassportRegistration { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public DateOnly PassportRegDate { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? RegistrationAddress { get; set; }
        public string? RegistrationZipCode { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? House { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? Apartment { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? HouseEntranceNumber { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string? HouseFloorNumber { get; set; }
        public string? AddressZipCode { get; set; }
        public string? SecretPhrase { get; set; }
        public bool SMSSending { get; set; } = false;
    }
}
