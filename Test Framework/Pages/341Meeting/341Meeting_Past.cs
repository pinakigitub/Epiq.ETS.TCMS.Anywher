using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages._341Meeting
{
    public class _341Meeting_Past : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        //header section locators
        private By LeftArrow = By.XPath("//i[@class='fa fa-3x fa-chevron-circle-left']");
        private By RightArrow = By.XPath("//i[@class='fa fa-3x fa-chevron-circle-right']");
        private By MeetingDateDropDown = By.XPath("//div[@class='epiq-page-heading clearfix']/div[2]//div/div[2]//div/span[2]/span");
        private By MeetingDatesList = By.XPath("//div[@class='Select-menu']/div");
        private By MeetingDate = By.XPath("//div[@class='epiq-appointment-341-overview-carousel']//div[2]/div/div/span/div/span");
        private By MeetingCases = By.XPath("//div[@class='row']/div[contains(@class,'epiq-appointment-341-text-middle')][2]");
        private By TimeHeaderSection = By.XPath("//h5/span");
        
        //Pagesection locators
        private By CollapseButton = By.XPath("//i[@class='fa fa-chevron-up']");
        private By ExpandButton = By.XPath("//i[@class='fa fa-chevron-down']");
        private By DebtorName = By.XPath("//div[@class='epiq-ellipsis-text']//span[2]");
        private By DebtorAttorneyEnvelope = By.XPath("//i[@class='fa fa-envelope']");
        private By DispositionClear = By.XPath("(//div[contains(@class,'blue-dotted')][1]//span[@title='Clear value']/span)[1]");
        private By CaseDispositionDropDown = By.XPath("(//div[contains(@class,'blue-dotted')][1]//span[@class='Select-arrow'])[2]");
        private By ToastMessage = By.XPath("//div[@class='toastr animated rrt-success']/div/div[2]/div");
        private By CaseNumberOrder2 = By.XPath("//div/div[2]/div[2]/div/ul/li[1]/div/div[2]/div[3]/div");
        private By MeetingTime2 = By.XPath("//div[3]/div/div[2]/div[2]/div/ul/li[1]/div/div[2]/div[2]//span[1]//span");
        private By TimeOrder = By.XPath("//div[3]/div/div[1]/div[1]/div/div[3]/h5/span");
        private By CaseNumberOrder1 = By.XPath("//div/div[2]/div[3]/div/div[1]/div[2]/div/ul/li[1]/div/div[2]/div[3]/div");
        private By MeetingTime1 = By.XPath("//div[3]/div/div[1]/div[2]/div/ul/li[10]/div/div[2]/div[2]//span[1]//span");
        private By Time1DropDown = By.XPath("//div[3]/div/div[1]/div[2]/div/ul/li[1]/div/div[2]/div[2]//span[2]/span");
        private By Time2DropDown = By.XPath("//div[3]/div/div[2]/div[2]/div/ul/li[1]/div/div[2]/div[2]//span[2]/span");
        private By DRAG_ELEMENT = By.XPath("//div[3]/div/div[1]/div[2]/div/ul/li[1]/div/div[3]");
        private By DRAG_TO_ELEMENT = By.XPath("//div[3]/div/div[2]/div[2]/div/ul/li[1]/div/div[3]");


        private By MeetingDateHeader = By.XPath("//div[@class='epiq-page-controls clearfix container']//h3");
        private By MeetingOverview = By.XPath("//div[@class='epiq-page-header has-right-content ']//li[@class='active']");

        private By ToastMessageText = By.XPath("//div[@class='rrt-middle-container']/div");

        //dashboard locators
        private By PastMeetingHeader = By.XPath("//div[@class='row epiq-flex']/div[3]//h3");
        private By UnExaminedTextHeader = By.XPath("//*[14]//*[1]//*[text()][1]");

        private By AssetText = By.XPath("//div[1]//div[1]/div[2]/div/ul/li[1]//div[2]/div[17]/span");
        private By CaseStatus = By.XPath("//div[2]//div[1]/div[2]/div/ul/li[2]//div[2]/div[6]/span");
        private By AlertIcon = By.XPath("//ul/li[1]/div/div[2]/div[2]/div/div[3]/span/i");
        private By CaseDispostionDropDown = By.XPath("//div[2]/div[3]/div/div[1]//li[2]//div[2]/div[8]//span[2]");
        public _341Meeting_Past(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void VerifyLastMeetingDate(string lastMeeting)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(LeftArrow).Click();
            var lastDate = WaitForElementToBeVisible(By.XPath($"//span[text()='{lastMeeting}']")).Text;
            lastDate.Equals(lastMeeting);
        }
        public void VerifyFirstMeetingDate(string firstMeeting)
        {
            WaitForElementToBeClickeable(RightArrow).Click();
            var firstDate = WaitForElementToBeVisible(By.XPath($"//span[text()='{firstMeeting}']")).Text;
            firstDate.Equals(firstMeeting);
        }
        public List<string> DatesDescendingOrder()
        {
            WaitForElementToBeClickeable(MeetingDateDropDown, 3).Click();
            this.Pause(4);

            List<string> list = new List<string>();

            IList<IWebElement> TimeData = driver.FindElements(MeetingDatesList);
            var TimeList = TimeData.OrderBy(t => t.Text);
            foreach (IWebElement element in TimeList)
            {
                list.Add(TimeList.ToString());
                Console.WriteLine(element.Text);

            }
            return list;

        }
        public void CasesCount()
        {
            var Date = WaitForElementToBeVisible(MeetingDate).Text;
            var newString = Date.Substring(16,Date.Length - 16);
            var CaseCount = newString.Remove(1,newString.Length - 1).Trim();

            IList<IWebElement> Cases = driver.FindElements(MeetingCases);
            this.Pause(2);
            var count = Cases.Count;
            count.Equals(CaseCount);
        }
        public void MeetingTimeOrder()
        {
            IList<IWebElement> TimeData = driver.FindElements(TimeHeaderSection);
            var TimeList = TimeData.OrderBy(t => t.Text);
            foreach (IWebElement element in TimeList)
            {
                
            }
        }
        public void ExpandAndCollapse()
        {
            WaitForElementToBeClickeable(CollapseButton).Click();
            WaitForElementToBeClickeable(ExpandButton).Click();
        }
        public void VerifyDebtorAttorneyField(string debtor)
        {
            var DebtorName = WaitForElementToBeVisible(this.DebtorName).Text;
            var newString = DebtorName.Substring(4, DebtorName.Length - 4);
            if(newString == debtor)
            {
                Assert.IsTrue(IsElementVisible(DebtorAttorneyEnvelope));
            }
        }
        public void SelectTaskType(string type)
        {
            var element = IsElementVisible(By.XPath($"//span[text()='{type}']"));
            if (element)
            {
                WaitForElementToBeClickeable(DispositionClear,2).Click();
                WaitForElementToBeClickeable(CaseDispositionDropDown,3).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{type}']"),2).Click();
            }
            else
            {
                WaitForElementToBeClickeable(CaseDispositionDropDown,3).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{type}']")).Click();
            }
        }
        public void VerifyToastMessage(string SuccessMsg)
        {
                var text = WaitForElementToBeVisible(ToastMessage).Text;
                text.Equals(SuccessMsg);
        }
        public void changeMeetingTime(string caseNum, string time1, string time2)
        {
            ScrollWindowBy(600,800);
            var num = WaitForElementToBeVisible(CaseNumberOrder2).Text;
            var time = WaitForElementToBeVisible(MeetingTime2).Text;

            if (num == caseNum && time == time1)
            {
                WaitForElementToBeClickeable(Time2DropDown,3).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[@role='listbox']/div[text()='{time2}']")).Click();
                
            }
        }
        public void VerifyCaseUnderTimeOrder(string caseNum, string timeOrder)
        {
            ScrollUpToPageTop();
            this.Pause(3);

            var TimeOrder = WaitForElementToBeVisible(this.TimeOrder).Text;
            if(TimeOrder == timeOrder)
            {
                var num = WaitForElementToBeVisible(CaseNumberOrder1).Text;
                num.Equals(caseNum);
            }
            this.Pause(3);
        }
        public void RevertMeetingTime(string caseNum, string time1, string time2)
        {
            this.Pause(3);

            var num = WaitForElementToBeVisible(CaseNumberOrder1).Text;
            var time = WaitForElementToBeVisible(MeetingTime1).Text;
            if (num == caseNum && time == time1)
            {
                WaitForElementToBeClickeable(Time1DropDown).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[@role='listbox']/div[text()='{time2}']")).Click();
            }
            this.Pause(3);

        }
        public void VerifyDragAndDrop(string CaseNum1, string CaseNum2)
        {
            this.Pause(3);

            var Num1 = WaitForElementToBeVisible(CaseNumberOrder1).Text;
            if(Num1 == CaseNum1)
            {
                var element = WaitForElementToBeVisible(DRAG_ELEMENT);
                var ToElement = WaitForElementToBeVisible(DRAG_TO_ELEMENT);
                Actions action = new Actions(driver);
                //IAction dragdrop = action.ClickAndHold(element).MoveToElement(ToElement).Release(ToElement).Build();
                //dragdrop.Perform();
                action.DragAndDrop(element, ToElement).Build().Perform();
                var Num2 = WaitForElementToBeVisible(CaseNumberOrder1).Text;
                Num2.Equals(CaseNum2);
            }

        }
        public void RevertDragAndDrop(string CaseNum2, string CaseNum1)
        {
            this.Pause(10);

            var Num1 = WaitForElementToBeVisible(CaseNumberOrder1).Text;
            if (Num1 == CaseNum2)
            {
                var element = WaitForElementToBeVisible(DRAG_ELEMENT);
                var ToElement = WaitForElementToBeVisible(DRAG_TO_ELEMENT);
                Actions action = new Actions(driver);
                IAction dragdrop = action.ClickAndHold(element).MoveToElement(ToElement).Release(ToElement).Build();
                dragdrop.Perform();

                var Num2 = WaitForElementToBeVisible(CaseNumberOrder1).Text;
                Num2.Equals(CaseNum1);
            }
            this.Pause(3);

        }
        public void ValidateHeader()
        {
            string MeetingHeaderDT = this.WaitForElementToBeVisible(MeetingDateHeader).Text;
            DateTime dateLink = DateTime.Now;
            dateLink = dateLink.AddDays(-1);
            string date_DD = dateLink.ToString("dd");
            string date_MM = dateLink.ToString("MMMM");
            MeetingHeaderDT.Contains(date_DD);            
            MeetingHeaderDT.Contains(date_MM);
        }
        public void ValidateMeetingOverviewPage()
        {
            this.Pause(10);
            this.WaitForElementToBeVisible(MeetingOverview).Displayed.Should().BeTrue();
        }
        public void VerifyDashboardPastMeetingSection(string header, string text)
        {
            var PastMeetingHeader = WaitForElementToBeVisible(this.PastMeetingHeader).Text;
            if (PastMeetingHeader.Equals(header))
            {
                var unexamined = WaitForElementToBeVisible(UnExaminedTextHeader).Text;
                Assert.AreEqual(unexamined, text);
            }
        }
        public void SelectCaseDisposition(string CaseDisposition)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(CaseDispostionDropDown, 2).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{CaseDisposition}']"),2).Click();
        }
        public void ToastMessageDisplayed()
        {
            WaitForElementToBeVisible(ToastMessageText).Displayed.Should().BeTrue();
            //var ToastMsg = WaitForElementToBeVisible(TOAST_MSG_TEXT, 4).Text.Trim();
            //Assert.AreEqual(ToastMsg.ToLower(), msg.ToLower());
           // this.Pause(4);
        }
        public void MouseHoverAlert()
        {
            var alert = WaitForElementToBeVisible(AlertIcon);
            Actions action = new Actions(driver);
            action.MoveToElement(alert).Build().Perform();
        }
        public void VerifyCaseStatus(string caseNum, string status)
        {
           string caseStatus = WaitForElementToBeVisible(By.XPath($"//div[@class='row epiq-appointment-341-overview-item-row with-drag-icon' and div//div[text()='{caseNum}']]//span[contains(@class,'badge badge')]")).Text;
            Assert.AreEqual(caseStatus, status);
            //this.ScrollUpToPageTop();
            //var Num = WaitForElementToBeVisible(By.XPath($"//div[2]//div[1]/div[2]/div/ul/li[2]//div[2]/div[4]//div[text()='{caseNum}']")).Text;
            //if (Num == caseNum)
            //{
            //    var CaseStatus = WaitForElementToBeVisible(CASE_STATUS).Text;
            //    Assert.AreEqual(CaseStatus, status);
            //}
        }
        public void VerifyAssetStatus(string caseNum, string status)
        {
            string caseStatus = WaitForElementToBeVisible(By.XPath($"//div[@class='row epiq-appointment-341-overview-item-row with-drag-icon' and div//div[text()='{caseNum}']]//span[contains(@class,'badge badge')]")).Text;
            Assert.AreEqual(caseStatus, status);
            //var Num = WaitForElementToBeVisible(By.XPath("//div[@class='row epiq-appointment-341-overview-item-row with-drag-icon' and div//div[text()='{caseNum}']]//span[contains(@class,'badge badge')]")).Text;

            //if (Num == caseNum)
            //{
            //    var CaseStatus = WaitForElementToBeVisible(ASSET_TEXT).Text;
            //    Assert.AreEqual(CaseStatus, status);
            //}
        }
        public void VerifyDSOCase(string caseNum,int num, string dso)
        {
            var Num = WaitForElementToBeVisible(By.XPath($"//div[1]//div[1]/div[2]/div/ul/li[1]//div[2]/div[4]//div[text()='{caseNum}']")).Text;
            if (Num == caseNum)
            {
                var dsoCase = WaitForElementToBeVisible(By.XPath("//div["+ num +"]/div[2]/div/ul/li/div/div[2]/div[10]/span")).Text;
                Assert.AreEqual(dsoCase, dso);
            }
        }
    }
}
