using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    public sealed class CaseDetail_Banking_TransactionsPrintSteps: StepBase
    {
        //REFACTORED

        [When(@"I See Check With Serial # '(.*)' Print Link Text Is '(.*)' And Is Active '(.*)'")]
        [Then(@"I See Check With Serial # '(.*)' Print Link Text Is '(.*)' And Is Active '(.*)'")]
        private void WhenISeeCheckWithSerialNbrPrintLinkTextIsAndIsActive(string serialNbr, string linkText, bool isActive)
        {
            BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));
            string actualLinkText = bankingTab.GetTransactionPrintLinkTextBySerialNumber(serialNbr);
            actualLinkText.Should().Be(linkText, "Print link text is correct");
            bankingTab.IsTransactionPrintLinkActiveBySerialNumber(serialNbr).Should().Be(isActive, "Print link status is correct");
        }

        [When(@"I Click On Print Link For Check With Serial # '(.*)'")]
        [Then(@"I Click On Print Link For Check With Serial # '(.*)'")]
        private void WhenIClickOnPrintLinkForCheckWithSerialNbr(string serialNbr)
        {
            BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));
            bankingTab.ClickOnTransactionPrintLinkBySerialNumber(serialNbr);
        }

        [BeforeScenario("@PrintChecks")]
        private void RestoreChecksPrintStatus()
        {
            //restore print status to "not printed" for check with id=5525
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("BankAccountTransactionId", "5525");
            parameters.Add("PrintStatus", "1");
            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.UpdateTransactionPrintStatus, parameters);
            TestsLogger.Log("Updated print status to 'not printed' for trx with id 5525");

            //restore print status to "printed" for check with id=5524
            Dictionary<string, string> parameters2 = new Dictionary<string, string>();
            parameters2.Add("BankAccountTransactionId", "5524");
            parameters2.Add("PrintStatus", "2");
            DataRowCollection rows2 = ExecuteQueryOnDB(Properties.Resources.UpdateTransactionPrintStatus, parameters2);
            TestsLogger.Log("Updated print status to 'printed' for trx with id 5524");
        }
    }
}
