namespace UI.tests
{
    using OpenQA.Selenium.Chrome;
    using TestStack.Seleno.Configuration;

    public static class WebHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";
       

        static WebHost()
        {
<<<<<<< HEAD
=======
           
            Instance.Run("Blog", 60634);
>>>>>>> 488381d794f49bc438cc0d07c5d2bad179cfc9ee

            Instance.Run("Blog", 60639, w => w.WithRemoteWebDriver(() => new ChromeDriver()));

        }
    }
}
