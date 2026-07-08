using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class SearchCommand : ICommand
    {
        private IReceiver _receiver;
        private IPrompter _prompter;

        public SearchCommand(IReceiver receiver, IPrompter prompter)
        {
            _receiver = receiver;
            _prompter = prompter;
        }

        public void Execute()
        {
            
            string searchField = _prompter.AskUserForSearchField(); //  "cartype"
            string searchValue = _prompter.AskUserForSearchValue(); //  "HybridCar"

            List<Car> foundCars = _receiver.SearchCar(searchField, searchValue);

            Console.WriteLine($"\n--- Search Results for {searchField}: {searchValue} ---");

            if (foundCars.Count == 0)
            {
                Console.WriteLine("No cars found matching that criteria.");
                return;
            }

            foreach (Car car in foundCars)
            {
                Console.WriteLine($"- [{car.Id}] {car.make} {car.model}");
            }
        }
    }
}
