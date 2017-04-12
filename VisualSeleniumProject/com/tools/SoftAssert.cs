using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSeleniumProject.tools
{
    class SoftAssert
    {

        private static int errorCount = 0;

        //Soft assert... will write lines with messages if condition is not validated
        //return false if condition is not true. 
        public static bool verifyTrue(String message, String expected, String actual)
        {
            bool result = true;
            if (!actual.Equals(expected))
            {
                errorCount++;
                result = false;
            }

          //  Debug.WriteLineIf(actual.Contains(expected), "PASSED: " + message + " -- Expected: " + expected + "  -- Actual: " + actual);
            Debug.WriteLineIf(!actual.Contains(expected), "Failure: " + message + " -- Expected: " + expected + "  -- Actual: " + actual);
           
           //Debug.Assert(expected.Contains(actual), "Error: " + message + " -- Expected: " + expected + " -- Actual: " + actual);

            return result;
        }

        //Soft assert... will write lines with messages if condition is not validated
        //return false if condition is not true. 
        public static bool verifyTrue(String message, bool condition)
        {
            bool result = true;
            if (!condition)
            {
                errorCount++;
                result = false;
            }

            Debug.WriteLineIf(!condition, "Failure: " + message );
            
            return result;
        }


        public static int getErrorCount()
        {
            return errorCount;
        }
    }
}
