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
        private CommandReciver _receiver;
        private CarConsolePrompter _prompter;


        public RemoveCommand(CommandReciver receiver, CarConsolePrompter prompter)
        {
            _receiver = receiver;
            _prompter = prompter;
        }

        public void Execute()
        {

            Car carToRemove = _prompter.AskUserForCarDetails("Remove");


            if (carToRemove != null)
            {
                _receiver.RemoveCar(carToRemove);
            }
        }
    }
}