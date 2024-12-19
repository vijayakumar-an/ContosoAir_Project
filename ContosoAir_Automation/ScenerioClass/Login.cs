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
using WebAdapterClass;

namespace ScenerioClass
{
    // Scenario class for executing the login test
    [TestFixture]
    public class LoginScenario
    {
        private IWebDriver driver;
        private ILoginTest loginTest;

        /// <summary>
        /// Initializes the WebDriver and login test setup before each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize the WebDriver (e.g., ChromeDriver or any other driver)
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            // Initialize the login test interface with the driver.
            loginTest = new LoginTest(driver);
        }

        /// <summary>
        /// Test to perform login with valid credentials.
        /// </summary>
        [Test]
        public void PerformLoginWithCredentials()
        {
            // Define test URL, username, and password
            string url = "http://contosoair.westus.cloudapp.azure.com:3000/";
            string username = "Vijay";
            string password = "Vijay";

            // Perform login steps
            loginTest.NavigateToUrl(url);
            loginTest.PerformLoginWithCredentials(username, password);
            // Pause execution to observe results (optional).
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Test to perform login without providing any credentials.
        /// </summary>
        [Test]
        public void PerformLoginWithOutCredentials()
        {
            // Define the test URL.
            string url = "http://contosoair.westus.cloudapp.azure.com:3000/";

            // Step 1: Navigate to URL
            loginTest.NavigateToUrl(url);

            // Step 2: Perform login without credentials
            loginTest.PerformLoginWithOutCredentials();

            Thread.Sleep(2000); // Allow time for UI validation (optional)
        }

        /// <summary>
        /// Cleans up the WebDriver after each test execution.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Close the browser and dispose of the WebDriver instance.
            driver.Dispose();
        }
    }
}
