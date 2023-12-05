using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    //[Table("Streets", Schema = "public")]
    public class Street
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CityId { get; set; }
        public required int DistId { get; set; }
    }
}
