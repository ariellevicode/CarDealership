using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class AddCommand : ICommand
    {
        private readonly IInventoryWriter _writer;
        private readonly IPrompter _prompter;

        public AddCommand(IInventoryWriter writer, IPrompter prompter)
        {
            _writer = writer;
            _prompter = prompter;
        }

        public void Execute()
        {
            Car carToAdd = _prompter.AskUserForCarDetails("Add");

            if (carToAdd != null)
            {
                _writer.Add(carToAdd);
                Console.WriteLine($"[System] Added car to inventory.");
            }
        }
    }
}
