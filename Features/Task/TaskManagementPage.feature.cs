﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Task
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("TaskManagementPage")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    [NUnit.Framework.CategoryAttribute("FailureCases")]
    public partial class TaskManagementPageFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TaskManagementPage.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TaskManagementPage", "Navigating to the different sections \r\nunder Task page", ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
                        "ReactJS",
                        "FailureCases"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("001 - Cases- Tasks page and Filters verification")]
        [NUnit.Framework.CategoryAttribute("CasesTab")]
        public virtual void _001_Cases_TasksPageAndFiltersVerification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Cases- Tasks page and Filters verification", new string[] {
                        "CasesTab"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Then("\'Task Management\' header should be displayed on Tasks Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.When("User click on Filter on Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("Tasks \'FILTER OPTIONS\' should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.When("User click on close on Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("Tasks \'FILTER OPTIONS\' should be closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.When("User click on Filter on Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
    testRunner.And("Enter Task Type \'341 Meeting Prep\' in Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
    testRunner.Then("Tasks records should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
    testRunner.And("User click on the reset button on Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
    testRunner.And("user click on close button on Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Cases- Tasks Page Pagination and all filter options")]
        public virtual void _002_Cases_TasksPagePaginationAndAllFilterOptions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Cases- Tasks Page Pagination and all filter options", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
    testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.When("User click on Filter on Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("Table data should be present on task page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
    testRunner.When("Enter Task Type \'DSO Discharge Notice\' in Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("user click on close button on Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.When("User displays the page count on task page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("the selected page records should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
    testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003_cases-Casespecific Navigation on the debtor and Case Number columns")]
        public virtual void _003_Cases_CasespecificNavigationOnTheDebtorAndCaseNumberColumns()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003_cases-Casespecific Navigation on the debtor and Case Number columns", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
 testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
 testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When("I do the mosusehover on debtor column", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.And("user clicks on the debtor name in task management page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.Then("user gets navigate to the case view details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004_Cases-Validate Due Date Color-over due task")]
        public virtual void _004_Cases_ValidateDueDateColor_OverDueTask()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004_Cases-Validate Due Date Color-over due task", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 49
 testRunner.When("I do the mosusehover on debtor column", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.Then("Validate that Due date is in blue color for over due task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.Then("Validate that Border is in red color for over due task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005_Validate the add task is disable and has view button")]
        [NUnit.Framework.CategoryAttribute("US235861")]
        [NUnit.Framework.CategoryAttribute("US235865")]
        public virtual void _005_ValidateTheAddTaskIsDisableAndHasViewButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005_Validate the add task is disable and has view button", new string[] {
                        "US235861",
                        "US235865"});
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
 testRunner.Given("I enter to Tasks page as user AutomationView with password Welcome456Epiq! and of" +
                    "fice crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
 testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
 testRunner.When("I try to click on the add task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
 testRunner.Then("I click on the view button on the result grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.And("I see all are read only fields on Task View page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006_Validate Tasks Create- Save at Case Level")]
        [NUnit.Framework.CategoryAttribute("US235863")]
        public virtual void _006_ValidateTasksCreate_SaveAtCaseLevel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006_Validate Tasks Create- Save at Case Level", new string[] {
                        "US235863"});
#line 64
this.ScenarioSetup(scenarioInfo);
#line 65
 testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
 testRunner.Given("I Go to Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.And("I click Add Task Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("Header should be displayed as - Add Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
    testRunner.Then("Input \'17-19895\' also I select debtorname \'17-19895 / QA-Testing-6,\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.Then("I select \'Document Request\' from Task Type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.And("I click on Save button on Add Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("Task Record should be added and saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
    testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007_Validate Tasks Edit at Case Level")]
        [NUnit.Framework.CategoryAttribute("US235864")]
        public virtual void _007_ValidateTasksEditAtCaseLevel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007_Validate Tasks Edit at Case Level", new string[] {
                        "US235864"});
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
 testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
 testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
    testRunner.When("I Click On Edit of Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("I click on Is Resolved Checkbox on Task Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.And("I click on Save button on Add Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("Task Record should be edited and saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
    testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008_Validate Tasks Filters at Case Level")]
        [NUnit.Framework.CategoryAttribute("US235862")]
        public virtual void _008_ValidateTasksFiltersAtCaseLevel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008_Validate Tasks Filters at Case Level", new string[] {
                        "US235862"});
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
 testRunner.Given("I enter to Tasks page as user AutomationView with password Welcome456Epiq! and of" +
                    "fice crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
 testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.When("User click on Filter on Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
    testRunner.And("Enter Task Type \'341 Meeting Prep\' in Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.Then("user click on close button on Tasks filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
    testRunner.Then("Tasks records should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009_Validate Tasks In Line Editing")]
        [NUnit.Framework.CategoryAttribute("US235854")]
        public virtual void _009_ValidateTasksInLineEditing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009_Validate Tasks In Line Editing", new string[] {
                        "US235854"});
#line 96
this.ScenarioSetup(scenarioInfo);
#line 97
    testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 98
  testRunner.Given("I enter on the office tasks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 99
  testRunner.When("I Click on Notes Button on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
     testRunner.Then("I should be able to edit Notes on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
  testRunner.When("I Click on Due Date Button on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
     testRunner.Then("I should be able to edit Due Date as \'02/10/18\' on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
  testRunner.When("I Click on Due Date Button on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
     testRunner.Then("I should be able to edit Due Date as \'12/09/10\' on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
  testRunner.When("I Click on Assigned To Button on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
        testRunner.Then("I should be able to edit Assigned To on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
  testRunner.When("I Click on Status Button on Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
     testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("010_Validate Tasks - Create - Save Plus New")]
        [NUnit.Framework.CategoryAttribute("US231111")]
        public virtual void _010_ValidateTasks_Create_SavePlusNew()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("010_Validate Tasks - Create - Save Plus New", new string[] {
                        "US231111"});
#line 111
this.ScenarioSetup(scenarioInfo);
#line 112
 testRunner.Given("I enter to Tasks page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
 testRunner.And("I click Add Task Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
  testRunner.And("I Enter Debtor as \'15-10024\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
      testRunner.Then("I select \'Document Request\' from Task Type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
      testRunner.And("I click on SavePlusAddNew button on Add Task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
      testRunner.And("Task Record should be added and saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
   testRunner.And("I see the Add Task Page for adding new task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
      testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion