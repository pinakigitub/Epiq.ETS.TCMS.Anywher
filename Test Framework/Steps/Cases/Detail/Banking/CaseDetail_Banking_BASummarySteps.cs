using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    public class CaseDetail_Banking_BASummarySteps:StepBase
    {
        //REFACTORED
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        [Then(@"I See the Banking Summary Section With Title '(.*)'")]
        public void ThenISeeTheBankingSummarySection(string summaryTitle)
        {

            bankingTab.IsSummarySectionVisible.Should().BeTrue("Bank Summary Section is visible");
            bankingTab.SummarySectionTitle.Should().Be(summaryTitle, "Summary Section Title should be " + summaryTitle);
        }

        [Then(@"I See the Bank Account Summary Section With Title '(.*)'")]
        public void ThenISeeTheBankAccountSummarySectionWithTitle(string baSectionTitle)
        {
            bankingTab.AccountSectionTitle.Should().Be(baSectionTitle, "Account Summary Section Title should be " + baSectionTitle);

        }

        [Then(@"I See the Ledger Section With Title '(.*)'")]
        public void ThenISeeTheLedgerSectionWithTitle(string ledgerSectionTitle)
        {
            bankingTab.LedgerSectionTitle.Should().Be(ledgerSectionTitle, "Ledger Section Title should be " + ledgerSectionTitle);
        }

        [Then(@"I See Banking Summary Cards and All Values are Correct")]
        public void ThenISeeBankingSummaryCardsAndAllValuesAreCorrect(Table table)
        {
            ScenarioContext.Current.Add("Parameters Table", table);

            TableRows expected = table.Rows;
            List<BankSummaryItemData> summaryCards = bankingTab.GetBankingSummaryItems();

            //check each item in given order, positions should match
            for (int i = 0; i < expected.Count; i++)
            {
                //expected values in this position
                TableRow row = expected[i];
                string expBankAccountName = row["BankAccountName"];
                string expStatus = row["Status"];
                string expBankAccNumber = row["BankAccountNumber"];
                string expBankName = row["BankName"];
                string expLedger = row["Ledger"];
                string expBank = row["Bank"];

                //actual values in this position
                BankSummaryItemData item = summaryCards[i];

                //verifications
                item.BankAccountName.Should().Be(expBankAccountName, "Bank Account Name displayed is " + expBankAccountName + "for Summary Item");
                item.BankAccountEllipsis.Should().BeTrue("Card " + expBankAccountName + " Displays Bank Account Name with Ellipsis");
                //TODO: set status for item according to its color and style
                item.Status.Should().Be(expStatus, "Card Status for BA '" + expBankAccountName + "' is correct");
                item.BankAccountNumber.Should().Be(expBankAccNumber, "Bank Account Number for BA '" + expBankAccountName + "' is correct");

                //Ledger
                item.LedgerLabel.Should().Be("LEDGER", expBankAccountName + " Card: Ledger label is correct");
                item.Ledger.Should().Be(expLedger, expBankAccountName + " Card: Ledger value is correct");
                if (expLedger.StartsWith("-"))
                    item.LedgerTextColor.Should().Be("RED");

                //Bank
                item.BankBalanceLabel.Should().Be("BANK", expBankAccountName + " Card: Bank label is correct");
                item.BankBalance.Should().Be(expBank, expBankAccountName + " Card: Bank value is correct");
                if (expBank.StartsWith("-"))
                    item.BankBalanceColor.Should().Be("RED");

            }
        }


        [Then(@"First Card is Selected By Default And Selecting Each Card Displays BA Detail")]
        public void ThenSelectingEachCardDisplaysBankAccountDataDetail()
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
                    //First card should be selected by default and we want to validate it as default selection first                    
                    bankingTab.IsCardSelectedByPosition(1).Should().BeTrue("Card styles applied to selected card");

                }
                else {
                    bankingTab.SelectSummaryCardByAccountNumber(expCard["BankAccountNumber"]);
                    bankingTab.IsCardSelectedByAccountNumber(expCard["BankAccountNumber"]).Should().BeTrue("Card styles applied to selected card");
                }

                bankingTab.GetDetailBAName().Should().Be(expCard["BankAccountName"], "Selected Card BA Name displays on BA Details");
                bankingTab.GetDetailBANumber().Should().Be(expCard["BankAccountNumber"], "Selected Card BA Number displays on BA Details");
                bankingTab.GetDetailBABankName().Should().Be(expCard["BankName"], "Selected Card Bank Name displays on BA Details");
                bankingTab.GetDetailBAStatus().Should().Be(expCard["Status"], "Selected Card BA Status displays on BA Details");

                position++;
            }

            //Verify going back to 1st card shows details correctly
            TableRow expFirst = expected[0];
            bankingTab.SelectSummaryCardByPosition(1);
            bankingTab.IsCardSelectedByPosition(1).Should().BeTrue("Card styles applied to selected card");
            bankingTab.GetDetailBAName().Should().Be(expFirst["BankAccountName"], "Selected Card BA Name displays on BA Details");
            bankingTab.GetDetailBANumber().Should().Be(expFirst["BankAccountNumber"], "Selected Card BA Number displays on BA Details");
            bankingTab.GetDetailBABankName().Should().Be(expFirst["BankName"], "Selected Card Bank Name displays on BA Details");
            bankingTab.GetDetailBAStatus().Should().Be(expFirst["Status"], "Selected Card BA Status displays on BA Details");
        }

        [Then(@"I See No Banking Summary Items And a Message Shows Reading '(.*)'")]
        public void ThenISeeNoBankingSummaryItemsAndAMessageShowsReading(string noResultsMsg)
        {
            bankingTab.IsResultsListEmpty().Should().BeTrue("No results display on Claims list");
            bankingTab.GetNoResultsMessage().Should().Be(noResultsMsg, "No results message is displayed and correct");
        }
    }
}
