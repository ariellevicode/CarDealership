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
        private IReceiver _receiver;
        private IPrompter _prompter;

        //  Create separate dictionaries for each role
        private Dictionary<string, ICommand> _adminCommands = new Dictionary<string, ICommand>();
        private Dictionary<string, ICommand> _customerCommands = new Dictionary<string, ICommand>();

        public CLIApp(IReceiver receiver, IPrompter prompter)
        {

            _receiver = receiver;
            _prompter = prompter;

            // created as to not create two diffrent instances of remove command as both the admin and the customer use it
            ICommand removeCommand = new RemoveCommand(_receiver, _prompter);

            // ADMIN commands
            _adminCommands.Add("add", new AddCommand(_receiver, _prompter));
            _adminCommands.Add("remove", removeCommand);
            _adminCommands.Add("print", new ViewInventoryCommand(_receiver));


            // CUSTOMER commands

            _customerCommands.Add("buy", removeCommand);
            _customerCommands.Add("print", new ViewInventoryCommand(_receiver));
        }

        private void RunAdminLoop()
        {
            while (true)
            {
                Console.Write("\n[ADMIN] Enter a command: ");
                string userInput = Console.ReadLine()?.ToLower();

                if (userInput == "logout") return;

                
                if (_adminCommands.ContainsKey(userInput))
                {
                    _adminCommands[userInput].Execute();
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
            }
        }
        private void RunCustomerLoop()
        {
            while (true)
            {
                Console.Write("\n[CUSTOMER] Enter a command (buy, print, logout): ");
                string userInput = Console.ReadLine()?.ToLower();

                if (userInput == "logout") return;

                
                if (_customerCommands.ContainsKey(userInput))
                {
                    _customerCommands[userInput].Execute();
                }

                else
                {
                    Console.WriteLine("Invalid command or insufficient permissions.");
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("=== Welcome to the Dealership Management System ===");

            while (true)
            {
                
                Console.Write("\nLogin as (admin / customer) or type 'exit': ");

                
                string role = Console.ReadLine()?.Trim().ToLower();

                
                if (role == "exit")
                {
                    Console.WriteLine("Shutting down the system. Goodbye!");
                    return; 
                }

                
                else if (role == "admin")
                {
                    Console.Write("Enter Admin Password: ");
                    string password = Console.ReadLine();

                    if (password == "admin")
                    {
                        Console.WriteLine("\n[System] Admin access granted.");

                        
                        RunAdminLoop();
                    }
                    else
                    {
                        Console.WriteLine("[Error] Incorrect password. Access denied.");
                    }
                }

                
                else if (role == "customer")
                {
                    Console.WriteLine("\n[System] Welcome, valued customer!");

                    
                    RunCustomerLoop();
                }

                
                else
                {
                    Console.WriteLine("[Error] Unknown role. Please type 'admin', 'customer'.");
                }
            }
        }

    }
}
