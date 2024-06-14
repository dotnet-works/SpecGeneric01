using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.Extensions
{
    public static class SpecFlowExtensions
    {
        
    /// <summary>
    /// Converts a two column Gherkin data table to a dictionary
    /// </summary>
    /// <param name="table"></param>
    /// <returns></returns>
    public static Dictionary<string, string> ToDictionary2(this Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Gherkin data table has no rows");

            if (table.Rows.First().Count != 2)
                throw new InvalidOperationException($@"Gherkin data table must have exactly 2 columns. Columns found: ""{string.Join(@""", """, table.Rows.First().Keys)}""");

            return table.Rows.ToDictionary(row => row[0], row => row[1]);
        }

        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }


        //public static Dictionary<string, string> ConvertToDictionary(this Table dt)
        //{
        //    var DataDict = new Dictionary<string, string>();
        //    dt.ToDictionary();
        //    //if (dt != null)
        //    //{
        //    //    var headers = dt.Header;

        //    //    //foreach (var row in dt.Rows)
        //    //    //{
        //    //    //    var dict = new Dictionary<string, string>();
        //    //        foreach (var header in headers)
        //    //        {
        //    //          DataDict.Add(header, dt.Rows.[header]);
        //    //        }

        //    //        DataDict.Add(dict);
        //    //    }
        //    //}

        //    //return lstDict;
        //}
    }



}

