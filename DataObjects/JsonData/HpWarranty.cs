using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyQuery.DataObjects.JsonData
{
    public class HPWarranty
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("warrantyStartDate")]
        public string WarranyStartDate { get; set; }

        [JsonProperty("warrantyEndDate")]
        public string WarrantyEndDate { get; set; }

        [JsonProperty("warrantyType")]
        public string WarrantyType { get; set; }

    }
}
