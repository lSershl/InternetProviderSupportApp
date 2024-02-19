using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSA.Shared.Dtos
{
    public class DateDto
    {
        public DateTime DateWithTime { get; set; }
        public DateOnly DateOnly { get; set; }
    }
}
