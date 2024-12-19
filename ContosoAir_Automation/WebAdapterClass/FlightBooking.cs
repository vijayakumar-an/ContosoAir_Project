using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAdapterClass
{
    public class FlightBooking : IFlightBooking
    {
        private IWebDriver driver;

        // Constructor to initialize the WebDriver
        public FlightBooking()
        {
            driver = new ChromeDriver();
        }

        // Implementing the Login method
        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("http://contosoair.westus.cloudapp.azure.com:3000");
            driver.Manage().Window.Maximize();

            // Navigate to login
            driver.FindElement(By.LinkText("Login")).Click();

            // Enter login credentials
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);

            // Click login button
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        // Implementing the SelectFlightDetails method
        public void SelectFlightDetails(string from, string to, DateTime departureDate, int numberOfPassengers, DateTime returnDate)
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Select 'from' location
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            new SelectElement(fromDropdown).SelectByText(from);

            // Select 'to' location
            var toDropdown = driver.FindElement(By.Id("toCode"));
            new SelectElement(toDropdown).SelectByText(to);

            // Set departure date
            driver.FindElement(By.Id("dpa")).SendKeys(departureDate.ToString("yyyy-MM-dd"));

            // Set return date
            driver.FindElement(By.Id("dpb")).SendKeys(returnDate.ToString("yyyy-MM-dd"));

            // Set number of passengers
            var passengersDropdown = driver.FindElement(By.Id("passengers"));
            new SelectElement(passengersDropdown).SelectByText(numberOfPassengers.ToString());

        }

        // Implementing the BookFlight method
        public void BookFlight()
        {
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            // Select flight option
            driver.FindElement(By.CssSelector(".block-flights-results-list-item:nth-child(2) .big-blue-radio")).Click();

            // Proceed to booking
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();
        }

        // Implementing the Close method to quit the driver
        public void Close()
        {
            driver.Quit();
        }

        // Additional method for retrieving booking confirmation title
        public string GetBookingConfirmationTitle()
        {
            return driver.FindElement(By.CssSelector(".block-booking-title")).Text;
        }

        public (string from, string to) GetBookingDetailsFromConfirmation()
        {
            // Locate the "From" and "To" elements on the confirmation page
            var fromLocation = driver.FindElement(By.CssSelector("body > main > section > div > div.cities--indicator.text-center > div:nth-child(2) > div:nth-child(1)")).Text;  // Update the CSS selector based on actual HTML
            var toLocation = driver.FindElement(By.CssSelector("body > main > section > div > div.cities--indicator.text-center > div:nth-child(2) > div:nth-child(3)")).Text;        // Update the CSS selector based on actual HTML

            return (fromLocation, toLocation);
        }
    }
}
