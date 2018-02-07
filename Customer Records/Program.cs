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
            string text;
            ConsoleKeyInfo keyValue;

            welcome(out keyValue);

            while (keyValue.Key == ConsoleKey.Enter)
            {


                FileStream file = new FileStream("WriteCustomerRecords.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);
                WriteLine("Please Enter your data: ");
                text = ReadLine();
                writer.WriteLine(text);

                writer.Close();
                file.Close();
            }

        }

        public static void welcome(out ConsoleKeyInfo keyValue)
        {
            WriteLine("Welcome to the Customer Records Program");
            WriteLine("\nTo start the program, please press Enter or any key to exit...");
            keyValue = ReadKey();
        }
        
        public static void display()
        {

        }
    }
}
