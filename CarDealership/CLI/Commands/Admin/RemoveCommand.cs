using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class RemoveCommand : ICommand
    {
        private readonly IInventoryWriter _writer;
        private readonly IInventoryReader _reader;
        private readonly IPrompter _prompter;

        public RemoveCommand(IInventoryWriter writer, IInventoryReader reader, IPrompter prompter)
        {
            _writer = writer;
            _reader = reader;
            _prompter = prompter;
        }

        public void Execute()
        {
            string targetId = _prompter.AskUserForCarId();
            Car carToRemove = _reader.GetCarById(targetId);

            if (carToRemove != null)
            {
                _writer.Remove(targetId);
                Console.WriteLine($"\n[Success] Car has been removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"\n[Error] No car found with ID: {targetId}");
            }
        }
    }
}