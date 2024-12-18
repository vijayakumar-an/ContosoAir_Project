﻿/*

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

Author: Ajay
*/
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceClass;
using WebAdapterClass;
namespace ScenerioClass
{
    [TestFixture]
    public class BookedFlightHistoryTests
    {
        private IBookedFlightHistory _flightHistory;

        /// <summary>
        /// Setup method to initialize the flight history instance before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _flightHistory = new BookedFlightHistory(); // Create a new instance of BookedFlightHistory
        }

        /// <summary>
        /// Test to verify that booked flights can be retrieved after logging in.
        /// </summary>
        [Test]
        public void TestViewBookedFlights()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            IList<string> bookedFlights = _flightHistory.GetBookedFlights();
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");
        }

        /// <summary>
        /// Test to verify that flight details can be viewed for a selected flight.
        /// </summary>
        [Test]
        public void TestViewFlightDetails()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            IList<string> bookedFlights = _flightHistory.GetBookedFlights();
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");

            _flightHistory.ViewFlightDetails(0);

            // Validate that the flight details page is displayed (you may need to adjust XPath here based on actual UI)
            var flightDetailsTitle = ((BookedFlightHistory)_flightHistory).Driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a"));
            Assert.IsNotNull(flightDetailsTitle, "Flight details page not displayed.");
        }

        /// <summary>
        /// Test to verify the "Shop for another flight" button functionality.
        /// </summary>
        [Test]
        public void TestShopForAnotherFlight()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            _flightHistory.ShopForAnotherFlight();

            // Validate that navigation occurs correctly
            var pageTitle = ((BookedFlightHistory)_flightHistory).Driver.Title;
            Assert.IsFalse(pageTitle.Contains("Booking Page"), "Failed to navigate to booking page.");
        }

        /// <summary>
        /// Test to verify the "Get another flight" button functionality.
        /// </summary>
        [Test]
        public void TestGetAnotherFlight()
        {
            _flightHistory.NavigateToLoginPage();
            _flightHistory.Login("test_user", "test_password");

            _flightHistory.NavigateToMyBookedFlightsPage();

            _flightHistory.GetAnotherFlight();

            // Validate that navigation occurs correctly
            var pageTitle = ((BookedFlightHistory)_flightHistory).Driver.Title;
            Assert.IsFalse(pageTitle.Contains("Booking Page"), "Failed to navigate to booking page.");
        }

        /// <summary>
        /// Cleanup method to close the browser after each test.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            _flightHistory.Cleanup(); // Close the browser session
        }
    }
}
