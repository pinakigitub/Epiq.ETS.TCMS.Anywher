using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail.Banking
{
    [Binding]
    class CaseDetail_Banking_NewDepositSteps : CommonMethodsUnityStepBase
    {
        [Given(@"Select Code by text '(.*)' using '(.*)' for Deposit")]
        [When(@"Select Code by text '(.*)' using '(.*)' for Deposit")]
        [Then(@"Select Code by text '(.*)' using '(.*)' for Deposit")]
        public void depositSelectCodeWithTextUsingX(string text, string selectMethod)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
                ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                selectResultInDifferentWaysInSelect2(results, text, selectMethod, typeBar);
                Thread.Sleep(500);
                IWebElement placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]");
                Assert.True(placeholder.Text.Contains(text));
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement blankResult = createVisibleWebElementByXpath("//ul[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-results')]]/li/div[@id[contains(.,'-1')]]");
                blankResult.Click();
                Thread.Sleep(500);
            }

            pleaseWaitSignDissapear();
        }


        [Given(@"Select Sub Code by text '(.*)' using '(.*)' for Deposit")]
        [When(@"Select Sub Code by text '(.*)' using '(.*)' for Deposit")]
        [Then(@"Select Sub Code by text '(.*)' using '(.*)' for Deposit")]
        public void depositSelectSubCodeWithTextUsingX(string text, string selectMethod)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            pleaseWaitSignDissapear();

            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
                ReadOnlyCollection<IWebElement> results = createVisibleElementsCollectionByXpath("//ul[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-results')]]/li/div[@id[not(contains(.,'-1'))]]");
                selectResultInDifferentWaysInSelect2(results, text, selectMethod, typeBar);
                Thread.Sleep(500);
                IWebElement placeholder = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]");
                Assert.True(placeholder.Text.Contains(text));
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                Thread.Sleep(1000);
                IWebElement blankResult = createVisibleWebElementByXpath("//ul[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-results')]]/li/div[@id[contains(.,'-1')]]");
                blankResult.Click();
                Thread.Sleep(500);
            }

            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Deposit input field with Name '(.*)' has state '(.*)'")]
        [When(@"Verify Deposit input field with Name '(.*)' has state '(.*)'")]
        [Then(@"Verify Deposit input field with Name '(.*)' has state '(.*)'")]
        public void checkDepositInputFieldStatus(string field, string state)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            IWebElement codeField = null;
            IWebElement subCodeField = null;

            if (field == "Code" && state == "Enabled")
            {
                codeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]");
                string className = codeField.GetAttribute("class").ToString();
                Assert.False(className.Contains("disabled"));
            }
            else if (field == "Code" && state == "Disabled")
            {
                codeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]");
                string className = codeField.GetAttribute("class").ToString();
                Assert.True(className.Contains("disabled"));
            }
            if (field == "Sub Code" && state == "Enabled")
            {
                subCodeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/../../..");
                string className = subCodeField.GetAttribute("class").ToString();
                Assert.False(className.Contains("disabled"));
            }
            else if (field == "Sub Code" && state == "Disabled")
            {
                subCodeField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/../../..");
                string className = subCodeField.GetAttribute("class").ToString();
                Assert.True(className.Contains("disabled"));
            }
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Deposit field with Name '(.*)' is not visible")]
        [When(@"Verify Deposit field with Name '(.*)' is not visible")]
        [Then(@"Verify Deposit field with Name '(.*)' is not visible")]
        public void Deposit_checkFieldIsNotVisible(string field)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            if (field == "Code")
            {
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]", "");
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]/../../../../../../../../../span", "CODE");
            }
            else if (field == "Sub Code")
            {
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]", "");
                waitElementIsInvisibleByXPath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/../../../../../../../label", "SUB CODE");
            }
            pleaseWaitSignDissapear();
        }

        [Given(@"Verify Deposit field with Name '(.*)' is visible")]
        [When(@"Verify Deposit field with Name '(.*)' is visible")]
        [Then(@"Verify Deposit field with Name '(.*)' is visible")]
        public void Deposit_checkFieldIsVisible(string field)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            pleaseWaitSignDissapear();
            if (field == "Code")
            {
                IWebElement inputField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]");
                IWebElement inputFieldLbl = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]/../../../../../../../../../span");
                Assert.True(inputField.Displayed);
                Assert.True(inputFieldLbl.Displayed);
            }
            else if (field == "Sub Code")
            {
                IWebElement inputField = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]");
                IWebElement inputFieldLbl = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/../../../../../../../label");
                Assert.True(inputField.Displayed);
                Assert.True(inputFieldLbl.Displayed);
            }
            pleaseWaitSignDissapear();
        }

        [Given(@"Search Code by text '(.*)' for Deposit")]
        [When(@"Search Code by text '(.*)' for Deposit")]
        [Then(@"Search Code by text '(.*)' for Deposit")]
        public void depositSearchCode(string text)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            pleaseWaitSignDissapear();

            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'code') and contains(.,'-container') and not(contains(.,'sub'))]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
            }

            pleaseWaitSignDissapear();
        }

        [Given(@"Search Sub Code by text '(.*)' for Deposit")]
        [When(@"Search Sub Code by text '(.*)' for Deposit")]
        [Then(@"Search Sub Code by text '(.*)' for Deposit")]
        public void depositSearchSubCode(string text)
        {
            Thread.Sleep(1500);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            pleaseWaitSignDissapear();

            if (text != "")
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
                IWebElement typeBar = createVisibleWebElementByXpath("//span/input[@class='select2-search__field']");
                typeStringByChar(text, typeBar);
                Thread.Sleep(1000);
            }
            else
            {
                IWebElement searchBar = createVisibleWebElementByXpath("//span[@id[contains(.,'select2-') and contains(.,'subcode') and contains(.,'-container')]]/..//span[@class='select2-selection__arrow']");
                searchBar.Click();
            }

            pleaseWaitSignDissapear();
        }
    }
}
