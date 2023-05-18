using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Application.DTOs.SP_User_Favourites
{
    public class SP_User_FavouritesDto
    {
        public int Id { get; set; }
        public String UserId { get; set; }
        public int ServiceProviderId { get; set; }
        public DateTime Date { get; set; }
    }
}
