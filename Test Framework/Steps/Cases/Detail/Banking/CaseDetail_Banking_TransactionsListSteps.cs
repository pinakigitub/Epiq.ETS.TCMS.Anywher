using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    public class CaseDetail_Banking_TransactionsListSteps:StepBase
    { 
        //REFACTORED
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        //TRANSACTIONS LIST
        [Then(@"I See No Transactions Display on the List And a Message Shows Reading '(.*)'")]
        private void ThenISeeNoTransactionsDisplayOnTheListAndAMessageShowsReading(string expMessage)
        {
            bankingTab.IsResultsListEmpty().Should().BeTrue("Transactions List is Empty");
            bankingTab.GetNoResultsMessage().Should().Be(expMessage, "No results message displays reading: '"+expMessage+"'");
        }
        
        [Then(@"I See Transactions Display on the List With Valid Data In Order")]
        private void ThenISeeTransactionsDisplayOnTheListWithValidDataInOrder()
        {
            //Get transactions list data from DB
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId", Convert.ToString(CaseDetailSteps.GetCaseIdFromCaseNumber(ScenarioContext.Current.Get<string>("Case Number"))));
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));
            DataRowCollection expectedTrxs = ExecuteQueryOnDB(Properties.Resources.GetTransactionsListForFirstActiveBankAccount, parameters);


            IEnumerator<BankTransactionData> actualTransactions = bankingTab.GetFirstNTransactions(expectedTrxs.Count).GetEnumerator();
            actualTransactions.MoveNext();

            //Compare with what is shown on the UI
            foreach (DataRow rowInDB in expectedTrxs)
            {
                string trxId = Convert.ToString(rowInDB.Field<int>("Id"));
                BankTransactionData actualTransaction = actualTransactions.Current;

                //Cleared Date label and value + Corner Tag Color depending on Cleared Date
                actualTransaction.ClearedDateLabel.Should().Be("CLEARED", "[" + trxId + "] Cleared Date Label is 'CLEARED'");
                DateTime clearedDate;
                try
                {
                    clearedDate = rowInDB.Field<DateTime>("ClearedDate");
                }
                catch (Exception)
                {
                    clearedDate = DateTime.MinValue;
                }

                if (clearedDate != DateTime.MinValue)
                {
                    actualTransaction.CornerTagColor.Should().Be("GREEN", "[" + trxId + "] Corner tag is Green if Cleared Date is populated");
                    actualTransaction.ClearedDate.Should().Be(clearedDate.ToString("MM/dd/yy"), "[" + trxId + "] Transaction Cleared Date is correct");
                }
                else
                {
                    actualTransaction.CornerTagColor.Should().Be("ORANGE", "Corner tag is Orange if Cleared Date is NOT populated");
                    actualTransaction.ClearedDate.Should().Be("", "[" + trxId + "] Transaction Cleared Date is correct");
                }

                //Trx Type Box
                actualTransaction.TypeBoxColor.Should().Be("GREY", "[" + trxId + "] Transaction Type Box Background Color is Grey");
                actualTransaction.TransactionNumber.Should().Be(rowInDB.Field<string>("Number"), "[" + trxId + "] Transaction Serial Number is: "+ rowInDB["Number"]);

                //Name
                actualTransaction.Name.Should().Be(rowInDB.Field<string>("Name").TrimEnd(), "[" + trxId + "] Transaction Name is correct");

                //Description
                actualTransaction.Description.Should().Be(rowInDB.Field<string>("Description").TrimEnd().Replace("\r\n ",""), "[" + trxId + "] Transaction Description is correct");

                //Trx date
                actualTransaction.TrxDateLabel.Should().Be("TRANSACTION", "[" + trxId + "] Transaction Date Label is  'TRANSACTION'");
                actualTransaction.TrxDate.Should().Be(rowInDB.Field<DateTime>("Date").ToString("MM/dd/yy"), "[" + trxId + "] Transaction Date is correct");

                

                //Code
                actualTransaction.CodeLabel.Should().Be("CODE", "[" + trxId + "] Transaction Code Label is 'CODE'");
                string expCode = rowInDB.Field<string>("Code");
                if (!expCode.Contains("null"))
                    actualTransaction.Code.Should().Be(expCode, "[" + trxId + "] Transaction Code is correct");
                else
                    actualTransaction.Code.Should().Be("", "[" + trxId + "] Transaction Code is correct");


                //Amount

                string transactionType = rowInDB.Field<string>("TransactionType");
                string nonCompensablePrefix = "";
                if (rowInDB.Field<int>("IsNonCompensable") == 1)
                    nonCompensablePrefix = "NON-COMPENSABLE ";

                if ((transactionType == "Deposit") || (transactionType == "Adjustment Credit"))
                {
                    actualTransaction.AmountLabel.Should().Be(nonCompensablePrefix+"RECEIPT", "[" + trxId + "] Transaction Amount Label is 'RECEIPT'");
                    actualTransaction.AmountValue.Should().Be(rowInDB.Field<string>("Receipt"), "[" + trxId + "] Transaction Amount is correct");
                }
                else if((transactionType == "Check") || (transactionType == "Disbursement") || (transactionType == "Adjustment Debit"))
                {
                    actualTransaction.AmountLabel.Should().Be(nonCompensablePrefix + "DISBURSEMENT", "[" + trxId + "] Transaction Amount Label is 'DISBURSEMENT'");
                    actualTransaction.AmountValue.Should().Be(rowInDB.Field<string>("Disbursement"), "[" + trxId + "] Transaction Amount is correct");
                }

                //Balance
                actualTransaction.BalanceLabel.Should().Be("BALANCE", "[" + trxId + "] Transaction Balance Label is 'BALANCE'");
                actualTransaction.BalanceValue.Should().Be(rowInDB.Field<string>("Balance"), "[" + trxId + "] Transaction Balance is correct");

                actualTransactions.MoveNext();
            }
        }

        [When(@"I Select Bank Account By Number '(.*)'")]
        private void WhenISelectBankAccountByNumber(string accountNbr)
        {
            bankingTab.SelectSummaryCardByAccountNumber(accountNbr);
        }

        [Then(@"I See New Transaction Buttons Are Disabled")]
        private void ThenISeeNewTransactionButtonsAreDisabled()
        {
            bankingTab.IsCheckButtonInactive().Should().BeTrue("Check Button is disabled for Closed Bank Accounts");
            bankingTab.IsDepositButtonInactive().Should().BeTrue("Deposit Button is disabled for Closed Bank Accounts");
        }


        //-----------------------        
        // TRANSACTIONS CREATION      
        //-----------------------

        [Given(@"I Go To Create Transaction '(.*)'")]
        [When(@"I Go To Create Transaction '(.*)'")]
        public void WhenIGoToCreateTransaction(string transaction)
        {
            //Wait 1 second to not colide with other transactions being added
            bankingTab.Pause(1);

            //Open a new check Form and save on Scenario context            
            TransactionForm newTransaction = bankingTab.ClickNewTransactionMenuLink(transaction);
            AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newTransaction);
            AddDataToScenarioContextOverridingExistentKey("New Transaction Type", transaction);
        }


        //----------------
        //  CREATE TRANSACTION
        //----------------       

        [When(@"I Create a New Transaction As '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        private void WhenICreateANewTransactionOnTheDefaultBankAccountAs(string payTo, string description, bool defaultDate, bool defaultClearedDate, string code, bool nonCompensable, string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");


            //Set some valid data                        
            //Get default serial number from UI and save on scenario context
            this.AddSerialNumberToScenario(newTransaction, trxType);

            newTransaction.SetName(payTo);
            newTransaction.SetDescription(description);
            if (!defaultDate) {
                if (trxType.Contains("Deposit Correcting Debit") || trxType.Contains("Bank Service Charge"))
                    newTransaction.SetTransactionDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(-3)));
                else
                    newTransaction.SetTransactionDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(3)));

            }
            if (!defaultClearedDate) { newTransaction.SetClearedDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(5))); }

            newTransaction.SetCode(code);

            if((trxType == "Check")||(trxType.Contains("Bank Service Charge")))
                newTransaction.SetNonCompensable(nonCompensable);

            newTransaction.SetAmount(amount);

            //Save       
            newTransaction.Save();            
        }

        private void AddSerialNumberToScenario(TransactionForm newTransaction, string trxType)
        {
            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
            {
                AddDataToScenarioContextOverridingExistentKey("Transaction Serial Number", newTransaction.SerialNumber);
            }
        }

        [Then(@"I See Transaction Displays on Transactions List With '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheTransactionDisplaysOnTransactionsListWith(string payTo, string description, bool defaultDate, bool defaultClearedDate, string code, string amount)
        {
            //Get serial number of the transaction to validate
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");            
            string trxExpectedSerialText = CommonMethodsUnityStepBase.GetExpectedSerialNumberTextForLedger(trxType);


            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");
            bankingTab.Pause(2);

            //Search transaction on the list
            BankTransactionData transaction;
            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
                transaction = bankingTab.GetTransactionBySerialNumber(trxExpectedSerialText);
            else
                transaction = bankingTab.GetTransactionByName(payTo);

            //Verify all data fields for the transaction            
            transaction.TransactionNumber.Should().Be(CommonMethodsUnityStepBase.GetExpectedSerialNumberTextForLedger(trxType), "Transaction Number is correct");
            transaction.Name.Should().Be(payTo, "Name is Correct");
            transaction.Description.Should().Be(description, "Description is Correct");

            if (!defaultDate)
            {
                if(trxType.Contains("Deposit Correcting Debit") || trxType.Contains("Bank Service Charge"))
                    transaction.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(-3)), "Transaction Date is Correct");
                else
                transaction.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(3)), "Transaction Date is Correct");
            }
            else
            {
                transaction.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now), "Transaction Date is Correct");
            }
            if (!defaultClearedDate)
            {
                transaction.ClearedDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(5)), "Cleared Date is Correct");
            }
            else
            {
                transaction.ClearedDate.Should().Be("", "Transaction Date is Correct");
            }

            transaction.Code.Should().Be(code, "Code is Correct");
            transaction.AmountValue.Should().Be(amount, "Amount is Correct");
        }

        [Then(@"I See The Check Displays at the Top of Transactions List With '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheCheckDisplaysAtTheTopOfTransactionsListWith(string payTo, string description, bool defaultDate, bool defaultClearedDate, string code, string amount)
        {
            //Get serial number of the check to validate
            string serialNbr = ScenarioContext.Current.Get<string>("Transaction Serial Number");

            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");

            //Search transaction on the list
            BankTransactionData transaction = bankingTab.GetTransactionBySerialNumber("Check #" + serialNbr); 
                     

            //Verify all data fields for the transaction
            transaction.TransactionNumber.Should().Be("Check #"+serialNbr, "Transaction Number is correct");
            transaction.Name.Should().Be(payTo, "Name is Correct");
            transaction.Description.Should().Be(description, "Description is Correct");

            if (!defaultDate)
            {
                transaction.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(3)), "Transaction Date is Correct");
            }
            else {
                transaction.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now), "Transaction Date is Correct");
            }
            if (!defaultClearedDate) {
                transaction.ClearedDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(5)), "Cleared Date is Correct");
            }
            else
            {
                transaction.ClearedDate.Should().Be("", "Transaction Date is Correct");
            }

            transaction.Code.Should().Be(code, "Code is Correct");
            transaction.AmountValue.Should().Be(amount, "Amount is Correct");
        }

        private string GetFormattedDateForList(DateTime date)
        {
            return date.ToString("MM/dd/yy");
        }

        //-------------------------
        //  CANCEL TRANSACTION CREATION
        //-------------------------
        [When(@"I Enter Valid Data for a New Transaction And Click on the Cancel Button")]
        private void WhenIEnterValidDataForANewTransaction()
        {
            //Transaction form already opened
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

            //Set some valid data
            if(trxType != "Transfer Out")
            newTransaction.SetName("Test Automation Canceling Transaction");

            newTransaction.SetCode("2300");

            newTransaction.SetAmount("15000");

            //Save serial number for other steps            
            this.AddSerialNumberToScenario(newTransaction, trxType);

            //Cancel
            newTransaction.Cancel();
        }

        [Then(@"I Do NOT See The Transaction on the Transactions List")]
        private void ThenIDoNOTSeeTTransactionOnTheTransactionsList()
        {
            //Verify Trx Form has been closed
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");

            //Verify the TRX was not saved
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            string trxExpectedSerialText = CommonMethodsUnityStepBase.GetExpectedSerialNumberTextForLedger(trxType);
            bankingTab.IsTransactionPresentOnTheList(trxExpectedSerialText).Should().BeFalse("A canceled transaction is not saved.");

        }

        [Then(@"I See The Deposit Displays at the Top of Transactions List With '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheDepositDisplaysAtTheTopOfTransactionsListWith(string payTo, string description, string defaultDate, string defaultClearedDate, string code, string amount)
        {
            //Get serial number of the deposit to validate
            int serialNbr = ScenarioContext.Current.Get<int>("Created Deposit Serial Number");

            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");

            //Search the transaction on the list
            BankTransactionData deposit = bankingTab.GetTransactionBySerialNumber("Deposit #" + serialNbr);      

            //Verify all data fields for the transaction
            deposit.TransactionNumber.Should().Be("Deposit #" + serialNbr, "Transaction Number is correct");
            deposit.Name.Should().Be(payTo, "Name is Correct");
            deposit.Description.Should().Be(description, "Description is Correct");
            
            if (defaultDate == "false")
            {
                deposit.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(3)), "Transaction Date is Correct");
            }
            else if (defaultDate == "true")
                {
                deposit.TrxDate.Should().Be(this.GetFormattedDateForList(DateTime.Now), "Transaction Date is Correct");
            }
            else
            {
                deposit.TrxDate.Should().Be(defaultDate, "Transaction Date is Correct");
            }

            if (defaultClearedDate == "false")
            {
                deposit.ClearedDate.Should().Be(this.GetFormattedDateForList(DateTime.Now.AddDays(5)), "Cleared Date is Correct");
            }
            else if (defaultClearedDate == "true")
            {
                deposit.ClearedDate.Should().Be("", "Transaction Date is Correct");
            }
            else if (defaultClearedDate == "current")
            {
                deposit.ClearedDate.Should().Be(this.GetFormattedDateForList(DateTime.Now), "Cleared Date is Correct");
            }
            else
            {
                deposit.ClearedDate.Should().Be(defaultClearedDate, "Cleared Date is Correct");
            }

            deposit.Code.Should().Be(code, "Code is Correct");
            deposit.AmountValue.Should().Be(amount, "Amount is Correct");

        }

        protected int GetRandomTrxSerialNumber()
        {
            Random rnd = new Random();
            int randomID = rnd.Next(1, 987654);
            return randomID;
        }

        //---------------
        //- VALIDATIONS -
        //---------------

        [Given(@"I Click on Check Button")]
        [When(@"I Click on Check Button")]
        [Then(@"I Click on Check Button")]
        private void GivenIClickOnCheckButton()
        {
            //Wait 1 second to not colide with other transactions being added
            bankingTab.Pause(1);

            //Open a new check Form and save on Scenario context
            TransactionForm newCheck = bankingTab.ClickCheckButton();
            AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newCheck);
            AddDataToScenarioContextOverridingExistentKey("New Transaction Type", "Check");

        }

        [Given(@"I Click on Deposit Button")]
        [When(@"I Click on Deposit Button")]
        private void GivenIClickOnDepositButton()
        {
            //Wait 1 second to not colide with other transactions being added
            bankingTab.Pause(1);

            //Open a new check Form and save on Scenario context
            TransactionForm newDeposit = bankingTab.ClickDepositButton();
            AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newDeposit);
            AddDataToScenarioContextOverridingExistentKey("New Transaction Type", "Deposit");
        }        


        //VALIDATIONS
        [When(@"I Enter These Values for a New Transaction '(.*)','(.*)','(.*)','(.*)'")]
        private void WhenIEnterTheseValuesForANewTransaction(string name,string amount,string text, string method)
        {
            Thread.Sleep(2500);
            CaseDetail_Banking_NewTransactionSteps _caseDetail_Banking_NewTransactionSteps = new CaseDetail_Banking_NewTransactionSteps();
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            
            //Set the given data
            newTransaction.SetName(name);
            //this.SetTransactionDate(newTransaction, transactionDate);
            //this.SetClearedDate(newTransaction, clearedDate);
            this.SetTransactionAmount(newTransaction, amount);
            newTransaction.SetCode("2100");
            _caseDetail_Banking_NewTransactionSteps.TransactionSelectCodeWithTextUsingX(text, method);

            //Save serial number for other steps            
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            this.AddSerialNumberToScenario(newTransaction, trxType);
        }

        [When(@"I Enter These Values for an Edit Transaction '(.*)','(.*)'")]
        private void WhenIEnterTheseValuesForAnEditTransaction(string transactionDate, string clearedDate)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            //Set the given data
            this.SetClearedDate(newTransaction, clearedDate);
            //newTransaction.SetCode("1290");
            this.SetTransactionDate(newTransaction, transactionDate);

            //Save serial number for other steps            
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            this.AddSerialNumberToScenario(newTransaction, trxType);
        }

        [When(@"I Click On Transaction Save Button")]
        [Then(@"I Click On Transaction Save Button")]
        private void WhenIClickOnTransactionSaveButton()
        {
            //Click on Trx Save button
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            //Get default serial number from UI and save on Scenario Context            
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            this.AddSerialNumberToScenario(newTransaction, trxType);

            AddDataToScenarioContextOverridingExistentKey("Participant Description", newTransaction.GetTransactionName().Split('|')[0].TrimEnd());

            if (!newTransaction.TransactionLinks.ClaimLinksCountIsZero())
            {
                AddDataToScenarioContextOverridingExistentKey("Claim Links Ids", newTransaction.TransactionLinks.GetClaimsLinksIds());
            }

            //Save transaction
            newTransaction.Save();
        }

        [Then(@"I See The Validation Messages for each Invalid Transaction Field '(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheValidationMessagesForEachTransactionInvalidField(string validPayTo, string validateTrxDate, string validAmount, string validateCleared)
        {
            bool isValidPayTo = Convert.ToBoolean(validPayTo);            
            bool isValidAmount = Convert.ToBoolean(validAmount);

            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            //Verify all fields validation messages according to what is expected
            //Pay To or Received From
            if (isValidPayTo)
            {
                newTransaction.HasPayToValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Name' field");
            }
            else {
                this.VerifyTransactionNameValidationMessage(newTransaction);
            }

            //Transaction Date
            if (validateTrxDate == "None")
            {
                newTransaction.HasTrxDateValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Transaction Date' field");
            }
            else {
                this.VerifyTransactionDateValidationMessage(newTransaction, validateTrxDate);
            }

            //Cleared Date
            if (validateCleared == "None")
            {
                newTransaction.HasClearedDateValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Cleared' field");
            }
            else {
                this.VerifyClearedDateValidationMessage(newTransaction, validateCleared);
            }

            //Amount
            if (isValidAmount)
            {
                newTransaction.HasAmountValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Amount' field");
            }
            else {
                this.VerifyTransactionAmountValidationMessage(newTransaction);
            }

            //Save for other verification steps
            AddDataToScenarioContextOverridingExistentKey("validPayTo", isValidPayTo);
            AddDataToScenarioContextOverridingExistentKey("validateTrxDate", validateTrxDate);
            AddDataToScenarioContextOverridingExistentKey("validateCleared", validateCleared);
            AddDataToScenarioContextOverridingExistentKey("validAmount", isValidAmount);
        }

        [Then(@"I See The Validation Messages for each Invalid Edit Transaction Field '(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheValidationMessagesForEachEditTransactionInvalidField(string validPayTo, string validateTrxDate, string validAmount, string validateCleared)
        {
            bool isValidPayTo = Convert.ToBoolean(validPayTo);
            bool isValidAmount = Convert.ToBoolean(validAmount);

            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            //Transaction Date
            if (validateTrxDate == "None")
            {
                newTransaction.HasTrxDateValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Transaction Date' field");
            }
            else {
                this.VerifyTransactionDateValidationMessage(newTransaction, validateTrxDate);
            }

            //Cleared Date
            if (validateCleared == "None")
            {
                newTransaction.HasClearedDateValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Cleared' field");
            }
            else {
                this.VerifyClearedDateValidationMessage(newTransaction, validateCleared);
            }

            //Amount
            //if (isValidAmount)
            //{
            //    newTransaction.HasAmountValidationMessageDissapeared().Should().BeTrue("No validation shown on valid value for 'Amount' field");
            //}
            //else {
            //    this.VerifyTransactionAmountValidationMessage(newTransaction);
            //}

            //Save for other verification steps
            AddDataToScenarioContextOverridingExistentKey("validPayTo", isValidPayTo);
            AddDataToScenarioContextOverridingExistentKey("validateTrxDate", validateTrxDate);
            AddDataToScenarioContextOverridingExistentKey("validateCleared", validateCleared);
            //AddDataToScenarioContextOverridingExistentKey("validAmount", isValidAmount);
        }

        private void VerifyClearedDateValidationMessage(TransactionForm newTransaction, string validateCleared)
        {

            switch (validateCleared)
            {
                case "LessThanTrx":
                    newTransaction.GetClearedDateValidationMessage().Should().BeEquivalentTo("CLEARED must be after TRANSACTION", "Validation message displays on date smaller than transaction date for 'Cleared' field");
                    break;

                case "InvalidFormat":
                    newTransaction.GetClearedDateValidationMessage().Should().BeEquivalentTo("CLEARED Required entry format: MM/DD/YYYY", "Validation message displays on invalid format for 'Cleared' field");
                    break;

                case "InvalidDate":
                    newTransaction.GetClearedDateValidationMessage().Should().BeEquivalentTo("CLEARED Required entry format: MM/DD/YYYY", "Validation message displays on Invalid date for 'Cleared' field");
                    break;

                case "None":
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private void VerifyTransactionDateValidationMessage(TransactionForm newTransaction, string validateTrxDate)
        {
            switch (validateTrxDate)
            {
                case "Empty":
                    newTransaction.GetTrxDateValidationMessage().Should().BeEquivalentTo("TRANSACTION is required.", "Validation message displays on 'Transaction Date' field");
                    break;

                case "Past":
                    newTransaction.GetTrxDateValidationMessage().Should().BeEquivalentTo("TRANSACTION cannot be prior to current date", "Validation message displays on date prior to Today's date for 'Transaction Date' field");
                    break;

                case "GreaterThanCleared":
                    newTransaction.GetTrxDateValidationMessage().Should().BeEquivalentTo("TRANSACTION must be prior to CLEARED", "Validation message displays on date greater than cleared date for 'Transaction Date' field");
                    break;

                case "InvalidFormat":
                    newTransaction.GetTrxDateValidationMessage().Should().BeEquivalentTo("TRANSACTION Required entry format: MM/DD/YYYY", "Validation message displays on invalid format for 'Transaction' field");
                    break;

                case "InvalidDate":
                    newTransaction.GetTrxDateValidationMessage().Should().BeEquivalentTo("TRANSACTION cannot be prior to current date", "Validation message displays on Invalid date for 'Transaction' field");
                    break;

                case "None":
                    break;
                default:
                    throw new NotImplementedException();
            }

        }

        //Verifies the validation message for Name field, according to the transaction type
        private void VerifyTransactionNameValidationMessage(TransactionForm newTransaction)
        {
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            string message = newTransaction.GetPayToValidationMessage();

            switch (trxType)
            {
                case "Check":
                    message.Should().BeEquivalentTo("PAY TO THE ORDER OF is required.", "Validation message displays on 'Amount' field");
                    break;

                case "Deposit":
                    message.Should().BeEquivalentTo("RECEIVED FROM is required.", "Validation message displays on 'Amount' field");
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        //Verifies the validation message for Amount field, according to the transaction type
        private void VerifyTransactionAmountValidationMessage(TransactionForm newTransaction)
        {
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            string message = newTransaction.GetAmountValidationMessage();

            switch (trxType) {
                case "Check":
                    message.Should().Be("CHECK AMOUNT is required.", "Validation message displays on 'Amount' field");
                    break;

                case "Deposit":
                    message.Should().Be("NET DEPOSIT is required", "Validation message displays on 'Amount' field");
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        [Then(@"If I Enter valid Values for the Transaction Messages Dissapear One at a Time")]
        private void ThenIfIEnterValidValuesForTheTransactionMessagesDissapearOneAtATime()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            bool validPayTo = ScenarioContext.Current.Get<bool>("validPayTo");
            string validateTrxDate = ScenarioContext.Current.Get<string>("validateTrxDate");
            string validateClearDate = ScenarioContext.Current.Get<string>("validateCleared");
            bool validAmount = false;
            if (ScenarioContext.Current.ScenarioInfo.Title.ToString().Contains("Edit").Equals(false))
            {
                validAmount = ScenarioContext.Current.Get<bool>("validAmount");
            }

            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

            string serialNbr = "";

            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
                serialNbr = ScenarioContext.Current.Get<string>("Transaction Serial Number");
            else
                serialNbr = trxType;

            if (!validPayTo)
            {
                newTransaction.SetName("Test Automation Validations Test "+serialNbr);
                newTransaction.HasPayToValidationMessageDissapeared().Should().BeTrue("'Name' Field: Validation dissappears once a correct value has been entered ");
            }
            
            if (ScenarioContext.Current.ScenarioInfo.Title.ToString().Contains("Edit").Equals(false))
            {
            if (!validAmount)
            {
                this.SetTransactionAmount(newTransaction, "$1500.00");
                newTransaction.HasAmountValidationMessageDissapeared().Should().BeTrue("'Amount' Field: Validation dissappears once a correct value has been entered ");
            }
            }

            //Clear both dates fisrt to make all messages dissapear            
            if (ScenarioContext.Current.ScenarioInfo.Title.ToString().Contains("Edit").Equals(false))
            {
            this.SetTransactionDate(newTransaction, "");
            }
            this.SetClearedDate(newTransaction, "");

            //Set at least Transaction date (mandatory)
            this.SetTransactionDate(newTransaction, "current");

            //Verify messages are gone if they were present
            if (validateTrxDate != "None")
            {
                newTransaction.HasTrxDateValidationMessageDissapeared().Should().BeTrue("'Transaction Date' Field: Validation dissappears once a correct value has been entered ");
            }

            if (validateClearDate != "None")
            {
                this.SetClearedDate(newTransaction, "current");
                newTransaction.HasClearedDateValidationMessageDissapeared().Should().BeTrue("'Cleared' Field: Validation dissappears once a correct value has been entered ");
            }else{
                this.SetClearedDate(newTransaction, "");
            }

            if (trxType == "Check")
                newTransaction.SetCode("2100");
            else
                newTransaction.SetCode("1121");

        }

        private void SetTransactionAmount(TransactionForm trxForm, string amount)
        {
            //is empty by default and sets to $0.00 if focused on, so don't fill when empty
            if (amount != "")
            {
                trxForm.SetAmount(amount);
                trxForm.PressTabKey();
            }
        }

        private string GetFormattedDateForNewTrx(DateTime date)
        {
            return date.ToString("MM/dd/yyyy");
        }

        private string GetFormattedDateForEditTrx(DateTime date)
        {
            return date.ToString("MM/dd/yyyy");
        }

        private void SetTransactionDate(TransactionForm trxForm, string transactionDate)
        {
            switch (transactionDate)
            {
                case "current":
                    trxForm.SetTransactionDate(this.GetFormattedDateForNewTrx(DateTime.Now));
                    break;

                case "past":
                    trxForm.SetTransactionDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(-5)));
                    break;

                case "future":
                    trxForm.SetTransactionDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(5)));
                    break;

                case "farFuture":
                    trxForm.SetTransactionDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(15)));
                    break;

                case "invalidFormat":
                    trxForm.SetTransactionDate("(13/336.1200)");
                    break;
                    
                case "invalidDate":
                    trxForm.SetTransactionDate("13/36/1200");
                    break;

                case "default":
                    break;

                default:
                    trxForm.SetTransactionDate(transactionDate);
                    break;
            }
        }

        private void VerifyTransactionDateValue(TransactionForm trxForm, string transactionDate)
        {
            switch (transactionDate)
            {
                case "current":
                    trxForm.TransactionDate.Should().Be(this.GetFormattedDateForEditTrx(DateTime.Now));
                    break;

                case "past":
                    trxForm.TransactionDate.Should().Be(this.GetFormattedDateForEditTrx(DateTime.Now.AddDays(-5)));
                    break;

                case "future":
                    trxForm.TransactionDate.Should().Be(this.GetFormattedDateForEditTrx(DateTime.Now.AddDays(5)));
                    break;

                case "farFuture":
                    trxForm.TransactionDate.Should().Be(this.GetFormattedDateForEditTrx(DateTime.Now.AddDays(15)));
                    break;

                case "invalidFormat":
                    trxForm.TransactionDate.Should().Be("(13/336.1200)");
                    break;

                case "invalidDate":
                    trxForm.TransactionDate.Should().Be("13/36/1200");
                    break;

                case "default":
                    break;

                default:
                    trxForm.TransactionDate.Should().Be(transactionDate);
                    break;
            }
        }

        private void SetClearedDate(TransactionForm trxForm, string clearedDate)
        {
            switch (clearedDate)
            {
                case "current":
                    trxForm.SetClearedDate(this.GetFormattedDateForNewTrx(DateTime.Now));
                    break;

                case "past":
                    trxForm.SetClearedDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(-5)));
                    break;

                case "future":
                    trxForm.SetClearedDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(5)));
                    break;

                case "farFuture":
                    trxForm.SetClearedDate(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(15)));
                    break;

                case "invalidFormat":
                    trxForm.SetClearedDate("(13/336.1200)");
                    break;

                case "invalidDate":
                    trxForm.SetClearedDate("13/36/1200");
                    break;

                case "default":
                    break;

                default:
                    trxForm.SetClearedDate(clearedDate);
                    break;
            }
        }

        private void VerifyClearedDateValue(TransactionForm trxForm, string clearedDate)
        {
            switch (clearedDate)
            {
                case "current":
                    trxForm.Cleared.Should().Be(this.GetFormattedDateForNewTrx(DateTime.Now));
                    break;

                case "past":
                    trxForm.Cleared.Should().Be(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(-5)));
                    break;

                case "future":
                    trxForm.Cleared.Should().Be(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(5)));
                    break;

                case "farFuture":
                    trxForm.Cleared.Should().Be(this.GetFormattedDateForNewTrx(DateTime.Now.AddDays(15)));
                    break;

                case "invalidFormat":
                    trxForm.Cleared.Should().Be("(13/336.1200)");
                    break;

                case "invalidDate":
                    trxForm.Cleared.Should().Be("13/36/1200");
                    break;

                case "default":
                    break;

                default:
                    trxForm.Cleared.Should().Be(clearedDate);
                    break;
            }
        }

        [When(@"I See the Transaction has been Saved")]
        [Then(@"I See the Transaction has been Saved")]
        private void ThenISeeTheTransactionHasBeenSaved()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");
            bankingTab.Pause(1);
            //Search transaction on the list
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

            string participantDescription = ScenarioContext.Current.Get<string>("Participant Description");

            //Search transaction on the list
            BankTransactionData transaction;
            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
                transaction = bankingTab.GetTransactionBySerialNumber(CommonMethodsUnityStepBase.GetExpectedSerialNumberTextForLedger(trxType));
            else
                transaction = bankingTab.GetTransactionByName(participantDescription);

            transaction.Should().NotBeNull(trxType+" is Saved after correcting values and saving");
        }


        [Then(@"I See the Form is Still Open and the Transaction has NOT Been Saved")]
        private void ThenISeeTheCheckFormStillOpenAndTheTransactionHasNOTBeenSaved()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            

            //Check form should still be open
            bankingTab.IsNewTransactionFormOpen().Should().BeTrue("Transaction Form is not closed if there are validations errors");

            if (ScenarioContext.Current.ScenarioInfo.Title.Contains("Edit").Equals(false))
            {

                //Trx should not be saved
                string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

                //Search transaction on the list
                if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
                {
                    string serialNbr = ScenarioContext.Current.Get<string>("Transaction Serial Number");
                    bankingTab.IsTransactionPresentOnTheList(trxType + " #" + serialNbr).Should().BeFalse("Transaction is not saved with validations errors");
                }
                else
                {
                    BankTransactionData transaction;
                    transaction = bankingTab.GetTransactionByName(newTransaction.GetTransactionName().Replace(" | Add New Participant Record", ""));
                    transaction.Should().BeNull("Transaction is not saved with validations errors");
                }
            }


        }

        //Enter Key validation specific steps
        [When(@"I Focus on Transaction Field '(.*)' and Hit Enter Key")]
        [Then(@"I Focus on Transaction Field '(.*)' and Hit Enter Key")]
        private void WhenIFocusOnCheckFieldAndHitEnterKey(string field)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            AddDataToScenarioContextOverridingExistentKey("Participant Description", newTransaction.GetTransactionName().Split('|')[0].TrimEnd());
            newTransaction.FocusAndHitEnterOnField(field);
            bankingTab.Pause(2);
        }

        [Given(@"I See Default Cursor Position Is Name Field After Tabbing")]
        [When(@"I See Default Cursor Position Is Name Field After Tabbing")]
        [Then(@"I See Default Cursor Position Is Name Field After Tabbing")]
        private void ThenISeeDefaultCursorPositionIsNameField()
        {
            //get form and verify the focus is on Name field
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");            
            newTransaction.PressTabKey();
            newTransaction.IsFocusOnNameField().Should().BeTrue("Focus is on Name field when first entering the Transaction Form");            
        }

        [Then(@"I See All Fields Contain Correct Labels And Placeholders")]
        private void ThenISeeAllFieldsContainCorrectLabelsAndPlaceholders()
        {
            //Get form and trx type
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

            //Verify form title
            this.VerifyFormTitle(newTransaction, trxType);            

            //Verify each field label and placeholder
            this.VerifySerialNumberLabelAndValue(newTransaction, trxType);
            this.VerifyNameFieldLabelAndPlaceholder(newTransaction, trxType);
            this.VerifyDescriptionLabelAndPlaceholder(newTransaction);
            this.VerifyTransactionLabelAndValue(newTransaction);
            this.VerifyClearedLabelAndPlaceholder(newTransaction);
            this.VerifyCodeLabelAndValue(newTransaction, trxType);           
            this.VerifySubcodeLabelAndValue(newTransaction, trxType);

            if (trxType == "Check")
            {
                this.VerifyNonCompensableLabelAndValue(newTransaction);
                this.VerifyUTCSplit(newTransaction);               
            }

            this.VerifyAmountFieldLabelAndPlaceholder(newTransaction, trxType);
        }

        private void VerifySubcodeLabelAndValue(TransactionForm trxForm, string trxType)
        {
            if (trxType != "Transfer Out")
            {
            trxForm.SubCodeLabel.Should().Be("SUB CODE", "'Code' field has the correct label");
            if (trxType.Contains("Bank Service Charge"))
                trxForm.SubCode.Should().Be("", "'Code' field default value is 2600 on Bank Service Charge Transactions");
            else
                trxForm.SubCode.Should().Be("Search...", "'Code' field default value is empty");
        }
        }

        private void VerifyTransferOutFromAndTo(TransactionForm trxForm)
        {   
            trxForm.TransferOutFromLabel.Should().Be("FROM BANK AND ACCOUNT", "Transfer Out From label is correct");
            trxForm.TransferOutFrom.Should().BeEquivalentTo(bankingTab.GetDetailBABankName() + " - "+ bankingTab.GetDetailBANumber(), "Transfer Out From value is correct");
            trxForm.TransferOutToLabel.Should().Be("TO BANK AND ACCOUNT", "Transfer Out label is correct");
            trxForm.TransferOutTo.Should().BeEquivalentTo("Please open an account or set existing accounts to open to complete transfer.", "Transfer Out from is correct");
        }

        private void VerifyFormTitle(TransactionForm trxForm, string trxType)
        {
            string trxExpectedTitle = "";
            switch (trxType)
            {
                case "Check":
                    trxExpectedTitle = "Write a Check";
                    break;
                case "Deposit":
                    trxExpectedTitle = "Make a Deposit";
                    break;
                case "Deposit Correcting Check":
                    trxExpectedTitle = "Write Deposit Correcting Check";
                    break;
                case "Deposit Correcting Debit":
                    trxExpectedTitle = "Record a Deposit Correcting Debit";
                    break;
                case "Bank Service Charge":
                    trxExpectedTitle = "Record Bank Service Charge";
                    break;
                case "Bank Service Charge Refund (Neg)":
                    trxExpectedTitle = "Record Bank Service Charge Refund";
                    break;
                case "Transfer Out":
                    trxExpectedTitle = "Transfer Funds";
                    break;
                default:
                    throw new NotImplementedException();
            }

            trxForm.TransactionFormTitle.Should().Be(trxExpectedTitle, "Transaction form title for " + trxType + " is correct");
        }

        [Then(@"I See SUM OF ALLOCATION Field Is Not Present Except For Deposits")]
        private void ThenISeeSUMOFALLOCATIONFieldIsNotPresent()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            bool invisible = newTransaction.IsSumOfAllocationFieldInvisible();
            if (trxType == "Deposit")
                invisible.Should().BeFalse("Sum of Allocation field is present by default on Deposit form");
            else
                invisible.Should().BeTrue("Sum of Allocation field is not present by default on other forms than deposit");
        }


        private void VerifyUTCSplit(TransactionForm newTransaction)
        {
            newTransaction.UTCSplitTitle.Should().Be("UTC SPLITS", "UTC Splits title is correct");
            newTransaction.UTCSplitLinkText.Should().Be("ADD UTC SPLIT", "UTC Split link text is correct");
            newTransaction.IsUTCSplitLinkIconVisible.Should().BeTrue("UTC Split icon is present");
        }

        [Then(@"Entering A Negative Value On Amount Field Is Not Posible")]
        private void ThenEnteringANegativeValueOnAmountFieldIsNotPosible()
        {            
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetAmount("-15000");
            //if the number is not positive, selenium cannot add it at all, 
            //so the assert is for an empty string on the amount value after attempt
            newTransaction.Amount.Should().Be("$ 15,000", "Not Negative values can be entered on Amount field");
        }
        
        //Verify Serial Number label 
        private void VerifySerialNumberLabelAndValue(TransactionForm trxForm, string trxType)
        {
            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
            {
                string label = trxForm.SerialNumberLabel;
                switch (trxType)
                {
                    case "Check":
                        label.Should().Be("CHECK SERIAL #", "'Serial Number' field has the correct label");
                        break;
                    case "Deposit":
                        label.Should().Be("DEPOSIT SERIAL #", "'Serial Number' field has the correct placeholder");
                        break;
                    case "Deposit Correcting Check":
                        label.Should().Be("CHECK SERIAL #", "'Serial Number' field has the correct label");
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }         
        }

        //Verify Name label and placeholder
        private void VerifyNameFieldLabelAndPlaceholder(TransactionForm trxForm, string trxType)
        {
            if (trxType == "Transfer Out")
            {
                this.VerifyTransferOutFromAndTo(trxForm);
            }
            else
            {
                string label = trxForm.ToOrFromNameLabel;
                switch (trxType)
                {
                    case "Check":
                        label.Should().Be("PAY TO THE ORDER OF", "'Pay to the Order Of' field has the correct label");
                        trxForm.ToOrFromNamePlaceholder.Should().Be("Add a Name...", "'Received' field has the correct placeholder");
                        break;

                    case "Deposit Correcting Check":
                        label.Should().Be("PAY TO THE ORDER OF", "'Pay to the Order Of' field has the correct label");
                        trxForm.ToOrFromNamePlaceholder.Should().Be("", "'Pay to the Order Of' field has the correct placeholder");
                        break;

                    case "Deposit Correcting Debit":
                        label.Should().Be("PAY TO THE ORDER OF", "'Pay to the Order Of' field has the correct label");
                        trxForm.ToOrFromNamePlaceholder.Should().Be("Add a Name...", "'Received' field has the correct placeholder");
                        break;

                    case "Bank Service Charge":
                        label.Should().Be("PAY TO THE ORDER OF", "'Pay to the Order Of' field has the correct label");
                        trxForm.ToOrFromNamePlaceholder.Should().Be("Add a Name...", "'Received' field has the correct placeholder");
                        break;

                    case "Deposit":
                        label.Should().Be("RECEIVED FROM", "'Received From' field has the correct label");
                        trxForm.ToOrFromNamePlaceholder.Should().Be("Add a Name...", "'Received' field has the correct placeholder");
                        break;

                    case "Bank Service Charge Refund (Neg)":
                        label.Should().Be("RECEIVED FROM", "'Received From' field has the correct label");
                        trxForm.ToOrFromNamePlaceholder.Should().Be("Add a Name...", "'Received' field has the correct placeholder");
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        //Verify Description label and ph
        private void VerifyDescriptionLabelAndPlaceholder(TransactionForm trxForm)
        {
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

            trxForm.DescriptionLabel.Should().Be("DESCRIPTION", "'Description' field has the correct label");
            string descriptionPlaceholder = trxForm.DescriptionPlaceholder;
            if(trxType == "Transfer Out")
                descriptionPlaceholder.Should().Be("Enter a Description...", "'Description' field has the correct placeholder");
            else
                descriptionPlaceholder.Should().Be("Add a Description...", "'Description' field has the correct placeholder");
        }

        //Verify Transaction label and value
        private void VerifyTransactionLabelAndValue(TransactionForm trxForm)
        {
            trxForm.TransactionDateLabel.Should().Be("TRANSACTION", "'Transaction' field has the correct label");
            //trxForm.TransactionDate.Should().Be(this.GetFormattedDateForNewTrx(DateTime.Now), "'Transaction' field default value is today's date");
        }

        //Verify Cleared label and ph
        private void VerifyClearedLabelAndPlaceholder(TransactionForm trxForm)
        {
            trxForm.ClearedLabel.Should().Be("CLEARED", "'Cleared' field has the correct label");
            trxForm.ClearedPlaceholder.Should().Be("MM/DD/YYYY", "'Cleared' field has the correct placeholder");
        }

        //Verify Code label and value
        private void VerifyCodeLabelAndValue(TransactionForm trxForm, string trxType)
        {
            trxForm.CodeLabel.Should().Be("CODE", "'Code' field has the correct label");
            if(trxType.Contains("Bank Service Charge"))
                trxForm.Code.Should().StartWithEquivalent("2600", "'Code' field default value is 2600 on Bank Service Charge Transactions");
            else if (trxType== "Transfer Out")
                trxForm.Code.Should().Be("9999", "'Code' field default value is empty");
            else
                trxForm.Code.Should().Be("Search...", "'Code' field default value is empty");
        }

        //Verify Non Compensable label and value
        private void VerifyNonCompensableLabelAndValue(TransactionForm trxForm)
        {
            trxForm.NonCompensableLabel.Should().Be("Non-Compensable", "'Non Compensable' field has the correct label");
            trxForm.NonCompensable.Should().BeFalse("'Non Compensable' field default value is false");
        }

        //Verify Asset Link label
        private void VerifyAssetLinkLabel(TransactionForm trxForm)
        {
            trxForm.AssetLinkLabel.Should().Be("ASSET LINK", "'Asset Link' field has the correct labels");
        }

        //Verify Amount label and ph
        private void VerifyAmountFieldLabelAndPlaceholder(TransactionForm trxForm, string trxType)
        {
            string label = trxForm.AmountLabel;
            switch (trxType){
			    case "Check":
				    label.Should().Be("CHECK AMOUNT", "'Check Amount' field has the correct label");
                    break;
			    case "Deposit":
				    label.Should().Be("NET DEPOSIT", "'Net Deposit' field has the correct label");
                    break;
                case "Deposit Correcting Check":
                    label.Should().Be("CHECK AMOUNT", "'Amount' field has the correct label");
                    break;
                case "Deposit Correcting Debit":
                    label.Should().Be("DEBIT AMOUNT", "'Amount' field has the correct label");
                    break;
                case "Bank Service Charge":
                    label.Should().Be("SERVICE CHARGE AMOUNT", "'Amount' field has the correct label");
                    break;
                case "Bank Service Charge Refund (Neg)":
                    label.Should().Be("SERVICE CHARGE AMOUNT", "'Amount' field has the correct label");
                    break;
                case "Transfer Out":
                    label.Should().Be("TRANSFER AMOUNT", "'Amount' field has the correct label");
                    break;                    
                default:
			    	throw new NotImplementedException();

            }

            string placeholder = trxForm.AmountPlaceholder;
            //placeholder.Should().Be("Enter Amount...", "'Amount' field has the correct placeholder");
        }


        [Then(@"I See Dates Values Are Converted To '(.*)' and '(.*)'")]
        private void ThenISeeDatesBeing(string transactionDate, string clearedDate)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            this.VerifyTransactionDateValue(newTransaction, transactionDate);
            this.VerifyClearedDateValue(newTransaction, clearedDate);
        }

        [Then(@"When I Focus on Transaction Date Field I See A Date Picker")]
        private void ThenWhenIFocusOnClearedDateFieldISeeADatePicker()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.IsDatePickerPresentOnTransactionInput().Should().BeTrue("Date picker displays when doing focus on Transaction field");
        }

        [Then(@"When I Focus on Cleared Date Field I See A Date Picker")]
        private void ThenWhenIFocusOnTransactionDateFieldISeeADatePicker()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.IsDatePickerPresentOnClearedInput().Should().BeTrue("Date picker displays when doing focus on Transaction field");
        }

        [Then(@"I See Serial Number Autocompletes")]
        private void ThenISeeSerialNumberAutocompletes()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SerialNumber.Should().NotBeEmpty("Serial Number Automcompletes on New Transaction Form");
        }

        [When(@"I Create A Transaction With The Default Serial Number")]
        private void WhenICreateATransactionWithTheDefaultSerialNumber()
        {
            //Set required data and save with default Serial #
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            newTransaction.SetName("Test Automation Of Default Serial Number");
            newTransaction.SetAmount("100.00");
            newTransaction.SetCode("1121");

            //Save serial number for other steps            
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            this.AddSerialNumberToScenario(newTransaction, trxType);

            newTransaction.Save();            

            AddDataToScenarioContextOverridingExistentKey("Participant Description", "Test Automation Of Default Serial Number");
        }

        [Then(@"If I Open The Form Again I See The Default Serial Number Is Higher Than The Previous One")]
        private void ThenISeeTheDefaultSerialNumberIsHigherThanThePreviousOne()
        {
            //Open the Transaction form
            TransactionForm newTransaction;
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            newTransaction = bankingTab.ClickNewTransactionMenuLink(trxType);

            //Get serial number of the previously created check on scenario context
            int previousSerialNbr = Convert.ToInt32(ScenarioContext.Current.Get<string>("Transaction Serial Number"));

            //Evaluate if the new number is greater than the previous one that has been saved            
            Convert.ToInt32(newTransaction.SerialNumber).Should().BeGreaterThan(previousSerialNbr, "Transactions Default Serial # the Next on the series");

            //Note that not always is going to be the very next one, because another transaction 
            //could have been entered outside the automation run, modifying the series
        }

    }
}
