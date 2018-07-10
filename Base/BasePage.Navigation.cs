using System.Configuration;
using Baseclass.Contrib.SpecFlow.Selenium.NUnit.Bindings;
using OpenQA.Selenium;
using GABAK.Automation.UI.Acceptance.Pages;

namespace GABAK.Automation.UI.Acceptance.Base
{
    public abstract partial class BasePage
    {
        public static string BaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["seleniumBaseUrl"];
            }
        }

        public static HomePageOffline GetHomePageOffline(IWebDriver driver, string baseURL)
        {
            if (driver == null)
                driver = Browser.Current;
            driver.Navigate().GoToUrl(baseURL.TrimEnd(new char[] { '/' }) + HomePageOffline.URL);
            return GetPage<HomePageOffline>(driver, baseURL, "");
        }

        public static SignUpPage GetSignUpPage(IWebDriver driver)
        {
            if (driver == null)
                driver = Browser.Current;
            return GetPage<SignUpPage>(driver);
        }

        public static SignInPage GetSignInPage(IWebDriver driver)
        {
            if (driver == null)
                driver = Browser.Current;
            return GetPage<SignInPage>(driver);
        }

        public static HomePageOnline GetHomePageOnline(IWebDriver driver)
        {
            if (driver == null)
                driver = Browser.Current;
            return GetPage<HomePageOnline>(driver);
        }

        public static EditorPage GetEditorPage(IWebDriver driver)
        {
            if (driver == null)
                driver = Browser.Current;
            return GetPage<EditorPage>(driver);
        }

        public static ArticlePage GetArticlePage(IWebDriver driver)
        {
            if (driver == null)
                driver = Browser.Current;
            return GetPage<ArticlePage>(driver);
        }
    }
}
