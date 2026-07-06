using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarCreation.Factories
{
    internal interface ICarFactory
    {
        Car CreateCar(string make, string model, int year, double odometer);
    }
}
