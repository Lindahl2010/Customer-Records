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
            //Declarations
            ConsoleKeyInfo keyValue;
            Customer client = new Customer();
            List<String> clientList = new List<String>();
            FileStream file = new FileStream("WriteCustomerRecords.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            welcome(out keyValue);

            while (keyValue.Key == ConsoleKey.Enter)
            {

                Write("ID Number: ");
                client.idNumber = ReadLine();
                Write("Name: ");
                client.name = ReadLine();
                Write("Balance: ");
                client.balance = ReadLine();
                WriteLine($"ID Number: {client.idNumber} Name: {client.name} Balance: {client.balance}\n");
                clientList.Add(client.idNumber);
                clientList.Add(client.name);
                clientList.Add(client.balance);

                foreach (var i in clientList)
                {
                    writer.WriteLine($"{i}");
                }

                restart(out keyValue);

                writer.Close();
                file.Close();

            }
        }//End of main method

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
    }//End of Program Class

    class Customer
    {
        public string idNumber { get; set; }
        public string name { get; set; }
        public string balance { get; set; }
    }
}
