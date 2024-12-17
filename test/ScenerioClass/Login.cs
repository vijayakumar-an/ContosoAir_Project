using InterfaceClass;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdaptor;

namespace ScenerioClass
{
    // Scenario class for executing the login test
    [TestFixture]
    public class LoginScenario
    {
        private IWebDriver driver;
        private ILoginTest loginTest;

        [SetUp]
        public void SetUp()
        {
            // Initialize the WebDriver (e.g., ChromeDriver or any other driver)
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            loginTest = new LoginTest(driver);
        }

        [Test]
        public void TestLogin()
        {
            // Define test URL, username, and password
            string url = "http://34.134.208.225:3000/";
            string username = "admin";
            string password = "admin";

            // Perform login steps
            loginTest.NavigateToUrl(url);
            loginTest.PerformLogin(username, password);
            Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser after the test
            driver.Dispose();
        }
    }
}
