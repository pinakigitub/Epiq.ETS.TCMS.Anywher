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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.UnityGlobalTrustee
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("TrusteeVisibility")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class TrusteeVisibilityFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "TrusteeVisibility.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "TrusteeVisibility", "In order to verify Trustee Visibility with view permission \r\nAnd verify the data " +
                    "between UI and DB", ProgrammingLanguage.CSharp, new string[] {
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
        
        public virtual void FeatureBackground()
        {
#line 8
#line 9
testRunner.Given("I enter to Unity Login page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.When("I try to login with credentials autotest1, Welcome789Epiq! and crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("001 - Unity Pages-TrusteeVisibility- DSO Management Page")]
        [NUnit.Framework.CategoryAttribute("204500")]
        public virtual void _001_UnityPages_TrusteeVisibility_DSOManagementPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Unity Pages-TrusteeVisibility- DSO Management Page", new string[] {
                        "204500"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 15
        testRunner.Given("I Go to DSO page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
                 testRunner.Then("I see DSO Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
                 testRunner.Then("I verify the DSO record with Claimant Name as \'KALPANA\' and \'4\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
                 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Unity Pages-TrusteeVisibility- Tasks Management Page")]
        [NUnit.Framework.CategoryAttribute("US204499")]
        public virtual void _002_UnityPages_TrusteeVisibility_TasksManagementPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Unity Pages-TrusteeVisibility- Tasks Management Page", new string[] {
                        "US204499"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 23
         testRunner.Given("I Go to Tasks page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
                 testRunner.Then("I see Task Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
                 testRunner.Then("I see No matching tasks message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
                 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003 - Unity Pages-TrusteeVisibility- Banking Print Checks & Deposits")]
        [NUnit.Framework.CategoryAttribute("US228996")]
        public virtual void _003_UnityPages_TrusteeVisibility_BankingPrintChecksDeposits()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003 - Unity Pages-TrusteeVisibility- Banking Print Checks & Deposits", new string[] {
                        "US228996"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 31
           testRunner.Given("I Go to Banking ChecksOrDeposits page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
                   testRunner.Then("I see Banking Center header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
                   testRunner.Then("I verify the Checks record with Case# as \'17-30005\' and \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
                   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004 - Unity Pages-TrusteeVisibility- Banking Receipt Log")]
        [NUnit.Framework.CategoryAttribute("US228999")]
        public virtual void _004_UnityPages_TrusteeVisibility_BankingReceiptLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004 - Unity Pages-TrusteeVisibility- Banking Receipt Log", new string[] {
                        "US228999"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 38
           testRunner.Given("I Go to Banking ReceiptLog page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
                    testRunner.Then("I see Banking Center header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
                    testRunner.Then("I verify the ReceiptLog record with Received from as \'Sushma\' and \'6\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
                    testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005 - Unity Pages-TrusteeVisibility-Dashboard Page - Claims Management Page")]
        [NUnit.Framework.CategoryAttribute("US228998")]
        public virtual void _005_UnityPages_TrusteeVisibility_DashboardPage_ClaimsManagementPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005 - Unity Pages-TrusteeVisibility-Dashboard Page - Claims Management Page", new string[] {
                        "US228998"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 45
           testRunner.Given("I Go to Claims page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
                     testRunner.Then("I see Claims Management header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
                     testRunner.Then("I verify the Claims record with Received from as \'FINAL ANALYSIS INC.\' and \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
               testRunner.And("I see No matching claims message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
                     testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006 - Unity Pages-TrusteeVisibility-Dashboard Page - Favorite Cases")]
        [NUnit.Framework.CategoryAttribute("US229003")]
        public virtual void _006_UnityPages_TrusteeVisibility_DashboardPage_FavoriteCases()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006 - Unity Pages-TrusteeVisibility-Dashboard Page - Favorite Cases", new string[] {
                        "US229003"});
#line 52
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 53
                    testRunner.Then("I Verify the Favorite record with Case No as \'17-90000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
                     testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007 - Unity Pages-TrusteeVisibility-Dashboard Page -  Header Search")]
        [NUnit.Framework.CategoryAttribute("US229004")]
        public virtual void _007_UnityPages_TrusteeVisibility_DashboardPage_HeaderSearch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007 - Unity Pages-TrusteeVisibility-Dashboard Page -  Header Search", new string[] {
                        "US229004"});
#line 58
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 59
              testRunner.Given("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
                      testRunner.When("I Enter \'11-10132\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
                      testRunner.And("I Verify Case section with Case Num \'11-10132\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
                      testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008 - Unity Pages-TrusteeVisibility-Dashboard Page -  Banking Activity")]
        [NUnit.Framework.CategoryAttribute("US204502")]
        public virtual void _008_UnityPages_TrusteeVisibility_DashboardPage_BankingActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008 - Unity Pages-TrusteeVisibility-Dashboard Page -  Banking Activity", new string[] {
                        "US204502"});
#line 65
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 66
              testRunner.Given("I Go to Banking Activity page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
                     testRunner.Then("I see Banking Center header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
                     testRunner.Then("I verify the Activity record with Account#  as \'9999924139\' and \'\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
               testRunner.And("I see No matching activity message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
                     testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
