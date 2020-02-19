using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    public class CaseDetail_Banking_AddTransactionsSpecialSteps : StepBase
    {
        //REFACTORED 
        [When(@"I Click On '(.*)' Field")]
        public void WhenIClickOnField(string field)
        {
            //get form and verify the focus is on the field
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            switch (field)
            {
                case "Serial #":
                    newTransaction.ClickOnSerialNumber();
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        [Then(@"I See Cursor Position Is '(.*)' Field")]
        public void ThenISeeCursorPositionIsField(string field)
        {
            //get form and verify the focus is on the field
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            switch (field) {
                case "Name":
                    newTransaction.IsFocusOnNameField().Should().BeTrue("Focus is on Name field");
                    break;
                case "Amount":
                    newTransaction.IsFocusOnAmountField().Should().BeTrue("Focus is on Amount field");
                    break;
                case "Description":
                    newTransaction.IsFocusOnDescriptionField().Should().BeTrue("Focus is on Description field");
                    break;
                case "Non-Compensable":
                    newTransaction.IsFocusOnNonCompensableField().Should().BeTrue("Focus is on Non-Compensable field");
                    break;
                case "Transaction":
                    newTransaction.IsFocusOnTransactionField().Should().BeTrue("Focus is on Transaction field");
                    break;
                case "Cleared":
                    newTransaction.IsFocusOnClearedField().Should().BeTrue("Focus is on Cleared field");
                    break;
                case "Code":
                    newTransaction.IsFocusOnCodeField().Should().BeTrue("Focus is on Code field");
                    break;
                case "Add UTC Split":
                    newTransaction.IsFocusOnAddUTCSplitField().Should().BeTrue("Focus is onAdd UTC Split field");
                    break;
                case "Serial #":
                    newTransaction.IsFocusOnSerialNumberField().Should().BeTrue("Focus is on Check Serial # field");
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }    
       
        
        [Then(@"I See Cursor Position Is '(.*)' Button")]
        public void ThenISeeCursorPositionIsButton(string button)
        {
            //get form and verify the focus is on the button
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            switch (button)
            {
                case "Save And Add Another":
                    newTransaction.IsFocusOnSaveAndAddAnotherButton().Should().BeTrue("Focus is on Save And Add Another button");
                    break;

                case "Save":
                    newTransaction.IsFocusOnSaveButton().Should().BeTrue("Focus is on Save button");
                    break;

                case "Cancel":
                    newTransaction.IsFocusOnCancelButton().Should().BeTrue("Focus is on Cancel button");
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        [Given(@"I See Transaction Amount Field Value is '(.*)'")]
        [Then(@"I See Transaction Amount Field Value is '(.*)'")]
        public void GivenISeeTransactionAmountFieldValueIs(string expAmount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.Amount.Should().Be(expAmount,"Amount field displays expected amount");
        }

        [Given(@"I See Transaction Amount Field Placeholder is '(.*)'")]
        public void GivenISeeTransactionAmountFieldPlaceholderIs(string expPlaceholder)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.AmountPlaceholder.Should().Be(expPlaceholder, "Amount field displays expected placeholder");
        }


        [When(@"I Click On Transaction Amount Field")]
        public void WhenIClickOnTransactionAmountField()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.ClickOnAmountField();
        }

        [Then(@"I Enter Amount Field Value '(.*)'")]
        public void ThenIEnterAmountFieldValue(string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetAmount(amount);
            newTransaction.PressTabKey();
        }

        [Then(@"I Can Select Two Digits From Amount Value And Delete With DELETE Key Getting '(.*)'")]
        public void ThenICanSelectTwoDigitsFromAmountValueAndDeleteWithDELETEKey(string expValue)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string original = newTransaction.Amount;
            newTransaction.DeleteFirstFourDigitsFromAmount("delete");
            newTransaction.PressDeleteKey();
            newTransaction.PressTabKey();
            newTransaction.Amount.Should().Be(expValue, "User can delete a value partially highlighting and pressing DELETE key");
        }

        [Then(@"I Can Select Two Digits From Amount Value And Delete With BACKSPACE Key Getting '(.*)'")]
        public void ThenICanSelectTwoDigitsFromAmountValueAndDeleteWithBACKSPACEKey(string expValue)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string original = newTransaction.Amount;
            newTransaction.DeleteFirstFourDigitsFromAmount("backspace");
            newTransaction.PressBackSpaceKey();
            newTransaction.PressTabKey();
            newTransaction.Amount.Should().Be(expValue, "User can delete a value partially highlighting and pressing BACKSPACE key");
        }

        [Then(@"I Can Select All Digits From Amount Value And Delete With DELETE Key")]
        public void ThenICanSelectAllDigitsFromAmountValueAndDeleteWithDELETEKey()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string original = newTransaction.Amount;
            newTransaction.DeleteAllDigitsFromAmount("delete");
            newTransaction.PressDeleteKey();
            newTransaction.PressTabKey();
            newTransaction.Amount.Should().Be("", "User can delete a value completely highlighting and pressing BACKSPACE key");
        }

        [Then(@"I Can Select All Digits From Amount Value And Delete With BACKSPACE Key")]
        public void ThenICanSelectAllDigitsFromAmountValueAndDeleteWithBACKSPACEKey()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string original = newTransaction.Amount;
            newTransaction.DeleteAllDigitsFromAmount("backspace");
            newTransaction.PressBackSpaceKey();
            newTransaction.Amount.Should().Be("", "User can delete a value completely highlighting and pressing BACKSPACE key");
        }





    }
}
