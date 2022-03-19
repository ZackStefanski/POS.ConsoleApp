# Inventory Management Console App
Welcome! This is a Inventory Management Application I built for my first semester at **Code Louisville** - Spring '22. The app is specifically designed to assist with that of a generic music store's inventory. Each item added to the inventory is an iteration of the "Equipment" class. It has It is very loosely based off an application I used at a former place of employment. 
## Features
The three features I applied the following... 

 - Implement a “master loop” console application where the user can
   repeatedly enter commands/perform actions, including choosing to exit
   the program 
 - Create a dictionary or list, populate it with several
   values, retrieve at least one value, and use it in your program 
 - Read data from an external file, such as text, JSON, CSV, etc and use that
   data in your application
## Notes
My app begins by calling `InventoryRepository.InitializeInventory();`.
This method creates a working list object which reads information saved to a CSV file that is saved to the following location: *POS.ConsoleApp\POS.ConsoleApp\POS.ConsoleApp\Docs\inventory.csv*
In the event that this file is not located here, I have included a copy of this inventory in the folder so that you may place it in /Docs


> Written with [StackEdit](https://stackedit.io/).