using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyQuery.DataObjects.JsonData
{
    public class DellWarranty
    {
        [JsonProperty("model")]
        public string Model { get; set; }    

        [JsonProperty("warrantyEndDate")]
        public string WarrantyEndDate { get; set; }

        [JsonProperty("expressservicecode")]
        public string ExpressServiceCode { get; set; }
    }
}
