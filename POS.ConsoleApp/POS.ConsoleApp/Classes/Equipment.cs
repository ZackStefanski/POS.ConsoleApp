using POS.ConsoleApp;

namespace POS.ConsoleApp.Classes

{
    public class Equipment
    {
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
        public string DisplayItemProperties(Equipment e)
        {
            return $"Item: {e.Item}\nCost: {e.Cost}\nID: {e.Id}\nOld ID (if applicable): {e.OldId}";
        }
    }
}
