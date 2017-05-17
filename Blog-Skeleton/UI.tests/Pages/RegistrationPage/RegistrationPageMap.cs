using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UI.tests.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement Email
        {
            get { return this.Driver.FindElement(By.Id("Email")); }
        }

        public IWebElement FullName
        {
            get { return this.Driver.FindElement(By.Id("FullName")); }
        }

        public IWebElement Password
        {
            get { return this.Driver.FindElement(By.Id("Password")); }
        }

        public IWebElement ConfirmPassword
        {
            get { return this.Driver.FindElement(By.Id("ConfirmPassword")); }
        }

        public IWebElement RegisterBtn
        {
            get { return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input")); }
        }

        public IWebElement ErrorMsgForEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li")));
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]/ul/li"));
            }
        }

        public IWebElement MenageBtn
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")));
                return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a"));
            }
        }
    }
}
