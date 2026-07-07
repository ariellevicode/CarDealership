using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    internal class DealershipInventory
    {
        //using singleton to ensure only one instance of the inventory
        private static readonly Lazy<DealershipInventory> _instance = new Lazy<DealershipInventory>(() => new DealershipInventory());

        //object list to keep abstraction
        private Dictionary<string, Car> _inventory = new Dictionary<string, Car>();

        private DealershipInventory() { }


        public static DealershipInventory Instance
        {
            get { return _instance.Value; }
        }


        public void Add(Car car) { _inventory.TryAdd(car.Id, car); }
        public void Remove(string carId) { _inventory.Remove(carId); }
        public IReadOnlyList<object> Get() { return _inventory.Values.ToList().AsReadOnly(); }

        public Car GetCarById(string carId)
        {
            if (_inventory.TryGetValue(carId, out Car foundCar))
            {
                return foundCar;
            }
            return null; 
        }
    }
}
