using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenerioClass
{
    public class HomepageTests
    {
        private WebAdapterClass.Homepage homepage;
        private IWebDriver driver;

        [SetUp] // Marks this method to run before each test
        public void Setup()
        {
            // Initialize WebDriver and Homepage instance
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            homepage = new WebAdapterClass.Homepage(driver);
            homepage.NavigateToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");
        }

        [Test]
        public void getLogo()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);
            Thread.Sleep(2000);
            // Check logo image
            Assert.DoesNotThrow(() => homepage.getLogo(), "Logo image is not displayed using Relative XPath.");
        }

        [Test] // Test for retrieving the title
        public void getTitle()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);

            // Expected title of the page
            string expected = "Where do you want to go?";

            // Actual title fetched from the page using the Homepage object
            string actual = homepage.getTitle();

            // Use System's Assert.Equals for comparison (if that's your preference)
            Assert.That(actual, Is.EqualTo("Where do you\r\nwant to go?"));
        }

        [Test] // Test for retrieving subtitle
        public void GetSubtitle()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);

            string expectedSubtitle = "Flight deals";
            string actualSubtitle = homepage.subTitle();

            Assert.That(actualSubtitle, Is.EqualTo(expectedSubtitle));
        }

        [Test] // Test for retrieving recommended title
        public void GetSuggestedTitle()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps using the homepage object
            homepage.PerformLogin(username, password);

            string expectedSuggestedTitle = "Recommended for you";
            string actualSuggestedTitle = homepage.getSuggestTitle();

            Assert.That(actualSuggestedTitle, Is.EqualTo(expectedSuggestedTitle));
        }

        [Test]
        public void checkHawaiiImage()
        {
            string username = "admin";
            string password = "admin";

            // Perform login
            homepage.PerformLogin(username, password);

            // Check Paris image
            Assert.DoesNotThrow(() => homepage.checkHawaiiImage(), "Hawaii image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkHawaiiCaption()
        {
            string username = "admin";
            string password = "admin";

            homepage.PerformLogin(username, password);

            string expectedName = "Hawaii";

            // Get the actual caption name
            string actualName = homepage.checkHawaiiCaption();

            // Assert the caption name
            Assert.That(actualName, Is.EqualTo(expectedName));

            // Check Paris caption, this should not throw an error.
            Assert.DoesNotThrow(() => homepage.checkParisCaption(), "The Hawaii caption is not displayed on the homepage.");
        }

        [Test]
        public void checkParisImageTest()
        {
            string username = "admin";
            string password = "admin";

            // Perform login
            homepage.PerformLogin(username, password);

            // Check Paris image
            Assert.DoesNotThrow(() => homepage.checkParisImage(), "Paris image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkParisCaption()
        {
            string username = "admin";
            string password = "admin";

            // Perform login
            homepage.PerformLogin(username, password);

            string expectedName = "Paris";

            // Get the actual caption name
            string actualName = homepage.checkParisCaption();

            // Assert the caption name
            Assert.That(actualName, Is.EqualTo(expectedName));

            // Check Paris caption, this should not throw an error.
            Assert.DoesNotThrow(() => homepage.checkParisCaption(), "The Paris caption is not displayed on the homepage.");
        }

        [Test]
        public void checkBarcelonaImage()
        {
            string username = "admin";
            string password = "admin";

            // Perform login
            homepage.PerformLogin(username, password);

            // Check Paris image
            Assert.DoesNotThrow(() => homepage.checkBarcelonaImage(), "Barcelona image is not displayed using Relative XPath.");
        }

        [Test]
        public void checkBarcelonaCaption()
        {
            string username = "admin";
            string password = "admin";

            homepage.PerformLogin(username, password);

            string expectedName = "Barcelona";

            // Get the actual caption name
            string actualName = homepage.checkBarcelonaCaption();

            // Assert the caption name
            Assert.That(actualName, Is.EqualTo(expectedName));

            // Check Paris caption, this should not throw an error.
            Assert.DoesNotThrow(() => homepage.checkBarcelonaCaption(), "The Barcelona caption is not displayed on the homepage.");
        }



        [Test] // Test for performing login
        public void PerformLoginTest()
        {
            // Define test username and password
            string username = "admin";
            string password = "admin";

            // Perform login steps using the _homepage object
            homepage.PerformLogin(username, password);

            // No need for logout verification, you can add another assertion if needed,
            // like checking that some element exists after login.
        }
        [TearDown] // Marks this method to run after each test
        public void TearDown()
        {
            driver.Quit();
        }
    }

}
