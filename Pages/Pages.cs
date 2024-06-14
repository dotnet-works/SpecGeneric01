using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecGeneric01.Pages.SocialNetwork;
using SpecGeneric01.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.Pages
{
    public static class Pages
    {
        private static IWebDriver driver;
        

        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browsers.getDriver, page);
            return page;
        }
        public static MainPage SocialMainPage => getPages<MainPage>();
    }//class
}
