namespace Unit.tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.Configuration;
    using System.IO;
    using NUnit.Framework.Interfaces;
    using System;
    using Sections;

    [TestFixture]
    public class RegistrationSectionTests
    {
        public IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();

        }

        [TearDown]
        public void CleanUp()
        {
            this.driver.Quit();

        }

        // 1. Registration without Email
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegistrateWithoutEmail()
        {
            var registrationsection = new RegistrationSection(this.driver);
            var InputData = AccessExcelData.GetTestData("Test1");
            RegistrationForm user = new RegistrationForm(InputData.Email,
                                                          InputData.FullName,
                                                          InputData.Password,
                                                          InputData.ConfirmPassword);

            registrationsection.NavigateTo();
            registrationsection.FillRegistrationForm(user);
            registrationsection.AssertMissingEmailMessage("The Email field is required.");
        }
        // 2. Registration without FullNaname
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegistrateWithoutFullName()
        {
            var registrationsection = new RegistrationSection(this.driver);
            var InputData = AccessExcelData.GetTestData("Test2");
            RegistrationForm user = new RegistrationForm(InputData.Email,
                                                          InputData.FullName,
                                                          InputData.Password,
                                                          InputData.ConfirmPassword);

            registrationsection.NavigateTo();
            registrationsection.FillRegistrationForm(user);
            registrationsection.AssertMissingFullNamelMessage("The Full Name field is required.");
        }
        // 3. Registration without Password
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegistrateWithoutPassword()
        {
            var registrationsection = new RegistrationSection(this.driver);
            var InputData = AccessExcelData.GetTestData("Test3");
            RegistrationForm user = new RegistrationForm(InputData.Email,
                                                          InputData.FullName,
                                                          InputData.Password,
                                                          InputData.ConfirmPassword);

            registrationsection.NavigateTo();
            registrationsection.FillRegistrationForm(user);
            registrationsection.AssertMissingPasswordMessage("The Password field is required.");
        }
        
        // 4. Registration with Mismatch pasword
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegistrateWithoutMismatchPassword()
        {
            var registrationsection = new RegistrationSection(this.driver);
            var InputData = AccessExcelData.GetTestData("Test4");
            RegistrationForm user = new RegistrationForm(InputData.Email,
                                                          InputData.FullName,
                                                          InputData.Password,
                                                          InputData.ConfirmPassword);

            registrationsection.NavigateTo();
            registrationsection.FillRegistrationForm(user);
            registrationsection.AssertMismatchPasswordMessage("The password and confirmation password do not match.");
        }
        // 5. Registration with Invalid email
        [Test, Property("Priority", 1)]
        [Author("Dimo Yanev")]

        public void RegistrateWithInvaalidEmail()
        {
            var registrationsection = new RegistrationSection(this.driver);
            var InputData = AccessExcelData.GetTestData("Test5");
            RegistrationForm user = new RegistrationForm(InputData.Email,
                                                          InputData.FullName,
                                                          InputData.Password,
                                                          InputData.ConfirmPassword);

            registrationsection.NavigateTo();
            registrationsection.FillRegistrationForm(user);
            registrationsection.AsserInvalidEmailMessage("The Email field is not a valid e-mail address.");
        }


        public void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        [TearDown]
        public void CleanUpTest()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = AppDomain.CurrentDomain.BaseDirectory
                    .Replace("bin\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename, TestContext.CurrentContext.Test.FullName + "        " + TestContext.CurrentContext.WorkDirectory + "            " + TestContext.CurrentContext.Result.PassCount);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(filename + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }
        }

    }

}
