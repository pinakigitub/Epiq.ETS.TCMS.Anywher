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
    [NUnit.Framework.DescriptionAttribute("CheckCreation")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    [NUnit.Framework.CategoryAttribute("ReactJS")]
    public partial class CheckCreationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CheckCreation.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CheckCreation", "In order to create CHECK", ProgrammingLanguage.CSharp, new string[] {
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
#line 7
#line 8
testRunner.Given("I enter to Bank Accounts page as superuser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("001-Check Creation- Existing Payee")]
        [NUnit.Framework.CategoryAttribute("US208612")]
        public virtual void _001_CheckCreation_ExistingPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("001-Check Creation- Existing Payee", new string[] {
                        "US208612"});
#line 11
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 14
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
   testRunner.Then("I Filter with Account No \'9000074143\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
   testRunner.Then("\'Bank AccountsAccount Management\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
   testRunner.When("I select \'Existing Payee\' type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
   testRunner.Then("Input \'LOUIS\' and select debtorname \'2956 TestRecon, KNRAJ\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
   testRunner.Then("Input Description \'DATECHANGE\' Distribution Type \'Other Payment To Creditor\' Rema" +
                    "rks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("002- Linking claims to Check-Existing Payee")]
        [NUnit.Framework.CategoryAttribute("US208612")]
        [NUnit.Framework.CategoryAttribute("US264019")]
        public virtual void _002_LinkingClaimsToCheck_ExistingPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("002- Linking claims to Check-Existing Payee", new string[] {
                        "US208612",
                        "US264019"});
#line 30
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 33
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
   testRunner.Then("I Filter with Account No \'9000074143\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
   testRunner.Then("Input \'LOUIS\' and select debtorname \'2956 TestRecon, KNRAJ\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
   testRunner.Then("Input Description \'DATECHANGE\' Distribution Type \'Other Payment To Creditor\' Rema" +
                    "rks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
   testRunner.When("I click Link Claim \'LINK CLAIM\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
   testRunner.Then("Select any claim and Add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("003-Split Utc Check Creation- when no claims linked with Existing Payee")]
        [NUnit.Framework.CategoryAttribute("US208744")]
        public virtual void _003_SplitUtcCheckCreation_WhenNoClaimsLinkedWithExistingPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("003-Split Utc Check Creation- when no claims linked with Existing Payee", new string[] {
                        "US208744"});
#line 49
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 52
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
   testRunner.Then("I Filter with Account No \'9000074119\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
   testRunner.Then("Input \'LOUIS\' and select debtorname \'2956 TestRecon, KNRAJ\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
   testRunner.Then("Input Description \'Regression\' Distribution Type \'Other Payment To Creditor\' Rema" +
                    "rks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
   testRunner.Then("Verify the message displayed \'No Claims Linked\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
   testRunner.When("I click Link Claim \'UNLINKED ALLOCATION (UTC)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
   testRunner.Then("Input UTC split fields information for row \'0\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
   testRunner.Then("I click button \'ADD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("004-Split Utc Check Creation-when claims already linked with Existing Payee")]
        [NUnit.Framework.CategoryAttribute("US208744")]
        public virtual void _004_SplitUtcCheckCreation_WhenClaimsAlreadyLinkedWithExistingPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("004-Split Utc Check Creation-when claims already linked with Existing Payee", new string[] {
                        "US208744"});
#line 70
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 73
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
   testRunner.Then("I Filter with Account No \'9000074119\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
   testRunner.Then("Input \'LOUIS\' and select debtorname \'2956 TestRecon, KNRAJ\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
   testRunner.Then("Input Description \'RegressionTEST\' Distribution Type \'Other Payment To Creditor\' " +
                    "Remarks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
   testRunner.When("I click Link Claim \'LINK CLAIM\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
   testRunner.Then("Select any claim and Add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
   testRunner.When("I click Link Claim \'UNLINKED ALLOCATION (UTC)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
   testRunner.Then("Input UTC split fields information for row \'0\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'100\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
   testRunner.Then("I select Non Compensable as \'YES\' for row \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
   testRunner.Then("I click button \'ADD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("005-Split Utc Check Creation-when claims already linked with New Payee")]
        [NUnit.Framework.CategoryAttribute("US255988")]
        [NUnit.Framework.CategoryAttribute("US247566")]
        public virtual void _005_SplitUtcCheckCreation_WhenClaimsAlreadyLinkedWithNewPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("005-Split Utc Check Creation-when claims already linked with New Payee", new string[] {
                        "US255988",
                        "US247566"});
#line 93
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 96
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
   testRunner.Then("I Filter with Account No \'9000074119\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
   testRunner.When("I select \'New Payee\' type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
   testRunner.When("I select \'Individual\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
   testRunner.Then("I input Debtor title as \'Miss\' for \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
   testRunner.Then("Input \'payee\' Debtor Firstname as \'Paul\' and MiddleName as \'Kristy\' and Lastname " +
                    "as \'BRAIN\' for Individual", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
   testRunner.Then("Input Description \'RegressionTEST\' Distribution Type \'Other Payment To Creditor\' " +
                    "Remarks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
   testRunner.When("I click Link Claim \'LINK CLAIM\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
   testRunner.Then("Select any claim and Add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
   testRunner.When("I click Link Claim \'UNLINKED ALLOCATION (UTC)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
   testRunner.Then("Input UTC split fields information for row \'0\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
  testRunner.Then("I select Non Compensable as \'YES\' for row \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
   testRunner.Then("I click button \'ADD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("006-Split Utc Check Creation-When add multiple line items in Split Utc with Exist" +
            "ing Payee")]
        [NUnit.Framework.CategoryAttribute("US208744")]
        public virtual void _006_SplitUtcCheckCreation_WhenAddMultipleLineItemsInSplitUtcWithExistingPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("006-Split Utc Check Creation-When add multiple line items in Split Utc with Exist" +
                    "ing Payee", new string[] {
                        "US208744"});
#line 119
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 122
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
   testRunner.Then("I Filter with Account No \'9000074119\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
   testRunner.Then("Input \'LOUIS\' and select debtorname \'2956 TestRecon, KNRAJ\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
   testRunner.Then("Input Description \'Regressionlinks\' Distribution Type \'Other Payment To Creditor\'" +
                    " Remarks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
   testRunner.Then("Verify the message displayed \'No Claims Linked\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
   testRunner.When("I click Link Claim \'UNLINKED ALLOCATION (UTC)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
   testRunner.Then("Input UTC split fields information for row \'0\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
   testRunner.Then("I select Non Compensable as \'YES\' for row \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
   testRunner.Then("I click Add Line Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
   testRunner.Then("Input UTC split fields information for row \'1\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'100\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
   testRunner.Then("I select Non Compensable as \'YES\' for row \'2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
   testRunner.Then("I click button \'ADD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("007-Split Utc Check Creation-When add multiple line items in Split Utc with New P" +
            "ayee")]
        [NUnit.Framework.CategoryAttribute("US255988")]
        [NUnit.Framework.CategoryAttribute("US247566")]
        public virtual void _007_SplitUtcCheckCreation_WhenAddMultipleLineItemsInSplitUtcWithNewPayee()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("007-Split Utc Check Creation-When add multiple line items in Split Utc with New P" +
                    "ayee", new string[] {
                        "US255988",
                        "US247566"});
#line 144
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 147
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
   testRunner.Then("I Filter with Account No \'9000074119\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 153
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
   testRunner.When("I select \'New Payee\' type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 155
   testRunner.When("I select \'Corporation\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
   testRunner.When("I input \'payee\' Payee displayname as \'paul\' for Corporation", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
   testRunner.Then("Input Description \'Regressionlinks\' Distribution Type \'Other Payment To Creditor\'" +
                    " Remarks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 158
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 159
   testRunner.Then("Verify the message displayed \'No Claims Linked\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
   testRunner.When("I click Link Claim \'UNLINKED ALLOCATION (UTC)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 161
   testRunner.Then("Input UTC split fields information for row \'0\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 162
  testRunner.Then("I select Non Compensable as \'YES\' for row \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 163
   testRunner.Then("I click Add Line Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
   testRunner.Then("Input UTC split fields information for row \'1\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'100\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
   testRunner.Then("I select Non Compensable as \'YES\' for row \'2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 166
   testRunner.Then("I click button \'ADD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 167
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("008-Split Utc Check Creation-Cancel the Split Utc Creation after adding Line Item" +
            "s")]
        [NUnit.Framework.CategoryAttribute("US208744")]
        public virtual void _008_SplitUtcCheckCreation_CancelTheSplitUtcCreationAfterAddingLineItems()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("008-Split Utc Check Creation-Cancel the Split Utc Creation after adding Line Item" +
                    "s", new string[] {
                        "US208744"});
#line 172
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 174
   testRunner.When("I click filter icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
   testRunner.Then("I Filter with Account No \'9000074119\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
   testRunner.When("I Close Filter pop up I should see data on grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
   testRunner.When("I click on Account # on Grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 178
   testRunner.When("I Click on Create Check Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
   testRunner.Then("\'Account ManagementWrite Check\' Breadcrumb should display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 180
   testRunner.Then("I input Clear Date as \'01/20/19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 181
   testRunner.Then("Input \'LOUIS\' and select debtorname \'2956 TestRecon, KNRAJ\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 182
   testRunner.Then("Input Description \'Regressionlinks\' Distribution Type \'Other Payment To Creditor\'" +
                    " Remarks \'CREATION OF CHECK\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 183
   testRunner.Then("I Input amount as \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 184
   testRunner.Then("Verify the message displayed \'No Claims Linked\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 185
   testRunner.When("I click Link Claim \'UNLINKED ALLOCATION (UTC)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 186
   testRunner.Then("Input UTC split fields information for row \'0\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 187
   testRunner.Then("I select Non Compensable as \'YES\' for row \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 188
   testRunner.Then("I click Add Line Item", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 189
   testRunner.Then("Input UTC split fields information for row \'1\',\'SAMPLE\',\'SAMPLE\',\'8100 Exemptions" +
                    "\',\'100\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 190
   testRunner.Then("I select Non Compensable as \'YES\' for row \'2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 191
   testRunner.Then("I click button \'CANCEL\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 192
   testRunner.When("I save the Check", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 193
   testRunner.Then("I SignOut from the Unity Application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
