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
    public class EditorPage : BasePage
    {
        public override string DefaultTitle { get { return "Editor — Conduit"; } }

        #region Webelements

        [FindsBy(How = How.CssSelector, Using = ".form-control[placeholder='Article Title']")]
        private IWebElement ArticleTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset .form-group:nth-child(2)")]
        private IWebElement About_Article { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset .form-group:nth-child(3)")]
        private IWebElement Article_Content { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset .form-group:nth-child(4)")]
        private IWebElement Tag_Field { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".btn-primary")]
        private IWebElement Publish_Article { get; set; }


        #endregion

        #region Actions

        public void EnterArticleTitle(string title)
        {
            ArticleTitle.SendKeys(title);
        }

        public void EnterAboutArticle(string aboutArticle)
        {
            About_Article.SendKeys(aboutArticle);
        }

        public void EnterArticleDescription(string desc)
        {
            Article_Content.SendKeys(desc);
        }

        public void EnterTags(string tags)
        {
            Tag_Field.SendKeys(tags);
        }

        public ArticlePage PublishArticle()
        {
            Publish_Article.Click();
            return GetPage<ArticlePage>();
        }

        #endregion
    }
}
