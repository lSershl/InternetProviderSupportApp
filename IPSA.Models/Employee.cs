using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required int DepartmentId { get; set; }
        public required string FullName { get; set; }
        public required string ShortName { get; set; }
        public required DateTime RegistrationDateTime { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }

        public Department Department { get; set; } = null!;
        public List<AbonentRequest> AbonentRequests { get; set; } = new();
    }
}
