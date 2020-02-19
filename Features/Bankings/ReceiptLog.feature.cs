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
namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Features.Bankings
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("ReceiptLog")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class ReceiptLogFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ReceiptLog.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ReceiptLog", "     In order to manage Receipts(Void,Verify,Deposit) in the RECEIPT LOG", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("001 - Closing Cost - Add Closing Cost Modal Default Display and verify")]
        [NUnit.Framework.CategoryAttribute("US#207984")]
        public virtual void _001_ClosingCost_AddClosingCostModalDefaultDisplayAndVerify()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001 - Closing Cost - Add Closing Cost Modal Default Display and verify", new string[] {
                        "US#207984"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
       testRunner.And("I select trasaction \'not void\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
       testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
       testRunner.Then("Closing Cost table should display with Unlinked Transaction", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
       testRunner.When("I select closing costs button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
       testRunner.Then("Closing Cost Modal should display default", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
    testRunner.When("I close add closing cost modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002 -  Closing Cost - CLOSING COST TYPE Field")]
        public virtual void _002_ClosingCost_CLOSINGCOSTTYPEField()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002 -  Closing Cost - CLOSING COST TYPE Field", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
    testRunner.When("I Select the PageSize as 50 under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
    testRunner.Then("I Select transaction Received from \'Sushma\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
       testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
       testRunner.And("I select closing costs button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
       testRunner.Then("Claims sholud be in ascending order", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
       testRunner.When("I enter \'FARID AHMED\' in search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
       testRunner.Then("\'FARID AHMED\' should be displayed in closing costs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
       testRunner.When("I enter \'invalidData\' in search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
       testRunner.Then("\'No result found...\' should be displayed in closing costs(Claim)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
       testRunner.When("I close add closing cost modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003 -  Closing Cost - Non-Claim All Fields")]
        public virtual void _003_ClosingCost_Non_ClaimAllFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003 -  Closing Cost - Non-Claim All Fields", ((string[])(null)));
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
    testRunner.When("I Select the PageSize as 50 under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
    testRunner.Then("I Select transaction Received from \'Sushma\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
       testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
       testRunner.And("I select closing costs Non-Claim button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
       testRunner.When("I Enter All Feilds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
       testRunner.Then("Asterisk should not display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
       testRunner.When("I Clear All Fields", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
       testRunner.Then("All Fields should Empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
       testRunner.When("I close add closing cost modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004_ ReceiptLog - CreateReceiptLog")]
        public virtual void _004_ReceiptLog_CreateReceiptLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004_ ReceiptLog - CreateReceiptLog", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
       testRunner.And("I Click on Add Receipt", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
       testRunner.And("I enter CaseNum \'17-00001\', Recieved From \'Sushma\', Bank Received \'01/21/18\', Add" +
                    "ress \'Banjara Hills\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
       testRunner.And("I enter Amount \'10\', CheckNum \'123456\', CheckDate \'02/15/18\' and CheckReceived \'0" +
                    "2/10/18\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
       testRunner.And("I enter Transaction Details Description \'QA Testing\', Notes \'Creating New Receipt" +
                    " log Page \' and UTC \'Other Litigation\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
       testRunner.Then("I \'SAVE\' the Receipt Log", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005_ReceiptLog - Create a Deposit and Link Asset for saved ReceiptLog")]
        [NUnit.Framework.CategoryAttribute("US#259313")]
        [NUnit.Framework.CategoryAttribute("US#259369")]
        public virtual void _005_ReceiptLog_CreateADepositAndLinkAssetForSavedReceiptLog()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005_ReceiptLog - Create a Deposit and Link Asset for saved ReceiptLog", new string[] {
                        "US#259313",
                        "US#259369"});
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
       testRunner.When("I click on filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
    testRunner.And("I select Linked \'No\' in Filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
       testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
    testRunner.When("I Select the PageSize as 50 under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
       testRunner.Then("I Select transaction Received from \'Subbu\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
    testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
       testRunner.Then("I input \'NAME-Nagarjuna;DESCRIPTION-Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
       testRunner.And("I Click Link Asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
       testRunner.And("I select Asset \'Well Fargo Savings A/C\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
    testRunner.And("I click on button ADD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
       testRunner.And("I click on button SAVE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
       testRunner.When("I click on filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
    testRunner.And("I select Linked \'Yes\' in Filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
       testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
    testRunner.Then("I Edit transaction Received from \'Subbu\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
       testRunner.And("I click \'UNLINK TRANSACTION\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
       testRunner.And("I click on button SAVE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006 - Closing Cost - Validate Add and Cancel")]
        public virtual void _006_ClosingCost_ValidateAddAndCancel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006 - Closing Cost - Validate Add and Cancel", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
    testRunner.When("I Select the PageSize as 50 under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
       testRunner.Then("I Select transaction Received from \'Sushma\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
       testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
       testRunner.And("I select closing costs Non-Claim button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
       testRunner.Then("Add Deposit page should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
       testRunner.When("I Enter All Feilds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
       testRunner.Then("Asterisk should not display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
       testRunner.When("I Click on ADD in Add Closing Cost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
       testRunner.Then("Added Claim Should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
       testRunner.When("I Click on X in the Closing cost", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
       testRunner.Then("Closing Cost Should Removed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
       testRunner.When("I select closing costs button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
       testRunner.And("I close add closing cost modal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
    testRunner.Then("\'Account ManagementAdd Deposit\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
       testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007_ReceiptLog - Edit a Deposit and Link Non- Closing cost claim")]
        [NUnit.Framework.CategoryAttribute("US#259314")]
        [NUnit.Framework.CategoryAttribute("US#259313")]
        [NUnit.Framework.CategoryAttribute("US#266860")]
        [NUnit.Framework.CategoryAttribute("US#259369")]
        public virtual void _007_ReceiptLog_EditADepositAndLinkNon_ClosingCostClaim()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007_ReceiptLog - Edit a Deposit and Link Non- Closing cost claim", new string[] {
                        "US#259314",
                        "US#259313",
                        "US#266860",
                        "US#259369"});
#line 112
this.ScenarioSetup(scenarioInfo);
#line 113
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 114
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
       testRunner.When("I click on filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
       testRunner.And("I select Linked \'No\' in Filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
       testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
    testRunner.When("I Select the PageSize as 50 under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
       testRunner.Then("I Select transaction Received from \'Sushma\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
    testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
       testRunner.Then("I input \'NAME-Subhash;DESCRIPTION-Testing;UTC CODE-1142 Personal Injury Litigatio" +
                    "n\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
       testRunner.And("I Click Link Asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
       testRunner.And("I select Asset \'Well Fargo Savings A/C\'                        \'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
       testRunner.And("I click on button ADD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
       testRunner.And("I click on button CLOSING COST(NON-CLAIM)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
    testRunner.And("I click on button CANCEL", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
       testRunner.And("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008-Permit Asset Imbalance on Deposit")]
        [NUnit.Framework.CategoryAttribute("US#259316")]
        public virtual void _008_PermitAssetImbalanceOnDeposit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008-Permit Asset Imbalance on Deposit", new string[] {
                        "US#259316"});
#line 131
this.ScenarioSetup(scenarioInfo);
#line 132
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 133
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
    testRunner.Then("I Select transaction Received from \'Sushma\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
    testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
    testRunner.Then("I input \'NAME-Nick;DESCRIPTION-Testing\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
    testRunner.And("I enter Net Amount \'200.00\' and Gross Amount \'300.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 138
    testRunner.And("I Click Link Asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
       testRunner.And("I select Asset \'Well Fargo Savings A/C\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
       testRunner.And("I click on button ADD", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
    testRunner.And("I select PERMIT ASSET IMBALANCE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("009_ReceiptLog - Create a Deposit and Link Asset with updated titles")]
        [NUnit.Framework.CategoryAttribute("US#259369")]
        public virtual void _009_ReceiptLog_CreateADepositAndLinkAssetWithUpdatedTitles()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("009_ReceiptLog - Create a Deposit and Link Asset with updated titles", new string[] {
                        "US#259369"});
#line 145
this.ScenarioSetup(scenarioInfo);
#line 146
       testRunner.Given("I enter to Banking ReceiptLog page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
       testRunner.Then("Receipts page should be opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 148
    testRunner.When("I click on filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 149
       testRunner.And("I select Linked \'No\' in Filter", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
       testRunner.Then("I Click on Close Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
    testRunner.When("I Select the PageSize as 50 under Pagination Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
       testRunner.Then("I Select transaction Received from \'Subbu\' in Receipt Log page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 153
    testRunner.When("I click on deposit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
       testRunner.Then("I input \'RECEIVED FROM-Nagarjuna;DESCRIPTION-Testing;UTC CODE-1142 Personal Injur" +
                    "y Litigation\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 155
       testRunner.And("I Click on AssetLinks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
    testRunner.And("I Click on ClosingCostLinks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
    testRunner.And("I Click on Unlinked Allocations", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 158
    testRunner.And("I click on ClaimLinks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
       testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
