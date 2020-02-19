using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.List;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;
using System.Collections;
using System.Data;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Case_List
{
    public class NewCaseListSearchPage : PageObject
    {
        private static string pageTitle = "UNITY";
        //Filter Section Buttons
        private By filterIconLocator = By.XPath("(//button[@type='button'])[4]");
        private By resetButtonLocator = By.XPath("//button[text()='RESET']");
        private By closeButtonLocator = By.XPath("//button[text()='CLOSE']");
        private By closeFilterOptionsLocator = By.XPath("//nav/div/i");
        private By caseExpandLocator = By.XPath("//i[@class='epiq-table-icon-more-info fa text-info fa-chevron-circle-down']");
        private By feePaidCheckbox = By.XPath("//i[@class='fa fa-check epiq-cursor-pointer']");
        private By feeAmount = By.XPath("//input[@name='feeAmount']");
        private By feePaidd = By.XPath("//input[@name='feePaid']");
        private By datePaidd = By.XPath("//div[@class='form-group']//div[3]//span[@class='input-group']//input");
        private By reference = By.XPath("//input[@name='feeReference']");
        private By caseFeeSaveButton = By.XPath("//button[text()='SAVE']");
        private By collapseUpButton = By.XPath("//div[@class='visible-sm visible-md visible-lg visible-xl']//i[@class='epiq-table-icon-more-info fa text-info fa-chevron-circle-up']");
        private By caseFeeCancelButton = By.XPath("//button[text()='CANCEL']");
        private By caseFeeCloseButton = By.XPath("//div[@class='modal-footer']//button[text()='CANCEL']");

        //Locator of Filter Sections
        private By caseInputLocator = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//input[1]");
        private By noMatchesFoundMessageLocator = By.XPath("//li[@class='menu-item-footer disabled']/a");
        private By assetStatusDropdownLocator = By.XPath("//div[label[text()='ASSET STATUS']]//span/div[1]");
        private By caseStatusDropdownLocator = By.XPath("//div[label[text()='CASE STATUS']]//span/div[1]");
        private By feePaidDropdownLocator = By.XPath("//div[label[text()='FEE PAID']]//span/div[1]");
        private string statusSelect = "//div/div[text()='{0}']";
        private By dropdownCaseLocator = By.XPath("//a[@class='dropdown-item']");
        private By pageSize = By.XPath("//div[@class='epiq-paging-pagesize-control']/div/div");

        //CaseList Table locator
        private By expandAndCollapseButtonLocator = By.XPath("//tr/td/div/i");
        private By meetingHeaderNames = By.XPath("//div[4]/div/div/table/thead/tr/th[2]");

        //old locators which can be removed
        private By meetingDateLocator = By.XPath("//span[text()='04/09/17']");
        private By petitionDateLocator = By.XPath("//span[text()='04/06/17']");
        private By debtorNameLocator = By.XPath("//div[text()='Mr. Naresh Raj DAttorney_QA1']");
        private By assetStatusLocator = By.XPath("//td[text()='Asset']");
        private By caseStatusLocator = By.XPath("//td[text()='Open']");
        private By caseTableLocator = By.XPath("//table[@class='epiq-table table table-condensed']");
        //private By DEBTOR_NAME = By.XPath("//div[@class='epiq-ellipsis-text']/a/span/span");
        private By debtorName = By.XPath("//div[@class='epiq-ellipsis-text']/a/span");
        public CaseListPage CaseListPage;

        public NewCaseListSearchPage(IWebDriver driver) : base(driver, pageTitle)
        {
            this.driver = driver;
        }


        public void MouseHouver()
        {

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(debtorName)).Perform();
            this.PressEscapeKey();
        }
        public void  SearchFilterIcon()
        {
            this.Pause(2);
            var viewFilter = WaitForElementToBeClickeable(By.XPath("//button[@title='View and change current filters.']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", viewFilter);
        }

        public void EnterCaseNumber(string caseNum)
        {
            this.Pause(2);
            this.ClearAndType(this.WaitForElementToBeVisible(caseInputLocator), caseNum);
        }
        public void EnterCaseName(string caseName)
        {
            this.ClearAndType(this.WaitForElementToBeVisible(caseInputLocator), caseName);
        }

        public void SelectCaseList()
        {
            this.WaitForElementToBeVisible(dropdownCaseLocator,4).Click();
        }

        public NewCaseListSearchPage SelectCase()
        {
            CaseListPage.SearchSection.SelectCaseList();
            return this;
        }

        public void CloseFilterOptions()
        {
            this.WaitForElementToBeVisible(closeFilterOptionsLocator,2).Click();
        }

        public void CasesWithSameCaseNumber(string CaseNumber)
        {
            this.WaitForElementToBeClickeable(expandAndCollapseButtonLocator,3).Click();
            IWebElement CaseNum = driver.FindElement(By.XPath($"//div[div[text()='CASE #']]//span/span[text()='{CaseNumber}']"));
            var CaseNumb = CaseNum.Text;
            Assert.AreEqual(CaseNumb, CaseNumber);
        }
        public void CasesWithSameCaseName(string caseName)
        {
            this.Pause(4);
            IList<IWebElement> DebtorData = driver.FindElements(By.XPath("//div[contains(@class,'epiq-table-wrapper')]//td[5]"));

            String[] allText = new String[DebtorData.Count];
            int i = 0;
            foreach (IWebElement element in DebtorData)
            {
                allText[i++] = element.Text;
                var ActualList = element.Text;
                if (ActualList == caseName)
                {
                    break;
                }
            }
        }

        public void EnterDates(string titleFrom, string DateFrom, string titleTo, string DateTo)
        {
            var fromDate = WaitForElementToBeVisible(By.XPath($"//div[label[text()='{titleFrom}']]//input"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fromDate);
            this.Pause(3);
            fromDate.SendKeys(DateFrom);
            var toDate = WaitForElementToBeVisible(By.XPath($"//div[label[text()='{titleTo}']]//input"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", toDate);
            this.Pause(3);
            toDate.SendKeys(DateTo);
        }

        public void FiltereddataonGrid(string title, int j, string fromdate, string todate)
        {
            try
            {
                this.Pause(2);
                IWebElement table = driver.FindElement(By.XPath("//div[@class='epiq-page-body']//div//table//tbody"));
                IList<IWebElement> tableRows = table.FindElements(By.XPath("//tr"));
                this.Pause(2);
                var count = WaitForElementToBePresent(By.XPath("//div[contains(@class,'epiq-page-controls')]/div/h3//span//span")).Text;
                int countvalue = int.Parse(count);
                string actualfromdate = fromdate.Substring(0, 8);
                string actualtodate = todate.Substring(0, 8);
                var text = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-body']//div//table//thead//tr//th["+j+"]")).Text;
                if (text == title)
                {
                    for (int i = 1; i <= countvalue; i++)
                    {
                        this.Pause(2);
                        string celldata = table.FindElement(By.XPath("//tr[" + i + "]//td[" + j + "]//span")).Text;
                        Console.WriteLine(celldata);
                        Assert.GreaterOrEqual(DateTime.Parse(celldata), DateTime.Parse(actualfromdate));
                        Assert.LessOrEqual(DateTime.Parse(celldata), DateTime.Parse(actualtodate));
                        i++;
                    }
                }
            }
            catch(Exception)
            {

            }
        }     
        public void CasesWithClaimsDates()
        {
            this.Pause(3);
            IList<IWebElement> Rows = driver.FindElements(By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr"));
            int RowLength = Rows.Count;
            for (int i = 1; i <= RowLength; i++)
            {
                WaitForElementToBeClickeable(By.XPath("//tbody/tr[" + i + "]/td[1]/div/i"),4).Click();
                //var dateHistory = WaitForElementToBeVisible(By.XPath("//div[div[text()='DATE HISTORY']]/div/i"), 4);
                var dateHistory = WaitForElementToBeVisible(By.XPath("//div[text()='DATE HISTORY']"), 4);
                Actions action = new Actions(driver);
                action.MoveToElement(dateHistory).Build().Perform();
                i++;
            }
        }
        public void SelectAssetStatus(string assetStatus)
        {
            this.Pause(3);
            WaitForElementToBeClickeable(assetStatusDropdownLocator).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(statusSelect, assetStatus))).Click();
        }
        public void SelectCaseStaus(string caseStatus)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(caseStatusDropdownLocator).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(statusSelect, caseStatus))).Click();
        }
        public void SelectFeePaid(string feepaid)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(feePaidDropdownLocator,3).Click();
            var dr = driver.FindElement(By.XPath($"//div[text()='{feepaid}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", dr);
            this.Pause(2);
            dr.Click();

        }
        public void AssetColumnData(string assetColumn)
        {
            this.Pause(4);
            IList<IWebElement> assetStatusData = driver.FindElements(By.XPath("//div[contains(@class,'epiq-table-wrapper')]//td[8]"));

            String[] allText = new String[assetStatusData.Count];
            int i = 0;
            foreach (IWebElement element in assetStatusData)
            {
                allText[i++] = element.Text;

                var ActualList = element.Text;
                Assert.AreEqual(ActualList, assetColumn);
            }
            //i++;
        }
        public void CaseStatusColumnData(string caseStatusColumn)
        {
            this.Pause(2);
            IList<IWebElement> CaseStatusData = driver.FindElements(By.XPath("//div[contains(@class,'epiq-table-wrapper')]//td[9]"));

            String[] Text = new String[CaseStatusData.Count];
            int k = 0;
            foreach (IWebElement element in CaseStatusData)
            {
                Text[k++] = element.Text;
                var ActualList = element.Text;
                Assert.AreEqual(ActualList, caseStatusColumn);
            }
            this.Pause(3);
        }
        public void ClickOnReset()
        {
            var reset = driver.FindElement(resetButtonLocator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", reset);
            this.Pause(2);
        }
        public void ClickOnClose()
        {
            var close = driver.FindElement(By.XPath("//button[text()='CLOSE']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", close);
            Thread.Sleep(3000);
        }
        public void CasesInCaseTable()
        {
            this.WaitForElementToBeVisible(caseTableLocator);
        }
        public void ClickOnCaseExpandButton()
        {
            this.Pause(3);
            IList<IWebElement> CaseExpandButtons = driver.FindElements(caseExpandLocator).ToList();
            CaseExpandButtons[0].Click();
            Pause(1);
        }
        public void ClickOnFeePaidCheckbox()
        {
            this.Pause(3);
            IList<IWebElement> Feepaid_checkbox = driver.FindElements(feePaidCheckbox).ToList();
            Feepaid_checkbox[1].Click();
        }
        public void EnterFeeAmount(string amount)
        {
            this.WaitForElementToBeVisible(feeAmount).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
            this.WaitForElementToBeVisible(feeAmount).SendKeys(amount);
        }
        public void EnterFeePaid(string feePaid)
        {
            this.WaitForElementToBeVisible(feePaidd).Click();
            this.WaitForElementToBeVisible(feePaidd).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
            this.WaitForElementToBeVisible(feePaidd).SendKeys(feePaid);
        }
        public void EnterDatePaid(string datePaid)
        {
            this.WaitForElementToBeVisible(datePaidd).Click();
            this.WaitForElementToBeVisible(datePaidd).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
            this.WaitForElementToBeVisible(datePaidd).SendKeys(datePaid);
            this.WaitForElementToBeVisible(By.XPath("//label[text()='DATE PAID']")).Click();
        }
        public void ClickOnCaseFeeSAVE()
        {
            this.WaitForElementToBeVisible(caseFeeSaveButton).Click();
            this.WaitForElementToBeVisible(collapseUpButton).Click();
            Pause(1);
        }
        public void ClickOnCaseFeeCANCEL()
        {
            this.WaitForElementToBeVisible(caseFeeCancelButton).Click();
        }

        public void ClickOnCaseFeeCLOSE()
        {
            this.WaitForElementToBeVisible(caseFeeCloseButton).Click();
            Pause(1);
        }

        public bool VerifySAVE_Button()
        {
            return this.WaitForElementToBeVisible(caseFeeSaveButton).Displayed;
        }
        public bool VerifyCANCEL_Button()
        {
            return this.WaitForElementToBeVisible(caseFeeCancelButton).Displayed;
        }
        public bool VerifyCLOSE_Button()
        {
            return this.WaitForElementToBeVisible(caseFeeCloseButton).Displayed;
        }


        public void Verify341MeetingPageTableColumns(List<string> titles)
        {
            List<string> Columnnames = new List<string>();
                for (int column = 5; column <= 11; column++)
                {
                    var TableElements = driver.FindElement(By.XPath("//div[4]/div/div/table/thead/tr/th[2][" + column + "] | //table//tr[1]//th[" + column + "]")).Text;
                    Columnnames.Add(TableElements);
                }
                bool equal = titles.SequenceEqual(Columnnames);
        }

        public List<DateTime> SortingColumns(string column)
        {
            List<DateTime> list = new List<DateTime>();

            var Table = Get341MeetingRecords(column);
            int index = Table.Columns[column].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add((DateTime)Table.Rows[i][index]);
            }
            return list;
        }


        public DataTable Get341MeetingRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(meetingHeaderNames).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            var headerNames = driver.FindElements(meetingHeaderNames).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 1; i++)
            {
                htmlTable.Columns.Add(headerNames[i], typeof(DateTime));
                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, headerNames[i])), 8);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpath, headerNames[i])));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }
                var testList = rows.Select(e => e.Text.Trim()).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) {
                        htmlTable.Rows[j][i] = DateTime.Parse(testList[j]);
                    }
                    else { htmlTable.Rows.Add(DateTime.Parse(testList[j])); }
                }
            }
            return htmlTable;
        }
          public void SelectPageSize(int PageSize)
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeClickeable(pageSize,2).Click();
            WaitForElementToBeClickeable(By.XPath("//div[@class='Select-menu']/div[text()='" + PageSize + "']"),2).Click();
            this.Pause(2);
            this.ScrollDownToPageBottom();
        }
    }
}
