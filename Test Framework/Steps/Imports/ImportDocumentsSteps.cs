using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Imports;
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
    class ImportDocumentsSteps : StepBase
    {
        ImportDocumetsPage importDocuments = new ImportDocumetsPage(driver);

        [When(@"I Click on one Document link of listed cases")]
        public void WhenIClickOnOneDocumentLinkOfListedCases()
        {
            importDocuments.ClickOnDocumentNumberToImportLink();
        }
        [Then(@"I see the Visible headers on Documents In Case are '(.*)' '(.*)' and '(.*)'")]
        public void ThenISeeTheVisibleHeadersOnDocumentsInCaseAreAnd(string h1, string h2, string h3)
        {
            importDocuments.VisibleHeaderExistsDocumentsInCase(h1, h2, h3);
        }
        [When(@"I Click on one DocumentsToImport Tile")]
        public void WhenIClickOnOneDocumentsToImportTile()
        {
            importDocuments.ClickOnDocumentsToImportLink();
        }
        [When(@"I Click on GearButton")]
        public void WhenIClickOnGearButton()
        {
            importDocuments.ClickGearButton();
        }

        [Then(@"I see GearButton is Displayed beside to Documents to Import Header")]
        public void ThenISeeGearButtonIsDisplayedBesideToDocumentsToImportHeader()
        {
            importDocuments.GearIsEnabled().Should().BeTrue();
        }
        


    }

}
