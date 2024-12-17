using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAdaptor
{
    public class Homepage : IHomepage
    {
        private readonly IWebDriver driver;

        public Homepage(IWebDriver webDriver)
        {
            driver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        public void NavigateToUrl(string url)
        {
           driver.Navigate().GoToUrl(url);
        }


        public void getLogo()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement LogoImage = wait.Until(d => d.FindElement(By.XPath("//img[@class='block-navbar-left-logo']")));

            if (!LogoImage.Displayed)
            {
                throw new Exception("logo image is not displayed on the homepage.");
            }
        }

      public string getTitle()
        {
            // Create WebDriverWait instance
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Wait for up to 10 seconds

            // Wait for the element to be visible (we use the standard WebDriverWait here)
            IWebElement headingElement = wait.Until(d => d.FindElement(By.XPath("//span[normalize-space()='Where do youwant to go?']")));

            // Return the text of the element
            return headingElement.Text;
        }


        public string subTitle()
        {
            IWebElement subtitleElement = driver.FindElement(By.XPath("//h2[normalize-space()='Flight deals']"));
            return subtitleElement.Text;
        }

        public string getSuggestTitle()
        {
            IWebElement suggestTitleElement = driver.FindElement(By.XPath("//h2[normalize-space()='Recommended for you']"));
            return suggestTitleElement.Text;
        }

        public void checkHawaiiImage()
        {

        }

        public string checkHawaiiCaption()
        {
            IWebElement hawaiiCaption = driver.FindElement(By.XPath("//figcaption[normalize-space()='Hawaii']"));
            if (hawaiiCaption == null || !hawaiiCaption.Displayed)
            {
                throw new Exception("Hawaii caption is not displayed on the homepage.");
            }
            return hawaiiCaption.Text; // Return the caption text if it's found and displayed.
        }

        public void checkParisImage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement parisImage = wait.Until(d => d.FindElement(By.XPath("//img[@src='/assets/cities/paris_m.jpg']")));

            if (!parisImage.Displayed)
            {
                throw new Exception("Paris image is not displayed on the homepage.");
            }
        }

        public string checkParisCaption()
        {
            IWebElement ParisCaption = driver.FindElement(By.XPath("//figcaption[normalize-space()='Paris']"));
            if (ParisCaption == null || !ParisCaption.Displayed)
            {
                throw new Exception("Paris caption is not displayed on the homepage.");
            }
            return ParisCaption.Text; // Return the caption text if it's found and displayed.
        }

        public void checkBarcelonaImage()
        {

        }


        public string checkBarcelonaCaption()
        {
            IWebElement BarcelonaCaption = driver.FindElement(By.XPath("//figcaption[normalize-space()='Barcelona']"));
            if (BarcelonaCaption == null || !BarcelonaCaption.Displayed)
            {
                throw new Exception("Barcelona caption is not displayed on the homepage.");
            }
            return BarcelonaCaption.Text; // Return the caption text if it's found and displayed.
        }

        public void PerformLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be null or empty");
            }
                driver.FindElement(By.LinkText("Login")).Click();
                driver.FindElement(By.Id("username")).SendKeys(username);
                driver.FindElement(By.Id("password")).SendKeys(password);
                driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}

