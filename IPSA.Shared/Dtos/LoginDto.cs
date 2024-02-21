using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class LoginDto
    {
        [Required (ErrorMessage = "Обязательное поле"), DataType(DataType.Text)]
        public string Login { get; set; } = string.Empty;
        [Required (ErrorMessage = "Обязательное поле"), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
