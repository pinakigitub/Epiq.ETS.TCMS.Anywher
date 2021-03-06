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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Imports
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ImportsDocuments")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class ImportsDocumentsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ImportDocuments.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ImportsDocuments", "", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("001_ImportDocuments- Validate Breadcrumb, Filters, Header")]
        [NUnit.Framework.CategoryAttribute("US264016")]
        [NUnit.Framework.CategoryAttribute("US264017")]
        [NUnit.Framework.CategoryAttribute("US264018")]
        public virtual void _001_ImportDocuments_ValidateBreadcrumbFiltersHeader()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001_ImportDocuments- Validate Breadcrumb, Filters, Header", new string[] {
                        "US264016",
                        "US264017",
                        "US264018"});
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I enter to Imports Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Then("I see Import Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.Then("\'DashboardImport Documents\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
 testRunner.Then("I see subheader as \'Documents to Import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.When("Click on filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("Filter with \'IMPORTED\' as \'Waiting to import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.Then("Filter with \'CASE STATUS\' as \'All\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.When("I \'CLOSE\' Filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.When("I Click on one Document link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.When("I Click on one DocumentsToImport Tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("I see Import and Ignore button Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.Then("I click on checkbox on tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.Then("I see Import and Ignore button Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("Inline edit the Description as \'Testing automation inline edit for Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002_ImportDocuments- Filtering of 2 Tiles")]
        [NUnit.Framework.CategoryAttribute("US270475")]
        public virtual void _002_ImportDocuments_FilteringOf2Tiles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002_ImportDocuments- Filtering of 2 Tiles", new string[] {
                        "US270475"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
 testRunner.Given("I enter to Imports Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
 testRunner.Then("I see Import Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.Then("\'DashboardImport Documents\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.Then("I see subheader as \'Documents to Import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
 testRunner.When("Click on filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("Filter with \'IMPORTED\' as \'Waiting to import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
 testRunner.Then("Filter with \'CASE STATUS\' as \'All\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.When("I \'CLOSE\' Filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.When("I Click on one Document link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.When("Click on filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("Filter with \'IMPORT STATUS\' as \'Waiting to import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003_ImportDocuments- Validate Gear Button is Displayed")]
        [NUnit.Framework.CategoryAttribute("US293964")]
        public virtual void _003_ImportDocuments_ValidateGearButtonIsDisplayed()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003_ImportDocuments- Validate Gear Button is Displayed", new string[] {
                        "US293964"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("I enter to Imports Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.Then("I see Import Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.Then("\'DashboardImport Documents\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
 testRunner.Then("I see subheader as \'Documents to Import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.Then("I see GearButton is Displayed beside to Documents to Import Header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.When("I Click on GearButton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("\'Settings Management\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.Then("\'Import DocumentsOffice Settings Management\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
