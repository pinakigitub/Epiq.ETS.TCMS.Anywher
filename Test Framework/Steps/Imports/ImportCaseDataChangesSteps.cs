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
    class ImportCaseDataChangesSteps : StepBase
    {
        ImportCaseDataChangesPage importCaseData = new ImportCaseDataChangesPage(driver);
        [Then(@"I see GearButton is Displayed beside to Case Data Changes Header")]
        public void ThenISeeGearButtonIsDisplayedBesideToCaseDataChangesHeader()
        {
            
        }

        [Then(@"I view column names in ImportCaseData table")]
        public void ThenIViewColumnNamesInImportCaseDataTable()
        {
            importCaseData.ViewColumnNames();
        }

        [Then(@"I view breifcase icon is displayed")]
        public void ThenIViewBreifcaseIconIsDisplayed()
        {
            importCaseData.VerifyBreifCaseIcon();
        }

        [Then(@"I view no data to display message")]
        public void ThenIViewNoDataToDisplayMessage()
        {
            importCaseData.VerifyNoDataDisplay();
        }

    }
}