using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using VisualSeleniumProject.tools;

namespace VisualSeleniumProject.com.steps
{
    class RestSharpSteps : AbstractSteps
    {

        public RestSharpSteps(IWebDriver driver, ExtentTest extentTestReport)
            : base(driver, extentTestReport)
        {
            this.driver = driver;
            this.extentTestReport = extentTestReport;
        }


        //Home Page

        public void SearchFor(String searchTerm)
        {
            googleSearchPage.searchFor(searchTerm);
            loggerInfo(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void GetCategories(String expectedText)
        {

            String x = restSharpPage.restSharpTestMethod();



            loggerInfo("This is it!!!" + x);

            verifyTrue("The ID is not correct", x, expectedText);

        }


        public void postTest()
        {
            //loggerInfo("This is the ID: " + restSharpPage.ExecutePostWithDefaultValues());
            verifyTrue("The ID is: ", "201", restSharpPage.ExecutePostWithDefaultValues());
        }

        public void putTest()
        {
            //loggerInfo("This is the updated doc: " + restSharpPage.ExecutePutMethod());
            verifyTrue("This is the response code: ", "OK", restSharpPage.ExecutePutMethod());
        }

        public void putTestAfterDelete()
        {
            //loggerInfo("This is the updated doc: " + restSharpPage.ExecutePutMethod());
            verifyTrue("This is the response code: ", "NotFound", restSharpPage.ExecutePutMethod());
        }

        public void getTest()
        {
            //loggerInfo("This is the status code : " + restSharpPage.ExecuteGetMethod());
            verifyTrue("Get test failed: ", "test123", restSharpPage.ExecuteGetMethod());
        }

        public void getTestAfterPost()
        {
            verifyTrue("This is the docJson name: ", "Test DocJson Name", restSharpPage.ExecuteGetMethodAfterPost());
        }

        public void deleteTest()
        {
            //loggerInfo("This is the status code: " + restSharpPage.ExecuteDeleteMethod());
            verifyTrue("This is the response code: ", "OK", restSharpPage.ExecuteDeleteMethod());
        }

        public void getTestAfterDelete()
        {
            verifyTrue("Delete test failed! ", "0", restSharpPage.GetContentLength().ToString());
        }
    }
}
