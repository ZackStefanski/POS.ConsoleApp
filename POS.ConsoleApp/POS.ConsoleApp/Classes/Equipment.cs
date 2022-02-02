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
            
            string[] matrix = { Item.ToUpper(), Cost.ToString(), ID.ToString() };
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

        // A constructor is used to allow us to create new equipment objects.
        public Equipment(string item, double cost)
        {
            Item = item;
            Cost = cost;
        }
    }
}
