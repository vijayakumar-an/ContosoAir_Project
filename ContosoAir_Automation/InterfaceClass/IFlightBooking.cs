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

namespace InterfaceClass
{
    /// <summary>
    /// Interface for implementing flight booking functionality.
    /// Provides methods for login, selecting flight details, booking flights, and closing the session.
    /// </summary>
    public interface IFlightBooking
    {
        /// <summary>
        /// Logs in to the flight booking system with the given username and password.
        /// </summary>
        /// <param name="username">The username for authentication.</param>
        /// <param name="password">The password for authentication.</param>
        void Login(string username, string password);

        /// <summary>
        /// Selects flight details including departure and arrival locations, 
        /// dates for departure and return, and the number of passengers.
        /// </summary>
        /// <param name="from">The departure location code (e.g., "JFK").</param>
        /// <param name="to">The arrival location code (e.g., "LAX").</param>
        /// <param name="departureDate">The date of departure.</param>
        /// <param name="passengers">The number of passengers traveling.</param>
        /// <param name="returnDate">The date of return.</param>
        void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate);

        /// <summary>
        /// Books the selected flight based on previously provided details.
        /// </summary>
        void BookFlight();

        /// <summary>
        /// Closes the flight booking session and releases browser resources.
        /// </summary>
        void Close();
    }
}
