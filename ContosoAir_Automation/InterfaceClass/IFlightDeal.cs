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
    /// Represents an interface for a flight deal system.
    /// Defines methods for performing login, retrieving flight details, and interacting with the UI elements.
    /// </summary>
    public interface IFlightDeal
    {
        /// <summary>
        /// Performs login action with the provided username and password.
        /// </summary>
        /// <param name="username">The username of the user attempting to log in.</param>
        /// <param name="password">The password associated with the username.</param>
        void PerformLogin(string username, string password);

        /// <summary>
        /// Retrieves the title of the flight deal.
        /// </summary>
        /// <returns>A string representing the title of the flight deal.</returns>
        string Title();

        /// <summary>
        /// Retrieves the source and destination airports for a particular flight deal, based on the provided index.
        /// </summary>
        /// <param name="i">The index of the flight deal.</param>
        /// <returns>A tuple containing the source and destination airports for the flight deal.</returns>
        (string, string) BoxSourceToDestination(int i);

        /// <summary>
        /// Retrieves the end date of the flight deal, based on the provided index.
        /// </summary>
        /// <param name="i">The index of the flight deal.</param>
        /// <returns>A string representing the end date of the flight deal.</returns>
        string BoxEndDate(int i);

        /// <summary>
        /// Retrieves the description of the flight deal, based on the provided index.
        /// </summary>
        /// <param name="i">The index of the flight deal.</param>
        /// <returns>A string representing the description of the flight deal.</returns>
        string BoxDescription(int i);

        /// <summary>
        /// Simulates clicking the button associated with the flight deal, triggering any associated actions.
        /// </summary>
        void BoxButton();
    }
}
