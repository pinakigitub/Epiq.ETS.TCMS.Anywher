using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.UnityReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.UnityReports
{
    [Binding]
    class UFRReportsSteps : StepBase
    {
        UnityReportsPage unityReportPage = new UnityReportsPage(driver);


        //[Then(@"I click on Checkbox for Export as XML")]
        //public void ThenIClickOnCheckboxForExportAsXML()
        //{
        //    unityReportPage.ClickExportXML();
        //}

    }
}
