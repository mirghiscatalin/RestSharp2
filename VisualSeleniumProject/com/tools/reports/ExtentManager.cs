using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualSeleniumProject.tools;

namespace VisualSeleniumProject.com.tools.reports
{

    //Documentation link - http://relevantcodes.com/extentreports-for-selenium/
    class ExtentManager
    {

        private static ExtentReports extent;

        public static ExtentReports Instance
        {
            get
            {
                if (extent == null)
                {
                    extent = new ExtentReports(Constants.EXTENT_REPORT_FILE, false);
                }
                return extent;
            }
        }

    }
}
