using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Assets
{
    [Binding]
    public class CaseAssetsSummarySteps:StepBase
    {
        //REFACTORED
        private AssetsDetailTab assetsTab = ((AssetsDetailTab)GetSharedPageObjectFromContext("Assets Tab"));

        [Then(@"I See Assets Summary Cards and All Values are Correct")]
        public void ThenISeeAssetsSummaryCardsAndAllValuesAreCorrect(Table table)
        {
            ScenarioContext.Current.Add("Parameters Table", table);

            TableRows expected = table.Rows;
            List<AssetSummaryItemData> summaryCards = assetsTab.GetAssetsSummaryItems();

            //check each item in given order, positions should match
            for (int i = 0; i < expected.Count; i++)
            {
                //expected values in this position
                TableRow row = expected[i];
                string expTitle = row["Title"]+" ("+row["Count"]+")";
                string expRemainingValue = row["Remaining Value"];
                string expPetitionValue = row["Petition Value"];
                string expExemptions = row["Exemptions"];
                string expSales = row["Sales"];

                //actual values in this position
                AssetSummaryItemData item = summaryCards[i];

                //verifications
                item.Title.Should().Be(expTitle, "Tile header text is " + expTitle + "for Summary Item #"+i);
                item.RemainingValue.Should().Be(expRemainingValue, "Card " + expTitle + " displays Remaining Value = "+expRemainingValue);                
                item.PetitionValue.Should().Be(expPetitionValue, "Card " + expTitle + " displays Petition Value = "+expPetitionValue);
                item.Exemptions.Should().Be(expExemptions, "Card " + expTitle + " displays Exemptions = " + expExemptions);
                item.Sales.Should().Be(expSales, "Card " + expTitle + " displays Sales = " + expSales);              

            }
        }


        [Then(@"First Card is Selected By Default And Selecting Each Card Displays Assets Detail")]
        public void ThenSelectingEachCardDisplaysAssetsDetail(Table table)
        {
            TableRows expected = table.Rows;
            int position = 1;

            assetsTab.ScrollToAssetsSummarySection();

            //Verify that all cards selection results in details displaying bellow
            foreach (TableRow expTile in expected)
            {
                if (position == 1)
                {
                    //First card should be selected by default
                    assetsTab.IsSummaryTileSelectedByPosition(1).Should().BeTrue("Selected styles applied to selected tile");
                }
                else {
                    //For other cards select and then verify
                    assetsTab.SelectSummaryTileByPosition(position);
                    assetsTab.IsSummaryTileSelectedByPosition(position).Should().BeTrue("Selected styles applied to selected tile");
                }

                this.verifyAssetTileDetails(expTile);

                position++;
            }


            //Verify going back to 1st card shows details correctly
            TableRow expFirst = expected[0];
            //reload page to reset carousel positions
            assetsTab.Reload();
            assetsTab.ScrollToAssetsSummarySection();
            assetsTab.SelectSummaryTileByPosition(1);
            assetsTab.IsSummaryTileSelectedByPosition(1).Should().BeTrue("Selecting first tile again works correctly");
            this.verifyAssetTileDetails(expFirst);
        }

        private void verifyAssetTileDetails(TableRow expTile)
        {
            //Selection Card title matches selected tile
            string expTitle = expTile["Title"];
            assetsTab.SelectionTitle.Should().Be(expTitle, "Selection title corresponds to selected tile");

            //Selection assets count matches the count for selected tile
            int expAssetsNumber = Convert.ToInt32(expTile["Count"]);
            if (expTitle == "All Assets")
                expTitle = "Total";

            string assetsCountDetailText = assetsTab.SelectionAssetsCountDetail;
            if (expAssetsNumber == 1)
                assetsCountDetailText.Should().Be(expAssetsNumber + " " + expTitle + " Asset", "Selected tile claims count displays correctly");
            else
                assetsCountDetailText.Should().Be(expAssetsNumber + " " + expTitle + " Assets", "Selected tile claims count displays correctly");

            int assetsCountDetail = Convert.ToInt32(assetsCountDetailText.Split(' ')[0]);

            //Selection count matches elements on assets list and is the expected
            assetsCountDetail.Should().Be(assetsTab.AssetsListItemsCount, "Count of claims on Selection Summary is the same as the count of claims on Claims list");
        }
    }
}
