using OpenQA.Selenium;

namespace Unit.tests.Sections
{
    public partial class RegistrationSection
    {
        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
            }
        }

        public IWebElement FullName
        {
            get
            {
                return this.Driver.FindElement(By.Id("FullName"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("Password"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("ConfirmPassword"));
            }
        }
        public IWebElement SubmitButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[6]/div/input"));
            }
        }
        public string ErrorMessagesForMissingEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]")).Text;
            }
        }
        public string ErrorMessagesForInvalidgEmail
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]")).Text;
            }
        }
        public string ErrorMessagesForMissingFullName
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]")).Text;
            }
        }
        public string ErrorMessagesForMissingPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]")).Text;
            }
        }
        public string ErrorMessagesForMismatchPassword
        {
            get
            {
                return this.Driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[1]")).Text;
            }
        }
    }
}
