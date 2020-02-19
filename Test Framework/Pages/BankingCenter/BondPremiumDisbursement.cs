using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using FluentAssertions;
using System.Data;
using System.Threading;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Bogus;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter
{
    public class BondPremiumDisbursement : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        public BondPremiumDisbursement(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        private By disbursementFilter = By.XPath("//div[@class='filter-buttons']/button");
        private By filterResetButton = By.XPath("//button[text()='RESET']");
        private By filterCloseButton = By.XPath("//button[text()='CLOSE']");
        private By addBond = By.XPath("//button[text()=' BOND']");
        private By cancelButton = By.XPath("//button[@class='btn btn-default']");
        private By editIcon = By.XPath("//i[@class='fa test fa-pencil']");
        private By bondAlerts = By.XPath("//i[contains(@class,'epiq-cursor-pointer text-warning')]");
        private By calculateButton = By.XPath("//button[text()='CALCULATE']");
        private By bondStatus = By.XPath("(//span[@class='Select-arrow'])[1]");
            
        public void ClickOnFilter()
        {
            this.Pause(3);
            this.WaitForElementToBeClickeable(disbursementFilter).Click();
        }
        public void ClickOnResetButton()
        {
            this.Pause(3);
            var e = driver.FindElement(filterResetButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public void ClickOnCloseButton()
        {
            this.Pause(3);
            var e = driver.FindElement(filterCloseButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
         public void ClickOnAddBond()
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(addBond).Click();
         }
        public void ClickOnCancelBtn()
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(cancelButton).Click();
        }
         public void EditBondPremiumDisbursement()
        {
            IList<IWebElement> ViewButton = this.WaitForElementsToBeVisible(editIcon).ToList();
            ViewButton[0].Click();
            this.Pause(3);
        }
        public void MouseHoverOnAlerts()
        {
            Thread.Sleep(4000);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(bondAlerts)).Perform();
            this.PressEscapeKey();
        }
        public void CalculateButton()
        {
            this.WaitForElementToBeVisible(calculateButton).Click();            
        }
        public void MandatoryCheckValidations()
        {
            var actualErrMsg = "Please review the error(s) above.";
            IWebElement expectedErrMsg = driver.FindElement(By.XPath("//p[@class='text-danger epiq-form-validation-summary']"));
            string newErrMsg = expectedErrMsg.Text;
            Assert.AreEqual(newErrMsg, actualErrMsg);
        }
        public void SelectPaymentMethod(string payMethod)
        {
            WaitForElementToBeClickeable(By.XPath("//div[label[text()='PAYMENT METHOD']]//div[input[@name='paymentMethod']]/div"), 2).Click();
            var text = WaitForElementToBeVisible(By.XPath($"//div[@class='Select-menu-outer']//div[text()='{payMethod}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", text);
            text.Click();
        }
        public void SelectStatusOption(string SelectStatus)
        {
            this.Pause(1);
            WaitForElementToBeClickeable(bondStatus, 4).Click();
            this.Pause(1);
            driver.FindElement(By.XPath($"//div[text()='{SelectStatus}']")).Click();
        }        
    }
}
