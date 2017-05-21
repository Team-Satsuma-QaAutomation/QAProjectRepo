using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.tests.Pages.LoginPage
{
    public partial class LoginPage
    {
        public IWebElement LoginEmail
        {
            get {
                return this.Driver.FindElement(By.Id("Email"));
            }
        }


        public IWebElement LoginPassword
        {
            get {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }
        public IWebElement LoginButton
        {
            get { return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[4]/div/input")); }
        }
        public IWebElement ManageButton
        {
            get { return this.Driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li[2]/a")); }
        }
    }
}
