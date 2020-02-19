using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    [Binding]    
    public class ReceiptLogSteps : StepBase
    {
        BankingPage receiptLog = new BankingPage(driver);
        AddDeposit addDeposit;
        AssetsDetailTab assetsDetailTab = new AssetsDetailTab(driver);


        [Then(@"Receipts page should be opened")]
        public void ThenReceiptsPageShouldBeOpened()
        {
            receiptLog = ((BankingPage)GetSharedPageObjectFromContext("Banking ReceiptLog"));
        }

        [Then(@"I select trasaction '(.*)'")]
        public void WhenISelectTrasaction(string voidType)
        {
            receiptLog.SelectTransaction(voidType);
        }

        [When(@"I click on deposit button")]
        public void WhenIClickOnDepositButton()
        {
            addDeposit = receiptLog.ClickOnDepositLinkButton();
        }

        [Then(@"Closing Cost table should display with Unlinked Transaction")]
        public void ThenClosingCostTableShouldDisplayWithUnlinkedTransaction()
        {
            addDeposit.VerifyDefaultAssetsAndClosingCosts();
        }

        [When(@"I select closing costs button")]
        public void WhenISelectClosingCostsButton()
        {
            addDeposit.ClickClosingCostButton();
        }


        [When(@"I Clear Payee Name")]
        public void WhenIClearPayeeName()
        {
            addDeposit.ClearPayeeName();
        }

        [Then(@"Payee Name shuold be clear")]
        public void ThenPayeeNameShuoldBeClear()
        {
            addDeposit.VerifyPayeeNameCleared().Should().BeNullOrWhiteSpace();
        }

        [When(@"I Enter Description")]
        public void WhenIEnterDescription()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Closing Cost Modal should display default")]
        public void ThenClosingCostModalShouldDisplayDefault()
        {
            addDeposit.VerifyAddClosingCostModal();
        }

        [Then(@"Defalut claim type should be NonClaim")]
        public void ThenDefalutClaimTypeShouldBeNonClaim()
        {
            addDeposit.VerifyClaimType();
        }

        [When(@"I select claim radio button")]
        public void WhenISelectClaimRadioButton()
        {
            addDeposit.SelectClaimRadioButton();
        }

        [When(@"I enter '(.*)' in search")]
        public void WhenIEnterInSearch(string claimName)
        {
            addDeposit.EnterClaimNameSearch(claimName);
        }

        [Then(@"Claims sholud be in ascending order")]
        public void ThenClaimsSholudBeInAscendingOrder()
        {
            addDeposit.GetClaimResults();
            addDeposit.ClaimNames.Should().BeInAscendingOrder();
        }


        [Then(@"'(.*)' should be dispaly")]
        public void ThenShouldBeDispaly(string claimName)
        {
            if (claimName.Contains("No result found..."))
                addDeposit.GetClaimResults().NoResultsFound.Should().Contain(claimName);
            else
            {
                var list = claimName.Split(';').ToList();
                addDeposit.GetClaimResultsInfo().Should().Contain(list);
            }
        }

        [When(@"I click on filter")]
        public void WhenIClickOnFilter()
        {
            receiptLog.ClickOnFilter();
        }

        [When(@"I close add closing cost modal")]
        public void WhenICloseAddClosingCostModal()
        {
            addDeposit.ClickClaimClosingCostModal();
        }


        [When(@"I enter case name '(.*)'")]
        public void WhenIEnterCaseName(string caseName)
        {
            receiptLog.EnterCaseNumber(caseName);
        }
        [Then(@"I Click on Add Receipt")]
        public void ThenIClickOnAddReceipt()
        {
            receiptLog.AddReceipt();
        }
        [Then(@"I enter CaseNum '(.*)', Recieved From '(.*)', Bank Received '(.*)', Address '(.*)'")]
        public void ThenIEnterCaseNumBankReceived(string num, string name, string date, string add)
        {
            receiptLog.EnterDetails1(num, name, date, add);
        }
        [Then(@"I enter Amount '(.*)', CheckNum '(.*)', CheckDate '(.*)' and CheckReceived '(.*)'")]
        public void ThenIEnterAmountCheckDate(string amt, string Num, string date1, string date2)
        {
            receiptLog.EnterDetails2(amt,  Num, date1, date2);
        }
        [Then(@"I enter Transaction Details Description '(.*)', Notes '(.*)' and UTC '(.*)'")]
        public void ThenIEnterTransactionDetailsDescriptionAndUTC(string Desc, string notes, string UTC)
        {
            receiptLog.TransactionDetails(Desc, notes, UTC);
        }
        [Then(@"I '(.*)' the Receipt Log")]
        public void ThenITheReceiptLog(string Button)
        {
            receiptLog.ReceiptSaveOrClose(Button);
        }
        [Then(@"I select the Case '(.*)'")]
        public void ThenISelectTheCase(string DedtorName)
        {
            receiptLog.SelectCase(DedtorName);
        }
        [Then(@"I click Deposit")]
        public void ThenIClickDeposit()
        {
            receiptLog.ClickDeposit();
        }
        [Then(@"I Click Link Asset")]
        public void ThenIClickLinkAsset()
        {
             receiptLog.ClickLinkAsset();
        }
        [Then(@"I select Asset '(.*)'")]
        public void ThenISelectAsset(string Asset)
        {
            receiptLog.LinkAsset(Asset);
        }
        [Then(@"I Click on AssetLinks")]
        public void ThenIClickOnAssetLinks()
        {
            receiptLog.ClickAssetLink();
        }
        [Then(@"I Click on ClosingCostLinks")]
        public void ThenIClickOnClosingCostLinks()
        {
            receiptLog.ClickClosingCostLink();
        }

        [Then(@"I Click on Unlinked Allocations")]
        public void ThenIClickOnUnlinkedAllocations()
        {
            receiptLog.ClickUnlinkedAllocations();
        }

        [Then(@"I click on ClaimLinks")]
        public void ThenIClickOnClaimLinks()
        {
            receiptLog.ClickClaimLinks();
        }


        [When(@"I Enter All Feilds")]
        public void WhenIEnterAllFeilds()
        {            
            addDeposit.EnterAllFields();            
        }

        [Then(@"Asterisk should not display")]
        public void ThenAsteriskShouldNotDisplay()
        {
            addDeposit.GetAsteriskDispalyed().Should().BeFalse();
        }

        [When(@"I Clear All Fields")]
        public void WhenIClearAllFields()
        {
            addDeposit.ClearAllFields();
        }

        [Then(@"All Fields should Empty")]
        public void ThenAllFieldsShouldEmpty()
        {
            addDeposit.VerifyAllFieldsCleared();
        }

        [When(@"I Click on ADD in Add Closing Cost")]
        public void WhenIClickOnADDInAddClosingCost()
        {
            addDeposit.ClickAddButton();
        }

        [Then(@"Add Deposit page should display")]
        public void ThenAddDepositPageShouldDisplay()
        {
            addDeposit.VerifyAddDepositPage().Should().BeTrue();
        }

        [When(@"I click on Cancel in Add Closing Cost")]
        public void WhenIClickOnCancelInAddClosingCost()
        {
            addDeposit.ClickCancelButton();
        }

        [Then(@"Added Claim Should display")]
        public void ThenAddedClaimShouldDisplay()
        {
            addDeposit.VerifyAddedClosingCost();
        }

        [When(@"I Click on X in the Closing cost")]
        public void WhenIClickOnXInTheClosingCost()
        {
            addDeposit.RemoveClosingCost();
        }

        [Then(@"Closing Cost Should Removed")]
        public void ThenClosingCostShouldRemoved()
        {
            addDeposit.VerifyClosingCostRecordPresent().Should().BeFalse();
        }
        //[When(@"I enter Linked '(.*)'")]
        //public void WhenIEnterLinked(string type)
        //{
        //    receiptLog.SelectLinked(type);
        //}
        [Then(@"the Records should contain '(.*)'")]
        public void ThenTheRecordsShouldContain(string value)
        {
            receiptLog.GetRecordsByColumnNames(value.Split('-')[0], value.Split('-')[1]);
        }
        [Then(@"I Click On Cancel")]
        public void ThenIClickOnCancel()
        {
            receiptLog.ClickCancel();
        }
        [When(@"I select closing costs Non-Claim button")]
        public void WhenISelectClosingCostsNon_ClaimButton()
        {
            receiptLog.NonClaimClosingCost();
        }
        [Then(@"I Edit transaction Received from '(.*)'")]
        public void ThenIEditTransactionReceivedFrom(string receivedFrom)
        {
            receiptLog.EditReceivedFrom(receivedFrom);
        }
        [Then(@"I click on button ADD")]
        public void ClickOnButtonAdd()
        {
            receiptLog.ClickOnButtonAdd();
        }
        [Then(@"I click on button CLOSING COST\(NON-CLAIM\)")]
        public void ClickOnButtonClosingCostNon_Claim()
        {
            receiptLog.ClickOnButtonClosingCostNon_Claim();
        }
        [Then(@"I click on button CANCEL")]
        public void ClickOnButtonCancel()
        {
            receiptLog.ClickOnButtonCancel();
        }
        [Then(@"I click on button SAVE")]
        public void ClickOnButtonSave()
        {
            receiptLog.ClickOnButtonSave();
        }
        [Then(@"'(.*)' should be displayed in closing costs")]
        public void ClaimNameInClosingCosts(string name)
        {
            receiptLog.ClaimNameInClosingCosts(name);
        }
        [Then(@"'(.*)' should be displayed in closing costs\(Claim\)")]
        public void MessageInClosingCostsClaim(string msg)
        {
            receiptLog.MessageInClosingCostsClaim(msg);
        }
        [Then(@"I enter Net Amount '(.*)' and Gross Amount '(.*)")]
        public void EnterNetAmountAndGrossAmount(string netAmt, string grossAmt)
        {
            receiptLog.EnterNetAmountAndGrossAmount(netAmt, grossAmt);
        }
        [Then(@"I Select transaction Received from '(.*)' in Receipt Log page")]
        public void SelectTransactionInReceiptLogPage(string receivedFrom)
        {
            receiptLog.SelectTransactionInReceiptLogPage(receivedFrom);
        }
        [When(@"I select Voided '(.*)' in Filter")]
        public void SelectVoidedInFilter(string type)
        {
            receiptLog.SelectVoidedInFilter(type);
        }
        [When(@"I select Linked '(.*)' in Filter")]
        public void WhenISelectLinkedInFilter(string type)
        {
            receiptLog.SelectLinkedInFilter(type);
        }


    }
}
