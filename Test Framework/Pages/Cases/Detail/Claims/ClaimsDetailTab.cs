using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Data;
using FluentAssertions;
using System.Data.SqlClient;
using System.Configuration;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class ClaimsDetailTab : CaseDetailPage
    {
        private By claimsTabTitleLocator = By.Id("detailTabTitle-Claims Detail");
        private By claimsSummarySectionTitleLocator = By.Id("claimsSummarySectionTitle");
        protected By selectionTitleLocator = By.Id("claimSelectionsSectionTitle");
        protected By claimsListSectionTitleLocator = By.Id("claimsSectionTitle");

        //CLAIM SUMMARY LOCATORS
        private By claimsSummarySectionCarouselLocator = By.CssSelector("section.claimsSummaryCarouselContainer");
        //note: text and label css classes are inverted in html        
        private By claimSummaryItemLocator = By.CssSelector("article.claimSummaryItem");
        private By selectedClaimSummaryItemNameLocator = By.XPath("//article[contains(@class, 'claimSummaryItem') and contains(@class,'selectedTile')]//h1");
        private By claimSummaryItemNameLocator = By.XPath("//article[contains(@class, 'claimSummaryItem')]//h1");
        private By claimSummaryItemByNameLocator = By.XPath("//article[contains(@class,'claimSummaryItem')]//h1[contains(text(),'{0}')]/../..");
        private By claimSummaryItemTitleLocator = By.CssSelector("header > h1");
        private string claimSummaryItemLabelLocatorTemplate = ".//div[contains(@class, '{0}')]//p[contains(@class,'claimItemText')]";
        private string claimSummaryItemValueLocatorTemplate = ".//div[contains(@class, '{0}')]//p[contains(@class,'claimItemValue')]";

        //CLAIMS SELECTION DETAILS LOCATORS
        private By selectionClaimsCountDetailLocator = By.Id("claimMenuDetails");

        //CLAIMS LIST LOCATORS
        //General locators
        protected By claimListRowLocator = By.CssSelector("article.claimRow");
        private By noResultsMessageLocator = By.Id("claimsNoResultsMessage");
        private By listItemClassLocator = By.XPath("//p[contains(@id, 'claimClass-')]");

        //First row locators
        private string claimNumberByIdLocatorTemplate = "claimNumber-{0}";
        private string creditorNameByIdLocatorTemplate = "claimName-{0}";
        private string statusLocatorByIdTemplate = "claimStatus-{0}";
        private string classLocatorByIdTemplate = "claimClass-{0}";

        //2nd row labels locators
        private string codeLabelLocatorByIdTemplate = "claimCode-{0}";
        private string paySeqLabelLocatorByIdTemplate = "claimPaySeq-{0}";
        private string claimedLabelLocatorByIdTemplate = "claimClaimed-{0}";
        private string allowedLabelLocatorByIdTemplate = "claimAllowed-{0}";
        private string paidlabelLocatorByIdTemplate = "claimPaid-{0}";
        private string reservedLabelLocatorByIdTemplate = "claimReserved-{0}";
        private string interestLabelLocatorByIdTemplate = "claimInterest-{0}";
        private string balanceLabelLocatorByIdTemplate = "//label[@id='claimBalance-{0}']";
        private string cornerTagLoactorByIdTemplate = "claimCornerTag-{0}";


        //2nd row values locators
        private string codeValueLocatorByIdTemplate = "claimCodeValue-{0}";
        private string paySeqValueLocatorByIdTemplate = "claimPaySeqValue-{0}";
        private string claimedValueLocatorByIdTemplate = "claimClaimedValue-{0}";
        private string allowedValueLocatorByIdTemplate = "claimAllowedValue-{0}";
        private string paidValueLocatorByIdTemplate = "claimPaidValue-{0}";
        private string reservedValueLocatorByIdTemplate = "claimReservedValue-{0}";
        private string interestValueLocatorByIdTemplate = "claimInterestValue-{0}";
        private string balanceValueLocatorByIdTemplate = "(//span[@id='claimBalanceValue-{0}'])[2]";
        private string classCircleLocatorByIdTemplate = "claimCircle-{0}";

        //Selection section
        private By newClaimButtonLocator = By.Id("navItem-New");
        protected By newClaimFormTitleLocator = By.Id("newClaimTitle");
        private By claimFormCancelButtonLocator = By.Id("cancelNewClaim");
        private By newClaimButtonInsideSummaryCardLocator = By.XPath("//*[@id='claimMenu']//*[@id='navItem-New']");

        //LIST
        private string claimByNumberLocatorTemplate = "//*[contains(@id,'claimNumber-') and contains(text(),'{0}')]";
        private string editButtonByClaimIdLocatorTemplate = ".//*[@id='scrollTopView{0}']/header/div[2]/div[1]/div[2]/div/div/a";


        //Claim Management
        private By claimsManagementHeader = By.XPath("//div[@class='epiq-page-heading clearfix']/div/h2");
        private By navigation = By.XPath("//*[@class='epiq-page-header']//ol[@role='navigation']");
        //private By HEADER_NAMES = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By headerNames = By.XPath("//table//th[@class='epiq-table-header-sortable ' or @class='epiq-table-header-sortable  visible-xl' or @class='epiq-table-header-sortable  visible-md visible-lg visible-xl' or @class='epiq-table-header-sortable  visible-lg visible-xl']");
        private By pageCount = By.XPath("//h3[text()='Claims']/span");
        private By pagination = By.ClassName("pagination");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By filterButton = By.XPath("//button[contains(@title,'filters.')]");
        //button[contains(@title,'filters.')]
        private By claimCreditorr = By.XPath("//main[@id='epiq-main-page-wrap']/div/div/div/div/div/nav/div[3]/div/div/input");
        private By claimClas = By.XPath("//div[label[text()='CLASS']]//span/div[1]");
        private By claimClassX = By.XPath("//div[label[text()='CLASS']]//span[2]/span");
        private By claimsClassStatus = By.XPath("//div[label[text()='CLAIM STATUS']]//span/div[1]");
        private By claimClassStatusX = By.XPath("//div[label[text()='CLAIM STATUS']]//span[2]/span");
        private By balanceFrom = By.XPath("//main[@id='epiq-main-page-wrap']/div/div/div/div/div/nav/div[3]/div/div[4]/span/input");
        private By balanceToo = By.XPath("//main[@id='epiq-main-page-wrap']/div/div/div/div/div/nav/div[3]/div/div[5]/span/input");
        private By claimCaseStatus = By.XPath("//div[label[text()='CASE STATUS']]//span/div[1]");
        private By arrowIcon = By.XPath("//main[@id='epiq-main-page-wrap']/div/div[4]/div/div/div/table/tbody/tr/td/div/i");
        private By scheduleToClaimReconciliationBreadcrumb = By.XPath("//*[@role='navigation']");
        private By caseNumber = By.XPath("//div[@class='epiq-page-body']//tr/th[2]");
        private By debtorData = By.XPath("//div[@class='epiq-page-body']//tr/th[3]");
        private By claimData = By.XPath("//div[@class='epiq-page-body']//tr/th[4]");
        private By scheduleData = By.XPath("//div[@class='epiq-page-body']//tr/th[5]");
        private By unreconciledData = By.XPath("//div[@class='epiq-page-body']//tr/th[6]");
        private By statusClaim = By.XPath("//div[@class='epiq-page-body']//tr/th[7]");
        private By cases = By.XPath("//div[@class='epiq-page-body']//tr/th[8]");
        private By scheduleToClaimRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By filterScheduleToClaimReconciliation = By.XPath("//button[contains(@title,'filters.')]");
        private By filterReconciled = By.XPath("//div[label[text()='ALL CLAIMS RECONCILED']]//span[@class='Select-arrow-zone']");
        private By filterReconciledValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterClose = By.XPath("//button[text()='CLOSE']");
        private By filterAsset = By.XPath("//div[label[text()='ASSET STATUS']]//span[@class='Select-arrow-zone']");
        private By filterAssetValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterCase = By.XPath("//div[label[text()='CASE STATUS']]//span[@class='Select-arrow-zone']");
        private By filterCaseValues = By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div");
        private By filterReset = By.XPath("//button[text()='RESET']");
        private By claimsRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By linkButton = By.XPath("//button[text()='LINK']");
        private By unlinkButton = By.XPath("//button[text()='UNLINK']");
        private By Delete_Document = By.XPath("//div/div/div/div[2]/i");
        private By scheduleLink = By.XPath("(//div[@class='epiq-table-tab']//tbody/tr/td[2]/div[@class='epiq-input-styled-radio-checkbox'])[1]");
        private By scheduleCreditor = By.XPath("(//div[@class='epiq-table-tab']//tbody/tr/td[4]/div[@class='epiq-ellipsis-text']/span)[1]");
        private By scheduleCreditorAtBottomOfScreen = By.XPath("(//div[@class='row']/div[2]/div/span)[1]");
        private By XButton = By.XPath("(//div[@class='row'])/i");
        private By claimLink = By.XPath("(//div[@class='epiq-table-tab']//tbody/tr/td[2]/div[@class='epiq-input-styled-radio-checkbox'])[11]");
        private By claimCreditor = By.XPath("(//div[@class='epiq-table-tab']//tbody/tr/td[3]/div[@class='epiq-ellipsis-text'])[1]");
        private By claimsCreditorAtBottomOfScreen = By.XPath("(//div[@class='row']/div[2]/div/span)[2]");

        private By claimCaseStatusX = By.XPath("//div[label[text()='CASE STATUS']]//span[2]/span");
        private By claimCloseButton = By.XPath("//button[text()='CLOSE']");
        private By claimResetButton = By.XPath("//button[text()='RESET']");
        private By claimValidPay = By.XPath("//div[div[text()='VALID TO PAY']]/div[2]");

        private string claimFilterSelect = "//div/div[text()='{0}']";
        string expandRecord = "//tbody/tr[{0}]/td/div[@class='visible-sm visible-md visible-lg visible-xl']/i";

        //Add Claim locators
        private By addClaim = By.XPath("//div[@class='epiq-page-control']//button");
        private By subHeader = By.XPath("//div[@class='epiq-page-header']//h2 | //div[@class='epiq-page-header  ']//h2");
        private By caseLevelSubHeader= By.XPath("//div[@class='epiq-page-case-modify-title']//h2");
        //private By SAVE = By.XPath("//button[@class='btn btn-info'][text()='SAVE']");
        private By save = By.XPath("//button[@class='btn btn-info' and text()='SAVE']");
       
        //private By SAVE = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div/form/div/div[2]/div/div/div/button[1]");
        private By editClaim = By.XPath("//main[@id='epiq-main-page-wrap']/div/div[4]/div/div/div/table/tbody/tr/td[23]/a/i | //main[@id='epiq-main-page-wrap']/div/div[5]/div/div/div/table/tbody/tr/td[19]/a");
        private By displayName = By.XPath("//div[@class='row']//input[@name='participantSearch.creditor.new.corporateDisplayName']");
        private By caseLevelClaimsCount = By.XPath("//div[@class='title-button-block']/h3/span/span");

        private By expandRow = By.XPath("//tbody/tr[1]/td[1]/div/i");
        private By inlineEditInput = By.XPath("//div[h3[contains(text(),'')]]/div/form//input");
        private By claimedLocator = By.XPath("//tr[1]/td[13]/div/button");
        private By allowedLocator = By.XPath("//tr[1]/td[14]/div/button");
        private By claimNumLocator = By.XPath("//div[div[text()='CLAIM #']]//button");
        private By categoryLocator = By.XPath("//div[div[text()='CATEGORY']]//button");
        private By sequenceLocator = By.XPath("//div[div[text()='SEQUENCE']]//button");
        private By scheduledLocator = By.XPath("//div[div[text()='SCHEDULED']]//button");
        private By reservedLocator = By.XPath("//div[div[text()='RESERVED']]//button");
        int beforeCount;
        int afterCount;

        //Adding the locators for EXPORT FUNCTIONALITY
        private By exportListButton = By.XPath("//span[@class='epiq-export']/button");
        private By claimMainCount = By.XPath("//h3[text()='Claims']/span");
        private By popUpParagrah = By.XPath("//div[@class='modal-body']/div[1]");
        private By popUpExportButton = By.XPath("//div[2]/div[2]/button");
        private By popUpCancelButton = By.XPath("//button[text()='Cancel']");
        private By toastedMessage = By.XPath("//div[@class='rrt-text']");
        private By deleteButton = By.XPath("//div[@class='epiq-button-group-separator']/button");
        private By selectFirstRecord = By.XPath("//td[2]/div/input");

        private By document = By.XPath("//td[@data-title='FILE NAME']/preceding-sibling::td[2]//label");
        private By documentView = By.XPath("//table/tbody/tr[1]/td[18]/div/i");
        private By documentName = By.XPath("(//a/div)[2]");
        private By linkButtonInLinkCaseDocuments = By.XPath("//button[contains(text(),'LINK (1)')]");

        IList<IWebElement> paidColumnValues;
        string amount,Count;

        List<int> uiValuesClaim;
        List<int> uiValuesSchedule;
        List<int> uiValuesUnreconciled;

        public ClaimsDetailTab(IWebDriver driver) : base(driver, "UNITY")
        {

        }

// adding methods for Export Functionality
        public void ClickOnExportList()
        {
            Count = this.WaitForElementToBeVisible(claimMainCount).Text;
            this.WaitForElementToBeVisible(exportListButton).Click();
        }
        public void MouseHoverOnExportListButton()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(exportListButton)).Perform();
            this.Pause(2);
            this.PressEscapeKey();
        }
        public void ValidateToastedMessage(string ToastMessage)
        {
            string message = this.WaitForElementToBeVisible(toastedMessage,60).Text;
            StringAssert.Contains(ToastMessage ,message);
         }
        public void ValidatePopUpNotAppear()
        {
          bool b1 = this.WaitForElementToBeVisible(popUpParagrah).Enabled;
            Assert.AreEqual(true,b1);
        }
        public string ValidateTextInPopUp()
        {
           
            string text =this.WaitForElementToBeVisible(popUpParagrah).Text;
            return text;         
        }
        public void DeleteFuntionality()
        {
            WaitForElementToBePresent(deleteButton).Click();
            Thread.Sleep(1500);
        }
        public void SelectFirstRecord()
        {
            this.Pause(2);
            var e = driver.FindElement(selectFirstRecord);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }

        public void ClickOnExport()
        {
            this.WaitForElementToBeVisible(popUpExportButton).Click();
        }
        public void ClickOnCancelPopUp()
        {
            this.WaitForElementToBeVisible(popUpCancelButton).Click();
        }

        public void ClickPaidColumn(string paidAmount)
        {
            this.Pause(7);
            int rowsCount = driver.FindElements(By.XPath("//table//tbody//tr")).Count;
            amount = paidAmount;
                if (paidAmount.Equals("$0.00"))
                {
                    IList<IWebElement> paidColumnValues = driver.FindElements(By.XPath("//table//tbody//tr//td[16]//span//span"));
                    this.Pause(4);
                    paidColumnValues.Where(i => i.Text == "" + paidAmount + "").First().Click();
                }
                else
                {
                    //WaitForElementToBeVisible(By.XPath("//table//th[text()='PAID']")).Click();
                    WaitForElementToBeVisible(By.XPath("//td[@data-title='PAID']/span/span")).Click();
                               
                //this.Pause(4);
                //    paidColumnValues = driver.FindElements(By.XPath("//table//tbody//tr//td[16]//span//span"));
                //    paidColumnValues.Where(i => i.Text == "" + paidAmount + "").First().Click();
                 }
           }
        public void ExpandColumnVerify(string label)
        {
            Thread.Sleep(2000);
            var expandArrow = WaitForElementToBePresent(By.XPath("(//table[@class='epiq-table table table-condensed'])[2]//tbody//tr[1]//td[1]/div/i"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", expandArrow);
            var columnHeader = WaitForElementToBePresent(By.XPath($"//div[text()='{label}']")).Text;
            Assert.AreEqual(columnHeader, label);           
        }
        public void ClickEdit()
        {
            foreach (var amountValue in paidColumnValues)
            {
                if(amountValue.Text.Equals(amount))
                {
                     WaitForElementToBePresent(By.XPath("//a[@class='btn btn-info']//i")).Click();
                     break;                                 
                }
            }
        }
        public void VerifyLabel(string label)
        {
            this.Pause(2);
            var actualLabel = WaitForElementToBePresent(By.XPath("//div[text()='Transactions Linked to Claim']"),5).Text;
            Assert.AreEqual(actualLabel, "Transactions Linked to Claim");
        }

        public new void Reload()
        {
            base.Reload();
            this.WaitForBlockOverlayToDissapear();
        }

        public String TabTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(claimsTabTitleLocator).Text;
            }
        }

        public string SummarySectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(claimsSummarySectionTitleLocator).Text;
            }
        }

        public string ListSectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(claimsListSectionTitleLocator).Text;
            }
        }

        public string SelectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(selectionTitleLocator).Text;
            }
        }

        public string SelectionClaimsCountDetail
        {
            get
            {
                return this.WaitForElementToBeVisible(selectionClaimsCountDetailLocator).Text;
            }
        }

        public int ClaimsListItemsCount
        {
            get
            {
                return this.WaitForElementsToBeVisible(claimListRowLocator).Count;
            }
        }

        public int SummaryTilesCount
        {
            get
            {
                return this.WaitForElementsToBePresent(claimSummaryItemLocator).Count;
            }
        }

        public string SelectedTileName
        {
            get
            {
                return this.WaitForElementToBeVisible(selectedClaimSummaryItemNameLocator).Text;
            }
        }

        public List<string> ClaimsClassesOnList
        {
            get
            {
                List<string> retClasses = new List<string>();
                IReadOnlyCollection<IWebElement> all = this.WaitForElementsToBeVisible(listItemClassLocator);
                foreach (IWebElement item in all)
                {
                    string text = item.Text.Split(',')[0];
                    if (!retClasses.Contains(text))
                        retClasses.Add(text);
                }
                return retClasses;
            }
        }

        public List<string> SummaryItemsNames
        {
            get
            {
                List<string> ret = new List<string>();

                IReadOnlyCollection<IWebElement> all = this.WaitForElementsToBePresent(claimSummaryItemNameLocator);
                foreach (IWebElement item in all)
                {
                    string text = item.GetAttribute("innerHTML");
                    if ((text != "All Claims") && (!ret.Contains(text)))
                    {
                        ret.Add(text);
                    }
                }

                return ret;
            }
        }

        //CLAIMS SUMMARY SECTION
        public bool IsClaimsSummarySectionPresent()
        {
            try
            {
                this.WaitForElementToBeVisible(claimsSummarySectionCarouselLocator);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<ClaimSummaryItemData> GetClaimSummaryItems()
        {
            this.JSMoveToViewElement(this.WaitForElementToBeVisible(claimsSummarySectionTitleLocator));

            IReadOnlyCollection<IWebElement> summaryItems = this.WaitForElementsToBePresent(claimSummaryItemLocator);

            List<ClaimSummaryItemData> retItems = new List<ClaimSummaryItemData>();
            IWebElement previousCard = null;

            //Get content from all Summary Cards
            foreach (var weItem in summaryItems)
            {
                ClaimSummaryItemData item = new ClaimSummaryItemData();

                //Locate title of Summary Card
                item.Title = weItem.FindElement(claimSummaryItemTitleLocator).Text;

                //Get "Balance" label, value and color
                item.BalanceLabel = weItem.FindElement(By.XPath(String.Format(claimSummaryItemLabelLocatorTemplate, "claimBalanceRow"))).Text;

                IWebElement balanceValue = weItem.FindElement(By.XPath(String.Format(claimSummaryItemValueLocatorTemplate, "claimBalanceRow")));
                item.Balance = balanceValue.Text;

                //IF BALANCE CAME BLANK, card is not visible, so SWIPE TO THE LEFT
                if (item.Balance == "")
                {
                    this.SwipeTileToTheLeft(previousCard);

                    //Get Balance value again
                    balanceValue = weItem.FindElement(By.XPath(String.Format(claimSummaryItemValueLocatorTemplate, "claimBalanceRow")));
                    item.Balance = balanceValue.Text;
                }

                item.BalanceTextColor = this.GetColorFromColorCode(balanceValue.GetCssValue("color"));

                //Get "Claimed" label, value and color
                item.ClaimedLabel = weItem.FindElement(By.XPath(String.Format(claimSummaryItemLabelLocatorTemplate, "claimClaimedRow"))).Text;
                IWebElement claimedValue = weItem.FindElement(By.XPath(String.Format(claimSummaryItemValueLocatorTemplate, "claimClaimedRow")));
                item.Claimed = claimedValue.Text;
                item.ClaimedTextColor = this.GetColorFromColorCode(claimedValue.GetCssValue("color"));

                //Get "Paid" , value and color
                item.PaidLabel = weItem.FindElement(By.XPath(String.Format(claimSummaryItemLabelLocatorTemplate, "claimPaidRow"))).Text;
                IWebElement paidValue = weItem.FindElement(By.XPath(String.Format(claimSummaryItemValueLocatorTemplate, "claimPaidRow")));
                item.Paid = paidValue.Text;
                item.PaidTextColor = this.GetColorFromColorCode(paidValue.GetCssValue("color"));

                //Get "Reserved" label, value and color
                item.ReservedLabel = weItem.FindElement(By.XPath(String.Format(claimSummaryItemLabelLocatorTemplate, "claimReservedRow"))).Text;
                IWebElement reservedValue = weItem.FindElement(By.XPath(String.Format(claimSummaryItemValueLocatorTemplate, "claimReservedRow")));
                item.Reserved = reservedValue.Text;
                item.ReservedTextColor = this.GetColorFromColorCode(reservedValue.GetCssValue("color"));

                // Add this item to the returned list
                retItems.Add(item);

                //save this as previous card in case of need for swipping on next card
                previousCard = weItem;
            }

            return retItems;
        }

        public void ClickCancel()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(claimsListSectionTitleLocator));
            this.WaitForElementToBeVisible(claimFormCancelButtonLocator).Click();
            this.WaitForBlockOverlayToDissapear();
        }

        public void SelectSummaryTileByPosition(int position)
        {
            this.JSMoveToViewElement(this.WaitForElementToBePresent(claimSummaryItemLocator));
            this.ScrollDownToAvoidStickyHeadersOnClick();
            IEnumerator<IWebElement> allCardsWE = this.WaitForElementsToBePresent(claimSummaryItemLocator).GetEnumerator();

            allCardsWE.MoveNext();
            IWebElement lastVisibleTile = allCardsWE.Current;

            for (int i = 1; i < position; i++)
            {
                allCardsWE.MoveNext();
                if (!allCardsWE.Current.Displayed)
                    this.SwipeTileToTheLeft(lastVisibleTile);
                lastVisibleTile = allCardsWE.Current;
            }

            allCardsWE.Current.Click();
            this.WaitForBlockOverlayToDissapear();
        }

        public bool IsSummaryTileSelectedByPosition(int position)
        {
            this.JSMoveToViewElement(this.WaitForElementToBePresent(claimSummaryItemLocator));
            this.ScrollDownToAvoidStickyHeadersOnClick();
            IEnumerator<IWebElement> allCardsWE = this.WaitForElementsToBePresent(claimSummaryItemLocator).GetEnumerator();
            for (int i = 0; i < position; i++)
            {
                allCardsWE.MoveNext();
            }
            return allCardsWE.Current.GetAttribute("class").Contains("selectedTile");
        }
        //CLAIMS DETAILS SECTION

        public bool NewClaimButtonIsDisabled
        {
            get
            {
                return this.WaitForElementToBeVisible(newClaimButtonLocator).GetAttribute("class").Contains("clickDisabled grey");
            }
        }

        public bool IsNewClaimButtonOnSummaryCard
        {
            get
            {
                try
                {
                    this.WaitForElementToBeVisible(newClaimButtonInsideSummaryCardLocator);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }

        public bool HasNewClaimFormDissapeared
        {
            get
            {
                try
                {
                    this.WaitForElementToDissapear(newClaimFormTitleLocator, 5);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool IsNewClaimFormVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(newClaimFormTitleLocator);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ClaimForm ClickNewClaim()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(selectionTitleLocator));
            this.MoveToViewElement(this.WaitForElementToBeVisible(claimsListSectionTitleLocator));
            //this.WaitForElementToBeVisible(NEW_CLAIM_BUTTON_LOCATOR).Click();
            this.clickNotVisualizedElement(this.WaitForElementToBeVisible(newClaimButtonLocator));
            this.WaitForBlockOverlayToDissapear();
            return new ClaimForm(driver, false);
        }

        public bool IsClaimPresentByClaimNumber(string claimNbr)
        {
            try
            {
                this.WaitForElementToBeVisible(By.XPath(String.Format(claimByNumberLocatorTemplate, claimNbr)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //CLAIM LIST METHODS
        public int GetClaimsCount()
        {
            return this.WaitForElementsToBeVisible(claimListRowLocator).Count;
        }

        public string GetNoResultsMessage()
        {
            return this.WaitForElementToBeVisible(noResultsMessageLocator).Text;
        }

        public bool IsResultsListEmpty()
        {
            try
            {
                //wait only for 10 seconds
                this.WaitForElementToBeVisible(claimListRowLocator, 2);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public List<ClaimData> GetFirstNClaims(int top)
        {
            IReadOnlyCollection<IWebElement> allClaims = this.WaitForElementsToBeVisible(claimListRowLocator);
            List<ClaimData> claims = new List<ClaimData>();

            int count = 0;
            IEnumerator<IWebElement> enumClaims = allClaims.GetEnumerator();
            while ((enumClaims.MoveNext()) && (count < top))
            {
                claims.Add(this.CreateClaimFromWebElement(enumClaims.Current));
                count++;
            }

            return claims;
        }

        private ClaimData CreateClaimFromWebElement(IWebElement claimWE)
        {
            ClaimData claim = new ClaimData();
            //get claim id to replace on id locators
            string claimNumberId = claimWE.FindElement(By.XPath(".//p[contains(@id,'claimNumber-')]")).GetAttribute("id");
            int claimId = Convert.ToInt32(claimNumberId.Replace("claimNumber-", ""));

            //fill 1st row data for the claim
            claim.Id = claimId;
            IWebElement cornerTag = claimWE.FindElement(By.Id(String.Format(cornerTagLoactorByIdTemplate, claimId)));
            claim.CornerTagLetter = cornerTag.Text;
            claim.CornerTagColor = this.GetColorFromColorCode(cornerTag.FindElement(By.TagName("polygon")).GetCssValue("fill"));
            claim.ClaimNumber = claimWE.FindElement(By.Id(String.Format(claimNumberByIdLocatorTemplate, claimId))).Text;
            claim.CreditorName = claimWE.FindElement(By.Id(String.Format(creditorNameByIdLocatorTemplate, claimId))).Text;
            IWebElement status = claimWE.FindElement(By.Id(String.Format(statusLocatorByIdTemplate, claimId)));
            claim.Status = status.Text;
            claim.StatusColor = this.GetColorFromColorCode(status.GetCssValue("color"));

            string classAndCategory = claimWE.FindElement(By.Id(String.Format(classLocatorByIdTemplate, claimId))).Text;
            if (classAndCategory.Contains(","))
            {
                string[] splitted = classAndCategory.Split(',');
                claim.Class = splitted[0].Trim();
                claim.Category = splitted[1].Trim();
            }
            else
            {
                claim.Class = classAndCategory;
                claim.Category = "";
            }

            IWebElement circle = claimWE.FindElement(By.Id(String.Format(classCircleLocatorByIdTemplate, claimId))).FindElement(By.TagName("circle"));
            claim.CircleIndicatorColor = GetColorFromColorCode(circle.GetCssValue("fill"));

            //fill 2nd row data
            claim.CodeLabel = claimWE.FindElement(By.Id(String.Format(codeLabelLocatorByIdTemplate, claimId))).Text;
            claim.Code = claimWE.FindElement(By.Id(String.Format(codeValueLocatorByIdTemplate, claimId))).Text;
            claim.PaySequenceLabel = claimWE.FindElement(By.Id(String.Format(paySeqLabelLocatorByIdTemplate, claimId))).Text;
            claim.PaySequence = claimWE.FindElement(By.Id(String.Format(paySeqValueLocatorByIdTemplate, claimId))).Text;
            claim.ClaimedLabel = claimWE.FindElement(By.Id(String.Format(claimedLabelLocatorByIdTemplate, claimId))).Text;
            claim.Claimed = claimWE.FindElement(By.Id(String.Format(claimedValueLocatorByIdTemplate, claimId))).Text;
            claim.AllowedLabel = claimWE.FindElement(By.Id(String.Format(allowedLabelLocatorByIdTemplate, claimId))).Text;
            claim.Allowed = claimWE.FindElement(By.Id(String.Format(allowedValueLocatorByIdTemplate, claimId))).Text;
            claim.PaidLabel = claimWE.FindElement(By.Id(String.Format(paidlabelLocatorByIdTemplate, claimId))).Text;
            claim.Paid = claimWE.FindElement(By.Id(String.Format(paidValueLocatorByIdTemplate, claimId))).Text;
            claim.ReservedLabel = claimWE.FindElement(By.Id(String.Format(reservedLabelLocatorByIdTemplate, claimId))).Text;
            claim.Reserved = claimWE.FindElement(By.Id(String.Format(reservedValueLocatorByIdTemplate, claimId))).Text;
            claim.InterestLabel = claimWE.FindElement(By.Id(String.Format(interestLabelLocatorByIdTemplate, claimId))).Text;
            claim.Interest = claimWE.FindElement(By.Id(String.Format(interestValueLocatorByIdTemplate, claimId))).Text;
            claim.BalanceLabel = claimWE.FindElement(By.XPath(String.Format(balanceLabelLocatorByIdTemplate, claimId))).Text;
            claim.Balance = claimWE.FindElement(By.XPath(String.Format(balanceValueLocatorByIdTemplate, claimId))).Text;

            //return claim data
            return claim;
        }

        public bool IsFirstSummaryCardSelected()
        {
            return this.WaitForElementToBeVisible(claimSummaryItemLocator).GetAttribute("class").Contains("selectedTile");
        }

        public ClaimForm ClickOnEditClaimByClaimNumber(string claimNbr)
        {
            //locate and click on edit button
            IWebElement claimNumberBox = this.WaitForElementToBeVisible(By.XPath(String.Format(claimByNumberLocatorTemplate, claimNbr)));
            string claimId = claimNumberBox.GetAttribute("id").Replace("claimNumber-", "");
            this.MoveToViewElement(this.WaitForElementToBeVisible(By.XPath(String.Format(balanceValueLocatorByIdTemplate, claimId))));
            this.MoveToViewElement(this.WaitForElementToBeVisible(By.Id(String.Format(statusLocatorByIdTemplate, claimId))));
            this.WaitForElementToBeVisible(By.XPath(String.Format(editButtonByClaimIdLocatorTemplate, claimId))).Click();

            //wait for block overlay to dissapear
            this.WaitForBlockOverlayToDissapear();

            //return edition form
            return new ClaimForm(driver, true);

        }

        public string GetClaimIdByClaimNumber(string claimNbr)
        {
            IWebElement claimNbrBox = this.WaitForElementToBeVisible(By.XPath(String.Format(claimByNumberLocatorTemplate, claimNbr)));
            return claimNbrBox.GetAttribute("id").Replace("claimNumber-", "");
        }
        public string GetClaimsMangementHeader()
        {
            return this.WaitForElementToBePresent(claimsManagementHeader).Text;
        }

        public bool GetClaimsNavigation()
        {
            return this.WaitForElementToBePresent(navigation).Displayed;
        }

        public bool IsOpenClaimForm()
        {
            try
            {
                this.WaitForElementToBeVisible(newClaimFormTitleLocator, 5);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string GetPageCount()
        {
            return this.WaitForElementToBeVisible(pageCount).Text;
        }
        public Dictionary<string, object> GetPagination()
        {
            var dict = new Dictionary<string, object>();
            dict.Add("Pagination", this.WaitForElementToBeVisible(pagination).Displayed);
            dict.Add("ActivePage", this.WaitForElementToBeVisible(activePage).Text);
            return dict;
        }
        public DataTable GetClaimRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";

            if (!string.IsNullOrEmpty(SortColumn))
            {
                driver.FindElements(headerNames).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();
                driver.FindElements(headerNames).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();
            }
            var headerNames1 = driver.FindElements(headerNames).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames1.Count - 1; i++)
            {
                htmlTable.Columns.Add(headerNames1[i]);
                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, headerNames1[i])), 10);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpath, headerNames1[i])));
                    this.Pause(4);
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames1[i]}']")); }
                }
                catch
                {
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames1[i]}']"));
                }

                var testList = rows.Select(e => e.Text.Trim()).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) { htmlTable.Rows[j][i] = testList[j]; }
                    else { htmlTable.Rows.Add(testList[j]); }
                }
            }
            return htmlTable;
        }

        public List<string> GetSortedList(string columnName)
        {
            List<string> list = new List<string>();
            var Table = GetClaimRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add(Table.Rows[i][index].ToString());
            }
            return list;
        }

        public void ClickFilterButton()
        {
            this.WaitForElementToBeClickeable(filterButton).Click();
        }

        public void EnterCreditor(string creditor)
        {
            this.WaitForElementToBeVisible(claimCreditorr).SendKeys(creditor);
            Thread.Sleep(2000);
        }
        public void ArrowIcon()
        {
            this.WaitForElementToBeVisible(arrowIcon).Click();
        }
        public void SelectClass(string claimClass)
        {
            Thread.Sleep(2000);
            this.WaitForElementToBeVisible(claimClas).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(claimFilterSelect, claimClass))).Click();
        }

        public void SelectClaimStatus(string claimStatus)
        {
            this.WaitForElementToBeVisible(claimsClassStatus).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(claimFilterSelect, claimStatus))).Click();
        }

        public void EnterBalanceFrom(string balanceFrom)
        {
            this.WaitForElementToBeVisible(this.balanceFrom).SendKeys(balanceFrom);
        }

        public void EnterBalanceTo(string balanceTo)
        {
            this.WaitForElementToBeVisible(balanceToo).SendKeys(balanceTo);
        }

        public void SelectCaseStatus(string status)
        {
            this.WaitForElementToBeVisible(claimCaseStatus).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(claimFilterSelect, status))).Click();
        }

        public void ClickOnCloseButton()
        {
            this.WaitForElementToBeVisible(claimCloseButton,2).Click();
            this.Pause(4);
        }

        public void ClickOnResetButton()
        {
            this.Pause(1);
            this.WaitForElementToBeVisible(claimResetButton).Click();
        }

        public List<string> GetRecordsByColumnName(string ColumnName, string value = null)
        {
            IList<IWebElement> rows = null;
            List<string> lists = new List<string>();
            ColumnName = ColumnName.ToUpper();
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";
            try
            {
                this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, ColumnName)), 8);
                rows = driver.FindElements(By.XPath(string.Format(rowXpath, ColumnName)));
                if (rows.Count == 0)
                {
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']"));
                }
            }
            catch
            {
                rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']"));
            }
            lists = rows.Select(e => e.Text.Trim()).ToList();

            // To verify the value exist in the respective column 
            if (!string.IsNullOrWhiteSpace(value))
            {
                bool found = false;
                foreach (string list in lists)
                {
                    found = list.Contains(value);
                    if (found) break;
                }
                found.Should().BeTrue();
            }
            return lists;
        }

        public void ClickClassX()
        {
            this.WaitForElementToBeVisible(claimClassX).Click();
        }
        public void ClickClassStatusX()
        {
            this.WaitForElementToBeVisible(claimClassStatusX).Click();
        }
        public void ClickCaseStatusX()
        {
            this.WaitForElementToBeVisible(claimCaseStatusX).Click();
        }

        public string GetValidToPay(int i = 1)
        {
            this.WaitForElementToBeVisible(By.XPath(string.Format(expandRecord, i.ToString()))).Click();
            var text = this.WaitForElementToBeVisible(claimValidPay).Text;
            this.WaitForElementToBeVisible(By.XPath(string.Format(expandRecord, i.ToString()))).Click();
            return text;
        }
        public void AddClaimClick()
        {
            WaitForElementToBePresent(addClaim).Click();
        }
        public void subheaderverify(string subheader)
        {           
                string message = driver.FindElement(subHeader).Text;
                Assert.AreEqual(message.Trim(), subheader.Trim());
        }
        public void VerifyGridBeforeCount()
        {
            Thread.Sleep(2000);
            string bcountvalue = WaitForElementToBePresent(caseLevelClaimsCount).Text;
            beforeCount = int.Parse(bcountvalue);                     
        }
        public void VerifyGridAfterCount()
        {
            Thread.Sleep(2000);
            var acountvalue = WaitForElementToBePresent(caseLevelClaimsCount,5).Text;
            afterCount = int.Parse(acountvalue);
            Thread.Sleep(2000);                         
            Assert.AreEqual(beforeCount+1, afterCount);

        }
        public void CaseDebtorfields(List<string> inputs)
        {
            foreach (string input in inputs)
            {
                int separator = input.IndexOf('@');
                string parameter = input.Substring(0, separator);
                string value = input.Substring(separator + 1);               
                By xpath = By.XPath($"//div[label[text()='{parameter}']]//input[not(@aria-hidden='true')] | //div[label[text()='State / Province']]//following-sibling::div//input | //div[label[text()='{parameter}']]//textarea[not(@aria-hidden='true')]");            
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 4);                   
                    if (control.Text.Contains("0.00") || GetAttrubuteValue(control, "type").Contains("text"))
                    {
                        control.Clear();
                        control.SendKeys(value);
                        Thread.Sleep(2000);
                        if (parameter.Contains("CASE #") || parameter.Contains("SEARCH CLAIM"))
                        {
                            this.WaitForElementToBePresent(By.CssSelector("li[class] a[class='dropdown-item']"), 4);
                            control.SendKeys(Keys.ArrowDown);
                            control.SendKeys(Keys.Enter);
                            Thread.Sleep(1000);
                        }
                    }
                    else if (GetAttrubuteValue(control, "type").Contains("checkbox"))
                    {
                        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();",control);
                        Thread.Sleep(1000);
                    }
                        
                    else
                    {
                        SelectCustomList(control, value);
                        Thread.Sleep(1000);
                    }

                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        public void EnterStateValue(string state)
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='row']//div[label[text()='State / Province']]/div/div/input")).SendKeys(state);
        //    this.Pause(3);
        //    ScrollWindowBy(952, 960);
        //    var states = driver.FindElement(By.XPath($"//div[@class='Select-control']/div/div[text()='{state}']"));
        //    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", states);
        //    states.Click();
        }
        private void SelectCustomList(IWebElement control, string value)
        {
            ScrollDown();
            MoveToViewElement(control);
            Thread.Sleep(2000);
            try
            {
                var a = (control.FindElement(By.XPath(".."))).FindElement(By.XPath(".."));
                if (a.TagName.ToString().Contains("span"))
                    a.FindElement(By.XPath("..")).Click();
                a.Click();
                Thread.Sleep(2000);
                this.WaitForElementToBePresent(By.XPath($"//div[text()='{value}']"), 2).Click();
                
            }
            catch (Exception e)
            {
                JSMoveToViewElement(control);
                MoveToViewElement(control);
                control.SendKeys(Keys.Enter);
                driver.FindElement(By.XPath($"//div[text()='{value}']")).Click();
                Thread.Sleep(1000);
            }

        }       
        public void SelectParticipant(string particpanttype)
        {
            IList<IWebElement> participantoptions = driver.FindElements(By.XPath("//span[contains(@class,'has-text')]"));

            foreach (IWebElement option in participantoptions)
            {
                if ((option.Text).Equals(particpanttype))
                {                   
                    JavaScriptClick(option);
                    this.Pause(3);
                    break;
                }
            }
        }
        public void Saveclaim()
        {
            Thread.Sleep(3000);                
            WaitForElementToBePresent(save,2).Click();               
            
        }
        public void ClickButton(string label)
        {
            this.Pause(2);
            WaitForElementToBePresent(By.XPath("//button[@class='btn btn-default'][text()='CLOSE']")).Click();
        }
        public void ClickOnEditClaim()
        {
            WaitForElementToBePresent(editClaim).Click();
            this.Pause(3);
        }
        public void ClickOnDeleteClaim()
        {
            var select = WaitForElementToBePresent(Delete_Document);
            JavaScriptClick(select);
            this.Pause(3);
        }
      
        public void InputDisplayName(string displayname)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            string actualname = displayname;
            string name = actualname + date;
            WaitForElementToBePresent(displayName).SendKeys(name);
        }
        public void VerifyClaimsInLineEdit(string header, string text)
        {
            WaitForElementToBeClickeable(expandRow,4).Click();
            var value = WaitForElementToBeVisible(By.XPath($"//td[@data-title='{header}']//button"), 2).Text;
            Assert.AreEqual(value, text);
            WaitForElementToBeClickeable(expandRow, 4).Click();
        }
        public void InLineEditViewOnly()
        {
            Assert.False(IsElementVisible(claimedLocator));
            Assert.False(IsElementVisible(allowedLocator));
            WaitForElementToBeClickeable(expandRow, 4).Click();
            Assert.False(IsElementVisible(claimNumLocator));
            Assert.False(IsElementVisible(categoryLocator));
            Assert.False(IsElementVisible(sequenceLocator));
            Assert.False(IsElementVisible(scheduledLocator));
            Assert.False(IsElementVisible(reservedLocator));
        }
        public void VerifyPageHeader(string header)
        {
            string actualHeader = WaitForElementToBePresent(By.XPath("//div[@class='epiq-page-header  ']/h2"), 2).Text;
            Assert.AreEqual(actualHeader.Trim(), header.Trim());
        }
        public bool ScheduleToClaimManagementBreadcrumb()
        {
            return this.WaitForElementToBeVisible(scheduleToClaimReconciliationBreadcrumb).Displayed;
        }
        public void VerifyFieldsInSCheduleToClaimManagementPage(string casenum, string debt, string claim, string schedule, string unreconciled, string status, string casestatus)
        {
            var caseno = WaitForElementToBeVisible(caseNumber).Text;
            Assert.IsTrue(casenum.Equals(caseno, StringComparison.OrdinalIgnoreCase));

            var debtor = WaitForElementToBeVisible(debtorData).Text;
            Assert.IsTrue(debt.Equals(debtor, StringComparison.OrdinalIgnoreCase));

            var claimcount = WaitForElementToBeVisible(claimData).Text;
            Assert.IsTrue(claim.Equals(claimcount, StringComparison.OrdinalIgnoreCase));

            var schedulecount = WaitForElementToBeVisible(scheduleData).Text;
            Assert.IsTrue(schedule.Equals(schedulecount, StringComparison.OrdinalIgnoreCase));

            var unreconciledcount = WaitForElementToBeVisible(unreconciledData).Text;
            Assert.IsTrue(unreconciled.Equals(unreconciledcount, StringComparison.OrdinalIgnoreCase));

            var assetstatus = WaitForElementToBeVisible(statusClaim).Text;
            Assert.IsTrue(status.Equals(assetstatus, StringComparison.OrdinalIgnoreCase));

            var casesText = WaitForElementToBeVisible(cases).Text;
            Assert.IsTrue(casestatus.Equals(casesText, StringComparison.OrdinalIgnoreCase));
        }

        public void VerifyScheduleToClaimManagementPageUICount()
        {
            try
            {
                uiValuesClaim = new List<int>();
                uiValuesSchedule = new List<int>();
                uiValuesUnreconciled = new List<int>();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                var claimcount = driver.FindElements(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[1]//td[4]"));
                var Schedulecount = driver.FindElements(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[1]//td[5]"));
                var Unreconciledcount = driver.FindElements(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[1]//td[6]"));
                for (int count = 0; count < claimcount.Count; count++)
                {
                    var UIClaimCount = int.Parse(claimcount[count].Text);
                    uiValuesClaim.Add(UIClaimCount);
                }
                for (int scount = 0; scount < Schedulecount.Count; scount++)
                {
                    var UIScheduleCount = int.Parse(Schedulecount[scount].Text);
                    uiValuesSchedule.Add(UIScheduleCount);
                }
                for (int ucount = 0; ucount < Unreconciledcount.Count; ucount++)
                {
                    var UIUnreconciledCount = int.Parse(Unreconciledcount[ucount].Text);
                    uiValuesUnreconciled.Add(UIUnreconciledCount);
                }
            }

            catch { }

        }

        public void VerifyScheduleToClaimManagementPageDBCount()
        {
            this.Pause(6);
            IList<IWebElement> rows = driver.FindElements(scheduleToClaimRows);
            IWebElement Casenum = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[1]//td[2]"));
            string CaseNumber = Casenum.Text;
            DataTable results = new DataTable();
            List<int> dbValuesClaim = new List<int>();
            List<int> dbValuesSchedule = new List<int>();
            List<int> dbValuesUnreconciled = new List<int>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {

                SqlCommand command = new SqlCommand(@"SELECT DISTINCT c.caseid, c.CoreCaseNumber , d.DebtorSortName, ISNULL(caseClaimCount, 0) AS ClaimsCount
				, CASE WHEN c.scheduleformstypeid = 1 THEN ISNULL(s.caseSchedulecount,0)
					   WHEN c.scheduleformstypeid = 2 THEN ISNULL(sng.caseSchedulecount,0)
					   ELSE 0 
					END AS SchedulesCount
				, CASE WHEN c.scheduleformstypeid = 1 THEN ISNULL(sc.caseUnReconciledCnt, 0) 
					   WHEN c.scheduleformstypeid = 2 THEN ISNULL(scng.caseUnReconciledCnt, 0)
					   ELSE 0
					END AS UnReconciledClaimsCount
				, CASE WHEN c.scheduleformstypeid = 1 THEN ISNULL(sc.caseReconciledCnt, 0) 
					   WHEN c.scheduleformstypeid = 2 THEN ISNULL(scng.caseReconciledCnt, 0)
					   ELSE 0
					END AS ReconciledClaimsCount
				, ast.assetstatus , cs.CaseStatus , c.scheduleformstypeid  FROM dbo.[case] c 
				INNER JOIN tcms.vw_VisibleCases vc WITH (NOEXPAND) ON vc.CaseId = c.CaseId 
				INNER JOIN dbo.casestatus cs ON cs.casestatusid = c.CaseStatusId
				INNER JOIN dbo.assetstatus ast ON ast.AssetStatusId = c.AssetStatusId
			    INNER JOIN dbo.vw_ParticipationMap_Debtor d WITH (NOEXPAND) ON d.caseid = c.CaseId
				INNER JOIN (SELECT  cl1.caseid , COUNT(*) AS caseClaimCount FROM dbo.claim cl1 
				INNER JOIN 	dbo.[case] c1 ON c1.caseid = cl1.caseid AND c1.officeid = 215 AND c1.isdeleted = 0
				 WHERE cl1.IsDeleted = 0 AND cl1.importclasstypeid in (2,3,4)
				 GROUP BY cl1.caseid
				) cl on cl.caseid = c.caseid
		       LEFT OUTER JOIN
				(SELECT sh2.caseid , COUNT(*) as caseSchedulecount  FROM dbo.schedule s2
				 INNER JOIN dbo.scheduleheader sh2 on sh2.scheduleheaderid = s2.scheduleheaderid
				 INNER JOIN dbo.[case] c2 ON c2.caseid = sh2.caseid AND c2.officeid = 215 AND c2.scheduleformstypeid = 1 AND c2.isdeleted = 0
				 WHERE s2.IsDeleted = 0 AND s2.scheduletypeid IN (4,6,7) AND sh2.officeid = 215
				 GROUP BY	sh2.caseid) s on s.CaseId = c.caseid
		        LEFT OUTER JOIN
				(
				SELECT 	sh3.caseid , COUNT(*) as caseSchedulecount FROM dbo.schedulenextgen s3
				 INNER JOIN dbo.scheduleheadernextgen sh3 on sh3.scheduleheadernextgenid = s3.scheduleheadernextgenid
				 INNER JOIN dbo.[case] c3 ON c3.caseid = sh3.caseid AND c3.officeid = 215 AND c3.scheduleformstypeid = 2 AND c3.isdeleted = 0
				 WHERE 	s3.IsDeleted = 0 AND s3.scheduletypenextgenid IN (3,4,10,11) AND sh3.officeid = 215
				 GROUP BY sh3.caseid) sng on sng.CaseId = c.caseid
		         LEFT OUTER JOIN
				(
				SELECT 	cl4.caseid, SUM(CASE WHEN sc4.claimid IS NULL OR S4.ScheduleId IS NULL THEN 1 ELSE 0 END) AS caseUnReconciledCnt
					, SUM(CASE WHEN sc4.claimid IS NOT NULL AND S4.ScheduleId IS NOT NULL THEN 1 ELSE 0 END) AS caseReconciledCnt
				FROM dbo.claim cl4 
				INNER JOIN 	dbo.[case] c4 ON c4.caseid = cl4.caseid AND c4.officeid = 215 AND c4.scheduleformstypeid = 1 AND c4.isdeleted = 0
				LEFT OUTER JOIN dbo.ScheduleClaim sc4 ON sc4.claimid = cl4.claimid AND sc4.caseid = cl4.caseid
				LEFT OUTER JOIN dbo.schedule s4 on s4.scheduleid = sc4.scheduleid AND s4.isdeleted = 0 AND s4.scheduletypeid IN (4,6,7) 
				WHERE cl4.isdeleted = 0 AND cl4.importclasstypeid in (2,3,4) 
				GROUP BY cl4.caseid) sc on sc.caseid = c.caseid
		        LEFT OUTER JOIN
				(
				SELECT cl5.caseid, SUM(CASE WHEN sc5.claimid IS NULL OR s5.ScheduleNextGenId IS NULL THEN 1 ELSE 0 END) AS caseUnReconciledCnt
					, SUM(CASE WHEN sc5.claimid IS NOT NULL AND s5.ScheduleNextGenId IS NOT NULL THEN 1 ELSE 0 END) AS caseReconciledCnt
					FROM dbo.claim cl5
					INNER JOIN 	dbo.[case] c5 ON c5.caseid = cl5.caseid  AND c5.officeid = 215 AND c5.scheduleformstypeid = 2 AND	c5.isdeleted = 0
					LEFT OUTER JOIN dbo.ScheduleNextGenClaim sc5 ON sc5.claimid = cl5.claimid AND sc5.caseid = cl5.caseid
					LEFT OUTER JOIN dbo.scheduleNextGen s5 on s5.scheduleNextGenid = sc5.scheduleNextGenid AND s5.isdeleted = 0 AND s5.scheduletypenextgenid IN (3,4,10,11) 
					WHERE cl5.isdeleted = 0	AND cl5.importclasstypeid in (2,3,4) 
					GROUP BY cl5.caseid) scng on scng.caseid = c.caseid
		         WHERE   c.isdeleted = 0 AND c.officeid = 215 AND c.CoreCaseNumber='" + CaseNumber + @"' ;", connection);
                this.Pause(10);
                connection.Open();
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                var totalCount = dataAdapter.Fill(results);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    for (int counter = 0; counter <= totalCount; counter++)
                        if (reader.Read())
                        {
                            int countClaim = (int)reader["ClaimsCount"];
                            dbValuesClaim.Add(countClaim);

                            int countSchedule = (int)reader["SchedulesCount"];
                            dbValuesSchedule.Add(countSchedule);

                            int countUnreconciled = (int)reader["UnReconciledClaimsCount"];
                            dbValuesUnreconciled.Add(countUnreconciled);

                        }
                }
                Assert.IsTrue(uiValuesClaim.SequenceEqual(dbValuesClaim));//linq method to compare two list values
                Assert.IsTrue(uiValuesSchedule.SequenceEqual(dbValuesSchedule));
                Assert.IsTrue(uiValuesUnreconciled.SequenceEqual(dbValuesUnreconciled));

            }
        }
        public void ClickOnFilterInScheduleToClaimReconciliationPage()
        {
            this.WaitForElementToBeClickeable(filterScheduleToClaimReconciliation).Click();
        }
        public void VerifyDefaultDataInFilterOptions(string allclaimsreconcile, string asset, string cstatus)
        {
            this.Pause(3);
            IWebElement allclaimsrecon = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[1]"));
            string allclaimsreconciled = allclaimsrecon.Text;
            Assert.AreEqual(allclaimsreconciled, allclaimsreconcile);

            IWebElement astatus = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[2]"));
            string assetstatus = astatus.Text;
            Assert.AreEqual(assetstatus, asset);

            IWebElement cases = driver.FindElement(By.XPath("(//div[@class='Select-value']/span[@class='Select-value-label'])[3]"));
            string casestatus = cases.Text;
            Assert.AreEqual(casestatus, cstatus);

            this.WaitForElementToBeClickeable(filterClose).Click();
        }
        public void VerifyDataInFilterOptions()
        {
            //Verifying data in Filter option ALL CLAIMS RECONCILED
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterScheduleToClaimReconciliation).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterReconciled).Click();
            string[] UIAllClaimsReconciledValues = { "", "Yes", "No" };
            IList<IWebElement> ReconciledRows = driver.FindElements(filterReconciledValues);
            int ReconciledRowCount = ReconciledRows.Count;
            for (int reconciledrow = 1; reconciledrow <= ReconciledRowCount; reconciledrow++)
            {
                this.Pause(3);
                IWebElement AllClaimsReconciledValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + reconciledrow + "]"));
                string AllClaimsReconciledData = AllClaimsReconciledValues.Text;
                string UIAllClaimsReconciledData = UIAllClaimsReconciledValues[reconciledrow];
                Assert.IsTrue(UIAllClaimsReconciledData.Equals(AllClaimsReconciledData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeClickeable(filterClose).Click();
            //Verifying data in Filter option ASSET STATUS
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterScheduleToClaimReconciliation).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterAsset).Click();
            string[] UIAssetStatusValues = { "", "All", "Asset", "No Asset" };
            IList<IWebElement> AssetRows = driver.FindElements(filterAssetValues);
            int AssetRowCount = AssetRows.Count;
            for (int assetrow = 1; assetrow <= AssetRowCount; assetrow++)
            {
                this.Pause(3);
                IWebElement AssetStatusValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + assetrow + "]"));
                string AssetStatusData = AssetStatusValues.Text;
                string UIAssetStatusData = UIAssetStatusValues[assetrow];
                Assert.IsTrue(UIAssetStatusData.Equals(AssetStatusData, StringComparison.OrdinalIgnoreCase));
            }
            this.WaitForElementToBeVisible(filterAsset).Click();
            this.WaitForElementToBeClickeable(filterClose).Click();
            //Verifying data in Filter option CASE STATUS
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterScheduleToClaimReconciliation).Click();
            this.Pause(3);
            this.WaitForElementToBeVisible(filterCase).Click();
            string[] UICaseStatusValues = { "", "All", "Open", "Closed" };
            IList<IWebElement> CaseRows = driver.FindElements(filterCaseValues);
            int CaseRowCount = CaseRows.Count;
            for (int caserow = 1; caserow <= CaseRowCount; caserow++)
            {
                this.Pause(3);
                IWebElement CaseStatusValues = driver.FindElement(By.XPath("//div[@class='Select-menu-outer']/div[@class='Select-menu']/div[" + caserow + "]"));
                string CaseStatusData = CaseStatusValues.Text;
                string UICaseStatusData = UICaseStatusValues[caserow];
                Assert.IsTrue(UICaseStatusData.Equals(CaseStatusData, StringComparison.OrdinalIgnoreCase));
            }
        }
        public void FilterOptions(string allclaimsreconcile, string asset, string cstatus)
        {
            this.WaitForElementToBeVisible(filterReconciled).Click();
            var SelectReconcile = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{allclaimsreconcile}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectReconcile);
            this.Pause(1);
            SelectReconcile.Click();

            this.WaitForElementToBeVisible(filterAsset).Click();
            var SelectAsset = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{asset}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectAsset);
            this.Pause(1);
            SelectAsset.Click();

            this.WaitForElementToBeVisible(filterCase).Click();
            var SelectCase = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{cstatus}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectCase);
            this.Pause(1);
            SelectCase.Click();
        }

        public void VerifyTableHeaderReconciled(string allclaimsreconcile)
        {
            IWebElement Reconciled = driver.FindElement(By.XPath("//div[@class='epiq-page-body']//tr/th[6]"));
            string UIReconciled = Reconciled.Text;
            Assert.AreEqual("RECONCILED", UIReconciled);
        }
        public void VerifyTableHeaderUnReconciled(string allclaimsreconcile)
        {
            this.WaitForElementToBeVisible(filterReconciled).Click();
            var SelectReconcile = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='{allclaimsreconcile}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectReconcile);
            this.Pause(1);
            SelectReconcile.Click();
            this.Pause(3);
            IWebElement UnReconciled = driver.FindElement(By.XPath("//div[@class='epiq-page-body']//tr/th[6]"));
            string UIUnReconciled = UnReconciled.Text;
            Assert.AreEqual("UNRECONCILED", UIUnReconciled);
            this.WaitForElementToBeClickeable(filterClose).Click();

        }
        public void VerifyMessageInTheGrid(string message)
        {
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterScheduleToClaimReconciliation).Click();

            this.WaitForElementToBeVisible(filterReconciled).Click();
            var SelectReconcile = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='Yes']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectReconcile);
            this.Pause(1);
            SelectReconcile.Click();

            this.WaitForElementToBeVisible(filterAsset).Click();
            var SelectAsset = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='No Asset']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectAsset);
            this.Pause(1);
            SelectAsset.Click();

            this.WaitForElementToBeVisible(filterCase).Click();
            var SelectCase = driver.FindElement(By.XPath($"//div[@class='Select-menu-outer']/div/div[text()='Closed']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SelectCase);
            this.Pause(1);
            SelectCase.Click();
            this.Pause(5);
            IWebElement NoResultsMessage = driver.FindElement(By.XPath($"//div[text()='{message}']"));
            string UIMessage = NoResultsMessage.Text;
            Assert.AreEqual(UIMessage, "No results to display per selections");
        }

        public void ClickResetInFilter()
        {
            this.WaitForElementToBeClickeable(filterReset).Click();
            this.WaitForElementToBeClickeable(filterClose).Click();
        }
        public void VerifyMessageForAllCases(string message)
        {
            IWebElement MessageForAllCases = driver.FindElement(By.XPath($"//div[text()='{message}']"));
            string UIMessage = MessageForAllCases.Text;
            Assert.AreEqual(UIMessage, "Please contact your Office Administrator and request permission to view this content. You are missing one of the following permissions: Schedules Reconcile");

        }
        public void ClickOnUnreconciledLink(string casenum)
        {
            this.Pause(4);
            IList<IWebElement> rows = driver.FindElements(claimsRows);
            int ScheduleRows = rows.Count;
            bool isFound = false;
            for (int row = 1; row <= ScheduleRows; row++)
            {
                IWebElement CaseNumber = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[2]"));
                string CaseNo = CaseNumber.Text;
                if (CaseNo == casenum)
                {
                    var Unreconciled = WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + row + "]/td[6]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", Unreconciled);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);

        }

        public void SelectDocument()
        {
            Thread.Sleep(2000);
            var selectDocument = WaitForElementToBeClickeable(document, 3);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", selectDocument);
        }




        public void ClickDocumentView()
        {
            WaitForElementToBeClickeable(documentView).Click();
        }
        public void VerifyDocumentDetails(string documentDetails)
        {
            var documentText = WaitForElementToBeVisible(documentName).Text;
            Assert.IsTrue(documentText.Contains(documentDetails));
        }

        public void SelectSchedulesInClaimReconciliationPage()
        {
            WaitForElementToBeClickeable(scheduleLink).Click();

        }
        public void VerifySchedulesLinkButtonAndXButton()
        {
            var creditorInSchedules = WaitForElementToBeVisible(scheduleCreditor).Text;
            var creditorInSchedulesAtBottomOfScreen = WaitForElementToBeVisible(scheduleCreditorAtBottomOfScreen).Text;
            Assert.IsTrue(creditorInSchedules.Equals(creditorInSchedulesAtBottomOfScreen, StringComparison.OrdinalIgnoreCase));
            bool scheduleLinkButton = driver.FindElement(By.XPath("//button[text()='LINK']")).Displayed;
            Assert.IsTrue(scheduleLinkButton);
            WaitForElementToBeClickeable(XButton).Click();

        }
        public void SelectClaimsInClaimReconciliationPage()
        {
            WaitForElementToBeClickeable(claimLink).Click();
        }
        public void VerifyClaimsLinkButtonAndXButton()
        {
            var creditorInClaims = WaitForElementToBeVisible(claimCreditor).Text;
            var creditorInClaimsAtBottomOfScreen = WaitForElementToBeVisible(claimsCreditorAtBottomOfScreen).Text;
            Assert.IsTrue(creditorInClaims.Contains(creditorInClaimsAtBottomOfScreen));
            bool claimLinkButton = driver.FindElement(By.XPath("//button[text()='LINK']")).Displayed;
            Assert.IsTrue(claimLinkButton);
            WaitForElementToBeClickeable(XButton).Click();
        }
        public void SelectScheduleAndClaim()
        {
            WaitForElementToBeClickeable(scheduleLink).Click();
            WaitForElementToBeClickeable(claimLink).Click();
        }
        public void ClickLinkButtonInClaimReconciliationPage()
        {
            this.Pause(3);
            WaitForElementToBeClickeable(linkButton).Click();
        }
        public void ClickUnlinkButtonInClaimReconciliationPage()
        {
            this.Pause(3);
            WaitForElementToBeClickeable(scheduleLink).Click();
            this.Pause(3);
            WaitForElementToBeClickeable(unlinkButton).Click();
        }
        public void VerifyColumnsInTransactionsLinkedToClaimPage(int colStartIndex, int colEndIndex, List<string> inputs, string page)
        {
            List<string> columnNames = new List<string>();
            for (int colIndex = colStartIndex; colIndex <= colEndIndex; colIndex++)
            {
                var columnName = WaitForElementToBePresent(By.XPath("//div[@class='" + page + "']//table//thead//tr//th[" + colIndex + "]"), 3).Text;
                columnNames.Add(columnName);
            }
            Assert.IsTrue(inputs.SequenceEqual(columnNames));
            this.Pause(3);
            
        }
        public void ClickOnLinkButtonInLinkCaseDocumentsPage()
        {
            Thread.Sleep(2000);
            WaitForElementToBeClickeable(linkButtonInLinkCaseDocuments).Click();

        }
                
    }

    }

