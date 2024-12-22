using Mini_Project.Factories;
using Mini_Project.Implementors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
  
    public class AdminClass : Menu
    {

        public void PerformActions()
        {
            Console.Write("Enter Admin Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Admin Password: ");
            string password = Console.ReadLine();

            if (AdminOperations.ValidateCredentials(username, password))
            {
                Console.WriteLine("--------------------Login Successful!----------------------");
                while (true)
                {
           
                    Console.WriteLine("\n1. Add Train\n2. Modify Train\n3. Delete Train\n4. ShowAllTrains\n5.ViewBookings\n6.ViewCancellation\n7.Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AdminOperations.AddTrain();
                            break;
                        case 2:
                            AdminOperations.ModifyTrain();
                            break;
                        case 3:
                            AdminOperations.DeleteTrain();
                            break;
                        case 4:
                            AdminOperations.ShowAllTrains();
                            break;
                        case 5:
                            AdminOperations.ViewBookings(); 
                            break;
                        case 6:
                            AdminOperations.ViewCancellation();
                            break;
                        case 7:
                            Console.WriteLine("--------------------------------------Exiting Admin menu-----------------------------"); 
                            return; // Exits Admin actions
                        default:
                            Console.WriteLine("Invalid choice! Please try again.");
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid Username or Password.");
            }  
        }
    }
}

