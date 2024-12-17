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
    /// <summary>
    /// Test class to validate the functionality of viewing flight history.
    /// </summary>
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
            _flightHistory = new BookedFlightHistory();  // Create a new instance of BookedFlightHistory
        }

        /// <summary>
        /// Test to verify that booked flights can be retrieved after logging in.
        /// </summary>
        [Test]
        public void TestViewBookedFlights()
        {
            // Navigate to the login page
            _flightHistory.NavigateToLoginPage();

            // Login with valid credentials
            _flightHistory.Login("test_user", "test_password");

            // Navigate to the "My Booked Flights" page
            _flightHistory.NavigateToMyBookedFlightsPage();

            // Get the list of booked flights
            IList<string> bookedFlights = _flightHistory.GetBookedFlights();

            // Verify that there are booked flights
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");
        }

        /// <summary>
        /// Test to verify that flight details can be viewed for a selected flight.
        /// </summary>
        [Test]
        public void TestViewFlightDetails()
        {
            // Navigate to the login page
            _flightHistory.NavigateToLoginPage();

            // Login with valid credentials
            _flightHistory.Login("test_user", "test_password");

            // Navigate to the "My Booked Flights" page
            _flightHistory.NavigateToMyBookedFlightsPage();

            // Get the list of booked flights
            IList<string> bookedFlights = _flightHistory.GetBookedFlights();

            // Ensure that there are booked flights
            Assert.IsTrue(bookedFlights.Count > 0, "No booked flights found.");

            // View details for the first flight (index 0)
            _flightHistory.ViewFlightDetails(0);

            // Verify that the flight details page is displayed
            var flightDetailsTitle = ((BookedFlightHistory)_flightHistory).Driver.FindElement(By.XPath("/html/body/navbar/nav/div/div[2]/div[2]/ul/li[2]/a"));
            Assert.IsNotNull(flightDetailsTitle, "Flight details page not displayed.");
        }

        /// <summary>
        /// Cleanup method to close the browser after each test.
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            // Clean up the browser session
            _flightHistory.Cleanup();
        }
    }
}
