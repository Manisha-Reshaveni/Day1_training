using Mini_Project.Implementors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Factories
{
   public class Client
    {


        public static Menu GetUser(string userType)
        {
            if (userType.ToLower() == "admin")
            {

                return new AdminClass();
            }
            else if (userType.ToLower() == "user")
            {
                return new UserClass();
            }
            else
            {
                Console.WriteLine("Invalid user type");
            }
            return null;
        }
    }
}
