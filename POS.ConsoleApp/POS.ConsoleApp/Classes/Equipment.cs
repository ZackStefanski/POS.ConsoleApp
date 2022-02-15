using POS.ConsoleApp;

namespace POS.ConsoleApp.Classes

{
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
