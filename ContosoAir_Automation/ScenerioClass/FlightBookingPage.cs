using InterfaceClass;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebAdapterClass;

namespace ScenerioClass
{

    [TestFixture]
    public class FlightBookingTests
    {
        private IWebDriver driver;
        private IFlightBooking flightBookingPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            flightBookingPage = new FlightBookingPage(driver);
        }

        [Test]
        public void FlightBooking_ValidLogin()
        {
            // Login with valid credentials
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 1, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Close the browser
            flightBookingPage.Close();
        }

        

        [Test]
        public void FlightBooking_SinglePassenger()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details for a single passenger
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 1, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Close the browser
            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_MultiplePassengers()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details for multiple passengers
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 3, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Close the browser
            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_DifferentDestinations()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details with different destinations
            flightBookingPage.SelectFlightDetails("New York JFK", "Los Angeles LAX", new DateTime(2024, 12, 20), 2, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Close the browser
            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_ReturnDateLaterThanDepartureDate()
        {
            // Login
            flightBookingPage.Login("athesh", "athesh");

            // Select flight details with a return date later than the departure date
            flightBookingPage.SelectFlightDetails("Seisia ABM", "Egg Harbor City ACY", new DateTime(2024, 12, 20), 2, new DateTime(2024, 12, 25));

            // Book the flight
            flightBookingPage.BookFlight();

            // Close the browser
            flightBookingPage.Close();
        }

        [Test]
        public void FlightBooking_PassengerDropdown_ShouldContainValidValues()
        {
            // Arrange
            flightBookingPage.Login("athesh", "athesh");

            // Act
            driver.FindElement(By.LinkText("Book")).Click();
            var passengerDropdown = new SelectElement(driver.FindElement(By.Id("passengers")));
            var options = passengerDropdown.Options;

            // Assert
            var expectedValues = new List<string> { "1", "2", "3", "4", "5" };
            var actualValues = options.Select(o => o.Text).ToList();

            CollectionAssert.AreEqual(expectedValues, actualValues, "Passenger dropdown values do not match.");
        }




        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
