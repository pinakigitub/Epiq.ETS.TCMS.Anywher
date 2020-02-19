using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;
using System.Data;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports
{
    public class ImportClaimsPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        //private By breadCrumb = By.XPath("//div[contains(@class,'epiq-page-header')]//ol");
        private By filter = By.XPath("//div[@class='epiq-page-control pull-right']//button");
        private By pageSize = By.XPath("//div[@class='epiq-paging-pagesize']/div/div/span[2]");
        private By claimsTableRowsLocator = By.XPath("//tbody//tr[not(contains(@class,'epiq-table-details-row'))]");
        private By headerTableNames = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By pagination = By.ClassName("pagination");
        private By navigation = By.XPath("//ol[@aria-label='breadcrumbs']//span");
        private By pages = By.XPath("//*[@class='pagination']//li[not(@class='disabled')]/a[not(descendant::*)]");
        private By delete = By.XPath("//div[@class='epiq-table-action-button ']//span");
        private By import = By.XPath("//div[@class='epiq-table-action-button ']//span[text()='IMPORT']");
        private By importClaimsHeader = By.XPath("//div[@class='case-header-data-case-display']//span[3]");
        private By caseHeader = By.XPath("//div[@class='case-header-data-case-display']");
        private By selectViewDocumentsTab = By.XPath(".//*[@id='claims-view-tabs-tab-2']/div");
        private By viewSectionText = By.XPath(".//*[@id='claims-view-tabs-pane-2']//div[@class='panel-body']//p");
        private By assetsLocator = By.XPath("//div[@class='epiq-page-heading clearfix']//ul//li[1]//a");
        int beforeClaimsCount;
        string importCounter;
        //int counter;
        int beforeImportClaimsCount;
        //int deleteCounter;
        private By nextArrow = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[1]/div[1]/h2/div/div[1]/a[2]/i");
        private By assetCellData = By.XPath("//table[contains(@class,'epiq-table table')]//tbody//tr[1]//td[6]");
        private By settingsIcon = By.XPath("//button[@class='epiq-button-link btn btn-default']");
        private By save = By.XPath("//button[text()='SAVE']");
        private By messageTable = By.XPath("//table//div[text()='No claims to import']");
        private By paginations = By.ClassName("pagination");
        private By next = By.XPath("//*[@class='pagination']//span[@aria-label='Last']");
        private By previous = By.XPath("//*[@class='pagination']//span[@aria-label='First']");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By page = By.XPath("//*[@class='pagination']//li[not(@class='disabled')]/a[not(descendant::*)]");

        public ImportClaimsPage(IWebDriver driver) : base(driver, pageTitle)
        {
            this.driver = driver;
        }
        public void VerifyColumns(int colStartIndex, int colEndIndex, List<string> inputs, string page)
        {
            List<string> columnNames = new List<string>();
            for (int colIndex = colStartIndex; colIndex <= colEndIndex; colIndex++)
            {
                var columnName = WaitForElementToBePresent(By.XPath("//div[@id='" + page + "']//table//thead//tr//th[" + colIndex + "]"),3).Text;
                columnNames.Add(columnName);
            }
            Assert.IsTrue(inputs.SequenceEqual(columnNames));
        }

        public void ClickColumnsExpandIcon(List<string> inputs, string page, int count)
        {
            List<string> expandedColumnNames = new List<string>();
            string tableXpath = "//div[contains(@class,'epiq-page-body')]";
            var tablesCount = driver.FindElements(By.XPath(tableXpath)).Count;
            var table = WaitForElementToBePresent(By.XPath(string.Format(tableXpath + "[{0}]", count)),2);
            bool found = IsFound(table, string.Format(tableXpath + "[{0}]" + "//*[contains(@class,'epiq-table-data-no-') and text()]", count));
            if (!found)
            {
                this.Pause(2);
                driver.FindElement(By.XPath(".//*[@id='" + page + "']//table[contains(@class,'epiq-table table')]//tbody//tr[1]//i")).Click();
                this.Pause(6);
                if (page == "claims-view-tabs-pane-1" || page == "claims-to-import-tabs-pane-1")
                {
                    foreach (string userInputs in inputs)
                    {
                        var columnName = WaitForElementToBePresent(By.XPath("//table//div[@class='panel-heading'][text()='" + userInputs + "']"),2).Text;
                        expandedColumnNames.Add(columnName);
                    }
                    Assert.IsTrue(inputs.SequenceEqual(expandedColumnNames));
                }
                else
                {
                    string actualMessage = WaitForElementToBePresent(viewSectionText, 3).Text;
                    this.Pause(2);
                    Assert.IsTrue(string.Equals(actualMessage, "Loading the requested document.") || string.Equals(actualMessage, "An error occurred while loading the document."));
                }
            }
        }
        public void ClickNextOnHeader()
        {
            WaitForElementToBePresent(nextArrow, 10).Click();
        }

        public void VerifyCaseHeader(string caseHeader)
        {
            string actualCaseHeader = WaitForElementToBePresent(this.caseHeader, 2).Text;
            Assert.AreEqual(caseHeader, actualCaseHeader);
        }

        public void ClickFilter()
        {
           WaitForElementToBeVisible(filter).Click();
        }
        public void ClickTwoTileFilter()
        {
            this.Pause(2);
            WaitForElementToBeVisible(By.XPath("//div[@class='epiq-page-control pull-right']//button[1]")).Click();
        }
        public void ClickOnCheckBox()
        {
            this.Pause(2);
            WaitForElementToBeVisible(By.XPath("(//table//tbody//tr[1]//td[2]//div)[1]")).Click();
        }
        public void SelectFilterOptions(string field, string option)
        {
            this.Pause(2);
            driver.FindElement(By.XPath("//div[label[text()='" + field + "']]//span[@class='Select-arrow']")).Click();
            IList<IWebElement> options = driver.FindElements(By.XPath("//div[@class='Select-menu-outer']//div//div"));
            options.Where(optionValue => optionValue.Text == option).FirstOrDefault().Click();
            this.Pause(2);
        }
        public void VerifySubHeader(string subHeader)
        {
            string actualSubHeader = WaitForElementToBePresent(By.XPath(".//*[@id='epiq-main-page-wrap']/div//h3[text()='" + subHeader + "']"),3).Text;
            Assert.AreEqual(actualSubHeader.Substring(0, actualSubHeader.IndexOf('(')).Trim(), subHeader.Trim());
        }

        public void SelectPageSize(int pageSize, string section, int count)
        {
            string tableXpath = "//div[contains(@class,'epiq-page-body')]";
            var tablesCount = driver.FindElements(By.XPath(tableXpath)).Count;
            var table = WaitForElementToBePresent(By.XPath(string.Format(tableXpath + "[{0}]", count)),2);
            bool found = IsFound(table, string.Format(tableXpath + "[{0}]" + "//*[contains(@class,'epiq-table-data-no-') and text()]", count));
            if (!found)
            {
                string counter = PageSize(pageSize, section);
            }
        }
        private string PageSize(int pageSize, string xpath)
        {
            this.ScrollDownToPageBottom();
            WaitForElementToBePresent(By.XPath("//div[@id='" + xpath + "']//div[@class='epiq-paging-pagesize']//span[@class='Select-arrow-zone']"),2).Click();
            WaitForElementToBePresent(By.XPath("//div[@id='" + xpath + "']//div[@class='Select-menu-outer']//div//div[text()='" + pageSize + "']"),2).Click();
            this.ScrollDownToPageBottom();
            return null;
        }
        public void VerifyRowsLength(int pageSize, string xpath, int count)
        {
            string tableXpath = "//div[contains(@class,'epiq-page-body')]";
            var table = WaitForElementToBePresent(By.XPath(string.Format(tableXpath + "[{0}]", count)),2);
            bool found = IsFound(table, string.Format(tableXpath + "[{0}]" + "//*[contains(@class,'epiq-table-data-no-') and text()]", count));
            if (!found)
            {
                int countValue = RowsCount(pageSize, xpath);
            }
        }
        private int RowsCount(int pageSize, string xpath)
        {
            this.ScrollUpToPageTop();
            this.Pause(1);
            IList<IWebElement> Rows = driver.FindElements(By.XPath("//div[@id='" + xpath + "']//table//tbody//tr"));
            int rowsLength = Rows.Count() / 2;
            Assert.AreEqual(pageSize, rowsLength);
            return rowsLength;
        }
        public void VerifyDataOnGrid(int pageSize, string status)
        {
            this.Pause(2);
            IList<IWebElement> rows = driver.FindElements(By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr"));
            for (int rowIndex = 1; rowIndex <= rows.Count(); rowIndex++)
            {
                string filterValue = WaitForElementToBePresent(By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr[" + rowIndex + "]/td[8]"),2).Text;
                Assert.AreEqual(filterValue, status);
                rowIndex++;
            }
        }
        public void ClickFilterOption(string option)
        {
            if (option == "xi")
                WaitForElementToBePresent(By.XPath(".//*[@id='epiq-main-page-wrap']//nav//div//i"),2).Click();
            else
                WaitForElementToBePresent(By.XPath("//button[@class='btn btn-info'][text()='" + option + "']"),2).Click();
        }
        public List<string> GetSortedList(string columnName)
        {
            List<string> sortedList = new List<string>();
            var Table = GetClaimRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int rows = 0; rows <= Table.Rows.Count - 1; rows++)
            {
               sortedList.Add(Table.Rows[rows][index].ToString());
            }
            return sortedList;
        }
        public DataTable GetClaimRecords(string sortColumn = null)
        {
            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";

            if (!string.IsNullOrEmpty(sortColumn))
                driver.FindElements(headerTableNames).Where(e => e.Text.Contains(sortColumn.ToUpper())).FirstOrDefault().Click();

            var headerNames = driver.FindElements(headerTableNames).Select(e => e.Text.Trim()).ToList();
            for (int headerIndex = 0; headerIndex <= headerNames.Count - 1; headerIndex++)
            {
                htmlTable.Columns.Add(headerNames[headerIndex]);
                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, headerNames[headerIndex])), 8);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpath, headerNames[headerIndex])));
                    if (rows.Count == 0)
                    {
                        rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[headerIndex]}']"));
                    }
                }
                catch
                {
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[headerIndex]}']"));
                }

                var testList = rows.Select(e => e.Text.Trim()).ToList();
                for (int rowIndex = 0; rowIndex <= testList.Count - 1; rowIndex++)
                {
                    if (headerIndex != 0)
                    {
                        htmlTable.Rows[rowIndex][headerIndex] = testList[rowIndex];
                    }
                    else
                    {
                        htmlTable.Rows.Add(testList[rowIndex]);
                    }
                }
            }
            return htmlTable;
        }

        public void VerifyPaginationAndNavigation(int count, string section)
        {
            string tableXpath = "//div[contains(@class,'epiq-page-body')]";
            string tableXpath2 = "//div[contains(@id,'epiq-outer-container')]";
            var table = WaitForElementToBePresent(By.XPath(string.Format(tableXpath + "[{0}]", count)),2);
            bool found = IsFound(table, string.Format(tableXpath2 + "//div[@id='" + section + "']//*[contains(@class,'epiq-table-data-no-') and text()]"));
            if (!found)
            {
                var pageNumbers = driver.FindElements(By.XPath(string.Format(tableXpath2 + "//div[@id='" + section + "']//*[@class='pagination']//li[not(@class='disabled')]/a[not(descendant::*)]"))).Select(e => e.Text.Trim()).Select(s => Int32.Parse(s)).ToList();
                if (pageNumbers.Last() > 0)
                {
                    int currentPageNumber = Convert.ToInt16(WaitForElementToBeVisible(By.XPath("//div[@id='" + section + "']//*[@class='pagination']//li[@class='active']/a")).Text);
                    int nextPage = ClickPageNext(section);
                    this.Pause(2);
                    if (!(currentPageNumber < nextPage))
                        throw new Exception("[Pagination] - verification failed");
                    int temp = ClickPagePrevious(section);
                    this.Pause(2);
                    if (currentPageNumber != temp)
                        throw new Exception("[Pagination] - verification failed");
                }
                else
                {
                    int currentPageNumber = Convert.ToInt16(WaitForElementToBeVisible(By.XPath("//div[@id='" + section + "']//*[@class='pagination']//li[@class='active']/a")).Text);
                    int nextPage = ClickPageNext(section);
                    this.Pause(2);
                    if (!(currentPageNumber == nextPage))
                        throw new Exception("[Pagination] - verification failed");
                    int temp = ClickPagePrevious(section);
                    this.Pause(2);
                    if (!(currentPageNumber == temp))
                        throw new Exception("[Pagination] - verification failed");
                }
            }
        }

        private bool IsFound(IWebElement element, string xpathValue)
        {
            try
            {
                return element.FindElement(By.XPath(xpathValue)).Enabled;
            }
            catch
            {
                return false;
            }
        }

        private int ClickPageNext(string section)
        {
            this.WaitForElementToBeVisible(By.XPath("//div[@id='" + section + "']//*[@class='pagination']//span[@aria-label='Last']")).Click();
            this.Pause(4);
            return Convert.ToInt16(WaitForElementToBeVisible(By.XPath("//div[@id='" + section + "']//*[@class='pagination']//li[@class='active']/a")).Text);
        }
        private int ClickPagePrevious(string section)
        {
            this.WaitForElementToBeVisible(By.XPath("//div[@id='" + section + "']//*[@class='pagination']//span[@aria-label='First']")).Click();
            this.Pause(4);
            return Convert.ToInt16(WaitForElementToBeVisible(By.XPath("//div[@id='" + section + "']//*[@class='pagination']//li[@class='active']/a")).Text);
        }

        public void ClickClaim(string caseNo)
        {
            this.Pause(2);
            IList<IWebElement> rowsList = driver.FindElements(claimsTableRowsLocator);
            for (int rowIndex = 1; rowIndex <= rowsList.Count(); rowIndex++)
            {
                string actualCaseNo = driver.FindElement(By.XPath("//table//tbody//tr[" + rowIndex + "]//td[2]//span")).Text;
                if (actualCaseNo == caseNo)
                {
                    WaitForElementToBePresent(By.XPath("//table//tbody//tr[" + rowIndex + "]//td[4]//a"),2).Click();
                    break;
                }
                rowIndex++;
            }
        }
        public void VerifyEnabled(string label1, string label2)
        {
            Assert.IsTrue(WaitForElementToBePresent(By.XPath("//div[@class='epiq-table-action-button ']//span[text()='" + label1 + "']"),2).Enabled);
            Assert.IsTrue(WaitForElementToBePresent(By.XPath("//div[@class='epiq-table-action-button ']//span[text()='" + label2 + "']"),2).Enabled);
            importCounter = WaitForElementToBePresent(By.XPath(".//*[@id='claims-to-import-tabs-tab-1']/div/span"), 4).Text;
            beforeImportClaimsCount = Convert.ToInt32(importCounter);
        }
        public void SelectClaimToDelete(string creditorName)
        {
            this.Pause(4);
            string beforeClaimsCountString = WaitForElementToBePresent(By.XPath("//a[@id='claims-view-tabs-tab-1']/div/span"), 5).Text;
            beforeClaimsCount = Convert.ToInt32(beforeClaimsCountString);
            IList<IWebElement> rowsList = driver.FindElements(By.XPath("//div[@id='claims-view-tabs-pane-1']//tbody//tr"));
            if (beforeClaimsCount == 0)
            {
                string actual = WaitForElementToBePresent(By.XPath("//table//tbody//div[@class='text-center epiq-table-data-no-data-message'][text()='No claims in this case']"),2).Text;
                Assert.AreEqual("No claims in this case", actual);
            }
            else
            {
                //for (int rowIndex = 1; rowIndex <= rowsList.Count(); rowIndex++)
                //{
                //    string creditorValue = WaitForElementToBePresent(By.XPath("//table//tbody//tr[" + rowIndex + "]//td[4]//div")).Text;
                //    if (creditorValue == creditorName)
                //    {
                //        WaitForElementToBePresent(By.XPath("//div[@id='claims-view-tabs-pane-1']//table//tbody//tr[" + rowIndex + "]//td[2]//div")).Click();
                //        deleteCounter++;
                //    }
                //    rowIndex++;
                //}
                this.Pause(4);
                driver.FindElement(By.XPath("(//tbody/tr[3]/td[2]/div)[2]")).Click();
            }
        }
        public void VerifyMessageOnTable(string message)
        {           
            string actualMessageOnTable =WaitForElementToBePresent(By.XPath("//table//div[text()='"+ message + "']"), 2).Text;
            Assert.AreEqual(message, actualMessageOnTable);
        }
        public void ClickDeleteClaim()
        {
            string bclaimsCount = WaitForElementToBePresent(By.XPath("(//div[@id='claims-view-tabs']//a//span)[1]"), 4).Text;
            int beforecount = Convert.ToInt32(bclaimsCount)-1;
            WaitForElementToBePresent(delete).Click();
            this.Pause(2);
            string aclaimsCount = WaitForElementToBePresent(By.XPath("(//div[@id='claims-view-tabs']//a//span)[1]"), 4).Text;
            Assert.AreEqual(beforecount, Convert.ToInt32(aclaimsCount));
        }
        public void SelectClaimToImportOrIgnore(string creditorName)
        {
            this.Pause(4);
            string beforeClaimsCountString = WaitForElementToBePresent(By.XPath(".//*[@id='claims-to-import-tabs-tab-1']/div/span"), 7).Text;
            beforeClaimsCount = Convert.ToInt32(beforeClaimsCountString);
            IList<IWebElement> rowsList = driver.FindElements(By.XPath("//div[@id='claims-to-import-tabs']//tbody//tr"));
            if (beforeClaimsCount == 0)
            {
                string actual = driver.FindElement(By.XPath("//table//tbody//td[text()='No data to display']")).Text;
                Assert.AreEqual("No data to display", actual);
            }
            else
            {
                //for (int rowIndex = 1; rowIndex <= rowsList.Count(); rowIndex++)
                //{
                //    string actualCreditName = WaitForElementToBePresent(By.XPath("//div[@class='epiq-table-tab']//table//tbody//tr[" + rowIndex + "]//td[5]//div")).Text;
                //    if (actualCreditName == creditorName)
                //    {
                //        driver.FindElement(By.XPath("//table//tbody//tr[" + rowIndex + "]//td[2]//div")).Click();
                //        counter++;
                //    }
                //    rowIndex++;
                //}
                driver.FindElement(By.XPath("(//table//tbody//tr[1]//td[2]//div)[1]")).Click();
            }
        }
        public void ClickImportRestore(string option)
        {
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-table-action-button ']//span[text()='" + option + "']"), 3).Click();
            this.Pause(2);
        }
        public void ClickImportOrIgnoreClaim(string option)
        {
            string bClaimsCount = WaitForElementToBePresent(By.XPath(".//*[@id='claims-to-import-tabs-tab-1']/div/span"), 4).Text;
            int beforeImportClaimsCount = Convert.ToInt32(bClaimsCount);
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-table-action-button ']//span[text()='" + option + "']"), 3).Click();
            this.Pause(2);
            string aclaimsCount = WaitForElementToBePresent(By.XPath(".//*[@id='claims-to-import-tabs-tab-1']/div/span"), 4).Text;
            int afterClaimsCount = Convert.ToInt32(aclaimsCount);
            this.Pause(5);
            Assert.AreEqual(beforeImportClaimsCount-1, afterClaimsCount);
        }
        public void SelectTabViewDocuments()
        {
            WaitForElementToBePresent(selectViewDocumentsTab, 2).Click();
            this.Pause(4);
        }
        public void VerifyHeader(string header)
        {
            string actualHeader = WaitForElementToBePresent(importClaimsHeader, 8).Text;
            Assert.AreEqual(actualHeader, header);
        }
        public void VerifyTheSubHeader(string subHeader)
        {
            string actualSubHeader = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-header has-right-content ']//h2[text()='" + subHeader + "']")).Text;
            Assert.AreEqual(actualSubHeader, subHeader);
        }
        public void VerifyAssetsNavigation()
        {
            WaitForElementToBePresent(assetsLocator, 2).Click();
        }
        public void VerifyAssetsData()
        {
            string actualCellValue = WaitForElementToBePresent(assetCellData, 8).Text;
            Assert.IsTrue(string.Equals(actualCellValue, "Open") || string.Equals(actualCellValue, "Close") || string.Equals(actualCellValue, "All"));
        }
        public void DisplayAssetsButton()
        {
            bool elementPresence = false;
            try
            {
                elementPresence = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-heading clearfix']//ul//li[1]//a//span[text()='ASSETS']"),2).Enabled;
            }
            catch
            {
                Assert.IsFalse(elementPresence);
            }
        }
        public void ClickSettingsIcon()
        {
            WaitForElementToBePresent(settingsIcon).Click();
        }
        public void VerifySections(List<string> sectionsList)
        {
            foreach (string section in sectionsList)
            {           
                string actualSection= WaitForElementToBePresent(By.XPath("//div[@class='tab-content']//div[text()='"+ section + "']")).Text;
                Assert.AreEqual(section, actualSection);
            }
        }
        public void ExpandSectionByClick(List<string> sectionHeaderList, List<string> sectionLabelsList)
        {
            foreach (string section in sectionHeaderList)
            {
                WaitForElementToBePresent(By.XPath("//div[@class='tab-content']//div[text()='" + section + "']")).Click();
                foreach (string label in sectionLabelsList)
                {
                    this.Pause(2);
                    if (section == "GENERAL IMPORT DEFAULTS" && label == "DEFAULT STATUS")
                    {
                        bool labelStatus = WaitForElementToBePresent(By.XPath("//div[@class='panel panel-default'][@title='" + section + "']//label[contains(text(),'" + label + "')]")).Displayed;                                             
                        break;  
                    }
                    else
                    {
                        if (!(section == "GENERAL IMPORT DEFAULTS") && !(label == "DEFAULT STATUS"))
                        {
                            bool labelStatus = WaitForElementToBePresent(By.XPath("//div[@class='panel panel-default'][@title='" + section + "']//label[contains(text(),'" + label + "')]")).Displayed;                                                  
                        }                       
                    }                     
                }
            }           
        }
        public void ClickCheckBox(List<string> sectionCheckBoxList)
        {
            var checkBoxActualList = driver.FindElements(By.XPath("//span[starts-with(@class,'has-text')]")).ToList();
            List<string> checkBoxNames = new List<string>();
            for (int checkOptionCount = 0; checkOptionCount < checkBoxActualList.Count; checkOptionCount++)
            {
                var name = checkBoxActualList[checkOptionCount].Text;
                checkBoxNames.Add(name);
                checkBoxActualList[checkOptionCount].Click();
            }
            Assert.IsTrue(sectionCheckBoxList.SequenceEqual(checkBoxNames));
        }
        public void VerifyLabels(List<string> sectionHeaderList, List<string> sectionLabelsList)
        {
            foreach (string section in sectionHeaderList)
            {
                WaitForElementToBePresent(By.XPath("//div[@class='tab-content']//div[text()='" + section + "']")).Click();
                this.Pause(2);
                foreach (string label in sectionLabelsList)
                {
                    string labelName = WaitForElementToBePresent(By.XPath("//div[@class='panel panel-default'][@title='" + section + "']//label[contains(text(),'" + label + "')]")).Text;
                    this.Pause(1);
                    Assert.AreEqual(labelName, label);                  
                }
            }
        }
        public void SelectData(string sectionHeader, List<string> sectionLabelsList, List<string> amountList)
        {   
            int listIndex = 0;
            foreach (string label in sectionLabelsList)
             {
                this.Pause(2);         
                WaitForElementToBePresent(By.XPath("//div[@class='panel panel-default'][@title='" + sectionHeader + "']//div[label[contains(text(),'" + label + "')]]//div[@class='Select-input']//input"),3).SendKeys(amountList[listIndex]);
                WaitForElementToBePresent(By.XPath("//div[@class='panel panel-default'][@title='" + sectionHeader + "']//div[label[contains(text(),'" + label + "')]]//div[@class='Select-input']//input"),3).SendKeys(Keys.Down);
                WaitForElementToBePresent(By.XPath("//div[@class='panel panel-default'][@title='" + sectionHeader + "']//div[label[contains(text(),'" + label + "')]]//div[@class='Select-input']//input"),3).SendKeys(Keys.Enter);
                listIndex++;              
             }        
        }             
        public void ClickSave()
         {
            WaitForElementToBePresent(save, 3).Click();
         }
        public void ClickOnDocumentNumberToImportLink()
        {
            IList<IWebElement> DocumentToImportList = this.WaitForElementsToBeVisible(By.XPath("//td[@data-title='DATES TO IMPORT']/a")).ToList();
            DocumentToImportList[0].Click();
        }

        public void VerifyPaginationAndNavigations()
        {
            IWebElement element = WaitForElementToBeVisible(paginations, 8);
            JSMoveToViewElement(element);
            element.Displayed.Should().BeTrue();

            var pageNumbers = driver.FindElements(page).Select(e => e.Text.Trim()).Select(s => int.Parse(s)).ToList();

            if (pageNumbers.Last() > 1)
            {
                int active = Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
                int nextPage = ClickPageNext();
                if (!(active < nextPage))
                    throw new Exception("[Pagination] - verification failed");
                int temp = ClickPagePrevious();
                if (active != temp)
                    throw new Exception("[Pagination] - verification failed");
            }
            else
            {
                int active = Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
                int nextPage = ClickPageNext();
                if (!(active == nextPage))
                    throw new Exception("[Pagination] - verification failed");
                int temp = ClickPagePrevious();
                if (!(active == temp))
                    throw new Exception("[Pagination] - verification failed");
            }
        }
        private int ClickPageNext()
        {
            this.WaitForElementToBeVisible(next).Click();
            return Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
        }
        private int ClickPagePrevious()
        {
            this.WaitForElementToBeVisible(previous).Click();
            return Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
        }
    }
}