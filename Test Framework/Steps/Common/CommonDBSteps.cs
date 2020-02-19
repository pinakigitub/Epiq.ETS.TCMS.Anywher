using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using TechTalk.SpecFlow;

using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    public class CommonDBSteps:StepBase
    {
        public static int GetConfigOfficeId()
        {
            string officeCode = ConfigurationManager.AppSettings.Get("Office");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("OfficeCode", officeCode);
            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.GetOfficeIdFromOfficeCode, parameters);
            return Convert.ToInt32(results[0].ItemArray[0]);
        }        

        [BeforeScenario("EditClaim", Order = 0)]        
        public void RestoreClaim3813ForEdition() {            
            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.CLAIMS_RESTORE_CLAIM3813_FOR_EDITION);
            TestsLogger.Log("Data on Claim 3813 from Case 1092 was restored!");
        }

        [BeforeScenario("NewClaim", Order = 0)]
        [AfterScenario("NewClaim", Order =0)]
        public void DeleteAllTestClaimsOnCase1092() {
            Dictionary <string,string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId","1092");
            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.DeleteAutomationCreatedTestClaimsFromCaseByCaseId, parameters);
            TestsLogger.Log("Deleted all claims generated on Case 1092!");
        }

        [BeforeScenario("NeedsDBClaimUpdates")]
        protected void SetClaimTestsData()
        {
            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.CLAIMS_UPDATES_AUTOMATION);
            TestsLogger.Log("Data on Claims from case '09-13569 QUALITY TIME EARLY LEARNING CENTER' with CaseId=397 modified for Claim list and summary tests!");
        }

        [AfterScenario("TransactionSaving", Order = 0)]
        private void DeleteCreatedTransactionsByCaseId()
        {
            //remove all transactions created with text "Test Automation" from the current Case            
            string casenbr = ScenarioContext.Current.Get<string>("Case Number");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("CaseId", Convert.ToString(CaseDetailSteps.GetCaseIdFromCaseNumber(casenbr)));

            DataRowCollection rows = ExecuteQueryOnDB(Properties.Resources.DeleteAutomationCreatedTransactionsByCaseId, parameters);
            TestsLogger.Log("Removed all transactions created with text 'Test Automation' from Case with Caseid=" + casenbr);
        }

        [AfterScenario("AddNewParticipant", Order = 5)]
        public void DeleteCreatedParticipant()
        {
            string expectedParticipantName = ScenarioContext.Current.Get<string>("Participant Description");
            string casenbr = ScenarioContext.Current.Get<string>("Case Number");

            //Get all participants created for automated tests and remove them
            Dictionary<string, string> parameters = new Dictionary<string, string>();            
            parameters.Add("ParticipantNameLike", expectedParticipantName);
            DataRowCollection results = ExecuteQueryOnDB(Properties.Resources.DeleteAutomationCreatedTestParticipantsByName, parameters);
            TestsLogger.Log("Deleted all Created Participants generated on Case "+casenbr+" with Name like '"+expectedParticipantName+"'");
        }

        [BeforeScenario("TemplateNotes", Order = 10)]
        public void CreateANoteTemplateOnDBWithLabelAndText()
        {
            //Delete old note templates, in case AfterScenario method didn't execute
            DeleteTemplateFromDB();

            //Note 1: Test Automation Note Template | This is note template for automated testing            
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("NoteLabel", "Test Automation Note Template");
            parameters.Add("NoteText", "This is note template for automated testing");
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));
            DataRowCollection insertResult = ExecuteQueryOnDB(Properties.Resources.InsertNoteTemplate, parameters);
            TestsLogger.Log("CREATED 'Test Automation Note Template' template note on DB");

            //Note 2: LONG Test Automation Note Template | This is long note template for automated testing purposes, it shuld work as well as a short note does
            parameters.Remove("NoteLabel");
            parameters.Remove("NoteText");
            parameters.Add("NoteLabel", "Test Automation LONG Note Template");
            parameters.Add("NoteText", "This is long note template for automated testing purposes, it shuld work as well as a short note does");
            insertResult = ExecuteQueryOnDB(Properties.Resources.InsertNoteTemplate, parameters);
            TestsLogger.Log("CREATED 'Test Automation LONG Note Template' template note on DB");
        }

        [AfterScenario("TemplateNotes")]
        public void DeleteTemplateFromDB()
        {
            //Note 1: Test Automation Note Template | This is note template for automated testing            
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("NoteLabel", "Test Automation Note Template");
            parameters.Add("NoteText", "This is note template for automated testing");
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));
            DataRowCollection insertResult = ExecuteQueryOnDB(Properties.Resources.DeleteNoteTemplate, parameters);
            TestsLogger.Log("DELETED 'Test Automation Note Template' template note on DB");

            //Note 2: LONG Test Automation Note Template | This is long note template for automated testing purposes, it shuld work as well as a short note does
            parameters.Remove("NoteLabel");
            parameters.Remove("NoteText");
            parameters.Add("NoteLabel", "Test Automation LONG Note Template");
            parameters.Add("NoteText", "This is long note template for automated testing purposes, it shuld work as well as a short note does");
            insertResult = ExecuteQueryOnDB(Properties.Resources.DeleteNoteTemplate, parameters);
            TestsLogger.Log("DELETED 'Test Automation LONG Note Template' template note on DB");
        }

        [BeforeScenario("DeleteSuperadmin", Order = 10)]
        [AfterScenario("DeleteSuperadmin", Order = 5)]
        public void DeleteCreatedAssetsDocketsAndDocumentsFromDB()
        {
            //Delete assets, dockets and documents that could have been created by superadmin tests
            //This is necessaary when delete does not work on the UI to remove all created data after the test fails
            string itemNames = "for Super Admin Test Automation";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("OfficeCode", ConfigurationManager.AppSettings.Get("Office"));
            parameters.Add("ItemsNameLike", itemNames);
            ExecuteQueryOnDB(Properties.Resources.Delete_AssetsDocketsAndDocumentsByName, parameters);
            TestsLogger.Log("DELETED created itemss for Test Automation of superadmin");
        }
    }
}
