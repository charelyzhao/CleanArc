using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.Common.Models
{
    public record AuthResponse(string Token, DateTime Expiration);
}
