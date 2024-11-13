using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment2
{ 
    class Products
    {
        public int ProductID;
     public int[] Price = new int[10];
        protected string[] Product = new string[10];
        public void Productsmethod()
        {
            
            for (int i = 0; i < Product.Length; i++)
            {
             
                Console.Write("Enter Product {0} name: ", i + 1);
                Product[i] = Console.ReadLine();
              
            }
            Productsprice();
        }
    public void Productsprice()
    {

        for (int i = 0; i < Price.Length; i++)
        {
            Console.Write("Enter Product {0} price: ", i + 1);
            Price[i] = Convert.ToInt32(Console.ReadLine());
        }

    }
    public void show()
        {
            Console.WriteLine("------After sort the price details-------");
            Array.Sort(Price);
            foreach (var p in Price)
            {
                Console.WriteLine(p);
               
            }
        }

        public static void Main()
        {
            Console.WriteLine("Enter productid:");
            int proID = Convert.ToInt32(Console.ReadLine());
            Products productobj = new Products();
            productobj.Productsmethod();                   
            productobj.show();
            Console.Read();

        }
    }
}
