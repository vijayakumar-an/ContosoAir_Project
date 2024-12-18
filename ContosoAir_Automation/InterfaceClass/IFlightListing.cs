﻿/*

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

Author: Ajay
*/
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using System;

namespace InterfaceClass
{
    /// <summary>
    /// Interface that defines the methods for the flight listing functionality,
    /// including login, searching for flights, and listing available flights.
    /// </summary>
    public interface IFlightListing
    {
        /// <summary>
        /// Logs in to the application with the provided username and password.
        /// </summary>
        /// <param name="username">The username to log in.</param>
        /// <param name="password">The password to log in.</param>
        void Login(string username, string password);

        /// <summary>
        /// Searches for flights with the specified parameters.
        /// </summary>
        /// <param name="from">The departure airport (e.g., "New York").</param>
        /// <param name="to">The arrival airport (e.g., "Los Angeles").</param>
        /// <param name="departureDate">The departure date of the flight.</param>
        /// <param name="passengers">The number of passengers for the flight.</param>
        /// <param name="returnDate">The return date of the flight (if applicable).</param>
        void SearchFlights(string from, string to, DateTime departureDate, int passengers, DateTime returnDate);

        /// <summary>
        /// Lists all available flights after performing the search.
        /// </summary>
        List<IWebElement> ListAvailableFlights();

        /// <summary>
        /// Closes the WebDriver and shuts down the browser session.
        /// </summary>
        void Close();
    }
}
