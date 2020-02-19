using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DashboardExtendNoData;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.DashboardExtendNoData
{
    [Binding]
    class GlobalExtendNoDataSteps : StepBase
    {
        GlobalExtendNoDataPage globalExtendPage = new GlobalExtendNoDataPage(driver);

        [Then(@"I see (.*) header")]
        public void ISeeHeader(string header)
        {
            globalExtendPage.HeaderVerify(header);
        }
        [Then(@"I see (.*) subheader")]
        public void ISeeSubHeader(string subHeader)
        {
            globalExtendPage.SubHeaderVerify(subHeader);
        }
        [Then(@"I see (.*) message")]
        public void ISeeMessage(string message)
        {
            globalExtendPage.MessageVerify(message);
        }
        [Then(@"I see '(.*)' dashboardmessage")]
        public void ISeeDashboardMessage(string dashboardMessage)
        {
            globalExtendPage.DashboardMessageVerify(dashboardMessage);
        }
      }
}