using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common
{
    /**
     * This Page Object represents the common "frame" page for all pages on the Unity site when a user is logged in.
     * It includes access and actions over:
     *      - Navigation Bar 
     *      - Universal App Bar 
     *      - Version & Copyright information on the footer
     */
    public class UnityPageBase : PageObject
    {
        //UI elements locators
        //Navigation Bar
        private By navigationBars = By.XPath("//nav/div");         

        //Universal App Bar
        //private By universalAppBar = By.XPath("//nav[@id='top-bar']/ul/li/a/img");
        
        //Copyright and Version
        private By versionCopyRightInfo = By.Id("loginCopyright");

        //Unity logo locator
       // private By UNITY_LOGO_LOCATOR = By.XPath("//a[@class='navbar-brand']//img");
        private By unityLogo = By.XPath("//nav/div");     

        //General Regions locators
        private By regionrelevantInfo = By.Id("carousel-area");
        private By alertAreas = By.Id("alerts-area");
        private By contentOutputArea = By.Id("bottom-widgets-area");

        //Content Output locators
        private By casesListQuickLookTitles = By.Id("casesListQuickLookTitle");

        //Login button locator to check the login page is diplsayed or not
        private By loginButton = By.Id("login");

        //unauthorized access message locator
        private By unauthorizedMessage = By.XPath("//router-view//*[contains(@class,'tabContainer')]");

        //Block UI Overlay locator - wait please message and IU blocker
        protected By blockOverlays = By.CssSelector("div.blockUI.blockOverlay");
        protected int blockOverlayWaitTimeout = 65;
        protected int maxTimesOverlays = 30;


        //Common Areas - Header
        protected UniversalAppBar appBar;
        protected NavigationBar navigationBar;

        public UnityPageBase(IWebDriver driver, string pageTitle): base(driver, pageTitle){
            try
            {
                //this.WaitForBlockOverlayToDissapear();
            }
            catch (Exception)
            {
                //Reload already checks for overlay to dissappear after refreshing the page
                //this.Reload();
            }
        }
                        
        protected void WaitForBlockOverlayToDissapear()
        {
            //Message 'Please wait' is appearing multiple times, 
            //expecting it as many times as the max we could define per the current pages Ajax calls
            this.Pause(2);
            TestsLogger.Log("WaitForBlockOverlayToDissapear with locator " +  blockOverlays + " for "+ blockOverlayWaitTimeout + " secs ("+maxTimesOverlays+" times)");
            for (int i = 0; i < maxTimesOverlays; i++)
            {
                this.WaitForElementToDissapear(blockOverlays, blockOverlayWaitTimeout);
              
            }
        }

        public void ForceToLoadURL(string url)
        {
            TestsLogger.Log("Forcing URL load to " + url);
            driver.Navigate().GoToUrl(url);
            this.WaitForBlockOverlayToDissapear();
        }

        public new void Reload()
        {
            driver.Navigate().Refresh();
            this.WaitForBlockOverlayToDissapear();
        }

        public UniversalAppBar UniversalApplicationBar
        {
            get
            {
                if (appBar == null){                 
                   //this.WaitForElementToBeVisible(UNIVERSAL_APP_BAR_LOCATOR);
                   //this.WaitForElementToBeVisible(NAVIGATION_BAR_LOCATOR);
                   this.WaitForElementToBeVisible(unityLogo);
                   appBar = new UniversalAppBar(driver);

                }

                return appBar;
            }
        }

        public NavigationBar NavigationBar
        {
            get
            {
                if (this.navigationBar == null)
                {
                    this.WaitForBlockOverlayToDissapear();
                    Thread.Sleep(3500);
                    this.WaitForElementToBeVisible(navigationBars);
                    navigationBar = new NavigationBar(driver);
                }

                return navigationBar;
            }
        }

        public bool IsLoginPageDisplayed()
        {
            try
            {
                this.WaitForElementsToBeVisible(loginButton);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public string VersionAndCopyrightInfo
        {
            get
            {
                return this.WaitForElementToBeVisible(versionCopyRightInfo).Text;
            }
        }

        public LoginPage Logout()
        {
            this.UniversalApplicationBar.SignOutFromUnity();
            //driver.Manage().Cookies.DeleteAllCookies();            
            this.Pause(2);
            this.WaitForBlockOverlayToDissapear();
            return new LoginPage(driver);

        }

        public LoginPage SignOutFromUnity()
        {
            this.UniversalApplicationBar.SignOutFromUnity();
            this.Pause(2);
            this.WaitForBlockOverlayToDissapear();
            return new LoginPage(driver);
        }

        private void GoToLoginPage()
        {
            this.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("PortalURL"));
        }
        
        public bool IsRelevantInfoRegionVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(regionrelevantInfo);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
             
        }

        public bool IsAlertsRegionVisible()
        {
            try {
                this.WaitForElementToBeVisible(alertAreas);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }

        public bool IsContentOutputRegionVisible()
        {
            try {
                this.WaitForElementToBeVisible(contentOutputArea);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }

        public string GetQuickLookTitle()
        {
            return this.WaitForElementToBeVisible(casesListQuickLookTitles).Text;
        }

        public bool IsQuickLookTitleVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(casesListQuickLookTitles);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }

        protected string GetColorFromColorCode(string colorCode)
        {
            switch (colorCode)
            {
                case "rgb(0, 0, 0)":
                    return "";

                case "rgba(0, 0, 0, 1)":
                    return "BLACK";

                case "black":
                    return "";

                case "rgba(128, 128, 128, 1)":
                    return "GREY";

                case "rgba(52, 160, 30, 1)":
                    return "GREEN";

                case "rgb(52, 160, 30)":
                    return "GREEN";

                case "#34a01e":
                    return "GREEN";

                case "rgba(251, 176, 64, 1)":
                    return "ORANGE";

                case "rgb(251, 176, 64)":
                    return "ORANGE";

                case "rgba(232, 119, 34, 1)":
                    return "ORANGE";

                case "#fbb040":
                    return "ORANGE";

                case "rgba(208, 2, 27, 1)":
                    return "RED";

                case "rgb(208, 2, 27)":
                    return "RED";

                case "#d0021b":
                    return "RED";

                case "rgba(230, 230, 1, 1)":
                    return "YELLOW";

                case "rgb(230, 230, 1)":
                    return "YELLOW";

                case "#e6e601":
                    return "YELLOW";

                case "rgb(112, 0, 191)":
                    return "PURPLE";

                case "#7000bf":
                    return "PURPLE";

                default:
                    return colorCode;
            }
        }

        protected void ScrollDownByMenuBarHeightOffset()
        {
            int headerOffset = this.WaitForElementToBeVisible(By.Id("top-bar")).Size.Height;
            this.ScrollWindowBy(0, -headerOffset);
        }

        protected void ScrollDownBySearchBarHeightOffset()
        {
            int headerOffset = this.WaitForElementToBeVisible(By.Id("quick-link-universal-search")).Size.Height;
            this.ScrollWindowBy(0, -headerOffset);
        }

        public string UnauthorizedErrorMessage
        {
            get
            {
               return this.WaitForElementToBeVisible(unauthorizedMessage).Text;
            }
        }
    }
}