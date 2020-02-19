using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Dashboard
{

    [Binding]
    class Dashboard_EnhancementsSteps : StepBase
    {
        Dashboard_EnhancementsPage Dashboardenhancementpage = new Dashboard_EnhancementsPage(driver);
        [Then(@"I see Dashboard header '(.*)'")]
        public void IseeDashboardHeaders(string header)
        {
            Dashboardenhancementpage.DashboardHeaders(header);
        }
        [When(@"I click on link (.*)")]
        public void Iclickonbanksummary(int link)
        {
            Dashboardenhancementpage.BankSummaryLinksClick(link);
        }
        [When(@"I click on 341 meetings")]
        public void Iclick341meeting()
        {
            Dashboardenhancementpage.Meeting341Click();
        }
        [Then(@"should navigate to '(.*)' page")]
        public void IPreperatinpage(string header)
        {
            Dashboardenhancementpage.VerifyHeaderOnPreperationPage(header);
        }
        [When(@"I click on '(.*)'")]
        public void IViewalltasksclick(string buttonText)
        {
            Dashboardenhancementpage.ViewAllTasksClick(buttonText);
        }
        [When(@"I click on CASE/DEBTOR NAME")]
        public void IclickCASEDEBTORNAME()
        {
            Dashboardenhancementpage.ClickCaseDebtorName();
        }
        [Then(@"verify the 341 meetings UI count")]
        public void VerifyUICount()
        {
            Dashboardenhancementpage.GetCasesCountFromUI();
        }
        [Then(@"Verify the 341 meetings count from DB")]
        public void VerifyDBCount()
        {         
            Dashboardenhancementpage.GetCasesCountFromDB();
        }
        [When(@"I click on New Cases then cases should be displayed or a message '(.*)'")]
        public void WhenIClickOnNewCasesThenCasesShouldBeDisplayedOrAMessage(string message)
        {
            Dashboardenhancementpage.VerifyNewCasesLinkToPrefilteredInUpcoming341Page(message);
        }
        [When(@"I click on Continued Cases then cases should be displayed or a message '(.*)'")]
        public void WhenIClickOnContinuedCasesThenCasesShouldBeDisplayedOrAMessage(string message)
        {
            Dashboardenhancementpage.VerifyContinuedCasesLinkToPrefilteredInUpcoming341Page(message);
        }
        [Then(@"I see header in the dashboard page as '(.*)'")]
        public void ThenISeeHeaderInTheDashboardPageAs(string header)
        {
            Dashboardenhancementpage.DashboardHeaders(header);
        }
        [When(@"I click on Continued Cases and I should be able to see a message '(.*)'")]
        public void WhenIClickOnContinuedCasesAndIShouldBeAbleToSeeAMessage(string message)
        {
            Dashboardenhancementpage.VerifyNewCasesLinkToPrefilteredInUpcoming341Page(message);
        }
        [Then(@"the Page Navigation '(.*)'")]
        [Then(@"I see CaseNumber '(.*)' in CaseNavigation")]
        public void ThenISeeCaseNumberInCaseNavigation(string navigationDetails)
        {
            Dashboardenhancementpage.VerifyDetailsInCaseNavigationAndPageNavigation(navigationDetails);   
        }
        [Then(@"I click on Epiq Unity Logo in Header")]
        public void ClickOnEpiqUnityLogoInHeader()
        {
            Dashboardenhancementpage.ClickOnEpiqUnityLogoInHeader();
        }
        [Then(@"I  redirected to the '(.*)','(.*)'page")]
        public void RedirectedToAllCasesOrDashboardPage(string cases, string dashboard)
        {
            Dashboardenhancementpage.RedirectedToAllCasesOrDashboardPage(cases, dashboard);
        }

    }
}

