using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    public class CaseDetail_Banking_TransactionsLinksSteps: CommonMethodsUnityStepBase
    {
        //REFACTORED
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        [Given(@"I See Claim Link Section Layout Is Correct")]
        public void GivenISeeClaimLinkSectionLayoutIsCorrect()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClaimLinksSectionTitle.Should().Be("CLAIM LINK", "Claim links section title is correct");
            newTransaction.TransactionLinks.AddClaimLinkText.Should().Be("ADD CLAIM LINK", "Add Claim link text is correct");
            newTransaction.TransactionLinks.IsAddClaimLinkIconVisible().Should().BeTrue("Add Claim link icon is present");            
        }

        [Then(@"I See Add Claim Link Now Reads '(.*)'")]
        public void ThenISeeAddClaimLinkNowReads(string linkText)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.AddClaimLinkText.Should().Be(linkText, "Add Claim link text is correct");
        }

        [Given(@"I Click On Claim Search Box For Row '(.*)'")]
        [When(@"I Click On Claim Search Box For Row '(.*)'")]
        [Then(@"I Click On Claim Search Box For Row '(.*)'")]
        public void WhenIClickOnClaimSearchBoxForRow(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickClaimSearchBoxByRow(rowPosition);            
        }
        
        [When(@"I Enter Text '(.*)' on Claim Search Box Filter For Row '(.*)'")]
        [Then(@"I Enter Text '(.*)' on Claim Search Box Filter For Row '(.*)'")]
        public void WhenIEnterTextOnClaimSearchBoxFilterForRow(string searchText, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.EnterTextOnClaimSearchBoxByRow(searchText, rowPosition);            
        }
        
        [When(@"I Select Claim To Link On Row '(.*)' By Claim Number '(.*)' And Claim Name '(.*)' And Claim Code '(.*)' Using Method '(.*)'")]
        public void WhenISelectClaimToLinkByClaimNumberAndClaimNameAndClaimCodeUsingMethod(int rowPosition, string number, string name, string code, string selectionMethod)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.SelectClaimFromResultsUsingMethod(rowPosition, number, name, code,selectionMethod);
        }
        
        [When(@"I Click On Save Check For Claim Links")]
        public void WhenIClickOnSaveCheckForClaimLinks()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            AddDataToScenarioContextOverridingExistentKey("Transaction Serial Number", newTransaction.SerialNumber);

            //Save links data to verify DB later
            try
            {
                ScenarioContext.Current.Get<bool>("Added Claim Link/s");
                //TODO Save claims balances prior to save - to verify later that balance has changed on DB or claims list
                ScenarioContext.Current.Add("Created Transaction Linked Claim Data", newTransaction.TransactionLinks.GetClaimsLinksData());
            }
            catch (Exception)
            {
                //if "Added Claim Link/s" is not in the scenario context, then no claim links were added to transaction
            }

            string serialNbr = newTransaction.SerialNumber;

            newTransaction.Save();

            //Verify Trx form closes  and get transaction id
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");
            ScenarioContext.Current.Add("Saved Transaction Id", bankingTab.GetTransactionIdFromListBySerialNumber(serialNbr));
        }

        private object GetSelectedClaimsBalances()
        {
            throw new NotImplementedException();
        }

        [Then(@"I See Labels For Claim Link Columns Are Correct")]
        public void ThenISeeLabelsForClaimLinkColumnsAreCorrect()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");

            if (trxType == "Check")
            { 
                newTransaction.TransactionLinks.ClaimNumberLabel.Should().Be("CLAIM #", "Add Claim link - Claim Number label is correct");
                newTransaction.TransactionLinks.ClaimNameLabel.Should().Be("CLAIM NAME", "Add Claim link - Claim Name label is correct");
                newTransaction.TransactionLinks.ClaimAllocationDescriptionLabel.Should().Be("ALLOCATION DESCRIPTION", "Add Claim link - Allocation Descriptio label is correct");
            }
            else
            {                
                newTransaction.TransactionLinks.ClaimNumberLabel.Should().Be("CLAIM #", "Add Claim link - Claim Number label is correct");
                newTransaction.TransactionLinks.ClaimNameLabel.Should().Be("CLAIM NAME", "Add Claim link - Claim Name label is correct");
                newTransaction.TransactionLinks.ClaimAllocationDescriptionLabel.Should().Be("ALLOCATION DESCRIPTION", "Add Claim link - Description label is correct");
            }
            newTransaction.TransactionLinks.ClaimCodeLabel.Should().Be("CODE", "Add Claim link - Claim Code label is correct");
            newTransaction.TransactionLinks.ClaimNonCompensableLabel.Should().Be("NON-COMPENSABLE", "Add Claim link - Claim Non Compensable label is correct");
            newTransaction.TransactionLinks.ClaimAmountLabel.Should().Be("AMOUNT", "Add Claim link - Claim Amount label is correct");
        }

        [Given(@"I See '(.*)' Claim Link Rows")]
        [When(@"I See '(.*)' Claim Link Rows")]
        [Then(@"I See '(.*)' Claim Link Rows")]
        public void ThenISeeClaimLinkRows(int expRowsCount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            if(expRowsCount != 0)
                newTransaction.TransactionLinks.GetClaimLinksCount().Should().Be(expRowsCount,"Claim Links count is "+expRowsCount+" as expected");
            else
                newTransaction.TransactionLinks.ClaimLinksCountIsZero().Should().BeTrue("Claim Links count is " + expRowsCount + " as expected");

        }

        [Given(@"I Click On ADD Claim Link")]
        [When(@"I Click On ADD Claim Link")]
        [Then(@"I Click On ADD Claim Link")]        
        public void GivenIClickOnADDClaimLink()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickAddClaimLink();
        }

        [Then(@"I See Claim Name Search Box Placeholder For Row '(.*)' Is '(.*)'")]
        public void ThenISeeClaimNameSearchBoxPlaceholderIs(int rowPosition, string placeholder)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.GetClaimNamePlaceholderByRowPosition(rowPosition).Should().Be(placeholder,"Claim Search box placeholder is correct");
        }


        [Then(@"I See The List Of Claims Displays With Correct Layout On Row '(.*)'")]
        public void ThenISeeTheListOfClaimsDisplaysWithCorrectLayout(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.GetClaimNumberGridHeaderByRowPosition(rowPosition).Should().Be("CLAIM #", "Claim Number grid header is correct");
            newTransaction.TransactionLinks.GetClaimNameGridHeaderByRowPosition(rowPosition).Should().Be("CLAIM NAME", "Claim Name grid header is correct");
            newTransaction.TransactionLinks.GetClaimCodeGridHeaderByRowPosition(rowPosition).Should().Be("CODE", "Claim Code grid header is correct");
            newTransaction.TransactionLinks.GetClaimTypeGridHeaderByRowPosition(rowPosition).Should().Be("TYPE", "Claim Type grid header is correct");
            newTransaction.TransactionLinks.GetClaimBalanceGridHeaderByRowPosition(rowPosition).Should().Be("BALANCE", "Claim Type grid header is correct");
        }

        [Then(@"I See The List Of Claims Has Correct Data")]
        public void ThenISeeTheListOfClaimsHasCorrectData()
        {
            //NOTE:This verifies content and sorting of claims list

            //Get displayed claims on the Grid
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            List<ClaimData> displayedClaims = newTransaction.TransactionLinks.GetListOfClaimsOnLinkSearchGrid();
            
            
            //Get Claims for this Case from DB
            List<ClaimData> expectedClaims = new List<ClaimData>();

            //Set caseId
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId", CaseDetailSteps.GetCaseIdFromCaseNumber(ScenarioContext.Current.Get<string>("Case Number"))+"");
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));

            //Execute query
            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetClaimLinksListDetailsByCaseId, parameters);           
            foreach (DataRow row in rows)
            {
                ClaimData dbClaim = new ClaimData();
                string claimNumber = Convert.ToString(row.ItemArray[1]);
                if (claimNumber == null)
                    claimNumber = "";
                dbClaim.ClaimNumber = claimNumber+ row.Field<string>("Suffix").TrimStart().TrimEnd();
                dbClaim.CreditorName = row.Field<string>("SortName").TrimStart().TrimEnd();
                dbClaim.Code = row.Field<string>("ClaimUTC").TrimStart().TrimEnd();
                dbClaim.Class = row.Field<string>("ClaimClass").TrimStart().TrimEnd();
                dbClaim.Balance = row.Field<string>("ClaimBalance").TrimStart().TrimEnd();
                expectedClaims.Add(dbClaim);              
            }

            displayedClaims.ShouldBeEquivalentTo(expectedClaims,"Claims on Grid match claims on DB for this Case and Sort order is the same");
        }      
        
        
        [Then(@"I See Filtered Results Match Search Text '(.*)'")]
        public void ThenISeeFilteredResultsAreCorrect(string searchText)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            bool allMatches = true;
            List<ClaimData> displayedClaims = newTransaction.TransactionLinks.GetListOfClaimsOnLinkSearchGrid();
            foreach (ClaimData claim in displayedClaims)
            {
                //check if this row matches search text on number, name or code fields
                bool matchesRow = false;
                matchesRow = matchesRow || claim.ClaimNumber.Contains(searchText);
                matchesRow = matchesRow || claim.CreditorName.Contains(searchText);
                matchesRow = matchesRow || claim.Code.Contains(searchText);

                //add match to all matches
                allMatches = allMatches && matchesRow;

                //if this row doesn't match, then everything fails
                if (!allMatches)
                    break;
            }

            allMatches.Should().BeTrue("All rows match search text "+searchText);
        }

        [Then(@"I See No Claims Results On The Grid And a Message Reading '(.*)'")]
        public void ThenISeeNoClaimsResultsOnTheGridAndAMessageReading(string message)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.GetCountOfClaimsAvailableToLink().Should().Be(0,"No results expected on claims Grid");
            newTransaction.TransactionLinks.ClaimsListMessage.Should().Be(message, "Expected message displays on Claims Grid");
        }

        [Then(@"I See Claim Link Grid Closes")]
        public void ThenISeeClaimLinkGridCloses()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.HasClaimsGridDissapeared().Should().BeTrue("Claims grid closes after selecting a claim");
        }

        [Given(@"I See Claim Link Row '(.*)' With Claim \# '(.*)' Name '(.*)' Code '(.*)' Allocation Description '(.*)' Non-Compensable '(.*)' And Amount '(.*)'")]
        [Then(@"I See Claim Link Row '(.*)' With Claim \# '(.*)' Name '(.*)' Code '(.*)' Allocation Description '(.*)' Non-Compensable '(.*)' And Amount '(.*)'")]
        public void ThenISeeClaimLinkRowWithClaimAndNameAndCode(int rowPosition, string number, string name, string code, string allocationDescr, bool nonCompensable, string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");            
            newTransaction.TransactionLinks.GetClaimLinkNumberByRowPosition(rowPosition).Should().Be(number,"Claim Link " + rowPosition + " - Claim # is correct");

            newTransaction.TransactionLinks.GetClaimLinkNameByRowPosition(rowPosition).Should().Be(name, "Claim Link " + rowPosition + " - Claim Name is correct");
            newTransaction.TransactionLinks.GetClaimLinkCodeByRowPosition(rowPosition).Should().Be(code, "Claim Link " + rowPosition + " - Claim Code is correct");
            
            newTransaction.TransactionLinks.GetClaimLinkAllocationDescriptionByRowPosition(rowPosition).Should().Be(allocationDescr, "Claim Link " + rowPosition + " - Allocation Description value is correct");
            newTransaction.TransactionLinks.IsClaimLinkNonCompensableVisibleByRowPosition(rowPosition).Should().BeTrue("Claim Link " + rowPosition + " - Non-Compensable checkbox is visible");
            newTransaction.TransactionLinks.IsClaimLinkNonCompensableSelectedByRowPosition(rowPosition).Should().Be(nonCompensable, "Claim Link " + rowPosition + " - Non-Compensable value is correct");
            //ignore spaces on amount verification
            newTransaction.TransactionLinks.GetClaimLinkAmountByRowPosition(rowPosition).Replace(" ", "").Should().Be(amount.Replace(" ", ""), "Claim Link " + rowPosition + " - Amount value is correct");

        }       

        [Then(@"I See No Claim Result On Row '(.*)' Has Claim Number '(.*)' And Claim Name '(.*)' And Claim Code '(.*)'")]
        public void ThenISeeNoClaimResultHasClaimNumberAndClaimNameAndClaimCode(int rowPosition, string number, string name, string code)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.IsClaimOnList(rowPosition, number, name, code).Should().BeFalse("Claim with Claim # "+number+", Name "+name+" and Code "+code+" is not present on row "+rowPosition+" claims list");
        }

        [Given(@"I Search And Select Claim To Link On Row '(.*)' By Claim Number '(.*)' And Claim Name '(.*)' And Claim Code '(.*)'")]
        [When(@"I Search And Select Claim To Link On Row '(.*)' By Claim Number '(.*)' And Claim Name '(.*)' And Claim Code '(.*)'")]
        [Then(@"I Search And Select Claim To Link On Row '(.*)' By Claim Number '(.*)' And Claim Name '(.*)' And Claim Code '(.*)'")]
        public void GivenISearchAndSelectClaimToLinkByClaimNumberAndClaimNameAndClaimCode(int rowPosition, string number, string name, string code)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickClaimSearchBoxByRow(rowPosition);
            newTransaction.TransactionLinks.EnterTextOnClaimSearchBoxByRow(name, rowPosition);
            newTransaction.TransactionLinks.SelectClaimFromResultsUsingMethod(rowPosition, number, name, code, "Click");
            AddDataToScenarioContextOverridingExistentKey("Added Claim Link/s", true);            
        }

        [Given(@"I Select The First Claim To Link On Row '(.*)'")]
        public void GivenISelectTheFirstClaimToLinkOnRow(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickClaimSearchBoxByRow(rowPosition);
            newTransaction.TransactionLinks.SelectFirstClaimFromResults(rowPosition);
        }

        [Then(@"I See Claim Balance Is Reduced For Claim With Claim Number '(.*)' And Claim Name '(.*)' And Claim Code '(.*)'")]
        public void ThenISeeClaimBalanceIsReducedForClaimWithClaimNumberAndClaimNameAndClaimCode(string number, string name, string code)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I Enter Claim Link Amount '(.*)' On Row '(.*)'")]
        [When(@"I Enter Claim Link Amount '(.*)' On Row '(.*)'")]
        [Then(@"I Enter Claim Link Amount '(.*)' On Row '(.*)'")]
        public void GivenIEnterClaimLinkAmountOnRow(string amount, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.EnterClaimLinkAmountOnRowPosition(amount, rowPosition);
        }

        [Given(@"I Enter Claim Link Use As Payee Name '(.*)' On Row '(.*)'")]
        public void GivenIEnterClaimLinkUseAsPayeeNameOnRow(bool useAsPayeeName, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.SetClaimLinkUseAsPayeeNameOnRowPosition(useAsPayeeName, rowPosition);
        }


        [When(@"I Click On Remove Icon For Row '(.*)'")]
        [Then(@"I Click On Remove Icon For Row '(.*)'")]
        public void WhenIClickOnRemoveIconForRow(int rowPosition) {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickOnClaimLinkRemoveIconByRowPosition(rowPosition);
        }

        [When(@"I See The Check Displays Data Correctly On Transactions List '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        [Then(@"I See The Check Displays Data Correctly On Transactions List '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheCheckDisplaysOnTransactionsListWith(string payTo, string code, string amount, string claimNbr1, string claimName1, string claimNbr2, string claimName2)
        {
            //TODO replace with "I See The Transaction Displays Data Correctly On Transactions List"
            //Get serial number of the check to validate
            string serialNbr = ScenarioContext.Current.Get<string>("Transaction Serial Number");

            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");

            //Search transaction on the list
            BankTransactionData check = bankingTab.GetTransactionBySerialNumber("Check #" + serialNbr);

            //Verify data for the check
            //Trx number and name
            check.TransactionNumber.Should().Be("Check #" + serialNbr, "Transaction Number is correct");
            check.Name.Should().Be(payTo, "Name is Correct");

            //claim links data display
            check.ClaimLinkLabel.Should().Be("CLAIM LINK", "Claim Link label is correct on Check display");
            // If links are expected, verify claim links data 
            if (check.ClaimLinkName1 != "")
            {
                check.ClaimLinkNumberLabel.Should().Be("CLAIM#", "Claim Link # label is correct on Check display");
                check.ClaimLinkNameLabel.Should().Be("NAME", "Claim Link name label is correct on Check display");
                check.ClaimLinkNameLabel.Should().Be("NAME", "Claim Link name label is correct on Check display");
                check.ClaimLinkBalanceLabel.Should().Be("BALANCE", "Claim Link balance label is correct on Check display");

                //shows 2 claims max
                //link 1
                check.ClaimLinkNumber1.Should().Be(claimNbr1, "Claim Link # is correct on Check display");
                check.ClaimLinkName1.Should().Be(claimName1, "Claim Link Name is correct on Check display");

                //TODO add query to restore claims before scenario and check balance value
                if (claimNbr1 == "SPLIT")
                    check.ClaimLinkBalance1.Should().Be("", "Claim Link Balance is empty on Check display for claim link SPLIT");
                else
                    check.ClaimLinkBalance1.Should().NotBe("", "Claim Link Balance is not empty on Check display");

                //link 2
                check.ClaimLinkNumber2.Should().Be(claimNbr2, "Claim Link # is correct on Check display");
                check.ClaimLinkName2.Should().Be(claimName2, "Claim Link Name is correct on Check display");
                //TODO add query to restore claims before scenario and check balance value
                if (claimNbr1 == "SPLIT")
                    check.ClaimLinkBalance2.Should().Be("", "Claim Link Balance is empty on Check display for claim link SPLIT");
                else if (check.ClaimLinkName2 != "")
                    check.ClaimLinkBalance2.Should().NotBe("", "Claim Link Balance is not empty on Check display");
            }

            //code and amount
            check.Code.Should().Be(code, "Code is Correct");
            check.AmountValue.Should().Be(amount, "Amount is Correct");

        }

        [Given(@"I Enter Claim Link Code '(.*)' On Row '(.*)'")]
        public void GivenIEnterClaimLinkCodeOnRow(string code, int rowPosition) {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.EnterClaimLinkCodeOnRowPosition(code, rowPosition);
        }

        [Given(@"I Enter Claim Link Allocation Description '(.*)' On Row '(.*)'")]
        [When(@"I Enter Claim Link Allocation Description '(.*)' On Row '(.*)'")]
        public void GivenIEnterClaimLinkAllocationDescriptionOnRow(string allocDescription, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.EnterClaimLinkAllocationDescriptionOnRowPosition(allocDescription, rowPosition);
        }


        [Given(@"I Enter Claim Link Non-Compensable '(.*)' On Row '(.*)'")]
        public void GivenIEnterClaimLinkNonCompensableOnRow(bool nonComp, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.SetClaimLinkNonCompensableOnRowPosition(nonComp, rowPosition);
        }

        [Then(@"I See Claim Link Allocation Description '(.*)' On Row '(.*)'")]
        public void ThenISeeClaimLinkAllocationDescriptionOnRow(string allocDescr, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.GetClaimLinkAllocationDescriptionByRowPosition(rowPosition).Should().Be(allocDescr,"Allocation Description expected is max 254 characters");
        }

        [Given(@"I Click On Claim Detail View Arrow On Row '(.*)'")]
        [When(@"I Click On Claim Detail View Arrow On Row '(.*)'")]
        [Then(@"I Click On Claim Detail View Arrow On Row '(.*)'")]
        public void WhenIClickOnClaimDetailViewArrow(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.IsClaimDetailViewArrowVisibleByRowPosition(rowPosition).Should().BeTrue("Additional View of Claims dropdown arrow is present.");
            newTransaction.TransactionLinks.ClickOnClaimDetailViewArrowByRowPosition(rowPosition);
        }

        [Then(@"I See Claim Detail Displays With Correct Data On Row '(.*)'")]
        public void ThenISeeClaimDetailDisplaysWithCorrectData(int rowPosition)
        {
            //verify detail arrow icon is fold img
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.IsClaimDetailViewArrowUpByRowPosition(rowPosition).Should().BeTrue("Claim detail icon on Row "+rowPosition);

            //verify displayed labels and boxes
            newTransaction.TransactionLinks.GetClaimDetailClaimedLabelByRowPosition(rowPosition).Should().Be("CLAIMED AMOUNT", "Claim Link "+ rowPosition+" Details - Claimed amount label is correct");
            newTransaction.TransactionLinks.GetClaimDetailAllowedLabelByRowPosition(rowPosition).Should().Be("ALLOWED AMOUNT", "Claim Link " + rowPosition + " Details - Allowed amount label is correct");
            newTransaction.TransactionLinks.GetClaimDetailPaidToDateLabelByRowPosition(rowPosition).Should().Be("PAID TO DATE", "Claim Link " + rowPosition + " Details - Paid to Date label is correct");
            newTransaction.TransactionLinks.GetClaimDetailBalanceDueLabelByRowPosition(rowPosition).Should().Be("BALANCE DUE", "Claim Link " + rowPosition + " Details - Balance due label is correct");

            //query db with claim id
            Decimal claimedAmount = 0;
            Decimal allowedAmount = 0;
            Decimal paidToDate = 0;
            Decimal balanceDue = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ClaimId", newTransaction.TransactionLinks.GetClaimIdFromLinkInRowPosition(rowPosition));
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));

            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetClaimDetailsInfo, parameters);
            foreach (DataRow row in rows)
            {
                claimedAmount = row.Field<Decimal>("ClaimedAmount");
                allowedAmount = row.Field<Decimal>("AllowedAmount");
                paidToDate = row.Field<Decimal>("PaidAmount");
                balanceDue = row.Field<Decimal>("BalanceAmount");
            }

            //verify displayed data
            string expClaimedStr = "$" + claimedAmount;
            expClaimedStr = expClaimedStr.Substring(0, expClaimedStr.Length - 2);
            newTransaction.TransactionLinks.GetClaimDetailClaimedByRowPosition(rowPosition).Replace(",", "").Should().Be(expClaimedStr, "Claim Link " + rowPosition + " Details - Claimed amount is correct");

            string expAllowedStr = "$" + allowedAmount;
            expAllowedStr = expAllowedStr.Substring(0, expAllowedStr.Length - 2);
            newTransaction.TransactionLinks.GetClaimDetailAllowedByRowPosition(rowPosition).Replace(",", "").Should().Be(expAllowedStr, "Claim Link " + rowPosition + " Details - Allowed amount is correct");

            string expPaidStr = "$" + paidToDate;
            expPaidStr = expPaidStr.Substring(0, expPaidStr.Length - 2);
            newTransaction.TransactionLinks.GetClaimDetailPaidToDateByRowPosition(rowPosition).Replace(",", "").Should().Be(expPaidStr, "Claim Link " + rowPosition + " Details - Paid to Date is correct");

            string expBalance= "$" + balanceDue;
            expBalance = expBalance.Substring(0, expBalance.Length - 2);
            if (balanceDue < 0)
                expBalance = "("+expBalance.Replace("-", "")+")";

            newTransaction.TransactionLinks.GetClaimDetailBalanceDueByRowPosition(rowPosition).Replace(",", "").Should().Be(expBalance, "Claim Link " + rowPosition + " Details - Balance due is correct");
        }

        [Then(@"I See Claim Detail View Is Closed On Row '(.*)'")]
        public void ThenISeeClaimDetailViewIsClosed(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            //detail boxes are not visible
            newTransaction.TransactionLinks.ClaimDetailBoxesInvisible(rowPosition).Should().BeTrue("Claim Detail view boxes are not visible");
            //verify detail arrow icon is unfold img
            newTransaction.TransactionLinks.IsClaimDetailViewArrowDownByRowPosition(rowPosition).Should().BeTrue("Claim detail icon on Row " + rowPosition);

        }

        [Given(@"I Save Claim Details Updateable Values For Row '(.*)'")]
        public void GivenISaveClaimDetailsUpdateableValuesForRow(int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");

            string paidToDate = newTransaction.TransactionLinks.GetClaimDetailPaidToDateByRowPosition(rowPosition);
            string balanceDue = newTransaction.TransactionLinks.GetClaimDetailBalanceDueByRowPosition(rowPosition);

            //save paid to date
            ScenarioContext.Current.Add("Claim Link " + rowPosition + " Paid To Date", paidToDate);
            //save balance due
            ScenarioContext.Current.Add("Claim Link " + rowPosition + " Balance Due", balanceDue);
        }


        [Then(@"I See Paid To Date Value Updates By '(.*)' On Row '(.*)'")]
        public void ThenISeePaidToDateValueUpdatesBy(Decimal amount, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string actualPaid = newTransaction.TransactionLinks.GetClaimDetailPaidToDateByRowPosition(rowPosition).Replace("$", "");
            Decimal actualPaidToDate = Convert.ToDecimal(actualPaid);

            //get paid to date from scenario context
            string previousPaid = ScenarioContext.Current.Get<string>("Claim Link " + rowPosition + " Paid To Date").Replace("$", "");
            Decimal previousPaidToDate = Convert.ToDecimal(previousPaid);
            Decimal expPaidToDate = previousPaidToDate + amount;
            //verify Paid To Date has decreased by value
            expPaidToDate.Should().Be(actualPaidToDate, "Paid to Date is updated by " + amount);
        }

        [Then(@"I See Balance Due Value Updates By '(.*)' On Row '(.*)'")]
        public void ThenISeeBalanceDueValueUpdatesBy(Decimal amount, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string actualBalance = newTransaction.TransactionLinks.GetClaimDetailBalanceDueByRowPosition(rowPosition);
            
            Decimal actualBalanceDue = this.GetDecimalForBalanceString(actualBalance);

            //get balance from scenario context
            string previousBalance = ScenarioContext.Current.Get<string>("Claim Link " + rowPosition + " Balance Due");
            Decimal previousBalanceDue = this.GetDecimalForBalanceString(previousBalance);
            Decimal expBalanceDue = previousBalanceDue - amount;
            
            //verify Balance Due has decreased by value
            expBalanceDue.Should().Be(actualBalanceDue, "Paid to Date is updated by " + amount);
        }

        private Decimal GetDecimalForBalanceString(string stringBalance)
        {
            stringBalance = stringBalance.Replace("$", "");
            if (stringBalance.Contains("("))
            {
                //negative value 
                stringBalance = "-" + stringBalance.Replace("(", "").Replace(")", "");
            }
            stringBalance = stringBalance.Replace(",", "");
            return Convert.ToDecimal(stringBalance.Replace(",", ""));
        }

        

        [Then(@"I Verify Claim Links For Check Were Correctly Saved on DB")]
        public void ThenIVerifyClaimLinksForCheckWereCorrectlySavedOnDB()
        {
            int checkId = ScenarioContext.Current.Get<int>("Saved Transaction Id");
            List<ClaimLinkData> claimsLinks = ScenarioContext.Current.Get<List<ClaimLinkData>>("Created Transaction Linked Claim Data");

            foreach (ClaimLinkData claimLink in claimsLinks)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("TransactionId", checkId + "");
                parameters.Add("ClaimId", claimLink.Id + "");

                DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetClaimLinkDataByTransactionIdAndClaimId, parameters);
                rows.Count.Should().Be(1, "Link for Claim " + claimLink.Id + " is saved on DB");

                foreach (DataRow row in rows)
                {
                    //Verify entered data for claim link     
                    string dbClaimNbr = row.Field<string>("ClaimNumber");
                    if (dbClaimNbr == null)
                        dbClaimNbr = "";
                    dbClaimNbr.Should().Be(claimLink.Number, "Claim " + claimLink.Id + " Link Claim # is correct");
                    row.Field<string>("Name").Should().Be(claimLink.Name, "Claim " + claimLink.Id + " Link Name is correct");
                    row.Field<string>("LinkCode").Should().Be(claimLink.Code, "Claim " + claimLink.Id + " Link Code is correct");
                    row.Field<string>("ClaimCode").Should().Be(claimLink.OriginalClaimCode, "Claim " + claimLink.Id + " ORIGINAL Code is correct");
                    row.Field<string>("Description").Should().Be(claimLink.Description, "Claim " + claimLink.Id + " Link Description is correct");
                    row.Field<bool>("IsNonCompensable").Should().Be(claimLink.NonCompensable, "Claim " + claimLink.Id + " Link Non Compensable is correct"); ;
                    string linkAmount = row.Field<string>("Amount");
                    linkAmount.Should().Be(claimLink.Amount, "Claim " + claimLink.Id + " Link Amount is correct"); ;
                    //Verify claim paid original vs new paid values
                    row.Field<Decimal>("PaidAmount").Should().Be(claimLink.PaidAmount - Convert.ToDecimal(linkAmount), "Paid Amount for the Claim is updated");
                    row.Field<int>("IsDeleted").Should().Be(0, "Claim " + claimLink.Id + " Link is Not Deleted");

                }
            }
        }




        [Given(@"I See Deposit Claim Link Section Layout Is Correct")]
        public void GivenISeeDepositClaimLinkSectionLayoutIsCorrect()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClosingCostsClaimLinksSectionTitle.Should().Be("CLOSING COSTS", "Closing Costs links section title is correct");
            newTransaction.TransactionLinks.AddClaimLinkText.Should().Be("ADD CLAIM", "Add Claim link text is correct");
            newTransaction.TransactionLinks.IsAddClaimLinkIconVisible().Should().BeTrue("Add Claim link icon is present");
        }

        [Then(@"I See SUM OF CLOSING COSTS Label is '(.*)'")]
        public void ThenISeeCumOfClosingCostsLabelIs(string expLabel)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SumOfClosingCostsLabel.Should().Be(expLabel, "Sum Of Closing Costs label is correct");
        }

        [Then(@"I See SUM OF CLOSING COSTS Is '(.*)'")]
        public void ThenISeeCumOfClosingCostsIs(string expSum) {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SumOfClosingCosts.Should().Be(expSum, "Sum Of Closing Costs value is correct");
        }

        [Given(@"I Click On ADD Non Claim Payee Link")]
        [When(@"I Click On ADD Non Claim Payee Link")]
        [Then(@"I Click On ADD Non Claim Payee Link")]
        public void WhenIClickOnADDNonClaimPayeeLink()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickAddNonClaimPayeeLink();

        }

        [Then(@"I See AdADD Non Claim Payee Link Text Reads '(.*)'")]
        public void ThenISeeAdADDNonClaimPayeeLinkTextReads(string linkText)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.AddNonClaimPayeeLinkText.Should().Be(linkText, "Non Claim Payee Link text is the expected");
        }


        [Then(@"I See Non Claim Payee Code Placeholder For Row '(.*)' Is '(.*)'")]
        public void ThenISeeNonClaimPayeeCodePlacehodlerForRowIs(int rowPosition, string expPlaceholder)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.GetNonClaimPayeeCodePlaceholder(rowPosition).Should().Be(expPlaceholder, "Placeholder for Non Claim Payee code is correct");
        }

        [Given(@"I Enter Non Claim Payee Name '(.*)' Code '(.*)' And Amount '(.*)' On Row '(.*)'")]
        [Then(@"I Enter Non Claim Payee Name '(.*)' Code '(.*)' And Amount '(.*)' On Row '(.*)'")]
        public void ThenIEnterNonClaimPayeeNameCodeAndAmountOnRow(string name, string code, string amount, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.EnterNonClaimPayeeNameByRow(name, rowPosition);
            newTransaction.TransactionLinks.EnterClaimLinkCodeOnRowPosition(code, rowPosition);
            newTransaction.TransactionLinks.EnterClaimLinkAmountOnRowPosition(amount, rowPosition);
            AddDataToScenarioContextOverridingExistentKey("Added Non Claim Payee Link/s", true);            
        }

        [Then(@"I See Non Claim Payee Link Row '(.*)' With Name '(.*)' Code '(.*)' Allocation Description '(.*)' Non-Compensable '(.*)' And Amount '(.*)'")]
        public void ThenISeeNonClaimPayeeLinkRowWithNameCodeAllocationDescriptionNon_CompensableAndAmount(int rowPosition, string name, string code, string allocDescr, bool nonCompensable, string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            //Verify is always empty
            newTransaction.TransactionLinks.GetClaimLinkNumberByRowPosition(rowPosition).Should().Be("", "Claim Link " + rowPosition + " - Claim # is correct");

            newTransaction.TransactionLinks.GetNonClaimPayeeNameByRowPosition(rowPosition).Should().Be(name, "Non Claim Payee Link " + rowPosition + " - Name is correct");
            newTransaction.TransactionLinks.GetClaimLinkCodeByRowPosition(rowPosition).Should().Be(code, "Non Claim Payee Link " + rowPosition + " - Code is correct");

            newTransaction.TransactionLinks.GetClaimLinkAllocationDescriptionByRowPosition(rowPosition).Should().Be(allocDescr, "Non Claim Payee Link " + rowPosition + " - Allocation Description value is correct");
            newTransaction.TransactionLinks.IsClaimLinkNonCompensableVisibleByRowPosition(rowPosition).Should().BeTrue("Non Claim Payee Link  " + rowPosition + " - Non-Compensable checkbox is visible");
            newTransaction.TransactionLinks.IsClaimLinkNonCompensableSelectedByRowPosition(rowPosition).Should().Be(nonCompensable, "Non Claim Payee Link  " + rowPosition + " - Non-Compensable value is correct");
            //ignore spaces on amount verification
            newTransaction.TransactionLinks.GetClaimLinkAmountByRowPosition(rowPosition).Replace(" ", "").Should().Be(amount.Replace(" ", ""), "Non Claim Payee Link " + rowPosition + " - Amount value is correct");
        }

        [Then(@"See Non Claim Payee Name Placeholder For Row '(.*)' Is '(.*)'")]
        public void ThenSeeNonClaimPayeeNamePlaceholderForRowIs(int rowPosition, string expPlaceholder)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.GetNonClaimPayeeNamePlaceholder(rowPosition).Should().Be(expPlaceholder, "Placeholder for Non Claim Payee name is correct");
        }

        [Given(@"I Enter Non Claim Payee Link Allocation Description '(.*)' On Row '(.*)'")]
        [Then(@"I Enter Non Claim Payee Link Allocation Description '(.*)' On Row '(.*)'")]
        public void ThenIEnterNonClaimPayeeLinkAllocationDescriptionOnRow(string description, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.EnterClaimLinkAllocationDescriptionOnRowPosition(description, rowPosition);
        }

        [Given(@"I Enter Non Claim Payee Link Non-Compensable '(.*)' On Row '(.*)'")]
        [Then(@"I Enter Non Claim Payee Link Non-Compensable '(.*)' On Row '(.*)'")]
        public void ThenIEnterNonClaimPayeeLinkNon_CompensableOnRow(bool nonComp, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.SetClaimLinkNonCompensableOnRowPosition(nonComp, rowPosition);
        }

        [Given(@"I Enter Net Deposit Amount '(.*)'")]
        public void GivenIEnterNetDepositAmount(string amount)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetAmount(amount);
        }

        [Given(@"I Enter Gross Deposit Amount '(.*)'")]
        [When(@"I Enter Gross Deposit Amount '(.*)'")]
        public void WhenIEnterGrossDepositAmountOnRow(string grossDeposit)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetGrossDeposit(grossDeposit);
        }

        [Then(@"I See an Alert Validation Message Reading '(.*)'")]
        public void ThenISeeAnAlertValidationMessageReading(string p0)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.GetBottomDepositValidationMessage().Should().Be(p0, "Validatoin message for Gross Deposit Less Closing Costs Does Not Equal Net Deposit is correct");
        }

        [When(@"I Click On Save Deposit For Save With Links")]
        public void WhenIClickOnSaveDepositForSaveWithLinks()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string transactionType = ScenarioContext.Current.Get<string>("New Transaction Type");

            //Save links data to verify DB later
            try
            {
                ScenarioContext.Current.Get<bool>("Added Claim Link/s");
                //TODO Save claims balances and linked amount prior to save - to verify later that balance has changed on DB or claims list
                ScenarioContext.Current.Add("Created Transaction Linked Claim Data", newTransaction.TransactionLinks.GetClaimsLinksData());
            } catch (Exception){ }
            try
            {
                ScenarioContext.Current.Get<bool>("Added Non Claim Payee Link/s");
                ScenarioContext.Current.Add("Created Deposit Linked Non Claim Payees", newTransaction.TransactionLinks.GetNonClaimPayeeLinksData());
            }
            catch (Exception) { }

            try
            {
                ScenarioContext.Current.Get<bool>("Added Asset Link/s");
                ScenarioContext.Current.Add("Created Deposit Linked Assets Data", newTransaction.TransactionLinks.GetAssetsLinksData());
            }
            catch (Exception)
            { }

            string serialNbr = "";

            if (transactionType == "Deposit" || transactionType == "Deposit Correcting Check")
            {
                serialNbr = newTransaction.SerialNumber;
                AddDataToScenarioContextOverridingExistentKey("Transaction Serial Number", serialNbr);
            }

            newTransaction.Save();
            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving");

            if (transactionType == "Deposit" || transactionType == "Deposit Correcting Check")
            {
                AddDataToScenarioContextOverridingExistentKey("Saved Transaction Id", bankingTab.GetTransactionIdFromListBySerialNumber(transactionType+" #" + serialNbr));
            }
            else
            {
                AddDataToScenarioContextOverridingExistentKey("Saved Transaction Id", bankingTab.GetTransactionIdFromListByName(GetExpectedSerialNumberTextForLedger(transactionType)));
            }


        }

        [Given(@"I Enter Deposit Received From Value '(.*)'")]
        public void GivenIEnterReceivedFromValue(string receivedFrom)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.SetName(receivedFrom);
        }

        [When(@"I See The Transaction Displays Data Correctly On Transactions List '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        [Then(@"I See The Transaction Displays Data Correctly On Transactions List '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        private void ThenISeeTheTransactionDisplaysAtTheTopOfTransactionsListWith(string receivedFrom, string code, string amount, string assetNbr1, string assetName1, string assetAmount1, string assetNbr2, string assetName2, string assetAmount2)
        {


            //Get serial number of the transaction to validate
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            string trxExpectedSerialText = CommonMethodsUnityStepBase.GetExpectedSerialNumberTextForLedger(trxType);


            //Verify Trx form closes
            bankingTab.NewTransactionFormHasDissapeared().Should().BeTrue("Transaction Form Closes after Saving or Cancelling");
            bankingTab.Pause(2);

            //Search transaction on the list
            BankTransactionData deposit;
            if ((trxType == "Check") || (trxType == "Deposit") || (trxType == "Deposit Correcting Check"))
                deposit = bankingTab.GetTransactionBySerialNumber(trxExpectedSerialText);
            else
                deposit = bankingTab.GetTransactionByName(receivedFrom);

            //Verify data for the check
            //Trx number and name
            deposit.TransactionNumber.Should().Be(trxExpectedSerialText, "Transaction Number is correct");
            deposit.Name.Should().Be(receivedFrom, "Name is Correct");


            //links data display
            if ((trxType == "Check"))
            {
                deposit.ClaimLinkLabel.Should().Be("CLAIM LINK", "Claim Link label is correct on Deposit display");
            }
            else
            {
                deposit.ClaimLinkLabel.Should().Be("ASSET LINK", "ASSET Link label is correct on Deposit display");
            }



            if (assetName1 != "") //if expecting any assets, then verify content
            {
                deposit.ClaimLinkNameLabel.Should().Be("NAME", "Asset/Claim Link name label is correct on Transaction display");

                if ((trxType == "Check"))
                {
                    deposit.ClaimLinkNumberLabel.Should().Be("CLAIM#", "Claim Link # label is correct on Deposit display");
                    deposit.ClaimLinkBalanceLabel.Should().Be("BALANCE", "Asset/Claim Link balance label is correct on Transaction display");
                    //TODO Verify Balance from DB
                }
                else
                {
                    deposit.ClaimLinkNumberLabel.Should().Be("ASSET#", "Claim Link # label is correct on Deposit display");
                    deposit.ClaimLinkBalanceLabel.Should().Be("AMOUNT", "Asset/Claim Link balance label is correct on Transaction display");
                    deposit.ClaimLinkBalance1.Should().Be(assetAmount1, "Asset/Claim Link 1 Amount/Balance is correct on Transaction display");
                    deposit.ClaimLinkBalance2.Should().Be(assetAmount2, "Asset/Claim Link 2 Amount/Balance is correct on Transaction display");
                }
                //shows 2 assets links max
                //link 1
                deposit.ClaimLinkNumber1.Should().Be(assetNbr1, "Asset/Claim Link 1 # is correct on Transaction display");
                deposit.ClaimLinkName1.Should().Be(assetName1, "Asset/Claim Link1  Name is correct on Transaction display");


                //link 2
                deposit.ClaimLinkNumber2.Should().Be(assetNbr2, "Asset/Claim Link 2 # is correct on Transaction display");
                deposit.ClaimLinkName2.Should().Be(assetName2, "Asset/Claim Link 2 Name is correct on Transaction display");                
            }

            //code and amount
            deposit.Code.Should().Be(code, "Code is Correct");
            deposit.AmountValue.Should().Be(amount, "Amount is Correct");
        }

        //ASSETS
        [Given(@"I Click On ADD Asset Link")]        
        public void WhenIClickOnADDAssetLink()
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickAddAssetLink();
        }

        [Given(@"I Search And Select Asset To Link On Row '(.*)' By Asset Number '(.*)' And Asset Name '(.*)' And Asset Code '(.*)'")]
        
        public void GivenISearchAndSelectAssetToLinkByAssetNumberAndAssetNameAndAssetCode(int rowPosition, string number, string name, string code)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.ClickAssetSearchBoxByRow(rowPosition);
            newTransaction.TransactionLinks.EnterTextOnAssetSearchBoxByRow(number, rowPosition);
            newTransaction.TransactionLinks.SelectAssetFromResultsUsingMethod(rowPosition, number, name, code, "Click");
            AddDataToScenarioContextOverridingExistentKey("Added Asset Link/s", true);

        }

        [Given(@"I Enter Asset Linked Amount '(.*)' On Row '(.*)'")]
        public void GivenIEnterAssetLinkedAmountOnRow(string amount, int rowPosition)
        {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            newTransaction.TransactionLinks.SetAssetLinkAmountByRowPosition(amount, rowPosition);
        }

        [Given(@"I Enter Asset Fully Administered Date '(.*)' On Row '(.*)'")]
        public void GivenIEnterAssetFullyAdministeredDateOnRow(string date, int rowPosition) {
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            if(date == "Today")
                newTransaction.TransactionLinks.SetAssetLinkFADateByRowPosition(DateTime.Now.ToString("MM/dd/yyyy"), rowPosition);
            else
                newTransaction.TransactionLinks.SetAssetLinkFADateByRowPosition(date, rowPosition);
        }

        [Then(@"I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '(.*)' Code '(.*)' And Amount '(.*)'")]
        public void ThenIVerifyDepositBasicDataWasCorrectlySavedOnDB(string expName, string expCode, string expAmount)
        {
            string trxType = ScenarioContext.Current.Get<string>("New Transaction Type");
            int trxId = ScenarioContext.Current.Get<int>("Saved Transaction Id");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("TransactionId", trxId+"");           

            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetTransactionDetails, parameters);
            string name = "";
            string amount = "";
            string code = "";

            foreach (DataRow row in rows)
            {
                name = row.Field<string>("Name");
                amount = row.Field<Decimal>("Amount")+"";
                code = row.Field<string>("UTCCode");
            }
            //NAME verification
            name.Should().Be(expName, "Transaction NAME is correct on DB");

            //AMOUNT verification
            expAmount = expAmount.Replace(" ", "").Replace(",", "").Replace("$", "");

            //TODO see wich ones save amount as negative on DB and add on this condition
            if (trxType == "Check")
            {
                amount.Substring(0, amount.Length - 2).Should().Be("-" + expAmount, trxType + " AMOUNT is correct on DB");
            }
            else
            {
                amount.Substring(0, amount.Length - 2).Should().Be(expAmount, trxType + " AMOUNT is correct on DB");
            }

            //CODE verification
            code.Should().Be(expCode, "Transaction CODE is correct on DB");

        }
        
        [Then(@"I Verify Claim Links For Deposit Were Correctly Saved on DB")]
        public void ThenIVerifyClaimLinksForDepositWereCorrectlySavedOnDB()
        {
            int depositId = ScenarioContext.Current.Get<int>("Saved Transaction Id");
            List<ClaimLinkData> claimsLinks = ScenarioContext.Current.Get<List<ClaimLinkData>>("Created Transaction Linked Claim Data");

            foreach(ClaimLinkData claimLink in claimsLinks)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("TransactionId", depositId + "");
                parameters.Add("ClaimId", claimLink.Id + "");               

                DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetClaimLinkDataByTransactionIdAndClaimId, parameters);
                rows.Count.Should().Be(1, "Link for Claim "+claimLink.Id+" is saved on DB");

                foreach (DataRow row in rows)
                {
                    //Verify entered data for claim link     
                    string expClaimNbr = row.Field<string>("ClaimNumber");
                    if (expClaimNbr == null)
                        expClaimNbr = "";
                    expClaimNbr.Should().Be(claimLink.Number, "Claim " + claimLink.Id + " Link Claim # is correct on DB");
                    row.Field<string>("Name").Should().Be(claimLink.Name, "Claim "+ claimLink.Id + " Link Name is correct on DB");
                    row.Field<string>("LinkCode").Should().Be(claimLink.Code, "Claim " + claimLink.Id + " Link Code is correct on DB");
                    row.Field<string>("ClaimCode").Should().Be(claimLink.OriginalClaimCode, "Claim " + claimLink.Id + " ORIGINAL Code is correct on DB");
                    row.Field<string>("Description").Should().Be(claimLink.Description, "Claim " + claimLink.Id + " Link Description is correct on DB");
                    row.Field<bool>("IsNonCompensable").Should().Be(claimLink.NonCompensable, "Claim " + claimLink.Id + " Link Non Compensable is correct on DB");
                    string linkDBAmount = Convert.ToString(row.Field<Decimal>("Amount"));
                    linkDBAmount = linkDBAmount.Substring(0,linkDBAmount.Length-2);
                    string enteredAmount = claimLink.Amount.Replace(" ", "").Replace(",", "").Replace("$", "");
                    linkDBAmount.Should().Be("-" + enteredAmount, "Claim " + claimLink.Id + " Link Amount is correct on DB");

                    //Verify claim paid original vs new paid values
                    row.Field<Decimal>("PaidAmount").Should().Be(claimLink.PaidAmount+Convert.ToDecimal(enteredAmount), "Paid Amount for the Claim is updated");
                    row.Field<bool>("IsDeleted").Should().Be(false, "Claim "+claimLink.Id+ " Link is Not Deleted on DB");                    
                }
            }
        }

        [Then(@"I Verify Non Claim Payee Link For Deposit Were Correctly Saved On DB")]
        public void ThenIVerifyNonClaimPayeeLinkForDepositIsCorrectlySavedOnDB()
        {
            int depositId = ScenarioContext.Current.Get<int>("Saved Transaction Id");
            List<NonClaimPayeeLinkData> nonClaimsLinkedData = ScenarioContext.Current.Get<List<NonClaimPayeeLinkData>>("Created Deposit Linked Non Claim Payees");

            foreach (NonClaimPayeeLinkData nonClaimLink in nonClaimsLinkedData)
            {                
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("TransactionId", depositId + "");
                parameters.Add("PayeeName", nonClaimLink.Name);
                DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetNonClaimPayeeLinkDataByTransactionIdAndPayeeName, parameters);
                rows.Count.Should().Be(1, "Link for Non Claim Payee " + nonClaimLink.Name+ " is saved on DB");

                foreach (DataRow row in rows)
                {
                    //Verify entered data for non claim payee link
                    row.Field<string>("Name").Should().Be(nonClaimLink.Name, "Non Claim Payee Link Name is correct on DB");
                    row.Field<string>("Code").Should().Be(nonClaimLink.Code, "Non Claim Payee Link Code is correct on DB");
                    row.Field<string>("Description").Should().Be(nonClaimLink.Description, "Non Claim Payee Link Description is correct on DB");
                    row.Field<bool>("IsNonCompensable").Should().Be(nonClaimLink.NonCompensable, "Non Claim Payee Link Non Compensable is correct on DB"); ;

                    string linkDBAmount = Convert.ToString(row.Field<Decimal>("Amount"));
                    linkDBAmount = linkDBAmount.Substring(0, linkDBAmount.Length - 2);
                    string enteredAmount = nonClaimLink.Amount.Replace(" ", "").Replace(",", "").Replace("$", "");
                    linkDBAmount.Should().Be("-" + enteredAmount, "Non Claim Payee Link Amount is correct on DB");
                    
                    row.Field<bool>("IsDeleted").Should().Be(false, "Non Claim Payee Link is Not Deleted on DB");
                }
            }

        }

        [Then(@"I Verify Assets Links For Deposit Were Correctly Saved On DB")]
        public void ThenIVerifyAssetsLinkForDepositIsCorrectlySavedOnDB()
        {

            int depositId = ScenarioContext.Current.Get<int>("Saved Transaction Id");
            List<AssetLinkData> assetsLinkedData = ScenarioContext.Current.Get<List<AssetLinkData>>("Created Deposit Linked Assets Data");

            foreach (AssetLinkData assetLink in assetsLinkedData)
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("TransactionId", depositId + "");
                parameters.Add("AssetId", assetLink.Id + "");

                DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.getAssetLinksDataForTransactionsLedger, parameters);
                rows.Count.Should().Be(1, "Link for Asset " + assetLink.Id + " is saved on DB");

                foreach (DataRow row in rows)
                {
                    assetLink.Number.Should().Be("" + row.Field<Int32>("AssetNumber"));
                    assetLink.Description.Should().Be(row.Field<string>("Description").Replace("                     ", ""));
                    assetLink.Code.Should().Be(row.Field<string>("CodeNumber"));
                    assetLink.FullAdministeredDate.Should().Be(row.Field<DateTime>("FullAdministratedDate").ToString("MM/dd/yyyy"));
                    string dbAmountFormatted = ("$" + row.Field<Decimal>("Amount"));
                    dbAmountFormatted = dbAmountFormatted.Substring(0, dbAmountFormatted.Length - 2);
                    assetLink.Amount.Replace(" ", "").Replace(",", "").Should().Be(dbAmountFormatted);
                }
            }
        }

        [When(@"I Click On Save Check For UTC Split And Claim Links")]
        public void WhenIClickOnSaveCheckForUTCSplitAndClaimLinks()
        {
            //Save transaction serial nbr
            TransactionForm newTransaction = ScenarioContext.Current.Get<TransactionForm>("New Transaction Form");
            string serialNbr = newTransaction.SerialNumber;
            AddDataToScenarioContextOverridingExistentKey("Transaction Serial Number",serialNbr);

            //Save links data to verify DB later
            try
            {
                ScenarioContext.Current.Get<bool>("Added Claim Link/s");
                //TODO Save claims balances prior to save - to verify later that balance has changed on DB or claims list
                ScenarioContext.Current.Add("Created Transaction Linked Claim Data", newTransaction.TransactionLinks.GetClaimsLinksData());
            }
            catch (Exception) {
                //if "Added Claim Link/s" is not in the scenario context, then no claim links were added to transaction
            }

            //Save utc splits data on scenario context
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
        }

    }
}

