using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using UI.tests.Models;

namespace UI.tests.Pages.LoginPage
{
    public partial class LoginPage : BasePage
    {
        private string url = "http://localhost:60634/Account/Login";

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }
        public void FillLoginForm_AndClickLoginBtn_DataDriven(LoginUser user)
        {
            Type(this.LoginEmail, user.Email);
            Type(this.LoginPassword, user.Password);
            this.LoginButton.Click();
        }

        private void Type(IWebElement element, string text)
        {
            if (text == null)
            {
                element.SendKeys(string.Empty);
            }
            else
            {
                element.Clear();
                element.SendKeys(text);
            }
        }
    }
}
