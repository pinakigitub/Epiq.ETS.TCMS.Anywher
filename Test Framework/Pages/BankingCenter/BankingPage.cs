using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using FluentAssertions;
using System.Data;
using System.Threading;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Bogus;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    public class BankingPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        public BankingPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        //Bank Accounts Locators
        private By bankingAccountsCleared = By.XPath("//div[@class='epiq-table-input-inline-edit']//button");
        private By bankingAccountsClearedInLineInput = By.XPath("//div[@class='form-group']//input");
        private By bankingAccountsInLineSubmit = By.XPath("//div[@class='epiq-form-inline-button']//button[@type='submit']");
        private By bankingAccountsCaseListLocator = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//td[@data-title='CASE #']//span//span");
        private By accountNumberList = By.XPath("//td[@class='epiq-table-data-title  visible-md visible-lg visible-xl' or @class='epiq-table-data-title ']/a");
        private By editBankAccount = By.XPath("//a[@title='Edit Bank Account']/i");
        private By nextCheckNumber=By.XPath("//input[@name='nextCheckNumber']");
        private By nextCheckNumberdisable = By.XPath("//div[@name='nextCheckNumber']");
        private By nextDepositNumberdisable = By.XPath("//div[@name='nextDepositNumber']");
        private By nextDepositNumber=By.XPath("//input[@name='nextDepositNumber']");
        private By selectFirstOption = By.XPath("//td[@data-title='BALANCE']/following-sibling::td");


        //Object for the Banking Activity  
        private By bankingActivityPageHeader = By.XPath("//div[@class='epiq-page-header  ']/h2");
        //private By BankingActivityPageBreadCrumbText = By.XPath("//*[@role='navigation']//span");
        private By bankingActivityPageFilter = By.XPath("//div[@class='epiq-page-control pull-right']//button[1] | //div[@class='pull-right epiq-page-control']/button[1] | //div[@class='pull-right']/button[1]");
        private By bankingActivityPageFilterClose = By.XPath("//div[@class='pull-right form-group epiq-fa']/i");
        private By bankingActivityPageBreadCrumb = By.XPath("//*[@role='navigation']");
        private By bankingActivityPageHeaderName = By.XPath("//th[@class='epiq-table-header-sortable' or @class='epiq-table-header-sortable visible-lg visible-xl' or @class='epiq-table-header-sortable visible-md visible-lg visible-xl']");
        private By bankingActivityPageFilterOptions = By.XPath("//div[@class='epiq-off-canvas-header']/h3");
        private By filterCaseNumberOrDebtorName = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//input[1]");
        private By filterAccountNumber = By.XPath("//div[label[text()='ACCOUNT #']]/input");
        private By bankingPrintingFilterType = By.XPath("//div[label[text()='TYPE']]//div[@class='Select-input']/input");
        private By filterCaseOrDebtorSelection = By.XPath("//a[@class ='dropdown-item']");
        private By bankingActivityResetButton = By.XPath("//button[text()='RESET']");
        private By bankingActivityCloseButton = By.XPath("//button[text()='CLOSE']");
        private By bankingAccountRowExpandButton = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[1]/td[1]/div/i");
        //private string BankingActivityFilterSelect = "//div/div[text()='{0}']";
        private By pageCount = By.XPath("//h3[text()='Unreconciled Bank Accounts']/span");
        private By pageCountAccounts = By.XPath("//h3[text()='Bank Accounts']/span");
        private By pageCountReceipts = By.XPath("//h3[text()='Receipts']/span");
        private By pageCountChecks = By.XPath("//h3[text()='Print Checks/Deposits']/span");
        private By pagination = By.ClassName("pagination");
        private By balanceFrom = By.XPath("//input[@data-test-selector='fromBalances']");
        private By balanceTo = By.XPath("//input[@data-test-selector='toBalances']");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By bankingActivityPageRefresh = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[3]/div[2]/div/div[1]/button[2]");
        private By bankingActivityAccountNumber = By.XPath("//div[label[text()='ACCOUNT #']]/input");
        private By bankingActivityIssueFilter = By.XPath("//div[label[text()='ISSUE']]//div[2]/input");
        private By debtorAccounts = By.XPath("//div[@class='epiq-ellipsis-text']/a");
        private By debtorActivity = By.XPath("//div[@class='epiq-ellipsis-text']/a");
        private By printCheckBox = By.XPath(".//*[@id='epiq-print-checks-deposits-page-wrap']/div[3]/div/div/table/tbody/tr[1]/td[2]/div/label");
        private By printButton = By.XPath("//button[text()='PRINT']");
        private By printQueueMessage = By.XPath("//div[@class='rrt-middle-container']/div[@class='rrt-text']");
        private By printQueueClose = By.XPath("//button[text()='?']");
        private By bankingActivityFilterClose = By.XPath("//button[text()='CLOSE']");
        private By filterUnlinkedTypeValue = By.XPath("//div[label[text()='UNLINKED TYPE']]//div[@class='Select-control']//span[@class='Select-value-label']");
        private By filterHasBankTransactionsValue = By.XPath("//div[label[text()='HAS BANK TRANSACTIONS']]//div[@class='Select-control']//span[@class='Select-value-label']");
        private By filterCaseStatusValue = By.XPath("//div[label[text()='CASE STATUS']]//div[@class='Select-control']//span[@class='Select-value-label']");
        private By selectReceipt = By.XPath("//div[@class='col-xs-12']/div[1]/div[@class='epiq-lookup-picker-card-content']");
        private By InterestAsset = By.XPath("//div[text()='Post-Petition Interest Deposits']/parent::div");
        private By descriptionText = By.XPath("//label[contains(text(),'DESCRIPTION')]//following-sibling::input");


        // Receipt Log
        private By receiptCheckbox = By.XPath("//tbody/tr[not(@class)]/td[2]/div");
        private By receiptDepositLink = By.XPath("//div[@class='epiq-page-control']/div/button[3]");
        private By receiptFilterLinkedArrow = By.XPath("//div[label[text()='LINKED']]//span[@class='Select-arrow']");
        private By receiptFilterClose = By.XPath("//button[text()='CLOSE']");
        private By receiptFilterReset = By.XPath("//button[text()='RESET']");
        private By checkBox = By.XPath("(//div[@class='epiq-input-styled-checkbox '])[7]");
        private By editButton = By.XPath("(//td[@class='epiq-table-data-no-title ']/a)[6]");
        private By verifiyColor = By.XPath("//td[@class='epiq-table-data-title  visible-lg visible-xl']/i");
        private By verifiyColorMouseHover = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div[4]/div/table/tbody/tr[1]/td[11]/i");
        private By verifyButton = By.XPath("//button[text()=' VERIFY']");
        private By editHeaderTitle = By.XPath("//div[contains(@class,'title')]//li[@class='active']//span");
        private By saveButtonEditPage = By.XPath("//button[text()='SAVE']");
        private By cancelButtonEditPage = By.XPath("//button[text()='CANCEL']");
        private By linkTransactionButton = By.XPath("//button[text()=' LINK TRANSACTION']");
        private By selectTransaction = By.XPath("//div[@class='clearfix modal-body']//button");
        private By unLinkTransactionButton = By.XPath("//button[text()=' UNLINK TRANSACTION']");
        private By caseDetailsTransaction = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div/form/div[1]/div[4]/div[3]/div");
        private By netAmount = By.XPath("//div[label[text()='NET AMOUNT']]/span/input");
        private By grossAmount = By.XPath("//div[label[text()='GROSS AMOUNT']]/span/input");
        private By addButton = By.XPath("//button[text()='ADD']");
        private By closingCostNonClaimButton = By.XPath("//div[@class='epiq-override-buttons']/button[2]");
        private By cancelButton = By.XPath("//div[@class='modal-footer']//button[text()='CANCEL']");
        private By saveButton = By.XPath("//button[text()='SAVE']");

        // Receipt Log Inputs
        private By addReceiptButton = By.XPath("//button[text()=' RECEIPT']");
        private By caseNumber = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]/div/div[1]");
        private By caseSelect = By.XPath("//a[@class='dropdown-item']");
        private By receivedFrom = By.XPath("//div[label[text()='RECEIVED FROM']]/input");
        private By bankReceived = By.XPath("//div[label[text()='BANK RECEIVED DATE']]/span/div/input");
        private By address = By.XPath("//div[label[text()='ADDRESS']]/textarea");
        private By amount = By.XPath("//div[label[text()='AMOUNT']]/span/input");
        private By checkNum = By.XPath("//div[label[text()='CHECK #']]/input");
        private By logCheckDate = By.XPath("//div[label[text()='CHECK DATE']]//input");
        private By checkReceived = By.XPath("//div[label[text()='CHECK RECEIVED']]//input");
        private By transactionDescription = By.XPath("//div[label[text()='TRANSACTION DESCRIPTION']]//input");
        private By transactionNotes = By.XPath("//div[label[text()='TRANSACTION NOTES']]/textarea");
        private By utcSection = By.XPath("//div[label[text()='UTC']]//div[@class='Select-control']/span/div[1]");
        private By receiptSave = By.XPath("//button[text()='SAVE']");
        private By debtorColumn = By.XPath("//div[@class='epiq-table-wrapper clearfix ']//td[4]");

        //Create Deposit Inputs
        private By linkAsset = By.XPath("//button[text()='LINK ASSET']");
        private By depositLinkAsset = By.XPath("//div[text()='Wells Fargo Savings A/C']/parent::div");

        private By closeAsset = By.XPath("//div[@class='modal-content']/div[@class='modal-header']/button");
        private By linkedTyep = By.XPath("(//span[@class='Select-arrow'])[1]");
                                        //div[label[text()='LINKED']]//span/div[1]


        // adding the code for View permission

        private By accountNumberDisabled = By.XPath("//td[@class='epiq-table-data-title  visible-md visible-lg visible-xl']/a");
        private By accountSummaryHeader = By.XPath("(//div[@class='epiq-page-body']//h3)[1]");
        private By transcationHeader = By.XPath("//div[contains(@class,'epiq-table-banner clearfix container')]//h3");
        private By checkButton = By.XPath("//button[text()=' CHECK']");

        private By voidButton = By.XPath("//button[text()=' VOID']");
        private By viewButton = By.XPath("//td[@class='epiq-table-data-no-title ']/a");
        private By depositButton = By.XPath("//button[text()=' DEPOSIT']");
        private By viewReceiptHeader = By.XPath("//div[contains(@class,'title')]//li[@class='active']//span");
        private By errorDisplay = By.XPath("//div[@class='col-xs-10 epiq-security-warning-message']");
        private By viewtransaction = By.XPath("//td[@class='epiq-table-data-no-title ']/a");
        private By caseTableRowsLocator = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By checktype = By.XPath("//div[@class='epiq-page-body']//tr/td[4]");
        private By header = By.XPath("//div[@class='epiq-page-case-modify-title']/ol//li[@class='active']/span[text()='View Check']");
        private By checkbank = By.XPath("//div[label[text()='BANK']]/div");
        private By checkaccountnumber = By.XPath("//div[label[text()='ACCOUNT NUMBER']]/div");
        private By checkserialnum = By.XPath("//div[label[text()='SERIAL #']]/div");
        private By checktransactiondate = By.XPath("//div[label[text()='TRANSACTION DATE']]/div");
        private By checkcleardate = By.XPath("//div[label[text()='CLEAR DATE']]/div");
        private By payee = By.XPath("//div[label[text()='PAYEE NAME']]/div");
        private By payeedesc = By.XPath("//div[label[text()='DESCRIPTION']]/div");
        private By payeeremark = By.XPath("//div[label[text()='REMARKS']]/div");
        private By checkamouunt = By.XPath("//div[label[text()='AMOUNT']]/div");
        private By checkallocations = By.XPath("//div[label[text()='SUM OF ALLOCATIONS']]/div");
        private By checkdistributiontype = By.XPath("//div[label[text()='DISTRIBUTION TYPE']]/div");
        private By payeeaddress = By.XPath("//div[label[text()='ADDRESS']]/div");
        private By viewcheckbreadcrumb = By.XPath("//*[@role='navigation']");
        private By claimantname = By.XPath("//div[label[text()='NAME']]/div");
        private By claimamount = By.XPath("//div[label[text()='LINKED AMOUNT']]/div");
        private By claimlinkutc = By.XPath("//div[label[text()='UTC']]/div");
        private By checkviewclose = By.XPath("//div[@class='pull-right epiq-page-footer-buttons']/button[text()='CLOSE']");
        private By accountmanagementlink = By.XPath("//*[@role='navigation']//a[contains(text(),'Account Management')]");
        private By accountnum = By.XPath("//a[contains(@href,'/banking/bank-accounts/586670?globalCaseId=1091863')]");
        private By caseTableRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        //private By Edittransaction = By.XPath("//a[@title='Edit Transaction']");
        private By writecheckheader = By.XPath("//div[@class='epiq-page-case-modify-title']//span");
        private By writecheckbreadcrumb = By.XPath("//*[@role='navigation']");
        private By payeeaddr = By.XPath("//div[label[text()='ADDRESS']]/div");
        private By cleardate = By.XPath("//div[@class='form-group']/span/div/input");
        private By checkaccount = By.XPath("//div[label[text()='ACCOUNT']]/div");
        private By writecheckpayeename = By.XPath("//div[label[text()='SELECTED PAYEE NAME']]/div");
        private By checkclaimamount = By.XPath("//div[label[text()='AMOUNT']]/span/input");
        private By description = By.XPath("//div[label[text()='DESCRIPTION']]/input");
        private By checkremark = By.XPath("//div[@class='form-group']//textarea[@name='notes']");
        private By distributiontype = By.XPath("//div[@class='Select-control']//div[@class='Select-value']");
        private By linkclaimbutton = By.XPath("//div[@class='form-group epiq-form-item-list']/button[text()='LINK CLAIM']");
        private By selectclaim = By.XPath("//div[@class='epiq-lookup-picker-card-content']");
        private By addclaim = By.XPath("//div[@class='modal-footer']//button[text()='ADD']");
        private By cname = By.XPath("(//div[label[text()='NAME']]/div/div/button)[2]");
        private By claim = By.XPath("//div[@class='popover-content']/input");
        private By cdesc = By.XPath("(//div[label[text()='DESCRIPTION']]/div/div/button)[2]");
        private By utc = By.XPath("(//div[label[text()='UTC']]/div/div/button)[2]");
        private By lamount = By.XPath("(//div[label[text()='LINKED AMOUNT']]/div/div/button)[2]");
        private By deleteclaimlink = By.XPath("(//div[@class='epiq-icon-right-2x']/i)[2]");
        private By utcselect = By.XPath("//div[@class='Select-value']");
        private By linkedamount = By.XPath("//div[@class='popover-content']/span/input");
        private By unlinkedallocations = By.XPath("//div[text()='UNLINKED ALLOCATIONS (UTC)']");
        private By unlinkedallocationutc = By.XPath("//div[@class='panel-body']//button[text()='UNLINKED ALLOCATION (UTC)']");
        private By pname = By.XPath("(//div[label[text()='PAYEE NAME']]/input)");
        private By unlinkedallocationutcname = By.XPath("//div[@class='Select-control']//div[@class='Select-placeholder']");
        private By unlinkedamount = By.XPath("(//div[label[text()='AMOUNT']]/span/input)[2]");
        private By editname = By.XPath("(//div[label[text()='NAME']]/div/div/button)[3]");
        private By editdesc = By.XPath("(//div[label[text()='DESCRIPTION']]/div/div/button)[3]");
        private By editamount = By.XPath("(//div[label[text()='LINKED AMOUNT']]/div/div/button)[3]");
        private By deletelink = By.XPath("(//div[@class='epiq-icon-right-2x']/i)[3]");
        private By savewritecheck = By.XPath("//button[text()='SAVE']");
        private By cancelwritecheck = By.XPath("//button[text()='CANCEL']");
        private By bankaccountsrows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By filterClose = By.XPath("//button[text()='CLOSE']");
        private By filterAccountManagement = By.XPath("//button[contains(@title,'filters.')]");
        private By filterClearedDate = By.XPath("//div[label[text()='CLEARED DATE']]//span[@class='Select-arrow-zone']");
        private By filterClearedDateValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterStopPayment = By.XPath("//div[label[text()='STOP PAYMENT']]//span[@class='Select-arrow-zone']");
        private By filterStopPaymentValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterPermitAssetImbalance = By.XPath("//div[label[text()='PERMIT ASSET IMBALANCE']]//span[@class='Select-arrow-zone']");
        private By filterPermitAssetImbalanceValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterReset = By.XPath("//button[text()='RESET']");
        private By assetlink = By.XPath("//div[4]/div/div/div/a/div");
        private By closingCostlink = By.XPath("//div[5]/div/div/div/a/div");
        private By claimlinks = By.XPath("//div[7]/div/div/div/a/div");
        By AddClosingCostPayeeName = By.Name("addCLAIMListItem.payeeName");
        By AddClosingCostDescription = By.Name("addCLAIMListItem.description");
        By AddClosingCostLinkedAmount = By.Name("addCLAIMListItem.linkedAmount");
        By AddClosingCostAddress = By.Name("addCLAIMListItem.address");
        By AddClosingCostUTCCode = By.XPath("//div[@class='modal-body']//div[label[text()='UTC CODE']]//div/input");
        private By accountNumberFilter = By.XPath("//div[@class='row']//input[@name='accountNumber']");
        private By addTransactionButton = By.XPath("//button[text()=' TRANSACTION']");
        private By depositButtonInAddTransaction = By.XPath("//div[contains(@class,'add-transaction-modal-text col')]/button[text()='DEPOSIT'][2]");
        private By cancelButtonInPage = By.XPath("//button[text()='CANCEL'] | //button[text()='Cancel']");
        private By voidedType = By.XPath("//div[@data-test-selector='voided']//span/div");
       
        public string bankName = null;
        public string accountName = null;
        public string accountNumber = null;
        public int grossAmounts, netAmounts, sumAmount, closingAmount;
        public string netAmountsWithCommas, grossAmountsWithCommas;

        #region Void Transaction Bank account page
        private By voidIcon = By.XPath("//span[text()='VOID']");
        //tr[td[@class='epiq-table-data-no-title']][1]//input
        private By checkBoxs = By.XPath("//tr[td[@class='epiq-table-data-no-title']][1]//input");
        private By popUpHeader = By.XPath("//h4");
        private By popUpBody = By.XPath("//div[@class='modal-body']/div[1]");
        private By popUpOk = By.XPath("//button[text()='OK']");
        private By clearedDateInput = By.XPath("//div[label[text()='CLEARED DATE']]//div[@class='Select-input']/input");
        private By remarks = By.XPath("//input[@type ='text']");
        private By transactionColor = By.XPath("//i[@class='fa fa-stop-circle'] | //div[@class='epiq-icon-stop']");
        private By stopPaymentField = By.XPath("//div[label[text()='STOP PAYMENT']]//div[@class='Select-input']/input");
        #endregion

        public void ClickCheckBoxIcon()
        {
            this.Pause(2);
            var check = driver.FindElement(checkBox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", check);
        }

        public void ValidateCaseDetails()
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBePresent(caseDetailsTransaction).Should().NotBeNull();
        }
        public void ValidateCaseDetailsNull()
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBePresent(caseDetailsTransaction).Should().BeNull();
        }
        public void ClickEditIcon()
        {
            this.Pause(2);
            var edit = driver.FindElement(editButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
        }

       public string GetEditHeaderName()
        {
            return this.WaitForElementToBeVisible(editHeaderTitle).Text;
        }
        public void ClickLinkTransaction()
        {
            this.Pause(2);
            this.ScrollDownToPageBottom();
            var link = driver.FindElement(linkTransactionButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", link);
        }
        public void ClickCaseTransaction()
        {
            this.Pause(2);
            this.ScrollDownToPageBottom();
            var cases = driver.FindElement(selectTransaction);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", cases);
        }
        public void ClickUnLinkTransaction()
        {
            this.Pause(2);
            this.ScrollDownToPageBottom();
            var unlink = driver.FindElement(unLinkTransactionButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", unlink);
        }
        public void ClickEditSaveButton()
        {
            this.Pause(2);
            this.ScrollDownToPageBottom();
            var save = driver.FindElement(saveButtonEditPage);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", save);
        }
        public bool ValidateEditCancelButton()
        {
            this.Pause(2);
            this.ScrollDownToPageBottom();
            var save = driver.FindElement(cancelButtonEditPage);
            return save.Enabled;
        }
        public void ClickVerifyButton()
        {
            this.Pause(2);
            var verify = driver.FindElement(verifyButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", verify);
        }

        public void ValidateVerifiedColor()
        {
            string color = driver.FindElement(verifiyColor).GetCssValue("color");
            color.Contains("rgba(4, 157, 223, 1)");
        }
        public void VerifyMouseHover()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(verifiyColorMouseHover)).Perform();
            this.PressEscapeKey();
        }



        public void SelectTransaction(string voidType)
        {
            this.WaitForElementToBeVisible(receiptCheckbox);
            var elements = driver.FindElements(receiptCheckbox);
            foreach(var element in elements)
            {
                element.Click();
                this.WaitForElementToBeVisible(receiptDepositLink);
                var e = driver.FindElement(receiptDepositLink);
                MoveToViewElement(e);
                var attribute = e.GetAttribute("aria-describedby");
                if ((voidType.Equals("void") && attribute != null) || (voidType.Equals("not void") && attribute == null))
                    break;
                element.Click();
            }

        }

        public AddDeposit ClickOnDepositLinkButton()
        {
            this.Pause(3);
            ScrollUpToPageTop();
            this.WaitForElementToBeVisible(receiptDepositLink).Click();
            return new AddDeposit(driver);
        }

        public void clickOnCheckBox()
        {

            this.Pause(1);
            var e = driver.FindElement(printCheckBox);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }

        public void clickOnPrintButton()
        {
            this.WaitForElementToBeClickeable(printButton).Click();
            Thread.Sleep(1500);
        }

        public string validatePrintQueueMessage()
        {

            var message = driver.FindElement(printQueueMessage).Text;
            return message;
        }
        public void clickOnPrintCloseButton()
        {
            String parentWindowHandle = driver.CurrentWindowHandle;
            List<string> lstWindow = driver.WindowHandles.ToList();

            // Traverse each and every window 
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window - > " + handle);
                Thread.Sleep(2000);
                //Switch to the desired window first and then execute commands using driver
                driver.SwitchTo().Window(handle);
                this.Pause(5);     
            }
          //  driver.Close();
        }
        public void mouseHouverActivity()
        {
            this.Pause(5);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(debtorActivity)).Perform();
            this.PressEscapeKey();
        }

        public void MouseHouver()
        {

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(debtorAccounts)).Perform();
            this.PressEscapeKey();
        }

        public void clickOnRowExpandButton()
        {
            this.WaitForElementToBeVisible(bankingAccountRowExpandButton).Click();
        }
        

        public void ClickOnResetButton()
        {
            this.Pause(3);
            var e = driver.FindElement(bankingActivityResetButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public void ClickOnCloseButton()
        {
            this.Pause(3);
            var e = driver.FindElement(bankingActivityCloseButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public string GetHeaderName()
        {
            return this.WaitForElementToBeVisible(bankingActivityPageHeader).Text;
        }

        public void ClickOnFilter()
        {
            this.Pause(1);
             var filterAccountManagement = this.WaitForElementToBeClickeable(bankingActivityPageFilter);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", filterAccountManagement);
        }

        public void ClickOnFilterClose()
        {
            this.WaitForElementToBeVisible(bankingActivityPageFilterClose).Click();
        }
        public void ClickOnReceiptFilterClose()
        {
            Pause(1);
            this.WaitForElementToBeVisible(receiptFilterClose).Click();
            Pause(1);
        }
        public void ClickButton(string buttonName)
        {
            this.WaitForElementToBeVisible(By.XPath(string.Format("//ul/li[@role='presentation']//a[span[text()='{0}']]", buttonName))).Click();                        
        }

        public void VerifyButtonHighlighted(string buttonName)
        {
            this.WaitForElementToBeVisible(By.XPath(string.Format("//ul/li[@role='presentation']//a[span[text()='{0}']]", buttonName))).GetCssValue("background-color").Should().Contain("rgba(3, 45, 136, 1)");
        }

        public string GetFilterOptionHeader()
        {
            try
            {
                Pause(1);
                return driver.FindElement(bankingActivityPageFilterOptions).Text;
            }
            catch
            {
                return null;
            }

        }
        public void EnterCaseNumber(string caseNumber)
        {
            this.WaitForElementToBeVisible(filterCaseNumberOrDebtorName).SendKeys(caseNumber);
            this.WaitForElementToBeVisible(filterCaseOrDebtorSelection).Displayed.Should().BeTrue();
            this.Pause(2);
            var e = this.WaitForElementToBeVisible(filterCaseOrDebtorSelection);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
            this.Pause(2);

        }

        public void EnterAccountNumber(string accountNumber)
        {
            this.WaitForElementToBeVisible(filterAccountNumber).SendKeys(accountNumber);
          //  this.WaitForElementToBeVisible(BANKING_ACTIVITY_PAGE_FILTEROPTIONS_CaseOrDebtor_Selection).Displayed.Should().BeTrue();
//var e = this.WaitForElementToBeVisible(BANKING_ACTIVITY_PAGE_FILTEROPTIONS_CaseOrDebtor_Selection);
          //  ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);

        }

        public void EnterType(string type) 
        {
            this.ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(bankingPrintingFilterType).SendKeys(type);
            this.WaitForElementToBeVisible(bankingPrintingFilterType).SendKeys(Keys.Down);
            this.WaitForElementToBeVisible(bankingPrintingFilterType).SendKeys(Keys.Enter);
            Thread.Sleep(3000);

        }
        public void EnterAccountNumber(decimal accountNumber)
        {
            this.WaitForElementToBeVisible(bankingActivityAccountNumber).SendKeys(accountNumber.ToString());
        }

        public void SelectIssue(string issue)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='Select Select--multi is-clearable is-searchable']//span[@class='Select-arrow']")).Click();
            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class='Select-menu-outer']//div//div"));
            foreach(IWebElement ele in  list)
                {
                if (ele.Text == issue)
                {
                    Actions moveToviewElement = new Actions(driver);
                    moveToviewElement.MoveToElement(ele).Click().Build().Perform();
                    break;
                    
                }
            }
           
        }

        public void ClickOnClose()
        {
            this.WaitForElementToBeVisible(bankingActivityFilterClose).Click();
        }
        public void EnterOtherBankBalance(string otherValue)
        {
            WaitForElementToBeVisible(By.XPath("//div[label[text()='BANK BALANCE OTHER THAN $ 0.00']]//span[@class='Select-arrow']")).Click();
            By linkedValuesXpath = By.XPath("//div[label[text()='BANK BALANCE OTHER THAN $ 0.00']]//div[contains(@class,'Select-option')]");
            try
            {
                var linkedValues = WaitForElementsToBeVisible(linkedValuesXpath).Where(e => e.Text.Trim().Contains(otherValue)).FirstOrDefault();
                linkedValues.Click();
            }
            catch { }

        }
        public DataTable GetActivityRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(bankingActivityPageHeaderName).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(bankingActivityPageHeaderName).Select(e => e.Text.Trim()).ToList();
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
                    if (i != 0)
                    {
                        htmlTable.Rows[j][i] = testList[j];
                    }
                    else
                    {
                        htmlTable.Rows.Add(testList[j]);
                    }
                }
            }

            return htmlTable;
        }

        public List<string> GetSortedList(string columnName)
        {
            List<string> list = new List<string>();

            var Table = GetActivityRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add(Table.Rows[i][index].ToString());
            }
            return list;
        }

        public DataTable GetReceiptRecords(string sortColumn = null)
        {
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(sortColumn))
                driver.FindElements(bankingActivityPageHeaderName).Where(e => e.Text.Contains(sortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(bankingActivityPageHeaderName).Select(e => e.Text.Trim()).ToList();
            for (int headerloopCounter = 0; headerloopCounter <= headerNames.Count - 2; headerloopCounter++)
            {
                htmlTable.Columns.Add(headerNames[headerloopCounter]);
                var newHeaderName = string.Join(" ", headerNames[headerloopCounter].Split(' ')
                .Select(w => w.Trim())
                .Where(w => w.Length > 0)
                .Select(w => w.Substring(0, 1).ToUpper() + w.Substring(1).ToLower()));

                try
                {

                    this.Pause(2); 
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{newHeaderName}']//span//span[text()]"));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{newHeaderName}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{newHeaderName}']")); }

                var recipientTextList = rows.Select(e => e.Text).ToList();
                for (int loopCounter = 0; loopCounter <= recipientTextList.Count - 1; loopCounter++)
                {
                    if (headerloopCounter != 0)
                    {
                        htmlTable.Rows[loopCounter][headerloopCounter] = recipientTextList[loopCounter];
                    }
                    else
                    {
                        htmlTable.Rows.Add(recipientTextList[loopCounter]);
                    }
                }
            }

            return htmlTable;
        }

        public void ClickOnReferesh()
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(By.XPath("//i[@class ='fa fa-refresh']")).Click();
            Pause(3);
        }

        public string GetPageCount()
        {
            Thread.Sleep(1500);
            return this.WaitForElementToBeVisible(pageCount).Text;
            
        }

        public string GetPageCountAccount()
        {
            Thread.Sleep(1500);
            return this.WaitForElementToBeVisible(pageCountAccounts).Text;
            
        }
        public string GetPageCountReceiptLog()
        {
            Thread.Sleep(1500);
            return this.WaitForElementToBeVisible(pageCountReceipts).Text;
        }

       public string GetPageCountCheckOrPrintLog()
        {
            Thread.Sleep(1500);
            return this.WaitForElementToBeVisible(pageCountChecks).Text;
        }

        public void EnterBalanceFrom(string balanceFrom)
        {
            this.WaitForElementToBeVisible(this.balanceFrom).SendKeys(balanceFrom);
        }

        public void EnterBalanceTo(string balanceTo)
        {
            this.WaitForElementToBeVisible(this.balanceTo).SendKeys(balanceTo);
        }

        public Dictionary<string, object> GetPagination()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Pagination", this.WaitForElementToBeVisible(pagination).Displayed);
            dict.Add("ActivePage", this.WaitForElementToBeVisible(activePage).Text);
            return dict;
        }

        public List<string> GetRecordsByColumnName(string columnName, string value = null)
        {
            IList<IWebElement> rows = null;
            List<string> lists = new List<string>();
            columnName = columnName.ToUpper();
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";
            try
            {
                this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, columnName)), 8);
                rows = driver.FindElements(By.XPath(string.Format(rowXpath, columnName)));
                if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{columnName}']")); }
            }
            catch {
                rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{columnName}']"));
            }
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

        public IssueReconciliation ClickOnResultLinkByColumnName(string columnName,string xpathSuffix)
        {
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";
            IList<IWebElement> rows;
            try
            {
                this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, columnName)), 8);
                rows = driver.FindElements(By.XPath(string.Format(rowXpath, columnName)));
                if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{columnName}']")); }
            }
            catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{columnName}']/a")); }
            MoveToElementAndClick(rows.First());
            return new IssueReconciliation(driver);
        }
        
        public void AddReceipt()
        {
            Thread.Sleep(2000);
            WaitForElementToBeClickeable(addReceiptButton).Click();
        }
        public void EnterDetails1(string number, string name, string date, string address)
        {
            if (!string.IsNullOrEmpty(number))
            {
                WaitForElementToBeVisible(caseNumber).SendKeys(number);
                this.Pause(1);
                WaitForElementToBeClickeable(caseSelect).Click();
            }
            ScrollUpToPageTop();
            ClearAndType(WaitForElementToBeVisible(receivedFrom), name);
            this.Pause(1);
            ClearAndType(WaitForElementToBeVisible(bankReceived), date);
            this.Pause(1);
            ClearAndType(WaitForElementToBeVisible(this.address), address);
        }
        public void EnterDetails2(string amount, string number, string checkDate, string receivedDate)
        {
            ClearAndType(WaitForElementToBeVisible(this.amount), amount);
            this.Pause(1);
            ClearAndType(WaitForElementToBeVisible(checkNum), number);
            this.Pause(1);
            ClearAndType(WaitForElementToBeVisible(logCheckDate), checkDate);
            this.Pause(1);
            ClearAndType(WaitForElementToBeVisible(checkReceived), receivedDate);
        }
        public void TransactionDetails(string description, string notes, string utcCode)
        {
            Pause(2);
            ScrollWindowBy(500,300);
            ClearAndType(WaitForElementToBeVisible(transactionDescription), description);
            ClearAndType(WaitForElementToBeVisible(transactionNotes), notes);
            this.Pause(1);
            ScrollWindowBy(300,180);
            WaitForElementToBeClickeable(utcSection).Click();
            this.Pause(2);
            var Code = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[contains(text(),'{utcCode}')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", Code);
            Pause(2);
            Code.Click();
        }
        public void ReceiptSaveOrClose(string button)
        {
            WaitForElementToBeClickeable(By.XPath($"//button[text()='{button}']"),3).Click();
        }
        public void SelectCase(string debtorName)
        {

            Pause(3);
            IList<IWebElement> debtorData = driver.FindElements(debtorColumn);

            String[] allText = new String[debtorData.Count];
            int i = 0;
            foreach (IWebElement element in debtorData)
            {
                allText[i++] = element.Text;
                var ActualList = element.Text;
                if (ActualList == debtorName)
                {
                    WaitForElementToBeClickeable(receiptCheckbox).Click();
                }
                break;
            }
        }
        public void ClickDeposit()
        {
           this.Pause(3);
           this.WaitForElementToBeClickeable(receiptDepositLink).Click();
        }
   
        public void ClickLinkAsset()
        {
            this.Pause(3);
            ScrollWindowBy(500,300);
            WaitForElementToBeClickeable(linkAsset,3).Click();

        }
        public void ClickAssetLink()
        {
            ScrollWindowBy(500, 300);
            WaitForElementToBeClickeable(assetlink, 3).Click();
        }

        public void ClickClosingCostLink()
        {
            ScrollWindowBy(500, 300);
            WaitForElementToBeClickeable(closingCostlink, 3).Click();
        }

        public void ClickUnlinkedAllocations()
        {
            ScrollWindowBy(500, 300);
            WaitForElementToBeClickeable(unlinkedallocations, 3).Click();
        }
        public void ClickClaimLinks()
        {
            ScrollWindowBy(500, 300);
            WaitForElementToBeClickeable(claimlinks, 3).Click();
        }
        public void LinkAsset(string asset)
        {
            WaitForElementToBeClickeable(depositLinkAsset, 4).Click();                
        }
        public void ClickCancel()
        {
            WaitForElementToBeClickeable(By.XPath("//button[text()='CANCEL']"),3).Click();
        }
        public List<string> GetRecordsByColumnNames(string ColumnName, string value = null)
        {

            var finished = false;
            List<string> lists = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    Pause(3);

                    IList<IWebElement> rows = null;

                    ColumnName = ColumnName.ToString();
                    string rowXpath = "//tr//td[@data-title='{0}']//span[text()] | //tr//td[@data-title='{0}']//button[text()] | //tr//td[@data-title='{0}']//div[text()]";
                    try
                    {
                        this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, ColumnName)), 16);
                        rows = driver.FindElements(By.XPath(string.Format(rowXpath, ColumnName)));
                        if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']")); }
                    }
                    catch (Exception e) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']")); }
                    lists = rows.Select(e => e.Text.Trim()).ToList();
                    finished = true;
                    // To verify the value exist in the respective column 
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        bool found = false;
                        foreach (string list in lists)
                        {
                            found = list.Contains(value);
                            break;
                        }
                        found.Should().BeTrue();
                    }

                    break;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            return lists;

        }


     
        public void ClickOnAccountNumberDisabled() {
            var aacountnum = driver.FindElement(accountNumberDisabled);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", aacountnum);
        }
        public string ValidateHeaderText() { Thread.Sleep(2000); return this.WaitForElementToBeVisible(accountSummaryHeader).Text; }

        public string ValidateSubHeaderText() { Thread.Sleep(2000); return this.WaitForElementToBeVisible(transcationHeader).Text; }

        public void ValidateCheckButton() {
                        Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(checkButton)).ClickAndHold().Perform();
            this.PressEscapeKey();
                    }

        public string ValidatereceiptHeaderText()
        { Thread.Sleep(2000);
            return this.WaitForElementToBeVisible(viewReceiptHeader).Text;
        }
        public void ClickOnViewButton()
        {
            Thread.Sleep(2000);
            var view = driver.FindElement(viewButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", view);
        }

        public void PerformClickonAllBuutons()
        {
            Actions action = new Actions(driver);
           action.MoveToElement(driver.FindElement(voidButton)).ClickAndHold().Perform();
            this.PressEscapeKey();
            action.MoveToElement(driver.FindElement(addReceiptButton)).ClickAndHold().Perform();
            this.PressEscapeKey();
            action.MoveToElement(driver.FindElement(verifyButton)).ClickAndHold().Perform();
            this.PressEscapeKey();
            action.MoveToElement(driver.FindElement(depositButton)).ClickAndHold().Perform();
            this.PressEscapeKey();

        }

        public string ValidateErrorText() { Thread.Sleep(2000); return this.WaitForElementToBeVisible(errorDisplay).Text; }
        public void PerformClickonPrint()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(printButton)).ClickAndHold().Perform();
            this.PressEscapeKey();
        }
        public void ClickOnBankAccountLink()
        {
            IList<IWebElement> BankAccountsLinkList = this.WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-page-body']//td[6]//a")).ToList();
            BankAccountsLinkList[0].Click();
        }
        private bool GetElementExists(By loc)
        {
            try
            {
                this.WaitForElementToBeVisible(loc, 5);
                return true;
            }
            catch { return false; }
        }
        public bool ValidateInlineEditing()
        {
            if (GetElementExists(bankingAccountsCleared))
            { return true; }
            else { return false; }
        }
        
        public void EditCleared()
        {
            IList<IWebElement> ClearedlinkList = this.WaitForElementsToBeVisible(bankingAccountsCleared).ToList();
            ClearedlinkList[0].Click();
            SelectAndDeleteCompleteText(driver.FindElement(bankingAccountsClearedInLineInput));
            string date = DateTime.Today.ToString("MM/dd/yy");
            this.WaitForElementToBeVisible(bankingAccountsClearedInLineInput).SendKeys(date);
            this.WaitForElementToBeVisible(By.XPath("//h3[@class='popover-title']")).Click();
            this.WaitForElementToBeVisible(bankingAccountsInLineSubmit).Click();
            Pause(1);
        }
        public void ClearInlineClearedDate()
        {
            IList<IWebElement> ClearedlinkList = this.WaitForElementsToBeVisible(bankingAccountsCleared).ToList();
            ClearedlinkList[0].Click();
            SelectAndDeleteCompleteText(driver.FindElement(bankingAccountsClearedInLineInput));
            this.WaitForElementToBeVisible(bankingAccountsClearedInLineInput).Clear();
            this.WaitForElementToBeVisible(By.XPath("//h3[@class='popover-title']")).Click();
            this.WaitForElementToBeVisible(bankingAccountsInLineSubmit).Click();
            Pause(5);
        }
        public void ClickOnCase()
        {
            IList<IWebElement> CaseList = this.WaitForElementsToBeVisible(bankingAccountsCaseListLocator).ToList();
            CaseList[1].Click();
        }
        public void ClickOnAccountNumber()
        {
            bankName = GetBankName_From_BankAccountsGrid();
            accountName = GetAccountName_From_BankAccountsGrid();
            IList<IWebElement> ACList = this.WaitForElementsToBeVisible(accountNumberList).ToList();
            accountNumber = ACList[0].Text;
            ACList[0].Click();
        }
        public string GetBankName_From_BankAccountsGrid()
        {
            List<string> lists = new List<string>();
            IList<IWebElement> Name_List= this.WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//td[@data-title='BANK NAME']")).ToList();
            for (int i = 0; i < Name_List.Count(); i++)
            {
                lists.Add(Name_List[i].Text);
            }
            return lists[0];
        }
        public string GetAccountName_From_BankAccountsGrid()
        {
            List<string> lists = new List<string>();
            IList<IWebElement> Name_List = this.WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//td[@data-title='ACCOUNT NAME']")).ToList();
            for (int i = 0; i < Name_List.Count(); i++)
            {
                lists.Add(Name_List[i].Text);
            }
            return lists[0];
        }
        public void ValidateBankNameOnHeader()
        {
            Pause(1);
            this.WaitForElementToBeVisible(By.XPath("//span[@class='bank-account-ledger-header']//span[1]")).Text.Should().Be(bankName +" /");
        }
        public void ValidateAccountNameOnHeader()
        {
            Pause(1);
            this.WaitForElementToBeVisible(By.XPath("//span[@class='bank-account-ledger-header']//span[3]")).Text.Should().Be("/ "+accountName);
        }
        public void ValidateAccountNumberOnHeader()
        {
            this.WaitForElementToBeVisible(By.XPath("//span[@class='bank-account-ledger-header']//span[2]")).Text.Should().Be(accountNumber);
        }
        public void ValidateAccountSummaryHeader()
        {
            this.WaitForElementToBeVisible(accountSummaryHeader).Text.Should().Contain("Account Summary");
        }
        public void ValidateTransactionsHeader()
        {
            this.WaitForElementToBeVisible(transcationHeader).Text.Should().Contain("Transactions");
        }
        public bool ValidateCheckBuuton_In_Transactions()
        {
            return this.WaitForElementToBeVisible(checkButton).Displayed;
        }
        public bool IsPartialAccount_No()
        {
            Thread.Sleep(1500);
            Regex reg = new Regex("X{3}[-]?X{2}[-]?[0-9]{4}");
            IList<IWebElement> ACList = this.WaitForElementsToBeVisible(accountNumberList).ToList();
            accountNumber = ACList[0].Text;
            return reg.IsMatch(accountNumber);

        }
        public bool IsHiddenSSN_No()
        {
            string reg = "XXX-XX-XXXX ";
            IList<IWebElement> ACList = this.WaitForElementsToBeVisible(accountNumberList).ToList();
            accountNumber = ACList[0].Text;
            return reg.Equals(accountNumber);
        }
        public void NonClaimClosingCost()
        {
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(By.XPath("//button[contains(text(),' CLOSING COST (NON-CLAIM)')]"),2).Click();
        }
        public void EditReceivedFrom(string receivedFrom)
        {
            this.Pause(3);
            IList<IWebElement> rows = driver.FindElements(caseTableRowsLocator);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement Name = driver.FindElement(By.XPath("//tr[contains(@class,'')][" + row + "]//td[6]"));
                string Received = Name.Text;
                Console.WriteLine(Received);
                if (Received == receivedFrom)
                {
                    var edit = WaitForElementToBeClickeable(By.XPath("//tr[" + row + "]/td[12]/a/i"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public string GetUnlinkedTypeValue()
        {
            return WaitForElementToBeVisible(filterUnlinkedTypeValue).Text;
        }
        public string GetHasBankTransactionsValue()
        {
            return WaitForElementToBeVisible(filterHasBankTransactionsValue).Text;
        }
        public string GetCaseStatusValue()
        {
            return WaitForElementToBeVisible(filterCaseStatusValue).Text;
        }
        public void ReceiptFilterLinkned_SelectValue(string linkedInput)
        { 
            WaitForElementToBeVisible(receiptFilterLinkedArrow).Click();
           By linkedValuesXpath = By.XPath("//div[label[text()='LINKED']]//div[contains(@class,'Select-option')]");
            try
            {
                var linkedValues = WaitForElementsToBeVisible(linkedValuesXpath).Where(e => e.Text.Trim().Contains(linkedInput)).FirstOrDefault();
                linkedValues.Click();
            }
            catch { }
       
        }
        public void ClickOnReceiptFilterReset()
        {
            Pause(1);
             WaitForElementToBeVisible(receiptFilterReset).Click();
        }
        public void ClickAccountNumber(string accountno)
        {
            WaitForElementToBeVisible(By.XPath($"//tr//td[@data-title='ACCOUNT #']/a[text()='{accountno}']")).Click();
        }
       public void ClickViewTransaction()
        {

            this.Pause(4);
            var view = driver.FindElement(viewtransaction);
            var check = driver.FindElement(checktype).Text;
            Assert.AreEqual(true, view.Enabled);
            Assert.AreEqual(check, "Check");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", view);
        }
        public void VerifyViewCheckHeader()
        {
            this.Pause(3);
            var Viewcheckheader = driver.FindElement(header).Text;
            Assert.AreEqual(Viewcheckheader, "View Check");
        }
        public void VerifyCheckDetails(string bankname, string accountnum, string serialno, string clrdate)
        {
            var bank = WaitForElementToBeVisible(checkbank).Text;
            Assert.IsTrue(bankname.Equals(bank, StringComparison.OrdinalIgnoreCase));

            var accountnumber = WaitForElementToBeVisible(checkaccountnumber).Text;
            Assert.IsTrue(accountnum.Equals(accountnumber, StringComparison.OrdinalIgnoreCase));

            var serialnum = WaitForElementToBeVisible(checkserialnum).Text;
            Assert.IsTrue(serialno.Equals(serialnum, StringComparison.OrdinalIgnoreCase));

           // var transactiondate = WaitForElementToBeVisible(Checktransactiondate).Text;
           // Assert.IsTrue(trandate.Equals(transactiondate, StringComparison.OrdinalIgnoreCase));

            var cleardate = WaitForElementToBeVisible(checkcleardate).Text;
            Assert.IsTrue(clrdate.Equals(cleardate, StringComparison.OrdinalIgnoreCase));

        }
        public void VerifyPayToDetails(string name, string desc, string remark)
        {
            var payeename = WaitForElementToBeVisible(payee).Text;
            Assert.IsTrue(name.Equals(payeename, StringComparison.OrdinalIgnoreCase));

            var description = WaitForElementToBeVisible(payeedesc).Text;
            Assert.IsTrue(desc.Equals(description, StringComparison.OrdinalIgnoreCase));

            var payremark = WaitForElementToBeVisible(payeeremark).Text;
            Assert.IsTrue(remark.Equals(payremark, StringComparison.OrdinalIgnoreCase));

        }
      public void VerifyAmounts(string amt, string allocations, string disttype)
        {
            var amount = WaitForElementToBeVisible(checkamouunt).Text;
            Assert.IsTrue(amt.Equals(amount, StringComparison.OrdinalIgnoreCase));

            var sumallocations = WaitForElementToBeVisible(checkallocations).Text;
            Assert.IsTrue(allocations.Equals(sumallocations, StringComparison.OrdinalIgnoreCase));

            var distributiontype = WaitForElementToBeVisible(checkdistributiontype).Text;
            Assert.IsTrue(disttype.Equals(distributiontype, StringComparison.OrdinalIgnoreCase));
        }
        public bool Breadcrumb()
        {
            return this.WaitForElementToBeVisible(viewcheckbreadcrumb).Displayed;
        }
        public void VerifyClaimLinks(string name, string amt, string utc)
        {

            var cname = WaitForElementToBeVisible(claimantname).Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0]", cname);
            Assert.IsTrue(name.Equals(cname, StringComparison.OrdinalIgnoreCase));

            var amount = WaitForElementToBeVisible(claimamount).Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0]", amount);
            Assert.IsTrue(amt.Equals(amount, StringComparison.OrdinalIgnoreCase));

            var claimutc = WaitForElementToBeVisible(claimlinkutc).Text;
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0]", claimutc);
            Assert.IsTrue(utc.Equals(claimutc, StringComparison.OrdinalIgnoreCase));

        }
        public void Close()
        {
            WaitForElementToBeVisible(checkviewclose).Click();
        }
       public void ClickAccountManagementInBreadcrumb()
        {
            WaitForElementToBeVisible(accountmanagementlink).Click();
        }
        public void ClickOnAccountnumber(string acct)
        {
            
            IList<IWebElement> rows = driver.FindElements(bankaccountsrows);
            int Accountows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= Accountows; row++)
            {
                IWebElement participantName = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[3]"));
                string ParticipantList = participantName.Text;
                if (ParticipantList == acct)
                {
                    var accountnumber = WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + row + "]/td[6]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", accountnumber);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);

        }
        public void ClickEditTransaction(string name)
        {
            this.Pause(4);
            IList<IWebElement> rows = driver.FindElements(bankaccountsrows);
            int Accountows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= Accountows; row++)
            {
                IWebElement participantName = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[6]"));
                string ParticipantList = participantName.Text;
                if (ParticipantList == name)
                {
                    var editicon = WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + row + "]/td[15]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", editicon);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void VerifyWriteCheckHeader()
        {
            this.Pause(3);
            var Writecheck = driver.FindElement(writecheckheader).Text;
            Assert.AreEqual(Writecheck, "Edit Check");
        }
        public bool WriteCheckBreadcrumb()
        {
            return this.WaitForElementToBeVisible(writecheckbreadcrumb).Displayed;
        }
        public void WriteCheckReadOnlyFields(string bank, string acct, string serial, string payeename, string addr1, string addr2, string amt, string allocation)
        {
            var payeebank = WaitForElementToBeVisible(checkbank).Text;
            Assert.IsTrue(bank.Equals(payeebank, StringComparison.OrdinalIgnoreCase));

            var accountnumber = WaitForElementToBeVisible(checkaccount).Text;
            Assert.IsTrue(acct.Equals(accountnumber, StringComparison.OrdinalIgnoreCase));

            var serialnum = WaitForElementToBeVisible(checkserialnum).Text;
            Assert.IsTrue(serial.Equals(serialnum, StringComparison.OrdinalIgnoreCase));

           // var transactiondate = WaitForElementToBeVisible(Checktransactiondate).Text;
           // Assert.IsTrue(transdate.Equals(transactiondate, StringComparison.OrdinalIgnoreCase));

            var name = WaitForElementToBeVisible(writecheckpayeename).Text;
            Assert.IsTrue(payeename.Equals(name, StringComparison.OrdinalIgnoreCase));
            ScrollDownToPageBottom();
            var amount = WaitForElementToBeVisible(checkclaimamount).GetAttribute("value");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0]", amount);
            Assert.IsTrue(amt.Equals(amount, StringComparison.OrdinalIgnoreCase));

            var sumallocations = WaitForElementToBeVisible(checkallocations).Text;
            Assert.IsTrue(allocation.Equals(sumallocations, StringComparison.OrdinalIgnoreCase));

            var payeeaddr1 = WaitForElementToBeVisible(payeeaddr).Text;
            Assert.IsTrue(payeeaddr1.Contains(addr1));

            var payeeaddr2 = WaitForElementToBeVisible(payeeaddr).Text;
            Assert.IsTrue(payeeaddr2.Contains(addr2));

        }
        public void WriteCheckEditFields(string Checkcleardate, string desc, string remark, string disttype)
        {
           
            ClearAndType(WaitForElementToBeVisible(cleardate), Checkcleardate);
            ClearAndType(WaitForElementToBeVisible(description), desc);
            ClearAndType(WaitForElementToBeVisible(checkremark), remark);
            ScrollDownToPageBottom();
            WaitForElementToBeVisible(distributiontype).Click();
            var dtype = WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{disttype}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", dtype);
            this.Pause(1);
            dtype.Click();
            
        }
        public void WireDebitFields(string desc, string remark)
        {
            ClearAndType(WaitForElementToBeVisible(description), desc);
            ClearAndType(WaitForElementToBeVisible(checkremark), remark);
            ScrollDownToPageBottom();
        }
        public void AddClaimLinks()
        {
            WaitForElementToBeVisible(linkclaimbutton).Click();
            this.Pause(3);
            WaitForElementToBeVisible(selectclaim).Click();
            WaitForElementToBeVisible(addclaim).Click();
        }
        public void EditClaimLinks(string name, string desc, string utc, string amt)
        {
            ScrollDownToPageBottom();
            WaitForElementToBeVisible(cname).Click();
            ClearAndType(WaitForElementToBeVisible(claim), name);
            WaitForElementToBeVisible(cdesc).Click();
            this.WaitForElementToBeVisible(claim).SendKeys(desc);
            WaitForElementToBeVisible(lamount).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(linkedamount).SendKeys(amt);
            WaitForElementToBeVisible(lamount).Click();
        }
        public void DeleteClaimLink()
        {
            this.Pause(3);
            WaitForElementToBeVisible(deleteclaimlink).Click();
            ScrollDownToPageBottom();

        }
        public void AddUnlinkedAllocations(string name, string utc, string amt)
        {
            ScrollDownToPageBottom();
            WaitForElementToBeVisible(unlinkedallocations).Click();
            this.Pause(3);
            WaitForElementToBeVisible(unlinkedallocationutc).Click();
            WaitForElementToBeVisible(pname).SendKeys(name);
            WaitForElementToBeVisible(unlinkedallocationutcname).Click();
            var Unlinkedutc = WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{utc}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", Unlinkedutc);
            this.Pause(1);
            Unlinkedutc.Click();
            WaitForElementToBeVisible(unlinkedamount).SendKeys(amt);
            WaitForElementToBeVisible(addclaim).Click();
        }
        public void EditUnlinkedAllocations(string name, string desc, string utc, string amt)
        {
            ScrollDownToPageBottom();
            WaitForElementToBeVisible(editname).Click();
            ClearAndType(WaitForElementToBeVisible(claim), name);
            WaitForElementToBeVisible(editdesc).Click();
            this.WaitForElementToBeVisible(claim).SendKeys(desc);
            WaitForElementToBeVisible(editamount).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(linkedamount).SendKeys(amt);
            WaitForElementToBeVisible(editamount).Click();
        }
        public void DeleteUnlinkedAllocations()
        {
            this.Pause(3);
            WaitForElementToBeVisible(deletelink).Click();
            ScrollDownToPageBottom();
        }
        public void SumOfAllocations()
        {
                IList<IWebElement> amount = driver.FindElements(By.XPath("(//div[label[text()='LINKED AMOUNT']]/div/div/button)"));
                decimal sumofamt = 0;
                string[] linkedamt = new string[amount.Count];
                int i = 0;
                string expectedamt=null;
                foreach (IWebElement element in amount)
                {
                   linkedamt[i++] = element.Text;
                   string sumof = element.Text;
                   string allocations = sumof.Replace("$", string.Empty);
                   sumofamt = sumofamt +(Convert.ToDecimal(allocations));
                   expectedamt = Convert.ToString(sumofamt);
                 }
                var actualamount = driver.FindElement(By.XPath("(//div[label[text()='SUM OF ALLOCATIONS']])/div")).Text;
               Assert.IsTrue(actualamount.Contains(expectedamt));
        }
        public void SaveOnWriteCheckPage()
        {
            WaitForElementToBeVisible(savewritecheck).Click();
        }
        public void CancelOnWriteCheckPage()
        {
            WaitForElementToBeVisible(cancelwritecheck).Click();
        }
        public void CheckAccountNumber(string acctno)
        {
            this.Pause(3);
            var accountnumber = WaitForElementToBeVisible(checkaccount).Text;
            Assert.IsTrue(acctno.Equals(accountnumber, StringComparison.OrdinalIgnoreCase));


        }
        public void VerifyReceiptLog()
        {
            var receiptType = "Receipt Log";
            this.Pause(2);
            WaitForElementToBePresent(By.XPath("//div[label[text()='UNLINKED TYPE']]//span/div[1]"), 2).Click();
            this.Pause(1);
            IList<IWebElement> unlinkedType= driver.FindElements(By.XPath("//div[label[text()='UNLINKED TYPE']]/div/div[2]/div/div"));
            
            bool isFound = false;
            foreach (var unlinkType in unlinkedType)
            {
                if (unlinkType.Text != receiptType)
                {
                   Assert.AreNotEqual(unlinkType.Text, receiptType);
                    isFound = true;
                }
                Assert.IsTrue(isFound);
            }
        }
        public string actual;
        #region Methods for Void Transaction
        public void VerifyPopUpHeader(string expectedHeader)
        {
            actual = WaitForElementToBePresent(popUpHeader).Text;
            Assert.IsTrue(actual.Contains(expectedHeader));
        }
        public void VerifyPopUpBody(string expectedBody)
        {
            actual = WaitForElementToBePresent(popUpBody).Text;
            Assert.IsTrue(actual.Contains(expectedBody));
        }
        public void ClickOnOkButton()
        {
            this.Pause(2);
            var ok = driver.FindElement(popUpOk);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", ok);
        }
        public void InputClearedText(string input)
        {
            Thread.Sleep(2000);
            WaitForElementToBeClickeable(clearedDateInput).SendKeys(input);
            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class='Select-menu-outer']"));
            foreach (IWebElement ele in list)
            {
                if (ele.Text == input)
                {
                    Actions moveToviewElement = new Actions(driver);
                    moveToviewElement.MoveToElement(ele).Click().Build().Perform();
                    break;

                }
            }
        }
        public void ClickOnVoidButton()
        {
            this.Pause(2);
            var voidButton = driver.FindElement(voidIcon);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", voidButton);
        }
        public void ClickCheckBoxed()
        {
            this.Pause(3);
            var checkBox = driver.FindElement(checkBoxs);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkBox);
        }
        public void SelectFirstRecord()
        {
            this.WaitForElementToBeVisible(selectFirstOption).Click();
        }
        public void InputRemarks()
        {
            var notes = new Faker().Random.Word();
            this.WaitForElementToBeClickeable(remarks).SendKeys(notes);
        }
        public void VoidTransactions()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(transactionColor)).Perform();
            this.PressEscapeKey();
        }
        public void SelectStopPayement(string input)
        {
            Thread.Sleep(2000);
            WaitForElementToBeClickeable(stopPaymentField).SendKeys(input);
            IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class='Select-menu-outer']"));
            foreach (IWebElement ele in list)
            {
                if (ele.Text == input)
                {
                    Actions moveToviewElement = new Actions(driver);
                    moveToviewElement.MoveToElement(ele).Click().Build().Perform();
                    break;

                }
            }
        }
        public void SelectPaymentOptions(string input)
        {
            this.Pause(2);
            this.WaitForElementToBeClickeable(By.XPath("(//button/i[@class='fa fa-ellipsis-v'])[1]"), 3).Click();
            this.Pause(2);
            var stop = driver.FindElement(By.XPath($"//span[text()='{input}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", stop);
            this.Pause(4);
        }
        #endregion

        public void ClickOnFilter(string date, string payment, string imbalance)
        {
            this.Pause(3);
            IWebElement clearedDate = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[1]"));
            string clearedDateValue = clearedDate.Text;
            Assert.AreEqual(clearedDateValue, date);
            IWebElement stopPayment = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[2]"));
            string stopPaymentValue = stopPayment.Text;
            Assert.AreEqual(stopPaymentValue, payment);
            IWebElement permitAssetImbalance = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[2]"));
            string permitAssetImbalancetValue = stopPayment.Text;
            Assert.AreEqual(permitAssetImbalancetValue, imbalance);
            this.WaitForElementToBeClickeable(filterClose).Click();
        }
        public void VerifyDataInFilterOptionsInAccountManagementPage()
        {
            //Verifying data in Filter options Cleared Date
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterAccountManagement).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterClearedDate).Click();
            string[] UIClearedDateValues = { "", "All", "Yes", "No" };
            IList<IWebElement> ClearedDateRows = driver.FindElements(filterClearedDateValues);
            int ClearedDateCount = ClearedDateRows.Count;
            for (int ClearedDateRow = 1; ClearedDateRow <= ClearedDateCount; ClearedDateRow++)
            {
                this.Pause(3);
                IWebElement ClearedDateValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + ClearedDateRow + "]"));
                string ClearedDateData = ClearedDateValues.Text;
                string UIClearedDateData = UIClearedDateValues[ClearedDateRow];
                Assert.IsTrue(UIClearedDateData.Equals(ClearedDateData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeClickeable(filterClose).Click();
            //Verifying data in Filter options Stop Payment
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterAccountManagement).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterStopPayment).Click();
            string[] UIStopPaymentValues = { "", "All", "Stop Payments Pending"};
            IList<IWebElement> StopPaymentRows = driver.FindElements(filterStopPaymentValues);
            int StopPaymentCount = StopPaymentRows.Count;
            for (int StopPaymentRow = 1; StopPaymentRow <= StopPaymentCount; StopPaymentRow++)
            {
                this.Pause(3);
                IWebElement StopPaymentValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + StopPaymentRow + "]"));
                string StopPaymentData = StopPaymentValues.Text;
                string UIStopPaymentData = UIStopPaymentValues[StopPaymentRow];
                Assert.IsTrue(UIStopPaymentData.Equals(StopPaymentData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeClickeable(filterClose).Click();
            //Verifying data in Filter options Permit Asset Imbalance
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterAccountManagement).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterPermitAssetImbalance).Click();
            string[] UIPermitAssetImbalanceValues = { "", "All", "Yes", "No" };
            IList<IWebElement> PermitAssetImbalanceRows = driver.FindElements(filterPermitAssetImbalanceValues);
            int PermitAssetImbalanceCount = PermitAssetImbalanceRows.Count;
            for (int PermitAssetImbalanceRow = 1; PermitAssetImbalanceRow <= PermitAssetImbalanceCount; PermitAssetImbalanceRow++)
            {
                this.Pause(3);
                IWebElement PermitAssetImbalanceValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + PermitAssetImbalanceRow + "]"));
                string PermitAssetImbalanceData = PermitAssetImbalanceValues.Text;
                string UIPermitAssetImbalanceData = UIPermitAssetImbalanceValues[PermitAssetImbalanceRow];
                Assert.IsTrue(UIPermitAssetImbalanceData.Equals(PermitAssetImbalanceData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeVisible(filterPermitAssetImbalance).Click();
           
        }
        public void SelectFilterOptionsInAccountManagementPage(string date, string payment, string imbalance)
        {
            this.WaitForElementToBeVisible(filterClearedDate).Click();
            var SelectClearedDate = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{date}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectClearedDate);
            this.Pause(1);
            SelectClearedDate.Click();
            this.WaitForElementToBeVisible(filterStopPayment).Click();
            var SelectStopPayment = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{payment}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectStopPayment);
            this.Pause(1);
            SelectStopPayment.Click();
            this.WaitForElementToBeVisible(filterPermitAssetImbalance).Click();
            var SelectPermitAssetImbalance = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{imbalance}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectPermitAssetImbalance);
            this.Pause(1);
            SelectPermitAssetImbalance.Click();
            //After selecting data in filter, check the result grid has rows
            this.Pause(4);
            IList<IWebElement> rows = driver.FindElements(bankaccountsrows);
            int Accountows = rows.Count;
            Assert.Greater(Accountows,0);

        }
        public void VerifyMessageWhenThereAreNoResultsToDisplay(string msg)
        {
            IWebElement NoResultsMessage = driver.FindElement(By.XPath($"//div[text()='{msg}']"));
            string UIMessage = NoResultsMessage.Text;
            Assert.AreEqual(UIMessage, "No Account Transactions Matching Current View");
        }
        public void ClickResetInFilter()
        {
            this.WaitForElementToBeClickeable(filterReset).Click();
            this.WaitForElementToBeClickeable(filterClose).Click();
        }

        public void EnterReceivedFrom()
        {
            var receivedName = new Bogus.DataSets.Name().Random.Word();
            this.Pause(2);
            this.WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='NAME']/following-sibling::input[@type='text']")).SendKeys(receivedName);
        }
        public void ValidateTheAmountCount()
        {
            Random random = new Random();
             netAmounts = random.Next(100, 9999);
            grossAmounts = random.Next(10000,50000);
            SelectAndDeleteCompleteText(By.XPath("//div[@class='row']//div//label[text()='NET AMOUNT']/following-sibling::span/input[@type='text']"));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='NET AMOUNT']/following-sibling::span/input[@type='text']")), netAmounts.ToString());
            SelectAndDeleteCompleteText(By.XPath("//div[@class='row']//div//label[text()='GROSS AMOUNT']/following-sibling::span/input[@type='text']"));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='GROSS AMOUNT']/following-sibling::span/input[@type='text']")), grossAmounts.ToString());
        }

        public void VerifyLinkAmountMismatchMessage()
        {
            this.ScrollDownToPageBottom();
            this.Pause(3);
            var finalNetAmount = this.WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='NET AMOUNT']/following-sibling::span/input[@type='text']")).GetAttribute("value");
            var finalGrossAmount = this.WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='GROSS AMOUNT']/following-sibling::span/input[@type='text']")).GetAttribute("value");
            var closingAmount = this.WaitForElementToBeVisible(By.XPath("//div[@name='sumOfClaimsClosingCostDisplay']")).GetAttribute("value");
            int minus = Int32.Parse(finalGrossAmount) - Int32.Parse(finalNetAmount);
            var errorText = this.WaitForElementToBeVisible(By.XPath("//div[@class='text-danger epiq-form-validation-summary']//li")).Text;
            var expText = "Sum of Closing Cost must equal Gross Amount minus Net Amount. Gross Amount: $"+ finalGrossAmount + "  minus Net Amount: $"+ finalNetAmount + " is: $"+ minus.ToString()+ " , which does not match the Sum of Closing Cost: "+closingAmount+"";
            Assert.IsTrue(expText.Equals(errorText, StringComparison.OrdinalIgnoreCase));
        }
        public void EnterAllFields()
        {
            this.WaitForElementToBeClickeable(AddClosingCostPayeeName).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(AddClosingCostDescription).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(AddClosingCostLinkedAmount).Text.Should().BeNullOrWhiteSpace();
            this.WaitForElementToBeClickeable(AddClosingCostAddress).Text.Should().BeNullOrWhiteSpace();
            ScenarioContext.Current.Add("ClosingCostFullName", FakeData.FullName());
            ScenarioContext.Current.Add("ClosingCostDescription", FakeData.Description());

            this.WaitForElementToBeClickeable(AddClosingCostPayeeName).SendKeys(ScenarioContext.Current.Get<string>("ClosingCostFullName"));
            this.WaitForElementToBeClickeable(AddClosingCostDescription).SendKeys(ScenarioContext.Current.Get<string>("ClosingCostDescription"));
            this.WaitForElementToBeClickeable(AddClosingCostLinkedAmount).SendKeys(FakeData.RandomNumber(2).ToString());
            this.WaitForElementToBeClickeable(AddClosingCostAddress).SendKeys(FakeData.RandomAddress());
            this.WaitForElementToBeClickeable(AddClosingCostUTCCode).SendKeys("2100");
            this.WaitForElementToBeClickeable(AddClosingCostUTCCode).SendKeys(Keys.ArrowDown);
            this.WaitForElementToBeClickeable(AddClosingCostUTCCode).SendKeys(Keys.Enter);
        }
        public void ClickOnButtonAdd()
        {
            this.WaitForElementToBeClickeable(addButton).Click();
        }
        public void ClickOnButtonClosingCostNon_Claim()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBeClickeable(closingCostNonClaimButton).Click();         
        }
        public void ClickOnButtonCancel()
        {
            this.WaitForElementToBeClickeable(cancelButton).Click();
        }
        public void ClickOnButtonSave()
        {
            var saveButton1 = this.WaitForElementToBeClickeable(saveButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", saveButton1);
        }
        public void ClaimNameInClosingCosts(string name)
        {
            this.Pause(5);
            IWebElement claimName = driver.FindElement(By.XPath("//div[@class='epiq-lookup-picker-card-content']/div[1]"));
            string closingCostClaimName = claimName.Text;
            Assert.AreEqual(closingCostClaimName, name);

        }
        public void MessageInClosingCostsClaim(string msg)
        {
            this.Pause(3);
            IWebElement message = driver.FindElement(By.XPath("//div[@class='row']/div/span"));
            string messageText = message.Text;
            Assert.AreEqual(messageText, msg);
        }
        public void EnterNetAmountAndGrossAmount(string netAmt, string grossAmt)
        {
            
            ScrollDown();
            IWebElement netAmount = driver.FindElement(By.XPath("//div[label[text()='NET AMOUNT']]/span/input"));
            netAmount.Click();
            netAmount.SendKeys(Keys.Control + "a");
            netAmount.SendKeys(Keys.Delete);
            this.Pause(3);
            netAmount.Click();
            netAmount.SendKeys(netAmt);
            IWebElement grossAmount = driver.FindElement(By.XPath("//div[label[text()='GROSS AMOUNT']]/span/input"));
            grossAmount.Click();
            grossAmount.SendKeys(Keys.Control + "a");
            grossAmount.SendKeys(Keys.Delete);
            this.Pause(3);
            grossAmount.Click();
            grossAmount.SendKeys(grossAmt);         

        }
        public void EnterAccountNumberInFilter(string accountNumber)
        {
            this.WaitForElementToBeClickeable(accountNumberFilter).SendKeys(accountNumber);
        }
        public void ClickAddTransactionButton()
        {
            this.Pause(3);
            var transactionButton = this.WaitForElementToBeClickeable(addTransactionButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", transactionButton);
        }
        public void VerifyHeaderInAddTransaction(string header)
        {
            IWebElement transactionHeader = driver.FindElement(By.XPath($"(//div[@class='modal-header']/h4[text()='{header}'])[2]"));
            string addTransactionHeader = transactionHeader.Text;
            Assert.AreEqual(addTransactionHeader, header);
        }
        public void ClickOnButton(string button)
        {
            Thread.Sleep(2000);
            var onbutton = driver.FindElement(By.XPath($"(//div[@class='add-transaction-modal-text col-xs-12']//button[text()='{button}'])[2] | //button[text()='{button}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", onbutton);
            Thread.Sleep(4000);
        }
        public void VerifyAndSubHeadersInAddTransaction(string receipt, string disbursement)
        {
            IWebElement receiptHeader = driver.FindElement(By.XPath("(//span[text()='RECEIPT TRANSACTIONS'])[2]"));
            string receiptTransactionHeader = receiptHeader.Text;
            Assert.AreEqual(receiptTransactionHeader, receipt);
            IWebElement disbursementHeader = driver.FindElement(By.XPath("(//span[text()='DISBURSEMENT TRANSACTIONS'])[2]"));
            string disbursementTransactionHeader = disbursementHeader.Text;
            Assert.AreEqual(disbursementTransactionHeader, disbursement);
        }
        public void VerifyInBreadcrumb(string header)
        {
            this.Pause(4);
            IWebElement depositHeader = driver.FindElement(By.XPath($"//span[text()='{header}']"));
            string addDepositHeader = depositHeader.Text;
            Assert.AreEqual(addDepositHeader, header);
        }
        public void ClickOnCancelButton()
        {
            WaitForElementToBeClickeable(cancelButtonInPage).Click();
        }
        public void VerifyInBreadcrumbed(string breadCrumb)
        {
            IWebElement breadCrumbHeader = driver.FindElement(By.XPath("//div[@class='epiq-page-header  has-case-content']//ol"));
            string breadcrumbHeader = breadCrumbHeader.Text;
            Assert.AreEqual(breadcrumbHeader, header);
        }
        public void SelectTransactionInReceiptLogPage(string receivedFrom)
        {

            this.Pause(2);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                this.Pause(2);
                IWebElement receivedName = driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[6]/div"));

                string received = receivedName.Text;

                if (received == receivedFrom)
                {
                    this.Pause(2);
                    ScrollUpToPageTop();
                    var SelectReceived = driver.FindElement(By.XPath($"//tbody/tr[" + row + "]/td[2]/div/label"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectReceived);
                    //WaitForElementToBeClickeable(By.XPath("//tbody/tr[" + row + "]/td[2]/div/label"), 4).Click();
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void SelectTransactionTypeInAccountsPage(string transactionType)
        {

            this.Pause(3);
            this.ScrollWindowBy(0,-5500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int caseRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= caseRows; row++)
            {
                this.Pause(3);
                IWebElement transType = driver.FindElement(By.XPath("//tbody/tr[" + row + "]/td[4]"));

                string transactionTypee = transType.Text;

                if (transactionTypee == transactionType)
                {
                    this.Pause(2);
                    ScrollUpToPageTop();
                    var SelectTransactionType = driver.FindElement(By.XPath($"//tbody/tr[" + row + "]/td[2]/div/label"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectTransactionType);
                    //WaitForElementToBeClickeable(By.XPath("//tbody/tr[" + row + "]/td[2]/div/label"), 4).Click();
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void SelectedTransactionTypeEditInAccountsPage(string type)
        {
            Thread.Sleep(3000);
           var selectTransactionType = driver.FindElement(By.XPath($"//td[text()='{type}']//following-sibling::td//a"));
           ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", selectTransactionType);
         }

        public void SelectedTransactionTypeViewInAccountsPage(string type)
        {
            Thread.Sleep(3000);
            var selectTransactionType = driver.FindElement(By.XPath($"//td[text()='{type}']//following-sibling::td//a"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", selectTransactionType);
        }
        public void SelectVoidedInFilter(string type)
        {
            this.Pause(3);
            WaitForElementToBeClickeable(voidedType, 4).Click();
            this.Pause(3);
            driver.FindElement(By.XPath($"//div[text()='{type}']")).Click();
            this.Pause(2);
            driver.FindElement(By.XPath("//button[text()='CLOSE']")).Click();
        }
        public void SelectLinkedInFilter(string type)
        {
            this.Pause(1);
            WaitForElementToBeClickeable(linkedTyep, 4).Click();
            this.Pause(1);
            driver.FindElement(By.XPath($"//div[text()='{type}']")).Click();
         }
        public void ClickAdd()
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='modal-footer']//button[1]")).Click();
        }
        public void ClickSave()
        {
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(By.XPath("//div[@class='pull-right epiq-page-footer-buttons']/button[1]")).Click();
        }
        public void ClickOnExportButton()
        {
            WaitForElementToBeClickeable(By.XPath("(//span[@class='epiq-export']/button)[1]")).Click();
        }
       
        public void clickOnViewIcon()
        {
            WaitForElementToBeClickeable(By.XPath("(//td[@class='epiq-table-data-no-title ']/a)[2]")).Click();
        }
        public void VerifyDepositFieldNonEditable()
        {
            Thread.Sleep(4000);
            Boolean value = WaitForElementToBeVisible(By.XPath("//label[text()='NAME']//following-sibling::div")).Enabled;
            value.Should().BeTrue();
        }
        public void ClickClosedButton()
        {
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(By.XPath("//div[@class='pull-right epiq-page-footer-buttons']/button")).Click();
        }
        public void ClickOnEditPencilIcon()
        {
            ScrollDownToPageBottom();
            var editPencilIcon = WaitForElementToBeClickeable(By.XPath("//a[contains(@title,'Edit Transaction')]"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", editPencilIcon);
        }
        public void ClickOnSaveButtonTransaction()
        {
            WaitForElementToBeClickeable(By.XPath("//label[text()='DESCRIPTION']/following-sibling::input")).Clear();
            WaitForElementToBeClickeable(By.XPath("//label[text()='DESCRIPTION']/following-sibling::input")).SendKeys("TestAutomation");
            ScrollDownToPageBottom();
            WaitForElementToBeClickeable(By.XPath("//div[@class='pull-right epiq-page-footer-buttons']/button")).Click();
        }

        public void ClickEditBankAccountIcon()
        {
            this.Pause(2);
            var EditBankAccount = driver.FindElement(editBankAccount);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", EditBankAccount);
        }

        public void nextCheckNumberIsEditable(string description)
        {
            ClearAndType(WaitForElementToBeVisible(nextCheckNumber), description);
        }

        public void nextDepositnumberIsEditable(string description)
        {
            ClearAndType(WaitForElementToBeVisible(nextDepositNumber), description);
        }

          public bool nextDepositNumberIsDisable()
        {
            return this.WaitForElementToBeVisible(nextDepositNumberdisable).Enabled;
        }
        
        public bool nextCheckNumberIsDisable()
        {
            return this.WaitForElementToBeVisible(nextCheckNumberdisable).Enabled;
        }

        public void ClickOnLinkReceiptButton()
        {
            this.Pause(3);
            driver.FindElement(By.XPath($"//div[@class='receipt-button']/button")).Click();
          
        }

        public void ReceiptSelect()
        {
            WaitForElementToBePresent(selectReceipt, 3).Click();
        }

        public void InterestAssetSelect()
        {
            WaitForElementToBePresent(InterestAsset, 3).Click();
        }
        public void InputDescriptionField(string description)
        {
            Thread.Sleep(5000);
            ScrollDownToPageBottom();
            //MoveToElementAndClick(driver.FindElement(descriptionText));
            //this.Pause(2);
            //WaitForElementToBeVisible(descriptionText).SendKeys(description);
            ClearAndType(WaitForElementToBeVisible(descriptionText), description);
        }
      }
}