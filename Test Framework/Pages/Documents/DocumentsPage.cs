using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using System.Data;
using FluentAssertions;
using System.Threading;
using AutoIt;
using System;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Documents
{
    public class DocumentsPage : UnityPageBase
    {
        private By documentsPageHeader = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[2]/div/h2");
        private By documentsPageFilterOption = By.XPath("//button[@title='View and change current filters.']");
        private By documentspageFilterClose = By.XPath("//button[text()='CLOSE']");
        private By documentsPageBreadcrumb = By.XPath("//*[@role='navigation']/li");
        private By documentsPageHeaderNames = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By documentsPageFilterOptions = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[2]/h3");
        private By documentsPageCaseStatus = By.XPath("//tr[@class='epiq-table-details-row']//div[text()='CASE #']");
        private By documentsPageTrustee = By.XPath("//tr[@class='epiq-table-details-row']//div[3]//div[text()='TRUSTEE']");
        private By documentsPageDistrict = By.XPath("//tr[@class='epiq-table-details-row']//div[4]//div[text()='DISTRICT']");
        private By documentsPageCaseType = By.XPath("//tr[@class='epiq-table-details-row']//div[5]//div[text()='CASE TYPE']");
        private By documentsPageAssetStatus = By.XPath("//tr[@class='epiq-table-details-row']//div[6]//div[text()='ASSET STATUS']");
        private By documentsPageFileName = By.XPath("//tr[@class='epiq-table-details-row']//div[7]//div[text()='FILE NAME']");
        private By documentsPageRowExpandButton = By.XPath("//td[1]//i");
        private By documentsPageFilterOptionsCaseORDebtor = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//input[@class='rbt-input-hint']");
        private By caseStatusLocator = By.XPath("//div[@class='row']//div[label[text()='CASE STATUS']]//div[@class='Select-value']");

        private By caseTableRowsLocator = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By documentsPageCaseNumber = By.XPath("//tr[@class='epiq-table-details-row']//div[text()='CASE #']");
        private By documentsPageCurrent341Date = By.XPath("//tr[@class='epiq-table-details-row']//div[text()='CURRENT 341 DATE']");
        private By documentsPageHistory = By.XPath("//tr[@class='epiq-table-details-row']//div[text()='HISTORY']");

        //private By DOCUMENTS_PAGE_FILTEROPTIONS_CaseOrDebtor = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//div[@class='rbt-input-wrapper']//div[2]//input");
        private By documentsPageFilterOptionsCaseORDebtorSelection = By.XPath("//div[label[contains(text(),'DEBTOR NAME')]]//li/a/span");
        private By documentsPageFilterOptionsDateFiledFrom = By.XPath("//div[label[contains(text(),'DATE FILED (FROM)')]]//input[@class='form-control']");
        private By documentsPageFilterOptionsDateFiledTo = By.XPath("//div[label[contains(text(),'DATE FILED (TO)')]]//input[@class='form-control']");
        private By documentsFilterCaseStatusX = By.XPath("//div[label[text()='CASE STATUS']]//div[@class='Select-control']//span[2]/span[@class='Select-clear']");
        private By documentsFilterCaseStatusDrpdn = By.XPath("//div[label[text()='CASE STATUS']]//div[@class='Select-control']//span/div[1]");
        private By documentsFilterResetButton = By.XPath("//button[text()='RESET']");
        private By tagLocator = By.XPath("//div[@class='row']//div[label[text()='TAG']]//div[@class='Select-control']/span/div[1]");

        // Add new document
        private By documentsAddNewDocuments = By.XPath("//button[text()=' Document']");
        private By documentsCaseDebtorSelection = By.XPath("html/body/div[2]/div[2]/div/div/form/div[1]/div[1]/div/div/div[1]/div/div/div[1]/input");
        private By documentsFileUpload = By.XPath("//p[text()='UPLOAD FROM COMPUTER']");
        private By windowUpload = By.XPath("//input[@type='file']");
        private By documentsSaveNewDocuments = By.XPath("html/body/div[2]/div[2]/div/div/form/div[2]/div/button[1]");
        private By documentsPageFilterOptionsCaseORDebtorSelections = By.XPath("//a[@class='dropdown-item']/span");
        private By caseDebtorNameLocator = By.XPath("//div[@class='modal-content']//form/div/div//div[label[text()='CASE # / DEBTOR NAME']]/div/div[1]");
        private By caseDebtorNameSelection = By.XPath("//a[@class='dropdown-item']");
        private By deleteButton = By.XPath("//div[@class='epiq-button-group-separator']/button");

       // private By TAGS_LOCATOR = By.XPath("//div[@class='form-group']//div[@class='Select-control']");
       // private By TAG1_LOCATOR = By.XPath("//div[@class='Select-menu-outer']//div[text()='341 Meeting']");
       // private By TAG2_LOCATOR = By.XPath("//div[@class='Select-menu-outer']//div[text()='Batch Tag QA Test']");
        private By clearTags = By.XPath("//div[@class='popover-content']//div[@class='Select-control']//span[@title='Clear all']/span");
        private By tagsPresent = By.XPath("//div[@class='form-group']//div[@class='Select-control']//span[@aria-selected ='true']");
        private By tagsSubmit = By.XPath("//button[@type='submit']");
        private By warningMsg = By.XPath("//div[@class='epiq-security-container panel']//div[@class='col-xs-10 epiq-security-warning-message']");
        private By contactText = By.XPath("//div[@class='epiq-security-contact']/strong");
        private By contactTextBox = By.XPath("//div[strong[text()='Contact Office Administrator']]/div[1]/div");
        private By adminName = By.XPath("//div[@class='epiq-security-contact-details well']/div/div[1]");
        private By emailAddress = By.XPath("//div[@class='epiq-security-contact-details well']/div/div[2]/a");
        private By inlineSubmitLocator = By.XPath("//div[@class='popover-content']//button[@class='btn btn-info']");
        private By tagOneLocator = By.XPath("//div[@class='form-group']//div[@class='Select-control']/span/div[1]");
        //Document Viewer Locators
        private By documentsHeaderLocator = By.XPath("//div[@class='panel-heading']//div[contains(@class,'document-info epiq-cursor-pointer')]");
        private By documentFileNameEditLocator = By.XPath("//div[Label[text()='FILE NAME']]//button");
        private By documentDescriptionEditLocator = By.XPath("//div[label[text()='DESCRIPTION']]//button");
        private By documentAssignedToEditLocator = By.XPath("//div[label[text()='ASSIGNED TO']]//button");
        private By documentDocEditLocator = By.XPath("//div[@class='row']//div[5]//button");
        private By documentSourceEditLocator = By.XPath("//div[label[text()='SOURCE']]//button");
        private By documentTagsEditLocator = By.XPath("//div[label[text()='TAGS']]//button");
        private By tagOneExistingDelete = By.XPath("(//div[@class='Select-value']/span[text()='×'])[1]");
        private By tagTwoExistingDelete = By.XPath("(//div[@class='Select-value']/span[text()='×'])[1]");
        private By tagThreeExistingDelete = By.XPath("(//div[@class='Select-value']/span[text()='×'])[1]");

        public DocumentsPage(IWebDriver driver) : base(driver, "UNITY")
        {
        }

        public string GetHeaderName()
        {
            return this.WaitForElementToBeVisible(documentsPageHeader).Text;
        }

        public void ClickOnFilter()
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(documentsPageFilterOption).Click();
        }

        public void ClickOnFilterClose()
        {
            this.WaitForElementToBeVisible(documentspageFilterClose).Click();
            Pause(1);
        }
        public string GetFilterOptionHeader()
        {
            try
            {
                Pause(1);
                return driver.FindElement(documentsPageFilterOptions).Text;
            }
            catch
            {
                return null;
            }

        }

        public void clickOnRowExpandButton()
        {
            Thread.Sleep(3000);
            IList<IWebElement> RowExpandButton = this.WaitForElementsToBeVisible(documentsPageRowExpandButton).ToList();
            RowExpandButton[0].Click();
        }
        public bool GetCaseStatusDisplayed()
        {
            this.Pause(10);
            return driver.FindElement(documentsPageCaseStatus).Displayed;
        }
        public bool GetTrusteeDisplayed()
        {
            return driver.FindElement(documentsPageTrustee).Displayed;
        }
        public bool GetDistrictDisplayed()
        {
            return driver.FindElement(documentsPageDistrict).Displayed;
        }

        public bool GetCaseTypeDisplayed()
        {
            return driver.FindElement(documentsPageCaseType).Displayed;
        }
        public bool GetAssetStatusDisplayed()
        {
            return driver.FindElement(documentsPageAssetStatus).Displayed;
        }
        public bool GetFileNameDisplayed()
        {
            return driver.FindElement(documentsPageFileName).Displayed;
        }
        public void EnterCaseNumber(string caseNumber)
        {
            this.WaitForElementToBeVisible(documentsPageFilterOptionsCaseORDebtor).SendKeys(caseNumber);
            this.WaitForElementToBeVisible(documentsPageFilterOptionsCaseORDebtorSelection).Displayed.Should().BeTrue();
            var selectCaseORDebtor = this.WaitForElementToBeVisible(documentsPageFilterOptionsCaseORDebtorSelection);
            MoveToElementAndClick(selectCaseORDebtor, 1095, 195);
        }

        public DataTable GetDocumentsRecords(string sortColumn = null)
        {

            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";

            if (!string.IsNullOrEmpty(sortColumn))
                driver.FindElements(documentsPageHeaderNames).Where(e => e.Text.Contains(sortColumn.ToUpper())).FirstOrDefault().Click();

            var headerNames = driver.FindElements(documentsPageHeaderNames).Select(e => e.Text.Trim()).ToList();
            for (int pageHeader = 0; pageHeader <= headerNames.Count - 1; pageHeader++)
            {
                htmlTable.Columns.Add(headerNames[pageHeader], typeof(string));
                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, headerNames[pageHeader])), 8);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpath, headerNames[pageHeader])));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[pageHeader]}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[pageHeader]}']")); }
                var testList = rows.Select(e => e.Text.Trim()).ToList();
                for (int pageList = 0; pageList <= testList.Count - 1; pageList++)
                {
                    if (pageHeader != 0)
                    {
                        htmlTable.Rows[pageList][pageHeader] =testList[pageList];
                    }
                    else { htmlTable.Rows.Add(testList[pageList]); }
                }
            }
            return htmlTable;
        }

        public List<string> GetSortedList(string column)
        {
            List<string> list = new List<string>();

            var Table = GetDocumentsRecords(column);
            int index = Table.Columns[column].Ordinal;
            for (int pageRow = 0; pageRow <= Table.Rows.Count - 1; pageRow++)
            {
                list.Add((string)Table.Rows[pageRow][index]);
            }
            return list;
        }

        public void searchInfo(string case_no, string casename)
        {
            Thread.Sleep(2000);
            this.MoveToViewElementandSAndkeys(driver.FindElement(documentsPageFilterOptionsCaseORDebtor), case_no);
            Thread.Sleep(2000);
            try
            {
                IList<IWebElement> dropdownValues = driver.FindElements(By.XPath("//div[contains(@class,'rbt clearfix open undefined')]//ul/li/a"));

                foreach (IWebElement textBox in dropdownValues)
                {
                    if ((textBox.Text) == casename)
                    {
                        Thread.Sleep(2000);
                        IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
                        Thread.Sleep(3000);
                        ex.ExecuteScript("arguments[0].click();", textBox);
                        Thread.Sleep(3000);
                        break;
                    }
                }
            }
            catch (StaleElementReferenceException e)
            {

            }
        }

        public void SelectDateFrom(string fromDate)
        {
            this.WaitForElementToBeVisible(documentsPageFilterOptionsDateFiledFrom).SendKeys(fromDate);
        }
        public void SelectDateTo(string toDate)
        {
            this.WaitForElementToBeVisible(documentsPageFilterOptionsDateFiledTo).SendKeys(toDate);
        }

        public List<string> GetRecordsByColumnName(string ColumnName, string value = null)
        {
            IList<IWebElement> rows = null;
            List<string> lists = new List<string>();
            ColumnName = ColumnName.ToUpper();
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";
            try
            {
                this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, ColumnName)), 8);
                rows = driver.FindElements(By.XPath(string.Format(rowXpath, ColumnName)));
                if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']")); }
            }
            catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']")); }
            lists = rows.Select(e => e.Text.Trim()).ToList();

            // To verify the value exist in the respective column 
            if (!string.IsNullOrWhiteSpace(value))
            {
                bool found = false;
                foreach (string list in lists)
                {
                    found = list.Contains(value);
                    if (found) break;
                }
                found.Should().BeTrue();
            }
            return lists;
        }

        public void ClickCaseStatusX()
        {
            this.WaitForElementToBeVisible(documentsFilterCaseStatusX).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[label[text()='CASE STATUS']]")).Click();

        }


        public string GetCaseStausValue()
        {
            this.Pause(1);
            return this.WaitForElementToBeVisible(documentsFilterCaseStatusDrpdn).Text;

        }

        public void ClickOnResetButton()
        {
            this.Pause(1);
            this.WaitForElementToBeVisible(documentsFilterResetButton).Click();
            this.Pause(1);

        }

        public void ClickOnAddDocument()
        {
            this.WaitForElementToBeVisible(documentsAddNewDocuments).Click();
        }
        public void selectCaseNumberOrDebtorNumber(string caseNumber)
        {
            this.WaitForElementToBeVisible(documentsCaseDebtorSelection).SendKeys(caseNumber);
            this.WaitForElementToBeVisible(documentsPageFilterOptionsCaseORDebtorSelections).Displayed.Should().BeTrue();
            var caseORDebtorSelection = this.WaitForElementToBeVisible(documentsPageFilterOptionsCaseORDebtorSelections);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", caseORDebtorSelection);


        }
        public void UploadNewDocument()
        {
            Thread.Sleep(2000);

            //string image_path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"C:\\\\Users\\\\shilpa.jain\\\\Desktop\\\\Test.docx");
            IWebElement fileUpload = driver.FindElement(documentsFileUpload);
            fileUpload.Click();


            AutoItX.WinWaitActive("Open");
            AutoItX.Send("Test.docx");
            AutoItX.Send("{ENTER}");

            //this.WaitForElementToBePresent(Window_Upload).SendKeys("C:\\\\Users\\\\shilpa.jain\\\\Desktop\\\\Test.docx");
            //driver.SwitchTo().Alert().Dismiss();
            //driver.Navigate().GoToUrl("http://unity-tnetqa.epiqsystems.com/documents/documents-list");
            // string s2=  Environment.GetEnvironmentVariable("Testplatz_Config_Location") + "\\Test.docx";
            // s1.SendKeys(s2);

            this.Pause(3);
            //string sFileDir = "C:\\";
            //long lMaxFileSize = 4096;

            // this.PressKeyOnActiveElement(Keys.Clear);
            // driver.SwitchTo().ActiveElement().SendKeys("C:\\\\Users\\\\shilpa.jain\\\\Desktop\\\\Test.docx");
            //driver.SwitchTo()
            //         .ActiveElement().Click();
            //driver.SwitchTo()
            //.ActiveElement().SendKeys(image_path);
            //driver.Close();
            // Actions action = new Actions(driver);
            //action.SendKeys(Keys.Tab);
            //action.SendKeys(Keys.Tab);
            //action.SendKeys(Keys.Tab);
            //action.SendKeys(Keys.Enter);
            // Thread.Sleep(1300);
            //this.WaitForElementsToBePresent(DOCUMENTS_FILE_UPLOAD).
            //String script = " this.WaitForElementsToBePresent(DOCUMENTS_FILE_UPLOAD).Where='" + "C:\\\\Users\\\\shilpa.jain\\\\Desktop\\\\Test.docx" + "';";
            // ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
        public void ClickOnSaveButton()
        {
            // IAlert alert = driver.SwitchTo().Alert();
            //alert.Dismiss();
            var saveNewDocuments = this.WaitForElementToBeVisible(documentsSaveNewDocuments);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", saveNewDocuments);
            //this.ScrollDownToPageBottom();
            //this.WaitForElementToBeVisible(DOCUMENTS_SAVE_NEW_dOCUMENTS).Click();
            Thread.Sleep(1500);
        }

        public void EditTagsOfCaseAndDesc(string DesText)
        {
            this.Pause(7);
            IList<IWebElement> Description = driver.FindElements(By.XPath("//tr//td[@data-title='DESCRIPTION']//span"));
            String[] Text = new String[Description.Count];
            int pageDesc = 0;

            foreach (IWebElement elements in Description)
            {
                Text[pageDesc++] = elements.Text;
                var DescriptionList = elements.Text;
                if (DescriptionList == DesText)
                {
                    driver.FindElement(By.XPath("//tbody//tr[" + pageDesc + "]//td[@data-title='TAGS']/div/button")).Click();
                }
            }
        }

        public void AddTagsToCase(string tag1, string tag2, string tag3)
        {
                this.Pause(5);
                var selecttag1 = driver.FindElement(By.XPath("(//div[@class='epiq-table-input-inline-edit']//button[@class='epiq-button-link epiq-inline-edit btn btn-default'])[2]"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", selecttag1);
                this.Pause(1);
                WaitForElementToBeClickeable(tagOneLocator).Click();
                WaitForElementToBeClickeable(tagOneExistingDelete).Click();
                this.Pause(3);
                WaitForElementToBeClickeable(tagTwoExistingDelete).Click();
                this.Pause(3);
                WaitForElementToBeClickeable(tagThreeExistingDelete).Click();
                this.Pause(3);
                var tagone = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{tag1}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tagone);
                this.Pause(3);
                tagone.Click();
                WaitForElementToBeClickeable(tagOneLocator).Click();           
                var tagtwo = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{tag2}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tagtwo);
                this.Pause(3);
                tagtwo.Click();
                WaitForElementToBeClickeable(tagOneLocator).Click();                
                var tagthree = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{tag3}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tagthree);
                this.Pause(1);
                tagthree.Click();
            
        }
        public void SaveTags()
        {
            WaitForElementToBeClickeable(tagsSubmit, 4).Click();
        }
        public void VerifyWarningIcon()
        {
            Thread.Sleep(1000);
            var resColor = driver.FindElement(By.XPath("//div[@class='epiq-security-container panel']//i[@class='text-warning fa fa-warning fa-3x']")).GetCssValue("color");
            Console.WriteLine(resColor);
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
        public bool VerifyWarningMsg(string warningMSG)
        {
            return this.WaitForElementToBeVisible(warningMsg).Text.Equals(warningMSG);
        }
        public void ContactAdmin(string ContactText, string Admin)
        {
            var contact = WaitForElementToBeVisible(contactText).Text;
            if (contact == ContactText)
            {
                WaitForElementToBeClickeable(contactTextBox).Click();
                var admin = WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{Admin}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", admin);
                this.Pause(2);
                admin.Click();
            }
        }
        public void AdminContactInfo(string Email, string Admin)
        {
            if (this.WaitForElementToBeVisible(adminName, 2).Text.Equals(Admin))
            {
                var email = WaitForElementToBeVisible(emailAddress, 1);
                Thread.Sleep(3000);
                var EmailTxt = email.Text.Trim();
                string newString = EmailTxt.Split(':', ' ').Last();
                Assert.AreEqual(newString, Email);
            }
        }

        public void ClickOnDescription()
        {
            IList<IWebElement> Description = this.WaitForElementsToBeVisible(By.XPath("//tbody//td[@data-title='DESCRIPTION']/div/button")).ToList();
            Description[1].Click();
        }

        public void ClickOnTAG()
        {
            Pause(1);
            IList<IWebElement> Description = this.WaitForElementsToBeVisible(By.XPath("//tbody//td[@data-title='TAGS']/div/button")).ToList();
            Description[1].Click();
        }

        public void EditDescription()
        {
            SelectAndDeleteCompleteText(driver.FindElement(By.XPath("//div[@class='form-group']/textarea")));
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']/textarea")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']/textarea")).SendKeys(FakeData.Description() + ".pdf");
            this.WaitForElementToBePresent(inlineSubmitLocator).Click();
        }
        public void EditTag(string tagnm)
        {
            if (GetElementExists(By.XPath("//div[@class='form-group']//span[@class='Select-clear']")))
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//span[@class='Select-clear']")).Click();
                this.WaitForElementToBeVisible(By.XPath("//h3[text()='TAGS']")).Click();
                this.WaitForElementToBePresent(inlineSubmitLocator).Click();
                Pause(1);

            }
            else
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//span[@class='Select-arrow']")).Click();
                this.WaitForElementToBeVisible(By.XPath("//div[@class='popover-content']//div[@class='Select-input']//input")).SendKeys(tagnm);
                SelectTag(tagnm);
                this.WaitForElementToBePresent(inlineSubmitLocator).Click();
                Pause(1);
            }

        }

        private bool GetElementExists(By loc)
        {
            try
            {
                this.WaitForElementToBeVisible(loc, 5);
                return true;
            }
            catch
            { return false; }

        }

        private void SelectTag(string tagname)
        {
            IList<IWebElement> Tag = this.WaitForElementsToBeVisible(By.XPath("//div[@class='form-group']//div//div[2]")).ToList();
            foreach (IWebElement TagTextBox in Tag)
            {
                if ((TagTextBox.Text) == tagname)
                {
                    this.MoveToElementAndClick(TagTextBox);
                    break;
                }

            }
        }

        public void ClickOnFileName()
        {
            this.WaitForElementToBeVisible(By.XPath("//div[@class='row']//div[7]//button")).Click();
        }

        public void EditFileName()
        {
            SelectAndDeleteCompleteText(driver.FindElement(By.XPath("//div[@class='form-group']/input")));
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']/input")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']/input")).SendKeys(FakeData.Description() + ".doc");
            this.WaitForElementToBePresent(inlineSubmitLocator).Click();
        }
        public bool ValidateEyeButton()
        {
            return this.WaitForElementToBeVisible(By.XPath("//i[@class='fa fa-eye']")).Displayed;
        }
        public bool ValidatePencilButton()
        {
            return this.WaitForElementToBeVisible(By.XPath("//i[@class='fa fa-pencil']")).Displayed;
        }
        public void ClickOnViewOfDocument()
        {
            IList<IWebElement> EyeList = this.WaitForElementsToBeVisible(By.XPath("//i[@class='fa fa-eye']")).ToList();
            EyeList[6].Click();
        }
        public void ClickOnEditPencilOfDocument()
        {
            IList<IWebElement> EyeList = this.WaitForElementsToBeVisible(By.XPath("//i[@class='fa fa-pencil']")).ToList();
            EyeList[4].Click();
        }
        public bool ValidateDocumentsEditing()
        {
            this.WaitForElementToBeVisible(By.XPath("//div[@class='panel-heading']")).Click();
            if (GetElementExists(By.XPath("//div[@class='row']//div[2]//button")) && GetElementExists(By.XPath("//div[@class='row']//div[3]//button")))
            {
                return true;
            }
            else { return false; }
        }
        public void ClickOnDocumentHeader_on_DocumentViewer()
        {
            this.WaitForElementToBeVisible(documentsHeaderLocator).Click();
        }


        public void EditDescription_on_DocumentViewer()
        {
            SelectAndDeleteCompleteText(driver.FindElement(By.XPath("//div[@class='form-group']/input")));
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']/input")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']/input")).SendKeys(FakeData.Description() + ".pdf");
            this.WaitForElementToBePresent(inlineSubmitLocator).Click();
        }
        public void EditFileName_on_DocumentViewer()
        {
            SelectAndDeleteCompleteText(driver.FindElement(By.XPath("//div[@class='form-group']/input")));
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']/input")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']/input")).SendKeys(FakeData.Description() + ".doc");
            this.WaitForElementToBePresent(inlineSubmitLocator).Click();
        }
        public void ClickOnTagButton_on_DocumentViewer()
        {
            this.WaitForElementToBeVisible(documentTagsEditLocator).Click();
        }
        public void ClickOnFileNameButton_on_DocumentViewer()
        {
            this.WaitForElementToBeVisible(documentFileNameEditLocator).Click();
        }
        public void ClickOnDescriptionButton_on_DocumentViewer()
        {
            Pause(1);
            this.WaitForElementToBeVisible(documentDescriptionEditLocator).Click();
        }
        public void ClickOnAssigendToButton_on_DocumentViewer()
        {
            this.WaitForElementToBeVisible(documentAssignedToEditLocator).Click();
        }
        public void ClickOnDocButton_on_DocumentViewer()
        {
            this.WaitForElementToBeVisible(documentDocEditLocator).Click();
        }
        public void ClickOnSourceButton_on_DocumentViewer()
        {
            this.WaitForElementToBeVisible(documentSourceEditLocator).Click();
        }
        public void EditAssigendTo_on_DocumentViewer()
        {
            if (GetElementExists(By.XPath("//div[@class='form-group']//span[@class='Select-clear']")))
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//span[@class='Select-clear']")).Click();
                this.WaitForElementToBeVisible(By.XPath("//h3[text()='ASSIGNED TO']")).Click();
                this.WaitForElementToBePresent(inlineSubmitLocator).Click();
                Pause(1);

            }
            else
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//span[@class='Select-arrow']")).Click();
                IList<IWebElement> AssignedTo_List = this.WaitForElementsToBeVisible(By.XPath("//div[@class='Select-menu-outer']//div//div")).ToList();
                AssignedTo_List[12].Click();               ;
                this.WaitForElementToBePresent(inlineSubmitLocator).Click();
                Pause(1);
            }

        }
        public void InputDescription(string desc)
        {
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[label[text()='DESCRIPTION']]/input")),desc);
        }
        public void DeleteFuntionality()
        {
            WaitForElementToBePresent(deleteButton).Click();
        }
        public void SelectCaseStatus(string casestatus)
        {
            var caseSelectorStatus = WaitForElementToBeClickeable(caseStatusLocator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", caseSelectorStatus);
            var CStatus = driver.FindElement(By.XPath($"//label[text()='CASE STATUS']/parent::div//div[@class='Select-value']/span[text()='{casestatus}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", CStatus);
            this.Pause(1);
            CStatus.Click();
        }
        public void SelectTagName(string tag)
        {
            this.Pause(1);
            WaitForElementToBeClickeable(tagLocator).Click();
            var tagname = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{tag}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tagname);
            this.Pause(1);
            tagname.Click();
        }
        public void CheckTagName(string tag)
        {
            this.Pause(1);
            var tagname = driver.FindElement(By.XPath($"//div[@class='epiq-table-input-inline-edit']/button[text()='{tag}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tagname);
            this.Pause(3);
            tagname.Click();

        }
        public bool GetCaseNumberDisplayed()
        {
            this.Pause(3);
            return driver.FindElement(documentsPageCaseNumber).Displayed;
        }
        public bool GetCurrent341DateDisplayed()
        {
            this.Pause(3);
            return driver.FindElement(documentsPageCurrent341Date).Displayed;
        }
        public bool GetHistoryDisplayed()
        {
            this.Pause(3);
            return driver.FindElement(documentsPageHistory).Displayed;
        }
    }
    }
       


