using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Dashboard;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    [Binding]
    public class ContactEpiqSteps:StepBase
    {
        ContactEpiqPage ContactEpiq = new ContactEpiqPage(driver);
        //REFACTORED
        [When(@"I Open the User Menu from the Application Bar")]
        public void WhenIOpenTheUserMenuFromTheApplicationBar()
        {
            DashboardPage dashboardPage = ((DashboardPage) GetSharedPageObjectFromContext("Dashboard"));
            dashboardPage.UniversalApplicationBar.OpenUserMenu();
        }
        [When(@"I Should be able to see the link with reference")]
        public void WhenIShouldBeAbleToSeeTheLinkWithReference()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'contactepiq@epiqsystems.com')]"));
            Thread.Sleep(2000);

        }
        [When(@"I Should be able to see the phone number")]
        public void WhenIShouldBeAbleToSeeThePhoneNumber()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'1-800-444-6666')]"));
        }
        [When(@"I Should navigate to home page")]
        public void WhenIShouldNavigateToHomePage()
        {
            driver.FindElement(By.XPath("//div[2]/div/div/div/div/div[2]"));
            Thread.Sleep(3000);
        }
        [Then(@"I see Help heading '(.*)'")]
        [When(@"I see Help heading '(.*)'")]
        public void WhenISeeHelpHeading(string expectedTitle)
        {
            ContactEpiq.HelpHeading(expectedTitle);
        }
        [Then(@"help text '(.*)'")]
        public void WhenHelpText(string expectedText)
        {
            ContactEpiq.HelpText(expectedText);
        }
        [Then(@"a Email Link with reference'(.*)'")]
        public void WhenAEmailLinkWithReference(string ExpectedEmailLink)
        {
            ContactEpiq.EpiqEmailLink(ExpectedEmailLink);
        }
        [Then(@"Number to Contant '(.*)'")]
        public void WhenNumberToContant(string ExpectedContactNo)
        {
            ContactEpiq.EpiqContactNo(ExpectedContactNo);
        }

    }
}
