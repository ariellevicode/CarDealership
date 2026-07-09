using CarDealership.CarClasses;

namespace CarDealership.CarCreation.Builders
{
    // changed from interface to abstract class
    internal abstract class CarBuilder
    {
        public abstract void reset();

        public abstract CarBuilder SetMake(CarMake make);
        public abstract CarBuilder SetModel(CarModel model);
        public abstract CarBuilder SetYear(int year);
        public abstract CarBuilder SetOdometer(double odometer);
        public abstract CarBuilder SetCarType(CarType type);
        public abstract CarBuilder SetPrice(double price);

        public abstract Car Build();
    }
}