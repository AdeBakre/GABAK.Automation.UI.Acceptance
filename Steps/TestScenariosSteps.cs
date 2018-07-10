using GABAK.Automation.UI.Acceptance.Base;
using GABAK.Automation.UI.Acceptance.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GABAK.Automation.UI.Acceptance;

namespace GABAK.Automation.UI.Acceptance.Steps
{
    [Binding]
    public class TestScenariosSteps : BaseSteps
    {
        

        [Given(@"a user is on the offline homepage")]
        public void GivenAUserIsOnTheHomepage()
        {
            CurrentPage = BasePage.GetHomePageOffline(CurrentDriver, BasePage.BaseUrl);

        }

        [Given(@"a user is on the logged in homepage")]
        public void GivenAUserIsOnTheLoggedInHomepage()
        {
            CurrentPage = BasePage.GetHomePageOffline(CurrentDriver, BasePage.BaseUrl);
  
            NextPage = CurrentPage.As<HomePageOffline>().ClickSignInLink();
            CurrentPage.As<SignInPage>().EnterEmailAddress("giggus01@email.com");
            CurrentPage.As<SignInPage>().EnterPassword("password");

            NextPage = CurrentPage.As<SignInPage>().ClickSignInButton();

        }


        [When(@"the user signs up")]
        public void WhenTheUserSignsUp(Table table)
        {
            dynamic form = table.CreateDynamicInstance();

            NextPage = CurrentPage.As<HomePageOffline>().ClickSignUpLink();

            CurrentPage.As<SignUpPage>().EnterUserName(form.username);
            CurrentPage.As<SignUpPage>().EnterEmailAddress(form.email);
            CurrentPage.As<SignUpPage>().EnterPassword(form.password);
            CurrentPage.As<SignUpPage>().ClickSignUpButton();

            CurrentPage = BasePage.GetHomePageOnline(CurrentDriver);
        }

        [When(@"the user clicks on the sign up link")]
        public void WhenTheUserClicksOnTheSignUpLink()
        {
            NextPage = CurrentPage.As<HomePageOffline>().ClickSignUpLink();
        }


        [Then(@"the user is automatically logged in")]
        public void ThenTheUserIsAutomaticallyLoggedIn()
        {
            CurrentPage = BasePage.GetHomePageOnline(CurrentDriver);
        }

        [Then(@"the user's name is displayed")]
        public void ThenTheUserSNameIsDisplayed()
        {
            
            Assert.True(CurrentPage.As<HomePageOnline>().GetUserNameDisplayed());
            //Reporter.Pass();
        }

        [When(@"the user signs in")]
        public void WhenTheUserSignsIn(Table table)
        {
            dynamic form = table.CreateDynamicInstance();

            NextPage = CurrentPage.As<HomePageOffline>().ClickSignInLink();
            CurrentPage.As<SignInPage>().EnterEmailAddress(form.email);
            CurrentPage.As<SignInPage>().EnterPassword(form.password);

           CurrentPage.As<SignInPage>().ClickSignInButton();

            CurrentPage = BasePage.GetHomePageOnline(CurrentDriver);
        }


        [Then(@"the user is logged in")]
        public void ThenTheUserIsLoggedIn()
        {
            CurrentPage = BasePage.GetHomePageOnline(CurrentDriver);
        }

        [When(@"the user enters ""(.*)"" as username on sign up page")]
        public void WhenTheUserEntersAsUsernameOnSignUpPage(string username)
        {
            CurrentPage.As<SignUpPage>().EnterUserName(username);
        }

        [When(@"the user enters ""(.*)"" as email on sign up page")]
        public void WhenTheUserEntersAsEmailOnSignUpPage(string email)
        {
            CurrentPage.As<SignUpPage>().EnterEmailAddress(email);
        }

        [When(@"the user enters ""(.*)"" as password on sign up page")]
        public void WhenTheUserEntersAsPasswordOnSignUpPage(string password)
        {
            CurrentPage.As<SignUpPage>().EnterPassword(password);
        }

        [When(@"the user clicks on the sign up button")]
        public void WhenTheUserClicksOnTheSignUpButton()
        {
            CurrentPage.As<SignUpPage>().ClickSignUpWithInvalid();
        }

        [Then(@"the global feeds and popular tags are displayed")]
        public void ThenTheGlobalFeedsAndPopularTagsAreDisplayed()
        {
           Assert.True(CurrentPage.As<HomePageOffline>().GetResultGlobalFeedDisplayed());
            Assert.True(CurrentPage.As<HomePageOffline>().GetResultGlobalFeedDisplayed());
            
        }

        [When(@"a user tries to like an article")]
        public void WhenAUserTriesToLikeAnArticle()
        {
            NextPage = CurrentPage.As<HomePageOffline>().ClickLikeOnArticle();
        }

        [Then(@"the user is directed to the sign up area")]
        public void ThenTheUserIsDirectedToTheSignUpArea()
        {
            CurrentPage = BasePage.GetSignUpPage(CurrentDriver);
        }



        [Then(@"a validation error is displayed")]
        public void ThenAValidationErrorIsDisplayed()
        {
            Assert.True(CurrentPage.As<SignUpPage>().ErrorMessageForInvalidDisplayed());
        }

        [Then(@"the Your Feeds section should be displayed by default")]
        public void ThenTheYourFeedsSectionShouldBeDisplayedByDefault()
        {
            Assert.True(CurrentPage.As<HomePageOnline>().GetYourFeedLinkDisplayed());
        }

        [Then(@"the Your Feeds section should be empty")]
        public void ThenTheYourFeedsSectionShouldBeEmpty()
        {
            Assert.True(CurrentPage.As<HomePageOnline>().GetNoFeedsDisplayed());
        }

        [When(@"the user creates a new article")]
        public void WhenTheUserCreatesANewArticle(Table table)
        {
            dynamic form = table.CreateDynamicInstance();

           
            CurrentPage.As<HomePageOnline>().ClickOnNewArticle();

            CurrentPage = BasePage.GetEditorPage(CurrentDriver);

            CurrentPage.As<EditorPage>().EnterArticleTitle(form.Title);
            CurrentPage.As<EditorPage>().EnterAboutArticle(form.About);
            CurrentPage.As<EditorPage>().EnterArticleDescription(form.Description);
            CurrentPage.As<EditorPage>().EnterTags(form.Tags);

           CurrentPage.As<EditorPage>().PublishArticle();

            CurrentPage = BasePage.GetArticlePage(CurrentDriver);

        }


        [Then(@"the article section is displayed with the article information")]
        public void ThenTheArticleSectionIsDisplayedWithTheArticleInformation()
        {
            Assert.True(CurrentPage.As<ArticlePage>().GetArticleTitleDisplayed());
            Assert.True(CurrentPage.As<ArticlePage>().GetArticleContentDisplayed());
        }

        [Then(@"the comment section is displayed")]
        public void ThenTheCommentSectionIsDisplayed()
        {
            Assert.True(CurrentPage.As<ArticlePage>().GetCommentDisplayed());
        }


    }
}
