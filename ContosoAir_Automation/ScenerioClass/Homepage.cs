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

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenerioClass
{
    /// <summary>
    /// Contains test cases for verifying the functionality of the Homepage class.
    /// </summary>
    public class HomepageTests
    {
        private WebAdapterClass.Homepage homepage;
        private IWebDriver driver;

        /// <summary>
        /// Sets up the test environment by initializing the WebDriver and the Homepage instance.
        /// </summary>
        [SetUp] // Marks this method to run before each test
        public void Setup()
        {
            // Initialize WebDriver and Homepage instance
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            homepage = new WebAdapterClass.Homepage(driver);
            homepage.NavigateToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");
        }

        /// <summary>
        /// Verifies that the logo image is displayed on the homepage.
        /// </summary>
        [Test]
        public void getLogo()
        {
            // Define test username and password
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);
            Thread.Sleep(2000);
            // Check logo image
            Assert.DoesNotThrow(() => homepage.getLogo(), "Logo image is not displayed using Relative XPath.");
        }

        /// <summary>
        /// Tests the retrieval of the homepage title and verifies it matches the expected value.
        /// </summary>
        [Test] // Test for retrieving the title
        public void getTitle()
        {
            // Define test username and password
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);

            // Expected title of the page
            string expected = "Where do you want to go?";

            // Actual title fetched from the page using the Homepage object
            string actual = homepage.getTitle();

            // Use System's Assert.Equals for comparison (if that's your preference)
            Assert.That(actual, Is.EqualTo("Where do you\r\nwant to go?"));
        }

        /// <summary>
        /// Tests the retrieval of the subtitle and verifies it matches the expected value.
        /// </summary>
        [Test] // Test for retrieving subtitle
        public void GetSubtitle()
        {
            // Define test username and password
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);

            string expectedSubtitle = "Flight deals";
            string actualSubtitle = homepage.subTitle();

            Assert.That(actualSubtitle, Is.EqualTo(expectedSubtitle));
        }

        /// <summary>
        /// Tests the retrieval of the suggested title and verifies it matches the expected value.
        /// </summary>
        [Test] // Test for retrieving recommended title
        public void GetSuggestedTitle()
        {
            // Define test username and password
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);

            string expectedSuggestedTitle = "Recommended for you";
            string actualSuggestedTitle = homepage.getSuggestTitle();

            Assert.That(actualSuggestedTitle, Is.EqualTo(expectedSuggestedTitle));
        }

        /// <summary>
        /// Verifies that the Hawaii image is displayed on the homepage.
        /// </summary>
        [Test]
        public void checkHawaiiImage()
        {
            string username = "Vijay";
            string password = "Vijay";

            // Perform login
            homepage.PerformLogin(username, password);

            // Check Paris image
            Assert.DoesNotThrow(() => homepage.checkHawaiiImage(), "Hawaii image is not displayed using Relative XPath.");
        }

        /// <summary>
        /// Verifies that the Hawaii caption matches the expected text.
        /// </summary>
        [Test]
        public void checkHawaiiCaption()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedName = "Hawaii";

            // Get the actual caption name
            string actualName = homepage.checkHawaiiCaption();

            // Assert the caption name
            Assert.That(actualName, Is.EqualTo(expectedName));

            // Check Paris caption, this should not throw an error.
            Assert.DoesNotThrow(() => homepage.checkParisCaption(), "The Hawaii caption is not displayed on the homepage.");
        }

        /// <summary>
        /// Verifies that the Paris image is displayed on the homepage.
        /// </summary>
        [Test]
        public void checkParisImageTest()
        {
            string username = "Vijay";
            string password = "Vijay";

            // Perform login
            homepage.PerformLogin(username, password);

            // Check Paris image
            Assert.DoesNotThrow(() => homepage.checkParisImage(), "Paris image is not displayed using Relative XPath.");
        }

        /// <summary>
        /// Verifies that the Paris caption matches the expected text.
        /// </summary>
        [Test]
        public void checkParisCaption()
        {
            string username = "Vijay";
            string password = "Vijay";

            // Perform login
            homepage.PerformLogin(username, password);

            string expectedName = "Pari";

            // Get the actual caption name
            string actualName = homepage.checkParisCaption();

            // Assert the caption name
            Assert.That(actualName, Is.EqualTo(expectedName));

            // Check Paris caption, this should not throw an error.
            Assert.DoesNotThrow(() => homepage.checkParisCaption(), "The Paris caption is not displayed on the homepage.");
        }

        /// <summary>
        /// Verifies that the Barcelona image is displayed on the homepage.
        /// </summary>
        [Test]
        public void checkBarcelonaImage()
        {
            string username = "Vijay";
            string password = "Vijay";

            // Perform login
            homepage.PerformLogin(username, password);

            // Check Paris image
            Assert.DoesNotThrow(() => homepage.checkBarcelonaImage(), "Barcelona image is not displayed using Relative XPath.");
        }

        /// <summary>
        /// Verifies that the Barcelona caption matches the expected text.
        /// </summary>
        [Test]
        public void checkBarcelonaCaption()
        {
            string username = "Vijay";
            string password = "Vijay";

            homepage.PerformLogin(username, password);

            string expectedName = "Barcelona";

            // Get the actual caption name
            string actualName = homepage.checkBarcelonaCaption();

            // Assert the caption name
            Assert.That(actualName, Is.EqualTo(expectedName));

            // Check Paris caption, this should not throw an error.
            Assert.DoesNotThrow(() => homepage.checkBarcelonaCaption(), "The Barcelona caption is not displayed on the homepage.");
        }

        /// <summary>
        /// Tests the login functionality by performing a login operation.
        /// </summary>
        [Test] // Test for performing login
        public void PerformLoginTest()
        {
            // Define test username and password
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps using the _homepage object
            homepage.PerformLogin(username, password);

            // No need for logout verification, you can add another assertion if needed,
            // like checking that some element exists after login.
        }

        /// <summary>
        /// Cleans up the test environment by closing the WebDriver.
        /// </summary>
        [TearDown] // Marks this method to run after each test
        public void TearDown()
        {
            driver.Quit();
        }
    }

}
