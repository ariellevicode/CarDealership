using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Commands
{
    internal class CommandReciver : IReceiver
    {
        private DealershipInventory _database;
        public CommandReciver()
        {
            _database = DealershipInventory.Instance;
        }

        public void AddCar(Car car)
        {

            _database.Add(car);
            Console.WriteLine($"[System] Added car to inventory.");
        }

        public void RemoveCar(string carId)
        {
            _database.Remove(carId);
        }

        public List<Car> SearchCar(string searchField, string searchValue)
        {
            return _database.Search(searchField, searchValue);
        }


        public Car GetCarById(string carId)
        {
            return _database.GetCarById(carId);
        }
        public void PrintInventory()
        {
            InventorySerializer serializer = new InventorySerializer();

            var currentList = _database.Get();

            string jsonOutput = serializer.ToJson(currentList);

            Console.WriteLine(jsonOutput);
        }
    }
}
