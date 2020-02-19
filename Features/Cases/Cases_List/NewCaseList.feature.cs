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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Cases.Cases_List
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("NewCaseList")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    [NUnit.Framework.CategoryAttribute("FailureCases")]
    [NUnit.Framework.CategoryAttribute("CaseListPage")]
    public partial class NewCaseListFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NewCaseList.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NewCaseList", "", ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
                        "ReactJS",
                        "FailureCases",
                        "CaseListPage"});
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
        [NUnit.Framework.DescriptionAttribute("001_Case List - Verify CaseList page Layout")]
        [NUnit.Framework.CategoryAttribute("CaseSearch")]
        public virtual void _001_CaseList_VerifyCaseListPageLayout()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001_Case List - Verify CaseList page Layout", new string[] {
                        "CaseSearch"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I see Table header contains \'DEBTOR;PETITION DATE;DEBTOR ATTORNEY;ASSET STATUS;CA" +
                    "SE STATUS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I click on Dashboard Link under Case Management", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("I see the Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002_Case List - Verify CaseList Reset Filters functionality")]
        public virtual void _002_CaseList_VerifyCaseListResetFiltersFunctionality()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002_Case List - Verify CaseList Reset Filters functionality", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.When("I click on 341 Meeting Date Sorting Controls", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.And("I see the 341 Meeting Date column details in Ascending Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("I Click Reset Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Then("I see the 341 Meeting Date column details reverted to default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003_Case List - Verify different Sorting Sections of CaseList Table")]
        public virtual void _003_CaseList_VerifyDifferentSortingSectionsOfCaseListTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003_Case List - Verify different Sorting Sections of CaseList Table", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.When("I click on 341 Meeting Date Sorting Controls", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.And("I see the 341 Meeting Date column details in Ascending Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I click on Debtor Sorting Controls", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("I see the Debtor column details in Ascending Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.Then("I see the 341 Meeting Date column details reverted to default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("I click on Petition Date Sorting Controls", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I see the Petition Date column details in Ascending Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I see the Debtor column details reverted to default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004_Case List - Verify Double Click Sorting Sections of CaseList Table")]
        public virtual void _004_CaseList_VerifyDoubleClickSortingSectionsOfCaseListTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004_Case List - Verify Double Click Sorting Sections of CaseList Table", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.When("I click on 341 Meeting Date Sorting Controls", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.And("I see the 341 Meeting Date column details in Ascending Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("I Click again on 341 Meeting Date Sorting Controls", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.Then("I see the 341 Meeting Date column details in Descending Order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005_Case List - Verify Pagination in CaseList Page")]
        public virtual void _005_CaseList_VerifyPaginationInCaseListPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005_Case List - Verify Pagination in CaseList Page", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.And("I select page \'4\' under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.Then("I see the CaseList details for the Selected Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006_Case List - Verify PageSize under Pagination in CaseList Page")]
        [NUnit.Framework.TestCaseAttribute("10", null)]
        [NUnit.Framework.TestCaseAttribute("25", null)]
        [NUnit.Framework.TestCaseAttribute("50", null)]
        [NUnit.Framework.TestCaseAttribute("100", null)]
        public virtual void _006_CaseList_VerifyPageSizeUnderPaginationInCaseListPage(string pageSize, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006_Case List - Verify PageSize under Pagination in CaseList Page", exampleTags);
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.When(string.Format("I Select the PageSize as {0} under Pagination Section", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.And(string.Format("I see the CaseList Table Contains the Same Number of Rows as per Selected {0}", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007_Case List - Verify Expand And Collapse Button in Case Table")]
        public virtual void _007_CaseList_VerifyExpandAndCollapseButtonInCaseTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007_Case List - Verify Expand And Collapse Button in Case Table", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 63
 testRunner.When("I click on Expand button I see few more fields under Case Table", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.And("I click on Collapse button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008_Case List - Verify All Sorting Controls in Case Table")]
        public virtual void _008_CaseList_VerifyAllSortingControlsInCaseTable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008_Case List - Verify All Sorting Controls in Case Table", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
 testRunner.And("I click on Sorting Controls of All fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009_Case List - CaseListCount and Favorite Case InLineEdit")]
        [NUnit.Framework.CategoryAttribute("US235858")]
        public virtual void _009_CaseList_CaseListCountAndFavoriteCaseInLineEdit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009_Case List - CaseListCount and Favorite Case InLineEdit", new string[] {
                        "US235858"});
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
 testRunner.And("I see the CasesCount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("I click on filter search Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("I enter Dates \'341 MEETING DATE (FROM)\' as \'06/04/17\' and \'341 MEETING DATE (TO)\'" +
                    " as \'06/04/17\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
 testRunner.When("I select the case \'QA Subbu 30\' as Favorite", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("the Case \'QA Subbu 30\' marked as Favorite with Yellow Star", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.And("I Go to Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.Then("I verify the Case \'QA Subbu 30\' in Favorites tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
 testRunner.And("I Go to Case List page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("I click on filter search Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.And("I enter Dates \'341 MEETING DATE (FROM)\' as \'06/04/17\' and \'341 MEETING DATE (TO)\'" +
                    " as \'06/04/17\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
 testRunner.And("I deselect the Favorite case \'QA Subbu 30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.Then("I see the Case \'QA Subbu 30\' is no more Favorite Case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
 testRunner.And("I Go to Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.Then("I verify the Case \'QA Subbu 30\' in Favorites tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("010_Case List - CaseList Favorite case as View")]
        [NUnit.Framework.CategoryAttribute("US235858")]
        public virtual void _010_CaseList_CaseListFavoriteCaseAsView()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("010_Case List - CaseList Favorite case as View", new string[] {
                        "US235858"});
#line 94
this.ScenarioSetup(scenarioInfo);
#line 95
 testRunner.Given("I enter to Case List page as user AutomationView with password Welcome456Epiq! an" +
                    "d office crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
 testRunner.And("I click on filter search Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.When("I enter Dates \'341 MEETING DATE (FROM)\' as \'06/04/17\' and \'341 MEETING DATE (TO)\'" +
                    " as \'06/04/17\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.Then("I see the Cases with CaseName same as \'QA Subbu 30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
 testRunner.And("the Marking Case as Favorite should be view only", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("011_Case List - Add the new Case- Save Button")]
        [NUnit.Framework.CategoryAttribute("US279717")]
        public virtual void _011_CaseList_AddTheNewCase_SaveButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("011_Case List - Add the new Case- Save Button", new string[] {
                        "US279717"});
#line 104
this.ScenarioSetup(scenarioInfo);
#line 105
testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
testRunner.And("I see the CasesCount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.And("I create the new Case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.Then("I click \'SAVE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
testRunner.When("I click on filter search Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
testRunner.Then("I input peition Date in the Fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
  testRunner.And("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.Then("the Records should contain \'CASE STATUS-Open\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("012_Case List - Add the new case - Save_New Button")]
        [NUnit.Framework.CategoryAttribute("US279717")]
        public virtual void _012_CaseList_AddTheNewCase_Save_NewButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("012_Case List - Add the new case - Save_New Button", new string[] {
                        "US279717"});
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
testRunner.And("I see the CasesCount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
testRunner.And("I create the new Case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.Then("I click \'SAVE + ADD NEW\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
testRunner.Then("\'Case ListAdd Case\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("013_Case List - Add the new case - Cancel Button")]
        [NUnit.Framework.CategoryAttribute("US279717")]
        public virtual void _013_CaseList_AddTheNewCase_CancelButton()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("013_Case List - Add the new case - Cancel Button", new string[] {
                        "US279717"});
#line 125
this.ScenarioSetup(scenarioInfo);
#line 126
 testRunner.Given("I enter to Case List page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 127
 testRunner.And("I see the CasesCount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("I create the new Case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.Then("I click \'CANCEL\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("\'DashboardCase List\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion