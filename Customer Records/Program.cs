using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Runtime.Serialization.Formatters.Binary;

namespace Customer_Records
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declarations
            const string DELIM = ",";
            ConsoleKeyInfo keyValue;
            Customer client = new Customer();
            List<String> clientList = new List<String>();
            FileStream file = new FileStream("WriteCustomerRecords.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            welcome(out keyValue);

            while (keyValue.Key == ConsoleKey.Enter)
            {
                Write("\nID Number: ");
                client.idNumber = Convert.ToInt32(ReadLine());
                Write("Name: ");
                client.name = ReadLine();
                Write("Balance: ");
                client.balance = Convert.ToInt32(ReadLine());
                clientList.Add(client.idNumber + DELIM + client.name + DELIM + client.balance);

                foreach (var i in clientList)
                {
                    writer.WriteLine($"{i}");
                }

                restart(out keyValue, ref clientList);

            }

            writer.Close();
            file.Close();


            consoleReset(out keyValue);

            readData();
            consoleReset(out keyValue);

            fileSearch();

        }//End of main method

        public static void welcome(out ConsoleKeyInfo keyValue)
        {
            WriteLine("Welcome to the Customer Records Program");
            Write("\nTo start the program, please press Enter or any key to exit...");
            keyValue = ReadKey();
            WriteLine("\nPlease Enter the customer's information below...");
        }

        public static void restart(out ConsoleKeyInfo keyValue, ref List<String> clientList)
        {
            Write("\nTo enter another customer's information, please press Enter or any other key to exit...");
            keyValue = ReadKey();

            if (keyValue.Key == ConsoleKey.Enter)
            {
                clientList.Clear();
                Console.Clear();
                WriteLine("Please Enter the customer's information below...");
            }
            else
            {
                Console.Clear();
            }
        }

        public static void consoleReset(out ConsoleKeyInfo keyValue)
        {
            WriteLine("To continue the program, please press Enter or any other key to exit...");
            keyValue = ReadKey();

            if (keyValue.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }
        }

        public static void readData()
        {
            const char DELIM = ',';
            const string FILE = "WriteCustomerRecords.txt";
            FileStream file = new FileStream(FILE, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(FILE);
            Customer client = new Customer();
            string record;
            string[] info;

            WriteLine("\n{0,-5}{1,-15}{2,8}\n", "ID", "Name", "Salary");
            record = reader.ReadLine();
            while(record != null)
            {
                info = record.Split(DELIM);
                client.idNumber = Convert.ToInt32(info[0]);
                client.name = info[1];
                client.balance = Convert.ToInt32(info[2]);
                WriteLine("{0,-5}{1,-15}{2,8}", 
                    client.idNumber, client.name, client.balance.ToString("C"));
                record = reader.ReadLine();
            }
            Write("\n");

            reader.Close();
            file.Close();

        }

        public static void fileSearch()
        {
            const char DELIM = ',';
            const string FILE = "WriteCustomerRecords.txt";
            Customer client = new Customer();
            FileStream inFile = new FileStream(FILE, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            bool advance = true;
            string record, userInput;
            string[] info;
            int idNumber;

            do
            {
                Write("Please enter the customer ID Number you would like to search: ");
                idNumber = Convert.ToInt32(ReadLine());

                WriteLine("\n{0,-5}{1,-15}{2,8}\n", "ID", "Name", "Salary");
                inFile.Seek(0, SeekOrigin.Begin);
                record = reader.ReadLine();

                while (record != null)
                {
                    info = record.Split(DELIM);
                    client.idNumber = Convert.ToInt32(info[0]);
                    client.name = info[1];
                    client.balance = Convert.ToInt32(info[2]);

                    if (client.idNumber == idNumber)
                    {
                        WriteLine("{0,-5}{1,-15}{2,8}",
                            client.idNumber, client.name, client.balance.ToString("C"));
                    }

                    record = reader.ReadLine();

                }

                Write("\nTo Enter another customer search, enter (Y/N): ");
                userInput = ReadLine();
                userInput = userInput.ToUpper();

                if (userInput == "Y")
                {
                    advance = true;
                    Console.Clear();
                }
                else
                {
                    advance = false;
                    break;
                }

            } while (advance);

            reader.Close();
            inFile.Close();

        }
    }//End of Program Class

    class Customer
    {
        public int idNumber { get; set; }
        public string name { get; set; }
        public int balance { get; set; }
    }




    

}
