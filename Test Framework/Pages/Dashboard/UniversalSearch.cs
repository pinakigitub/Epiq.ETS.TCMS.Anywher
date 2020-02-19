using System;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard
{
    public class UniversalSearch : PageObject
    {
        //Different searchtool container locators
        private By dashboardUniversalSearchConatiner = By.XPath("//*[contains(@class,'universalSearchDashboardContainer')]");
        private By dashboardStickyUniversalSearchConatiner = By.XPath("//*[contains(@class,'universalSearchContainer')]");

        //Any search bar locators (generic: for the visible search tool)        
        private static string prefixOfVisibleSearchTool;
        private string searchToolBox = "{0}//*[@id='universalSearchContainer']";
        private string searchToolDropdownLabel = "{0}//*[contains(@class,'searchBoxItem')]";
        private string searchToolDropdownLabelInput = "{0}//*[@id='select2-universalSearchBoxInput-container']";
        private string searchToolMagnGlass = "{0}//*[contains(@class,'fa-search') and contains(@class,'searchIcon')]";
        private By resultsMessage = By.XPath("//*[contains(@class,'select2-results__message')]");        
        private By searchToolTextInput = By.XPath("//*[contains(@class,'select2-search__field')]");
        private By searchResultRow = By.XPath("//*[@id='select2-universalSearchBoxInput-results']//*[contains(@class,'select2-results__option')]");

        private By blockOverlay = By.CssSelector("div.blockUI.blockOverlay");
        private int blockOverlayWaitTimeout = 65;

        private By resultsNewMessage = By.XPath("//a[text()='No results available']");
        private string newSearchResultText = "//ul[@class='dropdown-menu rbt-menu dropdown-menu-justify']//a[@class='dropdown-item']//*[contains(text(),'{0}')]";
        private By newSearchResultRow = By.XPath("//ul[@class='dropdown-menu rbt-menu dropdown-menu-justify']//a[@class='dropdown-item']");
        private By bankingCenter = By.XPath("//span[text()='BANKING CENTER']");
        private By bankingActivity = By.XPath("//a[@href='/banking/activity']");
//private By UNIVERSAL_SEARCHBOX_LOCATOR = By.XPath("//div[@class='pull-right  hidden-md hidden-xs']");

    
        //New Locators
        private By newSearchNavigation = By.XPath("//nav/div/div[3]");
        private By allCasesArrow = By.XPath("//div/i");
        private By selectACasetext = By.XPath("//strong[text()='SELECT A CASE']");
        private By universalSearchToolInput = By.XPath("//div[@id='epiq-header-case-selector']/h3/div/div/input");
        private By searchMagnifyglass = By.XPath("//h3/div/div/i");
        private string searchResultByText = "//div[@class='popover-content']/ul/li[contains(text(),'{0}')]";
        public UniversalSearch(IWebDriver driver, string barPrefixLocator):base(driver, null)
        {
            prefixOfVisibleSearchTool = barPrefixLocator;
        }

        protected void ScrollDownToAvoidStickyHeadersOnClick()
        {
            //Move by offset of the sticky headers height....
            IWebElement topBar = this.WaitForElementToBeVisible(By.Id("top-bar"));
            //IWebElement greyStickyBar = this.WaitForElementToBeVisible(By.CssSelector("quick-links-region"));
            int Y = topBar.Size.Height;// + greyStickyBar.Size.Height;
            ScrollWindowBy(0, Y);
        }

        public bool VisibleOnDashboardContent
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(dashboardUniversalSearchConatiner, 10);
                    this.WaitForElementToBeVisible(By.XPath(String.Format(searchToolBox,prefixOfVisibleSearchTool)), 10);
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public bool VisibleOnStickyBar
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(dashboardStickyUniversalSearchConatiner, 10);
                    this.WaitForElementToBeVisible(By.XPath(String.Format(searchToolBox, prefixOfVisibleSearchTool)), 10);
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public string DropDownLabel {
            get {
                By locator = By.XPath(String.Format(searchToolDropdownLabel, prefixOfVisibleSearchTool));
                return this.WaitForElementToBeVisible(locator).Text;
            }
        }
        public string InputPlaceholder {
            get
            {
                By locator = By.XPath(String.Format(searchToolDropdownLabelInput, prefixOfVisibleSearchTool));
                return this.WaitForElementToBeVisible(locator).Text;
            }
        }
        public bool MagnifyingGlassIconVisible {
            get {
                try
                {
                    By locator = By.XPath(String.Format(searchToolMagnGlass, prefixOfVisibleSearchTool));
                    this.WaitForElementToBeVisible(locator);
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        public void EnterTextForSearch(string searchText)
        {
            Pause(1);
            By locator = By.XPath(String.Format(searchToolDropdownLabelInput, prefixOfVisibleSearchTool));
            IWebElement searchTool = this.WaitForElementToBeVisible(locator);
            this.MoveToViewElement(searchTool);
            this.ScrollDownToAvoidStickyHeadersOnClick();
            searchTool.Click();
            Pause(1);
            this.ClearAndType(this.WaitForElementToBeVisible(searchToolTextInput), searchText);
            this.Pause(2); //search time should be narrowed to 2 seconds
        }

        public void EnterTextinUniversalSearch(string SearchText)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(universalSearchToolInput), SearchText);
            this.Pause(5);
        }
        

        public string ResultsMessage {
            get {
                return this.WaitForElementToBeVisible(resultsMessage).Text;
            }
        }

        public string NewResultsMessage
        {
            get
            {
                return this.WaitForElementToBeVisible(resultsNewMessage).Text;
            }
        }

        public List<string> ResultsList {
            get {
                List<string> ret = new List<string>();

                //Wait for "Searching..." message to dissapear
                this.Pause(1);
                this.WaitForElementToDissapear(By.XPath(String.Format(searchResultByText, "Searching...")));

                //Get all results and put them into ret list
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(searchResultRow);
                foreach (IWebElement result in results)
                {
                    ret.Add(result.Text);
                }
                
                return ret;
            }
        }
        public List<string> NewResultsList
        {
            get
            {
                List<string> ret = new List<string>();

                //Wait for "Searching..." message to dissapear
                this.Pause(1);
                this.WaitForElementToDissapear(By.XPath(String.Format(newSearchResultText, "Searching...")));

                //Get all results and put them into ret list
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(newSearchResultRow);
                foreach (IWebElement result in results)
                {
                    ret.Add(result.Text);
                }

                return ret;
            }
        }

        public CaseDetailPage ClickOnCaseResultByCaseNumber(string caseNbr)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(searchResultByText,caseNbr))).Click();
            TestsLogger.Log("Waiting for block overlay to dissappear after selecting case on Search");
            this.Pause(2);
            this.WaitForElementToDissapear(blockOverlay, blockOverlayWaitTimeout+10);
            TestsLogger.Log("Block overlay dissappeared after selecting case on Search. Next wait will be on CaseDetailPage constructor.");
            return new CaseDetailPage(driver);
        }

        public SuperAdminPage ClickOnCaseResultByCaseNumberOnSupreadmin(string caseNbr)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(searchResultByText, caseNbr))).Click();
            TestsLogger.Log("Waiting for block overlay to dissappear after selecting case on Search");
            this.Pause(2);
            this.WaitForElementToDissapear(blockOverlay, blockOverlayWaitTimeout + 10);
            TestsLogger.Log("Block overlay dissappeared after selecting case on Search. Next wait will be on CaseDetailPage constructor.");
            return new SuperAdminPage(driver);
        }
        public void SelectBankingActivity()
        {
            this.WaitForElementToBeVisible(bankingCenter).Click();
            this.WaitForElementToBeVisible(bankingActivity).Click();
        }
        public void NavigateToReactReports()
        {
            driver.Url = "http://unity-tnetqa.epiqsystems.com/reports-temp";
        }
        public void MagnifySearchGlass()
        {
            this.WaitForElementToBeVisible(searchMagnifyglass);
        }
        public void SelectAllCasesArrow()
        {
            this.WaitForElementToBeVisible(newSearchNavigation);
            this.WaitForElementToBeVisible(allCasesArrow).Click();
        }
        public string SelectACaseText
        {
            get
            {
                return this.WaitForElementToBeVisible(selectACasetext).Text.Trim();
            }
        }

    }
}