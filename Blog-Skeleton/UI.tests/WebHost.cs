namespace UI.tests
{
    using TestStack.Seleno.Configuration;

    public class WebHost
    {
        public static readonly SelenoHost Instance = new SelenoHost();
        public static readonly string RootUrl = @"http://localhost:60634/Article/List";
       

        static WebHost()
        {
           
            Instance.Run("Blog", 60639);


        }
    }
}
