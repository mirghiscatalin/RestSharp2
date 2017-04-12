using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Text.RegularExpressions;
using VisualSeleniumProject.pages;
using VisualSeleniumProject.tools;

namespace VisualSeleniumProject.com.steps
{
    //this class will contain reporting general methods and methods used in all other step classes
    class AbstractSteps
    {
        //pages used
        //all pages will be initialized here.
        public AbstractPage abstractPage;
        public GoogleHomePage googleSearchPage;
        public RestSharpPage restSharpPage;

        //Report and general elements
        //extent report link - http://extentreports.relevantcodes.com/net/docs.html#add-system-info
        public ExtentTest extentTestReport;
        public IWebDriver driver;


        public AbstractSteps(IWebDriver driver, ExtentTest extentTestReport)
        {
            this.driver = driver;
            this.extentTestReport = extentTestReport;

            abstractPage = new AbstractPage(driver);
            googleSearchPage = new GoogleHomePage(driver);
            restSharpPage = new RestSharpPage(driver);          
        }

        private String formatCamelCaseText(String camelCaseText)
        {
            //split name by camel case
            String formattedName = Regex.Replace(camelCaseText, "(\\B[A-Z]+?(?=[A-Z][^A-Z])|\\B[A-Z]+?(?=[^A-Z]))", " $1").Trim();

            System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
            formattedName = ti.ToTitleCase(formattedName);

            return formattedName;
        }

        //logging method
        public void loggerInfo(String methodName)
        {
            String formattedName = formatCamelCaseText(methodName);
            extentTestReport.Log(LogStatus.Info, formattedName);
        }

        //LoggingMethod with Screenshot for ExtentReports
        public void loggerInfoScreenshot(String methodName)
        {
            String formattedName = formatCamelCaseText(methodName);
            extentTestReport.Log(LogStatus.Info, formattedName + "\n" + extentTestReport.AddScreenCapture(ScreenshotHandler.captureScreenshot(driver)));
        }

        //logging method
        public void loggerPass(String message)
        {
            extentTestReport.Log(LogStatus.Pass, message + "\n");
        }

        //logging Errors method
        //method name and error message will be passed to this method
        public void loggerError(String message)
        {
            extentTestReport.Log(LogStatus.Error, message  + "\n");
        }

        //logging Errors method
        //method name and error message will be passed to this method
        public void loggerFail(String message)
        {
            extentTestReport.Log(LogStatus.Fail, message + "\n");
        }

        //Abstract method - general method for navigation. Same call regardless of env
        public void navigateTo(String baseUrl)
        {
            abstractPage.navigateTo(baseUrl);
            loggerInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }


        //General validation method
        public void verifyTrue(String message, String expectedData, String actualData)
        {
            bool result = SoftAssert.verifyTrue(message,expectedData,actualData);

            if (!result)
            {
                loggerFail("Failure: " + message + " -- Expected: " + expectedData + "  -- Actual: " + actualData);
            }
            else
            {
                loggerPass("Success: Validated. Expected: " + expectedData + " Actual: " + actualData);
            }
        }

    }
}
