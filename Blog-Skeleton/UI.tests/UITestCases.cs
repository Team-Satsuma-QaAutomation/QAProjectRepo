namespace UI.tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using System.Configuration;
    using System.IO;
    using NUnit.Framework.Interfaces;
    using UI.tests.Models;
    using UI.tests.Pages.RegistrationPage;
    using System;
    using Pages.LoginPage;

    [TestFixture]
    public class UITestCases
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = WebHost.Instance.Application.Browser;
            this.driver.Manage().Window.Maximize();
        }



        // 2. Register with invalid e-mail
        [Test, Property("Priority", 1)]
        [Author("Ivaylo Arsov")]
        public void RegisterWithInvalidEmail()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithInvalidEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationFormAndClickRegisterBtn_DataDriven(user);

            regPage.AssertInvalidEmailMsgExist();
        }

        // 3. Register without e-mail
        [Test, Property("Priority", 1)]
        [Author("Ivaylo Arsov")]
        public void RegisterWithoutEmail()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutEmail");

            regPage.NavigateTo();
            regPage.FillRegistrationFormAndClickRegisterBtn_DataDriven(user);

            regPage.AssertWithoutEmailMsgExist();
        }

        // 4. Registration without FullNaname
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegisterWithoutFullName()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutFullName");

            regPage.NavigateTo();
            regPage.FillRegistrationFormAndClickRegisterBtn_DataDriven(user);

            regPage.AssertWithoutFullName();
        }

        // 5. Registration without Password
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegisterWithoutPassword()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithoutPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationFormAndClickRegisterBtn_DataDriven(user);

            regPage.AssertWithoutPasswordMsg();
        }

        // 6. Registration with Mismatch pasword
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegisterWithMismatchPassword()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterMIsmatchPassword");

            regPage.NavigateTo();
            regPage.FillRegistrationFormAndClickRegisterBtn_DataDriven(user);

            regPage.AssertMisMatchPasswordMsg();
        }

        // 7. Register with valid credentials
        [Test, Property("Priority", 1)]
        [Author("Ivaylo Arsov")]
        public void RegisterWithValidCredentials()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithValidCredentials");

            regPage.NavigateTo();
            regPage.FillRegistrationFormAndCickRegisterBtn(user);
        }
        // 8. Login with existing user
        [Test, Property("Priority", 1)]
        [Author("Todor Todorov")]
        public void LoginWithExistingUser()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithExistingUser");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertLoginWithExistingUser();
        }


        // 9. Press Login withouting Email and Password
        [Test, Property("Priority", 1)]
        [Author("Todor Todorov")]
        public void LoginWithoutUserAndPassword()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithoutEmailAndPassword");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertLoginEmailAndPasswordIsRequired();

        }
        // 10. Login with existing user but without password
        [Test, Property("Priority", 1)]
        [Author("Todor Todorov")]
        public void LoginWithoutPassword()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithoutPassword");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertLoginPasswordIsRequired();
        }
        // 11. Login with existing user but with wrong password
        [Test, Property("Priority", 1)]
        [Author("Todor Todorov")]
        public void LoginWithExistingUserButWrongPassword()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithExistingUserButWrongPassword");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertLoginWithWrongPassword();
        }

        // 12. Login with nonexisting user but with valid password
        [Test, Property("Priority", 2)]
        [Author("Ivo Igov")]
        public void LoginWithNonExistingUserButValidPassword()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithNonExistingUserButValidPassword");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertLoginWithWrongPassword();
        }

        // 13. Login with invalid email
        [Test, Property("Priority", 2)]
        [Author("Ivo Igov")]
        public void LoginWithInvalidEmail()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithInvalidEmail");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertInvalidEmailMessage(); 
        }

        // 14. Login with random numbers as email and password
        [Test, Property("Priority", 1)]
        [Author("Ivo Igov")]
        public void LoginWithRandomNumbersAsEmailAndPassword()
        {
            LoginPage logPage = new LoginPage(this.driver);
            var existinguser = AccessExcelDataLoginUser.GetTestData("LoginWithRandomNumbersAsEmailAndPassword");
            logPage.NavigateTo();
            logPage.FillLoginForm_AndClickLoginBtn_DataDriven(existinguser);
            logPage.AssertInvalidEmailMessage();         
        }


        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\x86\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName
                    + "\n || " + TestContext.CurrentContext.TestDirectory
                    + "\n || " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }

        }
    }
}
