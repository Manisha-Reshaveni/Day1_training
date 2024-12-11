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

                    cmd.Parameters.Add(new SqlParameter("@ename", SqlDbType.VarChar, 10)).Value = "manisha";
                    cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.Int)).Value = 5000;
                 
                    SqlParameter param1 = new SqlParameter("@pid", SqlDbType.Int);
                    param1.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param1);
                    SqlParameter param2 = new SqlParameter("@discount", SqlDbType.Float);
                    param2.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param2);
                    cmd.ExecuteNonQuery();
                    int product_id = Convert.ToInt32(cmd.Parameters["@pid"].Value);
                    int discount = Convert.ToInt32(cmd.Parameters["@discount"].Value);
                    Console.WriteLine($"Product ID : {product_id}  ,  Discount Price : {discount}");

                }
            }
            Console.Read();
        }
    }
}
