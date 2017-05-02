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
    }
}
