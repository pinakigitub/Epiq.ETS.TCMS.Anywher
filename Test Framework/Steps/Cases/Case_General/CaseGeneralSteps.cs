using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Case_General;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Case_List;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Case_General
{
    public class CaseGeneralSteps : StepBase
    {
        private NewCaseListSearchPage CaseListSearch = new NewCaseListSearchPage(driver);
        Case_General_Page caseGeneral = new Case_General_Page(driver);
        [Then(@"I click on Case Info button")]
        public void ThenIClickOnCaseInfoButton()
        {
            caseGeneral.CaseInfoButton();
        }
        [Then(@"I input '(.*)'")]
        public void ThenIInput(string Inputs)
        {
            var EnterInputs = Inputs.Split(';').Select(i => i.Trim()).ToList();
            caseGeneral.InputFields(EnterInputs);
        }
        [Then(@"I save the Info")]
        public void ThenISaveTheInfo()
        {
            caseGeneral.SaveInfo();
        }
        [Then(@"I verify '(.*)'")]
        public void ThenIVerify(string Values)
        {
            var Fields = Values.Split(';').Select(i => i.Trim()).ToList();
            caseGeneral.FieldValues(Fields);
        }
        [When(@"I Click on Cancel")]
        public void WhenIClickOnCancel()
        {
            caseGeneral.ClickCancel();
        }
        [Then(@"I see Editable Fields as ReadOnlyFields '(.*)', '(.*)' and '(.*)'")]
        public void ThenISeeEditableFieldsAsReadOnlyFieldsAnd(string debtorType, string Judge, string BondAmt)
        {
            caseGeneral.ReadOnlyFields(debtorType, Judge, BondAmt);
        }
        [Then(@"I Close the Case Additional Info")]
        public void ThenICloseTheCaseAdditionalInfo()
        {
            caseGeneral.CloseInfo();
        }
        [Then(@"I see KeyDates '(.*)'")]
        public void ThenISeeKeyDates(string Values)
        {
            var DateFields = Values.Split(';').Select(i => i.Trim()).ToList();
            caseGeneral.VerifyKeyDates(DateFields);
        }
        [Then(@"I see Case Number '(.*)'")]
        public void WhenISeeCaseNumber(string caseNum)
        {
            caseGeneral.VerifyCaseNum(caseNum);
        }
        [Then(@"Debtor Name '(.*)'")]
        public void WhenDebtorName(string debtorName)
        {
            caseGeneral.VerifyDebtorName(debtorName);
        }
        [Then(@"Debtor Attorney '(.*)'")]
        public void WhenDebtorAttorney(string Attorney)
        {
            caseGeneral.VerifyDebtorAttorney(Attorney);
        }
        [Then(@"I see Case Status '(.*)' in Green")]
        public void WhenISeeCaseStatusInGreen(string status)
        {
            caseGeneral.VerifyCaseStatus(status);
        }
        [Then(@"I see CaseType '(.*)' in Orange")]
        public void WhenISeeCaseTypeInOrange(string type)
        {
            caseGeneral.VerifyCaseType(type);
        }
        [When(@"I select NOTES")]
        public void WhenISelectNOTES()
        {
            caseGeneral.SelectNotes();
        }
        [Then(@"I see Notes header contains Case\# '(.*)' and Debtor Name '(.*)'")]
        public void ThenISeeNotesHeaderContainsCaseAndDebtorName(string caseNum, string debtorNam)
        {
            caseGeneral.VerifyNotesHeader(caseNum, debtorNam);
        }
        [Then(@"I see Note Types '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void ThenISeeNoteTypesAnd(string office, string trustee, string form1, string form3, string meeting)
        {
            caseGeneral.VerifyNotesType(office, trustee, form1, form3, meeting);
        }     
        [Then(@"Verify the Notes count of type '(.*)'")]
        public void VerifyNotesCount(string notetype)
        {
            caseGeneral.VerifyNotesCount(notetype);
        }     
        [Then(@"Add Notes of type '(.*)' and '(.*)'")]
        public void AddNotes(string notetype,string header)
        {
            caseGeneral.AddNotes(notetype,header);
        }
        [Then(@"Edit Notes of type '(.*)'")]
        public void EditNotes(string notetype)
        {
            caseGeneral.EditNotes(notetype);
        }
        [Then(@"Verify view Permission '(.*)' and '(.*)'")]
        public void ViewPermission(string notetype,string text)
        {
            caseGeneral.ViewPermission(notetype,text);
        }
        [When(@"I click on cases")]
        public void WhenIClickOnCases()
        {
            caseGeneral.ClickCasesLink();
        }
        [Then(@"'(.*)' page should be displayed")]
        public void ThenPageShouldBeDisplayed(string CaseManagement)
        {
            caseGeneral.CaseManagementPage(CaseManagement);
        }
        [Then(@"I see the DEBTOR ATTORNEY '(.*)'")]
        public void ThenISeeTheDEBTORATTORNEY(string GenAttorney)
        {
            caseGeneral.GeneralInfoDebtorAttorney(GenAttorney);
        }
        [Then(@"I see Case Status '(.*)' and ASSETStatus '(.*)'")]
        public void ThenISeeCaseStatusAndAssetStatus(string status, string AssetType)
        {
            caseGeneral.VerifyGeneralStatus(status, AssetType);
        }
        [Then(@"I see CaseType '(.*)'")]
        public void ThenISeeCaseType(string type)
        {
            caseGeneral.verifyCaseType(type);
        }
        [Then(@"I see an Envelope after Debtor Attorney")]
        public void ThenISeeAnEnvelopeAfterDebtorAttorney()
        {
            caseGeneral.Envelope().Should().BeTrue();
        }
        [Then(@"Case has Tags '(.*)'")]
        public void ThenCaseHasTags(string tag)
        {
            caseGeneral.VerifyTags(tag);
        }
        [Then(@"'(.*)' section should display")]
        public void ThenSectionShouldDisplay(string header)
        {
            caseGeneral.CaseGenParitcipants(header);
        }
        [Then(@"I click on '(.*)' Expand button")]
        public void ThenIClickOnExpandButton(string participantType)
        {
            caseGeneral.ExpandParitcipantDebtor(participantType);
        }
        [Then(@"I able to view '(.*)' Full SSN '(.*)'")]
        public void ThenIAbleToViewFullSSN(string ParticipantType, string ssnNo)
        {
            caseGeneral.SsnView(ParticipantType, ssnNo);
        }
        [Then(@"I able to view '(.*)' Partial SSN '(.*)'")]
        public void ThenIAbleToViewPartialSSN(string ParticipantType, string ssnNo)
        {
            caseGeneral.SsnView(ParticipantType, ssnNo);
        }
        [Then(@"I should not able to view '(.*)' SSN No '(.*)'")]
        public void ThenIShouldNotAbleToViewSSNNo(string ParticipantType, string ssnNo)
        {
            caseGeneral.SsnView(ParticipantType, ssnNo);
        }
        [Then(@"I able to view '(.*)' Details '(.*)'")]
        public void ThenIAbleToViewDetails(string ParticipantType, string ParticipantDetails)
        {
            var Details = ParticipantDetails.Split(';').Select(i => i.Trim()).ToList();
            caseGeneral.ParticipantsDetails(Details);
        }
        [Then(@"I see participants '(.*)'")]
        public void ThenISeeParticipants(string participants)
        {
            var participant = participants.Split(';').Select(i => i.Trim()).ToList();
            caseGeneral.CaseGenParticipants(participant);
        }
        [Then(@"I see the '(.*)' Phone Link")]
        public void ThenISeeThePhoneLink(string participant)
        {
            caseGeneral.ParticipantPhoneLink(participant).Should().BeTrue();
        }
        [Then(@"I click on Unreconciled link for case number '(.*)'")]
        public void ClickOnUnreconciledLink(string casenum)
        {
            caseGeneral.ClickOnUnreconciledLink(casenum);
        }
        [Then(@"I verify default data in filter options as Schedules Tile Linked '(.*)', Claims Tile Linked '(.*)'")]
        public void VerifyDefaultDataInFilterOptions(string schedule, string claim)
        {
            caseGeneral.VerifyDefaultDataInFilterOptions(schedule, claim);
        }
        [Then(@"I verify data in filter options in Claim Reconciliation page")]
        public void VerifyDataInFilterOptionsInClaimReconciliationPage()
        {
            caseGeneral.VerifyDataInFilterOptionsInClaimReconciliationPage();
        }
        [Then(@"I select  ScheduleTileLinked '(.*)', ClaimsTileLinked '(.*)'")]
        public void VerifyFilterOptions(string schedule, string claim)
        {
            caseGeneral.VerifyFilterOptions(schedule, claim);
        }
        [Then(@"I click Reset in filter in Claim Reconciliation page")]
        public void ClickResetInFilterInClaimReconciliationPage()
        {
            caseGeneral.ClickResetInFilterInClaimReconciliationPage();
        }



    }
}
