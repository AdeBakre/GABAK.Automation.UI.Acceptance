using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GABAK.Automation.UI.Acceptance.Base
{
    public abstract partial class BasePage : CommonBase
    {
        public string BaseURL { get; set; }
        public virtual string DefaultTitle { get { return ""; } }

        protected TPage GetPageWithTitle<TPage>() where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage();

            //if (string.IsNullOrWhiteSpace(expectedTitle)) expectedTitle = pageInstance.DefaultTitle;

            return pageInstance;
        }

        protected TPage GetPage<TPage>(IWebDriver driver = null, string expectedTitle = "") where TPage : BasePage, new()
        {
            return GetPage<TPage>(driver ?? Driver, BaseURL, expectedTitle);
        }



        protected static TPage GetPage<TPage>(IWebDriver driver) where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                Driver = driver
            };
            PageFactory.InitElements(driver, pageInstance);
            return pageInstance;
        }

        protected static TPage GetPage<TPage>(IWebDriver driver, string baseUrl, string expectedTitle = "") where TPage : BasePage, new()
        {
            TPage pageInstance = new TPage()
            {
                Driver = driver,
                BaseURL = baseUrl
            };
            PageFactory.InitElements(driver, pageInstance);

            if (string.IsNullOrWhiteSpace(expectedTitle)) expectedTitle = pageInstance.DefaultTitle;

            new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(5))
                                            .Until<OpenQA.Selenium.IWebElement>((d) =>
                                            {
                                                return d.FindElement(By.TagName("body"));
                                            });

            AssertIsEqual(expectedTitle, driver.Title, "Page Title");

            return pageInstance;
        }

        /// <summary>
        /// Asserts that the current page is of the given type
        /// </summary>
        public void Is<TPage>() where TPage : BasePage, new()
        {
            if (!(this is TPage))
            {
                throw new AssertionException(String.Format("Page Type Mismatch: Current page is not a '{0}'", typeof(TPage).Name));
            }
        }

        /// <summary>
        /// Inline cast to the given page type
        /// </summary>
        public TPage As<TPage>() where TPage : BasePage, new()
        {
            return (TPage)this;
        }
    }
}
