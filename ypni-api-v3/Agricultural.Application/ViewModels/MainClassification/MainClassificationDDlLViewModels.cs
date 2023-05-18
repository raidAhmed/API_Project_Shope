using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.ViewModels.MainClassification
{
    public class MainClassificationDDlLViewModels
    {
        public int Id { get; set; }
        public string MainClassificationName { get; set; }
        public int ActivityTypeId { get; set; }
        public string ImageUrl { get; set; }
        public bool Active { get; set; }
    }
}
