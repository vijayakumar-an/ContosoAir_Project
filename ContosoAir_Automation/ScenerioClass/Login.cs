using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdapterClass;

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
        public void PerformLoginWithCredentials()
        {
            // Define test URL, username, and password
            string url = "http://contosoair.westus.cloudapp.azure.com:3000/";
            string username = "admin";
            string password = "admin";

            // Perform login steps
            loginTest.NavigateToUrl(url);
            loginTest.PerformLoginWithCredentials(username, password);
            Thread.Sleep(2000);
        }


        [Test]
        public void PerformLoginWithOutCredentials()
        {
            string url = "http://contosoair.westus.cloudapp.azure.com:3000/";

            // Step 1: Navigate to URL
            loginTest.NavigateToUrl(url);

            // Step 2: Perform login without credentials
            loginTest.PerformLoginWithOutCredentials();

            Thread.Sleep(2000); // Allow time for UI validation (optional)
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser after the test
            driver.Dispose();
        }
    }
}
