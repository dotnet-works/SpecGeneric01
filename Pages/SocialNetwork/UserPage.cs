using OpenQA.Selenium;
using SpecGeneric01.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.Pages.SocialNetwork
{
    public class UserPage
    {
        private IWebDriver driver;

        public IWebElement _LI_UserDropDown => Browsers.getDriver.FindElement(By.CssSelector("li.ossn-topbar-dropdown-menu"));
        public IWebElement _LI_LogoutOption => Browsers.getDriver.FindElement(By.CssSelector("a.dropdown-item.menu-topbar-dropdown-logout"));


    }
}
