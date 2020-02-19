using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    class CaseDetail_Banking_EditDepositSteps:CommonMethodsUnityStepBase
    {
        //REFACTORED
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        [Given(@"Click Edit button for Deposit with Description '(.*)'")]
        [When(@"Click Edit button for Deposit with Description '(.*)'")]
        [Then(@"Click Edit button for Deposit with Description '(.*)'")]
        public void ClickEditButtonForDeposits(string text)
        {
            Thread.Sleep(1000);
            AddDataToScenarioContextOverridingExistentKey("toEditElementDesc", text);
            TransactionForm newDeposit = bankingTab.ClickEditButtonForTransactions(text,"Deposit");
            Assert.IsNotNull(newDeposit, "Edit button is Disabled due to permission restriction.");
            Assert.True(newDeposit.TransactionFormTitle.Contains("Edit Deposit"));
            AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newDeposit);
            AddDataToScenarioContextOverridingExistentKey("New Transaction Type", "Deposit");
            Thread.Sleep(5000);
        }

        [Given(@"I save Transaction ID for Transaction Type '(.*)' with Number '(.*)'")]
        [When(@"I save Transaction ID for Transaction Type '(.*)' with Number '(.*)'")]
        [Then(@"I save Transaction ID for Transaction Type '(.*)' with Number '(.*)'")]
        public void saveDepositForDepNumber(string transactionType, string depositNumber)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            Thread.Sleep(2500);
            IWebElement idToSave = null;
            string newDepositNumber = "";
            if (depositNumber != "")
            {
                if (transactionType == "Deposit")
                {
                    idToSave = createVisibleWebElementByXpath("//p[@id[contains(.,'transactionSerialNumber-')]][contains(text(),'Deposit #" + depositNumber + "')]");
                }
                else if (transactionType == "Check")
                {
                    idToSave = createVisibleWebElementByXpath("//p[@id[contains(.,'transactionSerialNumber-')]][contains(text(),'Check #" + depositNumber + "')]");
                }
                else if (transactionType == "Transfer Funds")
                {
                    idToSave = createVisibleWebElementByXpath("//p[@id[contains(.,'transactionSerialNumber-')]][contains(text(),'Transfer Funds #" + depositNumber + "')]");
                }
            }
            else
            {
                if (transactionType == "Deposit")
                {
                    newDepositNumber = ScenarioContext.Current.Get<string>("depositNumber");
                    idToSave = createVisibleWebElementByXpath("//p[@id[contains(.,'transactionSerialNumber-')]][contains(text(),'Deposit #" + newDepositNumber + "')]");
                }
                else if (transactionType == "Check")
                {
                    newDepositNumber = ScenarioContext.Current.Get<string>("depositNumber");
                    idToSave = createVisibleWebElementByXpath("//p[@id[contains(.,'transactionSerialNumber-')]][contains(text(),'Check #" + newDepositNumber + "')]");
                }
                else if (transactionType == "Transfer Funds")
                {
                    newDepositNumber = ScenarioContext.Current.Get<string>("depositNumber");
                    idToSave = createVisibleWebElementByXpath("//p[@id[contains(.,'transactionSerialNumber-')]][contains(text(),'Transfer Funds #" + newDepositNumber + "')]");
                }
            }

            string transactionIDString = idToSave.GetAttribute("id").ToString().Replace("transactionSerialNumber-","");
            int transactionIdInt = Convert.ToInt32(transactionIDString);
            AddDataToScenarioContextOverridingExistentKey("transactionId", transactionIdInt);
            TestsLogger.Log(transactionIDString);
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Deposit to be edited displayes correct values")]
        [When(@"Verify Deposit to be edited displayes correct values")]
        [Then(@"Verify Deposit to be edited displayes correct values")]
        public void verifyEditDepositModalLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1500);
            pleaseWaitSignDissapear();

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int transactionId = ScenarioContext.Current.Get<int>("transactionId");
            parameters.Clear();
            parameters.Add("transactionId", transactionId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getDepositToEditSavedValues, parameters);

            IWebElement depositSerialNumber = createVisibleWebElementByXpath("//input[@id='depositSerialTextBox']");
            IWebElement receivedFormFieldValue = createVisibleWebElementByXpath("//input[@id='receivedTextBox']");
            IWebElement descriptionFieldValue = createVisibleWebElementByXpath("//input[@id='descriptionTextBox']");
            IWebElement netDepositFieldValue = createVisibleWebElementByXpath("//input[@id='netDepositTextbox']");
            IWebElement grossDepositFieldValue = createVisibleWebElementByXpath("//input[@id='grossDepositTextbox']");
            IWebElement codeValue = createVisibleWebElementById("select2-codeTextBox-container");
            IWebElement subCodeValue = createVisibleWebElementById("select2-subcodeDesktop-container");
            IWebElement clearedDateValue = createVisibleWebElementByXpath("//input[@id='depositClearedDatebox']");
            IWebElement transactionDateFieldValue = createVisibleWebElementByXpath("//input[@id='depositTransactionDateBox']");
            assertAttributeContainsText(depositSerialNumber, "value", rows[0].ItemArray[1].ToString());
            assertAttributeContainsText(netDepositFieldValue, "value", "$ "+convertToDecimalWithCommasFromRows(rows,0,6));
            assertAttributeContainsText(grossDepositFieldValue, "value", "$ "+convertToDecimalWithCommasFromRows(rows,0,8));
            assertAttributeContainsText(codeValue, "value", rows[0].ItemArray[14].ToString()+" "+ rows[0].ItemArray[15].ToString());
            assertAttributeContainsText(subCodeValue, "value", rows[0].ItemArray[16].ToString()+" "+ rows[0].ItemArray[17].ToString());
            assertAttributeContainsText(clearedDateValue, "value", setDBDateToUIFormat(rows, 0, 5));
            assertAttributeContainsText(transactionDateFieldValue, "value", setDBDateToUIFormat(rows, 0, 4));
            checkElementIsDisabled(transactionDateFieldValue);
            checkElementIsDisabled(depositSerialNumber);
            checkElementIsDisabled(netDepositFieldValue);
            pleaseWaitSignDissapear();
        }
    }
}
