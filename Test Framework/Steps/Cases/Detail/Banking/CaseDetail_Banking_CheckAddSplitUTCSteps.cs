using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    public class CaseDetail_Banking_CheckAddSplitUTCSteps:StepBase
    {
        //REFACTORED
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        [Given(@"I Enter Check Amount '(.*)'")]
        private void GivenIEnterCheckAmount(string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.Amount = amount;
        }

        [Given(@"I Set Standard Layout Code '(.*)'")]
        private void GivenISetStandardLayoutCode(string code)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.Code = code;
        }

        [Given(@"I Set Standard Layout Non-Compensable '(.*)'")]
        private void GivenISetStandardLayoutNon_Compensable(bool nonCompensable)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.NonCompensable = nonCompensable;
        }

        [Given(@"I Click On ADD UTC Link")]
        [When(@"I Click On ADD UTC Link")]
        [Then(@"I Click On ADD UTC Link")]
        private void WhenIClickOnADDUTCLink()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.ClickAddUTCSplit();
        }

        [Then(@"I See Labels For UTC Split Columns Are Correct")]
        private void ThenISeeLabelsForUTCSplitColumnsAreCorrect()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.UTCSplitCodeLabel.Should().Be("CODE", "UTC Split Code label is correct");
            newTransaction.UTCSplitNonCompensableLabel.Should().Be("NON-COMPENSABLE", "UTC Split Non Compensable label is correct");
            newTransaction.CodeAmountLabel.Should().Be("CODE AMOUNT", "UTC Split Code Amount label is correct");
        }

        [Given(@"I See '(.*)' UTC Split Rows")]
        [Then(@"I See '(.*)' UTC Split Rows")]
        private void ThenISeeUTCSplitRows(int count)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.GetUTCSplitsCount().Should().Be(count, "Count of UTC splits is correct");            
        }

        [Then(@"I See Add UTC Split Link Now Reads '(.*)'")]
        private void ThenISeeAddUTCSplitLinkNowReads(string linkText)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.UTCSplitLinkText.Should().Be(linkText,"ADD UTC Split link name is correct");
        }

        [Given(@"I See Check Amount Is '(.*)'")]
        [Then(@"I See Check Amount Is '(.*)'")]
        private void ThenISeeCheckAmountIs(string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.Amount.Should().Be(amount, "Check Amount is correct");
        }

        [Given(@"I See SUM OF ALLOCATION Is '(.*)' In a '(.*)' Box")]

        [Then(@"I See SUM OF ALLOCATION Is '(.*)' In a '(.*)' Box")]
        private void ThenISeeSUMOFALLOCATIONIsInABox(string sum, string boxColor)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SumOfAllocation.Should().Be(sum, "Sum Of Allocation values is correct");
            newTransaction.SumOfAllocationBoxColor.Should().Be(boxColor, "Sum Of Allocation box COLOR correct");
        }

        [Given(@"I See UTC Row Number '(.*)' Name Is '(.*)'")]
        [When(@"I See UTC Row Number '(.*)' Name Is '(.*)'")]
        [Then(@"I See UTC Row Number '(.*)' Name Is '(.*)'")]
        private void ThenISeeUTCRowNumberNameIs(int rowPosition, string name)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.GetUTCSplitNameBySplitPosition(rowPosition).Should().Be(name, "Expected Name value is correct on split " + rowPosition);
        }

        [Given(@"I See UTC Row Number '(.*)' Code Is '(.*)'")]
        [When(@"I See UTC Row Number '(.*)' Code Is '(.*)'")]
        [Then(@"I See UTC Row Number '(.*)' Code Is '(.*)'")]
        private void ThenISeeUTCRowNumberCodeIs(int rowPosition, string code)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.GetUTCSplitCodeBySplitPosition(rowPosition).Should().Be(code, "Expected Code value is correct on split "+rowPosition);
        }

        [Given(@"I See UTC Row Number '(.*)' Non-Compensable Is '(.*)'")]
        [When(@"I See UTC Row Number '(.*)' Non-Compensable Is '(.*)'")]
        [Then(@"I See UTC Row Number '(.*)' Non-Compensable Is '(.*)'")]
        private void ThenISeeUTCRowNumberNon_CompensableIs(int rowPosition, bool nonCompensable)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.GetUTCSplitNonCompensableBySplitPosition(rowPosition).Should().Be(nonCompensable, "Expected Non-compensable value is correct on split " + rowPosition); 
        }
        
        [Then(@"I See UTC Row Number '(.*)' Amount Is '(.*)'")]
        private void ThenISeeUTCRowNumberAmountIs(int rowPosition, string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.GetUTCSplitAmountBySplitPosition(rowPosition).Should().Be(amount, "Expected Amount value is correct on split " + rowPosition);
        }

        [Given(@"I Set UTC Row Number '(.*)' Name '(.*)'")]
        [When(@"I Set UTC Row Number '(.*)' Name '(.*)'")]
        [Then(@"I Set UTC Row Number '(.*)' Name '(.*)'")]
        private void ThenISetUTCRowNumberName(int rowPosition, string name)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetUTCSplitNameBySplitPosition(rowPosition, name);
        }

        [Given(@"I Set UTC Row Number '(.*)' Code '(.*)'")]
        [When(@"I Set UTC Row Number '(.*)' Code '(.*)'")]
        [Then(@"I Set UTC Row Number '(.*)' Code '(.*)'")]
        private void ThenISetUTCRowNumberCode(int rowPosition, string code)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetUTCSplitCodeBySplitPosition(rowPosition, code);
        }

        [Given(@"I Set UTC Row Number '(.*)' Allocation Description '(.*)'")]
        [When(@"I Set UTC Row Number '(.*)' Allocation Description '(.*)'")]
        [Then(@"I Set UTC Row Number '(.*)' Allocation Description '(.*)'")]
        private void GivenISetUTCRowNumberAllocationDescription(int rowPosition, string allocDescription)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetUTCSplitAllocationDescriptionBySplitPosition(rowPosition, allocDescription);
        }

        [Given(@"I Set UTC Row Number '(.*)' Non-Compensable '(.*)'")]
        [When(@"I Set UTC Row Number '(.*)' Non-Compensable '(.*)'")]
        [Then(@"I Set UTC Row Number '(.*)' Non-Compensable '(.*)'")]
        private void ThenISetUTCRowNumberNon_Compensable(int rowPosition, bool nonCompensable)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetNonCompensableBySplitPosition(rowPosition, nonCompensable);
        }

        [Given(@"I Set UTC Row Number '(.*)' Amount '(.*)'")]
        [Then(@"I Set UTC Row Number '(.*)' Amount '(.*)'")]
        private void ThenISetUTCRowNumberAmount(int rowPosition, string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetAmountBySplitPosition(rowPosition, amount);
        }

        [When(@"I Click On x Icon For UTC Row Number '(.*)'")]
        [Then(@"I Click On x Icon For UTC Row Number '(.*)'")]
        private void WhenIClickOnXIconForUTCRowNumber(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.RemoveUTCSplitRowByPosition(rowPosition);
        }

        [Then(@"I See Code Layout Restores To Initial Display")]
        private void ThenISeeCodeLayoutRestoresToInitialDisplay()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.UTCSplitRowsDissapeared().Should().BeTrue("UTC Split was removed");
            newTransaction.IsSumOfAllocationFieldInvisible().Should().BeTrue();
            newTransaction.NonCompensableLabel.Should().Be("Non-Compensable", "Non-Compensable label is restored to default");
            newTransaction.CodeLabel.Should().Be("CODE", "CODE label is restored to default");
            newTransaction.IsCodeDefaultInputVisible().Should().BeTrue("Code input is restored to default");
        }

        [Given(@"I See Save Buttons Are Enabled")]
        private void GivenISeeSaveButtonsAreEnabled()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.IsSaveButtonEnabled().Should().BeTrue("Save button is active");
            newTransaction.IsSaveAndAddAnotherButtonEnabled().Should().BeTrue("Save And Add Another button is active");
        }

        [Given(@"I See Save Buttons Are Disabled")]
        [Then(@"I See Save Buttons Are Disabled")]
        private void GivenISeeSaveButtonsAreDisabledd()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.IsSaveButtonEnabled().Should().BeFalse("Save button is inactive");
            newTransaction.IsSaveAndAddAnotherButtonEnabled().Should().BeFalse("Save And Add Another button is inactive");
        }

        [Given(@"I Enter Pay To The Order Of '(.*)'")]
        private void GivenIEnterPayToTheOrderOf(string name)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetName(name);
        }

        [When(@"I Click On Save Check For UTC Split")]
        [Then(@"I Click On Save Check For UTC Split")]
        private void WhenIClickOnSaveCheckForUTCSplit()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string serialNbr = newTransaction.SerialNumber;
            
            //Save utc data on scenario context
            AddDataToScenarioContextOverridingExistentKey("Created Check UTC Splits Data", newTransaction.TransactionLinks.GetUTCSplitsData());           

            //Save
            newTransaction.Save();

            try
            {
                //try to save created transaction id after (and IF) transaction for closes
                //Verify Trx form closes
                bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving");

                //Add crated trx data to context 
                AddDataToScenarioContextOverridingExistentKey("Saved Transaction Id", bankingTab.GetTransactionIdFromListBySerialNumber(serialNbr));
            }
            catch (Exception)
            {
                //do nothing, clicking on save doesn't mean the check saves
            }

            //Serial nmber of intent to save           
            AddDataToScenarioContextOverridingExistentKey("Transaction Serial Number", serialNbr);
        }

        

        [Then(@"I See A Validation Message Appears Reading '(.*)'")]
        private void ThenISeeAValidationMessageAppearsReading(string validationMsg)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.UTCSplitValidationMessage.Should().Be(validationMsg, "I See a validation message for UTC Split and the text is correct");
        }

        [Then(@"I Verify on DB That UTC Splits Have Been Saved")]
        private void ThenIVerifyOnDBThatTheCodesHaveBeenSaved()
        {
                //Get saved utc splits data saved form UI before saving the check
                List<ClaimLinkData> UTCSplitsData = ScenarioContext.Current.Get<List<ClaimLinkData>>("Created Check UTC Splits Data");
                IEnumerator<ClaimLinkData> enumUTCSplitData = UTCSplitsData.GetEnumerator();
                enumUTCSplitData.Reset();

                //Query DB to verify saved UTC Splits data
                int depositId = ScenarioContext.Current.Get<int>("Saved Transaction Id");
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("TransactionId", depositId + "");
                DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetUTCSplitsDataByTransactionId, parameters);
                
                //Verify that saved the same count of utc splits we added on the UI
                if(UTCSplitsData.Count > 1)
                    rows.Count.Should().Be(UTCSplitsData.Count, "UTC Splits were saved on DB");
                else
                    rows.Count.Should().Be(UTCSplitsData.Count, "UTC Split was saved on DB");
               
                //Verify data for each saved split
                foreach (DataRow row in rows)
                {
                    enumUTCSplitData.MoveNext();
                    ClaimLinkData utcSplit = enumUTCSplitData.Current;
                    row.Field<string>("Name").Should().Be(utcSplit.Name, "UTC Split Name is correct on DB");
                    row.Field<string>("Code").Should().Be(utcSplit.Code, "UTC Split Code is correct on DB");
                    row.Field<string>("AllocationDescription").Should().Be(utcSplit.Description, "UTC Split Description is correct on DB");
                    row.Field<bool>("IsNonCompensable").Should().Be(utcSplit.NonCompensable, "UTC Split Non Compensable is correcton DB");

                    string dbAmountFormatted = row.Field<Decimal>("Amount")+"";
                    dbAmountFormatted = dbAmountFormatted.Substring(0, dbAmountFormatted.Length - 2);
                    string expectedAmount = "-"+utcSplit.Amount.Replace(" ", "").Replace(",", "").Replace("$", "");
                    dbAmountFormatted.Should().Be(expectedAmount, "UTC Split Amount is correcton DB");                    
                }
            
        }

    }
}
