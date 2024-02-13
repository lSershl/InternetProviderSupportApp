using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPSA.Models
{
    public class ConnectedTariff
    {
        public int Id { get; set; }
        public int AbonentId { get; set; }
        public int TariffId { get; set; }
        public required DateTime CreationDateTime { get; set; }
        public required string IpAddress { get; set; }
        public required string LinkToHardware { get; set; }
        public required bool IsBlocked { get; set;} = false;

        public Abonent Abonent { get; set; } = null!;
        public Tariff Tariff { get; set; } = null!;
    }
}
