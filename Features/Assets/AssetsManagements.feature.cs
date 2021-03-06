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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Assets
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AssetManagement")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class AssetManagementFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AssetsManagements.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AssetManagement", "Navigating to the different sections under AssetManagement Mangement Page", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("001 - AssetManagement Page verification")]
        public virtual void _001_AssetManagementPageVerification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - AssetManagement Page verification", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
  testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
  testRunner.Then("\'DashboardAssets\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
  testRunner.And("Page Count shoud be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
  testRunner.And("Table data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Add Asset")]
        public virtual void _002_AddAsset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Add Asset", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
  testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.When("I Click on Add Asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
  testRunner.Then("Add Asset page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.When("I enter \'CASE # / DEBTOR NAME-17-19907;DESCRIPTION-AutomationTest;PETITION VALUE " +
                    "STATUS-Scheduled;TRUSTEE VALUE STATUS-Known;ABANDONED-No\' fileds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And("I click on save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("I enter description \'AutomationTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
  testRunner.Then("Records should contain \'DESCRIPTION-AutomationTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004 - Assets verify Pagination")]
        public virtual void _004_AssetsVerifyPagination()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004 - Assets verify Pagination", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
  testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
  testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
  testRunner.And("Page Count shoud be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
  testRunner.And("navigation and pagination should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005 - Assets filters funnel Search and Clear")]
        public virtual void _005_AssetsFiltersFunnelSearchAndClear()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005 - Assets filters funnel Search and Clear", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
  testRunner.Then("Table data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.When("I enter description \'Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And("I select fully administered \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I select fully abandoned \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I select fully reserved \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I select fully case status \'Open\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.Then("Records should contain \'DESCRIPTION-Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
  testRunner.And("Fully abandoned should contains \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
  testRunner.And("Fully reserved should contains \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("Click on reset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
  testRunner.Then("default data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006 - Assets clear the filters from the funnel")]
        public virtual void _006_AssetsClearTheFiltersFromTheFunnel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006 - Assets clear the filters from the funnel", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
  testRunner.Then("Table data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.When("I enter description \'Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
  testRunner.Then("Records should contain \'DESCRIPTION-Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
 testRunner.When("I clear the description", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
  testRunner.Then("default data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.When("I select fully administered \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
  testRunner.Then("fully administered should contains \'dd/mm/yy\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.When("I click on fully administered x", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
  testRunner.Then("default data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
 testRunner.When("I select fully abandoned \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
  testRunner.Then("Fully abandoned should contains \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
 testRunner.When("I click on fully abandoned x", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
  testRunner.Then("default data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
 testRunner.When("I select fully reserved \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
  testRunner.Then("Fully reserved should contains \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
 testRunner.When("I click on fully reserved x", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
  testRunner.Then("default data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
 testRunner.When("I select fully case status \'Closed\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
  testRunner.Then("Case status should be \'Closed\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
  testRunner.And("default data should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007_ Assets - Verify PageSize under Pagination")]
        [NUnit.Framework.TestCaseAttribute("10", null)]
        [NUnit.Framework.TestCaseAttribute("25", null)]
        [NUnit.Framework.TestCaseAttribute("50", null)]
        [NUnit.Framework.TestCaseAttribute("100", null)]
        public virtual void _007_Assets_VerifyPageSizeUnderPagination(string pageSize, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007_ Assets - Verify PageSize under Pagination", exampleTags);
#line 85
this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.When(string.Format("I Select the PageSize as {0} under Pagination Section", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
 testRunner.And(string.Format("I see the Table Contains the Same Number of Rows as per Selected {0}", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008_ Assets - Edit Asset")]
        public virtual void _008_Assets_EditAsset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008_ Assets - Edit Asset", ((string[])(null)));
#line 98
this.ScenarioSetup(scenarioInfo);
#line 99
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 100
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.And("I enter description \'QA Automation Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.Then("I edit Record containing DESCRIPTION \'QA Automation Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.When("I enter \'DESCRIPTION-QA Automation Test;PETITION VALUE STATUS-Scheduled;TRUSTEE V" +
                    "ALUE STATUS-Known;CODE-1141 Preference/Fraudulent Transfer Litigation\' fileds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
    testRunner.When("I enter \'PETITION VALUE-1000.00;LIENS-200.00;OWNED VALUE-300.00;EXEMPTIONS-200.00" +
                    ";ESTIMATED COST OF SALE-500.00;PETITION VALUE-1500.00\' fileds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
 testRunner.And("I enter \'FORM 1 NOTES-QA Automation Testing on Edit Assets;FULLY ADMINISTERED DAT" +
                    "E-01/26/18;1ST UST REPORT DATE-06/22/18;SCHEDULE-B25: Aircraft\' fileds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.And("I enter \'SCHEDULE-106A/B Part 3-Q11;ABANDONED-Yes (OA);OWNERSHIP-Debtor 1 and Deb" +
                    "tor 2;RESERVED NOTE-Unity Edit Assets Testing\' fileds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("I click on save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
 testRunner.And("I enter description \'QA Automation Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.Then("Records should contain \'DESCRIPTION-QA Automation Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009_ Assets - SaveEdit- InLineEdit and verify")]
        [NUnit.Framework.CategoryAttribute("US235853")]
        public virtual void _009_Assets_SaveEdit_InLineEditAndVerify()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009_ Assets - SaveEdit- InLineEdit and verify", new string[] {
                        "US235853"});
#line 117
this.ScenarioSetup(scenarioInfo);
#line 118
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 119
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
 testRunner.And("I enter description \'INVENTORY\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.Then("I edit PETITION InLineEdit \'300\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
 testRunner.And("I edit TRUSTEE \'100\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("I edit EXEMPTIONS \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("I edit FA \'06/27/18\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("I edit OWNED \'300\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.And("I edit Reserved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.And("I Edit RESERVED NOTE \'Automation Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.Then("I see the PETITION value \'$300.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
 testRunner.And("the TRUSTEE value as \'$100.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("the EXEMPTIONS value as \'$200.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("the FA value as \'06/27/18\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.And("the ABANDONED value as \'Yes (OA)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.And("the OWNED value as \'$300.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.And("the RESERVED Notes as \'Automation Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("010_Assets - CancelEdit- InLineEdit and Verify")]
        [NUnit.Framework.CategoryAttribute("US235853")]
        public virtual void _010_Assets_CancelEdit_InLineEditAndVerify()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("010_Assets - CancelEdit- InLineEdit and Verify", new string[] {
                        "US235853"});
#line 141
this.ScenarioSetup(scenarioInfo);
#line 142
testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 143
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
 testRunner.And("I enter description \'INVENTORY\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.Then("I edit PETITION \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 148
 testRunner.And("edit TRUSTEE \'500\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.And("edit EXEMPTIONS \'600\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
 testRunner.And("edit FA \'08/09/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.And("edit OWNED \'800\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.And("Edit RESERVED NOTE \'Assets Automation Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
 testRunner.Then("I see the PETITION value \'$300.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
 testRunner.And("the TRUSTEE value as \'$100.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.And("the EXEMPTIONS value as \'$200.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
 testRunner.And("the FA value as \'06/27/18\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
 testRunner.And("the ABANDONED value as \'Yes (OA)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.And("the OWNED value as \'$300.00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 160
 testRunner.And("the RESERVED Notes as \'Automation Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 161
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("011_ Assets - NoPermission to InLineEdit")]
        [NUnit.Framework.CategoryAttribute("US235853")]
        [NUnit.Framework.CategoryAttribute("US277535")]
        public virtual void _011_Assets_NoPermissionToInLineEdit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("011_ Assets - NoPermission to InLineEdit", new string[] {
                        "US235853",
                        "US277535"});
#line 164
this.ScenarioSetup(scenarioInfo);
#line 165
 testRunner.Given("I enter to Assets page as user AutomationView with password Welcome456Epiq! and o" +
                    "ffice crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 166
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 167
 testRunner.And("I enter description \'INVENTORY\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
 testRunner.Then("I see the InLineEdit Fields as Non-Editable Fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 170
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("012_ Assets - Verify Fully Administered Cases")]
        [NUnit.Framework.CategoryAttribute("US#235896")]
        public virtual void _012_Assets_VerifyFullyAdministeredCases()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("012_ Assets - Verify Fully Administered Cases", new string[] {
                        "US#235896"});
#line 173
this.ScenarioSetup(scenarioInfo);
#line 174
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 175
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
 testRunner.And("I select fully administered \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
 testRunner.Then("I verify Fully Administered Cases as Green", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 180
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("013_ Assets - Verify Default values of Filter")]
        [NUnit.Framework.CategoryAttribute("US#235897")]
        public virtual void _013_Assets_VerifyDefaultValuesOfFilter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("013_ Assets - Verify Default values of Filter", new string[] {
                        "US#235897"});
#line 183
this.ScenarioSetup(scenarioInfo);
#line 184
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 185
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 186
 testRunner.When("I select fully administered \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 187
 testRunner.And("I select fully abandoned \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 188
 testRunner.And("I select fully reserved \'Yes\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.And("I select fully case status \'Closed\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
 testRunner.When("Click on reset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 191
 testRunner.Then("I see default value \'FULLY ADMINISTERED\' as \'All\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 193
 testRunner.And("I see default value \'RESERVED\' as \'All\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
 testRunner.And("I see default value \'CASE STATUS\' as \'Open\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 195
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("014_ Assets - Verify Case Level Default values of Filter")]
        [NUnit.Framework.CategoryAttribute("US235900")]
        public virtual void _014_Assets_VerifyCaseLevelDefaultValuesOfFilter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("014_ Assets - Verify Case Level Default values of Filter", new string[] {
                        "US235900"});
#line 198
this.ScenarioSetup(scenarioInfo);
#line 199
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 200
 testRunner.Given("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 201
 testRunner.When("I Enter \'17-90000\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 202
 testRunner.And("I Click on the Case Result \'17-90000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 203
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 204
 testRunner.Then("I see default value \'FULLY ADMINISTERED\' as \'All\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 206
 testRunner.And("I see default value \'RESERVED\' as \'All\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 207
 testRunner.And("I should not be able to see \'CASE STATUS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 208
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("016_ Assets - View Permission of Assets Page")]
        [NUnit.Framework.CategoryAttribute("US235904")]
        [NUnit.Framework.CategoryAttribute("US277535")]
        public virtual void _016_Assets_ViewPermissionOfAssetsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("016_ Assets - View Permission of Assets Page", new string[] {
                        "US235904",
                        "US277535"});
#line 222
this.ScenarioSetup(scenarioInfo);
#line 223
     testRunner.Given("I enter to Assets page as user AutomationView with password Welcome456Epiq! and o" +
                    "ffice crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 224
     testRunner.Then("Verify for View icon symbol \'19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 225
  testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("017_ Assets - View Tax refund request")]
        [NUnit.Framework.CategoryAttribute("US235904")]
        [NUnit.Framework.CategoryAttribute("US277535")]
        public virtual void _017_Assets_ViewTaxRefundRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("017_ Assets - View Tax refund request", new string[] {
                        "US235904",
                        "US277535"});
#line 228
this.ScenarioSetup(scenarioInfo);
#line 229
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 230
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 231
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 232
 testRunner.And("I enter description \'QA Automation Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 233
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 234
 testRunner.Then("I edit Record containing DESCRIPTION \'QA Automation Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 235
 testRunner.And("I click on Tax refund request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 236
    testRunner.Then("click \'GENERATE REPORT\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 237
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008_ Assets - Edit Asset-Edit Tax Refund Request")]
        [NUnit.Framework.CategoryAttribute("US293966")]
        public virtual void _008_Assets_EditAsset_EditTaxRefundRequest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008_ Assets - Edit Asset-Edit Tax Refund Request", new string[] {
                        "US293966"});
#line 240
this.ScenarioSetup(scenarioInfo);
#line 241
 testRunner.Given("I enter to Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 242
 testRunner.Then("\'AssetManagement\' page should be display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 243
 testRunner.When("I click on filter button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 244
 testRunner.And("I enter description \'Nissan X-Trail Hybrid SUV - Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 245
 testRunner.And("I click on close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 246
 testRunner.Then("I edit Record containing DESCRIPTION \'Nissan X-Trail Hybrid SUV - Test\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 247
 testRunner.And("I click on Taxrefund request button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 248
 testRunner.And("I click on button SAVE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 249
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
