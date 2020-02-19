using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Bankings
{
    [Binding]
    public class BankingManagementPageSteps : StepBase
    {
        BankingPage bankingPage = new BankingPage(driver);
        DashboardPage dashboardPage;
        IssueReconciliation issueReconciliation = new IssueReconciliation(driver);
        List<string> activeRecords = null;
        [When(@"User click on Filter on Issue Reconcilation page")]
        [When(@"User click on Filter on Banking Activity page")]
        public void WhenUserClickOnFilterOnBankingActivityPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking Activity"));
            Thread.Sleep(7000);
            bankingPage.ClickOnFilter();
        }
        [When(@"I click on Filter on Banking Activity page")]
        public void WhenIClickOnFilterOnBankingActivityPage()
        {
            Thread.Sleep(4000);
            bankingPage.ClickOnFilter();
        }
        [Then(@"I click on close button")]
        public void ThenIClickOnCloseButton()
        {
            bankingPage.ClickOnClose();
        }
        [When(@"User click on Filter buton on Banking Activity page")]
        public void WhenUserClickOnFilterButonOnBankingActivityPage()
        {
            Thread.Sleep(3000);
            bankingPage.ClickOnFilter();
        }

        [When(@"User click on close on Banking Activity page")]
        public void WhenUserClickOnCloseOnBankingActivityPage()
        {
            bankingPage.ClickOnFilterClose();
        }

        [When(@"Enter Case Number '(.*)' in Banking Activity filter option")]
        public void WhenEnterCaseNumberInBankingActivityFilterOption(string caseNumber)
        {
            bankingPage.EnterCaseNumber(caseNumber);
        }
        [When(@"Enter Account \# '(.*)' in Banking Activity filter option")]
        public void WhenEnterAccountInBankingActivityFilterOption(string accountNumber)
        {
            bankingPage.EnterAccountNumber(accountNumber);
        }


        [When(@"User displays the page count on Banking Activity page")]
        public void WhenUserDisplaysThePageCountOnBankingActivityPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking Activity"));
            Thread.Sleep(3500);
            bankingPage.GetPageCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Activity count is [{0}]", bankingPage.GetPageCount()));
        }

        [Then(@"'(.*)' header should be displayed on Banking Activity Page")]
        public void ThenHeaderShouldBeDisplayedOnBankingActivityPage(string header)
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking Activity"));
            Thread.Sleep(3500);
            bankingPage.GetHeaderName().Should().Contain(header);
        }

        [Then(@"perform mouse over on debotor column")]
        public void ThenPerformMouseOverOnDebotorColumn()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking Activity"));
            Thread.Sleep(3500);
            bankingPage.mouseHouverActivity();
        }
        [Then(@"perform mouse over on debotor column On bankings")]
        public void ThenPerformMouseOverOnDebotorColumnOnBankings()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts")); Thread.Sleep(3500);

            bankingPage.MouseHouver();
        }
        [Then(@"perform mouse over on debotor column On receiptlog")]
        public void ThenPerformMouseOverOnDebotorColumnOnReceiptlog()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
            Thread.Sleep(3500);
            bankingPage.MouseHouver();
        }

        [Then(@"perform mouse over on debotor column On checks")]
        public void ThenPerformMouseOverOnDebotorColumnOnChecks()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits"));
            Thread.Sleep(3500);
            bankingPage.MouseHouver();
        }


        [Then(@"Banking Activity '(.*)' should be displayed")]
        public void ThenBankingActivityShouldBeDisplayed(string filterHeader)
        {
            bankingPage.GetFilterOptionHeader().Should().Contain(filterHeader);
        }


        //[Then(@"Banking Activity Breadcrumbs should be displayed")]
        //public void ThenBankingActivityBreadcrumbsShouldBeDisplayed()
        //{
        //    bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking Activity"));
        //    Thread.Sleep(3500);
        //    bankingPage.GetBreadcrumb().Should().BeTrue();
        //}

        [Then(@"'(.*)' Should be able to sort on Banking Activity page")]
        public void ThenShouldBeAbleToSortOnBankingActivityPage(string headerName)
        {
            Thread.Sleep(3500);
            var list = bankingPage.GetSortedList(headerName);
            list.Should().BeInAscendingOrder();
            list = bankingPage.GetSortedList(headerName);
            list.Should().BeInDescendingOrder();
        }
        [When(@"I enter Bank Balance other as '(.*)'")]
        public void WhenIEnterBankBalanceOtherAs(string otherValue)
        {
            bankingPage.EnterOtherBankBalance(otherValue);
        }


        [Then(@"Banking Activity records should be displayed")]
        public void ThenBankingActivityRecordsShouldBeDisplayed()
        {
            Thread.Sleep(3500);
            bankingPage.GetActivityRecords().Should().NotBeNull();
        }

        [Then(@"User click on the reset button on Banking Activity filter option")]
        public void ThenUserClickOnTheResetButtonOnBankingActivityFilterOption()
        {
            bankingPage.ClickOnResetButton();
        }

        [Then(@"user click on close button on Banking Activity option")]
        public void ThenUserClickOnCloseButtonOnBankingActivityOption()
        {
            bankingPage.ClickOnCloseButton();
        }
        [When(@"Enter Account Number '(.*)' in Banking Activity filter option")]
        public void WhenEnterAccountNumberInBankingActivityFilterOption(Decimal accountNumber)
        {
            Thread.Sleep(3500);
            bankingPage.EnterAccountNumber(accountNumber);
        }

        [When(@"I Select  Issue '(.*)' in Banking Activity filter option")]
        public void WhenISelectIssueInBankingActivityFilterOption(string issue)
        {
            bankingPage.SelectIssue(issue);
        }

        [When(@"I enter Balance from '(.*)'")]
        public void WhenIEnterBalanceFrom(string balanceFrom)
        {
            bankingPage.EnterBalanceFrom(balanceFrom);
        }

        [When(@"I enter Balance to '(.*)'")]
        public void WhenIEnterBalanceTo(string balanceTo)
        {
            bankingPage.EnterBalanceTo(balanceTo);
        }



        [Then(@"the selected page records should be  in Banking Activity page")]
        public void ThenTheSelectedPageRecordsShouldBeInBankingActivityPage()
        {
            Thread.Sleep(3500);
            object value = null;
            var pageInfo = bankingPage.GetPagination();
            pageInfo.TryGetValue("Pagination", out value);
            ((bool)value).Should().BeTrue();
            pageInfo.TryGetValue("ActivePage", out value);
            (value).Should().NotBeNull();
        }

        // Scenarios for Banking Accounts

        [When(@"User click on Filter on Banking Accounts page")]
        public void WhenUserClickOnFilterOnBankingAccountsPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            Thread.Sleep(3500);
            bankingPage.ClickOnFilter();
        }

        [Then(@"'(.*)' header should be displayed on Banking Accounts Page")]
        public void ThenHeaderShouldBeDisplayedOnBankingAccountsPage(string header)
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            Thread.Sleep(3500);
            bankingPage.GetHeaderName().Should().Contain(header);
        }

        //[Then(@"Banking Accounts Breadcrumbs should be displayed")]
        //public void ThenBankingAccountsBreadcrumbsShouldBeDisplayed()
        //{
        //    bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
        //    Thread.Sleep(3500);
        //    bankingPage.GetBreadcrumb().Should().BeTrue();
        //}

        [When(@"User displays the page count on Banking Accounts page")]
        public void WhenUserDisplaysThePageCountOnBankingAccountsPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            Thread.Sleep(3500);
            bankingPage.GetPageCountAccount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Account count is [{0}]", bankingPage.GetPageCountAccount()));
        }
        // Banking Receipt Log Scenarios

        [Then(@"'(.*)' header should be displayed on Banking ReceiptLog Page")]
        public void ThenHeaderShouldBeDisplayedOnBankingReceiptLogPage(string header)
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
            Thread.Sleep(3500);
            bankingPage.GetHeaderName().Should().Contain(header);
        }

        [When(@"User click on Filter on Banking ReceiptLog page")]
        public void WhenUserClickOnFilterOnBankingReceiptLogPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
            Thread.Sleep(3500);
            bankingPage.ClickOnFilter();
        }
        [When(@"User select Linked '(.*)' on Banking Receipt filter")]
        public void WhenUserSelectLinkedOnBankingReceiptFilter(string linkedValue)
        {
            bankingPage.ReceiptFilterLinkned_SelectValue(linkedValue);
        }
        [When(@"I click on close button on Banking Receipt filter")]
        public void WhenIClickOnCloseButtonOnBankingReceiptFilter()
        {
            bankingPage.ClickOnReceiptFilterClose();
        }
        [Then(@"Banking Receipt Log records should be displayed")]
        public void ThenBankingReceiptLogRecordsShouldBeDisplayed()
        {
            bankingPage.GetReceiptRecords().Should().NotBeNull();
        }
        [When(@"User click on the reset button Banking Receipt filter")]
        public void WhenUserClickOnTheResetButtonBankingReceiptFilter()
        {
            bankingPage.ClickOnReceiptFilterReset();
        }

        //[Then(@"Banking ReceiptLog Breadcrumbs should be displayed")]
        //public void ThenBankingReceiptLogBreadcrumbsShouldBeDisplayed()
        //{
        //    bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
        //    Thread.Sleep(3500);
        //    bankingPage.GetBreadcrumb().Should().BeTrue();
        //}

        [When(@"User displays the page count on Banking ReceiptLog page")]
        public void WhenUserDisplaysThePageCountOnBankingReceiptLogPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
            Thread.Sleep(3500);
            bankingPage.GetPageCountReceiptLog().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Receipt log count is [{0}]", bankingPage.GetPageCountReceiptLog()));
        }


        // Scenarios for Banking Checks/Deposits
        [Then(@"'(.*)' header should be displayed on Banking ChecksOrDeposits Page")]
        public void ThenHeaderShouldBeDisplayedOnBankingChecksOrDepositsPage(string header)
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits"));
            Thread.Sleep(3500);
            bankingPage.GetHeaderName().Should().Contain(header);
        }

        [When(@"User click on Filter on Banking ChecksOrDeposits page")]
        public void WhenUserClickOnFilterOnBankingChecksOrDepositsPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits"));
            Thread.Sleep(3500);
            bankingPage.ClickOnFilter();
        }

        //[Then(@"Banking ChecksOrDeposits Breadcrumbs should be displayed")]
        //public void ThenBankingChecksOrDepositsBreadcrumbsShouldBeDisplayed()
        //{
        //    bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits"));
        //    Thread.Sleep(3500);
        //    bankingPage.GetBreadcrumb().Should().BeTrue();
        //}
        [When(@"User displays the page count on Banking ChecksOrDeposits page")]
        public void WhenUserDisplaysThePageCountOnBankingChecksOrDepositsPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits"));
            Thread.Sleep(3500);
            bankingPage.GetPageCountCheckOrPrintLog().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Print or Deposit count is [{0}]", bankingPage.GetPageCountCheckOrPrintLog()));
        }


        [When(@"user select the checkbox from the result gird")]
        public void WhenUserSelectTheCheckboxFromTheResultGird()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits"));
            Thread.Sleep(3500);
            bankingPage.clickOnCheckBox();
        }

        [When(@"Clicks on the print button")]
        public void WhenClicksOnThePrintButton()
        {
            bankingPage.clickOnPrintButton();
        }

        [Then(@"Validate that print queue message appears")]
        public void ThenValidateThatPrintQueueMessageAppears()
        {
            string validate = bankingPage.validatePrintQueueMessage();
            validate.Should().Contain("Your request is being generated, please wait for your file(s) to be available.");

        }

        [When(@"Enter Secondary Type '(.*)' in banking printing filter option")]
        public void WhenEnterSecondaryTypeInBankingPrintingFilterOption(string type)
        {
            bankingPage.EnterType(type);
        }


        [Then(@"Click on the close button button")]
        public void ThenClickOnTheCloseButtonButton()
        {
            bankingPage.clickOnPrintCloseButton();

        }

        [When(@"I Click on Unreconciled Bank Activity Link")]
        public void WhenIClickOnUnreconciledBankActivityLink()
        {
            dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
            Thread.Sleep(3500);
            bankingPage = dashboardPage.ClickOnUnReconciledBankActivity();
        }
        [Then(@"'(.*)' Column should contain '(.*)' list")]
        public void ThenColumnShouldContainList(string columnName, string toVerify)
        {
            bankingPage.GetRecordsByColumnName(columnName, toVerify);
        }

        [When(@"I Click on '(.*)' link in '(.*)'")]
        public void WhenIClickOnLinkIn(string xpathSuffix, string columnName)
        {
            issueReconciliation = bankingPage.ClickOnResultLinkByColumnName(columnName, xpathSuffix);
        }

        [Then(@"'(.*)' Tables should  defalut sorted to '(.*)'")]
        public void ThenTablesShouldDefalutSortedTo(string tables, string sortOption)
        {
            var tableName = tables.Split(';').ToList();
            var sortOptions = sortOption.Split(';').ToList();
            issueReconciliation.VerifyTablesDisplay(tableName, sortOptions);
        }

        [Then(@"'(.*)' Tables should have filters '(.*)'")]
        public void ThenTablesShouldHaveFilters(string tables, string filterOption)
        {
            var tableName = tables.Split(';').ToList();
            var filterOptions = filterOption.Split(';').ToList();
            issueReconciliation.VerifyFilters(tableName, filterOptions);
        }

        [Then(@"Case Name should Followed by veritical line and Bank Account Transaction should linked")]
        public void ThenCaseNameShouldFollowedByVeriticalLineAndBankAccountTransactionShouldLinked()
        {
            issueReconciliation.VerifCaseNameAndBankAccount();
        }


        ////[When(@"I Click on BreadCrumb Link")]
        ////public void WhenIClickOnBreadCrumbLink()
        ////{
        ////    bankingPage = issueReconciliation.ClickOnBredCrumb();
        ////}

        [Then(@"'(.*)' should have '(.*)' columns")]
        public void ThenShouldHaveColumns(string tableName, string columnNames)
        {
            issueReconciliation.VerifyTransactionsTableFormat(tableName, columnNames.Split(';').ToList());
        }
        [When(@"I click on Arrow '(.*)'")]
        public void WhenIClickOnArrow(string input)
        {
            issueReconciliation.ClickOnArrow(input);
        }

        [Then(@"Case Should navigate to previous case")]
        public void ThenCaseShouldNavigateToPreviousCase()
        {
            var caseNumber = issueReconciliation.GetCaseNumber();
            caseNumber.Should().Contain(activeRecords.Last());
        }

        [Then(@"Case Should navigate to next case")]
        public void ThenCaseShouldNavigateToNextCase()
        {
            var caseNumber = issueReconciliation.GetCaseNumber();

            if (activeRecords[0] == caseNumber)
                caseNumber.Should().Contain(activeRecords[0]);
            else
                caseNumber.Should().Contain(activeRecords[1]);
        }

        [When(@"Get Records by column '(.*)'")]
        public void WhenGetRecordsByColumn(string columnName)
        {
            activeRecords = bankingPage.GetRecordsByColumnName(columnName);
        }

        [Then(@"Records Should not selected by detault")]
        public void ThenRecordsShouldNotSelectedByDetault()
        {
            issueReconciliation.VerifyRadioButtonSelected().Should().Equals(new List<bool>() { false });
        }

        [When(@"I Link Transaction Serial\# (.*)")]
        public void WhenILinkTransactionSerial(string serialNumber)
        {
            issueReconciliation.LinkOrUnlinkTransaction(serialNumber);
        }

        [When(@"I Unlink Transaction Serial\# (.*)")]
        public void WhenIUnlinkTransactionSerial(string serialNumber)
        {
            issueReconciliation.LinkOrUnlinkTransaction(serialNumber);
        }

        [When(@"I click on (.*) button and verify Toast message")]
        public void WhenIClickOnButton(string buttonName)
        {
            issueReconciliation.ClickLinkTransactionButton(buttonName);
            issueReconciliation.VerifyTaostMessagePresent().Should().BeTrue();
        }


        [Then(@"Serial\# (.*) Should (.*) dispaly in Unlinked Transactions")]
        public void ThenSerialShouldDispalyInUnlinkedTransactions(string serialNumber, bool display)
        {
            issueReconciliation.GetRecordExist(serialNumber).Should().Be(display);
        }

        [Then(@"Serial\# (.*) Should (.*) dispaly Linked Transactions")]
        public void ThenSerialShouldDispalyLinkedTransactions(string serialNumber, bool display)
        {
            issueReconciliation.GetRecordExist(serialNumber).Should().Be(display);
        }

        [When(@"I Filter Transaction with (.*)")]
        public void WhenIFilterTransactionWith(string filterOption)
        {
            issueReconciliation.SelectFilter(filterOption);
        }

        [Then(@"Records should filtered with (.*)")]
        public void ThenRecordsShouldFilteredWith(string filteredValue)
        {
            var resultStatus = issueReconciliation.GetFilteredRecords(filteredValue);
            if (resultStatus.Count > 0)
                resultStatus.ForEach(String =>
                {
                    String.Should().BeEquivalentTo(filteredValue);
                });
            else
            {
                return;
            }

        }

        //[Then(@"(.*) Breadcrumb should be displayed")]
        //public void ThenBreadcrumbShouldBeDisplayed(string bredCrumb)
        //{
        //    bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
        //    Thread.Sleep(3500);
        //    bankingPage.GetBredCrumbText().Should().Contain(bredCrumb);
        //}

        [When(@"I click (.*) Button")]
        public void WhenIClickButton(string buttonName)
        {
            bankingPage.ClickButton(buttonName);
        }

        [Then(@"(.*) button should hilghlight")]
        public void ThenButtonShouldHilghlight(string buttonName)
        {
            bankingPage.VerifyButtonHighlighted(buttonName);
        }
        [Then(@"BANK TRANSACTION Value should be displayed")]
        public void ThenBANKTRANSACTIONValueShouldBeDisplayed()
        {
            issueReconciliation.GetBankTRansactionValue().Should().NotBeNull();
        }

        [Then(@"LEDGER TRANSACTION Value should be displayed")]
        public void ThenLEDGERTRANSACTIONValueShouldBeDisplayed()
        {
            issueReconciliation.GetLedgerTRansactionValue().Should().NotBeNull();
        }

        [When(@"I click on Close on Banking Activity Filter")]
        public void WhenIClickOnCloseOnBankingActivityFilter()
        {
            bankingPage.ClickOnClose();
        }

        [When(@"I click on Ignore button of transaction and verify Count")]
        public void WhenIClickOnIgnoreButtonOfTransactionAndVerifyCount()
        {
            int PriorCount = issueReconciliation.CountofIgnoreButton();
            issueReconciliation.ClickOnIgnoreButton();
            int PostCount = issueReconciliation.CountofIgnoreButton();
            PostCount.Should().Equals(PriorCount - 1);
        }


        [When(@"I click on Ignore button of transaction and verify Toast message")]
        public void WhenIClickOnIgnoreButtonOfTransactionAndVerifyToastMessage()
        {
            issueReconciliation.ClickOnIgnoreButton();
            //issueReconciliation.VerifyTaostMessagePresentForIgnoreUpdate().Should().BeTrue();
        }

        [Then(@"Record Ignore Button should be green")]
        public void ThenRecordIgnoreButtonShouldBeGreen()
        {
            issueReconciliation.VerifyIgnoreButtonColor();
        }

        [When(@"I click on Radio Button of Bank Transaction")]
        public void WhenIClickOnRadioButtonOfBankTransaction()
        {
            issueReconciliation.ClickOnBAnkTransactionRadio();
        }

        [Then(@"Bank Record should display on footer")]
        public void ThenBankRecordShouldDisplayOnFooter()
        {
            issueReconciliation.BankRecordDisplay().Should().BeTrue();
        }

        [When(@"I click on Radio Button of Ledger Transaction")]
        public void WhenIClickOnRadioButtonOfLedgerTransaction()
        {
            issueReconciliation.ClickOnLedgerTransactionRadio();
        }

        [Then(@"Ledger Record should display on footer")]
        public void ThenLedgerRecordShouldDisplayOnFooter()
        {
            issueReconciliation.LedgerRecordDisplay().Should().BeTrue();
        }

        [When(@"I click on Close Button of Bank Transaction on Footer")]
        public void WhenIClickOnCloseButtonOfBankTransactionOnFooter()
        {
            issueReconciliation.ClickOnBankFooterCloseButton();
        }

        [Then(@"Bank Record should not display on footer")]
        public void ThenBankRecordShouldNotDisplayOnFooter()
        {
            issueReconciliation.BlankFooterDisplay().Should().BeTrue();
        }

        [When(@"I click on Close Button of Ledger Transaction on Footer")]
        public void WhenIClickOnCloseButtonOfLedgerTransactionOnFooter()
        {
            issueReconciliation.ClickOnLedgerFooterCloseButton();
        }

        [Then(@"Ledger Record should not display on footer")]
        public void ThenLedgerRecordShouldNotDisplayOnFooter()
        {
            issueReconciliation.BlankFooterDisplay().Should().BeTrue();
        }



        // Receipt Log Transactions(Voided, Edit and Verify)


        [Then(@"Click on the edit option for records")]
        public void ThenClickOnTheEditOptionForRecords()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
            Thread.Sleep(3500);
            bankingPage.ClickCheckBoxIcon();
            bankingPage.ClickEditIcon();
        }

        [Then(@"'(.*)' header should be displayed on Edit Receipt Log")]
        public void ThenHeaderShouldBeDisplayedOnEditReceiptLog(string headerName)
        {
            bankingPage.GetEditHeaderName().Contains(headerName);
        }

        [Then(@"Link Transaction button should be enable on edit receipt log")]
        public void ThenLinkTransactionButtonShouldBeEnableOnEditReceiptLog()
        {
            bankingPage.ClickLinkTransaction();
        }

        [When(@"select and link transaction for a case")]
        public void WhenSelectAndLinkTransactionForACase()
        {
            bankingPage.ClickCaseTransaction();
        }

        [Then(@"click on the save to link the transaction and also validate the row is present")]
        public void ThenClickOnTheSaveToLinkTheTransactionAndAlsoValidateTheRowIsPresent()
        {
            bankingPage.ValidateCaseDetails();
            bankingPage.ClickEditSaveButton();
        }

        [Then(@"UnLink Transaction button should be enable on edit receipt log")]
        public void ThenUnLinkTransactionButtonShouldBeEnableOnEditReceiptLog()
        {
            bankingPage.ClickUnLinkTransaction();
        }

        [Then(@"Validate the cancel button is enabled on edit receipt log")]
        public void ThenValidateTheCancelButtonIsEnabledOnEditReceiptLog()
        {
            bankingPage.ValidateEditCancelButton();
        }

        [Then(@"click on the save to link the transaction and also validate the row is  not present")]
        public void ThenClickOnTheSaveToLinkTheTransactionAndAlsoValidateTheRowIsNotPresent()
        {
            //bankingPage.ValidateCaseDetailsNull();
            bankingPage.ClickEditSaveButton();
        }
        [When(@"User Select the result from grid and click on verified")]
        public void WhenUserSelectTheResultFromGridAndClickOnVerified()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog")); Thread.Sleep(3500);
            bankingPage.ClickCheckBoxIcon();
            bankingPage.ClickVerifyButton();
        }

        [Then(@"Verified record appears in green tick mark")]
        public void ThenVerifiedRecordAppearsInGreenTickMark()
        {
            bankingPage.ValidateVerifiedColor();
        }

        [Then(@"Mousehover on the verified column")]
        public void ThenMousehoverOnTheVerifiedColumn()
        {
            bankingPage.VerifyMouseHover();

        }
        // Adding code for view permissions
        [When(@"User clicks on the account number")]
        public void WhenUserClicksOnTheAccountNumber()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts")); Thread.Sleep(3500);
            bankingPage.ClickOnAccountNumberDisabled();
        }

        //[Then(@"BreadCrumb contains as '(.*)'")]
        //public void ThenBreadCrumbContainsAs(string bredCrumb)
        //{

        //    bankingPage.GetBredCrumbText().Should().Contain(bredCrumb);
        //}
        [Then(@"'(.*)' Breadcrumb should displayed")]
        public void ThenBreadcrumbShouldDisplayed(string headers)
        {
            bankingPage.VerifyInBreadcrumbed(headers);
        }


        [Then(@"'(.*)' is displayed as header")]
        public void ThenIsDisplayedAsHeader(string header)
        {
            bankingPage.ValidateHeaderText().Contains(header);
        }

        [Then(@"'(.*)' is displayed as subheader")]
        public void ThenIsDisplayedAsSubheader(string subHeader)
        {
            bankingPage.ValidateSubHeaderText().Should().Contain(subHeader);
        }

        [Then(@"Check button is not enabled")]
        public void ThenCheckButtonIsNotEnabled()
        {
            bankingPage.ValidateCheckButton();
        }

        [Then(@"'(.*)' Should be able to sort on Account Mangement page")]
        public void ThenShouldBeAbleToSortOnAccountMangementPage(string columnName)
        {
            var list = bankingPage.GetSortedList(columnName);
            list.Should().BeInAscendingOrder();
            list = bankingPage.GetSortedList(columnName);
            list.Should().BeInDescendingOrder();
        }

        //Verify the view permission on receipt log page
        [When(@"User Select the result from grid")]
        public void WhenUserSelectTheResultFromGrid()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog")); Thread.Sleep(3500);
            bankingPage.ClickCheckBoxIcon();
        }

        [When(@"try to click on add receipt , void, deposit and verify")]
        public void WhenTryToClickOnAddReceiptVoidDepositAndVerify()
        {
            bankingPage.PerformClickonAllBuutons();
        }

        [Then(@"I Click the View button from the result grid")]
        public void ThenIClickTheViewButtonFromTheResultGrid()
        {
            bankingPage.ClickOnViewButton();
        }

        [Then(@"Header should display as'(.*)'")]
        public void ThenHeaderShouldDisplayAs(string header)
        {
            bankingPage.ValidatereceiptHeaderText().Should().Contain(header);
        }
        [Then(@"Validate the No Access message on the page as '(.*)'")]
        public void ThenValidateTheNoAccessMessageOnThePageAs(string errorpopup)
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Banking ChecksOrDeposits")); Thread.Sleep(3500);
            // bankingPage.PerformClickonPrint();
            bankingPage.ValidateErrorText().Should().Contain(errorpopup);
        }
        [When(@"I click on Account Number link")]
        public void WhenIClickOnAccountNumberLink()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            bankingPage.ClickOnBankAccountLink();
        }

        [Then(@"I should not be able to edit CLEARED field value")]
        public void ThenIShouldNotBeAbleToEditCLEAREDFieldValue()
        {
            bankingPage.ValidateInlineEditing().Should().BeFalse();
        }
        [Then(@"I should be able to edit CLEARED field value with current date")]
        public void ThenIShouldBeAbleToEditCLEAREDFieldValueWithCurrentDate()
        {
            bankingPage.EditCleared();
        }
        [When(@"I Select one case from Bank Accounts page")]
        public void WhenISelectOneCaseFromBankAccountsPage()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            bankingPage.ClickOnCase();
        }
        [Then(@"I select one Account from Bank Account list")]
        public void ThenISelectOneAccountFromBankAccountList()
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            bankingPage.ClickOnAccountNumber();
        }
        [Then(@"I see Bank Name and Account Name and Account Number Under Case header details")]
        public void ThenISeeBankNameAndAccountNameAndAccountNumberUnderCaseHeaderDetails()
        {
            bankingPage.ValidateBankNameOnHeader();
            bankingPage.ValidateAccountNumberOnHeader();
            // bankingPage.ValidateAccountNameOnHeader();

        }
        [Then(@"I See the Account Summary Section")]
        public void ThenISeeTheAccountSummarySection()
        {
            bankingPage.ValidateAccountSummaryHeader();
        }

        [Then(@"I See the TRansactions Section")]
        public void ThenISeeTheTRansactionsSection()
        {
            bankingPage.ValidateTransactionsHeader();
        }
        [Then(@"I See the Check Button enabled in Transactions Section")]
        public void ThenISeeTheCheckButtonEnabledInTransactionsSection()
        {
            bankingPage.ValidateCheckBuuton_In_Transactions().Should().BeTrue();
        }
        [Then(@"I see partial Account number")]
        public void ThenISeePartialAccountNumber()
        {
            bankingPage.IsPartialAccount_No().Should().BeTrue();
        }
        [Then(@"I see Full Account number is hidden")]
        public void ThenISeeFullAccountNumberIsHidden()
        {
            bankingPage.IsPartialAccount_No();
        }
        //[Then(@"I should be on Bank Activity Page")]
        //public void ThenIShouldBeOnBankActivityPage()
        //{
        //    bankingPage = new BankingPage(driver);
        //    Thread.Sleep(3500);
        //    bankingPage.GetBreadcrumb().Should().BeTrue();

        //}
        [Then(@"I see Unlinked Type value is Deposit")]
        public void ThenISeeUnlinkedTypeValueIsDeposit()
        {
            //bankingPage = new BankingPage(driver);
            bankingPage.GetUnlinkedTypeValue().Contains("Deposit");
        }
        [Then(@"I see HAS BANK TRANSACTIONS value is All")]
        public void ThenISeeHASBANKTRANSACTIONSValueIsAll()
        {
            bankingPage.GetHasBankTransactionsValue().Contains("All");
        }

        [Then(@"I see CASE STATUS value is Open")]
        public void ThenISeeCASESTATUSValueIsOpen()
        {
            bankingPage.GetCaseStatusValue().Contains("Open");
        }
        [When(@"I click on Account\# '(.*)'")]
        public void WhenIClickOnAccount(string accountno)
        {
            bankingPage = ((BankingPage)GetSharedPageObjectFromContext("Bank Accounts"));
            bankingPage.ClickAccountNumber(accountno);
        }
        [Then(@"I Click the View Transation")]
        public void ThenIClickTheViewTransation()
        {
            bankingPage.ClickViewTransaction();
        }
        [Then(@"I verify View Check page header")]
        public void ThenIVerifyViewCheckPageHeader()
        {
            bankingPage.VerifyViewCheckHeader();
        }

        [Then(@"I verify Receipt Log Option")]
        public void ThenIVerifyReceiptLogOption()
        {
            bankingPage.VerifyViewCheckHeader();
        }


        [Then(@"I see the fields in Check Details section BANKNAME '(.*)' , ACCOUNT '(.*)', SERIAL \# '(.*)' , CLEAR DATE '(.*)'")]
        public void VerifyCheckDetails(string bankname, string accountnum, string serialno, string clrdate)
        {
            bankingPage.VerifyCheckDetails(bankname, accountnum, serialno,clrdate);
        }

        [Then(@"I see the fields in Pay To Section PAYEE NAME '(.*)', DESCRIPTION '(.*)', REMARKS '(.*)'")]
        public void VerifyPayToDetails(string name, string desc, string remark)
        {
            bankingPage.VerifyPayToDetails(name, desc, remark);
        }

        [Then(@"I see the fields in Amounts Section AMOUNT '(.*)', SUM OF ALLOCATIONS '(.*)', DISTRIBUTION TYPE '(.*)'")]
        public void VerifyAmounts(string amt, string allocations, string disttype)
        {
            bankingPage.VerifyAmounts(amt, allocations, disttype);
        }
        [Then(@"View Check Breadcrumbs should be displayed")]
        public void ThenViewCheckBreadcrumbsShouldBeDisplayed()
        {
            bankingPage.Breadcrumb();
        }
        [Then(@"I see the fields in Claim Links Section NAME '(.*)', LINKED AMOUNT '(.*)', UTC '(.*)'")]
        public void VerifyClaimLinks(string name, string amt, string utc)
        {
            bankingPage.VerifyClaimLinks(name, amt, utc);
        }
        [When(@"User click on close on Check View page")]
        public void WhenUserClickOnCloseOnCheckViewPage()
        {
            bankingPage.Close();
        }
        [Then(@"I click Account Management in Breadcrumb")]
        public void ThenIClickAccountManagementInBreadcrumb()
        {
            bankingPage.ClickAccountManagementInBreadcrumb();
        }
        [When(@"I click on Accountnumber '(.*)'")]
        public void WhenIClickOnAccountnumber(string acct)
        {
            bankingPage.ClickOnAccountnumber(acct);
        }
        [Then(@"I Click the Transaction '(.*)'")]
        public void ThenIClickTheEditTransaction(string name)
        {
            bankingPage.ClickEditTransaction(name);
        }
        [Then(@"I verify Write Check page header")]
        public void VerifyWriteCheckHeader()
        {
            bankingPage.VerifyWriteCheckHeader();
        }
        [Then(@"Write Check Breadcrumbs should be displayed")]
        public void WriteCheckBreadcrumb()
        {
            bankingPage.WriteCheckBreadcrumb();
        }


        [Then(@"I see the fields in Edit Check page as BANKNAME '(.*)' , ACCOUNT '(.*)', SERIAL \# '(.*)', PAYEE NAME '(.*)', ADDRESSLINEONE '(.*)', ADDRESSLINETWO '(.*)', AMOUNT '(.*)', SUM OF ALLOCATIONS '(.*)'")]
        public void WriteCheckReadOnlyFields(string bank, string acct, string serial, string payee, string addr1, string addr2, string amt, string allocation)
        {
            bankingPage.WriteCheckReadOnlyFields(bank, acct, serial, payee, addr1, addr2, amt, allocation);
        }


        [Then(@"I edit the fields CLEAR DATE '(.*)', DESCRIPTION '(.*)', REMARKS '(.*)', DISTRIBUTION TYPE '(.*)'")]
        public void WriteCheckEditFields(string cleardate, string desc, string remark, string disttype)
        {
            bankingPage.WriteCheckEditFields(cleardate, desc, remark, disttype);
        }

        [Then(@"I edit the fields DESCRIPTION '(.*)', REMARKS '(.*)'")]
        public void ThenIEditTheFieldsDESCRIPTIONREMARKS(string desc, string remark)
        {
            bankingPage.WireDebitFields(desc, remark);
        }


        [Then(@"I add Claim links")]
        public void AddClaimLinks()
        {
            bankingPage.AddClaimLinks();
        }

        [Then(@"I edit Claim links NAME '(.*)', DESCRIPTION '(.*)', UTC '(.*)', LINKED AMOUNT '(.*)'")]
        public void EditClaimLinks(string name, string desc, string utc, string amt)
        {
            bankingPage.EditClaimLinks(name, desc, utc, amt);
        }
        [Then(@"I delete Claim link")]
        public void DeleteClaimLink()
        {
            bankingPage.DeleteClaimLink();
        }
        [Then(@"I add Unlinked allocations PAYEE NAME '(.*)', UTC '(.*)', AMOUNT '(.*)'")]
        public void AddUnlinkedAllocations(string name, string utc, string amt)
        {
            bankingPage.AddUnlinkedAllocations(name, utc, amt);
        }
        [Then(@"I edit Unlinked allocations NAME '(.*)', DESCRIPTION '(.*)', UTC '(.*)', LINKED AMOUNT '(.*)'")]
        public void EditUnlinkedAllocations(string name, string desc, string utc, string amt)
        {
            bankingPage.EditUnlinkedAllocations(name, desc, utc, amt);
        }

        [Then(@"I delete Unlinked allocations")]
        public void DeleteUnlinkedAllocations()
        {
            bankingPage.DeleteUnlinkedAllocations();
        }
        [Then(@"I validate SUM OF ALLOCATIONS")]
        public void SumOfAllocations()
        {
            bankingPage.SumOfAllocations();
        }
        [When(@"User click on Save on Write Check page")]
        public void SaveOnWriteCheckPage()
        {
            bankingPage.SaveOnWriteCheckPage();
        }


        [Then(@"I click Cancel on Write Check page")]
        public void CancelOnWriteCheckPage()
        {
            bankingPage.CancelOnWriteCheckPage();
        }
        [Then(@"I see the fields in Check Details section ACCOUNT '(.*)'")]
        public void CheckAccountNumber(string acctno)
        {
            bankingPage.CheckAccountNumber(acctno);
        }

        [Then(@"I Verify for Receipt Log")]
        public void ThenIVerifyForReceiptLog()
        {
            bankingPage.VerifyReceiptLog();
        }
        #region Void Transaction 

        [When(@"User click on Filter on Banking AccountsSummary page")]
        public void WhenUserClickOnFilterOnBankingAccountsSummaryPage()
        {
            bankingPage.ClickOnFilter();
        }
        [Then(@"I select Cleared date as '(.*)'")]
        public void ThenISelectClearedDateAs(string clearedDateInput)
        {
            bankingPage.InputClearedText(clearedDateInput);
        }
        [Then(@"I click on close button in the filter")]
        public void ThenIClickOnCloseButtonInTheFilter()
        {
            bankingPage.ClickOnCloseButton();
        }
        [When(@"I select the any transaction")]
        public void WhenISelectTheAnyTransaction()
        {
            bankingPage.ClickCheckBoxed();
        }
        [When(@"I select the first record to edit the transaction")]
        public void WhenISelectTheFirstRecordToEditTheTransaction()
        {
            bankingPage.SelectFirstRecord();
        }
        [When(@"I click on the Void button on AccountSummary Page")]
        public void WhenIClickOnTheVoidButtonOnAccountSummaryPage()
        {
            bankingPage.ClickOnVoidButton();
        }
        [Then(@"Verify the pop header as '(.*)'")]
        public void ThenVerifyThePopHeaderAs(string title)
        {
            bankingPage.VerifyPopUpHeader(title);
        }
        [Then(@"verify the pop up body message as '(.*)'")]
        public void ThenVerifyThePopUpBodyMessageAs(string body)
        {
            bankingPage.VerifyPopUpBody(body);
        }
        [Then(@"Click on OK Button of the pop up modal")]
        public void ThenClickOnOKButtonOfThePopUpModal()
        {
            bankingPage.ClickOnOkButton();
        }
        [Then(@"I click on reset button")]
        public void ThenIClickOnResetButton()
        {
            bankingPage.ClickOnResetButton();
        }

        [When(@"I enter the text for Remarks")]
        public void WhenIEnterTheTextForRemarks()
        {
            bankingPage.InputRemarks();
        }
        [Then(@"verfiy the red button is appeared next to cleared date column")]
        public void ThenVerfiyTheRedButtonIsAppearedNextToClearedDateColumn()
        {
            bankingPage.VoidTransactions();
        }

        [Then(@"I clear cleared date field")]
        public void ThenIClearClearedDateField()
        {
            bankingPage.ClearInlineClearedDate();
        }

        [Then(@"I select Stop Payement as '(.*)'")]
        public void ThenISelectStopPayementAs(string value)
        {
            bankingPage.SelectStopPayement(value);
        }

        [Then(@"I click on dots and select '(.*)'")]
        public void ThenIClickOnDotsAndSelect(string value)
        {
            bankingPage.SelectPaymentOptions(value);
        }
        [When(@"I click on Reset Filters Buttons")]
        public void WhenIClickOnResetFiltersButtons()
        {

            bankingPage.ClickOnReferesh();
        }
        [Then(@"I verify default data in filter options as ClearedDate '(.*)', StopPayment '(.*)', PermitAssetImbalance '(.*)'")]
        public void BankAccountDefaultFilterOptions(string date, string payment, string imbalance)
        {
            bankingPage.ClickOnFilter(date, payment, imbalance);
        }
        [Then(@"I verify data in filter options in Account Management page")]
        public void VerifyDataInFilterOptionsInAccountManagementPage()
        {
            bankingPage.VerifyDataInFilterOptionsInAccountManagementPage();
        }
        [Then(@"I select  ClearedDate '(.*)', StopPayment '(.*)', PermitAssetImbalance '(.*)'")]
        public void SelectFilterOptionsInAccountManagementPage(string date, string payment, string imbalance)
        {
            bankingPage.SelectFilterOptionsInAccountManagementPage(date, payment, imbalance);
        }

        [Then(@"I verify message when there are no results to display in the grid '(.*)'")]
        public void VerifyMessageWhenThereAreNoResultsToDisplay(string msg)
        {
            bankingPage.VerifyMessageWhenThereAreNoResultsToDisplay(msg);
        }

        [Then(@"I click Reset in filter")]
        public void ClickResetInFilter()
        {
            bankingPage.ClickResetInFilter();
        }

        #endregion

        #region Banking services
        [Then(@"I enter the Name Field in the Received Form")]
        public void ThenIEnterTheNameFieldInTheReceivedForm()
        {
            bankingPage.EnterReceivedFrom();
        }

        [Then(@"I enter the amounts fields and validate the error message")]
        public void ThenIEnterTheAmountsFieldsAndValidateTheErrorMessage()
        {
            bankingPage.ValidateTheAmountCount();
        }

        [Then(@"Verify the error message on mismatch of the amount")]
        public void ThenVerifyTheErrorMessageOnMismatchOfTheAmount()
        {
            bankingPage.VerifyLinkAmountMismatchMessage();
        }
        [When(@"I Enter All Feilds in non closing cost claim")]
        public void WhenIEnterAllFeildsInNonClosingCostClaim()
        {
            bankingPage.EnterAllFields();
        }

        #endregion

        [Then(@"I enter Account\# '(.*)'")]
        public void EnterAccountNumberInFilter(string accountNumber)
        {
            bankingPage.EnterAccountNumberInFilter(accountNumber);
        }
        [Then(@"I click Add Transaction button")]
        public void ClickAddTransactionButton()
        {
            bankingPage.ClickAddTransactionButton();
        }
        [Then(@"I verify '(.*)' Header")]
        public void VerifyHeaderInAddTransaction(string header)
        {
            bankingPage.VerifyHeaderInAddTransaction(header);
        }
        [Then(@"I click on '(.*)' button")]
        public void ClickOnButton(string button)
        {
            bankingPage.ClickOnButton(button);
        }
        [Then(@"I verify '(.*)' and '(.*)' sub-headers")]
        public void VerifyAndSubHeadersInAddTransaction(string receipt, string disbursement)
        {
            bankingPage.VerifyAndSubHeadersInAddTransaction(receipt, disbursement);
        }
        [Then(@"I verify '(.*)' in Breadcrumb")]
        public void VerifyInBreadcrumb(string header)
        {
            bankingPage.VerifyInBreadcrumb(header);
        }
        [Then(@"I click on Cancel button")]
        public void ClickOnCancelButton()
        {
            bankingPage.ClickOnCancelButton();
        }
        [Then(@"I click on Add Button")]
        public void ThenIClickOnAddButton()
        {
            bankingPage.ClickAdd();
        }
        [Then(@"I click on Save Button")]
        public void ThenIClickOnSaveButton()
        {
            bankingPage.ClickSave();
        }
        [Then(@"I click on Export Button in Transaction page")]
        public void ThenIClickOnExportButtonInTransactionPage()
        {
            bankingPage.ClickOnExportButton();
        }

        [Then(@"I click on eye ball Icon")]
        public void ThenIClickOnEyeBallIcon()
        {
            bankingPage.clickOnViewIcon();
        }

        [Then(@"I verify deposit is non editible field")]
        public void ThenIVerifyDepositIsNonEditibleField()
        {
            bankingPage.VerifyDepositFieldNonEditable();
        }

        [Then(@"I click on close button on view page")]
        public void ThenIClickOnCloseButtonOnViewPage()
        {
            bankingPage.ClickClosedButton();
        }

        [Then(@"I click on Edit pencil Icon")]
        public void ThenIClickOnEditPencilIcon()
        {
            bankingPage.ClickOnEditPencilIcon();
        }

        [Then(@"I edit the values and save the new values")]
        public void ThenIEditTheValuesAndSaveTheNewValues()
        {
            bankingPage.ClickOnSaveButtonTransaction();
        }
        [Then(@"I click on EditBank Account icon")]
        public void ThenIClickOnEditBankAccountIcon()
        {
            bankingPage.ClickEditBankAccountIcon();
        }
        [Then(@"I enter checknumber Description '(.*)'")]
        public void ThenIEnterChecknumberDescription(string description)
        {
            bankingPage.nextCheckNumberIsEditable(description);
        }

        [Then(@"I enter nextDepositnumber Description '(.*)'")]
        public void ThenIEnterNextDepositnumberDescription(string description)
        {
            bankingPage.nextDepositnumberIsEditable(description);
        }

        [Then(@"I able to see disable icon for nextcheck Number")]
        public void ThenIAbleToSeeDisableIconForNextcheckNumber()
        {
            bankingPage.nextCheckNumberIsDisable().Equals(true);
        }

        [Then(@"I able to see disable icon for nextDeposit Number")]
        public void ThenIAbleToSeeDisableIconForNextDepositNumber()
        {
            bankingPage.nextDepositNumberIsDisable().Equals(true);
        }

        [Then(@"I click on LinkReceipt button in Received from Accordion")]
        public void ThenIClickOnLinkReceiptButtonInReceivedFromAccordion()
        {
            bankingPage.ClickOnLinkReceiptButton();
        }


        [Then(@"I Select any receipt from unlinked Receipt Log Entries")]
        public void ThenISelectAnyClaimFromUnlinkedReceiptLogEntries()
        {
            bankingPage.ReceiptSelect();
            
        }
        [Then(@"I click on '(.*)' button in InterestAssetLinks Accordion")]
        public void ThenIClickOnButtonInInterestAssetLinksAccordion(string button)
        {
            bankingPage.ClickOnButton(button);
        }
        [Then(@"I Select any Asset from LinkInterestAsset")]
        public void ThenISelectAnyAssetFromLinkInterestAsset()
        {
            bankingPage.InterestAssetSelect();
        }
        [Then(@"Input Description '(.*)' in Received from Accordion")]
        public void ThenInputDescriptionInReceivedFromAccordion(string description)
        {
            bankingPage.InputDescriptionField(description);
        }

        [Then(@"I Select transaction type from '(.*)' in Bank Accounts page")]
        public void ThenISelectTransactionTypeFromInBankAccountsPage(string transactionType)
        {
            bankingPage.SelectTransactionTypeInAccountsPage(transactionType);
        }

        [Then(@"I click on Edit pencil Icon of the selected '(.*)' Transaction type")]
        public void ThenIClickOnEditPencilIconOfTheSelectedTransactionType(string type)
        {
            bankingPage.SelectedTransactionTypeEditInAccountsPage(type);
        }

        [Then(@"I click on eye ball Icon of the selected '(.*)' Transaction type")]
        public void ThenIClickOnEyeBallIconOfTheSelectedTransactionType(string type)
        {
            bankingPage.SelectedTransactionTypeViewInAccountsPage(type);
        }


    }
}