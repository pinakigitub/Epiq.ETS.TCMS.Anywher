using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;
using NUnit.Framework;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages
{
    public class DashboardPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        //Top CASE Serach locators on dashboard
        private By dashboardCaseSearchFilter = By.XPath("//div[@class='epiq-header-case-selector primary epiq-header-selector']");
        private By caseSearchInput = By.XPath("//div[@class='epiq-header-search-case']//input");
        private By caseSearchListDropdown = By.XPath("//div[@id='epiq-header-case-selector']//li[@class='ellipsis']");

        //Welcome banner locators
        private By welcomeMessage = By.XPath("//*[contains(@class,'universalSearchDashboardContainer')]//*[contains(@class,'searchText')]");
        private By welcomeMessageIntroduction = By.Id("welcomeText");
        protected By welcomeUsername = By.Id("welcomeTextUser");

        //Top Left Locators
        private By topUserIcon = By.XPath("//a[@id='basic-nav-dropdown']/i");
        private By changePassword = By.XPath("//a[text()='Change Password']");

        //Change Password widow Locators
        private By oldPasswords = By.XPath("//input[@name='oldPassword']");
        private By newPasswords = By.XPath("//input[@name='newPassword']");
        private By CONFIRM_PASSWORD_LOCATOR = By.XPath("//input[@name='confirmPassword']");
      //  private By CHANGE_PASSWORD_SAVE_LOCATOR = By.XPath("//button[text()='SAVE']");
        private By changePasswordCancel = By.XPath("//button[text()='CANCEL']");
        //private By PASSWORD_CONDITIONS_LOCATOR = By.XPath("//div[@class='modal-body']//ul/li/i");
       

        //balance locators
        private By courtIcon = By.CssSelector("i.fa.fa-university");
        private By balanceLabels = By.Id("balanceLabel");
        private By balanceValues = By.Id("balanceValue");

        private By UnreconciledOption = By.XPath("//td[6]/a/span");

        //open cases locators
        private By gavelIcon = By.CssSelector("i.fa.fa-gavel");
        private By openCasesValues = By.Id("openCasesValue");
        private By openCasesLabels = By.Id("openCasesLabel");


        //favorite tile debtor
        private By debtorName = By.XPath("//div[@class='col-xs-7']/a");
        //Task Tile Debtor
        private By taskTileDebtorName = By.XPath("//div[@class='col-xs-12 col-sm-5 epiq-dashboard-tasks-content']/div[2]");

        //universal search container locator - gets the visible universal search tool
        private By unviversalSearchSection = By.XPath("//span[@class='select2-selection select2-selection--single']");
        private By unviversalStickySearchSection = By.XPath("//*[contains(@class,'universalSearchContainer')]");
        private By newUniversalSearchSection = By.XPath("//div[@class='pull-left epiq-header-global-navigation']");
        private By radioButton = By.XPath("//div[@id='schedules-tab-pane-1']/div/div/table/tbody/tr/td[2]/div/label");
        private By linkButton = By.XPath("//div[2]/button");


        // Banking Summary
        private By unreconciledBankingActivity = By.XPath("//div[@class='epiq-banking-summary']//div[span[text()='Unreconciled Bank Activity']]//a/span");
        //private By DashboardDepositsOutstanding = By.XPath("//span[@class='quantity']//a[@href='/banking/activity?issueCodes=deposit']");
        private By DashboardDepositsOutstanding = By.XPath("//div[3]/div[2]/span/a");

        //341 Meeting Section Locator
        private By past341MeetingDate = By.XPath("//div[@class='highcharts-axis-labels highcharts-xaxis-labels ']/span[1]");
        private By upcoming341MeetingDate = By.XPath("//div[@class='epiq-dashboard-tile epiq-flex-child epiq-first-row-tile']//div[@class='row epiq-upcoming-341-card epiq-panel-card']");
        private By upcomingTileNoData = By.XPath("//div[@class='epiq-dashboard-tile epiq-flex-child epiq-first-row-tile'][2]//div[@class=' text-center dashboard-data-none']//div[2]");
        private By upcomingTrusteeDropdowns = By.XPath("//input[@name='upcomingSelectTrustee']//following-sibling::div//span[@class='Select-arrow']");
        private By upcomingTrusteeDropdown = By.XPath("//input[@name='upcomingSelectTrustee']//following-sibling::div");
        private By upcoming341MeetingPanelCard = By.XPath("//div[@class='row epiq-upcoming-341-card epiq-panel-card']");
        private By pastTrusteeDropdown = By.XPath("//input[@name='pastSelectTrustee']//following-sibling::div//span[@class='Select-arrow']");
        private By pastTrusteeDropdownList = By.XPath("//input[@name='pastSelectTrustee']//following-sibling::div");
        private By dsoSummary = By.XPath("//div[@class='epiq-dashboard-tile epiq-flex-child']//div[@class='row epiq-panel-card']");
      
        public DashboardPage(IWebDriver driver):base(driver, pageTitle){}

        protected void ScrollDownToAvoidStickyHeadersOnClick()
        {
            //Move by offset of the sticky headers height....
            IWebElement topBar = this.WaitForElementToBeVisible(By.Id("top-bar"));
            IWebElement greyStickyBar = this.WaitForElementToBeVisible(By.CssSelector("quick-links-region"));
            int Y = topBar.Size.Height + greyStickyBar.Size.Height;
            ScrollWindowBy(0, Y);
        }

        public void MouseHouver()
        {
            this.ScrollDownToPageBottom();
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(debtorName)).Perform();
            this.PressEscapeKey();
        }

        public void ClickOnUnreconciled()
        {
           this.WaitForElementToBeVisible(UnreconciledOption,3).Click();
        }
        public void ClickOnRadioButton()
        {
            this.WaitForElementToBeVisible(radioButton, 3).Click();
        }
        
        public void ClickOnLinkButton()
        {
            this.WaitForElementToBeVisible(linkButton, 3).Click();
        }
        public void mouseHouverTaskTile()
        {
            this.ScrollDownToPageBottom();
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(taskTileDebtorName)).Perform();
            this.PressEscapeKey();
        }

        public BankingPage ClickOnUnReconciledBankActivity()
        {
            this.WaitForElementToBeVisible(unreconciledBankingActivity, 10).Click();
            return new BankingPage(driver);
        }    
            
        //WELCOME BANNER SECTION
        public string WelcomeMessageIntroduction
        {
            get
            {
                return this.WaitForElementToBeVisible(welcomeMessageIntroduction).Text;
            }
        }
        
        public string UserNameOnWelcomeMessage
        {
            get
            {
                return this.WaitForElementToBeVisible(welcomeUsername).Text;
            }
        }

        public string SearchToolWelcomeMessage
        {
            get
            {
                return this.WaitForElementToBeVisible(welcomeMessage).Text;
            }
        }

        //BALANCE SECTION
        public bool IsCourtIconPresent()
        {
            try
            {
                this.WaitForElementToBeVisible(courtIcon);
                return true;
            }
            catch (Exception)
            {
                return false;                
            }
        }

        public string Balance
        {
            get
            {
                return this.WaitForElementToBeVisible(balanceValues).Text;
            }
        }
        public string BalanceLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(balanceLabels).Text;
            }
        }

        //OPEN CASES SECTION
        public bool IsGavelIconPresent()
        {
            try
            {
                this.WaitForElementToBeVisible(gavelIcon);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        

        public string OpenCases
        {
            get
            {
                return this.WaitForElementToBeVisible(openCasesValues).Text;
            }
        }
        public string OpenCasesLabel
        {
            get
            {
                return this.WaitForElementToBeVisible(openCasesLabels).Text;
            }
        }
                
        public CaseListPage ClickOpenCasesLink()
        {
            this.WaitForElementToBeClickeable(openCasesLabels).Click();
            return new CaseListPage(driver);
        }

        public UniversalSearch UniversalSearch
        {
            get
            {
                this.WaitForElementToBeVisible(unviversalSearchSection);
                return new UniversalSearch(driver, "//span[@class='select2-selection select2-selection--single']");
            }
        }

        public bool UniversalSearchVisibleOnStickyBar()
        {
            try
            {
                this.WaitForElementToBeVisible(unviversalStickySearchSection, 10);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
            public UniversalSearch NewUniversalSearch
          {
            get
            {
                this.WaitForElementToBeVisible(newUniversalSearchSection);
                return new UniversalSearch(driver, "//div[@class='pull-left epiq-header-global-navigation']");
            }
        }
        public void ClickOnUserIcon()
        {
            Thread.Sleep(2000);
            this.WaitForElementToBeVisible(topUserIcon).Click();
        }

        public void ClickOnChangePassword()
        {
            this.WaitForElementToBeVisible(changePassword).Click();
        }
        public void EnterOldPassword(string oldPassword)
        {
            this.WaitForElementToBeVisible(oldPasswords).SendKeys(oldPassword);
        }
        public void EnterNewPassword(string newPassword)
        {
            this.WaitForElementToBeVisible(newPasswords).SendKeys(newPassword);
        }
        public void ClearNewPassword()
        {
            driver.FindElement(newPasswords).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
        }
        public void ValidateAllAreRequiredFields()
        {
            this.WaitForElementToBeVisible(oldPasswords).Click();
            this.WaitForElementToBePresent(By.XPath("//label[text()='ENTER EXISTING PASSWORD']")).Click();
            Assert.IsTrue(WaitForElementToBeVisible(By.XPath("//div[@class='modal-body']//div[1]//span[text()='*']")).Displayed);
            this.WaitForElementToBeVisible(newPasswords).Click();
            this.WaitForElementToBePresent(By.XPath("//label[text()='ENTER NEW PASSWORD']")).Click();
            Assert.IsTrue(WaitForElementToBeVisible(By.XPath("//div[@class='modal-body']//div[2]//span[text()='*']")).Displayed);
            this.WaitForElementToBeVisible(CONFIRM_PASSWORD_LOCATOR).Click();
            this.WaitForElementToBePresent(By.XPath("//label[text()='CONFIRM NEW PASSWORD']")).Click();
            Assert.IsTrue(WaitForElementToBeVisible(By.XPath("//div[@class='modal-body']//div[3]//span[text()='*']")).Displayed);
        }

       public bool VerifyDangerExist()
        {
            try
            {
                IList<IWebElement> list = driver.FindElements(By.XPath("//div[contains(@class,'modal-body')]//ul/li/i[contains(@class,'text-danger')]"));
                if (list.Count > 0)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
            
        }
        public void ClickOnChangePasswordCalcelButton()
        {
            this.WaitForElementToBePresent(changePasswordCancel).Click();

        }
        public void SelectCaseNumberFromTopSearch(string caseNumber)
        { 
            this.WaitForElementToBeVisible(dashboardCaseSearchFilter).Click();
            this.WaitForElementToBeVisible(caseSearchInput).SendKeys(caseNumber);
            Pause(2);
            IList<IWebElement> caseSearchResult = this.WaitForElementsToBeVisible(caseSearchListDropdown).ToList();
            caseSearchResult[0].Click();
        }
        public void ClickOnPast341MeetingDate()
        {
            IList<IWebElement> past341MeetingDates = this.WaitForElementsToBeVisible(past341MeetingDate).ToList();
            for (int i = 0; i <= past341MeetingDates.Count() - 1; i++)
            {
                DateTime dateLink = DateTime.Now;
                dateLink = dateLink.AddDays(-1);
                string dt = dateLink.ToString("MMM dd"); 
                string dd = past341MeetingDates[i].Text.ToString(); 
                if (dd.Equals(dt))
                    {
                      past341MeetingDates[i].Click();
                    }
                break;
            }
        }
        public void ClickOnUpcoming341MeetingDate()
        {
            IList<IWebElement> past341MeetingDates = this.WaitForElementsToBeVisible(upcoming341MeetingDate).ToList();
            past341MeetingDates[0].Click();
        }
        public bool Is_NoneDataMessage_Displayed()
        {
            string noDatText = this.WaitForElementToBeVisible(upcomingTileNoData).Text;
            return noDatText.Contains("No Upcoming 341 Meetings Matching Current View");
        }
        public bool Is_UpcomingDataPanel_Displayed()
        {
           return this.WaitForElementToBeVisible(upcoming341MeetingPanelCard).Displayed;
        }
        public bool Is_PastMeetingDataGraph_Displayed()
        {
           return this.WaitForElementToBeVisible(past341MeetingDate).Displayed;
        }
        public void SelectTrustee_ON_UpcomingMeeting(string trustee)
        {
            string trustees = this.WaitForElementToBeVisible(upcomingTrusteeDropdown).Text;
            trustees.Should().BeEquivalentTo(trustee);
            //this.WaitForElementToBeVisible(UPCOMING_MEETING_DROPDOWN_LOCATOR).Click();
            //IList<IWebElement> Trustee_List = this.WaitForElementsToBeVisible(UPCOMING_DROPDOWN_LIST_LOCATOR).ToList();
            //for (int i = 0; i < Trustee_List.Count(); i++)
            //{
            //    if (Trustee_List[i].Text == trustee)
            //    {
            //        Trustee_List[i].Click();
            //        break;
            //    }

            //}
        }
        public void SelectTrustee_ON_PastMeeting(string trustee)
        {
            this.WaitForElementToBeVisible(pastTrusteeDropdown).Click();
            IList<IWebElement> Trustee_List = this.WaitForElementsToBeVisible(pastTrusteeDropdownList).ToList();
            for (int i = 0; i < Trustee_List.Count(); i++)
            {
                if (Trustee_List[i].Text == trustee)
                {
                    Trustee_List[i].Click();
                    break;
                }

            }
        }
        public void ClickOnDSO_Summary_Record()
        {          
                ScrollDownToPageBottom();
                IList<IWebElement> DSO_Records = this.WaitForElementsToBeVisible(dsoSummary).ToList();
                DSO_Records[0].Click();           
        }
        public void ClickOnDepositsOutstandingQuantity()
        {
                WaitForElementToBeVisible(DashboardDepositsOutstanding).Click();
        }

    }
}

