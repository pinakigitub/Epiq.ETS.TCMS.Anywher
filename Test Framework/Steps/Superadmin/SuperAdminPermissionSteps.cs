using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Core;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Superadmin
{
    [Binding]
    public class SuperAdminPermissionSteps: SignedInUnityUserSteps
    {
        DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));

        [Given(@"I Can see Super Admin link")]
        [When(@"I Can see Super Admin link")]
        [Then(@"I Can see Super Admin link")]
        public void GivenICanSeeSuperAdminLink()
        {
            dashboardPage.NavigationBar.IsSuperAdminLinkVisible().Should().BeTrue("Super Admin link is visible");
        }
       
        
        [Given(@"I Navigate to Super Admin page")]
        [When(@"I Navigate to Super Admin page")]
        [Then(@"I Navigate to Super Admin page")]
        public void WhenINavigateToSuperAdminPage()
        {
            SetSharedPageObjectInCurrentContext("Super Admin", dashboardPage.NavigationBar.GoToSuperAdminPage());
        }
        
        [Given(@"I Search for a Case to add Items that will be deleted")]
        [When(@"I Search for a Case to add Items that will be deleted")]
        [Then(@"I Search for a Case to add Items that will be deleted")]
        public void WhenISearchForACaseWithMultipleAssetsToDelete()
        {
            //get a case from DB to work with           
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));            
            DataRow coreCaseNumber = ExecuteQueryOnDB(Properties.Resources.GetACoreCaseNumberForThisOffice, parameters)[0];
            string caseNbr = coreCaseNumber.Field<string>("CoreCaseNumber");

            //search for the case on Super Admin search tool
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            superadmin.UniversalSearch.EnterTextForSearch(caseNbr);
            superadmin.UniversalSearch.ClickOnCaseResultByCaseNumberOnSupreadmin(caseNbr);

            //Save Case number on Scenario
            AddDataToScenarioContextOverridingExistentKey("Case Number", caseNbr);            
        }
        
        [When(@"I replace the URL with Super Admin link")]
        public void WhenIReplaceTheURLWithSuperAdminLink()
        {
            var portalURL = ConfigurationManager.AppSettings.Get("PortalURL");
            dashboardPage.ForceToLoadURL(portalURL.Replace("/login","")+"/superadmin");
        }

        [Then(@"I See Super Admin page with correct layout")]
        public void ThenISeeSuperAdminPageWithCorrectLayout()
        {
            string expOffice = ConfigurationManager.AppSettings.Get("Office");
            string expCaseNbr = ScenarioContext.Current.Get<string>("Case Number");
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("OfficeId", Convert.ToString(CommonDBSteps.GetConfigOfficeId()));
            parameters.Add("CoreCaseNumber",expCaseNbr);
            DataRow caseInfo = ExecuteQueryOnDB(Properties.Resources.GetCaseDetailSPByCoreCaseNumber, parameters)[0];
            string expCaseName = caseInfo.Field<string>("CaseName");

            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));

            superadmin.OfficeInfo.Should().Be("OFFICE: "+ expOffice.ToUpper(), "Office info is correct");
            superadmin.CaseInfo.Should().Be(expCaseNbr + " " + expCaseName, "Case info is correct");
            superadmin.AssetsButtonText.Should().Be("Asset","Assets button is present and correct");
            superadmin.DocketsButtonText.Should().Be("Docket", "Dockets button is present and correct");
            superadmin.DocumentsButtonText.Should().Be("Document", "Documents button is present and correct");            
        }

        [Then(@"I Cannot see Super Admin link")]
        public void ThenICannotSeeSuperAdminLink()
        {
            dashboardPage.NavigationBar.IsSuperAdminLinkInvisible().Should().BeTrue("Super Admin link is NOT visible");
        }

        [Then(@"I Cannot see Super Admin page")]
        public void ThenICannotSeeSuperAdminPage()
        {
            dashboardPage.Title.Should().NotContain("Super Admin", "Super Admin page is not accesible via URL when user has no permission");
        }

        [Then(@"I See Unauthorized Access Message reading '(.*)'")]
        public void ThenISeeUnauthorizedMessageReading(string expMessage)
        {
            dashboardPage.UnauthorizedErrorMessage.Should().Be(expMessage, "Unauthorized message displays for non super admin user when trying to load super admin page via URL");
        }

        [Given(@"I Add '(.*)' Items of type '(.*)' in the Case on database")]
        public void GivenIAddItemsInTheCaseOnDatabase(int count, string itemType)
        {
            string caseNumber = ScenarioContext.Current.Get<string>("Case Number");
            List<string> createdItems = new List<string>();

            Dictionary<string, string> parameters = new Dictionary<string, string>();            
            parameters.Add("OfficeCode", ConfigurationManager.AppSettings.Get("Office"));
            parameters.Add("CoreCaseNumber", caseNumber);

            for (int i = 1; i <= count; i++)
            {
                //define a name for the item
                string itemName = itemType + " for Super Admin Test Automation " + i;
                if (itemType == "Document")
                    itemName += ".pdf";

                if (parameters.ContainsKey("ItemName"))
                    parameters.Remove("ItemName");

                parameters.Add("ItemName", itemName);

                //Create item on DB
                switch (itemType)
                {
                    case "Asset":
                        ExecuteQueryOnDB(Properties.Resources.Create_Asset, parameters);
                        break;
                    case "Docket":
                        ExecuteQueryOnDB(Properties.Resources.Create_Docket, parameters);
                        break;
                    case "Document":
                        ExecuteQueryOnDB(Properties.Resources.Create_Document, parameters);
                        break;
                    default:
                        throw new NotImplementedException();
                }
                TestsLogger.Log("Created item '"+ itemName+"' on Case "+ caseNumber);
                createdItems.Add(itemName);
            }

            //save names added items
            AddDataToScenarioContextOverridingExistentKey("Created Items Type", itemType);
            AddDataToScenarioContextOverridingExistentKey("Created Items", createdItems);            
        }

        [When(@"I Click on Superadmin (.*) button")]
        public void WhenIClickOnSuperadminButton(string itemType)
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            switch (itemType)
            {
                case "Asset":
                    superadmin.ClickAssetButton();
                    break;
                case "Docket":
                    superadmin.ClickDocketButton();
                    break;
                case "Document":
                    superadmin.ClickDocumentButton();
                    break;
                default:
                    throw new NotImplementedException(); ;
            }
            superadmin.ItemsListTitle.Should().Be(itemType + "s", "Items list title is for the correct item type");
        }

        [Then(@"I See an Alert Message that reads '(.*)'")]
        public void WhenISeeItemCautionsMessageThatReads(string expAlertMsg)
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            superadmin.AlertMessage.Should().Be(expAlertMsg, "Alert message displays correctly");
        }



        [Given(@"I Select all created (.*) items")]
        [When(@"I Select all created (.*) items")]
        [Then(@"I Select all created (.*) items")]
        public void WhenISelectAllCreatedItems(string itemType)
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            List<string> createdItems = ScenarioContext.Current.Get<List<string>>("Created Items");                

            foreach (string createdItem in createdItems)
            {
                if(parameters.ContainsKey("Name"))
                    parameters.Remove("Name");
                parameters.Add("Name", createdItem);
                int itemId;
                switch (itemType)
                {
                    case "Asset":
                        itemId = ExecuteQueryOnDB(Properties.Resources.GetAssetIdFromName, parameters)[0].Field<int>("AssetId");
                        superadmin.SelectAssetToDeleteById(itemId);
                        break;
                    case "Docket":
                        itemId = ExecuteQueryOnDB(Properties.Resources.GetDocketIdFromName, parameters)[0].Field<int>("DocketId");
                        superadmin.SelectDocketToDeleteById(itemId);
                        break;
                    case "Document":
                        itemId = ExecuteQueryOnDB(Properties.Resources.GetDocumentIdFromFileName, parameters)[0].Field<int>("DocumentId");
                        superadmin.SelectDocumentToDeleteById(itemId);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        [Given(@"I Click On Super Admin Delete Button")]
        [When(@"I Click On Super Admin Delete Button")]
        [Then(@"I Click On Super Admin Delete Button")]
        public void WhenIClickOnDeleteButton()
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            ConfirmationDialog confirm = superadmin.ClickDeleteButton();
            SetSharedPageObjectInCurrentContext("Confirmation Dialog", confirm);
        }

        [When(@"I Click on Cancel button")]
        public void WhenIClickOnCancelButton()
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            superadmin.ClickCancelButton();            
        }

        [Then(@"I See a confirmation dialog reading '(.*)'")]
        public void ThenISeeAConfirmationDialog(string expMessage)
        {            
            ConfirmationDialog confirm = ((ConfirmationDialog) GetSharedPageObjectFromContext("Confirmation Dialog"));
            confirm.IsVisibleConfirmationDialog.Should().BeTrue("Confirmation dialog appears when attempting to delete a record");
            confirm.DialogMessage.Should().Be(expMessage, "Confirmation dialog message is correct");
        }

        [Then(@"I Click Yes to delete")]
        public void ThenIClickYesToDelete()
        {
            ConfirmationDialog confirm = ((ConfirmationDialog)GetSharedPageObjectFromContext("Confirmation Dialog"));
            confirm.ClickYesOnConfirmationDialog();
        }

        [Then(@"I Click No to delete")]
        public void ThenIClickNOToDelete()
        {
            ConfirmationDialog confirm = ((ConfirmationDialog)GetSharedPageObjectFromContext("Confirmation Dialog"));
            confirm.ClickYesOnConfirmationDialog();
        }

        [Then(@"I See the records are gone")]
        public void ThenISeeTheRecordsAreGone()
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            List<string> createdAssets = ScenarioContext.Current.Get<List<string>>("Created Items");

            foreach (string createdAsset in createdAssets)
            {
                superadmin.AssetHasDissapeared(createdAsset).Should().BeTrue("Asset '"+ createdAsset + "' was deleted correctly");
            }
        }

        [Then(@"I See the records are still visible")]
        public void ThenISeeTheRecordsAreStillVisible()
        {
            SuperAdminPage superadmin = ((SuperAdminPage)GetSharedPageObjectFromContext("Super Admin"));
            List<string> createdAssets = ScenarioContext.Current.Get<List<string>>("Created Items");

            foreach (string createdAsset in createdAssets)
            {
                superadmin.AssetIsVisibleOnList(createdAsset).Should().BeTrue("Asset '" + createdAsset + "' was not deleted");
            }
        }        
    }
}
