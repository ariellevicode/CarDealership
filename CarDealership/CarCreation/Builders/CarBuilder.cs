using CarDealership.CarClasses;

namespace CarDealership.CarCreation.Builders
{
    // changed from interface to abstract class
    internal abstract class CarBuilder
    {
        public abstract void reset();

        public abstract CarBuilder SetMake(string make);
        public abstract CarBuilder SetModel(string model);
        public abstract CarBuilder SetYear(int year);
        public abstract CarBuilder SetOdometer(double odometer);

        public abstract Car Build();
    }
}