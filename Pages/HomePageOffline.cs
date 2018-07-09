using System.Collections.Generic;
using GABAK.Automation.UI.Acceptance.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GABAK.Automation.UI.Acceptance.Pages
{
    public class HomePageOffline : BasePage
    {
        public static string URL = "/";
        public override string DefaultTitle { get { return "Home — Conduit"; } }

        #region Webelements

        [FindsBy(How = How.LinkText, Using = "Sign in")]
        private IWebElement SignIn_link;

        [FindsBy(How = How.LinkText, Using = "Sign up")]
        private IWebElement SignUp_link;

        [FindsBy(How = How.LinkText, Using = "Global Feed")]
        private IWebElement GlobalFeed_link;

        [FindsBy(How = How.CssSelector, Using = ".sidebar")]
        private IWebElement PopularTags_section;

        [FindsBy(How = How.CssSelector, Using = ".btn.btn-sm")]
        private IList<IWebElement> All_Likes_icons;

        #endregion

        #region Actions

        public bool GetSignInDisplayed()
        {
            return SignIn_link.Displayed;
        }

        public SignUpPage ClickSignUpLink()
        {
            SignUp_link.Click();
            return GetPage<SignUpPage>();
        }

        public SignInPage ClickSignInLink()
        {
            SignIn_link.Click();
            return GetPage<SignInPage>();
        }

        public bool GetResultGlobalFeedDisplayed()
        {
            return GlobalFeed_link.Displayed;
        }

        public bool GetResultPopularTagsDisplayed()
        {
            return PopularTags_section.Displayed;
        }

        public SignUpPage ClickLikeOnArticle()
        {
            //Just click on the first icon you see.
            foreach (var likes in All_Likes_icons)
            {
                likes.Click();
                break;

            }

            return GetPage<SignUpPage>();
        }

        #endregion
    }
}
