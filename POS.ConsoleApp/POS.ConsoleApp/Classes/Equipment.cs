using System.Collections.Generic;

namespace POS.ConsoleApp.Classes
{
    public class Equipment
    {

        public string Item { get; set; }
        public double Cost { get; set; }

        static int ID = 0;

        public void makeMatrix()
        {
            string[] matrix = { Item, Cost.ToString(), ID.ToString() };
            Console.WriteLine($"{matrix[0]}\t{matrix[1]}\t{matrix[2]}");
        }

        // A constructor is used to allow us to create new equipment objects.
        public Equipment(string item, double cost)
        {
            Item = item;
            Cost = cost;
        }
    }
}
