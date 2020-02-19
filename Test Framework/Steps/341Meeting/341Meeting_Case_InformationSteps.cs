using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages._341Meeting;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DSOADD;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps._341Meeting
{

    [Binding]
    public class _341Meeting_Case_InformationSteps : StepBase
    {
        _341Meeting_Case_Information CaseInfo341 = new _341Meeting_Case_Information(driver);
        ADDDSOClaimantPage adddsopage = new ADDDSOClaimantPage(driver);

        [Then(@"I input Current Date in the Fields")]
        public void ThenIInputCurrentDateInTheFields()
        {
            CaseInfo341.CurrentDates();
        }
        [When(@"I click on the View (.*)_Meeting date link")]
        [Then(@"I click on the View (.*)_Meeting date link")]
        public void ThenIClickOnTheView_MeetingDateLink(int p0)
        {
            CaseInfo341.ClickOnViewLink();
        }
        [Given(@"I enter the Date fields '(.*)' and '(.*)'")]
        public void GivenIEnterTheDateFieldsAnd(string fromdate, string todate)
        {
            adddsopage.DateFields(fromdate, todate); ;
        }
        [When(@"I Select '(.*)' as '(.*)'")]
        public void WhenISelectAs(string header, string type)
        {
            CaseInfo341.SelectType(header, type);
        }

        [Then(@"I click Edit DSO Claimant button")]
        public void ThenIClickEditDSOClaimantButton()
        {
            CaseInfo341.ClickOnEditDSOClaimantPencil();
        }
        [Then(@"I input '(.*)' and '(.*)' and '(.*)' and '(.*)' dropdown fields informations")]
        public void Iinpudropdownfieldsinformations(string obligation, string state, string initialnotice, string disnotice)
        {
            CaseInfo341.Inputdropdownfieldsdatas(obligation, state, initialnotice, disnotice);

        }

        [When(@"I click on the (.*)_Meetins day overview View Link")]
        public void WhenIClickOnThe_MeetinsDayOverviewViewLink(int p0)
        {
            CaseInfo341.ClickOnViewOverviewLink();
        }

        [When(@"I try to Click on Debtor Attorney and validate button is disabled")]
        public void WhenITryToClickOnDebtorAttorneyAndValidateButtonIsDisabled()
        {
            CaseInfo341.ClickOnDebtorAttorneyButton();
        }
        [When(@"I click on Ready/NotReady and the button is disabled")]
        public void WhenIClickOnReadyNotReadyAndTheButtonIsDisabled()
        {
            CaseInfo341.ClickOnReadyNotReadyButton();
        }


        [When(@"And I try to Click on Joint Debtor and validate button is disabled")]
        public void WhenAndITryToClickOnJointDebtorAndValidateButtonIsDisabled()
        {
            CaseInfo341.ClickOnJointDebtorButton();
        }

        [When(@"And I try to Click on Joint Debtor Attorney and validate button is disabled")]
        public void WhenAndITryToClickOnJointDebtorAttorneyAndValidateButtonIsDisabled()
        {
            CaseInfo341.ClickOnJointDebtorAttorneyButton();
        }

        [When(@"And I try to Click on Debtor Co-Counsel and validate button is disabled")]
        public void WhenAndITryToClickOnDebtorCo_CounselAndValidateButtonIsDisabled()
        {
            CaseInfo341.ClickOnDebtorCoCounselButton();
        }

        [When(@"And I try to Click on DSO Claimant and validate button is disabled")]
        public void WhenAndITryToClickOnDSOClaimantAndValidateButtonIsDisabled()
        {
            CaseInfo341.ClickOnDSOClaimantAddButton();
        }

        [Then(@"I click on Add Debtor Attorney")]
        public void ThenIClickOnAddDebtorAttorney()
        {
            CaseInfo341.ClickOnAddDebtorAttorney();
        }
        [Then(@"I click on Add  Joint Debtor Attorney")]
        public void ThenIClickOnAddJointDebtorAttorney()
        {
            CaseInfo341.ClickOnAddJointDebtorAttorney();
        }

        [Then(@"I click on Add Debtor CoCounsel")]
        public void ThenIClickOnAddDebtorCoCounsel()
        {
            CaseInfo341.ClickOnAddDebtorCoCounsel();
        }
        [When(@"I select existing Debtor Cocounsel")]
        public void WhenISelectExistingDebtorCocounsel()
        {
            CaseInfo341.ClickOnExistingDebtorCoCounsel();
        }

        [When(@"I enter the input text as '(.*)'")]
        public void WhenIEnterTheInputTextAs(string debtorCoCounsel)
        {
            CaseInfo341.SelectExistingDebtorCoCounsel(debtorCoCounsel);
        }
        [Then(@"I click on the Save Button")]
        public void ThenIClickOnTheSaveButton()
        {
            CaseInfo341.ClickOnSaveButton();
        }
        [Then(@"I click on Add  Joint Debtor")]
        public void ThenIClickOnAddJointDebtor()
        {
            CaseInfo341.ClickOnAddJointDebtor();
        }
        [Then(@"I click on Add  DSO Claimant")]
        public void ThenIClickOnAddDSOClaimant()
        {
            CaseInfo341.ClickOnAddDsoClaimant();
        }

        [Then(@"I see Default value of '(.*)' as '(.*)'")]
        public void ThenISeeDefaultValueOfAs(string header, string value)
        {
            CaseInfo341.VerifyDefaultValues(header, value);
        }
        [Then(@"I see Case '(.*)' with '(.*)'")]
        public void WhenISeeCaseWith(string CaseNum, string Disposition)
        {
            CaseInfo341.VerifyValues(CaseNum, Disposition);
        }
        [When(@"I enter '(.*)' field '(.*)'")]
        public void WhenIEnterField(string header, string DA)
        {
            CaseInfo341.EnterDetorAttorney(header, DA);
        }
        [Then(@"I see Case '(.*)' with DetorAttorney '(.*)'")]
        public void ThenISeeCaseWithDetorAttorney(string CaseNum, string DA)
        {
            CaseInfo341.VerifyDetorAttorney(CaseNum, DA);
        }
        [Then(@"I clear '(.*)' field")]
        public void ThenIClearField(string header)
        {
            CaseInfo341.ClearField(header);
        }

        [Then(@"I input previous Date in the Fields")]
        public void ThenIInputPreviousDateInTheFields()
        {
            CaseInfo341.PreviousDates();
        }

        [Then(@"I click on Edit Debtor Attorney")]
        public void ThenIClickOnEditDebtorAttorney()
        {
            CaseInfo341.ClickOnEditDebtorAttorney();
        }

        [Then(@"I click on Edit Joint Debtor Attorney")]
        public void ThenIClickOnEditJointDebtorAttorney()
        {
            CaseInfo341.ClickOnEditJointDebtorAttorney();
        }

        [Then(@"I click on Edit Debtor CoCounsel")]
        public void ThenIClickOnEditDebtorCoCounsel()
        {
            CaseInfo341.ClickOnEditDebtorCoCounsel();
        }
        [Then(@"I do moveHover on the History Column")]
        public void ThenIDoMoveHoverOnTheHistoryColumn()
        {
            CaseInfo341.ClickOnHistoryColumn();
        }
        [Then(@"I validate that the Debtor Attorney Name is displayed in case overview")]
        public void ThenIValidateThatTheDebtorAttorneyNameIsDisplayedInCaseOverview()
        {
            CaseInfo341.ValidateDebtorAttorneyName().Equals(true);
        }
        [Then(@"I click on View link of the Case '(.*)'")]
        public void ThenIClickOnViewLinkOfTheCase(int num)
        {
            CaseInfo341.ClickView(num);
        }
        [Then(@"I see the header '(.*)'")]
        public void ThenISeeTheHeader(string header)
        {
            CaseInfo341.HeaderMeetingOutcome(header);
        }
        [Then(@"I see the buttons NDR, CONTINUED and MEETING HELD are in Disabled State")]
        public void ThenISeeTheButtonsNDRCONTINUEDAndMEETINGHELDAreInState()
        {
            CaseInfo341.VerifyButtonsAsDisabled();
        }
        [When(@"I click on Meeting OutCome Configurations")]
        public void WhenIClickOnMeetingOutComeConfigurations()
        {
            CaseInfo341.MeetingOutComeConfigurations();
        }
        [Then(@"I see header '(.*)'")]
        public void ThenISeeHeader(string header)
        {
            CaseInfo341.ConfigurationHeader(header);
        }
        [Then(@"I select Settings for NDR '(.*)'")]
        public void ThenISelectSettingsForNDRFileNDR(string NDRoption)
        {
            CaseInfo341.SelectNDRSettings(NDRoption);
        }
        [Then(@"I select Continue Settings '(.*)'")]
        public void ThenISelectContinueSettings(string ContinueOption)
        {
            CaseInfo341.SelectContinueSetting(ContinueOption);
        }
        [Then(@"I select Meeting Held Settings '(.*)'")]
        public void ThenISelectMeetingHeldSettings(string meetingOption)
        {
            CaseInfo341.SelectMeetingSettings(meetingOption);
        }
        [When(@"I click on button '(.*)' then Toast Message appears with header '(.*)' and message '(.*)'")]
        public void WhenIClickOnButtonThenToastMessageAppearsWithHeaderAndMessage(string button, string header, string Msg)
        {
            CaseInfo341.VerifyToastMessage(button, header, Msg);
        }
        [Then(@"I see the buttons NDR, CONTINUED and MEETING HELD are in Enabled State")]
        public void ThenISeeTheButtonsNDRCONTINUEDAndMEETINGHELDAreInEnabledState()
        {
            CaseInfo341.VerifyButtonsAreEnabled();
        }
        [Then(@"I verify the '(.*)' Edit Pencil Icon '(.*)'")]
        public void ThenIVerifyTheEditPencilIcon(string Name, int num)
        {
            CaseInfo341.VerifyEditIcon(Name, num);
        }
        [When(@"I click on the '(.*)' Edit Pencil Icon '(.*)'")]
        public void WhenIClickOnTheEditPencilIcon(string Name, int num)
        {
            CaseInfo341.ClickPencilIcon(Name, num);
        }
        [Then(@"I See '(.*)' Page")]
        public void ThenISeePage(string header)
        {
            CaseInfo341.PageHeader.Should().Be(header);
        }
        [Then(@"I see CASE INFORMATION section is by default Open")]
        public void ThenISeeCASEINFORMATIONSectionIsByDefaultOpen()
        {
            CaseInfo341.CaseInformation().Should().BeTrue();
        }
        [When(@"I click on Collapse button of CASE INFORMATION")]
        public void WhenIClickOnCollapseButtonOfCASEINFORMATION()
        {
            CaseInfo341.CloseCaseInformation();
        }
        [Then(@"I see CASE INFORMATION section is Closed")]
        public void ThenISeeCASEINFORMATIONSectionIsClosed()
        {
            CaseInfo341.CaseInformation();
        }
        [Then(@"I click on Expand button of CASE INFORMATION")]
        public void ThenIClickOnExpandButtonOfCASEINFORMATION()
        {
            CaseInfo341.OpenCaseInformation();
        }
        [When(@"I enter '(.*)' in Digital Recording")]
        public void WhenIEnterInDigitalRecording(string text)
        {
            CaseInfo341.EnterText(text);
        }
        [Then(@"I see the the text '(.*)' saved in Digital Recording")]
        public void ThenISeeTheTheTextSavedInDigitalRecording(string text)
        {
            CaseInfo341.VerifyDigitalRecordingText(text);
        }
        [Then(@"I see '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void ThenISeeAnd(string debtor, string JD, string DA, string JDA, string DebtorCoCounsel, string Claimant)
        {
            CaseInfo341.VerifyCaseInfo(debtor, JD, DA, JDA, DebtorCoCounsel, Claimant);
        }
        [Then(@"I verify the '(.*)', '(.*)' as '(.*)'")]
        public void ThenIVerifyTheAs(string designation, int num, string Name)
        {
            CaseInfo341.VerifyDetails(designation, num, Name);
        }
        [When(@"I expand '(.*)', '(.*)' then I verify NAME '(.*)', SSN '(.*)', ID '(.*)'")]
        public void WhenIExpandThenIVerifyNAMESSNID(int num, string designation, string name, string ssn, string id)
        {
            CaseInfo341.VerifyNameSsnId(num, designation, name, ssn, id);
        }
        [When(@"I expand '(.*)', '(.*)' and verify CONTACT INFO Address '(.*)', '(.*)', Phone No '(.*)', Email '(.*)' and Employee Info '(.*)'")]
        public void WhenIExpandAndVerifyCONTACTINFOAddressPhoneNoEmailAndEmployeeInfo(int num, string designation, int i, string address, string phone, string email, string info)
        {
            CaseInfo341.VerifyContactInfoAndEmployeeInfo(num, designation, i, address, phone, email, info);
        }
        [When(@"I expand '(.*)', '(.*)' then I should not able to see SSN '(.*)'")]
        public void WhenIExpandThenIShouldNotAbleToSeeSSN(int num, string designation, string ssn)
        {
            CaseInfo341.VerifySSNView(num, designation, ssn);
        }
        [When(@"I expand '(.*)', '(.*)' then I should able to see partial SSN '(.*)'")]
        public void WhenIExpandThenIShouldAbleToSeePartialSSN(int num, string designation, string ssn)
        {
            CaseInfo341.VerifySSNView(num, designation, ssn);
        }
        [Then(@"I perform inline edit for contd date and contd time in the case information page")]
        public void ThenIPerformInlineEditForContdDateAndContdTimeInTheCaseInformationPage()
        {
            CaseInfo341.EnterTheContinuedDetails();
        }
        [Then(@"I validate the Contd date and DSO is displayed in the case list page")]
        public void ThenIValidateTheContdDateAndDSOIsDisplayedInTheCaseListPage()
        {
            CaseInfo341.DisplayDetails().Equals(true);
        }
        [Then(@"I verify the VERIFICATION STATUS")]
        public void ThenIVerifyTheVERIFICATIONSTATUS()
        {
            CaseInfo341.VerifyVerficationStatus();
        }
        [Then(@"I Verify the DEBTOR VERFICATION SECTION")]
        public void ThenIVerifyTheDEBTORVERFICATIONSECTION()
        {
            CaseInfo341.VerifyDebtorVerficationSection();
            CaseInfo341.ValidateToggleButton();
        }
        [Then(@"I verify the toggle is clickable")]
        public void ThenIVerifyTheToggleIsClickable()
        {
            CaseInfo341.ValidateToggleButton();
        }
        [Then(@"I select the Meeting Debtor status '(.*)'")]
        public void ThenISelectTheMeetingDebtorStatus(string debtorMeetingStatus)
        {
            CaseInfo341.SelectDebtorMeetingStatus(debtorMeetingStatus);
        }
        [Then(@"I select the Joint Debtor status as '(.*)'")]
        public void ThenISelectTheJointDebtorStatusAs(string jointDebtorMeetingStatus)
        {
            CaseInfo341.SelectJointDebtorMeetingStatus(jointDebtorMeetingStatus);
        }
        [Then(@"I Validate the Ready or not ready toggle in the case information left menu")]
        public void ThenIValidateTheReadyOrNotReadyToggleInTheCaseInformationLeftMenu()
        {
            CaseInfo341.ValidateReadyToggleButton();
        }
        [Then(@"Validate that ReadyToggle button is disabled")]
        public void ThenValidateThatReadyToggleButtonIsDisabled()
        {
            CaseInfo341.MouseHoverOnReadyToggleButton();
        }
        [When(@"I click '(.*)'")]
        public void WhenIClick(string uploadLink)
        {
            CaseInfo341.SelectUploadDocument(uploadLink);
        }
        [Then(@"I see Case\# and DebtorName '(.*)'")]
        public void ThenISeeCaseAndDebtorName(string details)
        {
            CaseInfo341.CaseDetails(details);
        }
        [When(@"the User Uploads the Document in new window")]
        public void WhenTheUserUploadsTheDocumentInNewWindow()
        {
            CaseInfo341.UploadDocument();
        }
        [Then(@"I should not be able to Upload the second Document")]
        public void ThenIShouldNotBeAbleToUploadTheSecondDocument()
        {
            CaseInfo341.VerifyUploadingSecondDocument();
        }
        [When(@"I delete the Uploaded document")]
        public void WhenIDeleteTheUploadedDocument()
        {
            CaseInfo341.DeleteUploadedDocument();
        }
        [When(@"I select Report '(.*)'")]
        public void WhenISelectReport(string reportType)
        {
            CaseInfo341.SelectReportType(reportType);
        }
        [Then(@"I save the Configure Meeting Batch Settings")]
        public void ThenISaveTheConfigureMeetingBatchSettings()
        {
            CaseInfo341.SaveConfigurations();
        }
        [When(@"I see '(.*)' contains '(.*)'")]
        public void WhenISeeContainsAppearedVerified(string configurationHeader, string options)
        {
            CaseInfo341.VerifyConfigurationOption(configurationHeader, options);
        }
        [Then(@"Verify the Pop up header as'(.*)'")]
        public void ThenVerifyThePopUpHeaderAs(string header)
        {
            CaseInfo341.VerifyPopupHeader(header);
        }

        [Then(@"Verify the modal pop up paragragh text\.")]
        public void ThenVerifyTheModalPopUpParagraghText_()
        {
            CaseInfo341.VerifyPopUpParagragh();
        }

        [Then(@"Verify the toast message title as '(.*)'")]
        public void ThenVerifyTheToastMessageTitleAs(string title)
        {
            CaseInfo341.VerifyToastTitle(title);
        }
        [Then(@"I click on DOWNLOAD button on the pop up")]
        public void ThenIClickOnDOWNLOADButtonOnThePopUp()
        {
            CaseInfo341.ClickOnPopUpDownload();
        }
        [Then(@"I select sort by '(.*)'")]
        public void ThenISelectSortBy(string value)
        {
            CaseInfo341.SelectSortBy(value);
        }

    }
}
