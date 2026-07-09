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

        private readonly object _inventoryLock = new object();

        private readonly string _filePath = "cars.json";

        private DealershipInventory()
        {
            _registry.Add("make", new CarIndex(car => car.make.ToString()));
            _registry.Add("model", new CarIndex(car => car.model.ToString()));
            _registry.Add("cartype", new CarIndex(car => car.type.ToString()));
            LoadDatabaseOnStartup();

        }


        public static DealershipInventory Instance
        {
            get { return _instance.Value; }
        }

        private void LoadDatabaseOnStartup()
        {
            InventorySerializer serializer = new InventorySerializer();
            List<Car> LoadedCars = serializer.LoadFromFile(_filePath);

            
            lock (_inventoryLock)
            {
                
                foreach (Car car in LoadedCars)
                {
                    if (_inventory.TryAdd(car.Id, car))
                    {
                        foreach (var index in _registry.Values)
                        {
                            string propertyValue = index.ValueExtractor(car);
                            if (!index.Map.ContainsKey(propertyValue))
                            {
                                index.Map[propertyValue] = new List<string>();
                            }
                            index.Map[propertyValue].Add(car.Id);
                        }
                    }
                }
            }
        }

        private void SaveDatabase()
        {
            // We extract the current inventory and hand it to the serializer
            InventorySerializer serializer = new InventorySerializer();
            serializer.SaveToFile(_inventory.Values, _filePath);
        }

        public void Add(Car car)
        {
            lock (_inventoryLock)
            {
                if (_inventory.TryAdd(car.Id, car))
                {
                    foreach (var index in _registry.Values)// for each CarIndex
                    {
                        string propertyValue = index.ValueExtractor(car);//"toyota" , "ferrari" 
                        if (!index.Map.ContainsKey(propertyValue)) // if it doesnt contain the key("toyota")
                        {
                            index.Map[propertyValue] = new List<string>();// add the value (id list)
                        }
                        index.Map[propertyValue].Add(car.Id);// add the id to the stirng list2
                    }
                    SaveDatabase();
                }
            }
           
        }


        public void Remove(string carId) 
        {
            lock (_inventoryLock)
            {
                if (_inventory.TryGetValue(carId, out Car carToRemove))
                {

                    foreach (var index in _registry.Values)
                    {
                        string propertyValue = index.ValueExtractor(carToRemove);
                        if (index.Map.ContainsKey(propertyValue))
                        {
                            index.Map[propertyValue].Remove(carId);
                        }
                    }


                    _inventory.Remove(carId);
                }
                SaveDatabase();
            }

        }
        
        
        public IReadOnlyList<object> Get() 
        {
            lock (_inventoryLock)
            {
                return _inventory.Values.ToList().AsReadOnly();
            }
           
        }

        
        
        public Car GetCarById(string carId)
        {
            lock (_inventoryLock)
            {
                if (_inventory.TryGetValue(carId, out Car foundCar))
                {
                    return foundCar;
                }
                return null;
            }
            
        }

        public List<Car> Search(string searchField, string searchValue)
        {
            lock (_inventoryLock)
            {
                List<Car> results = new List<Car>();


                if (_registry.TryGetValue(searchField, out CarIndex index))
                {

                    if (index.Map.TryGetValue(searchValue, out List<string> matchingIds))
                    {

                        foreach (string id in matchingIds)
                        {
                            results.Add(_inventory[id]);
                        }
                    }
                }
                return results;
            }

            
        }

    }
}
