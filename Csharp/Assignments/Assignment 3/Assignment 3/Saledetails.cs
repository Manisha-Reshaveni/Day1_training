using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    class Saledetails
    {
        public int Salesno;
        public string Productname;
        public float Price;
        public DateTime DateofSale;
        public int Quantity;
        public float TotalAmount;

        public Saledetails(int salesno, string productname,float price,int quantity , DateTime Dateofsale)
        {
            Salesno = salesno;
            Productname = productname;
            Price = price;
            Quantity = quantity;
            DateofSale = Dateofsale;
          
        }
        public  void Sales(int quantity, float price)
        {
            Price = price;
            Quantity = quantity;
             TotalAmount = quantity * price;
            ShowData();
        }
        public void ShowData()
        {
            Console.WriteLine("**********PRODUCT DETAILS******");
            Console.WriteLine();
            Console.WriteLine("Enter Sales number: {0}", Salesno);
            Console.WriteLine("Enter Product number:{0} ", Productname);
            Console.WriteLine("Enter Price:{0} ", Price);
            Console.WriteLine("Quantity of product:{0} ", Quantity);
            Console.WriteLine("Enter Date of sale:{0} ", DateofSale);
            Console.WriteLine("TotalAmount:{0}", TotalAmount);
        }
    }
    class Details: Saledetails
    {
       
        public Details(int salesno, string productname, float price, int quantity, DateTime Dateofsale) : base(salesno, productname,price, quantity, Dateofsale)
            {
           
        }
   
    }
    
    class Mainmethod
    {
        public static void Main()
        {
            Console.WriteLine("Enter Sales number: ");
            int salesno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Product name: ");
            string productname = Console.ReadLine();
            Console.WriteLine("Enter Price: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantity of product: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Date of sale: ");
            DateTime Dateofsale = Convert.ToDateTime(Console.ReadLine());
            
          
            Details obj = new Details(salesno, productname,price,quantity, Dateofsale);
            obj.Sales(quantity,price);
            Console.Read();
        }
    }
}
