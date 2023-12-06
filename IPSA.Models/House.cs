using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    public class House
    {
        [Key]
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CityId { get; set; }
        public required int DistId { get; set; }
        public required int StreetId { get; set; }
    }
}
