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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAdapterClass;

namespace ScenerioClass
{
    /// <summary>
    /// Test cases for the FlightListingPage class that ensures login, flight search, and listing functionalities work correctly.
    /// </summary>
    [TestFixture]
    public class FlightListingPageTest
    {
        private FlightListingPage flightListingPage;

        /// <summary>
        /// Setup method to initialize the WebDriver and FlightListingPage instance.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the page object for flight listing (WebDriver is initialized within the class)
            flightListingPage = new FlightListingPage();
        }

        /// <summary>
        /// TearDown method to close the browser after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            flightListingPage.Close();  // Ensures that the browser is closed after each test
        }

        /// <summary>
        /// Test case for logging in and searching for flights.
        /// </summary>
        [Test]
        public void Test_Flight_Search_With_Login()
        {
            // Arrange: Define login credentials and flight search parameters
            string username = "testuser";
            string password = "testpassword";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act: Login to the system
            flightListingPage.Login(username, password);

            // Act: Perform the flight search after login
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            // Assert: Ensure that the flight listings are displayed
            Assert.DoesNotThrow(() => flightListingPage.ListAvailableFlights(), "Flight listing failed or no flights are available");
        }

        /// <summary>
        /// Test case to ensure flight listings are not empty.
        /// </summary>
        [Test]
        public void Test_Flight_Listings_Are_Not_Empty()
        {
            // Arrange: Define login credentials and flight search parameters
            string username = "testuser";
            string password = "testpassword";
            string from = "Anchorage ANC";
            string to = "Abakan ABA";
            DateTime departureDate = new DateTime(2024, 12, 20);
            int passengers = 1;
            DateTime returnDate = new DateTime(2024, 12, 25);

            // Act: Login to the system
            flightListingPage.Login(username, password);

            // Act: Perform the flight search
            flightListingPage.SearchFlights(from, to, departureDate, passengers, returnDate);

            // Assert: Ensure that flight listings are not empty
            var flightListings = flightListingPage.ListAvailableFlights();
            Assert.IsNotEmpty(flightListings, "No flight listings were found!");
        }
    }
}