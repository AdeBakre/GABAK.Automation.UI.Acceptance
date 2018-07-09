using GABAK.Automation.UI.Acceptance.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GABAK.Automation.UI.Acceptance.Pages
{
    public class SignInPage : BasePage
    {
        public override string DefaultTitle { get { return "Sign in — Conduit"; } }

        #region Webelements

        [FindsBy(How = How.CssSelector, Using = ".form-control[type='email']")]
        private IWebElement Email_Text_Box { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".form-control[type='password']")]
        private IWebElement Password_Text_Box { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn[type='submit']")]
        private IWebElement Sign_In_Button { get; set; }

        #endregion

        #region Actions

        public void EnterEmailAddress(string email)
        {
            Email_Text_Box.Clear();
            Email_Text_Box.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            Password_Text_Box.Clear();
            Password_Text_Box.SendKeys(password);
        }

        public HomePageOnline ClickSignInButton()
        {
            Sign_In_Button.Click();
            return GetPageWithTitle<HomePageOnline>();
            //return GetPage<HomePageOnline>();
        }

        #endregion
    }
}
