using CarDealership.CarClasses;

namespace CarDealership.CarCreation.Builders
{
    internal class HybridCarBuilder : CarBuilder
    {
        public HybridCar car;

        override public void reset()
        {
            car = new HybridCar();
        }

        
        override public HybridCarBuilder SetMake(CarMake make) { car.make = make; return this; }
        override public HybridCarBuilder SetModel(CarModel model) { car.model = model; return this; }
        override public HybridCarBuilder SetYear(int year) { car.year = year; return this; }
        override public HybridCarBuilder SetOdometer(double odometer) { car.odometer = odometer; return this; }

        override public HybridCarBuilder SetCarType(CarType type) { car.type = type; return this; }
       


        public HybridCarBuilder SetChargeRate(double chargeRate) { car.chargeRate = chargeRate; return this; }
        public HybridCarBuilder SetBatteryCapacity(double batteryCapacity) { car.batteryCapacity = batteryCapacity; return this; }
        public HybridCarBuilder SetFuelType(FuelType fuelType) { car.fuelType = fuelType; return this; }
        public HybridCarBuilder SetTankCapacity(double tankCapacity) { car.tankCapacity = tankCapacity; return this; }
        public HybridCarBuilder SetKmPerLiter(double kmPerLiter) { car.kmPerLiter = kmPerLiter; return this; }
        public HybridCarBuilder SetHybridSystemType(HybridCarType hybridCarType) { car.hybridCarType = hybridCarType; return this; }

        override public Car Build()
        {
            Car finishedCar = this.car;
            this.reset();
            return finishedCar;
        }
        
    }
}