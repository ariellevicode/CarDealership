using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    internal class DynamicPricingInventory : IInventoryReader
    {
        private readonly IInventoryReader _reader;
        private readonly IInventoryStorage _storage;

        
        public DynamicPricingInventory(IInventoryReader reader, IInventoryStorage storage)
        {
            _reader = reader;
            _storage = storage;
        }

        
        public List<Car> Search(string searchField, string searchValue)
        {
            
            List<Car> foundCars = _reader.Search(searchField, searchValue);

            if (foundCars.Count > 0)
            {
                
                foreach (Car car in foundCars)
                {
                    car.price = car.price * 1.02;
                }

                
                _storage.SaveDatabase();
            }

            return foundCars;
        }

        
        public IReadOnlyList<object> Get() { return _reader.Get(); }
        public Car GetCarById(string carId) { return _reader.GetCarById(carId); }
    }
}
