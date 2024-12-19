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

using NUnit.Framework;
using System;
using InterfaceClass;
using WebAdapterClass;

namespace ScenerioClass
{
    [TestFixture]
    public class FlightSummaryTests
    {
        private IFlightSummary flightSummary;

        // Setup method to initialize the FlightSummary class
        [SetUp]
        public void SetUp()
        {
            flightSummary = new FlightSummary();
        }

        // Test Case 1: Valid Login and Booking Flight
        [Test]
        public void FlightSummary_ValidLogin()
        {
            // Arrange
            string username = "athesh";
            string password = "athesh";
            string from = "Seisia ABM";
            string to = "Egg Harbor City ACY";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act
            flightSummary.Login(username, password);
            flightSummary.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightSummary.BookFlight();
            var actual = flightSummary.IsBookingConfirmed();

            // Assert
            Assert.IsTrue(actual, "Booking confirmation failed.");
        }

        // Test Case 2: Check Passenger Name after Booking
        [Test]
        public void FlightSummary_CheckPassengerName()
        {
            // Arrange
            string username = "athesh";
            string password = "athesh";
            string from = "Seisia ABM";
            string to = "Egg Harbor City ACY";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act
            flightSummary.Login(username, password);
            flightSummary.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightSummary.BookFlight();
            flightSummary.CheckPassengerName();

            // Assert: Passenger name check is implicitly tested
        }

        // Test Case 3: Cancel Booking
        [Test]
        public void FlightSummary_CancelBooking()
        {
            // Arrange
            string username = "athesh";
            string password = "athesh";
            string from = "Seisia ABM";
            string to = "Egg Harbor City ACY";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act
            flightSummary.Login(username, password);
            flightSummary.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightSummary.BookFlight();
            flightSummary.CheckCancelBooking();
            var actual = flightSummary.IsCancellationSuccessful();

            // Assert
            Assert.IsTrue(actual, "Booking cancellation failed.");
        }

        // TearDown method to close the driver after each test
        [TearDown]
        public void TearDown()
        {
            flightSummary.Close();  // Close WebDriver after the test
        }
    }
}
