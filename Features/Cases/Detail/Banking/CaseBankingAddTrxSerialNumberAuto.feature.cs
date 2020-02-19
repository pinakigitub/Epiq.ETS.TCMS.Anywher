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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Cases.Detail.Banking
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Case Detail - Banking - Add transaction Serial Number Autocomplete")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("BankingTransactions")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("DoNotExecute")]
    public partial class CaseDetail_Banking_AddTransactionSerialNumberAutocompleteFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CaseBankingAddTrxSerialNumberAuto.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Case Detail - Banking - Add transaction Serial Number Autocomplete", "\tIn order to create new banking transactions with auto completed serial numbers\r\n" +
                    "\tAs a user of Unity\r\n\tI need to be able to see the serial number autocompletes t" +
                    "o the next on series for checks and deposits", ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
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
        [NUnit.Framework.DescriptionAttribute("Case Detail -  Banking - Add Transaction - Serial Number Default")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("BankingTransactions")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US96815")]
        [NUnit.Framework.CategoryAttribute("TC101352")]
        [NUnit.Framework.TestCaseAttribute("Check", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Deposit", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Deposit Correcting Check", new string[0])]
        public virtual void CaseDetail_Banking_AddTransaction_SerialNumberDefault(string transaction, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CaseDetail",
                    "BankingTransactions",
                    "Sanity",
                    "US96815",
                    "TC101352"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Case Detail -  Banking - Add Transaction - Serial Number Default", @__tags);
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'10-14868\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("I Go to Banking Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When(string.Format("I Go To Create Transaction \'{0}\'", transaction), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I See Serial Number Autocompletes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Case Detail -  Banking - Add Check - Serial Number Increment")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("BankingTransactions")]
        [NUnit.Framework.CategoryAttribute("TransactionSaving")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US96815")]
        [NUnit.Framework.CategoryAttribute("TC101353")]
        [NUnit.Framework.TestCaseAttribute("Check", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Deposit", new string[0])]
        [NUnit.Framework.TestCaseAttribute("Deposit Correcting Check", new string[0])]
        public virtual void CaseDetail_Banking_AddCheck_SerialNumberIncrement(string transaction, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CaseDetail",
                    "BankingTransactions",
                    "TransactionSaving",
                    "Sanity",
                    "US96815",
                    "TC101353"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Case Detail -  Banking - Add Check - Serial Number Increment", @__tags);
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'10-14868\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I Go to Banking Detail", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And(string.Format("I Go To Create Transaction \'{0}\'", transaction), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("I Create A Transaction With The Default Serial Number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.And("I See the Transaction has been Saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.Then("If I Open The Form Again I See The Default Serial Number Is Higher Than The Previ" +
                    "ous One", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
