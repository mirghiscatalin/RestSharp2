using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSeleniumProject.tools
{
    class Constants
    {

        public static String BASE_URL = "http://fixer.io/latest";
        //public static String BASE_URL = "https://www.northernsafety-qa.com/";

        //browser selection - set in BaseTest
        //public static String BROWSER = "firefox";
        public static String BROWSER = "iexplorer";

        // report path - for print screens and html report 
        public static String REPORT_PATH = @"D:\Temp\UITestsReport";
        public static String EXTENT_REPORT_FILE = REPORT_PATH + @"ExtentReport.html";

        //default application wait time for elements
        public static int WAIT_TIME = 10;

        //delay picture so content ca load on webpage.
        public static double WAIT_PICTURE_INTERVAL = 2000.0;
        public static double WAIT_PICTURE_DELAY = 1000.0;

        //Set this to testName so printsceens can be tracked
        public static String PICTURE_NAME = "SS";

        public static String GUID = "";
    }
}
