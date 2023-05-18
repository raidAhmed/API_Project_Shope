using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class SP_Address
    {
        public int Id { get; set; }
        public int DirectorateId { get; set; }
        public string Street { get; set; }
        public string UserId { get; set; }
        public string? Description { get; set; }
        public bool? State { get; set; }
        public bool Active { get; set; }
        public User User { get; set; }

        public Directorate Directorate { get; set; }

        public SP_Address()
        {
            Active = true;
        }

    }
}
