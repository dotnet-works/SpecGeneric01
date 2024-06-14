using OpenQA.Selenium;
using SpecGeneric01.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.Pages.SocialNetwork
{
    

    public class LoginPage
    {
        private IWebDriver driver;

        

        public IWebElement _TXT_UserName => Browsers.getDriver.FindElement(By.Name("username"));

        public IWebElement _TXT_Password => Browsers.getDriver.FindElement(By.Name("password"));

        public IWebElement _BTN_SignIn => Browsers.getDriver.FindElement(By.CssSelector("input.btn.btn-primary.btn-sm"));



    
    }
}
