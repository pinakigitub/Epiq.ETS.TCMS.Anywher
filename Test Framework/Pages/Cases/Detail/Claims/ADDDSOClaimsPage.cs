using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DSOADD
{
  public  class ADDDSOClaimantPage : PageObject
    {
        private static string pageExpectedTitle = "UNITY";
        private By dsoClaimantButton = By.XPath("//div[contains(@class,'epiq-page-control')]/button[contains(@class,'btn btn-info')]/i[contains(@class,'fa fa-plus-circle')]");
        private By addDsoClaimantsHeader = By.XPath("//div[contains(@class,'epiq-page-header')]//h2[text()='Add DSO Claimants']");
        string actualHeader;

        //Input Field Locators
        private By caseDebtorName = By.XPath("//div[contains(@class,'rbt-input')]//input[@placeholder='Select a case...']");
        private By dsoClaimantName = By.XPath("//div[contains(@class,'form-group')]//input[@placeholder='Enter Claimant Name']");
        private By addressField = By.XPath("//div[contains(@class,'form-group')]//input[@placeholder='Enter Claimant Address']");

        //New Debtor Individual Locators
        private By TITLE_DEBTOR = By.XPath("//div[@class='row'][2]//div[@class='row epiq-no-divider'][1]/div/div[input[contains(@name,'title')]]//span[3]");
        private By saveButton = By.XPath("//button[@type='submit'][text()='SAVE']");
        private By deleteButton = By.XPath("//a/button");
        private By popUpParagraph =By.XPath("//div[@class='modal-body']");
        private By deleteButtonPopUp = By.XPath("//div[2]/div/div/div[3]/button");
        private By cancelButtonPopUp = By.XPath("//div[3]/button[2]");
        private By selectFirstRecord = By.XPath("//td[2]/div/input");
        private By selectAllRecords = By.XPath("//th[2]/div/label");
        private By deleteButtonNotClick = By.XPath("//button[contains(text(),'DELETE')]");
        private By phoneField = By.XPath("//div[contains(@class,'form-group')]//input[@name='dsoClaimantPhoneNumber']");

        //New Joint Debtor Individual Locators
        private By firstNameJointDebtor = By.XPath("//input[contains(@class,'form-control')][contains(@name,'participantSearch.jointDebtorEmployer.new.firstName')]");
        private By middleNameJointDebtor = By.XPath("//input[contains(@class,'form-control')][contains(@name,'participantSearch.jointDebtorEmployer.new.middleName')]");
        private By lastNameJointDebtor = By.XPath("//input[contains(@class,'form-control')][contains(@name,'participantSearch.jointDebtorEmployer.new.lastName')]");

        //New Joint Debtor Corporation Locators
        private By displayNameJointDebtor = By.XPath("//div[contains(@class,'epiq-no-divider row')]//input[contains(@name,'participantSearch.jointDebtorEmployer.new.corporateDisplayName')]");

        //Dso Page locators
        private By breadCrumbField = By.XPath("//div[@class='epiq-page-header  ']//ol");
        private By dsoClaimantsSubHeader = By.XPath("//div[contains(@class,'epiq-page-controls')]/div/h3");
        private By filterIcon = By.XPath("//button[@class='btn btn-info'][@title='View and change current filters.']");
        private By closeButton = By.XPath("//button[text()='CLOSE']");
        private By resetButton = By.XPath("//button[text()='RESET']");
        String date = "11/10/2018";
        private By VerifiedButton = By.XPath("//td[@data-title='Verified']/i[@class='fa fa-check epiq-cursor-pointer epiq-receiptlog-enabled']");

        //Filter Locators
        string actualSubHeader;
        private By headerName = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");

        //InLineEdit Locators
        private By inlineEditInput = By.XPath("//div[h3[contains(text(),'')]]/div/form//input");
        private By saveField = By.XPath("//button[@type='submit']");
        private By cancelField = By.XPath("//button[@class='btn btn-default']");

        public ADDDSOClaimantPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
            this.driver = driver;
             //driver.IntializePage<GlobalExtendNoDataPage>(this);
        }

        public void DsoClaimantClick()
        {
            WaitForElementToBePresent(dsoClaimantButton,5).Click();
        }

        public void DeleteFuntionality()
        {
            WaitForElementToBePresent(deleteButton).Click();
        }

        public void SelectFirstRecord()
        {
            this.Pause(2);
            var e = driver.FindElement(selectFirstRecord);
            JavaScriptClick(e);
        }

        public void SelectAllRecords()
        {
            this.Pause(2);
            var e = WaitForElementToBePresent(selectAllRecords,3);
            JavaScriptClick(e);
        }
       
        public void DeleteInPopup()
        {
            WaitForElementToBePresent(deleteButtonPopUp,2).Click();
        }

        public void CancelInPopup()
        {
            WaitForElementToBePresent(cancelButtonPopUp,2).Click();
        }

        public void DeleteNotClickable()
        {
            Thread.Sleep(2500);
             bool state = driver.FindElement(deleteButtonNotClick).Enabled;
             Assert.IsTrue(state);           
        }

        public string ValidateTextInPopUp()
        {
            string text = this.WaitForElementToBeVisible(popUpParagraph,2).Text;
            return string.Concat(text);
        }
        public void VerifyAddDsoClaimantsHeader(string expectedHeader)
        {
            actualHeader = driver.FindElement(addDsoClaimantsHeader).Text.Trim();
            Assert.AreEqual(actualHeader, expectedHeader.Trim());
        }

        public void SelectDebtorName(string search, string caseName)
        {          
                WaitForElementToBeVisible(caseDebtorName,2).SendKeys(search);
                WaitForElementToBeVisible(caseDebtorName,2).Click();
                this.Pause(2);
                IList<IWebElement> caseDebtorValues = driver.FindElements(By.XPath("//div[contains(@class,'rbt open clearfix undefined')]//ul//li"));           
                caseDebtorValues.Where(e => e.Text == caseName).FirstOrDefault().Click();         
        }

        public void InputTextFieldsData(string dsoName, string address, string phone)
        {

            ClearAndType(WaitForElementToBeVisible(dsoClaimantName), date+dsoName);   
            WaitForElementToBeVisible(addressField,4).SendKeys(address);
            WaitForElementToBeVisible(phoneField).SendKeys(phone);
        }

        public void InputDropdownFieldsData(string obligation, string state, string initialNotice, string disNotice)
        {
            if (!string.IsNullOrEmpty(obligation))
            {
                SendDataInDropdownFields(8, obligation);
            }
            if (!string.IsNullOrEmpty(state))
            {
                SendDataInDropdownFields(9, state);
            }
            if (!string.IsNullOrEmpty(initialNotice))
            {
                SendDataInDropdownFields(10, initialNotice);
            }
            if (!string.IsNullOrEmpty(disNotice))
            {
                SendDataInDropdownFields(11, disNotice);
            }
        }

        private void SendDataInDropdownFields(int i, string status)
        {
            var ele = WaitForElementToBePresent(By.XPath(".//*[@id='react-select-" + i + "--value']//input"));
            ele.SendKeys(status);
            ele.SendKeys(Keys.Enter);
        }

        public void SaveClaim()
        {
            WaitForElementToBeVisible(saveButton).Click();
        }
        public void SelectParticipantType(string selectType)
        {
            ScrollDown();
             IList<IWebElement> participantOptions = driver.FindElements(By.XPath("//span[contains(@class,'has-text')]"));
             this.Pause(2); 
            foreach (IWebElement option in participantOptions)
            {
                if (option.Text == selectType)
                {
                    JavaScriptClick(option);
                    break;
                }
            }
        }

        public void InputTitle(string title)
        {
            if (title == "Miss")
            {
                WaitForElementToBeClickeable(By.XPath("//div[label[text()='TITLE']]//div[input[@name='participantSearch.debtorEmployer.new.title']]/div"), 2).Click();
                //var text = WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{title}']"));
                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", text);
                //this.Pause(2);
                //text.Click();
               // ScrollDown();
                WaitForElementToBeClickeable(By.XPath($"//div[text()='{title}']"), 2).Click();
            }
            else
            {
                WaitForElementToBeClickeable(By.XPath("//div[label[text()='TITLE']]//div[input[@name='participantSearch.jointDebtorEmployer.new.title']]/div"), 2).Click();
                var text = WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{title}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", text);
                text.Click();
            }
        }

        public void InputNameFields(string debtorType,string firstName, string middleName, string lastName)
        {
            string preXpath = "//input[contains(@class,'form-control')][contains(@name,'participantSearch.";
            WaitForElementToBePresent(By.XPath(string.Format(preXpath + debtorType + ".new.firstName')]"))).SendKeys(firstName);
            WaitForElementToBePresent(By.XPath(string.Format(preXpath + debtorType + ".new.middleName')]"))).SendKeys(middleName);
            WaitForElementToBePresent(By.XPath(string.Format(preXpath + debtorType + ".new.lastName')]"))).SendKeys(lastName);
        }
        public void InputDetorPayeeDisplayName(string payeeType,string displayName)
        { 
                WaitForElementToBePresent(By.XPath("//div[contains(@class,'epiq-no-divider row')]//input[contains(@name,'participantSearch." + payeeType + ".new.corporateDisplayName')]")).SendKeys(displayName);
        }

        public void InputJointDebtorType(string jointDebtorType)
        {
            ScrollDownToPageBottom();
            var jointDebtor = driver.FindElement(By.XPath("//label[contains(@for, 'epiq-radio-participantSearch.jointDebtorEmployer.new')]/span[text()='"+jointDebtorType+"']"));
            jointDebtor.Click();
        }

        public void InputJointDetorDisplayName(string jointDebtorDisplayName)
        {            
                WaitForElementToBePresent(displayNameJointDebtor).SendKeys(jointDebtorDisplayName);
        }
        public void VerifiedEnabledHover()
        {
            Actions ToolTip1 = new Actions(driver);
            IWebElement verifiedHover = this.WaitForElementToBeVisible(VerifiedButton);
            Thread.Sleep(2000);
            ToolTip1.ClickAndHold(verifiedHover).Perform();
        }
        public void ClickCloseButton()
        {
            Thread.Sleep(2500);
            var close = driver.FindElement(By.XPath("//button[text()='CLOSE']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", close);
            Thread.Sleep(3000);
        }
        public void BreadCrumbSubheaderVerify(string breadCrumb, string subHeader)
        {
            string actualBreadCrumb = WaitForElementToBePresent(breadCrumbField).Text;
            Assert.AreEqual(actualBreadCrumb.Trim(), breadCrumb.Trim());
            actualSubHeader = WaitForElementToBePresent(dsoClaimantsSubHeader).Text;
            Assert.AreEqual(actualSubHeader.Substring(0, 13).Trim(), subHeader.Trim());
        }

        public List<string> SortingColumns(string column)
        {
            List<string> listColumns = new List<string>();
            var Table = GetClaimRecords(column);
            int index = Table.Columns[column].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                listColumns.Add(Table.Rows[i][index].ToString());
            }
            return listColumns;
        }
        public DataTable GetClaimRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(headerName).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            var headerNames = driver.FindElements(headerName).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 1; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);
                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, headerNames[i])), 8);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpath, headerNames[i])));
                    if (rows.Count == 0)
                    {
                        rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']"));
                    }
                }
                catch
                {
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']"));
                }
                var testList = rows.Select(e => e.Text.Trim()).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) { htmlTable.Rows[j][i] = testList[j]; }
                    else
                    {
                        htmlTable.Rows.Add(testList[j]);
                    }
                }
            }
            return htmlTable;
        }

        public void SearchInfo(string search, string caseName)
        {
            WaitForElementToBePresent(filterIcon,2).Click();           
        }
        public void DropdownFields(string caseStatus, string dsoInitial, string dsoNotice)
        {
            if (!string.IsNullOrEmpty(caseStatus))
            {
                ClickDropDownData("CASE STATUS", caseStatus);
            }
            if (!string.IsNullOrEmpty(dsoInitial))
            {
                ClickDropDownData("DSO INITIAL NOTICE DUE", dsoInitial);
            }
            if (!string.IsNullOrEmpty(dsoNotice))
            {
                ClickDropDownData("DSO DISCHARGE NOTICE DUE", dsoNotice);
            }
            this.Pause(2);
            driver.FindElement(closeButton).Click();
        }

        private void ClickDropDownData(string labelType, string status)
        {
                WaitForElementToBePresent(By.XPath("//div[label[contains(text(),'"+labelType+"')]]//div//span[@class='Select-arrow']"),5).Click();           
                IList<IWebElement> caseStatusOptions = driver.FindElements(By.XPath("//div[label[contains(text(),'"+ labelType + "')]]//div[starts-with(@id,'react-select-')]"));
                caseStatusOptions.Where(e => e.Text == status).FirstOrDefault().Click();
        }
        public void FilteredDataOnGrid(string fromDate, string toDate)
        {
                IWebElement table = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-body']//div//table//tbody"),5);
                IList<IWebElement> tableRows = driver.FindElements(By.XPath("//div[@class='epiq-page-body']//div//table//tbody//tr[not(contains(@class,'epiq-table-details-row'))]"));
                var count = tableRows.Count();
                string actualFromDate = fromDate.Substring(0, 8);
                string actualToDate = toDate.Substring(0, 8);
                var text = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-body']//div//table//thead//tr//th[3]"),5).Text;
                if (text == "341 MEETING DATE")
                {
                    for (int counter = 1; counter <= count; counter++)
                    {
                        string cellData = table.FindElement(By.XPath("//tr[" + counter + "]//td[3]//span")).Text;
                        Assert.GreaterOrEqual(DateTime.Parse(cellData), DateTime.Parse(actualFromDate));
                        Assert.LessOrEqual(DateTime.Parse(cellData), DateTime.Parse(actualToDate));
                        counter++;
                    }
                }
        }
        public void DateFields(string fromDate, string toDate)
        {
            //identify two date fields and storing in list

            if (!string.IsNullOrEmpty(fromDate))
            {
                DateFieldsData("first", fromDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateFieldsData(null, toDate);
            }
        }
        private void DateFieldsData(string xpath, string date)
        {
            IList<IWebElement> datePickerFields = driver.FindElements(By.XPath("//input[contains(@class,'form-control')][@placeholder='MM/DD/YY']"));
            var ele = (xpath == "first") ? datePickerFields.FirstOrDefault() : datePickerFields.LastOrDefault();
            ele.SendKeys(date);
            ele.Click();
            //IList<IWebElement> datesList=driver.FindElements(By.XPath("//table//tbody//tr"));
            //datesList.Where(e => e.Text == "1").FirstOrDefault().Click();
           // WaitForElementToBePresent(By.XPath("//label[@class='control-label'][text()='341 MEETING DATE (TO)'] | //label[@class='control-label'][text()='341 DATE (TO)']")).Click();
        }

        public void ClickReset()
        {
            WaitForElementToBePresent(resetButton);
        }
        public void VerifyAddedRecordonGrid(string claimantName)
        {
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-body']//div//table//thead//tr//th[4]//i")).Click();        
            this.Pause(2);
            string search = string.Concat(date,claimantName);
            IWebElement table = driver.FindElement(By.XPath("//div[@class='epiq-page-body']//div//table//tbody"));
            IList<IWebElement> tableRows = table.FindElements(By.XPath("//tr"));
            int rowCount = tableRows.Count;                       
            for (int count = 1; count <= rowCount; count++)
            {
                var text = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-body']//div//table//thead//tr//th[4]")).Text;
                if (text == "CLAIMANT NAME")
                {
                    this.Pause(2);
                    String cellData = table.FindElement(By.XPath("//tr[" + count + "]//td[4]//button")).Text;
                    Assert.AreEqual(search, cellData);
                    if (cellData == search)
                    {
                        var edit = table.FindElement(By.XPath("//tr[" + count + "]//td[10]/a"));
                        edit.Click();
                        break;
                    }
                    count++;
                }
            }
        }

        public void EditRecord(string address,string phone)
        {           
            SelectAndDeleteCompleteText(addressField);         
            WaitForElementToBePresent(addressField, 2).SendKeys(address + date);
            SelectAndDeleteCompleteText(phoneField);
            WaitForElementToBePresent(phoneField, 2).SendKeys(phone);
        }
        public void VerifyViewIcon(int index)
        {
            Assert.IsTrue(IsElementVisible(By.XPath("//tr[19]/td[" + index + "]/a/i")));
        }
        public void EditFields(string header, int num, string text)
        {
            if (IsElementVisible(By.XPath($"//th[text()='{header}']")))
            {
                this.Pause(4);
                WaitForElementToBeClickeable(By.XPath($"//tbody/tr[1]/td[{num}]/div/button"), 2).Click();
                SelectAndDeleteCompleteText(WaitForElementToBeVisible(inlineEditInput, 8));
                TypeIn(WaitForElementToBeVisible(inlineEditInput, 4), text);
                WaitForElementToBeClickeable(saveField, 2).Click();
            }
            else
            {
                this.Pause(2);
               // WaitForElementToBeClickeable(By.XPath("//tbody/tr[1]/td[1]/div/i")).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[div[text()='{header}']]//button")).Click();
                this.Pause(2);
                SelectAndDeleteCompleteText(WaitForElementToBeVisible(inlineEditInput, 8));
                TypeIn(WaitForElementToBeVisible(inlineEditInput, 4), text);
                WaitForElementToBeClickeable(saveField, 2).Click();
            }
        }
        public void VerifyDetails(string header, int num, string text)
        {
            var headerValue = WaitForElementToBeVisible(By.XPath($"//th[text()='{header}']")).Text;
            if (headerValue != "ADDRESS")
            {
                this.Pause(4);
                var Text = WaitForElementToBeClickeable(By.XPath($"//tbody/tr[1]/td[{num}]/div/button"), 2);
                var inLineText = Text.Text;
                Assert.AreEqual(inLineText, text);
            }
            else
            {
                this.Pause(4);
                WaitForElementToBeClickeable(By.XPath($"//tbody/tr[1]/td[{num}]/div/button"), 2).Click();
                this.Pause(4);
                var address = WaitForElementToBeVisible(inlineEditInput, 4).GetAttribute("value");
                WaitForElementToBePresent(By.XPath("//button[@class='btn btn-default']//i")).Click();
                Assert.AreEqual(address, text);
            }
        }
        public void CancelEditFields(string header, int num, string text)
        {
            if (IsElementVisible(By.XPath($"//th[text()='{header}']")))
            {
                this.Pause(4);
                WaitForElementToBeClickeable(By.XPath($"//tbody/tr[1]/td[{num}]/div/button"), 2).Click();
                SelectAndDeleteCompleteText(WaitForElementToBeVisible(inlineEditInput, 8));
                TypeIn(WaitForElementToBeVisible(inlineEditInput, 4), text);
                WaitForElementToBeClickeable(cancelField, 2).Click();
            }
            else
            {
                this.Pause(2);
                WaitForElementToBeClickeable(By.XPath("//tbody/tr[1]/td[1]/div/i")).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[div[text()='{header}']]//button")).Click();
                SelectAndDeleteCompleteText(WaitForElementToBeVisible(inlineEditInput, 8));
                TypeIn(WaitForElementToBeVisible(inlineEditInput, 4), text);
                WaitForElementToBeClickeable(cancelField, 2).Click();
                WaitForElementToBeClickeable(By.XPath("//tbody/tr[1]/td[1]/div/i")).Click();
            }
        }
        public void ViewOnlyInLineEdit()
        {
            Assert.False(IsElementVisible(By.XPath($"//tbody/tr[1]/td[4]/div/button")));
            Assert.False(IsElementVisible(By.XPath($"//tbody/tr[1]/td[5]/div/button")));
            Assert.False(IsElementVisible(By.XPath($"//tbody/tr[1]/td[7]/div/button")));
            Assert.False(IsElementVisible(By.XPath($"//tbody/tr[1]/td[8]/div/button")));
        }
        public bool Verify_DateField_areFilled()
        {
           return WaitForElementToBeVisible(By.XPath("//input[contains(@class,'form-control')][@placeholder='MM/DD/YY'][@value!='']")).Displayed;   
        }
    }  
}


       
    



