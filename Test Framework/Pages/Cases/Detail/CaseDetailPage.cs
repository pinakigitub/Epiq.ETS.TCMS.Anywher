using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Meeting341;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class CaseDetailPage : UnityPageBase
    {
        //main case information locators
        private By caseNumberLocator = By.Id("caseNumber");
        private By caseNameLocator = By.Id("debtorName");
        private By jointDebtorNameLocator = By.Id("jointDebtor");
        private By caseTypeLocator = By.Id("caseDetail");
        private By caseStatusLocator = By.Id("caseStatus");
        private By goTo341MeetingsCalendarLinkLocator = By.XPath("//*[contains(@class,'caseDetailStatusContainer')]//*[contains(@class,'navigationLink')]");

        //other case information locators
        private By caseOpenDateLabelLocator = By.Id("openDateLabel");
        private By caseOpenDateLocator = By.Id("caseOpenDate");
        private By caseEstDistDateLabelLocator = By.Id("distDateLabel");
        private By caseEstDistDateLocator = By.Id("caseDistributionDate");
        private By caseTaxIdLabelLocator = By.Id("taxIdLabel");
        private By caseTaxIdLocator = By.Id("caseTaxId");

        //Icons locators
        private string claimsIconId = "claimsIcon";
        private string distributionsIconId = "distributionIcon";
        private string balanceIconId = "balanceIcon";

        //Assets Tab
        protected By assetsNavMenuItemLocator = By.Id("navItem-Assets");
        private By assetsTabTitleLocator = By.Id("detailTabTitle-Claims Detail");


        //Claims Tab
        private By claimsNavMenuItemLocator = By.Id("navItem-Claims");
        private By claimstabTitleLocator = By.Id("detailTabTitle-Asset Detail");
        
        //Banking Detail Tab
        private By bankingNavMenuItemLocator = By.Id("navItem-Banking");        
        private By bankingTabTitleLocator = By.Id("detailTabTitle-Banking Detail");

        //Distribution Tab
        private By distributionMenuItemLocator = By.Id("navItem-Distributions");
        private By distributionTabTitleLocator = By.Id("detailTabTitle-Distribution");       

        //Sticky header
        private By stickyCaseHeaderLocator  =By.Id("stickyCaseHeader");

        //Key Dates
        private string keyDateDropDownByTextLocatorTemplate = "//*[contains(@class,'keyDates')]//*[contains(text(),'{0}')]";
        private By addKeyDateButtonLocator = By.Id("addKeyDatesButton");
        private By addKeyDateModalTitleLocator = By.XPath("//*[contains(@class,'keyDateModalTitle')]");
        private string optionKeyDateByTextLocatorTemplate = "//*[contains(@id,'keyDateListCheck-results')]//*[contains(text(),'{0}')]";
        private string checkboxKeyDateByTextLocatorTemplate = "//*[contains(@id,'keyDateListCheck-results')]//*[contains(text(),'{0}')]/../input";
        private By addKeyDateModalAddButtonLocator = By.Id("addKeyDateButton");

        //Constructor
        public CaseDetailPage(IWebDriver driver) : base(driver, "UNITY") { }

        public CaseDetailPage(IWebDriver driver, string subPageTitle) : base(driver, subPageTitle+"") { }
        
        //CASE DETAIL GENERAL DATA
        public string Name {
            get
            {
                return this.WaitForElementToBeVisible(caseNameLocator).Text.Trim();
            }
        }
        public string Number {
            get
            {
                return this.WaitForElementToBeVisible(caseNumberLocator).Text.Trim();
            }
        }

        public string Type
        {
            get
            {
                return this.WaitForElementToBeVisible(caseTypeLocator).Text.Trim();
            }
        }

        public string Status
        {
            get
            {
                return this.WaitForElementToBeVisible(caseStatusLocator).Text.Trim();
            }
        }

        public bool GoTo341MeetingCalendarLinkIsVisible {
            get
            {
                try
                {
                    //Try for a longer time, sometimes takes more time to load
                    this.WaitForElementToBeVisible(goTo341MeetingsCalendarLinkLocator, 50);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string GoTo341MeetingCalendarLinkText
        {
            get
            {
                return this.WaitForElementToBeVisible(goTo341MeetingsCalendarLinkLocator).Text;
            }
        }

         public string OpenDateLabel {
            get
            {
                return this.WaitForElementToBeVisible(caseOpenDateLabelLocator).Text.Trim();
            }
        }


        public string OpenDate
        {
            get
            {
                return this.WaitForElementToBeVisible(caseOpenDateLocator).Text.Trim();
            }
        }

        public string EstimatedDistributionDateLabel
        {
            get
            {
                IWebElement distDate = this.WaitForElementToBeVisible(caseEstDistDateLabelLocator);
                return distDate.Text;
            }
        }

        public string EstimatedDistributionDate
        {
            get
            {
                return this.WaitForElementToBePresent(caseEstDistDateLocator).Text.Trim();
            }
        }

        public string TaxIdLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(caseTaxIdLabelLocator).Text.Trim();
            }
        }


        public string TaxId
        {
            get
            {
                return this.WaitForElementToBePresent(caseTaxIdLocator).Text.Trim();
            }
        }

        public string CaseStatusColor {
            get
            {
                return this.WaitForElementToBeVisible(caseStatusLocator).GetCssValue("color");
            }
        }
        
        public CircleIcon ClaimsIcon
        {
            get
            {
                return new CircleIcon(driver, claimsIconId);
            }
            
        }
        
        public CircleIcon DistributionsIcon
        {
            get
            {
                return new CircleIcon(driver, distributionsIconId);
            }
        }

        public CircleIcon BankBalanceIcon
        {
            get
            {
                return new CircleIcon(driver, balanceIconId);
            }
        }       


        //CASE CLAIMS TAB
        public bool ClaimsNavigationTabIsPresent()
        {
            try
            {
                this.WaitForElementToBeVisible(claimsNavMenuItemLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ClaimsDetailTab GoToClaimsDetail()
        {            
            this.MoveToTabsNavigationArea();
            this.clickNotVisualizedElement(this.WaitForElementToBeVisible(claimsNavMenuItemLocator));
            this.WaitForBlockOverlayToDissapear();
            return new ClaimsDetailTab(driver);
        }

        public AssetsDetailTab GoToAssetsDetail()
        {
            this.MoveToTabsNavigationArea();
            this.clickNotVisualizedElement(this.WaitForElementToBeVisible(assetsNavMenuItemLocator));
            this.WaitForBlockOverlayToDissapear();
            return new AssetsDetailTab(driver);            
        }

        public bool ClaimsDetailTabIsSelected()
        {
            try
            {
                this.WaitForElementToBeVisible(claimstabTitleLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string ClaimsDetailTabTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(claimstabTitleLocator).Text;
            }
        }

        //BANKING TAB SECTION
        public bool BankingNavigationTabIsPresent()
        {
            try
            {
                this.WaitForElementToBeVisible(bankingNavMenuItemLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public BankingDetailTab GoToBankingDetail()
        {
            //this.WaitForBlockOverlayToDissapear();
            this.MoveToTabsNavigationArea();

            //Click on banking link 
            this.clickNotVisualizedElement(this.WaitForElementToBeClickeable(bankingNavMenuItemLocator));            

            //Wait for the overlay to dissapear prior to return page
            this.WaitForBlockOverlayToDissapear();

            return new BankingDetailTab(driver);            
        }       

        private void MoveToTabsNavigationArea()
        {
            //Find details area that is bellow tabs navigation
            //Currently moving to tabs bar is not getting it into view
            this.MoveToViewElement(this.WaitForElementToBeVisible(By.CssSelector(".tabContainer")));
            this.MoveToViewElement(this.WaitForElementToBeVisible(By.Id("nonStickyHeader")));
        }

        public bool IsNameSticky()
        {
            try
            {
                this.WaitForElementToBeClickeable(caseNameLocator).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNumberSticky()
        {
            try
            {
                this.WaitForElementToBeClickeable(caseNumberLocator).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsTypeSticky()
        {
            try
            {
                this.WaitForElementToBeClickeable(caseTypeLocator).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsStatusSticky()
        {
            try
            {
                this.WaitForElementToBeClickeable(caseStatusLocator).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool BankBalanceIconIsNotInView()
        {
            try
            {
                this.WaitForElementToBeClickeable(By.Id(balanceIconId)).Click();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool IsStickyCaseHeaderVisible()
        {
            try
            {
                this.WaitForElementToBeClickeable(stickyCaseHeaderLocator).Click();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool BankingDetailTabIsSelected()
        {
            try
            {
                this.WaitForElementToBeVisible(bankingTabTitleLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //DISTRIBUTION TAB
        public DistributionTab GoToDistribution()
        {            
            this.MoveToTabsNavigationArea();
            this.clickNotVisualizedElement(this.WaitForElementToBeVisible(distributionMenuItemLocator));
            this.WaitForBlockOverlayToDissapear();
            return new DistributionTab(driver);
        }

        //CLAIMS TAB
        public ClaimsDetailTab ClaimsTab
        {
            get
            {
                this.WaitForElementToBeVisible(bankingNavMenuItemLocator);
                return new ClaimsDetailTab(driver);
            }
        }

        //NOTES SECTION
        public NotesWindow Notes {
            get {
                return new NotesWindow(driver);
            }
        }

        public string JointDebtorName {
            get {
                return this.WaitForElementToBeVisible(jointDebtorNameLocator).Text;
            }
        }

        public bool IsVisible341KeyDate {
            get {
                try
                {
                    this.WaitForElementToBeVisible(By.XPath(String.Format(keyDateDropDownByTextLocatorTemplate, "CURRENT 341 DATE")));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool GoTo341MeetingCalendarLinkIsInvisible {
            get
            {
                try
                {
                    this.WaitForElementToDissapear(goTo341MeetingsCalendarLinkLocator, 5);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        //COMMON TO ALL TABS
        protected void SwipeTileToTheLeft(IWebElement tile)
        {
            //Swipe
            int offset = -((tile.Size.Width) / 3)*2;
            Actions action = new Actions(driver);
            action.MoveToElement(tile).DragAndDropToOffset(tile, offset, 0).Build().Perform();
        }
        
        protected void ScrollDownToAvoidStickyHeadersOnClick()
        {
            //Move by offset of the sticky headers height....
            //int menuOffSet = this.WaitForElementToBeVisible(By.Id("top-bar")).Size.Height;
            IWebElement headerBar = this.WaitForElementToBeVisible(By.Id("header-bar"));            
            IWebElement caseDataStickyHeader = this.WaitForElementToBeVisible(By.XPath("//*[contains(@class,'bottomHeaderBorder')]"));
            int Y = headerBar.Size.Height + caseDataStickyHeader.Size.Height;
            ScrollWindowBy(0, -Y);            
        }

        public void Add341KeyDateToView()
        {
           
                this.WaitForElementToBeVisible(addKeyDateButtonLocator).Click();
                this.WaitForElementToBeVisible(addKeyDateModalTitleLocator);
                if(!this.WaitForElementToBePresent(By.XPath(String.Format(checkboxKeyDateByTextLocatorTemplate, "341 Date"))).Selected)
                    this.WaitForElementToBeVisible(By.XPath(String.Format(optionKeyDateByTextLocatorTemplate, "341 Date"))).Click();
                this.WaitForElementToBeVisible(addKeyDateModalAddButtonLocator).Click();
                this.WaitForBlockOverlayToDissapear();
            
        }
    }    
}