using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Case_List;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Case_List
{
    class NewCaseListSearchSteps : StepBase
    {
        private NewCaseListSearchPage CaseListSearch = new NewCaseListSearchPage(driver);
        [When(@"I click on filter search Icon")]
        [Given(@"I click on filter search Icon")]
        public void GivenIClickOnFilterSearchIcon()
        {
            CaseListSearch.SearchFilterIcon();
        }
       [Then(@"mouseover on the debtor column in case lists")]
        public void ThenMouseoverOnTheDebtorColumnInCaseLists()
        {
            CaseListSearch.MouseHouver();
        }
        [When(@"I Perform the Search of Cases with '(.*)' as Case Number")]
        public void WhenIPerformTheSearchOfCasesWithAsCaseNumber(string caseNum)
        {
            CaseListSearch.EnterCaseNumber(caseNum);
        }
        [When(@"I Perform the Search of Cases with '(.*)' Case Number")]
        public void WhenIPerformTheSearchOfCasesWithCaseNumber(string caseNum)
        {
            CaseListSearch.EnterCaseNumber(caseNum);
            CaseListSearch.SelectCaseList();
        }
        [When(@"I Perform the Search of Cases with '(.*)' Case Name")]
        public void WhenIPerformTheSearchOfCasesWithCaseName(string CaseName)
        {
            CaseListSearch.EnterCaseName(CaseName);
            CaseListSearch.SelectCaseList();
        }
        [When(@"I close the Filter Options")]
        [Then(@"I close the Filter Options")]
        public void WhenICloseTheFilterOptions()
        {
            CaseListSearch.CloseFilterOptions();
        }
        [Then(@"I see the Cases with same CaseNumber as '(.*)'")]
        public void ThenISeeTheCasesWithSameCaseNumberAs(string CaseNumber)
        {
            CaseListSearch.CasesWithSameCaseNumber(CaseNumber);
        }
        [Then(@"I see the Cases with CaseName same as '(.*)'")]
        public void ThenISeeTheCasesWithCaseNameSameAs(string caseName)
        {
            CaseListSearch.CasesWithSameCaseName(caseName);
        }
        [When(@"I enter Dates '(.*)' as '(.*)' and '(.*)' as '(.*)'")]
        public void WhenIEnterDatesAsAndAs(string titleFrom, string DateFrom, string titleTo, string DateTo)
        {
            CaseListSearch.EnterDates(titleFrom, DateFrom, titleTo, DateTo);
        }
        [Then(@"I see the Cases between the given '(.*)','(.*)', '(.*)' and '(.*)'")]
        public void ThenISeeTheCasesBetweenTheGivenAnd(string title, int j, string fromdate, string todate)
        {
            CaseListSearch.FiltereddataonGrid(title, j, fromdate, todate);
        }
        [Then(@"I see the Cases between the given Claims Bar Dates")]
        public void ThenISeeTheCasesBetweenTheGivenClaimsBarDates()
        {
            CaseListSearch.CasesWithClaimsDates();
        }
        [When(@"I select ASSETStatus as '(.*)'")]
        [Given(@"I select ASSETStatus as '(.*)'")]
        public void GivenISelectASSETStatusAs(string assetStatus)
        {
           CaseListSearch.SelectAssetStatus(assetStatus);
        }
        [When(@"I select CASE Status as '(.*)'")]
        [Given(@"I select CASE Status as '(.*)'")]
        public void GivenISelectCASEStatusAs(string caseStatus)
        {
            CaseListSearch.SelectCaseStaus(caseStatus);
        }
        [When(@"I select FeePaid as '(.*)'")]
        [Given(@"I select FeePaid as '(.*)'")]
        public void GivenISelectFeePaidAs(string feepaid)
        {
           CaseListSearch.SelectFeePaid(feepaid);
        }
        [Then(@"I see the ASSETStatus column as '(.*)'")]
        public void ThenISeeTheASSETStatusColumnAs(string assetColumn)
        {
            CaseListSearch.AssetColumnData(assetColumn);
        }
        [Then(@"CASEStatus column as '(.*)'")]
        public void ThenCASEStatusColumnAs(string caseStatusColumn)
        {
            CaseListSearch.CaseStatusColumnData(caseStatusColumn);
        }
        [When(@"I Click Reset Button")]
        public void WhenIClickResetButton()
        {
            CaseListSearch.ClickOnReset();
        }
        [Then(@"I Click on Close Button")]
        public void ThenIClickOnCloseButton()
        {
            CaseListSearch.ClickOnClose();
        }
        [Then(@"I see the Cases found in the Case Table")]
        public void ThenISeeTheCasesFoundInTheCaseTable()
        {
            CaseListSearch.CasesInCaseTable();
        }
        [When(@"I click on Case Expand Button to see all columns")]
        public void WhenIClickOnCaseExpandButtonToSeeAllColumns()
        {
            CaseListSearch.ClickOnCaseExpandButton();
        }
        [When(@"I click on Fee Paid Checkbox")]
        public void WhenIClickOnFeePaidCheckbox()
        {
            CaseListSearch.ClickOnFeePaidCheckbox();
        }
        [Then(@"I enter Fee Amount'(.*)'")]
        public void ThenIEnterFeeAmount(string feeAmt)
        {
            CaseListSearch.EnterFeeAmount(feeAmt);
        }
        [Then(@"I enter Fee Paid '(.*)'")]
        public void ThenIEnterFeePaid(string feePaid)
        {
            CaseListSearch.EnterFeePaid(feePaid);
        }
        [Then(@"I enter Date Paid '(.*)'")]
        public void ThenIEnterDatePaid(string date)
        {
            CaseListSearch.EnterDatePaid(date);
        }
        [Then(@"I Click On Save Button on Case Fee")]
        public void ThenIClickOnSaveButtonOnCaseFee()
        {
            CaseListSearch.ClickOnCaseFeeSAVE();
        }
        [Then(@"Close Button Should be displayed")]
        public void ThenCloseButtonShouldBeDisplayed()
        {
            CaseListSearch.VerifyCLOSE_Button().Equals(1);
        }
        [Then(@"I Click on Close button of Case Fee")]
        public void ThenIClickOnCloseButtonOfCaseFee()
        {
            CaseListSearch.ClickOnCaseFeeCLOSE();
        }
        [Then(@"Save Button Should be displayed on Case Fee")]
        public void ThenSaveButtonShouldBeDisplayedOnCaseFee()
        {
            CaseListSearch.VerifySAVE_Button().Equals(1);
        }
        [Then(@"Cancel Button Should be displayed Case Fee")]
        public void ThenCancelButtonShouldBeDisplayedCaseFee()
        {
            CaseListSearch.VerifyCANCEL_Button().Equals(1);
        }
        [Then(@"I Click on Cancel button of Case Fee")]
        public void ThenIClickOnCancelButtonOfCaseFee()
        {
            CaseListSearch.ClickOnCaseFeeCANCEL();
        }
        [Given(@"I see Table header contains '(.*)'")]
        public void GivenISeeTableHeaderContains(string titles)
        {
            var TableTitles = titles.Split(';').Select(i => i.Trim()).ToList();
            CaseListSearch.Verify341MeetingPageTableColumns(TableTitles);
        }
        [Given(@"Verify sorting on Grid '(.*)'")]
        public void GivenVerifySortingOnGrid(string column)
        {
            var list = CaseListSearch.SortingColumns(column);
            list.Should().BeInAscendingOrder();
        }
        [When(@"I Select the PageSize as (.*) under Pagination Section meeting page")]
        public void WhenISelectThePageSizeAsUnderPaginationSectionMeetingPage(int PageSize)
        {
            CaseListSearch.SelectPageSize(PageSize);
        }
        [When(@"I click on filter Icon in the page")]
        public void WhenIClickOnFilterIconInThePage()
        {
            CaseListSearch.SearchFilterIcon();
        }
    }
}
