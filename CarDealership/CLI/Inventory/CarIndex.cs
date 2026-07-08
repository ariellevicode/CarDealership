using CarDealership.CarClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    
    internal class CarIndex

    {
        public Dictionary<string, List<string>> Map { get; } = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
        public Func<Car, string> ValueExtractor { get; }

        

        public CarIndex(Func<Car, string> extractor)
        {
            ValueExtractor = extractor;
        }
    }
}
