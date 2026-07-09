using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CarCreation.Builders
{
    internal class ElectricCarBuilder : CarBuilder
    {
        public ElectricCar car;

        override public void reset()
        {
            car = new ElectricCar();
        }


         override public ElectricCarBuilder SetMake(CarMake make) { car.make = make; return this; }
        override public ElectricCarBuilder SetModel(CarModel model) { car.model = model; return this; }
        override public ElectricCarBuilder SetYear(int year) { car.year = year; return this; }
        override public ElectricCarBuilder SetOdometer(double odometer) { car.odometer = odometer; return this; }
        override public ElectricCarBuilder SetCarType(CarType type) { car.type = type; return this; }
        override public ElectricCarBuilder SetPrice(double price) { car.price = price; return this; }


        public ElectricCarBuilder SetChargeRate(double chargeRate) { car.chargeRate = chargeRate; return this; }
        public ElectricCarBuilder SetKmPerKw(double kmPerKw) { car.kmPerKW = kmPerKw; return this; }
        public ElectricCarBuilder SetBatteryCapacity(double batteryCapacity)
        {
            car.batteryCapacity = batteryCapacity; return this;
        }


        override public Car Build()
        {

            Car finishedCar = this.car;

            //optional but im reseting the car 
            this.reset();

            return finishedCar;
        }
        
        


    }
}
