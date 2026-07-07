using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class AddCommand  : ICommand
    {
        private CommandReciver _receiver;
        private Car _carToAdd;


        public AddCommand(CommandReciver receiver , Car carToAdd)
        {
            _receiver = receiver;
            _carToAdd = carToAdd;

        }

        public void Execute()
        {
            _receiver.AddCar(_carToAdd);
        }
    }
}
