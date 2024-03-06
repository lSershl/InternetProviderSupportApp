using System.ComponentModel.DataAnnotations;

namespace IPSA.Shared.Dtos
{
    public class AbonentRequestDto
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public DateOnly CompletionDate { get; set; }
        public string CompletionTimePeriod { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(100, ErrorMessage = "Описание заявки не должно быть длиннее 100 символов")]
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string AllocatedEngineer {  get; set; } = string.Empty;
    }
}
