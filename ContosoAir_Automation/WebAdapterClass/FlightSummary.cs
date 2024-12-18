using InterfaceClass;
using OpenQA.Selenium;
using System;
using static System.Collections.Specialized.BitVector32;

namespace WebAdapterClass
{
    /// <summary>
    /// The FlightSummary class implements IFlightSummary and provides functionality 
    /// for interacting with the flight booking application. It includes methods for navigating the website,
    /// performing login, booking flights, checking passenger details, and canceling bookings.
    /// </summary>
    public class FlightSummary : IFlightSummary
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the FlightSummary class with the specified WebDriver.
        /// </summary>
        /// <param name="webDriver">The WebDriver instance used to control the browser.</param>
        public FlightSummary(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        /// <summary>
        /// Navigates to the specified URL and maximizes the browser window.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Performs login with the given username and password.
        /// Throws an exception if either the username or password is null or empty.
        /// </summary>
        /// <param name="username">The username to log in.</param>
        /// <param name="password">The password associated with the username.</param>
        public void PerformLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be null or empty");
            }

            driver.FindElement(By.LinkText("Login")).Click();// Click login link
            driver.FindElement(By.Id("username")).SendKeys(username);// Enter username
            driver.FindElement(By.Id("password")).SendKeys(password);// Enter password
            driver.FindElement(By.CssSelector(".btn")).Click();// Click login button
        }

        /// <summary>
        /// Books a flight by selecting origin, destination, dates, and confirming the booking.
        /// This method automates the entire flight booking process.
        /// </summary>
        public void BookFlight()
        {
            driver.FindElement(By.LinkText("Book")).Click();// Navigate to the booking page

            // Select destination
            driver.FindElement(By.Id("toCode")).Click();
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Kabri Dar ABK']")).Click();

            // Select origin
            driver.FindElement(By.Id("fromCode")).Click();
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Novorossiysk AAQ']")).Click();

            // Select departure and arrival dates
            driver.FindElement(By.Id("dpb")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(5) > .day:nth-child(6)")).Click();
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(5)")).Click();

            // Click on flight search
            driver.FindElement(By.CssSelector(".row:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            // Select a flight
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(3) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Complete passenger details
            driver.FindElement(By.CssSelector(".block-booking-passenger")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();

        }

        /// <summary>
        /// Checks the passenger's name by booking a flight and proceeding to the passenger details page.
        /// </summary>
        public void checkPassengerName()
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Select destination
            driver.FindElement(By.Id("toCode")).Click();
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Kabri Dar ABK']")).Click();

            // Select origin
            driver.FindElement(By.Id("fromCode")).Click();
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Novorossiysk AAQ']")).Click();

            // Select departure and arrival dates
            driver.FindElement(By.Id("dpb")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(5) > .day:nth-child(6)")).Click();
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(5)")).Click();

            // Click on flight search
            driver.FindElement(By.CssSelector(".row:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            // Select a flight
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(3) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            // Complete passenger details
            driver.FindElement(By.CssSelector(".block-booking-passenger")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();

        }

        /// <summary>
        /// Cancels a flight booking by selecting the flight, confirming the booking, 
        /// and then initiating the cancellation process.
        /// </summary>
        public void checkCancelBooking()
        {
            // Navigate to "Book"
            driver.FindElement(By.LinkText("Book")).Click();

            // Select destination
            driver.FindElement(By.Id("toCode")).Click();
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath("//option[. = 'Winisk YMO']")).Click();

            // Select origin
            driver.FindElement(By.Id("fromCode")).Click();
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath("//option[. = 'Teniente R. Marsh TNM']")).Click();

            // Select departure date
            driver.FindElement(By.Id("dpb")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(6) > .day:nth-child(2)")).Click();

            // Select return date
            driver.FindElement(By.Id("dpa")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(4) > .day:nth-child(6)")).Click();

            // Select passengers
            driver.FindElement(By.Id("passengers")).Click();
            var passengerDropdown = driver.FindElement(By.Id("passengers"));
            passengerDropdown.FindElement(By.XPath("//option[. = '2']")).Click();

            // Search for flights
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            // Select outbound flight
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(6) .big-blue-radio")).Click();

            // Select return flight
            driver.FindElement(By.CssSelector(".row:nth-child(6) .block-flights-results-list-item:nth-child(6) .big-blue-radio")).Click();

            // Confirm booking
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Cancel booking
            driver.FindElement(By.LinkText("Cancel")).Click();

            // Update passengers after canceling
            driver.FindElement(By.Id("passengers")).Click();
            var updatedPassengerDropdown = driver.FindElement(By.Id("passengers"));
            updatedPassengerDropdown.FindElement(By.XPath("//option[. = '3']")).Click();

            // Finalize changes
            driver.FindElement(By.CssSelector(".block-search-form-title")).Click();
        }


    }
}
