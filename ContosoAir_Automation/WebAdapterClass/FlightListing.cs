using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAdapterClass
{
    /// <summary>
    /// Implementation of the IFlightListing interface for handling flight bookings using Selenium WebDriver.
    /// </summary>
    public class FlightListing : IFlightListing
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        /// <summary>
        /// Initializes the WebDriver and WebDriverWait.
        /// </summary>
        public FlightListing()
        {
            // Initialize Chrome WebDriver
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();  // Maximize the browser window

            // Initialize WebDriverWait with a 10-second timeout
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Property to expose the driver for testing purposes.
        /// </summary>
        public IWebDriver Driver
        {
            get { return _driver; }
        }

        /// <summary>
        /// Navigates to the booking page and handles login if required.
        /// </summary>
        public void NavigateToBookingPage()
        {
            _driver.Navigate().GoToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");

            // Wait for and click on the "Login" button
            var loginButton = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a")));
            loginButton.Click();
        }
        /// <summary>
        /// Logs the user into the website.
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
        /// Selects the flight type (Round trip, One way, etc.).
        /// </summary>
        public void SelectFlightType(string flightType)
        {
            var flightTypeOption = _wait.Until(driver => driver.FindElement(By.XPath($"//label[contains(text(), '{flightType}')]")));
            flightTypeOption.Click();
        }

        /// <summary>
        /// Selects the departure location from a dropdown.
        /// </summary>
        public void SelectDepartureLocation(string fromLocation)
        {
            var fromDropdown = new SelectElement(_driver.FindElement(By.Id("fromCode")));
            fromDropdown.SelectByText(fromLocation);
        }

        /// <summary>
        /// Selects the arrival location from a dropdown.
        /// </summary>
        public void SelectArrivalLocation(string toLocation)
        {
            var toDropdown = new SelectElement(_driver.FindElement(By.Id("toCode")));
            toDropdown.SelectByText(toLocation);
        }

        /// <summary>
        /// Sets the departure date for the flight.
        /// </summary>
        public void SetDepartureDate(DateTime departureDate)
        {
            var departDateInput = _driver.FindElement(By.Id("DepartDate"));
            departDateInput.SendKeys(departureDate.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// Sets the return date for the flight.
        /// </summary>
        public void SetReturnDate(DateTime returnDate)
        {
            var returnDateInput = _driver.FindElement(By.Id("ReturnDate"));
            returnDateInput.SendKeys(returnDate.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// Selects the number of passengers for the flight.
        /// </summary>
        public void SelectPassengers(int numberOfPassengers)
        {
            var passengersDropdown = new SelectElement(_driver.FindElement(By.Id("Passengers")));
            passengersDropdown.SelectByValue(numberOfPassengers.ToString());
        }

        /// <summary>
        /// Submits the flight search request.
        /// </summary>
        public void SubmitFlightSearch()
        {
            var searchButton = _driver.FindElement(By.XPath("//button[contains(text(), 'Search')]"));
            searchButton.Click();
        }

        /// <summary>
        /// Retrieves a list of available flights after the search.
        /// </summary>
        public IList<string> GetAvailableFlights()
        {
            var availableFlightsTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(), 'Available flights')]")));
            var flightListings = _driver.FindElements(By.XPath("//div[contains(@class, 'flight-listing')]"));
            return flightListings.Select(flight => flight.Text).ToList();
        }

        /// <summary>
        /// Selects a flight from the available listings.
        /// </summary>
        public void SelectFlight(int flightIndex)
        {
            var flightListings = _driver.FindElements(By.XPath("//div[contains(@class, 'flight-listing')]"));
            if (flightIndex < flightListings.Count)
            {
                var selectButton = flightListings[flightIndex].FindElement(By.XPath(".//button[contains(text(), 'Select')]"));
                selectButton.Click();
            }
            else
            {
                throw new ArgumentException("Invalid flight index.");
            }
        }
        

        /// <summary>
        /// Checks if the login form is required (by detecting the username field).
        /// </summary>
        private bool IsLoginRequired()
        {
            try
            {
                _wait.Until(driver => driver.FindElement(By.Id("username")));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
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