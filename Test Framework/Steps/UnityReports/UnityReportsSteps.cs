using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.UnityReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.UnityReports
{
    [Binding]
    class ReportsSteps : StepBase
    {
        UnityReportsPage unityReportPage = new UnityReportsPage(driver);

        [Given(@"I Go to '(.*)'")]
        public void SelectReport(string reportName)
        {
            unityReportPage.selectReport(reportName);
        }
        [Then(@"verify the report header '(.*)'")]
        public void verifyReportHeader(string reportHeader)
        {
            unityReportPage.verifyReportHeader(reportHeader);
        }
        [Then(@"verify the report sub header '(.*)'")]
        public void verifyReportSubHeader(string reportSubHeader)
        {
            unityReportPage.verifyReportSubHeader(reportSubHeader);
        }
        [Then(@"I click on Checkbox for Export as XML")]
        public void ThenIClickOnCheckboxForExportAsXML()
        {
            unityReportPage.ClickExportXML();
        }

        [Then(@"select '(.*)' as '(.*)'")]
        public void SelectTrusteeDivisionAsset(string labelName,string trusteeName)
        {
            unityReportPage.SelectTrusteeDivisionAsset(labelName, trusteeName);
        }
        [Then(@"select option as '(.*)'")]
        public void SelectOption(string option)
        {
            unityReportPage.SelectOption(option);
        }
        [Then(@"select date '(.*)' as '(.*)'")]
        public void SelectDates(string dateLabel,string dateValue)
        {
            unityReportPage.SelectDates(dateLabel, dateValue);
        }
        [Then(@"verify the added cases information in Report Parameters Grid")]
        public void VerifyTheAddedData()
        {
            unityReportPage.VerifyTheAddedData();
        }
        [Then(@"input case information as '(.*)' for '(.*)'")]
        public void InputCaseInformation(string caseInfo,string option)
        {
            unityReportPage.InputCaseInformation(caseInfo,option);
        }
        [Then(@"click '(.*)'")]
        public void ClickButtons(string buttonName)
        {
            unityReportPage.ClickButtons(buttonName);
        }
        [Then(@"click Clear All to clear the cases data in Report Parameters Grid")]
        public void ClickClearAll()
        {
            unityReportPage.ClickClearAll();
        }
        [Then(@"verify the notification title '(.*)'")]
        [Then(@"verify the notification message '(.*)'")]
        public void VerifyTitleAndNotificationMessage(string notificationMessage)
        {
            unityReportPage.VerifyTitleAndNotificationMessage(notificationMessage);
        }
        [Then(@"close notification")]
        public void CloseNotification()
        {
            unityReportPage.CloseNotification();
        }
        [Then(@"click on ReportQueue close button")]
        public void ClickClose()
        {
            unityReportPage.ClickClose();
        }
        [Then(@"select Report Options To Include as '(.*)'")]
        public void SelectReportOptions(string reportOption)
        {
            unityReportPage.SelectReportOptions(reportOption);
        }
        [Then(@"I search report '(.*)' under Report Queue")]
        public void ThenISearchReportUnderReportQueue(string report)
        {
            unityReportPage.ReportQueueSearch(report);
        }
        [Then(@"I '(.*)' report '(.*)' in queue with current date")]
        public void ThenIReportInQueueWithCurrentDate(string function, string report)
        {
            unityReportPage.VerifyReportUnderReportQueue(function, report);
        }
        [Then(@"select Interim TimePeriod")]
        public void ThenSelectInterimTimePeriod()
        {
            unityReportPage.SelectInterimTimePeriod();
        }

        [Then(@"select Search Add")]
        public void ThenSelectSearchAdd()
        {
            unityReportPage.SelectSearchAdd();
        }
        [Then(@"input case number as '(.*)'")]
        public void ThenInputCaseNumberAs(string casenumber)
        {
            unityReportPage.InputCaseNumber(casenumber);
        }


        [Then(@"I see the same number of records as per the selected PageSize '(.*)'")]
        public void ThenISeeTheSameNumberOfRecordsAsPerTheSelectedPageSize(int size)
        {
            unityReportPage.VerifyRecordsWithPageSize(size);
        }
        [Then(@"input PERCENTOFMARGIN as '(.*)'")]
        public void ThenInputpercentofmargin(string percent)
        {
            unityReportPage.Inputpercentofmargin(percent);
        }
        [Then(@"input DAYSOUTSTANDING as '(.*)'")]
        public void ThenInputDaysOutstanding(string days)
        {
            unityReportPage.ThenInputDaysOutstanding(days);
        }
        [Then(@"I enter '(.*)' as '(.*)'")]
        public void ThenIEnterAs(string label, string value)
        {
            unityReportPage.InputCaseNumberOrDebtorName(label, value);
        }
        [Then(@"click option as '(.*)'")]
        public void ClickCheckBoxValues(string checkOption)
        {
            unityReportPage.ClickCheckBoxValues(checkOption);
        }
        [Given(@"I see Reports text center '(.*)' and sub text '(.*)'")]
        public void GivenISeeReportsTextCenterAndSubText(string centerText, string subText)
        {
            unityReportPage.VerifyReportCenterText(centerText, subText);
        }
        [Then(@"I see Reports List in Alphabetical Order")]
        public void ThenISeeReportsListInAlphabeticalOrder()
        {
            unityReportPage.VerifyReportsListAlphabeticalOrder();
        }
        [Then(@"select Bank")]
        public void SelectBank()
        {
            unityReportPage.SelectBank();
        }
        [Then(@"select Report Options as '(.*)'")]
        public void ReportOptions(string option)
        {
            unityReportPage.ReportOptions(option);
        }
        [Then(@"select Bank as '(.*)'")]
        public void Bank(string bankname)
        {
            unityReportPage.Bank(bankname);
        }
        [Then(@"message '(.*)' should not be visible")]
        public void ThenMessageShouldNotBeVisible(string validationMessage)
        {
            unityReportPage.CaseValidationMessage(validationMessage);
        }
        [Then(@"I inline date fields under Case Dates section")]
        public void ThenIInlineDateFieldsUnderCaseDatesSection()
        {
            unityReportPage.InlineEditDatesSection();
        }
        [Then(@"user click '(.*)'")]
        public void ThenUserClick(string button)
        {
            unityReportPage.ClickOnOkButton(button);
        }
        [Then(@"Click on Include Claim Register button")]
        public void ThenClickOnIncludeClaimRegisterButton()
        {
            unityReportPage.ClickIncludeRadioButton();
        }

        [Then(@"user Verify the pop header as '(.*)'")]
        public void ThenUserVerifyThePopHeaderAs(string header)
        {
            unityReportPage.VerifyPopUpHeader(header);
        }

        [Then(@"user verify the pop up body message as '(.*)'")]
        public void ThenUserVerifyThePopUpBodyMessageAs(string body)
        {
            unityReportPage.VerifyPopUpBody(body);
        }
        [Then(@"validate the Compensation Section error message as '(.*)'")]
        public void ThenValidateTheCompensationSectionErrorMessageAs(string errorMessage)
        {
            unityReportPage.VerifyTrusteeCompensationNoClaim(errorMessage);
        }
        [Then(@"Enter the Trustee Compensation values and freeze the compensation")]
        public void ThenEnterTheTrusteeCompensationValuesAndFreezeTheCompensation()
        {
            unityReportPage.EnterCompensationValues();
        }

    }
}
