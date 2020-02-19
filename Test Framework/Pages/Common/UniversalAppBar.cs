using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest
{
    /**
     * This class represents the page portion of the Universal App Bar 
     * and contains all the actions that can be made through it.
     */
    public class UniversalAppBar : PageObject
    {
        //UI locators
        //private By SEARCH_INPUT_LOCATOR = By.Id("nav-input-search");
        private By searchIcon = By.CssSelector("i.fa.fa-search");
        private By searchBox = By.Id("caseSearchBox");
        private By searchInput = By.CssSelector("input.select2-search__field");
        private By favoritesIcon = By.CssSelector("i.fa.fa-star");
        private By flagIcon = By.CssSelector("i.fa.fa-flag");
        private By userIcon = By.XPath(".//*[@id='basic-nav-dropdown']/i");
        private By contactEpiq = By.XPath("//div[2]/div/img");
        private By logoutLink = By.XPath("//a[text()='Logout']");
        private By searchResults = By.CssSelector("li.select2-results__option");
        private By searchResultMessage = By.CssSelector("li.select2-results__message");
        private By officeNameMenus = By.Id("officeNameMenu");

        private By dashboardIcon = By.XPath("//a[@class='navbar-brand']//img");
        private By userIcons = By.XPath("//*[@id='basic-nav-dropdown']/i");

        public UniversalAppBar(IWebDriver driver) : base(driver, null) { }

        public bool IsFlagIconVisible()
        {
            try
            {
                WaitForElementToBeVisible(flagIcon);
                return true;
            }
            catch (MissingElementException) { return false; }
        }

        public bool IsFavoritesIconVisible()
        {
            try
            {
                WaitForElementToBeVisible(favoritesIcon);
                return true;
            }
            catch (MissingElementException) { return false; }
        }

        public bool IsSearchCasesToolVisible()
        {
            try
            {
                WaitForElementToBeVisible(searchIcon);
                return true;
            }
            catch (MissingElementException) { return false; }

        }

        public string GetNoResultsMessage()
        {
            return WaitForElementToBeVisible(searchResultMessage).Text;
        }

        public bool IsUserProfileLinkVisibleAndComplete()
        {
            try
            {
                Thread.Sleep(3000);
                WaitForElementToBeVisible(userIcon).Click();
                Thread.Sleep(3000);
                WaitForElementToBeVisible(logoutLink);
                Thread.Sleep(3000);
                WaitForElementToBeVisible(userIcon).Click();
                Thread.Sleep(3000);
                return true;
            }
            catch (MissingElementException) { return false; }

        }

        public bool Logout()
        {
           //Thread.Sleep(18000);
            //driver.Navigate().GoToUrl("http://unity-tnetqa.epiqsystems.com/reports");
            //Thread.Sleep(10000);
            this.WaitForElementToBeVisible(dashboardIcon,20).Click();
           // Thread.Sleep(5000);
            WaitForElementToBeClickeable(userIcon,20).Click();
            //Thread.Sleep(3000);
            WaitForElementToBeClickeable(logoutLink,20).Click();
            return true;
        }
        public bool SignOutFromUnity()
        {
            Thread.Sleep(5000);
            WaitForElementToBeClickeable(userIcons).Click();
            WaitForElementToBeClickeable(logoutLink).Click();
            return true;
        }


        /**
         * Cases Search Box
         */

        public void ClickMagnifyingGlass()
        {
            this.WaitForElementToBeClickeable(searchIcon).Click();
        }

        public bool IsSearchnIputBoxVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(searchBox);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void TypeSearchText(string searchText)
        {
            this.WaitForElementToBeVisible(searchBox).Click();
            ClearAndType(this.WaitForElementToBeVisible(searchInput), searchText);
        }

        public List<string> Search(string searchText)
        {
            this.ClickMagnifyingGlass();
            this.TypeSearchText(searchText);

            this.WaitForElementToHaveAttributeValue(searchInput, "value", searchText);           

            this.WaitUntilResultListStabilizes();
            return this.GetSearchResults();
        }

        private void WaitUntilResultListStabilizes()
        {
            //TODO see what to do with this
            //this.Pause(3000);
            // IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(SEARCH_RESULT_LOCATOR);

        }

        public List<string> GetSearchResults()
        {
            //wait for search results to appear in 2 seconds top
            IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(searchResults, 2);

            List<string> ret = new List<string>();
            foreach (IWebElement result in results)
            {
                ret.Add(result.Text);
            }

            return ret;
        }

        public string SelectSearchResultByCaseNumber(string caseNumber)
        {
            IWebElement result = this.WaitForElementToHaveText(searchResults, caseNumber);
            string resultText = result.Text;
            result.Click();
            return resultText;
        }

        public void OpenUserMenu()
        {

            //Do hover over User icon
            Actions actions = new Actions(driver);
            IWebElement userIcon = this.WaitForElementToBeVisible(contactEpiq);
            Thread.Sleep(3000);
            actions.MoveToElement(userIcon);

            //perform all actions
            actions.Click().Perform();
            Thread.Sleep(3000);

        }

        public string OfficeName
        {
            get
            {
                return this.WaitForElementToBeVisible(officeNameMenus).Text;
            }
        }
    }
}