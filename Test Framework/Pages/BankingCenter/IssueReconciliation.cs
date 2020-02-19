using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    public class IssueReconciliation : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        #region Constructor
        public IssueReconciliation(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        #endregion

        #region Page Objects
        By transactionsTables = By.XPath("//div[@class='epiq-table-title-bar epiq-background-info' or @class='epiq-table-title-bar bg-primary']/strong");
        //By BREDCRUMB_LINK = By.XPath("//ol['navigation']//a");
        By transactionsTablesSortingOption = By.XPath("//div[@class='Select-control']/span/div[@class='Select-value']/span[child::*]");
        By bankAccountDataCaseName = By.CssSelector(".bank-account-data");
        By bankAccountDataAccountNumber = By.CssSelector("span[class='text-info bank-account-number-data']");
        By leftArrow = By.XPath("//a[@class='case-header-carousel-arrow']/i[contains(@class,'left')]");
        By rightArrow = By.XPath("//a[@class='case-header-carousel-arrow']/i[contains(@class,'right')]");
        By dataCaseName = By.XPath("//span[@class='case-header-data-number']");
        By radioButtons = By.XPath("//td[@data-title='SERIAL #']/../td[2]/div/label");
        By filterArrow = By.XPath("//div[@class='Select-control'][child::span[3]]");
        By filterOptionText = By.XPath("//div[@class='Select-control'][child::span[3]]/span/div/span[2]");
        By toastMessage = By.XPath("//div[@class='toastr animated rrt-success']/div/div[@class='rrt-middle-container']/div[2]");
        By bankTransactionValue = By.XPath("//div[@class='epiq-table-title-bar epiq-background-info']//div[contains(@class,'issue-reconcile-balance')]//span");
        By ledgerTransactionValue = By.XPath("//div[@class='epiq-table-title-bar bg-primary']//div[contains(@class,'issue-reconcile-balance')]//span");
        By ignoreButton = By.XPath("//button[@class='issue-reconcile-btn-transparent btn btn-default']");
        By toastrLocator = By.XPath("//div[@Class='toastr animated rrt-success']//div[@class='rrt-middle-container']//div[@class='rrt-text']");
        By bankTransactionCheckbox = By.XPath("//div/div[1][@class='epiq-page-body col-sm-6']//div[@class='epiq-input-styled-radio-checkbox']");
        By ledgerTransactionCheckbox = By.XPath("//div/div[2][@class='epiq-page-body col-sm-6']//div[@class='epiq-input-styled-radio-checkbox']");
        By bankFooter = By.XPath("//div[@class='container']//div[@class='row issue-reconcile-footer-bank-row']");
        By ledgerFooter = By.XPath("//div[@class='container']//div[@class='row issue-reconcile-footer-ledger-row']");
        By bankFooterClose = By.XPath("//div[@class='row issue-reconcile-footer-bank-row']//div[6]//button[@class='issue-reconcile-btn-x btn btn-default']/i");
        By ledgerFooterClose = By.XPath("//div[@class='row issue-reconcile-footer-ledger-row']//div[6]//button[@class='issue-reconcile-btn-x btn btn-default']/i");
        By bankActivityBlankFooter = By.XPath("//div[@class='issue-reconcile-footer-no-selection text-center']/h3");

        By arrowClick = By.XPath("//div[@class='epiq-table-title-bar epiq-background-info']//span//span[@class='Select-arrow'][1]");

        // Generic Xpath Format
        string transactionHeaderNames = "//div[strong[text()='{0}']]/../div[2]//tr/*[@class='epiq-table-header-sortable 'or @class='epiq-table-header-sortable  visible-lg visible-xl' or @class='epiq-table-header-sortable visible-lg visible-xl'][child::*]";
        string rowXpathPrefix = "//div[strong[text()='{0}']]/../div[2]//tr//td[@data-title='{1}']";
        string defaultPageCount = "//div[strong[text()='{0}']]/../div[2]/div/div[2]/div[1]//span[text()]";
        string unlinkedTransactionAmount = "//div[strong[text()='{0}']]/../div[2]//tr//td[@data-title='AMOUNT']//span[contains(text(),'-')]";
        string radioButtonLinkOrUnlinkTransaction = "//td[@data-title='SERIAL #'][contains(text(),'{0}')]/../td[2]/div/label";
        string filterText = "//div[text()='{0}']";
        string filterX = "//div[@data-test-selector='elecFilterValue']//div[@class='Select-control'][child::span[3]]/span/div/span[not(text()='{0}')]/preceding-sibling::span";
        string transactionSerialNumber = "//td[@data-title='SERIAL #'][contains(text(),'{0}')]";
        string filterOptionSelected = "//div[strong[text()='{0}']]//div[2]/div/div";
        string filterOptionsText = "//div[strong[text()='{0}']]//div[@class='Select-menu-outer']/div/child::div";
        string expandRecord = "//div[strong[text()='{0}']]/../div[2]//table//tr[not(@class='epiq-table-details-row')][1]//td[@class='epiq-table-view-more sm md lg xl'][1]//i";
        string recordStatus = "//div[strong[text()='{0}']]/../div[2]//tbody//div[div[text()='STATUS']]/div[2]";



        #endregion

        #region Methods
        public void VerifyTablesDisplay(List<string> tableNames, List<string> sortOptions)
        {
            if (tableNames != null)
            {
                this.WaitForElementToBePresent(transactionsTables, 8);
                var list = driver.FindElements(transactionsTables).Select(e => e.Text.Trim()).ToList();
                list.Should().Contain(tableNames);
            }
            if (sortOptions != null)
            {
                this.WaitForElementToBePresent(transactionsTablesSortingOption, 8);
                var list = driver.FindElements(transactionsTablesSortingOption).Select(e => e.Text.Trim()).ToList();
                list.Should().Contain(sortOptions);
            }

        }

        public void VerifyFilters(List<string> tableNames, List<string> filters)
        {
            if (tableNames != null && filters != null)
            {
                int i = 0;
                tableNames.ForEach(tableName =>
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(filterOptionSelected, tableName))).Click();
                    var actualFilters = driver.FindElements(By.XPath(string.Format(filterOptionsText, tableName))).Select(e => e.Text.Trim()).ToList();
                    actualFilters.Should().Contain(filters[i].Split(',').ToList());
                    i++;
                });

            }
            else
            {
                throw new Exception("Provide Required Parameters");
            }

        }

        public void VerifCaseNameAndBankAccount()
        {
            // verify Case color is blue
            // verify the Bank number is numeric
            this.WaitForElementToBePresent(bankAccountDataCaseName, 8).GetCssValue("color").Should().Equals("rgba(4, 157, 223, 1)");
            this.WaitForElementToBePresent(bankAccountDataAccountNumber, 5).Text.Select(s => int.Parse(s.ToString()));
        }
        public DataTable GetTransactionTable(string tableName, List<string> coulumnNamesVerify = null)
        {
            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;

            this.WaitForElementToBePresent(By.XPath(string.Format(transactionHeaderNames, tableName)), 8);
            var headerNames = driver.FindElements(By.XPath(string.Format(transactionHeaderNames, tableName))).Select(e => e.Text.Trim()).ToList();

            if (coulumnNamesVerify != null)
                headerNames.Should().Contain(coulumnNamesVerify.Select(s => s.ToUpper()));

            if (VerifyNoResultsFound(tableName))
                return null;

            for (int i = 0; i < headerNames.Count; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);

                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpathPrefix + "//span[text()]", tableName, headerNames[i])), 8);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpathPrefix + "//span[text()]", tableName, headerNames[i])));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath(string.Format(rowXpathPrefix, tableName, headerNames[i]))); }
                }
                catch { rows = driver.FindElements(By.XPath(string.Format(rowXpathPrefix, tableName, headerNames[i]))); }

                var testList = rows.Select(e => e.Text).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) { htmlTable.Rows[j][i] = testList[j]; }
                    else { htmlTable.Rows.Add(testList[j]); }
                }
            }
            return htmlTable;
        }

        public void VerifyTransactionsTableFormat(string tableName, List<string> columnNames)
        {
            DataTable table = this.GetTransactionTable(tableName, columnNames);
            if (table != null)
            {
                // Veriyfy Date formate in mm/dd/yy
                string cName = tableName.Contains("BANK") ? "CLEAR DATE" : "DATE";
                int index = table.Columns[cName].Ordinal;
                var list = new List<string>();
                for (int i = 0; i <= table.Rows.Count - 1; i++)
                {
                    string expected = table.Rows[i][index].ToString();
                    list.Add(expected);
                    (new Regex(@"\d{2}/\d{2}/\d{2}")).Match(expected).Success.Should().BeTrue();
                }

                // Default sort order is Date Old to New
                //var DateExpectedSortOrder = list.OrderByDescending(s => s);
                //list.Should().BeEquivalentTo(DateExpectedSortOrder);

                // Verify the Unlinked transaction color is in Red
                var elements = driver.FindElements(By.XPath(string.Format(unlinkedTransactionAmount, tableName)));
                foreach (IWebElement e in elements)
                {
                    e.GetCssValue("color").Should().Contain("rgba(208, 2, 27, 1)");
                }

                // Verify pagination default size should be 10
                this.WaitForElementToBePresent(By.XPath(string.Format(defaultPageCount, tableName)), 2).Text.Trim().Should().Equals("10");
            }
        }

        public void ClickOnArrow(string arrow)
        {
            if (arrow.Equals("<"))
                this.WaitForElementToBePresent(leftArrow, 8).Click();
            else if (arrow.Equals(">"))
                this.WaitForElementToBePresent(rightArrow, 8).Click();
        }

        public string GetBankTRansactionValue()
        {
            return this.WaitForElementToBeVisible(bankTransactionValue).Text;
        }

        public string GetLedgerTRansactionValue()
        {
            return this.WaitForElementToBeVisible(ledgerTransactionValue).Text;
        }

        public int CountofIgnoreButton()
        {

            IList<IWebElement> IgnoreMark = driver.FindElements(ignoreButton).ToList();
            int IgnoreCount = IgnoreMark.Count();
            return (IgnoreCount);
        }

        public void ClickOnIgnoreButton()
        {
            try
            {
                IList<IWebElement> IgnoreMark = driver.FindElements(ignoreButton).ToList();
                IgnoreMark[0].Click();
                string toastMessge = this.WaitForElementToBePresent(toastrLocator).Text;
                var expectedString = "Transaction Ignore status has been updated.";
                toastMessge.Should().Contain(expectedString);
            }
            catch
            {

            }
        }

        public void VerifyIgnoreButtonColor()
        {
            this.WaitForElementToBePresent(ignoreButton).GetCssValue("color").Should().Equals("rgba(74, 74, 74, 1)"); //0, 255, 0, 0.3
        }
        public string GetToastrMessage()
        {
            return this.WaitForElementToBeVisible(toastrLocator).Text;
            //this.WaitForElementToBeVisible(By.XPath("//div[@Class='toastr animated rrt-success']//button[@class='close-toastr']")).Click();
        }
        public void ClickOnBAnkTransactionRadio()
        {
            IList<IWebElement> RadioButton = driver.FindElements(bankTransactionCheckbox).ToList();
            RadioButton[0].Click();

        }
        public void ClickOnLedgerTransactionRadio()
        {
            IList<IWebElement> RadioButton = driver.FindElements(ledgerTransactionCheckbox).ToList();
            RadioButton[0].Click();

        }
        public bool BankRecordDisplay()
        {
            return this.WaitForElementToBePresent(bankFooter).Displayed;
        }
        public bool LedgerRecordDisplay()
        {
            return this.WaitForElementToBePresent(ledgerFooter).Displayed;
        }
        public bool BlankFooterDisplay()
        {
            return this.WaitForElementToBePresent(bankActivityBlankFooter).Displayed;
        }
        public void ClickOnBankFooterCloseButton()
        {
            this.WaitForElementToBeVisible(bankFooterClose).Click();
        }
        public void ClickOnLedgerFooterCloseButton()
        {
            this.WaitForElementToBeVisible(ledgerFooterClose).Click();
        }

        public string GetCaseNumber()
        {
            Pause(3);
            return this.WaitForElementToBePresent(dataCaseName, 8).Text;
        }

        public List<bool> VerifyRadioButtonSelected()
        {
            this.WaitForElementToBePresent(radioButtons, 8);
            return driver.FindElements(radioButtons).Select(e => e.Selected).ToList();
        }

        public void LinkOrUnlinkTransaction(string serialNumber)
        {
            By xpath = By.XPath(string.Format(radioButtonLinkOrUnlinkTransaction, serialNumber));
            this.WaitForElementToBePresent(xpath);
            IList<IWebElement> radioButtons = driver.FindElements(xpath);
            for (int i = 0; i <= 1; i++)
            {
                Pause(1);

                if (!driver.FindElement(filterOptionText).Text.Contains("Unlinked") && i == 1)
                    break;

                if (!radioButtons[i].Selected)
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", radioButtons[i]);
                break;
            }
        }

        public void ClickLinkTransactionButton(string buttonName)
        {
            By xpath = By.XPath(string.Format("//div[@class='container']//button[text()='{0}']", buttonName));
            this.WaitForElementToBePresent(xpath).Click();
        }

        public bool VerifyTaostMessagePresent()
        {
            string toastMessge = this.WaitForElementToBePresent(toastMessage).Text;
            var expectedString = new List<string>() { "The selected transactions were successfully linked.", "The selected transactions were successfully unlinked." };
            return expectedString.Contains(toastMessge);
        }

        public bool VerifyTaostMessagePresentForIgnoreUpdate()
        {
            string toastMessge = this.WaitForElementToBePresent(toastrLocator).Text;
            var expectedString = "Transaction Ignore status has been updated.";
            return expectedString.Contains(toastMessge);
        }

        public bool GetRecordExist(string serialNumber)
        {
            try
            {
                bool found = false;
                By xpath = By.XPath(string.Format(transactionSerialNumber, serialNumber));
                this.WaitForElementToBePresent(xpath, 8);
                IList<IWebElement> radioButtons = driver.FindElements(xpath);
                for (int i = 0; i <= 1; i++)
                {
                    found = radioButtons[0].Enabled;
                }
                return found;
            }
            catch
            {
                return false;
            }

        }
        
        public void SelectFilter(string option)
        {
            skipStaleElementException(filterArrow);
            var filters = driver.FindElements(filterArrow);
            foreach (var filter in filters)
            {
                skipStaleElementException(null, filter).Click();
                IWebElement nextFilter = skipStaleElementException(By.XPath(string.Format(filterText, option)));
                if (nextFilter != null)
                {
                   MoveToElementAndClick(nextFilter);
                    //nextFilter.Click();
                    Thread.Sleep(500);

                    driver.FindElements(By.XPath(string.Format(filterX, option))).Select(e => e).ToList().ForEach(x =>
                    {
                        // To remove the reamaining filters
                        Thread.Sleep(100);
                        skipStaleElementException(null, x).Click();
                        Thread.Sleep(100);
                    });

                }
            }
        }

        public List<string> GetFilteredRecords(string filteredValue)
        {
            var resultData = new List<string>();

            List<string> list = new List<string>() { "BANK TRANSACTIONS", "LEDGER TRANSACTIONS" };
            var commonFilter = new List<string>() { "Unlinked", "Linked" };

            if (!VerifyNoResultsFound(list[0]) && filteredValue.Contains("Ignored") || commonFilter.Contains(filteredValue))
            {
                try
                {
                    if (!filteredValue.Contains("Ignored"))
                    {
                        this.WaitForElementToBePresent(By.XPath(string.Format(expandRecord, list[0])), 8).Click();
                        var text = this.WaitForElementToBePresent(By.XPath(string.Format(recordStatus, list[0])), 8).Text;
                        this.WaitForElementToBePresent(By.XPath(string.Format(expandRecord, list[0])), 8).Click();
                        resultData.Add(text);
                    }
                    else
                    {
                        var resusltText = skipStaleElementException(By.XPath("//i[@class='fa fa-check text-success']")) != null ? "Ignored" : null;
                        resultData.Add(resusltText);
                    }

                }
                catch
                {
                    var NODATA=driver.FindElement(By.XPath(" //div[strong[text()='BANK TRANSACTIONS']]/../div[2]//table//tr[not(@class='epiq-table-details-row')][1]//td[@class='epiq-table-data-no-title']")).Text;
                   
                }
            if (!VerifyNoResultsFound(list[1]) && filteredValue.Contains("Manually Posted") || commonFilter.Contains(filteredValue))
                {
                    try
                    {
                        this.WaitForElementToBePresent(By.XPath(string.Format(expandRecord, list[1])), 8).Click();
                        var text = this.WaitForElementToBePresent(By.XPath(string.Format(recordStatus, list[1])), 8).Text;
                        this.WaitForElementToBePresent(By.XPath(string.Format(expandRecord, list[1])), 8).Click();
                        resultData.Add(text);
                    }
                    catch
                    {
                        var NODATA = driver.FindElement(By.XPath(" //div[strong[text()='LEDGER TRANSACTIONS']]/../div[2]//table//tr[not(@class='epiq-table-details-row')][1]//td[@class='epiq-table-data-no-title']")).Text;
                    }
                }
            }
            return resultData;
        }
    
        #endregion

        #region Common Private Methods
        IWebElement skipStaleElementException(By xpath = null, IWebElement element = null)
        {
            IWebElement returnObject = null;
            for (var i = 0; i < 4; i++)
            {
                try
                {
                    Thread.Sleep(300);
                    returnObject = xpath != null ? driver.FindElement(xpath) : element;
                    break;
                }
                catch (NoSuchElementException e)
                {
                    return returnObject;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            return returnObject;
        }

        bool VerifyNoResultsFound(string tableName)
        {
            By xpath = By.XPath($"//div[strong[text()='{tableName}']]/../div[2]//tbody//td[text()='No data to display']");
            try
            {
                return this.WaitForElementToBePresent(xpath, 5).Displayed;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        
    }
}
        

    
