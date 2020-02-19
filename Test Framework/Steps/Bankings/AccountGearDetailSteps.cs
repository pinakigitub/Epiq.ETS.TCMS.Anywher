using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Bankings
{
    [Binding]
    public class AccountGearDetailSteps : StepBase
    {
        AccountGearDetailsPage AccountsPage = new AccountGearDetailsPage(driver);
        [Given(@"I select the Account with Case Number '(.*)'")]
        public void GivenISelectTheAccountWithCaseNumber(string caseNumber)
        {
            AccountsPage.SelectAccount(caseNumber);
        }
        [Given(@"I see CaseNumber '(.*)' and Debtor Name '(.*)'")]
        public void GivenISeeCaseNumberAndDebtorName(string caseNum, string debtorName)
        {
            AccountsPage.verifyCaseDetails(caseNum, debtorName);
        }
        [When(@"I click on Account Edit Icon")]
        public void WhenIClickOnAccountEditIcon()
        {
            AccountsPage.ClickGear();
        }
        [When(@"I click on BreadCrumb '(.*)'")]
        [Then(@"I click on BreadCrumb '(.*)'")]
        public void ThenIClickOnBreadCrumb(string Text)
        {
            AccountsPage.BreadCrumbText(Text);
        }
        [Then(@"I see the fields CASE '(.*)' , BANK NAME '(.*)'")]
        public void ThenISeeTheFieldsCASEBANKNAMEACCOUNTTYPE(string caseNum, string bank)
        {
            AccountsPage.VerifyAccountDetails(caseNum, bank);
        }
        [Then(@"ACCOUNT NUMBER '(.*)' , BANK TOTAL '(.*)' and LEDGER TOTAL'(.*)'")]
        public void ThenACCOUNTNUMBERBANKTOTALAndLEDGERTOTAL(string AccNum, string BankTotal, string ledgerTotal)
        {
            AccountsPage.VerifyBankAccountDetails(AccNum, BankTotal, ledgerTotal);
        }
        [Then(@"I see Text '(.*)' with Red Triangle When BANK TOTAL '(.*)' and LEDGER TOTAL'(.*)' are not equal")]
        public void ThenISeeTextWithRedTriangleWhenBANKTOTALAndLEDGERTOTALAreNotEqual(string text, string bank, string ledger)
        {
            AccountsPage.VerifyUnbalanced(text, bank, ledger);
        }
        [Then(@"I select STATUS as '(.*)'")]
        public void ThenISelectSTATUSAs(string status)
        {
            AccountsPage.SelectStatus(status);
        }

        [Then(@"a message displayed as '(.*)'")]
        public void ThenAMessageDisplayedAs(string msg)
        {
            AccountsPage.Message(msg);
        }
        [When(@"I select CheckBox of '(.*)'")]
        public void WhenISelectCheckBoxOf(string checkType)
        {
            AccountsPage.SelectCheckBoxes(checkType);
        }
        [When(@"I select  Deposit CheckBox of '(.*)'")]
        public void WhenISelectDepositCheckBoxOf(string deposit)
        {
            AccountsPage.DepositCheckBox(deposit);
        }
        [When(@"I select '(.*)' CheckBox")]
        public void WhenISelectCheckBox(string request)
        {
            AccountsPage.SelectRequestCheckBox(request);
        }

        [When(@"I input the fields TAX ID '(.*)'")]
        public void WhenIInputTheFieldsTAXID(string id)
        {
            AccountsPage.InputFields(id);
        }
        [Then(@"I click on Cancel")]
        [When(@"I click on Cancel")]
        public void WhenIClickOnCancel()
        {
            AccountsPage.ClickCancel();
        }
        [Then(@"I click on Save")]
        [When(@"I click on Save")]
        public void WhenIClickOnSave()
        {
            AccountsPage.ClickSave();
        }
        [Then(@"I see the TaxId is no more editable")]
        public void ThenISeeTheTaxIdIsNoMoreEditable()
        {
            AccountsPage.VerifyTaxIdField();
        }
        [When(@"I input the TAX ID '(.*)'")]
        public void WhenIInputTheTAXID(string id)
        {
            AccountsPage.EnterTaxId(id);
        }
        [When(@"I De-select '(.*)' CheckBox")]
        public void WhenIDe_SelectCheckBox(string request)
        {
            AccountsPage.SelectRequestCheckBox(request);
        }
        [When(@"I Enter Account Name '(.*)'")]
        public void WhenIEnterAccountName(string name)
        {
            AccountsPage.EnterAccountName(name);
        }
        [When(@"I verify the Account Name as '(.*)' on Account Management Page")]
        public void WhenIVerifyTheAccountNameAsOnAccountManagementPage(string AccName)
        {
            AccountsPage.VerifyAccountName(AccName);
        }
        [When(@"I select the CheckBox '(.*)'")]
        public void WhenISelectTheCheckBox(string flagCheck)
        {
            AccountsPage.SelectNoBondFlag(flagCheck);
        }
        [Then(@"I verify Field Values '(.*)'")]
        public void ThenIVerifyFieldValues(string Values)
        {
            var Fields = Values.Split(';').Select(i => i.Trim()).ToList();
            AccountsPage.VerifyFieldValues(Fields);
        }
        [When(@"I Select view icon '(.*)'")]
        public void ThenISelectViewIcon(int i)
        {
            AccountsPage.SelectViewIcon(i);
        }
        [Then(@"I verify '(.*)' button")]
        public void ThenIVerifyButton(string button)
        {
            AccountsPage.VerifyButtonState(button);
        }
        [Then(@"I click '(.*)' button")]
        public void ThenIClickButton(string button)
        {
            AccountsPage.ClickClose(button);
        }
        [Then(@"I should not be able to see Full Account Number")]
        public void ThenIShouldNotBeAbleToSeeFullAccountNumber()
        {
            AccountsPage.NoViewOfAccountNumber();
        }
        [Then(@"I should be able to see Partial Account Number '(.*)' for case '(.*)'")]
        public void ThenIShouldBeAbleToSeePartialAccountNumber(string accountNumber, string accountsCaseNumber)
        {
            AccountsPage.ViewOfAccountNumber(accountNumber, accountsCaseNumber);
        }
        [Then(@"I should be able to see Full Account Number '(.*)' for case '(.*)'")]
        public void ThenIShouldBeAbleToSeeFullAccountNumberForCase(string accountNumber, string accountsCaseNumber)
        {
            AccountsPage.ViewOfAccountNumber(accountNumber, accountsCaseNumber);
        }
    }
}