using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    internal abstract class Car
    {
        public string make { get; }
        public string model { get; }
        public int year { get; }
        public double odometer { get; }

        // Protected constructor so only subclasses can call it
        protected Car(string make, string model, int year, double odometer)
        {
            this.make = make;
            this.model = model;
            this.year = year;
            this.odometer = odometer;
        }
    }
}
