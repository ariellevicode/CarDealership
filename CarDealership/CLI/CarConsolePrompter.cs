using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;
using System;

namespace CarDealership.CLI
{
    internal class CarConsolePrompter
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

            Console.Write("Enter Car type: (Hybrid, Electric, Gas): ");
            Enum.TryParse<CarType>(Console.ReadLine(), true, out CarType carType);

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

                        Console.Write("Enter Fuel type: (Gasoline, Diesel, Ethanol, Hydrogen): ");
                        Enum.TryParse<FuelType>(Console.ReadLine(), true, out FuelType fuelType);

                        Console.Write("Enter Hybrid type: (HEV, PHEV): ");
                        Enum.TryParse<HybridCarType>(Console.ReadLine(), true, out HybridCarType hybridCarType);

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

                        Console.Write("Enter Fuel type: (Gasoline, Diesel, Ethanol, Hydrogen): ");
                        Enum.TryParse<FuelType>(Console.ReadLine(), true, out FuelType fuelType);

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
    }
}