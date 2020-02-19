using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    class CheckCreationPage:PageObject
    {
        private static string pageExpectedTitle = "UNITY";
        private By bankAccountsOption = By.XPath("//ul[@class='epiq-navbar epiq-navbar-right nav nav-pills']//a[@href='/banking/bank-accounts']");
        private By filterIcon = By.XPath("//button[@class='btn btn-info'][@title='View and change current filters.']");
        private By accountNumberField = By.XPath("//div[@class='row']//div//label[text()='ACCOUNT #']/following-sibling::input[@type='text']");
        private By closeButton = By.XPath("//button[text()='CLOSE']");
        private By accountNumberOnGrid = By.XPath("//td[6]/a");
        //account management page locators
        private By checkButton = By.XPath("(//div[@class='epiq-page-control']/button)[2]");
        private By caseDebtorName = By.XPath("//div[contains(@class,'rbt-input')]//input[@placeholder='Select a Payee...']");
        //write check page locators
        private By headerPage = By.XPath("//div[@class='epiq-page-case-modify-title']//ol | html/body/div/div/main/div/div/div[1]/div[1]/h2 | //div[@class='epiq-page-header  ']//ol | //div[@class='epiq-page-header  has-case-content']//ol | //div[@class='epiq-page-header']//ol |  //div[@class='epiq-page-header has-right-content ']//ol");
        private By clearDate = By.XPath("//div[@class='row']//div[label[contains(text(),'CLEAR DATE')]]//input[@placeholder='MM/DD/YY']");
        private By descriptionText = By.XPath("//label[contains(text(),'DESCRIPTION')]//following-sibling::input");
        private By distributionInput = By.XPath("//div[@id='epiq-outer-container']//div[label[contains(text(),'DISTRIBUTION TYPE')]]//input");
        private By remarks = By.XPath("//div[label[contains(text(),'REMARKS')]]//textarea[@name='notes']");
        private By amount = By.XPath("//input[@name='amount']");
        private By interestAmount = By.XPath("//label[text()='INTEREST AMOUNT']");
        private By interestValue = By.XPath("//label[text()='INTEREST AMOUNT']/parent::div//span");
        private By interestAmountValue = By.XPath("//input[contains(@name, 'interestAmount')]");
        private By selectLinkedAmount = By.XPath("//button[text()='[Linked Amount]']");
        private By updateLinkedAmount = By.XPath("//h3[text()='Linked Amount']/following-sibling::div//input");
        //claimant payee locators
        private By selectClaimant = By.XPath("//div[@class='col-xs-12']/div[1]/div[@class='epiq-lookup-picker-card-content']");
        private By save = By.XPath("//div[@class='container']//button[text()='SAVE']");    
        private By addStandardClaim = By.XPath("//div[@class='modal-footer']//button[text()='ADD']");
        private By verifyTextMessage = By.XPath("//div[@class='epiq-form-items']");      
        private By lineItemAdd = By.XPath("//div[@class='epiq-banking-create-check']//i");
        


        public CheckCreationPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
          //  this.driver = driver;
            // driver.IntializePage<GlobalExtendNoDataPage>(this);
        }
        public void SelectBankAccount()
        {
            WaitForElementToBePresent(bankAccountsOption).Click();
        }
        public void ClickFilter()
        {
            WaitForElementToBeVisible(filterIcon).Click();
        }
        public void AccountNoFilter(string accountno)
        {
            this.Pause(2);
            WaitForElementToBeVisible(accountNumberField).SendKeys(accountno);
            this.Pause(3);
        }
        public void CloseFilter()
        {
            WaitForElementToBePresent(closeButton).Click();
            this.Pause(2);
        }
        public void AccountNoGridClick()
        {
            this.Pause(3);
            WaitForElementToBePresent(accountNumberOnGrid).Click();
            this.Pause(4);
        }
        public void SelectPayeeName(string search, string caseName)
        {
            WaitForElementToBeVisible(caseDebtorName, 2).SendKeys(caseName);
            this.Pause(4);
            WaitForElementToBeVisible(caseDebtorName, 2).SendKeys(Keys.Down);
            WaitForElementToBeVisible(caseDebtorName, 2).SendKeys(Keys.Enter);
            this.Pause(2);
        }

        public void CheckButtonClick()
        {
            Thread.Sleep(2000);
          WaitForElementToBeClickeable(checkButton,3).Click();
        }      
        public void VerifyBreadCrumb(string header)
        {
            this.ScrollUpToPageTop();
            var actualHeader = WaitForElementToBePresent(headerPage).Text.Trim();
            // Assert.AreEqual(actualHeader, header);
            actualHeader.Contains(header);
        }
        public void ClearDateInput(string Date)
        {
            this.Pause(2);
            string DateTime = System.DateTime.Now.ToString("MM/dd/yy");
            WaitForElementToBePresent(clearDate,2).SendKeys(DateTime);
        }
        public void UpdateClearDate(string Date)
        {
            this.Pause(2);
            string DateTime = System.DateTime.Now.ToString("MM/dd/yy");
            WaitForElementToBePresent(clearDate, 2).Clear();
            this.Pause(2);
            WaitForElementToBePresent(clearDate, 2).SendKeys(DateTime);
        }
        public void InputAddressFields(string description, string distributionType, string remarksInput)
        {
            ScrollDownToPageBottom();           
            MoveToElementAndClick(driver.FindElement(descriptionText));
            this.Pause(2);
            WaitForElementToBeVisible(descriptionText).SendKeys(description);                  
            WaitForElementToBePresent(distributionInput).SendKeys(distributionType);
            this.Pause(1);
            WaitForElementToBePresent(distributionInput).SendKeys(Keys.Down);
            WaitForElementToBePresent(distributionInput).SendKeys(Keys.Enter);         
            WaitForElementToBePresent(remarks).SendKeys(remarksInput);
        }
        public void LinkClaimClick(string claimType)
        {
            ScrollWindowBy(0, 500);
            if (claimType == "LINK CLAIM")
            {
                WaitForElementToBePresent(By.XPath("//div[@class='form-group epiq-form-item-list']//button[text()='" + claimType + "']"),2).Click();
            }
            else
            {
                WaitForElementToBePresent(By.XPath("//div[text()='UNLINKED ALLOCATIONS (UTC)']")).Click();
                this.Pause(2);
                WaitForElementToBePresent(By.XPath("//div[@class='form-group epiq-form-item-list']//button[text()='" + claimType + "']"),4).Click();
            }
          
        }
        public void InputAmount(string amountValue)
        {
            SelectAndDeleteCompleteText(amount);
            Thread.Sleep(2000);
            WaitForElementToBePresent(amount).SendKeys(amountValue);
        }

        public void InputUpdatedAmount(string Value)
        {
            SelectAndDeleteCompleteText(amount);
            WaitForElementToBePresent(amount).SendKeys(Value);
        }
        public void ClaimSelect()
        {
            WaitForElementToBePresent(selectClaimant,3).Click();
            WaitForElementToBePresent(addStandardClaim).Click();
        }

        public void UpdateLinkedAmount(string Value)
        {
            var uLinkedAmount = WaitForElementToBePresent(selectLinkedAmount);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", uLinkedAmount);
            Thread.Sleep(3000);
            WaitForElementToBePresent(updateLinkedAmount).SendKeys(Value);
        }
        public void SaveCheck()
        {
            this.Pause(2);
            MoveToElementAndClick(driver.FindElement(save),607, 18);
            JavaScriptClick(driver.FindElement(save));
            this.Pause(2);
        }
        public void verifyMessage(string message)
        {
            var actualMessage = driver.FindElement(verifyTextMessage).Text;
            Assert.AreEqual(actualMessage.Trim(), message.Trim());
        }

        public void InputUTCFields(int rowIndex,string payeeName, string desc, string utcValue, string amount)
        {
            int dropdownIndex = rowIndex + 1;
            WaitForElementToBePresent(By.XPath("//input[@name='addUnlinked Allocation (UTC)ListItem.new["+ rowIndex + "].payeeName']")).SendKeys(payeeName);         
            WaitForElementToBePresent(By.XPath("//input[@name='addUnlinked Allocation (UTC)ListItem.new["+ rowIndex + "].description']")).SendKeys(desc);        
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-banking-bordered-row']["+ dropdownIndex + "]//div[@class='Select-input']//input")).SendKeys(utcValue);          
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-banking-bordered-row']["+ dropdownIndex + "]//div[@class='Select-input']//input")).SendKeys(Keys.Enter);
            this.Pause(2);
            WaitForElementToBePresent(By.XPath("//input[@name='addUnlinked Allocation (UTC)ListItem.new["+rowIndex+"].linkedAmount']")).SendKeys(amount);          
        }
        public void SelectCompensable(string compensableStatus,int row)
        {
            if (compensableStatus == "YES")
            {              
                WaitForElementToBePresent(By.XPath("//div[@class='epiq-banking-bordered-row']["+row+"]//span[text()='Non Compensable']"),2).Click();
            }
        }
        public void ClickAddLineItem()
        {
            WaitForElementToBePresent(lineItemAdd).Click();
        }
        public void ClickAdd(string buttonText)
        {
            WaitForElementToBePresent(By.XPath("//div[@class='modal-footer']//button[text()='"+buttonText+ "']")).Click();
            this.Pause(3);
        }
        public void EnterPayeeName(string payeeName)
        {
            TypeIn(WaitForElementToBeVisible(By.XPath("//div[label[text()='SEARCH PAYEE NAME']]//input[1]"),2),payeeName);
            WaitForElementToBeClickeable(By.XPath($"//div[@class='row']//div[@class='menu-item']/div/strong[text()='{payeeName}']"),3).Click();
            
        }
        public bool InterestAmountDisplayed()
        {
            return this.WaitForElementToBeVisible(interestAmount).Displayed;
        }

        public void InputInterestAmount(string amountValue)
        {
            Thread.Sleep(2000);
            var Interestvalue1 = WaitForElementToBePresent(interestValue);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();",Interestvalue1);
            SelectAndDeleteCompleteText(interestAmountValue);
            WaitForElementToBePresent(interestAmountValue).SendKeys(amountValue);
        }

        public void VerifyInterestAmountFieldNonEditable()
        {
            Thread.Sleep(4000);
            Boolean value = WaitForElementToBeVisible(interestValue).Enabled;
            value.Should().BeTrue();

        }
        }

    }
