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
using System.Collections.Generic;
using System.Linq;
using WebAdapterClass;
using InterfaceClass;

namespace ScenerioClass
{
    [TestFixture]
    public class FlightBookingTests
    {
        private IFlightBooking flightBooking;

        // Setup method to initialize the FlightBookingPage
        [SetUp]
        public void SetUp()
        {
            flightBooking = new FlightBooking();  // No need to pass WebDriver here anymore
        }

        // Test Case 1: Valid Login and Booking Flight
        [Test]
        public void FlightBooking_ValidLogin()
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
            flightBooking.Login(username, password);
            flightBooking.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightBooking.BookFlight();

            // Assert
            var actual = flightBooking.GetBookingConfirmationTitle();
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");
        }

        // Test Case 2: Flight Booking with Single Passenger
        [Test]
        public void FlightBooking_SinglePassenger()
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
            flightBooking.Login(username, password);
            flightBooking.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightBooking.BookFlight();

            // Assert
            var actual = flightBooking.GetBookingConfirmationTitle();
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");
        }

        // Test Case 3: Flight Booking with Multiple Passengers
        [Test]
        public void FlightBooking_MultiplePassengers()
        {
            // Arrange
            string username = "athesh";
            string password = "athesh";
            string from = "Seisia ABM";
            string to = "Egg Harbor City ACY";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 3;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act
            flightBooking.Login(username, password);
            flightBooking.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightBooking.BookFlight();

            // Assert
            var actual = flightBooking.GetBookingConfirmationTitle();
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");
        }

        // Test Case 4: Flight Booking with Different Destinations
        [Test]
        public void FlightBooking_DifferentDestinations()
        {
            // Arrange
            string username = "athesh";
            string password = "athesh";
            string from = "New York JFK";
            string to = "Los Angeles LAX";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 2;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act
            flightBooking.Login(username, password);
            flightBooking.SelectFlightDetails(from, to, departureDate, passengers, returnDate);
            flightBooking.BookFlight();

            // Assert
            var actual = flightBooking.GetBookingConfirmationTitle();
            var expected = "Flight booked!";
            Assert.AreEqual(expected, actual, "The booking title does not match the expected description.");
        }
        [Test]
        public void FlightBooking_ValidateFromAndToAfterBooking()
        {
            // Arrange
            string username = "athesh";
            string password = "athesh";
            string from = "Seisia ABM";
            string to = "Egg Harbor City ACY"; 
            DateTime departureDate = DateTime.Now.AddDays(7);
            DateTime returnDate = DateTime.Now.AddDays(14);
            int numberOfPassengers = 2;

            // Act
            flightBooking.Login(username, password);
            flightBooking.SelectFlightDetails(from, to, departureDate, numberOfPassengers, returnDate);
            flightBooking.BookFlight();

            // Get the booking confirmation details
            var (confirmedFrom, confirmedTo) = flightBooking.GetBookingDetailsFromConfirmation();
            var exceptfrom = "ABM";
            var exceptto = "ACY";

            // Assert
            Assert.AreEqual(exceptfrom, confirmedFrom, $"Expected 'From' location: {from}, but got: {confirmedFrom}");
            Assert.AreEqual(exceptto, confirmedTo, $"Expected 'To' location: {to}, but got: {confirmedTo}");
        }


        // TearDown method to close the driver after each test
        [TearDown]
        public void TearDown()
        {
            flightBooking.Close();  // Closing WebDriver after the test
        }
    }
}

