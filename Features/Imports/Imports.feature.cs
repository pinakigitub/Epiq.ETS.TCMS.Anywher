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
    [NUnit.Framework.DescriptionAttribute("ImportAssets")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class ImportAssetsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Imports.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ImportAssets", "Navigating to the different sections \r\nunder Imports", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("001 - Imports- Asset Page Header and Count Validation")]
        public virtual void _001_Imports_AssetPageHeaderAndCountValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Imports- Asset Page Header and Count Validation", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I see header on Import Assets Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
 testRunner.And("I see the count for Assets to Import", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("I see the count for Assets in case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Imports- Asset To Import Tab Columns Header Validation")]
        public virtual void _002_Imports_AssetToImportTabColumnsHeaderValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Imports- Asset To Import Tab Columns Header Validation", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I see the Visible headers on Assets to Import are \'DESCRIPTION\' \'FA\' and \'UTC\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.When("I click on Row Expand Button of Assets to Import", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("I see all Hidden coulumns hearder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003 - Imports- Asset In Case Tab - Columns Header Validation")]
        public virtual void _003_Imports_AssetInCaseTab_ColumnsHeaderValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003 - Imports- Asset In Case Tab - Columns Header Validation", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.Then("I see the Visible headers on Assets In Case are \'DESCRIPTION\' \'UTC\' and \'REMAININ" +
                    "G\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
 testRunner.When("I click on Row Expand Button of Assets in Case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("I see all Hidden coulumns hearder for Assets in case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007 - Imports-Asset Page Filter Options-Default Values")]
        public virtual void _007_Imports_AssetPageFilterOptions_DefaultValues()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007 - Imports-Asset Page Filter Options-Default Values", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.When("User clicks on the filter options of Import Asset Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.And("Validate by default the imports text is\'Waiting to import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("Validate by default the Case status is \'Open\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.Then("User clicks on cross button of the filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.And("Validate the Header title of Import Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
 testRunner.Then("\'DashboardImport Assets\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008 - Imports-Asset Page Filter Options-All values")]
        public virtual void _008_Imports_AssetPageFilterOptions_AllValues()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008 - Imports-Asset Page Filter Options-All values", ((string[])(null)));
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 75
 testRunner.When("User clicks on the filter options of Import Asset Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And("Enter imports text as\'imported\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("Enter the Case status as \'Closed\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("User clicks on Close button of the filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When("User clicks on the filter options of Import Asset Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("Clicks on the reset button of the filter options", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.When("User clicks on Close button of the filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009-Imports-Assets-Inline Editing")]
        public virtual void _009_Imports_Assets_InlineEditing()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009-Imports-Assets-Inline Editing", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("I see the Visible headers on Assets to Import are \'DESCRIPTION\' \'FA\' and \'UTC\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
 testRunner.Then("\'DashboardImport AssetsAssets\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
 testRunner.And("Inline edit the Description as \'Testing automation inline edit\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("010-Imports-Assets-View Permission")]
        public virtual void _010_Imports_Assets_ViewPermission()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("010-Imports-Assets-View Permission", ((string[])(null)));
#line 94
this.ScenarioSetup(scenarioInfo);
#line 95
 testRunner.Given("I enter to Import Assets page as user AutomationView with password Welcome456Epiq" +
                    "! and office crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 96
 testRunner.Then("I see the Security Warning Icon in Orange", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("011_IMPORT_ASSETS - Verify PageSize under Pagination")]
        [NUnit.Framework.TestCaseAttribute("10", null)]
        [NUnit.Framework.TestCaseAttribute("25", null)]
        [NUnit.Framework.TestCaseAttribute("50", null)]
        public virtual void _011_IMPORT_ASSETS_VerifyPageSizeUnderPagination(string pageSize, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("011_IMPORT_ASSETS - Verify PageSize under Pagination", exampleTags);
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 101
 testRunner.When(string.Format("I Select the PageSize as {0} under Pagination Section in import asset page", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.And(string.Format("I see the Assets Table Contains the Same Number of Rows as per Selected {0}", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("012 - Imports- View Documents-Import Assets Tab Columns Header Validation and cou" +
            "nt")]
        public virtual void _012_Imports_ViewDocuments_ImportAssetsTabColumnsHeaderValidationAndCount()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("012 - Imports- View Documents-Import Assets Tab Columns Header Validation and cou" +
                    "nt", ((string[])(null)));
#line 110
this.ScenarioSetup(scenarioInfo);
#line 111
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 112
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
 testRunner.Then("I see the Visible headers on View Documents Tab are \'DOC #\' \'SOURCE\' and \'DESCRIP" +
                    "TION\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
 testRunner.And("Validate the count of the documents in the view document tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("013 - Imports-Description Inline Edit Count length.")]
        public virtual void _013_Imports_DescriptionInlineEditCountLength_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("013 - Imports-Description Inline Edit Count length.", ((string[])(null)));
#line 117
this.ScenarioSetup(scenarioInfo);
#line 118
  testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 119
  testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
 testRunner.Then("I see the Visible headers on Assets to Import are \'DESCRIPTION\' \'FA\' and \'UTC\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.Then("\'DashboardImport AssetsAssets\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
 testRunner.And("Inline edit the Description as \'The length of the characters enter is greaterthan" +
                    " sixty count testing the US\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("014 - Imports- Validate the Header Title")]
        [NUnit.Framework.CategoryAttribute("US256003")]
        [NUnit.Framework.TestCaseAttribute("Imported", "Imported Assets", null)]
        [NUnit.Framework.TestCaseAttribute("Ignored", "Ignored Assets", null)]
        public virtual void _014_Imports_ValidateTheHeaderTitle(string imports, string header, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "US256003"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("014 - Imports- Validate the Header Title", @__tags);
#line 127
this.ScenarioSetup(scenarioInfo);
#line 128
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 129
 testRunner.Then("Validate the Record Default Count on the Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.Then("Validate the header tilte \'Assets to Import \'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
 testRunner.When("User clicks on the filter options of Import Asset Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.And(string.Format("Enter imports text as \'{0}\'", imports), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
 testRunner.And("Enter the Case status as \'Open\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("User clicks on Close button of the filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.Then("Validate the count after filter applied", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
 testRunner.Then(string.Format("Validate the header tilte \'{0} \'", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("015 - Imports- Redirection of caselevel navigation")]
        [NUnit.Framework.CategoryAttribute("US256004")]
        public virtual void _015_Imports_RedirectionOfCaselevelNavigation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("015 - Imports- Redirection of caselevel navigation", new string[] {
                        "US256004"});
#line 144
this.ScenarioSetup(scenarioInfo);
#line 145
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 146
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
 testRunner.When("I Enter \'12-70476\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
 testRunner.And("I Click on the Case Result \'12-70476\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.Then("Validate the Record Default Count on the Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 150
 testRunner.And("Validate the header tilte \'Assets to Import \'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
 testRunner.And("I see case as \'open\' in green", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.And("CaseType as \'Asset\' in Orange", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
 testRunner.Then("Validate the message as \'No assets to import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
 testRunner.And("I Click on Cross Button on Universal search box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.And("Validate the Record Default Count on the Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.And("Validate the header tilte \'Assets to Import \'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("016 - Import Assets:Settings Functionality")]
        [NUnit.Framework.CategoryAttribute("US230558")]
        public virtual void _016_ImportAssetsSettingsFunctionality()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("016 - Import Assets:Settings Functionality", new string[] {
                        "US230558"});
#line 160
this.ScenarioSetup(scenarioInfo);
#line 161
 testRunner.Given("I enter to Import Assets page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 162
 testRunner.Then("I see header on Import Assets Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
 testRunner.When("I click on settings icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
 testRunner.Then("verify the subheader \'Settings Management\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
 testRunner.Then("verify the expand functionality on \'IMPORT;BATCH OPTIONS\' section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 166
    testRunner.Then("verify the displayed options in \'IMPORT\' section as \'Set the Trustee Value to the" +
                    " Schedule\'s Market Value / Owned Value;Set the Abandonment status to \"Yes\";Set t" +
                    "he Fully Administered date to import date;Import Assets in UPPERCASE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
 testRunner.Then(@"verify the displayed options in 'BATCH OPTIONS' section as 'Set the Abandonment status to ""Yes"";Set the Remaining value to 0.00;Do not set the Fully Administered date;Set the Fully Administered date to import date;Prompt for a date to set the Fully Administered date to when the batch is processed'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
    testRunner.Then("I save the settings", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("017 - Viewing of Documents-Import to Asset")]
        [NUnit.Framework.CategoryAttribute("US245005")]
        public virtual void _017_ViewingOfDocuments_ImportToAsset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("017 - Viewing of Documents-Import to Asset", new string[] {
                        "US245005"});
#line 173
this.ScenarioSetup(scenarioInfo);
#line 174
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 175
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
 testRunner.When("I Enter \'15-70235\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
 testRunner.And("I Click on the Case Result \'15-70235\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
 testRunner.Then("I click on View Documents Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 180
 testRunner.And("I click on Expand button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("018 - Import Assets - Validate state of Import option at case level")]
        [NUnit.Framework.CategoryAttribute("US293919")]
        [NUnit.Framework.CategoryAttribute("US230561")]
        public virtual void _018_ImportAssets_ValidateStateOfImportOptionAtCaseLevel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("018 - Import Assets - Validate state of Import option at case level", new string[] {
                        "US293919",
                        "US230561"});
#line 184
this.ScenarioSetup(scenarioInfo);
#line 185
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 186
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 187
 testRunner.When("I Enter \'15-70235\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 188
 testRunner.And("I Click on the Case Result \'15-70235\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
 testRunner.And("I View that Import Option is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
 testRunner.Then("I click on checkbox on tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 193
 testRunner.Then("I see Import and Ignore button Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 194
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("019 - Import Assets - Verify filter functionality and data on Import assets page")]
        [NUnit.Framework.CategoryAttribute("US293919")]
        [NUnit.Framework.CategoryAttribute("US293917")]
        public virtual void _019_ImportAssets_VerifyFilterFunctionalityAndDataOnImportAssetsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("019 - Import Assets - Verify filter functionality and data on Import assets page", new string[] {
                        "US293919",
                        "US293917"});
#line 197
this.ScenarioSetup(scenarioInfo);
#line 198
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 199
 testRunner.Then("I see Import Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 200
 testRunner.Then("\'DashboardImport Assets\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 201
 testRunner.And("I see subheader as \'Assets to Import\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
 testRunner.When("Click on filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 203
 testRunner.Then("Filter with \'IMPORTED\' as \'Imported\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 204
 testRunner.When("I \'CLOSE\' Filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 205
 testRunner.Then("I see subheader as \'Imported Assets\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 206
 testRunner.When("Click on filter option on tile page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 207
 testRunner.Then("Filter with \'IMPORTED\' as \'Ignored\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 208
 testRunner.When("I \'CLOSE\' Filter option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 209
 testRunner.Then("I see subheader as \'Ignored Assets\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 210
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("020 - Import Assets - Filter Ignored Assets and perform import action")]
        [NUnit.Framework.CategoryAttribute("US293919")]
        public virtual void _020_ImportAssets_FilterIgnoredAssetsAndPerformImportAction()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("020 - Import Assets - Filter Ignored Assets and perform import action", new string[] {
                        "US293919"});
#line 213
this.ScenarioSetup(scenarioInfo);
#line 214
 testRunner.Given("I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and o" +
                    "ffice Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 215
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 216
 testRunner.When("I Enter \'15-21754\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 217
 testRunner.And("I Click on the Case Result \'15-21754\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 218
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 219
 testRunner.Then("I click on checkbox on tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 220
 testRunner.When("I click import \'IMPORT\' in Assets to import tile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 221
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion