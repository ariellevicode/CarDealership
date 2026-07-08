using CarDealership.CarClasses;

namespace CarDealership.CarCreation.Builders
{
    internal class GasCarBuilder : CarBuilder
    {
        public GasCar car;

        override public void reset()
        {
            car = new GasCar();
        }

        
        override public GasCarBuilder SetMake(CarMake make) { car.make = make; return this; }
        override public GasCarBuilder SetModel(CarModel model) { car.model = model; return this; }
        override public GasCarBuilder SetYear(int year) { car.year = year; return this; }
        override public GasCarBuilder SetOdometer(double odometer) { car.odometer = odometer; return this; }
        override public GasCarBuilder SetCarType(CarType type) { car.type = type; return this; }


        public GasCarBuilder SetFuelType(FuelType fuelType) { car.fuelType = fuelType; return this; }
        public GasCarBuilder SetTankCapacity(double tankCapacity) { car.tankCapacity = tankCapacity; return this; }
        public GasCarBuilder SetKmPerLiter(double kmPerLiter) { car.kmPerLiter = kmPerLiter; return this; }

        override public Car Build()
        {
            Car finishedCar = this.car;
            this.reset();
            return finishedCar;
        }
       
    }
}