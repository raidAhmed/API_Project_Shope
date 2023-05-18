using Agricultural.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Markets  :IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? DescriptionAddress { get; set; }
        public int? CityId { get; set; }
        public int? DirectorateId { get; set; }
        public bool Active { get; set; }
        public List<News> News { get; set; }
        public Markets()
        {
            Active = true;
        }
    }
}
