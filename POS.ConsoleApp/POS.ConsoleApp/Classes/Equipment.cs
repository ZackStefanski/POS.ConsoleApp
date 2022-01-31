namespace POS.ConsoleApp.Classes
{
    public class Equipment
    {

        public string? Item { get; set; }
        public double Cost { get; set; }

        static int ID = 0;
        public int createID() => ID++;

        public static int ShowAllObjects()
        {
            return ID;
        }
            
        public void showDetails()
        {
            Console.WriteLine($"{this.ID}\t{this.Item}\t{this.Cost}");
        }

        // A constructor is used to allow us to create new equipment objects.
        public Equipment(string item, double cost)
        {
            Item = item;
            Cost = cost;
        }
    }
}
