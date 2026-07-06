using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal class HybridCar : Car
    {
        public double tankCapacity { get; }
        public FuelType fuelType { get; }
        public double kmPerLiter { get; }
        public double batteryCapacity { get; }
        public HybridCarType hybridCarType { get; }
        public double chargeRate { get; }
        public HybridCar(string make, double odometer, string model, int year, double tankCapacity, FuelType fuel, HybridCarType hybridCarType, double batteryCapacityKwh, double chargeRate)
        : base(make, model, year,odometer)
        {
            this.tankCapacity = tankCapacity;
            this.kmPerLiter = kmPerLiter;
            this.fuelType = fuelType;
            this.hybridCarType = hybridCarType;
            this.chargeRate = chargeRate;
            this.batteryCapacity = batteryCapacityKwh;
        }
    }
}
