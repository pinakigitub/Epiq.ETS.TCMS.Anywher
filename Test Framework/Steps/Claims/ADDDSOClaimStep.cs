using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DSOADD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.DSOADD
{
    [Binding]
   public class ADDDSOClaimantSteps : StepBase
    {
        ADDDSOClaimantPage addDsoPage = new ADDDSOClaimantPage(driver);

        [Then(@"I see breadcrumb(.*) and subheader(.*)")]
        public void IseeBreadcrumbandsubheader(string breadCrumb, string subHeader)
        {
            addDsoPage.BreadCrumbSubheaderVerify(breadCrumb, subHeader);
        }
        [Then(@"Verify sorting on Grid '(.*)'")]
        public void Sort(string column)
        {
            var actualList = addDsoPage.SortingColumns(column);
            actualList.Should().BeInAscendingOrder();
            actualList = addDsoPage.SortingColumns(column);
            actualList.Should().BeInDescendingOrder();
        }
       [Then(@"I search(.*) information and I select (.*)")]
        public void IselectsearchInfo(string search, string caseName)
        {
            addDsoPage.SearchInfo(search, caseName);
        }
        [Then(@"I input all the fields data '(.*)' and '(.*)' and '(.*)' and '(.*)' and '(.*)'")]
        public void IInputAllTheFieldsData(string fromDate, string toDate, string caseStatus, string dsoInitial, string dsoNotice)
        {
            addDsoPage.DateFields(fromDate, toDate);
            addDsoPage.DropdownFields(caseStatus, dsoInitial, dsoNotice);
        }
        [Then(@"verify the filtered data on Grid '(.*)' and '(.*)'")]
        public void VerifyGrid(string fromDate,string toDate)
        {
            addDsoPage.FilteredDataOnGrid(fromDate,toDate);
        }
        [Then(@"I click Reset")]
        public void IClickReset()
        {
            addDsoPage.ClickReset();
        }
        [When(@"I click DSO claimant on DSO Page")]
        [Then(@"check Dso claimant on DSO Page")]
        public void ClickDsoClaimantOnDSOPage()
        {
            addDsoPage.DsoClaimantClick();
        }
        [Then(@"I see (.*) header on Claimants page")]
        public void ISeeAddDsoClaimantsHeader(string expectedHeader)
        {
            addDsoPage.VerifyAddDsoClaimantsHeader(expectedHeader);
        }
        [Then(@"Input '(.*)' and I select debtorname '(.*)'")]
        public void InputTextFieldsInformation(string search, string caseName)
        {
            addDsoPage.SelectDebtorName(search, caseName);
        }
        [Then(@"I input '(.*)' and '(.*)' and '(.*)' text fields information")]
        public void IInputTextFieldsInformation(string dsoName, string address, string phone)
        {
            addDsoPage.InputTextFieldsData(dsoName, address, phone);
        }
        [Then(@"I input '(.*)' and '(.*)' and '(.*)' and '(.*)' dropdown fields information")]
        public void IInpuDropdownFieldsInformation(string obligation, string state, string initialNotice, string disNotice)
        {
            addDsoPage.InputDropdownFieldsData(obligation, state, initialNotice, disNotice);
        }
        [Then(@"I search with Joint debtor '(.*)' and I select '(.*)'")]
        [Then(@"I Save claimant")]
        public void ISaveClaimant()
        {         
            addDsoPage.SaveClaim();
        }
        [When(@"I select '(.*)' type")]
        [When(@"I select '(.*)'")]
        public void ISelectParticipantType(string selectType)
        {
            addDsoPage.SelectParticipantType(selectType);
        }
        [Then(@"I input Joint Debtor title as '(.*)'")]
        [Then(@"I input Debtor title as '(.*)'")]
        public void IInputTitle(string title)
        {
            addDsoPage.InputTitle(title);
        }
        [Then(@"Input '(.*)' Joint Debtor Firstname as '(.*)' and MiddleName as '(.*)' and Lastname as '(.*)' for Individual")]
        [Then(@"Input '(.*)' Debtor Firstname as '(.*)' and MiddleName as '(.*)' and Lastname as '(.*)' for Individual")]
        public void IInputNameFields(string debtorType,string firstName, string middleName, string lastName)
        {
            addDsoPage.InputNameFields(debtorType,firstName, middleName, lastName);
        }
        [When(@"I input '(.*)' Payee displayname as '(.*)' for Corporation")]
        [When(@"I input '(.*)' Debtor displayname as '(.*)' for Corporation")]
        public void IInputDebtorPayeeDisplayName(string payeeType,string displayName)
        {
            addDsoPage.InputDetorPayeeDisplayName(payeeType,displayName);
        }
        [When(@"I select Joint debtor '(.*)'")]
        public void IInputJointDebtor(string jointDebtorType)
        {
            addDsoPage.InputJointDebtorType(jointDebtorType);
        }

        [When(@"I input Joint Debtor displayname as '(.*)' for Corporation")]
        public void InputJointDebtorDisplayName(string jointDebtorDisplayName)
        {
            addDsoPage.InputJointDetorDisplayName(jointDebtorDisplayName);
        }

        [Then(@"Verify the added record on Grid using climant name'(.*)'")]
        public void verifyaddedRecordonGrid(string cliamantName)
        {
            addDsoPage.VerifyAddedRecordonGrid(cliamantName);
        }

        [Then(@"I can select first record in page")]
        public void ThenICanSelectFirstRecordInPage()
        {
            addDsoPage.SelectFirstRecord();
        }

        [When(@"I can select all option in the header")]
        public void WhenICanSelectAllOptionInTheHeader()
        {
            addDsoPage.SelectAllRecords();
        }

        [When(@"I can Deselect all option in the header")]
        public void WhenICanDeSelectAllOptionInTheHeader()
        {
            addDsoPage.SelectAllRecords();
        }

        [When(@"I can select first record in dso page")]
        public void WhenICanSelectFirstRecordInDsoPage()
        {
            addDsoPage.SelectFirstRecord();
        }

        [Then(@"input Edit fields information Address '(.*)' and Phone '(.*)'")]
        public void EditAddedRecord(string address,string phone)
        {
            addDsoPage.EditRecord(address,phone);
        }

        [Then(@"Verify for View icon symbol '(.*)'")]
        public void VerifyViewIcon(int i)
        {
            addDsoPage.VerifyViewIcon(i);
        }

        [Then(@"I edit '(.*)', '(.*)', '(.*)'")]
        public void ThenIEdit(string header, int num, string text)
        {
            addDsoPage.EditFields(header, num, text);
        }

        [Then(@"the '(.*)', '(.*)' should contain '(.*)'")]
        public void ThenTheShouldContain(string header, int num, string text)
        {
            addDsoPage.VerifyDetails(header, num, text);
        }

        [Then(@"I edit the '(.*)', '(.*)', '(.*)'")]
        public void ThenIEditThe(string header, int num, string text)
        {
            addDsoPage.CancelEditFields(header, num, text);
        }

        [Then(@"I see InLineEdit Fields are No more Editable")]
        public void ThenISeeInLineEditFieldsAreNoMoreEditable()
        {
            addDsoPage.ViewOnlyInLineEdit();
        }
       
        [Then(@"I See dates are filled in filter")]
        public void ThenISeeDatesAreFilledInFilter()
        {
            addDsoPage.Verify_DateField_areFilled().Should().BeTrue();
            driver.FindElement(By.XPath("//div[@class='pull-right form-group epiq-fa']//i")).Click();//filter close
        }
        [Then(@"I can click on delete button in the DSO Page")]
        public void ThenICanClickOnDeleteButtonInTheDSOPage()
        {
            addDsoPage.DeleteFuntionality();
        }
     
        [When(@"I can see delete button is not clickcable until select the case")]
        public void WhenICanSeeDeleteButtonIsNotClickcableUntilSelectTheCase()
        {
            addDsoPage.DeleteNotClickable();
        }

        [Then(@"verify the Text in the pop up as '(.*)'")]
        public void ThenVerifyTheTextInThePopUpAs(string expected)
        {
            string actual = addDsoPage.ValidateTextInPopUp();
            StringAssert.Contains(expected, actual);
        }

        [Then(@"I click on Delete button in pop up")]
        public void ThenIClickOnDeleteButtonInPopUp()
        {
            addDsoPage.DeleteInPopup();
        }

        [Then(@"I click on Cancel button in pop up")]
        public void ThenIClickOnCancelButtonInPopUp()
        {
            addDsoPage.CancelInPopup();
        }

        [Then(@"I see Verified button Enabled")]
        public void ThenISeeVerifiedButtonEnabled()
        {
            addDsoPage.VerifiedEnabledHover();
        }
        [Then(@"I Click on Close Button on DSO Filter")]
        public void ThenIClickOnCloseButtonOnDSOFilter()
        {
            addDsoPage.ClickCloseButton();
        }        
    }
}