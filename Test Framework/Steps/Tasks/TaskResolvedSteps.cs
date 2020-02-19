using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Tasks
{
    [Binding]
    public class TaskResolvedSteps : StepBase
    {
        TaskResolvedPage TaskResolved = new TaskResolvedPage(driver);
        [Given(@"I Click on Add Task button")]
        public void GivenIClickOnAddTaskButton()
        {
            TaskResolved.ClickAddTask();
        }
        [When(@"a Model appears with title as '(.*)'")]
        [Given(@"a Model appears with title as '(.*)'")]
        public void GivenAModelAppearsWithTitleAs(string expectedTitle)
        {
            TaskResolved.VerifyTitleHeader(expectedTitle);
        }
        [When(@"I Click Edit of row with Debtor '(.*)'")]
        [Given(@"I Click Edit of row with Debtor '(.*)'")]
        public void GivenIClickEditOfRowWithDebtor(string debtor)
        {
            TaskResolved.ClickEditWithDebtorName(debtor);
        }
        [Given(@"I Enter Debtor as '(.*)'")]
        public void GivenIEnterDebtorAs(string debtorname)
        {
            TaskResolved.EnterDebtorName(debtorname);
        }
        [Given(@"I select TASK TYPE '(.*)'")]
        [When(@"I select Task Type '(.*)'")]
        public void WhenISelectTaskType(string taskType)
        {
            TaskResolved.SelectTaskType(taskType);
        }
        [When(@"I select Status as '(.*)'")]
        public void WhenISelectStatusAs(string status)
        {
            TaskResolved.SelectStatus(status);
        }
        [When(@"I select Assign as '(.*)'")]
        public void WhenISelectAssignAs(string assign)
        {
            TaskResolved.SelectAssign(assign);
        }
        [When(@"I enter text in the Notes field '(.*)'")]
        public void WhenIEnterTextInTheNotesField(string notes)
        {
            TaskResolved.EnterNotes(notes);
        }
        [Then(@"I click on Save button")]
        public void ThenIClickOnSaveButton()
        {
            TaskResolved.ClickSave();
            Thread.Sleep(3000);
        }
        [When(@"I Select IS RESOLVED as '(.*)'")]
        public void WhenISelectISRESOLVEDAs(string resolvedStatus)
        {
            TaskResolved.ResolvedType(resolvedStatus);
        }
        [When(@"I select IS RESOLVED")]
        [Given(@"I select IS RESOLVED")]
        public void GivenISelectISRESOLVED()
        {
            TaskResolved.SelectIsResolved();
        }
        [When(@"I see the Debtor '(.*)' status as Resolved")]
        public void WhenISeeTheDebtorStatusAsResolved(string debtor)
        {
            TaskResolved.DebtorResolvedStatus(debtor);
        }
        [Given(@"I Click on Close Button")]
        public void GivenIClickOnCloseButton()
        {
            TaskResolved.ClickOnClose();
        }
        [Given(@"I select ASSIGNED TO '(.*)'")]
        public void GivenISelectASSIGNEDTO(string assign)
        {
            TaskResolved.SelectAssignTo(assign);
        }
    }
}
