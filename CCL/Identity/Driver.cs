﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Identity
{
    public class Driver : User
    {
        public Driver(int user_Id, string user_Name, string user_Email, string role) 
            : base(user_Id, user_Name, user_Email, nameof(Driver))
        {
        }
    }
}
