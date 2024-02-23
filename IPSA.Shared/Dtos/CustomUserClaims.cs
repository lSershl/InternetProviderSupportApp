using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSA.Shared.Dtos
{
    public record CustomUserClaims (string Id = null!, string Name = null!, string Role = null!);
}
