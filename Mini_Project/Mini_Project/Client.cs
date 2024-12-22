using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Mini_Project.Factories;

namespace Mini_Project
{

    public class Client
    {

        public static void Main()
        {

            Console.WriteLine("============== Railway Reservation System ==============");
            Console.Write("Enter Type (Admin/User or Exit to quit): ");
            string userType = Console.ReadLine();

            if (userType.ToLower() == "exit")
            {
                Console.WriteLine("----------------------Exiting  from the  Railway Reservation System !----------------------");
                return;
            }

            else 
            {
                var user = Factories.Client.GetUser(userType);
                user.PerformActions();
            }
            Console.Read();
        }

       
    }
    
}
