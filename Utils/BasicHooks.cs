using BoDi;
using TechTalk.SpecFlow;

namespace SpecGeneric01.Utils
{
    [Binding]
    public sealed class BasicHooks
    {
        private IObjectContainer _container;

        public BasicHooks(IObjectContainer _container)
        {
            this._container = _container;  
        }


        [BeforeTestRun]
        public static void beforeTestRun()
        {

        }

        [AfterTestRun]
        public static void afterTestRun()
        {
           
        }


     
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
           
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            
        }

        [BeforeStep]
        public void beforeSpecTest(ScenarioContext scenarioContext)
        {

            Console.WriteLine($"Step-Info: {scenarioContext.StepContext.StepInfo.Text.ToString()}");
        }

        [AfterStep]
        public void afterSpecStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine(" ========= Step Info ============");
            var stepType = scenarioContext.CurrentScenarioBlock.ToString();
            // var stepDef = scenarioContext.ScenarioInfo.Description.ToString();
            Console.WriteLine($"step status :{scenarioContext.StepContext.Status}");
            Console.WriteLine($"step Title :{scenarioContext.ScenarioInfo.Title}");
            Console.WriteLine($"step Description :{scenarioContext.ScenarioInfo.Description}");
            Console.WriteLine($"step Type: {stepType}");
            Console.WriteLine($"step Def: {scenarioContext.StepContext.StepInfo.Text}");
            Console.WriteLine($"{scenarioContext.StepContext.Status.ToString()}");


            if (scenarioContext.TestError != null)
            {
                Console.WriteLine($"Test Error Message: {scenarioContext.TestError.Message.ToString()}");
                Console.WriteLine($"Test StackTrace {scenarioContext.TestError.StackTrace.ToString()}");
                Console.WriteLine($"Test Error Source: {scenarioContext.TestError.Source.ToString()}");
            }
            Console.WriteLine(" =========  END  ==========");

        }



    }
}