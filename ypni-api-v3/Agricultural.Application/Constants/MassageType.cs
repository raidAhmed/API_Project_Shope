using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.Constants
{
    public  class MassageType
    {
     
        public Dictionary<string,int> Getmassagetype()
        {
            Dictionary<string, int> massagetype = new Dictionary<string, int>();
            massagetype.Add("طلب منتج", 1);
             massagetype.Add("طلب أستشارة", 2);
             massagetype.Add("طلب دعم أو شكوى", 3);
            return massagetype;
        }
    }

}
