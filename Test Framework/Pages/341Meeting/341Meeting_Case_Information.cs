using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using AutoIt;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages._341Meeting
{
    public class _341Meeting_Case_Information : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        private By MeetingDateFrom = By.XPath("//div[label[text()='341 DATE (FROM)']]//div/input");
        private By MeetingDateTo = By.XPath("//div[label[text()='341 DATE (TO)']]//div/input");
        private By ViewMeetingDateLink = By.XPath("//tr[1]/td[2]/a");
        private By OverviewViewLink = By.XPath("//ul/li[1]//div[2]/div[5]/a/i");
        private By JointDebtor = By.XPath("//div[@class='col-xs-2']/div[@class='epiq-overlay-button disabled']/i");
        private By DebtorAttorney = By.XPath("//div[@class='col-xs-2']/div[@class='epiq-overlay-button disabled']/i");
        private By JointDebtorAttorney = By.XPath("//div[@class='col-xs-2']/div[@class='epiq-overlay-button disabled']/i");
        private By DebtorCoCounsel = By.XPath("//div[@class='col-xs-2']/div[@class='epiq-overlay-button disabled']/i");
        private By DSOClaimantEdit = By.XPath("//div[@class='col-xs-2']/div[@class='epiq-overlay-button disabled']/i");
        private By DSOClaimantAdd = By.XPath("//div[@class='col-xs-2']/div[@class='epiq-overlay-button disabled']/i");
        private By CaseDisposition = By.XPath("//div[@class='epiq-341-text-middle']/a");
        //private By MEETING_OVERVIEW = By.XPath("//*[@role='navigation']/li/a");
        private By DebtorAttorneyName = By.XPath("//div[@class='panel-group']/div[3]//div/div[2]/div/div[2]//small");
        private By DebtorAttorneyAddButton = By.XPath("//i[@title='Add DEBTOR ATTORNEY']");
        private By JointDebtorAttorneyAddButton = By.XPath("//i[@title='Add JOINT DEBTOR ATTORNEY']");
        private By DebtorCoCounselAddButton = By.XPath("//i[@title='Add DEBTOR CO-COUNSEL']");
        private By DSOClaimantAddButton = By.XPath("//i[@title='Add DSO CLAIMANT']");
        private By DebtorCoCounselExisting = By.XPath("//label/span[text()='Existing Debtor Co-Counsel']");
        private By JointDebtorAddButton = By.XPath("//i[@title='Add JOINT DEBTOR']");
        private By DSOClaimantEditButton = By.XPath("//i[@title='Edit DSO CLAIMANT']");
        private By DebtorAttorneyEdit = By.XPath("//i[@title='Edit DEBTOR ATTORNEY']");
        private By JointDebtorAttorneyEdit = By.XPath("//i[@title='Edit JOINT DEBTOR ATTORNEY']");
        private By DebtorCoCounselEdit = By.XPath("//i[@title='Edit DEBTOR CO-COUNSEL']");
        private By HistoryColumn = By.XPath("//div[@class='epiq-appointment-341-text-middle']/i");
        private By MeetingOutcomeHeader = By.XPath("//div[@class='tab-content']/div[1]//div/h3");
        private By NDRButton = By.XPath("//div[@class='tab-content']/div[1]//div/div[1]/button");
        private By ContinuedButton = By.XPath("//div[@class='tab-content']/div[1]//div/div[2]/button");
        private By MeetingHeldButton = By.XPath("//div[@class='tab-content']/div[1]//div/div[3]/button");
        private By MeetingOutcomeConfiguration = By.XPath("//div[@class='tab-content']/div[1]//div/h3/button/i");
        private By ConfigurationHeaderText = By.XPath("//div[@class='modal-content']//h4");
        private By ToastMessageHeader = By.XPath("//div[@class='rrt-middle-container']/div[1]");
        private By ToastMessageText = By.XPath("//div[@class='rrt-middle-container']/div[2]");
        private By ContinueDate = By.XPath("//button[text()='[Continued Date]']");
        private By InputContinueDate = By.XPath("//div[@class='rdt epiq-date-picker rdtOpen']/input");
        private By ContinueTime = By.XPath("//button[text()='[Continued Time]']");
        private By InputContinueTime = By.XPath("//div[@class='Select epiq-time-picker minimum-sm Select--single is-searchable']//span//div/input");
        private By SaveChangesButton = By.XPath("//button[text()='SAVE CHANGES']");
        private By ContinuedDateDisplay = By.XPath("//a[text()='Continued']");
        private By DSODisplay = By.XPath("//a[text()='Disposition']");
        private By Debtor = By.XPath("//div[@class='panel-group']/div[1]/div[1]//div/div[2]//div/strong");
        private By JointDebtorText = By.XPath("//div[@class='panel-group']/div[2]/div[1]//div/div[2]//div/strong");
        private By DebtorAttorneyText = By.XPath("//div[@class='panel-group']/div[3]/div[1]//div/div[2]//div/strong");
        private By JointDebtorAttorneyText = By.XPath("//div[@class='panel-group']/div[4]/div[1]//div/div[2]//div/strong");
        private By DebtorCounsel = By.XPath("//div[@class='panel-group']/div[5]/div[1]//div/div[2]//div/strong");
        private By DSOClaimant = By.XPath("//div[@class='panel-group']/div[6]/div[1]//div/div[2]//div/strong");
        private By DigitalRecording = By.XPath("//div[label[text()='DIGITAL RECORDING #']]/input");
        private By CaseInformationTitle = By.XPath("//div[@class='panel-title']/span");
        private By CollapseCaseInformation = By.XPath("//div[contains(@class,'epiq-sidebar')]/button");
        private By ExpandCaseInformation = By.XPath("//div[contains(@class,'epiq-sidebar')]/button");
        private By CaseInformationBar = By.XPath("//div[contains(@class,'epiq-sidebar')]");
        private By View341MeetingBreadCrumb = By.XPath("//ol[@class='breadcrumb']/li[2]/span");
        //Meeting outcome tab
        private By DebtorAppeared = By.XPath("//span[@data-offtext='NOT APPEARED']");
        private By DebtorSSN = By.XPath("//span[@data-offtext='SSN UNVERIFIED']");
        private By DebtorId = By.XPath("//span[@data-offtext='ID UNVERIFIED']");
        private By VerificationStatus = By.XPath("//div[label[text() ='VERIFICATION STATUS']]//div//label");
        private By DebtorMeetingStatus = By.XPath("//div[span[text()='DEBTOR MEETING STATUS']]//div[2]/input");
        private By JointDebtorMeetingStatus = By.XPath("//div[span[text()='JOINT DEBTOR MEETING STATUS']]//div[2]/input");
        private By readyToggle = By.XPath("//span[@class='onoffswitch-inner-gray']");

        private By DocumentsFileUpload = By.XPath("//p[text()='UPLOAD FROM COMPUTER']");
        private By DocumentDelete = By.XPath("//td[@data-title='DOCUMENT']//span/i");
        private By ClearReport = By.XPath("//div[@class='form-group']/div//div/span[2]");
        private By ReportButton = By.XPath("//tr[1]/td[@data-title='REPORT']/div/button");
        private By ReportDropDown = By.XPath("//div[@class='form-group']//span[3]/span");
        private By SaveField = By.XPath("//button[@type='submit']");
        private By ReadyNotReady = By.XPath("html/body/div/div/main/div/div[2]/div[3]/div/div/div[2]/div/ul/li/div/div[2]/div[13]/div/div/div/label/span[1]");

        //Download 341 Meeting
        private By popUpHeader = By.XPath("//h4[@class='modal-title']");
        private By popUpParagragh = By.XPath("//div[@class='modal-body']/p");
        private By popUpDownload = By.XPath("//div[@class='modal-footer']/button[1]");
 

        public _341Meeting_Case_Information(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        public void VerifyVerficationStatus()
        {
            this.ScrollDown();
            this.Pause(2);
            WaitForElementToBeVisible(VerificationStatus, 2).Click();
           
        }
        public void VerifyDebtorVerficationSection()
        {
            this.ScrollDown();
            bool toggle1 = this.WaitForElementToBeVisible(DebtorAppeared).Enabled;
            Assert.IsTrue(toggle1);
            bool toggle2 = this.WaitForElementToBeVisible(DebtorId).Enabled;
            Assert.IsTrue(toggle2);
            bool toggle3 = WaitForElementToBeVisible(DebtorSSN).Enabled;
            Assert.IsTrue(toggle3);
        }

        public void ValidateToggleButton()
        {
            string beforeVerfication = WaitForElementToBeVisible(VerificationStatus).GetProperty("data-offtext");
            StringAssert.Contains(beforeVerfication, "NOT EXAMINED");
            this.WaitForElementToBeVisible(VerificationStatus).Click();
            string afterVerfication = WaitForElementToBeVisible(VerificationStatus).GetProperty("data-ontext");
            StringAssert.Contains(beforeVerfication, "EXAMINED");
            string beforeAppeared = WaitForElementToBeVisible(DebtorAppeared).GetProperty("data-offtext");
            StringAssert.Contains(beforeAppeared, "NOT APPEARED");
            this.WaitForElementToBeVisible(DebtorAppeared).Click();
            string afterAppeared = WaitForElementToBeVisible(DebtorAppeared).GetProperty("data-ontext");
            StringAssert.Contains(afterAppeared, "APPEARED");
            string beforeIDVerfried = WaitForElementToBeVisible(DebtorId).GetProperty("data-offtext");
            StringAssert.Contains(beforeAppeared, "ID UNVERIFIED");
            this.WaitForElementToBeVisible(DebtorId).Click();
            string afterIDVerfried = WaitForElementToBeVisible(DebtorId).GetProperty("data-ontext");
            StringAssert.Contains(afterAppeared, "ID VERIFIED");
            string beforeSSN = WaitForElementToBeVisible(DebtorSSN).GetProperty("data-offtext");
            StringAssert.Contains(beforeAppeared, "SSN UNVERIFIED");
            this.WaitForElementToBeVisible(DebtorSSN).Click();
            string afterSSN = WaitForElementToBeVisible(DebtorSSN).GetProperty("data-ontext");
            StringAssert.Contains(afterAppeared, "SSN VERIFIED");
        }

        public void ValidateReadyToggleButton()
        {
            string beforeAttribute = driver.FindElement(readyToggle).GetAttribute("data-offtext");
            Assert.AreEqual(beforeAttribute, "NOT READY");
            var e = driver.FindElement(readyToggle);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
            string afterAttribute = driver.FindElement(readyToggle).GetAttribute("data-ontext");
            Assert.AreEqual(afterAttribute, "READY");
        }
        public void MouseHoverOnReadyToggleButton()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(readyToggle)).ClickAndHold();
            this.PressEscapeKey();
        }

        public void SelectDebtorMeetingStatus(string debtorMettingStatus)
        {
            IWebElement element = driver.FindElement(DebtorMeetingStatus);
            element.SendKeys(debtorMettingStatus);
            element.SendKeys(Keys.Down);
            element.SendKeys(Keys.Enter);
        }

        public void SelectJointDebtorMeetingStatus(string jointDebtorMettingStatus)
        {
            IWebElement element = driver.FindElement(JointDebtorMeetingStatus);
            element.SendKeys(jointDebtorMettingStatus);
            element.SendKeys(Keys.Down);
            element.SendKeys(Keys.Enter);
        }
        public void CurrentDates()
        {
            this.WaitForElementToBeVisible(MeetingDateFrom).SendKeys(DateTime.Now.ToShortDateString());
            this.Pause(3);
            this.WaitForElementToBeVisible(MeetingDateTo,3).SendKeys(DateTime.Now.ToShortDateString());
            this.Pause(3);
        }

        public void PreviousDates()
        {
            this.WaitForElementToBeVisible(MeetingDateFrom).SendKeys(DateTime.Today.AddDays(-1).ToShortDateString());
            this.Pause(3);
            this.WaitForElementToBeVisible(MeetingDateTo).SendKeys(DateTime.Today.AddDays(-1).ToShortDateString());
        }
        public void ClickOnEditJointDebtorAttorney()
        {
            WaitForElementToBeClickeable(JointDebtorAttorneyEdit, 3).Click();
        }
        public void ClickOnEditDebtorAttorney()
        {
            WaitForElementToBeClickeable(DebtorAttorneyEdit, 3).Click();
        }
        public void ClickOnEditDebtorCoCounsel()
        {
            WaitForElementToBeClickeable(DebtorCoCounselEdit, 3).Click();
        }
        public bool ValidateDebtorAttorneyName()
        {
            return this.WaitForElementToBeVisible(DebtorAttorneyName).Text.Contains("DA: Anil, Jhansi Rani");
        }
        public void ClickOnHistoryColumn()
        {
            this.Pause(5);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(HistoryColumn)).Perform();
            this.Pause(3);
            this.PressEscapeKey();
        }
        public void EnterTheContinuedDetails()
        {
            var dates = DateTime.Today.AddDays(+1).ToShortDateString();
            var times = DateTime.Today.ToShortTimeString();
            this.Pause(3);
            this.WaitForElementToBeVisible(ContinueDate).Click();
            this.WaitForElementToBeVisible(InputContinueDate, 2).SendKeys(dates);
            this.WaitForElementToBeVisible(InputContinueTime, 2).SendKeys(times);
            this.WaitForElementToBeClickeable(SaveChangesButton).Click();
        }
        public bool DisplayDetails()
        {
            this.WaitForElementToBeVisible(ContinuedDateDisplay).Text.Contains("Continued");
            return this.WaitForElementToBeVisible(DSODisplay).Text.Contains("Disposition");
        }
        public void ClickOnViewLink()
        {
            WaitForElementToBeClickeable(ViewMeetingDateLink, 7).Click();
        }

        public void ClickOnEditDSOClaimantPencil()
        {
            this.ScrollDown();
            WaitForElementToBeClickeable(DSOClaimantEditButton, 3).Click();
        }
        public void SelectType(string header, string type)
        {
            this.Pause(3);
            WaitForElementToBeClickeable(By.XPath($"//div[label[text()='{header}']]/div")).Click();
            Thread.Sleep(1000);
            var dr = WaitForElementToBeClickeable(By.XPath($"//div[text()='{type}']"),5);
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", dr);
            dr.Click();
        }
        public void Inputdropdownfieldsdatas(string obligation, string state, string initialnotice, string disnotice)
        {
            if (!string.IsNullOrEmpty(obligation))
            {
                this.Pause(2);
                IWebElement element = driver.FindElement(By.XPath("//div[label[text()='OBLIGATION']]/div/div/span//input"));
                element.SendKeys(obligation);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Enter);
            }
            if (!string.IsNullOrEmpty(state))
            {
                this.Pause(2);
                IWebElement element = driver.FindElement(By.XPath("//div[label[text()='DSEA STATE']]/div/div/span//input"));
                element.SendKeys(state);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Enter);
            }
            if (!string.IsNullOrEmpty(initialnotice))
            {
                this.Pause(2);
                IWebElement element = driver.FindElement(By.XPath("//div[label[text()='ASSIGN TASK FOR INITIAL NOTICE']]/div/div/span//input"));
                element.SendKeys(initialnotice);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Enter);
            }
            if (!string.IsNullOrEmpty(disnotice))
            {
                this.Pause(2);
                IWebElement element = driver.FindElement(By.XPath("//div[label[text()='ASSIGN TASK FOR DISCHARGE NOTICE']]/div/div/span//input"));
                element.SendKeys(disnotice);
                element.SendKeys(Keys.Down);
                element.SendKeys(Keys.Enter);
            }
        }
        public void VerifyDefaultValues(string header, string value)
        {
            var defaultValue = WaitForElementToBeVisible(By.XPath($"//div[label[text()='{header}']]//span/div/span")).Text;
            Assert.IsTrue(defaultValue.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
        public void VerifyValues(string caseNumber, string disposition)
        {
            var number = WaitForElementToBeVisible(By.XPath($"//div[text()='{caseNumber}']")).Text;
            if (number == caseNumber)
            {
                var caseDispostion = WaitForElementToBeVisible(CaseDisposition).Text;
                Assert.IsTrue(disposition.Equals(caseDispostion, StringComparison.OrdinalIgnoreCase));
            }
        }
        public void EnterDetorAttorney(string header, string debtorAttorney)
        {
            ClearAndType(WaitForElementToBeVisible(By.XPath($"//div[label[text()='{header}']]/input")), debtorAttorney);
        }
        public void VerifyDetorAttorney(string caseNumber, string debtorAttorney)
        {
            var number = WaitForElementToBeVisible(By.XPath($"//div[text()='{caseNumber}']")).Text;
            if (number == caseNumber)
            {
                var attorney = WaitForElementToBeVisible(By.XPath($"//span[text()='{debtorAttorney}']")).Text;
                Assert.IsTrue(debtorAttorney.Contains(attorney));
            }
        }
        public void ClearField(string header)
        {
            WaitForElementToBeClickeable(By.XPath($"//div[label[text()='{header}']]//span[2]/span")).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[label[text()='{header}']]//span/div[1]"), 2).Click();
        }
        public void ClickOnViewOverviewLink()
        {
            this.Pause(5);
            WaitForElementToBeClickeable(OverviewViewLink, 3).Click();
        }
        public void ClickOnJointDebtorButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(JointDebtor).Click();
            this.PressEscapeKey();
        }
        public void ClickOnDebtorAttorneyButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(DebtorAttorney).Click();
            this.PressEscapeKey();
        }
        public void ClickOnReadyNotReadyButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(ReadyNotReady).Click();
            this.PressEscapeKey();
        }
        public void ClickOnJointDebtorAttorneyButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(JointDebtorAttorney).Click();
            this.PressEscapeKey();
        }
        public void ClickOnDebtorCoCounselButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(DebtorCoCounsel).Click();
            this.PressEscapeKey();
        }
        public void ClickOnDSOClaimantEditButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(DSOClaimantEdit).Click();
            this.PressEscapeKey();
        }
        public void ClickOnDSOClaimantAddButton()
        {
            ScrollDown();
            WaitForElementToBeClickeable(DSOClaimantAdd).Click();
            this.PressEscapeKey();
        }
        public void ClickOnAddDebtorAttorney()
        {
            ScrollDown();
            WaitForElementToBeClickeable(DebtorAttorneyAddButton).Click();
        }
        public void ClickOnAddJointDebtorAttorney()
        {
            ScrollDown();
            WaitForElementToBeClickeable(JointDebtorAttorneyAddButton).Click();
        }
        public void ClickOnAddDebtorCoCounsel()
        {
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(DebtorCoCounselAddButton).Click();
        }
        public void ClickOnAddDsoClaimant()
        {
            ScrollDown();
            WaitForElementToBeClickeable(DSOClaimantAddButton, 3).Click();
        }
        public void ClickOnExistingDebtorCoCounsel()
        {
            ScrollWindowBy(341, 9);
            WaitForElementToBeClickeable(DebtorCoCounselExisting).Click();
        }
        public void SelectExistingDebtorCoCounsel(string DebtorCocounsel)
        {
            Pause(2);
            TypeIn(WaitForElementToBeVisible(By.XPath("//div[label[text()='SEARCH DEBTOR CO-COUNSELS']]/div/div[1]")), DebtorCocounsel);
            WaitForElementToBeClickeable(By.XPath("//a[@class='dropdown-item']"), 2).Click();
        }
        public void ClickOnSaveButton()
        {
            var saveButton = driver.FindElement(By.XPath($"//button[text()='SAVE']"));
            saveButton.Click();
        }
        public void ClickOnAddJointDebtor()
        {
            ScrollDown();
            WaitForElementToBeClickeable(JointDebtorAddButton).Click();
        }
        public void ClickView(int index)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(By.XPath("//div[1]/div[2]/div/ul/li[" + index + "]/div/div[2]/div[2]/div/div[1]/a"), 2).Click();
        }
        public void HeaderMeetingOutcome(string header)
        {
            var headerTitle = WaitForElementToBeVisible(MeetingOutcomeHeader).Text;
            Assert.IsTrue(header.Equals(headerTitle, StringComparison.OrdinalIgnoreCase));
        }
        public void VerifyButtonsAsDisabled()
        {
            bool ndr = WaitForElementToBeVisible(NDRButton).Enabled;
            Assert.IsFalse(ndr);
            bool continued = WaitForElementToBeVisible(ContinuedButton).Enabled;
            Assert.IsFalse(continued);
            bool meeting = WaitForElementToBeVisible(MeetingHeldButton).Enabled;
            Assert.IsFalse(meeting);
        }
        public void VerifyButtonsAreEnabled()
        {
            bool ndr = WaitForElementToBeVisible(NDRButton).Displayed;
            Assert.IsTrue(ndr);
            bool continued = WaitForElementToBeVisible(ContinuedButton).Displayed;
            Assert.IsTrue(continued);
            bool meeting = WaitForElementToBeVisible(MeetingHeldButton).Displayed;
            Assert.IsTrue(meeting);
        }
        public void MeetingOutComeConfigurations()
        {
            this.Pause(2);
            WaitForElementToBeClickeable(MeetingOutcomeConfiguration).Click();
        }
        public void ConfigurationHeader(string header)
        {
            var configurationHeader = WaitForElementToBeVisible(ConfigurationHeaderText).Text;
            Assert.IsTrue(configurationHeader.Equals(header, StringComparison.OrdinalIgnoreCase));
        }
        public void SelectNDRSettings(string ndrOption)
        {
            WaitForElementToBeClickeable(By.XPath($"//form//div[1]/div/div/div/label/span[contains(text(),'{ndrOption}')]"), 2).Click();
        }
        public void SelectContinueSetting(string continueOption)
        {
            WaitForElementToBeClickeable(By.XPath($"//form//div[2]/div/div/div/label/span[contains(text(),'{continueOption}')]"), 2).Click();
        }
        public void SelectMeetingSettings(string meetingOption)
        {
            WaitForElementToBeClickeable(By.XPath($"//form//div[3]/div/div/div/label/span[contains(text(),'{meetingOption}')]"), 2).Click();
        }
        public void VerifyToastMessage(string button, string header, string message)
        {
            this.Pause(4);
            WaitForElementToBeClickeable(By.XPath($"//button[text()='{button}']"), 3).Click();
            var toastMessageHeader = WaitForElementToBeVisible(ToastMessageHeader, 4).Text;
            Assert.IsTrue(toastMessageHeader.Equals(header, StringComparison.OrdinalIgnoreCase));

            var toastMessage = WaitForElementToBeVisible(ToastMessageText, 4).Text;
            Assert.IsTrue(toastMessage.Equals(message, StringComparison.OrdinalIgnoreCase));
            this.Pause(4);
        }
        public void VerifyEditIcon(string name, int number)
        {
            try
            {
                var Debtor = WaitForElementToBeVisible(By.XPath($"//div[contains(@class,'larger-text')]/strong[text()='{name}']")).Text;
                if (Debtor == name)
                {
                    var element = WaitForElementToBeVisible(By.XPath("//div[" + number + "]/div[1]/div/div/div[3]/a/i")).Displayed;
                    Assert.IsTrue(element);
                }
            }
            catch (Exception)
            {
            }
        }
        public void ClickPencilIcon(string name, int number)
        {
            var Debtor = WaitForElementToBeVisible(By.XPath($"//div[contains(@class,'larger-text')]/strong[text()='{name}']")).Text;
            if (Debtor == name)
            {
                WaitForElementToBeVisible(By.XPath("//div[" + number + "]/div[1]/div/div/div[3]/a/i")).Click();
            }
        }
        public string PageHeader
        {
            get
            {
                return this.WaitForElementToBeVisible(View341MeetingBreadCrumb).Text.TrimStart().TrimEnd();
            }
        }
        public bool CaseInformation()
        {
            return WaitForElementToBeVisible(CaseInformationBar).Displayed;
        }
        public void CloseCaseInformation()
        {
            WaitForElementToBeClickeable(CollapseCaseInformation).Click();
        }
        public void CaseInformationSection()
        {
            var CaseInfo = WaitForElementToBeVisible(CaseInformationBar).Enabled;
            Assert.IsFalse(CaseInfo);
        }
        public void OpenCaseInformation()
        {
            WaitForElementToBeClickeable(ExpandCaseInformation).Click();
        }
        public void EnterText(string text)
        {
            this.Pause(2);
            ClearAndType(WaitForElementToBeVisible(DigitalRecording), text);
            WaitForElementToBeClickeable(CaseInformationTitle).Click();
        }
        public void VerifyDigitalRecordingText(string text)
        {
            var recordedText = WaitForElementToBeVisible(DigitalRecording).GetAttribute("value");
            Assert.IsTrue(recordedText.Equals(text, StringComparison.OrdinalIgnoreCase));
        }
        public void VerifyCaseInfo(string debtor, string jointDebtor, string debtorAttorney, string jointDebtorAttorney, string debtorCoCounsel, string Claimant)
        {
            var debtorDetails = WaitForElementToBeVisible(Debtor).Text;
            Assert.IsTrue(debtorDetails.Equals(debtor, StringComparison.OrdinalIgnoreCase));
            var jointDebtorDetails = WaitForElementToBeVisible(JointDebtorText).Text;
            Assert.IsTrue(jointDebtorDetails.Equals(jointDebtor, StringComparison.OrdinalIgnoreCase));
            var debtorAttorneyDetails = WaitForElementToBeVisible(DebtorAttorneyText).Text;
            Assert.IsTrue(debtorAttorneyDetails.Equals(debtorAttorney, StringComparison.OrdinalIgnoreCase));
            var jointDebtorAttorneyDetails = WaitForElementToBeVisible(JointDebtorAttorneyText).Text;
            Assert.IsTrue(jointDebtorAttorneyDetails.Equals(jointDebtorAttorney, StringComparison.OrdinalIgnoreCase));
            var debtorCounsel = WaitForElementToBeVisible(DebtorCounsel).Text;
            Assert.IsTrue(debtorCounsel.Equals(debtorCoCounsel, StringComparison.OrdinalIgnoreCase));
            var dsoClaimant = WaitForElementToBeVisible(DSOClaimant).Text;
            Assert.IsTrue(dsoClaimant.Equals(Claimant, StringComparison.OrdinalIgnoreCase));
        }
        public void VerifyDetails(string designation, int index, string name)
        {
            var designationDetails = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[1]//div/div[2]//div/strong")).Text;
            if (designationDetails == designation)
            {
                var names = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[1]//div/div[2]//div/small")).Text;
                Assert.IsTrue(names.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
        }
        public void VerifyNameSsnId(int index, string designation, string name, string ssn, string id)
        {
            ScrollDown();
            WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[1]/div/div/div[1]/div/i")).Click();

            var designationDetails = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[1]//div/div[2]//div/strong")).Text;
            if (designationDetails == designation)
            {
                var names = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[2]/div/div/div[1]/div")).Text;
                Assert.IsTrue(names.Equals(name, StringComparison.OrdinalIgnoreCase));
                var ssnNumber = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[2]/div/div/div[2]/div[1]/div[2]//button/div")).Text;
                Assert.IsTrue(ssnNumber.Equals(ssn, StringComparison.OrdinalIgnoreCase));
                var idNumber = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[2]/div/div/div[2]/div[2]/div[2]//button/div")).Text;
                Assert.IsTrue(idNumber.Equals(id, StringComparison.OrdinalIgnoreCase));
            }
            WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + index + "]/div[1]/div/div/div[1]/div/i")).Click();
        }
        public void VerifyContactInfoAndEmployeeInfo(int num, string designation, int i, string address, string phone, string email, string information)
        {
            this.Pause(4);

            WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[1]/div/div/div[1]/div/i")).Click();

            var Debtor = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[1]//div/div[2]//div/strong")).Text;
            if (Debtor == designation)
            {
                var addressDetails = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[2]/div/div/div[" + i + "]/div/pre"));
                var text = addressDetails.Text;
                var details = text.Replace(Environment.NewLine, " ");
                Assert.IsTrue(details.Equals(address, StringComparison.OrdinalIgnoreCase));
                var phoneNumber = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[2]/div/div/div[" + (i + 1) + "]/div[text()]")).Text;
                Assert.IsTrue(phoneNumber.Equals(phone, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrEmpty(email))
                {
                    var emailDetails = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[2]/div/div/div[" + (i + 2) + "]/div")).Text;
                    Assert.IsTrue(emailDetails.Equals(email, StringComparison.OrdinalIgnoreCase));
                }
                if (!string.IsNullOrEmpty(information))
                {
                    var employeeInformation = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[2]/div/div/div[8]/div[3]")).Text;
                    Assert.IsTrue(employeeInformation.Equals(information, StringComparison.OrdinalIgnoreCase));
                }
                WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + num + "]/div[1]/div/div/div[1]/div/i")).Click();
            }
        }
        public void VerifySSNView(int number, string designation, string ssn)
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + number + "]/div[1]/div/div/div[1]/div/i")).Click();
            var debtor = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + number + "]/div[1]//div/div[2]//div/strong")).Text;
            if (debtor == designation)
            {
                var ssnNumber = WaitForElementToBeVisible(By.XPath("//div[@class='panel-group']/div[" + number + "]/div[2]/div/div/div[2]/div[1]/div[2]/div")).Text;
                Assert.IsTrue(ssnNumber.Equals(ssn, StringComparison.OrdinalIgnoreCase));
            }
        }
        public void SelectUploadDocument(string uploadLink)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(By.XPath($"//tr[1]//a[text()='{uploadLink}']"), 5).Click();
        }
        public void CaseDetails(string details)
        {
            var debtorDetails = WaitForElementToBeVisible(By.XPath("//div[@class='modal-content']/form/div/div/div/div/div[1]")).Text;
            Assert.IsTrue(debtorDetails.Equals(details, StringComparison.OrdinalIgnoreCase));
        }
        public void UploadDocument()
        {
            this.Pause(3);
            IWebElement s1 = driver.FindElement(DocumentsFileUpload);
            s1.Click();
            AutoItX.WinWaitActive("Open");
            AutoItX.Send("Test.pdf");
            AutoItX.Send("{ENTER}");
            this.Pause(3);
        }
        public void DeleteUploadedDocument()
        {
            WaitForElementToBeClickeable(DocumentDelete, 3).Click();
        }
        public void VerifyUploadingSecondDocument()
        {
            Assert.IsFalse(IsElementVisible(By.XPath($"//tr[1]//a[text()='UPLOAD DOCUMENT']")));
        }
        public void SelectReportType(string reportType)
        {
            if (IsElementVisible(By.XPath($"//tr[1]/td[@data-title='REPORT']/div/button[text()='{reportType}']")))
            {
                WaitForElementToBeClickeable(ReportButton, 2).Click();
                WaitForElementToBeClickeable(ClearReport, 2).Click();   
               WaitForElementToBeClickeable(ReportDropDown, 2).Click();
               WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{reportType}']"), 2).Click();
                WaitForElementToBeClickeable(SaveField, 2).Click();
            }
            else
            {
                WaitForElementToBeClickeable(ReportButton, 2).Click();
                WaitForElementToBeClickeable(ReportDropDown, 2).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/divdiv[text()='{reportType}']"), 2).Click();
                WaitForElementToBeClickeable(SaveField, 2).Click();
            }
        }
        public void SaveConfigurations()
        {
            WaitForElementToBeClickeable(By.XPath("//form/div[2]/div/button[@class='btn btn-info']"), 2).Click();
        }
        public void VerifyConfigurationOption(string configurationHeader, string options)
        {
            var header = WaitForElementToBeVisible(By.XPath($"//h3[contains(text(),'{configurationHeader}')]")).Text;
            bool isFound = false;
            if (configurationHeader == header)
            {
                var section = driver.FindElement(By.XPath($"//div[h3[text()='{configurationHeader}']]/div[1]/div/div[1]//label//span|//div[h3[text()='{configurationHeader}']]/div[3]/div/div[1]//label//span")).Text;
                isFound = true;
                Assert.IsTrue(section.Equals(options, StringComparison.OrdinalIgnoreCase));
            }
            Assert.IsTrue(isFound);
        }

        public void VerifyPopupHeader(string header)
        {
            this.Pause(3);
            string popUpHeaderText = WaitForElementToBeVisible(popUpHeader).Text;
            Assert.IsTrue(popUpHeaderText.Equals(header, StringComparison.OrdinalIgnoreCase));
        }

        public void VerifyPopUpParagragh()
        {
            string actual = "Do you want to continue?";
            string paragraph = this.WaitForElementToBeVisible(popUpParagragh).Text;
            Assert.IsTrue(paragraph.Equals(actual, StringComparison.OrdinalIgnoreCase));
        }

        public void VerifyToastTitle(string title)
        {
            this.Pause(2);
            string toast = this.WaitForElementToBeVisible(ToastMessageHeader).Text;
            Assert.IsFalse(toast.Equals(title, StringComparison.OrdinalIgnoreCase));
            this.Pause(4);
        }
        public void ClickOnPopUpDownload()
        {
            this.WaitForElementToBeClickeable(popUpDownload).Click();
          
        }

        public void SelectSortBy(string value)
        {
            this.WaitForElementToBeClickeable(By.XPath("//div[span[text()= 'SORT BY']]//div[@class='Select-control']//input")).SendKeys(value);
            this.Pause(2);
       
        }
    }
}
