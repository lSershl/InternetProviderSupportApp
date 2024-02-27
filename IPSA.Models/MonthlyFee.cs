using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSA.Models
{
    public class MonthlyFee
    {
        public required int Id { get; set; }
        public required int ConnectedTariffId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly ScheduledDay { get; set; }
        public bool IsCompleted { get; set; }

        public ConnectedTariff ConnectedTariff { get; set; } = null!;
    }
}
