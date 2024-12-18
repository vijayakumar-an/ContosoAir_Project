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

 using OpenQA.Selenium;
using InterfaceClass;
using WebAdapterClass;
using NUnit.Framework;
using System;

namespace ScenerioClass
{
    /// <summary>
    /// This class contains test scenarios for booking and canceling a flight.
    /// It includes tests for logging in, booking a flight, and verifying the cancellation process.
    /// </summary>
    public class ScenerioClass
    {
        private IWebDriver driver;
        private IFlightSummary flightSummary;

        /// <summary>
        /// Setup method to initialize the WebDriver and navigate to the application URL.
        /// It creates a new instance of the ChromeDriver and navigates to the flight booking system.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();// Initialize ChromeDriver
            flightSummary = new FlightSummary(driver);// Instantiate FlightSummary using the driver
            flightSummary.NavigateToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");// Navigate to the flight booking website
        }

        /// <summary>
        /// Test case for booking a flight.
        /// It performs login and then attempts to book a flight using the flightSummary object.
        /// </summary>
        [Test]
        public void BookFlightTest()
        {
            // Perform login
            flightSummary.PerformLogin("Vijay", "Vijay");// Login with test credentials
            // Book a flight
            flightSummary.BookFlight();
        }

        /// <summary>
        /// Test case to check the passenger's name after login and flight booking.
        /// This test verifies that the flight booking is successful and checks the passenger name.
        /// </summary>
        [Test]
        public void checkPassengerName()
        {
            flightSummary.PerformLogin("Vijay", "Vijay"); // Login with test credentials
            flightSummary.BookFlight(); // Book the flight
        }

        /// <summary>
        /// Test case for canceling a flight booking.
        /// It performs login and then checks the cancellation functionality.
        /// </summary>
        [Test]
        public void checkCancelBooking()
        {
            flightSummary.PerformLogin("Vijay", "Vijay"); // Login with test credentials
            flightSummary.checkCancelBooking(); // Check the cancel booking functionality
        }

        /// <summary>
        /// Cleanup method to close the WebDriver after the test execution.
        /// Ensures that the browser is closed and resources are released.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();// Quit the driver, closing the browser
        }


    }
}
