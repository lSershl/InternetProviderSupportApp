﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPSA.Models
{
    public class Abonent
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberForSending { get; set; }
        public string? Email { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string PassportRegistration { get; set; }
        public DateOnly PassportRegDate { get; set; }
        public string RegistrationAddress { get; set; }
        public string? RegistrationZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public string HouseEntranceNumber { get; set; }
        public string HouseFloorNumber { get; set; }
        public string? AddressZipCode { get; set; }
        public string? SecretPhrase { get; set; }
        public bool SMSSending { get; set; } = false;
        public decimal Balance { get; init; } = 0;
    }
}
