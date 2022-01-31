using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ConsoleApp.Classes
{
    internal class Customer
    {
        public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public Customer(string name, int phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

    }
}
