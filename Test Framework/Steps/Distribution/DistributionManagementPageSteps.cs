using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Data;
using TechTalk.SpecFlow;
using System.Threading;
using System.Linq;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Distribution
{
    [Binding]
    public class DistributionManagementPageSteps :StepBase
    {
        DistributionTab distributionTab;
        DataTable randomDistibutionRecords;

        [When(@"User click on Filter on Distribution page")]
        public void WhenUserClickOnFilterOnDistributionPage()
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            Thread.Sleep(3000);
            distributionTab.ClickOnFilter();
        }
        
        [When(@"User click on close on Distribution page")]
        public void WhenUserClickOnCloseOnDistributionPage()
        {
            distributionTab.ClickOnFilterClose();
        }
        
        [Then(@"'(.*)' header should be displayed on Distribution Page")]
        public void ThenHeaderShouldBeDisplayedOnDistributionPage(string header)
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.GetHeaderName().Should().Contain(header);
        }
        
        [Then(@"Distribution '(.*)' should be displayed")]
        public void ThenDistributionShouldBeDisplayed(string filterHeader)
        {
            distributionTab.GetFilterOptionHeader().Should().Contain(filterHeader);
        }
        [Then(@"'(.*)' should display in the popup")]
        public void ThenShouldDisplayInThePopup(string reportOption)
        {
            distributionTab.GetReportOption().Should().Contain(reportOption);
        }

        [Then(@"verify the columns '(.*)' to '(.*)' displayed on '(.*)' as '(.*)'")]
        public void VerifyColumns(int colStartIndex, int colEndIndex, string page, string columns)
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            var inputEntries = columns.Split(';').Select(i => i.Trim()).ToList();
            this.distributionTab.VerifyColumns(colStartIndex, colEndIndex, inputEntries, page);
        }
        [Then(@"Distribution '(.*)' should be closed")]
        public void ThenDistributionShouldBeClosed(string filterHeader)
        {
            distributionTab.GetFilterOptionHeader().Should().BeNullOrWhiteSpace();
        }
        
        [Then(@"User click on Refresh Button")]
        public void ThenUserClickOnRefreshButton()
        {
            distributionTab.ClickOnReferesh();
        }
        [Then(@"'(.*)' Should be able to sort on Distributions page")]
        public void ThenShouldBeAbleToSortOnDistributionsPage(string headerName)
        {
            var list = distributionTab.GetSortedList(headerName);
            list.Should().BeInAscendingOrder();
            list = distributionTab.GetSortedList(headerName);
            list.Should().BeInDescendingOrder();
        }
        [When(@"Enter Case Number '(.*)' in Distribution filter option")]
        public void WhenEnterCaseNumberInDistributionFilterOption(string caseNumber)
        {
            distributionTab.EnterCaseNumber(caseNumber);
        }
        [Then(@"History has mouseover")]
        public void ThenHistoryHasMouseover()
        { 
        distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.MouseHouver();
        }
        [Then(@"Distribution records should be displayed")]
        public void ThenDistributionRecordsShouldBeDisplayed()
        {
            distributionTab.GetDistributionRecords().Should().NotBeNull();
        }
        [Then(@"User click on the reset button on Distribution filter option")]
        public void ThenUserClickOnTheResetButtonOnDistributionFilterOption()
        {
            distributionTab.ClickOnResetButton();
        }
        [Then(@"user click on close button on Distribution filter option")]
        public void ThenUserClickOnCloseButtonOnDistributionFilterOption()
        {
            distributionTab.ClickOnCloseButton();
        }
        [Then(@"Table data should be present on distribution page")]
        public void ThenTableDataShouldBePresentOnDistributionPage()
        {
            randomDistibutionRecords = distributionTab.GetDistributionRecords();
            randomDistibutionRecords.Should().NotBeNull();
        }
        [When(@"I enter Debtor '(.*)' on distribution page")]
        public void WhenIEnterDebtorOnDistributionPage(string debtor)
        {
            distributionTab.EnterDebtor(debtor);
        }
        [Then(@"Selected result should contains '(.*)' on distribution page")]
        public void ThenSelectedResultShouldContainsOnDistributionPage(string Status)
        {
            System.Threading.Thread.Sleep(1500);

            if (!string.IsNullOrWhiteSpace(Status))
                distributionTab.GetRecordsByColumnName("STATUS", Status);
        }
        [When(@"User displays the page count on distribution page")]
        public void WhenUserDisplaysThePageCountOnDistributionPage()
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.GetPageCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Distributions count is [{0}]", distributionTab.GetPageCount()));
        }
        [Then(@"the selected page records should be displayed on distribution page")]
        public void ThenTheSelectedPageRecordsShouldBeDisplayedOnDistributionPage()
        {
            object value = null;
            var pageInfo = distributionTab.GetPagination();
            pageInfo.TryGetValue("Pagination", out value);
            ((bool)value).Should().BeTrue();
            pageInfo.TryGetValue("ActivePage", out value);
            (value).Should().NotBeNull();
        }
        [When(@"I click on one Distribution in line edit button")]
        public void WhenIClickOnOneDistributionInLineEditButton()
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.ClickOnDistribution_InlineEdit();
        }
        [Then(@"I should be able to edit the distribution")]
        public void ThenIShouldBeAbleToEditTheDistribution()
        {
            distributionTab.EditDistribution_Inline();
        }
        [Then(@"I should not be able to edit the distribution")]
        public void ThenIShouldNotBeAbleToEditTheDistribution()
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.ValidateDistributionEditInlineButton().Should().BeFalse();
        }
        [When(@"I select DistributionStatus '(.*)'")]
        public void WhenISelectDistributionStatus(string status)
        {
            distributionTab.SelectDistributionStatus(status);
        }
        [Then(@"Click on the View Icon for one of case from distribution lists")]
        public void ThenClickOnTheViewIconForOneOfCaseFromDistributionLists()
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.ClickOnViewButtonDistribution();
        }
        [When(@"I select the record for the selected")]
        public void WhenISelectTheRecordForTheSelected()
        {
            distributionTab.Selectrecord();
        }
        [When(@"I select the report from final distribution page")]
        public void WhenISelectTheReportFromFinalDistributionPage()
        {
            distributionTab.Selectreport();
        }
        [Then(@"user clicks on close button on view pages")]
        public void ThenUserClicksOnCloseButtonOnViewPages()
        {
            distributionTab.ClickOnCloseButtonDistribution();
        }
        [Then(@"I click and view the History Icon")]
        public void ThenIClickAndViewTheHistoryIcon()
        {
            distributionTab.VerifyHistoryIcon();
        }
        [When(@"I click On The Add Distribution")]
        public void WhenIClickOnTheAddDistribution()
        {
            distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions"));
            distributionTab.ClickAddDistribution();
        }

        [When(@"Enter the distribution name")]
        public void WhenEnterTheDistributionName()
        {
            distributionTab.EnterDistributionName();
        }

        [When(@"I click on Generate Distribution")]
        public void WhenIClickOnGenerateDistribution()
        {
            distributionTab.ClickGenerateButton();
        }
        [Then(@"I click Remit to Court Accordion")]
        public void ThenIClickRemitToCourtAccordion()
        {
            distributionTab.ClickOnRemitToCourt();
        }

        [Then(@"I click on check box for remit to court and enter the amount")]
        public void ThenIClickOnCheckBoxForRemitToCourtAndEnterTheAmount()
        {
            distributionTab.ClickCheckAndEnterAmount();
        }

        [Then(@"I select the current distribution date")]
        public void ThenISelectTheCurrentDistributionDate()
        {
            distributionTab.CurrentDateDetails();
        }

        [Then(@"Click on Modify Amount button")]
        public void ThenClickOnModifyAmountButton()
        {
            distributionTab.ClickModifyAmount();
        }

        [Then(@"I click on Cancel button in pop up distribution")]
        public void ThenIClickOnCancelButtonInPopUpDistribution()
        {
            distributionTab.ClickCancelButton();
        }

    }
}
