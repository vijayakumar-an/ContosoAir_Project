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
    /// <summary>
    /// Contains test cases for the IFlightSummary interface methods, ensuring that flight booking, cancellation, and related functionalities work correctly.
    /// </summary>
    [TestFixture]
    public class FlightSummaryTests
    {
        private IFlightSummary flightSummary;

        /// <summary>
        /// Setup method to initialize the FlightSummary class before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            flightSummary = new FlightSummary();
        }

        /// <summary>
        /// Test Case 1: Valid Login and Booking Flight.
        /// Verifies that the flight booking is confirmed after a valid login and flight selection.
        /// </summary>
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

        /// <summary>
        /// Test Case 2: Check Passenger Name after Booking.
        /// Verifies that the passenger name can be correctly checked after booking a flight.
        /// </summary>
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

        /// <summary>
        /// Test Case 3: Cancel Booking.
        /// Verifies that the booking can be successfully canceled and the cancellation status is correct.
        /// </summary>
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

        /// <summary>
        /// TearDown method to close the flight summary session after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            flightSummary.Close();  // Close WebDriver after the test
        }
    }
}

