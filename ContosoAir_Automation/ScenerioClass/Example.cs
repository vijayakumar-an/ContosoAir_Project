using NUnit.Framework;
using OpenQA.Selenium;
using System.Xml.Serialization;
using WebAdapterClass;
using OpenQA.Selenium.Chrome;

namespace ScenerioClass
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
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("admin");
            driver.FindElement(By.CssSelector(".btn")).Click();
        }


    }
}