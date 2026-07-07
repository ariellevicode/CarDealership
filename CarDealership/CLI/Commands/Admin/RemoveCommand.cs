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
        private IReceiver _receiver;
        private IPrompter _prompter;


        public RemoveCommand(IReceiver receiver, IPrompter prompter)
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