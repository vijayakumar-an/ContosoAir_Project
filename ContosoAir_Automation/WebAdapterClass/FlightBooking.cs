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

Author: Athesh
*/

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
    /// Implements the IFlightBooking interface, providing functionality for flight booking operations.
    /// This class interacts with a web-based flight booking application through Selenium WebDriver.
    /// </summary>
    public class FlightBooking : IFlightBooking
    {
        private IWebDriver driver;

        /// <summary>
        /// Constructor to initialize the WebDriver with a ChromeDriver.
        /// </summary>
        public FlightBooking()
        {
            driver = new ChromeDriver();
        }

        /// <summary>
        /// Logs in to the flight booking application using provided credentials.
        /// </summary>
        /// <param name="username">Username for login</param>
        /// <param name="password">Password for login</param>
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
        /// Selects the flight details including departure and return locations, dates, and number of passengers.
        /// </summary>
        /// <param name="from">Departure location</param>
        /// <param name="to">Destination location</param>
        /// <param name="departureDate">Departure date</param>
        /// <param name="numberOfPassengers">Number of passengers</param>
        /// <param name="returnDate">Return date</param>
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

        /// <summary>
        /// Books the selected flight after choosing the flight options and confirming the booking.
        /// </summary>
        public void BookFlight()
        {
            driver.FindElement(By.CssSelector(".btn-md")).Click();

            // Select flight option
            driver.FindElement(By.CssSelector(".block-flights-results-list-item:nth-child(2) .big-blue-radio")).Click();

            // Proceed to booking
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();
        }

        /// <summary>
        /// Closes the WebDriver session after completing the test.
        /// </summary>
        public void Close()
        {
            driver.Quit();
        }

        /// <summary>
        /// Retrieves the booking confirmation title from the confirmation page.
        /// </summary>
        /// <returns>The booking confirmation title as a string.</returns>
        public string GetBookingConfirmationTitle()
        {
            return driver.FindElement(By.CssSelector(".block-booking-title")).Text;
        }

        /// <summary>
        /// Retrieves the "From" and "To" flight details from the booking confirmation.
        /// </summary>
        /// <returns>A tuple containing the "From" and "To" locations from the confirmation.</returns>
        public (string from, string to) GetBookingDetailsFromConfirmation()
        {
            // Locate the "From" and "To" elements on the confirmation page
            var fromLocation = driver.FindElement(By.CssSelector("body > main > section > div > div.cities--indicator.text-center > div:nth-child(2) > div:nth-child(1)")).Text;  // Update the CSS selector based on actual HTML
            var toLocation = driver.FindElement(By.CssSelector("body > main > section > div > div.cities--indicator.text-center > div:nth-child(2) > div:nth-child(3)")).Text;        // Update the CSS selector based on actual HTML

            return (fromLocation, toLocation);
        }
    }
}
