using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ProFeatures
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }

        public List<SP_ProFeatures> SP_ProFeatures { get; set; }

    }
}
