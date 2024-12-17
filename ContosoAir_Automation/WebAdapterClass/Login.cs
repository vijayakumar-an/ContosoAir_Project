using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdapterClass
{
    // Class implementing the interface
    public class LoginTest : ILoginTest
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Constructor to initialize the WebDriver.
        /// </summary>
        /// <param name="driver">The WebDriver instance to control the browser.</param>
        public LoginTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
        }
        public void PerformLoginWithCredentials(string username, string password)
        {
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        public void PerformLoginWithOutCredentials()
        {
            // Click on the 'Login' link to navigate to the login form
            driver.FindElement(By.LinkText("Login")).Click();

            // Click the login button without entering any credentials
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Optional: Capture the alert or validation message
            var alertMessage = driver.FindElement(By.CssSelector(".alert > span")).Text;
            Console.WriteLine("Alert Message Displayed: " + alertMessage);
        }

    }
}
