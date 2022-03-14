using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ConsoleApp.Classes
{
    public class InventoryRepository
    {
        public static List<Equipment> InitializeInventory()
        {
            /*
            Outputs: list of equipment
            Inputs: csv file parse
            Constraints:
            Edge Cases: 
            ------------
            ++ PSEUDOCODE ++
            declare list
            find csv file
            declare array & add csv items into array
            convert each to their proper type
            create equipment based on data and add to list / loop
            return result
            */
            List<Equipment> result = new List<Equipment>();
            var path = System.IO.Directory.GetCurrentDirectory() + @"\Docs\inventory.csv";

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                string Item = columns[0];
                double Cost = Convert.ToDouble(columns[1]);
                int Id = Convert.ToInt32(columns[2]);
                result.Add(new Equipment(Item, Cost, Id));
            }
            return result;
        }
        public static void AddToList(List<Equipment> ListName, string name, double cost)
        {
            /*
            I: new Equipment (name, cost, generate id)
            O: void
            C: n/a
            E: n/a

            ++ PSEUDOCODE ++
            Create new equipment item
            Generate id number
            Add to existing list 
            */

            int newItemId = ListName.OrderBy(x => x.Id).ToList().Last().Id + 1;
            ListName.Add(new Equipment(name, cost, newItemId));
        }
        public static void AddToList(List<Equipment> ListName, string name, double cost, int id)
        {
            //I: list name, new Equipment (name, cost, id)
            //O: n/a
            //C: n/a
            //E: new Equipment where we know the id #, duplicate ID #s.

            // ++ PSEUDOCODE ++
            // Create new equipment item
            // Add to existing list 

            foreach(var item in ListName)
            {
                if (item.Id == id)
                {
                    int newItemId = ListName.OrderBy(x => x.Id).ToList().Last().Id + 1;
                    ListName.Add(new Equipment(name, cost, newItemId, id));
                } else
                {
                    ListName.Add(new Equipment(name, cost, id));
                }
            } 
        }
        public static void DisplayList(List<Equipment> ListName)
        {
            /*
            Outputs: list of items, displayed in a visually pleasing way
            Inputs: name of list
            Constraints: 
            Edge Cases:
            ------------
            ++ PSEUDOCODE ++
            get list
            find all items in list
            display
            */
            foreach (Equipment e in ListName)
            {
                string[] grid = { e.Item.ToUpper(), e.Cost.ToString(), e.Id.ToString() };
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
        public static Equipment FindListItem(List<Equipment> ListName, int id)
        {
            /*
            Outputs: true or false, and the item info if true
            Inputs: name of list & id
            Constraints: 
            Edge Cases:
            ------------
            ++ PSEUDOCODE ++
            get list
            find item in list
            return the item
            */
            foreach (Equipment e in ListName)
            {
                if (id == e.Id)
                {
                    return e;
                    //Console.WriteLine($"Item:{e.Item}\nCost:{e.Cost}\nID:{e.Id}\nOld ID (if applicable):{e.OldId}");
                }
            }
            return null;
        }
        public void EditItemName(List<Equipment> ListName, int id, string name)
        {
            /*
            Outputs: change name of item
            Inputs: List name, id, and item name
            Constraints:
            Edge Cases:
            ------------
            ++ PSEUDOCODE ++
            find list item
            change name
            */

            Equipment Item = FindListItem(ListName, id);
            Item.Item = name;
        }
        public void EditItemCost(List<Equipment> ListName, int id, double cost)
        {
            /*
            Outputs: change name of item
            Inputs: List name, id, and item name
            Constraints:
            Edge Cases:
            ------------
            ++ PSEUDOCODE ++
            find list item
            change name
            */

            Equipment Item = FindListItem(ListName, id);
            Item.Cost = cost;
        }
        public static void DeleteItem(List<Equipment> ListName, int id)
        {
            /*
            Outputs: delete item from the current list that it is referenceing 
                & add to another list for deleted items
            Inputs: List name, ID
            Constraints:
            Edge Cases:
            ------------
            ++ PSEUDOCODE ++
            find list item
            put in new list of deleted files
            delete from original list
            */
            Equipment Item = FindListItem(ListName, id);
            List<Equipment> DeletedItems = new List<Equipment> { Item };
            ListName.Remove(Item);
        }
        public static void ExportListToCSVFile(List<Equipment> ListName)
        {
            var path = System.IO.Directory.GetCurrentDirectory() + $@"\{ListName}.csv";

            // taken from https://stackoverflow.com/questions/18757097/writing-data-into-csv-file-in-c-sharp
            var csv = new StringBuilder();
            foreach (Equipment e in ListName)
            {
                var newLine = string.Format(e.Item + "," + e.Cost + "," + e.Id + ",");
                csv.AppendLine(newLine);
            }

            //after your loop
            File.WriteAllText(path, csv.ToString());
        }

    }
}
