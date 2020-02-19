using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Data;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Claims
{
    [Binding]
    [Scope(Feature = "ClaimsMangement")]
    public class ClaimsMangementSteps : StepBase
    {
        ClaimsDetailTab claimsDetailTab=new ClaimsDetailTab(driver);
        DataTable randomClaimRecords=new DataTable();

        [Then(@"'(.*)' page should be display")]
        public void ThenPageShouldBeDisplay(string headerName)
        {
            claimsDetailTab = ((ClaimsDetailTab)GetSharedPageObjectFromContext("Claims"));
            claimsDetailTab.GetClaimsMangementHeader().Should().Contain(headerName);            
        }
        [Given(@"I click on filter button")]
        [When(@"I click on filter button")]
        public void WhenIClickOnFilterButton()
        {
            claimsDetailTab = ((ClaimsDetailTab)GetSharedPageObjectFromContext("Claims"));
            claimsDetailTab.ClickFilterButton();
        }
        [Then(@"Table data should be present")]
        public void ThenTableDataShouldBePresent()
        {
            randomClaimRecords = claimsDetailTab.GetClaimRecords();
            randomClaimRecords.Should().NotBeNull();
        }
        [Then(@"'(.*)' should be able sorted")]
        public void ThenShouldBeAbleSorted(string columnName)
        {
            var list = claimsDetailTab.GetSortedList(columnName);
            list.Should().BeInDescendingOrder();
            list = claimsDetailTab.GetSortedList(columnName);
            list.Should().BeInAscendingOrder();
        }
        [Then(@"Page count should be display")]
        public void ThenPageCountShouldBeDisplay()
        {
            claimsDetailTab.GetPageCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Claims count is [{0}]" , claimsDetailTab.GetPageCount()));
        }
        [Then(@"pagination shouold be display")]
        public void ThenPaginationShouoldBeDisplay()
        {
            object value = null;            
            var pageInfo = claimsDetailTab.GetPagination();
            pageInfo.TryGetValue("Pagination", out value);
            ((bool)value).Should().BeTrue();                      
            pageInfo.TryGetValue("ActivePage", out value);
            (value).Should().NotBeNull();
        }
        [When(@"I enter Creditor '(.*)'")]
        public void WhenIEnterCreditor(string creditor)
        {
            claimsDetailTab.EnterCreditor(creditor);
        }
        [When(@"I click on Arrow Icon to see all sections")]
        public void WhenIClickOnArrowIconToSeeAllSections()
        {
            claimsDetailTab.ArrowIcon();
        }
        [When(@"I select Class '(.*)'")]
        public void WhenISelectClass(string claimClass)
        {
            claimsDetailTab.SelectClass(claimClass);
        }
        [When(@"I select Claim status '(.*)'")]
        public void WhenISelectClaimStatus(string claimStatus)
        {
            claimsDetailTab.SelectClaimStatus(claimStatus);
        }
        [When(@"I enter Balance from '(.*)'")]
        public void WhenIEnterBalanceFrom(string balanceFrom)
        {
            claimsDetailTab.EnterBalanceFrom(balanceFrom);
        }
        [When(@"I enter Balance to '(.*)'")]
        public void WhenIEnterBalanceTo(string BalanceTo)
        {
            claimsDetailTab.EnterBalanceTo(BalanceTo);
        }
        [When(@"I select Case status '(.*)'")]
        public void WhenISelectCaseStatus(string status)
        {
            claimsDetailTab.SelectCaseStatus(status);
        }
        [When(@"I click on close")]
        public void WhenIClickOnClose()
        {
            claimsDetailTab.ClickOnCloseButton();
        }

        [Then(@"Selected result should contains '(.*)' '(.*)' '(.*)' '(.*)'")]
        public void ThenSelectedResultShouldContains(string creditor, string claimClass, string claimFrom, string claimTo)
        {
            System.Threading.Thread.Sleep(1500);

            if (!string.IsNullOrWhiteSpace(creditor))
                claimsDetailTab.GetRecordsByColumnName("CREDITOR",creditor);

            if (!string.IsNullOrWhiteSpace(claimClass))
                claimsDetailTab.GetRecordsByColumnName("CLASS",claimClass);

            if (!string.IsNullOrWhiteSpace(claimFrom))
                claimsDetailTab.GetRecordsByColumnName("CLAIMED",claimFrom);

            if (!string.IsNullOrWhiteSpace(claimTo))
                claimsDetailTab.GetRecordsByColumnName("ALLOWED",claimTo);
        }
        [When(@"I click on Class x")]
        public void ThenIClickOnClassX()
        {
            claimsDetailTab.ClickClassX();
        }
        [When(@"I click on claim status x")]
        public void WhenIClickOnClaimStatusX()
        {
            claimsDetailTab.ClickClassStatusX();
        }
        [When(@"I click on case status x")]
        public void WhenIClickOnCaseStatusX()
        {
            claimsDetailTab.ClickCaseStatusX();
        }
        [When(@"Click on reset")]
        public void WhenClickOnReset()
        {
            claimsDetailTab.ClickOnResetButton();
        }
        [Then(@"Valid To Pay should be '(.*)'")]
        public void ThenValidToPayShouldBe(string value)
        {
            claimsDetailTab.GetValidToPay().Should().Contain(value);
        }
        [Then(@"default data should be present")]
        public void ThenDefaultDataShouldBePresent()
        {
            System.Threading.Thread.Sleep(2000);
            claimsDetailTab.GetClaimRecords().Should().Equals(randomClaimRecords);
        }
        [Then(@"verify the count on Grid")]
        public void VerifyCount()
        {
          claimsDetailTab.VerifyGridBeforeCount();
        }
        [Then(@"verify the after count on Grid")]
        public void VerifyAfterCount()
        {
           claimsDetailTab.VerifyGridAfterCount();
        }
        [When(@"I click on Add Claim")]
        public void ClickAddClaim()
        {
            claimsDetailTab.AddClaimClick();
        }
        [Then(@"I see subheader as '(.*)'")]
        public void subheaderverify(string subheader)
        {           
            claimsDetailTab.subheaderverify(subheader);
        }
        [When(@"I select Participant Type as '(.*)'")]
        public void selectParticipantType(string particpanttype)
        {
            claimsDetailTab.SelectParticipant(particpanttype);
        }
        [When(@"I click on Edit Claim")]
        public void clickEditClaim()
        {
            claimsDetailTab.ClickOnEditClaim();
        }
        [When(@"I click on delete button")]
        public void WhenIClickOnDeleteButton()
        {
            claimsDetailTab.ClickOnDeleteClaim();
        }

        [Then(@"I input Display name as '(.*)'")]
        public void InputName(string displayname)
        {
            claimsDetailTab.InputDisplayName(displayname);
        }
        //   
        [Then(@"I input case/debtor details as '(.*)'")]
        [Then(@"I search claim '(.*)'")]
        [Then(@"I input codesvalues information '(.*)'")]
        [Then(@"I input codesvalues Amounts information '(.*)'")]
        [Then(@"I input Payment Options & Additional Creditor Info '(.*)'")]
        [Then(@"I input Notes information '(.*)'")]
        [Then(@"I input Payment Options & Additional Creditor Checkboxes info '(.*)'")]
        [Then(@"I input details as '(.*)'")]
        [Then(@"I input Contact details as '(.*)'")]
        public void casedebtorfields(string fieldInputs)
        {           
            var inputEntries = fieldInputs.Split(';').Select(i => i.Trim()).ToList();
            claimsDetailTab.CaseDebtorfields(inputEntries);
        }
        [Then(@"I enter state as '(.*)'")]
        public void ThenIEnterStateAs(string state)
        {
            claimsDetailTab.EnterStateValue(state);
        }

        [When(@"I save claim")]
        public void Save()
        {           
            claimsDetailTab.Saveclaim();
            Thread.Sleep(5000);
        }
        [Then(@"the '(.*)', contains '(.*)'")]
        public void ThenTheContains(string header, string text)
        {
            claimsDetailTab.VerifyClaimsInLineEdit(header, text);
        }
        [Then(@"Claims InLineEdit Fields should be view only fields")]
        public void ThenClaimsInLineEditFieldsShouldBeViewOnlyFields()
        {
            claimsDetailTab.InLineEditViewOnly();
        }

        // Adding Steps for Export Functionality

        [When(@"I click On the EXPORT BUTTON")]
        public void WhenIClickOnTheEXPORTBUTTON()
        {
            claimsDetailTab.ClickOnExportList();

        }
        [Then(@"Validate the Text in the pop up.")]
        public void ThenValidateTheTextInThePopUpAs()
        {
            string actual =claimsDetailTab.ValidateTextInPopUp();
            actual.Contains("This action creates a spreadsheet of the Claims listed on all pages of this table");
        }
        [Then(@"Click on the EXPORT BUTTON on the pop up")]
        public void ThenClickOnTheEXPORTBUTTONOnThePopUp()
        {
            claimsDetailTab.ClickOnExport();           
        }
        [Then(@"Click on the CANCEL BUTTON on the pop up")]
        public void ThenClickOnTheCANCELBUTTONOnThePopUp()
        {
            claimsDetailTab.ClickOnCancelPopUp();
        }
        [Then(@"Validate that export button is disabled")]
        public void ThenValidateThatExportButtonIsDisabled()
        {
            claimsDetailTab.MouseHoverOnExportListButton();
        }
        [Then(@"I validate the toasted message is appeared")]
        public void ThenIValidateTheToastedMessageIsAppeared()
        {
            Thread.Sleep(1500);        
            string text = "Claims successfully exported.";
            claimsDetailTab.ValidateToastedMessage(text);
        }
        [Then(@"I validate the Pop Up is not appearaing")]
        public void ThenIValidateThePopUpIsNotAppearaing()
        {
            claimsDetailTab.ValidatePopUpNotAppear();
        }
        [Then(@"I can click on delete button in the Claims Page")]
        public void ThenICanClickOnDeleteButtonInTheClaimsPage()
        {
            claimsDetailTab.DeleteFuntionality();
        }
        [Then(@"I can click on delete button in the Claim Page")]
        public void ThenICanClickOnDeleteButtonInTheClaimPage()
        {
            claimsDetailTab.DeleteFuntionality();
        }
        [Given(@"I can select first record in Claim page")]
        public void GivenICanSelectFirstRecordInClaimPage()
        {
            claimsDetailTab.SelectFirstRecord();
        }
        [When(@"I click on PAID column '(.*)'")]
        public void IclickonPaidolumn(string paidAmount)
        {
            claimsDetailTab.ClickPaidColumn(paidAmount);
        }
        [Then(@"verify the label '(.*)'")]
        public void verifythelabel(string label)
        {
            claimsDetailTab.VerifyLabel(label);
        }
        [Then(@"I click '(.*)' Button")]
        public void IClickCloseButton(string label)
        {
            claimsDetailTab.ClickButton(label);
        }
        [Then(@"click on expand symbol and verify the columns as '(.*)'")]
        public void ClickExpandAndVerifyTheColumn(string label)
        {
            claimsDetailTab.ExpandColumnVerify(label);
        }
        [Then(@"click Edit Icon")]
        public void ClickEditIcon()
        {
            claimsDetailTab.ClickEdit();
        }
        [Then(@"verify the page header '(.*)'")]
        public void VerifyPageHeader(string header)
        {
            claimsDetailTab.VerifyPageHeader(header);
        }

        [Then(@"Schedule to Claim Management Breadcrumbs should be displayed")]
        public void ScheduleToClaimManagementBreadcrumb()
        {
            claimsDetailTab.ScheduleToClaimManagementBreadcrumb();
        }

        [Then(@"I see the fields in Schedule to Claim Management page as CaseNumber '(.*)', Debtor '(.*)', Claims '(.*)',Schedules '(.*)',Unreconciled '(.*)',Status '(.*)',Case '(.*)'")]
        public void VerifyFieldsInSCheduleToClaimManagementPage(string casenum, string debt, string claim, string schedule, string unreconciled, string status, string casestatus)
        {
            claimsDetailTab.VerifyFieldsInSCheduleToClaimManagementPage(casenum, debt, claim, schedule, unreconciled, status, casestatus);

        }

        [Then(@"verify the Schedule to Claim Management page UI count")]
        public void VerifyScheduleToClaimManagementPageUICount()
        {
            claimsDetailTab.VerifyScheduleToClaimManagementPageUICount();
        }

        [Then(@"verify the Schedule to Claim Management page count from Database")]
        public void VerifyScheduleToClaimManagementPageDBCount()
        {
            claimsDetailTab.VerifyScheduleToClaimManagementPageDBCount();
        }
        [Given(@"I click on filter in Schedule to Claim Reconciliation page")]
        public void ClickOnFilterInScheduleToClaimReconciliationPage()
        {
            claimsDetailTab.ClickOnFilterInScheduleToClaimReconciliationPage();
        }
        [Then(@"I verify default data in filter options as AllClaimsReconciled '(.*)', AssetStatus '(.*)', CaseStaus '(.*)'")]
        public void VerifyDefaultDataInFilterOptions(string allclaimsreconcile, string asset, string cstatus)
        {
            claimsDetailTab.VerifyDefaultDataInFilterOptions(allclaimsreconcile, asset, cstatus);
        }
        [Then(@"I verify data in filter options in Schedule to Claim Reconciliation page")]
        public void VerifyDataInFilterOptions()
        {
            claimsDetailTab.VerifyDataInFilterOptions();
        }
        [Then(@"I select  AllClaimsReconciled '(.*)', AssetStatus '(.*)', CaseStaus '(.*)'")]
        public void FilterOptions(string allclaimsreconcile, string asset, string cstatus)
        {
            claimsDetailTab.FilterOptions(allclaimsreconcile, asset, cstatus);
        }
        [Then(@"I verify Table Header when AllClaimsReconciled '(.*)'")]
        public void VerifyTableHeaderReconciled(string allclaimsreconcile)
        {
            claimsDetailTab.VerifyTableHeaderReconciled(allclaimsreconcile);
        }
        [Then(@"I verify Table Header when AllClaimsReconciled as '(.*)'")]
        public void VerifyTableHeaderUnReconciled(string allclaimsreconcile)
        {
            claimsDetailTab.VerifyTableHeaderUnReconciled(allclaimsreconcile);
        }
        [Then(@"I verify message when there are no results to display in the grid '(.*)'")]
        public void VerifyMessageInTheGrid(string message)
        {
            claimsDetailTab.VerifyMessageInTheGrid(message);
        }

        [Then(@"I click Reset in filter")]
        public void ClickResetInFilter()
        {
            claimsDetailTab.ClickResetInFilter();
        }
        [Then(@"I verify message '(.*)'")]
        public void VerifyMessageForAllCases(string message)
        {
            claimsDetailTab.VerifyMessageForAllCases(message);
        }

        //[When(@"I click on case number '(.*)' UnreconciledLink")]
        //public void ClickOnCaseNumberUnreconciledLink(string casenum)
        //{
        //    claimsDetailTab.ClickOnCaseNumberUnreconciledLink(casenum);
        //}
        [When(@"I select document")]
        public void WhenISelectDocument()
        {
            claimsDetailTab.SelectDocument();
        }
        [Then(@"I click on Document view")]
        public void ThenIClickOnDocumentView()
        {
            claimsDetailTab.ClickDocumentView();
        }
        [Then(@"I see the document details '(.*)'")]
        public void ThenISeeTheDocumentDetails(string documentDetails)
        {
            claimsDetailTab.VerifyDocumentDetails(documentDetails);
        }
        [Then(@"I click on Unreconciled link for case number '(.*)'")]
        public void ClickOnUnreconciledLink(string casenum)
        {
            claimsDetailTab.ClickOnUnreconciledLink(casenum);
        }
        [Then(@"I select Schedules in Claim Reconciliation page")]
        public void SelectSchedulesInClaimReconciliationPage()
        {
            claimsDetailTab.SelectSchedulesInClaimReconciliationPage();
        }
        [Then(@"I verify Schedules Link button and X button at the bottom of the screen")]
        public void VerifySchedulesLinkButtonAndXButton()
        {
            claimsDetailTab.VerifySchedulesLinkButtonAndXButton();
        }
        [Then(@"I select Claims in Claim Reconciliation page")]
        public void SelectClaimsInClaimReconciliationPage()
        {
            claimsDetailTab.SelectClaimsInClaimReconciliationPage();
        }
        [Then(@"I verify Claims Link button and X button at the bottom of the screen")]
        public void VerifyClaimsLinkButtonAndXButton()
        {
            claimsDetailTab.VerifyClaimsLinkButtonAndXButton();
        }
        [Then(@"I select schedule and claim in Claim Reconciliation page")]
        public void SelectScheduleAndClaim()
        {
            claimsDetailTab.SelectScheduleAndClaim();
        }
        [Then(@"I click LINK button in Claim Reconciliation page")]
        public void ClickLinkButtonInClaimReconciliationPage()
        {
            claimsDetailTab.ClickLinkButtonInClaimReconciliationPage();
        }
        [Then(@"I click UNLINK button in Claim Reconciliation page")]
        public void ClickUnlinkButtonInClaimReconciliationPage()
        {
            claimsDetailTab.ClickUnlinkButtonInClaimReconciliationPage();
        }
        [Then(@"verify the columns from '(.*)' to '(.*)' displayed on '(.*)' as '(.*)' in Transactions Linked to Claim page")]
        public void VerifyColumnsInTransactionsLinkedToClaimPage(int colStartIndex, int colEndIndex, string page, string columns)
        {
            var inputEntries = columns.Split(';').Select(i => i.Trim()).ToList();
            claimsDetailTab.VerifyColumnsInTransactionsLinkedToClaimPage(colStartIndex, colEndIndex, inputEntries, page);
        }
        [Then(@"I click LINK in Link Case Documents page")]
        public void ClickOnLinkButtonInLinkCaseDocumentsPage()
        {
            claimsDetailTab.ClickOnLinkButtonInLinkCaseDocumentsPage();
        }
    }


}


