using Microsoft.VisualBasic.FileIO;
using POS.ConsoleApp.Classes;
using System;
using System.IO;

namespace POS
{
    partial class Program
    {
        private static object value;

        public static void Main(string[] args)
        {
            // the "mainMenu()" is exctracted to increase code legibility.
            mainMenu();
            
            // adding inventory.
            Equipment mic = new Equipment("MIC",99.99);
            Equipment cable = new Equipment("CABLE", 18.99);
            Equipment micStand = new Equipment("MIC STAND", 24.99);

            Console.WriteLine($"{mic.Item}\t{mic.Cost}\t{mic.ID}");
            Console.WriteLine($"{cable.Item}\t{cable.Cost}\t{cable.ID}");
            Console.WriteLine($"{micStand.Item}\t{micStand.Cost}\t{micStand.ID}");


            Console.ReadLine();

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
                    Console.WriteLine("something");
                    Console.ReadLine();
                    //ViewEditInventory(inventory);
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

        //private static void ViewEditInventory(List<Equipment> inventory)
        //{
        //    Console.Clear();

        //    Console.WriteLine("***********************");
        //    Console.WriteLine("* View/Edit Inventory *");
        //    Console.WriteLine("***********************");
        //    Console.WriteLine("Press 0 to return to the Main Menu");
        //    Console.WriteLine("__________________________________");
        //    Console.WriteLine($"ID     \tItem     \tCost");
        //    Console.WriteLine("");

        //    Console.WriteLine("'add' to add new inventory | 'id' to edit existing inventory.");
        //    string inventoryUserInput = Console.ReadLine();
        //    if (inventoryUserInput == "0")
        //    {
        //        Console.Clear();
        //        mainMenu();
        //    }
        //    else if (inventoryUserInput == "add")
        //    {
        //        Console.WriteLine("What is the item?");
        //        string newItem = Console.ReadLine();
        //        Console.WriteLine("What is the cost?");
        //        double newCost = double.Parse(Console.ReadLine());

        //        Equipment NEWITEM = new Equipment(newItem.ToUpper(),newCost);

        //        ViewEditInventory(inventory);
        //    }
        //}

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
