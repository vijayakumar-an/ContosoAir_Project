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
using OpenQA.Selenium;
using InterfaceClass;
using System.Runtime.CompilerServices;

namespace WebAdapterClass
{
    /// <summary>
    /// This class implements the IFlightDeal interface and provides methods for interacting with the flight deal page.
    /// It includes functionality for logging in, navigating the page, and retrieving various flight deal details.
    /// </summary>
    public class FlightDeal : IFlightDeal
    {
        private readonly IWebDriver driver;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightDeal"/> class.
        /// </summary>
        /// <param name="webDriver">The Selenium WebDriver instance used to interact with the webpage.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="webDriver"/> is null.</exception>
        public FlightDeal(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        /// <summary>
        /// Navigates to the specified URL in the browser.
        /// </summary>
        /// <param name="url">The URL of the page to navigate to.</param>
        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Performs the login action by filling out the username, password, and clicking the login button.
        /// </summary>
        /// <param name="username">The username to log in with.</param>
        /// <param name="password">The password associated with the username.</param>
        public void PerformLogin(string username, string password)
        {
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        /// <summary>
        /// Retrieves the title of the flight deals page.
        /// </summary>
        /// <returns>The title of the flight deals page.</returns>
        public string Title()
        {
            IWebElement titleElement = driver.FindElement(By.XPath("//h2[normalize-space()='Flight deals']"));
            return titleElement.Text;
        }

        /// <summary>
        /// Clicks the button in the flight deal box to interact with it.
        /// </summary>
        public void BoxButton()
        {
            // Find the button element
            IWebElement buttonElement = driver.FindElement(By.XPath("/html/body/main/main/div/div/div[2]/deals/ul/li[1]/span/span/span[3]/button"));

            // Perform the click action on the button
            buttonElement.Click();
        }

        /// <summary>
        /// Retrieves the source and destination locations for the specified flight deal box.
        /// </summary>
        /// <param name="boxIndex">The index of the flight deal box (1-based).</param>
        /// <returns>A tuple containing the source and destination of the flight deal box.</returns>
        public (string, string) BoxSourceToDestination(int boxIndex)
        {
            string sourceXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[1]";
            string destinationXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[2]";

            // Find the source element by XPath
            IWebElement boxSource = driver.FindElement(By.XPath(sourceXPath));

            // Find the destination element by XPath
            IWebElement boxDestination = driver.FindElement(By.XPath(destinationXPath));

            // Return both source and destination as a tuple
            return (boxSource.Text, boxDestination.Text);
        }

        /// <summary>
        /// Retrieves the end date for the specified flight deal box.
        /// </summary>
        /// <param name="boxIndex">The index of the flight deal box (1-based).</param>
        /// <returns>The end date for the flight deal box.</returns>
        public string BoxEndDate(int boxIndex)
        {
            string endDateXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[1]/span[3]";

            // Find the end date element by XPath
            IWebElement boxEndDate = driver.FindElement(By.XPath(endDateXPath));
            return boxEndDate.Text;
        }

        /// <summary>
        /// Retrieves the description for the specified flight deal box.
        /// </summary>
        /// <param name="boxIndex">The index of the flight deal box (1-based).</param>
        /// <returns>The description for the flight deal box.</returns>
        public string BoxDescription(int boxIndex)
        {
            string descriptionXPath = $"/html/body/main/main/div/div/div[2]/deals/ul/li[{boxIndex}]/span/span/span[2]";

            // Find the description element by XPath
            IWebElement boxDescription = driver.FindElement(By.XPath(descriptionXPath));
            return boxDescription.Text;
        }
    }
}
