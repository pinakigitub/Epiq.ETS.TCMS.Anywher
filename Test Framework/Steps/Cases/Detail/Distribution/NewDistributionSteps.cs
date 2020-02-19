using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Distribution;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Distribution
{
    [Binding]
    public class NewDistributionSteps: StepBase
    {
        //REFACTORED - tests not ran, since this functionality is not being used right now
        //if any problem comes up with this distributionTab as it is declared, put it on every stp that uses it instead
        private DistributionTab distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions Tab"));

        //Cancel Flow
        [Given(@"I Click on New Distribution Button on Summary Card")]
        [When(@"I Click on New Distribution Button on Summary Card")]
        private void WhenIClickOnNewDistibutionButtonOnSummaryCard()
        {
            DistributionForm newDistribution= distributionTab.ClickNewDistribution();  

            //save distribution form on scenario context
            ScenarioContext.Current.Add("New Distribution Form", newDistribution);
        }

        [Given(@"I Enter Valid Values on Mandatory Fields for New Distribution")]
        [When(@"I Enter Valid Values on Mandatory Fields for New Distribution")]
        private void WhenIEnterValuesOnMandatoryFieldsForNewDistribution()
        {
            //get distribution Form from ScenarioContext
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");

            //set some valid data
            newDistribution.ProposedAmountToDistribute = "$100.00";
            string distName = "Test Automation of New Distributions " + this.GetRandomNumber();
            newDistribution.DistributionName = distName;

            //Save data for scenario verifications
            ScenarioContext.Current.Add("New Distribution Name", distName);
            ScenarioContext.Current.Add("New Distribution Amount", "$100.00");

        }

        [Given(@"I Enter '(.*)' And '(.*)' Values On Step One")]
        [When(@"I Enter '(.*)' And '(.*)' Values On Step One")]
        private void WhenIEnterValuesOnStepOne(string amount, string name)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ProposedAmountToDistribute = amount;
            newDistribution.DistributionName = name;
        }

        [Given(@"I Enter '(.*)' And '(.*)' On Step Two")]
        [When(@"I Enter '(.*)' And '(.*)' On Step Two")]
        [Then(@"I Enter '(.*)' And '(.*)' On Step Two")]
        private void WhenIEnterOnStepTwo(string percentage, string amount)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.PercentageToDistribute = percentage;
            newDistribution.CalculatedAmountToDistribute = amount;
        }

        [When(@"I Click on Distribution Cancel Button")]
        private void WhenIClickOnDistributionCancelButton()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ClickOnCancel();
        }


        [Then(@"I See New Distribution Form Dissappear")]
        private void ThenISeeNewDistributionFormDissappear()
        {
            distributionTab.HasDistributionFormDissappeared().Should().BeTrue("New Distribution Form Dissapears after cancelling or saving");
        }
        
        
        [Then(@"I See Distribution Has Not Been Saved")]
        private void ThenISeeDistributionHasNotBeenSaved()
        {
            string newDistributionName = ScenarioContext.Current.Get<string>("New Distribution Name");
            distributionTab.IsDistributionPresent(newDistributionName).Should().BeFalse("Distribution is not saved if clicking on Cancel button");
        }

        protected int GetRandomNumber()
        {
            Random rnd = new Random();
            int randomID = rnd.Next(1, 987654);
            return randomID;
        }

        //Steps 1 and 2 Forms Display and Interaction
                
        [Then(@"I See New Distribution Form Displays Fields Labels and Placeholders Correctly For Step One")]
        private void ThenISeeNewDistributionFormDisplaysFieldsLabelsAndPlaceholdersCorrectlyForStepOne()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.FormTitle.Should().Be("New Distribution", "On Step 1, form Title is 'New Distribution'");

            //type
            newDistribution.TypeLabel.Should().Be("DISTRIBUTION TYPE", "Distribution type label is correct");
            newDistribution.BreakdownTypeIsSelected.Should().BeTrue("New Distribution default selected type is 'Breakdown'");
            newDistribution.SelectedTypeDescription.Should().Be("Breakdown - allows users to put creditors into payment groups and allows flexibility of how you pay out each group", "New Distribution default selected type description is correct");
            
            //bank balance
            newDistribution.BankBalanceLabel.Should().Be("BANK BALANCE", "Bank Balance label is correct");

            //amount on reserve
            newDistribution.AmountOnReserveLabel.Should().Be("AMOUNT ON RESERVE", "Bank Balance label is correct");

            //amount available
            newDistribution.AmountAvailableForDistributionLabel.Should().Be("AMOUNT AVAILABLE FOR DISTRIBUTION", "Amount Available For Distribution label is correct");

            //amount to distribute
            newDistribution.ProposedAmountToDistributeLabel.Should().Be("AMOUNT TO DISTRIBUTE", "Amount to distribute label is correct");
            newDistribution.ProposedAmountToDistributePlaceholder.Should().Be("$ 0.00", "Amount to distribute placeholder is correct");

            //amount available
            newDistribution.RemainingBalanceLabel.Should().Be("REMAINING BALANCE", "Remaining Balance label is correct");

            //remaining balance label and value
            newDistribution.DistributionNameLabel.Should().Be("DISTRIBUTION NAME", "Distribution Name label is correct");
            newDistribution.ProposedDistributionPlaceholder.Should().Be("Enter name...", "Distribution Name placeholder is correct");            
        }

        [Then(@"I See New Distribution Form Displays Calculated Balances With Correct Format For Step One")]
        private void ThenISeeNewDistributionFormDisplaysCalculatedBalancesWithCorrectFormatForStep()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            string moneyRegExp = "\\(?\\$([0-9]*)(,[0-9]*)*(\\.[0-9][0-9])?\\)?";
            newDistribution.BankBalance.Should().MatchRegex(moneyRegExp, "Bank Balance format is correct");
            newDistribution.AmountOnReserve.Should().MatchRegex(moneyRegExp, "Amount on Reserve dormat is correct");
            newDistribution.AmountAvailableForDistribution.Should().MatchRegex(moneyRegExp, "Amount Available for Distribution format is correct");
            newDistribution.RemainingBalance.Should().MatchRegex(moneyRegExp, "Remaining Balance format is correct");
        }

        [Then(@"I See New Distribution Form Displays Next and Cancel Button")]
        private void ThenISeeNewDistributionFormDisplaysNextAndCancelButton()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.NextButtonIsPresent.Should().BeTrue("Next button is present on New Distribution form");
            newDistribution.CancelButtonIsPresent.Should().BeTrue("Cancel button is present on New Distribution form");
        }

        [Given(@"I Click on Next Button")]
        [When(@"I Click on Next Button")]
        private void WhenIClickOnNextButton()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ClickOnNext();           
        }

        [Then(@"I See New Distribution Form Locks Down Step One Section And Title is Distributions Name")]
        private void ThenISeeNewDistributionFormLocksDownStepSectionAndTitleIsDistributionsName()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            string name = ScenarioContext.Current.Get<string>("New Distribution Name");
            string amountToDistr = ScenarioContext.Current.Get<string>("New Distribution Amount");

            newDistribution.FormTitle.Should().Be(name, "Once moved on to Step 2, form Title becomes new distribution's name");
            newDistribution.ProposedAmountToDistributeIsEditable.Should().BeFalse("Proposed Amount to Distribute is not editable after clicking on Next");
            newDistribution.ProposedAmountToDistributeNonEditableValue.Replace(" ","").Should().Be(amountToDistr, "Proposed Amount to distribute is set");
        }

        [Then(@"I See Step Two Message Displays Reading '(.*)'")]
        private void ThenISeeStepMessageDisplaysReading(string message)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.Step2Message.Should().Be(message, "Step 2 displays the correct message header");
        }

        [Then(@"I See New Distribution Form Displays Fields Labels and Placeholders Correctly For Step Two")]
        private void ThenISeeNewDistributionFormDisplaysFieldsLabelsAndPlaceholdersCorrectlyForStepTwo()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.PercentageToDistributeLabel.Should().Be("PERCENTAGE TO DISTRIBUTE", "Percentage to distribute label is correct");
            newDistribution.PercentageToDistributePlaceholder.Should().Be("Enter percentage...", "Percentage to distribute placeholder is correct");
            newDistribution.PercentageToDistributeValueOnFocus.Should().Be("%", "Percentage to distribute shows '%' on focus");
            newDistribution.CalculatedAmountToDistributeLabel.Should().Be("AMOUNT TO DISTRIBUTE", "Amount to distribute label is correct");
            newDistribution.CalculatedAmountToDistributePlaceholder.Should().Be("Enter amount...", "Amount to distribute placeholder is correct");
            newDistribution.CalculatedAmountToDistribute.Replace(" ", "").Should().Be("$0.00", "Amount to distribute shows $0.00 on focus");            
        }

        //Remaining Balance Calculation and Display
        [When(@"I Enter An Amount to Distribute Higher Than the Available Amount")]
        private void WhenIEnterAnAmountToDistributeHigherThanTheAvailableAmount()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            string available = newDistribution.AmountAvailableForDistribution;
            double availableAmount = this.GetDoubleFromMoneyString(available);
            double proposedAmount = availableAmount + 1000;
            newDistribution.ProposedAmountToDistribute = ""+ proposedAmount * 100;

            ScenarioContext.Current.Add("New Distribution Available Amount", availableAmount);
            ScenarioContext.Current.Add("New Distribution Proposed Amount", proposedAmount);

        }

        [When(@"I Enter An Amount to Distribute Lower Than the Available Amount")]
        private void WhenIEnterAnAmountToDistributeLowerThanTheAvailableAmount()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            string available = newDistribution.AmountAvailableForDistribution;
            double availableAmount = this.GetDoubleFromMoneyString(available);
            double proposedAmount = availableAmount - 10;
            newDistribution.ProposedAmountToDistribute = "" + proposedAmount * 100;

            ScenarioContext.Current.Add("New Distribution Available Amount", availableAmount);
            ScenarioContext.Current.Add("New Distribution Proposed Amount", proposedAmount);

        }

        protected double GetDoubleFromMoneyString(string moneyString)
        {
            return Convert.ToDouble(moneyString.Replace("$", "").Replace("(", "").Replace(")", "").Replace(" ", ""));//.Replace(",", "")
        }

        [Then(@"I See Remaining Balance Calculation Is Correct")]
        private void ThenISeeRemainingBalanceCalculationIsCorrect()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            double availableAmount = ScenarioContext.Current.Get<double>("New Distribution Available Amount");
            double proposedAmount = ScenarioContext.Current.Get<double>("New Distribution Proposed Amount");

            //get int value of remaining balance
            string remaining = newDistribution.RemainingBalance;
            double remainingBalance = this.GetDoubleFromMoneyString(remaining);
            if (remaining.Contains("(") && remaining.Contains(")"))
                remainingBalance = remainingBalance * (-1);

            remainingBalance.Should().Be(availableAmount - proposedAmount, "Remaining balance calculation is: available amount - proposed amount");
        }

        [Then(@"I See Remainig Balance Displays Correctly As Negative Value")]
        private void ThenISeeRemainigBalanceDisplaysCorrectlyAsNegativeValue()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.RemainingBalance.Should().MatchRegex("\\(\\$([0-9]*)(,[0-9]*)*(\\.[0-9][0-9])?\\)", "Negative values display within parenthesis");
            newDistribution.RemainingBalanceColor.Should().Be("RED", "Negative Remaining Balance displays in red color");
        }

        [Then(@"I See Remainig Balance Displays Correctly As Positive Value")]
        private void ThenISeeRemainigBalanceDisplaysCorrectlyAsPositiveValue()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.RemainingBalance.Should().MatchRegex("\\$([0-9]*)(,[0-9]*)*(\\.[0-9][0-9])?", "Positive values display correctly");
            newDistribution.RemainingBalanceColor.Should().Be("BLACK", "Positive Remaining Balance displays in red color");
        }

        [Given(@"I Go To Step Three Of New Distribution")]
        [When(@"I Go To Step Three Of New Distribution")]
        private void WhenIGoToStepThreeOfNewDistribution()
        {
            //get distribution Form from ScenarioContext
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");

            //set some valid data and go through steps 1 and 2
            newDistribution.ProposedAmountToDistribute = "$100.00";
            string distName = "Test Automation of New Distributions " + this.GetRandomNumber();
            newDistribution.DistributionName = distName;
            newDistribution.ClickOnNext();
            newDistribution.PercentageToDistribute = "100";

            //removed next button from UI - we now have 2 steps
            //newDistribution.ClickOnNext();
        }

        //Distr Methods
        [Then(@"I See Distribution Methods Are Displayed Correctly")]
        private void ThenISeeDistributionMethodsAreDisplayedCorrectly() {
            //get distribution Form from ScenarioContext
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.MethodTitle.Should().Be("(DISTRIBUTION METHOD)", "Distribution method title is correct");
            List<string> methods = newDistribution.MethodOptions;
            methods[0].Should().Be("Pro Rata", "Pro Rata method is present and first");
            methods[1].Should().Be("Pay Each Claim Equally (Convenience Claim)", "Pay Equally method is present and second");
        }

        [Then(@"I See Distribution Methods Default Selection is '(.*)'")]
        private void ThenISeeDistributionMethodsDefaultSelectionIs(string method)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedMethod(method).Should().BeTrue("Selected payment method is correct");
        }

        [Then(@"I See Payees Message Reading '(.*)'")]
        private void ThenISeePayeesMessageReading(string message)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.SelectClassesAndCategoriesMessage.Should().Be(message, "Select claim class message is correct");
        }

        [Given(@"I Select Method '(.*)'")]
        [When(@"I Select Method '(.*)'")]
        private void WhenISelectMethodPayEachClaimEqually(string method)
        {
            //get distribution Form from ScenarioContext
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.SelectPaymentMethod(method);
        }

        [Then(@"I See Method Pro Rata Is Unselected and Pay Each Claim Equally Is Selected")]
        private void ThenISeeMethodProRataIsUnselectedAndPayEachClaimEquallyIsSelected()
        {
            // get distribution Form from ScenarioContext
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedMethod("Pay Each Claim Equally").Should().BeTrue("Pay Each Claim Equally method is selected");
            newDistribution.IsSelectedMethod("Pro Rata").Should().BeFalse("Pro Rata method is unselected");
        }

        [Then(@"I Can Select Pro Rata Again After Selecting Pay Each Claim Equally")]
        private void ThenICanSelectProRataAgainAfterSelectingPayEachClaimEqually()
        {
            //get distribution Form from ScenarioContext
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.SelectPaymentMethod("Pro Rata");
            newDistribution.IsSelectedMethod("Pro Rata").Should().BeTrue("Pro Rata method is selected");
            newDistribution.IsSelectedMethod("Pay Each Claim Equally").Should().BeFalse("Pay Each Claim Equally method is unselected");
        }

        //Class
        [Then(@"I See Claims Class Header And Some Class Displays")]
        private void ThenISeeClaimsClassHeaderAndSomeClassDisplays()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ClaimClassHeader.Should().Be("CLAIM CLASS", "Claim Class header is correct");
            newDistribution.ClaimClassesCount.Should().BeGreaterThan(0, "Some class displays under Claim Class section");
        }
        
        [Then(@"I See Claim Class Select All Option Is Active By Default")]
        private void ThenISeeClaimClassSelectAllOptionIsActiveByDefault()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimClassOption("Select All").Should().BeTrue("Select All is checked by default");
        }

        [Given(@"I Unselect '(.*)' Option From Claim Class")]
        [When(@"I Unselect '(.*)' Option From Claim Class")]
        private void WhenIUnselectOptionFromClaimClass(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.UnselectClassOption(option);
        }

        [Then(@"I See All Claim Classes Are Unselected")]
        private void ThenISeeAllClaimClassesAreUnselected()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.AllClaimClassOptionsUnselected.Should().BeTrue("All Claim Class options are selected");
        }

        [When(@"I Select '(.*)' Option From Claim Class")]
        [Then(@"I Select '(.*)' Option From Claim Class")]
        private void ThenISelectOptionFromClaimClass(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.SelectClassOption(option);
        }

        [Then(@"I See '(.*)' Option From Claim Class Is Selected")]
        private void ThenISeeOptionFromClaimClassIsSelected(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimClassOption(option).Should().BeTrue("Claim Class '" + option + "' is selected");
        }

        [Then(@"I See '(.*)' Option From Claim Class Is Unselected")]
        private void ThenISeeOptionFromClaimClassIsUnselected(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimClassOption(option).Should().BeFalse("Claim Class '" + option + "' is unselected");
        }

        [Then(@"I See All Claim Classes Are Selected")]
        private void ThenISeeAllClaimClassesAreSelected()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.AllClaimClassOptionsSelected.Should().BeTrue("All Claim Class options are selected");
        }

        [Then(@"I Unselect One Option From Claim Class")]
        private void ThenIUnselectOneOptionFromClaimClass()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.UnselectClaimClassFirstOption();
        }

        //Category
        [Then(@"I See Claim Category Header And Some Category Displays")]
        private void ThenISeeClaimCategoryHeaderAndSomeCategoryDisplays()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ClaimCategoryHeader.Should().Be("CLAIM CATEGORY", "Claim Category header is correct");
            newDistribution.ClaimCategoriesCount.Should().BeGreaterThan(0, "Some category displays under Claim Category section");
        }
        
        [Then(@"I See Claim Category Select All Option Is Active By Default")]
        private void ThenISeeClaimCategorySelectAllOptionIsActiveByDefault()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimCategoryOption("Select All").Should().BeTrue("Select All is checked by default");            
        }

        [Given(@"I Unselect '(.*)' Option From Claim Category")]
        [When(@"I Unselect '(.*)' Option From Claim Category")]
        private void WhenIUnselectOptionFromClaimCategory(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.UnselectClaimCategoryOption(option);
        }

        [Then(@"I See All Claim Categories Are Unselected")]
        private void ThenISeeAllClaimCategoriesAreUnselected()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.AllClaimCategoryOptionsUnselected.Should().BeTrue("All Claim Category options are selected");
        }

        [Then(@"I Select '(.*)' Option From Claim Category")]
        private void ThenISelectOptionFromClaimCategory(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.SelectClaimCategoryOption(option);
        }

        [Then(@"I See '(.*)' Option From Claim Category Is Selected")]
        private void ThenISeeOptionFromClaimCategoryIsSelected(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimCategoryOption(option).Should().BeTrue("Claim Category '" + option + "' is selected");
        }

        [Then(@"I See '(.*)' Option From Claim Category Is Unselected")]
        private void ThenISeeOptionFromClaimCategoryIsUnselected(string option)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimCategoryOption(option).Should().BeFalse("Claim Category '" + option + "' is unselected");
        }

        [Then(@"I See All Claim Categories Are Selected")]
        private void ThenISeeAllClaimCategoriesAreSelected()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.AllClaimCategoryOptionsSelected.Should().BeTrue("All Claim Category options are selected");
        }

        [Then(@"I Unselect One Option From Claim Category")]
        private void ThenIUnselectOneOptionFromClaimCategory()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.UnselectClaimCategoryFirstOption();
        }

        //Confirm Selection
        [Then(@"I See Confirm Selections Message Reads '(.*)'")]
        private void ThenISeeConfirmSelectionsMessageReads(string message)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ConfirmSelectionsMessage.Should().Be(message, "Confirm Selections message is correct");
        }

        [Then(@"I See Confirm Selections Description Reads '(.*)'")]
        private void ThenISeeConfirmSelectionsDescriptionReads(string description)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ConfirmSelectionsDescription.Should().Be(description, "Confirm Selections description is correct");
        }

        [Then(@"I See Some Claims Display for the Selected Classes and Categories")]
        private void ThenISeeSomeClaimsDisplayForTheSelectedClassesAndCategories()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ClaimsListCount.Should().BeGreaterThan(0, "Some claims display under Confirm Selection section");
        }

        [Then(@"I See All Claim Classes Display Correctly")]
        private void ThenISeeAllClaimClassesDisplayCorrectly(Table table)
        {
            TableRows expectedClasses = table.Rows;

            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            IEnumerator<DistributionClaimClassData> actualClasses = newDistribution.GetFirstNClasses(expectedClasses.Count).GetEnumerator();
            actualClasses.MoveNext();

            foreach (TableRow expClassData in expectedClasses)
            {
                string expClassName = expClassData["Claim Class"];
                string expCount = expClassData["Count"];
                bool expSelected = Convert.ToBoolean(expClassData["Selected"]);
                string expBalance = expClassData["Balance"];
                string expReserved = expClassData["Reserved"];

                DistributionClaimClassData classData = actualClasses.Current;
                classData.Selected.Should().Be(expSelected, "Claim Class '" + expClassName + "' selected is correct");
                classData.Name.Should().Be(expClassName+" ("+expCount+")", "Claim Class '" + expClassName + "' name is correct");
                classData.BalanceLabel.Should().Be("BALANCE", "Claim Class '" + expClassName + "' balance label is correct");
                classData.BalanceValue.Should().Be(expBalance, "Claim Class '" + expClassName + "' balance value is correct");
                classData.Reserved.Should().Be(expReserved+" Reserved");

                actualClasses.MoveNext();
            }
        }

        [Then(@"I See All Claim Categories Display Correctly")]
        private void ThenISeeAllClaimCategoriesDisplayCorrectly(Table table)
        {
            TableRows expectedClasses = table.Rows;

            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            IEnumerator<DistributionClaimCategoryData> actualCategories = newDistribution.GetFirstNCategories(expectedClasses.Count).GetEnumerator();
            actualCategories.MoveNext();

            foreach (TableRow expCategoryData in expectedClasses)
            {
                string expClassName = expCategoryData["Claim Category"];
                string expCount = expCategoryData["Count"];
                bool expSelected = Convert.ToBoolean(expCategoryData["Selected"]);
                string expBalance = expCategoryData["Balance"];
                string expReserved = expCategoryData["Reserved"];

                DistributionClaimCategoryData categoryData = actualCategories.Current;
                categoryData.Selected.Should().Be(expSelected, "Claim Class '" + expClassName + "' selected is correct");
                categoryData.Name.Should().Be(expClassName + " (" + expCount + ")", "Claim Class '" + expClassName + "' name is correct");
                categoryData.BalanceLabel.Should().Be("BALANCE", "Claim Class '" + expClassName + "' balance label is correct");
                categoryData.BalanceValue.Should().Be(expBalance, "Claim Class '" + expClassName + "' balance value is correct");
                categoryData.Reserved.Should().Be(expReserved + " Reserved");

                actualCategories.MoveNext();
            }
        }

        //Claims list steps
        [When(@"I Select '(.*)' Option From Claims List")]
        [Then(@"I Select '(.*)' Option From Claims List")]
        private void ThenISelectOptionFromClaimsList(string claimName)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.SelectClaimOptionByName(claimName);
        }


        [Then(@"I See '(.*)' Option From Claims List Is Selected")]
        private void ThenISeeOptionFromClaimsListIsSelected(string claimName)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimOption(claimName).Should().BeTrue("Claim "+ claimName + " is selected");
        }
        

        [When(@"I Unselect '(.*)' Option From Claims List")]
        [Then(@"I Unselect '(.*)' Option From Claims List")]
        private void WhenIUnselectOptionFromClaimsList(string claimName)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.UnselectClaimOptionByName(claimName);
        }
        

        [Then(@"I See '(.*)' Option From Claims List Is Unselected")]
        private void ThenISeeOptionFromClaimsListIsUnselected(string claimName)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsSelectedClaimOption(claimName).Should().BeFalse("Claim " + claimName + " is unselected");
        }        


        [Then(@"I See Claims Class '(.*)' Does Not Display On Claims List Section")]
        private void ThenISeeClaimsClassDoesNotDisplayOnClaimsListSection(string claimClass)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsClaimClassPresentOnClaimList(claimClass).Should().BeFalse("Claim class" + claimClass + " is not present on claims list");
        }


        [Then(@"I See These '(.*)' Claims Under '(.*)' With Count Of '(.*)'")]
        private void ThenISeeTheseClaimsUnderWithCountOf(string status, string claimClass, int count, Table table)
        {
            TableRows expectedClaims = table.Rows;            
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");

            //Claims Class Label and Count verification
            newDistribution.IsClaimClassPresentOnClaimList(claimClass).Should().BeTrue("Claim class "+claimClass+" displays on claims list");
            int claimsCountByLabel = newDistribution.GetClaimClassCountOnClaimList(claimClass);
            claimsCountByLabel.Should().Be(count, "Claims class count is correct on Claims List");

            List<DistributionClaimData> actualClaims = newDistribution.GetClaimsByStatusUnderClass(status, claimClass);
            claimsCountByLabel.Should().Be(count, "Expected count of Claims for Class "+claimClass+" matches Count Label on Claims List");
            //actualClaims.Count.Should().Be(claimsCountByLabel, "Count of Claim Items Count on Claims List matches Label Count and Expected Count");

            //Status under Class
            this.VerifyStatusUnderClaimClass(newDistribution,status, claimClass);

            //Claims items verification
            IEnumerator<DistributionClaimData> claimsUnderClass = actualClaims.GetEnumerator();
            claimsUnderClass.MoveNext();
            foreach (TableRow expClaimData in expectedClaims)
            {                
                string expName = expClaimData["Claim Name"];
                string expCategory = expClaimData["Category"];
                string expBalance = expClaimData["Balance"];
                string expNumber = expClaimData["Number"];

                //Data verifications
                DistributionClaimData claim = claimsUnderClass.Current;
                claim.Selected.Should().BeTrue("Claim is selected by default");
                claim.Name.Should().Be(expName, "Claim name is " + expName);
                claim.Category.Should().Be(expCategory, "Claim category is " + expCategory);
                claim.Balance.Should().Be(expBalance, "Claim balance is " + expBalance);
                claim.Number.Should().Be(expNumber, "Claim number is " + expNumber);

                claimsUnderClass.MoveNext();
            }

        }

        private void VerifyStatusUnderClaimClass(DistributionForm newDistribution, string status, string claimClass)
        {
            string statusTitle = newDistribution.StatusUnderClassTitle(status, claimClass);
            switch (status)
            {
                case "Valid To Pay":
                    statusTitle.Should().Be("Valid to Pay", "Valid to pay section title is correct under " + claimClass + " class");
                    break;

                case "Objection Pending":
                    statusTitle.Should().Be("Objection Pending Claims/Reserved", "Objection pending section title is correct under " + claimClass + " class");
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }            
        }

        [Then(@"I See No Message For Another Selection")]
        private void ThenISeeNoMessageForAnotherSelectionDisplays()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.AnotherSelectionRequiredMessageInvisible.Should().BeTrue("No Message For Another Selection Displays");
        }

        [Given(@"I See Message For Another Selection Reads '(.*)'")]
        [Then(@"I See Message For Another Selection Reads '(.*)'")]
        private void ThenISeeMessageForAnotherSelectionReads(string message)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.AnotherSelectionRequiredMessage.Replace("\r\n", " ").Should().Be(message, "Another selection message is correct ");
        }

        [Given(@"I See Grouping Title Reads '(.*)'")]
        [Then(@"I See Grouping Title Reads '(.*)'")]
        private void ThenISeeGroupingTitleReads(string title)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.GroupingSectionTitle.Should().Be(title, "Grouping section title is correct ");
        }

        [Given(@"I See Grouping Box With Correct Data Displays")]
        [Then(@"I See Grouping Box With Correct Data Displays")]
        private void ThenISeeGroupingBoxWithCorrectDataDisplays(Table table)
        {
            TableRows expectedGroups = table.Rows;

            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            IEnumerator<DistributionGroupData> actualGroups = newDistribution.GetDistributionGroups().GetEnumerator();
            actualGroups.MoveNext();

            foreach (TableRow expGroupData in expectedGroups)
            {
                string expNumber = expGroupData["Group Number"];
                string expPercentage = expGroupData["Percentage"];
                string expAmount = expGroupData["Amount Sum"];
                string expMethod = expGroupData["Method"];
                string expReserved = expGroupData["Reserved"];
                string expClaimsIncludedNumber = expGroupData["Claims Included #"];
                string expClaimsIncludedList = expGroupData["Claims Included List"];

                DistributionGroupData group = actualGroups.Current;
                group.DistributingLabel.Should().Be("DISTRIBUTING");
                group.Number.Should().Be(expNumber, "Distribution group has correct number");
                group.Percentage.Should().Be(expPercentage, "Distribution group has correct percentage");
                group.Amount.Should().Be(expAmount, "Distribution group has correct amount");
                switch (expMethod)
                {
                    case "Pro Rata":
                        group.Method.Should().Be("Pro Rata", "Distribution group has correct payment method");
                        break;
                    case "Pay Each Claim Equally":
                        group.Method.Should().Be("Pay Each Claim Equally (Convenience Claim)", "Distribution group has correct payment method");
                        break;
                    default:
                        ScenarioContext.Current.Pending();
                        break;
                }
                group.ReservedValue.Should().Be(expReserved, "Distribution group has correct reserved #");
                group.ReservedLabel.Should().Be("Reserved Claims", "Distribution group has correct reserved label");
                group.ClaimsIncludedLabel.Should().Be("CLAIMS INCLUDED");
                group.ClaimsIncludedNumber.Should().Be(expClaimsIncludedNumber, "Distribution group has correct included claims #");
                group.ClaimsIncludedList.Should().Be(expClaimsIncludedList, "Distribution group has correct included claims #");
                group.ClaimsIncludedNote.Should().Be("Includes Objection Pending/Reserved Claims");

                actualGroups.MoveNext();
            }
        }

        [Then(@"I See Save Button Displays")]
        private void ThenISeeSaveButtonDisplays()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.IsPresentSaveButton.Should().BeTrue("Save button displays");
            newDistribution.SaveButtonText.Should().Be("SAVE","Save button text is correct");
        }

        [Then(@"I See Next Button Dissapears")]
        private void ThenISeeNextButtonDissapears()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.NextButtonIsInvisible.Should().BeTrue("Next Button is not visible ");
        }

        [Then(@"I See Cancel Button Displays")]
        private void ThenISeeCancelButtonDisplays()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");            
            newDistribution.CancelButtonIsPresent.Should().BeTrue("Cancel button is present on New Distribution form");
        }

        [Then(@"I See New Distribution Form Displays Correctly For Step Two On Grouping With '(.*)' And '(.*)'")]
        private void ThenISeeNewDistributionFormDisplaysCorrectlyForStepTwoOnGroupingWith(string percentage, string amount)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.PercentageToDistributeLabel.Should().Be("PERCENTAGE TO DISTRIBUTE", "Percentage to distribute label is correct");            
            newDistribution.PercentageToDistributeValueOnFocus.Should().Be(percentage, "Percentage to distribute shows '%' on focus");
            newDistribution.CalculatedAmountToDistributeLabel.Should().Be("AMOUNT TO DISTRIBUTE", "Amount to distribute label is correct");            
            newDistribution.CalculatedAmountToDistribute.Replace(" ", "").Should().Be(amount, "Amount to distribute shows $0.00 on focus");
        }

        [Then(@"I See Claim Category Header And '(.*)' Category Displays")]
        private void ThenISeeClaimCategoryHeaderAndCategoryDisplays(int count)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ClaimCategoryHeader.Should().Be("CLAIM CATEGORY", "Claim Category header is correct");
            newDistribution.ClaimCategoriesCount.Should().Be(count, count+" categories display under Claim Category section");
        }


        [Then(@"I See A Validation Message on Amount Reading '(.*)'")]
        private void ISeeAValidationMessageOnAmountReading(string message)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.CalculatedAmountValidationMessage.Should().Be(message,"Amount validation message is correct");
        }
    }
}
