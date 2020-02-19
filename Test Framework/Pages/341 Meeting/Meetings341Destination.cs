using System;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Meeting341;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Meeting341
{
    public class Meetings341Destination : UnityPageBase
    {
        //341 Meeting page basics
        private By MEETING_LIST_TAB_TITLE_LOCATOR = By.Id("navItem-341 Meeting List");
        private By PERMISSION_DENIED_ON_PAGE_LOCATOR = By.XPath("//span[@id='errorMessageLabel']");
        private By PAGE_HEADER_LOCATOR = By.XPath("//*[@id='meetingsHeader']//h3");

        //Upcoming meetings
        private By UPCOMING_MEETINGS_TITLE_LOCATOR = By.Id("upcomingMeetingsSectionTitle");
        private By UPCOMING_MEETING_DATE_ROW_LOCATOR = By.CssSelector(".meeting341InformationContainer");
        private By UPCOMING_MEETING_DATE_VALUE_LOCATOR = By.XPath("//*[@class[contains(.,'meeting341InformationContainer')]]/div/div[1]");
        private By UPCOMING_MEETING_VIEW_BUTTON_LOCATOR = By.XPath("//*[@class[contains(.,'viewMeetingContainer')]]");
        private string UPCOMING_MEETING_ROW_BY_DATE_LOCATOR_TEMPLATE = "//*[@class[contains(.,'meeting341InformationContainer')]]/div/div[1][contains(text(),'{0}')]/../../..";

        //Past meetings
        private By PAST_MEETINGS_TITLE_LOCATOR = By.Id("pastMeetingsSectionTitle");
        private By PAST_MEETING_DATE_ROW_LOCATOR = By.CssSelector(".meetingPast341Row");
        private By PAST_MEETING_DATE_VALUE_LOCATOR = By.XPath("//*[@class[contains(.,'meetingPast341Row')]]//*[@class[contains(.,'meeting341date')]]");
        private By PAST_MEETING_VIEW_BUTTON_LOCATOR = By.XPath("//*[@class[contains(.,'meetingPastView')]]");
        private string PAST_MEETING_ROW_BY_DATE_LOCATOR_TEMPLATE = "//*[@class[contains(.,'meetingPast341Row')]]//*[@class[contains(.,'meeting341date')]][contains(text(),'{0}')]/..";

        //Status indicator labels and color circles
        private By INSIDE_ROW_MEETING_LABEL_LOCATOR = By.XPath(".//*[@class[contains(.,'meeting341CircleWrapper')]][2]");
        private By INSIDE_ROW_MEETING_CIRCLE_LOCATOR = By.XPath(".//*[@class[contains(.,'meeting341CircleWrapper')]][2]/i");

        private By INSIDE_ROW_PREPARATION_LABEL_LOCATOR = By.XPath(".//*[@class[contains(.,'meeting341CircleWrapper')]][1]");
        private By INSIDE_ROW_PREPARATION_CIRCLE_LOCATOR = By.XPath(".//*[@class[contains(.,'meeting341CircleWrapper')]][1]/i");

        private By INSIDE_ROW_POST_LABEL_LOCATOR = By.XPath(".//*[@class[contains(.,'meeting341CircleWrapper')]][3]");
        private By INSIDE_ROW_POST_CIRCLE_LOCATOR = By.XPath(".//*[@class[contains(.,'meeting341CircleWrapper')]][3]/i");
        private By NOTES_BAR_LOCATOR = By.XPath("//*[@id='noteIcon']");

        public Meetings341Destination(IWebDriver driver, string title) : base(driver, title)
        {

        }

    }

}