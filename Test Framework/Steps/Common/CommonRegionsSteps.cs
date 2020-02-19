using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    [Binding]
    public class CommonRegionsSteps : StepBase
    {
        //REFACTORED
        private DashboardPage dashboardPage = ((DashboardPage) GetSharedPageObjectFromContext("Dashboard"));

        //UNIVERSAL APP BAR REGION
        [Then(@"I see the Universal App Bar container")]
        public void ThenISeeTheUniversalAppBarContainer()
        {            
            UniversalAppBar appBar = dashboardPage.UniversalApplicationBar;
        }

        [Then(@"I see the Flag Icon")]
        public void ThenISeeTheFlagIcon()
        {
           dashboardPage.UniversalApplicationBar.IsFlagIconVisible().Should().Be(true);
        }

        [Then(@"I see the Favorites Icon")]
        public void ThenISeeTheFavoritesIcon()
        {
           dashboardPage.UniversalApplicationBar.IsFavoritesIconVisible().Should().Be(true);
        }

        [Then(@"I see the Search cases tool")]
        public void ThenISeeTheSearchCasesTool()
        {
            dashboardPage.UniversalApplicationBar.IsSearchCasesToolVisible().Should().Be(true);
        }

        [Then(@"I see the User Profile link and its content is correct")]
        public void ThenISeeTheUserProfileLinkComplete()
        {
            dashboardPage.UniversalApplicationBar.IsUserProfileLinkVisibleAndComplete().Should().Be(true);
        }


        //NAVIGATION MENU REGION
        [Then(@"I see the Main Navigation Menu and it is correct")]
        public void ThenISeeMainNavigationMenu()
        {
            NavigationBar navigationBar = dashboardPage.NavigationBar;
            Link menuItem = null;            

            try
            {
                menuItem = navigationBar.ToolsMenuItemLink;
            }
            catch (MissingElementException)
            {
                //the ToolsMenuItemLink shoud not be visible, so this would be ok.
            }

            try
            {
                menuItem = navigationBar.OfficesMenuItemLink;
            }
            catch (MissingElementException)
            {
                //the OfficesMenuItemLink shoud not be visible, so this would be ok.
            }

            menuItem.Should().BeNull("Dashboard, Tools and Offices menu items are hidden");

        }


        [Then(@"I see '(.*)' menu item text is '(.*)'")]
        public void ThenISeeMenuItemTextIs(string name, string expectedValue)
        {
            switch (name)
            {
                case "dashboard":
                    {
                        dashboardPage.NavigationBar.DashboardMenuItemLink.Text.Should().Be(expectedValue);
                        break;
                    }
                case "cases":
                    {
                        dashboardPage.NavigationBar.CasesMenuItemLink.Text.Should().Be(expectedValue);
                        break;
                    }
                case "offices":
                    {
                        dashboardPage.NavigationBar.OfficesMenuItemLink.Text.Should().Be(expectedValue);
                        break;
                    }
                case "tools":
                    {
                        dashboardPage.NavigationBar.ToolsMenuItemLink.Text.Should().Be(expectedValue);
                        break;
                    }
                default:
                    {
                        ScenarioContext.Current.Pending();
                        break;
                    }
            }
        }
    }
}
