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

        private IReceiver _receiver;

        public ViewInventoryCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.PrintInventory();
        }

    }
}

