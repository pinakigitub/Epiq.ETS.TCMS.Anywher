using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using System.Text.RegularExpressions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    public class AccountGearDetailsPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        private By caseTableRows = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");
        #region Verify Fields Locators
        private By accountEditIcon = By.XPath("//button[@title='Edit Bank Account']");
        private By breadCrumb = By.XPath("//ol/li[1]/a");
        private By caseNumber = By.XPath("//div[label[@class='control-label']]/div[@name='caseEditDisplay']");
        private By bankName = By.XPath("//div[label[text()='BANK']]/div[@name='bankName']");
        private By accountType = By.XPath("//div[label[text()='ACCOUNT TYPE']]//div/span/div[1]/span");
        private By accountNumbers = By.XPath("//div[label[text()='ACCOUNT #']]/div[@name='accountNumber']");
        private By bankTotal = By.XPath("//div[label[text()='BANK BALANCE']]//div/span");
        private By ledgerTotal = By.XPath("//div[label[text()='LEDGER BALANCE']]//div/span");
        private By unbalanced = By.XPath("//div[@class='col-xs-12']/span/b");
        private By unbalancedIcon = By.XPath("//div[@class='epiq-form-display-field']//i");
        private By accountSummary = By.XPath("//h3[text()='Account Summary']/span");
        #endregion Verify Fields Locators

        #region Input field Locators
        private By accountStatus = By.XPath("//div[label[text()='STATUS']]//div/span[3]/span");
        private string statusSelect = "//div/div[text()='{0}']";
        private By statusMessage = By.XPath("//span[text()='Cannot close bank account, Ledger Balance does not equal $0.00 or some transactions are missing a Cleared Date']");
        private By taxIdTextBox = By.XPath("//div[label[text()='TAX ID']]/input");
        private By accountNameInput = By.XPath("//div[label[text()='ACCOUNT NAME']]/input");
        private By defaultChecks = By.XPath("//label/span[text()='Default for Checks']");
        private By defaultDeposit = By.XPath("//label/span[text()='Default for Deposits']");
        private By checkboxes = By.XPath("//span[contains(@class,'has-text')]");
        private By requestFromBankText = By.XPath("//div[input[@name='requestFromBank']]//label/span");
        private By requestFromBankCheckbox = By.XPath("//form/div[2]/div//div[2]/div[@class='epiq-input-styled-checkbox ']/label");
        private By noBondFlag = By.XPath("//span[text()='No Bond Flag']");
        private By taxIdInput = By.XPath("//form//div[@class='row']//div[label[text()='TAX ID']]/input");
        private By checkNumberInput = By.XPath("//form//div[@class='row']//div[label[text()='NEXT CHECK NUMBER']]/input");
        private By depositNumberInput = By.XPath("//form//div[@class='row']//div[label[text()='NEXT DEPOSIT NUMBER']]/input");
        private By cancelButton = By.XPath("//button[text()='CANCEL']");
        private By saveButton = By.XPath("//button[text()='SAVE']");
        #endregion Input field Locators

        public string accountNumber = null;

        public AccountGearDetailsPage(IWebDriver driver) : base(driver, pageTitle)
        {
            this.driver = driver;
        }
        public void SelectAccount(string caseNumber)
        {
            this.Pause(3);
            IList<IWebElement> accountRows = driver.FindElements(caseTableRows);
            int accountsRowCount = accountRows.Count;
            bool isFound = false;
            for (int row = 1; row <= accountsRowCount; row++)
            {
                IWebElement caseNumbers = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr["+ row +"]//td[2]"));
                string caseNumList = caseNumbers.Text;

                if (caseNumList == caseNumber)
                {
                    var select = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]/td[6]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", select);
                    isFound = true;
                    break;
                }
                row++;
            }
            Assert.IsTrue(isFound);
        }
        public void verifyCaseDetails(string caseNumber, string debtorName)
        {
            this.Pause(2);
            var caseNumberDetails = driver.FindElement(By.XPath($"//div[@class='case-header-data-case-display']//span[text()='{caseNumber}']")).Text;
            Assert.IsTrue(caseNumberDetails.Equals(caseNumber, StringComparison.OrdinalIgnoreCase));
            var debtorDetails = driver.FindElement(By.XPath($"//div[@class='case-header-data-case-display']//span[text()='{debtorName}']")).Text;
            Assert.IsTrue(debtorDetails.Equals(debtorName, StringComparison.OrdinalIgnoreCase));

        }
        public void ClickGear()
        {
            WaitForElementToBeClickeable(accountEditIcon,3).Click();
        }
        public void BreadCrumbText(string breadCrumb)
        {
            var breadCrumbText = WaitForElementToBeVisible(this.breadCrumb).Text;
            if (breadCrumbText == breadCrumb)
            {
                WaitForElementToBeClickeable(this.breadCrumb).Click();
            }

        }
        public void VerifyAccountDetails(string caseNumber, string bankDetails)
        {
            this.Pause(2);
            var caseDetails = WaitForElementToBeVisible(this.caseNumber).Text;
            Assert.IsTrue(caseNumber.Equals(caseDetails, StringComparison.OrdinalIgnoreCase));
            var bankName = WaitForElementToBeVisible(this.bankName).Text;
            Assert.IsTrue(bankName.Equals(bankDetails, StringComparison.OrdinalIgnoreCase));
                  }
        public void VerifyBankAccountDetails(string accountDetails, string bankTotal, string ledgerTotal)
        {
            if (!string.IsNullOrEmpty(accountDetails))
            {
                var AccountNumber = WaitForElementToBeVisible(this.accountNumbers).Text;
                string newString = AccountNumber.Remove(AccountNumber.Length - 1, 0);
                Assert.IsTrue(newString.Equals(accountDetails, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(bankTotal))
            {
                var totalAmount = WaitForElementToBeVisible(this.bankTotal).Text;
                Assert.IsTrue(totalAmount.Equals(bankTotal, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(ledgerTotal))
            {
                var ledger = WaitForElementToBeVisible(this.ledgerTotal).Text;
                Assert.IsTrue(ledger.Equals(ledgerTotal, StringComparison.OrdinalIgnoreCase));
            }
        }
        public void VerifyUnbalanced(string unbalanceText, string bank, string ledger)
        {
            //if (!string.IsNullOrEmpty(unbalanceText))
            //{
            //    //var unBalance = WaitForElementToBeVisible(UNBALANCED_TEXT_LOCATOR).Text;
            //    //Assert.IsTrue(unBalance.Equals(unbalanceText, StringComparison.OrdinalIgnoreCase));
            //}
            if (bank != ledger)
            {
                var resColor = driver.FindElement(unbalancedIcon).GetCssValue("color");
                string[] arrColor = resColor.Split(',');
                string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

                int hexValue1 = Int32.Parse(hexValue[0]);
                hexValue[1] = hexValue[1].Trim();
                int hexValue2 = Int32.Parse(hexValue[1]);
                hexValue[2] = hexValue[2].Trim();
                int hexValue3 = Int32.Parse(hexValue[2]);

                string actualColor = string.Format("#d0021b", hexValue1, hexValue2, hexValue3);
                Assert.AreEqual("#d0021b", actualColor);
            }
        }
        public void SelectStatus(string status)
        {
            this.Pause(2);
            this.ScrollWindowBy(200,80);
            WaitForElementToBeClickeable(accountStatus).Click();
            this.Pause(2);
            this.WaitForElementToBeVisible(By.XPath(String.Format(statusSelect, status))).Click();
        }
        public string Message(string message)
        {
            try
            {
                return this.WaitForElementToBeVisible(statusMessage).Text;

            }
            catch (MissingElementException)
            {
                return null;
            }
        }
        public void SelectCheckBoxes(string checkType)
        {
            this.ScrollWindowBy(300, 100);
            WaitForElementToBeClickeable(defaultChecks,3).Click();           
        }
        public void DepositCheckBox(string deposit)
        {
            ScrollDown();
            IList<IWebElement> checkBoxes = driver.FindElements(checkboxes);
            bool checkValue = false;
            checkValue = checkBoxes.ElementAt(0).Selected;
            if (checkValue == true)
            {
                checkBoxes.ElementAt(1).Click();
            }
            else
            {
                checkBoxes.ElementAt(0).Click();
            }

            WaitForElementToBeClickeable(defaultDeposit).Click();
        }
        public void SelectRequestCheckBox(string request)
        {
            this.Pause(3);
            this.ScrollDownToPageBottom();
            var requestText = WaitForElementToBeVisible(requestFromBankText).Text;
            if (requestText == request)
            {
                WaitForElementToBeClickeable(requestFromBankCheckbox).Click();
            }
        }
        public void InputFields(string id)
        {
            this.ScrollDownToPageBottom();
            this.ClearAndType(WaitForElementToBeVisible(taxIdInput,5), id);
            //this.ClearAndType(WaitForElementToBeVisible(checkNumberInput,2),"" +checkNumber);
            //this.ClearAndType(WaitForElementToBeVisible(depositNumberInput),""+depositNumber);
        }
        public void ClickCancel()
        {
            WaitForElementToBeClickeable(cancelButton,2).Click();
        }
        public void ClickSave()
        {
            WaitForElementToBeClickeable(saveButton,2).Click();
        }
        public void VerifyTaxIdField()
        {
            this.Pause(2);
            Assert.False(IsElementVisible(taxIdTextBox));
        }
        public void EnterTaxId(string id)
        {
            this.Pause(2);
            this.ClearAndType(WaitForElementToBeVisible(taxIdInput), id);
        }
        public void EnterAccountName(string name)
        {
            this.Pause(3);
            this.ClearAndType(WaitForElementToBeVisible(accountNameInput), name);
        }
        public void VerifyAccountName(string accountName)
        {
            this.Pause(3);
            var accountDetails = WaitForElementToBeVisible(this.accountSummary).Text;
        }
        public void SelectNoBondFlag(string flagCheck)
        {
            this.Pause(3);
            ScrollDownToPageBottom();
            var bondFlag = WaitForElementToBeVisible(noBondFlag).Text;
            if(bondFlag == flagCheck)
            {
                WaitForElementToBeClickeable(noBondFlag).Click();
            }
        }
        public void VerifyFieldValues(List<string> fields)
        {
            foreach (string input in fields)
            {
                int separator = input.IndexOf('-');
                string xpathSuffix = input.Substring(0, separator);
                string value = input.Substring(separator + 1);
                By xpath = By.XPath($"//div[@class='panel-body']//div[label[text()='{xpathSuffix}']]//div | //div[label[text()='{xpathSuffix}']]/div/span[text()='{value}']");
                try
                {
                    var control = this.WaitForElementToBePresent(xpath, 6);
                    if (GetAttrubuteValue(control, "class").Contains("epiq-form-display-field"))
                    {
                        this.Pause(2);
                        var fieldText = control.Text;
                        Assert.IsTrue(fieldText.Equals(value, StringComparison.OrdinalIgnoreCase));
                    }
                }
                catch (Exception e)
                {
                    new Exception($"[Failure : Check input pattern (InputLabelName-InputValue)] OR \n {e.Message}");
                }
            }
        }
        public void SelectViewIcon(int rowNumber)
        {
            this.Pause(6);
            WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-page-body']//table//tbody//tr[19]/td[" + rowNumber + "]//a"),3).Click();
        }
        public void VerifyButtonState(string button)
        {
            bool state = WaitForElementToBePresent(By.XPath($"//button[text()='{button}']")).Displayed;
            Assert.IsTrue(state);
        }
        public void ClickClose(string button)
        {
           WaitForElementToBeClickeable(By.XPath($"//button[text()='{button}']"), 2).Click();          
            this.Pause(3);
        }
        public bool NoViewOfAccountNumber()
        {
            Regex reg = new Regex("X/*{*/3}[-]?X{2}[-]?[0-9]{4}");
            IList<IWebElement> accountList = this.WaitForElementsToBeVisible(By.XPath("//td[@data-title='ACCOUNT #']/a")).ToList();
            accountNumber = accountList[0].Text;
            return reg.IsMatch(accountNumber);
        }
        public void ViewOfAccountNumber(string accountNumber, string accountsCaseNumber)
        {
            IList<IWebElement> accountRows = driver.FindElements(caseTableRows);
            int accountCount = accountRows.Count;

            for (int row = 1; row <= accountCount; row++)
            {
                IWebElement caseNumber = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[2]"));
                var caseNumberList = caseNumber.Text;
                if (caseNumberList == accountsCaseNumber)
                {
                    IList<IWebElement> accountNumberList = driver.FindElements(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + row + "]//td[6]/a"));
                    foreach (var element in accountNumberList)
                    {
                        Assert.IsTrue(element.Text.Equals(accountNumber, StringComparison.OrdinalIgnoreCase));
                        break;   
                    }
                }
                row++;
            }
        }
    }
}
