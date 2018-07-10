using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;



namespace GABAK.Automation.UI.Acceptance.Base
{
    [TestFixture]
    public class Reporter
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        protected static IWebDriver driver { get; set; }
        protected ExtentHtmlReporter htmlReporter;

        [SetUp]
        public void StartReport()
        {


            htmlReporter = new ExtentHtmlReporter("C:/Users/Setup/Desktop/SampleReports");

            htmlReporter.Configuration().Theme = Theme.Dark;

            htmlReporter.Configuration().DocumentTitle = "Test Scenarios Report";

            htmlReporter.Configuration().ReportName = "QA Report";

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);

            //ITakesScreenshot ts = (ITakesScreenshot)driver;
            //Screenshot screenshot = ts.GetScreenshot();

            //string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            //string actualPath = path.Substring(0, path.LastIndexOf("bin")) + "ErrorScreenshots" + "Ade test" + ".png";
            //string projectPath = new Uri(actualPath).LocalPath;
            //string reportPath = projectPath + "Reports\\AdeReports.html";

            //extent = new ExtentReports();
            //var extentHtml = new ExtentHtmlReporter(reportPath);


        }

        //protected static string Capture(IWebDriver _driver, string screenshotName)
        //{
        //    ITakesScreenshot ts = (ITakesScreenshot)_driver;
        //    Screenshot screenshot = ts.GetScreenshot();

        //    //string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //    //string actualPath = pth.Substring(0, pth.LastIndexOf("bin")) + "ErrorScreenshots" + screenshotName + ".png";
        //    //string projectPath = new Uri(actualPath).LocalPath;
        //    //screenshot.SaveAsFile(projectPath, ImageFormat.Png);
        //    return projectPath;
        //}

        //[OneTimeSetUp]
        //public static void InitialiseReport(string reportLocation, string reportName)
        //{

        //    //string reportPath = projectPath + "Reports\\MyReports.html";

        //    extent = new ExtentReports();

        //}

        public static void Pass()
        {
            test = extent.CreateTest("Report Pass");
            Assert.IsTrue(true);
            test.Log(Status.Pass, "test has passed");
        }

        public static void Fail()
        {
            test = extent.CreateTest("Report Pass");
            Assert.IsTrue(false);
            test.Log(Status.Pass, "test has failed");
        }

        /// <summary>
        /// This is to add the information for the report without verification
        /// </summary>
        /// <param name="infoText"></param>
        public static void Info(string infoText)
        {
            test = extent.CreateTest("Report Info");
            test.Log(Status.Info, infoText);
        }

        //public static void GetResult()
        //{
        //    var status = TestContext.CurrentContext.Result.Outcome.Status;
        //    var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
        //    var errorMessage = TestContext.CurrentContext.Result.Message;

        //    if (status == TestStatus.Failed)
        //    {

        //        test.Log(Status.Fail, stackTrace + errorMessage);
        //    }

        //}

        public static void AttachScreenshot(IWebDriver driver, Status status, string reportText)
        {
            //driver.
        }

        [TearDown]
        public static void EndReport()
        {
            extent.Flush();
        }
    }

}
