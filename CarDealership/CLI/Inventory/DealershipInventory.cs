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
        private static readonly Lazy<DealershipInventory> _instance = new Lazy<DealershipInventory>(()=> new DealershipInventory());

        //object list to keep abstraction
        private List<object> _inventory = new List<object>();

        
        private DealershipInventory()
        {
        }

        
        public static DealershipInventory Instance
        {
            get { return _instance.Value; }
        }

        
        public void Add(Car car) { _inventory.Add(car); }
        public void Remove(Car car) { _inventory.Remove(car); }
        public IReadOnlyList<object> Get() { return _inventory.AsReadOnly(); }

    }
}
