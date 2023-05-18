using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.ComplainantPic
{
    public class ComplainantPicQueryDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ComplainantToPartyId { get; set; }
    }
}
