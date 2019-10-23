using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5EP
{
    class User
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            this.UserName = name;
            this.Email = email;
        }
    }
}
