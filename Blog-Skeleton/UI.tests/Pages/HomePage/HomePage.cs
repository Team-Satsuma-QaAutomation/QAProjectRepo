using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace UI.tests.Pages.HomePage
{
    public partial class HomePage : BasePage
    {
        private string url = "http://localhost:60634/Account/Login";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }

        //public void FillLoginForm()
    }
}
