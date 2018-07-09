using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GABAK.Automation.UI.Acceptance.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GABAK.Automation.UI.Acceptance.Pages
{
    public class ArticlePage : BasePage
    {
        #region Webelements

        [FindsBy(How = How.CssSelector, Using = "h1']")]
        private IWebElement Article_Title { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".row.article-content")]
        private IWebElement ArticleContentField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".card.comment-form")]
        private IWebElement CommentSection { get; set; }

        #endregion

        #region Article

        public bool GetArticleTitleDisplayed()
        {
            return Article_Title.Displayed;
        }

        public bool GetArticleContentDisplayed()
        {
            return ArticleContentField.Displayed;
        }

        public bool GetCommentDisplayed()
        {
            return CommentSection.Displayed;
        }

        #endregion

    }
}
