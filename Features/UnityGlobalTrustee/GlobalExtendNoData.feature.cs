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
    [NUnit.Framework.DescriptionAttribute("GlobalExtendNoData")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class GlobalExtendNoDataFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GlobalExtendNoData.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GlobalExtendNoData", "In order to Verify Extend No Data Display message for New page", ProgrammingLanguage.CSharp, new string[] {
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
#line 6
#line 7
testRunner.When("I login to Unity as NON Super Admin user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("001 - Unity Pages- Global NavBar:Extend No Data Display validation")]
        [NUnit.Framework.CategoryAttribute("202711")]
        [NUnit.Framework.TestCaseAttribute("Case List", "Case Management", "Cases", "No matching cases", null)]
        [NUnit.Framework.TestCaseAttribute("Assets", "Asset Management", "Assets", "No matching assets", null)]
        [NUnit.Framework.TestCaseAttribute("Bank Accounts", "Banking Center", "Bank Accounts", "No matching accounts", null)]
        [NUnit.Framework.TestCaseAttribute("Banking Activity", "Banking Center", "Unreconciled Bank Accounts", "No matching activity", null)]
        [NUnit.Framework.TestCaseAttribute("Banking ReceiptLog", "Banking Center", "Receipts", "No matching receipts", null)]
        [NUnit.Framework.TestCaseAttribute("Banking ChecksOrDeposits", "Banking Center", "Print Checks/Deposits", "No matching transactions", null)]
        [NUnit.Framework.TestCaseAttribute("Claims", "Claims Management", "Claims", "No matching claims", null)]
        [NUnit.Framework.TestCaseAttribute("Dates", "Date Management", "Dates", "No Dates Available Matching Current View", null)]
        [NUnit.Framework.TestCaseAttribute("Distributions", "Distribution Management", "Distributions", "No matching distributions", null)]
        [NUnit.Framework.TestCaseAttribute("Documents", "Document Management", "Documents", "No matching documents", null)]
        [NUnit.Framework.TestCaseAttribute("DSO", "DSO Management", "DSO Claimants", "No matching claimants", null)]
        [NUnit.Framework.TestCaseAttribute("Tasks", "Task Management", "Tasks", "No matching tasks", null)]
        public virtual void _001_UnityPages_GlobalNavBarExtendNoDataDisplayValidation(string selection, string header, string subHeader, string message, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "202711"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Unity Pages- Global NavBar:Extend No Data Display validation", @__tags);
#line 10
 this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 11
 testRunner.When(string.Format("I Go to {0} page", selection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then(string.Format("I see {0} header", header), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
 testRunner.And(string.Format("I see {0} subheader", subHeader), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And(string.Format("I see {0} message", message), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Unity Pages- Dashboard:Extend No Data Display validation")]
        [NUnit.Framework.CategoryAttribute("220246")]
        [NUnit.Framework.TestCaseAttribute("Upcoming 341 Meetings", "No Upcoming 341 Meetings Matching Current View", null)]
        [NUnit.Framework.TestCaseAttribute("Past 341 Meetings", "No Past 341 Meetings Matching Current View", null)]
        [NUnit.Framework.TestCaseAttribute("This Week\'s Tasks", "No current tasks", null)]
        [NUnit.Framework.TestCaseAttribute("DSO Summary", "No upcoming claimants", null)]
        [NUnit.Framework.TestCaseAttribute("Favorites", "No current favorites", null)]
        public virtual void _002_UnityPages_DashboardExtendNoDataDisplayValidation(string selection, string dashboardMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "220246"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Unity Pages- Dashboard:Extend No Data Display validation", @__tags);
#line 34
 this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 35
 testRunner.Then(string.Format("I see Dashboard header \'{0}\'", selection), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.Then(string.Format("I see \'{0}\' dashboardmessage", dashboardMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
