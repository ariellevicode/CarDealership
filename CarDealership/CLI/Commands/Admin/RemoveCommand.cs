using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class RemoveCommand
    {
        private CommandReciver _receiver;
        private Car _carToRemove;

        public RemoveCommand(CommandReciver receiver, Car car)
        {
            _receiver = receiver;
            _carToRemove = car;
        }

        public void Execute()
        {
            _receiver.RemoveCar(_carToRemove);
        }
    }
}
