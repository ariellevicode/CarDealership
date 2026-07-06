using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal class GasCar : Car
    {
        public double tankCapacity { get; }
        public FuelType fuelType { get; }
        public double kmPerLiter { get; }
        public GasCar(string make, double odometer, string model, int year, double tankCapacity, FuelType fuelType, double kmPerLiter)
        : base(make, model, year, odometer)
        {
            this.tankCapacity = tankCapacity;
            this.kmPerLiter = kmPerLiter;
            this.fuelType = fuelType;
        }
    }
}
