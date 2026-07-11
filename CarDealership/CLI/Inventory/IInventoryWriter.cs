using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    internal interface IInventoryWriter
    {
        void Add(Car car);
        void Remove(string carId);
    }
}
