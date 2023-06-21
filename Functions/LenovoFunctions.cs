using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarrantyQuery.JsonDataObject;
using HtmlAgilityPack;
using System.Net;

namespace WarrantyQuery.Functions
{
    public class LenovoFunctions
    {
        public async static Task<LenovoProduct> LenovoGET(string serial)
        {
            //Lenovo API GET - getproducts
            string request_url = "https://pcsupport.lenovo.com/tr/tr/api/v4/mse/getproducts?productId=" + serial;
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(request_url);
            var content = await response.Content.ReadAsStringAsync();
            content = content.Substring(1, content.Length - 2);
            var jsonresult = JsonConvert.DeserializeObject<LenovoProduct>(content);
            return jsonresult;
        }

        public static string GetMachineType(string Id)
        {
            //Get machine type parameter with HTML parsing
            string url = "https://pcsupport.lenovo.com/tr/tr/products/" + Id;
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            WebClient webClient = new WebClient();
            htmlDocument.Load(webClient.OpenRead(url), Encoding.UTF8);
            var node = htmlDocument.DocumentNode.SelectSingleNode("//html/head/meta[25]").GetAttributeValue("content", "");
            return node;
        }

        public async static Task<LenovoWarranty> LenovoPOST(string serial)
        {
            //Lenovo API POST - IbaseInfo
            var data = await LenovoGET(serial);
            var mt = GetMachineType(data.Id);
            var dic = new Dictionary<string, string>()
            {
                {"country","tr"},
                {"language","tr"},
                {"machineType",mt },
                {"serialNumber",serial}
            };
            var serialized = JsonConvert.SerializeObject(dic);
            var content = new StringContent(serialized, null, "application/json");
            HttpClient httpClient = new HttpClient();
            var request = await httpClient.PostAsync("https://pcsupport.lenovo.com/tr/tr/api/v4/upsell/redport/getIbaseInfo", content);
            var response = await request.Content.ReadAsStringAsync();
            var jsonresult = JsonConvert.DeserializeObject<LenovoWarranty>(response);
            return jsonresult;
        }
    }
}