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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Documents
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Documents")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    [NUnit.Framework.CategoryAttribute("FailureCases")]
    public partial class DocumentsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Documents.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Documents", "Navigating to the different sections \r\nunder Documents page", ProgrammingLanguage.CSharp, new string[] {
                        "Regression",
                        "ReactJS",
                        "FailureCases"});
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
        [NUnit.Framework.DescriptionAttribute("001 - Cases- Documents page verification")]
        [NUnit.Framework.CategoryAttribute("CasesTab")]
        public virtual void _001_Cases_DocumentsPageVerification()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Cases- Documents page verification", new string[] {
                        "CasesTab"});
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 testRunner.Then("\'Document Management\' header should be displayed on Document Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
 testRunner.When("I click on Filter on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("Documents \'FILTER OPTIONS\' should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.When("I click on close on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("Documents \'FILTER OPTIONS\' should be closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003 - Cases- Documents Expand row for more columns")]
        public virtual void _003_Cases_DocumentsExpandRowForMoreColumns()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003 - Cases- Documents Expand row for more columns", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
   testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
   testRunner.When("I click on Row Expand button on Document page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I should be able to see column CASE STATUS", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
 testRunner.Then("I should  be able to see column CASE #", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.Then("I should  be able to see column CURRENT 341 DATE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
 testRunner.Then("I should  be able to see column HISTORY", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004 - Cases- Documents Filter Options Validation")]
        public virtual void _004_Cases_DocumentsFilterOptionsValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004 - Cases- Documents Filter Options Validation", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
   testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
   testRunner.When("I click on Filter on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
   testRunner.And("I select CaseStatus \'Open\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
   testRunner.And("I click on close on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.Then("Document records should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
   testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005 - Cases- Documents- Filter search and clear validation")]
        public virtual void _005_Cases_Documents_FilterSearchAndClearValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005 - Cases- Documents- Filter search and clear validation", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.When("I click on Filter on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.And("I select Tag \'341 Meeting\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
    testRunner.And("I click on close on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.Then("Document result should contain Tag \'341 Meeting\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.When("I click on Filter on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.And("I click on reset button of documents filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.Then("default Documents result should be present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006 - Cases- Documents- Filter dropdown X validation")]
        public virtual void _006_Cases_Documents_FilterDropdownXValidation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006 - Cases- Documents- Filter dropdown X validation", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.When("I click on Filter on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
 testRunner.And("I click on X button of case Status dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.Then("case status filter value should be All", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
 testRunner.When("I click on close on Documents page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008_Documents - Verify PageSize under Pagination")]
        [NUnit.Framework.CategoryAttribute("229001")]
        [NUnit.Framework.TestCaseAttribute("10", null)]
        [NUnit.Framework.TestCaseAttribute("25", null)]
        [NUnit.Framework.TestCaseAttribute("50", null)]
        [NUnit.Framework.TestCaseAttribute("100", null)]
        public virtual void _008_Documents_VerifyPageSizeUnderPagination(string pageSize, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "229001"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008_Documents - Verify PageSize under Pagination", @__tags);
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.When(string.Format("I Select the PageSize as {0} under Pagination Section", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.And(string.Format("I see the CaseList Table Contains the Same Number of Rows as per Selected {0}", pageSize), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009_Documents-Add Tags- Verify Tags as Multiple")]
        [NUnit.Framework.CategoryAttribute("229001")]
        public virtual void _009_Documents_AddTags_VerifyTagsAsMultiple()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009_Documents-Add Tags- Verify Tags as Multiple", new string[] {
                        "229001"});
#line 102
this.ScenarioSetup(scenarioInfo);
#line 103
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 104
 testRunner.And("I click on filter search Icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.When("I enter Description \'Automation.pdf\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
 testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
 testRunner.And("I Edit Tags and Description \'Automation.pdf\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
 testRunner.And("I Add Tags \'341 Meeting\', \'Batch Tag QA Test\' and \'test\' to that Case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
 testRunner.And("I save the Added tags", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("010_Documents- Documents View Permission")]
        [NUnit.Framework.CategoryAttribute("229001")]
        public virtual void _010_Documents_DocumentsViewPermission()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("010_Documents- Documents View Permission", new string[] {
                        "229001"});
#line 118
this.ScenarioSetup(scenarioInfo);
#line 119
 testRunner.Given("I enter to Documents page as user Manaswi3 with password Welcome123Epiq! and offi" +
                    "ce crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 120
 testRunner.Then("I see the Security Warning Icon in Orange", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.And("Security Warning msg as \'Please contact your Office Administrator and request per" +
                    "mission to view this content. You are missing one of the following permissions: " +
                    "Document View\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.When("I see the text \'Contact Office Administrator\' and Select Administrator \'AutoTest1" +
                    "\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
 testRunner.Then("an Email \'QA@auot.com\' and Admin Name \'AutoTest1\' are Populated below", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("011_Documents-In Line Edit")]
        public virtual void _011_Documents_InLineEdit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("011_Documents-In Line Edit", ((string[])(null)));
#line 126
this.ScenarioSetup(scenarioInfo);
#line 127
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 128
 testRunner.When("I Click on Description button on Documents Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
 testRunner.Then("I Sould be able to edit description in line", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.When("I Click on Tag button on Documents Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
 testRunner.Then("I Sould be able to edit Tag in line - \'341 Meeting\' or Blank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
 testRunner.When("I click on Row Expand button on Document page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 135
 testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("012_Documents-Validation for View only")]
        [NUnit.Framework.CategoryAttribute("US195065")]
        public virtual void _012_Documents_ValidationForViewOnly()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("012_Documents-Validation for View only", new string[] {
                        "US195065"});
#line 138
this.ScenarioSetup(scenarioInfo);
#line 139
 testRunner.Given("I enter to Documents page as user AutomationView with password Welcome456Epiq! an" +
                    "d office crose", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 140
 testRunner.Then("I see eye button for all records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.When("I clik on Eye Button of Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 142
 testRunner.Then("I should not be able to edit the documents details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 143
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("013_Documents-Validation for Edit Document")]
        [NUnit.Framework.CategoryAttribute("US195065")]
        public virtual void _013_Documents_ValidationForEditDocument()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("013_Documents-Validation for Edit Document", new string[] {
                        "US195065"});
#line 146
this.ScenarioSetup(scenarioInfo);
#line 147
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
 testRunner.Then("I see edit-pencil button for all records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
 testRunner.When("I clik on pencil Button of Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
 testRunner.Then("I should be able to edit the documents details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("014_Documents-Edit Pencil -Validate Editing of the Document")]
        [NUnit.Framework.CategoryAttribute("US235433")]
        public virtual void _014_Documents_EditPencil_ValidateEditingOfTheDocument()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("014_Documents-Edit Pencil -Validate Editing of the Document", new string[] {
                        "US235433"});
#line 154
this.ScenarioSetup(scenarioInfo);
#line 155
 testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
 testRunner.Then("I see edit-pencil button for all records", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
 testRunner.When("I clik on pencil Button of Document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
 testRunner.And("I Click on Header of Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.When("I click on File Name button on Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
   testRunner.Then("Should be able to edit File Name in line", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
 testRunner.When("I click on Description button on Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 162
   testRunner.Then("I Should be able to edit Description in line on Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
 testRunner.When("I click on Assigned To button on Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 164
  testRunner.Then("I Should be able to edit Assigned To in line on Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
 testRunner.When("I click on TAG button on Document Viewer Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
   testRunner.Then("I Sould be able to edit Tag in line - \'341 Meeting\' or Blank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
 testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("015 - Dcouments Page-Delete funtionality verification in Dcouments page")]
        [NUnit.Framework.CategoryAttribute("US256012")]
        public virtual void _015_DcoumentsPage_DeleteFuntionalityVerificationInDcoumentsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("015 - Dcouments Page-Delete funtionality verification in Dcouments page", new string[] {
                        "US256012"});
#line 173
this.ScenarioSetup(scenarioInfo);
#line 174
  testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 175
  testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
  testRunner.When("I Enter \'17-90000\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
  testRunner.And("I Click on the Case Result \'17-90000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
  testRunner.And("I can select all option in the header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
  testRunner.And("I can Deselect all option in the header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
     testRunner.And("I can select first record in dso page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 181
  testRunner.Then("I can click on delete button in the Dcouments Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
  testRunner.Then("verify the Text in the pop up as \'Confirm deletion of selected documents.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
  testRunner.And("I click on Delete button in pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 184
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("016 - Dcouments Page-Delete funtionality verification in Dcouments page with out " +
            "selecting the record")]
        [NUnit.Framework.CategoryAttribute("US256012")]
        public virtual void _016_DcoumentsPage_DeleteFuntionalityVerificationInDcoumentsPageWithOutSelectingTheRecord()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("016 - Dcouments Page-Delete funtionality verification in Dcouments page with out " +
                    "selecting the record", new string[] {
                        "US256012"});
#line 187
this.ScenarioSetup(scenarioInfo);
#line 188
  testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 189
  testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
  testRunner.When("I Enter \'17-90000\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 191
  testRunner.And("I Click on the Case Result \'17-90000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 192
  testRunner.And("I can see delete button is not clickcable until select the case", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("017 - Dcouments Page-Cancel funtionality verification in Dcouments page")]
        [NUnit.Framework.CategoryAttribute("US256012")]
        public virtual void _017_DcoumentsPage_CancelFuntionalityVerificationInDcoumentsPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("017 - Dcouments Page-Cancel funtionality verification in Dcouments page", new string[] {
                        "US256012"});
#line 196
this.ScenarioSetup(scenarioInfo);
#line 197
  testRunner.Given("I enter to Documents page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 198
  testRunner.And("I see the Search box under All Cases Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 199
  testRunner.When("I Enter \'17-90000\' On The Universal Search Section Input", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 200
  testRunner.And("I Click on the Case Result \'17-90000\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 201
     testRunner.And("I can select first record in dso page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 202
  testRunner.Then("I can click on delete button in the Dcouments Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 203
  testRunner.Then("verify the Text in the pop up as \'Confirm deletion of selected documents.\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 204
  testRunner.And("I click on Cancel button in pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 205
  testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
