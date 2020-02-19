using System;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Meeting341;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Superadmin;
using System.Threading;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.TestFramework.Pages.Cases.Detail;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Dates;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Documents;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Pariticipants;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Tasks;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.BankingCenter;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.User;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Imports;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Emails;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common
{
    public class NavigationBar: PageObject
    {
        //Menu Links
        private By dashboardMenuItem = By.PartialLinkText("/ dashboard");
// private By meeting341MenuItemLocator = By.XPath("//a[text()='341']");
        //private By REPORTS_MENUITEM_LOCATOR = By.Id("menu-reports");
        private By superAdminLink = By.Id("menu-superadmin");
        //Cases Menu Items
        private By casesListMenuItem = By.XPath("//a[@id='basic-nav-dropdown']/span)[4]");
        //private By CASES_LIST_SECOND_LOCATOR = By.XPath("//li[3]/ul/li/ul/li[2]/a/span");
        //private By CASES_MENUITEM_LOCATOR = By.XPath("//li[@id='caseMenu']/button");
        //Tools Menu
        private By toolsMenuItem = By.Id("menu-tools");
        //Office Menu
        private By officesMenuItem = By.Id("menu-office");
        //User Locators      
        private By userManagementLocator = By.XPath("//a[text()='User Management']");
        private By roleIcon = By.XPath("//div[@class='user-management-tabs']//a[span[text()='ROLES']]");
        //new locators
        private By dasboardMenu = By.XPath("//div[@id='epiq-outer-container']/nav/div/div[3]/div[3]/div/div");
        private By dashboardNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[1]/a");
        private By calendarMeeting341Navigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[3]/a");
        private By assetsNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[4]/a");
        private By claimsNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[6]/a");
        private By distributionsNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[8]/a");
        private By dsoNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[10]/a");
        private By reportsNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[14]/a");
        private By datesNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[7]/a");
        private By documentsNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[9]/a");
        private By participantsNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[13]/a");
        private By tasksNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[16]/a");
        private By bankingListNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[contains(text(),'Banking')]");
        private By bankingAccountsNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[text()='Bank Accounts']");
        private By bankingActivityNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[text()='Activity']");
        private By bondPremiumDisbursementNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[text()='Bond Premium Disbursement']");
        private By receiptlogNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[text()='Receipt Log']");
        private By printChecksOrDepositsNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[text()='Print Checks / Deposits']");
        private By importsNavigator = By.XPath("//div[@id='epiq-header-navigation-selector']//a[contains(text(),'Import')]");
        private By imortsAssetsNavigator = By.XPath("//div[@class='popover-content']//ul[@class='dropdown-menu']//li//a[contains(text(),'Assets')]");
        private By emailNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[11]/a");
        private By scheduleToClaimReconciliationNavigator = By.XPath("//ul[@class='epiq-header-selector-list']/li[15]/a");


        //logout locators
        private By userIcon = By.XPath("//a[@id='basic-nav-dropdown']/i");
        private By logoutLink = By.XPath("//div[@class='pull-right epiq-header-quick-links']//a[text()='Logout']");

        public NavigationBar(IWebDriver driver):base(driver,null)
        {

        }
        public Link DashboardMenuItemLink
        {
            get { return GetLink(dashboardMenuItem); }
        }

        public Link CasesMenuItemLink
        {
            get { return GetLink(casesListMenuItem); }
        }

        public Link OfficesMenuItemLink
        {
            get { return GetLink(officesMenuItem); }
        }

        public Link ToolsMenuItemLink
        {
            get { return GetLink(toolsMenuItem); }
        }
        public DashboardPage DashboardSelectionContainer()
        {
            WaitForElementToBeClickeable(dasboardMenu,3).Click();
            return new DashboardPage(driver);
        }

        public DashboardPage GoToDashboard()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(dashboardNavigator,4).Click();
            return new DashboardPage(driver);
        }

        //TODO make this a general method to navigate anywhere using actions and mouse over
        //it might receive an array with the navigation route and could live on Page Object
        public CaseListPage GoToCasesList()
        {
            DashboardSelectionContainer();
            driver.FindElement(By.XPath("//ul[@class='epiq-header-selector-list']/li[2]/a")).Click();
            return new CaseListPage(driver);

        }

        public ReportsPage GoToReports()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeVisible(reportsNavigator,4).Click();
            return new ReportsPage(driver);
        }

        public Meetings341Destination GoTo341MeetingList()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(calendarMeeting341Navigator,4).Click();
            return new Meetings341Destination(driver, "UNITY");
        }

        public AssetsDetailTab GoToAssetsPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(assetsNavigator,4).Click();
            return new AssetsDetailTab(driver);
        }
        public BankingPage GoToBankAccounts()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(bankingListNavigator,3).Click();
            this.WaitForElementToBeClickeable(bankingAccountsNavigator,3).Click();
            return new BankingPage(driver);
        }

        public BankingPage GoToBankingActivity()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(bankingListNavigator,3).Click();
            this.WaitForElementToBeClickeable(bankingActivityNavigator,6).Click();
             return new BankingPage(driver);
        }
        public BankingPage GoToBondPremiumDisbursement()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(bankingListNavigator, 3).Click();
            this.WaitForElementToBeClickeable(bondPremiumDisbursementNavigator, 6).Click();
            return new BankingPage(driver);
        }
        public BankingPage GoToBankingReceiptLog()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(bankingListNavigator,3).Click();
            this.WaitForElementToBeClickeable(receiptlogNavigator,5).Click();
            return new BankingPage(driver);
        }
        public BankingPage GoToBankingChecksOrDeposits()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(bankingListNavigator,3).Click();
            this.WaitForElementToBeClickeable(printChecksOrDepositsNavigator,5).Click();
            return new BankingPage(driver);
        }
        public ClaimsDetailTab GoToClaimsPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(claimsNavigator,3).Click();
            return new ClaimsDetailTab(driver);
        }
        public DatesPage GoToDatesPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(datesNavigator,3).Click();
            return new DatesPage(driver);
        }
        public DistributionTab GoToDistributionsPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(distributionsNavigator,3).Click();
            return new DistributionTab(driver);
        }
        public DocumentsPage GoToDocumentsPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(documentsNavigator,5).Click();
            return new DocumentsPage(driver);
        }
        public EmailsPage GoToEmailsPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(emailNavigator).Click();
            Thread.Sleep(2000);
            return new EmailsPage(driver);
        }
        public DSOClaimantModal GoToDSOPage()
        {
            DashboardSelectionContainer();
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("(//a[contains(text(),'DSO')])[2]"))).Click().Build().Perform();
            //this.WaitForElementToBeClickeable(DSO_LOCATOR).Click();
            this.Pause(2);
            return new DSOClaimantModal(driver);
        }
        public ParticipantsPage GoToParticipantsPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(participantsNavigator,3).Click();
            return new ParticipantsPage(driver);
        }
        public TasksPage GoToTasksPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(tasksNavigator,3).Click();
            return new TasksPage(driver);
        }

        public UserManagement GotoRolesPage()
        {
            DashboardSelectionContainer();
            Thread.Sleep(2000);
            WaitForElementToBeClickeable(userIcon).Click();
            WaitForElementToBeClickeable(userManagementLocator).Click();
            WaitForElementToBeClickeable(roleIcon).Click();
            return new UserManagement(driver);
        }
        public UserManagement GotoUserManagementPage()
        {
            DashboardSelectionContainer();
            Thread.Sleep(2000);
            var userPage = (new UserManagement(driver)).GotoUSerManagement();
            return userPage;
        }

                public bool IsSuperAdminLinkVisible()
        {
            try
            {
                this.WaitForElementToBeVisible(superAdminLink);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       public bool IsSuperAdminLinkInvisible()
        {
            try
            {
                this.WaitForElementToDissapear(superAdminLink, 5);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SuperAdminPage GoToSuperAdminPage() {
            this.WaitForElementToBeVisible(superAdminLink).Click();
            return new SuperAdminPage(driver);
        }
        public bool SignOutFromUnity()
        {
            Thread.Sleep(2000);
            var element = driver.FindElement(userIcon);
           ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
            var logout = WaitForElementToBeClickeable(logoutLink);
            JavaScriptClick(logout);
            return true;
        }
        public ImportAssets GoToImportAssets()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(importsNavigator,2).Click();
            this.WaitForElementToBeClickeable(imortsAssetsNavigator,4).Click();
            return new ImportAssets(driver);
        }
        public ImportClaimsPage GoToImportClaims()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(importsNavigator, 2).Click();
            IWebElement IMPORT_CLAIMS_LOCATOR = driver.FindElement(By.XPath("//div[@class='popover-content']//ul[@class='dropdown-menu']//li//a[contains(text(),'Claims')]"));
            MoveToElementAndClick(IMPORT_CLAIMS_LOCATOR);
            return new ImportClaimsPage(driver);
        }
        public ImportCaseDataChangesPage GoToCaseDataChangesPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(importsNavigator,2).Click();         
            IWebElement IMPORT_CASE_DATA_CHANGES_LOCATOR = driver.FindElement(By.XPath("//div[@class='popover-content']//ul[@class='dropdown-menu']//li//a[contains(text(),'Case Data Changes')]"));
            MoveToElementAndClick(IMPORT_CASE_DATA_CHANGES_LOCATOR);          
            return new ImportCaseDataChangesPage(driver);
        }
        public ImportClaimsPage GoToImportDates()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(importsNavigator, 2).Click();
            IWebElement IMPORT_CLAIMS_LOCATOR = driver.FindElement(By.XPath("//div[@class='popover-content']//ul[@class='dropdown-menu']//li//a[contains(text(),'Dates')]"));
            MoveToElementAndClick(IMPORT_CLAIMS_LOCATOR);
            return new ImportClaimsPage(driver);
        }
        public ImportDocumetsPage GoToImportDocuments()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(importsNavigator, 2).Click();
            IWebElement IMPORT_DOCUMENTS_LOCATOR = driver.FindElement(By.XPath("//div[@class='popover-content']//ul[@class='dropdown-menu']//li//a[contains(text(),'Documents')]"));
            MoveToElementAndClick(IMPORT_DOCUMENTS_LOCATOR);
            return new ImportDocumetsPage(driver);
        }
        public ClaimsDetailTab GoToScheduleToClaimReconciliationPage()
        {
            DashboardSelectionContainer();
            this.WaitForElementToBeClickeable(scheduleToClaimReconciliationNavigator, 3).Click();
            return new ClaimsDetailTab(driver);
        }

    }
}