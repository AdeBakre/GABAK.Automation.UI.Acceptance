using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace GABAK.Automation.UI.Acceptance.Base
{
    public abstract class CommonBase
    {
        public IWebDriver Driver { get; set; }
        Random randomGenerator = new Random();

        public void ClearAndType(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public void ClickOnElement(IWebElement element)
        {
            WaitTillElementDisplayed(element);
            element.Click();
            
        }

        public string RandomEmailGenerator(string startName)
        {          
            int randomInt = randomGenerator.Next(100000);
            return startName + randomInt + "@email.com";
        }

        public string RandomNumberGenerator(string startName)
        {
            int randomInt = randomGenerator.Next(10000);
            return startName + randomInt;
        }

        public void WaitTillElementDisplayed(IWebElement Element)
        {
            TimeSpan timeout = new TimeSpan(0,0,15);
            WebDriverWait wait = new WebDriverWait(Driver, timeout);

            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                if (Element.Displayed)
                {
                    return true;
                }

                return false;
            });

            wait.Until(waitForElement);
        }

        public void WaitForPageToChange(string pageTitle,IWebDriver driver = null)
        {
            TimeSpan timeout = new TimeSpan(0, 0, 15);
            WebDriverWait wait = new WebDriverWait(Driver, timeout);

            if (driver == null)
            {
                driver = Driver;
            }

            //I know this can be improved on with a lambda expression but..
            Func<IWebDriver, bool> waitForPageTitle = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                if (pageTitle.Equals(Driver.Title))
                {

                    return false;
                }

                return true;
            });
          
            wait.Until(waitForPageTitle);
        }

        public static void AssertIsEqual(string expectedValue, string actualValue, string elementDescription)
        {
            if (expectedValue != actualValue)
            {
                throw new AssertionException(String.Format("AssertIsEqual Failed: '{0}' didn't match expectations. Expected [{1}], Actual [{2}]", elementDescription, expectedValue, actualValue));
            }
        }

        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool b = element.Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void AssertElementPresent(IWebElement element, string elementDescription)
        {
            if (!IsElementPresent(element))
                throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static bool IsElementPresent(ISearchContext context, By searchBy)
        {
            try
            {
                bool b = context.FindElement(searchBy).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void AssertElementPresent(ISearchContext context, By searchBy, string elementDescription)
        {
            if (!IsElementPresent(context, searchBy))
                throw new AssertionException(String.Format("AssertElementPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static void AssertElementsPresent(IWebElement[] elements, string elementDescription)
        {
            if (elements.Length == 0)
                throw new AssertionException(String.Format("AssertElementsPresent Failed: Could not find '{0}'", elementDescription));
        }

        public static void AssertElementText(IWebElement element, string expectedValue, string elementDescription)
        {
            AssertElementPresent(element, elementDescription);
            string actualtext = element.Text;
            if (actualtext != expectedValue)
            {
                throw new AssertionException(String.Format("AssertElementText Failed: Value for '{0}' did not match expectations. Expected: [{1}], Actual: [{2}]", elementDescription, expectedValue, actualtext));
            }
        }   
    }
}
