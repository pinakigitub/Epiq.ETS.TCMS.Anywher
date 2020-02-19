using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common
{
    [Binding]
    public class SignedInUnityUserSteps : StepBase
    {

        //Start page for the Signed In user is Dashboard Page
      
        [Given(@"I enter to (.*) page as superuser")]
        [When(@"I enter to (.*) page as superuser")]
        [Then(@"I enter to (.*) page as superuser")]
        //TODO make step methods public once there is no more hierarchies
        private void GivenIEnterToPageAsSuperuser(string targetPage)
        {            
            SetSharedPageObjectInCurrentContext("Dashboard", LoginOrReloadDashboard(null, null, null));
            Thread.Sleep(5000);
            GivenIGoToPage(targetPage);
        }

        [Given(@"I enter to (.*) page as user (.*) with password (.*) and office (.*)")]
        [When(@"I enter to (.*) page as user (.*) with password (.*) and office (.*)")]
        [Then(@"I enter to (.*) page as user (.*) with password (.*) and office (.*)")]
        private void GivenIEnterToPageAsThisUuser(string targetPage, string user, string passwd, string office)
        {
            SetSharedPageObjectInCurrentContext("Dashboard", LoginOrReloadDashboard(user, passwd, office));
            GivenIGoToPage(targetPage);
        }

        [Given(@"I login to Unity as user (.*) with password (.*) and office (.*)")]
        [When(@"I login to Unity as user (.*) with password (.*) and office (.*)")]
        private void GivenILoginToUnityAsThisUuser(string user, string passwd, string office)
        {
            SetSharedPageObjectInCurrentContext("Dashboard", LoginOrReloadDashboard(user, passwd, office));
        }

        [Given(@"I login to Unity as Super Admin user")]
        [When(@"I login to Unity as Super Admin user")]
        private void GivenILoginAsSuperAdminUser()
        {
            string user = ConfigurationManager.AppSettings.Get("superadmin-user");
            string password = ConfigurationManager.AppSettings.Get("superadmin-password");
            string office = ConfigurationManager.AppSettings.Get("superadmin-office");
            SetSharedPageObjectInCurrentContext("Dashboard", LoginOrReloadDashboard(user, password, office));
        }

        [Given(@"I login to Unity as NON Super Admin user")]
        [When(@"I login to Unity as NON Super Admin user")]
        private void GivenILoginAsNONSuperAdminUser()
        {
            string user = ConfigurationManager.AppSettings.Get("non-superadmin-user");
            string password = ConfigurationManager.AppSettings.Get("non-superadmin-password");
            string office = ConfigurationManager.AppSettings.Get("non-superadmin-office");
            SetSharedPageObjectInCurrentContext("Dashboard", LoginOrReloadDashboard(user, password, office));
        }

        private DashboardPage LoginOrReloadDashboard(string user, string passwd, string office)
        {
            DashboardPage dashboardPage;
            try
            {  //See if already on current context
                dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
                //already running a test as a loged user
                return dashboardPage.NavigationBar.GoToDashboard();
            }
            catch (Exception) {
                return this.LoginWithUserOrConfigCredentials(user, passwd, office);
            }            
        }


        /**
         * Logs in to Unity as the user credentials or default from config if any of the credentials parameters is null
         */
        private DashboardPage LoginWithUserOrConfigCredentials(string usr, string passwd, string off)
        {
            string user = "";
            string password = "";
            string office = "";

            if ((usr!= null)&& (passwd != null) && (off != null)) {
                user = usr;
                password = passwd;
                office = off;
            }
            else { 
                //Login to Unity site as superuser with config file credentials
                user = ConfigurationManager.AppSettings.Get("user");
                password = ConfigurationManager.AppSettings.Get("password");
                office = ConfigurationManager.AppSettings.Get("office");
            }


            LoginPage loginPage = new LoginPage(driver);
            return loginPage.Login(user, password, office);
        }                

        [Given(@"I Go to (.*) page")]
        [When(@"I Go to (.*) page")]
        [Then(@"I Go to (.*) page")]
        private void GivenIGoToPage(string targetPage)
        {
            DashboardPage dashboardPage = ((DashboardPage) GetSharedPageObjectFromContext("Dashboard"));

            //Go to target page
            switch (targetPage)
            {
               
                case "Dashboard":
                    SetSharedPageObjectInCurrentContext("Dashboard", dashboardPage.NavigationBar.GoToDashboard());
                    break;

                case "Case List":
                    SetSharedPageObjectInCurrentContext("Case List", dashboardPage.NavigationBar.GoToCasesList());
                    break;

                case "341 Meeting":
                    SetSharedPageObjectInCurrentContext("341 Meeting", dashboardPage.NavigationBar.GoTo341MeetingList());
                    break;

                case "Assets":
                    SetSharedPageObjectInCurrentContext("Assets", dashboardPage.NavigationBar.GoToAssetsPage());
                    break;

                case "Bank Accounts":
                    SetSharedPageObjectInCurrentContext("Bank Accounts", dashboardPage.NavigationBar.GoToBankAccounts());
                    break;

                case "Banking Activity":
                    SetSharedPageObjectInCurrentContext("Banking Activity", dashboardPage.NavigationBar.GoToBankingActivity());
                    break;

                case "Bond Premium Disbursement":
                    SetSharedPageObjectInCurrentContext("Bond Premium Disbursement", dashboardPage.NavigationBar.GoToBondPremiumDisbursement());
                    break;
                case "Banking ReceiptLog":
                    SetSharedPageObjectInCurrentContext("Banking ReceiptLog", dashboardPage.NavigationBar.GoToBankingReceiptLog());
                    break;

                case "Banking ChecksOrDeposits":
                    SetSharedPageObjectInCurrentContext("Banking ChecksOrDeposits", dashboardPage.NavigationBar.GoToBankingChecksOrDeposits());
                    break;

                case "Claims":
                    SetSharedPageObjectInCurrentContext("Claims", dashboardPage.NavigationBar.GoToClaimsPage());
                    break;

                case "Dates":
                    SetSharedPageObjectInCurrentContext("Dates", dashboardPage.NavigationBar.GoToDatesPage());
                    break;

                case "Distributions":
                    SetSharedPageObjectInCurrentContext("Distributions", dashboardPage.NavigationBar.GoToDistributionsPage());
                    break;

                case "Documents":
                    SetSharedPageObjectInCurrentContext("Documents", dashboardPage.NavigationBar.GoToDocumentsPage());
                    break;

                case "DSO":
                    SetSharedPageObjectInCurrentContext("DSO", dashboardPage.NavigationBar.GoToDSOPage());
                    break;

                case "Participants":
                    SetSharedPageObjectInCurrentContext("Participants", dashboardPage.NavigationBar.GoToParticipantsPage());
                    break;

                case "Reports":
                    SetSharedPageObjectInCurrentContext("Reports", dashboardPage.NavigationBar.GoToReports());
                    break;

                case "Tasks":
                    SetSharedPageObjectInCurrentContext("Tasks", dashboardPage.NavigationBar.GoToTasksPage());
                    break;

                case "UserManagement":
                    SetSharedPageObjectInCurrentContext("UserManagement", dashboardPage.NavigationBar.GotoUserManagementPage());
                    break;

                case "Add User":
                    SetSharedPageObjectInCurrentContext("Add User", dashboardPage.NavigationBar.GotoUserManagementPage());
                    break;

                case "Roles":
                    SetSharedPageObjectInCurrentContext("Add Role", dashboardPage.NavigationBar.GotoRolesPage());
                    break;

                case "Import Assets":
                    SetSharedPageObjectInCurrentContext("Import Assets", dashboardPage.NavigationBar.GoToImportAssets());
                    break;
                case "Imports Claims":
                    SetSharedPageObjectInCurrentContext("Imports Claims", dashboardPage.NavigationBar.GoToImportClaims());
                    break;
                case "Imports Dates":
                    SetSharedPageObjectInCurrentContext("Imports Dates", dashboardPage.NavigationBar.GoToImportDates());
                    break;
                case "Imports Documents":
                    SetSharedPageObjectInCurrentContext("Imports Documents", dashboardPage.NavigationBar.GoToImportDocuments());
                    break;
                case "Imports Case Data Changes":
                    SetSharedPageObjectInCurrentContext("Imports Case Data Changes", dashboardPage.NavigationBar.GoToCaseDataChangesPage());
                    break;
                case "Emails":
                    SetSharedPageObjectInCurrentContext("Emails", dashboardPage.NavigationBar.GoToEmailsPage());
                    break;
                case "Schedule to Claim Reconciliation":
                    SetSharedPageObjectInCurrentContext("Schedule to Claim Reconciliation", dashboardPage.NavigationBar.GoToScheduleToClaimReconciliationPage());
                    break;

                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
        }

        

        [Then(@"I see the '(.*)' link with reference to '(.*)'")]
        private void ThenISeeTheLinkWithReferenceTo(string linkText, string linkURL)
        {
            DashboardPage dashboardPage = ((DashboardPage) GetSharedPageObjectFromContext("Dashboard"));
            dashboardPage.GetLinkByExactTextAndURL(linkText, linkURL).Should().NotBeNull();
        }

        [Given(@"I go to Dashboard Selection Container")]
        public void GivenIGoToDashboardSelectionContainer()
        {
            DashboardPage dashboardPage = ((DashboardPage)GetSharedPageObjectFromContext("Dashboard"));
            dashboardPage.NavigationBar.DashboardSelectionContainer();
        }


        [When(@"I do Logout")]
        private void WhenIDoLogout()
        {
            //if user is already logged in, then Logout and go to login page
            //use base class to access navigation bar, independently of what page is loaded
            UnityPageBase navigationBar = new UnityPageBase(driver, null);
            navigationBar.Logout();
            RemovedSharedPageObjectFromCurrentContext("Dashboard");   
        }

        [When(@"I got to know")]
        public void WhenIGotToKnow()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
