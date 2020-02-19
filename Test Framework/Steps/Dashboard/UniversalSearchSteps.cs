using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Dashboard
{
    [Binding]
    public class UniversalSearchSteps : StepBase
    {
        //REFACTORED
        private DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));

        [Given(@"I Click on the Case Result '(.*)'")]
        [When(@"I Click on the Case Result '(.*)'")]
        public void WhenIClickOnTheCaseResult(string caseNbr)
        {
            CaseDetailPage caseDetailPage = dashboardPage.NewUniversalSearch.ClickOnCaseResultByCaseNumber(caseNbr);
            //ScenarioContext.Current.Add("Target Case Detail Page", caseDetailPage);
        }

        [Then(@"I See The Universal Search Section")]
        public void ThenISeeTheUniversalSearchSection()
        {
             dashboardPage.UniversalSearch.VisibleOnDashboardContent.Should().BeTrue("Universal Search Section is visible");            
        }
        
        [Then(@"Search Title is '(.*)'")]
        public void ThenSearchTitleIs(string searchTitle)
        {
            dashboardPage.SearchToolWelcomeMessage.Should().Be(searchTitle, "Universal Search Title is "+searchTitle);
        }
        
        [Then(@"DropDown Label is '(.*)'")]
        public void ThenDropDownLabelIs(string dropDownLabel)
        {
            dashboardPage.UniversalSearch.DropDownLabel.Should().Be(dropDownLabel, "Universal Search Drop Down Label is " + dropDownLabel);
        }
        
        [Then(@"Search Input Placeholder is '(.*)'")]
        public void ThenSearchInputPlaceholderIs(string searchPlaceholder)
        {
            dashboardPage.UniversalSearch.InputPlaceholder.Should().Be(searchPlaceholder, "Universal Search Input Placeholder is " + searchPlaceholder);
        }

        [Then(@"Magnifying Glass Icon Is Present")]
        public void ThenMagnifyingGlassIconIsPresent()
        {
            dashboardPage.UniversalSearch.MagnifyingGlassIconVisible.Should().BeTrue("Universal Search Input Has a Magnifying Glass Icon");
        }

        [When(@"I Enter '(.*)' On The Universal Search Input")]
        [Then(@"I Enter '(.*)' On The Universal Search Input")]
        public void WhenIEnterOnTheUniversalSearchInput(string searchText)
        {
            dashboardPage.UniversalSearch.EnterTextForSearch(searchText);
        }
        [Given(@"I Enter '(.*)' On The Universal Search Section Input")]
        [When(@"I Enter '(.*)' On The Universal Search Section Input")]
        public void WhenIEnterOnTheUniversalSearchSectionInput(string SearchText)
        {
            dashboardPage.NewUniversalSearch.EnterTextinUniversalSearch(SearchText);
        }

        [Then(@"The Search Unfolds and Displays The Message as '(.*)'")]
        public void ThenTheSearchUnfoldsAndDisplaysTheMessageAs(string newmessage)
        {
            dashboardPage.NewUniversalSearch.NewResultsMessage.Should().Be(newmessage, "Search unfolds and displays message '" + newmessage + "'");
        }

        [Then(@"I See Only Cases Matching the '(.*)' on the Result List")]
        public void ThenISeeOnlyCasesMatchingTheOnTheResultList(string SearchText)
        {
            List<string> actualResults = dashboardPage.NewUniversalSearch.NewResultsList;

            foreach (string res in actualResults)
            {
                res.Should().ContainEquivalentOf(SearchText, "Result " + res + "does not match search text '" + SearchText + "'");
            }
        }


        [Then(@"The Search Unfolds and Displays The Message '(.*)'")]
        public void ThenTheSearchUnfoldsAndDisplaysTheMessage(string message)
        {
            dashboardPage.UniversalSearch.ResultsMessage.Should().Be(message, "Search unfolds and displays message '"+message+"'");
        }

        [Then(@"I See This Cases on the Result List")]
        public void ThenISeeThisCasesOnTheResultList(Table table)
        {
            TableRows expectedResults = table.Rows;
            List<string> actualResults = dashboardPage.UniversalSearch.ResultsList;

            int position = 0;
            foreach (TableRow expCase  in expectedResults)
            {
                string expectedCase = expCase["Case Result"];
                actualResults[position].Should().Be(expectedCase,"Expected Case '"+expectedCase+"' is part of Results for the Search");
                position++;
            }
       }
        

        [Then(@"I See Only Cases Matching '(.*)' on the Result List")]
        public void ThenISeeOnlyCasesMatchingOnTheResultList(string searchText)
        {
            List<string> actualResults = dashboardPage.UniversalSearch.ResultsList;

            foreach (string result in actualResults)
            {
                result.Should().ContainEquivalentOf(searchText, "Result " + result + "does not match search text '" + searchText + "'");
            }
        }

        [Then(@"I DO NOT See The Universal Search As A Sticky Bar")]
        public void ThenIDONOTSeeTheUniversalSearchAsAStickyBar()
        {
            dashboardPage.UniversalSearchVisibleOnStickyBar().Should().BeFalse("Universal Search Sticky Bar is not visible");
        }

        [Then(@"I See The Universal Search As A Sticky Bar")]
        public void ThenISeeTheUniversalSearchAsAStickyBar()
        {
            dashboardPage.UniversalSearchVisibleOnStickyBar().Should().BeTrue("Universal Search Sticky Bar is visible");

        }


        [Then(@"I See The Case Detail Page Displays For Case Number '(.*)' With Case Name '(.*)'")]
        public void ThenISeeTheCaseDetailPageDisplaysForCaseNumberWithCaseName(string caseNbr, string caseName)
        {
            CaseDetailPage caseDetailPage = ScenarioContext.Current.Get<CaseDetailPage>("Target Case Detail Page");            
            caseDetailPage.Number.Trim().Should().Be(caseNbr, "Case Detail Should Display Case Number '"+caseNbr+"'");
            caseDetailPage.Name.Should().Be(caseName, "Case Detail Should Display Case Name '" + caseName + "'");
        }

        [Then(@"I SignOut from the Unity Application")]
        public void ThenISignOutFromTheUnityApplication()
        {
            dashboardPage.NavigationBar.SignOutFromUnity();
        }
        [Given(@"I select Activity under BankingCenter")]
        public void GivenISelectActivityUnderBankingCenter()
        {
            dashboardPage.NewUniversalSearch.SelectBankingActivity();
        }
        [Given(@"I Navigate to ReactReports")]
        public void GivenINavigateToReactReports()
        {
            dashboardPage.NewUniversalSearch.NavigateToReactReports();
        }
        [Given(@"I see the Magnifying Glass Icon Is Present")]
        public void GivenISeeTheMagnifyingGlassIconIsPresent()
        {
            dashboardPage.NewUniversalSearch.MagnifySearchGlass();
        }
        [Given(@"I see the Search box under All Cases Section")]
        public void GivenISeeTheSearchBoxUnderAllCasesSection()
        {
            dashboardPage.NewUniversalSearch.SelectAllCasesArrow();
        }       
        [Given(@"I see the text '(.*)' under Search Section")]
        public void GivenISeeTheTextUnderSearchSection(string Text)
        {
            dashboardPage.NewUniversalSearch.SelectACaseText.Should().Be(Text, "Search Section Should Display Text '" + Text + "'");
        }

        [When(@"I Click on Unreconciled option")]
        public void WhenIClickOnUnreconciledOption()
        {
            dashboardPage.ClickOnUnreconciled();
        }
        [When(@"I click on Radio Button of schedules and claims")]
        public void WhenIClickOnRadioButtonOfSchedulesAndClaims()
        {
            dashboardPage.ClickOnRadioButton();
        }
        [When(@"I Add link and unlink transactions")]
        public void WhenIAddLinkAndUnlinkTransactions()
        {
            dashboardPage.ClickOnLinkButton();
        }


        [When(@"user perform mouseover on debtor name")]
        public void WhenUserPerformMouseoverOnDebtorName()
        {
            dashboardPage.MouseHouver();
        }

        [When(@"user perform mouseover on debtor name on task tile")]
        public void WhenUserPerformMouseoverOnDebtorNameOnTaskTile()
        {
            dashboardPage.mouseHouverTaskTile();
        }
        [Then(@"I see the Search box under All Cases Section")]
        public void SearchBoxUnderAllCasesSection()
        {
            dashboardPage.NewUniversalSearch.SelectAllCasesArrow();
        }

    }
}