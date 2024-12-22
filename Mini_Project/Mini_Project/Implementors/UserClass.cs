using Mini_Project.Factories;
using Mini_Project.Implementors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{

    public class UserClass : Menu
    {
        public void PerformActions()
        {
            Console.WriteLine("Welcome, User!");
            while (true)
            {
                Console.WriteLine("\n1. Book Ticket\n2. Cancel Ticket\n3. ViewBookings\n4. ShowAllTrains\n5.Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:
                        UserOperations.BookTicket();
                        break;
                    case 2:
                        UserOperations.CancelTicket();
                        break;
                    case 3:
                        AdminOperations.ViewBookings();
                        break;
                    case 4:
                        AdminOperations.ShowAllTrains();
                        break;
                    case 5:
                        Console.WriteLine("---------------------Exiting User menu. Goodbye!----------------------");
                        return; // Exits User actions
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
    
}
