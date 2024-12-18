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

using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace WebAdapterClass
{
    /// <summary>
    /// This class provides an implementation of the flight booking functionality 
    /// on the ContosoAir website. It interacts with web elements for login, 
    /// selecting flight details, booking flights, and closing the browser session.
    /// </summary>
    public class FlightBookingPage : IFlightBooking
    {
        private IWebDriver driver;

        /// <summary>
        /// Initializes the FlightBookingPage with a WebDriver instance.
        /// </summary>
        /// <param name="driver">The WebDriver instance for interacting with the web application.</param>
        public FlightBookingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Logs in to the ContosoAir website using the provided username and password.
        /// </summary>
        /// <param name="username">The username to log in.</param>
        /// <param name="password">The password to log in.</param>
        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Selects flight details including departure and arrival airports, 
        /// departure and return dates, and the number of passengers.
        /// </summary>
        /// <param name="from">The departure airport.</param>
        /// <param name="to">The arrival airport.</param>
        /// <param name="departureDate">The departure date.</param>
        /// <param name="passengers">The number of passengers.</param>
        /// <param name="returnDate">The return date.</param>
        public void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Select Departure Airport
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath($"//option[. = '{from}']")).Click();
            Thread.Sleep(2000);

            // Select Arrival Airport
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath($"//option[. = '{to}']")).Click();
            Thread.Sleep(2000);

            // Select Departure Date (with WebDriverWait)
            driver.FindElement(By.Id("dpa")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var departureDateCell = wait.Until(drv =>
                drv.FindElement(By.XPath($"//td[contains(text(), '{departureDate.Day}')]"))
            );
            departureDateCell.Click();

            // Select Passengers
            driver.FindElement(By.Id("passengers")).Click();
            var passengersDropdown = driver.FindElement(By.Id("passengers"));
            passengersDropdown.FindElement(By.XPath($"//option[. = '{passengers}']")).Click();

            // Select Return Date (with WebDriverWait)
            driver.FindElement(By.Id("dpb")).Click();
            var returnDateCell = wait.Until(drv =>
                drv.FindElement(By.XPath($"//td[contains(text(), '{returnDate.Day}')]"))
            );
            returnDateCell.Click();
        }

        /// <summary>
        /// Books a flight by selecting available options and completing the booking process.
        /// </summary>
        public void BookFlight()
        {
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(2) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();
            driver.FindElement(By.CssSelector(".block-booking-title")).Click();
            driver.FindElement(By.CssSelector(".block-booking-passenger")).Click();
        }

        /// <summary>
        /// Closes the browser session.
        /// </summary>
        public void Close()
        {
            driver.Close();
        }
    }
}
