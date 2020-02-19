using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Assets;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail;
using OpenQA.Selenium.Interactions;
using System.Data;
using System.Linq;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Assets;
using FluentAssertions;
using System.Threading;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class AssetsDetailTab : CaseDetailPage
    {
        private By assetListRow = By.CssSelector("li.assetListItem");
        private By noResultsMessage = By.Id("assetNoResultsMessage");

        private By assetsSummaryCardTitle = By.Id("assetSummaryTitle");
        private By assetsSelectionSummaryTitle = By.Id("assetMenuTitle");
        private By newAssetButton = By.Id("navItem-New");
        private By quickEditButton = By.XPath("//div[contains(@class,'quickEditMenu')]/a");
        private By newAssetFormTitle = By.Id("newAssetTitle");

        //top region
        private string assetCornerTagByIdTemplate = "assetCornerTag-{0}";
        private string assetNameByIdTemplate = "assetName{0}";
        private string assetFaDateLabelByIdTemplate = "assetFADateLabel{0}";

        private string assetFaDateByIdTemplate = "assetFADate{0}";
        private string assetTypeByIdTemplate = "assetType{0}";
        private string assetValueTypeByIdTemplate = "assetTrusteeValueName{0}";

        //left region
        private string assetCodeLabelByIdTemplate = "assetCodeLabel{0}";
        private string assetCodeByIdTemplate = "assetCodeValue{0}";

        //center region
        private string assetPetitionPositionByIdTemplate = "assetPetitionPosition{0}";
        private string assetPetitionLabelByIdTemplate = "assetPetitionLabel{0}";

        private string assetPetitionByIdTemplate = "assetPetitionValue{0}";

        private string assetNetValuePositionByIdTemplate = "assetNetPosition{0}";
        private string assetNetValueLabelByIdTemplate = "assetNetLabel{0}";
        private string assetNetvalueByIdTemplate = "assetNetValue{0}";

        private string assetAbandonedPositionByIdTemplate = "assetAbandonedPosition{0}";
        private string assetAbandonedLabelByIdTemplate = "assetAbandonedLabel{0}";

        private string assetAbandonedByIdTemplate = "assetAbandonedValue{0}";

        private string assetSalesPositionByIdTemplate = "assetSalesPosition{0}";
        private string assetSalesLabelByIdTemplate = "assetSalesLabel{0}";
        private string assetSalesByIdTemplate = "assetSalesValue{0}";

        private string assetRemainingPositionByIdTemplate = "assetRemainingPosition{0}";
        private string assetRemainingLabelByIdTemplate = "assetRemainingLabel{0}";
        private string assetRemainingByIdTemplate = "assetRemainingValue{0}";


        //right region
        private string assetTrusteeLabelByIdTemplate = "assetTrusteeLabel{0}";
        private string assetTrusteeByIdTemplate = "assetTrusteeValue{0}";
        private string assetLiensLabelByIdTemplate = "assetLiensLabel{0}";
        private string assetLiensByIdTemplate = "assetLiensValue{0}";
        private string assetExemptionsLabelByIdTemplate = "assetExemtionsLabel{0}";
        private string assetExemptionsByIdTemplate = "assetExemtionsValue{0}";

        //bottom region
        private string assetForm1NoteLabelByIdTemplate = "assetDescriptionLabel{0}";
        private string assetForm1NoteByIdTemplate = "assetDescriptionValue{0}";
        private By assetSummaryItem = By.CssSelector("article.claimSummaryItem");
        private By assetSummaryItemTitle = By.CssSelector("article.claimSummaryItem > header > h1");
        private By selectionDetailAssetsCount = By.Id("totalAssetsCount");
        private By selectionCardSelectedTitle = By.Id("assetTileName");
        private By assetsListTitle = By.Id("Title");
        private By assetsFirstCodeLabel = By.XPath("//label[contains(@id,'assetCodeLabel')]");
        private By newAssetCancelButton = By.Id("cancelNewAsset");
        private By newAssetLiens = By.Id("assetLiens");
        private By trusteeLabelFirstAssetOnList = By.XPath("//*[contains(@id,'assetTrusteeLabel')]");

        private By petitionInlineEdit = By.XPath("//tbody/tr[1]/td[7]/div/button");
        private By fieldPresent = By.XPath("//div[contains(@class,'form-group')]/span/input");
        private By inputFieldValue = By.XPath("//div[contains(@class,'form-group')]/span/div/input");
        private By saveField = By.XPath("//button[@type='submit']");
        private By cancelField = By.XPath("//button[@class='btn btn-default']");
        private By trusteeInlineEdit = By.XPath("//tbody/tr[1]/td[8]/div/button");
        private By exemptionInlineEdit = By.XPath("//tbody/tr[1]/td[9]/div/button");
        private By expandRow = By.XPath("//tr[1]/td[1]/div/i");
        private By faInlineedit = By.XPath("//div[div[text()='FA']]/div/div/button");
        private By abandonedInlineEdit = By.XPath("//div[div[text()='ABANDONED']]/div/div/button");
        private By abandonedDropdown = By.XPath("//form/div[1]/div/div/div/div//span/div//input");
        private By ownedInlineEdit = By.XPath("//div[div[text()='OWNED']]/div/div/button");
        private By reservedNotesInlineEdit = By.XPath("//div[div[text()='RESERVED NOTE']]/div/div/button");
        private By reservedTextArea = By.XPath("//div[@class='form-group']/textarea");
        private By reservedInlineEdit = By.XPath("//div[div[text()='RESERVED']]/div/div/button");
        private By faText = By.XPath("//div[div[text()='FA']]//div/button/span");
        private By abandonedText = By.XPath("//div[div[text()='ABANDONED']]//div/button[text()]");
        private By ownedText = By.XPath("//div[div[text()='OWNED']]//div/button/span");
        private By reservedNotesText = By.XPath("//div[div[text()='RESERVED NOTE']]//div/button");
        private By taxRefunedRequest = By.XPath("//a[contains(text(),'TAX REFUND REQUEST')]");

        #region  Asset Management Fileds
        private By pagination = By.ClassName("pagination");
        private By next = By.XPath("//*[@class='pagination']//span[@aria-label='Last']");
        private By previous = By.XPath("//*[@class='pagination']//span[@aria-label='First']");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By pageCount = By.XPath("//h3/span");
        private By headerName = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By addAsset = By.XPath("//button[contains(text(),'Asset')]");
        private By pages = By.XPath("//*[@class='pagination']//li[not(@class='disabled')]/a[not(descendant::*)]");
        private By filterButton = By.XPath("//button[contains(@title,'View and change current filters.')]");
        private By assetCloseButton = By.XPath("//button[text()='CLOSE']");
        private By assetResetButton = By.XPath("//button[text()='RESET']");
        private By assetDescription = By.XPath("//div[label[text()='DESCRIPTION']]/input");
        private By assetFullyAdministered = By.XPath("//div[label[text()='FULLY ADMINISTERED']]//span/div[1]");
        private By assetAbandoned = By.XPath("//div[label[text()='ABANDONED']]//div[@class='Select-input']/input");
        private By assetReserved = By.XPath("//div[label[text()='RESERVED']]//span/div[1]");
        private By assetCaseStatus = By.XPath("//div[label[text()='CASE STATUS']]//span/div[1]");
        private By assetAdministeredX = By.XPath("//div[label[text()='FULLY ADMINISTERED']]//span[2]/span");
        private By assetAbandonedX = By.XPath("//div[label[text()='ABANDONED']]//span[2]/span");
        private By assetReservedX = By.XPath("//div[label[text()='RESERVED']]//span[2]/span");
        private By assetClassStatusX = By.XPath("//div[label[text()='CASE STATUS']]//span[2]/span");

        string expandRecord = "//tbody/tr[{0}]/td/div[@class='visible-sm visible-md visible-lg visible-xl']/i";
        private string assetFilterSelect = "//div/div[text()='{0}']";
        string recordData = "//div[div[text()='{0}']]//span[text()] | //div[div[text()='{0}']]//button[text()]";

        private By caseTableRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By caseStatus = By.XPath("//span[contains(text(),'Closed')]");

        #endregion

        public AssetsDetailTab(IWebDriver driver) : base(driver, "UNITY") { }

        public bool IsResultsListEmpty()
        {
            try
            {
                //wait only for 10 seconds
                this.WaitForElementToBeVisible(assetListRow, 2);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public string GetNoResultsMessage()
        {
            return this.WaitForElementToBeVisible(noResultsMessage).Text;
        }
        public string SelectionTitle
        {
            get
            {
                return this.WaitForElementToBeVisible(selectionCardSelectedTitle).Text;
            }
        }

        public string SelectionAssetsCountDetail
        {
            get
            {
                return this.WaitForElementToBeVisible(selectionDetailAssetsCount).Text;
            }
        }

        public int AssetsListItemsCount
        {
            get
            {
                return this.WaitForElementsToBeVisible(assetListRow).Count;
            }
        }

        public List<AssetData> GetFirstNAssets(int top)
        {
            IReadOnlyCollection<IWebElement> allAssets = this.WaitForElementsToBeVisible(assetListRow);
            List<AssetData> transactions = new List<AssetData>();

            int count = 0;
            IEnumerator<IWebElement> enumTransactions = allAssets.GetEnumerator();
            while ((enumTransactions.MoveNext()) && (count < top))
            {
                transactions.Add(this.CreateAssetFromWebElement(enumTransactions.Current));
                count++;
            }

            return transactions;
        }

        private AssetData CreateAssetFromWebElement(IWebElement assetWE)
        {
            AssetData asset = new AssetData();
            //get from Web Element only the number and then search the rest of the elements by id
            IWebElement assetNbr = assetWE.FindElement(By.XPath(".//p[contains(@id,'assetNumber')]"));
            asset.Id = assetNbr.GetAttribute("id").Replace("assetNumber", "");

            //top region
            asset.Number = assetNbr.Text;
            asset.Name = this.WaitForElementToBeVisible(By.Id(String.Format(assetNameByIdTemplate, asset.Id))).Text;

            try
            {
                IWebElement cornerTagWE = this.WaitForElementToBeVisible(By.Id(String.Format(assetCornerTagByIdTemplate, asset.Id)), 2);
                asset.CornerTagColor = this.GetColorFromColorCode(cornerTagWE.FindElement(By.TagName("polygon")).GetCssValue("fill"));
                asset.CornerTagText = cornerTagWE.FindElement(By.TagName("text")).Text;
            }
            catch (Exception)
            {
                asset.CornerTagColor = "";
                asset.CornerTagText = "";
            }

            try
            {
                IWebElement faDateWE = this.WaitForElementToBeVisible(By.Id(String.Format(assetFaDateByIdTemplate, asset.Id)), 2);
                asset.FADate = faDateWE.Text;
                asset.FADateLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetFaDateLabelByIdTemplate, asset.Id))).Text;
                asset.FADateColor = this.GetColorFromColorCode(faDateWE.GetCssValue("color"));
            }
            catch (Exception)
            {
                asset.FADate = "";
                asset.FADateColor = "";
                asset.FADateLabel = "";
            }

            asset.Type = this.WaitForElementToBeVisible(By.Id(String.Format(assetTypeByIdTemplate, asset.Id))).Text;
            asset.ValueType = this.WaitForElementToBeVisible(By.Id(String.Format(assetValueTypeByIdTemplate, asset.Id))).Text;

            //left 
            asset.CodeLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetCodeLabelByIdTemplate, asset.Id))).Text;
            try
            {
                asset.Code = this.WaitForElementToBeVisible(By.Id(String.Format(assetCodeByIdTemplate, asset.Id)), 2).Text;
            }
            catch (Exception)
            {
                asset.Code = "";
            }

            //center
            asset.PetitionPosition = this.WaitForElementToBeVisible(By.Id(String.Format(assetPetitionPositionByIdTemplate, asset.Id))).Text;
            asset.PetitionLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetPetitionLabelByIdTemplate, asset.Id))).Text;
            asset.Petition = this.WaitForElementToBeVisible(By.Id(String.Format(assetPetitionByIdTemplate, asset.Id))).Text;

            asset.NetValuePosition = this.WaitForElementToBeVisible(By.Id(String.Format(assetNetValuePositionByIdTemplate, asset.Id))).Text;
            asset.NetValueLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetNetValueLabelByIdTemplate, asset.Id))).Text;
            asset.NetValue = this.WaitForElementToBeVisible(By.Id(String.Format(assetNetvalueByIdTemplate, asset.Id))).Text;

            asset.AbandonedPosition = this.WaitForElementToBeVisible(By.Id(String.Format(assetAbandonedPositionByIdTemplate, asset.Id))).Text;
            asset.AbandonedLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetAbandonedLabelByIdTemplate, asset.Id))).Text;
            asset.Abandoned = this.WaitForElementToBeVisible(By.Id(String.Format(assetAbandonedByIdTemplate, asset.Id))).Text;

            asset.SalesPosition = this.WaitForElementToBeVisible(By.Id(String.Format(assetSalesPositionByIdTemplate, asset.Id))).Text;
            asset.SalesLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetSalesLabelByIdTemplate, asset.Id))).Text;
            asset.Sales = this.WaitForElementToBeVisible(By.Id(String.Format(assetSalesByIdTemplate, asset.Id))).Text;

            asset.RemainingPosition = this.WaitForElementToBeVisible(By.Id(String.Format(assetRemainingPositionByIdTemplate, asset.Id))).Text;
            asset.RemainingLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetRemainingLabelByIdTemplate, asset.Id))).Text;
            asset.Remaining = this.WaitForElementToBeVisible(By.Id(String.Format(assetRemainingByIdTemplate, asset.Id))).Text;

            asset.TrusteeLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetTrusteeLabelByIdTemplate, asset.Id))).Text;
            asset.Trustee = this.WaitForElementToBeVisible(By.Id(String.Format(assetTrusteeByIdTemplate, asset.Id))).Text;

            asset.LiensLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetLiensLabelByIdTemplate, asset.Id))).Text;
            asset.Liens = this.WaitForElementToBeVisible(By.Id(String.Format(assetLiensByIdTemplate, asset.Id))).Text;

            asset.ExemptionsLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetExemptionsLabelByIdTemplate, asset.Id))).Text;
            asset.Exemptions = this.WaitForElementToBeVisible(By.Id(String.Format(assetExemptionsByIdTemplate, asset.Id))).Text;

            //bottom region
            asset.Form1NoteLabel = this.WaitForElementToBeVisible(By.Id(String.Format(assetForm1NoteLabelByIdTemplate, asset.Id))).Text;
            IWebElement form1Note = this.WaitForElementToBePresent(By.Id(String.Format(assetForm1NoteByIdTemplate, asset.Id)));
            //text can only ve invisble when empty, otherwise text is not displaying correctly and something is wrong
            if ((!form1Note.Displayed && form1Note.Text == "") || (form1Note.Displayed && form1Note.Text != ""))
                asset.Form1Note = form1Note.Text;
            else
                asset.Form1Note = null;



            return asset;
        }

        private AssetData CreateAssetFromWebElementFindFromElement(IWebElement assetWE)
        {
            AssetData asset = new AssetData();
            //get from Web Element only the number and then search the rest of the elements by id
            IWebElement assetNbr = assetWE.FindElement(By.XPath("//p[contains(@id,'assetNumber')]"));
            asset.Id = assetNbr.GetAttribute("id").Replace("assetNumber", "");

            //top region
            asset.Number = assetNbr.Text;
            asset.Name = assetWE.FindElement(By.Id(String.Format(assetNameByIdTemplate, asset.Id))).Text;

            try
            {
                IWebElement cornerTagWE = assetWE.FindElement(By.Id(String.Format(assetCornerTagByIdTemplate, asset.Id)));
                asset.CornerTagColor = this.GetColorFromColorCode(cornerTagWE.FindElement(By.TagName("polygon")).GetCssValue("fill"));
                asset.CornerTagText = cornerTagWE.FindElement(By.TagName("text")).Text;
            }
            catch (Exception)
            {
                asset.CornerTagColor = "";
                asset.CornerTagText = "";
            }

            try
            {
                IWebElement faDateWE = assetWE.FindElement(By.Id(String.Format(assetFaDateByIdTemplate, asset.Id)));
                asset.FADate = faDateWE.Text;
                asset.FADateLabel = assetWE.FindElement(By.Id(String.Format(assetFaDateLabelByIdTemplate, asset.Id))).Text;
                asset.FADateColor = this.GetColorFromColorCode(faDateWE.GetCssValue("color"));
            }
            catch (Exception)
            {
                asset.FADate = "";
                asset.FADateColor = "";
                asset.FADateLabel = "";
            }

            asset.Type = assetWE.FindElement(By.Id(String.Format(assetTypeByIdTemplate, asset.Id))).Text;
            asset.ValueType = assetWE.FindElement(By.Id(String.Format(assetValueTypeByIdTemplate, asset.Id))).Text;

            //left 
            asset.CodeLabel = assetWE.FindElement(By.Id(String.Format(assetCodeLabelByIdTemplate, asset.Id))).Text;
            try
            {
                asset.Code = assetWE.FindElement(By.Id(String.Format(assetCodeByIdTemplate, asset.Id))).Text;
            }
            catch (Exception)
            {
                asset.Code = "";
            }

            //center
            asset.PetitionPosition = assetWE.FindElement(By.Id(String.Format(assetPetitionPositionByIdTemplate, asset.Id))).Text;
            asset.PetitionLabel = assetWE.FindElement(By.Id(String.Format(assetPetitionLabelByIdTemplate, asset.Id))).Text;
            asset.Petition = assetWE.FindElement(By.Id(String.Format(assetPetitionByIdTemplate, asset.Id))).Text;

            asset.NetValuePosition = assetWE.FindElement(By.Id(String.Format(assetNetValuePositionByIdTemplate, asset.Id))).Text;
            asset.NetValueLabel = assetWE.FindElement(By.Id(String.Format(assetNetValueLabelByIdTemplate, asset.Id))).Text;
            asset.NetValue = assetWE.FindElement(By.Id(String.Format(assetNetvalueByIdTemplate, asset.Id))).Text;

            asset.AbandonedPosition = assetWE.FindElement(By.Id(String.Format(assetAbandonedPositionByIdTemplate, asset.Id))).Text;
            asset.AbandonedLabel = assetWE.FindElement(By.Id(String.Format(assetAbandonedLabelByIdTemplate, asset.Id))).Text;
            asset.Abandoned = assetWE.FindElement(By.Id(String.Format(assetAbandonedByIdTemplate, asset.Id))).Text;

            asset.SalesPosition = assetWE.FindElement(By.Id(String.Format(assetSalesPositionByIdTemplate, asset.Id))).Text;
            asset.SalesLabel = assetWE.FindElement(By.Id(String.Format(assetSalesLabelByIdTemplate, asset.Id))).Text;
            asset.Sales = assetWE.FindElement(By.Id(String.Format(assetSalesByIdTemplate, asset.Id))).Text;

            asset.RemainingPosition = assetWE.FindElement(By.Id(String.Format(assetRemainingPositionByIdTemplate, asset.Id))).Text;
            asset.RemainingLabel = assetWE.FindElement(By.Id(String.Format(assetRemainingLabelByIdTemplate, asset.Id))).Text;
            asset.Remaining = assetWE.FindElement(By.Id(String.Format(assetRemainingByIdTemplate, asset.Id))).Text;

            asset.TrusteeLabel = assetWE.FindElement(By.Id(String.Format(assetTrusteeLabelByIdTemplate, asset.Id))).Text;
            asset.Trustee = assetWE.FindElement(By.Id(String.Format(assetTrusteeByIdTemplate, asset.Id))).Text;

            asset.LiensLabel = assetWE.FindElement(By.Id(String.Format(assetLiensLabelByIdTemplate, asset.Id))).Text;
            asset.Liens = assetWE.FindElement(By.Id(String.Format(assetLiensByIdTemplate, asset.Id))).Text;

            asset.ExemptionsLabel = assetWE.FindElement(By.Id(String.Format(assetExemptionsLabelByIdTemplate, asset.Id))).Text;
            asset.Exemptions = assetWE.FindElement(By.Id(String.Format(assetExemptionsByIdTemplate, asset.Id))).Text;

            //bottom region
            asset.Form1NoteLabel = assetWE.FindElement(By.Id(String.Format(assetForm1NoteLabelByIdTemplate, asset.Id))).Text;
            asset.Form1Note = assetWE.FindElement(By.Id(String.Format(assetForm1NoteByIdTemplate, asset.Id))).Text;

            return asset;
        }

        public List<AssetSummaryItemData> GetAssetsSummaryItems()
        {
            throw new NotImplementedException();
        }

        public void ScrollToAssetsSummarySection()
        {
            this.JSMoveToViewElement(this.WaitForElementToBeVisible(assetsSummaryCardTitle));
            this.ScrollDownToAvoidStickyHeadersOnClick();
        }

        //TODO If ASSET_SUMMARY_ITEM_LOCATOR remains the same on all tabs due to generic carousel classes, we could move this  up to CaseDetail
        // In BankingDetailTab it's implemented different because it doesn't need to swipe
        public void SelectSummaryTileByPosition(int position)
        {
            //this.MoveToViewElement(this.WaitForElementToBeVisible(ASSET_SUMMARY_ITEM_TITLE_LOCATOR));
            IEnumerator<IWebElement> allCardsWE = this.WaitForElementsToBePresent(assetSummaryItemTitle).GetEnumerator();

            allCardsWE.MoveNext();
            IWebElement lastVisibleTile = allCardsWE.Current;

            for (int i = 1; i < position; i++)
            {
                allCardsWE.MoveNext();
                if ((!allCardsWE.Current.Displayed) || (i >= 4))
                    this.SwipeTileToTheLeft(lastVisibleTile);
                lastVisibleTile = allCardsWE.Current;
            }

            allCardsWE.Current.Click();
            this.WaitForBlockOverlayToDissapear();
        }


        public bool IsSummaryTileSelectedByPosition(int position)
        {
            IEnumerator<IWebElement> allCardsWE = this.WaitForElementsToBePresent(assetSummaryItem).GetEnumerator();
            for (int i = 0; i < position; i++)
            {
                allCardsWE.MoveNext();
            }
            return allCardsWE.Current.GetAttribute("class").Contains("selectedTile");
        }

        public AssetForm ClickNewAssetButton()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(assetsListTitle));
            this.MoveToViewElement(this.WaitForElementToBeVisible(assetsSelectionSummaryTitle));
            this.WaitForElementToBeVisible(newAssetButton).Click();
            this.WaitForBlockOverlayToDissapear();
            return new AssetForm(driver, false);
        }

        public AssetForm ClickQuickEditButtonOnFirstAsset()
        {
            this.MoveToViewElement(this.WaitForElementToBeVisible(trusteeLabelFirstAssetOnList));
            this.MoveToViewElement(this.WaitForElementToBeVisible(assetsListTitle));
            this.WaitForElementToBeVisible(quickEditButton).Click();
            this.WaitForBlockOverlayToDissapear();
            return new AssetForm(driver, true);
        }

        public bool IsNewAssetButtonActive
        {
            get
            {
                return !this.WaitForElementToBeVisible(newAssetButton).GetAttribute("class").Contains("clickDisabled grey");
            }
        }
        public bool IsNewAssetFormVisible
        {
            get
            {
                return this.WaitForElementToBeVisible(newAssetFormTitle).Text.Contains("New Asset");
            }
        }
        public bool AllQuickEditButtonsActive
        {
            get
            {
                IReadOnlyCollection<IWebElement> allQuickEditLinks = this.WaitForElementsToBeVisible(quickEditButton);
                bool allActive = true;
                foreach (IWebElement link in allQuickEditLinks)
                {
                    allActive = allActive && (!link.GetAttribute("class").Contains("clickDisabled grey"));
                }
                return allActive;
            }
        }
        public bool AllQuickEditButtonsInactive
        {
            get
            {
                IReadOnlyCollection<IWebElement> allQuickEditLinks = this.WaitForElementsToBeVisible(quickEditButton);
                bool allActive = true;
                foreach (IWebElement link in allQuickEditLinks)
                {
                    allActive = allActive && link.GetAttribute("class").Contains("clickDisabled grey");
                }
                return allActive;
            }
        }

        public bool IsEditAssetFormVisible
        {
            get
            {
                return this.WaitForElementToBeVisible(newAssetFormTitle).Text.Contains("Edit Asset");
            }
        }

        public void CancelNewAsset()
        {
            IWebElement list = this.WaitForElementToBeVisible(assetsListTitle);
            this.MoveToViewElement(list);
            IWebElement liens = this.WaitForElementToBeVisible(newAssetLiens);
            MoveToViewElement(liens);
            liens.Click();
            this.MoveToViewElement(list);
            IWebElement button = this.WaitForElementToBeClickeable(newAssetCancelButton);
            button.Click();
            this.WaitForBlockOverlayToDissapear();
        }
        public void GetPageCount()
        {
            // return Convert.ToInt32(this.WaitForElementToBeVisible(PAGECOUNT).Text.Replace(",",""));
            WaitForElementToBeVisible(pageCount);
            var count = driver.FindElement(pageCount).Text.Replace(",", "");
            // return Convert.Parse(count).Replace(",", ""));

        }
        public AddAsset ClickOnAsset()
        {
            this.WaitForElementToBePresent(addAsset).Click();
            return new AddAsset(driver);
        }
        public DataTable GetClaimRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();
            IList<IWebElement> rows = null;
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(headerName).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            var headerNames = driver.FindElements(headerName).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 1; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);
                try
                {
                    this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, headerNames[i])), 8);
                    rows = driver.FindElements(By.XPath(string.Format(rowXpath, headerNames[i])));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }

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
        public void VerifyPaginationAndNavigations()
        {
            IWebElement element = WaitForElementToBeVisible(pagination, 8);
            JSMoveToViewElement(element);
            element.Displayed.Should().BeTrue();

            var pageNumbers = driver.FindElements(pages).Select(e => e.Text.Trim()).Select(s => int.Parse(s)).ToList();

            if (pageNumbers.Last() > 1)
            {
                int active = Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
                int nextPage = ClickPageNext();
                if (!(active < nextPage))
                    throw new Exception("[Pagination] - verification failed");
                int temp = ClickPagePrevious();
                if (active != temp)
                    throw new Exception("[Pagination] - verification failed");
            }
            else
            {
                int active = Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
                int nextPage = ClickPageNext();
                if (!(active == nextPage))
                    throw new Exception("[Pagination] - verification failed");
                int temp = ClickPagePrevious();
                if (!(active == temp))
                    throw new Exception("[Pagination] - verification failed");
            }
        }
        private int ClickPageNext()
        {
            this.WaitForElementToBeVisible(next).Click();
            return Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
        }
        private int ClickPagePrevious()
        {
            this.WaitForElementToBeVisible(previous).Click();
            return Convert.ToInt16(WaitForElementToBeVisible(activePage).Text);
        }
        public void ClickFilterButton()
        {
            this.Pause(2);
            this.WaitForElementToBeClickeable(filterButton).Click();
        }
        public void ClickOnCloseButton()
        {
            this.WaitForElementToBeVisible(assetCloseButton,5).Click();
        }
        public void ClickOnResetButton()
        {
            this.Pause(1);
            this.WaitForElementToBeVisible(assetResetButton).Click();
        }
        public void EnterDescription(string description)
        {
            this.Pause(2);
            this.WaitForElementToBeVisible(assetDescription, 2).SendKeys(description);
        }
        public void SelectFullyAdministered(string fullyAdministered)
        {
            this.Pause(2);
            this.WaitForElementToBeVisible(assetFullyAdministered, 2).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(assetFilterSelect, fullyAdministered)), 1).Click();
            Thread.Sleep(2000);
        }
        public void SelectFullyAbondoned(string fullyAbondoned)
        {
            //this.WaitForElementToBeVisible(assetAbandoned, 2).Click();
            //this.WaitForElementToBeVisible(By.XPath(String.Format(assetFilterSelect, fullyAbondoned)), 1).Click();
            this.WaitForElementToBeVisible(assetAbandoned, 2).SendKeys(fullyAbondoned);

        }
        public void SelectFullyReserved(string fullyReserved)
        {
            this.Pause(2);
            this.WaitForElementToBeVisible(assetReserved, 2).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(assetFilterSelect, fullyReserved)), 1).Click();
        }
        public void SelectCaseStatus(string caseStatus)
        {
            this.WaitForElementToBeVisible(assetCaseStatus, 2).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(assetFilterSelect, caseStatus)), 1).Click();
        }
        public void ClearDescription()
        {
            this.WaitForElementToBeVisible(assetDescription, 2).Clear();
        }
        public void TaxrefundRequest()
        {
            this.Pause(2);
            this.WaitForElementToBeVisible(taxRefunedRequest, 2).Click();
        }
        public void ClickOnTaxrefundrequest()
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(taxRefunedRequest, 3).Click();
        }
        public void ClickFullyAdministeredX()
        {
            this.Pause(3);
            this.WaitForElementToBeClickeable(filterButton).Click();
            this.WaitForElementToBeVisible(assetAdministeredX).Click();
        }
        public void ClickFullyAbondonedX()
        {
            this.Pause(2);
            this.WaitForElementToBeVisible(assetAbandonedX).Click();
        }
        public void ClickFullyReservedX()
        {
            this.WaitForElementToBeVisible(assetReservedX).Click();
        }
        public void ClickFullyCaseStatusX()
        {
            this.WaitForElementToBeVisible(assetClassStatusX).Click();
        }

        public List<string> GetRecordsByColumnName(string ColumnName, string value = null)
        {

            var finished = false;
            List<string> lists = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    Pause(2);

                    IList<IWebElement> rows = null;

                    ColumnName = ColumnName.ToUpper();
                    string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";
                    try
                    {
                        this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, ColumnName)), 16);
                        rows = driver.FindElements(By.XPath(string.Format(rowXpath, ColumnName)));
                        if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']")); }
                    }
                    catch (Exception e) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{ColumnName}']")); }
                    lists = rows.Select(e => e.Text.Trim()).ToList();
                    finished = true;
                    // To verify the value exist in the respective column 
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        bool found = false;
                        foreach (string list in lists)
                        {
                            found = list.Contains(value);
                            break;
                        }
                        found.Should().BeTrue();
                    }

                    break;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            return lists;

        }
        public bool CheckFullyAdministeredFormat(string value)
        {
            this.WaitForElementToBeVisible(assetCloseButton).Click();
            bool result = false;

            for (var i = 0; i < 10; i++)
            {
                try
                {
                    this.Pause(3);
                    this.WaitForElementToBeVisible(By.XPath(string.Format(expandRecord, "1")), 4).Click();
                    Thread.Sleep(3000);
                    By xpath = By.XPath(string.Format(string.Format(recordData, "FA")));
                    var expected = this.WaitForElementToBePresent(xpath).Text;
                    Regex rgx = new Regex(@"\d{2}/\d{2}/\d{2}");
                    this.WaitForElementToBeVisible(By.XPath(string.Format(expandRecord, "1")), 4).Click();
                    result = rgx.Match(expected).Success;
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            return result;
        }
        public string GetRecordValue(string xpathSuffix)
        {
            this.WaitForElementToBeVisible(assetCloseButton).Click();
            Thread.Sleep(3000);
            this.WaitForElementToBeVisible(By.XPath(string.Format(expandRecord, "1")), 4).Click();
            Thread.Sleep(300);
            By xpath = By.XPath(string.Format(string.Format(recordData, xpathSuffix)));
            var text = this.WaitForElementToBePresent(xpath).Text;
            this.WaitForElementToBeVisible(By.XPath(string.Format(expandRecord, "1")), 4).Click();
            this.WaitForElementToBeClickeable(filterButton).Click();
            return text;

        }

        public string GetCaseStatus()
        {
            string text = String.Empty;
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    Pause(4);
                    By rowXpath = By.XPath("//tr[not(@class='epiq-table-details-row')][@class][1]/td/div/a[span]");
                    this.WaitForElementToBeVisible(rowXpath).Click();
                    text = this.WaitForElementToBeVisible(By.XPath("//div[strong[text()='CASE STATUS']]/div/span"), 30).Text;
                    //driver.Navigate().Back();
                    this.WaitForElementToBeVisible(caseStatus, 60);
                    break;
                }
                catch (StaleElementReferenceException e)
                {
                    continue;
                }
            }
            return text;
        }
        public void VerifyRowsLength(int PageSize)
        {
            this.ScrollUpToPageTop();
            Thread.Sleep(1000);
            IList<IWebElement> Rows = driver.FindElements(caseTableRows);
            int RowsLength = Rows.Count() / 2;
            Assert.AreEqual(PageSize, RowsLength);
        }
        public void EditWithDescription(string description)
        {
            Thread.Sleep(3500);
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int caseRows = rows.Count;

            for (int row = 1; row <= caseRows; row++)
            {
                IWebElement descriptionValues = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[5]"));
                string descriptionList = descriptionValues.Text;
                Console.WriteLine(descriptionList);

                if (descriptionList == description)
                {
                    Thread.Sleep(3000);
                    var edit = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + row + "]/td[19]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
                    break;
                }
                row++;
            }
        }
        public void EditPetition(string petition)
        {
            this.Pause(3);
            WaitForElementToBeClickeable(petitionInlineEdit).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 3), petition);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void EditTrustee(string trustee)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(trusteeInlineEdit,2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent,2), trustee);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void EditExemptions(string exemption)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(exemptionInlineEdit,2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 2), exemption);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void EditFA(string date)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(expandRow, 4).Click();
            WaitForElementToBeClickeable(faInlineedit, 2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(inputFieldValue));
            this.TypeIn(WaitForElementToBeVisible(inputFieldValue, 4), date);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void EditAbandoned(string abandoned)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(abandonedInlineEdit,4).Click();
            WaitForElementToBeClickeable(abandonedDropdown, 4).SendKeys(abandoned);
            WaitForElementToBeClickeable(By.XPath($"//div[contains(text(),'{abandoned}')]")).SendKeys(Keys.Down);
            WaitForElementToBeClickeable(By.XPath($"//div[contains(text(),'{abandoned}')]")).SendKeys(Keys.Space);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void EditOwned(string owned)
        {
            this.Pause(2);
            WaitForElementToBeClickeable(ownedInlineEdit, 2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 4), owned);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void ReservedNotes(string note)
        {
            this.Pause(2);
            WaitForElementToBeVisible(reservedNotesInlineEdit, 4).Click();
            this.ClearAndType(WaitForElementToBeVisible(reservedTextArea),note);
            WaitForElementToBeClickeable(saveField,2).Click();
        }
        public void Reserved()
        {
            try
            {
                WaitForElementToBeClickeable(reservedInlineEdit,2).Click();
                WaitForElementToBeClickeable(saveField,2).Click();
            }
            catch (Exception)
            {
                
            }
        }
        public void PetitionValue(string petition)
        {
            var petitionValue = WaitForElementToBeVisible(petitionInlineEdit,2).Text;
            Assert.IsTrue(petitionValue.Equals(petition, StringComparison.OrdinalIgnoreCase));
        }
        public void TrusteeValue(string trustee)
        {
            var trusteeValue = WaitForElementToBeVisible(trusteeInlineEdit,2).Text;
            Assert.IsTrue(trusteeValue.Equals(trustee, StringComparison.OrdinalIgnoreCase));
        }
        public void ExemptionValue(string exemption)
        {
            var exemptionValue = WaitForElementToBeVisible(exemptionInlineEdit,2).Text;
            Assert.IsTrue(exemptionValue.Equals(exemption, StringComparison.OrdinalIgnoreCase));
        }
        public void FAValue(string fa)
        {
            this.Pause(2);
            var faValue = WaitForElementToBeVisible(faText).Text;
            Assert.IsTrue(faValue.Equals(fa, StringComparison.OrdinalIgnoreCase));
        }
        public void AbandonedValue(string abandoned)
        {
            var abandonedValue = WaitForElementToBeVisible(abandonedText).Text;
            Assert.IsTrue(abandonedValue.Equals(abandoned, StringComparison.OrdinalIgnoreCase));
        }
        public void OwnedValue(string owned)
        {
            var ownedValue = WaitForElementToBeVisible(ownedText).Text;
            Assert.IsTrue(ownedValue.Equals(owned, StringComparison.OrdinalIgnoreCase));
        }
        public void ReservedText(string notes)
        {
            var notesText = WaitForElementToBeVisible(reservedNotesText).Text;
            Assert.IsTrue(notesText.Equals(notes, StringComparison.OrdinalIgnoreCase));
        }
        public void CancelPetitionEdit(string petition)
        {
            this.Pause(3);
            WaitForElementToBeClickeable(petitionInlineEdit, 3).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 3), petition);
            WaitForElementToBeClickeable(cancelField,2).Click();
        }
        public void CancelTrusteeEdit(string trustee)
        {
            WaitForElementToBeClickeable(trusteeInlineEdit,2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent, 4));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 4), trustee);
            WaitForElementToBeClickeable(cancelField,2).Click();
        }
        public void CancelExemptionEdit(string exemption)
        {
            WaitForElementToBeClickeable(exemptionInlineEdit,2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 4), exemption);
            WaitForElementToBeClickeable(cancelField,2).Click();
        }
        public void CancelFAEdit(string date)
        {
            WaitForElementToBeClickeable(expandRow, 4).Click();
            WaitForElementToBeClickeable(faInlineedit, 2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(inputFieldValue));
            this.TypeIn(WaitForElementToBeVisible(inputFieldValue,4), date);
            WaitForElementToBeClickeable(cancelField,2).Click();
        }
        public void CancelAbandonedEdit(string abandoned)
        {
            WaitForElementToBeClickeable(abandonedInlineEdit,2).Click();
            WaitForElementToBeClickeable(abandonedDropdown, 4).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[contains(text(),'{abandoned}')]")).Click();
            WaitForElementToBeClickeable(cancelField,2).Click();
        }
        public void CancelOwnedEdit(string owned)
        {
            WaitForElementToBeClickeable(ownedInlineEdit, 2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(fieldPresent));
            this.TypeIn(WaitForElementToBeVisible(fieldPresent, 4), owned);
            WaitForElementToBeClickeable(cancelField).Click();
        }
        public void CancelReservedNotesEdit(string notes)
        {
            WaitForElementToBeVisible(reservedNotesInlineEdit, 4).Click();
            this.ClearAndType(WaitForElementToBeVisible(reservedTextArea), notes);
            WaitForElementToBeClickeable(cancelField).Click();
        }
        public void InLineEditViewFields()
        {
            Assert.False(IsElementVisible(petitionInlineEdit));
            Assert.False(IsElementVisible(trusteeInlineEdit));
            Assert.False(IsElementVisible(exemptionInlineEdit));
            WaitForElementToBeVisible(expandRow,2).Click();
            Assert.False(IsElementVisible(faInlineedit));
            Assert.False(IsElementVisible(abandonedInlineEdit));
            Assert.False(IsElementVisible(ownedInlineEdit));
            Assert.False(IsElementVisible(reservedInlineEdit));
            Assert.False(IsElementVisible(reservedNotesInlineEdit));
        }
        public void VerifyCaseFullyAdministered()
        {
            var resColor = driver.FindElement(By.XPath("//tr[1]/td[@class='epiq-table-view-more sm md lg xl']")).GetCssValue("color");

            string[] arrColor = resColor.Split(',');
            string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

            int hexValue1 = Int32.Parse(hexValue[0]);
            hexValue[1] = hexValue[1].Trim();
            int hexValue2 = Int32.Parse(hexValue[1]);
            hexValue[2] = hexValue[2].Trim();
            int hexValue3 = Int32.Parse(hexValue[2]);

            string actualColor = string.Format("#34a01e", hexValue1, hexValue2, hexValue3);
            Assert.AreEqual("#34a01e", actualColor);
        }
        public void VerifyFilterDefaultValue(string header, string value)
        {
            var defaultValue =WaitForElementToBeVisible(By.XPath($"//div[label[text()='{header}']]//span[text()='{value}']")).Text;
            Assert.IsTrue(defaultValue.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
        public void CaseStatusHidden(string caseStatus)
        {
            Assert.False(IsElementVisible(By.XPath($"//div[label[text()='{caseStatus}']]")));
        }
    }
}