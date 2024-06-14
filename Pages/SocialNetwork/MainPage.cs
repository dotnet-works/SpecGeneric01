using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SpecGeneric01.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.Pages.SocialNetwork
{
    public class MainPage
    {
        //private static IWebDriver driver;
        private IWebDriver driver;
        //public MainPage(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    PageFactory.InitElements(this.driver,this);
        //}

        //public IWebElement Login => driver.FindElement(By.XPath("//a[contains(text(),'Frontend Demo')]"));
        public IWebElement Login => Browsers.getDriver.FindElement(By.XPath("//a[contains(text(),'Frontend Demo')]"));



    }
}
