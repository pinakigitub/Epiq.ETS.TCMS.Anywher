using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Claims
{
    [Binding]
    public sealed class CaseClaimsNewSteps:StepBase
    {
        //REFACTORED
        private ClaimsDetailTab claimsTab = ((ClaimsDetailTab)GetSharedPageObjectFromContext("Claims Tab"));

        [Given(@"I See New Claim Button Displays on Summary Card")]
        public void GivenISeeNewClaimButtonDisplaysOnSummaryCard()
        {
            claimsTab.IsNewClaimButtonOnSummaryCard.Should().BeTrue("New Claim Button Displays on Summary Card"); 
        }


        [When(@"I Click On New Claim Button")]
        [Given(@"I Click On New Claim Button")]
        public void GivenIClickOnNewClaimButton()
        {
            ClaimForm claimForm = claimsTab.ClickNewClaim();

            //replace for if clicking on New Claim button again
            try
            {
                ScenarioContext.Current.Get<ClaimForm>("New Claim Form");
                ScenarioContext.Current.Remove("New Claim Form");
                ScenarioContext.Current.Get<string>("Claim Action");
                ScenarioContext.Current.Remove("Claim Action");
            }
            catch (Exception)
            {
                //do nothing   
            }
            ScenarioContext.Current.Add("Claim Action", "New");
            ScenarioContext.Current.Add("New Claim Form", claimForm);
        }

        [Given(@"I See Save Button is inactive")]
        public void GivenISeeSaveButtonIsInactive()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SaveButtonIsInactive.Should().BeTrue("Save button is inactive on Claim form");
        }



        [Then(@"I See New Claim Form Displays With Correct Layout")]
        public void ThenISeeNewClaimFormDisplaysWithCorrectLayout() {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();

            claimForm.ClaimFormTitle.Should().Be("New Claim","New Claim Form title is correct");
            //Claim #
            claimForm.ClaimNumberCornerTagColor.Should().Be("GREEN", "Claim Number label is correct");
            claimForm.ClaimNumberLabel.Should().Be("CLAIM #", "Claim Number label is correct");
            claimForm.ClaimNumber.Should().Be("", "Claim Number default value is correct");

            //Name
            claimForm.ClaimNameLabel.Should().Be("CLAIM NAME", "Claim Name label is correct");
            claimForm.ClaimNamePlaceholder.Should().Be("Add a name...", "Claim Name placeholder is correct");
            claimForm.ClaimName.Should().Be("Add a name...", "Claim Name default value is: empty");


            //Status
            //US110864 Default status valid to pay and corner tag green
            claimForm.ClaimStatusLabel.Should().Be("STATUS", "Status label is correct");
            claimForm.ClaimStatus.Should().Be("Valid To Pay", "Status default value is correct");

            List<string> expectedStatusList = new List<string>();
            expectedStatusList.Add("Dismissed");
            expectedStatusList.Add("Invalid");
            expectedStatusList.Add("Objection Pending");
            expectedStatusList.Add("Superseded");
            expectedStatusList.Add("Valid To Pay");
            expectedStatusList.Add("Withdrawn");
            claimForm.ClaimStatusList.Should().BeEquivalentTo(expectedStatusList, "Status Dropdown List is correct");

            //Objection Code 
            claimForm.ObjectionCodeLabel.Should().Be("OBJECTION CODE", "Objection Code label is correct");
            claimForm.ObjectionCode.Should().Be("","Objection Code default value is correct");

            //Inactive if status not objection pending - check codes list otherwise
            claimForm.ObjectionCodeActive.Should().BeFalse("", "Objection Code is inactive if status is Valid To Pay");

            claimForm.ClaimStatus = "Objection Pending";
            List<string> expectedObjectionCodesList = new List<string>();
            expectedObjectionCodesList.Add("");
            expectedObjectionCodesList.Add("Allow as Tardy");
            expectedObjectionCodesList.Add("Amount Claimed Incorrect");
            expectedObjectionCodesList.Add("Duplicate");
            expectedObjectionCodesList.Add("Not Debtor's Obligation");
            expectedObjectionCodesList.Add("Previously Paid");
            expectedObjectionCodesList.Add("Priority - Wrong Class \\ Allow as Unsecured");
            expectedObjectionCodesList.Add("Secured");
            expectedObjectionCodesList.Add("Undocumented Deficiency");
            expectedObjectionCodesList.Add("Unsubstantiated");
            claimForm.ObjectionCodeList.Should().BeEquivalentTo(expectedObjectionCodesList, "Objection Codes Dropdown List is correct");

            //Category
            //# US110866 Category is empty by default - check categories list items and sorting
            claimForm.CategoryLabel.Should().Be("CATEGORY", "Objection Code label is correct");
            claimForm.Category.Should().Be("", "Category default value is correct");
            List<string> expectedCategoryList = new List<string>();
            expectedCategoryList.Add("");
            expectedCategoryList.Add("Administrative Expense");
            expectedCategoryList.Add("Convenience Claim");
            expectedCategoryList.Add("Creditor");
            expectedCategoryList.Add("Investor");
            expectedCategoryList.Add("Professional Fee\\Expense");
            expectedCategoryList.Add("Secured Class One");
            expectedCategoryList.Add("Secured Class Two");
            expectedCategoryList.Add("Unsecured Class One");
            expectedCategoryList.Add("Security Interest");
            expectedCategoryList.Add("Unsecured Class Two");
            expectedCategoryList.Add("Wage Claim");
            claimForm.CategoryList.Should().BeEquivalentTo(expectedCategoryList, "Category Dropdown List is correct");

            //Codes and values header and horizontal line
            claimForm.CodesAndValuesTitle.Should().Be("Codes and Values", "Codes and values subtitle is correct");
            claimForm.CodesAndValuesHorizontalLinePresent.Should().BeTrue("Codes and values subtitle has an horizontal line bellow");

            //Code
            //Code component empty by default 
            claimForm.CodeLabel.Should().Be("CODE", "Status label is correct");
            claimForm.CodePlaceholder.Should().Be("Search...", "Code placeholder is correct");
            claimForm.Code.Should().Be("Search...", "Code default value is correct");

            //Class 
            //#+ Class default text is -- 
            claimForm.ClassLabel.Should().Be("CLASS", "Class label is correct");
            claimForm.Class.Should().Be("--", "Class default value is correct and matches selected Code");

            //Subcode
            //+ subcode component present and empty by default
            claimForm.SubcodeLabel.Should().Be("SUB CODE", "Status label is correct");
            claimForm.SubcodePlaceholder.Should().Be("Search...", "Subcode placeholder is correct");
            claimForm.Subcode.Should().Be("Search...", "Subcode default value is correct");

            //Pay Sequence
            claimForm.PaySequenceLabel.Should().Be("PAY SEQUENCE", "Pay Sequence label is correct");
            claimForm.PaySequence.Should().Be("", "Pay Sequence default value is correct");

            //Scheduled amount
            claimForm.ScheduledAmountLabel.Should().Be("SCHEDULED AMOUNT", "Scheduled Amount label is correct");
            claimForm.ScheduledAmount.Should().Be("", "Scheduled Amount default value is correct");

            //Claimed amount
            claimForm.ClaimedAmountLabel.Should().Be("CLAIMED AMOUNT", "Claimed Amount label is correct");
            claimForm.ClaimedAmount.Should().Be("", "Claimed Amount default value is correct");

            //Allowed amount
            //# US110873 Allowed amount present and currency format
            claimForm.AllowedAmountLabel.Should().Be("ALLOWED AMOUNT", "Allowed Amount label is correct");
            claimForm.AllowedAmount.Should().Be("", "Allowed Amount default value is correct");

            //Reserved amount
            //# US110873 Reserved amount present and currency format
            claimForm.ReservedAmountLabel.Should().Be("RESERVED AMOUNT", "Scheduled Amount label is correct");
            claimForm.ReservedAmount.Should().Be("", "Reserved Amount default value is correct");

            //Interest
            claimForm.InterestLabel.Should().Be("INTEREST", "Scheduled Amount label is correct");
            claimForm.Interest.Should().Be("$0.00", "Interest default value is correct");

            //Paid
            claimForm.PaidLabel.Should().Be("PAID", "Scheduled Amount label is correct");
            claimForm.Paid.Should().Be("$0.00", "Paid default value is correct");

            //Balance
            claimForm.BalanceLabel.Should().Be("BALANCE", "Scheduled Amount label is correct");
            claimForm.Balance.Should().Be("$0.00", "Balance default value is correct");
            claimForm.BalanceColor.Should().Be("GREEN", "Balance default value COLOR is correct");

            //More Options Bar functional
            claimForm.MoreOptionsLinkText.Should().Be("More Options", "More Options link text is correct");
            claimForm.MoreOptionsLinkArrowPointsDown.Should().BeTrue("More options link displays a pointing down arrow");
            claimForm.ClickMoreOptionsLink();
            claimForm.MoreOptionsVisible.Should().BeTrue("Clicking on More options link opens more option section");
            claimForm.LessOptionsLinkText.Should().Be("Less Options", "More Options link text becomes 'Less Options' when open");
            claimForm.LessOptionsLinkArrowPointsUp.Should().BeTrue("Less options link displays a pointing up arrow");
            claimForm.ClickLessOptionsLink();
            claimForm.MoreOptionsLinkText.Should().Be("More Options", "More Options link text is correct");
            claimForm.MoreOptionsLinkArrowPointsDown.Should().BeTrue("More options link displays a pointing down arrow");
            claimForm.MoreOptionsVisible.Should().BeFalse("Clicking on Less options link closes more option section");
        }


        [When(@"I Select Each Status The Corner Tag Color Updates")]
        public void WhenISelectEachStatusTheCornerTagColorUpdates(Table table)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            TableRows rows = table.Rows;
            foreach (TableRow row in rows)
            {
                string selectStatus = row["Status"];
                string expCornerTagColor = row["Color"];
                claimForm.ClaimStatus = selectStatus;
                claimForm.ClaimNumberCornerTagColor.Should().Be(expCornerTagColor, "For Status "+selectStatus+ " Corner tag displays color "+expCornerTagColor);
            }
        }
        [Given(@"I Click On Save Button")]
        [When(@"I Click On Save Button")]
        [Then(@"I Click On Save Button")]
        public void WhenIClickOnSaveButton()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickSaveButton();
        }


        [Then(@"I See Validation Messages On (.*)")]
        public void ThenISeeValidationMessagesOnMandatoryFields(List<string> mandatoryFields)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();

            //Name
            string nameValidation = claimForm.ValidationMessageOnName;
            if (mandatoryFields.Contains("Name"))
                nameValidation.Should().Be("CLAIM NAME is required.", "Validation message appears on Name field");
            else
                nameValidation.Should().Be("", "No validation required on Name field");

            //Code
            string codeValidation = claimForm.ValidationMessageOnCode;
            if (mandatoryFields.Contains("Code"))
                codeValidation.Should().Be("CODE is Required.", "Validation message appears on CODE field");
            else
                codeValidation.Should().Be("", "No validation required on CODE field");

            //Pay Sequence
            string paySeqValidation = claimForm.ValidationMessageOnPaySequence;
            if (mandatoryFields.Contains("Pay Sequence"))
                paySeqValidation.Should().Be("PAY SEQUENCE is Required.", "Validation message appears on CODE field");
            else
                paySeqValidation.Should().Be("", "No validation required on Pay Sequence field");
        }

        [Given(@"I Enter Valid Data For (.*) And I See Validation Messages Dissapear One At A Time")]
        [When(@"I Enter Valid Data For (.*) And I See Validation Messages Dissapear One At A Time")]
        [Then(@"I Enter Valid Data For (.*) And I See Validation Messages Dissapear One At A Time")]
        public void ThenIEnterValidDataForNameCodePaySequence(List<string> mandatoryFields)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();

            string claimNbr = this.GetRandomClaimNumber();
            claimForm.ClaimNumber = claimNbr;
            ScenarioContext.Current.Add("New Claim Number", claimNbr);

            //Name
            if (mandatoryFields.Contains("Name"))
            {
                claimForm.ClaimName = "Automated Test For Mandatory Fields Validation";
                claimForm.ValidationMessageOnNameDissapeared.Should().BeTrue("Validation message disappears on Name completion");
            }

            //Code
            if (mandatoryFields.Contains("Code"))
            {
                claimForm.Code = "5200";
                claimForm.ValidationMessageOnCodeDissapeared.Should().BeTrue("Validation message disappears on CODE completion");
            }

            //Pay Sequence
            if (mandatoryFields.Contains("Pay Sequence"))
            {                
                claimForm.PaySequence = "220";
                claimForm.ValidationMessageOnPaySequenceDissapeared.Should().BeTrue("Validation message appears on CODE field");
            }

            claimForm.SaveButtonIsInactive.Should().BeFalse("Save button becomes active after completing mandatory fields");
        }        

        [Then(@"I See Claim Displays On The List")]
        public void ThenISeeClaimDisplaysOnTheList()
        {
            string claimNbr = ScenarioContext.Current.Get<string>("New Claim Number");
            claimsTab.IsClaimPresentByClaimNumber(claimNbr).Should().BeTrue("New Claim with Claim # "+claimNbr+" displays on the List");
        }

        private string GetRandomClaimNumber()
        {
            Random rnd = new Random();
            int randomID = rnd.Next(1, 987654);
            return randomID + "QAutom";
        }

        [Given(@"I Type '(.*)' on Name Search Field")]
        [When(@"I Type '(.*)' on Name Search Field")]
        public void WhenIEnterOnNameField(string name)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.TypeClaimName(name);
            try
            {
                ScenarioContext.Current.Get<string>("New Claim Name Search Input");
                ScenarioContext.Current.Remove("New Claim Name Search Input");
            }
            catch (Exception)
            {
                //do nothing
            }

            ScenarioContext.Current.Add("New Claim Name Search Input", name);

        }

        [Then(@"I See Claim Name Results Match Predictive Search")]
        public void ThenISeeResultsMatchPredictiveSearch()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Name Search Input");

            List<string> results = claimForm.ClaimNameSearchResults;
            results.First().Should().Be(searchInput+" | Add New Claimant", "Name Search first result is to add new claimant");
            foreach (string name in results)
            {
                name.Should().ContainEquivalentOf(searchInput,"Name Search results include the given input string: "+ searchInput);
            }
        }

        [Given(@"I Select Add Claimant Result")]
        public void GivenISelectAddClaimantResult()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SelectResultContainingClaimName("Add New Claimant");
        }

        [Then(@"I See The Exact Result '(.*)' As An Existent Name")]
        public void ThenISeeTheExactResultAsAnExistentName(string name)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Name Search Input");
            List<string> results = claimForm.GetClaimNameResultsByContent(name);

            for (int i=1; i < results.Count; i++) //Discard first element, it is "Add Claimant"
            {
                results[i].Should().BeEquivalentTo(name, "Added claimant appears as an existent claimant on search results");
            }
        }

        [Given(@"I Enter These Values On Basic Claim Form")]
        public void GivenIEnterTheseValuesOnBasicClaimForm(Table table)
        {
            TableRow claimData = table.Rows[0];

            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimNumber = claimData["Number"];
            claimForm.ClaimName = claimData["Name"];
            claimForm.ClaimStatus = claimData["Status"];
            claimForm.Category = claimData["Category"];
            if (claimData["Code"] != "")
                claimForm.Code = claimData["Code"];
            if(claimData["Sub Code"] != "")
                claimForm.Subcode = claimData["Sub Code"];
            claimForm.PaySequence = claimData["Pay Sequence"];
            claimForm.ScheduledAmount = claimData["Scheduled"];
            claimForm.ClaimedAmount = claimData["Claimed"];
            claimForm.AllowedAmount = claimData["Allowed"];
            claimForm.ReservedAmount = claimData["Reserved"];

            ScenarioContext.Current.Add("New Claim Number", claimData["Number"]);
            ScenarioContext.Current.Add("Claim Data Basic Form", claimData);
        }

        [Then(@"I See Claim Form Has Been Closed")]
        public void ThenISeeNewClaimFormHasBeenClosed()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimsTab.HasNewClaimFormDissapeared.Should().BeTrue("New Claim Form dissapears after saving or cancelling");
        }

        private ClaimForm GetCurrentOpenClaimForm()
        {
            string action = ScenarioContext.Current.Get<string>("Claim Action");
            if (action == "New")
                return ScenarioContext.Current.Get<ClaimForm>("New Claim Form");
            else 
                if (action == "Edit")
                    return ScenarioContext.Current.Get<ClaimForm>("Edit Claim Form");
                else
                    throw new NotImplementedException();
        }

        [Given(@"I Enter A Valid Claim Number")]
        public void GivenIEnterAValidClaimNumber()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string claimNbr = this.GetRandomClaimNumber();
            claimForm.ClaimNumber = claimNbr;
            ScenarioContext.Current.Add("New Claim Number", claimNbr);
        }

        [Given(@"I Enter A Valid Name Value For Test '(.*)'")]
        public void GivenIEnterAValidNameValue(string test)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimName = "Automated Test For "+test;
        }



        [When(@"I Click On Save And Add Another Button")]
        public void WhenIClickOnSaveAndAddAnotherButton()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickSaveAndAddAnotherButton();
        }

        [Given(@"I Click On Cancel Button")]
        [When(@"I Click On Cancel Button")]
        [Then(@"I Click On Cancel Button")]
        public void WhenIClickOnCancelButton()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickCancelButton();
        }

        [Then(@"I See Claim Does Not Display On The List")]
        public void ThenISeeClaimDoesNotDisplayOnTheList()
        {
            string claimNbr = ScenarioContext.Current.Get<string>("New Claim Number");
            claimsTab.IsClaimPresentByClaimNumber(claimNbr).Should().BeFalse("New Claim with Claim # " + claimNbr + " was not created on Cancel");
        }

        [Given(@"I See Calculated Values Update to '(.*)' '(.*)' '(.*)' And '(.*)'")]
        [Then(@"I See Calculated Values Update to '(.*)' '(.*)' '(.*)' And '(.*)'")]
        public void GivenISeeValuesUpdateToClassPaid(string claimClass, string interest, string paid, string balance)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.Pause(2);
            claimForm.Class.Should().Be(claimClass, "Class is updated to "+claimClass);
            claimForm.Interest.Should().Be(interest, "Interest is updated to " + interest);
            claimForm.Paid.Should().Be(paid, "Interest is pdated to " + paid);
            claimForm.Balance.Should().Be(balance, "Interest is uupdated to " + balance);
        }

        [Given(@"I Type '(.*)' on Code Field")]
        [When(@"I Type '(.*)' on Code Field")]
        [Then(@"I Type '(.*)' on Code Field")]
        public void WhenITypeOnCodeField(string code)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.TypeCode(code);
            try
            {
                ScenarioContext.Current.Get<string>("New Claim Code Search Input");
                ScenarioContext.Current.Remove("New Claim Code Search Input");
            }
            catch (Exception)
            {
                //do nothing
            }

            ScenarioContext.Current.Add("New Claim Code Search Input", code);
        }        

        [Then(@"I See Code Results Match Predictive Search And Display Correctly")]
        public void ThenISeeCodeResultsMatchPredictiveSearchAndDisplayCorrectly()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Code Search Input");

            List<string> results = claimForm.CodeSearchResults;
            //results.First().Should().Be(" ", "Name Search first result is to add new claimant");
            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i];
                name.Should().ContainEquivalentOf(searchInput, "Code Search results include the given input string: " + searchInput);
                name.Should().MatchRegex("([0-9]{4}) \\/ (.*)");
            }
        }

        [Then(@"I See Subcode Input Is Inactive")]
        public void ThenISeeSubcodeInputIsInactive()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SobcodeInputIsActive().Should().BeFalse("Subcode Input is Inactive");
        }

        [Then(@"I See Code Results Display Sorted Descending")]
        public void ThenISeeCodeResultsDisplaySortedDescending()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Code Search Input");

            List<string> results = claimForm.CodeSearchResults;
            results.Should().BeInAscendingOrder();
        }

        [Given(@"I Select The First Result On Code Dropdown")]
        [When(@"I Select The First Result On Code Dropdown")]
        public void WhenISelectTheFirstResultOnCodeDropdown()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Code Search Input");
            claimForm.SelectResultContainingCode(searchInput);
        }

        [Then(@"I See Code Input Displays Selected Code And Description '(.*)'")]
        public void ThenISeeCodeInputDisplaysSelectedCodeAndDescription(string expected)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.Code.Should().Be(expected, "Code has been selected and displays as expected ");
        }

        [Then(@"I See Subcode Input Displays Selected Subcode And Description '(.*)'")]
        public void ThenISeeSubcodeInputDisplaysSelectedSubcodeAndDescription(string expected)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.Subcode.Should().Be(expected, "Subcode has been selected and displays as expected ");
        }

        [Then(@"I See Class Autocompletes To '(.*)'")]
        public void ThenISeeClassAutocompletesToAdministrative(string expClaimClass)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.Class.Should().Be(expClaimClass, "Claim Class updates when changing Code");
        }

        [Given(@"I Type '(.*)' on Subcode Field")]
        [When(@"I Type '(.*)' on Subcode Field")]
        [Then(@"I Type '(.*)' on Subcode Field")]
        public void WhenITypeOnSubcodeField(string subcode)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.TypeSubcode(subcode);
            try
            {
                ScenarioContext.Current.Get<string>("New Claim Subcode Search Input");
                ScenarioContext.Current.Remove("New Claim Subcode Search Input");
            }
            catch (Exception)
            {
                //do nothing
            }

            ScenarioContext.Current.Add("New Claim Subcode Search Input", subcode);
        }

        [Given(@"I See Subcode Results Match Predictive Search And Display Correctly")]
        [Then(@"I See Subcode Results Match Predictive Search And Display Correctly")]
        public void ThenISeeSubcodeResultsMatchPredictiveSearchAndDisplayCorrectly()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Subcode Search Input");

            List<string> results = claimForm.SubcodeSearchResults;
            //results.First().Should().Be(" ", "Subcode Search first result is to add new claimant");
            for (int i = 0; i < results.Count; i++)
            {
                string name = results[i];
                name.Should().ContainEquivalentOf(searchInput, "Subcode Search results include the given input string: " + searchInput);
                name.Should().MatchRegex("([0-9]{2}) \\/ (.*)");
                
            }
        }

        [Then(@"I See Subcode Results Display Sorted Descending")]
        public void ThenISeeSubcodeResultsDisplaySortedDescending()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Code Search Input");

            List<string> results = claimForm.SubcodeSearchResults;
            results.Should().BeInAscendingOrder();
            claimForm.PressEscapeKey();
        }

        [When(@"I Select The First Result On Subcode Dropdown")]
        public void WhenISelectTheFirstResultOnSubcodeDropdown()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string searchInput = ScenarioContext.Current.Get<string>("New Claim Subcode Search Input");
            claimForm.SelectResultContainingSubcode(searchInput);
        }

        [When(@"I Enter '(.*)' on Claimed Amount Field")]
        public void WhenIEnterOnClaimedAmountField(string claimed)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimedAmount = claimed;
        }

        [Given(@"I See Allowed Amount Field Value Is '(.*)'")]
        [Then(@"I See Allowed Amount Field Value Is '(.*)'")]
        public void ThenISeeAllowedAmountFieldValueIs(string allowed)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.AllowedAmount.Should().Be(allowed, "Allowed Amount has the expected value");
        }

        [Given(@"I See Balance Value Is '(.*)'")]
        [Then(@"I See Balance Value Is '(.*)'")]
        public void ThenISeeBalanceValueIs(string balance)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.Balance.Should().Be(balance, "Balance value is the expected one");
        }

        [When(@"I Enter '(.*)' on Pay Sequence Field")]
        public void WhenIEnterOnPaySequenceField(string paySeq)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.PaySequence = paySeq;
        }

        [Then(@"I See Pay Sequence Value is '(.*)'")]
        public void ThenISeePaySequenceValueIs(string paySeq)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.PaySequence.Should().Be(paySeq, "Pay Sequence value is the expected one");
        }

        /// More Options Section        
        [Given(@"I Click On More Options")]        
        [When(@"I Click On More Options")]
        [Then(@"I Click On More Options")]
        public void WhenIClickOnMoreOptions()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickMoreOptionsLink();
        }

        [Then(@"I See Creditor Payment Options Layout Is Correct")]
        public void ThenISeeCreditorPaymentOptionsLayoutIsCorrect()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.LessOptionsLinkText.Should().Be("Less Options", "Less Options link is visible on More options Layout");

            //Payment Options
            claimForm.PaymentOptionsTitle.Should().Be("Payment Options and Additional Creditor Info", "Payment Option title is correct");

            //Creditor Acc Nbr
            claimForm.CreditorAccountNumberLabel.Should().Be("CREDITOR ACCOUNT NUMBER", "Creditor Account number label is correct");
            claimForm.CreditorAccountNumber.Should().Be("", "Creditor Account number default value is correct");

            //Check description
            claimForm.CheckDescriptionLabel.Should().Be("CHECK DESCRIPTION", "Check Description label is correct");
            claimForm.CheckDescription.Should().Be("", "Check Description default value is correct");

            //Claim options
            claimForm.ClaimOptionsLabel.Should().Be("CLAIM OPTIONS", "Claim Options Label is correct");

            claimForm.WageDeductionLabel.Should().Be("Wage Deduction", "Wage Deduction Label is correct");
            claimForm.WageDeductionSelect.Should().BeFalse("Wage Deduction default selection value is correct");

            claimForm.NonCompensableLabel.Should().Be("Non-Compensable", "Non-Compensable Label is correct");
            claimForm.NonCompensableSelect.Should().BeFalse("Non Compensable default selection value is correct");

            claimForm.ExcludeFromUFRLabel.Should().Be("Exclude from UFR", "Exclude From UFR Label is correct");
            claimForm.ExcludeFromUFRSelect.Should().BeFalse("Exclude From UFR default selection value is correct");

            claimForm.NonDischargedLabel.Should().Be("Non-discharged", "Non-Discharged Label is correct");
            claimForm.NonDischargedSelect.Should().BeFalse("Non-discharged default selection value is correct");

            claimForm.ReaffirmedLabel.Should().Be("Reaffirmed", "Reaffirmed Label is correct");
            claimForm.ReaffirmedSelect.Should().BeFalse("Reaffirmed default selection value is correct");

            //Dates
            claimForm.DateFiledLabel.Should().Be("DATE FILED", "Date Filed label is correct");
            claimForm.DateFiledPlaceholder.Should().Be("MM/DD/YYYY", "Date Filed format placeholder is correct");
            claimForm.DateFiled.Should().Be("", "Date Filed default value is correct");

            claimForm.BarDateLabel.Should().Be("BAR DATE", "Bar Date label is correct");
            claimForm.BarDatePlaceholder.Should().Be("", "Bar Date format placeholder is correct");
            claimForm.BarDate.Should().Be("12/27/2010", "Bar Date default value is correct");

            //Amend
            claimForm.AmendsLabel.Should().Be("AMENDS", "Amends label is correct");
            claimForm.Amends.Should().Be("", "Amends default value is correct");

            claimForm.AmendsVersionLabel.Should().Be("VERSION", "Amends Version  Label is correct");
            claimForm.AmendsVersion.Should().Be("", "Amends Version default value is correct");

            claimForm.AmendedByLabel.Should().Be("AMENDED BY", "Amended By Label is correct");
            claimForm.AmendedBy.Should().Be("", "Amended By default value is correct");

            claimForm.AmendedByVersionLabel.Should().Be("VERSION", "Amended By Version Label is correct");
            claimForm.AmendedByVersion.Should().Be("", "Amended By Version default value is correct");

            //Notes
            claimForm.NotesTitle.Should().Be("Notes", "Notes title is correct");

            claimForm.ClaimsRegisterNoteLabel.Should().Be("CLAIMS REGISTER NOTE", "Claims Register Note label is correct");
            claimForm.ClaimsRegisterNote.Should().Be("", "Claims Register Note default value is correct");

            claimForm.InternalClaimNoteLabel.Should().Be("INTERNAL CLAIM NOTE", "Internal Claim Note label is correct");
            claimForm.InternalClaimNote.Should().Be("", "Internal Claim Note default value is correct");

        }

        [Then(@"I See Bar Date Value Is '(.*)'")]
        public void ThenISeeBarDateValueIs(string expDate)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.BarDate.Should().Be(expDate);
        }

        [Then(@"I Can Enter A Max Of Fifty Characters on Creditor Account Number Field")]
        public void ThenICanEnterAMaxOfCharactersOnCreditorAccountNumberField()
        {
            // Max = 50 chars
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string lessThan = "Lorem ipsum dolor sit amet, consectetuer";
            string fifty = "Lorem ipsum dolor sit amet, consectetuer adipiscin";
            string moreThan = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Ae";
            string muchMore = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis p";

            claimForm.CreditorAccountNumber = lessThan + "";
            claimForm.CreditorAccountNumber.Should().Be(lessThan, "User can enter less than 50 characters on Creditor Account Number");
            claimForm.CreditorAccountNumber = fifty + "";
            claimForm.CreditorAccountNumber.Should().Be(fifty, "User can enter exactly 50 characters on Creditor Account Number");
            claimForm.CreditorAccountNumber = moreThan + "";
            claimForm.CreditorAccountNumber.Should().Be(fifty, "User cannot enter more than 50 characters on Creditor Account Number");
            claimForm.CreditorAccountNumber = muchMore + "";
            claimForm.CreditorAccountNumber.Should().Be(fifty, "User cannot enter more than 50 characters on Creditor Account Number");
        }

        [Then(@"I Can Enter A Max Of Characters on Check Description Field")]
        public void ThenICanEnterAMaxOfCharactersOnCheckDescriptionField()
        {
            // Max = 512
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string lessThan = "Lorem ipsum dolor sit amet, consectetuer adipiscin";
            string exactly = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus e";
            string moreThan = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper ni";
            string muchMore = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus";

            claimForm.CheckDescription = lessThan + "";
            claimForm.CheckDescription.Should().Be(lessThan, "User can enter less than 512 characters on Check Description");
            claimForm.CheckDescription = exactly + "";
            claimForm.CheckDescription.Should().Be(exactly, "User can enter exactly 512 characters on Check Description");
            claimForm.CheckDescription = moreThan + "";
            claimForm.CheckDescription.Should().Be(exactly, "User cannot enter more than 512 characters on Check Description");
            claimForm.CheckDescription = muchMore + "";
            claimForm.CheckDescription.Should().Be(exactly, "User cannot enter more than 512 characters on Check Description");
        }

        [Then(@"I Can Enter A Max Of Three Alphanumeric Chars on Amended By")]
        public void ThenICanEnterAMaxOfAlphanumericCharsOnAmendedBy()
        {
            // Max = 3
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string lessThan = "A2";
            string exactly = "A23";
            string moreThan = "A234";
            string muchMore = "A234567890";

            claimForm.AmendedBy = lessThan + "";
            claimForm.AmendedBy.Should().Be(lessThan, "User can enter less than 3 digits on Amended By");
            claimForm.AmendedBy = exactly + "";
            claimForm.AmendedBy.Should().Be(exactly, "User can enter exactly 3 digist on Amended By");
            claimForm.AmendedBy = moreThan + "";
            claimForm.AmendedBy.Should().Be(exactly, "User cannot enter more than 3 digits on Amended By");
            claimForm.AmendedBy = muchMore + "";
            claimForm.AmendedBy.Should().Be(exactly, "User cannot enter more than 3 digits on Amended By");
        }

        [Then(@"I Can Enter A Max Of Three Numeric Chars on Amended By Version")]
        public void ThenICanEnterAMaxOfNumericCharsOnAmendedByVersion()
        {
            // Max = 3
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string lessThan = "12";
            string exactly = "123";
            string moreThan = "1234";
            string muchMore = "1234567890";

            claimForm.AmendedByVersion = lessThan + "";
            claimForm.AmendedByVersion.Should().Be(lessThan, "User can enter less than 3 digits on Amended By Version");
            claimForm.AmendedByVersion = exactly + "";
            claimForm.AmendedByVersion.Should().Be(exactly, "User can enter exactly 3 digist on Amended By Version");
            claimForm.AmendedByVersion = moreThan + "";
            claimForm.AmendedByVersion.Should().Be(exactly, "User cannot enter more than 3 digits on Amended By Version");
            claimForm.AmendedByVersion = muchMore + "";
            claimForm.AmendedByVersion.Should().Be(exactly, "User cannot enter more than 3 digits on Amended By Version");
        }


        [Then(@"I Can Enter A Max Of Three Alphanumeric Chars on Amends")]
        public void ThenICanEnterAMaxOfThreeAlphanumericCharsOnAmends()
        {
            // Max = 3
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string lessThan = "A2";
            string exactly = "A23";
            string moreThan = "A234";
            string muchMore = "A234567890";

            claimForm.Amends = lessThan + "";
            claimForm.Amends.Should().Be(lessThan, "User can enter less than 3 digits on Amends");
            claimForm.Amends = exactly + "";
            claimForm.Amends.Should().Be(exactly, "User can enter exactly 3 digist on Amends");
            claimForm.Amends = moreThan + "";
            claimForm.Amends.Should().Be(exactly, "User cannot enter more than 3 digits on Amends");
            claimForm.Amends = muchMore + "";
            claimForm.Amends.Should().Be(exactly, "User cannot enter more than 3 digits on Amends");
        }

        [Then(@"I Can Enter A Max Of Three Numeric Chars on Amends Version")]
        public void ThenICanEnterAMaxOfThreeNumericCharsOnAmendsVersion()
        {
            // Max = 3
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            string lessThan = "12";
            string exactly = "123";
            string moreThan = "1234";
            string muchMore = "1234567890";

            claimForm.AmendsVersion = lessThan + "";
            claimForm.AmendsVersion.Should().Be(lessThan, "User can enter less than 3 digits on Amends Version");
            claimForm.AmendsVersion = exactly + "";
            claimForm.AmendsVersion.Should().Be(exactly, "User can enter exactly 3 digits on Amends Version");
            claimForm.AmendsVersion = moreThan + "";
            claimForm.AmendsVersion.Should().Be(exactly, "User cannot enter more than 3 digits on Amends Version");
            claimForm.AmendsVersion = muchMore + "";
            claimForm.AmendsVersion.Should().Be(exactly, "User cannot enter more than 3 digits on Amends Version");
        }

        [When(@"I Click on Payment Options Title Bar")]
        [Then(@"I Click on Payment Options Title Bar")]
        public void WhenIClickOnPaymentOptionsTitleBar()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickPaymentOptionsTitleBar();
        }

        [Then(@"I See Payment Options Section Is Hidden")]
        public void ThenISeePaymentOptionsSectionIsHidden()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsPaymentOptionsSectionHidden().Should().BeTrue("Payment Options Section is hidden");
            claimForm.IsPaymentOptionsUnfoldArrowVisible().Should().BeTrue("Payment Options title bar arrow changes to unfold icon");
        }

        [Then(@"I See Payment Options Section Is Open")]
        public void ThenISeePaymentOptionsSectionIsOpen()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsPaymentOptionsSectionVisible().Should().BeTrue("Payment Options Section is visible");
            claimForm.IsPaymentOptionsFoldArrowVisible().Should().BeTrue("Payment Options title bar arrow changes to fold icon");
        }

        [When(@"I Click on Notes Title Bar")]
        [Then(@"I Click on Notes Title Bar")]
        public void WhenIClickOnNotesTitleBar()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickNotesTitleBar();
        }

        [Then(@"I See Notes Section Is Hidden")]
        public void ThenISeeNotesSectionIsHidden()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsNotesSectionHidden().Should().BeTrue("Notes Section is hidden");
            claimForm.IsNotesUnfoldArrowVisible().Should().BeTrue("Notes title bar arrow changes to unfold icon");
        }

        [Then(@"I See Notes Section Is Open")]
        public void ThenISeeNotesSectionIsOpen()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsNotesSectionVisible().Should().BeTrue("Notes Section is visible");
            claimForm.IsNotesFoldArrowVisible().Should().BeTrue("Notes title bar arrow changes to fold icon");
        }

        [Then(@"I Can Select And Unselect All Options Except For Wage Deduction")]
        public void ThenICanSelectAndUnselectAllOptionsExceptForWageDeduction()
        {            
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ScrollToClaimOptionsSection();
            //Select each one
            //wage deduction
            claimForm.WageDeductionSelect = true;
            claimForm.WageDeductionSelect.Should().BeFalse("Wage Deduction cannot be selected");
            
            //non compensable
            claimForm.NonCompensableSelect = true;
            claimForm.NonCompensableSelect.Should().BeTrue("Non-compensable can be selected");            

            //exclude...
            claimForm.ExcludeFromUFRSelect = true;
            claimForm.ExcludeFromUFRSelect.Should().BeTrue("Exclude From UFR Label can be selected");
            
            //non discharged...
            claimForm.NonDischargedSelect = true;
            claimForm.NonDischargedSelect.Should().BeTrue("Non Discharged can be selected");
            

            //non discharged...
            claimForm.ReaffirmedSelect = true;
            claimForm.ReaffirmedSelect.Should().BeTrue("Reaffirmed can be selected");
            
            //Unselect Each One
            claimForm.NonCompensableSelect = false;
            claimForm.NonCompensableSelect.Should().BeFalse("Non-compensable can be unselected");
            claimForm.ExcludeFromUFRSelect = false;
            claimForm.ExcludeFromUFRSelect.Should().BeFalse("Exclude From UFR can be unselected");
            claimForm.NonDischargedSelect = false;
            claimForm.NonDischargedSelect.Should().BeFalse("Non Discharged can be unselected");
            claimForm.ReaffirmedSelect = false;
            claimForm.ReaffirmedSelect.Should().BeFalse("Reaffirmed can be unselected");
        }

        [When(@"I Try To Select Wage Deduction From Claim Options")]
        public void WhenITryToSelectWageDeductionFromClaimOptions()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ScrollToClaimOptionsSection();
            claimForm.WageDeductionSelect = true;
        }

        [Then(@"I See Wage Deduction Selection Is '(.*)'")]
        public void ThenISeeWageDeductionSelectionIsTrue(bool selected)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.WageDeductionSelect.Should().Be(selected, "Wage Deductions selected = "+selected);
        }

        [When(@"I Enter Claim Register Note Text '(.*)'")]
        public void WhenIEnterClaimRegisterNoteText(string registerNote)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimsRegisterNote = registerNote;
            ScenarioContext.Current.Add("New Claim Register Note", registerNote);

        }

        [When(@"I Enter Internal Claim Note Text '(.*)'")]
        public void WhenIEnterClaimInternalNoteText(string internalNote)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.InternalClaimNote = internalNote;
            ScenarioContext.Current.Add("New Internal Claim Note", internalNote);
        }

        [When(@"I Click On Edit For The Created Claim")]
        public void WhenIClickOnEditForTheCreatedClaim()
        {            
            string claimNbr = ScenarioContext.Current.Get<string>("New Claim Number");
            this.ClickEditOnClaimByNumber(claimNbr);
        }        

        [Given(@"I Click On Edit For Claim With Claim Number '(.*)'")]
        [When(@"I Click On Edit For Claim With Claim Number '(.*)'")]
        [Then(@"I Click On Edit For Claim With Claim Number '(.*)'")]
        public void GivenIClickOnEditForClaimWithClaimNumber(string claimNbr)
        {
            this.ClickEditOnClaimByNumber(claimNbr);
        }

        [Then(@"I See Note Displays on Claims Register Note Field")]
        public void ThenISeeNoteDisplaysOnClaimsRegisterNoteField()
        {
            ClaimForm claimForm = ScenarioContext.Current.Get<ClaimForm>("Edit Claim Form");
            string note = ScenarioContext.Current.Get<string>("New Claim Register Note");
            claimForm.ClaimsRegisterNote.Should().Be(note, "Register note was saved correctly");
        }

        private void ClickEditOnClaimByNumber(string claimNbr)
        {
            ClaimForm editClaimForm = claimsTab.ClickOnEditClaimByClaimNumber(claimNbr);
            try
            {
                ScenarioContext.Current.Add("Claim Action", "Edit");
            }
            catch (Exception)
            {
                ScenarioContext.Current.Remove("Claim Action");
                ScenarioContext.Current.Add("Claim Action", "Edit");
            }
            try
            {
                ScenarioContext.Current.Add("Edit Claim Form", editClaimForm);
            }
            catch (Exception)
            {
                ScenarioContext.Current.Remove("Edit Claim Form");
                ScenarioContext.Current.Add("Edit Claim Form", editClaimForm);
            }
        }

        [Then(@"I See Note Displays on Internal Claim Note Field")]
        public void ThenISeeNoteDisplaysOnInternalClaimNoteField()
        {
            ClaimForm claimForm = ScenarioContext.Current.Get<ClaimForm>("Edit Claim Form");
            string note = ScenarioContext.Current.Get<string>("New Internal Claim Note");
            claimForm.InternalClaimNote.Should().Be(note, "Internal Note was saved correctly");
        }

        [Given(@"I Enter These Values On More Options Claim Form")]
        public void GivenIEnterTheseValuesOnMoreOptionsClaimForm(Table table)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            TableRows rows = table.Rows;

            TableRow claimData = rows.First();
            claimForm.ScrollToClaimOptionsSection();
            claimForm.CreditorAccountNumber = claimData["Creditor Acc Number"];
            claimForm.CheckDescription = claimData["Check Description"];
            claimForm.WageDeductionSelect = Convert.ToBoolean(claimData["Wage Deduction"]);
            claimForm.NonCompensableSelect = Convert.ToBoolean(claimData["Non-Compensable"]);
            claimForm.ExcludeFromUFRSelect = Convert.ToBoolean(claimData["Exclude from UFR"]);
            claimForm.NonDischargedSelect = Convert.ToBoolean(claimData["Non-discharged"]);
            claimForm.ReaffirmedSelect = Convert.ToBoolean(claimData["Reaffirmed"]);
            claimForm.DateFiled = claimData["Date Filed"];
            claimForm.Amends = claimData["Amends"];
            claimForm.AmendsVersion = claimData["Amends Version"];
            claimForm.AmendedBy = claimData["Amended By"];
            claimForm.AmendedByVersion = claimData["Amended By Version"];

            ScenarioContext.Current.Add("Claim Data More Options", claimData);
        }

        [Given(@"I Enter These Values For Claim Notes")]
        public void GivenIEnterTheseValuesForClaimNotes(Table table)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            TableRows rows = table.Rows;
            TableRow claimNotes = rows.First();
            claimForm.ClaimsRegisterNote = claimNotes["Register Note"];
            claimForm.InternalClaimNote = claimNotes["Internal Note"];

            ScenarioContext.Current.Add("Claim Data Notes", claimNotes);
        }


        [Then(@"I See Edited Values Appear On Edit Claim Basic Form")]
        public void ThenISeeEditedValuesAppearOnEditClaimBasicForm()
        {
            //Expected values
            TableRow expBasicData = ScenarioContext.Current.Get<TableRow>("Claim Data Basic Form");

            //Get current open form
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimFormTitle.Should().Be("Edit Claim", "Claim Form title for edition is correct");

            //Basic section
            claimForm.ClaimNumber.Should().Be(expBasicData["Number"], "Claim Number is correct");
            claimForm.ClaimName.Should().Be(expBasicData["Name"], "Claim Name is correct");
            claimForm.ClaimStatus.Should().Be(expBasicData["Status"], "Status is correct");
            claimForm.Category.Should().Be(expBasicData["Category"], "Category is correct");
            if(expBasicData["Code"] != "")
                claimForm.Code.Should().Contain(expBasicData["Code"], "Code is correct");
            else
                claimForm.Code.Should().Be("Search...", "Code is correct");

            if(expBasicData["Sub Code"] != "")
                claimForm.Subcode.Should().Contain(expBasicData["Sub Code"], "Sub Code is correct");
            else
                claimForm.Subcode.Should().Be("Search...","Sub Code is correct");

            claimForm.PaySequence.Should().Be(expBasicData["Pay Sequence"], "Pay Sequence is correct");
            claimForm.ScheduledAmount.Should().Be(expBasicData["Scheduled"], "Scheduled is correct");
            claimForm.ClaimedAmount.Should().Be(expBasicData["Claimed"], "Claimed is correct");
            claimForm.AllowedAmount.Should().Be(expBasicData["Allowed"], "Allowed is correct");
            claimForm.ReservedAmount.Should().Be(expBasicData["Reserved"], "Reserved is correct");            
        }

        [Then(@"I See Edited Values Appear On Edit Claim Form Under More Options")]
        public void ThenISeeEditedValuesAppearOnEditClaimFormUnderMoreOptions()
        {
            //Get expected data
            TableRow expMoreOptionsData = ScenarioContext.Current.Get<TableRow>("Claim Data More Options");
            TableRow expNotesData = ScenarioContext.Current.Get<TableRow>("Claim Data Notes");

            //Get current open form
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimFormTitle.Should().Be("Edit Claim", "Claim Form title for edition is correct");

            //More options
            claimForm.CreditorAccountNumber.Should().Be(expMoreOptionsData["Creditor Acc Number"], "Creditor Acc Number is correct");
            claimForm.CheckDescription.Should().Be(expMoreOptionsData["Check Description"], "Check Description is correct");
            claimForm.WageDeductionSelect.Should().Be(Convert.ToBoolean(expMoreOptionsData["Wage Deduction"]), "Wage Deduction is correct");
            claimForm.NonCompensableSelect.Should().Be(Convert.ToBoolean(expMoreOptionsData["Non-Compensable"]), "Non-Compensable is correct");
            claimForm.ExcludeFromUFRSelect.Should().Be(Convert.ToBoolean(expMoreOptionsData["Exclude from UFR"]), "Exclude from UFR is correct");
            claimForm.NonDischargedSelect.Should().Be(Convert.ToBoolean(expMoreOptionsData["Non-discharged"]), "Non-discharged");
            claimForm.ReaffirmedSelect.Should().Be(Convert.ToBoolean(expMoreOptionsData["Reaffirmed"]), "Reaffirmed is correct");
            claimForm.DateFiled.Should().Be(expMoreOptionsData["Date Filed"], "Date Filed is correct");
            claimForm.Amends.Should().Be(expMoreOptionsData["Amends"], "Amends is correct");
            claimForm.AmendsVersion.Should().Be(expMoreOptionsData["Amends Version"], "Amends Version is correct");
            claimForm.AmendedBy.Should().Be(expMoreOptionsData["Amended By"], "Amended By is correct");
            claimForm.AmendedByVersion.Should().Be(expMoreOptionsData["Amended By Version"], "Amended By Version is correct");

            //Notes
            claimForm.ClaimsRegisterNote.Should().Be(expNotesData["Register Note"], "Register Note is correct");
            claimForm.InternalClaimNote.Should().Be(expNotesData["Internal Note"], "Internal Claim Note is correct");
        }

        [Then(@"I Verify On DB That Verified Field Is True For This Claim")]
        public void ThenVerifyOnDBThatVerifiedFieldIsTrueForThisClaim()
        {
            TableRow claimData = ScenarioContext.Current.Get<TableRow>("Claim Data Basic Form");            
            string claimId = this.GetClaimIdByClaimNumber(claimData["Number"]);

            TestsLogger.Log("Doing query on DB to verify 'Verified' field");
            Dictionary<string,string> parameters = new Dictionary<string, string>();
            parameters.Add("ClaimId", claimId);
            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.GetVerifiedValueForClaimById, parameters);
            foreach (DataRow row in rows)
            {
                row.Field<bool>("Verified").Should().BeTrue("Claim has field Verified = 1 on DB");
            }

        }

        private string GetClaimIdByClaimNumber(string claimNbr)
        {
            return claimsTab.GetClaimIdByClaimNumber(claimNbr);
        }

        //Focus and tabbing
        [Given(@"I See Claim Default Cursor Position Is Claim Number Field")]
        public void GivenISeeClaimDefaultCursorPositionIsClaimField()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsFocusOnField("Serial #").Should().BeTrue("Default Cursor Position Is Claim Number Field");
        }

        [Then(@"I See Claim Cursor Position Is '(.*)' Field")]
        public void ThenISeeClaimCursorPositionIsField(string field)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsFocusOnField(field).Should().BeTrue("Focus expected on field " + field);
        }               

        [Then(@"I See Claim More Options Is Open")]
        public void ThenISeeClaimMoreOptionsIsOpen()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.MoreOptionsVisible.Should().BeTrue("More options section is open");
        }

        [Then(@"I See Claim More Options Is Closed")]
        public void ThenISeeClaimMoreOptionsIsClosed()
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.MoreOptionsVisible.Should().BeFalse("More options section is closed");
        }

        [Then(@"I See Claim Cursor Position Is '(.*)' Button")]
        public void ThenISeeClaimCursorPositionIsButton(string button)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.IsFocusOnButton(button).Should().BeTrue("Focus expected on button " + button);
        }

        [Then(@"I Select Claim Status '(.*)'")]
        public void ThenISelectClaimStatus(string status)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClaimStatus = status;
        }


        [Then(@"I Select Claim Code '(.*)'")]
        public void ThenISelectClaimCode(string code)
        {
            this.WhenITypeOnCodeField(code);
            this.WhenISelectTheFirstResultOnCodeDropdown();
        }

        //Value Field Format
        [Given(@"I See Claim '(.*)' Field Value is '(.*)'")]
        [Then(@"I See Claim '(.*)' Field Value is '(.*)'")]
        public void GivenISeeClaimFieldValueIs(string field, string value)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.GetFieldValue(field).Should().Be(value, field+" value is "+value);
        }

        [Given(@"I See Claim '(.*)' Field Placeholder is '(.*)'")]
        public void GivenISeeClaimFieldPlaceholderIs(string field, string placeholder)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.GetFieldPlaceholder(field).Should().Be(placeholder, field + " placeholder is " + placeholder);
        }

        [When(@"I Click On Claim Field '(.*)'")]
        public void WhenIClickOnClaimField(string field)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.ClickOnField(field);
        }

        [Then(@"I Enter Claim '(.*)' Field Value '(.*)'")]
        public void ThenIEnterClaimFieldValue(string field, string value)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SetFieldValue(field, value);
        }

        [Then(@"I Can Select Two Digits From Claim '(.*)' Value '(.*)' And Delete With DELETE Key Getting '(.*)'")]
        public void ThenICanSelectTwoDigitsFromClaimValueAndDeleteWithDELETEKey(string field, string value, string expValue)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SetFieldValue(field, value);
            claimForm.DeleteFirstFourDigitsFromField(field, "delete");            
            claimForm.GetFieldValue(field).Should().Be(expValue, "User can delete a value partially highlighting and pressing DELETE key");
        }

        [Then(@"I Can Select Two Digits From Claim '(.*)' Value '(.*)' And Delete With BACKSPACE Key Getting '(.*)'")]
        public void ThenICanSelectTwoDigitsFromClaimValueAndDeleteWithBACKSPACEKey(string field, string value, string expValue)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SetFieldValue(field, value);
            claimForm.DeleteFirstFourDigitsFromField(field,"backspace");
            claimForm.GetFieldValue(field).Should().Be(expValue, "User can delete a value partially highlighting and pressing BACKSPACE key");
        }

        [Then(@"I Can Select All Digits From Claim '(.*)' Value '(.*)' And Delete With DELETE Key")]
        public void ThenICanSelectAllDigitsFromClaimValueAndDeleteWithDELETEKey(string field, string value)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SetFieldValue(field, value);
            claimForm.DeleteAllDigitsFromField(field, "delete");
            claimForm.GetFieldValue(field).Should().Be("", "User can delete a value completely highlighting and pressing DELETE key");
        }

        [Then(@"I Can Select All Digits From Claim '(.*)' Value '(.*)' And Delete With BACKSPACE Key")]
        public void ThenICanSelectAllDigitsFromClaimValueAndDeleteWithBACKSPACEKey(string field, string value)
        {
            ClaimForm claimForm = this.GetCurrentOpenClaimForm();
            claimForm.SetFieldValue(field, value);
            claimForm.DeleteAllDigitsFromField(field, "backspace");
            claimForm.GetFieldValue(field).Should().Be("", "User can delete a value completely highlighting and pressing BACKSPACE key");
        }

        //Added afterscenario click cancel button to avoid form to prevento logout after a test failure
        [AfterScenario("NewClaim", Order = 0)]
        [AfterScenario("EditClaim", Order = 0)]
        public void CloseClaimFormOnTestFailure()
        {
            if (claimsTab.IsOpenClaimForm())
            {
                claimsTab.ClickCancel();
            }
        }
    }
}
