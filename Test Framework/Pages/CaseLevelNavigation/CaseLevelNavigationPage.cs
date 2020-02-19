using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.CaseLevelNavigation
{
    class CaseLevelNavigationPage : UnityPageBase
    {
        public static string pageTitle = "UNITY";
        public By allCasesText = By.XPath("//div[@class='epiq-header-selection']/div[text()='All Cases']");
        public By debtorName = By.XPath("//div[@class='case-header-data-case-display']//span[1]");
        public By caseNumber = By.XPath("//div[@class='case-header-data-case-display']//span[3]");
        public By caseStatus = By.XPath("//div[@class='case-header-status']//span[1]");
        public By caseType = By.XPath("//div[@class='case-header-status']/div[2]//span[1]");
        public By summaryTitle = By.XPath("//div[@class='panel-heading']//a/div");
        public By scheduleValue = By.XPath("//div[@class='row panel-content']//span[3]");
        public By netValue = By.XPath("//div[@class='row panel-content']/div[2]//span[2]");
        public By abandonedValue = By.XPath("//div[@class='row panel-content']/div[3]//span[2]");
        public By salesValue = By.XPath("//div[@class='row panel-content']/div[4]//span[2]");
        public By remainingValue = By.XPath("//div[@class='row panel-content']/div[5]//span[2]");
        private By caseTableRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By estateValue = By.XPath("//div[@class='row panel-content']/div[1]//span[2]");
        private By validToPayValue = By.XPath("//div[@class='row panel-content']/div[2]//span[3]");
        private By paidValue = By.XPath("//div[@class='row panel-content']/div[3]//span[3]");
        private By reservedValue = By.XPath("//div[@class='row panel-content']/div[4]//span[3]");
        private By claimsBalanceValue = By.XPath("//div[@class='row panel-content']/div[5]//span[2]");
        private By selectButtonOn = By.XPath("//span[text()='PERMIT ASSET IMBALANCE']");
        //private By EPIQ_LOGO_341_LOCATOR = By.XPath("//img[@class='unity-logo au-target']");

        //DEBTOR & CASE navigation locators
        private By debtor = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table/tbody/tr[1]/td[5]//a");
        private By expand = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//table/tbody/tr[1]/td[1]/div//i");
        private By caseNumberLocator = By.XPath("(//td[@data-title='CASE #'])[1]/a/span");
        private By validToPay = By.XPath("//span[text()='Valid to Pay']");

        //Claims Filter Locators
        private By filterButton = By.XPath("//button[contains(@title,'filters.')]");
        private By claimClassStatus = By.XPath("//div[label[text()='CLAIM STATUS']]//span/div[1]");
        private string claimFilterSelect = "//div/div[text()='{0}']";
        private By resetButton = By.XPath("//button[text()='RESET']");
        private By closeButton = By.XPath("//button[text()='CLOSE']");

        //Claims Summary Locators
        private By claimsCount = By.XPath("//h3//span/span[text()]");
        private By paidText = By.XPath("//span[text()='Paid']");

        //ReceiptLog page
        private By pageCount = By.XPath("//h3/span/span");
        private By receivedFrom = By.XPath("//div[label[text()='RECEIVED FROM']]/input");
        private By addressField = By.XPath("//div[label[text()='ADDRESS']]/textarea");
        private By checkNumber = By.XPath("//div[label[text()='CHECK #']]/input");
        private By utcCode = By.XPath("//div[label[text()='UTC']]//span/div[1]");

        //ReceiptLog FilterSection
        private By voidedType = By.XPath("//div[label[text()='VOIDED']]//div[@class='Select-input']/input");
        private By unlinkTransaction = By.XPath("//button[text()=' UNLINK TRANSACTION']");
        private By caseNumberReadOnly = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]/div/div[1]");
        private By addReceiptDisable = By.XPath("//div[@class='epiq-page-control']/div[1]/button[@disabled='']");
        private By cancelTransaction = By.XPath("//button[text()='Cancel']");
        private By linkTransaction = By.XPath("//button[text()=' LINK TRANSACTION']");
        private By pencilIcon = By.XPath("//div[@class='epiq-page-body']//table//tbody//td[12]//a");

        //Banking Activity 
        private By issueHeader = By.XPath("//th[text()='ISSUE']");
        private By accountNumberHeader = By.XPath("//th[text()='ACCOUNT #']");
        private By bankNameHeader = By.XPath("//th[text()='BANK']");
        private By accountNameHeader = By.XPath("//th[text()='ACCOUNT NAME']");
        private By accountTypeHeader = By.XPath("//th[text()='ACCOUNT TYPE']");
        private By serialNumber = By.XPath("(//div/div[2]/table/thead/tr/th[5]/i)[1]");
        private By ledgerPageDropdown = By.XPath("(//div[@class='epiq-paging-pagesize']//span[@class='Select-arrow-zone']/span)[2]");
        private By bankPageDropdown = By.XPath("(//div[@class='epiq-paging-pagesize']//span[@class='Select-arrow-zone']/span)[1]");
        private By bankTransactionRows = By.XPath("//div[@class='issue-reconcile-page']//table/tbody/tr");
        private By ledgerRows = By.XPath("(//table[@class='epiq-table table table-condensed'])[2]/tbody/tr");

        private By saveField = By.XPath("//button[@type='submit']");
        private By dropdownField = By.XPath("//div[@class='Select-control']/span[2]/span");
        private By clearField = By.XPath("//div[@class='Select-control']/span[2]/span");
        private By expandDocument = By.XPath("//a[@class='collapsed']/span");

        private By historyIcon = By.XPath("//td[@data-title='DATE HISTORY']/i");
        private By tableTitles = By.XPath("//tr/th[text()]");
        private By printButton = By.XPath("//button[text()='PRINT']");
        private By tableCheckbox = By.XPath("//tr[1]/td[2]/div");
        private By historyButton = By.XPath("//div[@class='epiq-page-control pull-right']/a");
        private By historyTableHeader = By.XPath("//div[@class='epiq-page-body']/h3");
        private By printIcon = By.XPath("//tr[1]/td[6]/i");
        private By debtorAttorney = By.XPath("//div[@class='case-header-contact']/a/span/span[2]");
        private By expenseDetailsButton = By.XPath("//a[text()='Comp/Expense Details']");
        private By expenses = By.XPath("//span[text()='EXPENSES']");
        private By expensesRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody//tr[@class='epiq-table-details-row']");
        private By trusteeExpenses = By.XPath("//span[text()='Total Expenses']");
        private By trusteePaid = By.XPath("//span[text()='Paid']");
        private By trusteeBalanceDue = By.XPath("//span[text()='Balance Due']");
        private By trusteeAmounts = By.XPath("//span[text()='Update Allowed and Claimed Amounts']");
        private By trusteeExpensesDate = By.XPath("//th[text()='DATE']");
        private By trusteeExpensesType = By.XPath("//th[text()='TYPE']");
        private By trusteeExpensesUOM = By.XPath("//th[text()='UOM']");
        private By trusteeExpensesUnitPrice = By.XPath("//th[text()='UNIT PRICE']");
        private By trusteeExpensesQuantity = By.XPath("//th[text()='QTY']");
        private By trusteeExpensesTotal = By.XPath("//th[text()='TOTAL']");
        private By trusteeExpensesNotes = By.XPath("//div[text()='NOTES']");
        private By editExpenseButton = By.XPath("(//button[@title='Edit Expense'])[1]");
        private By unitOfMeasure = By.XPath("//input[@name='unitOfMeasure']");
        private By expenseRemarks = By.XPath("//input[@name='notes']");
        private By quantity = By.XPath("//input[@name='quantity']");
        private By unitPrice = By.XPath("//input[@name='unitPrice']");
        private By trusteeExpenseType = By.XPath("(//span[@class='Select-arrow'])[3]");
        private By expandColumns = By.XPath("(//div[@class='epiq-page-body']//table/tbody/tr/td/div/i)[1]");
        private By trusteeExpensesFilter = By.XPath("//button[@title='View and change current filters.']");
        private By trusteeExpensesFilterClose = By.XPath("//button[text()='CLOSE']");
        private By editExpenseSave = By.XPath("//button[text()='SAVE']");
        private By closeCase = By.XPath("//div[@class='epiq-header-case-selector info epiq-header-selector']/div/i");
        private By caseArrow = By.XPath("//div[@class='epiq-clearable epiq-header-selection']/i");
        private By allCases = By.XPath("//div[@class='popover-content']/ul/li[text()='All Cases']");
        private By trusteeExpensesCaseNumber = By.XPath("//div[@class='case-header-data-case-display']/span[3]");
        private By trusteeExpensesHeader = By.XPath("//h3[text()='Expenses']");
        private By noResultsMessage = By.XPath("//div[text()='No expenses to display']");
        private By linkClaim = By.XPath("//button[text()='LINK CLAIM']");
        private By bankAccount = By.XPath("//button[text()='LINK CLAIM']");
        private By saveClaim = By.XPath("//button[text()='ADD']");
        private By bankAccounts = By.XPath("//ol[@class='breadcrumb']/li[1]/a");

        public CaseLevelNavigationPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void AllCasesBGColor()
        {
            this.Pause(3);
            var resColor = driver.FindElement(By.XPath("//div[@class='epiq-header-case-selector primary epiq-header-selector']/div")).GetCssValue("color");
            string[] arrColor = resColor.Split(',');
            string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

            int hexValue1 = Int32.Parse(hexValue[0]);
            hexValue[1] = hexValue[1].Trim();
            int hexValue2 = Int32.Parse(hexValue[1]);
            hexValue[2] = hexValue[2].Trim();
            int hexValue3 = Int32.Parse(hexValue[2]);

            string actualColor = string.Format("#fafafa", hexValue1, hexValue2, hexValue3);
            Assert.AreEqual("#fafafa", actualColor);
        }
        public void CaseBGColor()
        {
            this.Pause(3);
            var resColor = driver.FindElement(By.XPath("//div[@class='epiq-header-case-selector info epiq-header-selector']/div")).GetCssValue("color");
            string[] arrColor = resColor.Split(',');
            string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

            int hexValue1 = Int32.Parse(hexValue[0]);
            hexValue[1] = hexValue[1].Trim();
            int hexValue2 = Int32.Parse(hexValue[1]);
            hexValue[2] = hexValue[2].Trim();
            int hexValue3 = Int32.Parse(hexValue[2]);

            string actualColor = string.Format("#049ddf", hexValue1, hexValue2, hexValue3);
            Assert.AreEqual("#049ddf", actualColor);
        }
        public void ClearBox(string expectedHeader)
        {
           var clearSearchBox=driver.FindElement(By.XPath("//div[@class='epiq-header-case-selector info epiq-header-selector']/div/i"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", clearSearchBox);
            this.Pause(2);
            var actualHeader = driver.FindElement(allCasesText).Text.Trim();
            expectedHeader = expectedHeader.Trim();
            Assert.AreEqual(actualHeader.ToLower(), expectedHeader.ToLower());
        }
        public void VerifyDetails(string expecteddebName, string expectedcaseNum)
        {
            Thread.Sleep(1000);
            var actualdebName = driver.FindElement(debtorName).Text.Trim();
            expecteddebName = expecteddebName.Trim();
            Assert.AreEqual(actualdebName.ToLower(), expecteddebName.ToLower());
            if (expecteddebName == actualdebName)
            {
                Thread.Sleep(1000);
                var actualcaseNum = driver.FindElement(caseNumber).Text.Trim();
                expectedcaseNum = expectedcaseNum.Trim();
                Assert.AreEqual(actualcaseNum.ToLower(), expectedcaseNum.ToLower());
            }
        }
        public void VerifyStates(string state)
        {
            var status = driver.FindElement(caseStatus);
            var text = status.Text;
            if (text == state)
            {
                Thread.Sleep(2000);
                var resColor1 = driver.FindElement(caseStatus).GetCssValue("color");
                string[] arrColor = resColor1.Split(',');
                string[] hexValue = resColor1.Replace("rgba(", "").Replace(")", "").Split(',');

                int hexValue1 = Int32.Parse(hexValue[0]);
                hexValue[1] = hexValue[1].Trim();
                int hexValue2 = Int32.Parse(hexValue[1]);
                hexValue[2] = hexValue[2].Trim();
                int hexValue3 = Int32.Parse(hexValue[2]);

                string actualColor = string.Format("#34a01e", hexValue1, hexValue2, hexValue3);
                Assert.AreEqual("#34a01e", actualColor);
            }
        }
        public void VerifyType(string type)
        {
            var Type = driver.FindElement(caseType);
            var CaseType = Type.Text;
            if (CaseType == type)
            {
                Thread.Sleep(2000);
                var resColor2 = driver.FindElement(caseType).GetCssValue("color");
                string[] arrColor = resColor2.Split(',');
                string[] hexValue = resColor2.Replace("rgba(", "").Replace(")", "").Split(',');

                int hexValue1 = Int32.Parse(hexValue[0]);
                hexValue[1] = hexValue[1].Trim();
                int hexValue2 = Int32.Parse(hexValue[1]);
                hexValue[2] = hexValue[2].Trim();
                int hexValue3 = Int32.Parse(hexValue[2]);

                string actualColor = string.Format("#e87722", hexValue1, hexValue2, hexValue3);
                Assert.AreEqual("#e87722", actualColor);
            }
        }
        public void VerifySummaryTitle(string expectedTitle)
        {
            Thread.Sleep(2000);
            var actualtitle = driver.FindElement(summaryTitle).Text.Trim();
            expectedTitle = expectedTitle.Trim();
            Assert.AreEqual(actualtitle.ToLower(), expectedTitle.ToLower());
        }
        public void ScheduleDetails(string text, string expectedValue)
        {
            Thread.Sleep(2000);
            var textValue = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{text}']"));
            var scheduleText = textValue.Text;
            if (scheduleText == text)
            {
                var actualValue = driver.FindElement(scheduleValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void NetValueDetails(string netValueText, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{netValueText}']"));
            var netText = text.Text;
            if (netText == netValueText)
            {
                var actualValue = driver.FindElement(netValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void AbandonedDetails(string abandonText, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{abandonText}']"));
            var abandonedText = text.Text;
            if (abandonedText == abandonText)
            {
                var actualValue = driver.FindElement(abandonedValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void SalesDetails(string salesText, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{salesText}']"));
            var salesTextValue = text.Text;
            if (salesTextValue == salesText)
            {
                var actualValue = driver.FindElement(salesValue).Text.Trim();
                expectedValue = expectedValue.Trim();

                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void RemainingDetails(string remaining, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{remaining}']"));
            var remainText = text.Text;
            if (remainText == remaining)
            {
                var actualValue = driver.FindElement(remainingValue).Text.Trim();
                expectedValue = expectedValue.Trim();

                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void verifyAssetDetails(string description, string petition)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int RowLength = rows.Count;

            for (int row = 1; row <= RowLength; row++)
            {
                IWebElement descriptionText = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[3]"));
                string descriptionList = descriptionText.Text;

                if (descriptionList == description)
                {
                    Thread.Sleep(1000);
                    var petitionText = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[5]"));
                    var PetitionList = petitionText.Text;
                    Assert.AreEqual(PetitionList, petition);
                    break;
                }
                row++;
            }
        }
        public void EstateDetails(string estateTextValue, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{estateTextValue}']"));
            var estateText = text.Text;
            if (estateText == estateTextValue)
            {
                var actualValue = driver.FindElement(estateValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void ValidToPayDetails(string text, string expectedValue)
        {
            Thread.Sleep(2000);
            var validToPayText = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{text}']"));
            var validToPay = validToPayText.Text;
            if (validToPay == text)
            {
                var actualValue = driver.FindElement(validToPayValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void PaidDetails(string text, string expectedValue)
        {
            Thread.Sleep(2000);
            var paidText = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{text}']"));
            var paidValue = paidText.Text;
            if (paidValue == text)
            {
                var actualValue = driver.FindElement(this.paidValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void ReservedDetails(string reservedText, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{reservedText}']"));
            var reservedValue = text.Text;
            if (reservedValue == reservedText)
            {
                var actualValue = driver.FindElement(this.reservedValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void ClaimsBalanceDetails(string claimsValueText, string expectedValue)
        {
            Thread.Sleep(2000);
            var text = driver.FindElement(By.XPath($"//div[@class='row panel-content']//span[text()='{claimsValueText}']"));
            var claimsText = text.Text;
            if (claimsText == claimsValueText)
            {
                var actualValue = driver.FindElement(claimsBalanceValue).Text.Trim();
                expectedValue = expectedValue.Trim();
                Assert.AreEqual(actualValue.ToLower(), expectedValue.ToLower());
            }
        }
        public void VerifyClaimsDetails(string creditor, string classDetails)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement credit = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[3]"));
                string creditorList = credit.Text;

                if (creditorList == creditor)
                {
                    Thread.Sleep(1000);
                    var type = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[4]"));
                    var classList = type.Text;
                    Assert.AreEqual(classList, classDetails);
                    break;
                }
                row++;
            }
        }
        public void VerifyDSODetails(string name, string add)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement claimNameValue = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[3]"));
                string claimName = claimNameValue.Text;

                if (claimName == name)
                {
                    Thread.Sleep(1000);
                    var Address = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[4]//i"));
                    Address.Click();
                    Thread.Sleep(2000);
                    var getAddress = driver.FindElement(By.XPath("//div[@class='popover-content']//form//div[@class='form-group']/input")).GetAttribute("value");
                    Assert.AreEqual(getAddress, add);
                    break;
                }
                row++;
            }
        }
        public void VerifyTaskDetails(string type, string notes, string assign)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement task = WaitForElementToBeVisible(By.XPath("//tr[" + row + "]//td[2]/div"), 2);
                string taskType = task.Text;

                if (taskType == type)
                {
                    Thread.Sleep(1000);
                    var notesText = driver.FindElement(By.XPath("//tr[" + row + "]//td[3]/div"));
                    var taskNotes = notesText.Text;

                    if (taskNotes == notes)
                    {
                        Thread.Sleep(1000);
                        var assignValue = driver.FindElement(By.XPath("//tr[" + row + "]//td[5]/div"));
                        var taskAssign = assignValue.Text;
                        Assert.AreEqual(taskAssign, assign);
                        break;
                    }
                }
                row++;
            }
        }
        public void VerifyReceiptLogDetails(string name, string amountValue)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement receivedName = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[4]"));
                string receivedFrom = receivedName.Text;

                if (receivedFrom == name)
                {
                    Thread.Sleep(1000);
                    var amount = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[5]")).Text;
                    Assert.AreEqual(amount, amountValue);
                    break;
                }
                row++;
            }
        }
        public void clickDebtorName()
        {
            WaitForElementToBePresent(debtor).Click();
            Thread.Sleep(3000);
        }
        public void ClickExpand()
        {
            WaitForElementToBePresent(expand).Click();
        }
        public void ClickCase()
        {
            Thread.Sleep(2000);
            WaitForElementToBePresent(caseNumberLocator).Click();

        }
        public void GetValidToPayCount(string field)
        {
            var text = WaitForElementToBeVisible(validToPay).Text;
            if (text == field)
            {
                var count = WaitForElementToBeVisible(By.XPath($"//span[text()='{field}']/following-sibling::span[1]")).Text;

                this.WaitForElementToBeClickeable(filterButton).Click();
                this.Pause(3);
                this.WaitForElementToBeVisible(claimClassStatus, 3).Click();
                this.WaitForElementToBeVisible(By.XPath(String.Format(claimFilterSelect, "Valid To Pay")), 3).Click();
                this.Pause(3);

                var claimsCount = WaitForElementToBeVisible(this.claimsCount).Text;
                Assert.AreEqual(count.Trim(), claimsCount.Trim());
                Thread.Sleep(3000);
                this.WaitForElementToBeVisible(resetButton).Click();
                this.WaitForElementToBeVisible(closeButton).Click();
            }
        }
        public void GetPaidCount(string field)
        {
            var text = WaitForElementToBeVisible(paidText, 3).Text;
            if (text == field)
            {
                var paidCount = WaitForElementToBeVisible(By.XPath($"//span[text()='{field}']/following-sibling::span[1]")).Text;
                var count = int.Parse(paidCount);
                Thread.Sleep(3500);
                IList<IWebElement> rows = driver.FindElements(caseTableRows);
                int rowLength = rows.Count;
                List<string> listvalues = new List<string>();

                for (int row = 1; row <= rowLength; row++)
                {
                    IWebElement paid = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[8]/span"));
                    string list = paid.Text;

                    if (list != "$0.00")
                    {
                        listvalues.Add(list);
                        row++;
                    }
                    else
                    {
                        row++;
                    }
                }
                listvalues.Count();
                Assert.AreEqual(count, listvalues.Count());
            }
        }
        public string GetPageCount()
        {
            return this.WaitForElementToBeVisible(pageCount).Text;
        }
        public void verifyColumns(string caseNumber, string debtorName)
        {
            Assert.IsFalse(IsElementVisible(By.XPath($"//div[text()='{caseNumber}']")));
            Assert.IsFalse(IsElementVisible(By.XPath($"//th[text()='{debtorName}']")));
        }
        public void MarkReceipt(string debtor, int index)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement name = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[4]"));
                string debtorName = name.Text;

                if (debtorName == debtor)
                {
                    if (IsElementVisible(By.XPath($"//tr[{index}]/td[11]/i[contains(@class,'epiq-receiptlog-disabled')]")))
                    {
                        WaitForElementToBeClickeable(By.XPath($"//tr[{index}]/td[11]/i[contains(@class,'epiq-receiptlog-disabled')]")).Click();
                    }
                    else
                    {
                        WaitForElementToBeClickeable(By.XPath($"//tr[{index}]/td[11]/i[contains(@class,'epiq-receiptlog-enabled')]")).Click();
                        WaitForElementToBeClickeable(By.XPath($"//tr[{index}]/td[11]/i[contains(@class,'epiq-receiptlog-disabled')]")).Click();
                    }
                    break;
                }
                row++;
            }

        }
        public void VerifyMarkedAsGreen(string debtor)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement name = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tr[" + row + "]//td[4]"));
                string debtorName = name.Text;

                if (debtorName == debtor)
                {
                    var resultColor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]/td[11]/a/i")).GetCssValue("color");

                    string[] arrColor = resultColor.Split(',');
                    string[] hexValue = resultColor.Replace("rgba(", "").Replace(")", "").Split(',');

                    int hexValue1 = Int32.Parse(hexValue[0]);
                    hexValue[1] = hexValue[1].Trim();
                    int hexValue2 = Int32.Parse(hexValue[1]);
                    hexValue[2] = hexValue[2].Trim();
                    int hexValue3 = Int32.Parse(hexValue[2]);

                    string actualColor = string.Format("#34a01e", hexValue1, hexValue2, hexValue3);
                    Assert.AreEqual("#34a01e", actualColor);
                    break;
                }
                row++;

            }
        }
        public void VerifyFilterInCaseLevel(string caseOrDebtor, string caseStatus)
        {
            Assert.IsFalse(IsElementVisible(By.XPath($"//div[label[text()='{caseOrDebtor}']]/div/div[1]")));
            if (!string.IsNullOrEmpty(caseStatus))
            {
                Assert.IsFalse(IsElementVisible(By.XPath($"//div[label[text()='{caseStatus}']]/div/div[1]")));
            }
        }
        public void SelectVoided(string voidedType)
        {
            ClearAndType(this.WaitForElementToBeVisible(this.voidedType), voidedType);
            WaitForElementToBeVisible(this.voidedType).SendKeys(Keys.Down);
            WaitForElementToBeVisible(this.voidedType).SendKeys(Keys.Enter);
        }
        public void VerifyLinkedStatus(string receivedFrom)
        {
            this.Pause(1);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int caseRows = rows.Count;

            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement receivedName = driver.FindElement(By.XPath("//div[contains(@class,'epiq-table-wrapper clearfix')]//tr[" + row + "]//td[4]"));
                string received = receivedName.Text;

                if (received == receivedFrom)
                {
                    var edit = driver.FindElement(By.XPath("//div[contains(@class,'epiq-table-wrapper clearfix')]//tbody/tr[" + row + "]/td[10]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
                    this.Pause(1);
                    ScrollDownToPageBottom();
                    Assert.True(IsElementVisible(unlinkTransaction));
                    break;
                }
                row++;
            }
        }
        public void VerifyCaseNumReadOnly()
        {
            Assert.False(IsElementVisible(caseNumberReadOnly));
        }
        public void AddReceiptDisabledState()
        {
            Assert.True(IsElementVisible(addReceiptDisable));
        }
        public void ReceivedFrom(string receivedFrom)
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                Thread.Sleep(2000);
                IWebElement receivedName = driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[4]/div"));
                
                string received = receivedName.Text;
                if (received == receivedFrom)
                {
                    //ScrollDown();
                    this.Pause(2);
                    ScrollUpToPageTop();
                    var TransactionReceivedfrom = driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[2]//label"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", TransactionReceivedfrom);
                    //JavaScriptClick(check);
                    //this.Pause(2);
                    //Actions action = new Actions(driver);
                    //action.MoveToElement(check).Click().Build().Perform();
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
            //ScrollUpToPageTop();
        }
        public void SelectTransactionType(string type)
        {
            //this.Pause(3);
            
            WaitForElementToBeClickeable(By.XPath($"//div[@class='epiq-page-control']/div/button[contains(text(),'{type}')]")).Click();
            
        }
        public void SelectButton(string button)
        {
            this.Pause(3);
            var select = WaitForElementToBeClickeable(By.XPath($"//button[contains(text(),'{button}')] | //a[text()='{button}'] | //div[@class='modal-footer']/button[contains(text(),'{button}')] | //div[@class='modal-footer']/button[1] | //button[contains(text(),'{button}')]/i | //div[@class='epiq-override-buttons']/button[2] | //div/div/div[2]/button[2] | //button[text()='{button}']"), 2);
            JavaScriptClick(select);
            this.Pause(5);        
        }

        public void ClickButton(string Button)
        {
            WaitForElementToBeClickeable(By.XPath("//div/div/div[2]/button[2]")).Click();
            this.Pause(3);
        }
        public void VerifyDisabledState(string status)
        {
            bool element = driver.FindElement(By.XPath($"//button[contains(text(),'{status}')][@disabled='']")).Enabled;
            Assert.AreEqual(false, element);
            Actions action = new Actions(driver);
            action.MoveToElement(WaitForElementToBeVisible(By.XPath($"//div[@class='epiq-page-control']/div//button[contains(text(),'{status}')]")));
        }
        public void VerifyEnabledState(string enableStatus)
        {
            Thread.Sleep(3000);
            bool element = driver.FindElement(By.XPath($"//button[contains(text(),'{enableStatus}')]")).Enabled;
            Assert.AreEqual(true, element);
        }
        public void SelectButtonOn()
        {
            WaitForElementToBeClickeable(selectButtonOn).Click();

        }
     
        public void PencilIcon()
        {
            Assert.IsFalse(IsElementVisible(pencilIcon));
        }
        public void EditByReceivedFrom(string receivedFrom)
        {
            Thread.Sleep(3500);
            ScrollUpToPageTop();
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement name = driver.FindElement(By.XPath("//div[contains(@class,'epiq-table-wrapper clearfix')]//tr[" + row + "]//td[4]"));
                string received = name.Text;
                
                if (received == receivedFrom)
                {
                    WaitForElementToBeClickeable(By.XPath("//tbody/tr[" + row + "]/td[10]/a"), 2).Click();
                    break;
                }
                row++;
            }
        }
        public void ClickLinkTransaction()
        {
            ScrollDownToPageBottom();
            this.Pause(3);
            WaitForElementToBeClickeable(linkTransaction).Click();
        }
        public void ClickLinkClaim()
        {
            ScrollDownToPageBottom();
            this.Pause(3);
            WaitForElementToBeClickeable(linkClaim).Click();

        }
        public void LinkTransaction(string transaction)
        {
            var linkTransaction = driver.FindElement(By.XPath("(//div[@class='form-group']/button/div)[1]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", linkTransaction);
            Thread.Sleep(2000);
            linkTransaction.Click();
        }

        public void LinkClaim()
        {
            this.Pause(3);
            var linkClaim = driver.FindElement(By.XPath("(//div[@class='col-xs-12']/div/div)[5]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", linkClaim);
            Thread.Sleep(2000);
            linkClaim.Click();
            WaitForElementToBeClickeable(saveClaim).Click();

        }
        public void VerifyFields(List<string> inputs)
        {
            foreach (string input in inputs)
            {
                int separator = input.IndexOf('-');
                string xpathSuffix = input.Substring(0, separator);
                string value = input.Substring(separator + 1);
                By xpath = By.XPath($"//div[label[text()='{xpathSuffix}']]//div[text()='{value}'] | //div[label[text()='{xpathSuffix}']]//span");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 6);
                    if (GetAttrubuteValue(control, "name").Contains("bankAccountNumber") || GetAttrubuteValue(control, "name").Contains("dateDeposited") || GetAttrubuteValue(control, "name").Contains("bankPostedDate"))
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
        public void UnLinkTransaction()
        {
            WaitForElementToBeClickeable(unlinkTransaction).Click();
        }
        public void VerifyPartialAccNum(string transaction, string AccNum)
        {
            var link = WaitForElementToBeVisible(By.XPath($"//div[@class='clearfix modal-body']/div/button[1]")).Text;
            if (link == transaction)
            {
                var partialAccountNumber = WaitForElementToBeVisible(By.XPath($"//div[@class='clearfix modal-body']/div/button[1]/div[2]/span[text()='{AccNum}']")).Text;
                partialAccountNumber.Equals(AccNum);
            }
        }
        public void CancelLinkTransaction()
        {
            var button = WaitForElementToBeClickeable(cancelTransaction, 2);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", button);
            Thread.Sleep(2000);
            button.Click();
        }
        public void SelectAccountNum(Decimal accountNumber)
        {
            WaitForElementToBeClickeable(By.XPath($"//a[text()='{accountNumber}']")).Click();
        }
        public void ClickIssueLink(string link)
        {
            WaitForElementToBeClickeable(By.XPath($"//a[contains(text(),'{link}')]")).Click();
        }
        public bool IssueReconciliationPage(string page)
        {
            return WaitForElementToBeVisible(By.XPath($"//span[text()='{page}']")).Displayed;
        }
        public void SelectTransactionsBySerialNum(string bankSerial, string ledgerSerial)
        {
            Thread.Sleep(3000);
            IList<IWebElement> bankRows = driver.FindElements(bankTransactionRows);
            int rowLength = bankRows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement serialNumber = driver.FindElement(By.XPath("//div[@class='issue-reconcile-page']//table/tbody/tr[" + row + "]/td[5]"));
                string number = serialNumber.Text;
                if (number == bankSerial)
                {
                    //ScrollDown();
                    WaitForElementToBeClickeable(By.XPath("//div[@class='issue-reconcile-page']//table/tbody/tr[" + row + "]/td[2]/div"), 2).Click();
                    break;
                }
                row++;
            }
            WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-table-title-bar bg-primary']/strong"), 2).Click();
            if (!string.IsNullOrEmpty(ledgerSerial))
                    {
                        Thread.Sleep(2000);
                        IList<IWebElement> ledgerRow = driver.FindElements(ledgerRows);
                        int length = ledgerRow.Count;

                        for (int rowLedger = 1; rowLedger <= length; rowLedger++)
                        {
                            IWebElement LedgerSerialNum = driver.FindElement(By.XPath("(//table[@class='epiq-table table table-condensed'])[2]/tbody/tr[" + rowLedger + "]/td[5]"));
                            string LedgerNum = LedgerSerialNum.Text;


                            if (LedgerNum == ledgerSerial)
                            {
                               var text = WaitForElementToBeClickeable(By.XPath("(//table[@class='epiq-table table table-condensed'])[2]/tbody/tr[" + rowLedger + "]/td[2]"), 2);
                               ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", text);
                                break;
                            }

                            rowLedger++;
                        }                        
            }
        }

        public void BankDropdown(string linkType, string transaction)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(By.XPath("(//div[@class='Select-control']/span[3]/span)[1]")).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{linkType}']")).Click();
            //WaitForElementToBeClickeable(By.XPath($"//div[strong[text()='{transaction}']]/div/div[2]//div/div/span/div[1]/span[1]")).Click();
        }
        public void BankTransactionsPageSize(int size)
        {
            this.Pause(2);
            ScrollDown();
            WaitForElementToBeClickeable(bankPageDropdown).Click();
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{size}']")).Click();
        }
        public void LedgerPageSize(int size)
        {
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(ledgerPageDropdown,3).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{size}']")).Click();
            ScrollUpToPageTop();
        }
        public void ClickSortingControls(string p0)
        {
            WaitForElementToBeClickeable(serialNumber).Click();
            WaitForElementToBeClickeable(serialNumber).Click();
        }
        public void VerifyFieldsAsReadOnly()
        {
            Assert.IsFalse(IsElementVisible(receivedFrom));
            Assert.IsFalse(IsElementVisible(addressField));
            Assert.IsFalse(IsElementVisible(checkNumber));
            Assert.IsFalse(IsElementVisible(utcCode));
        }
        public void SelectTaskType(string type)
        {
            WaitForElementToBeClickeable(By.XPath($"//span[text()='{type}']"), 3).Click();
        }
        public void DocumentDescInLineEdit(int index, string text)
        {
            WaitForElementToBeClickeable(By.XPath("//tr[" + index + "]/td[3]/div/button")).Click();
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[@class='form-group']/textarea"), 2), text);
            WaitForElementToBeClickeable(saveField, 2).Click();
            this.Pause(4);
        }
        public void InlineEditValidateText(int index1, string description, int index2, string tag)
        {
            var descriptionText = WaitForElementToBeVisible(By.XPath("//tr[" + index1 + "]/td[3]/div/button/div/span"), 2).Text;
            Assert.AreEqual(descriptionText, description);
            this.Pause(3);
            var tagText = WaitForElementToBeVisible(By.XPath("//tbody/tr[" + index2 + "]/td[6]/div/button"), 2).Text;
            Assert.AreEqual(tagText, tag);
            
        }
        public void TagInLineEdit(int index, string tag)
        {
            if (IsElementVisible(By.XPath($"//tbody/tr[{index}]/td[6]/div/button[text()='{tag}']")))
            {
                WaitForElementToBeClickeable(By.XPath("//tbody/tr[" + index + "]/td[6]/div/button"), 2).Click();
                this.Pause(2);
                WaitForElementToBeClickeable(By.XPath("//div[@id='EpiqInLineEdit']/div/form/div[1]//div/div/span[2]/span"), 4).Click();
                this.Pause(2);
                WaitForElementToBeClickeable(By.XPath("//div[@id='EpiqInLineEdit']/div/form/div[1]//div/span[2]/span"), 2).Click();
                this.Pause(5);
                var documentTag = driver.FindElement(By.XPath($"//div[@class='Select-menu']//div[text()='{tag}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", documentTag);
                this.Pause(1);
                documentTag.Click();
                //WaitForElementToBeClickeable(By.XPath($"//div[text()='{tag}']"),2).Click();
                WaitForElementToBeClickeable(saveField, 2).Click();
            }
            else
            {
                WaitForElementToBeClickeable(By.XPath("//tr[" + index + "]/td[6]/div/button")).Click();
                WaitForElementToBeClickeable(By.XPath("//div[@id='EpiqInLineEdit']/div/form/div[1]//div/span[2]")).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[text()='{tag}']")).Click();
                WaitForElementToBeClickeable(saveField, 2).Click();
            }
        }
        public void ExpandDocument()
        {
            WaitForElementToBeClickeable(expandDocument, 2).Click();
        }
        public void EditDescription(string header, string text)
        {
            WaitForElementToBeClickeable(By.XPath($"//div[label[text()='{header}']]/div/button"), 2).Click();
            this.Pause(2);
            ClearAndType(WaitForElementToBeVisible(By.XPath($"//div[h3[text()='{header}']]//div/input"), 2), text);
            var saveField1 = WaitForElementToBeVisible(saveField);
            // WaitForElementToBeClickeable(saveField, 2).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", saveField1);
        }
        public void InputAndEditSource(string header, string text, string source)
        {
            WaitForElementToBeClickeable(By.XPath($"//div[label[text()='{header}']]/div/button"), 2).Click();
            this.Pause(2);
            ClearAndType(WaitForElementToBeVisible(By.XPath($"//div[label[text()='{header}']]//input"), 2), text);
            WaitForElementToBeClickeable(dropdownField, 3).Click();
            WaitForElementToBeClickeable(By.XPath($"//div/span[text()='{source}']"), 3).Click();
            WaitForElementToBeClickeable(saveField, 2).Click();
        }
        public void EditFields(string text)
        {
                WaitForElementToBeClickeable(By.XPath("//label[text()='ASSIGNED TO']//following-sibling::div//span"), 3).Click();
               // WaitForElementToBeClickeable(By.XPath("//div[@class='Select-control']/span/div[@class='Select-placeholder']"), 3).Click();
                WaitForElementToBeClickeable(clearField, 2).Click();
                this.Pause(2);
                WaitForElementToBeClickeable(dropdownField, 2).Click();
                this.Pause(2);
                var assignedTo = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{text}']"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", assignedTo);
                this.Pause(5);
                assignedTo.Click();
                WaitForElementToBeClickeable(saveField, 2).Click();

        }
        public void EditTags(string tag)
        {

            WaitForElementToBeClickeable(By.XPath("//label[text()='TAGS']//following-sibling::div/button"), 3).Click();
            //WaitForElementToBeClickeable(By.XPath("//div[@class='Select-control']/span/div[@class='Select-placeholder']"), 3).Click();
            WaitForElementToBeClickeable(clearField, 2).Click();
            this.Pause(2);
            WaitForElementToBeClickeable(dropdownField, 2).Click();
            var tagName = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{tag}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", tagName);
            this.Pause(5);
            tagName.Click();
            WaitForElementToBeClickeable(saveField, 2).Click();
        }
        public void EditWithDescription(string description)
        {
            this.Pause(3);
            IList<IWebElement> list = driver.FindElements(caseTableRows);
            int caseRows = list.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement descriptionText = driver.FindElement(By.XPath("//tr[" + row + "]//td[3]//span"));
                string descriptionList = descriptionText.Text;

                if (descriptionList == description)
                {
                    Thread.Sleep(1000);
                    var edit = driver.FindElement(By.XPath("//tr[" + row + "]/td[11]/a/button"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void InputAndEditDoc(string header, string text, string source)
        {
            WaitForElementToBeClickeable(By.XPath($"//div[label[text()='{header}']]/div/button"), 2).Click();
            this.Pause(2);
            ClearAndType(WaitForElementToBeVisible(By.XPath($"//div[label[text()='{header}']]//input"), 2), text);
            bool isFound = false;
            this.Pause(3);
            if (IsElementVisible(By.XPath("//div[@class='Select-control']/span/div[@class='Select-value']")))
            {
                WaitForElementToBeClickeable(dropdownField, 3).Click();
                WaitForElementToBeClickeable(By.XPath($"//div[text()='{source}']"), 3).Click();
                WaitForElementToBeClickeable(saveField, 2).Click();
                isFound = true;
            }
            Assert.IsTrue(isFound);
        }

        public void DocumentBreadCrumb(string breadCrumb)
        {
            WaitForElementToBeClickeable(By.XPath($"//ol/li[1]/a[text()='{breadCrumb}']"), 2).Click();
        }
        public void VerifyDebtorAttorney(string attorney)
        {
            var debtorAttorneyText = WaitForElementToBeVisible(debtorAttorney).Text;
            Assert.AreEqual(debtorAttorneyText, attorney);
        }

        public void VerifyHistoryColumn()
        {
            Actions action = new Actions(driver);
            var element = WaitForElementToBeVisible(historyIcon);
            action.MoveToElement(element).Build().Perform();
            WaitForElementToBeClickeable(historyIcon, 3).Click();
        }

        public void VerifyCaseLevelPageTableColumns(List<string> titles, string page)
        {
            List<string> tableTitles = new List<string>();
            var tableHeader = WaitForElementToBeVisible(By.XPath($"//h3[contains(text(),'{page}')]")).Text;
            if (page == tableHeader)
            {
                for (int column = 2; column <= 6; column++)
                {
                    var tableTitle = driver.FindElement(By.XPath("//table//tr[1]//th[" + column + "]")).Text;
                    tableTitles.Add(tableTitle);
                }
                bool equal = titles.SequenceEqual(tableTitles);
            }
        }

        public void VerifyPrintDisabledState()
        {
            bool state = WaitForElementToBeVisible(printButton).Enabled;
            Assert.IsFalse(state);
        }

        public void VerifyPrintInEnabledState()
        {
            WaitForElementToBeVisible(tableCheckbox, 2).Click();
            bool state = WaitForElementToBeVisible(printButton, 3).Displayed;
            Assert.IsTrue(state);
        }

        public void SelectHistoryButton()
        {
            WaitForElementToBeClickeable(historyButton).Click();
        }
        public void VerifyHistoryTableHeader(string header)
        {
            var tableHeader = WaitForElementToBeVisible(historyTableHeader).Text;
            Assert.AreEqual(tableHeader, header);
        }

        public void VerifyPrintIcon()
        {
            bool state = WaitForElementToBeVisible(printIcon).Enabled;
            Assert.IsTrue(state);
        }
        public void EditDescription(string description)
        {
            WaitForElementToBeClickeable(By.XPath("//tr/td[2]/div/div/button"), 4).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(By.XPath("//div[h3[text()='DESCRIPTION']]/div/textarea[text()]"), 4));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[h3[text()='DESCRIPTION']]/div/textarea"), 2), description);
        }


        //public void VerifyCaseLevelPageTableColumns(List<string> titles)
        //{

        //    foreach (var element in titles)
        //    {
        //        for(int i=2; i<=11; i++)
        //        {
        //            IList TableElements = driver.FindElements(By.XPath("//table[@class='epiq-table table table-condensed']//tr/th[" + i + "]"));
        //            foreach(IWebElement title in TableElements)
        //            {
        //                Assert.AreEqual(title.Text,element);
        //            }
        //            break;
        //        }
        //        break;
        //    }
        //}

        //public void VerifyPrintDisabledState()
        //{
        //    bool state = WaitForElementToBeVisible(PRINT_BUTTON).Enabled;
        //    Assert.IsFalse(state);
        //}

        //public void VerifyPrintInEnabledState()
        //{
        //    WaitForElementToBeVisible(TABLE_CHECKBOX,2).Click();
        //    bool state = WaitForElementToBeVisible(PRINT_BUTTON,3).Displayed;
        //    Assert.IsTrue(state);
        //}

        //public void SelectHistoryButton()
        //{
        //    WaitForElementToBeClickeable(HISTORY_BUTTON).Click();
        //}
        //public void VerifyHistoryTableHeader(string header)
        //{
        //    var tableHeader = WaitForElementToBeVisible(HISTORY_TABLE_HEADER).Text;
        //    Assert.AreEqual(tableHeader, header);
        //}

        //public void VerifyPrintIcon()
        //{
        //    bool state = WaitForElementToBeVisible(PRINT_ICON).Enabled;
        //    Assert.IsTrue(state);
        //}

        public void ClickOnCompExpenseDetailsButton()
        {
            WaitForElementToBeClickeable(expenseDetailsButton).Click();
        }
        public void ClickOnCalculatorButton()
        {
            WaitForElementToBeClickeable(By.XPath("//button[text()=' CALCULATOR']")).Click();
        }
        public void EnterAdditionalCompensationValues()
        {
            Random random = new Random();
            var reqComp = random.Next(100, 9999);
            var maxComp = random.Next(10, 999);
            SelectAndDeleteCompleteText(By.XPath("//span[text()='Additional compensable amount']/parent::div/following-sibling::div//span/input"));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//span[text()='Additional compensable amount']/parent::div/following-sibling::div//span/input")), reqComp.ToString());
            SelectAndDeleteCompleteText(By.XPath("//span[text()='Non compensable amount']/parent::div/following-sibling::div//span/input"));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//span[text()='Non compensable amount']/parent::div/following-sibling::div//span/input")), maxComp.ToString());
        }
        public void ClickonFreezeCompensationButton()
        {
            ScrollDownToPageBottom();
            var freeze = "200";
            Thread.Sleep(2000);
            var yes = driver.FindElement(By.XPath("//span[text()='Freeze compensation at:']/parent::label"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", yes);
            ClearAndType(WaitForElementToBeVisible(By.XPath("//span[text()='Freeze compensation at:']/parent::label/parent::div/../following-sibling::div//input")), freeze.ToString());

        }
        public void ClickOnCloseButton()
        {
            var close = driver.FindElement(By.XPath("//div[@class='modal-footer text-right']/button[text()='CLOSE']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", close);
        }
        public void ClickOnByDateTab()
        {
            Thread.Sleep(3000);
            var dts = driver.FindElement(By.XPath("//div[@id='trustee-comp-calculator-tabs']//li[2]//a[text()='BY DATE']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", dts);
        }
        public void EnterTheTransactionDates()
        {
            Thread.Sleep(2000);
            var from = driver.FindElement(By.XPath("(//div[span[contains(text(),'Transaction from')]]/following-sibling::div//span/div/input)[2]"));
            from.SendKeys("08/22/17");
            Thread.Sleep(2000);
            var to = driver.FindElement(By.XPath("(//div[span[contains(text(),'Transaction to')]]/following-sibling::div//span/div/input)[2]"));
            to.SendKeys("09/10/18");
        }
        public void ClickOnExpenses()
        {
            WaitForElementToBeClickeable(expenses).Click();
        }
        public void VerifyTheNumberOfExpensesInTheGrid()
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(expensesRows);
            int trusteeExpenseRows = rows.Count;
            IWebElement UIExpense = driver.FindElement(By.XPath("//h3[text()='Expenses']/span/span"));
            string UIExpenseText = UIExpense.Text;
            int UIExpenseCount = int.Parse(UIExpenseText);
            Assert.AreEqual(trusteeExpenseRows, UIExpenseCount);
        }
        public void VerifyFieldsInExpensesSummary(string expenses, string paid, string balance, string amount)
        {
            var totalExpenses = WaitForElementToBeVisible(trusteeExpenses).Text;
            Assert.IsTrue(expenses.Equals(totalExpenses, StringComparison.OrdinalIgnoreCase));
            var totalPaid = WaitForElementToBeVisible(trusteePaid).Text;
            Assert.IsTrue(paid.Equals(totalPaid, StringComparison.OrdinalIgnoreCase));
            var balanceDue = WaitForElementToBeVisible(trusteeBalanceDue).Text;
            Assert.IsTrue(balance.Equals(balanceDue, StringComparison.OrdinalIgnoreCase));
            var allowedAndClaimedAmounts = WaitForElementToBeVisible(trusteeAmounts).Text;
            Assert.IsTrue(amount.Equals(allowedAndClaimedAmounts, StringComparison.OrdinalIgnoreCase));
            
        }
        public void VerifyColumnsInExpenses(string date, string type, string uom, string price, string qty, string total, string notes)
        {
            WaitForElementToBeClickeable(expandColumns).Click();
            var expenseDate = WaitForElementToBeVisible(trusteeExpensesDate).Text;
            Assert.IsTrue(date.Equals(expenseDate, StringComparison.OrdinalIgnoreCase));
            var expenseType = WaitForElementToBeVisible(trusteeExpensesType).Text;
            Assert.IsTrue(type.Equals(expenseType, StringComparison.OrdinalIgnoreCase));
            var expenseUOM = WaitForElementToBeVisible(trusteeExpensesUOM).Text;
            Assert.IsTrue(uom.Equals(expenseUOM, StringComparison.OrdinalIgnoreCase));
            var expenseUnitPrice = WaitForElementToBeVisible(trusteeExpensesUnitPrice).Text;
            Assert.IsTrue(price.Equals(expenseUnitPrice, StringComparison.OrdinalIgnoreCase));
            var expenseQuantity = WaitForElementToBeVisible(trusteeExpensesQuantity).Text;
            Assert.IsTrue(qty.Equals(expenseQuantity, StringComparison.OrdinalIgnoreCase));
            var expenseTotal = WaitForElementToBeVisible(trusteeExpensesTotal).Text;
            Assert.IsTrue(total.Equals(expenseTotal, StringComparison.OrdinalIgnoreCase));
            var expenseNotes = WaitForElementToBeVisible(trusteeExpensesNotes).Text;
            Assert.IsTrue(notes.Equals(expenseNotes, StringComparison.OrdinalIgnoreCase));

        }
        public void VerifyDefaultDataInFilterOptionsExpenseType(string type)
        {
            WaitForElementToBeClickeable(trusteeExpensesFilter).Click();
            IWebElement expenseType = driver.FindElement(By.XPath("//div[@class='Select-control']/span/div[@class='Select-placeholder']"));
            Thread.Sleep(2000);
            string UIexpenseType = expenseType.Text;
            Assert.AreEqual(UIexpenseType, type);
            WaitForElementToBeClickeable(trusteeExpensesFilterClose).Click();
        }
        public void EditExpenses(string date, string type, string measure, string remark, string qty, string price)
        {
            var editExpenseButton1 = WaitForElementToBeClickeable(editExpenseButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", editExpenseButton1);
            this.Pause(3);
            IWebElement dateOfExpense = driver.FindElement(By.XPath("//input[@placeholder='MM/DD/YY']"));
            dateOfExpense.Click();
            dateOfExpense.SendKeys(Keys.Control + "a");
            dateOfExpense.SendKeys(Keys.Delete);
            this.Pause(3);
            dateOfExpense.Click();
            dateOfExpense.SendKeys(date);
            WaitForElementToBeVisible(trusteeExpenseType).Click();
            var expenseType = WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{type}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", expenseType);
            this.Pause(1);
            expenseType.Click();
            ClearAndType(WaitForElementToBeVisible(unitOfMeasure), measure);
            ClearAndType(WaitForElementToBeVisible(expenseRemarks), remark);
            ClearAndType(WaitForElementToBeVisible(quantity), qty);
            ClearAndType(WaitForElementToBeVisible(unitPrice), price);
            WaitForElementToBeClickeable(editExpenseSave).Click();
        }
        public void SelectXInTheGlobalCaseNavigation()
        {
            WaitForElementToBeClickeable(closeCase).Click();
        }
        public void SelectAllCasesInTheGlobalCaseNavigation()
        {
            WaitForElementToBeClickeable(caseArrow).Click();
            WaitForElementToBeClickeable(allCases).Click();
        }
        public void NavigatedToTrusteeExpenses(string casenum, string expenses)
        {
            this.Pause(3);
            var caseNumber = WaitForElementToBeVisible(trusteeExpensesCaseNumber).Text;
            Assert.IsTrue(casenum.Equals(caseNumber, StringComparison.OrdinalIgnoreCase));
            var expensesHeader = WaitForElementToBeVisible(trusteeExpensesHeader).Text;
            Assert.IsTrue(expensesHeader.Contains(expenses));
        }
        public void VerifyMessageWhenNoResultsInGrid(string msg)
        {
            var Message = WaitForElementToBeVisible(noResultsMessage).Text;
            Assert.IsTrue(msg.Equals(Message, StringComparison.OrdinalIgnoreCase));

        }
        public void ClickOnBankAccountsInBreadcrumb()
        {
            this.Pause(3);
            WaitForElementToBeClickeable(bankAccounts).Click();
        }
        public void SelectLedgerTransactionsInDropdown(string linkType)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(By.XPath("(//div[@class='Select-control']/span[3]/span)[2]")).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{linkType}']")).Click();
            WaitForElementToBeClickeable(closeButton).Click();
        }
        public void ClickOnExportButton()
        {
            WaitForElementToBeClickeable(By.XPath("//span[@class='epiq-export']/button")).Click();
        }
        }

    }

