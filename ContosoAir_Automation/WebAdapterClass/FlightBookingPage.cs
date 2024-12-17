using InterfaceClass;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace WebAdapterClass
{
    public class FlightBookingPage : IFlightBooking
    {
        private IWebDriver driver;

        public FlightBookingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("http://contosoair.westus.cloudapp.azure.com:3000/");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 688);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("username")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.CssSelector(".btn")).Click();
        }

        public void SelectFlightDetails(string from, string to, DateTime departureDate, int passengers, DateTime returnDate)
        {
            driver.FindElement(By.LinkText("Book")).Click();

            // Select Departure Airport
            var fromDropdown = driver.FindElement(By.Id("fromCode"));
            fromDropdown.FindElement(By.XPath($"//option[. = '{from}']")).Click();
            Thread.Sleep(2000);

            // Select Arrival Airport
            var toDropdown = driver.FindElement(By.Id("toCode"));
            toDropdown.FindElement(By.XPath($"//option[. = '{to}']")).Click();
            Thread.Sleep(2000);

            // Select Departure Date (with WebDriverWait)
            driver.FindElement(By.Id("dpa")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var departureDateCell = wait.Until(drv =>
                drv.FindElement(By.XPath($"//td[contains(text(), '{departureDate.Day}')]"))
            );
            departureDateCell.Click();

            // Select Passengers
            driver.FindElement(By.Id("passengers")).Click();
            var passengersDropdown = driver.FindElement(By.Id("passengers"));
            passengersDropdown.FindElement(By.XPath($"//option[. = '{passengers}']")).Click();

            // Select Return Date (with WebDriverWait)
            driver.FindElement(By.Id("dpb")).Click();
            var returnDateCell = wait.Until(drv =>
                drv.FindElement(By.XPath($"//td[contains(text(), '{returnDate.Day}')]"))
            );
            returnDateCell.Click();
        }

        public void BookFlight()
        {
            driver.FindElement(By.CssSelector(".btn-md")).Click();
            driver.FindElement(By.CssSelector(".row:nth-child(3) .block-flights-results-list-item:nth-child(2) .big-blue-radio")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".btn:nth-child(5)")).Click();
            driver.FindElement(By.CssSelector(".block-booking-title")).Click();
            driver.FindElement(By.CssSelector(".block-booking-passenger")).Click();
        }

        public void Close()
        {
            driver.Close();
        }
    }
}