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

        [FindsBy(How = How.CssSelector, Using = "fieldset .form-group:nth-child(2)>input")]
        private IWebElement About_Article { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset .form-group:nth-child(3)>textarea")]
        private IWebElement Article_Content { get; set; }

        [FindsBy(How = How.CssSelector, Using = "fieldset .form-group:nth-child(4)>input")]
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
            ClickOnElement(Publish_Article);
            WaitForPageToChange(DefaultTitle);
            return GetPage<ArticlePage>();
        }

        #endregion
    }
}
