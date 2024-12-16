using InterfaceClass;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace WebAdaptor
{
    public class WebDriverAdapter : IWebDriverAdapter
    {
        private IWebDriver _driver;

        public void InitializeDriver()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        public void QuitDriver()
        {
            _driver.Quit();
        }

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
