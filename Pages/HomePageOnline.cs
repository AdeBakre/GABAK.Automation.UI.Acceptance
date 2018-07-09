using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using GABAK.Automation.UI.Acceptance.Base;

namespace GABAK.Automation.UI.Acceptance.Pages
{
    public class HomePageOnline : BasePage
    {
        public override string DefaultTitle { get { return "Home — Conduit"; } }

        #region Webelements

        [FindsBy(How = How.CssSelector, Using = ".nav.nav-pills")]
        private IWebElement YourFeedsLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".nav.nav-pills>li:nth-child(2)>a")]
        private IWebElement Global_Feeds_link { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ion-compose")]
        private IWebElement New_Article { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".navbar-nav-link[ui-sref='app.settings']")]
        private IWebElement App_Settings { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".container>ul:nth-child(3)>li:nth-child(4)>a")]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.CssSelector, Using = "")]
        private IList<IWebElement> Articles;

        #endregion

        #region Actions

        public bool GetUserNameDisplayed()
        {

            return Username.Displayed;
            
        }

        public void ClickOnGlobalFeed()
        {
            Global_Feeds_link.Click();
        }

        public bool GetYourFeedLinkDisplayed()
        {
            return YourFeedsLink.Displayed;
        }

        public bool GetFeedsDisplayed()
        {
            bool result = false;
            int article_count = Articles.Count;
            if (article_count < 1)
            {
                result = true;
            }

            return result;
        }

        public EditorPage ClickOnNewArticle()
        {
            New_Article.Click();
            return GetPage<EditorPage>();
        }

        #endregion
    }
}
