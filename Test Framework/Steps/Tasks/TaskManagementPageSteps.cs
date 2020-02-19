using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Tasks;
using FluentAssertions;
using System;
using System.Data;
using System.Threading;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Tasks
{
    [Binding]
    public class TaskManagementPageSteps : StepBase
    {
        TasksPage taskPage;
        DataTable randomTasksRecords;

        [When(@"User click on Filter on Tasks page")]
        public void WhenUserClickOnFilterOnTasksPage()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.ClickOnFilter();
        }
        
        [When(@"User click on close on Tasks page")]
        public void WhenUserClickOnCloseOnTasksPage()
        {
            taskPage.ClickOnFilterClose();
        }
        
        [When(@"Enter Task Type '(.*)' in Tasks filter option")]
        public void WhenEnterTaskTypeInTasksFilterOption(string taskType)
        {
            taskPage.EnterCaseNumber(taskType);
        }
        [When(@"Enter Assigned to '(.*)' in Tasks filter option")]
        public void WhenEnterAssignedToInTasksFilterOption(string Assigned)
        {
            taskPage.EnterAssignedTo(Assigned);
        }
        [When(@"User click on Row Expand button on Tasks page")]
        public void WhenUserClickOnRowExpandButtonOnTasksPage()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            //taskPage.clickOnRowExpandButton();
        }
        
        [Then(@"'(.*)' header should be displayed on Tasks Page")]
        public void ThenHeaderShouldBeDisplayedOnTasksPage(string header)
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.GetHeaderName().Should().Contain(header);
        }
        
        [Then(@"Tasks '(.*)' should be displayed")]
        public void ThenTasksShouldBeDisplayed(string filterHeader)
        {
            taskPage.GetFilterOptionHeader().Should().Contain(filterHeader);
        }
        
        [Then(@"Tasks '(.*)' should be closed")]
        public void ThenTasksShouldBeClosed(string filterHeader)
        {
            taskPage.GetFilterOptionHeader().Should().BeNullOrWhiteSpace();
        }
        
        [Then(@"User click on Refresh Button on Task Page")]
        public void ThenUserClickOnRefreshButtonOnTaskPage()
        {
            taskPage.ClickOnReferesh();
        }
        [Then(@"'(.*)' Should be able to sort on Tasks page")]
        public void ThenShouldBeAbleToSortOnTasksPage(string headerName)
        {
            var list = taskPage.GetSortedList(headerName);
            list.Should().BeInAscendingOrder();
            list = taskPage.GetSortedList(headerName);
            list.Should().BeInDescendingOrder();
        }      
        [Then(@"Tasks records should be displayed")]
        public void ThenTasksRecordsShouldBeDisplayed()
        {
            taskPage.GetTaskRecords().Should().NotBeNull();
        }
        
        [Then(@"User click on the reset button on Tasks filter option")]
        public void ThenUserClickOnTheResetButtonOnTasksFilterOption()
        {
            taskPage.ClickOnResetButton();
        }
        [Then(@"user click on close button on Tasks filter option")]
        public void ThenUserClickOnCloseButtonOnTasksFilterOption()
        {
            taskPage.ClickOnCloseButton();
        }
        [Then(@"User should be able to see column CASE \#")]
        public void ThenUserShouldBeAbleToSeeColumnCASE()
        {
            taskPage.GetCaseNumberDisplayed().Should().BeTrue();
        }
        [Then(@"Table data should be present on task page")]
        public void ThenTableDataShouldBePresentOnTaskPage()
        {
            randomTasksRecords = taskPage.GetTaskRecords();
            randomTasksRecords.Should().NotBeNull();
        }
        [Then(@"Input '(.*)' also I select debtorname '(.*)'")]
        public void ThenInputAlsoISelectDebtorname(string debtor, string casenum)
        {
            taskPage.EnterDebtor(debtor, casenum);
        }
        [Given(@"I enter on the office tasks")]
        public void GivenIEnterOnTheOfficeTasks()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.ClickOnOfficeTask();
        }
        [When(@"I select TYPE '(.*)'")]
        public void WhenISelectTYPE(string type)
        {
            taskPage.SelectType(type);
        }
        [When(@"I select ASSIGNED TO '(.*)'")]
        public void WhenISelectASSIGNEDTO(string assignedTo)
        {
            taskPage.SelectAssignedTo(assignedTo);
        }
        [Then(@"Selected result should contains '(.*)' '(.*)' '(.*)'")]
        public void ThenSelectedResultShouldContains(string debtor, string type, string assignedTo)
        {
            System.Threading.Thread.Sleep(1500);

            if (!string.IsNullOrWhiteSpace(debtor))
                taskPage.GetRecordsByColumnName("DEBTOR", debtor);

            if (!string.IsNullOrWhiteSpace(type))
                taskPage.GetRecordsByColumnName("TYPE", type);

            if (!string.IsNullOrWhiteSpace(assignedTo))
                taskPage.GetRecordsByColumnName("ASSIGNED", assignedTo);
        }
        [When(@"User displays the page count on task page")]
        public void WhenUserDisplaysThePageCountOnTaskPage()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.GetPageCount().Should().NotBeNullOrEmpty();
            TestsLogger.Log(string.Format("Tasks count is [{0}]", taskPage.GetPageCount()));
        }
        [Then(@"the selected page records should be displayed")]
        public void ThenTheSelectedPageRecordsShouldBeDisplayed()
        {
            object value = null;
            var pageInfo = taskPage.GetPagination();
            pageInfo.TryGetValue("Pagination", out value);
            ((bool)value).Should().BeTrue();
            pageInfo.TryGetValue("ActivePage", out value);
            (value).Should().NotBeNull();
        }
        [When(@"I do the mosusehover on debtor column")]
        public void WhenIDoTheMosusehoverOnDebtorColumn()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            Thread.Sleep(1000);
            taskPage.MouseHouver();
        }
        [When(@"user clicks on the debtor name in task management page")]
        public void WhenUserClicksOnTheDebtorNameInTaskManagementPage()
        {
            taskPage.CaseSpecificClick();
        }
        [Then(@"user gets navigate to the case view details")]
        public void ThenUserGetsNavigateToTheCaseViewDetails()
        {
            driver.Navigate().GoToUrl("http://unity-tnetqa.epiqsystems.com/dashboard");
        }
        [When(@"user clicks on the Case Number in task management page")]
        public void WhenUserClicksOnTheCaseNumberInTaskManagementPage()
        {
            taskPage.clickOnCaseNUM();
        }
        [When(@"I click on row Expand button on Tasks page")]
        public void WhenIClickOnRowExpandButtonOnTasksPage()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.ClickOnRowExpandButton();
        }

        [Then(@"Validate that Due date is in blue color for over due task")]
        public void ThenValidateThatDueDateIsInBlueColorForOverDueTask()
        {
            taskPage.ValidateTheColor();
        }
        [Then(@"Validate that Border is in red color for over due task")]
        public void ThenValidateThatBorderIsInRedColorForOverDueTask()
        {
            taskPage.ValidateTheBorderColor();
        }
        [When(@"I try to click on the add task")]
        public void WhenITryToClickOnTheAddTask()
        {
             taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
             taskPage.PerformClickOnTask();
        }
        [Then(@"I click on the view button on the result grid")]
        public void ThenIClickOnTheViewButtonOnTheResultGrid()
        {
            taskPage.ClickOnViewButton();
        }
        [Then(@"Header should be displayed as '(.*)'")]
        public void ThenHeaderShouldBeDisplayedAs(string header)
        {
            taskPage.ValidateViewHeaderName().Should().Contain(header);
        }
        [Then(@"Debtor and Case columns should display")]
        public void ThenDebtorAndCaseColumnsShouldDisplay()
        {
            taskPage.GetColumnsName().Should().Contain("DEBTOR", "CASE #");
        }
        [Given(@"I click Add Task Button")]
        [Then(@"I click Add Task Button")]
        public void ThenIClickAddTaskButton()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.ClickOnAddTaskButton();
        }
        [Then(@"Header should be displayed as - Add Task")]
        public void ThenHeaderShouldBeDisplayedAs_AddTask()
        {
            taskPage.GetAddTaskHeaderName().Should().Contain("Add Task");
        }
        [Then(@"I select '(.*)' from Task Type")]
        public void ThenISelectFromTaskType(string TaskType)
        {
            taskPage.AddTaskType(TaskType);
        }
        [Then(@"I click on Save button on Add Task")]
        public void ThenIClickOnSaveButtonOnAddTask()
        {
            taskPage.ClickOnTaskSave();
        }
        [Then(@"I click on SavePlusAddNew button on Add Task")]
        public void ThenIClickOnSavePlusAddNewButtonOnAddTask()
        {
            taskPage.ClickOnTaskSavePlusAddNew();
        }
        [Then(@"Task Record should be edited and saved")]
        [Then(@"Task Record should be added and saved")]
        public void ThenTaskRecordShouldBeAddedAndSaved()
        {
            taskPage.ValidateToastMessage().Should().BeTrue();
        }
        [When(@"I Click On Edit of Task")]
        public void WhenIClickOnEditOfTask()
        {
            taskPage.ClickOnTaskEdit();
        }
        [Then(@"I click on Is Resolved Checkbox on Task Page")]
        public void ThenIClickOnIsResolvedCheckboxOnTaskPage()
        {
            taskPage.ClickOnIsResolvedCheckbox();
        }
        [When(@"I Click on Notes Button on Task")]
        public void WhenIClickOnNotesButtonOnTask()
        {
            taskPage = ((TasksPage)GetSharedPageObjectFromContext("Tasks"));
            taskPage.ClickOnNotesButton();
        }
        [Then(@"I should be able to edit Notes on Task")]
        public void ThenIShouldBeAbleToEditNotesOnTask()
        {
            taskPage.EditNotes();
        }
        [When(@"I Click on Due Date Button on Task")]
        public void WhenIClickOnDueDateButtonOnTask()
        {
            taskPage.ClickOnDueDateButton();
        }
        [Then(@"I should be able to edit Due Date as '(.*)' on Task")]
        public void ThenIShouldBeAbleToEditDueDateAsOnTask(string dueDate)
        {
            taskPage.EditDueDate(dueDate);
        }
        [When(@"I Click on Assigned To Button on Task")]
        public void WhenIClickOnAssignedToButtonOnTask()
        {
            taskPage.ClickAssignedToButton();
        }
        [Then(@"I should be able to edit Assigned To on Task")]
        public void ThenIShouldBeAbleToEditAssignedToOnTask()
        {
            taskPage.EditAssignedTo();
        }
        [When(@"I Click on Status Button on Task")]
        public void WhenIClickOnStatusButtonOnTask()
        {
            taskPage.ClickStatusButton();
        }
        [Then(@"I should be able to edit Status on Task")]
        public void ThenIShouldBeAbleToEditStatusOnTask()
        {
            taskPage.EditStatus();
        }
        [Then(@"I see all are read only fields on Task View page")]
        public void ThenISeeAllAreReadOnlyFieldsOnTaskViewPage()
        {
            taskPage.ValidateSaveButton().Should().BeFalse();
        }
        [Then(@"I should be able to edit the task")]
        public void ThenIShouldBeAbleToEditTheTask()
        {
            taskPage.EditTaskDetails();
        }
        [Then(@"I see the Add Task Page for adding new task")]
        public void ThenISeeTheAddTaskPageForAddingNewTask()
        {
            taskPage.ValidateAddTaskPage().Should().BeTrue();
        }
    }
}
