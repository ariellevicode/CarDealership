using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;
using CarDealership.CLI;

namespace CarDealership
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CLIApp c = new CLIApp();
            c.Start();
        }
    }
}
