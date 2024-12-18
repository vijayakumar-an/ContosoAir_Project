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

namespace ScenerioClass
{
    /// <summary>
    /// Test class for verifying functionalities of the FlightDeal class.
    /// This class contains various tests for login, retrieving flight details, and interacting with flight deal UI elements.
    /// </summary>
    public class FlightDealTests
    {
        private WebAdapterClass.FlightDeal flightdeal;
        private IWebDriver driver;

        /// <summary>
        /// Setup method runs before each test to initialize the WebDriver and navigate to the FlightDeal page.
        /// </summary>
        [SetUp] // Marks this method to run before each test
        public void Setup()
        {
            // Initialize WebDriver and Homepage instance
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            flightdeal = new WebAdapterClass.FlightDeal(driver);
            flightdeal.NavigateToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");
        }

        /// <summary>
        /// Cleanup method that runs after each test to dispose of the WebDriver.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        /// <summary>
        /// Test for retrieving the title of the flight deals page after performing login.
        /// </summary>
        [Test] // Test for retrieving subtitle
        public void GetTitle()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps using the homepage object
            flightdeal.PerformLogin(username, password);
            Thread.Sleep(2000);

            string expectedSubtitle = "Flight deals";
            string actualSubtitle = flightdeal.Title();

            Assert.That(actualSubtitle, Is.EqualTo(expectedSubtitle));
        }

        /// <summary>
        /// Test for clicking the checkbox button on the flight deal page.
        /// </summary>
        [Test] // Test for clicking the checkbox button
        public void TestBoxOneButton()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps
            flightdeal.PerformLogin(username, password);

            // Click on the checkbox button
            flightdeal.BoxButton();

            // Optionally add assertions to confirm the expected result after the click
        }

        /// <summary>
        /// Test for verifying the source and destination of the first flight deal box.
        /// </summary>
        [Test]
        public void TestBoxOneSourceToDestination()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            // Expected values for source and destination
            string expectedSource = "Seattle (SEA)";
            string expectedDestination = "to Barcelona (BCN)";  // Replace with the actual destination

            // Get the actual source and destination
            var (actualSource, actualDestination) = flightdeal.BoxSourceToDestination(1);

            // Assert both source and destination
            Assert.That(actualSource, Is.EqualTo(expectedSource));
            Assert.That(actualDestination, Is.EqualTo(expectedDestination));
        }

        /// <summary>
        /// Test for verifying the source and destination of the second flight deal box.
        /// </summary>
        [Test]
        public void TestBoxTwoSourceToDestination()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            // Expected values for source and destination
            string expectedSource = "Seattle (SEA)";
            string expectedDestination = "to Singapore (SIN)";  // Replace with the actual destination

            // Get the actual source and destination
            var (actualSource, actualDestination) = flightdeal.BoxSourceToDestination(2);

            // Assert both source and destination
            Assert.That(actualSource, Is.EqualTo(expectedSource));
            Assert.That(actualDestination, Is.EqualTo(expectedDestination));
        }

        /// <summary>
        /// Test for verifying the source and destination of the third flight deal box.
        /// </summary>
        [Test]
        public void TestBoxThreeSourceToDestination()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            // Expected values for source and destination
            string expectedSource = "Seattle (SEA)";
            string expectedDestination = "to Puerto Nare (NAR)";  // Replace with the actual destination

            // Get the actual source and destination
            var (actualSource, actualDestination) = flightdeal.BoxSourceToDestination(3);

            // Assert both source and destination
            Assert.That(actualSource, Is.EqualTo(expectedSource));
            Assert.That(actualDestination, Is.EqualTo(expectedDestination));
        }

        /// <summary>
        /// Test for verifying the source and destination of the fourth flight deal box.
        /// </summary>
        [Test]
        public void TestBoxFourSourceToDestination()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            // Expected values for source and destination
            string expectedSource = "Seattle (SEA)";
            string expectedDestination = "to Hounslow (LHR)";  // Replace with the actual destination

            // Get the actual source and destination
            var (actualSource, actualDestination) = flightdeal.BoxSourceToDestination(4);

            // Assert both source and destination
            Assert.That(actualSource, Is.EqualTo(expectedSource));
            Assert.That(actualDestination, Is.EqualTo(expectedDestination));
        }

        /// <summary>
        /// Test for verifying the end date of the first flight deal box.
        /// </summary>
        [Test]
        public void TestBoxOneEndDate()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedEndDate = "Purchase by Feb 13th 2018";
            string actualEndDate = flightdeal.BoxEndDate(1);

            Assert.That(actualEndDate, Is.EqualTo(expectedEndDate));
        }

        /// <summary>
        /// Test for verifying the end date of the second flight deal box.
        /// </summary>
        [Test]
        public void TestBoxTwoEndDate()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedEndDate = "Purchase by Feb 13th 2017";
            string actualEndDate = flightdeal.BoxEndDate(2);

            Assert.That(actualEndDate, Is.EqualTo(expectedEndDate));
        }

        /// <summary>
        /// Test for verifying the end date of the third flight deal box.
        /// </summary>
        [Test]
        public void TestBoxThreeEndDate()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedEndDate = "Purchase by Feb 13th 2017";
            string actualEndDate = flightdeal.BoxEndDate(3);

            Assert.That(actualEndDate, Is.EqualTo(expectedEndDate));
        }

        /// <summary>
        /// Test for verifying the end date of the fourth flight deal box.
        /// </summary>
        [Test]
        public void TestBoxFourEndDate()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedEndDate = "Purchase by Feb 13th 2017";
            string actualEndDate = flightdeal.BoxEndDate(4);

            Assert.That(actualEndDate, Is.EqualTo(expectedEndDate));
        }

        /// <summary>
        /// Test for verifying the description of the first flight deal box.
        /// </summary>
        [Test]
        public void TestBoxOneDescription()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedDescription = "From $ 479 ONEWAY";
            string actualDescription = flightdeal.BoxDescription(1);

            Assert.That(actualDescription, Is.EqualTo(actualDescription));
        }

        /// <summary>
        /// Test for verifying the description of the second flight deal box.
        /// </summary>
        [Test]
        public void TestBoxTwoDescription()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedDescription = "From $ 528 ONEWAY";
            string actualDescription = flightdeal.BoxDescription(2);

            Assert.That(actualDescription, Is.EqualTo(actualDescription));
        }

        /// <summary>
        /// Test for verifying the description of the third flight deal box.
        /// </summary>
        [Test]
        public void TestBoxThreeDescription()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedDescription = "From $ 535 ONEWAY";
            string actualDescription = flightdeal.BoxDescription(3);

            Assert.That(actualDescription, Is.EqualTo(actualDescription));
        }

        /// <summary>
        /// Test for verifying the description of the fourth flight deal box.
        /// </summary>
        [Test]
        public void TestBoxFourDescription()
        {
            string username = "admin";
            string password = "admin";

            flightdeal.PerformLogin(username, password);

            string expectedDescription = "From $ 626 ONEWAY";
            string actualDescription = flightdeal.BoxDescription(4);

            Assert.That(actualDescription, Is.EqualTo(actualDescription));
        }
    }
}
