using System.ComponentModel.DataAnnotations;

namespace IPSA.Models
{
    public class Street
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CityId { get; set; }
    }
}
