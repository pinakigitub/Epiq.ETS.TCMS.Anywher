﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Cases.Detail.Banking.Deposits
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CaseBanking_Deposits_NewDeposit")]
    [NUnit.Framework.IgnoreAttribute("Ignored feature")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("DoNotExecute")]
    [NUnit.Framework.CategoryAttribute("BankingTransactions")]
    public partial class CaseBanking_Deposits_NewDepositFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CaseBanking_Deposits_NewDeposit.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CaseBanking_Deposits_NewDeposit", null, ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
                        "Ignore",
                        "DoNotExecute",
                        "BankingTransactions"});
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
        [NUnit.Framework.DescriptionAttribute("003_\"NewDeposit_SubCodes\" Code - Subcode Not enabled for no selection")]
        [NUnit.Framework.CategoryAttribute("AssetsPage")]
        [NUnit.Framework.CategoryAttribute("US127983")]
        public virtual void _003_NewDeposit_SubCodesCode_SubcodeNotEnabledForNoSelection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003_\"NewDeposit_SubCodes\" Code - Subcode Not enabled for no selection", new string[] {
                        "AssetsPage",
                        "US127983"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'JOHN WAYNE MYERS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("Click on Banking tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("Click on Deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Then("Verify Deposit input field with Name \'Sub Code\' has state \'Disabled\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005_\"NewDeposit_SubCodes\" Verify Code and Sub Code fields hide when adding Asset " +
            "Link")]
        [NUnit.Framework.CategoryAttribute("AssetsPage")]
        [NUnit.Framework.CategoryAttribute("US127983")]
        public virtual void _005_NewDeposit_SubCodesVerifyCodeAndSubCodeFieldsHideWhenAddingAssetLink()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005_\"NewDeposit_SubCodes\" Verify Code and Sub Code fields hide when adding Asset " +
                    "Link", new string[] {
                        "AssetsPage",
                        "US127983"});
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'JOHN WAYNE MYERS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("I Go to Banking Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.And("Click on More transactions button \'No\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("Click to open Transaction with name \'Deposit\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Select Code by text \'1290\' using \'Click\' for Transaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("Select Sub Code by text \'01\' using \'Click\' for Transaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("Click on Add Asset Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Verify Transaction field with Name \'Code\' is not visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("Verify Transaction field with Name \'Sub Code\' is not visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("Search and Select Asset Link with value \'8\' in column \'Asset Number\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("Enter Linked Amount value \'150\' for Asset Number \'8\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.When("Remove Asset Link with Asset Number \'8\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.Then("Verify Transaction field with Name \'Code\' is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.And("Verify Transaction field with Name \'Sub Code\' is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006_\"NewDeposit_SerialN\" Verify New Deposit Serial Number is not Editable")]
        [NUnit.Framework.CategoryAttribute("AssetsPage")]
        [NUnit.Framework.CategoryAttribute("US127978")]
        public virtual void _006_NewDeposit_SerialNVerifyNewDepositSerialNumberIsNotEditable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006_\"NewDeposit_SerialN\" Verify New Deposit Serial Number is not Editable", new string[] {
                        "AssetsPage",
                        "US127978"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'JOHN WAYNE MYERS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.And("I Go to Banking Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
 testRunner.When("Click on Deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("Verify Serial Number for transaction with name \'Deposit\' is not editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007_\"NewCheck_SerialN\" Verify New Check Serial Number is not Editable")]
        [NUnit.Framework.CategoryAttribute("AssetsPage")]
        [NUnit.Framework.CategoryAttribute("US127978")]
        public virtual void _007_NewCheck_SerialNVerifyNewCheckSerialNumberIsNotEditable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007_\"NewCheck_SerialN\" Verify New Check Serial Number is not Editable", new string[] {
                        "AssetsPage",
                        "US127978"});
#line 48
this.ScenarioSetup(scenarioInfo);
#line 49
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'JOHN WAYNE MYERS\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I Go to Banking Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.When("Click on Check button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.Then("Verify Serial Number for transaction with name \'Check\' is not editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion