using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using FluentAssertions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Tasks
{
    public class TasksPage : UnityPageBase
    {
        private static string pageTitle = "UNITY";
        public TasksPage(IWebDriver driver) : base(driver, pageTitle)
        {
        }

        // Adding new code

        //private By TASKS_PAGE_HEADER = By.XPath("//div[@class='epiq-page-header']/h2");
        private By tasksPageHeader = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[2]/div/h2");
        private By tasksPageFilterOption = By.XPath("//div[3]/div/div/div/button");
        private By tasksPageFilterClose = By.XPath("//div[@class='pull-right form-group epiq-fa']/i");
        private By tasksPageHeaderNames = By.XPath("//th[@class='epiq-table-header-sortable' or @class='epiq-table-header-sortable visible-lg visible-xl' or @class='epiq-table-header-sortable visible-md visible-lg visible-xl']");
        private By tasksPageFilterOptions = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[1]/div/div[1]/div[1]/nav/div[2]/h3");
        private By tasksPageRefresh = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[3]/div[2]/div/div[1]/button[2]");
        private By tasksPageFilterOptionsCaseOrDebtor = By.XPath("//div[label[text()='TASK TYPE']]//div[@class='Select-control']/span/div/input");
        private By tasksPageFilterOptionsAssigned = By.XPath("//div[label[text()='TASK ASSIGNED TO']//div[@class='Select-control']/span/div/input");
        //private By TASKS_PAGE_FILTEROPTIONS_CaseOrDebtor_Selection = By.XPath("//a[@class ='dropdown-item']/span"); (Only one reference, so commented)
        private By tasksPageResetButton = By.XPath("//button[text()='RESET']");
        private By tasksPageCloseButton = By.XPath("//button[text()='CLOSE']");
        private string tasksFilterSelect = "//div/div[text()='{0}']";
        private By tasksPageCaseNumber = By.XPath(".//*[@id='epiq-main-page-wrap']/div/div/div[1]/div/div[1]/div[1]");
        //private By TASKS_PAGE_RowExpandButton = By.XPath("//*[@id='epiq-main-page-wrap']/div/div[4]/div/div/table/tbody/tr[1]/td[1]/div/i");(Only one reference, so commented)
        private By pageCount = By.XPath("//h3[text()='Tasks']/span");
        private By pagination = By.ClassName("pagination");
        private By activePage = By.XPath("//*[@class='pagination']//li[@class='active']/a");
        private By tasksPageTaskType = By.XPath(".//*[@id='react-select-2--value']/div[1]/span");
        private By tasksPageAssignedTo = By.XPath(".//*[@id='react-select-3--value']//span");
        private By debtorName = By.XPath("//div[@class='epiq-ellipsis-text']/a/span/span");
        //private By CASE_NUM = By.XPath("//td[@class='epiq-table-data-title  visible-xl']/a/span/span");
        private By caseNumber = By.XPath("//div[@class='panel-body']/a");
        private By dueDate = By.XPath("//td[@class='epiq-table-data-title text-error']/div/button/span");
        private By rowBorder = By.XPath("//tr[@class='epiq-table-row-error']");
        //private By CASE_TASK_VIEW_BUTTON = By.XPath("//div[@class='epiq-page-body']//td[8]//a");(Only one reference, so commented)
        //adding new objects to fix the regression
        private By addCaseOrDebtorName = By.XPath("//div[contains(@class,'rbt-input')]//input[@placeholder='Select a case...']");
        private By dropdownCase = By.XPath("//li/a[@class ='dropdown-item']");

        // Adding View Permission
        private By viewTaskButton = By.XPath("//td[@class='epiq-table-data-no-title ']/a");
        private By viewTaskHeaderName = By.XPath("//ol/li/span[text()='View Task']");

        //Add Tasks Locators
        private By addTaskButton = By.XPath("//button[text()=' Task']");
        private By addTaskHeader = By.XPath("//ol//li/span[text()='Add Task']");
        private By taskTypeInput = By.XPath("//div[@class='col-md-4 col-sm-12 form-group has-feedback']//div[@class='Select-control']//div[@class='Select-input']//input");
        private By taskSaveButton = By.XPath("//button[text()='SAVE']");
        private By taskAddToaster = By.XPath("//div[@class='toastr animated rrt-success']");
        private By taskSavePlusAddNewButton = By.XPath("//button[text()='SAVE + ADD NEW']");

        //Inline editing Locators
        private By notesButtons = By.XPath("//tbody//tr[@class='epiq-table-row-error']//td[5]//button");
        private By notesTextArea = By.XPath("//div[@class='form-group']//textarea");
        private By dueDatesButton = By.XPath("//tbody//tr[@class='epiq-table-row-error']//td[6]//button");
        private By dueDateField = By.XPath("//div[@class='form-group']//input");
        private By assignedToButtons = By.XPath("//tbody//tr[@class='epiq-table-row-error']//td[7]//button");
        private By statusButtons = By.XPath("//tbody//tr[@class='epiq-table-row-error']//td[8]//button");
        private By inlineSubmitButton = By.XPath("//div[@class='epiq-form-inline-button']//button[@type='submit']");

        public void ValidateTheColor()
        {
            string color = driver.FindElement(dueDate).GetCssValue("color");
            color.Contains("rgba(4, 157, 223, 1)");
        }
        public void ValidateTheBorderColor()
        {
            string color = driver.FindElement(rowBorder).GetCssValue("border-left-color");
            color.Contains("rgba(208, 2, 27, 1)");
        }
        public void ClickOnRowExpandButton()
        {
            Pause(2);
            IList<IWebElement> rowExpandButton = this.WaitForElementsToBeVisible(By.XPath("//div[@class='visible-sm visible-md visible-lg']/i")).ToList();
            rowExpandButton[1].Click();
            Pause(1);
        }
        public void clickOnCaseNUM()
        {
            this.WaitForElementToBeVisible(caseNumber, 2).Click();
        }
        public void CaseSpecificClick()
        {
            this.WaitForElementToBeVisible(debtorName,2).Click();
        }
        public void MouseHouver()
        {
            this.Pause(2);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(debtorName)).Perform();
            this.PressEscapeKey();
        }
        public bool GetCaseNumberDisplayed()
        {
            return driver.FindElement(tasksPageCaseNumber).Displayed;
        }
        public void ClickOnResetButton()
        {
            this.Pause(1);
            var e = driver.FindElement(tasksPageResetButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public void ClickOnCloseButton()
        {
            this.Pause(1);
            var e = driver.FindElement(tasksPageCloseButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", e);
        }
        public string GetHeaderName()
        {
            return this.WaitForElementToBeVisible(tasksPageHeader).Text;
        }
        public void ClickOnFilter()
        {
            this.WaitForElementToBeVisible(tasksPageFilterOption).Click();
        }
        public void ClickOnFilterClose()
        {
            this.WaitForElementToBeVisible(tasksPageFilterClose).Click();
        }
        public string GetFilterOptionHeader()
        {
            try
            {
                Pause(1);
                return driver.FindElement(tasksPageFilterOptions).Text;
            }
            catch
            {
                return null;
            }
        }
        public void EnterCaseNumber(string caseNumber)
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(tasksPageFilterOptionsCaseOrDebtor).SendKeys(caseNumber);
            this.WaitForElementToBeVisible(tasksPageFilterOptionsCaseOrDebtor).SendKeys(Keys.Down);
            this.WaitForElementToBeVisible(tasksPageFilterOptionsCaseOrDebtor).SendKeys(Keys.Enter);
            this.Pause(3);
        }

        public void EnterAssignedTo(string Assgined)
        {
            this.Pause(3);
            this.WaitForElementToBeVisible(tasksPageFilterOptionsAssigned).SendKeys(Assgined);
            this.WaitForElementToBeVisible(tasksPageFilterOptionsAssigned).SendKeys(Keys.Down);
            this.WaitForElementToBeVisible(tasksPageFilterOptionsAssigned).SendKeys(Keys.Enter);
            this.Pause(3);
        }
        public DataTable GetTaskRecords(string sortColumn = null)
        {
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(sortColumn))
                driver.FindElements(tasksPageHeaderNames).Where(e => e.Text.Contains(sortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(tasksPageHeaderNames).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 2; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);
                try
                {
                    this.Pause(2);
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']//span[text()]"));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }

                var testList = rows.Select(e => e.Text).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) { htmlTable.Rows[j][i] = testList[j]; }
                    else { htmlTable.Rows.Add(testList[j]); }
                }
            }
            return htmlTable;
        }
       public List<string> GetSortedList(string columnName)
        {
            List<string> list = new List<string>();

            var Table = GetTaskRecords(columnName);
            int index = Table.Columns[columnName].Ordinal;
            for (int i = 0; i <= Table.Rows.Count - 1; i++)
            {
                list.Add(Table.Rows[i][index].ToString());
            }
            return list;
        }
        public List<string> GetColumnsName()
        {
            var headerNames = driver.FindElements(tasksPageHeaderNames).Select(e => e.Text.Trim()).ToList();
            List<string> list = new List<string>();
            for (int i = 0; i <= headerNames.Count - 2; i++)
            {
                list.Add(headerNames[i]);
            }
            return list;
        }
        public void ClickOnReferesh()
        {
            this.WaitForElementToBeVisible(tasksPageRefresh).Click();
            Pause(3);
        }
        public string GetPageCount()
        {
            return this.WaitForElementToBeVisible(pageCount).Text;
        }
        public Dictionary<string, object> GetPagination()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Pagination", this.WaitForElementToBeVisible(pagination).Displayed);
            dictionary.Add("ActivePage", this.WaitForElementToBeVisible(activePage).Text);
            return dictionary;
        }
        public List<string> GetRecordsByColumnName(string columnName, string value = null)
        {
            IList<IWebElement> rows = null;
            List<string> lists = new List<string>();
            columnName = columnName.ToUpper();
            string rowXpath = "//tr//td[@data-title='{0}']//span[text()]";
            try
            {
                this.WaitForElementToBePresent(By.XPath(string.Format(rowXpath, columnName)), 8);
                rows = driver.FindElements(By.XPath(string.Format(rowXpath, columnName)));
                if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{columnName}']")); }
            }
            catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{columnName}']")); }
            lists = rows.Select(e => e.Text.Trim()).ToList();

            // To verify the value exist in the respective column 
            if (!string.IsNullOrWhiteSpace(value))
            {
                bool found = false;
                foreach (string list in lists)
                {
                    found = list.Contains(value);
                    if (found) break;
                }
                found.Should().BeTrue();
            }
            return lists;
        }
        public void ClickOnOfficeTask()
        {
            this.WaitForElementToBeClickeable(By.XPath("//li[2]/a/div/strong")).Click();
        }
        public void EnterDebtor(string search, string caseName)
        {
            try
            {
                WaitForElementToBeVisible(addCaseOrDebtorName,2).SendKeys(search);
                this.Pause(3);
                WaitForElementToBeVisible(dropdownCase).Click();
                this.Pause(3);
                IList<IWebElement> dropdownValues = driver.FindElements(By.XPath("//div[contains(@class,'rbt clearfix open undefined')]//ul//li"));
                foreach (IWebElement textBox in dropdownValues)
                {
                    if ((textBox.Text) == caseName)
                    {
                        Actions action = new Actions(driver);
                        action.MoveToElement(textBox).Click().Build().Perform();
                        break;
                    }
                }
            }
            catch { }
        }
        public void SelectType(string type)
        {
            this.WaitForElementToBeVisible(tasksPageTaskType).Click();
            this.WaitForElementToBeVisible(By.XPath(String.Format(tasksFilterSelect, type))).Click();
        }
        public void SelectAssignedTo(string assignedTo)
        {
            var check = WaitForElementToBeVisible(tasksPageAssignedTo);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", check);
            var Click = WaitForElementToBeVisible(By.XPath(String.Format(tasksFilterSelect, assignedTo)));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", Click);
        }
        public void PerformClickOnTask()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(addTaskButton)).ClickAndHold().Perform();
            this.PressEscapeKey();
        }
        public void ClickOnViewButton()
        {
            this.WaitForElementToBeVisible(viewTaskButton).Click();
            Pause(3);
        }
        public String ValidateViewHeaderName()
        {
            Pause(2);
            return this.WaitForElementToBeVisible(viewTaskHeaderName).Text;
        }
        public void ClickOnAddTaskButton()
        {
            this.WaitForElementToBeVisible(addTaskButton,3).Click();
        }
        public String GetAddTaskHeaderName()
        {
            return this.WaitForElementToBeVisible(addTaskHeader,3).Text;
        }
        public void AddTaskType(string taskType)
        {
            this.WaitForElementToBeVisible(taskTypeInput).SendKeys(taskType);
            IList<IWebElement> taskTypeList = driver.FindElements(By.XPath("//div[@class='Select-menu-outer']"));
            foreach (var task in taskTypeList)
            {
                if ((task.Text) == taskType)
                {
                    task.Click();
                    break;
                }
            }
        }
        public void ClickOnTaskSave()
        {
            this.WaitForElementToBeVisible(taskSaveButton).Click();
            this.Pause(3);
        }
        public void ClickOnTaskSavePlusAddNew()
        {
            this.WaitForElementToBeVisible(taskSavePlusAddNewButton).Click();
        }
        public bool ValidateToastMessage()
        {
            return this.WaitForElementToBeVisible(taskAddToaster,3).Displayed;
        }
        public void ClickOnTaskEdit()
        {
            IList<IWebElement> editPencil =  WaitForElementsToBeVisible(By.XPath("//td[10]/a/i")).ToList();
            int editCount = editPencil.Count();
            editPencil[editCount - 1].Click();
        }
        public void ClickOnIsResolvedCheckbox()
        {
            ScrollDownToPageBottom();
            var check = driver.FindElement(By.XPath("//div[@class='epiq-input-styled-checkbox ']//label"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", check);
        }
        public void ClickOnNotesButton()
        {
            IList<IWebElement> notesButton = WaitForElementsToBeVisible(notesButtons).ToList();
            notesButton[5].Click();
        }
        public void EditNotes()
        {
            SelectAndDeleteCompleteText(this.WaitForElementToBeVisible(notesTextArea));
            this.WaitForElementToBeVisible(notesTextArea).SendKeys(FakeData.Description());
            this.WaitForElementToBeVisible(inlineSubmitButton).Click();
        }
        public void ClickOnDueDateButton()
        {
            this.Pause(3);
            IList<IWebElement> dueDateButton = this.WaitForElementsToBeVisible(dueDatesButton).ToList();
            this.Pause(2);
            dueDateButton[3].Click();
        }
        public void EditDueDate(string dueDate)
        {
            SelectAndDeleteCompleteText(this.WaitForElementToBeVisible(dueDateField));
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']//input")).Click();
            this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group has-feedback has-error']//input")).SendKeys(dueDate);
            this.WaitForElementToBeVisible(inlineSubmitButton).Click();
        }
        public void ClickAssignedToButton()
        {
            this.Pause(2);
            IList<IWebElement> assignedToButton = this.WaitForElementsToBeVisible(assignedToButtons).ToList();
            assignedToButton[3].Click();
        }
        private bool GetElementExists(By loc)
        {
            try
            {
                this.WaitForElementToBeVisible(loc, 5);
                return true; 
            }
            catch
            {
                return false;
            }
        }
        public void EditAssignedTo()
        {
            if (GetElementExists(By.XPath("//span[@class='Select-clear']")))
            {
                this.WaitForElementToBeVisible(By.XPath("//span[@class='Select-clear']")).Click();
                this.WaitForElementToBeVisible(By.XPath("//h3[text()='ASSIGNED TO']")).Click();
                this.WaitForElementToBeVisible(inlineSubmitButton).Click();
            }
            else
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//span[@class='Select-arrow']")).Click();
                IList<IWebElement> assignedToList = this.WaitForElementsToBeVisible(By.XPath("//div[@class='Select-menu-outer']//div//div")).ToList();
                assignedToList[10].Click();
                this.WaitForElementToBeVisible(inlineSubmitButton).Click();
            }
        }
        public void ClickStatusButton()
        {
            this.Pause(2);
            IList<IWebElement> statusButton = this.WaitForElementsToBeVisible(statusButtons).ToList();
            statusButton[3].Click();
        }
        public void EditStatus()
        {
            if (GetElementExists(By.XPath("//span[@class='Select-clear']")))
            {
                this.WaitForElementToBeVisible(By.XPath("//span[@class='Select-clear']")).Click();
                this.WaitForElementToBeVisible(By.XPath("//h3[text()='STATUS']")).Click();
                this.WaitForElementToBeVisible(inlineSubmitButton).Click();
            }
            else
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//span[@class='Select-arrow']")).Click();
                IList<IWebElement> assignedToList = this.WaitForElementsToBeVisible(By.XPath("//div[@class='Select-menu-outer']//div")).ToList();
                assignedToList[1].Click();
                this.WaitForElementToBeVisible(inlineSubmitButton).Click();
            }
        }
        public bool ValidateSaveButton()
        {
            if (GetElementExists(By.XPath("//button[text()='SAVE']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void EditTaskDetails()
        {
            if (GetElementExists(By.XPath("//div[@class='form-group']//div[3]//span[@class='Select-clear']")))
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//div[3]//span[@class='Select-clear']")).Click();
                this.WaitForElementToBeVisible(By.XPath("//label[text()='STATUS']")).Click();
                this.WaitForElementToBeVisible(taskSaveButton).Click();
            }
            else
            {
                this.WaitForElementToBeVisible(By.XPath("//div[@class='form-group']//div[3]//span[@class='Select-arrow']")).Click();
                IList<IWebElement> AssignedToList = this.WaitForElementsToBeVisible(By.XPath("//div[@class='Select-menu-outer']//div")).ToList();
                AssignedToList[1].Click();
                this.WaitForElementToBeVisible(inlineSubmitButton).Click();
            }
        }
        public bool ValidateAddTaskPage()
        {
            return this.WaitForElementToBeVisible(By.XPath("//div[@class='epiq-page-heading clearfix']//h2")).Text.Contains("Add Task");
        }
    }
}
