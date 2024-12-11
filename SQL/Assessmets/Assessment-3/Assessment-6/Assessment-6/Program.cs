using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_6
{
    class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;

        public static void Main()
        {
            using (SqlConnection con = new SqlConnection("Server=ICS-LT-D244D6BH;initial catalog=Assessments; integrated security=true;"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_products", con))
                {

                    Console.WriteLine("Enter the product id:");
                    int Product_Id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the Product_name:");
                    String Product_Name = Console.ReadLine();
                    Console.WriteLine("Enter the Product price:");
                    float Price = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter the discounted Price:");
                    float Discounted_Price = Convert.ToSingle(Console.ReadLine());
                    Discounted_Price =Price-0.10f;



                    cmd.Parameters.Add(new SqlParameter("@productId", SqlDbType.Int)).Value = Product_Id;
                    cmd.Parameters.Add(new SqlParameter("@productName", SqlDbType.VarChar, 40)).Value = Product_Name;
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Float)).Value = Price;
                    cmd.Parameters.Add(new SqlParameter("@DiscountedPrice", SqlDbType.Float)).Value = Discounted_Price;

                }
            }
            Console.Read();
        }
    }
}
