using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    internal class InventorySerializer
    {
        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };
        //takes the object list and turns it into a json for later use
        public string ToJson(IReadOnlyList<object> items)
        {
            return JsonSerializer.Serialize(items, _options);
            
        }

        public void SaveToFile(IEnumerable<Car> cars, string filePath)
        {
            string json = JsonSerializer.Serialize(cars, _options);
            File.WriteAllText(filePath, json);
        }

        public List<Car> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Car>();

            }
            string json = File.ReadAllText(filePath);
            List<Car> loadedCars = JsonSerializer.Deserialize<List<Car>>(json, _options);
            if (loadedCars != null)
            {
                return loadedCars;
            }
            Console.WriteLine("failed to load from json");
            return new List<Car>();
            
            
        }

    }
}
