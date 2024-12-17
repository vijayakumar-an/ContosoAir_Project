using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceClass;
namespace WebAdapterClass
{
    /// <summary>
    /// Implementation of IBookedFlightHistory for interacting with booked flights.
    /// </summary>
    public class BookedFlightHistory : IBookedFlightHistory
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        /// <summary>
        /// Initializes the WebDriver and WebDriverWait.
        /// </summary>
        public BookedFlightHistory()
        {
            // Initialize Chrome WebDriver
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize(); // Maximize the browser window

            // Initialize WebDriverWait with a 10-second timeout
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Public property to expose the WebDriver instance.
        /// </summary>
        public IWebDriver Driver
        {
            get { return _driver; }
        }

        /// <summary>
        /// Navigates to the login page.
        /// </summary>
        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");

            // Wait for and click on the "Login" button
            var loginButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            loginButton.Click();
        }

        /// <summary>
        /// Logs into the system with provided username and password.
        /// </summary>
        public void Login(string username, string password)
        {
            var usernameField = _wait.Until(driver => driver.FindElement(By.Id("username")));
            var passwordField = _wait.Until(driver => driver.FindElement(By.Id("password")));
            var loginButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button")));

            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();

            // Wait for the profile to appear, indicating successful login
            _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[1]/span/a")));
        }

        /// <summary>
        /// Navigates to the "My Booked Flights" page.
        /// </summary>
        public void NavigateToMyBookedFlightsPage()
        {
            var myBookedFlightsButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            myBookedFlightsButton.Click();
        }

        /// <summary>
        /// Retrieves the list of booked flights.
        /// </summary>
        public IList<string> GetBookedFlights()
        {
            var flightListings = _wait.Until(driver => driver.FindElements(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            var flightDetails = new List<string>();

            foreach (var listing in flightListings)
            {
                flightDetails.Add(listing.Text);
            }

            return flightDetails;
        }

        /// <summary>
        /// Views the details of a specific flight from the list.
        /// </summary>
        public void ViewFlightDetails(int flightIndex)
        {
            var flightListings = _driver.FindElements(By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul"));

            if (flightIndex < 0 || flightIndex >= flightListings.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(flightIndex), "Invalid flight index.");
            }

            //var viewDetailsButton = flightListings[flightIndex].FindElement(By.XPath(".//button[contains(text(), 'View Details')]"));
            //viewDetailsButton.Click();
        }

        /// <summary>
        /// Logs out from the system.
        /// </summary>
        public void Logout()
        {
            var logoutButton = _wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(), 'Logout')]")));
            logoutButton.Click();
        }

        /// <summary>
        /// Cleans up and closes the browser after the test.
        /// </summary>
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}