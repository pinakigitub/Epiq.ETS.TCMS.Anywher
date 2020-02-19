using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
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
    public sealed class CaseDetail_Banking_PayToTheOrderOfPredictive:StepBase
    {
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        [Given(@"I Type '(.*)' on Pay to the Order Of Field")]
        [When(@"I Type '(.*)' on Pay to the Order Of Field")]
        [Then(@"I Type '(.*)' on Pay to the Order Of Field")]
        public void GivenITypeOnPayToTheOrderOfField(string text)
        {
            TransactionForm transactionForm = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            transactionForm.TypePayToTheOrderOf(text);
        }
       
        [Then(@"I See Participant Name Results Match Predictive Search '(.*)'")]
        public void ThenISeeParticipantNameResultsMatchPredictiveSearch(string text)
        {
            TransactionForm transactionForm = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            List<string> results = transactionForm.PayToTheOrderOfSearchResults;
            results.First().Should().Contain (" | Add New Participant Record", "Name Search first result is to add new claimant");
            foreach (string name in results)
            {
                name.Should().ContainEquivalentOf(text, "Pay to the Order Of search results include the given input string: " + text);
            }
        }

        [Given(@"I Select The First Participant Result")]
        public void GivenISelectTheFirstParticipantResult()
        {
            TransactionForm transactionForm = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            transactionForm.SelectFirstResultPayToTheOrderOfNotContaining("Add New Participant");
            AddDataToScenarioContextOverridingExistentKey("Participant Description", transactionForm.GetTransactionName().Split('|')[0].TrimEnd());
        }

        [Then(@"I Verify The Selected Participant Is linked to the Transaction On DB")]
        public void ThenIVerifyTheSelectedParticipantIsLinkedToTheTransactionOnDB()
        {

            //get participant id either from Claim if claim links present or from Participant table record
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            int participantId = 0;

            try
            {
                //If there were claim links, linked participant is claim's paticipant
                List<string> claimLinkIds = ScenarioContext.Current.Get<List<string>>("Claim Links Ids");
                parameters.Add("ClaimId", claimLinkIds[0]);
                parameters.Add("CaseId", Convert.ToString(CaseDetailSteps.GetCaseIdFromCaseNumber(ScenarioContext.Current.Get<string>("Case Number"))));
                parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));

                DataRowCollection rows1 = ExecuteQueryOnDB(Properties.Resources.GetParticipantIdFromClaim, parameters);
                participantId = Convert.ToInt32(rows1[0].ItemArray[0]);
                parameters.Remove("ClaimId");
                parameters.Remove("CaseId");
                parameters.Remove("OfficeId");
            }
            catch (KeyNotFoundException)
            {
                //Else, there were no claim links, linked participant is new created participant
                string expectedParticipantName = ScenarioContext.Current.Get<string>("Participant Description");
                parameters.Add("ParticipantNameLike", expectedParticipantName);
                DataRowCollection rows2 = ExecuteQueryOnDB(Properties.Resources.GetParticipantIdFromName, parameters);
                participantId = Convert.ToInt32(rows2[0].ItemArray[0]);
                parameters.Remove("ParticipantNameLike");
            }


            //get participant id from Transaction table record
            string serialNbr = ScenarioContext.Current.Get<string>("Transaction Serial Number");            
            parameters.Add("TransactionId", ""+bankingTab.GetTransactionIdFromListBySerialNumber(serialNbr));
            DataRowCollection rowsTrx = ExecuteQueryOnDB(Properties.Resources.GetTransactionDetails, parameters);
            rowsTrx.Count.Should().BeGreaterThan(0, "Transaction record must be on DB");
            int participantIdTrx = Convert.ToInt32(rowsTrx[0].ItemArray[3]);
            
            //Compare and check the linking is OK
            participantIdTrx.Should().Be(participantId, "Participant Id linked to created transaction is correct on DB");
        }

        [Given(@"I Select Add New Participant Result")]
        public void GivenISelectAddNewParticipantResult()
        {
            TransactionForm transactionForm = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            transactionForm.SelectFirstResultPayToTheOrderOfContaining("Add New Participant");
        }

        [Then(@"I See The Exact Result '(.*)' As An Existent Pay to the Order Of Value")]
        public void ThenISeeTheExactResultAsAnExistentPayToTheOrderOfValue(string text)
        {
            TransactionForm transactionForm = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            List<string> results = transactionForm.GetPayToTheOrderOfResultsByContent(text);

            for (int i = 1; i < results.Count; i++) //Discard first element, it is "Add New Participant Record"
            {
                results[i].Should().BeEquivalentTo(text, "Added participant appears as an existent participant on search results");
            }
        }
    }
}
