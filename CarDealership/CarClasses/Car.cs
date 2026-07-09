using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarDealership.CarClasses
{
    [JsonDerivedType(typeof(GasCar), typeDiscriminator: "GasCar")]
    [JsonDerivedType(typeof(ElectricCar), typeDiscriminator: "ElectricCar")]
    [JsonDerivedType(typeof(HybridCar), typeDiscriminator: "HybridCar")]
    public abstract class Car
    {
        public string Id { get;  set; } = Guid.NewGuid().ToString();
        public CarMake make { get; set; }
        public CarModel model { get; set; }
        public int year { get; set; }
        public double odometer { get; set; }

        public CarType type { get; set; }

        public double price { get; set; }

    }
}
