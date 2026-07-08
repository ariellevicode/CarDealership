using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;
using System;

namespace CarDealership.CLI
{
    internal class CarConsolePrompter : IPrompter
    {
        public Car AskUserForCarDetails(string actionType)
        {
            Console.WriteLine($"\n--- {actionType} Vehicle ---");

            Console.Write("Enter Make: ");
            string make = Console.ReadLine();

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Year: ");
            int year = int.Parse(Console.ReadLine()); // note:unsafe if user types a letter

            Console.Write("Enter Odometer: ");
            double odometer = double.Parse(Console.ReadLine());

            Console.Write("Enter Car type: (Electric : 1, Gas : 2, Hybrid : 3): ");
            CarType carType = (CarType)int.Parse(Console.ReadLine());

            switch (carType)
            {
                case CarType.Hybrid:
                    {
                        HybridCarBuilder hybridCarBuilder = new HybridCarBuilder();
                        hybridCarBuilder.reset();

                        Console.Write("Enter Tank capacity: ");
                        double tankCapacity = double.Parse(Console.ReadLine());

                        Console.Write("Enter Battery capacity: ");
                        double batteryCapacity = double.Parse(Console.ReadLine());

                        Console.Write("Enter Efficiency (km/l): ");
                        double kmPerLiter = double.Parse(Console.ReadLine());

                        Console.Write("Enter Maximum charge rate: ");
                        double maxChargeRateKw = double.Parse(Console.ReadLine());

                        Console.Write("Enter Fuel type: (Gasoline = 1, Diesel = 2, Ethanol = 3, Hydrogen = 4): ");
                        FuelType fuelType = (FuelType)int.Parse(Console.ReadLine());

                        Console.Write("Enter Hybrid type: (HEV = 1, PHEV = 2): ");
                        HybridCarType hybridCarType = (HybridCarType)int.Parse(Console.ReadLine());

                        Car hCar = hybridCarBuilder
                                .SetModel(model)
                                .SetMake(make)
                                .SetYear(year)
                                .SetCarType(carType)
                                .SetOdometer(odometer)
                                .SetFuelType(fuelType)
                                .SetTankCapacity(tankCapacity)
                                .SetHybridSystemType(hybridCarType)
                                .SetBatteryCapacity(batteryCapacity)
                                .SetKmPerLiter(kmPerLiter)
                                .SetChargeRate(maxChargeRateKw)
                                .Build();

                        return hCar;
                    }

                case CarType.Electric:
                    {
                        ElectricCarBuilder e = new ElectricCarBuilder();
                        e.reset();

                        Console.Write("Enter Battery capacity: ");
                        double batteryCapacity = double.Parse(Console.ReadLine());

                        Console.Write("Enter Efficiency (km/kw): ");
                        double kmPerKw = double.Parse(Console.ReadLine());

                        Console.Write("Enter Maximum charge rate: ");
                        double maxChargeRateKw = double.Parse(Console.ReadLine());


                        Car eCar = e.SetModel(model)
                                .SetMake(make)
                                .SetYear(year)
                                .SetCarType(carType)
                                .SetOdometer(odometer)
                                .SetBatteryCapacity(batteryCapacity)
                                .SetKmPerKw(kmPerKw)
                                .SetChargeRate(maxChargeRateKw)
                                .Build();

                        return eCar;
                    }
                case CarType.Gas:
                    {
                        HybridCarBuilder hybridCarBuilder = new HybridCarBuilder();
                        hybridCarBuilder.reset();

                        Console.Write("Enter Tank capacity: ");
                        double tankCapacity = double.Parse(Console.ReadLine());


                        Console.Write("Enter Efficiency (km/l): ");
                        double kmPerLiter = double.Parse(Console.ReadLine());

                        Console.Write("Enter Fuel type: (Gasoline = 1, Diesel = 2, Ethanol = 3, Hydrogen = 4): ");
                        FuelType fuelType = (FuelType)int.Parse(Console.ReadLine());

                        Car gCar = hybridCarBuilder
                                .SetModel(model)
                                .SetMake(make)
                                .SetYear(year)
                                .SetCarType(carType)
                                .SetOdometer(odometer)
                                .SetFuelType(fuelType)
                                .SetTankCapacity(tankCapacity)
                                .SetKmPerLiter(kmPerLiter)
                                .Build();


                        return gCar;
                    }

                default:
                    Console.WriteLine("[Error] Unsupported car type.");
                    return null;
            }
        }
        public string AskUserForCarId()
        {
            while (true)
            {
                Console.Write("\nEnter the Unique ID of the car: ");
                string inputId = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(inputId))
                {
                    return inputId;
                }

                Console.WriteLine("[Error] ID cannot be empty. Please try again.");
            }
        }
    }
}