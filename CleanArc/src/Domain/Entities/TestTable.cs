using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Entities
{
    public class TestTable: BaseAuditableEntity
    {
        public string? Name { get; set; }
    }
}
