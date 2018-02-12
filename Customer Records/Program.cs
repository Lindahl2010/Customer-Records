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

            exit();

        }//End of main method

        public static void welcome(out ConsoleKeyInfo keyValue) 
        {
            //Welcome message that outputs a prompt for the user to start the program
            WriteLine("Welcome to the Customer Records Program");
            Write("\nTo start the program, please press Enter or any key to exit...");
            keyValue = ReadKey();
            WriteLine("\nPlease Enter the customer's information below...");
        }

        public static void exit()
        {
            //Method to show the end of the program
            WriteLine("Here is the data that you have entered: ");
            readData();
            WriteLine("Thank you for using this program!");
            Write("Press Enter to exit the program...");
            ReadLine();
        }

        public static void restart(out ConsoleKeyInfo keyValue, ref List<String> clientList)
        {
            //Method to restart the while loop if the user wishes to enter additional customers
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
            //Clears the console after the read method and the search method
            WriteLine("To continue the program, please press Enter...");
            keyValue = ReadKey();

            if (keyValue.Key == ConsoleKey.Enter)
            {
                Console.Clear();
            }
        }

        public static void readData()
        {
            //Method to read the data and display it in the console window
            //Declarations
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
            //Method to ask user to search based on ID Number and then based on minimum balance
            //Declarations
            const char DELIM = ',';
            const string FILE = "WriteCustomerRecords.txt";
            Customer client = new Customer();
            FileStream inFile = new FileStream(FILE, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            bool advance = true;
            string record, userInput;
            string[] info;
            int idNumber, minBalance;

            //Loop to search for customers based on ID Number 
            do
            {
                Write("Enter the customer ID to find: ");
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
                    Console.Clear();
                    break;
                }

            } while (advance);

            //Loop to search for customers based on minimum balance
            do
            {
                Write("Enter minimum balance to find: ");
                minBalance = Convert.ToInt32(ReadLine());

                WriteLine("\n{0,-5}{1,-15}{2,8}\n", "ID", "Name", "Salary");
                inFile.Seek(0, SeekOrigin.Begin);
                record = reader.ReadLine();

                while (record != null)
                {
                    info = record.Split(DELIM);
                    client.idNumber = Convert.ToInt32(info[0]);
                    client.name = info[1];
                    client.balance = Convert.ToInt32(info[2]);

                    if (client.balance >= minBalance)
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
                    Console.Clear();
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
