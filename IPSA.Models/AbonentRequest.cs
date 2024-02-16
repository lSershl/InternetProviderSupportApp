using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSA.Models
{
    public class AbonentRequest
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int EmployeeId { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required DateTime LastUpdateDateTime { get; set; }
        public required DateOnly CompletionDate { get; set; }
        public required string CompletionTimePeriod { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }

        public Abonent Abonent { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
    }
}
