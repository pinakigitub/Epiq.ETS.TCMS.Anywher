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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Distributions
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Distribution ManagementPage")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class DistributionManagementPageFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DistributionPage.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Distribution ManagementPage", "Navigating to the different sections \r\nof the Distribution Management page", ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
                        "ReactJS"});
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
        [NUnit.Framework.DescriptionAttribute("001 - Cases- Distributions page verification")]
        [NUnit.Framework.CategoryAttribute("CasesTab")]
        public virtual void _001_Cases_DistributionsPageVerification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Cases- Distributions page verification", new string[] {
                        "CasesTab"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.Then("\'Distribution Management\' header should be displayed on Distribution Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.When("User click on Filter on Distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("Distribution \'FILTER OPTIONS\' should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.When("User click on close on Distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("Distribution \'FILTER OPTIONS\' should be closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Cases- Distributions Breadcrumb and sorting verification")]
        public virtual void _002_Cases_DistributionsBreadcrumbAndSortingVerification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Cases- Distributions Breadcrumb and sorting verification", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
   testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
    testRunner.Then("\'DashboardDistribution List\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
   testRunner.And("History has mouseover", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
   testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004 - Cases- Distribution Page Pagination and all filter options")]
        public virtual void _004_Cases_DistributionPagePaginationAndAllFilterOptions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004 - Cases- Distribution Page Pagination and all filter options", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
  testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
     testRunner.When("User click on Filter on Distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
  testRunner.Then("Table data should be present on distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
  testRunner.When("I select DistributionStatus \'Posted\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
  testRunner.Then("user click on close button on Distribution filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
  testRunner.And("Selected result should contains \'Posted\' on distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
  testRunner.When("User displays the page count on distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005 - Cases- Distribution In Line Editing")]
        [NUnit.Framework.CategoryAttribute("US220363")]
        public virtual void _005_Cases_DistributionInLineEditing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005 - Cases- Distribution In Line Editing", new string[] {
                        "US220363"});
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
  testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
  testRunner.When("I click on one Distribution in line edit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
  testRunner.Then("I should be able to edit the distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006 - Cases- Distribution - Validation for View only")]
        [NUnit.Framework.CategoryAttribute("US220363")]
        public virtual void _006_Cases_Distribution_ValidationForViewOnly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006 - Cases- Distribution - Validation for View only", new string[] {
                        "US220363"});
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
  testRunner.Given("I enter to Distributions page as user AutomationView with password Welcome456Epiq" +
                    "! and office crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 61
  testRunner.Then("I should not be able to edit the distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007- Distribution - View Permission- with different status")]
        [NUnit.Framework.CategoryAttribute("US293954")]
        [NUnit.Framework.TestCaseAttribute("Posted", null)]
        [NUnit.Framework.TestCaseAttribute("Proposed", null)]
        public virtual void _007_Distribution_ViewPermission_WithDifferentStatus(string statused, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "US293954"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007- Distribution - View Permission- with different status", @__tags);
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
  testRunner.Given("I enter to Distributions page as user AutomationView with password Welcome456Epiq" +
                    "! and office crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
  testRunner.When("User click on Filter on Distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
  testRunner.When(string.Format("I select DistributionStatus \'{0}\'", statused), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
  testRunner.Then("user click on close button on Distribution filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
  testRunner.And(string.Format("Selected result should contains \'{0}\' on distribution page", statused), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
  testRunner.Then("Click on the View Icon for one of case from distribution lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
  testRunner.Then("\'DistributionsView Distribution\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
  testRunner.And("user clicks on close button on view pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008-Verify History Icon on Distribution Summary page")]
        [NUnit.Framework.CategoryAttribute("US293921")]
        public virtual void _008_VerifyHistoryIconOnDistributionSummaryPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008-Verify History Icon on Distribution Summary page", new string[] {
                        "US293921"});
#line 81
this.ScenarioSetup(scenarioInfo);
#line 82
 testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
 testRunner.Then("Click on the View Icon for one of case from distribution lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.And("I click and view the History Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009 - Cases- Distributions- Proposed Distribution Report")]
        [NUnit.Framework.CategoryAttribute("US#293920")]
        public virtual void _009_Cases_Distributions_ProposedDistributionReport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009 - Cases- Distributions- Proposed Distribution Report", new string[] {
                        "US#293920"});
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
   testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
   testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
   testRunner.When("I Enter \'01-21039\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
   testRunner.And("I Click on the Case Result \'01-21039\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
   testRunner.And("I select the record for the selected", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
   testRunner.And("I select the report from final distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
   testRunner.Then("\'Proposed Distribution Report\' should display in the popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("010-Add Distribution and Generate Distribution")]
        [NUnit.Framework.CategoryAttribute("US293959US293955")]
        public virtual void _010_AddDistributionAndGenerateDistribution()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("010-Add Distribution and Generate Distribution", new string[] {
                        "US293959US293955"});
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
  testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
   testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
   testRunner.When("I Enter \'01-21039\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
  testRunner.And("I Click on the Case Result \'01-21039\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.And("I click On The Add Distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
  testRunner.Then("\'DistributionsAdd Distribution\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
  testRunner.When("Enter the distribution name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
  testRunner.And("I click on Generate Distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("011-Edit Distibution-Remit to Court and Modify interest")]
        [NUnit.Framework.CategoryAttribute("US293960US293961")]
        public virtual void _011_EditDistibution_RemitToCourtAndModifyInterest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("011-Edit Distibution-Remit to Court and Modify interest", new string[] {
                        "US293960US293961"});
#line 111
this.ScenarioSetup(scenarioInfo);
#line 112
testRunner.Given("I enter to Distributions page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 113
   testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
   testRunner.When("I Enter \'01-21039\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
  testRunner.And("I Click on the Case Result \'01-21039\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
  testRunner.And("I click On The Add Distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
  testRunner.Then("\'DistributionsAdd Distribution\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
  testRunner.When("Enter the distribution name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
  testRunner.Then("I click Remit to Court Accordion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
  testRunner.And("I click on check box for remit to court and enter the amount", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
   testRunner.When("I click on Generate Distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
  testRunner.Then("\'DistributionsEdit Distribution\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
  testRunner.And("user clicks on close button on view pages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
  testRunner.When("User click on Filter on Distribution page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
  testRunner.Then("I select the current distribution date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
  testRunner.Then("user click on close button on Distribution filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
  testRunner.Then("Click on the View Icon for one of case from distribution lists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
  testRunner.Then("\'DistributionsEdit Distribution\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
  testRunner.Then("Click on Modify Amount button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("Verify the pop header as \'Estate Balance = Distribution\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
 testRunner.Then("I click on Cancel button in pop up distribution", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion