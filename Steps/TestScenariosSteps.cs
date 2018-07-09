using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GABAK.Automation.UI.Acceptance.Base;
using GABAK.Automation.UI.Acceptance.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            NextPage = CurrentPage.As<SignUpPage>().ClickSignUpButton();
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
        }

        [When(@"the user signs in")]
        public void WhenTheUserSignsIn(Table table)
        {
            dynamic form = table.CreateDynamicInstance();

            NextPage = CurrentPage.As<HomePageOffline>().ClickSignInLink();
            CurrentPage.As<SignInPage>().EnterEmailAddress(form.email);
            CurrentPage.As<SignInPage>().EnterPassword(form.password);

            NextPage = CurrentPage.As<SignInPage>().ClickSignInButton();
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



        [When(@"user is not signed in")]
        public void WhenUserIsNotSignedIn()
        {
            ScenarioContext.Current.Pending();
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
            Assert.True(CurrentPage.As<HomePageOnline>().GetFeedsDisplayed());
        }

        [When(@"the user creates a new article")]
        public void WhenTheUserCreatesANewArticle(Table table)
        {
            dynamic form = table.CreateDynamicInstance();

            NextPage = CurrentPage.As<HomePageOnline>().ClickOnNewArticle();

            CurrentPage.As<EditorPage>().EnterArticleTitle(form.Title);
            CurrentPage.As<EditorPage>().EnterArticleTitle(form.About);
            CurrentPage.As<EditorPage>().EnterArticleTitle(form.Description);
            CurrentPage.As<EditorPage>().EnterArticleTitle(form.Tags);

            NextPage = CurrentPage.As<EditorPage>().PublishArticle();

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
