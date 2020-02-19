using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Assets;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.CaseLevelNavigation;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.CaseLevelNavigation
{
    [Binding]
    public class CaseLevelNavigationSteps : StepBase
    {
        CaseLevelNavigationPage caseLevelNav = new CaseLevelNavigationPage(driver);
        AssetsDetailTab assetsDetailTab = new AssetsDetailTab(driver);
        AddAsset addAsset = new AddAsset(driver);
        EditAsset editAsset = new EditAsset(driver);
        ViewAsset viewAsset = new ViewAsset(driver);

        [Given(@"I see the search box in Darker blue")]
        public void GivenISeeTheSearchBoxInDarkerBlue()
        {
            caseLevelNav.AllCasesBGColor();
        }
        [When(@"I see the box in LightBlue")]
        public void WhenISeeTheBoxInLightBlue()
        {
            caseLevelNav.CaseBGColor();
        }
        [When(@"I clear the box and I see text '(.*)'")]
        public void WhenIClearTheBoxAndISeeText(string expectedheader)
        {
            caseLevelNav.ClearBox(expectedheader);
        }
        [Then(@"I see the DebtorName '(.*)' and CaseNum '(.*)'")]
        public void ThenISeeTheDebtorNameAndCaseNum(string expecteddebName, string expectedcaseNum)
        {
            caseLevelNav.VerifyDetails(expecteddebName, expectedcaseNum);
        }
        [Then(@"I see case as '(.*)' in green")]
        public void ThenISeeCaseAsInGreenAndInOrange(string state)
        {
            caseLevelNav.VerifyStates(state);
        }
        [Then(@"CaseType as '(.*)' in Orange")]
        public void ThenCaseTypeAsInOrange(string type)
        {
            caseLevelNav.VerifyType(type);
        }
        [Then(@"I see the table with title '(.*)'")]
        public void ThenISeeTheTableWithTitle(string expectedtitle)
        {
            caseLevelNav.VerifySummaryTitle(expectedtitle);
        }
        [Then(@"I see the value under '(.*)' as '(.*)'")]
        public void ThenISeeTheValueUnderAs(string SchdText, string expectedValue)
        {
            caseLevelNav.ScheduleDetails(SchdText, expectedValue);
        }
        [Then(@"I see '(.*)' as '(.*)'")]
        public void ThenISeeAs(string NetValTxt, string expectedValue)
        {
            caseLevelNav.NetValueDetails(NetValTxt, expectedValue);
        }
        [Then(@"I see '(.*)' value as '(.*)'")]
        public void ThenISeeValueAs(string AbandonText, string expectedValue)
        {
            caseLevelNav.AbandonedDetails(AbandonText, expectedValue);
        }
        [Then(@"I see the value of '(.*)' as '(.*)'")]
        public void ThenISeeTheValueOfAs(string salesTxt, string expectedValue)
        {
            caseLevelNav.SalesDetails(salesTxt, expectedValue);
        }
        [Then(@"I see '(.*)' with value '(.*)'")]
        public void ThenISeeWithValue(string RemTxt, string expectedValue)
        {
            caseLevelNav.RemainingDetails(RemTxt, expectedValue);
        }
        [Then(@"I verify Asset Details Description '(.*)' and Petition '(.*)'")]
        public void ThenIVerifyAssetDetailsDescriptionAndPetition(string description, string petition)
        {
            caseLevelNav.verifyAssetDetails(description, petition);
        }
        [Then(@"I see the value '(.*)' as '(.*)'")]
        public void ThenISeeTheValueAs(string Text, string expectedValue)
        {
            caseLevelNav.EstateDetails(Text, expectedValue);
        }
        [Then(@"'(.*)' as '(.*)'")]
        public void ThenAs(string Text, string expectedValue)
        {
            caseLevelNav.ValidToPayDetails(Text, expectedValue);
        }
        [Then(@"I see '(.*)' details as '(.*)'")]
        public void ThenISeeDetailsAs(string Text, string expectedValue)
        {
            caseLevelNav.PaidDetails(Text, expectedValue);
        }
        [Then(@"I See the '(.*)' value '(.*)'")]
        public void ThenISeeTheValue(string Text, string expectedValue)
        {
            caseLevelNav.ReservedDetails(Text, expectedValue);
        }
        [Then(@"the '(.*)' value as '(.*)'")]
        public void ThenTheValueAs(string Text, string expectedValue)
        {
            caseLevelNav.ClaimsBalanceDetails(Text, expectedValue);
        }
        [Then(@"I verify Claims Details Creditor '(.*)' and Class '(.*)'")]
        public void ThenIVerifyClaimsDetailsCreditorAndClass(string creditor, string Class)
        {
            caseLevelNav.VerifyClaimsDetails(creditor, Class);
        }
        [Then(@"I verify DSO Claimants details Name '(.*)' and Address '(.*)'")]
        public void ThenIVerifyDSOClaimantsDetailsNameAndAddress(string name, string add)
        {
            caseLevelNav.VerifyDSODetails(name, add);
        }
        [Then(@"I verify Task Details Type '(.*)', Notes '(.*)' and Assigned To '(.*)'")]
        public void ThenIVerifyTaskDetailsTypeAndAssignedTo(string type, string notes, string assign)
        {
            caseLevelNav.VerifyTaskDetails(type, notes, assign);
        }
        [When(@"I see Received From '(.*)' and Amount '(.*)'")]
        public void WhenISeeReceivedFromAndAmount(string name, string amt)
        {
            caseLevelNav.VerifyReceiptLogDetails(name, amt);
        }
        [When(@"I click on DEBTOR NAME link")]
        public void clickDebtorName()
        {
            caseLevelNav.clickDebtorName();

        }
        [When(@"I click on expand link")]
        public void ClickExpandlink()
        {
            caseLevelNav.ClickExpand();
        }
        [When(@"I click on CASE# link")]
        public void ClickCaseLink()
        {
            caseLevelNav.ClickCase();
        }
        [When(@"I validate the Count of '(.*)'")]
        public void WhenIValidateTheCountOf(string field)
        {
            caseLevelNav.GetValidToPayCount(field);
        }
        [When(@"I validate the '(.*)' Count")]
        public void WhenIValidateTheCount(string field)
        {
            caseLevelNav.GetPaidCount(field);
        }

        [When(@"I click on Add Asset on specific case level")]
        public void WhenIClickOnAddAssetOnSpecificCaseLevel()
        {
            addAsset.ClickOnAddAsset();
        }

        [Then(@"I see the Page Header Title as '(.*)'")]
        public void ThenISeeThePageHeaderTitleAs(string title)
        {
            addAsset.HeaderTitle(title);
        }

        [Then(@"Add Asset page should be display")]
        public void ThenAddAssetPageShouldBeDisplayed()
        {
            addAsset.BackToAssets.Should().BeTrue();
        }

        [When(@"I Click on Back To Assets")]
        public void WhenIClickOnBackToAssets()
        {
            addAsset.ClickBackToAssetsLink();
        }

        [When(@"I click on Edit Assset button on a specific case level")]
        public void WhenIClickOnEditAsssetButtonOnASpecificCaseLevel()
        {
            editAsset.ClickEditPencilButton();
        }

        [When(@"I click on View Assset button on a specific case level")]
        public void WhenIClickOnViewAsssetButtonOnASpecificCaseLevel()
        {
            viewAsset.ClickViewEyeButton();
        }
        

        [Then(@"the Receipts count should display")]
        public void ThenTheReceiptsCountShouldDisplay()
        {
            caseLevelNav.GetPageCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Receipts count is [{0}]", caseLevelNav.GetPageCount()));
        }
        [Then(@"I should not be able to see '(.*)' and '(.*)' in Case Level View")]
        public void ThenIShouldNotBeAbleToSeeAndInCaseLevelView(string CaseNo, string debtorName)
        {
            caseLevelNav.verifyColumns(CaseNo, debtorName);
        }
        [Then(@"I mark the debtor '(.*)', '(.*)' as verified")]
        public void ThenIMarkTheCaseAsVerified(string debtor, int num)
        {
            caseLevelNav.MarkReceipt(debtor, num);
        }
        [Then(@"I see case '(.*)' as Verified")]
        public void ThenISeeCaseAsVerified(string debtor)
        {
            caseLevelNav.VerifyMarkedAsGreen(debtor);
        }
        [Then(@"I should not be able to see '(.*)' and '(.*)' in CaseLevel")]
        public void ThenIShouldNotBeAbleToSeeAndInCaseLevel(string CaseOrDebtor, string CaseStatus)
        {
            caseLevelNav.VerifyFilterInCaseLevel(CaseOrDebtor, CaseStatus);
        }
        [When(@"I select Voided '(.*)'")]
        public void WhenISelectVoided(string VoidedType)
        {
            caseLevelNav.SelectVoided(VoidedType);
        }
        [When(@"I verify Transaction Link of Received From '(.*)'")]
        public void WhenIVerifyTransactionLinkOfReceivedFrom(string ReceivedFrom)
        {
            caseLevelNav.VerifyLinkedStatus(ReceivedFrom);
        }
        [Then(@"I see CaseNumber is ReadOnly Field")]
        public void ThenISeeCaseNumberIsReadOnlyField()
        {
            caseLevelNav.VerifyCaseNumReadOnly();
        }
        [When(@"I See the Add Receipt is in Disabled State")]
        public void WhenISeeTheAddReceiptIsInDisabledState()
        {
            caseLevelNav.AddReceiptDisabledState();
        }
        [Then(@"I Select transaction Received from '(.*)'")]
        public void ThenISelectTransactionReceivedFrom(string ReceivedFrom)
        {
            caseLevelNav.ReceivedFrom(ReceivedFrom);
        }
        [Then(@"I click on '(.*)'")]
        public void ThenIClickOn(string Type)
        {
            caseLevelNav.SelectTransactionType(Type);
        }
        [Then(@"I clicked on '(.*)'")]
        public void ThenIClickedOn(string Button)
        {
            caseLevelNav.ClickButton(Button);
        }

        [Then(@"I click '(.*)'")]
        public void ThenIClick(string button)
        {
            caseLevelNav.SelectButton(button);
        }
        [Then(@"I select PERMIT ASSET IMBALANCE")]
        public void ThenISelectPERMITASSETIMBALANCE()
        {
            caseLevelNav.SelectButtonOn();
        }
        [Then(@"I see '(.*)' in disabled state")]
        public void ThenISeeInDisabledState(string status)
        {
            caseLevelNav.VerifyDisabledState(status);
        }
        [Then(@"I see '(.*)' In Enabled state")]
        public void ThenISeeInEnabledState(string EnableStatus)
        {
            caseLevelNav.VerifyEnabledState(EnableStatus);
        }
        [Then(@"I should not be able to see Pencil Icon")]
        public void WhenIShouldNotBeAbleToSeePencilIcon()
        {
            caseLevelNav.PencilIcon();
        }
        [When(@"I Edit Received From '(.*)'")]
        public void WhenIEditReceivedFrom(string ReceivedFrom)
        {
            caseLevelNav.EditByReceivedFrom(ReceivedFrom);
        }
        [Then(@"I click on Link Transaction")]
        public void ThenIClickOnLinkTransaction()
        {
            caseLevelNav.ClickLinkTransaction();
        }
        [Then(@"I click on Link Claim")]
        public void ClickLinkClaim()
        {
            caseLevelNav.ClickLinkClaim();
        }

        [Then(@"I link transaction '(.*)'")]
        public void ThenILinkTransaction(string transaction)
        {
            caseLevelNav.LinkTransaction(transaction);
        }
        [Then(@"I link Claim")]
        public void LinkClaim()
        {
            caseLevelNav.LinkClaim();
        }

        [When(@"I verify Linked Details '(.*)'")]
        public void WhenIVerifyLinkedDetails(string details)
        {
            var fields = details.Split(';').Select(i => i.Trim()).ToList();
            caseLevelNav.VerifyFields(fields);
        }
        [Then(@"I unlink the transaction")]
        public void ThenIUnlinkTheTransaction()
        {
            caseLevelNav.UnLinkTransaction();
        }
        [Then(@"I see partial AccountNum for '(.*)' as '(.*)'")]
        public void ThenISeePartialAccountNumForAs(string transaction, string AccNum)
        {
            caseLevelNav.VerifyPartialAccNum(transaction, AccNum);
        }
        [Then(@"I Cancel the Link Transaction")]
        public void ThenICancelTheLinkTransaction()
        {
            caseLevelNav.CancelLinkTransaction();
        }
        [When(@"the Select the Account Num '(.*)'")]
        public void WhenTheSelectTheAccountNum(Decimal AccNum)
        {
            caseLevelNav.SelectAccountNum(AccNum);
        }
       
        [When(@"I click on Issue Link '(.*)'")]
        public void WhenIClickOnIssueLink(string Link)
        {
            caseLevelNav.ClickIssueLink(Link);
        }
        [Then(@"I see '(.*)' page is displayed")]
        public void ThenISeePageIsDisplayed(string page)
        {
            caseLevelNav.IssueReconciliationPage(page).Should().BeTrue(page);
        }
        [Then(@"I Select the Bank Transactions SerialNum '(.*)' and Ledger Transactions SerialNum '(.*)'")]
        public void ThenISelectTheBankTransactionsSerialNumAndLedgerTransactionsSerialNum(string BankSerial, string LedgerSerial)
        {
            caseLevelNav.SelectTransactionsBySerialNum(BankSerial, LedgerSerial);
        }
        [Then(@"I select '(.*)' under '(.*)' dropdown")]
        public void ThenISelectUnderDropdown(string linkType, string transaction)
        {
            caseLevelNav.BankDropdown(linkType, transaction);
        }
        [Then(@"I select PageSize '(.*)' for BANK TRANSACTIONS")]
        public void ThenISelectPageSizeForBANKTRANSACTIONS(int size)
        {
            caseLevelNav.BankTransactionsPageSize(size);
        }
        [Then(@"I sort '(.*)' serialNo")]
        public void ThenISortSerialNo(string p0)
        {
            caseLevelNav.ClickSortingControls(p0);
        }

        [Then(@"I select PageSize '(.*)' for LEDGER TRANSACTIONS")]
        public void ThenISelectPageSizeForLEDGERTRANSACTIONS(int size)
        {
            caseLevelNav.LedgerPageSize(size);
        }
        [When(@"I see the Fields as ReadOnly")]
        public void WhenISeeTheFieldsAsReadOnly()
        {
            caseLevelNav.VerifyFieldsAsReadOnly();
        }
        [When(@"I see the Summary header in LightBlue")]
        public void WhenISeeTheSummaryHeaderInLightBlue()
        {
            caseLevelNav.CaseBGColor();
        }
        [When(@"I see table header in LightBlue")]
        public void WhenISeeTableHeaderInLightBlue()
        {
            caseLevelNav.CaseBGColor();
        }
        [When(@"I select Tasks as '(.*)'")]
        public void WhenISelectTasksAs(string type)
        {
            caseLevelNav.SelectTaskType(type);
        }
        [Then(@"I Sould be able to edit '(.*)' description '(.*)'")]
        public void ThenISouldBeAbleToEditDescription(int num, string text)
        {
            caseLevelNav.DocumentDescInLineEdit(num, text);
        }
        [Then(@"I see the Description '(.*)' contains '(.*)' and '(.*)' Tag '(.*)'")]
        public void ThenISeeTheDescriptionContainsAndTag(int i, string desc, int j, string tag)
        {
            caseLevelNav.InlineEditValidateText(i, desc, j, tag);
        }
        [Then(@"I edit '(.*)' Tag '(.*)'")]
        public void ThenIEditTag(int num, string tag)
        {
            caseLevelNav.TagInLineEdit(num, tag);
        }
        [When(@"I expand the Document")]
        public void WhenIExpandTheDocument()
        {
            caseLevelNav.ExpandDocument();
        }
        [Then(@"I edit '(.*)' as '(.*)'")]
        public void ThenIEditAs(string header, string text)
        {
            caseLevelNav.EditDescription(header, text);
        }
        [Then(@"I edit input '(.*)' as '(.*)' and Source '(.*)'")]
        public void ThenIEditInputAsAndSource(string header, string text, string source)
        {
            caseLevelNav.InputAndEditSource(header, text, source);
        }
        [Then(@"I input the '(.*)' as '(.*)' and Source '(.*)'")]
        public void ThenIInputTheAsAndSource(string header, string text, string source)
        {
            caseLevelNav.InputAndEditDoc(header, text, source);
        }

        [Then(@"I edit the ASSIGNED TO as '(.*)'")]
        public void ThenIEditTheASSIGNEDTOAs(string text)
        {
            caseLevelNav.EditFields(text);
        }

        [When(@"I Edit row with Description '(.*)'")]
        public void WhenIEditRowWithDescription(string description)
        {
            caseLevelNav.EditWithDescription(description);
        }
        [When(@"I click on breadcrumb '(.*)'")]
        public void WhenIClickOnBreadcrumb(string breadCrumb)
        {
            caseLevelNav.DocumentBreadCrumb(breadCrumb);
        }

        [Then(@"I see Debtor Attorney '(.*)'")]
        public void ThenISeeDebtorAttorney(string attorney)
        {
            caseLevelNav.VerifyDebtorAttorney(attorney);
        }
        [Then(@"I see the History Column")]
        public void ThenISeeTheHistoryColumn()
        {
            caseLevelNav.VerifyHistoryColumn();
        }
        [Then(@"I see '(.*)' Table header contains '(.*)'")]
        public void ThenISeeTableHeaderContains(string page, string titles)
        {
            var TableTitles = titles.Split(';').Select(i => i.Trim()).ToList();
            caseLevelNav.VerifyCaseLevelPageTableColumns(TableTitles,page);
        }
        [Then(@"I see the Print in Disabled State")]
        public void ThenISeeThePrintInDisabledState()
        {
            caseLevelNav.VerifyPrintDisabledState();
        }
        [When(@"I select the transaction and I see Print in Enabled State")]
        public void WhenISelectTheTransactionAndISeePrintInEnabledState()
        {
            caseLevelNav.VerifyPrintInEnabledState();
        }
        [When(@"I click on History button")]
        public void WhenIClickOnHistoryButton()
        {
            caseLevelNav.SelectHistoryButton();
        }
        [Then(@"I see table header text '(.*)'")]
        public void ThenISeeTableHeaderText(string header)
        {
            caseLevelNav.VerifyHistoryTableHeader(header);
        }
        [When(@"I Cilck on calculator button in header")]
        public void WhenICilckOnCalculatorButtonInHeader()
        {
            caseLevelNav.ClickOnCalculatorButton();
        }
        [Then(@"I enter the additional compensation amount under Calulated and forecast tab")]
        public void ThenIEnterTheAdditionalCompensationAmountUnderCalulatedAndForecastTab()
        {
            caseLevelNav.EnterAdditionalCompensationValues();
        }

        [Then(@"I click freeze compensesation and enter the value into it")]
        public void ThenIClickFreezeCompensesationAndEnterTheValueIntoIt()
        {
            caseLevelNav.ClickonFreezeCompensationButton();
        }

        [Then(@"I click on Close button on pop up")]
        public void ThenIClickOnCloseButtonOnPopUp()
        {
            caseLevelNav.ClickOnCloseButton();
        }
        [Then(@"I click on By Date Tab")]
        public void ThenIClickOnByDateTab()
        {
            caseLevelNav.ClickOnByDateTab();
        }

        [Then(@"I enter the transaction dates")]
        public void ThenIEnterTheTransactionDates()
        {
            caseLevelNav.EnterTheTransactionDates();
        }


        [Then(@"I see the Print Icon")]
        public void ThenISeeThePrintIcon()
        {
            caseLevelNav.VerifyPrintIcon();
        }
        
        [When(@"I enter the Description '(.*)'")]
        public void WhenIEnterTheDescription(string desc)
        {
            caseLevelNav.EditDescription(desc);
        }

        [Then(@"I edit the TAGS as '(.*)'")]
        public void ThenIEditTheTAGSAs(string tag)
        {
            caseLevelNav.EditTags(tag);
        }
        [Then(@"I Click on Comp/Expense Details button")]
        public void ClickOnCompExpenseDetailsButton()
        {
            caseLevelNav.ClickOnCompExpenseDetailsButton();
        }
        [Then(@"I Click  on Expenses")]
        public void ClickOnExpenses()
        {
            caseLevelNav.ClickOnExpenses();
        }
        [Then(@"I verify the number of expenses in the grid")]
        public void VerifyTheNumberOfExpensesInTheGrid()
        {
            caseLevelNav.VerifyTheNumberOfExpensesInTheGrid();
        }
        [Then(@"I verify '(.*)','(.*)', '(.*)', '(.*)' in Expenses Summary")]
        public void VerifyFieldsInExpensesSummary(string expenses, string paid, string balance, string amount)
        {
            caseLevelNav.VerifyFieldsInExpensesSummary(expenses, paid, balance, amount);
        }
        [Then(@"I Verify columns '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)','(.*)' in Expenses")]
        public void ThenIVerifyColumnsInExpenses(string date, string type, string uom, string price, string qty, string total, string notes)
        {
            caseLevelNav.VerifyColumnsInExpenses(date, type, uom, price, qty, total, notes);
        }
        [Then(@"I verify default data in filter options as ExpenseType '(.*)'")]
        public void VerifyDefaultDataInFilterOptionsExpenseType(string type)
        {
            caseLevelNav.VerifyDefaultDataInFilterOptionsExpenseType(type);
        }
        [Then(@"I edit expenses DATE OF EXPENSE '(.*)', EXPENSE TYPE '(.*)', UNIT OF MEASURE '(.*)', REMARKS '(.*)', QTY '(.*)', UNIT PRICE '(.*)'")]
        public void EditExpenses(string date, string type, string measure, string remark, string qty, string price)
        {
            caseLevelNav.EditExpenses(date, type, measure, remark, qty, price);
        }
        [Then(@"I select X in the Global Case Navigation")]
        public void SelectXInTheGlobalCaseNavigation()
        {
            caseLevelNav.SelectXInTheGlobalCaseNavigation();
        }
        [Then(@"I select All Cases in the Global Case Navigation")]
        public void SelectAllCasesInTheGlobalCaseNavigation()
        {
            caseLevelNav.SelectAllCasesInTheGlobalCaseNavigation();
        }
        [Then(@"user will be navigated to the Case they selected '(.*)' and the Page Navigation will read Trustee '(.*)'")]
        public void NavigatedToTrusteeExpenses(string casenum, string expenses)
        {
            caseLevelNav.NavigatedToTrusteeExpenses(casenum, expenses);
        }
        [Then(@"I verify message '(.*)'")]
        public void VerifyMessageWhenNoResultsInGrid(string msg)
        {
            caseLevelNav.VerifyMessageWhenNoResultsInGrid(msg);
        }
        [Then(@"I click on Bank Accounts in Breadcrumb")]
        public void ClickOnBankAccountsInBreadcrumb()
        {
             caseLevelNav.ClickOnBankAccountsInBreadcrumb();
        }
        [Then(@"I select '(.*)' under LEDGER TRANSACTIONS dropdown in Issue Reconciliation")]
        public void SelectLedgerTransactionsInDropdown(string linkType)
        {
            caseLevelNav.SelectLedgerTransactionsInDropdown(linkType);
        }
        [Then(@"I Click on Export button")]
        public void ThenIClickOnExportButton()
        {
            caseLevelNav.ClickOnExportButton();
        }

    }
}

