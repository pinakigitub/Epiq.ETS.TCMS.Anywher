using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    class CaseDetail_Banking_NewTransactionSteps : CommonMethodsUnityStepBase
    {
        private BankingDetailTab bankingTab = ((BankingDetailTab)GetSharedPageObjectFromContext("Banking Tab"));

        [Given(@"Click on Check button")]
        [When(@"Click on Check button")]
        [Then(@"Click on Check button")]
        public void clickCheckButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();
            IWebElement scrollToMe = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@id='summarySectionTitle']")));
            scrollToElement(scrollToMe);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("navItem-Check")));
            button.Click();
            WaitForBlockOverlayToDissapear();
            AddDataToScenarioContextOverridingExistentKey("transactionName", "Check");

        }

        [Given(@"Click to open Transaction with name '(.*)'")]
        [When(@"Click to open Transaction with name '(.*)'")]
        [Then(@"Click to open Transaction with name '(.*)'")]
        public void openTransactionX(string transactionName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            AddDataToScenarioContextOverridingExistentKey("transactionName", transactionName);
            IWebElement button = createVisibleWebElementById("navItem-"+transactionName);
            Thread.Sleep(500);
            clickNotVisualizedElement(button);
            WaitForBlockOverlayToDissapear();

            if (transactionName == "Check" || transactionName == "Adjustment Debit" || transactionName == "Wire Debit" || transactionName == "Record Funds Returned from a Payee or Creditor")
            {
                bankingTab.Pause(1);
                TransactionForm newCheck = new TransactionForm(driver,true, true);
                AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newCheck);
                AddDataToScenarioContextOverridingExistentKey("New Transaction Type", "Check");
            }

            if (transactionName == "Deposit" || transactionName == "Bank Service Charge Refund (Neg)"|| transactionName == "Deposit Correcting Check" || transactionName == "Deposit Correcting Debit" || transactionName == "Wire Credit" || transactionName == "Adjustment Credit" || transactionName == "Bank Service Charge")
            {
                bankingTab.Pause(1);
                TransactionForm newCheck = new TransactionForm(driver, false, true);
                AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newCheck);
                AddDataToScenarioContextOverridingExistentKey("New Transaction Type", "Deposit");
            }
            if (transactionName == "Bank Service Charge Refund (Neg)")
            {
                transactionName = "Bank Service Charge Refund";
            }
            else if (transactionName == "Transfer Out")
            {
                transactionName = "Transfer Funds";
            }
            IWebElement trxTitle = createVisibleWebElementByXpath("//section[@id='newTransaction']/article//div/h4");
            assertElementCouldContainThreeTexts(trxTitle, "Write " + transactionName, "Record " + transactionName, transactionName);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on More transactions button '(.*)'")]
        [When(@"Click on More transactions button '(.*)'")]
        [Then(@"Click on More transactions button '(.*)'")]
        public void clickMoreTransactionsButton(string action)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1500);
            WaitForBlockOverlayToDissapear();
            if (action != "No")
            {
                IWebElement scrollToMe = wait.Until(ExpectedConditions.ElementExists(By.XPath("//span[@id='summarySectionTitle']")));
                scrollToElement(scrollToMe);
                IWebElement label = createVisibleWebElementByXpath("//menu-link//div[@id='More-menu-link-button']/ul/li/a");
                Assert.True(label.Text.Contains("More"));
                IWebElement iconFirstState = createVisibleWebElementByXpath("//menu-link//div[@id='More-menu-link-button']/ul/li/span/i");
                assertAttributeContainsText(iconFirstState, "class", "fa-chevron-down");
                IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("More-menu-link-button")));
                WaitForBlockOverlayToDissapear();
                button.Click();
                WaitForBlockOverlayToDissapear();
                IWebElement listTitle1 = createVisibleWebElementByXpath("//div[@class='menuLinkListContainer'][1]/span");
                IWebElement listTitle2 = createVisibleWebElementByXpath("//div[@class='menuLinkListContainer'][2]/span");
                assertElementContainsSingleText(listTitle1, "Receipt Transactions", "Receipt Transactions link is incorrect on More Transactions section");
                assertElementContainsSingleText(listTitle2, "Disbursement Transactions", "Disbursement Transactions link is incorrect on More Transactions section");
                IWebElement iconSecondState = createVisibleWebElementByXpath("//menu-link//div[@id='More-menu-link-button']/ul/li/span/i");
                assertAttributeContainsText(iconSecondState, "class", "fa-chevron-up");
            }
            else
            {
                TestsLogger.Log("No need to click the More button");
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on ADD UTC SPLIT button")]
        [When(@"Click on ADD UTC SPLIT button")]
        [Then(@"Click on ADD UTC SPLIT button")]
        public void clickAddUTCSplitButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'utc-addRowContainer')]]//div[@class='addRowOption']")));
            IWebElement buttonIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'utc-addRowContainer')]]//div[@class='addRowOption']/../i")));
            Assert.True(button.Text.Contains("ADD UTC SPLIT"));
            clickNotVisualizedElement(button);
            //button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click on ADD CLAIM LINK button")]
        [When(@"Click on ADD CLAIM LINK button")]
        [Then(@"Click on ADD CLAIM LINK button")]
        public void clickAddClaimLinkButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(500);
            IWebElement button = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'claimLinkTable-addRowContainer')]]//div[@class='addRowOption']")));
            IWebElement buttonIcon = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id[contains(.,'claimLinkTable-addRowContainer')]]//div[@class='addRowOption']/../i")));
            Assert.True(button.Text.Contains("ADD CLAIM LINK"));
            clickNotVisualizedElement(button);
            //button.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Transaction input field with Name '(.*)' has state '(.*)'")]
        [When(@"Verify Transaction input field with Name '(.*)' has state '(.*)'")]
        [Then(@"Verify Transaction input field with Name '(.*)' has state '(.*)'")]
        public void VerifyTransactionFieldStatus(string field, string state)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            IWebElement codeField = null;
            IWebElement subCodeField = null;

            if (field == "Code" && state == "Enabled")
            {
                codeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]");
                string className = codeField.GetAttribute("class").ToString();
                Assert.False(className.Contains("disabled"));
            }
            else if (field == "Code" && state == "Disabled")
            {
                codeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]");
                string className = codeField.GetAttribute("class").ToString();
                Assert.True(className.Contains("disabled"));
            }
            if (field == "Sub Code" && state == "Enabled")
            {
                subCodeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/../../..");
                string className = subCodeField.GetAttribute("class").ToString();
                Assert.False(className.Contains("disabled"));
            }
            else if (field == "Sub Code" && state == "Disabled")
            {
                subCodeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/../../..");
                string className = subCodeField.GetAttribute("class").ToString();
                Assert.True(className.Contains("disabled"));
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Select Code by text '(.*)' using '(.*)' for Transaction")]
        [When(@"Select Code by text '(.*)' using '(.*)' for Transaction")]
        [Then(@"Select Code by text '(.*)' using '(.*)' for Transaction")]
        public void TransactionSelectCodeWithTextUsingX(string text, string selectMethod)
        {
            Thread.Sleep(2500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
                ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-mainCodeDropdown-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                selectResultInDifferentWaysInSelect2(results, text, selectMethod, typeBar);
                if (selectMethod == "Tab")
                {
                    if (waitElementIsInvisibleByXPath("//span/input[@class='select2-search__field']","").Equals(true))
                    {
                        typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                        typeBar.SendKeys(Keys.Escape);
                    }

                }
                Thread.Sleep(500);
                IWebElement placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]");
                Assert.True(placeholder.Text.Contains(text));
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement blankResult = createVisibleWebElementByXpath("//ul[@id[contains(.,'select2-mainCodeDropdown-results')]]/li/div[@id[contains(.,'-1')]]");
                blankResult.Click();
                Thread.Sleep(500);
            }

            WaitForBlockOverlayToDissapear();
        }


        [Given(@"Select Sub Code by text '(.*)' using '(.*)' for Transaction")]
        [When(@"Select Sub Code by text '(.*)' using '(.*)' for Transaction")]
        [Then(@"Select Sub Code by text '(.*)' using '(.*)' for Transaction")]
        public void TransactionSelectSubCodeWithTextUsingX(string text, string selectMethod)
        {
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();

            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
                ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDropdown-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                selectResultInDifferentWaysInSelect2(results, text, selectMethod, typeBar);
                Thread.Sleep(500);
                IWebElement placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]");
                Assert.True(placeholder.Text.Contains(text));
            }
            else if (text == "blank")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                Thread.Sleep(1000);
                IWebElement blankResult = createVisibleWebElementByXpath("//ul[@id[contains(.,'select2-subcodeDropdown-results')]]/li/div[@id[contains(.,'-1')]]");
                blankResult.Click();
                Thread.Sleep(500);
            }
            else
            {
                TestsLogger.Log("No Need to select a Sub Code");
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search Code by text '(.*)' for Transaction")]
        [When(@"Search Code by text '(.*)' for Transaction")]
        [Then(@"Search Code by text '(.*)' for Transaction")]
        public void TransactionSearchCode(string text)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();

            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeBar.Click();
                typeBar.Clear();
                typeBar.SendKeys("a");
                typeBar.SendKeys(Keys.Backspace);
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeBar.Click();
                typeBar.Clear();
                typeBar.SendKeys("a");
                typeBar.SendKeys(Keys.Backspace);
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Search Sub Code by text '(.*)' for Transaction")]
        [When(@"Search Sub Code by text '(.*)' for Transaction")]
        [Then(@"Search Sub Code by text '(.*)' for Transaction")]
        public void TransactionSearchSubCode(string text)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();

            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
            }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Transaction field with Name '(.*)' is not visible")]
        [When(@"Verify Transaction field with Name '(.*)' is not visible")]
        [Then(@"Verify Transaction field with Name '(.*)' is not visible")]
        public void TransactionCheckFieldIsNotVisible(string field)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            if (field == "Code")
            {
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]", "");
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]/../../../../../../../label", "CODE");
            }
            else if (field == "Sub Code")
            {
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]", "");
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/../../../../../../../label", "SUB CODE");
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Transaction field with Name '(.*)' is visible")]
        [When(@"Verify Transaction field with Name '(.*)' is visible")]
        [Then(@"Verify Transaction field with Name '(.*)' is visible")]
        public void TransactionCheckFieldIsVisible(string field)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            if (field == "Code")
            {
                IWebElement inputField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]");
                IWebElement inputFieldLbl = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container')]]/../../../../../../../label");
                Assert.True(inputField.Displayed);
                Assert.True(inputFieldLbl.Displayed);
            }
            else if (field == "Sub Code")
            {
                IWebElement inputField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]");
                IWebElement inputFieldLbl = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container')]]/../../../../../../../label");
                Assert.True(inputField.Displayed);
                Assert.True(inputFieldLbl.Displayed);
            }
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Remove Empty Link of a Transaction")]
        [When(@"Remove Empty Link of a Transaction")]
        [Then(@"Remove Empty Link of a Transaction")]
        public void removeEmptyTransactionLink()
        {
            WaitForBlockOverlayToDissapear();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            Thread.Sleep(1000);
            IWebElement removeButton = createVisibleWebElementByXpath("//i[@id[contains(.,'icon-') and contains(.,'-remove')]]");
            removeButton.Click();
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Codes list displayed is correct")]
        [When(@"Verify Codes list displayed is correct")]
        [Then(@"Verify Codes list displayed is correct")]
        public void checkCodesListAgainstDB()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            rows = this.ExecuteQueryOnDBWithString(Properties.Resources.getCodesAndSubCodesRelationList);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-mainCodeDropdown-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            string collectionXpath = "//ul[@id[contains(.,'select2-mainCodeDropdown-results')]]/li/div[@id[not(contains(.,'-1'))]]";
            string transactionName = ScenarioContext.Current.Get<string>("transactionName");
            if (transactionName == "Check" || transactionName == "Bank Service Charge" || transactionName == "Bank Service Charge Refund (Neg)")
            {scrollListDown(results, 94, createExistentWebElementByXpath("//span/input[@class='select2-search__field']"), collectionXpath);}

            else if (transactionName == "Deposit" || transactionName == "Deposit Correcting Check" || transactionName == "Deposit Correcting Debit")
            { scrollListDown(results, 25, createExistentWebElementByXpath("//span/input[@class='select2-search__field']"), collectionXpath);}

            else if (transactionName == "Transfer Out")
            { scrollListDown(results, 1, createExistentWebElementByXpath("//span/input[@class='select2-search__field']"), collectionXpath); }

            assertCollectionSortAscending(results);
            assertEachElementTextInUIIsContainedInDB(results, rows, 1);
            assertEachElementTextInUIIsContainedInDB(results, rows, 2);
        }

        [Given(@"Verify Sub Codes list displayed is correct")]
        [When(@"Verify Sub Codes list displayed is correct")]
        [Then(@"Verify Sub Codes list displayed is correct")]
        public void checkSubCodesListAgainstDB()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));

            /////////// Query to DB and validations between UI and DB ///////////
            DataRowCollection rows = null;
            rows = this.ExecuteQueryOnDBWithString(Properties.Resources.getCodesAndSubCodesRelationList);
            ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDropdown-results')]]/li/div[@id[not(contains(.,'-1'))]]");
            assertCollectionSortAscending(results);
            assertEachElementTextInUIIsContainedInDB(results, rows, 4);
            assertEachElementTextInUIIsContainedInDB(results, rows, 5);
        }

        [Given(@"Enter Transaction Amount value '(.*)'")]
        [When(@"Enter Transaction Amount value '(.*)'")]
        [When(@"Enter Transaction Amount value '(.*)'")]
        public void enterAmountValueForAnyTransaction(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            IWebElement inputField = null;
            Thread.Sleep(2000);
            if (text != "")
            {
                inputField = createVisibleWebElementByXpath("//input[@id[contains(.,'netDepositTextbox') or contains(.,'Amount')]]");
                inputField.Click();
                inputField.Clear();
                typeStringByChar(text, inputField);
                clickLabelContainingText("DESCRIPTION");
            }
            else
            {
                TestsLogger.Log("No Need to enter value into Amount field");
            }
        }

        [Given(@"Enter Transaction Name value '(.*)'")]
        [When(@"Enter Transaction Name value '(.*)'")]
        [When(@"Enter Transaction Name value '(.*)'")]
        public void enterPTTOOValueForAnyTransaction(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            IWebElement inputField = null;
            Thread.Sleep(2000);
            string trxName = ScenarioContext.Current.Get<string>("transactionName");
            if (text != "")
            {
                if (trxName == "Check")
                {
                    IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and (contains(.,'PayToTheOrderOfValue')) and contains(.,'-container')]]/..//span[@class='select2-selection__arrow']");
                    searchBar.Click();
                    IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                    typeStringByChar(text, typeBar);
                    Thread.Sleep(1000);
                    ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'PayToTheOrderOfValue') and contains(.,'-results')]]/li");
                    selectResultInDifferentWaysInSelect2(results, text, "Click", typeBar);
                    Thread.Sleep(500);
                    IWebElement placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and (contains(.,'PayToTheOrderOfValue')) and contains(.,'-container')]]");
                    Assert.True(placeholder.Text.Contains(text));
                }
                else
                {
                    inputField = createVisibleWebElementByXpath("//input[@id[contains(.,'received') or contains(.,'PayToTheOrderOfValue')]]");
                    inputField.Click();
                    inputField.Clear();
                    typeStringByChar(text, inputField);
                    clickLabelContainingText("DESCRIPTION");
                }
            }
            else
            {
                TestsLogger.Log("No Need to enter value into PAY TO THE ORDER OF field");
            }
        }

        [Given(@"Verify Transaction Amount value is '(.*)'")]
        [When(@"Verify Transaction Amount value is '(.*)'")]
        [Then(@"Verify Transaction Amount value is '(.*)'")]
        public void verifyTransactionAmountValue(string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            IWebElement inputField = createVisibleWebElementByXpath("//input[@id[contains(.,'netDepositTextbox') or contains(.,'Amount')]]");
            assertAttributeContainsText(inputField, "value", text);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Verify Disbursement Transactions message when Out of Balance")]
        [When(@"Verify Disbursement Transactions message when Out of Balance")]
        [Then(@"Verify Disbursement Transactions message when Out of Balance")]
        public void DisbursementTrxOutOfBalanceMessage()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//small[@id='errorMessage']")));
            Assert.That(errorMessage.Text.Contains("In order to save transaction, Sum of Allocations must equal the check amount"));
        }

        [Given(@"Verify Disbursement Transactions message not displayed when Balanced")]
        [When(@"Verify Disbursement Transactions message not displayed when Balanced")]
        [Then(@"Verify Disbursement Transactions message not displayed when Balanced")]
        public void DisbursementTrxBalancedMessage()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            waitElementIsInvisibleByXPath("//small[@id='errorMessage']", "In order to save transaction, Sum of Allocations must equal the check amount");
        }

        [Given(@"Verify Receipt Transactions message when Out of Balance")]
        [When(@"Verify Receipt Transactions message when Out of Balance")]
        [Then(@"Verify Receipt Transactions message when Out of Balance")]
        public void ReceiptTrxOutOfBalanceMessage()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//small[@id='errorMessage']")));
            Assert.That(errorMessage.Text.Contains("In order to save transaction, Sum of Allocations must equal the transaction amount."));
        }

        [Given(@"Verify Receipt Transactions message not displayed when Balanced")]
        [When(@"Verify Receipt Transactions message not displayed when Balanced")]
        [Then(@"Verify Receipt Transactions message not displayed when Balanced")]
        public void ReceiptTrxBalancedMessage()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            WaitForBlockOverlayToDissapear();
            waitElementIsInvisibleByXPath("//small[@id='errorMessage']", "In order to save transaction, Sum of Allocations must equal the transaction amount.");
        }

        [Given(@"Select value with text '(.*)' typing at position '(.*)' on field '(.*)' using '(.*)' for Transaction")]
        [When(@"Select value with text '(.*)' typing at position '(.*)' on field '(.*)' using '(.*)' for Transaction")]
        [Then(@"Select value with text '(.*)' typing at position '(.*)' on field '(.*)' using '(.*)' for Transaction")]
        public void TrxDropDownSelection(string value, string position, string field, string selectMethod)
        {
            Thread.Sleep(3500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            IWebElement searchBar = null;
            IWebElement typeBar = null;
            IWebElement placeholder = null;
            ReadOnlyCollection<IWebElement> results = null;
            if (field == "Description")
            {
                placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'escriptionValue') and contains(.,'-container')]]");
                string descInitialValue = placeholder.Text.ToString();
                searchBar = createVisibleWebElementByXpath("//select[@id[contains(.,'escriptionValue')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                Thread.Sleep(1000);
                typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                Assert.True(typeBar.GetAttribute("value").ToString().Contains(descInitialValue));
                results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'escriptionValue') and contains(.,'-results')]]/li");
                string result2 = results[0].Text;
                Assert.True(result2.Contains(descInitialValue));
                typeStringByCharInPositionX(value, typeBar, position);
                Thread.Sleep(1000);
                results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'escriptionValue') and contains(.,'-results')]]/li");
                selectResultInDifferentWaysInSelect2(results, value, selectMethod, typeBar);
                if (selectMethod == "Tab")
                {
                    if (waitElementIsInvisibleByXPath("//span/input[@class='select2-search__field']", "").Equals(true))
                    {
                        typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                        typeBar.SendKeys(Keys.Escape);
                    }

                }
                Thread.Sleep(500);
                placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'escriptionValue') and contains(.,'-container')]]");
                Assert.True(placeholder.Text.Contains(value));
                Assert.False(placeholder.Text.Contains(descInitialValue));
            }

            else if (field == "Code")
            {
                placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container') or contains(.,'select2-assetCodeTextBox-container') or contains(.,'select2-claimCode-container')]]");
                string descInitialValue = placeholder.Text.ToString();
                searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container') or contains(.,'select2-assetCodeTextBox-container') or contains(.,'select2-claimCode-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                Thread.Sleep(1000);
                typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                string descInitialValue2 = removeCharsAfterSpecificChar(descInitialValue, " ");
                Assert.True(typeBar.GetAttribute("value").ToString().Contains(descInitialValue2));
                results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-mainCodeDropdown-results') or contains(.,'select2-assetCodeTextBox-results') or contains(.,'select2-claimCode-results')]]/li");
                string result2 = results[0].Text;
                Assert.True(result2.Contains(descInitialValue2));

                typeStringByCharInPositionX(value, typeBar, position);

                Thread.Sleep(1000);
                results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-mainCodeDropdown-results') or contains(.,'select2-assetCodeTextBox-results') or contains(.,'select2-claimCode-results')]]/li");
                selectResultInDifferentWaysInSelect2(results, value, selectMethod, typeBar);
                if (selectMethod == "Tab")
                {
                    if (waitElementIsInvisibleByXPath("//span/input[@class='select2-search__field']", "").Equals(true))
                    {
                        typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                        typeBar.SendKeys(Keys.Escape);
                    }

                }
                Thread.Sleep(500);
                placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-mainCodeDropdown-container') or contains(.,'select2-assetCodeTextBox-container') or contains(.,'select2-claimCode-container')]]");
                Assert.True(placeholder.Text.Contains(value));

                if (value != descInitialValue2)
                {
                    Assert.False(placeholder.Text.Contains(descInitialValue));
                }
                else
                {
                    Assert.True(placeholder.Text.Contains(descInitialValue));
                }
            }

            else if (field == "Sub Code")
            {
                placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container') or contains(.,'select2-subcodeDesktop-container') or contains(.,'select2-subcodeClaim-container')]]");
                string descInitialValue = placeholder.Text.ToString();
                searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container') or contains(.,'select2-subcodeDesktop-container') or contains(.,'select2-subcodeClaim-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                Thread.Sleep(1000);
                typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                string descInitialValue2 = removeCharsAfterSpecificChar(descInitialValue, " ");
                if (descInitialValue2 == "Search..." || descInitialValue2 == "")
                { TestsLogger.Log("Empty placeholder"); }
                else
                {
                    Assert.True(typeBar.GetAttribute("value").ToString().Contains(descInitialValue2));
                    typeStringByChar(value, typeBar);
                    Thread.Sleep(1500);
                    results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDropdown-results') or contains(.,'select2-subcodeDesktop-results') or contains(.,'select2-subcodeClaim-results')]]/li");
                    string result2 = results[0].Text;
                    Assert.True(result2.Contains(descInitialValue2));
                }

                typeStringByCharInPositionX(value, typeBar, position);
                Thread.Sleep(1000);
                results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-subcodeDropdown-results') or contains(.,'select2-subcodeDesktop-results') or contains(.,'select2-subcodeClaim-results')]]/li");
                selectResultInDifferentWaysInSelect2(results, value, selectMethod, typeBar);
                Thread.Sleep(1000);
                placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-subcodeDropdown-container') or contains(.,'select2-subcodeDesktop-container') or contains(.,'select2-subcodeClaim-container')]]");
                if (value == "01")
                {
                    value = removeFirstCharsFromString(value);
                }
                Assert.True(placeholder.Text.Contains(value));
                if (value != descInitialValue2)
                {
                    Assert.False(placeholder.Text.Contains(descInitialValue));
                }
                else
                {
                    Assert.True(placeholder.Text.Contains(descInitialValue));
                }
        }

            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click Edit button for Transaction with Name '(.*)'")]
        [When(@"Click Edit button for Transaction with Name '(.*)'")]
        [Then(@"Click Edit button for Transaction with Name '(.*)'")]
        public void clickEditButtonForTransactions(string transactionName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(3500);
            AddDataToScenarioContextOverridingExistentKey("toEditElementDesc", transactionName);
            IWebElement editButton = createVisibleWebElementByXpath("//li[@class='bankTransactionItem']/article/header/div[2]/div[1]/div/h4[contains(text(),'" + transactionName + "')]/../..//div/a");
            IWebElement scrollToMe = createVisibleWebElementByXpath("//span[@id='bankAccountNameDetails']");
            scrollToElement(scrollToMe);
            clickNotVisualizedElement(editButton);
            WaitForBlockOverlayToDissapear();

            string trxName = ScenarioContext.Current.Get<string>("transactionName");

            if (trxName == "Check" || trxName == "Adjustment Debit" || trxName == "Wire Debit" || trxName == "Record Funds Returned from a Payee or Creditor")
            {
                bankingTab.Pause(1);
                AddDataToScenarioContextOverridingExistentKey("New Transaction Form", new TransactionForm(driver, true, false));
                AddDataToScenarioContextOverridingExistentKey("New Transaction Type", trxName);
            }

            else
            {
                bankingTab.Pause(1);
                AddDataToScenarioContextOverridingExistentKey("New Transaction Form", new TransactionForm(driver, false, false));
                AddDataToScenarioContextOverridingExistentKey("New Transaction Type", trxName);
            }
            Thread.Sleep(1000);
        }

        [Given(@"Click on Save New Transaction button")]
        [When(@"Click on Save New Transaction button")]
        [Then(@"Click on Save New Transaction button")]
        public void clickSaveNewTransactionButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1500);
            IWebElement scrollToMe = createVisibleWebElementByXpath("//input[@id[contains(.,'learedDate')]]");
            scrollToElement(scrollToMe);
            IWebElement button = createExistentWebElementByXpath("//button[@id='saveNewTransactionButton']");
            //button.Click();
            clickNotVisualizedElement(button);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"I save New Transaction Id value from Ledger")]
        [When(@"I save New Transaction Id value from Ledger")]
        [Then(@"I save New Transaction Id value from Ledger")]
        public void saveNewTransactionIdValue()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WaitForBlockOverlayToDissapear();
            Thread.Sleep(1000);
            string trxName = ScenarioContext.Current.Get<string>("transactionName");
            IWebElement depositNumber = createVisibleWebElementByXpath("//h4[@id[contains(.,'transactionName-')]][contains(text(),'"+ trxName + "')]");
            int trxId = Convert.ToInt32(depositNumber.GetAttribute("id").Replace("transactionName-", "").ToString());
            AddDataToScenarioContextOverridingExistentKey("trxId", trxId);
            WaitForBlockOverlayToDissapear();
        }

        [Given(@"Click Edit button for Transaction with Description '(.*)'")]
        [When(@"Click Edit button for Transaction with Description '(.*)'")]
        [Then(@"Click Edit button for Transaction with Description '(.*)'")]
        public void ClickEditButtonForTransactionsWithDescX(string text)
        {
            Thread.Sleep(3500);
            string trxType = ScenarioContext.Current.Get<string>("transactionName");
            AddDataToScenarioContextOverridingExistentKey("toEditElementDesc", text);
            TransactionForm newTransaction = bankingTab.ClickEditButtonForTransactions(text, trxType);
            Assert.IsNotNull(newTransaction, "Edit button is Disabled due to permission restriction.");
            AddDataToScenarioContextOverridingExistentKey("New Transaction Form", newTransaction);
            AddDataToScenarioContextOverridingExistentKey("New Transaction Type", trxType);
        }
    }
}
