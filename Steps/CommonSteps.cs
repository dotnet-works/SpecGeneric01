using OpenQA.Selenium;
using System.Threading;
using System;
using TechTalk.SpecFlow;
using Bogus;

namespace SpecGeneric.Steps
{
    [Binding]
    public class CommonSteps
    {
        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"user navigates to ""(.*)""")]
        public void gotosite(string url)
        {
            Console.WriteLine($"Test Start At: {DateTime.Now.ToString("g")}");
            Console.WriteLine($"Test Start At: {DateTime.Now.ToString("U")}");
            driver.Navigate().GoToUrl(url);
        }

        [When(@"search ""(.*)"" data")]
        public void searchdata(string query)
        {
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).SendKeys(query + "\n");
        }




        [Given("some faker data test")]
        public void sp01()
        {
            var Add = new Bogus.DataSets.Address();
            var Name = new Bogus.DataSets.Name(locale: "en_US");

            //Set the randomizer seed if you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);

            Console.WriteLine($"Address: {Add.FullAddress()}");
            Console.WriteLine($"Name: {Name.FullName()}");

            Console.WriteLine($"Random {Randomizer.Seed.Next(1000, 2000)}");
            Console.WriteLine($"");
            Console.WriteLine($"");



        }

        [When(@"wait for (.*)")]
        [Then(@"wait for (.*)")]
        public void sp02(int waitTime)
        {
            Thread.Sleep(waitTime);
        }






    }
}