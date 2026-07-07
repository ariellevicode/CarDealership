using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI
{
    internal interface IReceiver
    {
        void AddCar(Car car);
        void RemoveCar(Car car);
        void PrintInventory();
    }
}
