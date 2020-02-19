using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using System.Threading;
using NUnit.Framework;
using FluentAssertions;
using OpenQA.Selenium.Interactions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin
{
    public class SuperAdminPages : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        private By userIcons = By.XPath("//*[@id='basic-nav-dropdown']/i");
        private By headerNames = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By caseTableRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        private By docketTableRows = By.XPath("//div[@class='tab-content']/div[2]//table[@class='epiq-table table table-condensed']/tbody/tr");
        private By meeting341Link = By.XPath("//a[contains(text(),'341 MEETINGS')]");
        private By assetsLink = By.XPath("//a[contains(text(),'ASSETS')]");
        private By claimsLink = By.XPath("//a[contains(text(),'CLAIMS')]");
        private By importSection = By.XPath("//div[2]/form/div/div/div/div/div/a/div");
        private By batchOptions = By.XPath("//div[2]/div/div/div/a/div");
        private By selectYes = By.XPath("//input[@id='epiq-check-assetImportAbandonmentStatusSetToYes']");
        private By saveStatus = By.XPath("//div[3]/div/div/button");
        private By batchSetting = By.XPath("//div[2]/div/div[2]/div/div/div[2]/div/label");
        private By newActivity = By.XPath("//input[@id='epiq-check-createNew']");
        private By importClaimUppercase = By.XPath("//input[@id='epiq-check-importClaimInUpperCase']");
        private By importCreditorMatrixData = By.XPath("//input[@id='epiq-check-importCreditorMatrix']");
        private By onDemandMatrixData = By.XPath("//input[@id='epiq-check-importCreditorMatrixOnlyOnDemand']");
        
        public SuperAdminPages(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void SelectUserPermission(string user)
        {
            WaitForElementToBeClickeable(userIcons, 4).Click();
            WaitForElementToBeClickeable(By.XPath($"//ul[@class='dropdown-menu']/li/a[text()='{user}']"), 2).Click();
        }
        public void SelectAdminTabs(string adminTabs)
        {
            WaitForElementToBeClickeable(By.XPath($"//div[@id='super-admin-tabs']/ul/li/a[text()='{adminTabs}'] | //div[@id='settings-office-tabs']/ul/li/a[text()='{adminTabs}']")).Click();
        }
        public void SelectCheckBoxWithDescription(string description)
        {
            IList<IWebElement> rows = driver.FindElements(caseTableRows);
            int rowLength = rows.Count;

            for (int row = 1; row <= rowLength; row++)
            {
                IWebElement descriptionText = driver.FindElement(By.XPath("//div[@class='tab-content']/div[2]//tr[" + row + "]//td[4]//span"));
                string descriptionList = descriptionText.Text;
                if (descriptionList == description)
                {
                    //driver.FindElement(By.XPath("//div[@class='tab-content']/div[2]//tr[" + row + "]/td[2]//span")).Click();
                    //break;
                    this.Pause(1);
                    var e = driver.FindElement(By.XPath("//div[@class='tab-content']/div[2]//tr[" + row + "]/td[2]//span"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
                    this.Pause(2);
                    break;
                }
            }
        }
        public void VerifyDeleteButtonInEnabledState()
        {
            bool deleteButton = WaitForElementToBeVisible(By.XPath("//button[@class='epiq-button-link btn btn-default']")).Displayed;
            Assert.IsTrue(deleteButton);
        }
        public void SelectButton(int index, string button)
        {
            WaitForElementToBeClickeable(By.XPath($"//div[@class='tab-content']/div[" + index + "]//button[contains(text(),'DELETE')] | //div[@class='tab-content']/div[" + index + "]//button[contains(text(),'RESTORE')] | //div[@id='settings-office-tabs']//form//div[" + index + "]//button"), 3).Click();
        }
        public void VerifyRestoreButtonDisabledState(string state)
        {
            if (state == "Disabled")
            {
                bool disabledState = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-page-body']/div/div[2]/div[1]//button")).Enabled;
                Assert.IsFalse(disabledState);
            }
            else
            {
                bool enabledState = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-page-body']/div/div[2]/div[1]//button")).Displayed;
                Assert.IsTrue(enabledState);
            }
        }
        public List<string> GetRecordsByColumnName(string columnName, string value = null)
        {
            this.Pause(3);
            var finished = false;
            List<string> lists = new List<string>();
            for (var row = 0; row < 10; row++)
            {
                try
                {
                    Pause(2);

                    IList<IWebElement> rows = null;

                    columnName = columnName.ToUpper();
                    string rowXpath = "//div[@class='tab-content']/div[2]//tr//td[@data-title='{0}']//span[text()]";
                    try
                    {
                        this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, columnName)), 16);
                        rows = driver.FindElements(By.XPath(string.Format(rowXpath, columnName)));
                        if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//div[@class='tab-content']/div[2]//tr//td[@data-title='{columnName}']")); }
                    }
                    catch (Exception e) { rows = driver.FindElements(By.XPath($"//div[@class='tab-content']/div[2]//tr//td[@data-title='{columnName}']")); }
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
        public void verifyNoVisibilitySuperAdmin(string userType)
        {
            WaitForElementToBeClickeable(userIcons, 4).Click();
            Assert.IsFalse(IsElementVisible(By.XPath($"//ul[@class='dropdown-menu']/li/a[text()='{userType}']")));
            WaitForElementToBeClickeable(userIcons, 4).Click();
        }
        public void VerifySuperAdminVisibility(string userType)
        {
            WaitForElementToBeClickeable(userIcons, 4).Click();
            Assert.IsTrue(IsElementVisible(By.XPath($"//ul[@class='dropdown-menu']/li/a[text()='{userType}']")));
            WaitForElementToBeClickeable(userIcons, 4).Click();
        }
        public void VerifyErrorMessage(string internalError, string errorMessage)
        {
            var errorText = WaitForElementToBeVisible(By.XPath("//div[@class='jumbotron']/h1")).Text;
            Assert.IsTrue(errorText.Equals(internalError, StringComparison.OrdinalIgnoreCase));
            var message = WaitForElementToBeVisible(By.XPath("//div[@class='jumbotron']/p")).Text;
            Assert.IsTrue(message.Equals(errorMessage, StringComparison.OrdinalIgnoreCase));
        }
        public void VerifyNavigationSection(string allCasesText, string superAdminText)
        {
            var navigationAllCases = WaitForElementToBeVisible(By.XPath("//div[@class='container']/div[3]/div[1]/div/div/div")).Text;
            Assert.IsTrue(navigationAllCases.Equals(allCasesText, StringComparison.OrdinalIgnoreCase));
            var navigationSuperAdmin = WaitForElementToBeVisible(By.XPath("//div[@class='container']/div[3]/div[3]/div/div/div")).Text;
            Assert.IsTrue(navigationSuperAdmin.Equals(superAdminText, StringComparison.OrdinalIgnoreCase));
        }
        public void VerifyMessage(string message)
        {
            var adminMessage = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-page-body']/div/h3")).Text;
            Assert.IsTrue(adminMessage.Equals(message, StringComparison.OrdinalIgnoreCase));
        }
        public void verifyOfficeMessage(string office)
        {
            var officeMessage = WaitForElementToBeVisible(By.XPath(".//*[@id='epiq-main-page-wrap']/div/div[2]/div/h3/strong")).Text;
            Assert.IsTrue(officeMessage.Equals(office, StringComparison.OrdinalIgnoreCase));
        }
        public void verifyAdminTabs(string tab)
        {
            var adminTab = WaitForElementToBeVisible(By.XPath($"//div[@id='super-admin-tabs']/ul/li/a[text()='{tab}']")).Text;
            Assert.IsTrue(adminTab.Equals(tab, StringComparison.OrdinalIgnoreCase));
        }
        public void verifyDeleteInDisableState()
        {
            bool state = WaitForElementToBeVisible(By.XPath("//div[@class='tab-content']/div[2]//button")).Enabled;
            Assert.IsFalse(state);
        }
        public void VerifySuperAdminPageTableColumns(List<string> titles)
        {
            this.Pause(3);
            List<string> Columnnames = new List<string>();
            for (int column = 3; column <= 6; column++)
            {
                var TableElements = driver.FindElement(By.XPath("//table//tr[1]//th[" + column + "]")).Text;
                Columnnames.Add(TableElements);
            }
            bool equal = titles.SequenceEqual(Columnnames);
        }
        public void VerifyCautionHeader(int index, string cautionHeader)
        {
            var cautionTitle = WaitForElementToBeVisible(By.XPath("//div[@class='tab-content']/div[" + index + "]//h2[@class='text-danger']")).Text;
            Assert.IsTrue(cautionTitle.Equals(cautionHeader, StringComparison.OrdinalIgnoreCase));
        }
        public void SelectSelectionColumn(int index)
        {
            var element = IsElementVisible(By.XPath($"//tr[" + index + "]//td[@data-title='SALES' and not(span)]"));
            if (element)
            {
                IList<IWebElement> allCheckbox = driver.FindElements(By.XPath("//tbody//tr[" + index + "]//label/span[contains(@class,'')]"));
                foreach (IWebElement checkbox in allCheckbox)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
                }
            }
        }
        public List<string> VerifyAssetNumberOrder()
        {
            IList<IWebElement> assetNumberList = driver.FindElements(By.XPath("//td[@data-title='ASSET #']/span | //td[@data-title='#']"));
            List<string> list = new List<string>();
            bool isFound = true;
            foreach (var item in assetNumberList)
            {
                var Text = item.Text;
                isFound = false;
            }
            return list;
        }
        public void VerifyButtonState(string button, int index, string state)
        {
            if (state == "Disabled")
            {
                bool buttonDisableState = WaitForElementToBeVisible(By.XPath("//div[@class='tab-content']/div[" + index + "]//button")).Enabled;
                Assert.IsFalse(buttonDisableState);
            }
            else
            {
                bool buttonEnableState = WaitForElementToBeVisible(By.XPath("//div[@class='tab-content']/div[" + index + "]//button")).Displayed;
                Assert.IsTrue(buttonEnableState);
            }
        }
        public void SelectRowOfSelectionColumn(int section, int index)
        {
            IList<IWebElement> allCheckbox = driver.FindElements(By.XPath($"//div[@id='super-admin-tabs-pane-{section}']//tbody//tr[" + index + "]//label/span[contains(@class,'')]"));
            foreach (IWebElement checkbox in allCheckbox)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", checkbox);
            }

        }
        public void MeetingLink()
        {
           this.WaitForElementToBeClickeable(meeting341Link, 4).Click();
        }
        public void CliamsLink()
        {
            this.WaitForElementToBeClickeable(claimsLink, 4).Click();
        }
        public void AssetsLink()
        {
            WaitForElementToBeClickeable(assetsLink, 4).Click();
        }
        public void ImportsSection()
        {
            WaitForElementToBeClickeable(importSection, 4).Click();
            WaitForElementToBeClickeable(importSection, 6).Click();
        }
        public void BatchOptions()
        {
            WaitForElementToBeClickeable(batchOptions, 4).Click();
            WaitForElementToBeClickeable(batchOptions, 6).Click();
        }
        public void AbondedStatusYes()
        {
            WaitForElementToBeClickeable(selectYes, 6).Click();
        }
        public void SaveTheStatus()
        {
            WaitForElementToBeClickeable(saveStatus, 5).Click();
        }
        public void BatchSettings()
        {
           WaitForElementToBeClickeable(batchSetting, 5).Click();            
        }
        public void VerifyDefaultOptions()
        {
            this.Pause(3);
            Assert.IsTrue(driver.FindElement(newActivity).Selected);
            }
        public void UpperCaseImportClaim()
        {
            this.Pause(3);
            Assert.IsTrue(driver.FindElement(importClaimUppercase).Selected);
        }
        public void MatrixDataimportCreditor()
        {
            this.Pause(3);
            Assert.IsTrue(driver.FindElement(importCreditorMatrixData).Selected);
        }
        public void MatrixDataOnDemand()
        {
            this.Pause(3);
            Assert.IsTrue(driver.FindElement(onDemandMatrixData).Selected);
        }
     }
}