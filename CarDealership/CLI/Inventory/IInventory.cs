using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    public interface IInventory
    {
        void Add(Car car);
        void Remove(string carId);
        IReadOnlyList<object> Get();
        Car GetCarById(string carId);
        List<Car> Search(string searchField, string searchValue);
        void SaveDatabase();


    }
}
