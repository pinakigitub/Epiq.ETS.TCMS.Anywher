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

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Case_General
{
    public class Case_General_Page : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        //CaseGeneralPage Buttons
        private By caseInfoButton = By.XPath("//div[@class='row']//h3[text()='General Info']/button");
        private By saveInfoButton = By.XPath("//div[@class='modal-content']//div[@class='modal-footer']//button[1]");
        private By cancelButton = By.XPath("//div[@class='modal-content']//div[@class='modal-footer']//button[2]");
        private By closeButton = By.XPath("//div[@class='modal-footer']/div/button");
        //Locators to verify different sections
        private By caseNumber = By.XPath("//div[@class='case-header ']/div//span[3]");
        private By debtorNamee = By.XPath("//div[@class='case-header ']/div//span[@class='case-header-data-name']");
        private By debtorAttorney = By.XPath("//div[@class='case-header-contact']/a/span/span[2]");
        private By caseStatus = By.XPath("//div[@class='onoffswitch']/label[contains(@for,'epiq-toggle-switch-caseStatus')]");
        private By caseType = By.XPath("//div[@class='onoffswitch']/label[contains(@for,'epiq-toggle-switch-assetStatus')]");
        //Notes Section Locators
        private By notesLocator = By.XPath("//div[@class='pull-right epiq-page-header-notes-link ']/button");
        private By notesCaseNum = By.XPath("//h3[strong[text()='NOTES']]/div/span[1]");
        private By notesDebtorName = By.XPath("//h3[strong[text()='NOTES']]/div/span[2]");
        private By officeNotes = By.XPath("//div[@class='epiq-case-note-types list-group']/span[1]/span[2]");
        private By trusteeNotes = By.XPath("//div[@class='epiq-case-note-types list-group']/span[2]/span[2]");
        private By form1Notes = By.XPath("//div[@class='epiq-case-note-types list-group']/span[3]/span[2]");
        private By form3Notes = By.XPath("//div[@class='epiq-case-note-types list-group']/span[4]/span[2]");
        private By meetingNotes = By.XPath("//div[@class='epiq-case-note-types list-group']/span[5]/span[2]");
        //Header Section Locators
        private By casesLink = By.XPath("//div[@class='epiq-page-header  has-case-content']/ol/li/a");
        private By caseManagement = By.XPath("//div[@class='epiq-page-header  has-case-content']/ol/li//span");
        //CaseGeneral Info Locators
        private By generalDebtorAttorney = By.XPath("//div[strong[text()='DEBTOR ATTORNEY']]/div");
        private By generalCaseStatus = By.XPath("//div[strong[text()='CASE STATUS']]/div/span");
        private By generalAssetStatus = By.XPath("//div[strong[text()='ASSET STATUS']]/div/span");
        private By generalCaseType = By.XPath("//div[strong[text()='Case Type']]/div");
        private By caseGeneralEnvelope = By.XPath("//div[strong[text()='DEBTOR ATTORNEY']]/div/a/i");
        private By caseGeneralTags = By.XPath("//div[strong[text()='Tags']]/span");

        //CaseGeneral Pariticpant Locators
        private By caseGeneralParticipant = By.XPath("//h3[text()='Participants']");
        private By participantDebtor = By.XPath("//div[strong[text()='Debtor']]");
        private By expandDebtor = By.XPath("//div[@class='panel-group']/div[1]//div[@class='row case-info-participant-header']/div[2]/div/button/i");
        private By caseGeneralParticipantsCount = By.XPath("//div[@class='case-info-participant primary panel panel-default']");
        private By phoneLink = By.XPath("//i[@class='fa fa-phone fa-2x text-info']");

        //NOTES SECTION LOCATORS

        private By addNotes = By.XPath("//div[@class='epiq-case-note-actions']//button");
        private By notesAddLabel = By.XPath("//div[@class='epiq-case-note-modify-header']");
        private By inputNotes = By.XPath("//div//iframe[@id='react-tinymce-1_ifr']");
        private By saveNote = By.XPath("//button[@type='submit'][text()='SAVE']");
        private By noteTypes = By.XPath("//div[@class='row epiq-case-note-header']//a[text()='Note Types']");
        int beforeNoteCount;
        int beforeDivCount;
        int afterDivCount;
        int afterNoteCount;
        private By oneClickNotes = By.XPath("//div[@id='mceu_24']//button");
        private By addingNote = By.XPath("//div[@class='mce-widget mce-btn mce-abs-layout-item mce-btn-has-text']//button");
        private By editSelectRecord = By.XPath("//div[@class='row epiq-case-list-notes-item']//div[2]/i");
        private By edit = By.XPath("//div[@class='epiq-case-note-actions']//button");
        private By bold = By.XPath(".//*[@id='mceu_6-button']");
        private By pageSize = By.XPath("//div[@class='epiq-paging-pagesize']//span[@class='Select-arrow']");
        private By pageCount = By.XPath("//div[@class='Select-menu-outer']//div[4]");
        private By readOnly = By.XPath("//div[@class='epiq-case-note-actions-warning']");

        private By claimsRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By filterClaimReconciliation = By.XPath("//button[contains(@title,'filters.')]");
        private By filterSchedulesTile = By.XPath("(//div[label[text()='LINKED']]//span[@class='Select-arrow-zone'])[1]");
        private By filterSchedulesTileValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterClaimsTile = By.XPath("(//div[label[text()='LINKED']]//span[@class='Select-arrow-zone'])[2]");
        private By filterClaimsTileValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By scheduleClaimRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By filterClose = By.XPath("//button[text()='CLOSE']");
        private By filterReset = By.XPath("//button[text()='RESET']");

        public Case_General_Page(IWebDriver driver) : base(driver, pageTitle)
        {
            driver.Manage().Window.Maximize();
            Console.WriteLine(driver.Manage().Window.Size);
        }
        public void CaseInfoButton()
        {
            this.Pause(4);
            WaitForElementToBeClickeable(caseInfoButton, 4).Click();
        }
        public void InputFields(List<string> inputs)
        {
            foreach (string input in inputs)
            {
                int separator = input.IndexOf('-');
                string xpathSuffix = input.Substring(0, separator);
                string value = input.Substring(separator + 1);
                // Find the element based on Label name
                By xpath = By.XPath($"//div[@class='modal-content']//div[label[text()='{xpathSuffix}']]//div[contains(@class,'searchable has-value')]/input[not(@aria-hidden='true')] | //div[label[text()='{xpathSuffix}']]//input");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 4);
                    if (control.Text.Contains("0.00") || GetAttrubuteValue(control, "type").Contains("text") || GetAttrubuteValue(control, "role").Contains("option") || GetAttrubuteValue(control, "value").Contains("0.00"))
                    {
                        this.Pause(3);
                        control.Click();
                        this.Pause(5);
                        ClearAndType(control, value);                   
                    }
                    else
                    {
                        SelectValue(control, value);
                    }
                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        private void SelectValue(IWebElement control, string value)
        {
            ScrollDown();
            MoveToViewElement(control);
            try
            {
                var a = (control.FindElement(By.XPath(".."))).FindElement(By.XPath(".."));
                if (a.TagName.ToString().Contains("span"))
                    a.FindElement(By.XPath("..")).Click();
                a.Click();
                this.WaitForElementToBePresent(By.XPath($"//div[text()='{value}']"), 2).Click();
            }
            catch (Exception e)
            {
                JSMoveToViewElement(control);
                MoveToViewElement(control);
                control.SendKeys(Keys.Enter);
                driver.FindElement(By.XPath($"//div[text()='{value}']")).Click();
            }

        }
        public void SaveInfo()
        {
            WaitForElementToBeClickeable(saveInfoButton, 4).Click();
        }
        public void FieldValues(List<string> fields)
        {
            foreach (string input in fields)
            {
                int separator = input.IndexOf('-');
                string xpathSuffix = input.Substring(0, separator);
                string value = input.Substring(separator + 1);
                // Find the element based on Label name
                By xpath = By.XPath($"//div[@class='modal-content']//div[label[text()='{xpathSuffix}']]//span[text()='{value}'] | //div[@class='modal-content']//div[label[text()='{xpathSuffix}']] //input[@value='{value}']");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 6);
                    if (GetAttrubuteValue(control, "role").Contains("option") || GetAttrubuteValue(control, "type").Contains("text"))
                    {
                        this.Pause(2);
                        var FieldText = control.Text;
                        Assert.AreEqual(FieldText, value);                        
                    }
                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        public void ClickCancel()
        {
            WaitForElementToBeClickeable(cancelButton, 2).Click();
        }
        public void ReadOnlyFields(string debtorType, string Judge, string BondAmt)
        {
            Assert.False(IsElementVisible(By.XPath($"//div[@class='modal-content']//div[label[text()='{debtorType}']]//div[contains(@class,'searchable has-value')]/input[not(@aria-hidden='true')]")));
            Assert.False(IsElementVisible(By.XPath($"//div[@class='modal-content']//div[label[text()='{Judge}']]//div[contains(@class,'searchable has-value')]/input[not(@aria-hidden='true')]")));
            Assert.False(IsElementVisible(By.XPath($"//div[@class='modal-content']//div[label[text()='{BondAmt}']] //input[not(@aria-hidden='true')]")));
        }
        public void CloseInfo()
        {
            WaitForElementToBeClickeable(closeButton).Click();
        }
        public void VerifyKeyDates(List<string> keyDates)
        {
            foreach (string Date in keyDates)
            {
                int separator = Date.IndexOf('-');
                string xpathSuffix = Date.Substring(0, separator);
                string value = Date.Substring(separator + 1);
                // Find the element based on Label name
                By xpath = By.XPath($"//div[div[text()='{xpathSuffix}']]//span[text()='{value}'] | //div[@class='well']//div[label[text()='{xpathSuffix}']]//span[text()='{value}']");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 4);
                    var MeetingDate = control.Text;

                    if (MeetingDate == value)
                    {
                        ScrollDown();
                        var Dates = control.Text;
                        Assert.AreEqual(Dates, value);                        
                    }
                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        public void VerifyCaseNum(string caseNum)
        {
            string CaseNumber = driver.FindElement(caseNumber).Text;
            Assert.AreEqual(CaseNumber.ToLower().Trim(), caseNum.ToLower().Trim());
        }
        public void VerifyDebtorName(string debtorName)
        {
            string debtor = driver.FindElement(debtorNamee).Text;
            Assert.AreEqual(debtor.ToLower().Trim(), debtorName.ToLower().Trim());
        }
        public void VerifyDebtorAttorney(string Attorney)
        {
            string debtorAttorney = driver.FindElement(this.debtorAttorney).Text;
            Assert.AreEqual(debtorAttorney.ToLower().Trim(), Attorney.ToLower().Trim());
        }
        public void VerifyCaseStatus(string status)
        {
            string statusText = WaitForElementToBeVisible(caseStatus).Text.Trim();
            if (statusText == status)
            {
                var resColor = driver.FindElement(caseStatus).GetCssValue("color");

                string[] arrColor = resColor.Split(',');
                string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

                int hexValue1 = Int32.Parse(hexValue[0]);
                hexValue[1] = hexValue[1].Trim();
                int hexValue2 = Int32.Parse(hexValue[1]);
                hexValue[2] = hexValue[2].Trim();
                int hexValue3 = Int32.Parse(hexValue[2]);

                string actualColor = string.Format("#34a01e", hexValue1, hexValue2, hexValue3);
                Assert.AreEqual("#34a01e", actualColor);
            }
        }
        public void VerifyCaseType(string type)
        {
            string statusType = WaitForElementToBeVisible(caseType).Text.Trim();
            if (statusType == type)
            {
                var resColor = driver.FindElement(caseStatus).GetCssValue("color");

                string[] arrColor = resColor.Split(',');
                string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

                int hexValue1 = Int32.Parse(hexValue[0]);
                hexValue[1] = hexValue[1].Trim();
                int hexValue2 = Int32.Parse(hexValue[1]);
                hexValue[2] = hexValue[2].Trim();
                int hexValue3 = Int32.Parse(hexValue[2]);

                string actualColor = string.Format("#e87722", hexValue1, hexValue2, hexValue3);
                Assert.AreEqual("#e87722", actualColor);
            }
        }
        public void SelectNotes()
        {
            WaitForElementToBeClickeable(notesLocator, 3).Click();
        }
        public void VerifyNotesHeader(string caseNum, string debtorNam)
        {
            var Numb = WaitForElementToBeVisible(notesCaseNum, 2);
            var Number = Numb.Text;
            string newString = Number.Remove(Number.Length - 1, 1);
            Assert.AreEqual(newString.ToLower().Trim(), caseNum.ToLower().Trim());

            var Name = WaitForElementToBeVisible(notesDebtorName, 2).Text;
            Assert.AreEqual(Name.ToLower().Trim(), debtorNam.ToLower().Trim());

        }
        public void VerifyNotesType(string office, string trustee, string form1, string form3, string meeting)
        {
            var OFFICE = WaitForElementToBeVisible(officeNotes, 2).Text;
            Assert.AreEqual(OFFICE.ToLower().Trim(), office.ToLower().Trim());
            var TRUSTEE = WaitForElementToBeVisible(trusteeNotes, 2).Text;
            Assert.AreEqual(TRUSTEE.ToLower().Trim(), trustee.ToLower().Trim());
            var FORM1 = WaitForElementToBeVisible(form1Notes, 2).Text;
            Assert.AreEqual(FORM1.ToLower().Trim(), form1.ToLower().Trim());
            var FORM3 = WaitForElementToBeVisible(form3Notes, 2).Text;
            Assert.AreEqual(FORM3.ToLower().Trim(), form3.ToLower().Trim());
            var MEETING = WaitForElementToBeVisible(meetingNotes, 2).Text;
            Assert.AreEqual(MEETING.ToLower().Trim(), meeting.ToLower().Trim());
        }
        public void VerifyNotesCount(string notetype)
        {
           string value = WaitForElementToBePresent(By.XPath("//div[@class='epiq-case-note-types list-group']//span[text()='"+ notetype + "']/preceding-sibling::span")).Text;
           beforeNoteCount = int.Parse(value);
           WaitForElementToBePresent(By.XPath("//div[@class='epiq-case-note-types list-group']//span[text()='" + notetype + "']/following-sibling::i"), 4).Click();
           Thread.Sleep(1000);
           IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
           ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", WaitForElementToBePresent(pageSize));
           Thread.Sleep(2000);
           WaitForElementToBePresent(pageSize).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", WaitForElementToBePresent(pageCount));           
            WaitForElementToBePresent(pageCount).Click();
            Thread.Sleep(4000);
            IList<IWebElement> BeforeCount = driver.FindElements(By.XPath("//div[@class='list-group']//span[@class='list-group-item']"));
           beforeDivCount = BeforeCount.Count();
           Assert.AreEqual(beforeNoteCount, beforeDivCount);
        }
        public void AddNotes(string notetype,string header)
        {
            WaitForElementToBePresent(addNotes, 3).Click();
            var actuaheader=WaitForElementToBePresent(notesAddLabel, 2).Text;
            Assert.AreEqual(actuaheader.ToLower().Trim(), header.ToLower().Trim());
            this.Pause(4);
            WaitForElementToBePresent(oneClickNotes,6).Click();
            Thread.Sleep(3000);
            WaitForElementToBePresent(addingNote).Click();
            WaitForElementToBePresent(saveNote,2).Click();
            Thread.Sleep(2000);
            IList<IWebElement> AfterCount = driver.FindElements(By.XPath("//div[@class='list-group']//span[@class='list-group-item']"));
            Thread.Sleep(1000);
            afterDivCount = AfterCount.Count();
            Assert.AreEqual(beforeDivCount + 1, afterDivCount);
            WaitForElementToBePresent(noteTypes, 2).Click();
            Thread.Sleep(3000);
            string value = WaitForElementToBePresent(By.XPath("//div[@class='epiq-case-note-types list-group']//span[text()='" + notetype + "']/preceding-sibling::span[1]")).Text;
            Thread.Sleep(4000);
            afterNoteCount = int.Parse(value);
            Assert.AreEqual(afterNoteCount, afterDivCount);
        }
        public void EditNotes(string notetype)
        {           
                WaitForElementToBePresent(By.XPath("//div[@class='epiq-case-note-types list-group']//span[text()='" + notetype + "']/following-sibling::i"), 4).Click();
                Thread.Sleep(1000);
                WaitForElementToBePresent(editSelectRecord).Click();
                Thread.Sleep(2000);
                WaitForElementToBePresent(edit, 4).Click();
                this.Pause(4);
                WaitForElementToBePresent(bold, 3).Click();
                Thread.Sleep(6000);
                WaitForElementToBePresent(oneClickNotes, 4).Click();
                Thread.Sleep(4000);
                WaitForElementToBePresent(addingNote).Click();
                WaitForElementToBePresent(saveNote, 2).Click();         
        }
        public void ViewPermission(string notetype,string text )
        {
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-case-note-types list-group']//span[text()='" + notetype + "']/following-sibling::i"), 4).Click();
            Thread.Sleep(3000);
            string actual=WaitForElementToBePresent(readOnly).Text;        
            Assert.AreEqual(actual.ToLower().Trim(),text.ToLower().Trim());                                  
        }
        public void ClickCasesLink()
        {
            WaitForElementToBeClickeable(casesLink, 8).Click();
        }
        public void CaseManagementPage(string CaseManagement)
        {
            IWebElement caseHeader = WaitForElementToBePresent(caseManagement, 4);
            string caseHeaderText = caseHeader.Text;
            StringAssert.Contains(CaseManagement, caseHeaderText);
        }
        public void GeneralInfoDebtorAttorney(string GenAttorney)
        {
            string GenDebtor = driver.FindElement(generalDebtorAttorney).Text;
            Assert.AreEqual(GenDebtor.ToLower().Trim(), GenAttorney.ToLower().Trim());
        }
        public void VerifyGeneralStatus(string status, string AssetType)
        {
            string GenCaseStat = driver.FindElement(generalCaseStatus).Text;
            Assert.AreEqual(GenCaseStat.ToLower().Trim(), status.ToLower().Trim());
            string GenAssetStat = driver.FindElement(generalAssetStatus).Text;
            Assert.AreEqual(GenAssetStat.ToLower().Trim(), AssetType.ToLower().Trim());
        }
        public void verifyCaseType(string type)
        {
            string GenCaseType = driver.FindElement(generalCaseType).Text;
            Assert.AreEqual(GenCaseType.ToLower().Trim(), type.ToLower().Trim());
        }
        public bool Envelope()
        {
            try
            {
                WaitForElementToBeVisible(caseGeneralEnvelope, 4);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void VerifyTags(string tag)
        {
            string GenTag = driver.FindElement(caseGeneralTags).Text;
            Assert.AreEqual(GenTag.ToLower().Trim(), tag.ToLower().Trim());
        }
        public void CaseGenParitcipants(string header)
        {
            string ParticipantHeader = driver.FindElement(caseGeneralParticipant).Text;
            Assert.AreEqual(ParticipantHeader.ToLower().Trim(), header.ToLower().Trim());
        }
        public void ExpandParitcipantDebtor(string participantType)
        {
           // ScrollUpToPageTop();
            IList<IWebElement> PartipantsCount = driver.FindElements(caseGeneralParticipantsCount);
            int Length = PartipantsCount.Count;

            for (int i = 1; i <= Length; i++)
            {
                string Participant = WaitForElementToBeVisible(By.XPath($"//div[@class='panel-group']/div[" + i + "]//div[strong[contains(text(),'Debtor')]]")).Text;
                if (Participant == participantType)
                {
                   // this.ScrollDown();
                    Thread.Sleep(3000);
                    this.WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + i + "]//button")).Click();
                    break;
                }
            }
        }
        public void SsnView(string ParticipantType, string ssnNo)
        {
            IList<IWebElement> PartipantsCount = driver.FindElements(caseGeneralParticipantsCount);
            int Length = PartipantsCount.Count;

            for (int i = 1; i <= Length; i++)
            {
                string Participant = WaitForElementToBeVisible(By.XPath($"//div[@class='panel-group']/div[" + i + "]//div[strong[contains(text(),'Debtor')]]")).Text;
                if (Participant == ParticipantType)
                {
                    var SsnNum = WaitForElementToBeVisible(By.XPath($"//div[@class='panel-group']/div[" + i + "]//div[strong[text()='SSN']]/div[text()]")).Text;
                    SsnNum.Equals(ssnNo);
                    this.Pause(2);
                    this.WaitForElementToBeClickeable(By.XPath("//div[@class='panel-group']/div[" + i + "]//button")).Click();
                }
            }
        }
        public void ParticipantsDetails(List<string> fields)
        {
            foreach (string details in fields)
            {
                int separator = details.IndexOf('-');
                string xpathSuffix = details.Substring(0, separator);
                string value = details.Substring(separator + 1);
                // Find the element based on Label name
                By xpath = By.XPath($"//div[strong[text()='{xpathSuffix}']]/div[text()='{value}'] | //div[strong[text()='{xpathSuffix}']]/div[pre[text()]]");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 4);
                    if (GetAttrubuteValue(control, "class").Contains("epiq-form-display-field"))
                    {
                        this.Pause(2);
                        var FieldText = control.Text;
                        Assert.AreEqual(FieldText, value);
                    }
                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        public void CaseGenParticipants(List<string> fields)
        {
            foreach (string details in fields)
            {
                int separator = details.IndexOf('-');
                string xpathSuffix = details.Substring(0, separator);
                string value = details.Substring(separator + 1);
                // Find the element based on Label name
                By xpath = By.XPath($"//div[strong[text()='{xpathSuffix}']]/following-sibling::div[div[text()]]");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 4);
                    if (GetAttrubuteValue(control, "class").Contains("col-lg-7 col-lg-offset-1 col-md-7 col-md-offset-1"))
                    {
                        this.Pause(2);
                        var FieldText = control.Text.Trim();
                        Assert.AreEqual(FieldText, value);
                    }
                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        public bool ParticipantPhoneLink(string participant)
        {
            string Participant = WaitForElementToBeVisible(By.XPath($"//div[@class='panel-group']//div[strong[contains(text(),'{participant}')]]")).Text;
            if (Participant == participant)
            {
                try
                {
                    WaitForElementToBeVisible(phoneLink, 4);
                    return true;
                }
                catch (Exception)
                {
                }
            }
            return false;
        }
        public void ClickOnUnreconciledLink(string casenum)
        {
            this.Pause(4);
            IList<IWebElement> rows = driver.FindElements(claimsRows);
            int ScheduleRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= ScheduleRows; row++)
            {
                IWebElement CaseNumber = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[2]"));
                string CaseNo = CaseNumber.Text;
                if (CaseNo == casenum)
                {
                    var Unreconciled = WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + row + "]/td[6]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", Unreconciled);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void VerifyDefaultDataInFilterOptions(string schedule, string claim)
        {
            this.Pause(3);
            IWebElement schedulesTile = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[1]"));
            string schedulesTileLinked = schedulesTile.Text;
            Assert.AreEqual(schedulesTileLinked, schedule);
            IWebElement claimsTile = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[2]"));
            string claimsTileLinked = claimsTile.Text;
            Assert.AreEqual(claimsTileLinked, claim);
            this.WaitForElementToBeClickeable(filterClose).Click();
        }
        public void VerifyDataInFilterOptionsInClaimReconciliationPage()
        {
            //Verifying data in Filter options Schedules Tile Linked
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterClaimReconciliation).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterSchedulesTile).Click();
            string[] schedulesTileLinkedUIValues = { "", "All", "Yes", "No" };
            IList<IWebElement> schedulesTileRows = driver.FindElements(filterSchedulesTileValues);
            int schedulesTileCount = schedulesTileRows.Count;
            for (int schedulesTileRow = 1; schedulesTileRow <= schedulesTileCount; schedulesTileRow++)
            {
                this.Pause(3);
                IWebElement schedulesTileValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + schedulesTileRow + "]"));
                string schedulesTileData = schedulesTileValues.Text;
                string schedulesTileUIData = schedulesTileLinkedUIValues[schedulesTileRow];
                Assert.IsTrue(schedulesTileUIData.Equals(schedulesTileData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeClickeable(filterClose).Click();
            //Verifying data in Filter options Claims Tile Linked
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterClaimReconciliation).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterClaimsTile).Click();
            string[] claimsTileUIValues = { "", "All", "Yes", "No" };
            IList<IWebElement> claimsTileRows = driver.FindElements(filterClaimsTileValues);
            int claimsTileCount = claimsTileRows.Count;
            for (int claimsTileRow = 1; claimsTileRow <= claimsTileCount; claimsTileRow++)
            {
                this.Pause(3);
                IWebElement claimsTileValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + claimsTileRow + "]"));
                string claimsTileData = claimsTileValues.Text;
                string claimsTileUIData = claimsTileUIValues[claimsTileRow];
                Assert.IsTrue(claimsTileUIData.Equals(claimsTileData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeVisible(filterClaimsTile).Click();
            this.WaitForElementToBeClickeable(filterClose).Click();
        }
        public void VerifyFilterOptions(string schedule, string claim)
        {
            this.WaitForElementToBeClickeable(filterClaimReconciliation).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterSchedulesTile).Click();
            var selectSchedulesTile = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{schedule}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", selectSchedulesTile);
            this.Pause(1);
            selectSchedulesTile.Click();
            this.WaitForElementToBeVisible(filterClaimsTile).Click();
            var selectClaimsTile = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{claim}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", selectClaimsTile);
            this.Pause(1);
            selectClaimsTile.Click();
            //After selecting data in filter, check the result grid has rows
            this.Pause(4);
            IList<IWebElement> rows = driver.FindElements(scheduleClaimRows);
            int scheduleToClaimows = rows.Count;
            Assert.Greater(scheduleToClaimows, 0);

        }
        public void ClickResetInFilterInClaimReconciliationPage()
        {
            this.WaitForElementToBeClickeable(filterReset).Click();
        }

        }
}
