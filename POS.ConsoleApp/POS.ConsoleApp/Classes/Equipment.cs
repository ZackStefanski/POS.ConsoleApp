using POS.ConsoleApp;

namespace POS.ConsoleApp.Classes

{
    public class Store
    {
        //List<Equipment> inventoryInClass = new List<Equipment>();

        //public void InventoryInClass(string item, double cost, int id)
        //{
        //    Equipment(item, cost, id);
        //    Item = item;
        //    Cost = cost;
        //    Id = id;
        //}

        //public static void InventoryPageRefresh(List<Equipment> inventoryInClass)
        //{
        //    Console.Clear();
        //    Console.WriteLine("INVENTORY");
        //    Console.WriteLine($"ITEM\t\tCOST\tID");
        //    Console.WriteLine("--------------------------------");
        //    Display(inventoryInClass);
        //    Console.WriteLine("--------------------------------");
        //    Console.WriteLine("1: new | 2: edit | 4: back");
        //}

        //public static void CreateNewItem(List<Equipment> inventoryInClass, string name, double cost)
        //{
        //    int newItemId = inventoryInClass.OrderBy(x => x.Id).ToList().Last().Id + 1;
        //    inventoryInClass.Add(new Equipment(name, cost, newItemId));
        //}

        //public static void Display(List<Equipment> inventoryInClass)
        //{
        //    foreach (Equipment e in inventoryInClass)
        //    {
        //        e.ViewItemByGrid();
        //    }
        //}

        //public static void ExportInventoryToTxtFile(List<Equipment> inventoryInClass)
        //{
        //    StreamWriter A = new StreamWriter("inventory.csv");
        //    A.WriteLine("ITEM,COST,ID");
        //    foreach (Equipment e in inventoryInClass)
        //    {
        //        A.WriteLine(e.Item + "," + e.Cost + "," + e.Id + ",");
        //    }
        //    A.Close();
        //}
    }
    public class Equipment
    {
        // A constructor is used to allow us to create new equipment objects.
        public Equipment(string item, double cost, int id)
        {
            Item = item;
            Cost = cost;
            Id = id;
        }

        public string Item { get; set; }
        public double Cost { get; set; }
        public int Id { get; private set; }

        // Formatting for easier display.
        public void ViewItemByGrid()
        {
            string[] grid = { Item.ToUpper(), Cost.ToString(), Id.ToString() };
            if (grid[0].Length <= 8)
            {
                grid[0] = grid[0] + "\t\t";
                Console.WriteLine($"{grid[0]}{grid[1]}\t{grid[2]}");
            } 
            else if (grid[0].Length >= 9 && grid[0].Length <= 16)
            {
                grid[0] = grid[0] + "\t";
                Console.WriteLine($"{grid[0]}{grid[1]}\t{grid[2]}");
            }
            else
            {
                string abreviatedItem = grid[0].Substring(0, 13);
                abreviatedItem = abreviatedItem + "...";
                Console.WriteLine($"{abreviatedItem}{grid[1]}\t{grid[2]}");
            }
        }
    }
}
