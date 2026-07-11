using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;
using CarDealership.CLI;
using CarDealership.CLI.Commands;
using CarDealership.CLI.Inventory;

namespace CarDealership
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IPrompter prompter = new CarConsolePrompter();

            CLIApp app = new CLIApp(
                writer: DealershipInventory.Instance,
                baseReader: DealershipInventory.Instance,
                storage: DealershipInventory.Instance,
                prompter: prompter
            );

            app.Start();
        }
    }
}
