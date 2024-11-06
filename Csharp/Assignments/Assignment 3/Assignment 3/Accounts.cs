using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{

    class Accounts
    {
        protected int Account_no;
        protected string Customer_name;
        protected string Account_type;
        protected string Transaction_type;
        protected double amount;
        protected double balance = 10000;
        public Accounts()
        {
            Console.WriteLine("Enter Account number:");
            Account_no = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Customer name");
            Customer_name = Console.ReadLine();
            Console.WriteLine("Enter Account type:");
            Account_type = Console.ReadLine();

        }
        public void Showdata()
        {
            Console.WriteLine("Account number:{0}", Account_no);
            Console.WriteLine("Custermer name:{0}", Customer_name);
            Console.WriteLine("Account type:{0}", Account_type);
            Console.WriteLine("Balance:{0}", balance);
            Console.WriteLine("Transaction type:{0}", Transaction_type);
            Console.WriteLine("Amount:{0}", amount);

        }
    }
    class Transaction : Accounts
    {
        public void Credit()
        {

            Console.WriteLine("Enter Transaction type:");
            Transaction_type = Console.ReadLine();


            if (Transaction_type == "deposit" || Transaction_type == "d")

            {
                Console.WriteLine("Enter amount to be deposited");
                amount = Convert.ToDouble(Console.ReadLine());
                Showdata();
                Console.WriteLine("deposited amount added to the current balance:");
                Console.WriteLine((double)balance + (double)amount);
            }

        }
        public void Debit()
        {
            if (Transaction_type == "withdraw" || Transaction_type == "w")
            {
                Console.WriteLine("Enter amount to be withdraw");
                amount = Convert.ToDouble(Console.ReadLine());
                Showdata();
                Console.WriteLine("withdraw amount removed from the  balance:");
                Console.WriteLine("current balance:");
                Console.WriteLine((double)balance - (double)amount);
            }


        }

        static void Main(string[] args)
        {
            Transaction t1 = new Transaction();
            t1.Credit();
            t1.Debit();
            Console.Read();
        }

    }
}
