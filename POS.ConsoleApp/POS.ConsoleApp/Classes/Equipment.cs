using System.Collections.Generic;

namespace POS.ConsoleApp.Classes
{
    public class Equipment
    {
        // A constructor is used to allow us to create new equipment objects.
        public Equipment(string item, double cost)
        {
            Item = item;
            Cost = cost;

            // I discovered how to automatically generate an incremented ID from this blog discussion: https://stackoverflow.com/questions/8813435/incrementing-a-unique-id-number-in-the-constructor/8813494
            // I learned more about the topic here: https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.increment?view=net-6.0

            this.Id = System.Threading.Interlocked.Increment(ref m_Counter);
        }
        public Equipment(string item, double cost, int id)
        {
            Item = item;
            Cost = cost;
            Id = id;
        }

        public string Item { get; set; }
        public double Cost { get; set; }
        public int Id { get; private set; }


        private static int m_Counter = 100;

        public void CreateItemGridView()
        {
            //Formatting for inventory page.
            string[] matrix = { Item.ToUpper(), Cost.ToString(), Id.ToString() };
            if (matrix[0].Length <= 8)
            {
                matrix[0] = matrix[0] + "\t\t";
                Console.WriteLine($"{matrix[0]}{matrix[1]}\t{matrix[2]}");
            } 
            else if (matrix[0].Length >= 9 && matrix[0].Length <= 16)
            {
                matrix[0] = matrix[0] + "\t";
                Console.WriteLine($"{matrix[0]}{matrix[1]}\t{matrix[2]}");
            }
            else
            {
                string abreviatedItem = matrix[0].Substring(0, 13);
                abreviatedItem = abreviatedItem + "...";
                Console.WriteLine($"{abreviatedItem}{matrix[1]}\t{matrix[2]}");
            }
        }

        public void ShowDetails(int ID)
        {
            Console.WriteLine($"Item: {Item} \t Cost: {Cost} \t {Id}");
        }

    }
}
