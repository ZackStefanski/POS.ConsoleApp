using POS.ConsoleApp.Classes;
using System.Text;

namespace POS
{
    partial class Program
    {
        public static void Main(string[] args)
        {
            Store MusicStore = new Store();

            // MAIN LOOP
            while (true)
            {
                // MAIN MENU PAGE
                Console.Clear();
                Console.WriteLine("******************************************");
                Console.WriteLine("**** Inventory Management Console App ****");
                Console.WriteLine("******************************************");
                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: Access Inventory");
                Console.WriteLine("8: About Me");
                Console.WriteLine("0: Exit Application");
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
                            InventoryRepository.DisplayList(MusicStore.inventory);
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("1: new | 2: edit | 3: delete | 4: back");
                            string UserInput_Inventory = Console.ReadLine();
                            switch (UserInput_Inventory)
                            {
                                case "1": // CREATE NEW ITEM & ADD TO <LIST> INVENTORY
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("\tCREATE NEW ITEM");
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("Input New Item Name... (press 0 to exit)");

                                        string? UserInput_NewItemName = Console.ReadLine();
                                        if (UserInput_NewItemName == "0")
                                        {
                                            break;
                                        } else
                                        {
                                            Console.WriteLine("Input Item Cost... (press 0 to exit)");
                                            double.TryParse(Console.ReadLine(), out double UserInput_NewCost);
                                            if (UserInput_NewCost == 0)
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                InventoryRepository.AddToList(MusicStore.inventory, UserInput_NewItemName, UserInput_NewCost);
                                                break;
                                            }
                                        }
                                    } while (true);
                                    continue;
                                case "2": // EDIT EXISTING ITEM
                                    do
                                    {
                                        Console.WriteLine("--------------------------------");
                                        Console.WriteLine("Which item would you like to edit?... (0 to exit)");

                                        string? UserInput_ItemToEdit = Console.ReadLine();
                                        if (UserInput_ItemToEdit == "0")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Equipment Item = InventoryRepository.FindListItem(MusicStore.inventory, int.Parse(UserInput_ItemToEdit));
                                            //there is an issue here - all are returning null?
                                            if (Item == null)
                                            {
                                                Console.WriteLine($"item not found");
                                                Console.ReadLine();
                                                break;
                                            } else
                                            {
                                                Console.WriteLine("New item name... (0 to exit)");
                                                string UserInput_ItemName = Console.ReadLine();
                                                if (UserInput_ItemName == "0")
                                                {
                                                    break;
                                                } else
                                                {
                                                    double NewCost;
                                                    Console.WriteLine("New item cost... (0 to exit");
                                                    string UserInput_ItemCost = Console.ReadLine();
                                                    if (double.TryParse(UserInput_ItemCost, out NewCost))
                                                    {
                                                        // if the parse was successful, create new item and break out of the loop
                                                        Item.Cost = NewCost;
                                                        Item.Item = UserInput_ItemName;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    } while (true);
                                    continue;
                                case "3": // DELETE EXISTING ITEM
                                    do
                                    {
                                        Console.WriteLine("________________________");
                                        Console.WriteLine("\tDELETE ITEM");
                                        Console.WriteLine("________________________");
                                        Console.WriteLine("Item ID... press 0 to exit");
                                        string? ItemIDToDelete = Console.ReadLine();
                                        if (ItemIDToDelete == "0")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Equipment e = InventoryRepository.FindListItem(MusicStore.inventory, int.Parse(ItemIDToDelete));
                                            e.DisplayItemProperties(e);
                                            Console.WriteLine("ARE YOU SURE? y or n");
                                            string UserInputResponse = Console.ReadLine();
                                            if (UserInputResponse == "n")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                InventoryRepository.DeleteItem(MusicStore.inventory, MusicStore.listOfDeletedItems, int.Parse(ItemIDToDelete));
                                                break;
                                            }
                                        }
                                    } while (true);
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
                        Console.WriteLine("Welcome! This is a Inventory Management Application I built for my first \nsemester at Code Louisville - Spring '22. The app is specifically designed to assist \nwith that of a generic music store's inventory. Each item added to the inventory \nis an iteration of the Equipment class. It is very loosely based off an application \nI used at a former place of employment.");
                        Console.ReadLine();
                        continue;
                    case "0":

                        Console.WriteLine("Would you like to save a copy of your inventory and your deleted items to a new local CSV file? y or n");
                        string? userInput_Csv = Console.ReadLine();
                        if (userInput_Csv == "y")
                        {
                            InventoryRepository.ExportListToCSVFile(MusicStore.inventory, "inventory");
                            InventoryRepository.ExportListToCSVFile(MusicStore.listOfDeletedItems, "deleted_items");
                            Console.WriteLine("done!");
                            Console.WriteLine(@"files saved in ...POS.ConsoleApp\bin\Debug\net6.0\Docs");
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
