using CarDealership.CarClasses;
using CarDealership.CLI.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCar()
        {
            
            //add code
        }
        public void RemoveCar(Car car)
        {
            _database.Remove(car);
        }
        public void PrintInventory()
        {
            //print code
        }
    }
}
