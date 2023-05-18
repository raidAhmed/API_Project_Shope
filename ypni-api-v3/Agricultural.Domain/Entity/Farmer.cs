using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class Farmer
    {
        public int Id { get; set; }
        public string EarthLength { get; set; }
        public string EarthInfo { get; set; }
        public string EarthWidth { get; set; }
        public int? ServiceProviderId { get; set; }
        public bool Active { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public List<SupportRequest> SupportRequests { get; set; }
        public List<ConsultationRequest> ConsultationRequests { get; set; }

        public Farmer()
        {
            Active = true;
        }
    }
}
