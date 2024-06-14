using Bogus;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecGeneric01.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpecGeneric01.Pages.SocialNetwork
{
    public class RegistrationPage
    {

            private IWebDriver driver;

            public IWebElement _TXT_FirstName => Browsers.getDriver.FindElement(By.Name("firstname"));
            public IWebElement _TXT_LastNameTXT => Browsers.getDriver.FindElement(By.Name("lastname"));

            public IWebElement _TXT_NewMail => Browsers.getDriver.FindElement(By.Name("email"));
            public IWebElement _TXT_NewReMail => Browsers.getDriver.FindElement(By.Name("email_re"));

            public IWebElement _TXT_BirthDate => Browsers.getDriver.FindElement(By.Name("birthdate"));
            public IWebElement _SI_BirthMonthPicker => Browsers.getDriver.FindElement(By.ClassName("ui-datepicker-month"));

            public IWebElement _SI_BirthYearPicker => Browsers.getDriver.FindElement(By.ClassName("ui-datepicker-year"));

            public IWebElement _TXT_UserName => Browsers.getDriver.FindElement(By.Name("username"));
            public IWebElement _TXT_Password => Browsers.getDriver.FindElement(By.Name("password"));
            public IWebElement _RD_Gender => Browsers.getDriver.FindElement(By.Name("gender"));
            public IWebElement _CK_AgreeCHK => Browsers.getDriver.FindElement(By.Name("gdpr_agree"));
            public IWebElement _BTN_SignUp => Browsers.getDriver.FindElement(By.Id("ossn-submit-button"));

            public IList<IWebElement> _BTN_Login => Browsers.getDriver.FindElements(By.XPath("//a[contains(text(),'Login')]"));

            
            public void RegisterNewUser(string fname=null,string lname=null,string userNewMail=null)
            {
               var userFaker = new Faker("en_IND");
            try
            {
                //fname = string.IsNullOrEmpty(fname) ? userFaker.Name.FirstName();

                _TXT_FirstName.SendKeys(string.IsNullOrEmpty(fname) ? userFaker.Name.FirstName():fname);
                _TXT_LastNameTXT.SendKeys("Test");// userFaker.Name.LastName());
                _TXT_NewMail.SendKeys(userNewMail);
                _TXT_NewReMail.SendKeys(userNewMail);
                _TXT_UserName.SendKeys(userFaker.Name.FirstName());
                _TXT_Password.SendKeys("Test@1234");
                 EnterBirthDate();
                _RD_Gender.Click();
                _CK_AgreeCHK.Click();
                _BTN_SignUp.Click();
                Thread.Sleep(3000);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void EnterBirthDate()
        {
            Thread.Sleep(2000);

            _TXT_BirthDate.Click();
            Thread.Sleep(500);
            SelectElement selectMonth = new SelectElement(_SI_BirthMonthPicker);
            selectMonth.SelectByText("Jan.");
            Thread.Sleep(1500);

            //IWebElement _selectEle2 = driver.FindElement(By.ClassName("ui-datepicker-year"));
            SelectElement selectYear = new SelectElement(_SI_BirthYearPicker);
            selectYear.SelectByText("2000");

            Thread.Sleep(500);

            string TodayDayOfMonth = DateTime.Now.Day.ToString();
            IWebElement calDay = driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']/tbody/tr/td//a[contains(text(),'12')]"));
            calDay.Click();

            Console.WriteLine($"Today day of Month: {TodayDayOfMonth}");

            Thread.Sleep(500);
            string text4 = driver.FindElement(By.Name("birthdate")).GetAttribute("value");

            Console.WriteLine($"BirtDate Format Day\\Month\\Year: {text4}");
            string dtTimeFormat = DateTime.Now.ToString("MMM-d-yyyy");
            Console.WriteLine($"Date Time Input Format: {dtTimeFormat}");
        }



    }
}
