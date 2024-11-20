using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public Box(int l,int b)
        {
            this.Length = l;
            this.Breadth = b;
        }
        public static void Boxs()
        {
           
        }
    }
}
//2.Write a class Box that has Length and breadth as its members. Write a function that adds 
//    2 box objects and stores in the 3rd.
//    Display the 3rd object details. Create a Test class to execute the above.