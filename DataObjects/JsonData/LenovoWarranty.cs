using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarrantyQuery.JsonDataObject
{
    public class LenovoWarranty
    {
        [JsonProperty("code")]
        public int code { get; set; }

        [JsonProperty("costMillis")]
        public int costMillis { get; set; }

        [JsonProperty("requestId")]
        public string requestId { get; set; }

        [JsonProperty("responseHost")]
        public string responseHost { get; set; }

        [JsonProperty("msg")]
        public Msg msg { get; set; }

        [JsonProperty("data")]
        public Data data { get; set; }
    }
    public class BaseWarranty
    {
        [JsonProperty("sdf")]
        public string sdf { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("deliveryType")]
        public string deliveryType { get; set; }

        [JsonProperty("lastDeliveryType")]
        public string lastDeliveryType { get; set; }

        [JsonProperty("deliveryTypeList")]
        public List<string> deliveryTypeList { get; set; }

        [JsonProperty("deliveryTypeName")]
        public string deliveryTypeName { get; set; }

        [JsonProperty("duration")]
        public int duration { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("startDate")]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        public string endDate { get; set; }

        [JsonProperty("level")]
        public string level { get; set; }
    }

    public class CurrentWarranty
    {
        [JsonProperty("sdf")]
        public string sdf { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("category")]
        public string category { get; set; }

        [JsonProperty("deliveryType")]
        public string deliveryType { get; set; }

        [JsonProperty("lastDeliveryType")]
        public string lastDeliveryType { get; set; }

        [JsonProperty("deliveryTypeList")]
        public List<string> deliveryTypeList { get; set; }

        [JsonProperty("deliveryTypeName")]
        public string deliveryTypeName { get; set; }

        [JsonProperty("duration")]
        public int duration { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("startDate")]
        public string startDate { get; set; }

        [JsonProperty("endDate")]
        public string endDate { get; set; }

        [JsonProperty("level")]
        public string level { get; set; }
    }

    public class Data
    {
        [JsonProperty("machineInfo")]
        public MachineInfo machineInfo { get; set; }

        [JsonProperty("baseWarranties")]
        public List<BaseWarranty> baseWarranties { get; set; }

        [JsonProperty("upgradeWarranties")]
        public List<object> upgradeWarranties { get; set; }

        [JsonProperty("contractWarranties")]
        public List<object> contractWarranties { get; set; }

        [JsonProperty("currentWarranty")]
        public CurrentWarranty currentWarranty { get; set; }

        [JsonProperty("hasActiveContract")]
        public bool hasActiveContract { get; set; }

        [JsonProperty("regularEndDate")]
        public object regularEndDate { get; set; }

        [JsonProperty("hasSpecialWarranty")]
        public bool hasSpecialWarranty { get; set; }

        [JsonProperty("regularDeliveryType")]
        public object regularDeliveryType { get; set; }

        [JsonProperty("warrantyRegistered")]
        public object warrantyRegistered { get; set; }

        [JsonProperty("oow")]
        public bool oow { get; set; }
    }

    public class MachineInfo
    {
        [JsonProperty("buildDate")]
        public string buildDate { get; set; }

        [JsonProperty("model")]
        public string model { get; set; }

        [JsonProperty("product")]
        public string product { get; set; }

        [JsonProperty("productName")]
        public string productName { get; set; }

        [JsonProperty("serial")]
        public string serial { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("imei")]
        public string imei { get; set; }

        [JsonProperty("popDate")]
        public string popDate { get; set; }

        [JsonProperty("swapImei")]
        public string swapImei { get; set; }

        [JsonProperty("shipToCountry")]
        public string shipToCountry { get; set; }

        [JsonProperty("shipDate")]
        public string shipDate { get; set; }

        [JsonProperty("brand")]
        public string brand { get; set; }

        [JsonProperty("series")]
        public string series { get; set; }

        [JsonProperty("group")]
        public string group { get; set; }

        [JsonProperty("productImage")]
        public string productImage { get; set; }

        [JsonProperty("baseStartDate")]
        public string baseStartDate { get; set; }

        [JsonProperty("eosDate")]
        public string eosDate { get; set; }

        [JsonProperty("maxDuration")]
        public int maxDuration { get; set; }

        [JsonProperty("tier")]
        public object tier { get; set; }

        [JsonProperty("tablet")]
        public bool tablet { get; set; }
    }

    public class Msg
    {
        [JsonProperty("desc")]
        public string desc { get; set; }

        [JsonProperty("value")]
        public object value { get; set; }
    }
}
