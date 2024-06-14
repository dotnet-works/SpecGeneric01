using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecGeneric.Steps
{
    [Binding]
    public class GoogleStep1
    {
        private IWebDriver driver;
        public GoogleStep1(IWebDriver driver)
        {
            this.driver = driver;
        }

        [When(@"search ""(.*)""")]
        public void login(string query)
        {
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).SendKeys(query+"\n");
        }


    }
}