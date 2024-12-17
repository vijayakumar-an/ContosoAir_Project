/*

Licensed to the Software Freedom Conservancy (SFC) under one
or more contributor license agreements. See the NOTICE file
distributed with this work for additional information
regarding copyright ownership. The SFC licenses this file
to you under the Apache License, Version 2.0 (the
"License"); you may not use this file except in compliance
with the License. You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0 
Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an
"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, either express or implied. See the License for the
specific language governing permissions and limitations
under the License.

*/
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
    /// Implementation of the IBookedFlightHistory interface for interacting with the booked flights.
    /// Uses Selenium WebDriver to automate the interaction with the web application.
    /// </summary>
    public class BookedFlightHistory : IBookedFlightHistory
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        /// <summary>
        /// Initializes a new instance of the BookedFlightHistory class.
        /// Initializes WebDriver and WebDriverWait for Selenium automation.
        /// </summary>
        public BookedFlightHistory()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize(); // Maximizes the browser window
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Initialize WebDriverWait
        }

        /// <summary>
        /// Gets the current WebDriver instance.
        /// </summary>
        public IWebDriver Driver
        {
            get { return _driver; }
        }

        /// <summary>
        /// Navigates to the login page of the application.
        /// </summary>
        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");
            var loginButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            loginButton.Click();
        }

        /// <summary>
        /// Logs into the system with the provided username and password.
        /// </summary>
        /// <param name="username">Username for login</param>
        /// <param name="password">Password for login</param>
        public void Login(string username, string password)
        {
            var usernameField = _wait.Until(driver => driver.FindElement(By.Id("username")));
            var passwordField = _wait.Until(driver => driver.FindElement(By.Id("password")));
            var loginButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/main/section/div/div/div[3]/div/form/fieldset/button")));

            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            loginButton.Click();

            // Wait until the profile is loaded after a successful login
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
        /// Retrieves the list of booked flights for the logged-in user.
        /// </summary>
        /// <returns>A list of strings representing the booked flights.</returns>
        public IList<string> GetBookedFlights()
        {
            var flightListings = _wait.Until(driver => driver.FindElements(By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul")));
            var flightDetails = new List<string>();

            foreach (var listing in flightListings)
            {
                flightDetails.Add(listing.Text); // Add flight information to the list
            }

            return flightDetails;
        }

        /// <summary>
        /// Views details for a specific flight from the list.
        /// </summary>
        /// <param name="flightIndex">Index of the flight to view details for.</param>
        public void ViewFlightDetails(int flightIndex)
        {
            var flightListings = _driver.FindElements(By.XPath("/html/body/main/div/div/section/form/div[1]/div/ul"));

            if (flightIndex < 0 || flightIndex >= flightListings.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(flightIndex), "Invalid flight index.");
            }

            // Uncomment to interact with a "View Details" button for the selected flight
            // var viewDetailsButton = flightListings[flightIndex].FindElement(By.XPath(".//button[contains(text(), 'View Details')]"));
            // viewDetailsButton.Click();
        }

        /// <summary>
        /// Clicks on the "Shop for another flight" button on the booking page.
        /// </summary>
        public void ShopForAnotherFlight()
        {
            var shopForAnotherButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/main/div/div/section/a")));
            shopForAnotherButton.Click();
        }

        /// <summary>
        /// Clicks on the "Get another flight" button on the booking page.
        /// </summary>
        public void GetAnotherFlight()
        {
            var getAnotherFlightButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/main/div/div/section/form/div[2]/a")));
            getAnotherFlightButton.Click();
        }

        /// <summary>
        /// Logs the user out of the system.
        /// </summary>
        public void Logout()
        {
            var logoutButton = _wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(), 'Logout')]")));
            logoutButton.Click();
        }

        /// <summary>
        /// Cleans up resources and closes the browser session.
        /// </summary>
        public void Cleanup()
        {
            _driver.Quit(); // Close the browser
        }
    }
}