using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Data;
using FluentAssertions;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.User
{
    public class UserManagement : UnityPageBase
    {
        public UserManagement(IWebDriver driver) : base(driver, "UNITY") {}
// public UserManagement(IWebDriver driver, string subPageTitle) : base(driver, subPageTitle+"") { }

        private By userIcon = By.XPath("//*[@id='basic-nav-dropdown']/i");
        private By userManagement = By.XPath("//a[text()='User Management']");
        private By userManagementPageHeader = By.XPath("//main[@id='epiq-main-page-wrap']/div/div[1]/div/h2");
        private By addUserButton = By.XPath("//button[contains(text(),'USER')]");
        private By userManagementHeader = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By lockedOutSorting = By.XPath("//th[text()='LOCKED OUT']//i");
        private By userLockedOutLink = By.XPath("//a[@class='locked-out']//i[@class='fa fa-lock epiq-cursor-pointer']");
        private By unlockSuccessToast = By.XPath("//div[@class='toastr animated rrt-success']");
        private By roleIcon = By.XPath("//ul[@class='epiq-navbar epiq-navbar-right nav nav-pills']//li[2]");
        private By addRolesButton = By.XPath("//button[text()=' ROLES']");
        private By rolesHeaders = By.XPath("//th[@class='epiq-table-header-sortable ']");
        private By editRoleButton = By.XPath("(//a[@title='Edit Role'])[1]");

        public UserManagement GotoUSerManagement()
        {
            WaitForElementToBeClickeable(userIcon).Click();
            WaitForElementToBeClickeable(userManagement).Click();


            return new UserManagement(driver);
        }

        public string GetHeaderName()
        {
            return this.WaitForElementToBeVisible(userManagementPageHeader).Text;
        }

        public AddUser ClickOnAddUserButton()
        {
            this.WaitForElementToBeVisible(addUserButton).Click();
            return new AddUser(driver);
        }

        public bool IsUserManagementPage()
        {
            return this.WaitForElementToBeVisible(addUserButton).Enabled;
        }

        public DataTable GetUsersRecords(string SortColumn = null)
        {
            DataTable htmlTable = new DataTable();

            if (!string.IsNullOrEmpty(SortColumn))
                driver.FindElements(userManagementHeader).Where(e => e.Text.Contains(SortColumn.ToUpper())).FirstOrDefault().Click();

            IList<IWebElement> rows = null;
            var headerNames = driver.FindElements(userManagementHeader).Select(e => e.Text.Trim()).ToList();
            for (int i = 0; i <= headerNames.Count - 2; i++)
            {
                htmlTable.Columns.Add(headerNames[i]);
                try
                {
                    this.Pause(2);
                    rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']//span[text()]"));
                    if (rows.Count == 0) { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }
                }
                catch { rows = driver.FindElements(By.XPath($"//tr//td[@data-title='{headerNames[i]}']")); }

                var testList = rows.Select(e => e.Text).ToList();
                for (int j = 0; j <= testList.Count - 1; j++)
                {
                    if (i != 0) { htmlTable.Rows[j][i] = testList[j]; }
                    else { htmlTable.Rows.Add(testList[j]); }
                }
            }

            return htmlTable;
        }

        public AddUser ClickOnEditUser()
        {
            var list = driver.FindElements(By.XPath("//a[@class='btn btn-link']"));
            list[2].Click();
            return new AddUser(driver);

        }
        public void ClickOnSoringOfLockedOut()
        {
            this.WaitForElementToBeVisible(lockedOutSorting).Click();
        }
        public void ClickOnLockedOutLinkAndValidateToastrMessage()
        {
            this.Pause(3);
            IList<IWebElement> LockedOutLink = WaitForElementsToBeVisible(userLockedOutLink).ToList();
            LockedOutLink[0].Click();
            WaitForElementToBeVisible(unlockSuccessToast).Displayed.Should().BeTrue();
        }
        
        public void ClickOnRolesIcon()
        {
            WaitForElementToBeVisible(roleIcon).Click();
        }

        public void IsDisplay_RolesPage()
        {
            WaitForElementToBeVisible(By.XPath("//div[@class='pull-left buttons-new-line']")).Text.Contains("Roles");
        }
        public void ValidateHeadersOnRolesPage(string nm,string desc, string type)
        {
          IList<IWebElement> headersList = WaitForElementsToBeVisible(rolesHeaders).ToList();
            headersList[0].Text.Should().Be(nm);
            headersList[1].Text.Should().Be(desc);
            headersList[2].Text.Should().Be(type);
        }
        public AddRole ClickOnAddRoleButton()
        {
           WaitForElementToBeVisible(addRolesButton).Click();
            return new AddRole(driver);
        }
        public AddRole ClickOnEditRoleButton()
        {
            WaitForElementToBeVisible(editRoleButton).Click();
            return new AddRole(driver);
        }
    }
}
