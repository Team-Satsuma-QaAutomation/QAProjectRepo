namespace Unit.tests.Sections
{
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class RegistrationSection : BaseSection
    {
        public RegistrationSection(IWebDriver driver)
            : base(driver)
        {
        }

        public void NavigateTo()
        {


            this.Driver.Navigate().GoToUrl(base.url + "Account/Register/");

        }

        public void FillRegistrationForm(RegistrationForm user)
        {

            Type(this.Email, user.Email);
            Type(this.FullName, user.FullName);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.SubmitButton.Click();
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

