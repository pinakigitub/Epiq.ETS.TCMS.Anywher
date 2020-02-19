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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Cases.Detail.Notes
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Case Detail - Case Notes Trustees")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("DoNotExecute")]
    public partial class CaseDetail_CaseNotesTrusteesFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CaseTrusteesNotes.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Case Detail - Case Notes Trustees", "\tIn order to be able to add, review, edit, and delete notes for a case.\r\n\tAs a us" +
                    "er of Unity\r\n\tI need to have a window for Trustee Notes that is active on all sc" +
                    "reens and tied back to the case I am viewing", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("001 - Case Notes Trustees - Show Trustee Notes on Trustees Tab")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US46454")]
        [NUnit.Framework.CategoryAttribute("TC617723")]
        [NUnit.Framework.CategoryAttribute("TC61773")]
        [NUnit.Framework.TestCaseAttribute("This is a Trustee Note", "Trustee", new string[0])]
        public virtual void _001_CaseNotesTrustees_ShowTrusteeNotesOnTrusteesTab(string noteText, string noteType, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CaseDetail",
                    "CaseNotes",
                    "Sanity",
                    "US46454",
                    "TC617723",
                    "TC61773"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Case Notes Trustees - Show Trustee Notes on Trustees Tab", @__tags);
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I Open Notes Window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.And("I Go To Trustee Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.Then(string.Format("I See a Note with Text \'{0}\'", noteText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 - Case Notes Trustees - Create New Note")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US46457")]
        [NUnit.Framework.CategoryAttribute("TC72794")]
        [NUnit.Framework.CategoryAttribute("TC72798")]
        [NUnit.Framework.CategoryAttribute("TC61772")]
        public virtual void _002_CaseNotesTrustees_CreateNewNote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 - Case Notes Trustees - Create New Note", new string[] {
                        "CaseDetail",
                        "CaseNotes",
                        "Sanity",
                        "US46457",
                        "TC72794",
                        "TC72798",
                        "TC61772"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("I Create a Trustee Note with Random Text", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("I See the New Note at the Top of Notes Historical View Displaying Correct Data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003 - Case Notes Trustees - Cancel New Note")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("US46457")]
        [NUnit.Framework.CategoryAttribute("TC72799")]
        public virtual void _003_CaseNotesTrustees_CancelNewNote()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003 - Case Notes Trustees - Cancel New Note", new string[] {
                        "CaseDetail",
                        "CaseNotes",
                        "US46457",
                        "TC72799"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.When("I Open Notes Window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.And("I Go To Trustee Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("I Click on New Notes Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("I Enter a Random Text on the Notes Text Area and Click On Cancel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.Then("I See New Note Form has Dissapeared", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("I See the Canceled Note is not Present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004 - Case Notes Trustees - Save Button Becomes Active with One Character")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("US46457")]
        [NUnit.Framework.CategoryAttribute("TC72808")]
        public virtual void _004_CaseNotesTrustees_SaveButtonBecomesActiveWithOneCharacter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004 - Case Notes Trustees - Save Button Becomes Active with One Character", new string[] {
                        "CaseDetail",
                        "CaseNotes",
                        "US46457",
                        "TC72808"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("I Open Notes Window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.And("I Go To Trustee Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("I Click on New Notes Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("I See the Save Note Button is Inactive", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("I Enter \'a\' Text on the Notes Text Area", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.Then("I See the Save Note Button Is Active", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005 - Case Notes Trustees - Historical View Display and Order")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US46454")]
        [NUnit.Framework.CategoryAttribute("TC61770")]
        [NUnit.Framework.CategoryAttribute("TC61771")]
        public virtual void _005_CaseNotesTrustees_HistoricalViewDisplayAndOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005 - Case Notes Trustees - Historical View Display and Order", new string[] {
                        "CaseDetail",
                        "CaseNotes",
                        "Sanity",
                        "US46454",
                        "TC61770",
                        "TC61771"});
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.When("I Open Notes Window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
 testRunner.And("I Go To Trustee Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I See Notes With Some Data and Ordered By Edited Date on the Historical View", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006 - Case Notes Trustees - Z Read More Wrapping")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US52686")]
        [NUnit.Framework.CategoryAttribute("TC72460")]
        [NUnit.Framework.CategoryAttribute("TC72455")]
        [NUnit.Framework.CategoryAttribute("TC61774")]
        [NUnit.Framework.CategoryAttribute("Fix")]
        [NUnit.Framework.CategoryAttribute("DoNotExecute")]
        [NUnit.Framework.TestCaseAttribute(@"Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per. Ius id vidit volumus mandamus, vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei. Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit.", new string[0])]
        public virtual void _006_CaseNotesTrustees_ZReadMoreWrapping(string noteText, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CaseDetail",
                    "CaseNotes",
                    "Sanity",
                    "US52686",
                    "TC72460",
                    "TC72455",
                    "TC61774",
                    "Fix",
                    "Ignore",
                    "DoNotExecute"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006 - Case Notes Trustees - Z Read More Wrapping", @__tags);
#line 70
this.ScenarioSetup(scenarioInfo);
#line 71
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.When(string.Format("I Create A Trustee Note with Text \'{0}\'", noteText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.Then("I See the Note Displays with Wrapped Text and the Read More Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
 testRunner.And("Clicking on Read More Expands the view And Read Less Link Displays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("Clicking on Read Less Closes the Expanded View", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007 - Case Notes Trustees - Z Read More Not Sticky")]
        [NUnit.Framework.IgnoreAttribute("Ignored scenario")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US52686")]
        [NUnit.Framework.CategoryAttribute("TC72464")]
        [NUnit.Framework.CategoryAttribute("Fix")]
        [NUnit.Framework.CategoryAttribute("DoNotExecute")]
        [NUnit.Framework.TestCaseAttribute(@"Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per. Ius id vidit volumus mandamus, vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei. Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit.", new string[0])]
        public virtual void _007_CaseNotesTrustees_ZReadMoreNotSticky(string noteText, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CaseDetail",
                    "CaseNotes",
                    "Sanity",
                    "US52686",
                    "TC72464",
                    "Fix",
                    "Ignore",
                    "DoNotExecute"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007 - Case Notes Trustees - Z Read More Not Sticky", @__tags);
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 88
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When(string.Format("I Create A Trustee Note with Text \'{0}\'", noteText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.And("I See the Note Displays with Wrapped Text and the Read More Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("Clicking on Read More Expands the view And Read Less Link Displays", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.And("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("I Go To Trustee Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.Then("I See the Note Displays with Wrapped Text and the Read More Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008 - Case Notes Trustees - Edit Historical")]
        [NUnit.Framework.CategoryAttribute("CaseDetail")]
        [NUnit.Framework.CategoryAttribute("CaseNotes")]
        [NUnit.Framework.CategoryAttribute("Sanity")]
        [NUnit.Framework.CategoryAttribute("US36802")]
        [NUnit.Framework.CategoryAttribute("TC76133")]
        public virtual void _008_CaseNotesTrustees_EditHistorical()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008 - Case Notes Trustees - Edit Historical", new string[] {
                        "CaseDetail",
                        "CaseNotes",
                        "Sanity",
                        "US36802",
                        "TC76133"});
#line 105
this.ScenarioSetup(scenarioInfo);
#line 106
 testRunner.Given("I enter to 341 Meeting page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 107
 testRunner.And("I Enter to Case Detail page for Case with Case Number \'09-13569\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.When("I Edit Trustee Note with Text \'This is a Note for Edition Test\' to Have Text \'Not" +
                    "e has been edited. Need to restore it later.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion