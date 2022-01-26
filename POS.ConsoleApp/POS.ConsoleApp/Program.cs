using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace POS
{
    class Program
    {
        private static object value;

        public static void Main(string[] args)
        {
            // the "mainMenu()" is called to increase code legibility.
            mainMenu();
            string userInput;

            // a "while" loop will ensure that the program runs consistantly until the user decides to exit. 
            while ((userInput = Console.ReadLine()) != "9")
            {
                // "if" statements are used to allow the user to navigate through the console application.
                if (userInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("New Rental");
                    Console.WriteLine("Press 0 to return to the Main Menu");
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Create New Customer");
                    Console.WriteLine("Press 0 to return to the Main Menu");
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    Console.WriteLine("View/Edit Customers");
                    Console.WriteLine("Press 0 to return to the Main Menu");
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    Console.WriteLine("View/Edit Inventory");
                    Console.WriteLine("Press 0 to return to the Main Menu");
                    ReadInventoryCSVFile();
                    Console.WriteLine("Item to edit:");
                    //string editItem;
                    //while ((editItem = Console.ReadLine()) != 0)
                    //{

                    //}
                }
                else if (userInput == "0")
                {
                    Console.Clear();
                    mainMenu();
                }
                else if (userInput == null || userInput == "")
                {
                    Console.WriteLine("please input a valid selection.");
                }
                else
                {
                    Console.WriteLine("please input a valid selection.");
                }
            }
            Console.Clear();
            Console.WriteLine("Goodbye for now! ... and don't forget the power cable!");
            Console.ReadLine();
        }

        static void ReadInventoryCSVFile()
        {

            var lines = File.ReadAllLines("C:/Users/zstefanski01/Projects/POS.ConsoleApp/POS.ConsoleApp/POS.ConsoleApp/INVENTORY.csv");
            var list = new List<Equipment>();

            foreach (var line in lines)
            {
                var values = line.Split(',');
                var equipment = new Equipment() { ID = values[0], Item = values[1], Cost = values[2] };
                list.Add(equipment);
            }
            list.ForEach(i => Console.WriteLine($"{i.ID}\t{i.Item}\t\t{i.Cost}"));

        }
        public class Equipment
        {
            public string ID { get; set; }
            public string Item { get; set; }
            public string Cost { get; set; }

        }

        private static void mainMenu()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("**** Point of Sale ****");
            Console.WriteLine("***********************");
            Console.WriteLine("");
            Console.WriteLine("Menu:");
            Console.WriteLine("1: New Sale/Rental");
            Console.WriteLine("2: Create New Customer");
            Console.WriteLine("3: View/Edit Customers");
            Console.WriteLine("4: View/Edit Inventory");
            Console.WriteLine("9: Exit Application");
        }
    }
}
