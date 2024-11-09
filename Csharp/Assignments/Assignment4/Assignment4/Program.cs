using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{

    class InsuffientBalanceException : ApplicationException
    {

      
        public InsuffientBalanceException(string msg) : base(msg)
        {
           
        }
    }
 
    class Transaction
        {

        string Customer_name;
        string Transaction_type;
        double amount;
        double balance = 10000;
        public Transaction(string Customer_name,string Transaction_type)
        {
            this.Customer_name = Customer_name;
            this.Transaction_type = Transaction_type;
         
        }
        public void  Credit()
        {
            if (Transaction_type == "deposit" || Transaction_type == "d")

            {
                Console.WriteLine("Enter amount to be deposited");
                amount = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("deposited amount added to the current balance:");
                Console.WriteLine((double)balance + (double)amount);
            }
        }
        public void Debit()
          {
                     
            try
            {
              

                if (Transaction_type == "w" || Transaction_type == "withdraw" )
                {
                    Console.WriteLine("Enter amount to be withdraw");
                    amount = Convert.ToDouble(Console.ReadLine());
                }

                if (Transaction_type == "w" && amount > balance)
                {
                    throw (new InsuffientBalanceException("customer doesn’t have sufficient balance"));
                }
                if (Transaction_type == "w" && amount < balance)
                {
                    double withdraw = (double)balance - (double)amount;
                    Console.WriteLine("After withdraw your current account balance:{0}", withdraw);

                }

            }
            catch (InsuffientBalanceException ve)
            {
                Console.WriteLine("ERROR:" + ve.Message);

            }
        }
        public void Balance()
        {
            if(Transaction_type == "deposit" || Transaction_type == "d")
            {
                Credit();
            }
            else
            {
                Debit();
            }
          
         
        }
     

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Customer name");
           string  Customer_name = Console.ReadLine();
            Console.WriteLine("Enter Transaction type:");
          string  Transaction_type = Console.ReadLine();
            Transaction obj = new Transaction(Customer_name,Transaction_type);

            obj.Balance();
                    
            Console.Read();
        }
    }
 }



