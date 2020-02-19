using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NUnit.Core.NUnitFramework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Emails
{
    public class EmailsPage : UnityPageBase
    {
        private By emailsPageHeader = By.XPath("//h2[text()='Email Management']");
        private By breadCrumbLocator = By.XPath("//ol[@class='breadcrumb']//li");
        private By emailsCountLocator = By.XPath("//div[@class='epiq-page-controls clearfix container row']//span//span");
        private By headersLocator = By.XPath("//th[contains(@class,'epiq-table-header-sortable')]");
        private By filterDateFrom = By.XPath("//div[label[text()='DATE (FROM)']]//div[@class='rdt epiq-date-picker']//input");
        private By filterDateTo = By.XPath("//div[label[text()='DATE (TO)']]//div[@class='rdt epiq-date-picker']//input");
        private By filterButton = By.XPath("//i[@class='fa fa-filter']");
        private By filterCloseButton = By.XPath("//button[text()='CLOSE']");
        private By filterFunnelCount = By.XPath("//div[@class='filter-buttons']//span");
        private By dateTimeList = By.XPath("//td[@data-title='DATE/TIME']");
        public EmailsPage(IWebDriver driver) : base(driver, "UNITY")
        { }
        public string GetHeaderName()
        {
            return WaitForElementToBeVisible(emailsPageHeader).Text;
        }
        public bool IsEmailsCountDisplaying()
        {
            return WaitForElementToBeVisible(emailsCountLocator).Displayed;            
        }

        public void VerifyHeaders()
        {
            var expectedHeaderNames = new List<string>() { "CASE #", "DEBTOR", "DATE/TIME", "SUBJECT", "FROM", "TO" };

            var actualHeadersList = WaitForElementsToBeVisible(headersLocator).ToList().Select(e => e.Text).ToList();
            actualHeadersList.Should().Contain(expectedHeaderNames);
        }
        public void VerifyCaseLevelHeaders()
        {
            var expectedHeaderNames = new List<string>() { "DATE/TIME", "SUBJECT", "FROM", "TO" };
            
                var actualHeadersList = WaitForElementsToBeVisible(headersLocator).ToList().Select(e => e.Text).ToList();
                actualHeadersList.Should().Contain(expectedHeaderNames);
           
        }
        public void ClickOnFilter()
        {
            WaitForElementToBeClickeable(filterButton).Click();
        }
        public void SelectDateFrom(string fromDate)
        {
            this.WaitForElementToBeVisible(filterDateFrom).SendKeys(fromDate);
            Thread.Sleep(1500);
        }
        public void SelectDateTo(string toDate)
        {
            this.WaitForElementToBeVisible(filterDateTo).SendKeys(toDate);
        }
        public void ClickOnClose()
        {
            WaitForElementToBeClickeable(filterCloseButton).Click();
        }
        public void ValidateRecords(string expectedDate)
        {
           Thread.Sleep(1000);
            var result = WaitForElementsToBePresent(dateTimeList).ToList().Select(e => e.Text).ToList();
            foreach (var actualDate in result)
            {
                actualDate.Contains(expectedDate);
            }
        }
        public bool ValidateFilterFunnelCount()
        {
            Thread.Sleep(3000);
           int filterResultCount = WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[position() mod 2 = 1 and position() > 1]")).Count();
           filterResultCount = filterResultCount + 1;
           return WaitForElementToBeVisible(filterFunnelCount).Text.Should().Equals(filterResultCount);            
        }
    }
}
