﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agricultural.Domain.Entity
{
    public class ComplainantPic
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int? ComplainantToPartyId { get; set; }
        public bool Active { get; set; }
        public ComplainantToParty ComplainantToParty { get; set; }

        public ComplainantPic()
        {
            Active = true;
        }
    }
}
