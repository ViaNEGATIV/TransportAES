using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Identity
{
    public class User
    {
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string Role { get; set; }

        public User(int user_Id, string user_Name, string user_Email, string role)
        {
            User_Id = user_Id;
            User_Name = user_Name;
            User_Email = user_Email;
            Role = role;
        }
    }

}
