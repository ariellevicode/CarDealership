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
        private List<object> _inventory = new List<object>();
        public void AddCar(Car car)
        { _inventory.Add(car); }

        public void RemoveCar(Car car)
        { _inventory.Remove(car); }

        // Exposes the list in a read-only format so the serializer can read it 
        // without accidentally modifying the data.
        public IReadOnlyList<object> GetInventory()
        {
            return _inventory.AsReadOnly();
        }

    }
}
