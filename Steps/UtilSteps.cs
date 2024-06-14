using FluentAssertions.Equivalency.Tracing;
using Newtonsoft.Json;
using NUnit.Framework;
using SpecGeneric01.TestEnumData;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecGeneric01.Steps
{
    [Binding]
    public sealed class UtilSteps
    {
        private ScenarioContext scenarioContext;

        public UtilSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }


        [Given(@"write data to json file")]
        public void write_json()
        {
            var PesonName = new Bogus.DataSets.Name(locale: "en");
            Dictionary<string,string> dataDict = new Dictionary<string,string>();
            dataDict.Add("Name", PesonName.FirstName());
            dataDict.Add("Address", new Bogus.DataSets.Address(locale:"en").StreetAddress());
            WriteToJsonFile(dataDict);
        }

        [When("read data from json file")]
        public void read_json()
        {
            using StreamReader reader = new("../../../test1.json");
            var json = reader.ReadToEnd();
            Dictionary<object, string> data = JsonConvert.DeserializeObject<Dictionary<object,string>>(json);
            Console.WriteLine(data["Name"]);
            //return data;
        }

        [When(@"the following JSON data:")]
        public void GivenTheFollowingJsonData(TestUserData user)
        {
            // Access the deserialized JSON object
            string name = user.Name;
            int age = user.Age;

            Console.WriteLine($"Name: {name} Age: {age}");
            // Use the parsed JSON data as needed in your step
        }

        [StepArgumentTransformation]
        public TestUserData TransformJsonToUserObject(string jsonString)
        {
            return JsonConvert.DeserializeObject<TestUserData>(jsonString);
        }



        [When(@"the following JSON data2:")]
        public void GivenTheFollowingJsonData2(Dictionary<string, object> data)
        {
            // Access the deserialized JSON object
            Console.WriteLine($"Name: {data["Name"]}");
            // Use the parsed JSON data as needed in your step
        }

        [Then(@"should be error in step")]
        public void errorX1()
        {
            Assert.Fail("I am going to Fail");
        }


        [StepArgumentTransformation]
        public Dictionary<string, object> TransformJsonToDict(string jsonString)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
        }








        public void WriteToJsonFile(Dictionary<string,string> d,string? path=null)
        {
            //Dictionary<string, string> data = new Dictionary<string, string>();
            //data.Add("Id", "data1");
            //data.Add("Name", "data2");
            //string name = TestEnumData.TestData.Name;


            System.IO.File.WriteAllText("../../../test1.json", JsonConvert.SerializeObject(d, Formatting.Indented));
        }

        ////public class MyClass<T> where T : new()
        ////{
        //    protected T GetObject()
        //    {
        //        return new T();
        //    }
        ////}







    }
}