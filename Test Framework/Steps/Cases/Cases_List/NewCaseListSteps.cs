using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Cases_List;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Cases_List
{
    public class NewCaseListSteps : StepBase
    {
        public NewCaseListPage NewCaseList = new NewCaseListPage(driver);

        [When(@"I click on Dashboard Link under Case Management")]
        public void WhenIClickOnDashboardLinkUnderCaseManagement()
        {
            NewCaseList.ClickDashboardLink();
        }
        [When(@"I click on (.*) Meeting Date Sorting Controls")]
        public void WhenIClickOnMeetingDateSortingControls(int p0)
        {
            NewCaseList.MeetingDateSortingControls();
        }
        [When(@"I see the (.*) Meeting Date column details in Ascending Order")]
        public void WhenISeeTheMeetingDateColumnDetailsInAscendingOrder(int p0)
        {
            NewCaseList.AscendingMeetingDateSection();
        }
        [When(@"I click on Reset Filters Button")]
        public void WhenIClickOnResetFiltersButton()
        {
            NewCaseList.ResetFilterButton();
        }
        [Then(@"I see the (.*) Meeting Date column details reverted to default")]
        public void ThenISeeTheMeetingDateColumnDetailsRevertedToDefault(int p0)
        {
            NewCaseList.DefaultMeetingDateDetails();
        }
        [When(@"I click on Debtor Sorting Controls")]
        public void WhenIClickOnDebtorSortingControls()
        {
            NewCaseList.DebtorSortingControls();
        }
        [When(@"I see the Debtor column details in Ascending Order")]
        public void WhenISeeTheDebtorColumnDetailsInAscendingOrder()
        {
            NewCaseList.DebtorAscendingDetails();
        }
        [Then(@"I click on Petition Date Sorting Controls")]
        public void ThenIClickOnPetitionDateSortingControls()
        {
            NewCaseList.PetitionDateSortingControls();
        }
        [Then(@"I see the Petition Date column details in Ascending Order")]
        public void ThenISeeThePetitionDateColumnDetailsInAscendingOrder()
        {
            NewCaseList.PetitionDateAscendingSection();
        }
        [Then(@"I see the Debtor column details reverted to default")]
        public void ThenISeeTheDebtorColumnDetailsRevertedToDefault()
        {
            NewCaseList.DebtorDefaultDetails();
        }
        [When(@"I Click again on (.*) Meeting Date Sorting Controls")]
        public void WhenIClickAgainOnMeetingDateSortingControls(int p0)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            NewCaseList.MeetingDateSortingControls();
        }
        [Then(@"I see the (.*) Meeting Date column details in Descending Order")]
        public void ThenISeeTheMeetingDateColumnDetailsInDescendingOrder(int p0)
        {
            NewCaseList.MeetingDateDescendingDetails();
        }
        [Given(@"I select page '(.*)' under Pagination Section")]
        public void GivenISelectPageUnderPaginationSection(int PageNum)
        {
            NewCaseList.SelectPages(PageNum);
        }

        [Then(@"I see the CaseList details for the Selected Page")]
        public void ThenISeeTheCaseListDetailsForTheSelectedPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            NewCaseList.SelectedPageCaseDetails();
        }
        [When(@"I Select the PageSize as (.*) under Pagination Section")]
        public void WhenISelectThePageSizeAsUnderPaginationSection(int PageSize)
        {
            NewCaseList.SelectPageSize(PageSize);
        }
        [When(@"I see the CaseList Table Contains the Same Number of Rows as per Selected (.*)")]
        public void WhenISeeTheCaseListTableContainsTheSameNumberOfRowsAsPerSelected(int PageSize)
        {
            NewCaseList.VerifyRowsLength(PageSize);
        }

        [When(@"I click on Expand button I see few more fields under Case Table")]
        public void WhenIClickOnExpandButtonISeeFewMoreFieldsUnderCaseTable()
        {
            NewCaseList.FieldsUnderExpandButtonInCaseTable();
        }
        [When(@"I click on Collapse button")]
        public void WhenIClickOnCollapseButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            NewCaseList.ClickCollapseButton();
        }
        [Given(@"I click on Sorting Controls of All fields")]
        public void GivenIClickOnSortingControlsOfAllFields()
        {
            NewCaseList.ClickSortingControls();
        }
        [Given(@"I see the CasesCount")]
        public void GivenISeeTheCasesCount()
        {
            NewCaseList.GetCasesCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Cases count is  [{0}]", NewCaseList.GetCasesCount()));
        }
        [When(@"I select the case '(.*)' as Favorite")]
        public void WhenISelectTheCaseAsFavorite(string DedtorName)
        {
            NewCaseList.MarkCaseFavorite(DedtorName);
        }
        [Then(@"the Case '(.*)' marked as Favorite with Yellow Star")]
        public void ThenTheCaseMarkedAsFavoriteWithYellowStar(string DebtorName)
        {
            NewCaseList.VerifyFavoriteCaseColor(DebtorName);
        }
        [Then(@"I deselect the Favorite case '(.*)'")]
        public void ThenIDeselectTheFavoriteCase(string DedtorName)
        {
            NewCaseList.MarkCaseFavorite(DedtorName);
        }
        [Then(@"I see the Case '(.*)' is no more Favorite Case")]
        public void ThenISeeTheCaseIsNoMoreFavoriteCase(string DedtorName)
        {
            NewCaseList.DeselectedFavoriteCase(DedtorName);
        }
        [Then(@"I verify the Case '(.*)' in Favorites tile")]
        public void ThenIVerifyTheCaseInFavoritesTile(string caseNum)
        {
            NewCaseList.VerifyCaseInFavoriteTile(caseNum);
        }
        [Then(@"the Marking Case as Favorite should be view only")]
        public void ThenTheMarkingCaseAsFavoriteShouldBeViewOnly()
        {
            NewCaseList.VerifyWhetherFavoriteIsEditable();
        }
        [Given(@"I create the new Case")]
        public void GivenICreateTheNewCase()
        {
            NewCaseList.AddNewCase();
        }
        [Then(@"I input peition Date in the Fields")]
        public void ThenIInputPeitionDateInTheFields()
        {
            NewCaseList.InputPetitionDateFrom();
        }

    }
}
