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

            CarDealershipFacade appFacade = new CarDealershipFacade();
            appFacade.RunApplication();
        }
    }
}
