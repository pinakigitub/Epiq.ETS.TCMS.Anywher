using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Tasks
{
    class TaskResolvedPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";

        private By caseTableRowsLocator = By.XPath("//table[contains(@class,'epiq-table table')]/tbody/tr");

        //Task Resolved related Locators
        private By isResolvedLocator = By.XPath("//div[label[text()='IS RESOLVED']]/div/label");
        private By resolvedStatusLocator = By.XPath("//div[label[text()='IS RESOLVED?']]//div/div/span[3]/span");
        private string resolvedStatusSelect = "//div/div[text()='{0}']";

        //Add Task input Locators
        private By addTaskLocator = By.XPath("//button[text()=' Task']");
        private By debtorInputLocator = By.XPath("//div[label[text()='CASE # / DEBTOR NAME']]//input[1]");
        private By debtorSelectLocator = By.XPath("//a[@class='dropdown-item']");
        private By taskTypeLocator = By.XPath("//div[label[text()='TASK TYPE']]//span/div[1]");
        private By statusLocator = By.XPath("//main[@id='epiq-main-page-wrap']//form//div[label[text()='STATUS']]/div//div[span]");
        private By assignLocator = By.XPath("//div[label[text()='ASSIGN']]/div/div");
        private By notesLocator = By.XPath("//main[@id='epiq-main-page-wrap']//div[label[text()='NOTES']]/textarea");
        private By saveButtonLocator = By.XPath("//button[text()='SAVE']");

        //Filter Input Locators
        private By assignedToLocator = By.XPath("//div[label[text()='TASK ASSIGNED TO']]//span/div[1]");
        private By closeButtonLocator = By.XPath("//button[text()='CLOSE']");


        public TaskResolvedPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }
        public void ClickEditWithDebtorName(string debtor)
        {
            this.Pause(3);
            IList<IWebElement> Rows = driver.FindElements(caseTableRowsLocator);
            int RowLength = Rows.Count;

            for (int i = 1; i <= RowLength; i++)
            {
                IWebElement Debtor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + i + "]//td[3]"));
                string DebtorList = Debtor.Text;

                if (DebtorList == debtor)
                {
                    this.Pause(1);
                    var edit = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tbody/tr[" + i + "]/td[10]/a"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", edit);
                    break;
                }
                i++;
            }
        }
        public void VerifyTitleHeader(string expectedTitle)
        {
            var actualTitle = WaitForElementToBeVisible(By.XPath("//ol/li[2]/span"),3);
            var final = actualTitle.Text;
            expectedTitle = expectedTitle.Trim();
            Assert.AreEqual(final.ToLower(), expectedTitle.ToLower());
            this.Pause(3);
        }
        public void SelectIsResolved()
        {
            ScrollDown();
             var check = WaitForElementToBeVisible(isResolvedLocator,3);
            Actions action = new Actions(driver);
            action.MoveToElement(check).Click().Build().Perform();
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", text);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", text);
        }
        public void ClickSave()
        {
            var save = WaitForElementToBeClickeable(saveButtonLocator,3);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", save);
        }
        public void ResolvedType(string resolvedStatus)
        {
            WaitForElementToBeClickeable(resolvedStatusLocator,3).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(resolvedStatusSelect, resolvedStatus))).Click();
        }
        public void DebtorResolvedStatus(string debtor)
        {
            this.Pause(3);
            IList<IWebElement> Rows = driver.FindElements(caseTableRowsLocator);
            int RowLength = Rows.Count;

            for (int i = 1; i <= RowLength; i++)
            {
                IWebElement Debtor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + i + "]//td[3]"));
                string DebtorResList = Debtor.Text;

                if (DebtorResList == debtor)
                {
                    Thread.Sleep(1000);
                    var resColor = driver.FindElement(By.XPath("//div[@class='epiq-table-wrapper clearfix ']//tr[" + i + "]/td[9]/a/i")).GetCssValue("color");

                    string[] arrColor = resColor.Split(',');
                    string[] hexValue = resColor.Replace("rgba(", "").Replace(")", "").Split(',');

                    int hexValue1 = Int32.Parse(hexValue[0]);
                    hexValue[1] = hexValue[1].Trim();
                    int hexValue2 = Int32.Parse(hexValue[1]);
                    hexValue[2] = hexValue[2].Trim();
                    int hexValue3 = Int32.Parse(hexValue[2]);

                    string actualColor = string.Format("#34a01e", hexValue1, hexValue2, hexValue3);
                    Assert.AreEqual("#34a01e", actualColor);
                    break;
                }
                i++;
            }
        }
        public void ClickAddTask()
        {
            WaitForElementToBeClickeable(addTaskLocator,3).Click();
        }
        public void EnterDebtorName(string debtorname)
        {
            this.TypeInCharByChar(driver.FindElement(debtorInputLocator), debtorname);
            this.Pause(3);
            WaitForElementToBeClickeable(debtorSelectLocator).Click();
        }
        public void SelectTaskType(string taskType)
        {
            WaitForElementToBeClickeable(taskTypeLocator,3).Click();
            var task = driver.FindElement(By.XPath($"//div[div[@class='Select-menu-outer']]//div[text()='{taskType}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", task);
            this.Pause(2);
            task.Click();
        }
        public void SelectStatus(string status)
        {
            WaitForElementToBeVisible(statusLocator,3).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[text()='{status}']"),2).Click();
        }
        public void SelectAssign(string assign)
        {
            WaitForElementToBeClickeable(assignLocator,2).Click();
            WaitForElementToBeClickeable(By.XPath($"//div[div[@class='Select-menu-outer']]//div[text()='{assign}']"),2).Click();
        }
        public void EnterNotes(string notes)
        {
            WaitForElementToBeClickeable(notesLocator,3).Click();
            this.TypeIn(WaitForElementToBeVisible(notesLocator), notes);
        }
        public void ClickOnClose()
        {
            var close = WaitForElementToBeVisible(closeButtonLocator,2);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", close);
            this.Pause(2);
        }
        public void SelectAssignTo(string assign)
        {
            WaitForElementToBeClickeable(assignedToLocator,3).Click();
            var assigned = driver.FindElement(By.XPath($"//div[div[@class='Select-menu-outer']]//div[text()='{assign}']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true)", assigned);
            this.Pause(3);
            assigned.Click();
        }
    }
}
