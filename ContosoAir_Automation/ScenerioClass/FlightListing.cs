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
    [TestFixture]
    public class FlightListingTests
    {
        private IFlightListing _flightListing;

        /// <summary>
        /// Setup method to initialize the FlightListing instance.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the FlightListing class
            _flightListing = new FlightListing();
        }

        /// <summary>
        /// Test case to navigate to the booking page, log in, and verify that flight listings are displayed.
        /// </summary>
        [Test]
        public void TestLoginAndViewFlightListings()
        {
            // Navigate to the booking page
            _flightListing.NavigateToBookingPage();
            _flightListing.Login("test_user", "test_password");

            // Cast IFlightListing to FlightListing to access the Driver property
            var flightListing = _flightListing as FlightListing;

            // Set the departure and arrival locations for the search (example)
            _flightListing.SelectDepartureLocation("New York");
            _flightListing.SelectArrivalLocation("London");

            // Set departure and return dates
            _flightListing.SetDepartureDate(DateTime.Today.AddDays(30));
            _flightListing.SetReturnDate(DateTime.Today.AddDays(37));

            // Select passengers (example: 1 passenger)
            _flightListing.SelectPassengers(1);

            // Submit the flight search
            _flightListing.SubmitFlightSearch();

            // Wait until the available flights section is visible
            var availableFlightsTitle = flightListing?.Driver.FindElement(By.XPath("//h2[contains(text(), 'Available flights')]"));
            Assert.IsNotNull(availableFlightsTitle, "Available flights section is not visible after submitting the search.");

            // Verify that flight listings are displayed
            var flightListings = flightListing?.Driver.FindElements(By.XPath("//div[contains(@class, 'flight-listing')]"));
            Assert.IsTrue(flightListings != null && flightListings.Count > 0, "No flight listings were found after searching.");
        }

        /// <summary>
        /// Cleanup method to close the browser after tests.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            _flightListing.Cleanup();
        }
    }
}