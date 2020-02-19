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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Cases.Detail.Claims
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Case Detail - Claims Summary")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("DoNotExecute")]
    public partial class CaseDetail_ClaimsSummaryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CaseClaimsSummary.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Case Detail - Claims Summary", "\tIn order to be able see the value associated to all claims, and each class.   \r\n" +
                    "\tAs a user of Unity\r\n\tI want to have a summary of my claims. For example Adminis" +
                    "trative, Secured, Priority, and Unsecured Claims", ProgrammingLanguage.CSharp, new string[] {
                        "Regression"});
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
        [NUnit.Framework.DescriptionAttribute("Case Detail - Claims Tab Display")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseClaimsSummary")]
        [NUnit.Framework.CategoryAttribute("US72373")]
        [NUnit.Framework.CategoryAttribute("TC76149")]
        [NUnit.Framework.CategoryAttribute("CaseClaims")]
        [NUnit.Framework.CategoryAttribute("US52695")]
        [NUnit.Framework.CategoryAttribute("TC72850")]
        [NUnit.Framework.CategoryAttribute("US97749")]
        [NUnit.Framework.CategoryAttribute("TC100836")]
        [NUnit.Framework.CategoryAttribute("US98816")]
        [NUnit.Framework.CategoryAttribute("TC100817")]
        [NUnit.Framework.CategoryAttribute("US98265")]
        [NUnit.Framework.CategoryAttribute("TC105466")]
        public virtual void CaseDetail_ClaimsTabDisplay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Case Detail - Claims Tab Display", new string[] {
                        "CaseDetail",
                        "CaseClaimsSummary",
                        "US72373",
                        "TC76149",
                        "CaseClaims",
                        "US52695",
                        "TC72850",
                        "US97749",
                        "TC100836",
                        "US98816",
                        "TC100817",
                        "US98265",
                        "TC105466"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("I Go to Claims Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I See Claims Detail is Selected by Default and Tab Title is \'Claims Detail\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
 testRunner.And("I See the Claims Summary Section With Title \'Claims Summary\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("I See the Selection Summary Section With Title \'Selection Summary\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("I See the Claims List Section With Title \'Claims\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Case Detail - Claims Summary - Cards Content And Selection Detail")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseClaimsSummary")]
        [NUnit.Framework.CategoryAttribute("NeedsDBClaimUpdates")]
        [NUnit.Framework.CategoryAttribute("US72373")]
        [NUnit.Framework.CategoryAttribute("TC76149")]
        [NUnit.Framework.CategoryAttribute("US74085")]
        [NUnit.Framework.CategoryAttribute("TC76264")]
        [NUnit.Framework.CategoryAttribute("US97706")]
        [NUnit.Framework.CategoryAttribute("TC98696")]
        [NUnit.Framework.CategoryAttribute("US105577")]
        [NUnit.Framework.CategoryAttribute("TC105663")]
        [NUnit.Framework.CategoryAttribute("TC105664")]
        [NUnit.Framework.CategoryAttribute("TC105665")]
        [NUnit.Framework.CategoryAttribute("TC105666")]
        [NUnit.Framework.CategoryAttribute("TC105667")]
        [NUnit.Framework.CategoryAttribute("TC105668")]
        [NUnit.Framework.CategoryAttribute("US98265")]
        [NUnit.Framework.CategoryAttribute("TC105443")]
        [NUnit.Framework.CategoryAttribute("TC105445")]
        [NUnit.Framework.CategoryAttribute("TC105449")]
        [NUnit.Framework.CategoryAttribute("TC105451")]
        [NUnit.Framework.CategoryAttribute("TC105453")]
        [NUnit.Framework.CategoryAttribute("TC106614")]
        [NUnit.Framework.TestCaseAttribute("09-13569", new string[0])]
        [NUnit.Framework.TestCaseAttribute("03-30382", new string[0])]
        public virtual void CaseDetail_ClaimsSummary_CardsContentAndSelectionDetail(string caseNumber, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CaseDetail",
                    "CaseClaimsSummary",
                    "NeedsDBClaimUpdates",
                    "US72373",
                    "TC76149",
                    "US74085",
                    "TC76264",
                    "US97706",
                    "TC98696",
                    "US105577",
                    "TC105663",
                    "TC105664",
                    "TC105665",
                    "TC105666",
                    "TC105667",
                    "TC105668",
                    "US98265",
                    "TC105443",
                    "TC105445",
                    "TC105449",
                    "TC105451",
                    "TC105453",
                    "TC106614"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Case Detail - Claims Summary - Cards Content And Selection Detail", @__tags);
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And(string.Format("I Enter to Case Detail page for Case with Case Number \'{0}\'", caseNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I Go to Claims Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.Then("I See Claims Summary Tiles and All Values are Correct", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.And("First Tile is Selected By Default And Selecting Each Tile Displays Claim Class De" +
                    "tail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Case Detail - Claims Summary - Selecting Tile Filters Results List")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseClaimsSummary")]
        [NUnit.Framework.CategoryAttribute("US102485")]
        [NUnit.Framework.CategoryAttribute("TC105433")]
        [NUnit.Framework.CategoryAttribute("TC105435")]
        [NUnit.Framework.CategoryAttribute("TC105436")]
        [NUnit.Framework.CategoryAttribute("TC105437")]
        [NUnit.Framework.CategoryAttribute("TC105439")]
        [NUnit.Framework.CategoryAttribute("TC106618")]
        public virtual void CaseDetail_ClaimsSummary_SelectingTileFiltersResultsList()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Case Detail - Claims Summary - Selecting Tile Filters Results List", new string[] {
                        "CaseDetail",
                        "CaseClaimsSummary",
                        "US102485",
                        "TC105433",
                        "TC105435",
                        "TC105436",
                        "TC105437",
                        "TC105439",
                        "TC106618"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("I Go to Claims Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.Then("Selecting Each Tile Displays Only Claims Of That Class", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
