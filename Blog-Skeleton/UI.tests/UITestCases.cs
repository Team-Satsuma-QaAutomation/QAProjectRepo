using System.Configuration;
using System.IO;
using NUnit.Framework.Interfaces;
using UI.tests.Models;
using UI.tests.Pages.RegistrationPage;

namespace UI.tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;

    [TestFixture]
    public class UITestCases
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Window.Maximize();
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

            this.driver.Quit();
        }

        // 1. Navigate to Blog homepage
        [Test, Property("Priority", 1)]
        [Author("Author")]
        public void LoadHomePage()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            

            driver.Navigate().GoToUrl(@"http://localhost:60634/Article/List");

            var logo = wait.Until(w => w.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")));

            Assert.AreEqual("SOFTUNI BLOG", logo.Text);
        }

        // 3. Register with invalid e-mail
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

        // 4. Register without e-mail
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



        // 9. Register with valid credentials
        [Test, Property("Priority", 1)]
        [Author("Ivaylo Arsov")]
        public void RegisterWithValidCredentials()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            var user = AccessExcelData.GetTestData("RegisterWithValidCredentials");
       
            regPage.NavigateTo();
            regPage.FillRegistrationFormAndCickRegisterBtn(user);


        }
    }   
}
