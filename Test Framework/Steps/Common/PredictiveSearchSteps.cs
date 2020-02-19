using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest
{
    [Binding]
    public class PredictiveSearchSteps:StepBase
    {
        //REFACTORING
        //private UniversalAppBar universalAppBar;

        [When(@"I Click on the Magnifying Glass")]
        public void WhenIClickOnTheMagnifyingGlass()
        {
            DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
            UniversalAppBar universalAppBar = dashboardPage.UniversalApplicationBar;
            universalAppBar.ClickMagnifyingGlass();
            AddDataToScenarioContextOverridingExistentKey("Universal App Bar", universalAppBar);
        }
        
        [When(@"I perform a case Search for (.*)")]
        public void WhenIPerformACaseSearchFor(string searchText)
        {
            DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
            UniversalAppBar universalAppBar = dashboardPage.UniversalApplicationBar;            
            universalAppBar.Search(searchText);
            AddDataToScenarioContextOverridingExistentKey("Universal App Bar", universalAppBar);

        }

        [When(@"I see exactly (.*) results")]
        public void WhenISeeExactlyResults(int expResultsNumber)
        {
            UniversalAppBar universalAppBar = ((UniversalAppBar)GetSharedPageObjectFromContext("Universal App Bar"));
            universalAppBar.GetSearchResults().Count.Should().Be(expResultsNumber);
        }
        
        [When(@"I select (.*) Case")]
        public void WhenISelectCase(string caseNumber)
        {
            UniversalAppBar universalAppBar = ((UniversalAppBar)GetSharedPageObjectFromContext("Universal App Bar"));
            universalAppBar.SelectSearchResultByCaseNumber(caseNumber);
        }
        
        [Then(@"I see an input field for search text")]
        public void ThenISeeAnInputFieldForSearchText()
        {
            UniversalAppBar universalAppBar = ((UniversalAppBar)GetSharedPageObjectFromContext("Universal App Bar"));
            universalAppBar.IsSearchnIputBoxVisible().Should().Be(true);
        }
        
        [Then(@"I see at least (.*) results")]
        public void ThenISeeAtLeastResults(int expMinResultsNumber)
        {
            UniversalAppBar universalAppBar = ((UniversalAppBar)GetSharedPageObjectFromContext("Universal App Bar"));
            universalAppBar.GetSearchResults().Count.Should().BeGreaterOrEqualTo(expMinResultsNumber);
        }
               
        
        [Then(@"I see an error message displays reading '(.*)'")]
        public void ThenISeeAnErrorMessageDisplaysReading(string errorMsg)
        {
            UniversalAppBar universalAppBar = ((UniversalAppBar)GetSharedPageObjectFromContext("Universal App Bar"));
            universalAppBar.GetNoResultsMessage().Should().Be(errorMsg);
        }
    }
}
