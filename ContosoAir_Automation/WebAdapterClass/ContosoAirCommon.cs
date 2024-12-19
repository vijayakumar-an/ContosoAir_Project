using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdapterClass
{
    public class ContosoAirCommon
    {
        protected IWebDriver driver;
        protected String ApprUrl;
        protected String BrowserName = "chrome";
        /// <summary>
        /// Sets up the test environment by initializing the WebDriver and the Homepage instance.
        /// </summary>
        /// 
        public ContosoAirCommon()
        {
            if (BrowserName.StartsWith("chrome"))
            {
                ApprUrl = "http://contosoair.westus.cloudapp.azure.com:3000/";
                this.driver = new ChromeDriver();
                this.driver.Navigate().GoToUrl(ApprUrl);
            }
        }

        public ContosoAirCommon(IWebDriver driver)
        {
            if (BrowserName.StartsWith("chrome"))
            {
                ApprUrl = "http://contosoair.westus.cloudapp.azure.com:3000/";
                this.driver = new ChromeDriver();
                this.driver.Navigate().GoToUrl(ApprUrl);
            }
        }

    }
}
