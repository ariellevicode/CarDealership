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
        public double tankCapacity { get; set; }
        public FuelType fuelType { get; set; }
        public double kmPerLiter { get; set; }
        
    }
}
