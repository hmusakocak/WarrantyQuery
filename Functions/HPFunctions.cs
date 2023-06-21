using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using WarrantyQuery.DataObjects.JsonData;

namespace WarrantyQuery.Functions
{
    internal class HPFunctions
    {
        public static string HpGET(string serial)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://support.hp.com/tr-tr/check-warranty");
            Thread.Sleep(2000);
            var element = driver.FindElement(By.Id("inputtextpfinder"));
            element.SendKeys(serial);
            var button = driver.FindElement(By.Id("FindMyProduct"));
            button.Click();
            Thread.Sleep(2500);
            string content = driver.PageSource;
            return content;
        }

        public static HPWarranty HPInformation(string serial)
        {
            var content = new Dictionary<string, string>();

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(HpGET(serial));
            Thread.Sleep(4000);

            string modelpath = "//*[@id='directionTracker']/app-layout/app-check-warranty/div/div/div[2]/app-warranty-details/div/div[2]/div/div/h2";
            string status = "//*[@id='warrantyStatus']/div[2]/div[1]";
            string wend = "//*[@id='directionTracker']/app-layout/app-check-warranty/div/div/div[2]/app-warranty-details/div/div[2]/section/app-left-panel/div/div[5]/div[3]/div[2]";
            string wstart = "//*[@id='directionTracker']/app-layout/app-check-warranty/div/div/div[2]/app-warranty-details/div/div[2]/section/app-left-panel/div/div[5]/div[1]/div[2]";
            string wtype = "//*[@id='warrantyStatus']/div[2]/div[2]";

            var modelname = htmlDocument.DocumentNode.SelectSingleNode(modelpath).InnerText;
            var stat = htmlDocument.DocumentNode.SelectSingleNode(status).InnerText;
            var wendtime = htmlDocument.DocumentNode.SelectSingleNode(wend).InnerText;
            var wstarttime = htmlDocument.DocumentNode.SelectSingleNode(wstart).InnerText;
            var wtypestr = htmlDocument.DocumentNode.SelectSingleNode(wtype).InnerText;

            content.Add("model", modelname);
            content.Add("status", stat);
            content.Add("warrantyStartDate", wstarttime);
            content.Add("warrantyEndDate", wendtime);
            content.Add("warrantyType", wtypestr);

            var jsondata = JsonConvert.SerializeObject(content);
            var result = JsonConvert.DeserializeObject<HPWarranty>(jsondata);
            return result;

        }
    }
}
