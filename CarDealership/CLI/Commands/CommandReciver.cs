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
    internal class CommandReciver
    {
        private DealershipInventory _database;
        public CommandReciver()
        {
            _database = DealershipInventory.Instance;
        }

        public void AddCar(Car car)
        {

            _database.Add(car);
            Console.WriteLine($"[System] Added {car.make} car to inventory.");
        }
        public void RemoveCar(Car car)
        {
            _database.Remove(car);
            Console.WriteLine($"[System] Attempted to remove {car.make} car.");
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
