using System;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Distribution;
using System.Linq;
using System.Data;
using FluentAssertions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using System.Threading;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class DistributionTab:CaseDetailPage
    {
        //Tab and Sections Title locators
        private By DISTRIBUTION_TAB_TITLE_LOCATOR = By.Id("detailTabTitle-Distribution");

        //TODO change XPaths for Ids
        private By SUMMARY_SECTION_TITLE_LOCATOR = By.XPath("//card/div/div/div/p");
        private By DETAIL_SECTION_TITLE_LOCATOR = By.XPath("//card[2]/div/div/div/p");

        //No Results message locator
        private By NO_RESULTS_MESSAGE_LOCATOR = By.Id("distributionNoResultsMessage");

        //Summary Items cards and data locators
        private By SUMMARY_ITEM_LOCATOR = By.CssSelector("article.claimSummaryItem");
        private string DISTRIBUTION_SUMMARY_ITEM_BY_NAME_LOCATOR_TEMPLATE = "//article[contains(@class,'claimSummaryItem')]//h1[contains(text(),'{0}')]/../..";

        private By SUMMARY_ITEM_NAME_LOCATOR = By.XPath(".//header[contains(@class,'claimSummaryItemBankingHeader')]/h1");
        private By SUMMARY_ITEM_STATUS_LOCATOR = By.XPath(".//header[contains(@class,'claimSummaryItemBankingHeader')]/h4");

        private string SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE = ".//div[contains(@class,'{0}')]//p[contains(@class,'claimItemText')]";
        private string SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE = ".//div[contains(@class,'{0}')]//p[contains(@class,'claimItemValue')]";

        private By SUMMARY_ITEM_MOD_PAYMENT_GREY_LABEL_LOCATOR = By.XPath(".//div[contains(@class,'claimClaimedRow')]//p[contains(@class,'claimItemText')]");
        private By SUMMARY_ITEM_MOD_PAYMENT_GREY_VALUE_LOCATOR = By.XPath(".//div[contains(@class,'claimClaimedRow')]//p[contains(@class,'claimItemValue')]");

        private By SUMMARY_ITEM_CALC_PAYMENT_GREY_LABEL_LOCATOR = By.XPath(".//div[contains(@class,'claimClaimedRow')][2]//p[contains(@class,'claimItemText')]");
        private By SUMMARY_ITEM_CALC_PAYMENT_GREY_VALUE_LOCATOR = By.XPath(".//div[contains(@class,'claimClaimedRow')][2]//p[contains(@class,'claimItemValue')]");
        
        //Detail section locators
        private By DETAIL_TOTAL_CREDITORS_LOCATOR = By.CssSelector("div.detailsCreditors");
        private By DETAIL_AMOUNT_LOCATOR = By.CssSelector("div.detailsAmount");
        private By Clickonrecord = By.XPath("//td[@class='epiq-table-data-no-title']//a");
        private By Clickonreport = By.XPath("//button[@type='button']");
        private By ReportOption = By.XPath("//button[text()='Proposed Distribution Report']");

        //New Distribution Locators
        //TODO change for ids when available
        private By NEW_DISTRIBUTION_BUTTON_LOCATOR = By.Id("btn-newDistributionSummary");
        private By NEW_DISTRIBUTION_LINK_LOCATOR = By.CssSelector("i.fa.fa-plus");
        private By NEW_DISTRIBUTION_TITLE_LOCATOR = By.Id("distributionTitle");
        private By NEW_DISTRIBUTION_FORM_LOCATOR = By.Id("newDistribution");

        // Inline editing locators
        private By INLINE_SUBMIT_BUTTON = By.XPath("//div[@class='popover-content']//button[@type='submit']");

        //pagination locators

        private By Pagesize = By.XPath("//div[@class='epiq-paging-pagesize']//span[@class='Select-arrow']");
        private By Pagecount = By.XPath("//div[@class='Select-menu-outer']");
        private By Distributionstatus = By.XPath("//div[@class='row']//div[label[text()='DISTRIBUTION STATUS']]//div[@class='Select-placeholder']");

        public DistributionTab(IWebDriver driver):base(driver)
        {
        }

        //General Elements
        public string TabTitle {
            get {
                return this.WaitForElementToBeVisible(DISTRIBUTION_TAB_TITLE_LOCATOR).Text;
            }
        }
        public string SummarySectionTitle {
            get {
                return this.WaitForElementToBeVisible(SUMMARY_SECTION_TITLE_LOCATOR).Text.Split('\r')[0].Replace(" New Distribution", "");
            }
        }

        public string NoResultsMessage
        {
            get
            {
                return this.WaitForElementToBeVisible(NO_RESULTS_MESSAGE_LOCATOR).Text;
            }
        }

        //DISTRIBUTION DETAIL SECTION
        public string DistributionDetailSectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(DETAIL_SECTION_TITLE_LOCATOR).Text.Split('\r')[0];
            }
        }
      
        public string DetailAmount
        {
            get
            {
                return this.WaitForElementToBeVisible(DETAIL_AMOUNT_LOCATOR).Text;
            }
        }

        public string DetailTotalCreditors {
            get {
                return this.WaitForElementToBeVisible(DETAIL_TOTAL_CREDITORS_LOCATOR).Text;
            }
        }

       
        public bool NewDistributionButtonIsEnabled
        {
            get
            {
                return !(this.WaitForElementToBeVisible(NEW_DISTRIBUTION_BUTTON_LOCATOR).GetAttribute("class").Contains("disabled"));
            }
        }
        public bool HasDistributionFormDissappeared() {
            try
            {
                this.WaitForElementToDissapear(NEW_DISTRIBUTION_FORM_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //DISTRIBUTION SUMMARY SECTION
        public List<DistributionSummaryItemData> GetSummaryItems()
        {
            //move to view the full cards
            this.MoveToViewElement(this.WaitForElementToBeVisible(SUMMARY_SECTION_TITLE_LOCATOR));

            //gEt all cards on summary carousel
            IReadOnlyCollection<IWebElement> summaryItems = this.WaitForElementsToBeVisible(SUMMARY_ITEM_LOCATOR);
            List<DistributionSummaryItemData> retItems = new List<DistributionSummaryItemData>();
            IWebElement previousCard = null;

            //Get content from all Summary Cards
            foreach (var weItem in summaryItems)
            {
                DistributionSummaryItemData item = new DistributionSummaryItemData();

                //Set visible STYLE according to style applied to Summary Card
                if (weItem.GetAttribute("class").Contains("grey"))
                    item.CardUIStyle = "GreyHeader";
                else
                    item.CardUIStyle = "BlueHeader";                

                //Get "Distribution Name"
                IWebElement distributionNameWE = weItem.FindElement(SUMMARY_ITEM_NAME_LOCATOR);
                item.DistributionName = distributionNameWE.Text;
                item.DistributionNameEllipsis = distributionNameWE.GetAttribute("class").Contains("ellipsis");

                //Get "Distribution Status"
                item.Status = weItem.FindElement(SUMMARY_ITEM_STATUS_LOCATOR).Text;

                //Set different locators for modidifed payment and calculated payment according to status
                //TODO change when fixed them to be unique classes per each field
                By modifiedPaymentLabelLocator;
                By modifiedPaymentLocator;
                By calculatedPaymentLabelLocator;
                By calculatedPaymentLocator;
                if (item.CardUIStyle == "BlueHeader") {
                    modifiedPaymentLabelLocator = By.XPath(String.Format(SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE, "claimBalanceRow"));
                    modifiedPaymentLocator = By.XPath(String.Format(SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimBalanceRow"));
                    calculatedPaymentLabelLocator = By.XPath(String.Format(SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE, "claimClaimedRow"));
                    calculatedPaymentLocator = By.XPath(String.Format(SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimClaimedRow"));
                }
                else
                {
                    modifiedPaymentLabelLocator = SUMMARY_ITEM_MOD_PAYMENT_GREY_LABEL_LOCATOR;
                    modifiedPaymentLocator = SUMMARY_ITEM_MOD_PAYMENT_GREY_VALUE_LOCATOR;
                    calculatedPaymentLabelLocator = SUMMARY_ITEM_CALC_PAYMENT_GREY_LABEL_LOCATOR;
                    calculatedPaymentLocator = SUMMARY_ITEM_CALC_PAYMENT_GREY_VALUE_LOCATOR;
                }

                //Get "Modified Payment" label and value
                item.ModifiedPaymentLabel = weItem.FindElement(modifiedPaymentLabelLocator).Text;
                item.ModifiedPayment = weItem.FindElement(modifiedPaymentLocator).Text;
                

                //IF Modified Payment CAME BLANK, card is not visible, so SWIPE TO THE LEFT
                if (item.ModifiedPayment == "")
                {
                    //Swipe
                    int offset = -(previousCard.Size.Width) / 2;
                    Actions action = new Actions(driver);
                    action.MoveToElement(previousCard).DragAndDropToOffset(previousCard, offset, 0).Build().Perform();

                    //Get Modified Payment value again
                    item.ModifiedPayment = weItem.FindElement(modifiedPaymentLocator).Text;                     
                }

                //Calculated Payment label and value
                item.CalculatedPaymentLabel = weItem.FindElement(calculatedPaymentLabelLocator).Text;
                item.CalculatedPayment = weItem.FindElement(calculatedPaymentLocator).Text;

                //Difference
                item.DifferenceLabel = weItem.FindElement(By.XPath(String.Format(SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE, "claimPaidRow"))).Text;
                item.Difference = weItem.FindElement(By.XPath(String.Format(SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimPaidRow"))).Text;

                //Updated Date
                item.UpdatedDateLabel = weItem.FindElement(By.XPath(String.Format(SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE, "claimReservedRow"))).Text;
                item.UpdatedDate = weItem.FindElement(By.XPath(String.Format(SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimReservedRow"))).Text;

                // Add this item to the returned list
                retItems.Add(item);

                //save this as previous card in case of need for swipping on next card
                previousCard = weItem;
            }

            return retItems;
        }        

        public bool IsNewDistributionFormVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(NEW_DISTRIBUTION_FORM_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Select a Summary card by its position
        public void SelectSummaryCardByPosition(int position)
        {
            IEnumerator<IWebElement> allCardsWE = this.WaitForElementsToBeVisible(SUMMARY_ITEM_LOCATOR).GetEnumerator();
            for (int i = 0; i < position; i++)
            {
                allCardsWE.MoveNext();
            }
            allCardsWE.Current.Click();
            this.WaitForBlockOverlayToDissapear();
            this.Pause(1);
        }

        //Says if the tile contains selected CSS class
        public bool IsCardSelectedByPosition(int position)
        {
            IEnumerator<IWebElement> allCardsWE = this.WaitForElementsToBeVisible(SUMMARY_ITEM_LOCATOR).GetEnumerator();
            for (int i = 0; i < position; i++)
            {
                allCardsWE.MoveNext();
            }
            return allCardsWE.Current.GetAttribute("class").Contains("selectedTile");            
        }

        //DISTRIBUTION FORM
        public DistributionForm ClickNewDistribution()
        {
            this.WaitForElementToBeClickeable(NEW_DISTRIBUTION_LINK_LOCATOR).Click();
            this.WaitForBlockOverlayToDissapear();
            this.Pause(2);
            this.WaitForElementToBeVisible(NEW_DISTRIBUTION_TITLE_LOCATOR);
            return new DistributionForm(driver);
        }

        public bool IsDistributionPresent(string name)
        {
            try
            {
                this.WaitForElementToBeVisible(By.XPath(String.Format(DISTRIBUTION_SUMMARY_ITEM_BY_NAME_LOCATOR_TEMPLATE, name)), 5);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Adding new code-ReactJS

        private By distributionPageHeader = By.XPath("//*[@id='epiq-main-page-wrap']/div/div/div[2]/div/h2");
        private By distributionPageFilterOption = By.XPath("//button[@title='View and change current filters.']/i");
        private By distributionPageFilterClose = By.XPath("//*[@id='epiq-main-page-wrap']/div/div/div[1]/div/div[1]/div[1]/nav/div[1]/i");
        private By distributionPageBreadcrumb = By.XPath("//*[@role='navigation']");
        private By distributionPageHeadernames = By.XPath("//th[@class='epiq-table-header-sortable ' or @class='epiq-table-header-sortable visible-lg visible-xl' or @class='epiq-table-header-sortable visible-md visible-lg visible-xl']");
        private By distributionPageFilterOptions = By.XPath("//*[@id='epiq-main-page-wrap']/div/div/div[1]/div/div[1]/div[1]/nav/div[2]/h3");
        private By distributionPageRefresh = By.XPath("//*[@id='epiq-main-page-wrap']/div/div/div[3]/div[2]/div/div[1]/button[2]");
        private By distributionPageFilteroptionsCaseOrDebtor = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//div[@class='rbt-input-wrapper']//div[1]/input");
        private By distributionPageFilteroptionsCaseOrDebtorSelection = By.XPath("//a[@class ='dropdown-item']");
        private By distributionPageResetButton = By.XPath("//button[text()='RESET']");
        private By distributionPageCloseButton = By.XPath("//button[text()='CLOSE']");
        private By pageCount = By.XPath("//h3[text()='Distributions']/span");
        private By pagination = By.ClassName("pagination");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By history = By.XPath("//td[@data-title='HISTORY']/div/i");
       

        public void MouseHouver()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(history)).Perform();
            this.PressEscapeKey();
        }


        public List<string> GetRecordsByColumnName(string ColumnName, string value = null)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", WaitForElementToBePresent(Pagesize));
            Thread.Sleep(2000);
            WaitForElementToBePresent(Pagesize).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", WaitForElementToBePresent(Pagecount));
            WaitForElementToBePresent(Pagecount).Click();
            Thread.Sleep(4000);
            IList<IWebElement> rows = null;
            List<string> lists = new List<string>();
            ColumnName = ColumnName.ToUpper();
            string rowXpath = "//tr//td[@data-title='{0}']";
            try
            {
                this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, ColumnName)), 8);
                rows = driver.FindElements(By.XPath(string.Format(rowXpath, ColumnName)));
                if (rows.Count == 0)
                {
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']"));
                }
            }
            catch
            {
                rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']"));
            }
            lists = rows.Select(e => e.Text.Trim()).ToList();

            // To verify the value exist in the respective column 
            if (!string.IsNullOrWhiteSpace(value))
            {
                bool found = false;
                foreach (string list in lists)
                {
                    found = list.Contains(value);
                    if (found)
                        break;
                }
                found.Should().BeTrue();
            }
            return lists;
        }

        public void EnterDebtor(string debtor)
        {
            this.WaitForElementToBeVisible(distributionPageFilteroptionsCaseOrDebtor).SendKeys(debtor);
            this.WaitForElementToBeVisible(distributionPageFilteroptionsCaseOrDebtorSelection).Displayed.Should().BeTrue();
            this.Pause(3);
            this.WaitForElementToBeVisible(distributionPageFilteroptionsCaseOrDebtorSelection).Click();
            this.Pause(3);
           //var e = this.WaitForElementToBeVisible(DISTRIBUTION_PAGE_FILTEROPTIONS_CaseOrDebtor_Selection);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }

        
        public string GetPageCount()
        {
            ScrollDown();
            return this.WaitForElementToBeVisible(pageCount).Text;
        }

        public Dictionary<string, object> GetPagination()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Pagination", this.WaitForElementToBeVisible(pagination).Displayed);
            dict.Add("ActivePage", this.WaitForElementToBeVisible(activePage).Text);
            PressKeyOnActiveElement(Keys.Enter);
           // ScrollDown();
            return dict;
        }


        public void ClickOnResetButton()
        {
            this.Pause(1);
            driver.FindElement(distributionPageResetButton).Click();
            this.Pause(1);
            //var e = driver.FindElement(DISTRIBUTION_PAGE_RESET_BUTTON);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public void ClickOnCloseButton()
        {
            this.Pause(1);
            ScrollDownToPageBottom();
            driver.FindElement(distributionPageCloseButton).Click();
            this.Pause(1);
            //var e = driver.FindElement(DISTRIBUTION_PAGE_CLOSE_BUTTON);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public string GetHeaderName()
        {
            return this.WaitForElementToBeVisible(distributionPageHeader).Text;
        }

        public void ClickOnFilter()
        {
            this.WaitForElementToBeVisible(distributionPageFilterOption).Click();
        }

        public void ClickOnFilterClose()
        {
            this.WaitForElementToBeVisible(distributionPageFilterClose).Click();
        }
        public string GetFilterOptionHeader()
        {
            try
            {
                Pause(1);
                return driver.FindElement(distributionPageFilterOptions).Text;
            }
            catch
            {
                return null;
            }

        }
        public string GetReportOption()
        {
            Pause(1);
            return driver.FindElement(ReportOption).Text;
        }
        public void VerifyColumns(int colStartIndex, int colEndIndex, List<string> inputs, string page)
        {
            List<string> columnNames = new List<string>();
            for (int colIndex = colStartIndex; colIndex <= colEndIndex; colIndex++)
            {
                var columnName = WaitForElementToBePresent(By.XPath(".//*[@class='" + page + "']//table//tr[1]//th[" + colIndex + "]"), 3).Text;
                columnNames.Add(columnName);
            }
            Assert.IsTrue(inputs.SequenceEqual(columnNames));
        }
        public void EnterCaseNumber(string caseNumber)
        {
            this.WaitForElementToBeVisible(distributionPageFilteroptionsCaseOrDebtor).SendKeys(caseNumber);
            this.WaitForElementToBeVisible(distributionPageFilteroptionsCaseOrDebtorSelection).Displayed.Should().BeTrue();
            this.Pause(3);
            this.WaitForElementToBeVisible(distributionPageFilteroptionsCaseOrDebtorSelection).Click();
            this.Pause(3);

            //var e = this.WaitForElementToBeVisible(DISTRIBUTION_PAGE_FILTEROPTIONS_CaseOrDebtor_Selection);
            //this.Pause(5);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
            //this.Pause(5);
        }
        public DataTable GetDistributionRecords(string SortColumn = null)
        {
            this.WaitForElementToBeVisible(distributionPageHeadernames);
            this.Pause(3);
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(distributionPageHeadernames).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(distributionPageHeadernames).Select(e => e.Text.Trim()).ToList();
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

            var Table = GetDistributionRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add(Table.Rows[i][index].ToString());
            }
            return list;
        }
        public void ClickOnReferesh()
        {
            this.WaitForElementToBeVisible(distributionPageRefresh).Click();
            Pause(3);
        }
        public void ClickOnDistribution_InlineEdit()
        {
            IList<IWebElement> DistributionListForEdit = this.WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-page-body']//button[@type='button']")).ToList();
            DistributionListForEdit[5].Click();

        }

        public void EditDistribution_Inline()
        {
            SelectAndDeleteCompleteText(this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//input")));
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']//input")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']//input")).SendKeys(FakeData.Description());
            this.WaitForElementToBeVisible(INLINE_SUBMIT_BUTTON).Click();
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
        public bool ValidateDistributionEditInlineButton()
        {
            if (GetElementExists(By.XPath("//div[@class='epiq-page-body']//button[@type='button']")))
            { return true; }
            else { return false; }
        }
        public void SelectDistributionStatus(string status)
        {
            this.Pause(3);
            WaitForElementToBeClickeable(Distributionstatus).Click();
            var DStatus = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{status}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", DStatus);
            this.Pause(1);
            DStatus.Click();
        }
         public void ClickOnViewButtonDistribution()
        {
            IList<IWebElement> ViewButton = this.WaitForElementsToBeVisible(By.XPath("//a[@class='btn btn-link']")).ToList();
            ViewButton[0].Click();
        }
        public void Selectrecord()
        {
           Thread.Sleep(5000);
           var record = WaitForElementToBeClickeable(Clickonrecord);
           ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", record);
        }
        public void Selectreport()
        {
            this.Pause(2);
            WaitForElementToBeClickeable(Clickonreport).Click();
        }
        public void ClickOnCloseButtonDistribution()
        {
            Thread.Sleep(4000);
            ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(By.XPath("//button[text()='BACK']")).Click();
        }
        public void VerifyHistoryIcon()
        {
            Thread.Sleep(4000);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//div[text()='Details']/following-sibling::div//i"))).Perform();
            Thread.Sleep(2000);
            this.PressEscapeKey();
        }
        public void ClickAddDistribution()
        {
            this.WaitForElementToBeVisible(By.XPath("//button[text()=' Distribution']")).Click();
        }
        public void EnterDistributionName()
        {
            var name = new Bogus.DataSets.Name().Random.Word();
            this.WaitForElementToBeVisible(By.XPath("//input[@name='distributionName']")).SendKeys(name);
            Thread.Sleep(2000);
        }
        public void ClickGenerateButton()
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(By.XPath("//button[text()='GENERATE DISTRIBUTION']")).Click();
        }
        public void ClickCancelButton()
        {
            this.WaitForElementToBeVisible(By.XPath("//button[text()='CANCEL']")).Click();
        }
        public void ClickOnRemitToCourt()
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(By.XPath("//div[text()='REMIT TO COURT']/preceding-sibling::span")).Click();
        }
        public void ClickCheckAndEnterAmount()
        {
            this.WaitForElementToBeVisible(By.XPath("//label[@for='epiq-check-remitPayment']")).Click();
            SelectAndDeleteCompleteText(By.XPath("//input[@name='diminimusCutoffValue']"));
            this.WaitForElementToBeVisible(By.XPath("//input[@name='diminimusCutoffValue']")).SendKeys("0.00");
            Thread.Sleep(1500);
            driver.Manage().Window.Maximize();
        }

        public void CurrentDateDetails()
        {
            this.WaitForElementToBeVisible(By.XPath("//div[label[text()='DISTRIBUTION DATE (FROM)']]//div/input"),3).SendKeys(DateTime.Now.ToShortDateString());
            this.Pause(3);
            this.WaitForElementToBeVisible(By.XPath("//div[label[text()='DISTRIBUTION DATE (TO)']]//div/input"), 3).SendKeys(DateTime.Now.ToShortDateString());
            this.Pause(3);
        }
        public void ClickModifyAmount()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(By.XPath("//button[text()='MODIFY AMOUNT']")).Click();
        }
        #endregion
    }
}