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

        
        private Dictionary<string, Car> _inventory = new Dictionary<string, Car>();

        private Dictionary<string , CarIndex> _registry = new Dictionary<string , CarIndex>(StringComparer.OrdinalIgnoreCase);


        private DealershipInventory()
        {
            _registry.Add("make", new CarIndex(car => car.make.ToString()));
            _registry.Add("model", new CarIndex(car => car.model.ToString()));
            _registry.Add("cartype", new CarIndex(car => car.type.ToString()));

        }


        public static DealershipInventory Instance
        {
            get { return _instance.Value; }
        }


        public void Add(Car car)
        {
            if (_inventory.TryAdd(car.Id, car))
            {
                foreach ( var index in _registry.Values)
                {
                    string propertyValue = index.ValueExtractor(car); // for example Toyota"
                    if (!index.Map.ContainsKey(propertyValue)) // if "Toyota" isnt in the map dict
                    {
                        index.Map[propertyValue] = new List<string>(); // create a new id string list for "Toyota"
                    }
                    index.Map[propertyValue].Add(car.Id);// else just add the id to the existing "Toyota" string list key
                }
            }

        }


        public void Remove(string carId) 
        {
            if (_inventory.TryGetValue(carId, out Car carToRemove)) // gets the car by its id while avoiding a crash if the car doesnt exist
            {
                
                foreach (var index in _registry.Values) // index is a CarIndex 
                {
                    string propertyValue = index.ValueExtractor(carToRemove); //"Toyota"
                    if (index.Map.ContainsKey(propertyValue)) 
                    {
                        index.Map[propertyValue].Remove(carId);
                    }
                }

                
                _inventory.Remove(carId);
            }
        }
        
        
        public IReadOnlyList<object> Get() 
        {
            return _inventory.Values.ToList().AsReadOnly(); 
        }

        
        
        public Car GetCarById(string carId)
        {
            if (_inventory.TryGetValue(carId, out Car foundCar))
            {
                return foundCar;
            }
            return null;
        }

        public List<Car> Search(string searchField, string searchValue) // for example "make" "Toyota"
        {
            List<Car> results = new List<Car>();

            
            if (_registry.TryGetValue(searchField, out CarIndex index)) // gets "make"'s key (carIndex)
            {
                
                if (index.Map.TryGetValue(searchValue, out List<string> matchingIds))//gets the CarIndex's key (list of ids)
                {
                    
                    foreach (string id in matchingIds) // for each id
                    {
                        results.Add(_inventory[id]);// add the id's corresponding car into the list
                    }
                }
            }
            return results; 
        }

    }
}
