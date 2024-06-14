using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebSpec01.Configurations
{
    public class AppVars
    {
        public string BrowserType { get; set; }

        public string ProjectBasePath;

        public IList<string> ChromeOptions { get; set; }

        public IList<string> HeadlessChromeOptions { get; set; }

        public string _TimeOut { get; set; }

        public string TimeOut
        {
            get => _TimeOut;
            set => _TimeOut = value;
        }


        public string BasePath
        {
            get=> ProjectBasePath;
            set => ProjectBasePath = Directory.GetCurrentDirectory().Split("bin")[0] ?? string.Empty;
            
        
        }


    }
}
