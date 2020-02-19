using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using FluentAssertions;
using System.Data;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dates
{
    public class DatesPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        public DatesPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        private By datesPageHeader = By.XPath("//div[@class='epiq-page-header']/h2");
        private By datesPageFilterOption = By.XPath("//button[@title='View and change current filters.']");
        private By datesPageFilterClose = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[1]/i");
        private By datesPageBreadcrumb = By.XPath("//*[@role='navigation']");
        private By datesPageHeaderNames = By.XPath("//th[@class='epiq-table-header-sortable ' or @class='epiq-table-header-sortable  visible-lg visible-xl' or @class='epiq-table-header-sortable  visible-md visible-lg visible-xl']");
        private By datesPageFilerOption = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[2]/h3");
        private By datesPageRefresh = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[3]/div[2]/div/div[1]/button[2]");
        //private By DATES_PAGE_FILTEROPTIONS_CaseOrDebtor = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//div[@class='rbt-input-wrapper']//div[1]/input");
        private By datesPageFilterOptionsCaseOrDebtor = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//div[@class='rbt-input-wrapper']//div[1]/input[@class='rbt-input-main']");
        //private By DATES_PAGE_FILTEROPTIONS_CaseOrDebtor_Selection = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//ul/li/a");
        private By datesPageFilterOptionsCaseOrDebtorSelection = By.XPath("//div[@class='row']/div/div/ul/li/a");
        private By datesPageResetButton = By.XPath("//button[text()='RESET']");
        private By datesPageCloseButton = By.XPath("//button[text()='CLOSE']");
        private string datesFilterSelect = "//div/div[text()='{0}']";
        private By datesPageCaseNumber = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[2]/td/div/div[1]/div/div[1]");
        private By datesPageAssetStatus = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[2]/td/div/div[4]/div/div[1]");
        private By datesPageRowExpandButton = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[1]/td[1]/div/i");
        private By pageCount = By.XPath("//h3[text()='Dates']/span");
        private By pagination = By.ClassName("pagination");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By datesCaseStatusFilter = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[3]/form/div[2]/div/div/span[3]/span");

        // Add/ Manage Dates
        private By addDates = By.XPath("//button[text()=' Date']");
        private By convertedToChapter7 = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div/div[2]/div[2]/div/div[1]/div/div/div[2]/div/div[2]/div[2]/div/button");
        private By ndrDate = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div/div[2]/div[2]/div/div[2]/div/div/div[2]/div/div[5]/div[2]/div/button");
        private By datesInput = By.XPath(".//*[@id='EpiqInLineEdit']/div[2]/form/div[1]/div/div/div/div/span/div/input");
        private By tickButton = By.XPath("//div[@class='col-md-2']//button[@class='btn btn-info']//i");
        private By crossButton = By.XPath(".//*[@id='EpiqInLineEdit']/div[2]/form/div[2]/div[2]/button");
        private By convertedFrom7DateButton = By.XPath("//div[@class='panel-group']/div[2]//div[@class='panel-body']/div[1]//div[@class='col-xs-6 col-sm-6 col-md-2 panel-content-dates']//button");
        private By dismissalDateButton = By.XPath("//div[@class='panel-group']/div[2]//div[@class='panel-body']/div[2]//div[@class='col-xs-6 col-sm-6 col-md-2 panel-content-dates']//button");
        private By datesInputLocator = By.XPath("//input[@class='form-control']");
        private By caseDateUpdateToastMessage = By.XPath("//div[@class='toastr animated rrt-success']");
        private By closingDateWarnMessage = By.XPath("//div[@class='warn-message']/strong");

        public void ClickOnAddDate()
        {
            this.WaitForElementToBeVisible(addDates).Click();
            Thread.Sleep(2000);
        }
        public void ClickCovertedToChapter7()
        {
            this.WaitForElementToBeVisible(convertedToChapter7).Click();
        }

        public void ClickNDR()
        {
            this.WaitForElementToBeVisible(ndrDate).Click();
        }
        public void SetDates(string datesSelected)
        {
            this.WaitForElementToBeVisible(datesInput).Clear();
            this.WaitForElementToBeVisible(datesInput).SendKeys(datesSelected);
            
        }

        public void ClickOnTickButton()
        {
            this.WaitForElementToBeVisible(tickButton).Click();
        }
        public void clickOnRowExpandButton()
        {
            this.WaitForElementToBeVisible(datesPageRowExpandButton).Click();
        }
        public bool GetCaseNumberDisplayed()
        {
            return driver.FindElement(datesPageCaseNumber).Displayed;
        }
        public bool GetAssetStatusisplayed()
        {
            return driver.FindElement(datesPageAssetStatus).Displayed;
        }
        public void ClickOnResetButton()
        {
            this.Pause(1);
            var e = driver.FindElement(datesPageResetButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public void ClickOnCloseButton()
        {
            this.Pause(1);
            var e = driver.FindElement(datesPageCloseButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public string GetHeaderName()
        {
            Pause(3);
            Thread.Sleep(1500);
            return this.WaitForElementToBeVisible(datesPageHeader).Text;
        }

        public void ClickOnFilter()
        {
            this.WaitForElementToBeVisible(datesPageFilterOption).Click();
        }

        public void ClickOnFilterClose()
        {
            this.WaitForElementToBeVisible(datesPageFilterClose).Click();
        }
        public string GetFilterOptionHeader()
        {
            try
            {
                Pause(1);
                return driver.FindElement(datesPageFilerOption).Text;
            }
            catch
            {
                return null;
            }

        }
        public void EnterCaseNumber(string caseNumber)
        {
            this.Pause(2);       
            this.WaitForElementToBeVisible(datesPageFilterOptionsCaseOrDebtor).SendKeys(caseNumber);
            this.Pause(3);
            this.WaitForElementToBeVisible(datesPageFilterOptionsCaseOrDebtorSelection).Click();
            //this.WaitForElementToBeVisible(DATES_PAGE_FILTEROPTIONS_CaseOrDebtor).SendKeys(Keys.Down);
            //this.WaitForElementToBeVisible(DATES_PAGE_FILTEROPTIONS_CaseOrDebtor).SendKeys(Keys.Enter);
        }

        public void SelectCaseStatus(string status)
        {
            this.WaitForElementToBeVisible(datesCaseStatusFilter).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(datesFilterSelect, status))).Click();
        }

        public DataTable GetDatesRecords(string SortColumn = null)
        {
            this.WaitForElementToBeVisible(datesPageHeaderNames);
            this.Pause(3);
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(datesPageHeaderNames).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(datesPageHeaderNames).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 2; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);
                try
                {
                    //this.Pause(2);
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']//span[text()]"));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }

                var testList = rows.Select(e => e.Text).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) { htmlTable.Rows[j][i] = testList[j]; }
                    else { htmlTable.Rows.Add(testList[j]); }
                }
            }

            return htmlTable;
        }

        public List<string> GetSortedList(string columnName)
        {
            List<string> list = new List<string>();
            Thread.Sleep(1500);
            var Table = GetDatesRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add(Table.Rows[i][index].ToString());
            }
            return list;
        }
        public void ClickOnReferesh()
        {
            this.WaitForElementToBeVisible(datesPageRefresh).Click();
            Pause(3);
        }

        public string GetPageCount()
        {
            return this.WaitForElementToBeVisible(pageCount).Text;
        }

        public Dictionary<string, object> GetPagination()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Pagination", this.WaitForElementToBeVisible(pagination).Displayed);
            dict.Add("ActivePage", this.WaitForElementToBeVisible(activePage).Text);
            return dict;
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

        public void EnterDebtor(string debtor)
        {
            this.WaitForElementToBeVisible(datesPageFilterOptionsCaseOrDebtor).SendKeys(debtor);
            this.WaitForElementToBeVisible(datesPageFilterOptionsCaseOrDebtorSelection).Displayed.Should().BeTrue();
            var e = this.WaitForElementToBeVisible(datesPageFilterOptionsCaseOrDebtorSelection);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }

       public void performClickOnDate()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(addDates)).ClickAndHold().Perform();
            this.PressEscapeKey();
        }
        public void Add_Converted_from_7_Date(string date)
        {
            this.WaitForElementToBeVisible(convertedFrom7DateButton).Click();
            this.WaitForElementToBeVisible(datesInputLocator).Clear();
            this.WaitForElementToBeVisible(datesInputLocator).SendKeys(date);
            this.WaitForElementToBeVisible(By.XPath("//div[@class='col-md-2']//button[@class='btn btn-info']//i")).Click();   
        }

        public void Add_Dismissal_Date(string date)
        {
            this.WaitForElementToBeVisible(dismissalDateButton).Click();
            this.WaitForElementToBeVisible(datesInputLocator).Clear();
            this.WaitForElementToBeVisible(datesInputLocator).SendKeys(date);
            this.WaitForElementToBeVisible(By.XPath("//div[@class='col-md-2']//button[@class='btn btn-info']//i")).Click();
        }
        public bool ValidateToastrMessage()
        {
            ClickOnTickButton();
            return this.WaitForElementToBeVisible(caseDateUpdateToastMessage).Displayed;
        }
        public bool VefifyWarnMessage()
        {
            return this.WaitForElementToBeVisible(closingDateWarnMessage).Displayed;
        }
    }
}
