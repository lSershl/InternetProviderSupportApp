using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    //[Table("Districts", Schema = "public")]
    public class District
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CityId { get; set; }
    }
}
