using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Assets
{
    [Binding]
    public class CaseAssetsListSteps:StepBase
    {
        //REFACTORED
        private AssetsDetailTab assetsTab = ((AssetsDetailTab)GetSharedPageObjectFromContext("Assets Tab"));

        [Then(@"I See No Assets Display on the List And a Message Shows Reading '(.*)'")]
        private void ThenISeeNoAssetsDisplayOnTheListAndAMessageShowsReading(string noResultsMsg)
        {
            assetsTab.IsResultsListEmpty().Should().BeTrue("No results display on Assets list");
            assetsTab.GetNoResultsMessage().Should().Be(noResultsMsg,"No results message is displayed and correct");
        }

        [Then(@"I See Assets on the List With Valid Data In Order")]
        private void ThenISeeAssetsDisplayOnTheListWithValidDataInOrder(Table table)
        {
            TableRows expectedAssets = table.Rows;
            IEnumerator<AssetData> actualAssets = assetsTab.GetFirstNAssets(expectedAssets.Count).GetEnumerator();
            actualAssets.MoveNext();

            foreach (TableRow row in expectedAssets)
            {
                AssetData asset = actualAssets.Current;

                //top region
                string expCornerTag = row["Corner Tag"];
                if (expCornerTag  != "None") {
                    asset.CornerTagColor.Should().Be("GREEN", "[" + asset.Id + "] Asset Corner Tag Color is GREEN");
                    asset.CornerTagText.Should().Be(expCornerTag, "[" + asset.Id + "] Asset Corner Tag Legend is " + expCornerTag);
                }

                asset.Number.Trim().Should().Be(row["Number"], "[" + asset.Id + "] Asset Number is " + row["Number"]);
                asset.Name.Should().Be(row["Name"], "[" + asset.Id + "] Asset Name is " + row["Name"]);
                string expFADate = row["FA Date"];
                if (expFADate.Trim() != "")
                {
                    asset.FADateLabel.Should().Be("FA Date:", "[" + asset.Id + "] Asset FA Date label is correct");
                    asset.FADate.Should().Be(expFADate, "[" + asset.Id + "] Asset FA Date is " + expFADate);
                    asset.FADateColor.Should().Be("GREEN", "[" + asset.Id + "] Asset FA Date color is GREEN when present");
                }
                asset.Type.Should().Be(row["Type"], "[" + asset.Id + "] Asset Type " + row["Type"]);
                asset.ValueType.Should().Be(row["Value Type"], "[" + asset.Id + "] Asset Value Type is " + row["Value Type"]);
                
                //left region
                asset.CodeLabel.Should().Be("CODE", "[" + asset.Id + "] Asset Code label is correct");
                asset.Code.Should().Be(row["Code"], "[" + asset.Id + "] Asset Code " + row["Code"]);

                //center region
                asset.PetitionPosition.Should().Be("2", "[" + asset.Id + "] Asset Petition Psotion is 2");
                asset.PetitionLabel.Should().Be("Petition/Unsched Value", "[" + asset.Id + "] Asset Petition Unsched Value is correct");
                asset.Petition.Should().Be(row["Petition Unsched Value"], "[" + asset.Id + "] Asset Petition Unsched Value is " + row["Petition Unsched Value"]);

                asset.NetValuePosition.Should().Be("3", "[" + asset.Id + "] Asset Net Value position is 3");
                asset.NetValueLabel.Should().Be("Net Value", "[" + asset.Id + "] Asset Net Value label is correct");
                asset.NetValue.Should().Be(row["Net Value"], "[" + asset.Id + "] Asset Net Value is " + row["Net Value"]);

                asset.AbandonedPosition.Should().Be("4", "[" + asset.Id + "] Asset Abandoned position is 4");
                asset.AbandonedLabel.Should().Be("Abandoned", "[" + asset.Id + "] Asset Abandoned label is correct");
                asset.Abandoned.Should().Be(row["Abandoned"], "[" + asset.Id + "] Asset Abandoned is " + row["Abandoned"]);

                asset.SalesPosition.Should().Be("5", "[" + asset.Id + "] Asset Sales position is 5");
                asset.SalesLabel.Should().Be("Sales", "[" + asset.Id + "] Asset Sales label is correct");
                asset.Sales.Should().Be(row["Sales"], "[" + asset.Id + "] Asset Sales amount is " + row["Sales"]);

                asset.RemainingPosition.Should().Be("6", "[" + asset.Id + "] Asset Remaining Value FA position is 6");
                asset.RemainingLabel.Should().Be("Remaining Value/FA", "[" + asset.Id + "] Asset Remaining Value FA amount is correct");
                asset.Remaining.Should().Be(row["Remaining Value FA"], "[" + asset.Id + "] Asset Remaining Value FA amount is " + row["Remaining Value FA"]);

                //right region
                asset.TrusteeLabel.Should().Be("Trustee", "[" + asset.Id + "] Asset Trustee label is correct");
                asset.Trustee.Should().Be(row["Trustee"], "[" + asset.Id + "] Asset Trustee amount is " + row["Trustee"]);

                asset.LiensLabel.Should().Be("Liens", "[" + asset.Id + "] Asset Liens label is correct");
                asset.Liens.Should().Be(row["Liens"], "[" + asset.Id + "] Asset Liens amount is " + row["Liens"]);

                asset.ExemptionsLabel.Should().Be("Exemptions", "[" + asset.Id + "] Asset Exemptions amount is correct");
                asset.Exemptions.Should().Be(row["Exemptions"], "[" + asset.Id + "] Asset Exemptions amount is " + row["Exemptions"]);

                //bottom region
                asset.Form1NoteLabel.Should().Be("FORM 1 NOTE", "[" + asset.Id + "] Asset Form 1 Note label is correct");
                string expNote = row["Form 1 Note"];
                if (expNote == "WrappedLongNote")
                    asset.Form1Note.Should().MatchRegex("Lorem ipsum dolor sit amet, consectetuer adipiscing elit.(.*)...", "[" + asset.Id + "] Asset Form 1 Note is " + row["Form 1 Note"]);
                else
                    asset.Form1Note.Should().Be(expNote, "[" + asset.Id + "] Asset Form 1 Note is " + row["Form 1 Note"]);

                actualAssets.MoveNext();
            }
        }
    }
}
