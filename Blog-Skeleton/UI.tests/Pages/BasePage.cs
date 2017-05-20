namespace UI.tests.Pages
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Configuration;

    public class BasePage
    {
        protected string url = ConfigurationManager.AppSettings["URL"];
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(120));
        }

        public IWebDriver Driver
        {
            get { return this.driver; }
        }

        public WebDriverWait Wait //May be, not worked fine
        {
            get { return this.wait; }
        }
    }
}
