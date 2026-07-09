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

            CLIApp app = new CLIApp(new CommandReciver(), new CarConsolePrompter());

            app.Start();
        }
    }
}
