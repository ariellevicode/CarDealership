using CarDealership.CarClasses;
using CarDealership.CarCreation.Builders;

namespace CarDealership
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElectricCarBuilder eBuilder = new ElectricCarBuilder();
            eBuilder.reset(); 

            
            
            ElectricCar myRivian = (ElectricCar)eBuilder
                .SetMake("Rivian")
                .SetModel("R1T")
                .SetYear(2026)
                .SetOdometer(15.2)
                .SetBatteryCapacity(135.0)
                .SetKmPerKw(4.5)
                .SetChargeRate(210.0)
                .Build();

            HybridCarBuilder hybridCarBuilder = new HybridCarBuilder();
            hybridCarBuilder.reset();
            HybridCar myPrius = (HybridCar)hybridCarBuilder
                .SetMake("Toyota")
                .SetModel("Prius Prime")
                .SetYear(2025)
                .SetOdometer(0.0)
                .SetFuelType(FuelType.Gasoline)
                .SetTankCapacity(40.0)
                .SetKmPerLiter(22.5)
                .SetBatteryCapacity(13.6)
                .SetChargeRate(3.3)
                .SetHybridSystemType(HybridCarType.HEV)
                .Build();

        }
    }
}
