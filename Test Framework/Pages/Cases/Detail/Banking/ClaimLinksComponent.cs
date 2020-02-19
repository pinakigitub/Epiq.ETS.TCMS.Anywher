using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using System.Collections.Generic;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Cases.Detail.Banking;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail
{
    public class ClaimLinksComponent : TransactionForm
    {
        //private string CHECK_CLAIM_LINK_ROW_LOCATOR_PREFIX = "//*[@id='claimLinkTable']/tbody";
        //private string DEPOSIT_CLAIM_LINK_ROW_LOCATOR_PREFIX = "//*[@id='claimLinkTable']/tbody";

        //Claim LinkSECTION locators
        //Title and add links
        private By CHECK_CLAIM_LINKS_SECTION_TITLE_LOCATOR = By.Id("checkClaimLink");
        private By DEPOSIT_CLAIM_LINKS_SECTION_TITLE_LOCATOR = By.Id("depositClosingCostTitle");
        
        private By CHECK_ADD_CLAIM_LINK_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[contains(@class,'addRowOption')]");
        private By CHECK_ADD_CLAIM_LINK_ICON_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[contains(@class,'addRowGridContainer')]//*[contains(@class,'fa-expand')]");       

        ////LINKS TABLE  locators
        //Table headers
        private By CHECK_CLAIM_NUMBER_LABEL_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='numberHeader']");
        private By DEPOSIT_CLAIM_NUMBER_LABEL_LOCATOR = By.XPath("//*[@id='closingCostsTable']//*[@id='numberHeader']");

        private By CHECK_CLAIM_NAME_LABEL_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='gridHeader']");
        private By DEPOSIT_CLAIM_NAME_LABEL_LOCATOR = By.XPath("//*[@id='closingCostsTable']//*[@id='gridHeader']");

        private By CHECK_CLAIM_CODE_LABEL_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='codeHeader']");
        private By DEPOSIT_CLAIM_CODE_LABEL_LOCATOR = By.XPath("//*[@id='closingCostsTable']//*[@id='codeHeader']");

        private By CHECK_CLAIM_ALLOCATION_DESCRIPTION_LABEL_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='allocationHeader']");
        private By DEPOSIT_CLAIM_ALLOCATION_DESCRIPTION_LABEL_LOCATOR = By.XPath("//*[@id='closingCostsTable']//*[@id='allocationHeader']");

        private By CHECK_CLAIM_NON_COMPENSABLE_LABEL_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='nonCompensableHeader']");
        private By DEPOSIT_CLAIM_NON_COMPENSABLE_LABEL_LOCATOR = By.XPath("//*[@id='closingCostsTable']//*[@id='nonCompensableHeader']");

        private By CHECK_CLAIM_AMOUNT_LABEL_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='amountHeader']");
        private By DEPOSIT_CLAIM_AMOUNT_LABEL_LOCATOR = By.XPath("//*[@id='closingCostsTable']//*[@id='amountHeader']");


        //Generic row locator
        private By CHECK_CLAIM_LINK_ROW_LOCATOR = By.XPath("//*[@id='claimLinkTable']/tbody");
        private By DEPOSIT_CLAIM_LINK_ROW_LOCATOR = By.XPath("//*[@id='closingCostsTable']/tbody");


        //Link data by row position
        private string CHECK_CLAIM_LINK_NAME_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable-{0}-gridContainer-searchGridContainer-{1}']";
        private string DEPOSIT_CLAIM_LINK_NAME_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='closingCostsTable-{0}-gridContainer-searchGridContainer-{1}']";

        //private string CLAIM_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable-{0}-gridContainer-text']";
        private string CHECK_CLAIM_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//p[contains(@id,'gridContainer-text')]";
        private string DEPOSIT_CLAIM_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='closingCostsTable']/tbody[{0}]//p[contains(@id,'gridContainer-text')]";
        private string CHECK_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]/tr/td[3]";
        private string CHECK_EDIT_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]/tr/td[2]";
        private string DEPOSIT_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//table[@id='closingCostsTable']/tbody[{0}]/tr/td[2]";
        private string DEPOSIT_CLAIM_LINK_CODE_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='select2-closingCostsTable-{0}-checkCodeTextBox-container']";
        private string DEPOSIT_CLAIM_LINK_CODE_PLACEHOLDER_BY_ROW_POSITION_LOCATOR_TEMPLATE = ".//*[@id='select2-closingCostsTable-{0}-checkCodeTextBox-container']//*[@class='select2-selection__placeholder']";
        private string CHECK_CLAIM_LINK_CODE_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='select2-claimLinkTable-{0}-checkCodeTextBox-container']";
        private string CHECK_CLAIM_LINK_CODE_PLACEHOLDER_BY_ROW_POSITION_LOCATOR_TEMPLATE = ".//*[@id='select2-claimLinkTable-{0}-checkCodeTextBox-container']//*[@class='select2-selection__placeholder']";
        //private string CHECK_CLAIM_LINK_AMOUNT_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@id,'-amount')]";
        private string CHECK_CLAIM_LINK_AMOUNT_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable-{0}-amount']";        
        private string DEPOSIT_CLAIM_LINK_AMOUNT_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='closingCostsTable-{0}-amount']";



        //private string DELETE_CLAIM_LINK_ICON_BY_ROW_POSITION_LOCATOR = "//*[@id='claimLinkTable']/tbody[{0}]//*[@id='icon-{0}-remove']";
        private string CHECK_DELETE_CLAIM_LINK_ICON_BY_ROW_POSITION_LOCATOR = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@id,'-remove')]";
        private string DEPOSIT_DELETE_CLAIM_LINK_ICON_BY_ROW_POSITION_LOCATOR = "//*[@id='closingCostsTable']/tbody[{0}]//*[contains(@id,'-remove')]";


        //// CLAIMS TABLE locators
        //Grid table and generic grid row
        private By CLAIMS_GRID_TABLE_LOCATOR = By.Id("claimsListTable-1");
        private By CLAIM_GRID_ROW_LOCATOR = By.XPath("//*[@id='claimsListTable-1']/tbody/tr");
        private string CLAIM_GRID_ROW_BY_LINK_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsListTable-{0}']/tbody/tr";


        private string TRANSACTION_ADD_CLAIM_RESULT_BY_NBR_NAME_AND_CODE_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable' or @id='closingCostsTable']/tbody[{0}]//*[@id='claimsListTable-{0}']/tbody/tr/td[2]/p[contains(text(),'{1}')]/../../td[3]/p[contains(text(),'{2}')]/../../td[1]/p[contains(text(),'{3}')]/../..";


        //Grid headers and no results msg
        private By CLAIM_NUMBER_GRID_HEADER_LOCATOR = By.Id("claimNumberHeader");
        //private string CLAIM_NUMBER_GRID_HEADER_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[@id='claimNumberHeader']";
        private string CLAIM_NUMBER_GRID_HEADER_LOCATOR_TEMPLATE = "//tbody[{0}]//*[@id='claimNumberHeader']";

        private By CLAIM_NAME_GRID_HEADER_LOCATOR = By.Id("claimNameHeader");
        //private string CLAIM_NAME_GRID_HEADER_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[@id='claimNameHeader']";
        private string CLAIM_NAME_GRID_HEADER_LOCATOR_TEMPLATE = "//tbody[{0}]//*[@id='claimNameHeader']";

        private By CLAIM_CODE_GRID_HEADER_LOCATOR = By.Id("claimCodeHeader");
        //private string CLAIM_CODE_GRID_HEADER_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[@id='claimCodeHeader']";
        private string CLAIM_CODE_GRID_HEADER_LOCATOR_TEMPLATE = "//tbody[{0}]//*[@id='claimCodeHeader']";
        
        private By CLAIM_TYPE_GRID_HEADER_LOCATOR = By.Id("claimTypeHeader");
        //private string CLAIM_TYPE_GRID_HEADER_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[@id='claimTypeHeader']";
        private string CLAIM_TYPE_GRID_HEADER_LOCATOR_TEMPLATE = "//tbody[{0}]//*[@id='claimTypeHeader']";

        private By CLAIM_BALANCE_GRID_HEADER_LOCATOR = By.Id("claimBalanceHeader");
        //private string CLAIM_BALANCE_GRID_HEADER_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[@id='claimBalanceHeader']";
        private string CLAIM_BALANCE_GRID_HEADER_LOCATOR_TEMPLATE = "//tbody[{0}]//*[@id='claimBalanceHeader']";

        //private By CLAIMS_GRID_NO_RESULTS_MESSAGE_LOCATOR = By.XPath("//*[@id='claimLinkTable']//*[@id='noResultsMessage']");
        private By CLAIMS_GRID_NO_RESULTS_MESSAGE_LOCATOR = By.XPath("//*[@id='noResultsMessage']");

        //Claim data by row position
        private string CHECK_CLAIM_NAME_CELL_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable-{0}-gridContainer-searchGridContainer-{0}']";
        private string DEPOSIT_CLAIM_NAME_CELL_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='closingCostsTable-{0}-gridContainer-searchGridContainer-{0}']";

        private string CLAIM_NUMBER_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsListTable-1']/tbody/tr[{0}]/td[1]/p";
        private string CLAIM_NAME_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsListTable-1']/tbody/tr[{0}]/td[2]/p";
        private string CLAIM_CODE_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsListTable-1']/tbody/tr[{0}]/td[3]/p";
        private string CLAIM_TYPE_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsListTable-1']/tbody/tr[{0}]/td[4]/p";
        private string CLAIM_BALANCE_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimsListTable-1']/tbody/tr[{0}]/td[5]/p";

       
        //Code and after locators
        //new code xpath for check claim link: "claimLinkTable-{0}-checkCodeTextBox"
        private string CHECK_CLAIM_LINK_CODE_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable-{0}-divCode']//select2";
        private string DEPOSIT_CLAIM_LINK_CODE_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='select2-closingCostsTable-{0}-checkCodeTextBox-container']";

        private By CLAIM_LINK_CODE_TEXT_INPUT_LOCATOR = By.CssSelector("input.select2-search__field");
        private By CLAIM_LINK_CODE_RESULT_LOCATOR = By.CssSelector(".select2-results__option");

        private string CHECK_CLAIM_LINK_ALLOCATION_DESCRIPTION_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable-{0}-allocation']";
        private string DEPOSIT_CLAIM_LINK_ALLOCATION_DESCRIPTION_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='{0}-allocation']";

        private string CHECK_CLAIM_LINK_NON_COMPENSABLE_LABEL_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='labelclaimLinkTable-{0}-checkNonCompensable']";
        private string DEPOSIT_CLAIM_LINK_NON_COMPENSABLE_LABEL_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='labelclosingCostsTable-{0}-checkNonCompensable']";           
        private string CHECK_CLAIM_LINK_NON_COMPENSABLE_VALUE_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='checkboxclaimLinkTable-{0}-checkNonCompensable']";
        private string DEPOSIT_CLAIM_LINK_NON_COMPENSABLE_VALUE_BY_POSITION_LOCATOR_TEMPLATE = "//*[@id='checkboxclosingCostsTable-{0}-checkNonCompensable']";

        private string CLAIM_LINK_ICON_EXPAND_BY_ROW_LOCATOR_TEMPLATE = "//*[@id='icon-{0}-expand']";

        //Claim Id for Link by Row Position
        private By CHECK_CLAIM_ID_LOCATOR = By.XPath("//*[contains(@id,'-claimId')]");
        private By DEPOSIT_CLAIM_ID_LOCATOR = By.XPath("//*[contains(@id,'-claimId')]");
        private By DEPOSIT_ASSET_ID_LOCATOR = By.XPath("//*[contains(@id,'-assetId')]");

        private string CHECK_CLAIM_LINK_CLAIM_ID_LOCATOR_BY_ROW_POSITION_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@id,'-claimId')]";
        private string DEPOSIT_CLAIM_LINK_CLAIM_ID_LOCATOR_BY_ROW_POSITION_TEMPLATE = "//*[@id='closingCostsTable']/tbody[{0}]//*[contains(@id,'-claimId')]";
        private string CLAIM_ID_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='{0}-claimId']";

        //Claim Detail
        private string CLAIM_DETAIL_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-box')]";       

        private string CLAIM_DETAIL_CLAIMED_AMOUNT_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][1]//*[contains(@class,'box-label')]";
        private string CLAIM_DETAIL_CLAIMED_AMOUNT_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][1]//*[contains(@class,'box-info')]";

        private string CLAIM_DETAIL_ALLOWED_AMOUNT_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][2]//*[contains(@class,'box-label')]";
        private string CLAIM_DETAIL_ALLOWED_AMOUNT_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][2]//*[contains(@class,'box-info')]";

        private string CLAIM_DETAIL_PAID_TO_DATE_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][3]//*[contains(@class,'box-label')]";
        private string CLAIM_DETAIL_PAID_TO_DATE_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][3]//*[contains(@class,'box-info')]";

        private string CLAIM_DETAIL_BALANCE_DUE_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][4]//*[contains(@class,'box-label')]";
        private string CLAIM_DETAIL_BALANCE_DUE_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='claimLinkTable']/tbody[{0}]//*[contains(@class,'claim-link-detail-column')][4]//*[contains(@class,'box-info')]";

        //Closing costs locators
        private By CLOSING_COSTS_CLAIM_LINKS_SECTION_TITLE_LOCATOR = By.XPath("//*[@class='sectionTitle' and contains(text(),'CLOSING COSTS')]");

        private By DEPOSIT_ADD_CLAIM_LINK_LOCATOR = By.XPath("//*[contains(@id,'button-claim')]/../*[contains(@class,'addRowOption')]");
        private By DEPOSIT_ADD_CLAIM_LINK_ICON_LOCATOR = By.XPath("//*[contains(@id,'button-claim')]");

        private By ADD_NON_CLAIM_PAYEE_LINK_LOCATOR = By.XPath("//*[contains(@id,'button-non-claim-payee')]/../*[contains(@class,'addRowOption')]");
        private By ADD_NON_CLAIM_PAYEE_LINK_ICON_LOCATOR = By.XPath("//*[contains(@id,'button-non-claim-payee')]");
        private string NON_CLAIM_PAYEE_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='{0}-claimPayeeName']";

        //Assets links
        private By DEPOSIT_ASSETS_LINKS_SECTION_TITLE_LOCATOR = By.Id("depositAssetTitle");
        private By DEPOSIT_ADD_ASSET_LINK_LOCATOR = By.XPath("//*[contains(@id,'assetLinkTable')]//*[@class='addRowOption']");
        private string DEPOSIT_ASSET_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='assetLinkTable']//*[@id='{0}-number']";
        private string DEPOSIT_ASSET_LINK_NAME_SEARCH_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='assetLinkTable-{0}-gridContainer-searchGridContainer-{0}']";
        private string DEPOSIT_ASSET_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='assetLinkTable-{0}-gridContainer-text']";
        private string DEPOSITS_ADD_ASSET_RESULT_BY_NBR_NAME_AND_CODE_LOCATOR_TEMPLATE = "//*[@id='assetLinkTable']/tbody[{0}]//*[@id='assetsListTable-{0}']/tbody/tr/td[3]/p[contains(text(),'{1}')]/../../td[1]/p[contains(text(),'{2}')]/../..";
        private string DEPOSIT_ASSET_LINK_AMOUNT_BY_ROW_POSITION_LOCATOR = "//*[@id='assetLinkTable-{0}-amount']";
        private string DEPOSIT_ASSET_LINK_FA_DATE_BY_ROW_POSITION_LOCATOR = "//*[@id='assetLinkTable-{0}-administeredDate']";
        private string DEPOSIT_ASSET_LINK_CODE_BY_ROW_POSITION_LOCATOR = "//*[@id='select2-assetLinkTable-{0}-checkCodeTextBox-container']";
        private string CHECK_CLAIM_LINK_USE_AS_PAYEE_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE = "//*[@id='labelclaimLinkTable-{0}-checkUsePayeeName']";

        public ClaimLinksComponent(IWebDriver driver, bool isCheck, bool isNew) : base(driver, isCheck, isNew)
        {

        }

        public string ClaimLinksSectionTitle
        {
            get
            {
                if(this.isCheck)
                 return this.WaitForElementToBeVisible(CHECK_CLAIM_LINKS_SECTION_TITLE_LOCATOR).Text;                
                else
                 return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_LINKS_SECTION_TITLE_LOCATOR).Text;
            }
        }

        public string AddClaimLinkText
        {
            get
            {
                return this.WaitForElementToBeVisible(this.GetAddClaimLinkLocator()).Text;
            }
        }

        private By GetAddClaimLinkLocator()
        {
            if (this.isCheck)
                return CHECK_ADD_CLAIM_LINK_LOCATOR;
            else
                return DEPOSIT_ADD_CLAIM_LINK_LOCATOR;
        }

        public string ClaimNumberLabel
        {
            get
            {                
                if(this.isCheck)
                    return this.WaitForElementToBeVisible(CHECK_CLAIM_NUMBER_LABEL_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_NUMBER_LABEL_LOCATOR).Text;

            }
        }

        public object ClaimNameLabel
        {
            get
            {
                if (this.isCheck)
                    return this.WaitForElementToBeVisible(CHECK_CLAIM_NAME_LABEL_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_NAME_LABEL_LOCATOR).Text;

            }
        }

        public object ClaimCodeLabel
        {
            get
            {
                if (this.isCheck)
                    return this.WaitForElementToBeVisible(CHECK_CLAIM_CODE_LABEL_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_CODE_LABEL_LOCATOR).Text;
            }
        }

        public object ClaimAllocationDescriptionLabel
        {
            get
            {
                if (this.isCheck)
                    return this.WaitForElementToBeVisible(CHECK_CLAIM_ALLOCATION_DESCRIPTION_LABEL_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_ALLOCATION_DESCRIPTION_LABEL_LOCATOR).Text;

            }
        }

        public object ClaimNonCompensableLabel
        {
            get
            {
                if (this.isCheck)
                    return this.WaitForElementToBeVisible(CHECK_CLAIM_NON_COMPENSABLE_LABEL_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_NON_COMPENSABLE_LABEL_LOCATOR).Text;

            }
        }

        public object ClaimAmountLabel
        {
            get
            {
                if (this.isCheck)
                    return this.WaitForElementToBeVisible(CHECK_CLAIM_AMOUNT_LABEL_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(DEPOSIT_CLAIM_AMOUNT_LABEL_LOCATOR).Text;

            }
        }

        public void SetClaimLinkUseAsPayeeNameOnRowPosition(bool useAsPayeeName, int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            this.Pause(1);
            IWebElement claimSetAsPayeenameInputWE = this.WaitForElementToBeVisible(By.XPath(String.Format(CHECK_CLAIM_LINK_USE_AS_PAYEE_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition)));
            
            //if not already as expected, then click the checkbox
            if ((useAsPayeeName && !claimSetAsPayeenameInputWE.Selected) ||((!useAsPayeeName && claimSetAsPayeenameInputWE.Selected)))
                claimSetAsPayeenameInputWE.Click();
        }

        public string GetClaimNumberGridHeaderByRowPosition(int rowPosition)
        {
            this.Pause(2);
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_NUMBER_GRID_HEADER_LOCATOR_TEMPLATE, rowPosition))).Text;           
        }

        public string GetClaimNameGridHeaderByRowPosition(int rowPosition)
        {            
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_NAME_GRID_HEADER_LOCATOR_TEMPLATE, rowPosition))).Text;            
        }

        public string GetClaimCodeGridHeaderByRowPosition(int rowPosition)
        {
             return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_CODE_GRID_HEADER_LOCATOR_TEMPLATE, rowPosition))).Text;
        }
        public string GetClaimTypeGridHeaderByRowPosition(int rowPosition)
        {           
             return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_TYPE_GRID_HEADER_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimBalanceGridHeaderByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_BALANCE_GRID_HEADER_LOCATOR_TEMPLATE, rowPosition))).Text;

        }

        public string ClaimsListMessage {
            get {
                return this.WaitForElementToBeVisible(CLAIMS_GRID_NO_RESULTS_MESSAGE_LOCATOR).Text;
            }
        }

        public bool IsAddClaimLinkIconVisible()
        {
            return this.IsElementVisible(this.GetAddCLaimLinkIconLocator());
        }

        private By GetAddCLaimLinkIconLocator()
        {
            if (this.isCheck)
                return CHECK_ADD_CLAIM_LINK_ICON_LOCATOR;
            else
                return DEPOSIT_ADD_CLAIM_LINK_ICON_LOCATOR;
        }

        private void ScrollToAddClaimsLinkSection()
        {
            this.ScrollUpToPageTop();
            IWebElement linksTitle;

                if (this.isCheck)

                {
                    linksTitle = this.WaitForElementToBeVisible(CHECK_CLAIM_LINKS_SECTION_TITLE_LOCATOR);

                }
                else
                {
                    linksTitle = this.WaitForElementToBeVisible(DEPOSIT_CLAIM_LINKS_SECTION_TITLE_LOCATOR);

                }

            this.JSMoveToViewElement(linksTitle);
            this.ScrollDownToAvoidStickyHeadersOnClick();
        }

        private void ScrollToAddAssetsLinkSection()
        {
            //move to section between save button and claims link title to assuere element visibility
            this.MoveToViewElement(this.WaitForElementToBeVisible(SAVE_BUTTON_LOCATOR));
            this.MoveToViewElement(this.WaitForElementToBeVisible(DEPOSIT_ASSETS_LINKS_SECTION_TITLE_LOCATOR));
        }

        public void ClickAddClaimLink()
        {
            this.ScrollToAddClaimsLinkSection();
            this.WaitForElementToBeClickeable(this.GetAddClaimLinkLocator()).Click();
        }

        public string GetClaimNamePlaceholderByRowPosition(int rowPosition)
        {
            if(this.isCheck)
                return this.WaitForElementToBeVisible(By.XPath(String.Format(CHECK_CLAIM_NAME_CELL_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("placeholder");
            else
                return this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_CLAIM_NAME_CELL_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("placeholder");
        }

        public void ClickClaimSearchBoxByRow(int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            this.GetClaimLinkBoxWE(rowPosition).Click();            
            this.Pause(1);
            //wait for table to display before performing other actions
        }        

        public void EnterTextOnClaimSearchBoxByRow(string searchText, int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            IWebElement claimNameInputWE = this.GetClaimLinkBoxWE(rowPosition);
            this.ClearAndType(claimNameInputWE, searchText);
            //wait for search to complete before to do any other action
            this.Pause(2);
        }
        private IWebElement GetClaimLinkBoxWE(int rowPosition)
        {
            string locator = "";
            if (this.isCheck)
                locator = String.Format(CHECK_CLAIM_LINK_NAME_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE,rowPosition,rowPosition);
            else
                locator = String.Format(DEPOSIT_CLAIM_LINK_NAME_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition, rowPosition);
            return this.WaitForElementToBeVisible(By.XPath(locator));
        }

        public void SelectClaimFromResultsUsingMethod(int rowPosition, string number, string name, string code, string selectionMethod)
        {     
            //identify result to select
            IWebElement resultWE = this.GetResultWEByRowPosition(rowPosition,number,name, code);

            //select with given method
            Actions highlightElement = new Actions(driver);           
            switch (selectionMethod)
            {
                case "Click":
                    {
                        try
                        {
                            resultWE.Click();
                        }
                        catch (Exception)
                        {
                            //move down to see complete Search Claim grid
                            this.JSMoveToViewElement(this.WaitForElementToBeVisible(CLEARED_DATE_INPUT_LOCATOR));
                            resultWE.Click();
                        }
                    }
                    break;
                case "Tab":
                    highlightElement.MoveToElement(resultWE).SendKeys(Keys.Tab).Build().Perform();
                    break;
                case "Enter":
                    highlightElement.MoveToElement(resultWE).SendKeys(Keys.Enter).Build().Perform();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsClaimDetailViewArrowVisibleByRowPosition(int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            try
            {
                this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_LINK_ICON_EXPAND_BY_ROW_LOCATOR_TEMPLATE, rowPosition)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IWebElement GetResultWEByRowPosition(int rowPosition, string number, string name, string code)
        {
            string locator = "";
                locator = String.Format(TRANSACTION_ADD_CLAIM_RESULT_BY_NBR_NAME_AND_CODE_LOCATOR_TEMPLATE, rowPosition, name, code, number);

            return this.WaitForElementToBeVisible(By.XPath(locator));
        }

        public int GetClaimLinksCount()
        {
            try
            {
                return this.WaitForElementsToBeVisible(this.GetClaimLinkRowLocator()).Count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private By GetClaimLinkRowLocator()
        {
            if (this.isCheck)
                return CHECK_CLAIM_LINK_ROW_LOCATOR;
            else
                return DEPOSIT_CLAIM_LINK_ROW_LOCATOR;
        }

        public bool ClaimLinksCountIsZero()
        {
            try
            {
                this.WaitForElementToDissapear(this.GetClaimLinkRowLocator(), 10);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<ClaimData> GetListOfClaimsOnLinkSearchGrid()
        {
            this.Pause(2);
            List<ClaimData> claims = new List<ClaimData>();
            int totalClaims = this.WaitForElementsToBeVisible(CLAIM_GRID_ROW_LOCATOR).Count;
            
            for (int position=0; position < totalClaims; position++ )
            {
                ClaimData newClaim = new ClaimData();
                //newClaim.Id = this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_ID_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, position + 1))).Text;
                newClaim.ClaimNumber = this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_NUMBER_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, position+1))).Text.TrimStart().TrimEnd();
                newClaim.CreditorName = this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_NAME_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, position + 1))).Text.TrimStart().TrimEnd();
                newClaim.Code = this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_CODE_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, position + 1))).Text.TrimStart().TrimEnd();
                newClaim.Class = this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_TYPE_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, position + 1))).Text.TrimStart().TrimEnd();
                newClaim.Balance = this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_BALANCE_BY_GRID_ROW_POSITION_LOCATOR_TEMPLATE, position + 1))).Text.TrimStart().TrimEnd();

                claims.Add(newClaim);
            }
            return claims;
        }        

        public int GetCountOfClaimsAvailableToLink()
        {
            try
            {
                return this.WaitForElementsToBeVisible(CLAIM_GRID_ROW_LOCATOR, 10).Count;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public bool HasClaimsGridDissapeared()
        {
            try
            {
                this.WaitForElementToDissapear(CLAIMS_GRID_TABLE_LOCATOR,10);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetClaimLinkNumberByRowPosition(int rowPosition)
        {
            IWebElement numberTdWE = this.WaitForElementToBeVisible(this.GetClaimLinkNumberLocator(rowPosition));            

            try
            {
               return numberTdWE.FindElement(By.XPath(".//p")).Text;
            }
            catch (Exception)
            {

                return "";
            }           
            
        }

        private By GetClaimLinkNumberLocator(int rowPosition)
        {
            if (isNew)
            {
                if (isCheck)

                    return By.XPath(String.Format(CHECK_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));
                else
                    return By.XPath(String.Format(DEPOSIT_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));
            }
            else
            {
                if (isCheck)

                    return By.XPath(String.Format(CHECK_EDIT_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));
                else
                    return By.XPath(String.Format(DEPOSIT_CLAIM_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));
            }

        }

        public string GetClaimLinkNameByRowPosition(int rowPosition)
        {
            string locatorTpl;
            if (this.isCheck)
                locatorTpl = CHECK_CLAIM_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE;
            else
                locatorTpl = DEPOSIT_CLAIM_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE;

            return this.WaitForElementToBeVisible(By.XPath(String.Format(locatorTpl, rowPosition))).Text;
        }

        public void ClickOnClaimLinkRemoveIconByRowPosition(int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            if(this.isCheck)
                this.WaitForElementToBeVisible(By.XPath(String.Format(CHECK_DELETE_CLAIM_LINK_ICON_BY_ROW_POSITION_LOCATOR, rowPosition))).Click();
            else
                this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_DELETE_CLAIM_LINK_ICON_BY_ROW_POSITION_LOCATOR, rowPosition))).Click();
        }

        public string GetClaimLinkCodeByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(this.GetClaimLinkCodeLocator(rowPosition)).Text;
        }

        private By GetClaimLinkCodeLocator(int rowPosition)
        {
            string locator = "";
            if (this.isCheck)
                locator = CHECK_CLAIM_LINK_CODE_BY_ROW_POSITION_LOCATOR_TEMPLATE;
            else
                locator = DEPOSIT_CLAIM_LINK_CODE_BY_ROW_POSITION_LOCATOR_TEMPLATE;

            return By.XPath(String.Format(locator, rowPosition));
        }

        public bool IsClaimOnList(int rowPosition, string number, string name, string code)
        {
            try
            {
                this.WaitForElementToBeVisible(By.XPath(String.Format(TRANSACTION_ADD_CLAIM_RESULT_BY_NBR_NAME_AND_CODE_LOCATOR_TEMPLATE,rowPosition,number,name,code)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SelectFirstClaimFromResults(int rowPosition)
        {
            //move down to ledger section to see complete Search Claim grid
            this.MoveToViewElement(this.WaitForElementToBeVisible(LEDGER_SECTION_TITLE_LOCATOR));
            this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_GRID_ROW_BY_LINK_POSITION_LOCATOR_TEMPLATE, rowPosition))).Click();
        }

        public void EnterClaimLinkAmountOnRowPosition(string amount, int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            this.Pause(1);
            IWebElement claimAmountInputWE = this.WaitForElementToBeVisible(this.GetClaimLinkAmountLocator(rowPosition));
            this.ClearAndType(claimAmountInputWE, amount);
         
        }

        private By GetClaimLinkAmountLocator(int rowPosition)
        {
            if (this.isCheck)
                return By.XPath(String.Format(CHECK_CLAIM_LINK_AMOUNT_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));
            else
                return By.XPath(String.Format(DEPOSIT_CLAIM_LINK_AMOUNT_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));

        }

        public string GetClaimLinkAmountByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(this.GetClaimLinkAmountLocator(rowPosition)).GetAttribute("value");
        }


        public void EnterClaimLinkCodeOnRowPosition(string code, int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();

            By locator;
            if (this.isCheck)
                locator = By.XPath(String.Format(CHECK_CLAIM_LINK_CODE_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));
            else
                locator = By.XPath(String.Format(DEPOSIT_CLAIM_LINK_CODE_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition));

            this.WaitForElementToBeVisible(locator).Click();
            this.ClearAndType(this.WaitForElementToBeVisible(CLAIM_LINK_CODE_TEXT_INPUT_LOCATOR), code);
            this.Pause(2);
            this.WaitForElementToBeVisible(CLAIM_LINK_CODE_RESULT_LOCATOR).Click();
        }

        public void EnterClaimLinkAllocationDescriptionOnRowPosition(string allocDescription, int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            IWebElement allocDescriptionWE = this.WaitForElementToBeVisible(this.GetClaimLinkAllocationDescriptionLocator(rowPosition));
            this.ClearAndType(allocDescriptionWE, allocDescription);
        }

        public string GetClaimLinkAllocationDescriptionByRowPosition(int rowPosition)
        {
            string locator = "";
            if (this.isCheck)
                locator = CHECK_CLAIM_LINK_ALLOCATION_DESCRIPTION_BY_ROW_POSITION_LOCATOR_TEMPLATE;
            else
                locator = DEPOSIT_CLAIM_LINK_ALLOCATION_DESCRIPTION_BY_ROW_POSITION_LOCATOR_TEMPLATE;

            return this.WaitForElementToBeVisible(this.GetClaimLinkAllocationDescriptionLocator(rowPosition)).GetAttribute("value");
        }

        private By GetClaimLinkAllocationDescriptionLocator(int rowPosition)
        {
            string locator = "";
            if (this.isCheck)
                locator = CHECK_CLAIM_LINK_ALLOCATION_DESCRIPTION_BY_ROW_POSITION_LOCATOR_TEMPLATE;
            else
                locator = DEPOSIT_CLAIM_LINK_ALLOCATION_DESCRIPTION_BY_ROW_POSITION_LOCATOR_TEMPLATE;

            return By.XPath(String.Format(locator, rowPosition));
        }

        public void SetClaimLinkNonCompensableOnRowPosition(bool nonCompensable, int rowPosition)
        {
           
            IWebElement nonCompensableWE = this.WaitForElementToBePresent(By.XPath(String.Format(this.GetClaimLinkNonCompensableValueLoctorTpl(), rowPosition)));

            if ((nonCompensable && !nonCompensableWE.Selected) || (!nonCompensable && nonCompensableWE.Selected))
            {
                IWebElement nonCompensableLabelWE = this.WaitForElementToBePresent(By.XPath(String.Format(this.GetClaimLinkNonCompensableLabelLoctorTpl(), rowPosition)));
                nonCompensableLabelWE.Click();
            }
        }

        private string GetClaimLinkNonCompensableValueLoctorTpl()
        {
            if (this.isCheck)
               return CHECK_CLAIM_LINK_NON_COMPENSABLE_VALUE_BY_POSITION_LOCATOR_TEMPLATE;
            else
                return DEPOSIT_CLAIM_LINK_NON_COMPENSABLE_VALUE_BY_POSITION_LOCATOR_TEMPLATE;
        }

        private string GetClaimLinkNonCompensableLabelLoctorTpl()
        {
            if (this.isCheck)
                return CHECK_CLAIM_LINK_NON_COMPENSABLE_LABEL_BY_POSITION_LOCATOR_TEMPLATE;
            else
                return DEPOSIT_CLAIM_LINK_NON_COMPENSABLE_LABEL_BY_POSITION_LOCATOR_TEMPLATE;
        }

        public bool IsClaimLinkNonCompensableSelectedByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBePresent(By.XPath(String.Format(this.GetClaimLinkNonCompensableValueLoctorTpl(), rowPosition))).Selected;
        }

        public bool IsClaimLinkNonCompensableVisibleByRowPosition(int rowPosition)
        {
           return this.IsElementVisible(By.XPath(String.Format(this.GetClaimLinkNonCompensableLabelLoctorTpl(), rowPosition)));
        }

        public void ClickOnClaimDetailViewArrowByRowPosition(int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_LINK_ICON_EXPAND_BY_ROW_LOCATOR_TEMPLATE, rowPosition))).Click();
        }

        public bool IsClaimDetailViewArrowUpByRowPosition(int rowPosition)
        {
            IWebElement expandLinkWE = this.WaitForElementToBeClickeable(By.XPath(String.Format(CLAIM_LINK_ICON_EXPAND_BY_ROW_LOCATOR_TEMPLATE, rowPosition)));
            return expandLinkWE.GetAttribute("class").Contains("fa-chevron-up");
        }
        public bool IsClaimDetailViewArrowDownByRowPosition(int rowPosition)
        {
            IWebElement expandLinkWE = this.WaitForElementToBeClickeable(By.XPath(String.Format(CLAIM_LINK_ICON_EXPAND_BY_ROW_LOCATOR_TEMPLATE, rowPosition)));
            return expandLinkWE.GetAttribute("class").Contains("fa-chevron-down");
        }

        public string GetClaimIdFromLinkInRowPosition(int rowPosition)
        {
            return this.WaitForElementToBePresent(By.XPath(String.Format(CLAIM_ID_BY_ROW_POSITION_LOCATOR_TEMPLATE,rowPosition))).GetAttribute("value");
        }

        public string GetClaimDetailClaimedLabelByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_CLAIMED_AMOUNT_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailClaimedByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_CLAIMED_AMOUNT_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailAllowedLabelByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_ALLOWED_AMOUNT_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailAllowedByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_ALLOWED_AMOUNT_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailPaidToDateLabelByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_PAID_TO_DATE_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailPaidToDateByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_PAID_TO_DATE_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailBalanceDueLabelByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_BALANCE_DUE_LABEL_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetClaimDetailBalanceDueByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(CLAIM_DETAIL_BALANCE_DUE_VALUE_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public bool ClaimDetailBoxesInvisible(int rowPosition)
        {
            try
            {
                this.WaitForElementToDissapear(By.XPath(String.Format(CLAIM_DETAIL_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE,rowPosition)), 5);
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        public List<AssetLinkData> GetAssetsLinksData()
        {
            List<AssetLinkData> assetsLinked = new List<AssetLinkData>();

            try
            {
                IReadOnlyCollection<IWebElement> idsList = this.WaitForElementsToBePresent(DEPOSIT_ASSET_ID_LOCATOR);
                int rowPosition = 1;
                foreach (IWebElement idWE in idsList)
                {
                    AssetLinkData newLink = new AssetLinkData();
                    newLink.Id = idWE.GetAttribute("value");
                    newLink.Number = this.GetAssetNumberByRowPosition(rowPosition);
                    newLink.Description = this.GetAssetDescriptionByRowPosition(rowPosition);
                    newLink.Code = this.GetAssetCodeByRowPosition(rowPosition);
                    newLink.FullAdministeredDate= this.GetAssetFullAdministeredDateByRowPosition(rowPosition);
                    newLink.Amount = this.GetAssetLinkAmountByRowPosition(rowPosition);
                    assetsLinked.Add(newLink);
                    rowPosition++;
                }
            }
            catch (Exception)
            {
                //do nothing, returns an empty list if there are no claim links
            }
            

            return assetsLinked;
        }

        
        public List<string> GetClaimsLinksIds()
        {
            By locator;
            if (this.isCheck)
                locator = CHECK_CLAIM_ID_LOCATOR;
            else
                locator = DEPOSIT_CLAIM_ID_LOCATOR;

            List<string> claimsLinked = new List<string>();

            try
            {                
                IReadOnlyCollection<IWebElement> idsList = this.WaitForElementsToBePresent(locator);

                foreach (IWebElement idWE in idsList)
                {
                    claimsLinked.Add(idWE.GetAttribute("value"));
                }
            }
            catch (Exception)
            {
                //do nothing, returns an empty list if there are no claim links
            }
            

            return claimsLinked;
        }

        public List<ClaimLinkData> GetClaimsLinksData()
        {
           

            List<ClaimLinkData> claimsLinked = new List<ClaimLinkData>();

            try
            {
                IReadOnlyCollection<IWebElement> closingCostLinks = this.WaitForElementsToBeVisible(DEPOSIT_CLAIM_LINK_ROW_LOCATOR);

                int rowPosition = 1;

                foreach (IWebElement link in closingCostLinks)
                {
                    try
                    {
                        //if it's a claim, then save it
                        ClaimLinkData linkData = new ClaimLinkData();
                        linkData.Id = this.GetClaimLinkIdByRowPosition(rowPosition);
                        linkData.Number = this.GetClaimLinkNumberByRowPosition(rowPosition);
                        linkData.Name = this.GetClaimLinkNameByRowPosition(rowPosition);
                        linkData.Code = this.GetClaimLinkCodeByRowPosition(rowPosition);
                        linkData.Description = this.GetClaimLinkAllocationDescriptionByRowPosition(rowPosition);
                        linkData.NonCompensable = this.IsClaimLinkNonCompensableSelectedByRowPosition(rowPosition);
                        linkData.Amount = this.GetClaimLinkAmountByRowPosition(rowPosition);

                        //get claim original data from DB 
                        DataRowCollection data = this.GetClaimOriginalDataFromDB(linkData.Id);
                            foreach (DataRow row in data)
                        {
                            linkData.OriginalClaimCode = row.Field<string>("Code");
                            linkData.PaidAmount = row.Field<decimal>("PaidAmount");
                            linkData.BalanceAmount = row.Field<decimal>("BalanceAmount");
                        }

                        claimsLinked.Add(linkData);
                    }
                    catch (Exception)
                    {
                        //is not a claim, GetClaimLinkIdByRowPosition will fail, so do not save it because it's a non claim payee link
                    }

                    rowPosition++;
                }
            }
            catch (Exception)
            {
                //do nothing, returns an empty list if there are no claim links
            }


            return claimsLinked;
        }       

        //Query the DB to get the paid original value of a claim by its claim id
        private DataRowCollection GetClaimOriginalDataFromDB(string id)
        {
            DataTable results = new DataTable();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("ClaimId", id);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings.Get("DBConnectionString")))
            {
                //Prepare command to execute
                SqlCommand command = new SqlCommand(Properties.Resources.GetClaimDetailsInfo, connection);

                //Add given parameters
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> param in parameters)
                    {
                        command.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }

                //Connect to DB and execute
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(results);
                TestsLogger.Log("Get Claim Details to get Paid amount - RowsAffected: " + results.Rows.Count);
            }

            return results.Rows;            
        }

        private string GetClaimLinkIdByRowPosition(int rowPosition)
        {
            string locator;
            if (this.isCheck)
                locator = CHECK_CLAIM_LINK_CLAIM_ID_LOCATOR_BY_ROW_POSITION_TEMPLATE;
            else
                locator = DEPOSIT_CLAIM_LINK_CLAIM_ID_LOCATOR_BY_ROW_POSITION_TEMPLATE;

            return this.WaitForElementToBePresent(By.XPath(String.Format(locator, rowPosition))).GetAttribute("value");
        }

        public List<NonClaimPayeeLinkData> GetNonClaimPayeeLinksData()
        {
            List<NonClaimPayeeLinkData> nonClaimsLinked = new List<NonClaimPayeeLinkData>();

            try
            {
                IReadOnlyCollection<IWebElement> closingCostLinks = this.WaitForElementsToBeVisible(DEPOSIT_CLAIM_LINK_ROW_LOCATOR);

                int rowPosition = 1;

                foreach (IWebElement link in closingCostLinks)
                {
                    try
                    {
                        //if is not a claim, then save it
                        NonClaimPayeeLinkData linkData = new NonClaimPayeeLinkData();
                        linkData.Name = this.GetNonClaimPayeeNameByRowPosition(rowPosition);
                        linkData.Code = this.GetClaimLinkCodeByRowPosition(rowPosition);
                        linkData.Description = this.GetClaimLinkAllocationDescriptionByRowPosition(rowPosition);
                        linkData.NonCompensable = this.IsClaimLinkNonCompensableSelectedByRowPosition(rowPosition);
                        linkData.Amount = this.GetClaimLinkAmountByRowPosition(rowPosition);

                        nonClaimsLinked.Add(linkData);

                    }
                    catch (Exception)
                    {
                        //if its a claim, Name search will fail, so do not save it because it's a claim link
                    }

                    rowPosition++;
                }
            }
            catch (Exception)
            {
                //do nothing, returns an empty list if there are no claim links
            }


            //remove last comma and return
            return nonClaimsLinked;
        }

        //deposits methods
        public string ClosingCostsClaimLinksSectionTitle {
            get {
                return this.WaitForElementToBeVisible(CLOSING_COSTS_CLAIM_LINKS_SECTION_TITLE_LOCATOR).Text;
            }
        }

        public void ClickAddNonClaimPayeeLink()
        {
            this.ScrollToAddClaimsLinkSection();
            this.WaitForElementToBeVisible(ADD_NON_CLAIM_PAYEE_LINK_LOCATOR).Click();
        }

        public string AddNonClaimPayeeLinkText
        {
            get {
                return this.WaitForElementToBeVisible(ADD_NON_CLAIM_PAYEE_LINK_LOCATOR).Text;
            }
        }

        public void EnterNonClaimPayeeNameByRow(string name, int rowPosition)
        {
            this.ScrollToAddClaimsLinkSection();
            this.ClearAndType(this.WaitForElementToBeVisible(By.XPath(String.Format(NON_CLAIM_PAYEE_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))), name);
        }

        public string GetNonClaimPayeeNamePlaceholder(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(NON_CLAIM_PAYEE_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("placeholder");
        }

        public string GetNonClaimPayeeNameByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(NON_CLAIM_PAYEE_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).GetAttribute("value");
        }

        public string GetNonClaimPayeeCodePlaceholder(int rowPosition)
        {
            string locator = "";
            if (this.isCheck)
                locator = CHECK_CLAIM_LINK_CODE_PLACEHOLDER_BY_ROW_POSITION_LOCATOR_TEMPLATE;
            else
                locator = DEPOSIT_CLAIM_LINK_CODE_PLACEHOLDER_BY_ROW_POSITION_LOCATOR_TEMPLATE;

            
            return this.WaitForElementToBeVisible(By.XPath(String.Format(locator, rowPosition))).Text;           
        }

        //ASSET links
        public void ClickAddAssetLink()
        {
            this.ScrollToAddAssetsLinkSection();
            this.WaitForElementToBeClickeable(DEPOSIT_ADD_ASSET_LINK_LOCATOR).Click();
        }

        

        public void ClickAssetSearchBoxByRow(int rowPosition)
        {
            this.ScrollToAddAssetsLinkSection();
            this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_NAME_SEARCH_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition, rowPosition))).Click();
            this.Pause(1);
            //wait for table to display before performing other actions
        }

        public void EnterTextOnAssetSearchBoxByRow(string searchText, int rowPosition)
        {
            this.ScrollToAddAssetsLinkSection();
            IWebElement assetNameInputWE = this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_NAME_SEARCH_BOX_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition, rowPosition)));
            this.ClearAndType(assetNameInputWE, searchText);
            //wait for search to complete before to do any other action
            this.Pause(2);
        }
        
        public void SelectAssetFromResultsUsingMethod(int rowPosition, string number, string name, string code, string selectionMethod)
        {
            //identify result to select
            IWebElement resultWE = this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSITS_ADD_ASSET_RESULT_BY_NBR_NAME_AND_CODE_LOCATOR_TEMPLATE, rowPosition, code, number)));

            //select with given method
            Actions highlightElement = new Actions(driver);
            switch (selectionMethod)
            {
                case "Click":
                    {
                        try
                        {
                            resultWE.Click();

                        }
                        catch (Exception)
                        {
                            
                            if (this.isNew) //move down to ledger section to see complete Search Claim grid
                                this.MoveToViewElement(this.WaitForElementToBeVisible(LEDGER_SECTION_TITLE_LOCATOR));
                            else  //move down to see complete Search Claim grid
                                this.JSMoveToViewElement(this.WaitForElementToBeVisible(CLEARED_DATE_INPUT_LOCATOR));

                            resultWE.Click();
                        }
                    }
                    break;
                case "Tab":
                    highlightElement.MoveToElement(resultWE).SendKeys(Keys.Tab).Build().Perform();
                    break;
                case "Enter":
                    highlightElement.MoveToElement(resultWE).SendKeys(Keys.Enter).Build().Perform();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }        

        public void SetAssetLinkAmountByRowPosition(string amount, int rowPosition)
        {
            this.ScrollToAddAssetsLinkSection();
            this.ClearAndType(this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_AMOUNT_BY_ROW_POSITION_LOCATOR,rowPosition))),amount);
        }

        public void SetAssetLinkFADateByRowPosition(string date, int rowPosition)
        {
            this.ScrollToAddAssetsLinkSection();
            this.ClearAndType(this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_FA_DATE_BY_ROW_POSITION_LOCATOR, rowPosition))), date);
        }

        private string GetAssetNumberByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_NUMBER_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        public string GetAssetDescriptionByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_NAME_BY_ROW_POSITION_LOCATOR_TEMPLATE, rowPosition))).Text;
        }

        private string GetAssetCodeByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_CODE_BY_ROW_POSITION_LOCATOR, rowPosition))).Text;
        }

        public string GetAssetFullAdministeredDateByRowPosition(int rowPosition)
        {
            return this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_FA_DATE_BY_ROW_POSITION_LOCATOR, rowPosition))).GetAttribute("value");
        }

        public string GetAssetLinkAmountByRowPosition(int rowPosition)
        {            
            return this.WaitForElementToBeVisible(By.XPath(String.Format(DEPOSIT_ASSET_LINK_AMOUNT_BY_ROW_POSITION_LOCATOR, rowPosition))).GetAttribute("value");
        }

    }
}