using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarrantyQuery.DataObjects.JsonData;
using Newtonsoft.Json;

namespace WarrantyQuery.Functions
{
    public class AsusFunctions
    {
        //Opens selenium on background, fills-clicks and gets html data
        public static string AsusGET(string serial)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://eu-rma.asus.com/tr/info/warranty");
            Thread.Sleep(2000);
            var element = driver.FindElement(By.Id("sn"));
            element.SendKeys(serial);
            var button = driver.FindElement(By.XPath("//html/body/div[2]/div[1]/section[1]/div/div[3]/form/div/div[2]/button"));
            button.Click();
            Thread.Sleep(2500);
            string content = driver.PageSource;
            driver.Quit();
            return content;
        }

        //html data parsing and converting to json data
        public static AsusWarranty AsusInformation(string serial)
        {
            var content = new Dictionary<string, string>();

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(AsusGET(serial)); 
            string path = "";
            string[] parameters = {"model", "distributor", "country", "warrantyStartDate", "warrantyEndDate", "warrantyExtension" };
            for (int i = 1; i < 7; i++)
            {
                path = string.Format("//html/body/div[2]/div[1]/section[2]/div/div[3]/ul/li[{0}]/text()",i);
                var node = htmlDocument.DocumentNode.SelectSingleNode(path).InnerText;
                content.Add(parameters[i-1],node);
            }           
            var jsondata = JsonConvert.SerializeObject(content);
            var result =  JsonConvert.DeserializeObject<AsusWarranty>(jsondata);
            return result;
        }
    }
}
