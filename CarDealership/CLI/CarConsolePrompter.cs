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

            CarMake make = AskUserForMake();
            CarModel model = AskUserForModel();

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
        public string AskUserForSearchField()
        {
            while (true)
            {
                Console.WriteLine("\nAvailable search criteria: [Make, Model, CarType]");
                Console.Write("Enter what property you want to search by: ");
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("[Error] Search field cannot be empty.");
            }
        }


        public string AskUserForSearchValue()
        {
            while (true)
            {
                Console.Write("Enter the search term value (e.g., Toyota, Camry, HybridCar): ");
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("[Error] Search term value cannot be empty.");
            }
        }
        public CarMake AskUserForMake()
        {
            Console.WriteLine("\n=== Select Car Make ===");
            Console.WriteLine(" 1. Toyota       2. Honda          3. Subaru");
            Console.WriteLine(" 4. Ford         5. Chevrolet      6. Jeep");
            Console.WriteLine(" 7. BMW          8. MercedesBenz   9. Audi");
            Console.WriteLine("10. Tesla       11. Rivian        12. Porsche");
            Console.WriteLine("13. Ferrari");
            Console.Write("\nEnter the number for the Make: ");

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(CarMake), choice))
                {
                    return (CarMake)choice;
                }
                Console.Write("[Error] Invalid selection. Please enter a valid number from the list: ");
            }
        }

        public CarModel AskUserForModel()
        {
            Console.WriteLine("\n=== Select Car Model ===");
            Console.WriteLine("--- Toyota ---                 --- Honda ---");
            Console.WriteLine("101. Camry    104. Highlander  201. Civic      204. Pilot");
            Console.WriteLine("102. Corolla  105. Tacoma      202. Accord     205. Odyssey");
            Console.WriteLine("103. RAV4     106. Prius       203. CR_V       206. Ridgeline");

            Console.WriteLine("\n--- Subaru ---                 --- Ford ---");
            Console.WriteLine("301. Outback  304. Impreza     401. F150       404. Escape");
            Console.WriteLine("302. Forester 305. WRX         402. Mustang    405. Bronco");
            Console.WriteLine("303. Crosstrek                 403. Explorer   406. Ranger");

            Console.WriteLine("\n--- Chevrolet ---              --- Jeep ---");
            Console.WriteLine("501. Silverado 504. Tahoe      601. Wrangler   604. Compass");
            Console.WriteLine("502. Malibu    505. Corvette   602. Gr.Cherokee 605. Renegade");
            Console.WriteLine("503. Equinox   506. Camaro     603. Gladiator");

            Console.WriteLine("\n--- BMW ---                    --- Mercedes-Benz ---");
            Console.WriteLine("701. 3 Series  704. X5         801. C Class    804. GLC");
            Console.WriteLine("702. 5 Series  705. M4         802. E Class    805. G Wagon");
            Console.WriteLine("703. X3                        803. S Class");

            Console.WriteLine("\n--- Audi ---                   --- Tesla ---");
            Console.WriteLine("901. A4        904. Q7         1001. Model S   1004. Model Y");
            Console.WriteLine("902. A6        905. R8         1002. Model 3   1005. Cybertruck");
            Console.WriteLine("903. Q5                        1003. Model X");

            Console.WriteLine("\n--- Premium/Exotic ---");
            Console.WriteLine("1101. Rivian R1T     1201. Porsche 911     1301. Ferrari F8");
            Console.WriteLine("1102. Rivian R1S     1202. Cayenne         1302. Ferrari Roma");
            Console.WriteLine("                     1203. Macan           1303. SF90 Stradale");
            Console.WriteLine("                     1204. Panamera        1304. Purosangue");
            Console.WriteLine("                     1205. Taycan");

            Console.Write("\nEnter the number for the Model: ");

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(CarModel), choice))
                {
                    return (CarModel)choice;
                }
                Console.Write("[Error] Invalid selection. Please enter a valid number from the list: ");
            }
        }
    }
}