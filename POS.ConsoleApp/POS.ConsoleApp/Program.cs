using POS.ConsoleApp.Classes;

namespace POS
{
    partial class Program
    {

        public static void Main(string[] args)
        {
            // the "mainMenu()" is exctracted to increase code legibility.
            mainMenu();

            List<Equipment> inventory = new List<Equipment>();

            // adding inventory.
            //inventory.Add(new Equipment("MIC", 99.99));
            //inventory.Add(new Equipment("CABLE", 18.99));
            //inventory.Add(new Equipment("MIC STAND", 24.99));

            //Display(inventory);

            //CreateNewItem(inventory);

            //// a "while" loop will ensure that the program runs consistantly until the user decides to exit. 
            string userInput = Console.ReadLine();

            while (userInput != "9")
            {

                // "if" statements are used to allow the user to navigate through the console application.
                if (userInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("INVENTORY");
                    Console.WriteLine($"ITEM\t\tCOST\tID");
                    inventory.Add(new Equipment("MIC", 99.99));
                    inventory.Add(new Equipment("CABLE", 18.99));
                    inventory.Add(new Equipment("MIC STAND", 24.99));
                    inventory.Add(new Equipment("XXXXXXXXXXXXXXXXX", 24.99));
                    inventory.Add(new Equipment("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", 24.99));


                    Display(inventory);

                    CreateNewItem(inventory);

                    Console.ReadLine();
                    Console.WriteLine("Press 0 to return to the Main Menu");

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

        private static void CreateNewItem(List<Equipment> inventory)
        {
            
            Console.WriteLine("New Item Name:");
            string userInput = Console.ReadLine();

            double userInputCostD;
            while (true)
            {
                Console.WriteLine("New Item Cost:");
                if (double.TryParse(Console.ReadLine(), out userInputCostD)) 
                {
                    // if the parse was successful, we can break out of the loop
                    inventory.Add(new Equipment(userInput, userInputCostD));
                    break;
                }
                else
                {
                    // if the parse was unsuccessful, display an error message and try again
                    Console.WriteLine("Invalid number. Try again.");
                }
            }

            Console.Clear();
            Display(inventory);
        }

        private static void Display(List<Equipment> inventory)
        {
            foreach (Equipment e in inventory)
            {
                e.makeMatrix();
            }
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
            Console.WriteLine("1: Access Inventory");
            Console.WriteLine("9: Exit Application");
        }
    }
}
