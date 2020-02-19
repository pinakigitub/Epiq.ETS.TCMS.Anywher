using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Distribution;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Distribution
{
    [Binding]
    public class NewDistributionValidationsSteps:NewDistributionSteps
    {
        //REFACTORED - tests not ran, since this functionality is not being used right now
        //if any problem comes up with this distributionTab as it is declared, put it on every stp that uses it instead
        private DistributionTab distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions Tab"));

        [When(@"I Enter '(.*)' on Field '(.*)' for New Distribution And Press Tab")]
        public void WhenIEnterPercentageForNewDistributionAndPressTab(string value, string field)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            this.SetFieldWithValue(newDistribution,field, value);
            newDistribution.PressTabKey();
        }

        [When(@"I Enter '(.*)' on Field '(.*)' for New Distribution And Press Enter Key")]
        public void WhenIEnterPercentageForNewDistributionAndPressEnterKey(string value, string field)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            this.SetFieldWithValue(newDistribution, field, value);
            newDistribution.PressEnterKey();
        }

        private void SetFieldWithValue(DistributionForm newDistribution, string field, string value)
        {
            switch (field)
            {
                case "Name":
                    newDistribution.DistributionName = value;
                    break;
                case "ProposedAmount":
                    newDistribution.ProposedAmountToDistribute = value;
                    break;
                case "Percentage":
                    newDistribution.PercentageToDistribute = value;
                    break;
                case "CalculatedAmount":
                    newDistribution.CalculatedAmountToDistribute = value;
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }        
        
        [When(@"I Enter Percentage '(.*)' On Step Two")]
        public void WhenIEnterPercentageOnStepTwo(string percentage)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.PercentageToDistribute = percentage;
        }
        
        [When(@"I Enter Amount '(.*)' On Step Two")]
        public void WhenIEnterAmountOnStepTwo(string amount)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.CalculatedAmountToDistribute = amount;
        }
        
        [Then(@"I See Validations On Amount If Not '(.*)' And On Name If Not '(.*)'")]
        public void ThenISeeValidationsOnAmountIfNotAndOnNameIfNot(string validAmount, string validName)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            bool isValidName = Convert.ToBoolean(validName);
            bool isValidAmount = Convert.ToBoolean(validAmount);

            if (!isValidName)
                this.ThenISeeAValidationErrorOn("Name", "DISTRIBUTION NAME is required");
            
            if (!isValidAmount)
                this.ThenISeeAValidationErrorOn("ProposedAmount", "The AMOUNT TO DISTRIBUTE needs to be greater than 0");                
        }

        [Then(@"I See Step Two Is Not Displayed On Validation Errors")]
        public void ThenISeeStepTwoIsNotDisplayedOnValidationErrors()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.Step2IsVisible.Should().BeFalse("Step 2 is not present when Step 1 has validation errors");
        }

        [Then(@"Entering Valid Values For Amount and Distribution Name Makes The Validation Messages Dissapear")]
        public void ThenEnteringValidValuesForAmountAndDistributionNameMakesTheValidationMessagesDissapear()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.ProposedAmountToDistribute = "100";
            newDistribution.HasProposedAmountMessageDissapeared().Should().BeTrue("Validation message for Proposed Amount dissappears after entering a valid value");
            newDistribution.DistributionName = "Automated Test of Validations " + this.GetRandomNumber(); ;
            newDistribution.DistributionNameMessageDissapeared().Should().BeTrue("Validation message for Distribution Name dissappears after entering a valid value");

        }

        [Then(@"I See Validations On Percentage If Not '(.*)' And On Amount If Not '(.*)'")]
        public void ThenISeeValidationsOnPercentageIfNotAndOnAmountIfNot(string validPercentage, string validAmount)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            bool isValidPercentage = Convert.ToBoolean(validPercentage);
            bool isValidAmount = Convert.ToBoolean(validAmount);

            if (!isValidPercentage)
                this.ThenISeeAValidationErrorOn("Percentage", "The percentage needs to be greater than 0.00%");

            if (!isValidAmount)
                this.ThenISeeAValidationErrorOn("CalculatedAmount", "The amount needs to be greater than $ 0.00");
        }
        
        [Then(@"Entering Valid Values For Percentage and Amount Makes The Validation Messages Dissapear")]
        public void ThenEnteringValidValuesForPercentageAndAmountMakesTheValidationMessagesDissapear()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.PercentageToDistribute = "100";
            newDistribution.HasPercentageMessageDissapeared().Should().BeTrue("Validation message for Percentage dissappears after entering a valid value");
            newDistribution.CalculatedAmountToDistribute = "";
            newDistribution.HasCalculatedAmountMessageDissapeared().Should().BeTrue("Validation message for Calculated Amount dissappears after entering a valid value");
        }
        
        [Then(@"I See A Validation Error On '(.*)' Reading '(.*)'")]
        public void ThenISeeAValidationErrorOn(string field, string expectedError)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");             
            switch (field)
            {
                case "Name":
                    newDistribution.DistributionNameValidationMessage.Should().Be(expectedError);
                    break;
                case "ProposedAmount":
                    newDistribution.ProposedAmountValidationMessage.Should().Be(expectedError);
                    break;
                case "Percentage":
                    newDistribution.PercentageValidationMessage.Should().Be(expectedError);
                    break;
                case "CalculatedAmount":
                    newDistribution.CalculatedAmountValidationMessage.Should().Be(expectedError);
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }
        
        [Then(@"I See Percentage Field Value Is '(.*)'")]
        public void ThenISeePercentageFieldValueIs(string percentageExpected)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.PercentageToDistribute.Should().Be(percentageExpected, "Expected Percentage to display as "+ percentageExpected);
        }

        [Then(@"I See Calculated Amount Field Value Is '(.*)'")]
        public void ThenISeeCalculatedAmountFieldValueIs(string calcAmountExpected)
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            newDistribution.CalculatedAmountToDistribute.Replace(" ", "").Should().Be(calcAmountExpected, "Calculated Amount to display as " + calcAmountExpected);
        }
        
        [Then(@"I See Calculated Amount Field Value Corresponds to Percentage and Is Rounded")]
        public void ThenISeeCalculatedAmountFieldValueCorresondsToPercentageAndIsRounded()
        {
            DistributionForm newDistribution = ScenarioContext.Current.Get<DistributionForm>("New Distribution Form");
            //Leave focus of any field to trigger masks and validations
            newDistribution.PressTabKey();

            double proposedAmount = this.GetDoubleFromMoneyString(newDistribution.ProposedAmountToDistributeNonEditableValue);
            double percentage = this.GetDoubleFromPercentageString(newDistribution.PercentageToDistribute);
            double calculatedAmount = this.GetDoubleFromMoneyString
                (newDistribution.CalculatedAmountToDistribute);

            calculatedAmount.Should().Be(proposedAmount*percentage/100.00,"Calculated amount is Amount to Distribute * Percentage / 100");
        }

        private double GetDoubleFromPercentageString(string percentage)
        {
            string procesed = percentage.Substring(0, percentage.IndexOf(".")+3);
            return Convert.ToDouble(procesed.Replace("%", "").Replace(" ", ""));
        }
    }
}
