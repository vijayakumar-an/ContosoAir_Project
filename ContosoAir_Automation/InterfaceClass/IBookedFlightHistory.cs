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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{
    /// <summary>
    /// Interface for interacting with the booked flight history.
    /// Defines the actions that can be performed related to user login,
    /// flight bookings, flight details, and logout.
    /// </summary>
    public interface IBookedFlightHistory
    {
        /// <summary>
        /// Navigates to the login page of the application.
        /// </summary>
        void NavigateToLoginPage();

        /// <summary>
        /// Logs the user into the system with the provided credentials.
        /// </summary>
        /// <param name="username">Username for login</param>
        /// <param name="password">Password for login</param>
        void Login(string username, string password);

        /// <summary>
        /// Navigates to the "My Booked Flights" page to view user's bookings.
        /// </summary>
        void NavigateToMyBookedFlightsPage();

        /// <summary>
        /// Retrieves the list of booked flights for the logged-in user.
        /// </summary>
        /// <returns>A list of strings representing booked flights.</returns>
        IList<string> GetBookedFlights();

        /// <summary>
        /// Views details for a specific flight from the booked flight list.
        /// </summary>
        /// <param name="flightIndex">Index of the flight to view details.</param>
        void ViewFlightDetails(int flightIndex);

        /// <summary>
        /// Clicks on the "Shop for another flight" button on the booking page.
        /// </summary>
        void ShopForAnotherFlight();

        /// <summary>
        /// Clicks on the "Get another flight" button on the booking page.
        /// </summary>
        void GetAnotherFlight();

        /// <summary>
        /// Logs the user out of the system.
        /// </summary>
        void Logout();

        /// <summary>
        /// Cleans up resources and closes the browser session.
        /// </summary>
        void Cleanup();
    }
}
