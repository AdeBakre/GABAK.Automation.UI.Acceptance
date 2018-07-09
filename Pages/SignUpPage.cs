using GABAK.Automation.UI.Acceptance.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GABAK.Automation.UI.Acceptance.Pages
{
    public class SignUpPage : BasePage
    {
        public override string DefaultTitle { get { return "Sign up — Conduit"; } }
        
        #region Webelements

        [FindsBy(How = How.CssSelector, Using = ".form-control[placeholder='Username']")]
        private IWebElement UserName_Text_Box { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".form-control[type='email']")]
        private IWebElement Email_Text_Box { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".form-control[type='password']")]
        private IWebElement Password_Text_Box { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn[type='submit']")]
        private IWebElement Sign_In_Button { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".error-messages")]
        private IWebElement Invalid_Details_Error_Message { get; set; }
        #endregion

        #region Actions

        public void EnterUserName(string userName)
        {
            if (userName.Contains("random"))
            {
                userName = RandomNumberGenerator((userName));
            }
                UserName_Text_Box.SendKeys(userName);
        }

        public void EnterEmailAddress(string email)
        {
            //Branch out if email text contains the word random
            if (email.Contains("random"))
            {          
                email = RandomNumberGenerator(email);
            }
           
                Email_Text_Box.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            Password_Text_Box.SendKeys(password);
        }

        public HomePageOnline ClickSignUpButton()
        {
            Sign_In_Button.Click();
            return GetPageWithTitle<HomePageOnline>();

        }

        public void ClickSignUpWithInvalid()
        {
            Sign_In_Button.Click();
        }

        public bool ErrorMessageForInvalidDisplayed()
        {
            return Invalid_Details_Error_Message.Displayed;
        }

        #endregion
    }
}
