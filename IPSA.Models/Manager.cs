using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    //[Table ("Managers", Schema = "public")]
    public class Manager
    {
        [Key]
        public required int Id { get; set; }
        public required string FullName { get; set; }
        public required string ShortName { get; set; }
        public required DateTime RegistrationDateTime { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
