using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dates;
using System;
using FluentAssertions;
using TechTalk.SpecFlow;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using System.Threading;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Dates
{
    [Binding]
    public class DatesManagementPageSteps :StepBase
    {

        DatesPage datesPage;
        [When(@"User click on Filter on Dates page")]
        public void WhenUserClickOnFilterOnDatesPage()
        {
            datesPage = ((DatesPage)GetSharedPageObjectFromContext("Dates"));
            datesPage.ClickOnFilter();
        }
        
        [When(@"User click on close on Dates page")]
        public void WhenUserClickOnCloseOnDatesPage()
        {
            datesPage.ClickOnFilterClose();
        }
        
        [Then(@"'(.*)' header should be displayed on Dates Page")]
        public void ThenHeaderShouldBeDisplayedOnDatesPage(string header)
        {
            datesPage = ((DatesPage)GetSharedPageObjectFromContext("Dates"));
            datesPage.GetHeaderName().Should().Contain(header);            
        }
        
        [Then(@"Dates '(.*)' should be displayed")]
        public void ThenDatesShouldBeDisplayed(string filterHeader)
        {
            datesPage.GetFilterOptionHeader().Should().Contain(filterHeader);
        }
        
        [Then(@"Dates '(.*)' should be closed")]
        public void ThenDatesShouldBeClosed(string filterHeader)
        {
            datesPage.GetFilterOptionHeader().Should().BeNullOrWhiteSpace();
        }
        
        [Then(@"User click on Refresh Button on Dates Page")]
        public void ThenUserClickOnRefreshButtonOnDatesPage()
        {
            datesPage.ClickOnReferesh();
        }
        [Then(@"'(.*)' Should be able to sort on Dates page")]
        public void ThenShouldBeAbleToSortOnDatesPage(string headerName)
        {
            Thread.Sleep(3500);
           // datesPage.ClickOnReferesh();
            var list = datesPage.GetSortedList(headerName);
            list.Should().BeInAscendingOrder();
            Thread.Sleep(3500);
            list = datesPage.GetSortedList(headerName);
            list.Should().BeInDescendingOrder();
            Thread.Sleep(3500);
           // datesPage.ClickOnReferesh();
        }
        [When(@"Enter Case Number '(.*)' in Dates filter option")]
        public void WhenEnterCaseNumberInDatesFilterOption(string caseNumber)
        {
            datesPage.EnterCaseNumber(caseNumber);
            datesPage.ScrollDown();
        }

        [When(@"I select case Status'(.*)' in Dates filter option")]
        public void WhenISelectCaseStatusInDatesFilterOption(string status)
        {
            datesPage.SelectCaseStatus(status);
        }
        [Then(@"Dates records should be displayed")]
        public void ThenDatesRecordsShouldBeDisplayed()
        {
            datesPage.GetDatesRecords().Should().NotBeNull();
        }
        [Then(@"User click on the reset button on Dates filter option")]
        public void ThenUserClickOnTheResetButtonOnDatesFilterOption()
        {
            datesPage.ClickOnResetButton();
        }
        [Then(@"user click on close button on Dates filter option")]
        public void ThenUserClickOnCloseButtonOnDatesFilterOption()
        {
            datesPage.ClickOnCloseButton();
        }
        [When(@"User click on Row Expand button on Dates page")]
        public void WhenUserClickOnRowExpandButtonOnDatesPage()
        {
            datesPage = ((DatesPage)GetSharedPageObjectFromContext("Dates"));
            datesPage.clickOnRowExpandButton();
        }
        [Then(@"User should be able to see column CASE \# on dates page")]
        public void ThenUserShouldBeAbleToSeeColumnCASEOnDatesPage()
        {
            datesPage.GetCaseNumberDisplayed().Should().BeTrue();
        }
        [Then(@"User should be able to see column ASSET STATUS on dates page")]
        public void ThenUserShouldBeAbleToSeeColumnASSETSTATUSOnDatesPage()
        {
            datesPage.GetAssetStatusisplayed().Should().BeTrue();
        }
        [When(@"User displays the page count on dates page")]
        public void WhenUserDisplaysThePageCountOnDatesPage()
        {
            datesPage = ((DatesPage)GetSharedPageObjectFromContext("Dates"));
            datesPage.GetPageCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Dates count is [{0}]", datesPage.GetPageCount()));
        }
        [Then(@"the selected page records should be  in dates page")]
        public void ThenTheSelectedPageRecordsShouldBeInDatesPage()
        {
            object value = null;
            var pageInfo = datesPage.GetPagination();
            pageInfo.TryGetValue("Pagination", out value);
            ((bool)value).Should().BeTrue();
            pageInfo.TryGetValue("ActivePage", out value);
            (value).Should().NotBeNull();
        }
        [When(@"User clicks on the Add Dates Button")]
        public void WhenUserClicksOnTheAddDatesButton()
        {
            datesPage = ((DatesPage)GetSharedPageObjectFromContext("Dates"));
            datesPage.ClickOnAddDate();
        }
        [When(@"User Enter the Date for Convert to chapter")]
        public void WhenUserEnterTheDateForConvertToChapter()
        {
            datesPage.ClickCovertedToChapter7();
            string d1 = "01/25/18";
            datesPage.SetDates(d1);
            Thread.Sleep(2000);
        }
        [Then(@"User Clicks on tick button on add page")]
        public void ThenUserClicksOnTickButtonOnAddPage()
        {
            datesPage.ClickOnTickButton();
        }
        [When(@"User Enter the Date for NDR")]
        public void WhenUserEnterTheDateForNDR()
        {
            datesPage.ScrollDown();
            datesPage.ClickNDR();
            Thread.Sleep(3000);
            string d1 = "01/25/18";
            datesPage.SetDates(d1);
            Thread.Sleep(2000);
        }
        [Then(@"User try to clicks on the Add Dates Button")]
        public void ThenUserTryToClicksOnTheAddDatesButton()
        {
            datesPage = ((DatesPage)GetSharedPageObjectFromContext("Dates"));
            datesPage.performClickOnDate();
        }
        [When(@"User Edit and Enter the Date '(.*)' to Converted")]
        public void WhenUserEditAndEnterTheDateToConverted(string date)
        {
            datesPage.Add_Converted_from_7_Date(date);
        }
        [When(@"User Edit and Enter the Date '(.*)' to Dismissal")]
        public void WhenUserEditAndEnterTheDateToDismissal(string date)
        {
            datesPage.Add_Dismissal_Date(date);
        }
        [Then(@"Click on tick and validate Toastr message")]
        public void ThenClickOnTickAndValidateToastrMessage()
        {
            datesPage.ValidateToastrMessage().Should().BeTrue();
            Thread.Sleep(1000);
        }
        [Then(@"validate message is displaying in Case Closing Date section")]
        public void ThenValidateMessageIsDisplayingInCaseClosingDateSection()
        {
            datesPage.VefifyWarnMessage().Should().BeTrue();
        }
    }
}
