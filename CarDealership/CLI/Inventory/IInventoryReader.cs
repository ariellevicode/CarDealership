using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    internal interface IInventoryReader
    {
        Car GetCarById(string carId);
        List<Car> Search(string searchField, string searchValue);
        IReadOnlyList<object> Get();
    }
}
