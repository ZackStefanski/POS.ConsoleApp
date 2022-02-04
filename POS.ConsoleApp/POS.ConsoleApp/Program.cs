using POS.ConsoleApp.Classes;

namespace POS
{
    partial class Program
    {

        public static void Main(string[] args)
        {
            List<Equipment> inventory = new List<Equipment>();
            inventory.Add(new Equipment("MIC", 99.99));
            inventory.Add(new Equipment("CABLE", 18.99));
            inventory.Add(new Equipment("MIC STAND", 24.99));

            //TODO_____________________________________________ how to instanciate instances of class with inventory.ADD & constructor
            Equipment f = new Equipment("name", 1234);

            // the "mainMenu()" is exctracted to increase code legibility & make it reusable.
            //mainMenu();
            string userInput_MainMenu;
            // a "while" loop will ensure that the program runs consistantly until the user decides to exit. 
            //string userInput_MainMenu = Console.ReadLine();

            do
            {
                // the "mainMenu()" is exctracted to increase code legibility & make it reusable.
                mainMenu();

                // a do/while loop will ensure that the program runs consistantly until the user decides to exit. 
                userInput_MainMenu = Console.ReadLine();
                // "if" statements are used to allow the user to navigate through the console application.

                // INVENTORY "PAGE" DO/WHILE LOOP
                if (userInput_MainMenu == "1")
                {
                    do
                    {
                        RefreshPage(inventory);
                        string UserInput_Inventory = Console.ReadLine();
                        if (UserInput_Inventory == "1" ) // CREATE NEW ITEM
                        {
                            CreateNewItem(inventory);
                            RefreshPage(inventory);
                        }
                        else if (UserInput_Inventory == "2") // EDIT ITEM
                        {
                            Console.WriteLine("Item ID that you wish to edit:");
                            int UserInput_EditItem = int.Parse(Console.ReadLine());

                            //TODO
                            f.ShowDetails(UserInput_EditItem);
                            Console.ReadLine();
                        }
                        else if (UserInput_Inventory == "4") // BACK TO MAIN MENU
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid number. Try again.");
                        }
                    } while (userInput_MainMenu != "9");
                }
                else if (userInput_MainMenu == "8")
                {
                    Console.Clear();
                    Console.WriteLine("S - Simple \nA - As \nF... \nAn inventory management system for the modern age.");
                    Console.ReadLine();
                }
                //else if (userInput_MainMenu == null || userInput_MainMenu == "")
                //{
                //    Console.WriteLine("please input a valid selection.");
                //    Console.WriteLine("check if NumLock is off");
                //}
                else
                {
                    Console.WriteLine("please input a valid selection.");
                }
            } while (userInput_MainMenu != "9") ;

            Console.Clear();
            Console.WriteLine("Goodbye for now! ... and don't forget the power cable!");
            Console.ReadLine();
        }

        private static void RefreshPage(List<Equipment> inventory)
        {
            Console.Clear();
            Console.WriteLine("INVENTORY");
            Console.WriteLine($"ITEM\t\tCOST\tID");
            Console.WriteLine("--------------------------------");
            Display(inventory);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1: new item | 2: view existing item ");
            Console.WriteLine("4: back ");
        }

        private static void CreateNewItem(List<Equipment> inventory)
        {
            
            //Console.WriteLine("New Item Name:");
            string? UserInput_CreateNewItem;
            double UserInput_ConvertToDouble;

            do
            {
                Console.WriteLine("New Item Name:");
                if ((UserInput_CreateNewItem = Console.ReadLine()) != "")
                {
                    break;
                }
                else
                {
                    // if the name was unsuccessful, display an error message and try again
                    Console.WriteLine("Invalid name. Try again.");
                }
            } while (true);

            do
            {
                Console.WriteLine("New Item Cost:");
                if (double.TryParse(Console.ReadLine(), out UserInput_ConvertToDouble))
                {
                    // if the parse was successful, create new item and break out of the loop
                    inventory.Add(new Equipment(UserInput_CreateNewItem, UserInput_ConvertToDouble));
                    break;
                }
                else
                {
                    // if the parse was unsuccessful, display an error message and try again
                    Console.WriteLine("Invalid number. Try again.");
                }
            } while (true);

        Console.Clear();
        Display(inventory);
        }

        private static void Display(List<Equipment> inventory)
        {
            foreach (Equipment e in inventory)
            {
                e.CreateItemMatrixView();
            }
        }

        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("***********************");
            Console.WriteLine("**** SAF_Inventory ****");
            Console.WriteLine("***********************");
            Console.WriteLine("");
            Console.WriteLine("Menu:");
            Console.WriteLine("1: Access Inventory");
            Console.WriteLine("8: About Me");
            Console.WriteLine("9: Exit Application");
            //string userInput_MainMenu = Console.ReadLine();
        }

        //public static void GetClassInstance()
        //{
        //    Console.WriteLine("Item ID that you wish to edit:");
        //    int UserInput_EditItem = int.Parse(Console.ReadLine());
        //    (UserInput_EditItem);

        //    //do
        //    //{
        //    //    if ((UserInput_EditItem = int.Parse(Console.ReadLine())) != null)
        //    //    {
        //    //        // if the parse was successful, create new item and break out of the loop
        //    //        Equipment.ShowDetails(UserInput_EditItem);
        //    //        break;
        //    //    }
        //    //    else
        //    //    {
        //    //        // if the parse was unsuccessful, display an error message and try again
        //    //        Console.WriteLine("Invalid number. Try again.");
        //    //    }
        //    //} while (true);

        //}
    }
}
