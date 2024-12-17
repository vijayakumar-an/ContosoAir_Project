using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml.Serialization;
using WebAdaptor;
using OpenQA.Selenium.Chrome;

namespace SeleniumAutomation.Tests
{
   
    public class PageTitleTest
    {

        private IWebDriver driver;


        [Test]
        public void login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://34.134.208.225:3000/");
            driver.FindElement(By.LinkText("Login")).Click();

        }


    }
}
