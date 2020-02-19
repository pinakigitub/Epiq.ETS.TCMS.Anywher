using System;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class BankingDetailTab:CaseDetailPage
    {
        //GENERAL
        private By NO_RESULTS_MESSAGE_LOCATOR = By.Id("bankingNoResultsMessage");        

        //BANK ACCOUNTS SUMMARY SECTION
        //Titles 
        private By BANKING_TAB_TITLE_LOCATOR = By.Id("detailTabTitle-Banking Detail");
        private By BANK_DETAIL_SUMMARY_SECTION_TITLE_LOCATOR = By.Id("summarySectionTitle");
        protected By ACCOUNT_SUMMARY_SECTION_TITLE_LOCATOR = By.Id("accountSummarySectionTitle");
        protected By LEDGER_SECTION_TITLE_LOCATOR = By.Id("ledgerSectionTitle");

        //Carousel
        private By BANKING_SUMMARY_SECTION_CAROUSEL_LOCATOR = By.CssSelector("section.claimsSummaryCarouselContainer");
        private By BANKING_SUMMARY_ITEM_LOCATOR = By.CssSelector("article.claimSummaryItem");
        private string BANKING_SUMMARY_ITEM_BY_POSITION_LOCATOR_TEMPLATE = "//article[contains(@class, 'claimSummaryItem')][{0}]";
        private string BANKING_SUMMARY_ITEM_BY_ACC_NUMBER_LOCATOR_TEMPLATE = "//h4[contains(text(),'{0}')]/../..";

        //Summary Items locators & loc templates
        private By BANKING_SUMMARY_BA_NAME_LOCATOR = By.XPath(".//h1[contains(@class, 'bankAccountName')]");
        private By BANKING_SUMMARY_BA_NUMBER_LOCATOR = By.XPath(".//h4[contains(@class, 'bankAccountNumber')]");
        private By BANKING_SUMMARY_BANK_NAME_LOCATOR = By.XPath(".//h4[contains(@class, 'bankName')]");

        private string BANKING_SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE = ".//div[contains(@class, '{0}')]//p[contains(@class,'claimItemText')]";
        private string BANKING_SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE = ".//div[contains(@class, '{0}')]//p[contains(@class,'claimItemValue')]";

        public TransactionForm ClickEditButtonForTransactions(string transactionName, string trxType)
        {
            this.WaitForBlockOverlayToDissapear();

            IWebElement editButton = this.WaitForElementToBeVisible(By.XPath("//li[@class='bankTransactionItem']/article/header/div[2]/div[1]/div/h4[contains(text(),'" + transactionName + "')]/../..//div/a"));
            IWebElement scrollToMe = this.WaitForElementToBePresent(By.XPath("//span[@id='ledgerSectionTitle']"));
            if (editButton.GetAttribute("class").ToString().Contains("clickDisabled grey"))
            {
                return null;
            }
            else
            {
                JSMoveToViewElement(scrollToMe);
                clickNotVisualizedElement(editButton);
                this.WaitForBlockOverlayToDissapear();
                if (trxType == "Check")
                {
                    return new TransactionForm(driver, true, false);
                }
                else
                {
                    return new TransactionForm(driver, false, false);
                }
            }
        }

        //BANK ACCOUNT DETAILS LOCATORS
        private By BA_DETAIL_BANK_ACCOUNT_NAME_LOCATOR = By.Id("bankAccountNameDetails");
        private By BA_DETAIL_BANK_ACCOUNT_NUMBER_LOCATOR = By.Id("bankAccountNumberDetails");
        private By BA_DETAIL_BANK_NAME_LOCATOR = By.Id("bankNameDetails");
        private By BA_DETAIL_BANK_ACCOUNT_STATUS_LOCATOR = By.Id("bankStatus");

        //TRANSACTIONS LIST LOCATORS
        private By TRANSACTION_CARD_LOCATOR = By.CssSelector("article.transactionRow");
        private string TRX_CORNER_TAG_BY_ID_LOCATOR_TEMPLATE = "transactionCornerTag-{0}";
        private string TRX_NUMBER_BY_ID_LOCATOR_TEMPLATE = "transactionSerialNumber-{0}";
        private string TRX_NAME_BY_ID_LOCATOR_TEMPLATE = "transactionName-{0}";
        private string TRX_DESCRIPTION_BY_ID_LOCATOR_TEMPLATE = "transactionDescription-{0}";
        private string TRX_DATE_LABEL_BY_ID_LOCATOR_TEMPLATE = "transactionDate-{0}";
        private string TRX_DATE_VALUE_BY_ID_LOCATOR_TEMPLATE = "transactionDateValue-{0}";
        private string TRX_CLEARED_DATE_LABEL_BY_ID_LOCATOR_TEMPLATE = "transactionclearedDate-{0}";
        private string TRX_CLEARED_DATE_VALUE_BY_ID_LOCATOR_TEMPLATE = "transactionClearedDateValue-{0}";
        private string TRX_CODE_LABEL_BY_ID_LOCATOR_TEMPLATE = "transactionCode-{0}";
        private string TRX_CODE_VALUE_BY_ID_LOCATOR_TEMPLATE = "//*[@id='transactionCodeValue-{0}']/span";
        private string TRX_AMOUNT_LABEL_BY_ID_LOCATOR_TEMPLATE = "transactionAmount-{0}";
        private string TRX_AMOUNT_VALUE_BY_ID_LOCATOR_TEMPLATE = "transactionAmountValue-{0}";
        private string TRX_BALANCE_LABEL_BY_ID_LOCATOR_TEMPLATE = "transactionBalance-{0}";
        private string TRX_BALANCE_VALUE_BY_ID_LOCATOR_TEMPLATE = "transactionBalanceValue-{0}";
        private string TRX_TYPE_BOX_BY_ID_LOCATOR_TEMPLATE = "transactionType-{0}";

        private string TRX_CARD_BY_SERIAL_NUMBER_LOCATOR_TEMPLATE = "//p[contains(@id,'transactionSerialNumber-') and contains(text(),'{0}')]/../../..";
        private string TRX_PRINT_LINK_BY_SERIAL_NBR_LOCATOR_TEMPLATE = "//*[contains(@id,'transactionSerialNumber-') and contains(text(),'#{0}')]/../../..//*[contains(@class,'transaction-ledger-option')]/a";


        //NEW TRANSACTIONS ACTIONS LOCATORS
        private By NEW_CHECK_BUTTON_LOCATOR = By.Id("navItem-Check");       
        private By NEW_DEPOSIT_BUTTON_LOCATOR = By.Id("navItem-Deposit");
        private By MORE_TRANSACTIONS_LINK_LOCATOR = By.XPath("//menu-link//div[@id='More-menu-link-button']//a");
        private string OPTION_UNDER_MORE_LINK_LOCATOR_TEMPLATE = "navItem-{0}";


        private By TRANSACTION_FORM_TITLE_LOCATOR = By.XPath("//*[@id='newTransaction']//*[contains(@id,'Title')]");

        private By NEW_TRANSACTION_FORM_LOCATOR = By.Id("newTransaction");

        //Inactive Check and Deposit buttons
        private By INACTIVE_CHECK_BUTTON_LOCATOR = By.XPath("//a[@id='navItem-Check' and contains(@class,'clickDisabled')  and contains(@class,'grey')]");
        private By INACTIVE_DEPOSIT_BUTTON_LOCATOR = By.XPath("//a[@id='navItem-Deposit' and contains(@class,'clickDisabled')  and contains(@class,'grey')]");

        //CLAIM LINKS locators
        private string TRX_CLAIM_LINK_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@class='transactionLinksLabel']";
        //claim nbr
        private string TRX_CLAIM_LINK_NUMBER_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='claimChildNumber']/label";
        private string TRX_CLAIM_LINK_NUMBER_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'claimChildNumber-')]/span[@class='claimLinkText']";
        //claim name
        private string TRX_CLAIM_LINK_NAME_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='claimChildName'][2]/label";
        private string TRX_CLAIM_LINK_NAME_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'claimChildName-')]/span[@class='claimLinkText']";

        //claim code
        private string TRX_CLAIM_LINK_CODE_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='claimChildName'][1]/label";
        private string TRX_CLAIM_LINK_CODE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'claimChildCode-')]/span[@class='claimLinkText']";

        //claim balance
        private string TRX_CLAIM_LINK_BALANCE_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='claimChildBalance']/label";
        private string TRX_CLAIM_LINK_BALANCE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'claimChildBalance-')]/span[@class='claimLinkText']";

        //ASSET LINKS locators
        private string TRX_ASSET_LINK_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@class='transactionLinksLabel']";
        //asset nbr
        private string TRX_ASSET_LINK_NUMBER_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='assetChildNumber']/label";
        private string TRX_ASSET_LINK_NUMBER_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'assetChildNumber-')]/span[@class='claimLinkText']";
        
        //asset name
        private string TRX_ASSET_LINK_NAME_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='assetChildName'][2]/label";
        private string TRX_ASSET_LINK_NAME_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'assetChildName-')]/span[@class='claimLinkText']";
        
        //asset name
        private string TRX_ASSET_LINK_CODE_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='assetChildName'][1]/label";
        private string TRX_ASSET_LINK_CODE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'assetChildCode-')]/span[@class='claimLinkText']";
        
        //asset balance
        private string TRX_ASSET_LINK_BALANCE_LABEL_BY_ID_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//*[@id='assetChildBalance']/label";
        private string TRX_ASSET_LINK_BALANCE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsLink-{0}' and contains(@class,'detailsForDesktop')]//div[@class='row'][{1}]//*[contains(@id,'assetChildBalance-')]/span[@class='claimLinkText']";
        private string TRX_CARD_BY_NAME_LOCATOR_TEMPLATE = "//*[contains(@id,'transactionName-') and contains(text(),'{0}')]/../../../../..";

        public BankingDetailTab(IWebDriver driver):base(driver, "Banking"){}

        public string TabTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(BANKING_TAB_TITLE_LOCATOR).Text;
            }
        }

        public bool IsSummarySectionVisible
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(BANKING_SUMMARY_SECTION_CAROUSEL_LOCATOR);
                    return true;
                }
                catch (System.Exception){ return false;}
            }
        }

        public string SummarySectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(BANK_DETAIL_SUMMARY_SECTION_TITLE_LOCATOR).Text;
            }
        }

        public string AccountSectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(ACCOUNT_SUMMARY_SECTION_TITLE_LOCATOR).Text;
            }
        }

        public string LedgerSectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(LEDGER_SECTION_TITLE_LOCATOR).Text;
            }
        }

        public bool IsDepositButtonInactive()
        {
            try
            {
                this.WaitForElementToBeVisible(INACTIVE_DEPOSIT_BUTTON_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsCheckButtonInactive()
        {
            try
            {
                this.WaitForElementToBeVisible(INACTIVE_CHECK_BUTTON_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<BankSummaryItemData> GetBankingSummaryItems()
        {
            //move to view the full cards
            this.MoveToViewElement(this.WaitForElementToBeVisible(BA_DETAIL_BANK_ACCOUNT_NAME_LOCATOR));

            //get all cards on summary carousel
            IReadOnlyCollection<IWebElement> summaryItems = this.WaitForElementsToBeVisible(BANKING_SUMMARY_ITEM_LOCATOR);
            List<BankSummaryItemData> retItems = new List<BankSummaryItemData>();
            IWebElement previousCard = null;

            //Get content from all Summary Cards
            foreach (var weItem in summaryItems)
            {
                BankSummaryItemData item = new BankSummaryItemData();

                //Set visible status according to style applied to Summary the Card
                if (weItem.GetAttribute("class").Contains("grey"))
                    item.Status = "CLOSED";
                else
                    item.Status = "OPEN";

                //Get "Bank Account Name"
                IWebElement bankAccNameWE = weItem.FindElement(BANKING_SUMMARY_BA_NAME_LOCATOR);
                item.BankAccountName = bankAccNameWE.Text;
                item.BankAccountEllipsis = bankAccNameWE.GetAttribute("class").Contains("ellipsis");

                //Get "Bank Account Number"
                item.BankAccountNumber = weItem.FindElement(BANKING_SUMMARY_BA_NUMBER_LOCATOR).Text;

                //Get "Bank Name"
                item.BankName = weItem.FindElement(BANKING_SUMMARY_BANK_NAME_LOCATOR).Text;

                //Get "Ledger" label, value and color
                item.LedgerLabel = weItem.FindElement(By.XPath(String.Format(BANKING_SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE, "claimClaimedRow"))).Text;

                IWebElement ledgerValue = weItem.FindElement(By.XPath(String.Format(BANKING_SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimClaimedRow")));
                item.Ledger = ledgerValue.Text;

                //IF BALANCE CAME BLANK, card is not visible, so SWIPE TO THE LEFT
                if (item.Ledger == "")
                {
                    //Swipe
                    int offset = -(previousCard.Size.Width) / 2;
                    Actions action = new Actions(driver);
                    action.MoveToElement(previousCard).DragAndDropToOffset(previousCard, offset, 0).Build().Perform();

                    //Get Balance value again
                    ledgerValue = weItem.FindElement(By.XPath(String.Format(BANKING_SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimClaimedRow")));
                    item.Ledger = ledgerValue.Text;
                }

                item.LedgerTextColor = this.GetColorFromColorCode(ledgerValue.GetCssValue("color"));

                //Get "Bank" label, value and color
                item.BankBalanceLabel = weItem.FindElement(By.XPath(String.Format(BANKING_SUMMARY_ITEM_LABEL_LOCATOR_TEMPLATE, "claimSummaryLastRow"))).Text;
                IWebElement bankBalanceValue = weItem.FindElement(By.XPath(String.Format(BANKING_SUMMARY_ITEM_VALUE_LOCATOR_TEMPLATE, "claimSummaryLastRow")));
                item.BankBalance = bankBalanceValue.Text;
                item.BankBalanceColor = this.GetColorFromColorCode(bankBalanceValue.GetCssValue("color"));


                // Add this item to the returned list
                retItems.Add(item);

                //save this as previous card in case of need for swipping on next card
                previousCard = weItem;
            }

            return retItems;
        }

        public void SelectSummaryCardByAccountNumber(string accNumber)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(BANKING_SUMMARY_ITEM_BY_ACC_NUMBER_LOCATOR_TEMPLATE, accNumber))).Click();
            this.WaitForBlockOverlayToDissapear();
            this.Pause(1);
        }

        //Says if the tile contains selected CSS class
        public bool IsCardSelectedByAccountNumber(string accNumber)
        {
            return  this.WaitForElementToBeVisible(By.XPath(String.Format(BANKING_SUMMARY_ITEM_BY_ACC_NUMBER_LOCATOR_TEMPLATE, accNumber))).GetAttribute("class").Contains("selectedTile");                
        }

        //Select a Summary card by its position
        public void SelectSummaryCardByPosition(int position)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(BANKING_SUMMARY_ITEM_BY_POSITION_LOCATOR_TEMPLATE, position))).Click();
            this.WaitForBlockOverlayToDissapear();
            this.Pause(1);
        }

        //Says if the tile contains selected CSS class
        public bool IsCardSelectedByPosition(int position)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(BANKING_SUMMARY_ITEM_BY_POSITION_LOCATOR_TEMPLATE, position))).GetAttribute("class").Contains("selectedTile");
                
        }

        //Selected Bank Account Details
        public string GetDetailBABankName()
        {
            return this.WaitForElementToBeVisible(BA_DETAIL_BANK_NAME_LOCATOR).Text;
        }

        public string GetDetailBAStatus()
        {
            return this.WaitForElementToBeVisible(BA_DETAIL_BANK_ACCOUNT_STATUS_LOCATOR).Text;
        }

        public string GetDetailBANumber()
        {
            return this.WaitForElementToBeVisible(BA_DETAIL_BANK_ACCOUNT_NUMBER_LOCATOR).Text;
        }

        public string GetDetailBAName()
        {
            return this.WaitForElementToBeVisible(BA_DETAIL_BANK_ACCOUNT_NAME_LOCATOR).Text;
        }

        //Transactions List
        public bool IsResultsListEmpty()
        {
            try
            {
                //wait only for 3 seconds
                this.WaitForElementToBeVisible(BANKING_SUMMARY_ITEM_LOCATOR, 3);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public string GetNoResultsMessage()
        {
            return this.WaitForElementToBeVisible(NO_RESULTS_MESSAGE_LOCATOR).Text;
        }

        public List<BankTransactionData> GetFirstNTransactions(int top)
        {
            IReadOnlyCollection<IWebElement> allClaims = this.WaitForElementsToBeVisible(TRANSACTION_CARD_LOCATOR);
            List<BankTransactionData> transactions = new List<BankTransactionData>();

            int count = 0;
            IEnumerator<IWebElement> enumTransactions = allClaims.GetEnumerator();
            while ((enumTransactions.MoveNext()) && (count < top))
            {
                transactions.Add(this.CreateBankTrxFromWebElement(enumTransactions.Current));
                count++;
            }

            return transactions;
        }

        public int GetTransactionIdFromListBySerialNumber(string serialNbr)
        {
            IWebElement trxWE = this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_CARD_BY_SERIAL_NUMBER_LOCATOR_TEMPLATE, serialNbr)));

            string trxNumberId = trxWE.FindElement(By.XPath(".//p[contains(@id,'transactionSerialNumber-')]")).GetAttribute("id");
            trxNumberId = trxNumberId.Replace("transactionSerialNumber-", "");

            return Convert.ToInt32(trxNumberId);
        }

        public int GetTransactionIdFromListByName(string name)
        {
            IWebElement trxWE = this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_CARD_BY_NAME_LOCATOR_TEMPLATE, name)));

            string trxNumberId = trxWE.FindElement(By.XPath(".//p[contains(@id,'transactionSerialNumber-')]")).GetAttribute("id");
            trxNumberId = trxNumberId.Replace("transactionSerialNumber-", "");

            return Convert.ToInt32(trxNumberId);
        }

        private BankTransactionData CreateBankTrxFromWebElement(IWebElement trxWE)
        {
            BankTransactionData transaction = new BankTransactionData();

            //get claim id to replace on id locators
            string trxNumberId = trxWE.FindElement(By.XPath(".//p[contains(@id,'transactionSerialNumber-')]")).GetAttribute("id");            
            trxNumberId = trxNumberId.Replace("transactionSerialNumber-", "");

            int trxId = Convert.ToInt32(trxNumberId);
            transaction.Id = trxId;

            TestsLogger.Debug("Getting data from UI for Transaction with Id="+ trxId);

            //Corner Tag color
            IWebElement cornerTagWE = trxWE.FindElement(By.Id(String.Format(TRX_CORNER_TAG_BY_ID_LOCATOR_TEMPLATE, trxId)));
            transaction.CornerTagColor = this.GetColorFromColorCode(cornerTagWE.FindElement(By.TagName("polygon")).GetCssValue("fill"));

            //TRX Type Box
            transaction.TypeBoxColor = this.GetColorFromColorCode(trxWE.FindElement(By.Id(String.Format(TRX_TYPE_BOX_BY_ID_LOCATOR_TEMPLATE, trxId))).GetCssValue("background-color"));
            transaction.TransactionNumber = trxWE.FindElement(By.Id(String.Format(TRX_NUMBER_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;

            //Name
            transaction.Name = trxWE.FindElement(By.Id(String.Format(TRX_NAME_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;

            //Description
            transaction.Description = trxWE.FindElement(By.Id(String.Format(TRX_DESCRIPTION_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;


            //TRX Date
            transaction.TrxDateLabel = trxWE.FindElement(By.Id(String.Format(TRX_DATE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            transaction.TrxDate = trxWE.FindElement(By.Id(String.Format(TRX_DATE_VALUE_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;

            //Cleared Date
            transaction.ClearedDateLabel = trxWE.FindElement(By.Id(String.Format(TRX_CLEARED_DATE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            IWebElement clearedDateValueWE = trxWE.FindElement(By.Id(String.Format(TRX_CLEARED_DATE_VALUE_BY_ID_LOCATOR_TEMPLATE, trxId)));
            transaction.ClearedDate = clearedDateValueWE.Text;
            transaction.ClaredDateColor = this.GetColorFromColorCode(clearedDateValueWE.GetCssValue("color"));

            //Code
            transaction.CodeLabel = trxWE.FindElement(By.Id(String.Format(TRX_CODE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            transaction.Code = trxWE.FindElement(By.XPath(String.Format(TRX_CODE_VALUE_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;

            //Amount
            transaction.AmountLabel = trxWE.FindElement(By.Id(String.Format(TRX_AMOUNT_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            transaction.AmountValue = trxWE.FindElement(By.Id(String.Format(TRX_AMOUNT_VALUE_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;

            //Balance
            transaction.BalanceLabel = trxWE.FindElement(By.Id(String.Format(TRX_BALANCE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            transaction.BalanceValue = trxWE.FindElement(By.Id(String.Format(TRX_BALANCE_VALUE_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;

            //Set claim links data for Check Trx
            if(transaction.TransactionNumber.Contains("Check #"))
                this.GetClaimLinksDataForTransaction(trxId, trxWE, transaction);
            else if(transaction.TransactionNumber.Contains("Deposit"))
                //Set asset links data for Deposit Trx
                this.GetAssetLinksDataForTransaction(trxId, trxWE, transaction);

            return transaction;
        }

        private void GetAssetLinksDataForTransaction(int trxId, IWebElement trxWE, BankTransactionData transaction)
        {
            //Assets Links section title is only present on certain transactions
            try
            {
                transaction.ClaimLinkLabel = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;                
            }
            catch (Exception)
            {
                transaction.ClaimLinkLabel = "";
            }

            //The rest only appears is there are links for the deposit
            try
            {
                //asset link data labels
                transaction.ClaimLinkNumberLabel = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_NUMBER_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
                transaction.ClaimLinkNameLabel = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_NAME_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
                transaction.ClaimLinkCodeLabel = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_CODE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
                transaction.ClaimLinkBalanceLabel = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_BALANCE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            }
            catch (Exception)
            {                
                transaction.ClaimLinkNumberLabel = "";
                transaction.ClaimLinkNameLabel = "";
                transaction.ClaimLinkCodeLabel = "";
                transaction.ClaimLinkBalanceLabel = "";
            }

            //asset # 1 values
            try
            {
                transaction.ClaimLinkName1 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_NAME_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                transaction.ClaimLinkName1 = transaction.ClaimLinkName1.TrimStart().TrimEnd();

                transaction.ClaimLinkBalance1 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_BALANCE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                transaction.ClaimLinkBalance1 = transaction.ClaimLinkBalance1.TrimStart().TrimEnd();

                //asset # could be empty
                try
                {
                    transaction.ClaimLinkNumber1 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_NUMBER_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                    transaction.ClaimLinkNumber1 = transaction.ClaimLinkNumber1.TrimStart().TrimEnd();
                }
                catch (Exception)
                {
                    transaction.ClaimLinkNumber1 = "";
                }

                //asset CODE could be empty
                try
                {
                    transaction.ClaimLinkCode1 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_CODE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                    transaction.ClaimLinkCode1 = transaction.ClaimLinkCode1.TrimStart().TrimEnd();
                }
                catch (Exception)
                {
                    transaction.ClaimLinkCode1 = "";
                }
            }
            catch (Exception)
            {
                transaction.ClaimLinkName1 = "";
                transaction.ClaimLinkCode1 = "";
                transaction.ClaimLinkBalance1 = "";
                transaction.ClaimLinkNumber1 = "";
            }



            //asset # 2 can be present or not - max asset links is 2
            if(transaction.ClaimLinkName1 != "")
            {
                try
                {
                    transaction.ClaimLinkName2 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_NAME_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                    transaction.ClaimLinkName2 = transaction.ClaimLinkName2.TrimStart().TrimEnd();

                    transaction.ClaimLinkBalance2 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_BALANCE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                    transaction.ClaimLinkBalance2 = transaction.ClaimLinkBalance2.TrimStart().TrimEnd();

                    //Claim # can be empty
                    try
                    {
                        transaction.ClaimLinkNumber2 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_NUMBER_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                        transaction.ClaimLinkNumber2 = transaction.ClaimLinkNumber2.TrimStart().TrimEnd();

                    }
                    catch (Exception)
                    {
                        transaction.ClaimLinkNumber2 = "";
                    }

                    //asset CODE could be empty
                    try
                    {
                        transaction.ClaimLinkCode1 = trxWE.FindElement(By.XPath(String.Format(TRX_ASSET_LINK_CODE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                        transaction.ClaimLinkCode1 = transaction.ClaimLinkCode1.TrimStart().TrimEnd();
                    }
                    catch (Exception)
                    {
                        transaction.ClaimLinkCode1 = "";
                    }
                }
                catch (Exception)
                {
                    transaction.ClaimLinkName2 = "";
                    transaction.ClaimLinkCode2 = "";
                    transaction.ClaimLinkBalance2 = "";
                    transaction.ClaimLinkNumber2 = "";
                }

            }
            else
            {
                transaction.ClaimLinkName2 = "";
                transaction.ClaimLinkCode2 = "";
                transaction.ClaimLinkBalance2 = "";
                transaction.ClaimLinkNumber2 = "";
            }
        }

        private void GetClaimLinksDataForTransaction(int trxId, IWebElement trxWE, BankTransactionData transaction)
        {
            //Claims Links section title is only present on certain transactions
            try
            {
                transaction.ClaimLinkLabel = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            }
            catch (Exception)
            {
                transaction.ClaimLinkLabel = "";
            }

            //CLAIM LINKS - optional - only present if claims linked to the check
            try
            {
                //claim link data labels
                transaction.ClaimLinkNumberLabel = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_NUMBER_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
                transaction.ClaimLinkNameLabel = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_NAME_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
                transaction.ClaimLinkCodeLabel = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_CODE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
                transaction.ClaimLinkBalanceLabel = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_BALANCE_LABEL_BY_ID_LOCATOR_TEMPLATE, trxId))).Text;
            }
            catch (Exception)
            {
                transaction.ClaimLinkNumberLabel = "";
                transaction.ClaimLinkNameLabel = "";
                transaction.ClaimLinkCodeLabel = "";
                transaction.ClaimLinkBalanceLabel = "";
            }

            //claim # 1 values
            try
            {
                transaction.ClaimLinkName1 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_NAME_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                transaction.ClaimLinkName1 = transaction.ClaimLinkName1.TrimStart().TrimEnd();

                

                transaction.ClaimLinkBalance1 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_BALANCE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                transaction.ClaimLinkBalance1 = transaction.ClaimLinkBalance1.TrimStart().TrimEnd();

                //claim # could be empty
                try
                {
                    transaction.ClaimLinkNumber1 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_NUMBER_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                    transaction.ClaimLinkNumber1 = transaction.ClaimLinkNumber1.TrimStart().TrimEnd();
                }
                catch (Exception)
                {
                    transaction.ClaimLinkNumber1 = "";
                }

                //claim CODE could be empty
                try
                {
                    transaction.ClaimLinkCode1 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_CODE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 2))).Text;
                    transaction.ClaimLinkCode1 = transaction.ClaimLinkCode1.TrimStart().TrimEnd();
                }
                catch (Exception)
                {
                    transaction.ClaimLinkCode1 = "";
                }
            }
            catch (Exception)
            {
                transaction.ClaimLinkNumber1 = "";
                transaction.ClaimLinkName1 = "";
                transaction.ClaimLinkCode1 = "";
                transaction.ClaimLinkBalance1 = "";
            }



            //claim # 2 can be present or not - max claim links is 2
            if (transaction.ClaimLinkName1 != "") {
                try
                {
                    transaction.ClaimLinkName2 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_NAME_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                    transaction.ClaimLinkName2 = transaction.ClaimLinkName2.TrimStart().TrimEnd();

                    transaction.ClaimLinkBalance2 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_BALANCE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                    transaction.ClaimLinkBalance2 = transaction.ClaimLinkBalance2.TrimStart().TrimEnd();

                    //Claim # can be empty
                    try
                    {
                        transaction.ClaimLinkNumber2 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_NUMBER_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                        transaction.ClaimLinkNumber2 = transaction.ClaimLinkNumber2.TrimStart().TrimEnd();

                    }
                    catch (Exception)
                    {
                        transaction.ClaimLinkNumber2 = "";
                    }

                    //Claim CODE can be empty
                    try
                    {
                        transaction.ClaimLinkCode2 = trxWE.FindElement(By.XPath(String.Format(TRX_CLAIM_LINK_CODE_VALUE_BY_ID_AND_POSITION_LOCATOR_TEMPLATE, trxId, 3))).Text;
                        transaction.ClaimLinkCode2 = transaction.ClaimLinkCode2.TrimStart().TrimEnd();

                    }
                    catch (Exception)
                    {
                        transaction.ClaimLinkNumber2 = "";
                    }
                }
                catch (Exception)
                {
                    //do nothing, we could have no second claim link on the transaction
                    transaction.ClaimLinkNumber2 = "";
                    transaction.ClaimLinkName2 = "";
                    transaction.ClaimLinkCode2 = "";
                    transaction.ClaimLinkBalance2 = "";
                }

            }
            else
            {
                transaction.ClaimLinkName2 = "";
                transaction.ClaimLinkBalance2 = "";
                transaction.ClaimLinkNumber2 = "";
            }
        }



        //Add Forms and auxiliar methods for the list
        public TransactionForm ClickCheckButton()
        {
            //Scroll to bring buttons into centered view
            this.ScrollDownToTransactionsListStart();
            this.MoveToViewElement(this.WaitForElementToBeVisible(ACCOUNT_SUMMARY_SECTION_TITLE_LOCATOR));

            //Get button and click            
            this.clickNotVisualizedElement(this.WaitForElementToBeClickeable(NEW_CHECK_BUTTON_LOCATOR));
            this.WaitForBlockOverlayToDissapear();

            //Wait for the new check form to appear
            this.WaitForElementToBeVisible(TRANSACTION_FORM_TITLE_LOCATOR);

            //Scroll down again to bring form into view and return page object
            return new TransactionForm(driver, true, true);
        }

        public TransactionForm ClickDepositButton()
        {
            //Scroll to bring buttons into centered view
            this.ScrollDownToTransactionsListStart();
            this.MoveToViewElement(this.WaitForElementToBeVisible(ACCOUNT_SUMMARY_SECTION_TITLE_LOCATOR));

            //Get button and click
            this.clickNotVisualizedElement(this.WaitForElementToBeClickeable(NEW_DEPOSIT_BUTTON_LOCATOR));

            //Wait for the new deposit form to appear
            this.WaitForElementToBeVisible(TRANSACTION_FORM_TITLE_LOCATOR);

            //Scroll down again to bring form into view and return page object
            //this.ScrollDownToTransactionsListStart();
            return new TransactionForm(driver, false, true);
        }

        public TransactionForm ClickNewTransactionMenuLink(string transaction)
        {
            //Scroll to bring buttons into centered view and click on More
            this.ScrollDownToTransactionsListStart();
            this.MoveToViewElement(this.WaitForElementToBeVisible(ACCOUNT_SUMMARY_SECTION_TITLE_LOCATOR));

            bool isCheck = false;

            if (transaction == "Check")
            {
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(NEW_CHECK_BUTTON_LOCATOR));
                isCheck = true;
            }
            else if (transaction == "Deposit")
            {
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(NEW_DEPOSIT_BUTTON_LOCATOR));
            }
            else
            {
                //Click on More > Transaction Link
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(MORE_TRANSACTIONS_LINK_LOCATOR));
                this.clickNotVisualizedElement(this.WaitForElementToBeVisible(By.Id(String.Format(OPTION_UNDER_MORE_LINK_LOCATOR_TEMPLATE, transaction))));
            }


            //Wait for new transaction form to appear
            this.WaitForElementToBeVisible(TRANSACTION_FORM_TITLE_LOCATOR);

            //Return page object for new transaction form
            return new TransactionForm(driver, isCheck, true);
        }

        private void ScrollElementIntoView(IWebElement element)
        {
            this.MoveToViewElement(element);
            this.ScrollDownToAvoidStickyHeadersOnClick();
        }

        

        private void ScrollDownToTransactionsListStart()
        {
            //Scroll down to make button visible
            IWebElement transactionListItem = this.WaitForElementToBeVisible(TRANSACTION_CARD_LOCATOR);
            this.MoveToViewElement(transactionListItem);
            this.ScrollDownToAvoidStickyHeadersOnClick();
        }
        
        public bool NewTransactionFormHasDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(NEW_TRANSACTION_FORM_LOCATOR);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsNewTransactionFormOpen()
        {
            try
            {
                this.WaitForElementToBeVisible(NEW_TRANSACTION_FORM_LOCATOR);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public BankTransactionData GetTransactionBySerialNumber(string serialNbr)
        {
            try
            {
                return this.CreateBankTrxFromWebElement(this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_CARD_BY_SERIAL_NUMBER_LOCATOR_TEMPLATE, serialNbr))));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BankTransactionData GetTransactionByName(string serialNbr)
        {
            try
            {
                return this.CreateBankTrxFromWebElement(this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_CARD_BY_NAME_LOCATOR_TEMPLATE, serialNbr))));
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool IsTransactionPresentOnTheList(string serialNbr)
        {
            try
            {
                //Wait a few seconds, we are already waiting for block screen to dissapear
                By trxSerialNumberLocator = By.XPath(String.Format(TRX_NUMBER_BY_ID_LOCATOR_TEMPLATE, ""));
                this.WaitForElementToHaveText(trxSerialNumberLocator, serialNbr, 5);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Print Link on Trx Card
        public string GetTransactionPrintLinkTextBySerialNumber(string serialNbr)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_PRINT_LINK_BY_SERIAL_NBR_LOCATOR_TEMPLATE,serialNbr))).Text;
        }

        public bool IsTransactionPrintLinkActiveBySerialNumber(string serialNbr)
        {
            IWebElement printLinkWE = this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_PRINT_LINK_BY_SERIAL_NBR_LOCATOR_TEMPLATE,serialNbr)));
            return ! printLinkWE.GetAttribute("class").Contains("clickDisabled grey");
        }

        public void ClickOnTransactionPrintLinkBySerialNumber(string serialNbr)
        {
            IWebElement printLink = this.WaitForElementToBeVisible(By.XPath(String.Format(TRX_PRINT_LINK_BY_SERIAL_NBR_LOCATOR_TEMPLATE,serialNbr)));
            this.MoveToViewElement(printLink);
            if(!printLink.GetAttribute("class").Contains("clickDisabled grey")) { 
                this.clickNotVisualizedElement(printLink);
                this.WaitForBlockOverlayToDissapear();
            }
                //do nothing if cannot click
        }
    }
}