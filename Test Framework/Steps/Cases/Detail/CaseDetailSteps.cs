using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.List;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail
{
    [Binding]
    public class CaseDetailSteps:StepBase
    {
        //REFACTORED
        private DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));

        public static int GetCaseIdFromCaseNumber(string caseNbr)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseNumber", caseNbr);
            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetCaseIdFromCaseNumber, parameters);
            
            int caseId = 0;
            foreach (DataRow row in rows)
            {                
                caseId = Convert.ToInt32(row.ItemArray[0]);
                break;
            }

            return caseId;
        }               

        [When(@"I Navigate to Case Detail page for the '(.*)' Case with Case Number '(.*)'")]
        [Given(@"I Navigate to Case Detail page for the '(.*)' Case with Case Number '(.*)'")]
        private void GivenINavigateToCaseDetailPageForTheCaseWithCaseNumber(List<string> status, string caseNumber)
        {
            CaseListPage caseListPage = ((CaseListPage)GetSharedPageObjectFromContext("Case List"));

            //if case has status closed, then search for closed cases
            if (status.First().ToLower() == "closed")
            {
                CaseListSearchForm searchForm = caseListPage.SearchForm;
                searchForm.SelectOptionsFromSearchField(CaseListFields.STATUS, status);
                searchForm.TypeInCaseNumberValue(caseNumber);
                searchForm.SubmitSearch();
            }

            //Search the case in the case list
            CaseData caseData = caseListPage.GetCaseRowByCaseNumber(caseNumber);

            //Save data in scenario context for verifications (Add or Replace)
            try { ScenarioContext.Current.Remove("CaseData"); } catch (Exception) {}
            ScenarioContext.Current.Add("CaseData", caseData);


            //select case by its case number - navigates to case details page
            SetSharedPageObjectInCurrentContext("Case Detail", caseListPage.SelectCaseByNumber(caseNumber));
        }

        [When(@"I Enter to Case Detail page for Case with Case Number '(.*)'")]
        [Given(@"I Enter to Case Detail page for Case with Case Number '(.*)'")]
        private void GivenIEnterToCaseDetailPageForCaseWithCaseNumber(string caseNbr)
        {
            dashboardPage.UniversalSearch.EnterTextForSearch(caseNbr);
            CaseDetailPage detailPage = dashboardPage.UniversalSearch.ClickOnCaseResultByCaseNumber(caseNbr);
            SetSharedPageObjectInCurrentContext("Case Detail", detailPage);            

            //Save Case number on Scenario
            try
            {
                ScenarioContext.Current.Add("Case Number", caseNbr);
            }
            catch (Exception)
            {
                ScenarioContext.Current.Remove("Case Number");
                ScenarioContext.Current.Add("Case Number", caseNbr);
            }
        }

        [Given(@"I Go to Assets Detail")]
        [When(@"I Go to Assets Detail")]
        private void WhenIGoToAssetsDetail()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            SetSharedPageObjectInCurrentContext("Assets Tab", caseDetailPage.GoToAssetsDetail());
        }

        [Given(@"I Go to Claims Detail")]
        [When(@"I Go to Claims Detail")]
        private void WhenIGoToClaimsDetail()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            SetSharedPageObjectInCurrentContext("Claims Tab", caseDetailPage.GoToClaimsDetail());
        }

        [When(@"I Go to Banking Detail")]
        [Given(@"I Go to Banking Detail")]
        private void GivenIGoToBankingDetail()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            SetSharedPageObjectInCurrentContext("Banking Tab", caseDetailPage.GoToBankingDetail());            
        }

        [Given(@"I Go to Distribution")]
        [When(@"I Go to Distribution")]
        private void WhenIGoToDistribution()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            SetSharedPageObjectInCurrentContext("Distributions Tab", caseDetailPage.GoToDistribution());
        }

        [Then(@"I See Case Detail Page Displays the Correct Case Data")]
        private void ThenISeeCaseDetailPageDisplayingTheCorrectCaseData()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));

            CaseData caseData = ScenarioContext.Current.Get<CaseData>("CaseData");
            caseDetailPage.Number.Should().Be(caseData.Number, "Case Number displayed is correct");
            caseDetailPage.Name.Should().Be(caseData.Name, "Case Name displayed is correct");
            caseDetailPage.Type.Should().BeEquivalentTo(caseData.Type, "Case Type displayed is correct");

            caseDetailPage.Status.ToLower().Should().Be(caseData.Status.ToLower(), "Case Status displayed is correct");

            //not verifying this here anymore, special tests have been written for key dates
            //caseDetailPage.OpenDateLabel.ShouldBeEquivalentTo("OPEN DATE", "Open Date label is correct.");
            //caseDetailPage.OpenDate.Should().Be(caseData.OpenDate, "Case Open Date displayed is correct");
            //caseDetailPage.EstimatedDistributionDateLabel.ShouldBeEquivalentTo("ESTIMATED DISTRIBUTION DATE", "Open Date label is correct.");
            //caseDetailPage.EstimatedDistributionDate.Should().Be(caseData.EstimatedDistributionDate, "Case Estimated Distribution Date displayed is correct");
        }
        

        [Then(@"Tax Id is '(.*)'")]
        private void ThenTaxIdIs(string taxId)
        {            
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.TaxId.Should().Be(taxId, "Tax ID for the Case is "+taxId);
        }
        

        [Then(@"Claims Icon Displays with Description '(.*)' and Correct Value")]
        private void ThenClaimsIconDisplaysWithDescriptionAndValue(string description)
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            CaseData caseData = ScenarioContext.Current.Get<CaseData>("CaseData");            

            caseDetailPage.ClaimsIcon.DisplaysCorrectly().Should().BeTrue("Claims icon displays as a circle");
            caseDetailPage.ClaimsIcon.Description.Should().Be(description, "Claims icon description is " + description);

            //query db to get count of currently open cases
            int expectedCount = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();            
            parameters.Add("CaseId", Convert.ToString(GetCaseIdFromCaseNumber(caseData.Number)));

            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.GetClaimsCountByCaseId, parameters);
            foreach (DataRow result in results)
            {
                expectedCount = result.Field<int>("ClaimsCount");
            }

            caseDetailPage.ClaimsIcon.Value.Should().Be(""+expectedCount, "Claims icon value is " + expectedCount);
        }

        
        [Then(@"Distributions to Date Icon Displays with Description '(.*)' and Value '(.*)'")]
        private void ThenDistributionToDateIconDisplaysWithDescriptionAndValue(string description, string value)
        {            
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.DistributionsIcon.DisplaysCorrectly().Should().BeTrue("Distributions icon displays as a circle");
            caseDetailPage.DistributionsIcon.Description.Should().Be(description, "Distributions icon description is " + description);
            caseDetailPage.DistributionsIcon.Value.Should().Be(value, "Distributions icon value is " + value);
        }

        [Then(@"Bank Balance Icon Displays with Description '(.*)' and Value '(.*)'")]
        private void ThenBankBalanceIconDisplaysWithDescriptionAndValue(string description, string value)
        {            
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.BankBalanceIcon.DisplaysCorrectly().Should().BeTrue("Bank Balance icon displays as a circle");
            caseDetailPage.BankBalanceIcon.Description.Should().Be(description, "Bank Balance icon description is " + description);
            caseDetailPage.BankBalanceIcon.Value.Should().Be(value, "Bank Balance icon value is " + value);
        }

        

        [Then(@"I See Claims Detail is Selected by Default and Tab Title is '(.*)'")]
        private void ThenISeeClaimsDetailIsSelectedByDefaultAndTabTitleIs(string expTitle)
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));

            //Claims detail is selected by default
            ClaimsDetailTab claimsTab = caseDetailPage.ClaimsTab;
            claimsTab.Should().NotBeNull("Claims Navigation Menu Item is present and selected by default");
            claimsTab.TabTitle.Should().Be(expTitle, "Claims Tab Title is '"+expTitle+"'");

            //Save claims tab on context
            SetSharedPageObjectInCurrentContext("Claims Tab", claimsTab);            
        }

        [Then(@"I See Banking Detail Page Displays and Tab Title is '(.*)'")]
        private void ThenISeeTheBankingDetailDisplaysAndTabTitleIs(string expTitle)
        {
            BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));
            bankingTab.TabTitle.Should().Be(expTitle, "Banking Detail Tab Title is " + expTitle);
        }        

        [Then(@"I See the Distribution Page Displays and Tab Title is '(.*)'")]
        private void ThenISeeDistributionIsSelectedAndTabTitleIs(string expTitle)
        {
            DistributionTab distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distribution Tab"));
            distributionTab.TabTitle.Should().Be(expTitle, "Distribution Tab Title is " + expTitle);
        }


        [When(@"I Scroll All The Way Down On The Page")]
        private void WhenIScrollAllTheWayDownOnThePage()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.Pause(10);
            caseDetailPage.ScrollDownToPageBottom();            
        }

        [When(@"I Scroll All The Way up on The Page")]
        public void WhenIScrollAllTheWayUpOnThePage()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.Pause(10);
            caseDetailPage.ScrollUpToPageTop();
        }


        [Then(@"I See Header Bar Sticks Visible On Top")]
        private void ThenISeeHeaderBarSticksVisibleOnTop()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.IsStickyCaseHeaderVisible().Should().BeTrue("Case Header is Sticky");
            caseDetailPage.IsNameSticky().Should().BeTrue("Name is sticky");
            caseDetailPage.IsNumberSticky().Should().BeTrue("Number is sticky");
            caseDetailPage.IsTypeSticky().Should().BeTrue("Type is sticky");
            caseDetailPage.IsStatusSticky().Should().BeTrue("Status is sticky");
        }

        [Given(@"Go To '(.*)' Tab")]
        private void GivenGoToTab(string tab)
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            switch (tab)
            {
                case "Assets":
                    caseDetailPage.GoToAssetsDetail();
                    break;

                case "Banking":
                    caseDetailPage.GoToBankingDetail();
                    break;

                case "Claims":
                    caseDetailPage.GoToClaimsDetail();
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        [When(@"I Refresh The Page")]
        private void WhenIRefreshThePage()
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));
            caseDetailPage.Reload();
        }

        [Then(@"I Still See '(.*)' Tab")]
        private void ThenIStillSeeTab(string tab)
        {
            CaseDetailPage caseDetailPage = ((CaseDetailPage)GetSharedPageObjectFromContext("Case Detail"));

            switch (tab)
            {
                case "Assets":
                    caseDetailPage.Title.Should().Be("Assets | Case Detail | UNITY");
                    break;

                case "Banking":
                    caseDetailPage.Title.Should().Be("Banking | Case Detail | UNITY");
                    break;

                case "Claims":
                    caseDetailPage.Title.Should().Be("Claims | Case Detail | UNITY");
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }        

    }
}
