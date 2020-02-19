using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.DashboardExtendNoData
{
    class GlobalExtendNoDataPage : UnityPageBase
    {
        private static string pageExpectedTitle = "UNITY";
        string actualHeader;
        string actualSubHeader;
        string actualMessage;
        private By filterIcon = By.XPath("//button[@class='btn btn-info'][@title='View and change current filters.']");  
        private By roleDropdown = By.XPath("//span[contains(@class,'Select-arrow-zone')]/span");
        private By selectFilterOptionAccountant = By.XPath("//div[contains(text(), 'Accountant')]"); 
        private By filterClose = By.XPath("//div[contains(@class,'pull-right')]/i");

        public GlobalExtendNoDataPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
            this.driver = driver;
            // driver.IntializePage<GlobalExtendNoDataPage>(this);
        }
        public void HeaderVerify(string header)
        {           
            actualHeader = WaitForElementToBeVisible(By.XPath("//div[contains(@class,'epiq-page-header')]/h2 | //div[contains(@class,'epiq-page-header  ')]/h2"),5).Text;
            Assert.AreEqual(actualHeader, header);
        }
        public void SubHeaderVerify(string subHeader)
        {
            actualSubHeader = WaitForElementToBePresent(By.XPath("//div[contains(@class,'epiq-page-controls')]/div/h3"),4).Text;
            if (actualSubHeader =="Participants (2)")
            {
                WaitForElementToBePresent(filterIcon,2).Click();
                WaitForElementsToBeVisible(roleDropdown);
                WaitForElementToBePresent(roleDropdown).Click();
                WaitForElementsToBeVisible(selectFilterOptionAccountant);
                WaitForElementToBePresent(selectFilterOptionAccountant).Click();
                WaitForElementToBePresent(filterClose).Click();
                Assert.AreEqual(actualSubHeader.Substring(0, actualSubHeader.IndexOf('(')).Trim(), subHeader.Trim());
            }
            else
            {
                Assert.AreEqual(actualSubHeader.Substring(0, actualSubHeader.IndexOf('(')).Trim(), subHeader.Trim());
            }
        }
        public void MessageVerify(string message)
        {
            this.Pause(2);
            actualMessage = WaitForElementToBePresent(By.XPath("//div[contains(@class,'text-center epiq-table-data-no-data-message')]"),2).Text;
            Assert.AreEqual(actualMessage, message);
        }
        public void DashboardMessageVerify(string dashboardMessage)
        {
            var actualMessage = WaitForElementToBePresent(By.XPath("//div[@class='epiq-dashboard']//div[text()='"+dashboardMessage+"']"),2);
            Assert.AreEqual(actualMessage.Text.Trim(), dashboardMessage.Trim());
        }
    }
}

