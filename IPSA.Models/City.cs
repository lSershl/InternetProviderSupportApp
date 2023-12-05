using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    //[Table("Cities", Schema = "public")]
    public class City
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
