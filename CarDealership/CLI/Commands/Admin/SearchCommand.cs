using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands.Admin
{
    internal class SearchCommand : ICommand
    {
        private readonly IInventoryReader _reader;
        private readonly IPrompter _prompter;

        public SearchCommand(IInventoryReader reader, IPrompter prompter)
        {
            _reader = reader;
            _prompter = prompter;
        }

        public void Execute()
        {
            string searchField = _prompter.AskUserForSearchField();
            string searchValue = _prompter.AskUserForSearchValue();

            List<Car> foundCars = _reader.Search(searchField, searchValue);

            Console.WriteLine($"\n--- Search Results for {searchField}: {searchValue} ---");

            if (foundCars.Count == 0)
            {
                Console.WriteLine("No cars found matching that criteria.");
                return;
            }

            foreach (Car car in foundCars)
            {
                Console.WriteLine($"- [{car.Id}] {car.make} {car.model} - ${car.price}");
            }
        }
    }
}
