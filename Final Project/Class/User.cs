using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Class
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}  Email: {Email} Password: {Password} ";
        }
    }
}
