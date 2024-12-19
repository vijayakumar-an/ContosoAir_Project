using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebAdapterClass
{
    public class FlightSummary : IFlightSummary
    {
        private readonly IWebDriver driver;

        public FlightSummary()
        {
            driver = new ChromeDriver();
        }

        

        /// <summary>
        /// Logs in using the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
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

        /// <summary>
        /// Selects flight details for booking.
        /// </summary>
        /// <param name="from">The origin location.</param>
        /// <param name="to">The destination location.</param>
        /// <param name="departureDate">The departure date.</param>
        /// <param name="numberOfPassengers">The number of passengers.</param>
        /// <param name="returnDate">The return date.</param>
        public void SelectFlightDetails(string from, string to, DateTime departureDate, int numberOfPassengers, DateTime returnDate)
        {
            driver.FindElement(By.LinkText("Book")).Click();

            SelectDropdownValue("fromCode", from);
            SelectDropdownValue("toCode", to);

            driver.FindElement(By.Id("dpa")).SendKeys(departureDate.ToString("yyyy-MM-dd"));
            driver.FindElement(By.Id("dpb")).SendKeys(returnDate.ToString("yyyy-MM-dd"));
            SelectDropdownValue("passengers", numberOfPassengers.ToString());
        }

        /// <summary>
        /// Books the flight after selecting details.
        /// </summary>
        public void BookFlight()
        {
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            // Select flight option
            driver.FindElement(By.CssSelector(".block-flights-results-list-item:nth-child(2) .big-blue-radio")).Click();

            // Proceed to booking
            driver.FindElement(By.CssSelector(".btn")).Click();
            
            //driver.FindElement(By.CssSelector("body > main > section > div > form > div.text-center.text-md-right.block-booking-buttons > input.btn.btn-lg.btn-primary")).Click();
        }

        /// <summary>
        /// Checks the passenger's name on the confirmation page.
        /// </summary>
        public void CheckPassengerName()
        {
            string passengerName = driver.FindElement(By.CssSelector(".block-booking-passenger")).Text;
            if (string.IsNullOrEmpty(passengerName))
            {
                throw new Exception("Passenger name not found.");
            }
        }

        /// <summary>
        /// Cancels the flight booking.
        /// </summary>
        public void CheckCancelBooking()
        {
            driver.FindElement(By.CssSelector("body > main > section > div > form > div.text-center.text-md-right.block-booking-buttons > a")).Click();
        }

        /// <summary>
        /// Checks if the booking was successfully confirmed.
        /// </summary>
        /// <returns>True if booking confirmed, otherwise false.</returns>
        public bool IsBookingConfirmed()
        {
            return driver.FindElements(By.CssSelector(".block-booking")).Count > 0;
        }

        /// <summary>
        /// Gets the passenger's name from the confirmation page.
        /// </summary>
        /// <returns>The passenger name.</returns>
        public string GetPassengerName()
        {
            return driver.FindElement(By.CssSelector(".block-booking-passenger")).Text;
        }

        /// <summary>
        /// Checks if the booking cancellation was successful.
        /// </summary>
        /// <returns>True if cancellation successful, otherwise false.</returns>
        public bool IsCancellationSuccessful()
        {
            return driver.FindElements(By.CssSelector(".btn-cancel")).Count > 0;
        }

        /// <summary>
        /// Closes the browser.
        /// </summary>
        public void Close()
        {
            driver.Quit();
        }

        /// <summary>
        /// Utility method to select a value from a dropdown by element ID.
        /// </summary>
        /// <param name="elementId">The ID of the dropdown element.</param>
        /// <param name="value">The value to select.</param>
        private void SelectDropdownValue(string elementId, string value)
        {
            new SelectElement(driver.FindElement(By.Id(elementId))).SelectByText(value);
        }
    }
}
