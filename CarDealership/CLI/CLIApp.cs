using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;
using CarDealership.CLI.Commands;
using CarDealership.CLI.Commands.Admin;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI
{
    internal class CLIApp
    {
        //temporary CLI app, will fully implement in the future
        private CommandReciver _inventoryReceiver;

        public CLIApp()
        {
            
            _inventoryReceiver = new CommandReciver();
        }
        
        public void Start()
        {
            Console.WriteLine("=== Dealership CLI Started ===");

            while (true)
            {
                Console.Write("Enter a command (add, print, exit): ");

                
                string userInput = Console.ReadLine()?.ToLower();

                
                switch (userInput)
                {
                    case "add":
                        
                        
                        ICommand addCmd = new AddCommand(_inventoryReceiver);
                        addCmd.Execute();
                        break;

                    case "print":
                        ICommand printCmd = new ViewInventoryCommand(_inventoryReceiver);
                        printCmd.Execute();
                        break;

                    case "exit":
                        return; 

                    default:
                        Console.WriteLine("Invalid command string.");
                        break;
                }
            }
        }
    }
}
