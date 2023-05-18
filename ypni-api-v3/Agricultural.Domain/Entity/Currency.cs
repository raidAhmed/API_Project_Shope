using Agricultural.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Currency : AuditableEntity, IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Currency() {
            Active = true;
        }
    }
}
