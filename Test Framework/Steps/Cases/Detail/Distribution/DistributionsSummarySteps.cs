using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Distribution
{
    [Binding]
    public class DistributionsSummarySteps:StepBase
    {
        //REFACTORED - tests not ran, since this functionality is not being used right now
        //if any problem comes up with this distributionTab as it is declared, put it on every stp that uses it instead
        private DistributionTab distributionTab = ((DistributionTab)GetSharedPageObjectFromContext("Distributions Tab"));


        [Then(@"I See the Distribution Summary Section With Title '(.*)'")]
        public void ThenISeeTheDistributionSummarySectionWithTitle(string summaryTitle)
        {
            distributionTab.SummarySectionTitle.Should().Be(summaryTitle, "Summary Section Title is '"+summaryTitle+"'");
        }
        
        [Then(@"I See No Distribution Summary Items And a Message Shows Reading '(.*)'")]
        public void ThenISeeNoDistributionSummaryItemsAndAMessageShowsReading(string noResultsMessage)
        {
            distributionTab.NoResultsMessage.Should().Be(noResultsMessage, "No Results Message is '" + noResultsMessage + "' when there are no distributions");

        }

        [Then(@"I See Distribution Summary Cards and All Values are Correct")]
        public void ThenISeeDistributionSummaryCardsAndAllValuesAreCorrect(Table table)
        {
            ScenarioContext.Current.Add("Parameters Table", table);

            TableRows expected = table.Rows;
            List<DistributionSummaryItemData> summaryCards = distributionTab.GetSummaryItems();

            //check each item in given order, positions should match
            for (int i = 0; i < expected.Count; i++)
            {
                //expected values in this position
                TableRow row = expected[i];
                string expDistributionName = row["Distribution Name"];
                string expStatus = row["Status"];
                string expModifiedPayment = row["Modified Payment"];
                string expCalculatedPayment = row["Calculated Payment"];
                string expDifference = row["Difference"];
                string expUpdatedDate = row["Updated Date"];

                //actual values in this position
                DistributionSummaryItemData item = summaryCards[i];

                //verifications
                item.DistributionName.Should().Be(expDistributionName, expDistributionName + " Card: Distribution Name is correct");
                item.Status.Should().Be(expStatus, expDistributionName+" Card: Status is correct");

                if (item.Status == "EDITABLE")
                    item.CardUIStyle.Should().Be("BlueHeader","Editable Distributions have Blue header" );
                else
                    item.CardUIStyle.Should().Be("GreyHeader", "Posted Distributions have Grey header");

                item.ModifiedPaymentLabel.Should().Be("Modified Payment", expDistributionName + "Card: Modified Payment Label is correct");
                item.ModifiedPayment.Should().Be(expModifiedPayment, expDistributionName + "Card: Modified Payment Value is correct");

                item.CalculatedPaymentLabel.Should().Be("Calculated Payment", expDistributionName + "Card: Calculated Payment Label is correct");
                item.CalculatedPayment.Should().Be(expCalculatedPayment, expDistributionName + "Card: Calculated Payment Value is correct");

                item.DifferenceLabel.Should().Be("Difference", expDistributionName + "Card: Difference Label is correct");
                item.Difference.Should().Be(expDifference, expDistributionName + "Card: Difference Value is correct");

                item.UpdatedDateLabel.Should().Be("Updated Date", expDistributionName + "Card: Updated Date Label is correct");
                item.UpdatedDate.Should().Be(expUpdatedDate, expDistributionName + "Card: Updated Date Value is correct");

            }
        }

        [Then(@"First Card is Selected By Default And Selecting Each Card Displays Distribution Detail")]
        public void ThenFirstCardIsSelectedByDefaultAndSelectingEachCardDisplaysDistributionDetail()
        {
            //Get original set of parameters
            Table table = ScenarioContext.Current.Get<Table>("Parameters Table");
            TableRows expected = table.Rows;
            int position = 1;

            //Verify that all cards selection results in details displaying bellow
            foreach (TableRow expCard in expected)
            {
                if (position == 1)
                {
                    //First card should be selected by default
                    distributionTab.IsCardSelectedByPosition(1).Should().BeTrue("Card styles applied to selected card");
                }
                else {
                    //For other cards select and then verify
                    distributionTab.SelectSummaryCardByPosition(position);
                    distributionTab.IsCardSelectedByPosition(position).Should().BeTrue("Card styles applied to selected card");
                }

                this.verifyDistributionDetails(expCard);            

                position++;
            }

            //Verify going back to 1st card shows details correctly
            TableRow expFirst = expected[0];
            distributionTab.SelectSummaryCardByPosition(1);
            distributionTab.IsCardSelectedByPosition(1).Should().BeTrue("Card styles applied to selected card");
            this.verifyDistributionDetails(expFirst);
        }

        private void verifyDistributionDetails(TableRow expCard)
        {
            distributionTab.DistributionDetailSectionTitle.Should().Be(expCard["Distribution Name"], "Selected distribution Name displays on Details Section Title");
            distributionTab.DetailAmount.Should().Be(expCard["Modified Payment"], "Selected distribution Amount displays on Details Section");
            distributionTab.DetailTotalCreditors.Should().MatchRegex("([0-9]*) Total Creditors", "Selected distribution Total Creditors count displays on Details Section");
        }

        [Then(@"I See New Distribution Button is Disabled")]
        private void ISeeNewDistributionButtonIsDisabled()
        {
            distributionTab.NewDistributionButtonIsEnabled.Should().BeFalse("New Distribution Button is Disabled");
        }

        [Then(@"I See New Distribution Button is Enabled")]
        private void ISeeNewDistributionButtonIsEnabled()
        {
            distributionTab.NewDistributionButtonIsEnabled.Should().BeTrue("New Distribution Button is Enabled");
        }

    }
}
