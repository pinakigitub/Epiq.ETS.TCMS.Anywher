using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;


namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports
{
    public class ImportDocumetsPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        //Import Document Locators
        private By activeGearButton = By.XPath("//button[@class='epiq-button-link btn btn-default']");


        public ImportDocumetsPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void ClickOnDocumentNumberToImportLink()
        {
            IList<IWebElement> DocumentToImportList = this.WaitForElementsToBeVisible(By.XPath("//td[@data-title='DOCUMENTS']/a")).ToList();
            DocumentToImportList[0].Click();
        }
        public void VisibleHeaderExistsDocumentsInCase(String firstHeader, String secHeader, string thirdHeader)
        {
            var header1 = this.WaitForElementToBeVisible(By.XPath("//div[@id='import-document-view-tabs']//thead//th[@class='epiq-table-header-sortable'][1]")).Text;
            var header2 = this.WaitForElementToBeVisible(By.XPath("//div[@id='import-document-view-tabs']//thead//th[@class='epiq-table-header-sortable'][2]")).Text;
            var header3 = this.WaitForElementToBeVisible(By.XPath("//div[@id='import-document-view-tabs']//thead//th[@class='epiq-table-header-sortable'][3]")).Text;
            //var header1 = this.WaitForElementToBeVisible(By.XPath(".//*[@id='documents-to-import-tabs-pane-1']/div/div/div[2]/table/thead/tr/th[3]")).Text;
            //var header2 = this.WaitForElementToBeVisible(By.XPath(".//*[@id='documents-to-import-tabs-pane-1']/div/div/div[2]/table/thead/tr/th[4]")).Text;
            //var header3 = this.WaitForElementToBeVisible(By.XPath(".//*[@id='documents-to-import-tabs-pane-1']/div/div/div[2]/table/thead/tr/th[5]")).Text;
            header1.Should().Contain(firstHeader);
            header2.Should().Contain(secHeader);
            header3.Should().Contain(thirdHeader);
        }
        public void ClickOnDocumentsToImportLink()
        {
            IList<IWebElement> DocumentsToImportList = this.WaitForElementsToBeVisible(By.XPath("//*[@id='documents-to-import-tabs-pane-1']")).ToList();
            DocumentsToImportList[0].Click();
        }
        public bool GearIsEnabled()
        {
            return this.WaitForElementToBeVisible(activeGearButton).Displayed;
        }
        public void ClickGearButton()
        {
            this.WaitForElementToBeClickeable(activeGearButton).Click();
        }

        }
}
