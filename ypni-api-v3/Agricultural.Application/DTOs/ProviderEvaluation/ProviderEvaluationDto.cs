using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ProviderEvaluation
{
    public class ProviderEvaluationDto
    {
        public int Id { get; set; }
        public int value { get; set; }
        public int ServiceProviderId { get; set; }
        public String UserId { get; set; }
    }
}
