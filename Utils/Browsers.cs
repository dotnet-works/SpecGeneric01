using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSpec01.Configurations;

namespace SpecGeneric01.Utils
{
    public static class Browsers
    {
        //public static IWebDriver driver;
        public  static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        private static string? _baseURL = "https://www.google.com/";
        private static string? _browserName;  // = "Chrome";
        static AppVars _appVars = new AppVars();


        public static IWebDriver BrowserInit(string browserName)
        {
            switch (_browserName)
            {
                case "chrome":
                    driver.Value = new ChromeDriver();
                    break;
                case "firefox":
                    driver.Value = new FirefoxDriver();
                    break;
                default:
                    driver.Value = new ChromeDriver();
                    break;
            }
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(15);
            return driver.Value;
        }






        //public static void Init()
        //{
        //    Console.WriteLine($"browser name: {_appVars.BrowserType.ToLower()}");
        //    _browserName = _appVars.BrowserType.ToLower();

        //    switch (_browserName)
        //    {
        //        case "chrome":
        //            driver = new ChromeDriver();
        //            break;
        //        case "firefox":
        //            driver = new FirefoxDriver();
        //            break;
        //        default:
        //            driver = new ChromeDriver();
        //            break;
        //    }
        //    driver.Manage().Window.Maximize();
        //    Goto(_baseURL);
        //}
        //public static string Title
        //{
        //    get { return driver.Title; }
        //}
        public static IWebDriver getDriver
        {
            get { return driver.Value; }
        }
        //public static void Goto(string url)
        //{
        //    driver.Url = url;
        //}
        //public static void Close()
        //{
        //    driver.Quit();
        //}
    }//class
}
