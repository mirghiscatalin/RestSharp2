using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualSeleniumProject.tools;
using VisualSeleniumProject.pages;
using VisualSeleniumProject.com.steps;
using System.Diagnostics;
using VisualSeleniumProject.tests;
using NUnit.Framework;
using System.Configuration;

namespace VisualSeleniumProject
{
    
    public class PocGoogleTest : BaseTest
    {
        //test data
        private String baseUrl;
        private String searchTerm;
        private AbstractTest test;
        private String environment;

        //pages used
        private RestSharpSteps restSharpSteps;
        private AbstractPage abstractPage;


        [OneTimeSetUp]

        public void OneSetup()
        {
            test = new AbstractTest();
            environment = test.InitializeEnvironment(TestContext.Parameters["Environment"], "Environment");
            baseUrl = test.InitializeEnvironment(TestContext.Parameters["BaseUrl"], "BaseUrl");

        }


        [SetUp]
        public void before()
        {
            //init test data
            //baseUrl = Constants.BASE_URL;
            baseUrl = "http://www.google.com/";
            searchTerm = "Hamster";

            //printscreen names
            Constants.PICTURE_NAME = this.GetType().Name;

            //init webdriver
            InitializeDriver();

        }


        [Test]
        public void restSharpTest()
        {
            //init used pages
            extentTestReport = extentReports
             .StartTest("Google search");
            extentReports.AddSystemInfo("Environment", ConfigurationManager.AppSettings["Environment"]);
            restSharpSteps = new RestSharpSteps(driver, extentTestReport);
            abstractPage = new AbstractPage(driver);
            //abstractPage.navigateTo(baseUrl);
            //googleHomeSteps.SearchFor(searchTerm);
            //  googleHomeSteps.GetCategories("4.5384");
            restSharpSteps.postTest();
            restSharpSteps.getTestAfterPost();
            restSharpSteps.putTest();
            restSharpSteps.getTest();
            restSharpSteps.deleteTest();
            restSharpSteps.getTestAfterDelete();
            restSharpSteps.putTestAfterDelete();

            // String extractedTitle = abstractPage.waitForPageTitle(searchTerm);

            //SoftAssert.verifyTrue("Title is not as expected", "Hamster", extractedTitle );
        }

        [TearDown]
        public void after()
        {
            //Debug.Assert(SoftAssert.getErrorCount().CompareTo(0) == 0, "Error: Errors were found in test. Count: " + SoftAssert.getErrorCount());


            Debug.WriteLineIf(!(SoftAssert.getErrorCount().CompareTo(0) == 0), "Error: Errors were found in test. Count: " + SoftAssert.getErrorCount());

            driver.Close();
            driver.Quit();

            extentReports.EndTest(extentTestReport);
            extentReports.Flush();
            if (SoftAssert.getErrorCount() > (0))
            {
                Assert.Fail("Test failed!");
            }

        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            System.Diagnostics.Process.Start(Constants.EXTENT_REPORT_FILE);
        }
    }
}
