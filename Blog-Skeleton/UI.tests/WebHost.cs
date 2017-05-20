using OpenQA.Selenium.Chrome;
using TestStack.Seleno.Configuration;

namespace UI.tests
{
    

    public static class WebHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";

        static WebHost()
        {
            Instance.Run("Blog", 60634, w => w.WithRemoteWebDriver(() => new ChromeDriver()));
        }
    }
}
