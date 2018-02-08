using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Customer_Records
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyValue;
            Customer client = new Customer();
            string userInput;
            List<String> customerList = new List<String>();

            welcome(out keyValue);

            while (keyValue.Key == ConsoleKey.Enter)
            {
                FileStream file = new FileStream("WriteCustomerRecords.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                Write("ID Number: ");
                client.idNumber = ReadLine();
                Write("Name: ");
                client.name = ReadLine();
                Write("Balance: ");
                client.balance = ReadLine();
                WriteLine("ID Number: {0} Name: {1} Balance: {2}\n", client.idNumber, client.name, client.balance);
                customerList.Add(client.idNumber);
                customerList.Add(client.name);
                customerList.Add(client.balance);
                foreach (var i in customerList)
                {
                    writer.WriteLine($"{ i} ");
                }
                writer.Close();
                file.Close();

                restart(out keyValue);
            }

        }

        public static void welcome(out ConsoleKeyInfo keyValue)
        {
            WriteLine("Welcome to the Customer Records Program");
            WriteLine("\nTo start the program, please press Enter or any key to exit...");
            keyValue = ReadKey();
        }

        public static void restart(out ConsoleKeyInfo keyValue)
        {
            WriteLine("To restart the program, please press Enter or any other key to exit.");
            keyValue = ReadKey();

            if (keyValue.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                welcome(out keyValue);
            }
        }
        
        class Customer
        {
            public string idNumber { get; set; }
            public string name { get; set; }
            public string balance { get; set; }          
        }
    }
}
