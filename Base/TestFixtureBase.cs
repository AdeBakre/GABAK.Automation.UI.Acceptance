using System.Configuration;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using NUnit.Framework;
using OpenQA.Selenium;



namespace GABAK.Automation.UI.Acceptance.Base
{
    public class TestFixtureBase : Browser
    {
        protected IWebDriver CurrentDriver { get; set; }
        private string browser = ConfigurationManager.AppSettings["browserName"];

        [SetUp]
        public void Test_Setup()
        {

            CurrentDriver = BrowserConfig.SetDriverInstance(browser);
        }


        
        [TearDown]
        public void Test_Teardown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Status == TestStatus.Failed
                        && CurrentDriver is ITakesScreenshot)
                {
                   // ((ITakesScreenshot)CurrentDriver).GetScreenshot().SaveAsFile(TestContext.CurrentContext.Test.FullName + ".jpg", ImageFormat.Jpeg);
                }
            }
            catch { }   // null ref exception occurs from accessing TestContext.CurrentContext.Result.Status property

            try
            {
                CurrentDriver.Quit();
            }
            catch { }
        }
    }
}
