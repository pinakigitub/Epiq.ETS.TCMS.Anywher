using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using OpenQA.Selenium;
using System;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using System.Linq;
using System.Data;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.UnityReports
{
    class UnityReportsPage : PageObject
    {
        private static string pageExpectedTitle = "UNITY";
        private By reportNames = By.XPath("//div[@class='epiq-frame-container']//ul//li/a");
        private By reportQueueClose = By.XPath("//div[@class='pull-right epiq-fa']//i");
        private By textAreaInput = By.XPath("//textarea[@name='caseNumbers']|//div[@class='rbt-input-wrapper']//input[@class='rbt-input-main']");
        private By clearAll = By.XPath("//a[text()='CLEAR ALL']");
        private By daysOutstanding = By.XPath("//input[@name='outstandingdays']");
        private By percentMargin = By.XPath("//input[@name='percentOfMargin']");
        private By reportsList = By.XPath("//div[@class='epiq-menu epiq-menu-vertical']/ul/li/a");
        private By popUpHeader = By.XPath("//div[@class='modal-header']");
        private By popUpBody = By.XPath("//div[@class='clearfix modal-body']/div[1]");
        private By popUpOk = By.XPath("//button[text()='CANCEL']");
        public UnityReportsPage(IWebDriver driver) : base(driver, pageExpectedTitle)
        {
        }
        public void selectReport(string reportName)
        {
            IList<IWebElement> reportNamesList = driver.FindElements(reportNames);
            Thread.Sleep(2000);
            reportNamesList.Where(name => name.Text == reportName).FirstOrDefault().Click();
        }

        public void verifyReportHeader(string reportHeader)
        {
            string actualHeader = WaitForElementToBePresent(By.XPath("//div[@class='epiq-report']//h3"), 2).Text;
            Assert.AreEqual(actualHeader.Trim(), reportHeader.Trim());
        }

        public void verifyReportSubHeader(string reportSubHeader)
        {
            string actualSubHeader = WaitForElementToBePresent(By.XPath("//div[@class='epiq-report']//div[2]//h4")).Text;
            Assert.AreEqual(actualSubHeader.Trim(), reportSubHeader.Trim());
        }

        public void SelectTrusteeDivisionAsset(string labelName, string trusteeOrOrderByvalue)
        {
            Thread.Sleep(2000);
            WaitForElementToBePresent(By.XPath("//div[label[contains(text(),'" + labelName + "')]]//span[@class='Select-arrow']"), 3).Click();
            Thread.Sleep(2000);
            IList<IWebElement> trusteeOptionsList = driver.FindElements(By.XPath("//div[@class='Select-menu-outer']//div[@role='option']"));
            Thread.Sleep(2000);
            trusteeOptionsList.Where(name => name.Text == trusteeOrOrderByvalue).FirstOrDefault().Click();
            Thread.Sleep(2000);
        }

        public void SelectOption(string option)
        {
            WaitForElementToBePresent(By.XPath("//div[@class='epiq-report']//span[text()='" + option + "']"), 2).Click();
            this.Pause(5);
        }

        public void SelectDates(string dateLabel, string dateValue)
        {
            Thread.Sleep(1500);
            SelectAndDeleteCompleteText(By.XPath("//div[label[contains(text(),'" + dateLabel + "')]]//input[@placeholder='MM/DD/YY']"));
            Thread.Sleep(1500);
            WaitForElementToBePresent(By.XPath("//div[label[contains(text(),'" + dateLabel + "')]]//input[@placeholder='MM/DD/YY']")).SendKeys(dateValue);
            Thread.Sleep(1500);
        }

        public void VerifyTheAddedData()
        {
            this.Pause(4);
            var addedCasesCount = driver.FindElements(By.XPath("//div[@class='epiq-form-item-display']")).Count;
            Assert.Greater(addedCasesCount, 0);
        }

        public void ClickButtons(string buttonName)
        {
            Thread.Sleep(5000);
            var button = WaitForElementToBePresent(By.XPath("//button[text()='" + buttonName + "']"),3);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", button);
            Thread.Sleep(6000);
        }

        public void ClickClearAll()
        {
            var clear = WaitForElementToBeClickeable(clearAll,4);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", clear);
        }

        public void VerifyTitleAndNotificationMessage(string notificationMessage)
        {
            this.Pause(2);
            var actualMessage = WaitForElementToBePresent(By.XPath("//div[text()='" + notificationMessage + "']"), 10).Text;
            Assert.AreEqual(actualMessage, notificationMessage);
            this.Pause(2);
        }

        public void CloseNotification()
        {
            this.Pause(4);
            WaitForElementToBePresent(By.XPath("//button[@type='button']"), 5).Click();
            this.Pause(2);
        }

        public void InputCaseInformation(string caseInfo, string option)
        {
            if (!(option == "Interim Time Period"))
            {
                ClearAndType(WaitForElementToBeVisible(textAreaInput), caseInfo);
                this.Pause(3);
                WaitForElementToBePresent(textAreaInput).SendKeys(Keys.Down);
                WaitForElementToBePresent(textAreaInput).SendKeys(Keys.Enter);
                this.Pause(3);

            }
        }

        public void ClickClose()
        {
            var closeReportQueue = WaitForElementToBePresent(reportQueueClose, 5);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", closeReportQueue);
        }

        public void SelectReportOptions(string reportOption)
        {
            MoveToElementAndClick(driver.FindElement(By.XPath("//div[label[contains(text(),'" + reportOption + "')]]//label/span")));
        }

        public void ReportQueueSearch(string report)
        {
            ClearAndType(WaitForElementToBeVisible(By.XPath("//input[@placeholder='Search reports here']"), 5), report);
        }

        public void VerifyReportUnderReportQueue(string function, string report)
        {
            var List = WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-report-queue-info-content']"));
            var reportCount = List.Count();
            bool isFound = false;
            for (int count = 1; count <= reportCount; count++)
            {
                IList<IWebElement> DatesList = driver.FindElements(By.XPath("//div[" + count + "]/div[2]/div/h6/span[1]"));
                foreach (IWebElement dates in DatesList)
                {
                    var date = dates.Text;
                    var currentDate = DateTime.Now.ToString("MM/dd/yyyy");
                    if (date == currentDate)
                    {
                        IList<IWebElement> reportsList = driver.FindElements(By.XPath("//div[" + count + "]/div[1]/div[2]//h5"));
                        foreach (IWebElement element in reportsList)
                        {
                            var reportName = element.Text;
                            Assert.AreEqual(reportName, report);
                            this.Pause(6);
                            WaitForElementToBeClickeable(By.XPath("//div[" + count + "]/div[1]/div[2]//div/button"), 4).Click();
                            this.Pause(6);
                            WaitForElementToBeClickeable(By.XPath("//div[1]/div[" + count + "]/div[2]/div/div/ul/li/a[text()='" + function + "']"), 8).Click();
                            isFound = true;
                            break;
                        }
                        Assert.IsTrue(isFound);
                    }
                }
                break;
            }
        }
        public void SelectInterimTimePeriod()
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-input-styled-radio-checkbox']//span[text()='Interim Time Period']"), 4).Click();

        }
        public void SelectSearchAdd()
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-input-styled-radio-checkbox']//span[text()='Search Add']"), 4).Click();
        }
        public void InputCaseNumber(string casenumber)
        {
            WaitForElementToBePresent(By.XPath("//div[@class='row']//div[@class='rbt-input-wrapper']/div/input")).SendKeys(casenumber);
            this.Pause(3);
            WaitForElementToBeClickeable(By.XPath("//div[@class='row']//a[@class='dropdown-item']"), 4).Click();
        }
        public void VerifyRecordsWithPageSize(int size)
        {
            var List = WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-report-queue-info-content']"));
            var reportCount = List.Count();
            Assert.AreEqual(reportCount, size);
        }
        public void SelectBankAccount()
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='Select-placeholder']"), 4).Click();
            WaitForElementToBeClickeable(By.XPath("//div[@class='Select-menu-outer']//div[@class='Select-option is-focused']"), 4).Click();

        }
        public void Inputpercentofmargin(string percent)
        {
            WaitForElementToBePresent(percentMargin).Click();
            WaitForElementToBePresent(percentMargin).SendKeys(percent);
        }

        public void InputDAYSOUTSTANDING(string days)
        {
            WaitForElementToBePresent(daysOutstanding).Click();
            WaitForElementToBePresent(daysOutstanding).SendKeys(days);
        }

        public void InputCaseNumberOrDebtorName(string label, string value)
        {
            this.Pause(4);
            TypeIn(WaitForElementToBeVisible(By.XPath($"//div[label[text()='{label}']]//input[@type='text']"), 3), value);
            this.Pause(4);
            WaitForElementToBeClickeable(By.XPath("//ul[@role='listbox']/li/a"), 2).Click();
        }

        public void ThenInputDaysOutstanding(string days)
        {
            WaitForElementToBePresent(daysOutstanding).Click();
            WaitForElementToBePresent(daysOutstanding).SendKeys(days);
        }

        public void ClickCheckBoxValues(string checkOption)
        {
            var OptionPresence = WaitForElementToBePresent(By.XPath("//span[text()='" + checkOption + "']|//div[label[contains(text(),'"+ checkOption + "')]]//input")).Enabled;
            Assert.IsTrue(OptionPresence);
            MoveToElementAndClick(driver.FindElement(By.XPath("//span[text()='" + checkOption + "']|//div[label[contains(text(),'"+ checkOption + "')]]//label//span")));
        }

        public void VerifyReportCenterText(string centerText, string subText)
        {
            var reportsCenterText = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-report-create-message text-center']/strong")).Text;
            Assert.AreEqual(reportsCenterText, centerText);
            var reportsSubText = WaitForElementToBeVisible(By.XPath("//div[@class='epiq-report-create-message text-center']/span")).Text;
            Assert.AreEqual(reportsSubText, subText);
        }

        public void VerifyReportsListAlphabeticalOrder()
        {
            IList<IWebElement> list = driver.FindElements(reportsList);
            List<string> report = new List<string>();
            var alphabetical = true;
            string previous = null;

            foreach (var item in list)
            {
                string text = item.Text.Replace(System.Environment.NewLine, "");
                var current = item.Text.Replace(System.Environment.NewLine, "");
                report.Add(current);
                if (previous != null && StringComparer.Ordinal.Compare(previous, current) > 0)
                {
                    alphabetical = false;
                }
                previous = current;
            }

        }
        public void SelectBank()
        {
            WaitForElementToBeClickeable(By.XPath("//div[@class='Select-placeholder']"), 4).Click();
            WaitForElementToBeClickeable(By.XPath("//div[@class='Select-menu-outer']//div[@class='Select-menu']/div[1]"), 4).Click();
            this.Pause(2);
        }
        public void ReportOptions(string option)
        {
            MoveToElementAndClick(driver.FindElement(By.XPath($"//div[@class='epiq-input-styled-checkbox ']//label/span[text()='{option}']")));
        }
        public void Bank(string bankname)
        {
            WaitForElementToBeClickeable(By.XPath("//div[label[contains(text(),'Bank')]]//div[@class='Select-value']"), 4).Click();
            this.Pause(3);
            WaitForElementToBeClickeable(By.XPath($"//div[@class='Select-menu-outer']//div[@class='Select-menu']/div[text()='{bankname}']"), 4).Click();
        }
        public void CaseValidationMessage(string validationMessage)
        {
            Assert.False(IsElementVisible(By.XPath($"//a[text()='{validationMessage}']")));
        }
        public void ClickExportXML()
        {
            ScrollDown();
            ScrollDownToPageBottom();
            var check = WaitForElementToBeVisible(By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div[3]/div[2]/form/div[1]/div/div[5]/div[5]/div[2]/div/label |.//*[@id='epiq-main-page-wrap']/div/div/div[3]/div[2]/form/div[1]/div/div[2]/div[2]/div[4]/div/div/label"), 3);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", check);
            Thread.Sleep(1000);
        }
        public void  InlineEditDatesSection()
        {
            var OF = "From 11";
            this.Pause(2);
            WaitForElementToBeClickeable(By.XPath("//div[label[text()='ORIGINALLY FROM']]/div/button"), 2).Click();
            SelectAndDeleteCompleteText(WaitForElementToBeVisible(By.XPath("//div[@data-test-selector='originallyFrom']//span/div/input")));
            this.WaitForElementToBeVisible(By.XPath("//div[@data-test-selector='originallyFrom']//span/div/input"), 2).SendKeys(OF);
            this.WaitForElementToBeVisible(By.XPath("//div[@data-test-selector='originallyFrom']//span/div/input"), 1).SendKeys(Keys.Down);
            this.WaitForElementToBeVisible(By.XPath("//div[@data-test-selector='originallyFrom']//span/div/input"), 1).SendKeys(Keys.Enter);
            WaitForElementToBeClickeable(By.XPath("//div[@class='epiq-form-inline-button']/button[@type='submit']"), 2).Click();

        }
        
        public void VerifyPopUpHeader(string expectedHeader)
        {
           string actual = WaitForElementToBePresent(popUpHeader).Text;
            Assert.IsTrue(actual.Contains(expectedHeader));
        }
        public void VerifyPopUpBody(string expectedBody)
        {
           var actual = WaitForElementToBePresent(popUpBody).Text;
            Assert.IsTrue(actual.Contains(expectedBody));
        }

       public void  VerifyTrusteeCompensationNoClaim(string errorMessage)
        {
            var actual = WaitForElementToBePresent(By.XPath("(//div[@class='row']//h3)[3]")).Text;
            Assert.IsTrue(actual.Contains(errorMessage));
        }
        public void ClickIncludeRadioButton()
        {
            WaitForElementToBeClickeable(By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div[3]/div[2]/form/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div/label")).Click();
        }
        public void ClickOnOkButton(string button)
        {
            this.Pause(2);
            driver.Manage().Window.Maximize();
            if (button== "NO")
            {
                Thread.Sleep(2500);
                this.WaitForElementToBeClickeable(By.XPath("//button[text()='NO']")).Click();
            }
            else
            {
                ScrollDown();
                ScrollDown();
                this.WaitForElementToBeClickeable(By.XPath("//button[text()='GENERATE REPORT']")).Click();
                Thread.Sleep(5000);
            }
        }
        public void EnterCompensationValues()
        {
            Random random = new Random();
            var reqComp = random.Next(100, 9999);
            var maxComp = random.Next(10, 999);
            var freeze = "200";
            ScrollDown();
            SelectAndDeleteCompleteText(By.XPath("//div[@class='row']//div//label[text()='REQUESTED COMPENSATION']/following-sibling::span/input[@type='text']"));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='REQUESTED COMPENSATION']/following-sibling::span/input[@type='text']")), reqComp.ToString());
            SelectAndDeleteCompleteText(By.XPath("//div[@class='row']//div//label[text()='MAXIMUM COMPENSATION (PROPOSED)']/following-sibling::span/input[@type='text']"));
            ClearAndType(WaitForElementToBeVisible(By.XPath("//div[@class='row']//div//label[text()='MAXIMUM COMPENSATION (PROPOSED)']/following-sibling::span/input[@type='text']")), maxComp.ToString());
            Thread.Sleep(2000);
            var yes = driver.FindElement(By.XPath("//div[@class='epiq-input-styled-checkbox ']/input[@name='freezeCompensation']/following-sibling::label"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", yes);
            ClearAndType(WaitForElementToBeVisible(By.XPath("(//div[@class='row']//div//label/following-sibling::span/input[@type='text'])[3]")), freeze.ToString());
        }
    }
}

