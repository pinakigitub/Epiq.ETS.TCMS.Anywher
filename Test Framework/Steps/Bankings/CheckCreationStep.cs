using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Bankings
{
    [Binding]
    class CheckCreationStep:StepBase
    {
        CheckCreationPage checkCreationPage = new CheckCreationPage(driver);

        [When(@"I select Bank Accounts")]
        public void ISelectBankAccounts()
        {
            checkCreationPage.SelectBankAccount();
        }
        [When(@"I click filter icon")]
        public void IClickFilter()
        {
            checkCreationPage.ClickFilter();
        }
        [Then(@"Input '(.*)' and select debtorname '(.*)'")]
        public void InputTextFieldsInformation(string search, string caseName)
        {
            checkCreationPage.SelectPayeeName(search, caseName);
        }
        [Then(@"I Filter with Account No '(.*)'")]
        public void FilterWithAccountNo(string accountNo)
        {
            checkCreationPage.AccountNoFilter(accountNo);
        }
        [When(@"I Close Filter pop up I should see data on grid")]
        public void CloseFilter()
        {
            checkCreationPage.CloseFilter();
        }
        [When(@"I click on Account # on Grid")]
        public void ClickAccountNoOnGrid()
        {
            checkCreationPage.AccountNoGridClick();
        }
        [When(@"I Click on Create Check Button")]
        public void ClickCheckButton()
        {
            checkCreationPage.CheckButtonClick();
        }
        [Then(@"'(.*)' Breadcrumb should display")]
        public void BreadCrumbDisplay(String header)
        {
            checkCreationPage.VerifyBreadCrumb(header);
        }
        [Then(@"I input Clear Date as '(.*)'")]
        public void InputClearDate(String Date)
        {
            checkCreationPage.ClearDateInput(Date);
        }
        [Then(@"I Update the ClearDate as '(.*)'")]
        public void ThenIUpdateTheClearDate(String Date)
        {
            checkCreationPage.UpdateClearDate(Date);
        }

        [Then(@"Input Description '(.*)' Distribution Type '(.*)' Remarks '(.*)'")]
        public void InputAddressFields(string description,string distributionType,string notes)
        {
            checkCreationPage.InputAddressFields(description, distributionType, notes);      
        }
        [Then(@"I Input amount as '(.*)'")]
        public void InputAmount(string amount)
        {
            checkCreationPage.InputAmount(amount);
        }
        [Then(@"Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','0'")]
        public void InputUTCFields(int rowIndex, string payeeName, string desc, string utcValue, string amount)
        {
            checkCreationPage.InputUTCFields(rowIndex, payeeName, desc, utcValue,amount);
        }
        [When(@"I click Link Claim '(.*)'")]
        public void ClickLinkClaim(string claimType)
        {
            checkCreationPage.LinkClaimClick(claimType);
        }
        [Then(@"Select any claim and Add")]
        public void SelectAnyClaim()
        {
            checkCreationPage.ClaimSelect();
        }
        [When(@"I save the Check")]
        public void SaveCheck()
        {
            checkCreationPage.SaveCheck();
        }
        [Then(@"Verify the message displayed '(.*)'")]
        public void VerifyMessage(string message)
        {
            checkCreationPage.verifyMessage(message);
        }
        [Then(@"Input UTC split fields information for row '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void InputUTCfields(int rowIndex,string payeeName, string desc, string utcValue, string amount)
        {
            checkCreationPage.InputUTCFields(rowIndex,payeeName, desc, utcValue, amount);
        }
        [Then(@"I select Non Compensable as '(.*)' for row '(.*)'")]
        public void SelectCompensable(string compensableStatus,int row)
        {
            checkCreationPage.SelectCompensable(compensableStatus,row);
        }
        [Then(@"I click Add Line Item")]
        public void ClickAddLineItem()
        {
            checkCreationPage.ClickAddLineItem();
        }
        [Then(@"I click button '(.*)'")]
        public void ClickAdd(string buttonText)
        {
            checkCreationPage.ClickAdd(buttonText);
        }
        [Then(@"I enter Payee '(.*)'")]
        public void ThenIEnterPayee(string payeeName)
        {
            checkCreationPage.EnterPayeeName(payeeName);
        }

        [Then(@"I See Interest Amount field is Displayed")]
        public void ThenISeeInterestAmountFieldIsDisplayed()
        {
            checkCreationPage.InterestAmountDisplayed().Should().BeTrue();
        }

        [Then(@"I should update the Interest Amount value '(.*)'")]
        public void ThenIShouldUpdateTheInterestAmountValue(string amountValue)
        {
            checkCreationPage.InputInterestAmount(amountValue);
        }

        [Then(@"I verify Interest Amount field is non editible field")]
        public void ThenIVerifyInterestAmountFieldIsNonEditibleField()
        {
            checkCreationPage.VerifyInterestAmountFieldNonEditable();
        }

        [Then(@"I should update amount as '(.*)'")]
        public void ThenIShouldUpdateAmountAs(string Value)
        {
            checkCreationPage.InputUpdatedAmount(Value);
        }

        [Then(@"I click and Input Linked Amount as '(.*)'")]
        public void ThenIClickAndInputLinkedAmountAs(string Value)
        {
            checkCreationPage.UpdateLinkedAmount(Value);
        }

    }
}
