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
        private CommandReciver _receiver;
        private CarConsolePrompter _prompter;

        
        public AddCommand(CommandReciver receiver, CarConsolePrompter prompter)
        {
            _receiver = receiver;
            _prompter = prompter;
        }

        public void Execute()
        {
            
            Car carToAdd = _prompter.AskUserForCarDetails("Add");

           
            if (carToAdd != null)
            {
                _receiver.AddCar(carToAdd);
            }
        }
    }
}
