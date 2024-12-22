using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project.Implementors
{
    public static class AdminOperations
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=ICS-LT-D244D6BH;Initial Catalog=Railway;" +
                "Integrated Security=true";
            return new SqlConnection(connectionString);
        }

        public static bool ValidateCredentials(string username, string password)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Admins WHERE AdminName = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int result = (int)cmd.ExecuteScalar();

                return result > 0;
            }
        }
        public static void AddTrain()
        {
            Console.WriteLine("\n------------------ Add Train --------------------");
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter Source: ");
            string source = Console.ReadLine();
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();
            Console.Write("Enter Train Date & Time (yyyy-MM-dd HH:mm): ");
            DateTime trainDateTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Price for AC Class: ");
            float priceAC = float.Parse(Console.ReadLine());
            Console.Write("Enter Price for Sleeper Class: ");
            float priceSleeper = float.Parse(Console.ReadLine());
            Console.Write("Enter Price for General Class: ");
            float priceGeneral = float.Parse(Console.ReadLine());
            Console.Write("Enter Total AC Seats: ");
            int acSeats = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Total Sleeper Seats: ");
            int sleeperSeats = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Total General Seats: ");
            int generalSeats = Convert.ToInt32(Console.ReadLine());

            string query = @"INSERT INTO Trains (TrainNumber, TrainName, Source, Destination, DateTime, PriceAC, PriceSleeper, PriceGeneral, SeatsAC, SeatsSleeper, SeatsGeneral)
                             VALUES (@TrainNumber, @TrainName, @Source, @Destination, @DateTime, @PriceAC, @PriceSleeper, @PriceGeneral, @SeatsAC, @SeatsSleeper, @SeatsGeneral)";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TrainNumber", trainNumber);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@DateTime", trainDateTime);
                cmd.Parameters.AddWithValue("@PriceAC", priceAC);
                cmd.Parameters.AddWithValue("@PriceSleeper", priceSleeper);
                cmd.Parameters.AddWithValue("@PriceGeneral", priceGeneral);
                cmd.Parameters.AddWithValue("@SeatsAC", acSeats);
                cmd.Parameters.AddWithValue("@SeatsSleeper", sleeperSeats);
                cmd.Parameters.AddWithValue("@SeatsGeneral", generalSeats);

                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("==================================Train added successfully!========================================");
            }
        }


        public static void ModifyTrain()
        {

            using (SqlConnection connection = GetConnection())
            {
                Console.WriteLine("-------------------Modify Trains ------------------------");
                string query1 = "SELECT * FROM Trains"; // Fetch all columns
                SqlCommand command = new SqlCommand(query1, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("\nAll Trains Details:");
                while (reader.Read())
                {
                    // Loop through all columns dynamically
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($" {reader[i]}, ");
                    }
                    Console.WriteLine(); // New line for each train
                }

                connection.Close();
            }
            Console.WriteLine("\n-------------- Modify Train -----------------");
            Console.Write("Enter Train Number to Modify: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter New Source: ");
            string source = Console.ReadLine();
            Console.Write("Enter New Destination: ");
            string destination = Console.ReadLine();
            Console.Write("Enter New Train Date & Time (yyyy-MM-dd HH:mm): ");
            DateTime trainDateTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter New Price for AC Class: ");
            float priceAC = float.Parse(Console.ReadLine());
            Console.Write("Enter New Price for Sleeper Class: ");
            float priceSleeper = float.Parse(Console.ReadLine());
            Console.Write("Enter New Price for General Class: ");
            float priceGeneral = float.Parse(Console.ReadLine());
            Console.Write("Enter New Total AC Seats: ");
            int acSeats = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Total Sleeper Seats: ");
            int sleeperSeats = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter New Total General Seats: ");
            int generalSeats = Convert.ToInt32(Console.ReadLine());

            string query = @"UPDATE Trains
                             SET TrainName = @TrainName, Source = @Source, Destination = @Destination, DateTime = @DateTime,
                                 PriceAC = @PriceAC, PriceSleeper = @PriceSleeper, PriceGeneral = @PriceGeneral,
                                 SeatsAC = @SeatsAC, SeatsSleeper = @SeatsSleeper, SeatsGeneral = @SeatsGeneral
                             WHERE TrainNumber = @TrainNumber ";

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TrainNumber", trainNumber);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);
                cmd.Parameters.AddWithValue("@DateTime", trainDateTime);
                cmd.Parameters.AddWithValue("@PriceAC", priceAC);
                cmd.Parameters.AddWithValue("@PriceSleeper", priceSleeper);
                cmd.Parameters.AddWithValue("@PriceGeneral", priceGeneral);
                cmd.Parameters.AddWithValue("@SeatsAC", acSeats);
                cmd.Parameters.AddWithValue("@SeatsSleeper", sleeperSeats);
                cmd.Parameters.AddWithValue("@SeatsGeneral", generalSeats);

                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("====================================Train modified successfully!====================================");
            }
        }

        public static void DeleteTrain()
        {
            Console.Write("Enter Train ID to Delete: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            // SQL Query to delete a train
            using (SqlConnection connection = GetConnection())
            {
                string query = "DELETE FROM Trains WHERE TrainNumber = @TrainNumber";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TrainNumber", trainNumber);

                connection.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("==========================Train deleted successfully!=================================");
            }
        }

        public static void ViewBookings()
        {
            Console.WriteLine("----------------------------All Bookings--------------------------");
            Console.WriteLine();
            // SQL Query to get bookings
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT BookingID, UserName, TrainNumber, Class, Status,SeatsBooked, BookingTime FROM Bookings where Status='Booked'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("BookingID| UserName | TrainNumber   | Class      | Status   | SeatsBooked | Date & Time");
                Console.WriteLine("------------------------------------------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["BookingID"]} | {reader["UserName"]} | {reader["TrainNumber"]} | {reader["Class"]} | {reader["Status"]} | |{reader["SeatsBooked"]} | {reader["BookingTime"]}");
                }

                connection.Close();
            }
        }
        public static void ViewCancellation()
        {
            Console.WriteLine("--------------------------------View Cancellations-------------------------------");
            Console.WriteLine();

            // SQL Query to get bookings
            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT BookingID, UserName, TrainNumber, Class, Status,SeatsBooked, BookingTime FROM Bookings where Status='Cancelled'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("BookingID| UserName | TrainNumber   | Class      | Status   | SeatsBooked | Date & Time");
                Console.WriteLine("------------------------------------------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["BookingID"]} | {reader["UserName"]} | {reader["TrainNumber"]} | {reader["Class"]} | {reader["Status"]} | |{reader["SeatsBooked"]} | {reader["BookingTime"]}");
                }

                connection.Close();
            }
        }

    
       


       
        public static void ShowAllTrains()
        {
            using (SqlConnection connection = GetConnection())
            {
              
                Console.WriteLine("------------------Show All Trains for book ------------------------");
                string query = "SELECT TrainNumber ,TrainName ,Source ,Destination ,DateTime  FROM Trains";

               
                    SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("Train Number | Train Name           | Source         | Destination    | Date & Time");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                while(reader.Read())
                {
                    Console.WriteLine($"{reader["TrainNumber"]} | {reader["TrainName"]} | {reader["Source"]} | {reader["Destination"]} | {reader["DateTime"]}");

                }


                connection.Close();

            }

        }
  
    }
}
