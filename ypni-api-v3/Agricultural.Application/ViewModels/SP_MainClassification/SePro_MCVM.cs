using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.ViewModels.SP_MainClassification
{
    public class SePro_MCVM
    {
        public int ServiceProviderid { get; set; }
        public String ServiceProviderName { get; set; }
        public int MaiinClassId { get; set; }
        public string MainClassName { get; set; }
        public bool IsSelected { get; set; }
    }
}
