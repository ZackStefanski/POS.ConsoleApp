using POS.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ConsoleApp.Classes
{
    public class Store : IStore
    {
        public string Name { get; set; }

        public List<Equipment> inventory = InventoryRepository.InitializeInventory();

        public List<Equipment> listOfDeletedItems = InventoryRepository.InitializeListOfDeletedItems();

    }
}
