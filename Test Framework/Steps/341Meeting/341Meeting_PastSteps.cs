using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages._341Meeting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps._341Meeting
{
    [Binding]
    public  class _341Meeting_PastSteps:StepBase
    {
        _341Meeting_Past PastMeeting = new _341Meeting_Past(driver);

        [When(@"I click on LeftArrow then I see the last Meeting date '(.*)'")]
        public void WhenIClickOnLeftArrowThenISeeTheLastMeetingDate(string lastMeeting)
        {
            PastMeeting.VerifyLastMeetingDate(lastMeeting);
        }
        [When(@"I click on RightArrow then I see the first Meeting date '(.*)'")]
        public void WhenIClickOnRightArrowThenISeeTheFirstMeetingDate(string firstMeeting)
        {
            PastMeeting.VerifyFirstMeetingDate(firstMeeting);
        }
        [Then(@"I see dropdown of Meeting dates in Descending order")]
        public void ThenISeeDropdownOfMeetingDatesInDescendingOrder()
        {
            var list = PastMeeting.DatesDescendingOrder();
            list.Should().BeInDescendingOrder();
        }
        [Then(@"I Verify the No\.of Cases tied to date")]
        public void WhenIVerifyTheNo_OfCasesTiedToDate()
        {
            PastMeeting.CasesCount();
        }
        [Then(@"I verify the cases displayed in Meeting Time order")]
        public void ThenIVerifyTheCasesDisplayedInMeetingTimeOrder()
        {
            PastMeeting.MeetingTimeOrder();
        }
        [Then(@"I click on Expand and Collapse button")]
        public void ThenIClickOnExpandAndCollapseButton()
        {
            PastMeeting.ExpandAndCollapse();
        }
        [Then(@"I see Debtor Attorney name '(.*)' with an Envelope")]
        public void ThenISeeDebtorAttorneyNameWithAnEnvelope(string debtor)
        {
            PastMeeting.VerifyDebtorAttorneyField(debtor);
        }

        [Then(@"I select Case as '(.*)'")]
        public void ThenISelectCaseAsForCase(string type)
        {
            PastMeeting.SelectTaskType(type);
        }
        [Then(@"I see the successful Toast message '(.*)'")]
        public void ThenISeeTheSuccessfulToastMessage(string SuccessMsg)
        {
            PastMeeting.VerifyToastMessage(SuccessMsg);
        }
        [When(@"I change the MeetingTime of '(.*)' from '(.*)' to '(.*)'")]
        public void WhenIChangeTheMeetingTimeOfFromTo(string caseNum, string time1, string time2)
        {
            PastMeeting.changeMeetingTime(caseNum, time1, time2);
        }
        [Then(@"I see the case '(.*)' under TimeOrder of '(.*)'")]
        public void ThenISeeTheCaseUnderTimeOrderOf(string caseNum, string timeOrder)
        {
            PastMeeting.VerifyCaseUnderTimeOrder(caseNum, timeOrder);
        }
        [Then(@"I revert the MeetingTime of '(.*)' from '(.*)' to '(.*)'")]
        public void ThenIChangeTheMeetingTimeOfFromTo(string caseNum, string time1, string time2)
        {
            PastMeeting.RevertMeetingTime(caseNum, time1, time2);
        }
        [Then(@"I drag the Case '(.*)' to position of Case '(.*)'")]
        public void ThenIDragTheCaseToPositionOfCase(string CaseNum1, string CaseNum2)
        {
            PastMeeting.VerifyDragAndDrop(CaseNum1, CaseNum2);
        }
        [Then(@"I revert the position of Case '(.*)' to Case '(.*)'")]
        public void ThenIRevertThePositionOfCaseToCase(string CaseNum2, string CaseNum1)
        {
            PastMeeting.RevertDragAndDrop(CaseNum2, CaseNum1);
        }
        [Then(@"I see (.*)Meeting header has same date")]
        public void ThenISeeMeetingHeaderHasSameDate(int p0)
        {
            PastMeeting.ValidateHeader();
        }
        [Then(@"I see (.*)Meeting overview page")]
        public void ThenISeeMeetingOverviewPage(int p0)
        {
            PastMeeting.ValidateMeetingOverviewPage();
        }
        [Given(@"I see '(.*)' contains '(.*)'")]
        public void GivenISeeContains(string header, string text)
        {
            PastMeeting.VerifyDashboardPastMeetingSection(header, text);
        }
        [Then(@"I select the Case Disposition '(.*)'")]
        public void ThenISelectTheCaseDisposition(string CaseDisposition)
        {
            PastMeeting.SelectCaseDisposition(CaseDisposition);
        }

        [Then(@"I see the toast message on (.*) Past Meeting")]
        public void ThenISeeTheToastMessageOnPastMeeting(int p0)
        {
            PastMeeting.ToastMessageDisplayed();
        }

        [Then(@"I mouseover on Alert icon")]
        public void ThenIMouseoverOnAlertIcon()
        {
            PastMeeting.MouseHoverAlert();
        }
        [Then(@"I see the Case '(.*)' status as '(.*)'")]
        public void ThenISeeTheCaseStatusAs(string caseNum, string status)
        {
            PastMeeting.VerifyCaseStatus(caseNum, status);
        }
        [Then(@"I see the Case '(.*)' Asset Status as '(.*)'")]
        public void ThenISeeTheCaseAssetStatusAs(string caseNum, string status)
        {
            PastMeeting.VerifyAssetStatus(caseNum, status);
        }
        [Then(@"I see the Case '(.*)', '(.*)' as '(.*)' Case")]
        public void ThenISeeTheCaseAsCase(string caseNum, int num, string dso)
        {
            PastMeeting.VerifyDSOCase(caseNum, num, dso);
        }

    }
}
