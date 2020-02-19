using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages._341Meeting;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps._341Meeting
{
    [Binding]
    public  class _341Meeting_UpcomingSteps : StepBase
    {
        _341Meeting_Upcoming UpcomingMeeting341 = new _341Meeting_Upcoming(driver);

        [Then(@"I see number of cases in parentheses")]
        public void ThenISeeNumberOfCasesInParentheses()
        {
            UpcomingMeeting341.ValidateCountOfCases().Should().BeTrue();
        }
        [Then(@"Meeting dates should be in Ascending order")]
        public void ThenMeetingDatesShouldBeInAscendingOrder()
        {
            var abv = UpcomingMeeting341.MeetingDatesList();
            var cd = abv.OrderBy(s => s).ToList();
            var nf = abv.OrderByDescending(s => s).ToList();
            UpcomingMeeting341.MeetingDatesList().Should().BeInDescendingOrder();
        }
        [Then(@"I see Unique Time Blocks are available")]
        public void ThenISeeUniqueTimeBlocksAreAvailable()
        {
            UpcomingMeeting341.ValidateTimeBlocks().Should().BeTrue();
        }
        [Then(@"I see Unique Time Blocks are in Blue Oval")]
        public void ThenISeeUniqueTimeBlocksAreInBlueOval()
        {
            UpcomingMeeting341.ValidateTimeBlocksColor();
        }
        [Then(@"I see all time blocks arrow are open")]
        public void ThenISeeAllTimeBlocksArrowAreOpen()
        {
            UpcomingMeeting341.AllArrowPointing_OPEN();
        }
        [When(@"I click on Time Block Arrow")]
        public void WhenIClickOnTimeBlockArrow()
        {
            UpcomingMeeting341.ClickOnTimeBlockArrow();
        }

        [Then(@"I see Time Block Arror is down and closed")]
        public void ThenISeeTimeBlockArrorIsDownAndClosed()
        {
            UpcomingMeeting341.ValidateTimeBlockArrowPointing_CLOSE();
        }
        [Then(@"I click on toggle and success toastr message should be displayed")]
        public void ThenIClickOnToggleAndSuccessToastrMessageShouldBeDisplayed()
        {
            UpcomingMeeting341.Validate_Toggle_Ready_OR_NotReady();
        }
        [When(@"I Click on Meeting date View Button that have more than one cases")]
        public void WhenIClickOnMeetingDateViewButtonThatHaveMoreThanOneCases()
        {
            UpcomingMeeting341.ClickOn341DateViewLink();
        }
        [When(@"I Click on View button on Meeting management")]
        [Then(@"I Click on View button on Meeting management")]
        public void ThenIClickOnViewButtonOnMeetingManagement()
        {
            UpcomingMeeting341.ClickOnViewButton_On_MeetingManagement();
        }
        [Then(@"I see Date and Time displayed header of Meeting View")]
        public void ThenISeeDateAndTimeDisplayedHeaderOfMeetingView()
        {
            UpcomingMeeting341.VerifyDateTime();
        }

        [Then(@"I see the arrows for view of next case")]
        public void ThenISeeTheArrowsForViewOfNextCase()
        {
            UpcomingMeeting341.Validate_CaseHeader_Dropdown();
        }
        [When(@"I click on Right Arrow of Case Header")]
        public void WhenIClickOnRightArrowOfCaseHeader()
        {
            UpcomingMeeting341.ClickOnCaseHeader_RightArrow();
        }
        [When(@"I click on Left Arrow of Case Header")]
        public void WhenIClickOnLeftArrowOfCaseHeader()
        {
            UpcomingMeeting341.ClickOnCaseHeader_LeftArrow();
        }
        [Then(@"page refreshed with Selected case")]
        public void ThenPageRefreshedWithSelectedCase()
        {
            UpcomingMeeting341.ValidatePageRefreshed_With_selectedCaseDetail();
        }
        [Then(@"I see Continued Details Section of Meeting View Page")]
        public void ThenISeeContinuedDetailsSectionOfMeetingViewPage()
        {
            UpcomingMeeting341.Is_ContinuedDetailsSection_Displayed();
        }

        [Then(@"I edit Continued Date on Continued Details Section")]
        public void ThenIEditContinuedDateOnContinuedDetailsSection()
        {
            UpcomingMeeting341.Edit_ContinuedDate();
        }

        [Then(@"I edit Continued Time on Continued Details Section")]
        public void ThenIEditContinuedTimeOnContinuedDetailsSection()
        {
            UpcomingMeeting341.Edit_ContinuedTime();
        }
        [Then(@"I edit and select Continued Reason on Continued Details Section")]
        public void ThenIEditAndSelectContinuedReasonOnContinuedDetailsSection()
        {
            UpcomingMeeting341.Edit_ContinuedReason();
        }
        [When(@"I Click On Save Changes Button")]
        public void WhenIClickOnSaveChangesButton()
        {
            UpcomingMeeting341.ClickOnSaveChanges();
        }

        [Then(@"I see changes are saved and blue color info icon appeared")]
        public void ThenISeeChangesAreSavedAndBlueColorInfoIconAppeared()
        {
            UpcomingMeeting341.is_InfoIcon_displayed().Should().BeTrue();
        }
        [Then(@"I see Verification Status Section on Meeting View Page")]
        public void ThenISeeVerificationStatusSectionOnMeetingViewPage()
        {
            UpcomingMeeting341.Is_VerificationStatusSection_Displayed();
        }

        [Then(@"I see Case Disposition field on Meeting View Page")]
        public void ThenISeeCaseDispositionFieldOnMeetingViewPage()
        {
            UpcomingMeeting341.Is_CaseDisposition_Displayed();
        }

        [Then(@"I see One Click Filing Task field on Meeting View Page")]
        public void ThenISeeOneClickFilingTaskFieldOnMeetingViewPage()
        {
            UpcomingMeeting341.Is_OneClickFilingTaskLabel_Displayed();
        }
        [When(@"I Click on Case Documents Tab Meeting View Page")]
        public void WhenIClickOnCaseDocumentsTabMeetingViewPage()
        {
            UpcomingMeeting341.ClickOnCaseDocumentsTab();
        }

        [Then(@"I see three columns on case documents tab")]
        public void ThenISeeThreeColumnsOnCaseDocumentsTab()
        {
            UpcomingMeeting341.ValidateCaseDocumentsColumns();
        }

        [When(@"I drag case '(.*)' to time slot (.*) PM")]
        public void WhenIDragCaseToTimeSlotPM(string CaseNum, string time)
        {
            UpcomingMeeting341.DragCase(CaseNum, time);
        }
        [Then(@"I click on Expand button (.*) Meeting")]
        public void ThenIClickOnExpandButtonMeeting(int p0)
        {
            UpcomingMeeting341.ClickExpandCollapseButton();
        }
        [Then(@"I MouseHouver on the history icon at Continued Details Section")]
        public void ThenIMouseHouverOnTheHistoryIconAtContinuedDetailsSection()
        {
            UpcomingMeeting341.MouseHouverOnHistoryIcon();
        }

    }
}
