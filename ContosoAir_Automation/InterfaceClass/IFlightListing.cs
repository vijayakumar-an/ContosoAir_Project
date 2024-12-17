using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// Interface for flight listing and booking functionality.
    /// </summary>
    public interface IFlightListing
    {
        /// <summary>
        /// Property to get the WebDriver instance.
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Navigates to the booking page and handles login if required.
        /// </summary>
        void NavigateToBookingPage();

        /// <summary>
        /// Selects the flight type (Round trip, One way, etc.).
        /// </summary>
        void SelectFlightType(string flightType);

        /// <summary>
        /// Selects the departure location from a dropdown.
        /// </summary>
        void SelectDepartureLocation(string fromLocation);

        /// <summary>
        /// Selects the arrival location from a dropdown.
        /// </summary>
        void SelectArrivalLocation(string toLocation);

        /// <summary>
        /// Sets the departure date for the flight.
        /// </summary>
        void SetDepartureDate(DateTime departureDate);

        /// <summary>
        /// Sets the return date for the flight.
        /// </summary>
        void SetReturnDate(DateTime returnDate);

        /// <summary>
        /// Selects the number of passengers for the flight.
        /// </summary>
        void SelectPassengers(int numberOfPassengers);

        /// <summary>
        /// Submits the flight search request.
        /// </summary>
        void SubmitFlightSearch();

        /// <summary>
        /// Retrieves a list of available flights after the search.
        /// </summary>
        IList<string> GetAvailableFlights();

        /// <summary>
        /// Selects a flight from the available listings.
        /// </summary>
        void SelectFlight(int flightIndex);

        /// <summary>
        /// Logs the user into the website.
        /// </summary>
        void Login(string username, string password);

        /// <summary>
        /// Cleans up and closes the browser after the test.
        /// </summary>
        void Cleanup();
    }
}
