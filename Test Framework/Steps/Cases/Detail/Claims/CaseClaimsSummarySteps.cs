using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail
{
    [Binding]
    public class CaseClaimsSummarySteps:StepBase
    {
        //REFACTORED
        private ClaimsDetailTab claimsTab = ((ClaimsDetailTab)GetSharedPageObjectFromContext("Claims Tab"));

        [Then(@"I See the Claims Summary Section With Title '(.*)'")]
        public void ThenISeeTheClaimsSummarySection(string summaryTitle)
        {
            claimsTab.IsClaimsSummarySectionPresent().Should().BeTrue("Summary Carousel Section is present on Claims Detail Tile.");
            claimsTab.SummarySectionTitle.Should().Be(summaryTitle, "Summary Section Title should be "+summaryTitle);
        }

        [Then(@"I See the Selection Summary Section With Title '(.*)'")]
        public void ThenISeeTheSelectionSummarySectionWithTitle(string selectionTitle)
        {
            claimsTab.SelectionTitle.Should().Be(selectionTitle,"Selection Card Title is correct.");
        }


        [Then(@"I See the Claims List Section With Title '(.*)'")]
        public void ThenISeeTheClaimsListSectionWithTitle(string claimsListTitle)
        {
            claimsTab.ListSectionTitle.Should().Be(claimsListTitle, "Summary Section Title should be " + claimsListTitle);
        }


        [Then(@"I See Claims Summary Tiles and All Values are Correct")]
        public void ThenISeeClaimsSummaryTilesAndAllValuesAreCorrect()
        {
            //Get summary data from DB to verify is correctlyl displayed on the UI
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId", Convert.ToString(CaseDetailSteps.GetCaseIdFromCaseNumber(ScenarioContext.Current.Get<string>("Case Number"))));
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));
            DataRowCollection expectedCardDetail = ExecuteQueryOnDB(Properties.Resources.GetClaimsSummaryByCaseRetrieve, parameters);

            ScenarioContext.Current.Add("Parameters Table", expectedCardDetail);
            
            claimsTab.IsFirstSummaryCardSelected().Should().BeTrue("All Claims Summary Card is selected by Default");

            List<ClaimSummaryItemData> summaryCards = claimsTab.GetClaimSummaryItems();

            IEnumerator enumExpectedCardDetail = expectedCardDetail.GetEnumerator();
            enumExpectedCardDetail.MoveNext();

            //check each item in given order, positions should match
            for (int i = 0; i < expectedCardDetail.Count; i++)
            {
                //expected values in this position
                DataRow row = (DataRow) enumExpectedCardDetail.Current;
                string expCardTitle = row.Field<string>("ClassType");
                string expBalance = row.Field<string>("Balance");
                string expClaimed = row.Field<string>("Claimed");
                string expPaid = row.Field<string>("Paid");
                string expReserved = row.Field<string>("Reserved");

                //actual values in this position
                ClaimSummaryItemData item = summaryCards[i];

                //Verifications               

                //Title
                item.Title.Should().Be(expCardTitle, "Card Title is correct for Summary Item "+ expCardTitle);

                //Balance
                item.BalanceLabel.Should().Be("BALANCE", expCardTitle + " Card: Balance label is correct");
                item.Balance.Should().Be(expBalance, expCardTitle + " Card: Balance value is correct");
                if (expBalance.StartsWith("-"))
                    item.BalanceTextColor.Should().Be("RED");

                //Claimed
                item.ClaimedLabel.Should().Be("CLAIMED", expCardTitle + " Card: Claimed label is correct");
                item.Claimed.Should().Be(expClaimed, expCardTitle + " Card: Claimed value is correct");
                if (expClaimed.StartsWith("-"))
                    item.ClaimedTextColor.Should().Be("RED");

                //Paid
                item.PaidLabel.Should().Be("PAID", expCardTitle + " Card: Paid label is correct");
                item.Paid.Should().Be(expPaid, expCardTitle + " Card: Paid value is correct");
                if (expPaid.StartsWith("-"))
                    item.PaidTextColor.Should().Be("RED");

                //Reserved
                item.ReservedLabel.Should().Be("RESERVED", expCardTitle + " Card: Reserved label is correct");
                item.Reserved.Should().Be(expReserved, expCardTitle + " Card: Reserved value is correct");
                if (expReserved.StartsWith("-"))
                    item.ReservedTextColor.Should().Be("RED");

                //move enumerator from db data
                enumExpectedCardDetail.MoveNext();
            }
        }

        [Then(@"I See Unknown Card Header is Orange")]
        public void ThenISeeUnknownCardHeaderIsOrange()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"First Tile is Selected By Default And Selecting Each Tile Displays Claim Class Detail")]
        public void ThenFirstTileIsSelectedAndSelectingEachTileDisplaysClaimClassDetail()
        {
            //Reload page so carousel position resets - possible because claims is the tab loaded by default
            claimsTab.Reload();

            //Get count of claims by class
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId", Convert.ToString(CaseDetailSteps.GetCaseIdFromCaseNumber(ScenarioContext.Current.Get<string>("Case Number"))));
            DataRowCollection expectedClaimsCounts = ExecuteQueryOnDB(Properties.Resources.GetClaimsCountByClassByCaseId, parameters);

            int[] expClaimsCount = new int[6];
            int i = 1;
            foreach (DataRow item in expectedClaimsCounts)
            {
                expClaimsCount[i] = item.Field<int>("ClaimsCount");
                expClaimsCount[0] += expClaimsCount[i];
                i++;
            }

            DataRow expDataForFirstCard = null;
            //Get original set of parameters
            DataRowCollection expected = ScenarioContext.Current.Get<DataRowCollection>("Parameters Table");
            int position = 1;
            //Verify that all cards selection results in details displaying bellow
            foreach (DataRow expCard in expected)
            {

                if (position == 1)
                {
                    //Save data for last verification on first card
                    expDataForFirstCard = expCard;

                    //First card should be selected by default
                    claimsTab.IsSummaryTileSelectedByPosition(1).Should().BeTrue("Selected styles applied to selected tile");
                }
                else {
                    //For other cards select and then verify
                    claimsTab.SelectSummaryTileByPosition(position);
                    claimsTab.IsSummaryTileSelectedByPosition(position).Should().BeTrue("Selected styles applied to selected tile");
                }

                this.verifyClaimDetails(expCard, expClaimsCount[position-1]);
                position++;
            }


            //Verify going back to 1st card shows details correctly
            claimsTab.Reload();
            claimsTab.SelectSummaryTileByPosition(1);
            claimsTab.IsSummaryTileSelectedByPosition(1).Should().BeTrue("Card styles applied to selected card");            
            this.verifyClaimDetails(expected[0], expClaimsCount[0]);
        }


        private void verifyClaimDetails(DataRow expTile, int expClaimsCount)
        {
            string expClaimClass = (string) expTile.ItemArray[0];

            if (expClaimClass == "All Claims")
                expClaimClass = "Total";

            //verify count and text
            string claimsCountDetailText = claimsTab.SelectionClaimsCountDetail;
            if (expClaimsCount == 1)
                claimsCountDetailText.Should().Be(expClaimsCount + " "+ expClaimClass + " Claim", "Selected tile claims count displays correctly");
            else
                claimsCountDetailText.Should().Be(expClaimsCount + " " + expClaimClass + " Claims", "Selected tile claims count displays correctly");

            //Verify the count is correct, comparring with claims list when tile is selected
            int claimsCountDetail = Convert.ToInt32(claimsCountDetailText.Split(' ')[0]);

            claimsCountDetail.Should().Be(claimsTab.ClaimsListItemsCount, "Count of claims on Selection Summary is the same as the count of claims on Claims list");
        }
        

        [Then(@"Selecting Each Tile Displays Only Claims Of That Class")]
        public void ThenSelectingTileDisplaysOnlyClaimsOfThatClass()
        {
            int classesNbr = claimsTab.SummaryTilesCount;

            //Verify that all cards selection results in details displaying bellow
            for (int position = 1; position <= classesNbr; position++)
            {
               //For other cards select and then verify
               claimsTab.SelectSummaryTileByPosition(position);
               List<string> actualClasses = claimsTab.ClaimsClassesOnList;
               string expClaimClass = claimsTab.SelectedTileName;
                if (expClaimClass != "All Claims") {
                    actualClasses.Count.Should().Be(1, "Selecting a tile filters Claims list to one class of Claims");
                    actualClasses.Contains(expClaimClass).Should().BeTrue("Selecting "+expClaimClass+" tile filters Claims list to that class");
                }
                else
                {
                    actualClasses.Count.Should().Be(classesNbr - 1, "Selecting 'All Claims' tile list all classes of Claims");
                    actualClasses.ShouldAllBeEquivalentTo(claimsTab.SummaryItemsNames,"Selecting 'All Claims' tile list all classes of Claims");
                }
               position++;
            }
        }


    }
}
