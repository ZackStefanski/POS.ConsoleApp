using POS.ConsoleApp;

namespace POS.ConsoleApp.Classes

{
    public class Store
    {
        private List<Equipment> inventoryInClass = new List<Equipment>();

        public static void ExportInventoryToTxtFile(List<Equipment> inventoryInClass)
        {
            StreamWriter A = new StreamWriter("inventory.csv");
            A.WriteLine("ITEM,COST,ID");
            foreach (Equipment e in inventoryInClass)
            {
                A.WriteLine(e.Item + "," + e.Cost + "," + e.Id + ",");
            }
            A.Close();
        }
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
        public Equipment(string item, double cost, int id, int oldid)
        {
            Item = item;
            Cost = cost;
            Id = id;
            OldId = oldid;
        }

        public string Item { get; set; }
        public double Cost { get; set; }
        public int Id { get; private set; }
        public int OldId { get; private set; }
    }
}
