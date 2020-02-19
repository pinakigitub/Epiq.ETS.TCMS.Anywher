using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using FluentAssertions;
using System.Threading;
using System.Text.RegularExpressions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Pariticipants
{
    public class ParticipantsPage : UnityPageBase
    {
        private By participantPageHeader = By.CssSelector(".epiq-page-header>h2");
        private By participantPageFilter = By.XPath("//button[contains(@title,'filters.')]");
        private By participantPageFilterOptions = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[2]/h3");
        private By participantPageFilterClose = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[1]/i");
        private By participantPageBreadCrumb = By.XPath("//*[@role='navigation']");
        private By participantPageHeaderNames = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By participantPageRowExpandButton = By.XPath("//tr[1]//div[@class='visible-sm visible-md visible-lg visible-xl']/i");
        private By participantPageAddress = By.XPath("//div[@class='row']//div[4]//div[text()='ADDRESS']");
        private By participantPageSsn = By.XPath("//div[@class='row']//div[5]//div[text()='SSN']");
        private By participantPageDriversLicense = By.XPath("//div[@class='row']//div[6]//div[text()='DRIVERS LICENSE']");
        private By participantPageTaxId = By.XPath("//div[@class='row']//div[7]//div[text()='TAX ID']");
        private By participantPageFilterOptionsCaseorDebtor = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//div[@class='rbt-input-hint-container']/input[2]");
        private By participantPageFilterOptionsCaseorDebtorSelection = By.XPath("//div[label[contains(text(),'DEBTOR NAME')]]//li/a/span");
        private By participantPageFilterOptionsParticipantName = By.XPath("//main[@id='epiq-main-page-wrap']/div/div/div/div/div/nav/div[3]/div/div/input");
        private By participantPageCount = By.XPath("//h3[text()='Participants']/span");
        private By participantPagination = By.ClassName("pagination");
        private By participantActivePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By participantResetButton = By.XPath("//button[text()='RESET']");
        private By participantPageFilterOptionsRole = By.XPath("//div[label[text()='ROLE']]//span/div[1]");
        private By participantPageFilterOptionsType = By.XPath("//div[label[text()='TYPE']]//span/div[1]");
        //private By PARTICIPANT_ROLE_X = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[3]/form/div[3]/div/div/span[2]/span");
        //private By PARTICIPANT_ROLE_X = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[1]/i");
        private By participantRoleX = By.XPath("//*[@class='Select-value-icon']");
        private By participantPageSsnNo = By.XPath("//div[div[text()='SSN']]/div[2]");
        
        public ParticipantsPage(IWebDriver driver) : base(driver, "UNITY")
        {
        }
        public string GetHeaderName()
        {
            return this.WaitForElementToBeVisible(participantPageHeader).Text;
        }

        public void ClickOnFilter()
        {
            this.WaitForElementToBeVisible(participantPageFilter).Click();
        }

        public void EnterCaseNumber(string caseNumber)
        {
            this.WaitForElementToBeVisible(participantPageFilterOptionsCaseorDebtor).Click();
            this.WaitForElementToBeVisible(participantPageFilterOptionsCaseorDebtor).SendKeys(caseNumber);
            this.WaitForElementToBeVisible(participantPageFilterOptionsCaseorDebtorSelection).Displayed.Should().BeTrue();
            var e = this.WaitForElementToBeVisible(participantPageFilterOptionsCaseorDebtorSelection);
            MoveToElementAndClick(e, 1095, 195);
                        
        }
        public void EnterParticipName(string participant)
        {
            this.WaitForElementToBeVisible(participantPageFilterOptionsParticipantName).SendKeys(participant);
        }
        public string GetFilterOptionHeader()
        {
            try
            {
                Pause(1);
                return driver.FindElement(participantPageFilterOptions).Text;
            }
            catch
            {
                return null;
            }

        }

        public void ClickOnFilterClose()
        {
            this.Pause(1);
            this.WaitForElementToBeVisible(participantPageFilterClose).Click();
        }

        public bool GetBreadcrumb()
        {
            return this.WaitForElementToBeVisible(participantPageBreadCrumb).Displayed;
        }

        public DataTable GetParticipantsRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(participantPageHeaderNames).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(participantPageHeaderNames).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 2; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);
                try
                {
                    this.Pause(2);
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

            var Table = GetParticipantsRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add(Table.Rows[i][index].ToString());
            }
            return list;
        }

        public void clickOnRowExpandButton()
        {
            Pause(1);
            this.WaitForElementToBeVisible(participantPageRowExpandButton).Click();
        }

        public bool GetAddressDisplayed()
        {
            return driver.FindElement(participantPageAddress).Displayed;
        }

        public bool GetSSNDisplayed()
        {
            return driver.FindElement(participantPageSsn).Displayed;
        }

        public bool GetDriversLicenseDisplayed()
        {
            return driver.FindElement(participantPageDriversLicense).Displayed;
        }

        public bool GetTaxIdDisplayed()
        {
            return driver.FindElement(participantPageTaxId).Displayed;
        }

        public string GetPageCount()
        {
            return this.WaitForElementToBeVisible(participantPageCount).Text;
        }

        public Dictionary<string, object> GetPagination()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Pagination", this.WaitForElementToBeVisible(participantPagination).Displayed);
            dict.Add("ActivePage", this.WaitForElementToBeVisible(participantActivePage).Text);
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

        public void ClickOnResetButton()
        {
            this.Pause(1);
            var a = driver.FindElement(participantResetButton);
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();",a);
            
        }

        public void SelectRole(string role)
        {
            this.WaitForElementToBeVisible(participantPageFilterOptionsRole).Click();

            var elements = driver.FindElements(By.XPath("//div[label[text()='ROLE']]//div[@class='Select-menu-outer']//div[@class='Select-option']"));
            try
            {
                var resultElement = elements.Where(e => e.Text == role).FirstOrDefault();
                resultElement.Click();

            }
            catch
            {
                var resultElement = elements.Where(e => e.Text == role).FirstOrDefault();
                resultElement.Click();

            }

            this.WaitForElementToBeVisible(By.XPath("//div[label[text()='ROLE']]")).Click();

        }

        public void ClickRoleX()
        {
            this.Pause(2);
            this.WaitForElementToBeVisible(participantRoleX).Click();
        }


        public void searchInfo(string case_no, string casename)
        {
            this.MoveToViewElementandSAndkeys(driver.FindElement(participantPageFilterOptionsCaseorDebtor), case_no);
            Thread.Sleep(2000);
            try
            {
                IList<IWebElement> dropdownValues = driver.FindElements(By.XPath("//div[contains(@class,'rbt open')]//ul//span"));

                foreach (IWebElement textBox in dropdownValues)
                {
                    if ((textBox.Text) == casename)
                    {
                        Thread.Sleep(2000);
                        IJavaScriptExecutor ex = (IJavaScriptExecutor)driver;
                        Thread.Sleep(3000);
                        ex.ExecuteScript("arguments[0].click();", textBox);
                        break;
                    }
                }
            }
            catch (StaleElementReferenceException e)
            {

            }
        }

        public bool IsFullSSN_No()
        {   Regex reg = new Regex("[0-9]{3}[-]?[0-9]{2}[-]?[0-9]{4}"); 
            var rs =  this.WaitForElementToBeVisible(participantPageSsnNo).Text;
            return reg.IsMatch(rs);
          
        }

        public bool IsHiddenSSN_No()
        {
            string reg = "XXX-XX-XXXX ";
            var rs = this.WaitForElementToBeVisible(participantPageSsnNo).Text;
            return reg.Equals(rs);
            

        }

        public bool IsPartialSSN_No()
        {
            Regex reg = new Regex("X{3}[-]?X{2}[-]?[0-9]{4}");
            var rs = this.WaitForElementToBeVisible(participantPageSsnNo).Text;
            return reg.IsMatch(rs);

        }

    }
}
