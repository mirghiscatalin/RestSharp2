using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSeleniumProject.tools
{
    class ScreenshotHandler
    {
        private static int itemCount = 0;

        //return fileName + path
        public static String captureScreenshot(IWebDriver driver)
        {
            waitForPageToLoad(driver);  
            pictureConstantWait(driver);

            itemCount++;
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            String shotName = itemCount + "-" + Constants.PICTURE_NAME + "-SS.png";
            String shotNamePath = System.IO.Path.Combine(Constants.REPORT_PATH, @shotName);

            ss.SaveAsFile(shotNamePath, System.Drawing.Imaging.ImageFormat.Png);

            return shotNamePath;
        }

        private static void pictureConstantWait(IWebDriver driver)
        {
            var now = DateTime.Now;
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(Constants.WAIT_PICTURE_DELAY));
            wait.PollingInterval = TimeSpan.FromMilliseconds(Constants.WAIT_PICTURE_INTERVAL);
            wait.Until((d) => (DateTime.Now - now) - TimeSpan.FromMilliseconds(Constants.WAIT_PICTURE_DELAY) > TimeSpan.Zero);
        }

        private static void waitForPageToLoad(IWebDriver driver)
        {
            IWait<IWebDriver> waiter = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(Constants.WAIT_TIME));
            waiter.Until((d) => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
