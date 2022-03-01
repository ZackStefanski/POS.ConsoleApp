using POS.ConsoleApp.Classes;

namespace POS
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            // firstly, an instance of an object is declared. Then a list named "inventory" is created, and a series of instances of the object are created & added.

            List<Equipment> inventory = new();

            // Here, we locate a file, parse the info, and pull each item in as a new instance of the Equipment class.
            string path = "C:/Users/zstefanski01/Projects/POS.ConsoleApp/POS.ConsoleApp/POS.ConsoleApp/INVENTORY.csv";

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                string Item = columns[0];
                double Cost = Convert.ToDouble(columns[1]);
                int Id = Convert.ToInt32(columns[2]);

                inventory.Add(new Equipment(Item, Cost, Id));
                Console.WriteLine($"Added {Item} from the CSV file to the inventory.");
            }
            Console.WriteLine("press enter to continue...");
            Console.ReadLine();

            // MAIN LOOP
            while (true)
            {
                // MAIN MENU PAGE
                Console.Clear();
                Console.WriteLine("***********************");
                Console.WriteLine("**** SAF_Inventory ****");
                Console.WriteLine("***********************");
                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: Access Inventory");
                Console.WriteLine("8: About Me");
                Console.WriteLine("9: Exit Application");
                string userInput_MainMenu = Console.ReadLine();
                switch (userInput_MainMenu)
                {
                    case "1": // INVENTORY PAGE
                        while (true)
                        {
                            InventoryPageRefresh(inventory);
                            string UserInput_Inventory = Console.ReadLine();
                            switch (UserInput_Inventory)
                            {
                                case "1": // CREATE NEW ITEM
                                    string? UserInput_NewItemName;
                                    do
                                    {
                                        Console.WriteLine("New Item Name:");
                                        if ((UserInput_NewItemName = Console.ReadLine()) != "")
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
                                        if (double.TryParse(Console.ReadLine(), out double UserInput_NewCost))
                                        {
                                            // if the parse was successful, create new item and break out of the loop
                                            CreateNewItem(inventory, UserInput_NewItemName, UserInput_NewCost);
                                            //inventory.Add(new Equipment(UserInput_CreateNewItem, UserInput_ConvertToDouble, newItemId));
                                            break;
                                        }
                                        else
                                        {
                                            // if the parse was unsuccessful, display an error message and try again
                                            Console.WriteLine("Invalid number. Try again.");
                                        }
                                    } while (true);
                                    InventoryPageRefresh(inventory);
                                    continue;
                                case "2":
                                    Console.WriteLine("________________________");
                                    Console.WriteLine("Which Item would you like to edit:");
                                    Console.WriteLine("ITEM ID:");
                                    // TODO - blank if nvm
                                    int ItemIDToEdit = int.Parse(Console.ReadLine());
                                    foreach (Equipment x in inventory)
                                    {
                                        if (x.Id == ItemIDToEdit)
                                        {
                                            Console.WriteLine("________________________");
                                            Console.WriteLine(x.Item + " | " + x.Cost + " | " + x.Id);
                                            Console.WriteLine("New Item Name: | BLANK if nvm");
                                            string? NewName = Console.ReadLine();
                                            double NewCost;

                                            if (NewName != "")
                                            {
                                                x.Item = NewName;
                                            }

                                            do
                                            {
                                                Console.WriteLine("New Item Cost: | BLANK if nvm");
                                                if (double.TryParse(Console.ReadLine(), out NewCost))
                                                {
                                                    // if the parse was successful, create new item and break out of the loop
                                                    x.Cost = NewCost;
                                                    InventoryPageRefresh(inventory);
                                                    break;
                                                }
                                                else
                                                {
                                                    InventoryPageRefresh(inventory);
                                                    break;
                                                }
                                            } while (true);
                                        }
                                    }
                                    continue;
                                case "4":
                                    break;
                                default:
                                    Console.WriteLine("please enter valid selection");
                                    continue;
                            } break;
                        } break;
                    case "8": // ABOUT ME PAGE
                        Console.Clear();
                        Console.WriteLine("S - Simple \nA - And \nFunctional \nAn inventory management system for the modern age.");
                        Console.WriteLine("click any key to return...");
                        Console.ReadLine();
                        continue;
                    case "9":
                        Console.Clear();
                        Console.WriteLine("Would you like to back up your updated inventory to a txt file? y or n");
                        string? userInput_TxtYesOrNo = Console.ReadLine();
                        if (userInput_TxtYesOrNo == "y")
                        {
                            ExportInventoryToTxtFile(inventory);
                            Console.WriteLine("done!");
                            Console.ReadLine();
                        } else if (userInput_TxtYesOrNo == "n")
                        {
                            return;
                        } else
                        {
                            Console.WriteLine("please enter valid selection");
                            return;
                        }
                        Console.WriteLine("Goodbye for now! ... and don't forget the power cable!");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("please enter valid selection.");
                        continue;
                }
            }
            Console.ReadLine();
        }
        private static void InventoryPageRefresh(List<Equipment> inventory)
        {
            Console.Clear();
            Console.WriteLine("INVENTORY");
            Console.WriteLine($"ITEM\t\tCOST\tID");
            Console.WriteLine("--------------------------------");
            Display(inventory);
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1: new | 2: edit | 4: back");
        }

        private static void CreateNewItem(List<Equipment> inventory, string name, double cost)
        {
            int newItemId = inventory.OrderBy(x => x.Id).ToList().Last().Id + 1;
            inventory.Add(new Equipment(name, cost, newItemId));
        }

        private static void Display(List<Equipment> inventory)
        {
            foreach (Equipment e in inventory)
            {
                e.ViewItemByGrid();
            }
        }

        public static void ExportInventoryToTxtFile(List<Equipment> inventory)
        {
            StreamWriter A = new StreamWriter("inventory.csv");
            A.WriteLine("ITEM,COST,ID");
            foreach (Equipment e in inventory)
            {
                A.WriteLine(e.Item + "," + e.Cost + "," + e.Id + ",");
            }
            A.Close();
        }
    }
}
