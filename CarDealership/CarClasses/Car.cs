using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal abstract class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public double odometer { get; set; }

        public CarType type { get; set; }
        
    }
}
