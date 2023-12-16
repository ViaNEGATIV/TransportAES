using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Identity
{
    public class Client : User
    {
        public Client(int user_Id, string user_Name, string user_Email) 
            : base(user_Id, user_Name, user_Email, nameof(Client))
        {
        }
    }
}
