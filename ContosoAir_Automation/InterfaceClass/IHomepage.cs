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

Author: Vijay
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceClass
{

    /// <summary>
    /// Defines the contract for a homepage interface that includes navigation, login functionality, 
    /// and retrieval of various elements like titles, subtitles, and images.
    /// </summary>
    public interface IHomepage
    {
        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        void NavigateToUrl(string url);

        /// <summary>
        /// Logs in with the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        void PerformLogin(string username, string password);

        /// <summary>
        /// Checks and retrieves the homepage logo.
        /// </summary>
        void getLogo();

        /// <summary>
        /// Retrieves the text of the title element.
        /// </summary>
        /// <returns>The text of the title element.</returns>
        string getTitle();

        /// <summary>
        /// Retrieves the text of the subtitle element.
        /// </summary>
        /// <returns>The text of the subtitle element.</returns>
        string subTitle();

        /// <summary>
        /// Retrieves the text of the suggestion title element.
        /// </summary>
        /// <returns>The text of the suggestion title.</returns>
        string getSuggestTitle();

        /// <summary>
        /// Verifies the presence of the Hawaii image on the homepage.
        /// </summary>
        void checkHawaiiImage();

        /// <summary>
        /// Retrieves the caption for the Hawaii image.
        /// </summary>
        /// <returns>The caption text for the Hawaii image.</returns>
        string checkHawaiiCaption();

        /// <summary>
        /// Verifies the presence of the Paris image on the homepage.
        /// </summary>
        void checkParisImage();

        /// <summary>
        /// Retrieves the caption for the Paris image.
        /// </summary>
        /// <returns>The caption text for the Paris image.</returns>
        string checkParisCaption();

        /// <summary>
        /// Verifies the presence of the Barcelona image on the homepage.
        /// </summary>
        void checkBarcelonaImage();

        /// <summary>
        /// Retrieves the caption for the Barcelona image.
        /// </summary>
        /// <returns>The caption text for the Barcelona image.</returns>
        string checkBarcelonaCaption();
    }
}

