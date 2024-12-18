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

using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdapterClass
{
    //// <summary>
    /// Class implementing the ILoginTest interface to perform login automation.
    /// </summary>
    public class LoginTest : ILoginTest
    {
        /// <summary>
        /// The WebDriver instance used to control the browser.
        /// </summary>
        private readonly IWebDriver driver;

        /// <summary>
        /// Constructor to initialize the WebDriver.
        /// </summary>
        /// <param name="driver">The WebDriver instance to control the browser.</param>
        public LoginTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Navigates to the specified URL and sets the browser window size.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
        }

        /// <summary>
        /// Performs login using the provided username and password.
        /// </summary>
        /// <param name="username">The username for login.</param>
        /// <param name="password">The password for login.</param>
        public void PerformLoginWithCredentials(string username, string password)
        {
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Attempts to perform login without providing any credentials.
        /// </summary>
        public void PerformLoginWithOutCredentials()
        {
            // Click on the 'Login' link to navigate to the login form
            driver.FindElement(By.LinkText("Login")).Click();

            // Click the login button without entering any credentials
            driver.FindElement(By.CssSelector(".btn")).Click();

            // Optional: Capture the alert or validation message
            var alertMessage = driver.FindElement(By.CssSelector(".alert > span")).Text;
            Console.WriteLine("Alert Message Displayed: " + alertMessage);
        }

    }
}
