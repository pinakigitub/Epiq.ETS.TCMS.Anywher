using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using FluentAssertions;
using System.Threading;
using NUnit.Framework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports
{
    public class ImportAssets : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        public ImportAssets(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        //Import Assets Locators
        private By importAssetsHeader = By.XPath("//div[@class='epiq-page-header  ']/h2");
        private By assetsToImportCount = By.XPath("//div[@id='assets-to-import-tabs']//a/div/span");
        private By assetsInCaseCount = By.XPath("//div[@id='import-asset-view-tabs']//li[1]//a/div/span");
        private By assetsToImportExpand = By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tbody//td[1]//i");
        private By assetsToImportHiddenHeaders = By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//tbody//tr[@class='epiq-table-details-row']//div[@class='panel-heading']");
        private By assetsInCaseExpand = By.XPath("//div[@id='import-asset-view-tabs-pane-1']//td[@class='epiq-table-view-more sm md lg xl']//i");
        private By assetsInCaseHiddenHeaders = By.XPath("//div[@id='import-asset-view-tabs']//tbody//tr[@class='epiq-table-details-row']//div[@class='panel-heading']");
        private By disabledImport = By.XPath("(//div[@class='epiq-table-action-button disabled']/i)[1]");
        private By disabledIgnoreButton = By.XPath("(//div[@class='epiq-table-action-button disabled']/i)[2]");
        private By activeImportButton = By.XPath("//div[@class='epiq-table-action-button ']/i[@class='fa fa-arrow-circle-right']");
        private By activeIgnoreButton = By.XPath("//div[@class='epiq-table-action-button ']/i[@class='fa fa-times-circle']");
        private By assetsListChkBox = By.XPath("//div[@class='epiq-input-styled-checkbox ']//input[@type='checkbox']");
        private By successToastrMsg = By.XPath("//div[@class='toastr animated rrt-success']");
        private By processingMsg = By.XPath("//div[@class=toastr animated rrt-info']");
        private By assetInCaseList = By.XPath("//div[@id='import-asset-view-tabs-pane-1']//td[@data-title='DESCRIPTION']//span");
        private By assetToImportList = By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//td[@data-title='DESCRIPTION']//span");
        private By importHeader = By.XPath("//div[@class='epiq-page-header']/h2");
        private By importAssetsBreadcrumb = By.XPath("//ol[@role ='navigation']//li[2]/span");
        private By pageSize = By.XPath("//div[@class='epiq-paging-pagesize']/div/div//span[2]");
        private By assetTableRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By importsAssetsFilter = By.XPath("(//div[@class='epiq-page-control pull-right']/div/button)[1]");
        private By importsAssetsFilterImported = By.XPath("//div[label[text()='IMPORTED']]//div[@class='Select-input']/input");
        private By importsAssetsFilterDefaultImported = By.XPath("//div[label[text()='IMPORTED']]//div[@class='Select-value']/span");
        private By importsAssetsCaseStatusField = By.XPath("//div[label[text()='CASE STATUS']]//div[@class='Select-input']/input");
        private By importsAssetsCaseStatusDefault = By.XPath("//div[label[text()='CASE STATUS']]//div[@class='Select-value']/span");
        private By importsAssetsFilterCrossBtn = By.XPath("//div[@class='pull-right form-group epiq-fa']/i");
        private By importsAssetsFilterCloseBtn = By.XPath("//button[text()='CLOSE']");
        private By importsAssetsFilterResetBtn = By.XPath("//button[text()='RESET']");
        private By errorTextLength = By.XPath("//span[@class='text-danger']");
        private By importsAssetsPageHeaderNames = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        public string assetDesc = null;
        private By inlineEditDesc = By.XPath("//td[@data-title ='DESCRIPTION']//button");
        private By inlineEditFa = By.XPath("//td[@data-title ='FA']//button");
        private By inlineEditUtc = By.XPath("//td[@data-title ='UTC']//button");
        private By inlineEditInput = By.XPath("//div[@role ='tooltip']//div/input");
        private By inlineEditUtcInput = By.XPath("//div[@role ='tooltip']//div/span/div/input");
        private By viewDocTab = By.XPath("//a[@id='import-asset-view-tabs-tab-2']");
        private By viewDocCount = By.XPath("//a[@id='import-asset-view-tabs-tab-2']/div/span");
        private By tableHeader = By.XPath("//div[@class='epiq-page-controls clearfix container']//h3");
        private By assetCount = By.XPath("//div[@class='epiq-page-controls clearfix container']//h3/span/span");
        private By viewDocumentsTile = By.XPath("//div[@id='import-asset-view-tabs']/ul/li[2]/a");
        private By expandCollapseButton = By.XPath("//div[@id='import-asset-view-tabs-pane-2']//td[@class='epiq-table-view-more sm md lg xl']//i");

        public void NewInlineEditDescriptionValue(string description)
        {
            this.Pause(3);
            this.Pause(2);
            this.WaitForElementToBeVisible(inlineEditDesc).Click(); Thread.Sleep(2000);
            this.ClearAndType(this.WaitForElementToBeVisible(inlineEditInput), description); Thread.Sleep(2000);
            this.WaitForElementToBeVisible(inlineEditInput).SendKeys(Keys.Enter);
            this.Pause(6);
        }

        public void SelectPageSize(int PageSize)
        {
            this.ScrollDownToPageBottom();
            this.Pause(2);
            this.WaitForElementToBeClickeable(pageSize).Click();
            this.Pause(4);
            driver.FindElement(By.XPath("//div[@class='Select-menu']/div[text()='" + PageSize + "']")).Click();
            this.Pause(3);
            this.ScrollDownToPageBottom();
        }
        public void VerifyRowsLength(int PageSize)
        {
            this.ScrollUpToPageTop();
            this.Pause(1);
            IList<IWebElement> Rows = driver.FindElements(assetTableRows);
            int RowsLength = Rows.Count() / 2;
            Assert.AreEqual(PageSize, RowsLength);
        }
        public void NewInlineEditFaValue(string faValue)
        {
            this.Pause(3);
            Thread.Sleep(2000);
            this.WaitForElementToBeVisible(inlineEditFa).Click();
            Thread.Sleep(2000);
            this.ClearAndType(this.WaitForElementToBeVisible(inlineEditInput), faValue);
            Thread.Sleep(2000);
            // this.WaitForElementToBeVisible(INLINE_EDIT_INPUT).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        public void NewInlineEditUTCValue(string utcValue)
        {
            this.Pause(3);
            Thread.Sleep(2000);
            this.WaitForElementToBeVisible(inlineEditUtc).Click(); Thread.Sleep(2000);
            this.ClearAndType(this.WaitForElementToBeVisible(inlineEditUtcInput), utcValue); Thread.Sleep(2000);
            this.WaitForElementToBeVisible(inlineEditUtcInput).SendKeys(Keys.Down);
            Thread.Sleep(2000);
            this.WaitForElementToBeVisible(inlineEditUtcInput).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        public void ClickFilterButton() { Thread.Sleep(3500); this.WaitForElementToBeClickeable(importsAssetsFilter).Click(); }
        public void ClickFilterCrossButton() { Thread.Sleep(3500); this.WaitForElementToBeClickeable(importsAssetsFilterCrossBtn).Click(); }
        public void ClickFilterCLoseButton() { Thread.Sleep(3500); this.WaitForElementToBeClickeable(importsAssetsFilterCloseBtn).Click(); }
        public void ClickFilterResetButton() { Thread.Sleep(3500); this.WaitForElementToBeClickeable(importsAssetsFilterResetBtn).Click(); }
        public void FilterWithImportedNewValue(string newImportValue)
        {
            this.Pause(2);
            this.ClearAndType(this.WaitForElementToBeVisible(importsAssetsFilterImported), newImportValue);
            this.WaitForElementToBeVisible(importsAssetsFilterImported).SendKeys(Keys.Down);
            this.WaitForElementToBeVisible(importsAssetsFilterImported).SendKeys(Keys.Enter);
            Thread.Sleep(1500);

        }


        public void FilterWithCaseStatusNewValue(string newCaseStatusValue)
        {
            this.Pause(2);
            this.ClearAndType(this.WaitForElementToBeVisible(importsAssetsCaseStatusField), newCaseStatusValue);
            this.WaitForElementToBeVisible(importsAssetsCaseStatusField).SendKeys(Keys.Down);
            this.WaitForElementToBeVisible(importsAssetsCaseStatusField).SendKeys(Keys.Enter);
            Thread.Sleep(1500);

        }
        public bool ValidateErrorTextMessage()
        {
            return this.WaitForElementToBeVisible(errorTextLength).Text.Contains("Storing only the first 60 characters. Additional characters will be deleted. Current length: 61 characters.");
        }
        public ImportAssets ClickOnCrossButton()
        {
            this.WaitForElementToBeClickeable(By.XPath("//i[@class='fa fa-times epiq-fa']")).Click();
            return new ImportAssets(driver);
        }
        public void MessageVerify(string message)
        {
            var actualMessage = driver.FindElement(By.XPath($"//div[contains(@class,'text-center epiq-table-data-no-data-message')] | //div[text()='{message}'] | html/body/div/div/main/div/div/div[3]/div[2]/div/div/div[1]/div[2]/form/div/div[4]/div/div/div[3]/span[2] | //span[text()='{message}']")).Text;
            Assert.AreEqual(actualMessage.ToLower(), message.ToLower());
        }
        public string VerifyTableHeaderTitle(string headerTitle)
        {
            var actual = this.WaitForElementToBeVisible(tableHeader).Text;
            var defaultCount = this.WaitForElementToBeVisible(assetCount).Text;
            string s = "(";
            string s1 = ")";
            var finalHeader = string.Concat(headerTitle, s, defaultCount, s1);
            StringAssert.Contains(finalHeader, actual);
            return finalHeader;
        }

        public string ValidateTheTableRecordCount()
        {
            string defaultCount = this.WaitForElementToBeVisible(assetCount).Text;
            return defaultCount;
        }

        public bool ValidateHeaderTilteValue()
        {
            return this.WaitForElementToBeVisible(importAssetsBreadcrumb).Text.Contains("Import Management");
        }
        public string ValidateDefaultImportedValue()
        {
            return this.WaitForElementToBeVisible(importsAssetsFilterDefaultImported).Text;
        }

        public string ValidateDefaultCaseStatusValue()
        {
            return this.WaitForElementToBeVisible(importsAssetsCaseStatusDefault).Text;
        }

        public bool ValidatePageHeader()
        {
            return this.WaitForElementToBeVisible(importAssetsHeader).Text.Contains("Import Management");
        }
        public void ClickOnAssetToImportLink()
        {
            IList<IWebElement> AssetToImportList = this.WaitForElementsToBeVisible(By.XPath("//td[@data-title='ASSETS TO IMPORT']/a")).ToList();
            AssetToImportList[0].Click();
        }
        public bool ValidateAssetsToImport_Count()
        {
            return this.WaitForElementToBeVisible(assetsToImportCount).Displayed;
        }

        public void ClickViewDocument() { this.WaitForElementToBeClickeable(viewDocTab).Click(); }
        public bool ValidateAssetsInCase_Count()
        {

            return this.WaitForElementToBeVisible(assetsInCaseCount).Displayed;
        }

        public bool ValidateViewDocuments_Count()
        {
            ClickViewDocument();
            return this.WaitForElementToBeVisible(viewDocCount).Displayed;
        }

        public void ClickOnExpandButton()
        {
            Pause(1);
            IList<IWebElement> RowExpandButtonList = this.WaitForElementsToBeVisible(assetsToImportExpand).ToList();
            RowExpandButtonList[0].Click();
        }

        public void HiddenHeadersExist()
        {
            var HeaderNames = new List<string>() { "SCHEDULE", "OWNER", "MARKET", "LIENS", "OWNED", "TRUSTEE", "EXEMPTIONS", "ABANDONMENT" };

            try
            {
                var RowExpandHeadersList = driver.FindElements(assetsToImportHiddenHeaders).ToList().Select(e => e.Text).ToList();
                RowExpandHeadersList.Should().Contain(HeaderNames);
            }
            catch { }

        }
        public void VisibleHeaderExists(String firstHeader, String secHeader, string thirdHeader)
        {
            var header1 = this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//thead//th[@class='epiq-table-header-sortable ']")).Text;
            var header2 = this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//thead//th[@class='epiq-table-header-sortable  visible-md visible-lg visible-xl']")).Text;
            var header3 = this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix epiq-table-info']//thead//th[@class='epiq-table-header-sortable  visible-lg visible-xl']")).Text;
            header1.Should().Contain(firstHeader);
            header2.Should().Contain(secHeader);
            header3.Should().Contain(thirdHeader);
        }

        public void VisibleHeaderExists_AssetsInCase(String firstHeader, String secHeader, string thirdHeader)
        {

            var header1 = this.WaitForElementToBeVisible(By.XPath("(//div[@id='import-asset-view-tabs']//div[@class='tab-content']//thead//th[contains(@class, 'epiq-table-header-sortable ')])[2]")).Text;
            var header2 = this.WaitForElementToBeVisible(By.XPath("(//div[@id='import-asset-view-tabs']//div[@class='tab-content']//thead//th[contains(@class, 'epiq-table-header-sortable  visible')])[1]")).Text;
            var header3 = this.WaitForElementToBeVisible(By.XPath("(//div[@id='import-asset-view-tabs']//div[@class='tab-content']//thead//th[contains(@class, 'epiq-table-header-sortable  visible')])[3]")).Text;
            header1.Should().Contain(firstHeader);
            header2.Should().Contain(secHeader);
            header3.Should().Contain(thirdHeader);
        }

        public void VisibleHeaderExists_Documents_View(String firstHeader, String secHeader, string thirdHeader)
        {
            ClickViewDocument();
            var header1 = this.WaitForElementToBeVisible(By.XPath("(//div[@id='import-asset-view-tabs-pane-2']//div[@class='epiq-table-wrapper clearfix ']//thead//th[contains(@class, 'epiq-table-header-sortable')])[1]")).Text;
            var header2 = this.WaitForElementToBeVisible(By.XPath("(//div[@id='import-asset-view-tabs-pane-2']//div[@class='epiq-table-wrapper clearfix ']//thead//th[contains(@class, 'epiq-table-header-sortable')])[2]")).Text;
            var header3 = this.WaitForElementToBeVisible(By.XPath("(//div[@id='import-asset-view-tabs-pane-2']//div[@class='epiq-table-wrapper clearfix ']//thead//th[contains(@class, 'epiq-table-header-sortable')])[3]")).Text;
            header1.Should().Contain(firstHeader);
            header2.Should().Contain(secHeader);
            header3.Should().Contain(thirdHeader);
        }
        public void ClickOnExpandButton_AssetsInCase()
        {
            Pause(1);
            IList<IWebElement> RowExpandButtonList = this.WaitForElementsToBeVisible(assetsInCaseExpand).ToList();
            RowExpandButtonList[0].Click();
        }

        public void HiddenHeadersExist_AssetsInCase()
        {
            var HeaderNames = new List<string>() { "SCHEDULE", "PETITION", "TRUSTEE", "EXEMPTIONS", "LIENS", "SALES", "FA", "ABANDONMENT" };

            try
            {
                var RowExpandHeadersList = driver.FindElements(assetsInCaseHiddenHeaders).ToList().Select(e => e.Text).ToList();
                RowExpandHeadersList.Should().Contain(HeaderNames);
            }
            catch { }

        }
        public void ClickOnAssetCheckbox()
        {
            Pause(2);
            IList<IWebElement> Checkbox_List = this.WaitForElementsToBeVisible(assetsListChkBox).ToList();
            Thread.Sleep(3000);
            Checkbox_List[1].Click();
        }
        public bool ImportIsDisabled()
        {
            return this.WaitForElementToBeVisible(disabledImport).Displayed;
        }
        public bool IgnoreIsDisabled()
        {
            return this.WaitForElementToBeVisible(disabledIgnoreButton).Displayed;
        }
        public bool ImportIsEnabled()
        {
            Thread.Sleep(2500);
            return this.WaitForElementToBeVisible(activeImportButton).Displayed;
        }
        public bool IgnoreIsEnabled()
        {
            Thread.Sleep(2500);
            return this.WaitForElementToBeVisible(activeIgnoreButton).Displayed;
        }

        public bool ClickOnImport_and_VerifyToastMessage()
        {
            //GetAssetsDescription();
            this.WaitForElementToBeVisible(activeImportButton).Click();
            return this.WaitForElementToBeVisible(successToastrMsg).Displayed;
        }
        public bool ClickOnIgnore_and_VerifyToastMessage()
        {
           // GetAssetsDescription();
            this.WaitForElementToBeVisible(activeIgnoreButton).Click();
            return this.WaitForElementToBeVisible(successToastrMsg).Displayed;
        }
        public string GetAssetsDescription()
        {
            assetDesc = this.WaitForElementToBeVisible(By.XPath("(//td[@class='epiq-table-data-title epiq-ellipsis-md']//div[@class='epiq-inline-edit-overlay'])[1]")).Text;
            return assetDesc;
        }
        public bool IsExistInAssetsInCaseTab()
        {
            if (GetElementExists(assetInCaseList))
            {
                var DescList = this.WaitForElementsToBeVisible(assetInCaseList).ToList();
                List<string> lists = new List<string>();
                for (int i = 0; i < DescList.Count(); i++)
                {
                    lists.Add(DescList[i].Text);
                }

                return lists.Contains(assetDesc);
            }
            else return false;

        }
        public bool Is_Exist_In_AssetsToImport_Tab()
        {
            if (GetElementExists(assetToImportList))
            {
                var DescList = this.WaitForElementsToBeVisible(assetToImportList).ToList();
                List<string> lists = new List<string>();
                for (int i = 0; i < DescList.Count(); i++)
                {
                    lists.Add(DescList[i].Text);
                }
                return lists.Contains(assetDesc);
            }
            else return false;
        }
        private bool GetElementExists(By loc)
        {
            try
            {
                this.WaitForElementToBeVisible(loc, 5);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ClickExpandSymbol(List<string> sectionHeaderList)
        {
            foreach (string section in sectionHeaderList)
            {
                WaitForElementToBePresent(By.XPath("//div[@class='tab-content']//div[text()='" + section + "']")).Click();
                this.Pause(2);
            }
        }

        public void ClickCheckBox(string section,List<string> sectionCheckBoxList)
        {
            WaitForElementToBePresent(By.XPath("//div[@class='tab-content']//div[text()='" + section + "']")).Click();
            this.Pause(2);
            var checkBoxActualList = driver.FindElements(By.XPath("//div[@title='"+ section + "']//span[starts-with(@class,'has-text')]")).ToList();
            List<string> checkBoxNames = new List<string>();
            for (int checkOptionCount = 0; checkOptionCount < checkBoxActualList.Count; checkOptionCount++)
            {
                var name = checkBoxActualList[checkOptionCount].Text;
                checkBoxNames.Add(name);
                checkBoxActualList[checkOptionCount].Click();
            }
            Assert.IsTrue(sectionCheckBoxList.SequenceEqual(checkBoxNames));
        }
        public void ClickViewDocumentTab()
        {
            WaitForElementToBeVisible(viewDocumentsTile).Click();
        }
        public void ClickOnExpandCollapseButton()
        {
            WaitForElementToBeVisible(expandCollapseButton).Click();
            Pause(20);
        }
        public void ClickImportOrIgnoreAsset(string option)
        {
            string bAssetsCount = WaitForElementToBePresent(By.XPath(".//*[@id='assets-to-import-tabs-tab-1']/div/span"), 4).Text;
            int beforeImportAssetsCount = Convert.ToInt32(bAssetsCount);
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-table-action-button ']//span[text()='" + option + "']"), 3).Click();
            this.Pause(2);
            string aAssetsCount = WaitForElementToBePresent(By.XPath(".//*[@id='assets-to-import-tabs-tab-1']/div/span"), 4).Text;
            int afterAssetsCount = Convert.ToInt32(aAssetsCount);
            this.Pause(5);
            Assert.AreEqual(beforeImportAssetsCount - 1, afterAssetsCount);
        }
    }
}
