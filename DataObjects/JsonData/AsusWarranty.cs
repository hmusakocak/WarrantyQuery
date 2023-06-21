using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyQuery.DataObjects.JsonData
{
    public class AsusWarranty
    {
        [JsonProperty("model")]
        public string Model { get; set; }
        
        [JsonProperty("distributor")]
        public string Distributor { get; set; }
        
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("warrantyStartDate")]
        public string WarranyStartDate { get; set; }

        [JsonProperty("warrantyEndDate")]
        public string WarrantyEndDate { get; set; }

        [JsonProperty("warrantyExtension")]
        public string WarrantyExtension { get; set; }
    }
}
