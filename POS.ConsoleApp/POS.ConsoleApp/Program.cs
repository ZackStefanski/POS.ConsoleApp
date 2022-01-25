using System;

namespace POS
{
    class Program
    {
        public static void Main(string[] args)
        {
            // the "mainMenu()" is called to increase code legibility.
            mainMenu();
            string userInput;

            // a "while" loop will ensure that the program runs consistantly until the user decides to exit. 
            while ((userInput = Console.ReadLine()) != "9")
            {
                // "if" statements are used to allow the user to navigate through the console application.
                if (userInput == "1")
                {
                    Console.Clear();
                    Console.WriteLine("New Rental");
                    Console.WriteLine("Press 0 to return to the Main Menu");


                    // LEFT OFF HERE!!!!

                    // i copied this to help me parse through the inventory data i created in a csv file - https://www.csharp-console-examples.com/csharp-console/read-csv-file-in-c-console-application/
                    static string[,] LoadCSV(string filename)
                    {
                        string whole_file = File.ReadAllText(filename);

                        // \r used for mac? - come back to this & see if we can omit
                        whole_file = whole_file.Replace( '\n', '\r');
                        string[] lines = whole_file.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);

                        // See how many rows & colums there are 
                        int num_rows = lines.Length;
                        int num_cols = lines[0].Split(',').Length;

                        // allocate the data array
                        string[,] values = new string [num_rows, num_cols];

                        // using a for loop, we iterate through the number of rows and cols, essentially loading the data to be displayed later using a class. 
                        for (int r = 0; r < num_rows; r++)
                        {
                            string[] line_r = lines[r].Split(',');
                            for (int c=0; c<num_cols; c++)
                            {
                                values[r, c] = line_r[c];
                            }
                        }
                    }
                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Create New Customer");
                    Console.WriteLine("Press 0 to return to the Main Menu");
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    Console.WriteLine("View/Edit Customers");
                    Console.WriteLine("Press 0 to return to the Main Menu");
                }
                else if (userInput == "0")
                {
                    Console.Clear();
                    mainMenu();
                }
                else if (userInput == null || userInput == "")
                {
                    Console.WriteLine("please input a valid selection.");
                }
                else
                {
                    Console.WriteLine("please input a valid selection.");
                }
            }
            Console.Clear();
            Console.WriteLine("Goodbye for now! ... and don't forget the power cable!");
            Console.ReadLine();
        }

        private static void mainMenu()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("**** Point of Sale ****");
            Console.WriteLine("***********************");
            Console.WriteLine("");
            Console.WriteLine("Menu:");
            Console.WriteLine("1: New Rental");
            Console.WriteLine("2: Create New Customer");
            Console.WriteLine("3: View/Edit Customers");
            Console.WriteLine("9: Exit Application");
        }
    }
}
