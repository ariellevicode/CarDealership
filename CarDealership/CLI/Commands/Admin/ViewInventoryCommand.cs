using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class ViewInventoryCommand : ICommand
    {
        private readonly IInventoryReader _reader;

        public ViewInventoryCommand(IInventoryReader reader)
        {
            _reader = reader;
        }

        public void Execute()
        {
            InventorySerializer serializer = new InventorySerializer();
            var currentList = _reader.Get();
            string jsonOutput = serializer.ToJson(currentList);
            Console.WriteLine(jsonOutput);
        }
    }
}

