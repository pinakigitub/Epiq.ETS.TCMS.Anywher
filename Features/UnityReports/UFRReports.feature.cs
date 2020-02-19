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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.UnityReports
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("UFRReports")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class UFRReportsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "UFRReports.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "UFRReports", "Generate Trustee Reports.", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("001-UFR-Generate Reprt - PDF Format")]
        [NUnit.Framework.CategoryAttribute("US279721")]
        [NUnit.Framework.CategoryAttribute("US293867")]
        [NUnit.Framework.CategoryAttribute("US274008")]
        [NUnit.Framework.CategoryAttribute("US274009")]
        [NUnit.Framework.CategoryAttribute("US279720")]
        [NUnit.Framework.CategoryAttribute("US279719")]
        [NUnit.Framework.CategoryAttribute("US293869")]
        [NUnit.Framework.CategoryAttribute("US293868")]
        [NUnit.Framework.TestCaseAttribute("Trustee Distribution Report (TDR)", "Trustee Distribution Report (TDR)", "Provides the final account of the administration of the estate.", "Trustee Distribution Report", "GENERATE REPORT", "Download", null)]
        [NUnit.Framework.TestCaseAttribute("Notice of Final Report (NFR)", "NOTICE OF FINAL REPORT (NFR)", "Provides the final report and applications for compensation.", "Notice of Final Report", "GENERATE REPORT", "Download", null)]
        public virtual void _001_UFR_GenerateReprt_PDFFormat(string reportName, string headerName, string subHeader, string report, string button, string type, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "US279721",
                    "US293867",
                    "US274008",
                    "US274009",
                    "US279720",
                    "US279719",
                    "US293869",
                    "US293868"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001-UFR-Generate Reprt - PDF Format", @__tags);
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I enter to Reports page as user UFRReports with password Welcome456Epiq! and offi" +
                    "ce Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.When("I Enter \'10-22769\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.And("I Click on the Case Result \'10-22769\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.Given(string.Format("I Go to \'{0}\'", reportName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
 testRunner.Then(string.Format("verify the report header \'{0}\'", headerName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.Then(string.Format("verify the report sub header \'{0}\'", subHeader), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
 testRunner.Then(string.Format("click \'{0}\'", button), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("click \'REPORT QUEUE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And(string.Format("I search report \'{0}\' under Report Queue", report), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And(string.Format("I \'{0}\' report \'{1}\' in queue with current date", type, report), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("click on ReportQueue close button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.Given("I Go to 341 Meeting page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.When("I click on the View 341_Meeting date link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.And("I Click on View button on Meeting management", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I Click on Case Documents Tab Meeting View Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I click on Expand button 341 Meeting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.Then("I select All Cases in the Global Case Navigation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.Given("I Go to Import Assets page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("I see the Visible headers on View Documents Tab are \'DOC #\' \'SOURCE\' and \'DESCRIP" +
                    "TION\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002-UFR-Save to Queue- XML Format")]
        [NUnit.Framework.CategoryAttribute("US279718")]
        [NUnit.Framework.TestCaseAttribute("Trustee Distribution Report (TDR)", "Trustee Distribution Report (TDR)", "Provides the final account of the administration of the estate.", "Trustee Distribution Report", "SAVE TO QUEUE", "Delete", null)]
        [NUnit.Framework.TestCaseAttribute("Notice of Final Report (NFR)", "NOTICE OF FINAL REPORT (NFR)", "Provides the final report and applications for compensation.", "Notice of Final Report", "SAVE TO QUEUE", "Delete", null)]
        public virtual void _002_UFR_SaveToQueue_XMLFormat(string reportName, string headerName, string subHeader, string report, string button, string type, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "US279718"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002-UFR-Save to Queue- XML Format", @__tags);
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
 testRunner.Given("I enter to Reports page as user UFRReports with password Welcome456Epiq! and offi" +
                    "ce Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.When("I Enter \'10-22769\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
 testRunner.And("I Click on the Case Result \'10-22769\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.Given(string.Format("I Go to \'{0}\'", reportName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
 testRunner.Then(string.Format("verify the report header \'{0}\'", headerName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.Then(string.Format("verify the report sub header \'{0}\'", subHeader), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
 testRunner.And("I click on Checkbox for Export as XML", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.Then(string.Format("click \'{0}\'", button), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
 testRunner.And("click \'REPORT QUEUE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And(string.Format("I search report \'{0}\' under Report Queue", report), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And(string.Format("I \'{0}\' report \'{1}\' in queue with current date", type, report), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("click on ReportQueue close button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003-TFR Inline Date edit functionality and banking service")]
        [NUnit.Framework.CategoryAttribute("US293913")]
        [NUnit.Framework.CategoryAttribute("US293871")]
        [NUnit.Framework.CategoryAttribute("US293866")]
        [NUnit.Framework.CategoryAttribute("US293870")]
        public virtual void _003_TFRInlineDateEditFunctionalityAndBankingService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003-TFR Inline Date edit functionality and banking service", new string[] {
                        "US293913",
                        "US293871",
                        "US293866",
                        "US293870"});
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
testRunner.Given("I enter to Reports page as user UFRReports with password Welcome456Epiq! and offi" +
                    "ce Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("I Enter \'10-22769\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.And("I Click on the Case Result \'10-22769\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.Given("I Go to \'Trustee Final Report (TFR)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
 testRunner.Then("verify the report header \'Trustee Final Report (TFR)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
 testRunner.Then("Click on Include Claim Register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
 testRunner.Then("I inline date fields under Case Dates section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
 testRunner.Then("user click \'GENERATE REPORT\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.Then("user Verify the pop header as \'Stop Bank Fees confirmation\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
 testRunner.Then("user verify the pop up body message as \'Would you like to activate the date to st" +
                    "op bank service fees for this case?\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
 testRunner.Then("user click \'NO\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
  testRunner.And("click \'REPORT QUEUE\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("I search report \'Trustee Final Report\' under Report Queue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("click on ReportQueue close button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.Given("I Go to 341 Meeting page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
 testRunner.When("I click on the View 341_Meeting date link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("I Click on View button on Meeting management", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.When("I Click on Case Documents Tab Meeting View Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
 testRunner.Then("I click on Expand button 341 Meeting", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
 testRunner.Then("I select All Cases in the Global Case Navigation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
 testRunner.Given("I Go to Import Assets page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
 testRunner.When("I Click on one AssetToImport link of listed cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
 testRunner.Then("I see the Visible headers on View Documents Tab are \'DOC #\' \'SOURCE\' and \'DESCRIP" +
                    "TION\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004-UFR-Trustee Compensation")]
        [NUnit.Framework.CategoryAttribute("US293872")]
        [NUnit.Framework.CategoryAttribute("US293911")]
        [NUnit.Framework.TestCaseAttribute("Trustee Final Report (TFR)", "Trustee Final Report (TFR)", null)]
        [NUnit.Framework.TestCaseAttribute("Notice of Final Report (NFR)", "NOTICE OF FINAL REPORT (NFR)", null)]
        public virtual void _004_UFR_TrusteeCompensation(string reportName, string headerName, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "US293872",
                    "US293911"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004-UFR-Trustee Compensation", @__tags);
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
testRunner.Given("I enter to Reports page as user UFRReports with password Welcome456Epiq! and offi" +
                    "ce Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.Given(string.Format("I Go to \'{0}\'", reportName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.Then(string.Format("verify the report header \'{0}\'", headerName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
 testRunner.Then("Enter the Trustee Compensation values and freeze the compensation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005-TFR Trustee Compensation error message validation")]
        [NUnit.Framework.CategoryAttribute("US293910")]
        public virtual void _005_TFRTrusteeCompensationErrorMessageValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005-TFR Trustee Compensation error message validation", new string[] {
                        "US293910"});
#line 100
this.ScenarioSetup(scenarioInfo);
#line 101
testRunner.Given("I enter to Reports page as user UFRReports with password Welcome456Epiq! and offi" +
                    "ce Jwalsh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 102
 testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.When("I Enter \'15-70235\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.And("I Click on the Case Result \'15-70235\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.Given("I Go to \'Trustee Final Report (TFR)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 106
 testRunner.Then("verify the report header \'Trustee Final Report (TFR)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.Then("Click on Include Claim Register button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
 testRunner.Then("I inline date fields under Case Dates section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
 testRunner.Then("user click \'GENERATE REPORT\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
 testRunner.Then("validate the Compensation Section error message as \'Case does not have a Trustee " +
                    "Compensation claim.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion