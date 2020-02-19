using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dashboard;
using OpenQA.Selenium;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin
{
    public class SuperAdminPage:UnityPageBase
    {
        //super admin universal search
        private By UNIVERSAL_SEARCH_TOOL_LOCATOR = By.XPath("//superadmin-universal-search//*[@id='universalSearchContainer']");

        //case and office info
        private By OFFICE_NAME_LOCATOR = By.XPath("//*[contains(@class,'superadminOfficeName')]");
        private By CASE_INFO_LOCATOR = By.XPath("//*[contains(@class,'superadminCaseInfo')]");
        private By ITEMS_CARD_TITLE_LOCATOR = By.Id("Title");

        //caution message
        private By WARNING_MESSAGE_LOCATOR = By.XPath("//*[contains(@class,'superadminWarningMessage')]");
        private By ALERT_MESSAGE_LOCATOR = By.XPath("//*[contains(@class,'superadminAlertMessage')]"); 

        //items buttons
        private By ASSETS_BUTTON_LOCATOR = By.XPath("//*[contains(@class,'superadminContainer')]//button[contains(text(),'Asset')]");
        private By DOCKETS_BUTTON_LOCATOR = By.XPath("//*[contains(@class,'superadminContainer')]//button[contains(text(),'Docket')]");
        private By DOCUMENTS_BUTTON_LOCATOR = By.XPath("//*[contains(@class,'superadminContainer')]//button[contains(text(),'Document')]");

        //list elements
        private string ASSET_CHECKBOX_BY_ID_LOCATOR_TEMPLATE = "//*[contains(@id,'labelasset-checkbox-{0}')]";
        private string DOCKET_CHECKBOX_BY_ID_LOCATOR_TEMPLATE = "//*[contains(@id,'labeldocket-checkbox-{0}')]";
        private string DOCUMENT_CHECKBOX_BY_ID_LOCATOR_TEMPLATE = "//*[contains(@id,'labeldocument-checkbox-{0}')]";
        private string ASSET_BY_NAME_LOCATOR_TEMPLATE = "//*[contains(@class,'assetRow')]//*[contains(@class,'assetStatusColumn')]//*[contains(text(),'{0}')]";
        

        //actions buttons
        private By DELETE_BUTTON_LOCATOR = By.XPath("//*[contains(@class,'save') and contains(text(),'Delete')]");
        private By CANCEL_BUTTON_LOCATOR = By.XPath("//*[contains(@class,'save') and contains(text(),'Cancel')]");

        public SuperAdminPage(IWebDriver driver): base(driver, "Super Admin")
        {

        }
        

        public UniversalSearch UniversalSearch
        {
            get
            {
                this.WaitForElementToBeVisible(UNIVERSAL_SEARCH_TOOL_LOCATOR);
                return new UniversalSearch(driver, "//superadmin-universal-search");
            }
        }

        public string OfficeInfo
        {
            get
            {
                return this.WaitForElementToBeVisible(OFFICE_NAME_LOCATOR).Text;
            }
        }

        public string CaseInfo
        {
            get
            {
                return this.WaitForElementToBeVisible(CASE_INFO_LOCATOR).Text;
            }
        }

        public string AssetsButtonText {
            get {
                return this.WaitForElementToBeVisible(ASSETS_BUTTON_LOCATOR).Text;
            }
        }

        public string DocketsButtonText
        {
            get
            {
                return this.WaitForElementToBeVisible(DOCKETS_BUTTON_LOCATOR).Text;
            }
        }

        public string DocumentsButtonText
        {
            get
            {
                return this.WaitForElementToBeVisible(DOCUMENTS_BUTTON_LOCATOR).Text;
            }
        }

        public string AlertMessage {
            get {
               string listTitle=  this.ItemsListTitle; ;
                if(listTitle.Contains("Documents"))
                    return this.WaitForElementToBeVisible(ALERT_MESSAGE_LOCATOR).Text;
                else
                    return this.WaitForElementToBeVisible(WARNING_MESSAGE_LOCATOR).Text;
            }
        }
        public string ItemsListTitle {
            get {
                return this.WaitForElementToBeVisible(ITEMS_CARD_TITLE_LOCATOR).Text;
            }
        }

        public void ClickAssetButton()
        {
            this.WaitForElementToBeVisible(ASSETS_BUTTON_LOCATOR).Click();
        }

        public void ClickDocketButton()
        {
            this.WaitForElementToBeVisible(DOCKETS_BUTTON_LOCATOR).Click();
        }

        public void ClickDocumentButton()
        {
            this.WaitForElementToBeVisible(DOCUMENTS_BUTTON_LOCATOR).Click();
        }

        public void SelectAssetToDeleteById(int assetId)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(ASSET_CHECKBOX_BY_ID_LOCATOR_TEMPLATE, assetId))).Click();
        }

        public ConfirmationDialog ClickDeleteButton()
        {
            this.WaitForElementToBeClickeable(DELETE_BUTTON_LOCATOR).Click();
            this.WaitForBlockOverlayToDissapear();
            return new ConfirmationDialog(driver);
        }

        public void ClickCancelButton()
        {
            this.WaitForElementToBeClickeable(CANCEL_BUTTON_LOCATOR).Click();
        }

        public bool AssetHasDissapeared(string asset)
        {
            try
            {
                this.WaitForElementToDissapear(By.XPath(String.Format(ASSET_BY_NAME_LOCATOR_TEMPLATE, asset)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AssetIsVisibleOnList(string asset)
        {
            try
            {
                this.WaitForElementToBeVisible(By.XPath(String.Format(ASSET_BY_NAME_LOCATOR_TEMPLATE, asset)));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SelectDocketToDeleteById(int itemId)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(DOCKET_CHECKBOX_BY_ID_LOCATOR_TEMPLATE, itemId))).Click();

        }

        public void SelectDocumentToDeleteById(int itemId)
        {
            this.WaitForElementToBeVisible(By.XPath(String.Format(DOCUMENT_CHECKBOX_BY_ID_LOCATOR_TEMPLATE, itemId))).Click();

        }
    }
}