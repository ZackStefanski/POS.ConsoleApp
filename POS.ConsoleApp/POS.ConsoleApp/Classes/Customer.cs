namespace POS.ConsoleApp.Classes
{
    internal class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int _id { get; private set; }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
