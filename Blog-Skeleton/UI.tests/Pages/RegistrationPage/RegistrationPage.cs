using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using UI.tests.Models;

namespace UI.tests.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        private string url = "http://localhost:60634/Account/Register";

        public string UniqueEmail
        {
            get
            {
                return Guid.NewGuid() + "@abv.bg";
            }
        }

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }

        public void FillRegistrationFormAndCickRegisterBtn(RegistrationUser user)
        {
            Type(this.Email, this.UniqueEmail);
            Type(this.FullName, user.FullName);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.RegisterBtn.Click();
        }

        public void FillRegistrationFormAndClickRegisterBtn_DataDriven(RegistrationUser user)
        {
            Type(this.Email, user.Email);
            Type(this.FullName, user.FullName);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.RegisterBtn.Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
