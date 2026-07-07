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
        private IReceiver _receiver;
        private IPrompter _prompter;


        public AddCommand(IReceiver receiver, IPrompter prompter)
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
