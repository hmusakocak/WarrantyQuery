using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WarrantyQuery.DataObjects.JsonData;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WarrantyQuery.Functions
{
    public class DellFunctions
    {        //Opens selenium on background, fills-clicks and gets html data
        public static string DellGET(string serial)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(service, options);
            var url = "https://www.dell.com/support/home/tr-tr/product-support/servicetag/" + serial + "/overview";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(30000);
            string content = driver.PageSource;
            return content;
        }

        public static DellWarranty DellInformation(string serial)
        {
            var content = new Dictionary<string, string>();

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(DellGET(serial));

            var modelpath = "//*[@id='site-wrapper']/div/div[3]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/h1";
            var wendpath = "//*[@id='ps-inlineWarranty']/div[1]/div/p";
            var expcodepath = "//*[@id='site-wrapper']/div/div[3]/div[1]/div[2]/div[1]/div[2]/div/div/div/div[2]/div[1]/p[2]";

            var modelname = htmlDocument.DocumentNode.SelectSingleNode(modelpath).InnerText;
            var wend = htmlDocument.DocumentNode.SelectSingleNode(wendpath).InnerText;
            var expcode = htmlDocument.DocumentNode.SelectSingleNode(expcodepath).InnerText;

            content.Add("model", modelname);
            content.Add("warrantyEndDate", wend);
            content.Add("expressservicecode", expcode);

            var jsondata = JsonConvert.SerializeObject(content);
            var result = JsonConvert.DeserializeObject<DellWarranty>(jsondata);
            return result;
        }
    }
}
