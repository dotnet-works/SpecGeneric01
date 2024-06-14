using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecGeneric01.TableTransform
{
    public static class TableExtensions
    {

        public static List<string> HeaderToList(this Table table)
        {
            List<string> hed = new List<string>();
            try
            {
                foreach (var header in table.Header)
                {
                    hed.Add(header.ToString());//, typeof(string));
                }
                Console.WriteLine(hed[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return hed;
        }



        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();



            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            foreach (var row in table.Rows)
            {
                var newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

    }
}

