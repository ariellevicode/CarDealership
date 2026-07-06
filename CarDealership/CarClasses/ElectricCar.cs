using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal class ElectricCar : Car
    {
        public double batteryCapacity { get; set; }
        public double kmPerKW { get; set; }
        public double chargeRate { get; set; }

        
    }
}
