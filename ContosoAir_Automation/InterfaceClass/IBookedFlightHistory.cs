using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// Interface for interacting with the booked flight history.
    /// </summary>
    public interface IBookedFlightHistory
    {
        // Navigate to the login page
        void NavigateToLoginPage();

        // Log in to the system
        void Login(string username, string password);

        // Navigate to the booked flights page
        void NavigateToMyBookedFlightsPage();

        // Get a list of booked flights
        IList<string> GetBookedFlights();

        // View details of a specific flight
        void ViewFlightDetails(int flightIndex);

        // Log out of the system
        void Logout();

        // Cleanup method to close the browser session
        void Cleanup();
    }
}
