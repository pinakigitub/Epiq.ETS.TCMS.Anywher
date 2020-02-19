using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Emails;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Emails
{
    public class EmailsSteps : StepBase
    {
        EmailsPage email = new EmailsPage(driver);

        [Then(@"'(.*)' header should be displayed on Email Page")]
        public void ThenHeaderShouldBeDisplayedOnEmailPage(string header)
        {
            email = ((EmailsPage)GetSharedPageObjectFromContext("Emails"));
            email.GetHeaderName().Should().Contain(header);
        }
        [Then(@"I see all Expected headers on Emails Page")]
        public void ThenISeeAllExpectedHeadersOnEmailsPage()
        {
            email.VerifyHeaders();
        }
        [Then(@"I see all Case level Expected headers on Emails Page")]
        public void ThenISeeAllCaseLevelExpectedHeadersOnEmailsPage()
        {
            email.VerifyCaseLevelHeaders();
        }
        [When(@"I Click On Filter Icon on Emails Page")]
        public void WhenIClickOnFilterIconOnEmailsPage()
        {
            email.ClickOnFilter();
        }
        [When(@"I select date '(.*)' from DATE\(FROM\) on Emails filter")]
        public void WhenISelectDateFromDATEFROMOnEmailsFilter(string fromDate)
        {
            email.SelectDateFrom(fromDate);
        }
        [When(@"I select date '(.*)' from DATE\(TO\) on Emails filter")]
        public void WhenISelectDateFromDATETOOnEmailsFilter(string toDate)
        {
            email.SelectDateTo(toDate);
        }
        [When(@"I click on Close button of email filter")]
        public void WhenIClickOnCloseButtonOfEmailFilter()
        {
            email.ClickOnClose();
        }
        [Then(@"I see filter result has date '(.*)' only on Email page")]
        public void ThenISeeFilterResultHasDateOnlyOnEmailPage(string expectedDate)
        {
            email.ValidateRecords(expectedDate);
        }
        [Then(@"I See Filter Funnel displaying the count of filter Result")]
        public void ThenISeeFilterFunnelDisplayingTheCountOfFilterResult()
        {
            email.ValidateFilterFunnelCount().Should().BeTrue();
        }
    }
}
