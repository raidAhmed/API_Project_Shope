using Agricultural.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Agricultural.Domain.Entity
{
    public class Directorate : IBaseEntity<int>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }
        public bool Active { get; set; }
        public List<SP_Address> SP_Address { get; set; }
        public Directorate()
        {
            Active = true;
        }

    }
}
