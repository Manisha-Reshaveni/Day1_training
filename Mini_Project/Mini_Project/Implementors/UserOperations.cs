using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Implementors
{
    class UserOperations
    {
        private static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=ICS-LT-D244D6BH;Initial Catalog=Railway;" +
                "Integrated Security=true";
            return new SqlConnection(connectionString);
        }
       
        public static void BookTicket()
        {
                Console.WriteLine("\n------------------- Book Ticket -----------------------");
                Console.Write("Enter Your Source: ");
                string source = Console.ReadLine();
                Console.Write("Enter Train Destination: ");
                string destination = Console.ReadLine();

                bool trainFound = false;

                using (SqlConnection connection = GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT TrainNumber, TrainName, Source, Destination, DateTime FROM Trains WHERE Source = @Source AND Destination = @Destination",
                        connection);
                    cmd.Parameters.AddWithValue("@Source", source);
                    cmd.Parameters.AddWithValue("@Destination", destination);

                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        trainFound = true;
                        Console.WriteLine("------------------------Available Trains------------------------");
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["TrainNumber"]} | {dr["TrainName"]} | {dr["Source"]} | {dr["Destination"]} | {dr["DateTime"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------No trains are available--------------------");
                    }

                    dr.Close();
                    connection.Close();
                }

                if (trainFound)
                {
                    Console.Write("Enter Number of Seats to Book: ");
                    int seatsToBook = Convert.ToInt32(Console.ReadLine());

                    if (seatsToBook <= 0)
                    {
                        Console.WriteLine("Invalid number of seats. Please try again.");
                        return;
                    }

                    Console.Write("Enter Train Number: ");
                    int trainNumber = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Class (AC/Sleeper/General): ");
                    string trainClass = Console.ReadLine();
           

                using (SqlConnection connection = GetConnection())
                    {
                        connection.Open();

                        for (int i = 1; i <= seatsToBook; i++)
                        {
                            Console.Write($"Enter Name for Passenger {i}: ");
                            string userName = Console.ReadLine();

                            SqlCommand cmd2 = new SqlCommand("BookTicket", connection)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            cmd2.Parameters.AddWithValue("@UserName", userName);
                            cmd2.Parameters.AddWithValue("@TrainNumber", trainNumber);
                            cmd2.Parameters.AddWithValue("@Class", trainClass);
                            cmd2.Parameters.AddWithValue("@SeatsToBook", seatsToBook);

                            SqlParameter bookingParam = new SqlParameter("@bookingstatus", SqlDbType.VarChar, 50)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd2.Parameters.Add(bookingParam);

                            cmd2.ExecuteNonQuery();
                            string status = Convert.ToString(bookingParam.Value);

                            Console.WriteLine($"-----------------Booking Status for Passenger {i}: {status}--------------------");
                            Console.WriteLine($"----Passenger {i}: {userName}, Train: {trainNumber} ({trainClass} Class)----");
                        }

                        connection.Close();
                    }

                }  
        }

        public static void CancelTicket()
        {
            AdminOperations.ViewBookings();
            Console.WriteLine();
            Console.WriteLine("----------------------------Cancellation-------------------------------------");
          
            Console.Write("Enter username to Cancel: ");
            string username = Console.ReadLine();
            Console.Write("Enter Booking ID to Cancel: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("CancelBooking", connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    SqlParameter cancelgparam = new SqlParameter("@printoutput", SqlDbType.VarChar, 50);
                    cancelgparam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(cancelgparam);

                   
                    cmd.ExecuteNonQuery();
                    string Status = Convert.ToString(cancelgparam.Value);
                    Console.WriteLine($"{Status} ");

                    Console.WriteLine($"--------------Details--------------\nUser: {username}     bookingId: {bookingId} ");

                    connection.Close();

                }
            }

        }
    }
   
}
