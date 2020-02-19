using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Meeting341;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Meeting341
{
    [Binding]
    public class Meeting341ListSteps: SignedInUnityUserSteps
    {
        private Meetings341Destination meeting341Page = ((Meetings341Destination)GetSharedPageObjectFromContext("341 Meeting"));

        [When(@"I Go to Meeting Meeting Page through the Navigation Bar")]
        public void WhenIGoToMeetingMeetingPageThroughTheNavigationBar()
        {
            DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
            SetSharedPageObjectInCurrentContext("341 Meeting", dashboardPage.NavigationBar.GoTo341MeetingList());
        }

    }
}
