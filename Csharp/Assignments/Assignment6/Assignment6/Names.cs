using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Names
    {
        static void Main()
        {
            Console.WriteLine("Enter List length:");
            int length = Convert.ToInt32(Console.ReadLine());

            List<string> Name = new List<string> { };
            for (int i = 0; i < length; i++)
            {

                Console.WriteLine("enter list inputs:{0}" , i+1);
                string names = Console.ReadLine();
                Name.Add(names);

            }

            //foreach (string n in Name)
            //{
            //    if(n.StartsWith("a" && n.EndsWith("m")))
            //    Console.WriteLine("Name starts with a:" + n);
            //}
            IEnumerable<string> sname = from n in Name
                                        where n.StartsWith("a") && n.EndsWith("m")
                                        select n;
            foreach(var n in sname)
            {
                Console.WriteLine("Name starts with `a` and ends with `m`:" + n);
            }
        

            Console.Read();
        }
    }
}

