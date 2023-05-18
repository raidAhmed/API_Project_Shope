using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<Directorate> Directorates { get; set; }
        public City()
        {
            Active = true;
        }
    }
}
