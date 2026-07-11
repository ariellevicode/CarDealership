using CarDealership.CLI;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    internal class CarDealershipFacade
    {

        public void RunApplication()
        {
            IPrompter prompter = new CarConsolePrompter();
            var inventory = DealershipInventory.Instance;

            CLIApp app = new CLIApp(inventory, inventory, inventory, prompter);
            app.Start();
        }
    }
}
