using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Pariticipants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Participants
{
    public class ParticipantRolesSteps : StepBase
    {
        ParticipantRolesPage PariticipantRoles = new ParticipantRolesPage(driver);
        [Given(@"I click on Add Paritipant")]
        public void GivenIClickOnAddParitipant()
        {
            PariticipantRoles.AddParticipant();
        }
        [Then(@"I navigate back to the '(.*)' Page")]
        public void ThenINavigateBackToThePage(string title)
        {
            PariticipantRoles.PariticipantsPage(title);
        }
        [When(@"I input participant title as '(.*)' for '(.*)'")]
        public void WhenIInputParticipantTitleAsFor(string title, string participantType)
        {
            PariticipantRoles.InputTitle(title, participantType);
        }
        [When(@"I input Participant FIRSTNAME '(.*)', MIDDLENAME '(.*)', LASTNAME '(.*)' AND SUFFIX '(.*)'")]
        public void WhenIInputParticipantFIRSTNAMEMIDDLENAMELASTNAMEANDSUFFIX(string firstName, string middleName, string lastName, string suffix)
        {
            PariticipantRoles.InputNames(firstName, middleName, lastName, suffix);
        }
        [When(@"I input GENDER '(.*)', STATE BAR ID '(.*)', SSN '(.*)', TAX ID '(.*)' and DRIVER LICENSE '(.*)'")]
        public void WhenIInputGENDERSTATEBARIDSSNTAXIDAndDRIVERLICENSE(string gender, string barId, string ssn, string taxId, string license)
        {
            PariticipantRoles.EnterDetails(gender, barId, ssn, taxId, license);
        }
        [When(@"I enter '(.*)' details Type '(.*)' and Name '(.*)'")]
        public void WhenIEnterDetailsType(string alias, string type, string name)
        {
            PariticipantRoles.InputAliasDetails(alias, type, name);
        }
        [When(@"I enter '(.*)' details Type '(.*)' and PhoneNum '(.*)'")]
        public void WhenIEnterAndPhoneNum(string phone, string type, string phoneNumber)
        {
            PariticipantRoles.InputPhoneDetails(phone, type, phoneNumber);
        }
        [When(@"I enter '(.*)' details Type '(.*)' and Email '(.*)'")]
        public void WhenIEnterAndEmail(string email, string type, string emailAddress)
        {
            PariticipantRoles.InputEmailDetails(email, type, emailAddress);
        }
        [When(@"I enter '(.*)' details Type '(.*)', Address Line1 '(.*)', Line2 '(.*)', City '(.*)', state '(.*)' and Zip '(.*)'")]
        public void WhenIEnterAddressState(string address, string type, string addressLine1, string addressLine2, string city, string state, string zip)
        {
            PariticipantRoles.InputAddressDetails(address, type, addressLine1, addressLine2, city, state, zip);
        }
        [When(@"I Add '(.*)' to the participant '(.*)', '(.*)', '(.*)' and '(.*)'")]
        public void WhenIAddToTheParticipant(string role, string role1, string role2, string role3, string role4)
        {
            PariticipantRoles.AddRoles(role, role1, role2, role3, role4);
        }
        [When(@"I enter the Notes '(.*)'")]
        public void WhenIEnterTheNotes(string notes)
        {
            PariticipantRoles.EnterNotes(notes);
        }
        [Then(@"I SAVE the Participant")]
        public void ThenISAVETheParticipant()
        {
            PariticipantRoles.ClickSave();
        }
        [Given(@"I Enter Participant Name '(.*)'")]
        public void GivenIEnterParticipantName(string participantName)
        {
            PariticipantRoles.EnterParticipantName(participantName);
        }

        [Then(@"I See the Participant Name saved with Name '(.*)'")]
        public void ThenISeeTheParticipantNameSavedWithName(string participantName)
        {
            PariticipantRoles.VerifySavedParticipant(participantName);
        }
        [Given(@"I Edit the participant '(.*)'")]
        public void GivenIEditTheParticipant(string name)
        {
            PariticipantRoles.EditParticipant(name);
        }
        [When(@"I remove Alias and Email Details")]
        public void WhenIRemoveAliasAndEmailDetails()
        {
            PariticipantRoles.RemoveAliasAndEmail();
        }

        [Given(@"I select participant '(.*)' containing Role '(.*)'")]
        public void GivenISelectParticipantContainingRole(string name, string roleType)
        {
            PariticipantRoles.ParticipantMultipleRoles(name, roleType);
        }
        [Given(@"I verify header title '(.*)'")]
        public void GivenIVerifyHeaderTitle(string modalTitle)
        {
            PariticipantRoles.RolesModalTitle(modalTitle);
        }
        [Given(@"I verify the Alphabetical Order of Roles")]
        public void GivenIVerifyTheAlphabeticalOrderOfRoles()
        {
            PariticipantRoles.VerifyAlphabeticalOrder();
        }
        [Given(@"I close the modal Roles")]
        public void GivenICloseTheModalRoles()
        {
            PariticipantRoles.CloseRolesModal();
        }
        [Given(@"I select type '(.*)'")]
        public void GivenISelectType(string type)
        {
            PariticipantRoles.SelectType(type);
        }
    }
}
