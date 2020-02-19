using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core
{
    [Binding]
    public class BankingPageDeposits : CommonMethodsUnityStepBase
    {
        [Given(@"Click on Deposit button")]
        [When(@"Click on Deposit button")]
        [Then(@"Click on Deposit button")]
        public void clickDepositButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();
            IWebElement scrollToMe = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@id='summarySectionTitle']")));
            scrollToElement(scrollToMe);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("navItem-Deposit")));
            button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on Add Asset Link button")]
        [When(@"Click on Add Asset Link button")]
        [Then(@"Click on Add Asset Link button")]
        public void clickAddAssetLinkButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//add-row-grid[@id='assetLinkTable']//div[@class='addRowOption']")));
            IWebElement buttonIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//add-row-grid[@id='assetLinkTable']//div/i[@class='fa fa-expand linkColor']")));
            Assert.True(button.Text.Contains("ADD ASSET LINK"));
            clickNotVisualizedElement(button);
            //button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on Add Asset link - Asset Description input field")]
        [When(@"Click on Add Asset link - Asset Description input field")]
        [Then(@"Click on Add Asset link - Asset Description input field")]
        public void clickAddAssetLinkAssetDescInput()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-searchGridContainer-')]]")));
            button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on Add Additional Asset Link button")]
        [When(@"Click on Add Additional Asset Link button")]
        [Then(@"Click on Add Additional Asset Link button")]
        public void clickAddAdditionalAssetLinkButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//add-row-grid[@id='assetLinkTable']//div[@class='addRowOption']")));
            Assert.True(button.Text.Contains("ADD ADDITIONAL ASSET LINK"));
            ScrollPageUpOrDown("-80");
            button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on Save Transaction button")]
        [When(@"Click on Save Transaction button")]
        [Then(@"Click on Save Transaction button")]
        public void clickSaveTransactionButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement scrollToMe = createVisibleWebElementByXpath("//label[@id='depositAssetTitle']");
            scrollToElement(scrollToMe);
            IWebElement button = createExistentWebElementByXpath("//button[@id='saveNewTransactionButton']");
            button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Add Asset Link section layout")]
        [When(@"Verify Add Asset Link section layout")]
        [Then(@"Verify Add Asset Link section layout")]
        public void verifyAddAssetLinkSectionLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();

            var dateFormat = new Regex("\\d\\d[/]\\d\\d[/]\\d\\d\\d\\d");
            var timeFormat = new Regex("\\d\\d[:]\\d\\d[:]\\d\\d");
            IWebElement addAssetLinkButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//add-row-grid[@id='assetLinkTable']//div[@class='addRowOption']")));
            IWebElement addAssetLinkIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/i[@id='addRowExpandIcon']")));
            IWebElement assetLinkLbl = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//label[@id='depositAssetTitle']")));
            IWebElement assetNumberGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//th[@id='numberHeader']")));
            IWebElement assetDescriptionGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//th[@id='gridHeader']")));
            IWebElement assetCodeGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//th[@id='codeHeader']")));
            IWebElement assetFullyAdmGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//th[@id='administeredDateHeader']")));
            IWebElement assetRemainingValueGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//th[@id='remainingHeader']")));
            IWebElement assetLinkedAmountGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//th[@id='amountHeader']")));
            IWebElement assetDescInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-searchGridContainer-')]]")));
            IWebElement assetCodeInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@id[contains(.,'select2-assetLinkTable-') and contains(.,'-checkCodeTextBox-container')]]/span")));
            IWebElement assetFullyAdmnInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-administeredDate')]]")));
            IWebElement assetFullyAdmnIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//td/i[@id[contains(.,'icon-') and contains(.,'-remove')]]")));
            IWebElement assetRemValInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//p[@id[contains(.,'assetLinkTable-') and contains(.,'-remaining')]]")));
            IWebElement assetLinkedAmountInput = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-amount')]]")));

            Assert.True(addAssetLinkButton.Text.Contains("ADD ASSET LINK") || addAssetLinkButton.Text.Contains("ADD ADDITIONAL ASSET LINK"));
            Assert.True(assetLinkLbl.Text.Contains("ASSET LINK"));
            Assert.True(assetNumberGrid.Text.Contains("ASSET #"));
            Assert.True(assetDescriptionGrid.Text.Contains("ASSET DESCRIPTION"));
            Assert.True(assetCodeGrid.Text.Contains("CODE"));
            Assert.True(assetFullyAdmGrid.Text.Contains("FULLY ADMINISTERED"));
            Assert.True(assetRemainingValueGrid.Text.Contains("REMAINING VALUE"));
            Assert.True(assetLinkedAmountGrid.Text.Contains("LINKED AMOUNT"));
            Assert.True(assetDescInput.GetAttribute("placeholder").ToString().Contains("Find asset by asset #, or code..."));
            Assert.True(assetCodeInput.Text.Contains("Search..."));
            Assert.True(assetFullyAdmnInput.GetAttribute("placeholder").ToString().Contains("MM/DD/YYYY"));
            Assert.True(assetRemValInput.Text.Contains("$0.00"));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Assets List section layout")]
        [When(@"Verify Assets List section layout")]
        [Then(@"Verify Assets List section layout")]
        public void verifyAssetsListSectionLayout()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();

            IWebElement assetNumberGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[1]")));
            IWebElement assetDescriptionGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[2]")));
            IWebElement assetCodeGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[3]")));
            IWebElement assetRemainingValueGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[4]")));
            ReadOnlyCollection<IWebElement> assetNumbers = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[1]/p")));
            ReadOnlyCollection<IWebElement> assetDescriptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[2]/p")));
            ReadOnlyCollection<IWebElement> assetCodes = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[3]/p")));
            ReadOnlyCollection<IWebElement> assetRemainingValues = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[4]/p")));
            Assert.True(assetNumberGrid.Text.Contains("ASSET #"));
            Assert.True(assetDescriptionGrid.Text.Contains("ASSET DESCRIPTION"));
            Assert.True(assetCodeGrid.Text.Contains("CODE"));
            Assert.True(assetRemainingValueGrid.Text.Contains("REMAINING VALUE"));
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int caaseId = ScenarioContext.Current.Get<int>("caseId");
            assertCollectionSortAscending(assetNumbers);
            parameters.Clear();
            parameters.Add("caseId", caaseId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getAssetsListInfoForSpecificCaseId, parameters);
            assertEachElementTextInUIIsContainedInDB(assetNumbers, rows, 1);
            assertEachElementTextInDBIsContainedInUI(assetDescriptions, rows, 2);
            assertEachElementTextInDBIsContainedInUI(assetCodes, rows, 4);
            assertEachElementTextInUIIsContainedInDB(assetRemainingValues, rows, 5);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Deposit Code dropdown list")]
        [When(@"Verify Deposit Code dropdown list")]
        [Then(@"Verify Deposit Code dropdown list")]
        public void verifyDepositCodeDropDownList()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();

            IWebElement assetNumberGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[1]")));
            IWebElement assetDescriptionGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[2]")));
            IWebElement assetCodeGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[3]")));
            IWebElement assetRemainingValueGrid = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[4]")));
            ReadOnlyCollection<IWebElement> assetNumbers = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[1]/p")));
            ReadOnlyCollection<IWebElement> assetDescriptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[2]/p")));
            ReadOnlyCollection<IWebElement> assetCodes = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[3]/p")));
            ReadOnlyCollection<IWebElement> assetRemainingValues = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[4]/p")));
            Assert.True(assetNumberGrid.Text.Contains("ASSET #"));
            Assert.True(assetDescriptionGrid.Text.Contains("ASSET DESCRIPTION"));
            Assert.True(assetCodeGrid.Text.Contains("CODE"));
            Assert.True(assetRemainingValueGrid.Text.Contains("REMAINING VALUE"));
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int caaseId = ScenarioContext.Current.Get<int>("caseId");
            assertCollectionSortAscending(assetNumbers);
            parameters.Clear();
            parameters.Add("caseId", caaseId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getAssetsListInfoForSpecificCaseId, parameters);
            assertEachElementTextInUIIsContainedInDB(assetNumbers, rows, 1);
            assertEachElementTextInDBIsContainedInUI(assetDescriptions, rows, 2);
            assertEachElementTextInDBIsContainedInUI(assetCodes, rows, 4);
            assertEachElementTextInUIIsContainedInDB(assetRemainingValues, rows, 5);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search and Select Asset Link with value '(.*)' in column '(.*)'")]
        [When(@"Search and Select Asset Link with value '(.*)' in column '(.*)'")]
        [Then(@"Search and Select Asset Link with value '(.*)' in column '(.*)'")]
        public void selectAssetLink(string value, string columnName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
            IWebElement scrollToMe = createExistentWebElementByXpath("//div[@class='full-width row transactionHeader']");
            scrollToElement(scrollToMe);
            ReadOnlyCollection<IWebElement> collection = null;
            if (columnName == "Asset Number")
            {
                IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-searchGridContainer-')]]")));
                typeStringByChar(value, button);
                Thread.Sleep(1200);
                collection = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[1]/p")));
                selectResultEqualToSearchedText(collection, value);
            }
            else if (columnName == "Code")
            {
                IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-searchGridContainer-')]]")));
                typeStringByChar(value, button);
                Thread.Sleep(1200);
                collection = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[3]/p")));
                selectResultEqualToSearchedText(collection, value);
            }
            waitElementIsInvisibleByXPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/thead/tr/th[1]", "ASSET #");
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify searched Asset Link results contains value '(.*)' in column '(.*)'")]
        [When(@"Verify searched Asset Link results contains value '(.*)' in column '(.*)'")]
        [Then(@"Verify searched Asset Link results contains value '(.*)' in column '(.*)'")]
        public void checkResultsContainsSearchedText(string value, string columnName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
            ReadOnlyCollection<IWebElement> collection = null;

            if (columnName == "Asset Number")
            {
                IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-searchGridContainer-')]]")));
                typeStringByChar(value, button);
                IWebElement scrollToMe = createExistentWebElementByXpath("//div[@class='full-width row transactionHeader']");
                scrollToElement(scrollToMe);
                collection = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[1]/p")));
                assertEachResultContainsSearchedText(collection, value);
            }
            else if (columnName == "Code")
            {
                IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-searchGridContainer-')]]")));
                typeStringByChar(value, button);
                IWebElement scrollToMe = createExistentWebElementByXpath("//div[@class='full-width row transactionHeader']");
                scrollToElement(scrollToMe);
                collection = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//data-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetsListTable-')]]/tbody/tr/td[3]/p")));
                assertEachResultContainsSearchedText(collection, value);
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Assets List shows correct data for linked Assets")]
        [When(@"Verify Assets List shows correct data for linked Assets")]
        [Then(@"Verify Assets List shows correct data for linked Assets")]
        public void verifyLinkedAssetShowsCorrectData()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();

            ReadOnlyCollection<IWebElement> assetNumbers = createVisibleElementsCollectionByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p");
            ReadOnlyCollection<IWebElement> assetDescriptions = createVisibleElementsCollectionByXpath("//p[@id[contains(.,'assetLinkTable-') and contains(.,'-gridContainer-text')]]");
            ReadOnlyCollection<IWebElement> assetCodes = createPresentElementsCollectionByXpath("//span[@id[contains(.,'select2-assetLinkTable-') and contains(.,'-checkCodeTextBox-container')]]");
            ReadOnlyCollection<IWebElement> assetFADates = createVisibleElementsCollectionByXpath("//input[@id[contains(.,'assetLinkTable-') and contains(.,'-administeredDate')]]");
            ReadOnlyCollection<IWebElement> assetRemainingValues = createVisibleElementsCollectionByXpath("//p[@id[contains(.,'assetLinkTable-') and contains(.,'-remaining')]]");

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            int caaseId = ScenarioContext.Current.Get<int>("caseId");
            parameters.Clear();
            parameters.Add("caseId", caaseId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getAssetsListInfoForSpecificCaseId, parameters);
            assertEachElementTextInUIIsContainedInDB(assetNumbers, rows, 1);
            assertEachElementTextInUIIsContainedInDB(assetDescriptions, rows, 2);
            assertEachElementTextInUIIsContainedInDB(assetCodes, rows, 4);
            assertEachElementTextInDBIsContainedInUI(assetRemainingValues, rows, 5);
            assertEachElementAttributeInUIExistInDB(assetFADates, rows, 6, "value");
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Remove Asset Link with Asset Number '(.*)'")]
        [When(@"Remove Asset Link with Asset Number '(.*)'")]
        [Then(@"Remove Asset Link with Asset Number '(.*)'")]
        public void removeSpecificAssetLink(string assetNumber)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            string st1 = createExistentWebElementByXpath("//span[@id[contains(.,'AllocationValue')]]").Text;
            int SOABeforeRemove = Convert.ToInt32(st1.Replace("$", "").Replace(",", "").Replace(".", ""));
            IWebElement elementToRemove = createVisibleWebElementByXpath("//add-row-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td[1]/i");
            clickNotVisualizedElement(elementToRemove);
            WaitForBlockOverlayToDissapear();
            waitElementIsInvisibleByXPath("//add-row-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']", assetNumber);
            string st2 = createExistentWebElementByXpath("//span[@id[contains(.,'AllocationValue')]]").Text;
            if (st2 != "")
            {
                int SOAAfterRemove = Convert.ToInt32(st2.Replace("$", "").Replace(",", "").Replace(".", ""));
                Assert.True(SOAAfterRemove <= SOABeforeRemove);
            }
            else
            {
                TestsLogger.Log("No more Asset Links to compare");
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Add Additional Asset Link is displayed")]
        [When(@"Verify Add Additional Asset Link is displayed")]
        [Then(@"Verify Add Additional Asset Link is displayed")]
        public void checkAdditionalAssetLinkVisible()
        {
            WaitForBlockOverlayToDissapear();
            Assert.True(createVisibleWebElementByXpath("//add-row-grid[@id='assetLinkTable']//div[@class='addRowOption']").Text == "ADD ADDITIONAL ASSET LINK");
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I count Asset Link rows")]
        [When(@"I count Asset Link rows")]
        [Then(@"I count Asset Link rows")]
        public void countAssetLinkRows()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> rowsBeforeDeletion = createVisibleElementsCollectionByXpath("//add-row-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetLinkTable')]]/tbody/tr");
            int rowsBefore = rowsBeforeDeletion.Count;
            AddDataToScenarioContextOverridingExistentKey("rowsBefore", rowsBefore);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify counted Asset Link rows descended")]
        [When(@"Verify counted Asset Link rows descended")]
        [Then(@"Verify counted Asset Link rows descended")]
        public void countAssetLinkRowsDescended()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            int rowsBefore = ScenarioContext.Current.Get<int>("rowsBefore");
            ReadOnlyCollection<IWebElement> rowsAfterDeletion = createVisibleElementsCollectionByXpath("//add-row-grid[@class[not(contains(.,'aurelia-hide'))]]//table[@id[contains(.,'assetLinkTable')]]/tbody/tr");
            int rowsAfter = rowsAfterDeletion.Count;
            Assert.True(rowsAfter < rowsBefore);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Serial Number for transaction with name '(.*)' is not editable")]
        [When(@"Verify Serial Number for transaction with name '(.*)' is not editable")]
        [Then(@"Verify Serial Number for transaction with name '(.*)' is not editable")]
        public void verifyTransactionSerialNumberDisabled(string transactionName)
        {
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement serialN = null;
            if (transactionName == "Deposit")
            {
                serialN = createVisibleWebElementByXpath("//input[@id='depositSerialTextBox']");
                checkElementIsDisabled(serialN);
            }
/////////////// Check and Deposit Serial Number have the same "id", must check if changes ////////////
            else if (transactionName == "Check")
            {
                serialN = createVisibleWebElementByXpath("//input[@id='depositSerialTextBox']");
                checkElementIsDisabled(serialN);
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Enter Linked Amount value '(.*)' for Asset Number '(.*)'")]
        [When(@"Enter Linked Amount value '(.*)' for Asset Number '(.*)'")]
        [Then(@"Enter Linked Amount value '(.*)' for Asset Number '(.*)'")]
        public void enterLinkedAmount(string value, string assetNumber)
        {
            WaitForBlockOverlayToDissapear();
            IWebElement scrollToMe = createExistentWebElementByXpath("//div[@class='full-width row transactionHeader']");
            IWebElement inputField = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//input[@id[contains(.,'assetLinkTable-') and contains(.,'-amount')]]");
            scrollToElement(scrollToMe);
            moveElementHorizontalOrVertical(scrollToMe, 0, 100);
            inputField.Click();
            inputField.Clear();
            inputField.SendKeys(Keys.Control + "a");
            typeStringByChar(value, inputField);
            clickLabelEqualText("LINKED AMOUNT");
        }

        [Given(@"Verify Linked Amount value displayed is '(.*)' for Asset Number '(.*)'")]
        [When(@"Verify Linked Amount value displayed is '(.*)' for Asset Number '(.*)'")]
        [Then(@"Verify Linked Amount value displayed is '(.*)' for Asset Number '(.*)'")]
        public void verifyEnteredLinkedAmount(string value, string assetNumber)
        {
            WaitForBlockOverlayToDissapear();
            IWebElement inputField = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//input[@id[contains(.,'assetLinkTable-') and contains(.,'-amount')]]");
            assertAttributeContainsText(inputField, "value", value);
            clickLabelEqualText("LINKED AMOUNT");
        }

        [Given(@"Verify Code value displayed is '(.*)' for Asset Number '(.*)'")]
        [When(@"Verify Code value displayed is '(.*)' for Asset Number '(.*)'")]
        [Then(@"Verify Code value displayed is '(.*)' for Asset Number '(.*)'")]
        public void verifyCodeDisplayedValueForAssetLink(string value, string assetNumber)
        {
            WaitForBlockOverlayToDissapear();
            IWebElement inputField = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//span[@class='select2-selection__rendered']");
            Assert.True(inputField.Text.Contains(value));
            clickLabelEqualText("LINKED AMOUNT");
        }

        [Given(@"Search Code with text '(.*)' for Asset Link with Asset number '(.*)'")]
        [When(@"Search Code with text '(.*)' for Asset Link with Asset number '(.*)'")]
        [Then(@"Search Code with text '(.*)' for Asset Link with Asset number '(.*)'")]
        public void searchCodeForAssetLink(string text, string assetNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement searchBar = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//span[@id[contains(.,'select2-assetLinkTable-') and contains(.,'-checkCodeTextBox-container')]]");
            searchBar.Click();
            Thread.Sleep(500);
            IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
            Thread.Sleep(500);
            typeStringByChar(text, typeBar);
        }

        [Given(@"Search and Select Code with text '(.*)' for Asset Link with Asset number '(.*)'")]
        [When(@"Search and Select Code with text '(.*)' for Asset Link with Asset number '(.*)'")]
        [Then(@"Search and Select Code with text '(.*)' for Asset Link with Asset number '(.*)'")]
        public void searchAndSelectCodeForAssetLink(string text, string assetNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
            IWebElement scrollToMe = createExistentWebElementByXpath("//div[@class[contains(.,'transactionHeader')]]");
            scrollToElement(scrollToMe);
            IWebElement searchBar = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//span[@id[contains(.,'select2-assetLinkTable-') and contains(.,'-checkCodeTextBox-container')]]/..//span[@class='select2-selection__arrow']");
            searchBar.Click();
            Thread.Sleep(500);
            IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
            Thread.Sleep(500);
            typeStringByChar(text, typeBar);
            Thread.Sleep(1500);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            Thread.Sleep(500);
            selectResultInDifferentWaysInSelect2(results, text, "Click", typeBar);
            WaitForBlockOverlayToDissapear();
            IWebElement searchBarAfterSelection = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//span[@id[contains(.,'select2-assetLinkTable-') and contains(.,'-checkCodeTextBox-container')]]");
            Assert.True(searchBarAfterSelection.Text.Contains(text));
        }

        [Given(@"Verify Codes for Asset Link behavior and layout")]
        [When(@"Verify Codes for Asset Link behavior and layout")]
        [Then(@"Verify Codes for Asset Link behavior and layout")]
        public void checkAssetLinkCodes()
        {
            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            rows = this.ExecuteQueryOnDBWithString(Properties.Resources.getCodesListForAssets);
            IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
            typeBar.SendKeys(Keys.Control+"a");
            typeBar.SendKeys(Keys.Backspace);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            scrollListDown(results, 24, typeBar, "//ul[@id[contains(.,'select2-') and contains(.,'-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            assertCollectionSortAscending(results);
            assertEachElementTextInUIIsContainedInDB(results, rows, 1);
            assertEachElementTextInUIIsContainedInDB(results, rows, 2);
        }

        [Given(@"Enter FA Date with text '(.*)' for Asset Link with Asset number '(.*)'")]
        [When(@"Enter FA Date with text '(.*)' for Asset Link with Asset number '(.*)'")]
        [Then(@"Enter FA Date with text '(.*)' for Asset Link with Asset number '(.*)'")]
        public void enterFADateForAssetLink(string text, string assetNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement typeBar = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//input[@id[contains(.,'assetLinkTable-') and contains(.,'-administeredDate')]]");
            typeBar.Click();
            typeBar.SendKeys(Keys.Control + "a");
            typeBar.SendKeys(Keys.Backspace);
            Thread.Sleep(500);
            typeStringByChar(text, typeBar);
            clickLabelEqualText("CODE");
        }

        [Given(@"Verify Remaining value displayed is '(.*)' for Asset Number '(.*)'")]
        [When(@"Verify Remaining value displayed is '(.*)' for Asset Number '(.*)'")]
        [Then(@"Verify Remaining value displayed is '(.*)' for Asset Number '(.*)'")]
        public void checkRVforLinkedAsset(string value, string assetNumber)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(500);
            IWebElement remVal = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//p[@id[contains(.,'assetLinkTable-') and contains(.,'-remaining')]]")));
            Assert.True(remVal.Text == value);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Select day '(.*)' in FA Date datepicker for Asset Number '(.*)'")]
        [When(@"Select day '(.*)' in FA Date datepicker for Asset Number '(.*)'")]
        [Then(@"Select day '(.*)' in FA Date datepicker for Asset Number '(.*)'")]
        public void selectFADateWithDatePicker(string text, string assetNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement datePickerIcon = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//i[@class[contains(.,'calendarIconClass')]]");
            datePickerIcon.Click();
            IWebElement typeBar = createVisibleWebElementByXpath("//div[@style[contains(.,'display')]]//div[@class='datepicker-days']/table/tbody/tr/td[@class[not(contains(.,'old'))] and @class[not(contains(.,'new'))] and @class[not(contains(.,'disabled'))]][text()='" + text + "']");
            typeBar.Click();
        }

        [Given(@"Select day '(.*)' in CLEARED datepicker for new Deposit")]
        [When(@"Select day '(.*)' in CLEARED datepicker for new Deposit")]
        [Then(@"Select day '(.*)' in CLEARED datepicker for new Deposit")]
        public void selectCLearedDateWithDatePickerOnNewDeposit(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement datePickerIcon = createVisibleWebElementByXpath("//input[@id='depositClearedDatebox']/../i");
            datePickerIcon.Click();
            IWebElement nextMonthButton = null;
            IWebElement dayToSelect = null;
            if (text != "")
            {
                nextMonthButton = createVisibleWebElementByXpath("//div[@class[contains(.,'datepicker-top')]]/div[@class[contains(.,'datepicker-days')]]/table/thead/tr[1]/th[3]/i");
                nextMonthButton.Click();
                dayToSelect = createVisibleWebElementByXpath("//div[@style[contains(.,'display')]]//div[@class='datepicker-days']/table/tbody/tr/td[@class[not(contains(.,'old'))] and @class[not(contains(.,'new'))] and @class[not(contains(.,'disabled'))]][text()='" + text + "']");
                dayToSelect.Click();
            }
            else
            {
                dayToSelect = createVisibleWebElementByXpath("//div[@style[contains(.,'display')]]//div[@class='datepicker-days']/table/tbody/tr/td[@class[contains(.,'active')]]");
                dayToSelect.Click();
            }

        }

        [Given(@"Verify day '(.*)' in FA Date datepicker for Asset Number '(.*)' is disabled")]
        [When(@"Verify day '(.*)' in FA Date datepicker for Asset Number '(.*)' is disabled")]
        [Then(@"Verify day '(.*)' in FA Date datepicker for Asset Number '(.*)' is disabled")]
        public void checkFADateOnDatePickerDisabled(string text, string assetNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement datePickerIcon = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//i[@class[contains(.,'calendarIconClass')]]");
            datePickerIcon.Click();
            IWebElement dayToSelect = createVisibleWebElementByXpath("//div[@style[contains(.,'display: block')]]//div[@class='datepicker-days']/table/tbody/tr/td[@class[not(contains(.,'old'))] and @class[not(contains(.,'new'))]][text()='" + text + "']");
            assertAttributeContainsText(dayToSelect, "class", "disabled");
        }

        [Given(@"Verify default date in FA Date datepicker for Asset Number '(.*)' is today")]
        [When(@"Verify default date in FA Date datepicker for Asset Number '(.*)' is today")]
        [Then(@"Verify default date in FA Date datepicker for Asset Number '(.*)' is today")]
        public void checkDefaultFADateOnDatePickerToday(string assetNumber)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement datePickerIcon = createVisibleWebElementByXpath("//table[@id[contains(.,'assetLinkTable')]]/tbody/tr/td[2]/p[text()='" + assetNumber + "']/../../td//i[@class[contains(.,'calendarIconClass')]]");
            datePickerIcon.Click();
            string today = DateTime.Today.Day.ToString();
            IWebElement dayToSelect = createVisibleWebElementByXpath("//div[@style[contains(.,'display')]]//div[@class='datepicker-days']/table/tbody/tr/td[@class[not(contains(.,'old'))] and @class[not(contains(.,'new'))] and @class[not(contains(.,'disabled'))]][text()='" + today + "']");
            assertAttributeContainsText(dayToSelect, "class", "active");
        }

        [Given(@"Verify Deposit message with text '(.*)' is displayed")]
        [When(@"Verify Deposit message with text '(.*)' is displayed")]
        [Then(@"Verify Deposit message with text '(.*)' is displayed")]
        public void depositBalancedMessageDisplayed(string message)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            IWebElement errorMessage1 = createVisibleWebElementByXpath("//span[@id='message.id']");
            Assert.True(errorMessage1.Text.Contains(message));
            Assert.True(errorMessage1.Displayed);
        }

        [Given(@"Enter Net Deposit value '(.*)'")]
        [When(@"Enter Net Deposit value '(.*)'")]
        [When(@"Enter Net Deposit value '(.*)'")]
        public void enterNetDepositValueForNewDeposit(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id='netDepositTextbox']");
            inputField.Click();
            typeStringByChar(text, inputField);
            clickLabelContainingText("Make a Deposit");
        }

        [Given(@"Verify SAVE button format when in state '(.*)'")]
        [When(@"Verify SAVE button format when in state '(.*)'")]
        [Then(@"Verify SAVE button format when in state '(.*)'")]
        public void checkSaveButtonFormat(string state)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();

            if (state == "Balanced")
            {
                IWebElement button2 = createVisibleWebElementByXpath("//button[@id='saveNewTransactionButton']/span");
                IWebElement button = createVisibleWebElementByXpath("//button[@id='saveNewTransactionButton']");
                Assert.True(button2.Text.Contains(""));
                Assert.True(button.Text.Contains("SAVE"));
                Assert.True(button.Enabled);
            }
            else if (state == "Out Of Balance")
            {
                IWebElement button1 = createVisibleWebElementByXpath("//button[@id='saveNewTransactionButton']");
                IWebElement button2 = createVisibleWebElementByXpath("//button[@id='saveNewTransactionButton']/span");
                Assert.True(button1.Text.Contains("SAVE"));
                Assert.True(button2.Text.Contains("- Out Of Balance"));
                Assert.True(button1.Enabled);
            }
            else if (state == "Disabled")
            {
                IWebElement button1 = createVisibleWebElementByXpath("//button[@id='saveNewTransactionButton']");
                IWebElement button2 = createVisibleWebElementByXpath("//button[@id='saveNewTransactionButton']/span");
                Assert.True(button2.Text.Contains(""));
                Assert.True(button1.Text.Contains("SAVE"));
                checkElementIsDisabled(button1);
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Asset Link with Name '(.*)' and Asset Number '(.*)' for Deposit '(.*)' is displayed on Ledger")]
        [When(@"Verify Asset Link with Name '(.*)' and Asset Number '(.*)' for Deposit '(.*)' is displayed on Ledger")]
        [Then(@"Verify Asset Link with Name '(.*)' and Asset Number '(.*)' for Deposit '(.*)' is displayed on Ledger")]
        public void assetLinkDisplayedOnLedger(string assetName, string assetNumber, string depositName)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            IWebElement remVal = createVisibleWebElementByXpath("//article[@class='transactionRow']/header//div/h4[@id[contains(.,'transactionName')]][contains(text(), '" + depositName + "')]/../../../../..//div[@id[contains(.,'assetChildNumber-')]]/span[contains(text(), '" + assetNumber + "')]/../..//div[@id[contains(.,'assetChildName-')]]/span[contains(text(), '" + assetName + "')]");
            Assert.True(remVal.Text.Contains(assetName));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Asset Number '(.*)' is displayed on Ledger Asset Link section for Deposit '(.*)'")]
        [When(@"Verify Asset Number '(.*)' is displayed on Ledger Asset Link section for Deposit '(.*)'")]
        [Then(@"Verify Asset Number '(.*)' is displayed on Ledger Asset Link section for Deposit '(.*)'")]
        public void assetNumberDisplayedOnLedger(string assetNumber, string depositName)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            IWebElement remVal = createVisibleWebElementByXpath("//article[@class='transactionRow']/header//div/h4[@id[contains(.,'transactionName')]][contains(text(), '" + depositName + "')]/../../../../..//div[@id[contains(.,'assetChildNumber-')]]/span[contains(text(), '" + assetNumber + "')]");
            Assert.True(remVal.Text.Contains(assetNumber));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Asset Balance '(.*)' of Asset Number '(.*)' is displayed on Ledger for Deposit '(.*)'")]
        [When(@"Verify Asset Balance '(.*)' of Asset Number '(.*)' is displayed on Ledger for Deposit '(.*)'")]
        [Then(@"Verify Asset Balance '(.*)' of Asset Number '(.*)' is displayed on Ledger for Deposit '(.*)'")]
        public void assetBalanceDisplayedOnLedger(string assetBalance, string assetNumber, string depositName)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            IWebElement remVal = createVisibleWebElementByXpath("//article[@class='transactionRow']/header//div/h4[@id[contains(.,'transactionName')]][contains(text(), '" + depositName + "')]/../../../../..//div[@id[contains(.,'assetChildNumber-')]]/span[contains(text(), '" + assetNumber + "')]/../..//div[@id[contains(.,'assetChildBalance-')]]/span[contains(text(), '" + assetBalance + "')]");
            Assert.True(remVal.Text.Contains(assetBalance));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Asset Link Split is displayed on Ledger for Deposit '(.*)'")]
        [When(@"Verify Asset Link Split is displayed on Ledger for Deposit '(.*)'")]
        [Then(@"Verify Asset Link Split is displayed on Ledger for Deposit '(.*)'")]
        public void assetLinkSplitDisplayedOnLedger(string depositName)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            IWebElement remVal = createVisibleWebElementByXpath("//article[@class='transactionRow']/header//div/h4[@id[contains(.,'transactionName')]][contains(text(), '" + depositName + "')]/../../../../..//div[@id[contains(., 'claimsLink-')] and @class[contains(., 'detailsForDesktop')]]/compose/div");
            Assert.True(remVal.Text.Contains("SPLIT"));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Code Split is displayed on Ledger for Deposit '(.*)'")]
        [When(@"Verify Code Split is displayed on Ledger for Deposit '(.*)'")]
        [Then(@"Verify Code Split is displayed on Ledger for Deposit '(.*)'")]
        public void codeSplitDisplayedOnLedger(string depositName)
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            IWebElement remVal = createVisibleWebElementByXpath("//article[@class='transactionRow']/header//div/h4[@id[contains(.,'transactionName')]][contains(text(), '" + depositName + "')]/../../../../..//div[@class[contains(., 'detailsForDesktop')]]/span[@id[contains(., 'transactionCodeValue')]]/span");
            Assert.True(remVal.Text.Contains("SPLIT"));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify New Deposit is displayed on Ledger")]
        [When(@"Verify New Deposit is displayed on Ledger")]
        [Then(@"Verify New Deposit is displayed on Ledger")]
        public void checkNewDepositOnLedger()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            string DName = ScenarioContext.Current.Get<string>("depositName");
            string DNumber = ScenarioContext.Current.Get<string>("depositNumber");
            IWebElement dNameInLedger = createVisibleWebElementByXpath("//h4[@id[contains(.,'transactionName-')]][contains(text(), '" + DName + "')]");
            Assert.True(dNameInLedger.Text.Contains(DName));
            IWebElement dNumberInLedger = createVisibleWebElementByXpath("//h4[@id[contains(.,'transactionName-')]]/../../../..//div/p[contains(text(), 'Deposit #" + DNumber + "')]");
            Assert.True(dNumberInLedger.Text.Contains(DNumber));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Assets Link information is displayed on Ledger")]
        [When(@"Verify Assets Link information is displayed on Ledger")]
        [Then(@"Verify Assets Link information is displayed on Ledger")]
        public void checkAssetsLinkInfoOnLedger()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(3500);
            string DName = ScenarioContext.Current.Get<string>("depositName");
            int transactionId = ScenarioContext.Current.Get<int>("transactionId");
            ReadOnlyCollection<IWebElement> assetsLinkNumbers = createPresentElementsCollectionByXpath("//li[@class='bankTransactionItem']/article/header/div[2]/div[1]/div/h4[contains(text(),'" + DName + "')]/../../../../..//div[@class[contains(.,'mobileDetails')]]//div[@class[contains(.,'mobileBottomBorder stretched-container')]]//div[@class[contains(.,'columns detailsForDesktop')]]/compose/div/div[2]/div[1]/span");
            ReadOnlyCollection<IWebElement> assetsLinkNames = createPresentElementsCollectionByXpath("//li[@class='bankTransactionItem']/article/header/div[2]/div[1]/div/h4[contains(text(),'" + DName + "')]/../../../../..//div[@class[contains(.,'mobileDetails')]]//div[@class[contains(.,'mobileBottomBorder stretched-container')]]//div[@class[contains(.,'columns detailsForDesktop')]]/compose/div/div[2]/div[3]/span");
            ReadOnlyCollection<IWebElement> assetsLinkAmounts = createPresentElementsCollectionByXpath("//li[@class='bankTransactionItem']/article/header/div[2]/div[1]/div/h4[contains(text(),'" + DName + "')]/../../../../..//div[@class[contains(.,'mobileDetails')]]//div[@class[contains(.,'mobileBottomBorder stretched-container')]]//div[@class[contains(.,'columns detailsForDesktop')]]/compose/div/div[2]/div[4]/span");

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Clear();
            parameters.Add("transactionId", transactionId);
            rows = this.ExecuteQueryOnDBWithInt(Properties.Resources.getAssetLinkInfoOnDepositsLedger, parameters);
            assertCollectionSortAscending(assetsLinkNumbers);
            assertEachElementTextInUIIsContainedInDB(assetsLinkNumbers, rows, 12);
            assertEachElementTextInUIIsContainedInDB(assetsLinkNames, rows, 13);
            assertEachElementTextInUIIsContainedInDB(assetsLinkAmounts, rows, 1);
            parameters.Clear();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I save Deposit Received From value")]
        [When(@"I save Deposit Received From value")]
        [Then(@"I save Deposit Received From value")]
        public void saveDepositReceivedFromValue()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement depositName = createVisibleWebElementByXpath("//input[@id='receivedTextBox']");
            string DN = depositName.GetAttribute("value").ToString();
            AddDataToScenarioContextOverridingExistentKey("depositName", DN);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I save Edit Deposit Received From value")]
        [When(@"I save Edit Deposit Received From value")]
        [Then(@"I save Edit Deposit Received From value")]
        public void saveDepositReceivedFromOnEditDeposit()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement depositName = createVisibleWebElementByXpath("//span[@id='receivedLabel']");
            AddDataToScenarioContextOverridingExistentKey("depositName", depositName.Text.Replace("   ",""));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I save New Deposit Number value")]
        [When(@"I save New Deposit Number value")]
        [Then(@"I save New Deposit Number value")]
        public void saveNewDepositNumberValue()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement depositNumber = createVisibleWebElementByXpath("//input[@id='depositSerialTextBox']");
            string DNumber = depositNumber.GetAttribute("value").ToString();
            AddDataToScenarioContextOverridingExistentKey("depositNumber", DNumber);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I save Edit Deposit Serial Number value")]
        [When(@"I save Edit Deposit Serial Number value")]
        [Then(@"I save Edit Deposit Serial Number value")]
        public void saveEditDepositSerialNumberValue()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement depositNumber = createVisibleWebElementByXpath("//span[@id='depositSerialLabel']");
            AddDataToScenarioContextOverridingExistentKey("depositNumber", depositNumber.Text.Replace(" ", ""));
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Enter Deposit Received From value '(.*)'")]
        [When(@"Enter Deposit Received From value '(.*)'")]
        [Then(@"Enter Deposit Received From value '(.*)'")]
        public void enterDepositReceivedFromValue(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id='receivedTextBox']");
            inputField.Click();
            inputField.Clear();
            typeStringByChar(text, inputField);
            clickLabelContainingText("NET DEPOSIT");
        }

        [Given(@"Search and Select Code with text '(.*)' for New Deposit")]
        [When(@"Search and Select Code with text '(.*)' for New Deposit")]
        [Then(@"Search and Select Code with text '(.*)' for New Deposit")]
        public void searchAndSelectCodeForNewDeposit(string text)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            Thread.Sleep(1000);
            WaitForBlockOverlayToDissapear();
            IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-codeTextBox-container')]]");
            searchBar.Click();
            Thread.Sleep(500);
            IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
            Thread.Sleep(500);
            typeStringByChar(text, typeBar);
            Thread.Sleep(500);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            Thread.Sleep(500);
            selectResultContainsSearchedText(results, text);
            WaitForBlockOverlayToDissapear();
            IWebElement searchBarAfterSelection = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-codeTextBox-container')]]");
            Assert.True(searchBarAfterSelection.Text.Contains(text));
        }

        [Given(@"Verify Gross Deposit field value is equal to entered Net Deposit")]
        [When(@"Verify Gross Deposit field value is equal to entered Net Deposit")]
        [Then(@"Verify Gross Deposit field value is equal to entered Net Deposit")]
        public void grossDepositEqualToNetDeposit()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement netDepositField = createVisibleWebElementByXpath("//input[@id='netDepositTextbox']");
            string netDeposit = netDepositField.GetAttribute("value").ToString();
            IWebElement grossDepositField = createVisibleWebElementByXpath("//input[@id='grossDepositTextbox']");
            string grossDeposit = grossDepositField.GetAttribute("value").ToString();
            Assert.True(netDeposit == grossDeposit);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Gross Deposit field value is not equal to entered Net Deposit")]
        [When(@"Verify Gross Deposit field value is not equal to entered Net Deposit")]
        [Then(@"Verify Gross Deposit field value is not equal to entered Net Deposit")]
        public void grossDepositNotEqualToNetDeposit()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement netDepositField = createVisibleWebElementByXpath("//input[@id='netDepositTextbox']");
            string netDeposit = netDepositField.GetAttribute("value").ToString();
            IWebElement grossDepositField = createVisibleWebElementByXpath("//input[@id='grossDepositTextbox']");
            string grossDeposit = grossDepositField.GetAttribute("value").ToString();
            Assert.True(netDeposit != grossDeposit);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Enter Gross Deposit value '(.*)'")]
        [When(@"Enter Gross Deposit value '(.*)'")]
        [Then(@"Enter Gross Deposit value '(.*)'")]
        public void enterGrossDepositValue(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            ScrollPageUpOrDown("-5000");
            ScrollPageUpOrDown("920");
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id='grossDepositTextbox']");
            inputField.Click();
            typeStringByChar(text, inputField);
            clickLabelContainingText("Make a Deposit");
        }


        [Given(@"Verify Gross Deposit entered value is '(.*)'")]
        [When(@"Verify Gross Deposit entered value is '(.*)'")]
        [Then(@"Verify Gross Deposit entered value is '(.*)'")]
        public void verifyEnteredGrossDepositValue(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id='grossDepositTextbox']");
            assertAttributeContainsText(inputField, "value", text);
        }

        [Given(@"I save Net Deposit value")]
        [When(@"I save Net Deposit value")]
        [Then(@"I save Net Deposit value")]
        public void saveNetDepositValueFromField(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id='netDepositTextbox']");
            string fieldValue = inputField.GetAttribute("value").ToString();
            AddDataToScenarioContextOverridingExistentKey("netDepositValue", fieldValue);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify SUM OF ALLOCATION displays correct value '(.*)'")]
        [When(@"Verify SUM OF ALLOCATION displays correct value '(.*)'")]
        [Then(@"Verify SUM OF ALLOCATION displays correct value '(.*)'")]
        public void checkSOALayoutAndBehavior(string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            IWebElement label1 = createExistentWebElementByXpath("//label[@id[contains(.,'AllocationLabel')]]");
            IWebElement label2 = createExistentWebElementByXpath("//span[@id[contains(.,'AllocationValue')]]");
            if (label1.Text != "")
            {
                Assert.True(label1.Text.Contains("SUM OF ALLOCATION"));
                Assert.True(label2.Text.Contains(value));
            }
            else
            {
                TestsLogger.Log("No need to verufy value due to Label is not displayed");
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify SUM OF ALLOCATION label is not displayed")]
        [When(@"Verify SUM OF ALLOCATION label is not displayed")]
        [Then(@"Verify SUM OF ALLOCATION label is not displayed")]
        public void SOALabelIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            waitElementIsInvisibleByXPath("//label[@id[contains(.,'AllocationLabel')]]", "SUM OF ALLOCATION");
            waitElementIsInvisibleByXPath("//span[@id[contains(.,'AllocationValue')]]", "");
            WaitForBlockOverlayToDissapear();
        }
    }
}
