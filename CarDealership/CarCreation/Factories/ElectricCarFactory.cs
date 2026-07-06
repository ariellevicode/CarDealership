using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarCreation.Factories
{
    internal class ElectricCarFactory : ICarFactory
    {
        Car CreateCar(string make, string model, int year, double odometer, double batteryCapacityKwh, double kmPerKW, double chargeRate)
        {
            return new ElectricCar(make, model, year, odometer, batteryCapacityKwh, kmPerKW, chargeRate);
        }
    }
}
