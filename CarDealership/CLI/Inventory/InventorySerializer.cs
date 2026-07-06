using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarDealership.CLI.Inventory
{
    internal class InventorySerializer
    {
        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        //takes the object list and turns it into a json for later use
        public string ToJson(IReadOnlyList<object> items)
        {
            return JsonSerializer.Serialize(items, _options);
        }
    }
}
