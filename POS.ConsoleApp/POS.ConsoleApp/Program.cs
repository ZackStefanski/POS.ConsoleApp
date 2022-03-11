using POS.ConsoleApp.Classes;
using System.Text;

namespace POS
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            List<Equipment> inventory = InventoryRepository.InitializeInventory();
            

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
                            Console.Clear();
                            Console.WriteLine("INVENTORY");
                            Console.WriteLine($"ITEM\t\tCOST\tID");
                            Console.WriteLine("--------------------------------");
                            InventoryRepository.DisplayList(inventory);
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("1: new | 2: edit | 3: delete | 4: back");
                            string UserInput_Inventory = Console.ReadLine();
                            switch (UserInput_Inventory)
                            {
                                case "1": // CREATE NEW ITEM
                                    string? UserInput_NewItemName;
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("CREATE NEW ITEM");
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("Item Name: | leave blank if nvm");
                                        if ((UserInput_NewItemName = Console.ReadLine()) != "")
                                        {
                                            do
                                            {
                                                Console.WriteLine("New Item Cost:");
                                                if (double.TryParse(Console.ReadLine(), out double UserInput_NewCost))
                                                {
                                                    // if the parse was successful, create new item and break out of the loop
                                                    InventoryRepository.AddToList(inventory, UserInput_NewItemName, UserInput_NewCost);
                                                    break;
                                                }
                                                else
                                                {
                                                    // if the parse was unsuccessful, display an error message and try again
                                                    Console.WriteLine("Invalid number. Try again.");
                                                }
                                            } while (true) ;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } while (true);
                                    continue;
                                case "2": // EDIT EXISTING ITEM
                                    Console.WriteLine("________________________");
                                    Console.WriteLine("Which Item would you like to edit? leave blank if nvm");
                                    Console.WriteLine("ITEM ID:");
                                    string? itemIDToEdit = Console.ReadLine();

                                    if (itemIDToEdit != "")
                                    {
                                        foreach (Equipment x in inventory)
                                        {
                                            if (x.Id == int.Parse(itemIDToEdit))
                                            {
                                                Console.WriteLine("________________________");
                                                Console.WriteLine(x.Item + " | " + x.Cost + " | " + x.Id);
                                                Console.WriteLine("New Item Name: | BLANK if nvm");
                                                string? NewName = Console.ReadLine();
                                                double NewCost;

                                                do
                                                {
                                                    if (NewName != "")
                                                    {
                                                        x.Item = NewName;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }

                                                } while (true);
                                                do
                                                {
                                                    Console.WriteLine("New Item Cost: | BLANK if nvm");
                                                    if (double.TryParse(Console.ReadLine(), out NewCost))
                                                    {
                                                        // if the parse was successful, create new item and break out of the loop
                                                        x.Cost = NewCost;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                } while (true);
                                            }
                                        }
                                    } else {
                                        continue;
                                    }
                                    continue;
                                case "3": // DELETE EXISTING ITEM
                                    Console.WriteLine("________________________");
                                    Console.WriteLine("Which Item would you like to delete? leave blank if nvm");
                                    Console.WriteLine("ITEM ID:");
                                    // TODO - blank if nvm
                                    //int ItemIDToDelete = int.Parse(Console.ReadLine());
                                    string? ItemIDToDelete = Console.ReadLine();
                                    if (ItemIDToDelete != "")
                                    {
                                        foreach (Equipment x in inventory)
                                        {
                                            if (x.Id == int.Parse(ItemIDToDelete))
                                            {
                                                Console.WriteLine("________________________");
                                                Console.WriteLine(x.Item + " | " + x.Cost + " | " + x.Id);
                                                Console.WriteLine("Are you sure you wish to delete the item listed above? y or n");
                                                string? UI_DeleteItem = Console.ReadLine();

                                                if (UI_DeleteItem == "y")
                                                {
                                                    //var index = inventory.Single(x => x.Id == itemIDToEdit);
                                                    //inventory.RemoveAt(index);
                                                    var itemToRemove = inventory.Single(x => x.Id == int.Parse(ItemIDToDelete));
                                                    inventory.Remove(itemToRemove);
                                                }
                                                else if (UI_DeleteItem == "n")
                                                {
                                                    return;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("please make a valid selection");
                                                }
                                            }
                                        }
                                    } else
                                    {
                                        continue;
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
                        // ++++++++++
                        // FIX THIS
                        // ++++++++++
                        Console.WriteLine("Would you like to save your new inventory to a new local file? y or n");
                        string? userInput_Csv = Console.ReadLine();
                        if (userInput_Csv == "y")
                        {
                            InventoryRepository.ExportListToCSVFile(inventory);
                            Console.WriteLine("done!");
                            Console.ReadLine();
                        } else if (userInput_Csv == "n")
                        {
                            //return;
                            Console.WriteLine("okay!");
                            Console.ReadLine();
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
    }
}
