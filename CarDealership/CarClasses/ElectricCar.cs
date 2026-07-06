using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal class ElectricCar : Car
    {
        public double batteryCapacity { get; }
        public double kmPerKW { get; }
        public double chargeRate { get; }

        public ElectricCar(string make, string model, int year, double odometer, double batteryCapacityKwh, double kmPerKW, double chargeRate)
                : base(make, model, year, odometer)
        {
            this.kmPerKW = kmPerKW;
            this.chargeRate = chargeRate;
            this.batteryCapacity = batteryCapacityKwh;
        }
    }
}
