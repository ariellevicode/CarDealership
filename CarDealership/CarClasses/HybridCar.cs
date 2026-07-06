using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal class HybridCar : Car
    {
        public double tankCapacity { get; set; }
        public FuelType fuelType { get; set; }
        public double kmPerLiter { get; set; }
        public double batteryCapacity { get; set; }
        public HybridCarType hybridCarType { get; set; }
        public double chargeRate { get; set; }
        
    }
}
