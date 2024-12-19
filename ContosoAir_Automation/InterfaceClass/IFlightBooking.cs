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

using System;
using System.Collections;

namespace InterfaceClass
{
    /// <summary>
    /// Defines the contract for a flight booking system, including methods for login, flight selection, booking, and retrieving booking details.
    /// </summary>
    public interface IFlightBooking
    {
        /// <summary>
        /// Logs in the user with the provided username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        void Login(string username, string password);

        /// <summary>
        /// Selects the flight details based on departure and return locations, dates, and number of passengers.
        /// </summary>
        /// <param name="from">Departure location.</param>
        /// <param name="to">Destination location.</param>
        /// <param name="departureDate">Date of departure.</param>
        /// <param name="numberOfPassengers">Number of passengers.</param>
        /// <param name="returnDate">Return date (if applicable).</param>
        void SelectFlightDetails(string from, string to, DateTime departureDate, int numberOfPassengers, DateTime returnDate);

        /// <summary>
        /// Books the selected flight.
        /// </summary>
        void BookFlight();

        /// <summary>
        /// Closes the current flight booking session.
        /// </summary>
        void Close();

        /// <summary>
        /// Retrieves the title of the booking confirmation page.
        /// </summary>
        /// <returns>The title of the booking confirmation page.</returns>
        string GetBookingConfirmationTitle();

        /// <summary>
        /// Retrieves the booking details from the confirmation page, including the departure and destination locations.
        /// </summary>
        /// <returns>A tuple containing the departure and destination locations.</returns>
        (string from, string to) GetBookingDetailsFromConfirmation();
    }
}

