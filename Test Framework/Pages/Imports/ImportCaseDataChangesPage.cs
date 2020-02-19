using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using static NUnit.Core.NUnitFramework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports
{
   public class ImportCaseDataChangesPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        private By breifCaseIcon = By.XPath("//i[@class='fa fa-briefcase']");
        private By noDataDisplayMessage = By.XPath("//div[@class='text-center epiq-table-data-no-data-message']");
        private By caseNumberColumnHeader = By.XPath("//th[contains(text(),'CASE #')]");
        private By debtorColumnHeader = By.XPath("//th[contains(text(),'DEBTOR')]");
        private By dateOfChangeColumnHeader = By.XPath("//th[contains(text(),'DATE OF CHANGE')]");
        private By typeColumnHeader = By.XPath("//th[contains(text(),'TYPE')]");
        private By fieldColumnHeader = By.XPath("//th[contains(text(),'FIELD')]");
        private By oldColumnHeader = By.XPath("//th[contains(text(),'OLD')]");
        private By newColumnHeader = By.XPath("//th[contains(text(),'NEW')]");

        public ImportCaseDataChangesPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        public void ViewColumnNames()
        {
            this.Pause(2);
            string actualCaseNumber = WaitForElementToBePresent(caseNumberColumnHeader, 2).Text;
            string actualDebtor = WaitForElementToBePresent(debtorColumnHeader, 2).Text;
            string actualDateOfChange = WaitForElementToBePresent(dateOfChangeColumnHeader, 2).Text;
            string actualType = WaitForElementToBePresent(typeColumnHeader, 2).Text;
            string actualField = WaitForElementToBePresent(fieldColumnHeader, 2).Text;
            string actualOld = WaitForElementToBePresent(oldColumnHeader, 2).Text;
            string actualNew = WaitForElementToBePresent(newColumnHeader, 2).Text;
            Assert.AreEqual("CASE #", actualCaseNumber);
            Assert.AreEqual("DEBTOR", actualDebtor);
            Assert.AreEqual("DATE OF CHANGE", actualDateOfChange);
            Assert.AreEqual("TYPE", actualType);
            Assert.AreEqual("FIELD", actualField);
            Assert.AreEqual("OLD", actualOld);
            Assert.AreEqual("NEW", actualNew);            
        }

        public void VerifyBreifCaseIcon()
        {
            this.Pause(2);
            IWebElement icon = WaitForElementToBeVisible(breifCaseIcon, 8);
            JSMoveToViewElement(icon);
            icon.Displayed.Should().BeTrue();            
        }
        public void VerifyNoDataDisplay()
        {
            this.Pause(2);
            string message = WaitForElementToBePresent(noDataDisplayMessage, 8).Text;
            Assert.AreEqual("No Case Data Changes Matching Current View", message);
        }

    }
}