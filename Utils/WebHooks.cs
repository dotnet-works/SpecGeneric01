using BoDi;
using Bogus;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecGeneric01.Utils;
using TechTalk.SpecFlow;
using WebSpec01.Configurations;

namespace WebSpec01.Utils
{
    [Binding]
    public sealed class WebHooks
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        static AppVars appVars;

        public WebHooks(IObjectContainer _container, ScenarioContext _scenarioContext)
        {
            this._container = _container;
            this._scenarioContext = _scenarioContext;
        }

        [BeforeTestRun]
        public static void runInit()
        {
            appVars = new AppVars();
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("AppSettings.json");
            IConfigurationRoot configRoot = configBuilder.Build();
            configRoot.Bind(appVars);
        }

        [AfterTestRun]
        public static void afterTestRun()
        {
            
        }

        [BeforeScenario("@web")]
        public void BeforeScenarioRun()
        {

           

            Console.WriteLine($"Browser-Name: {appVars.BrowserType.ToLower()}");
            Console.WriteLine($"Browser-Options: {appVars.ChromeOptions}");
            Console.WriteLine(appVars._TimeOut);

            driver = Browsers.BrowserInit(appVars.BrowserType.ToLower());
            this._container.RegisterInstanceAs<IWebDriver>(driver);
            

            //if (appVars.BrowserType.ToLower() == "chrome")
            //{
            //    ChromeOptions options = new ChromeOptions();
            //    options.AddArguments(appVars.ChromeOptions);

            //    driver = new ChromeDriver(options);
            //    driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(15);
            //    this._container.RegisterInstanceAs<IWebDriver>(driver);
            //}
        }

        [AfterScenario("@web")]
        public void AfterScenario()
        {
            var driver = this._container.Resolve<IWebDriver>();
            if (driver != null)
            {
                driver.Close();
                driver.Dispose();
            }
        }

        //[BeforeScenario]
        //public static void FirstBeforeScenario()
        //{
        //    Console.WriteLine($"Scenario Title: {ScenarioContext.Current.ScenarioInfo.Title}");
        //}

        

        
    }
}