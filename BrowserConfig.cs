using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace GABAK.Automation.UI.Acceptance
{
    public class BrowserConfig
    {
        public static IWebDriver Current { get; set; }

        public static IWebDriver SetDriverInstance(string browserType)
        {

            switch (browserType)
            {
                case "Chrome":
                    SetDriverToChrome();
                    break;
                case "Firefox":
                    SetDriverToFireFox();
                    break;
                case "IE":
                    SetDriverToIE();
                    break;
            }
           // Current.Manage().Window.Maximize();
            return Current;
        }

        #region Browsers Config
        private static IWebDriver SetDriverToChrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("-incognito");
            options.AddArgument("--no-sandbox");
            Current = new ChromeDriver(options);
            return Current;

        }

        private static IWebDriver SetDriverToFireFox()
        {
            Current = new FirefoxDriver();
            return Current;
        }

        private static IWebDriver SetDriverToIE()
        {
            Current = new InternetExplorerDriver();
            return Current;
        }

        private static void SetDriverToEdge()
        {
            //Leave this empty for now
        }

        #endregion

        #region Browser cleanup

        public static void ClearBrowser()
        {
            Current.Dispose();
        }

        #endregion
    }
}
