using Bogus;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecGeneric01.Extensions;
using SpecGeneric01.Pages;
using SpecGeneric01.TestEnumData;



namespace SpecGeneric.Steps
{
    [Binding]
    public class SocialNetSteps1
    {
        private IWebDriver driver;
        private DataSet fakeData;
        private readonly ScenarioContext scenarioContext;
        public SocialNetSteps1(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;

        }

        [When(@"navigate to socialnetwork page")]
        public void login()
        {
            //driver.FindElement(By.XPath("//a[contains(text(),'Frontend Demo')]")).Click();
            Pages1.SocialMainPage.Login.Click();
        }

        [When(@"switch to window (.*) with title")]
        [Then(@"switch to window (.*) with title")]
        public void switchbetweenwins(string wintitle)
        {
            IList<string> WinHandles = driver.WindowHandles;
            Console.WriteLine(WinHandles.Count);

            scenarioContext.Add("WIN_HANDLES", WinHandles);
            driver.SwitchTo().Window(WinHandles.ToArray()[1].ToString());
        }

        //[When(@"enter (.*)")]
        [When(@"enter new user data")]
        public void stepx1()
        {
            var userFaker = new Faker("en_IND");

            string userNewMail = this.scenarioContext.Get<string>("NewMail");         //"zulu1122@yopmail.com";

            //Pages1.SocialRegestrationPage._TXT_FirstName.SendKeys(userFaker.Name.FirstName());
            //Pages1.SocialRegestrationPage._TXT_LastNameTXT.SendKeys(userFaker.Name.LastName());
            //Pages1.SocialRegestrationPage._TXT_NewMail.SendKeys(userNewMail);
            //Pages1.SocialRegestrationPage._TXT_NewReMail.SendKeys(userNewMail);
            //Pages1.SocialRegestrationPage._TXT_UserName.SendKeys(userFaker.Name.FirstName());
            //Pages1.SocialRegestrationPage._TXT_Password.SendKeys("Test@1234");
            //enterBirthDate();
            //Pages1.SocialRegestrationPage._RD_Gender.Click();
            //Pages1.SocialRegestrationPage._CK_AgreeCHK.Click();
            //Pages1.SocialRegestrationPage._BTN_SignUp.Click();
            //Thread.Sleep(3000);

            Pages1.SocialRegestrationPage.RegisterNewUser("MyTestName", null, userNewMail);

            this.scenarioContext.Add("NEWUSERMAIL", userNewMail);
            this.scenarioContext.Add(TestData.Name.ToString(), userNewMail);

        }

        [When(@"verify yopmail")]
        public void stepx2()
        {
            string yopUrl= "https://yopmail.com/";
            OpenNewTabAndSwitch(yopUrl);

            string _userYOPMail = this.scenarioContext.Get<string>("NEWUSERMAIL");

            Console.WriteLine(_userYOPMail);
            Console.WriteLine(this.scenarioContext.Get<string>(TestData.Name.ToString()));

            string activationURL = verifyYopMail(_userYOPMail);
            Console.WriteLine(activationURL);

            OpenNewTabAndSwitch(activationURL, 8000);
        }

        [When(@"login with new user to social network")]
        public void loginnewuser()
        {
            string _userYOPMail = this.scenarioContext.Get<string>("NEWUSERMAIL");
            Console.WriteLine(_userYOPMail);

            LoginSocialUser(_userYOPMail, "Test@1234", 5000);


            //if (Pages1.SocialRegestrationPage._BTN_Login.Count > 0)
            //{
            //    Pages1.SocialRegestrationPage._BTN_Login[0].Click();
            //}
            //Pages1.SocialLoginPage._TXT_UserName.Clear();
            //Pages1.SocialLoginPage._TXT_UserName.SendKeys(_userYOPMail);
            //Pages1.SocialLoginPage._TXT_Password.Clear();
            //Pages1.SocialLoginPage._TXT_Password.SendKeys("Test@1234");
            //Pages1.SocialLoginPage._BTN_SignIn.Click();
            //Thread.Sleep(8000);
            //Console.WriteLine($"Verify Title: {driver.Title}");


        }

        [When(@"verify user ""([^""]*)"" not exist")]
        public void xa1(string usermail)
        {
            LoginSocialUser(usermail, "Test@1234");
            if (driver.FindElement(By.CssSelector("div.alert.alert-danger")).Text.Contains("Invalid username or password!"))
            {
                Console.WriteLine("User Not found in system");
                Console.WriteLine("User Navigates to regestration page");
                Thread.Sleep(800);
                driver.Navigate().GoToUrl("https://demo.opensource-socialnetwork.org/");
                Thread.Sleep(2000);
                this.scenarioContext.Add("NewMail", usermail);
            }
            else
            {
                throw new Exception("User Exist in system");
            }
            
        }






        public void LoginSocialUser(string uname,string pw,int waitTime=0)
        {
            if (Pages1.SocialRegestrationPage._BTN_Login.Count > 0)
            {
                Pages1.SocialRegestrationPage._BTN_Login[0].Click();
                Pages1.SocialLoginPage._TXT_UserName.Clear();
                Pages1.SocialLoginPage._TXT_UserName.SendKeys(uname);
                Pages1.SocialLoginPage._TXT_Password.Clear();
                Pages1.SocialLoginPage._TXT_Password.SendKeys(pw);
                Pages1.SocialLoginPage._BTN_SignIn.Click();
                Thread.Sleep(waitTime);
                Console.WriteLine($"Verify Title: {driver.Title}");
            }
            else
            {
                throw new NoSuchElementException($"Element Not found:");
            }
            
        }

        //Then verify user logged in
        [When(@"logout from account")]
        public void x11()
        {
            Pages1.SocialUserPage._LI_UserDropDown.Click();
            Pages1.SocialUserPage._LI_LogoutOption.Click();
            Thread.Sleep(3000);
        }
        //Then verify user looged out






        public void OpenNewTabAndSwitch(string newurl,int msTime=0)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl(newurl);
            Thread.Sleep(msTime);
        }

        public string verifyYopMail(string yopmail)
        {
            string activationURL = null;
            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("login")).SendKeys(yopmail);

            driver.FindElement(By.CssSelector("div#refreshbut")).Click();
            string winHandle = driver.CurrentWindowHandle;

            Thread.Sleep(1000);

            driver.SwitchTo().Frame("ifinbox");
            Thread.Sleep(1000);

            driver.SwitchTo().Window(winHandle);
            Thread.Sleep(1000);

            driver.SwitchTo().Frame("ifmail");
            Thread.Sleep(1000);
            string mailBody = driver.FindElement(By.XPath("//main[@class='yscrollbar']")).Text;

            string[] strText2 = mailBody.ToString().Split("\n");
            for (int i = 0; i < strText2.Length; i++)
            {
               
                if (strText2[i].StartsWith("https://") && strText2[i].Contains("uservalidate/activate"))
                {
                    activationURL = strText2[i];
                    break;
                }
            }
            return activationURL;
        }

        public void enterBirthDate()
        {
            Thread.Sleep(2000);

            driver.FindElement(By.Name("birthdate")).Click();

            Thread.Sleep(500);

            IWebElement _selectEle = driver.FindElement(By.ClassName("ui-datepicker-month"));
            SelectElement selectMonth = new SelectElement(_selectEle);

            selectMonth.SelectByText("Jan.");

            Thread.Sleep(3500);

            IWebElement _selectEle2 = driver.FindElement(By.ClassName("ui-datepicker-year"));
            SelectElement selectYear = new SelectElement(_selectEle2);
            selectYear.SelectByText("2000");

            Thread.Sleep(500);

            string TodayDayOfMonth = DateTime.Now.Day.ToString();
            IWebElement calDay = driver.FindElement(By.XPath("//table[@class='ui-datepicker-calendar']/tbody/tr/td//a[contains(text(),'12')]"));
            calDay.Click();


            Console.WriteLine(TodayDayOfMonth);

            Thread.Sleep(500);
            string text4 = driver.FindElement(By.Name("birthdate")).GetAttribute("value");

            Console.WriteLine($"BirtDate Format Day\\Month\\Year: {text4}");
            string dtTimeFormat = DateTime.Now.ToString("MMM-d-yyyy");
            Console.WriteLine($"Date Time Input Format: {dtTimeFormat}");
        }

        [When(@"enter user credentails:")]
        public void x1(Table tbl)
        {
            var data1 = tbl.ToDictionary();
            var data2 = tbl.ToDictionary2();
            Console.WriteLine($"password: {data1["Password"]}");
            LoginSocialUser(data1["Email"], data1["Password"],7000);



        }

        


    }
}