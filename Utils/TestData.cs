using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.Utils
{
    public class TestDataLoader
    {
        private readonly string basePath = @"..\..\TestData";

        private readonly Dictionary<Type, string> fileNameRegistry = new()
    {
        { 
                //typeof(SortingData), "sorting_data.json" 
                 typeof(string), "sorting_data.json"
        }
    };

        public TResult GetJSONTestData<TResult>()
        {
            var typefileName = fileNameRegistry[typeof(TResult)];
            //var path = Path.Combine(basePath, typeFileName);
            var path = Path.Combine(basePath, "typeFileName");
            return LoadFromJSON<TResult>(path);
        }

        public static TResult LoadFromJSON<TResult>(string pathToJSON)
        {
            using (var reader = new StreamReader(pathToJSON))
            {
                var json = reader.ReadToEnd();
                var records = JsonConvert.DeserializeObject<TResult>(json);
                return records;
            }
        }

    }
}
