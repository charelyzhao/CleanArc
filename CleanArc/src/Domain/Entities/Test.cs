using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Entities
{
    public class Test: BaseAuditableEntity
    {
        public string? Name { get; set; }

        public string? Age { get; set; }
    }
}
