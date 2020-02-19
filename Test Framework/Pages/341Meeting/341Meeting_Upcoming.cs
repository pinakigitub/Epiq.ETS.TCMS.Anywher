using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages._341Meeting
{
    public class _341Meeting_Upcoming : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        
        private By meetingDatesCount = By.XPath("//div[@class='epiq-page-controls clearfix container']//h3//span/span");
        private By meetingDateList = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr//td[2]//a//span");
        private By meetingTimeBlock = By.XPath("//div[@class='epiq-grouped-list-341 epiq-grouped-list-upcoming341']//span");
        private By timeBlockSectionArrow = By.XPath("//div[@class='epiq-grouped-list-toggle-icon']");
        private By timeBlockArrowOpen = By.XPath("//div[@class='epiq-grouped-list-toggle-icon']//i[@class='fa fa-chevron-up']");
        private By timeBlockArrowClose = By.XPath("//div[@class='epiq-grouped-list-toggle-icon']//i[@class='fa fa-chevron-down']");
        private By toggleSwitch = By.XPath("//div[@class='onoffswitch']//label");
        private By toastMessageSuccess = By.XPath("//div[@class='toastr animated rrt-success']");
        private By viewButtonOnMeetingManagement = By.XPath("//a[@class='epiq-341-view-icon']");
        private By caseHeaderDropDown = By.XPath("//div[@class='case-header-data-additional-details']");
        private By caseDropDownValues = By.XPath("//div[@class='popover-content']//li");
        private By caseHeaderRightArrow = By.XPath("//i[@class='fa fa-2x fa-chevron-circle-right']");
        private By caseHeaderLeftArrow = By.XPath("//i[@class='fa fa-2x fa-chevron-circle-left']");
        private By caseHeaderDate = By.XPath("//div[@class='epiq-appointment-341-header-times']//span[1]");
        private By caseHeaderTime = By.XPath("//div[@class='epiq-appointment-341-header-times']//span[2]");
        private By viewMeetingContinuedDetails = By.XPath("//div[@class='epiq-well clearfix well']//span[text()=' Continued Details']");
        private By continuedTimeDropDownValues = By.XPath("//div[@class='popover-content']//div[@class='Select-menu-outer']//div//div");
        private By continuedReasonDropDownValues = By.XPath("//div[@class='epiq-well clearfix well']//div[@class='form-group col-lg-4 col-md-12']//div[@class='Select-menu-outer']//div//div");
        private By saveChangesButton = By.XPath("//button[text()='SAVE CHANGES']");
        private By continuedDetailsInfoIcon = By.XPath("//i[@class='fa fa-info-circle text-primary']");
        private By verificationStatus = By.XPath("(//div[@class='epiq-appointment-341-overview']//div//div[3])[1]");
        private By caseDispositionLabel = By.XPath("//div[text()='CASE DISPOSITION']");
        private By oneClickFilingTaskLabel = By.XPath("//div[text()='ONE CLICK FILING TASK']");
        private By caseDocumentsTab = By.XPath("//div[@id='appointment-341-view-tabs']//li[2]//a[text()='CASE DOCUMENTS']");
        private By caseDocumentColumns = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//th[@class='epiq-table-header-sortable ']");
        private By expandCollapsebutton = By.XPath("//div[@id='appointment-341-view-tabs-pane-2']//td[@class='epiq-table-view-more sm md lg xl']//i");
        private By dragElement = By.XPath("(//div[@class='epiq-grouped-list-drag-icon']//i[@class='fa fa-long-arrow-down'])[1]");                              
        private By dragToElement = By.XPath("//div[@class='panel-body']//li[2]");

        public _341Meeting_Upcoming(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        public bool ValidateCountOfCases()
        {
            return WaitForElementToBeVisible(meetingDatesCount).Displayed;
        }
        public IList<string> MeetingDatesList()
        {
            List<string> lists = new List<string>();
            IList<IWebElement> MeetingDates = WaitForElementsToBeVisible(meetingDateList).ToList();
            for (int i = 0; i < MeetingDates.Count(); i++)
            {
                lists.Add(MeetingDates[i].Text);
            }
            return lists;
        }
        public bool ValidateTimeBlocks()
        {
            return WaitForElementToBeVisible(meetingTimeBlock).Displayed;
        }
        public void ValidateTimeBlocksColor()
        {
            string color = WaitForElementToBeVisible(meetingTimeBlock).GetCssValue("color");
            color.Contains("rgba(255, 255, 255, 1)");
        }

        public bool ValidateOrdeOfMeetingDates()
        {
            bool sorted = true;
            for (int i = 1; i < MeetingDatesList().Count(); i++)
            {
            // if (MeetingDatesList[i-1].compareTo(MeetingDatesList[i]) > 0) sorted = false;
            }

            return sorted;
        }

        public void AllArrowPointing_OPEN()
        {
            int TotalTimeSectionArrow = this.WaitForElementsToBeVisible(timeBlockSectionArrow).ToList().Count();
            int TotalOpenSectionArrow = this.WaitForElementsToBeVisible(timeBlockArrowOpen).ToList().Count();
            TotalTimeSectionArrow.Equals(TotalOpenSectionArrow);
        }
        public void ClickOnTimeBlockArrow()
        {
            IList<IWebElement> TimeSectionArrow = this.WaitForElementsToBeVisible(timeBlockSectionArrow).ToList();
            TimeSectionArrow[0].Click();
        }
        public void ValidateTimeBlockArrowPointing_CLOSE()
        {            
            this.WaitForElementToBeVisible(timeBlockArrowClose).Displayed.Should().BeTrue();            
        }
        public void Validate_Toggle_Ready_OR_NotReady()
        {
            IList<IWebElement> Toggle_List = this.WaitForElementsToBeVisible(toggleSwitch).ToList();
            Toggle_List[0].Click();
            this.WaitForElementToBeVisible(toastMessageSuccess).Displayed.Should().BeTrue();            
        }
        public void ClickOn341DateViewLink()
        {
            int RowsCount = this.WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody//tr[position() mod 2 = 1]")).Count();
            for (int i = 1; i <= RowsCount;i=i+2)
            {
                string CasesCountText = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody//tr["+i+"]//td[contains(@data-title,'TOTAL CASES')]")).Text;
                int CasesCount = int.Parse(CasesCountText);
                if (CasesCount > 1)
                {
                    this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody//tr[" + i + "]//td[contains(@data-title, '341 DATE')]/a")).Click();
                    break;
                }

            }
        }
        public void ClickOnViewButton_On_MeetingManagement()
        {
            IList<IWebElement> ViewButton = this.WaitForElementsToBeVisible(viewButtonOnMeetingManagement).ToList();
            ViewButton[0].Click();
        }
        public void VerifyDateTime()
        {
            this.WaitForElementToBeVisible(caseHeaderDate).Displayed.Should().BeTrue();
            this.WaitForElementToBeVisible(caseHeaderTime).Displayed.Should().BeTrue();
        }
        public void Validate_CaseHeader_Dropdown()
        {
            this.WaitForElementToBeVisible(caseHeaderDropDown).Click();
            this.WaitForElementToBeVisible(caseDropDownValues).Displayed.Should().BeTrue();
        }
        public void ClickOnCaseHeader_RightArrow()
        {
            this.WaitForElementToBePresent(caseHeaderRightArrow).Click();
        }
        public void ClickOnCaseHeader_LeftArrow()
        {
            this.WaitForElementToBePresent(caseHeaderLeftArrow).Click();
        }
        public void ValidatePageRefreshed_With_selectedCaseDetail()
        {
          string Header_Case =  this.WaitForElementToBeVisible(By.XPath("//div[@class='case-header-data-case-display']//span[@class='case-header-data-number']")).Text;
            string Page_Case = this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-header-case-selector info epiq-header-selector']//div[@class='epiq-header-selection-content']")).Text;
            Page_Case.Contains(Header_Case);
        }
        public void Is_ContinuedDetailsSection_Displayed()
        {
            this.WaitForElementToBeVisible(viewMeetingContinuedDetails).Displayed.Should().BeTrue();
        }
        public void Is_VerificationStatusSection_Displayed()
        {
            this.WaitForElementToBeVisible(verificationStatus).Displayed.Should().BeTrue();
        }
        public void Is_CaseDisposition_Displayed()
        {
            this.WaitForElementToBeVisible(caseDispositionLabel).Displayed.Should().BeTrue();
        }
        public void Is_OneClickFilingTaskLabel_Displayed()
        {
            this.WaitForElementToBeVisible(oneClickFilingTaskLabel).Displayed.Should().BeTrue();
        }
        public void Edit_ContinuedDate()
        {
            Thread.Sleep(1000);
            this.WaitForElementToBeVisible(By.XPath("(//div[@class='epiq-inline-edit-overlay'])[1]/button")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='popover-content']//span[@class='input-group-addon']//i")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='popover-content']//div[@class='rdtPicker']//td[@class='rdtDay rdtToday']")).Click();
            this.WaitForElementToBeVisible(By.XPath("//label[text()='CONTINUED REASON']")).Click();
        }
        public void Edit_ContinuedTime()
        {
            this.WaitForElementToBeVisible(By.XPath("(//div[@class='epiq-inline-edit-overlay'])[2]/button")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='popover-content']//span[@class='Select-arrow-zone']//span")).Click();
            IList<IWebElement> TimeValues = this.WaitForElementsToBeVisible(continuedTimeDropDownValues).ToList();
            TimeValues[1].Click();
            this.WaitForElementToBeVisible(By.XPath("//label[text()='CONTINUED REASON']")).Click();
        }
        public void Edit_ContinuedReason()
        {
            this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-well clearfix well']//div[@class='form-group col-lg-4 col-md-12']//span[@class='Select-arrow-zone']/span")).Click();
            IList<IWebElement> ContinuedReasonList = this.WaitForElementsToBeVisible(continuedReasonDropDownValues).ToList();
            ContinuedReasonList[2].Click();
        }
        public void ClickOnSaveChanges()
        {
            this.WaitForElementToBeVisible(saveChangesButton).Click();
        }
        public bool is_InfoIcon_displayed()
        {
           return this.WaitForElementToBeVisible(continuedDetailsInfoIcon).Displayed;
        }
        public void ClickOnCaseDocumentsTab()
        {
            this.WaitForElementToBeVisible(caseDocumentsTab).Click();
        }
        public void ValidateCaseDocumentsColumns()
        {
            var HeaderNames = new List<string>() { "DOC #", "SOURCE", "DESCRIPTION" };
            IList<IWebElement> Columns = this.WaitForElementsToBeVisible(caseDocumentColumns).ToList();
            List<string> Clmn_list = new List<string>();
            for (int i = 0; i < Columns.Count(); i++)
            {
                Clmn_list.Add(Columns[i].Text);
            }
            Clmn_list.Should().Contain(HeaderNames);
        }

        public void DragCase(string CaseNum, string time)
        {
            var Num = WaitForElementToBeVisible(By.XPath($"//div[text()='{CaseNum}']")).Text;
            if (Num == CaseNum)
            {
                var drag = WaitForElementToBeVisible(dragElement);
                var ToElement = WaitForElementToBeVisible(dragToElement);
                Actions action = new Actions(driver);
                action.ClickAndHold(drag);
                action.MoveToElement(ToElement);
                action.Release(ToElement).Build().Perform();
            }
        }

         public void ClickExpandCollapseButton()
        {
            WaitForElementToBeVisible(expandCollapsebutton).Click();
            Pause(25);
        }
        public void MouseHouverOnHistoryIcon()
        {
            this.Pause(5);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath(""))).Perform();
            this.PressEscapeKey();
        }
    }
}
