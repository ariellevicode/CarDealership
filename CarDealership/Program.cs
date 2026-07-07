using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;
using CarDealership.CLI;
using CarDealership.CLI.Commands;

namespace CarDealership
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            IReceiver myReceiver = new CommandReciver();
            IPrompter myPrompter = new CarConsolePrompter();

            
            CLIApp app = new CLIApp(myReceiver, myPrompter);

            
            app.Start();
        }
    }
}
