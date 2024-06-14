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
    public class Pages1
    {
        private static IWebDriver driver;
        private static T getPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browsers.getDriver, page);
            return page;
        }
        public static MainPage SocialMainPage => getPages<MainPage>();
        public static RegistrationPage SocialRegestrationPage => getPages<RegistrationPage>();

        public static LoginPage SocialLoginPage => getPages<LoginPage>();

        public static UserPage SocialUserPage => getPages<UserPage>();

    }
    
}
