using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using System.Collections;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Imports
{
    [Binding]
    class ImportDatesSteps : StepBase
    {
        ImportDatesPage importDates = new ImportDatesPage(driver);

        [When(@"I Click on one Dates Link on Dates to Import Page")]
        public void WhenIClickOnOneDatesLinkOnDatesToImportPage()
        {
            importDates.ClickOnDocumentNumberToImportLink();
        }
        [Then(@"I see Import and Ignore Buttons as Disabled")]
        public void ThenISeeImportAndIgnoreButtonsAsDisabled()
        {
            importDates.ImportIsDisabled().Equals(true);
            importDates.IgnoreIsDisabled().Equals(true);
         }
    }
}
