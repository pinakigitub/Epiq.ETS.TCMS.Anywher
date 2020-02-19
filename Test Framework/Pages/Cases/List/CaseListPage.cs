using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.List;
using System.Diagnostics;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.List;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Case_List;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    public class CaseListPage : UnityPageBase
    {
        //Case List Column classes
        //private const string VIEW_COLUMN_CLASS = "view";
        private const string caseNUmberColumnClass = "caseNumber";
        private const string caseNameColumnClass = "caseName";
        private const string statusColumnClass = "status";
        private const string typeColumnClass = "type";
        private const string openDateColumnClass = "openStatusDate";
        private const string distributionDateColumnClass = "distributionDate";
        private const string balanceColumnClass = "balance";

        //UI elements locators        
        private By openCasesNumberLocator = By.Id("openedCases");
        private By searchFormLocator = By.Id("caseListSearchForm");
        private By caseListLocator = By.Id("casesListTable");
        private By caseListHeaderLocator = By.XPath("//table[@id='casesListTable']/thead/tr/th");


        //Case List Headers
        //private By VIEW_HEADER_LOCATOR = By.Id("Header");
        private By caseNbrHeaderLocator = By.Id("caseNumberHeader");
        private By caseNameHeaderLocator = By.Id("caseNameHeader");
        private By statusHeaderLocator = By.Id("statusHeader");
        private By typeHeaderLocator = By.Id("typeHeader");
        private By openDateHeaderLocator = By.Id("openStatusDateHeader");
        private By estDistDateHeaderLocator = By.Id("distributionDateHeader");
        private By balanceHeaderLocator = By.Id("balanceHeader");

        //Content Output Region locators
        private By noResultsAvailableMessageLocator = By.Id("noResultsMessage");
        private By caseRowLocator = By.XPath("//table[@id='casesListTable']/tbody/tr");
        private string caseRowInPositionLocatorTemplate = "//table[@id='casesListTable']/tbody/tr[{0}]";
        //private string CASE_ROW_BY_COLUMN_VALUE_LOCATOR_TEMPLATE = "//table[@id='casesListTable']/tbody/tr/td[@class='au-target {0}']/p[contains(text(),'{1}')]/../..";
        private string caseRowByColumnValueLocatorTemplate = "//table[@id='casesListTable']/tbody/tr/td[{0}]/p[contains(text(),'{1}')]/../..";
        //private string CASE_COLUMN_LOCATOR_TEMPLATE = "//table[@id='casesListTable']/tbody/tr/td[@class='au-target {0}']";
        private string caseColumnLocatorTemplate = "//table[@id='casesListTable']/tbody/tr/td[{0}]";

        private By caseNumberLinkLocator = By.XPath("//table[@id='casesListTable']/tbody/tr/td[1]/a");
        private string caseNameLinkLocatorByRowPositionTemplate = "//table[@id='casesListTable']/tbody/tr[{0}]/td[1]/a";
        private By caseNameLinkLocator = By.XPath("//table[@id='casesListTable']/tbody/tr/td[2]/a");
        private string caseNameLinkLocatorByRowPositionmTemplate = "//table[@id='casesListTable']/tbody/tr[{0}]/td[2]/a";

        private string caseRowByNumberValueLocatorTemplate = "//table[@id='casesListTable']/tbody/tr/td[1]/a[contains(text(),'{0}')]/../..";

        //Total Balances Icon locators
        private string totalBalanceIconId = "total-balance-icon";
        //private By TOTAL_BALANCE_ICON_LOCATOR = By.Id("total-balance-icon");
        //private By TOTAL_BALANCE_ICON_VALUE_LOCATOR = By.Id("total-balance-icon-value");
        //private By TOTAL_BALANCE_ICON_LABEL_LOCATOR = By.Id("total-balance-icon-description");        
        private string outstandingChecksIconId = "outstanding-checks-icon";
        //private By OUTSTANDING_CHECKS_ICON_LOCATOR = By.Id("outstanding-checks-icon");
        //private By OUTSTANDING_CHECKS_ICON_LABEL_LOCATOR = By.Id("outstanding-checks-icon-description");
        //private By OUTSTANDING_CHECKS_ICON_VALUE_LOCATOR = By.Id("outstanding-checks-icon-value");

        //LOCATORS FOR WITHIN THE CASE ROW
        //private By CASE_ROW_CASE_NUMBER_COLUMN_LOCATOR = By.XPath("td[@class='au-target caseNumber']/a");
        private By caseRowCaseNumberColumnLocator = By.XPath("td[1]/a");
        //private By CASE_ROW_CASE_NAME_COLUMN_LOCATOR = By.XPath("td[@class='au-target caseName']/a");
        private By caseRowCaseNameColumnLocator = By.XPath("td[2]/a");
        //private By CASE_ROW_CASE_STATUS_COLUMN_LOCATOR = By.XPath("td[@class='au-target status']/p");
        private By caseRowCaseStatusColumnLocator = By.XPath("td[3]/p");
        //private By CASE_ROW_CASE_TYPE_COLUMN_LOCATOR = By.XPath("td[@class='au-target type']/p");
        private By caseRowCaseTypeColumnLocator = By.XPath("td[4]/p");
        //private By CASE_ROW_OPEN_DATE_COLUMN_LOCATOR = By.XPath("td[@class='au-target openStatusDate']/p");
        private By caseRowOpenDateColumnLocator = By.XPath("td[5]/p");
        //private By CASE_ROW_EST_DIST_DATE_COLUMN_LOCATOR = By.XPath("td[@class='au-target distributionDate']/p");
        private By caseRowEstDistDateColumnLocator = By.XPath("td[6]/p");
        //private By CASE_ROW_BALANCE_COLUMN_LOCATOR = By.XPath("td[@class='au-target balance']/p");
        private By caseRowBalanceColumnLocator = By.XPath("td[7]/p");


        private By searchSectionLocator = By.XPath("//div/div/div/nav");
        public CaseListPage(IWebDriver driver) : base(driver, "UNITY") { }

        protected void ScrollDownToAvoidStickyHeadersOnClick()
        {
            //Move by offset of the sticky headers height....
            IWebElement topBar = this.WaitForElementToBeVisible(By.Id("top-bar"));
            IWebElement greyStickyBar = this.WaitForElementToBeVisible(By.CssSelector("quick-links-region"));
            int Y = topBar.Size.Height + greyStickyBar.Size.Height;
            ScrollWindowBy(0, Y);
        }

        public string GetCurrenttlyOpenCasesNumber()
        {
            return this.WaitForElementToBeVisible(openCasesNumberLocator).Text;
        }

        public bool IsCurrenttlyOpenCasesNumberVisible()
        {
            try
            {
                this.GetCurrenttlyOpenCasesNumber();
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }




        /************** Search Form ****************/

        /**
         * Gets the Search Form Page object
         */
        public CaseListSearchForm SearchForm
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(searchFormLocator);
                    //this.WaitForElementToBeVisible(By.Id("undefined"));
                    return new CaseListSearchForm(driver);
                }
                catch (MissingElementException)
                {
                    return null;
                }

            }
        }

        public NewCaseListSearchPage SearchSection
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(searchSectionLocator);
                    return new NewCaseListSearchPage(driver);
                }
                catch (MissingElementException)
                {
                    return null;
                }
            }
        }

        ///**
        // * Gets the description for Total Balance Icon
        // */
        //public string TotalBalanceIconLabel {
        //    get {
        //        return this.WaitForElementToBeVisible(TOTAL_BALANCE_ICON_LABEL_LOCATOR).Text;
        //    }
        //}

        ///**
        // * Gets the value of the Total Balance Icon
        // */
        //public string TotalBalanceIconValue
        //{
        //    get
        //    {
        //        return this.WaitForElementToBeVisibleAndHaveSomeText(TOTAL_BALANCE_ICON_VALUE_LOCATOR).Text;
        //    }
        //}

        ///**
        // * Gets the description for Total Balance Icon
        // */
        //public string OutstandingChecksIconLabel
        //{
        //    get
        //    {
        //        return this.WaitForElementToBeVisible(OUTSTANDING_CHECKS_ICON_LABEL_LOCATOR).Text;
        //    }
        //}

        ///**
        // * Gets the value of the Total Balance Icon
        // */
        //public string OutstandingChecksIconValue
        //{
        //    get
        //    {
        //        return this.WaitForElementToBeVisibleAndHaveSomeText(OUTSTANDING_CHECKS_ICON_VALUE_LOCATOR).Text;
        //    }
        //}

        public CircleIcon TotalBalanceIcon
        {
            get
            {
                return new CircleIcon(driver, totalBalanceIconId);
            }
        }

        public CircleIcon OutstandingChecksIcon
        {
            get
            {
                return new CircleIcon(driver, outstandingChecksIconId);
            }
        }

        /**
         * Click on Search button to perform the search
         */
        public CaseListPage SubmitSearch()
        {
            SearchForm.SubmitSearch();
            this.WaitForElementToDissapear(blockOverlays);
            this.WaitForElementToBeVisible(caseListLocator);
            return this;
        }

        /************** Case List Results Section ****************/

        /**
        * Gets the NoResults Available message if visible
        */
        public string GetNoResultsAvailableMessage()
        {
            try
            {
                return this.WaitForElementToBeVisible(noResultsAvailableMessageLocator).Text;

            }
            catch (MissingElementException)
            {
                return null;
            }
        }

        /**
        * Says if the Case List table element is visible
        */
        public bool IsCasesListVisible()
        {
            try
            {
                this.WaitForElementsToBeVisible(caseListLocator);
                return true;
            }
            catch (MissingElementException)
            {
                return false;
            }
        }

        /**
        * Gets the Text from the given column on the Case List table header
        */
        public string GetHeaderText(string header)
        {
            switch (header)
            {
                //case CaseListFields.VIEW:
                //    return this.WaitForElementToBeVisible(VIEW_HEADER_LOCATOR).Text;

                case CaseListFields.CASE_NUMBER:
                    return this.WaitForElementToBeVisible(caseNbrHeaderLocator).Text;

                case CaseListFields.CASE_NAME:
                    return this.WaitForElementToBeVisible(caseNameHeaderLocator).Text;

                case CaseListFields.STATUS:
                    return this.WaitForElementToBeVisible(statusHeaderLocator).Text;

                case CaseListFields.TYPE:
                    return this.WaitForElementToBeVisible(typeHeaderLocator).Text;

                case CaseListFields.OPEN_DATE:
                    return this.WaitForElementToBeVisible(openDateHeaderLocator).Text;

                case CaseListFields.DISTRIBUTION_DATE:
                    return this.WaitForElementToBeVisible(estDistDateHeaderLocator).Text;

                case CaseListFields.BALANCE:
                    return this.WaitForElementToBeVisible(balanceHeaderLocator).Text;

                default:
                    return "";
            }
        }


        /**
         * Gets the First Case matching the given Column Value
         */
        public CaseData GetOneCaseByColumnValue(string column, string value)
        {
            try
            {
                IWebElement rowWE = this.WaitForElementToBeVisible(By.XPath(String.Format(caseRowByColumnValueLocatorTemplate, GetColumnPosition(column), value)));
                return this.CreateCaseData(rowWE);
            }
            catch (MissingElementException)
            {
                return null;
            }

        }

        /**
         * Get all the rows with the given value on the given column
         */
        public List<CaseData> GetCasesByColumnValue(string column, string value)
        {
            List<CaseData> ret = this.GetCaseListResults(By.XPath(String.Format(caseRowByColumnValueLocatorTemplate, GetColumnPosition(column), value)));
            return ret;
        }

        /**
         * Gets a row by its position on the results list
         */
        public CaseData GetCaseRowByPosition(int position)
        {
            By ROW_IN_POSITION_LOCATOR = By.XPath(String.Format(caseRowInPositionLocatorTemplate, position));
            List<CaseData> cases = this.GetCaseListResults(ROW_IN_POSITION_LOCATOR);
            if (cases.Count > 0)
                return cases[0];

            return null;
        }

        /**
        * Get all the values on the results list for the given column            
        */
        public List<string> GetCaseListColumnValues(string column) {
            IReadOnlyCollection<IWebElement> columnValues = this.WaitForElementsToBeVisible(By.XPath(String.Format(caseColumnLocatorTemplate, this.GetColumnPosition(column))));

            List<string> ret = new List<string>();
            foreach (IWebElement col in columnValues)
            {
                ret.Add(col.Text);
            }

            return ret;
        }

        public List<CaseData> GetAllCaseListResults()
        {
            return this.GetCaseListResults(caseRowLocator);
        }

        //TODO: create a template Page Object for tables.
        private List<CaseData> GetCaseListResults(By by)
        {
            this.WaitForBlockOverlayToDissapear();
            List<CaseData> ret = new List<CaseData>();
            try
            {
                //Assume the UI blocker screen is already gone
                IReadOnlyCollection<IWebElement> results = this.WaitForElementsToBeVisible(by);
                foreach (IWebElement row in results)
                {
                    ret.Add(CreateCaseData(row));
                }
            }
            catch (MissingElementException)
            {
                //if no elements come up, return empty list
            }

            return ret;
        }

        private IWebElement GetRowByCaseNumber(string caseNumber)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(caseRowByNumberValueLocatorTemplate, caseNumber)));
        }

        public CaseData GetCaseRowByCaseNumber(string caseNumber) {
            return CreateCaseData(this.GetRowByCaseNumber(caseNumber));
        }

        public CaseDetailPage SelectCaseByNumber(string caseNumber) {

            this.GetRowByCaseNumber(caseNumber).FindElement(caseRowCaseNumberColumnLocator).Click();
            return new CaseDetailPage(driver);

        }

        public CaseData SelectCaseByName(string caseName)
        {
            IWebElement caseRow = this.WaitForElementToBeVisible(By.XPath(String.Format(caseRowByColumnValueLocatorTemplate, CaseListFields.CASE_NUMBER, caseName)));
            caseRow.FindElement(caseRowCaseNameColumnLocator).Click();
            return CreateCaseData(caseRow);
        }

        //Selects the Case Number link of a Case by ots row position
        public CaseDetailPage SelectCaseNumberLinkByRowPosition(int rowPosition)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(caseNameLinkLocatorByRowPositionTemplate, rowPosition))).Click();
            return new CaseDetailPage(driver);
        }

        //Selects the Case Number link of a Case by ots row position
        public CaseDetailPage SelectCaseNameLinkByRowPosition(int rowPosition)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(caseNameLinkLocatorByRowPositionmTemplate, rowPosition))).Click();
            return new CaseDetailPage(driver);
        }

        public bool IsCaseNameALinkOnAllCases()
        {
            //Get all cases on the list
            IReadOnlyCollection<IWebElement> allCases = this.WaitForElementsToBeVisible(caseRowLocator);

            //Get links from case name column
            IReadOnlyCollection<IWebElement> caseNameLinks = this.WaitForElementsToBeVisible(caseNameLinkLocator);

            //Compare counts from total vs cases with a link on the case number
            return (allCases.Count == caseNameLinks.Count);
        }

        public bool IsCaseNumberALinkOnAllCases()
        {
            //get total count of cases on the list
            IReadOnlyCollection<IWebElement> allCases = this.WaitForElementsToBeVisible(caseRowLocator);

            //get links from case number column and get count
            IReadOnlyCollection<IWebElement> caseNbrLinks= this.WaitForElementsToBeVisible(caseNumberLinkLocator);

            //Compare counts
            return (allCases.Count == caseNbrLinks.Count);

        }

        /**
         * Creates a case data from an IWebElement representing a row in the Case List table
         */
        private CaseData CreateCaseData(IWebElement row)
        {
            //TestsLogger.Debug("Creating bean for row " +row.Text);            

            //TODO load correct link once the feature is implemented
            CaseData caseData = new CaseData();
            caseData.ViewLink = "";
            //caseData.Number = row.FindElement(By.CssSelector("td.au-target.caseNumber > a")).Text;
            //caseData.Name = row.FindElement(By.CssSelector("td.au-target.caseName > a")).Text;
            //caseData.Status = row.FindElement(By.CssSelector("td.au-target.status > p")).Text;
            //caseData.Type = row.FindElement(By.CssSelector("td.au-target.type > p")).Text;
            //caseData.OpenDate = row.FindElement(By.CssSelector("td.au-target.openStatusDate > p")).Text;
            //caseData.EstimatedDistributionDate = row.FindElement(By.CssSelector("td.distributionDate > p")).Text;
            //caseData.Balance = row.FindElement(By.CssSelector("td.au-target.balance > p")).Text;

            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            caseData.Number = row.FindElement(caseRowCaseNumberColumnLocator).Text;
            caseData.Name = row.FindElement(caseRowCaseNameColumnLocator).Text;
            caseData.Status = row.FindElement(caseRowCaseStatusColumnLocator).Text;
            caseData.Type = row.FindElement(caseRowCaseTypeColumnLocator).Text;
            caseData.OpenDate = row.FindElement(caseRowOpenDateColumnLocator).Text;
            caseData.EstimatedDistributionDate = row.FindElement(caseRowEstDistDateColumnLocator).Text;
            caseData.Balance = row.FindElement(caseRowBalanceColumnLocator).Text;
            //stopWatch.Stop();
            //TestsLogger.Debug("Elapsed time: " + stopWatch.Elapsed);
            //TestsLogger.Debug("Creating bean for row ." + row.Text);
            return caseData;
        }

        private string GetColumnClass(string column)
        {
            switch (column)
            {
                case CaseListFields.STATUS:
                    return statusColumnClass;

                case CaseListFields.CASE_NAME:
                    return caseNameColumnClass;

                case CaseListFields.CASE_NUMBER:
                    return caseNUmberColumnClass;

                case CaseListFields.TYPE:
                    return typeColumnClass;

                case CaseListFields.OPEN_DATE:
                    return openDateColumnClass;

                case CaseListFields.DISTRIBUTION_DATE:
                    return distributionDateColumnClass;

                case CaseListFields.BALANCE:
                    return balanceColumnClass;

                default:
                    return "";
            }
        }

        private int GetColumnPosition(string column)
        {
            switch (column)
            {
                case CaseListFields.STATUS:
                    return 3;

                case CaseListFields.CASE_NAME:
                    return 2;

                case CaseListFields.CASE_NUMBER:
                    return 1;

                case CaseListFields.TYPE:
                    return 4;

                case CaseListFields.OPEN_DATE:
                    return 5;

                case CaseListFields.DISTRIBUTION_DATE:
                    return 6;

                case CaseListFields.BALANCE:
                    return 7;

                default:
                    throw new NotImplementedException();
            }
        }
    }

}