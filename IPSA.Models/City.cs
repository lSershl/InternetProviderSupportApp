using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    public class City
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
    }
}
