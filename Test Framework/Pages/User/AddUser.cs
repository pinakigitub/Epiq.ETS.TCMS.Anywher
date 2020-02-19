using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System.Collections;
using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Utils;
using FluentAssertions;
using static NUnit.Core.NUnitFramework;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.User
{
    public class AddUser : UnityPageBase
    {
        public AddUser(IWebDriver driver) : base(driver, "UNITY") { }

        private By addUserPageHeader = By.XPath("//h2[text()='Add User']");
        private By userNameLocator = By.XPath("//input[@name='userName']");
        private By passwordLocator = By.XPath("//input[@name='modifyPassword']");
        private By emailLocator = By.XPath("//input[@name='email']");
        private By trusteeUserVisibilityLocator = By.XPath("//div[@class='Select-placeholder']");
        // private By EPIQ_EMPLOYEE_CHECKBOX_LOCATOR = By.XPath("//input[@id='epiq-check-cbIsEmp']");
        private By roleButtonLocator = By.XPath("//button[@class='btn btn-info']");
        private By permissionsButtonLocator = By.XPath("//button[text()='PERMISSIONS']");
        private By trusteeUserVisibilityClearLocator = By.XPath("//span[@class='Select-clear']");
        private By trusteeUserVisibilityArrowLocator = By.XPath("//span[@class='Select-arrow-zone']//span[@class='Select-arrow']");
        private By permissionsAddButtonLocator = By.XPath("//button[text()='Add']");
        private By saveButtonOnAdduserLocator = By.XPath("//div[@class='container']//button[text()='SAVE']");
        private By activeLabelLocator = By.XPath("//label[text()='ACTIVE']");
        private By activeToggle = By.XPath("//div[@class='epiq-input-toggle-switch large']");
        private By displayNameLocator = By.XPath("//div[@class='form-group']//div[2]//div//input[@name='displayName']");
        private By sortNameLocator = By.XPath("//div[@class='form-group']//div[2]//div[2]//input[@name='sortName']");
        private By roleAddButtonLocator = By.XPath("//button[text()='Add']");
        private By toastrLocator = By.XPath("//div[@class='toastr animated rrt-success']");
        private By epiqEmployeeCheckboxLocator = By.XPath("//div[@class='form-group']//div[4]//div[@class='epiq-input-styled-checkbox']//input");
        private By userManagementHeadernames = By.XPath("//table//th[@class='epiq-table-header-sortable'or @class='epiq-table-header-sortable visible-md visible-lg visible-xl'  or @class='epiq-table-header-sortable visible-lg visible-xl']");
        private By editUserNameLocator = By.XPath("(//div[@class='form-group']//div[@class='epiq-form-display-field '])[1]");
        private By userLevelPermissionLabel = By.XPath("//h4[text()='USER LEVEL PERMISSIONS']");
        private By permissionDeleteRedCircle = By.XPath("//i[@class='fa fa-times-circle fa-2x epiq-form-item-remove text-danger']");
        private By allPermissionCheckbox = By.XPath("(//div[@class='epiq-user-role-list-checkbox'])[1]");
        private By allPermissionAppliedLocator = By.XPath("//div[@class='epiq-user-role-no-permissions']");
        private By permissionsFilterOptionsDropdownValues = By.XPath("//div[@class='Select-menu-outer']//div//div");
        private By permissionsFilterArrow = By.XPath("//div[@class='epiq-user-permission-list']//div[@class='Select-control']//span[@class='Select-arrow-zone']//span");
        private By permissionFilterResult = By.XPath("//div[@class='epiq-user-permission-list']//div[@class='epiq-user-role-list-header row']//div[div[@class='epiq-user-role-list-checkbox']]");


        //private By PASSWORD_LOCATOR = By.XPath("");

        public string GetAddUserHeaderName()
        {
            this.Pause(1);
            return this.WaitForElementToBeVisible(addUserPageHeader).Text;
        }
        public bool IsUserPage()
        {
            return this.WaitForElementToBeVisible(addUserPageHeader).Displayed;
        }
        public void EnterUserName()
        {
            this.WaitForElementToBeVisible(userNameLocator).SendKeys(FakeData.RandomUserName());
        }
        public void EnterPassword(string password)
        {
            this.WaitForElementToBeVisible(passwordLocator).SendKeys(password);
        }
        public void ClearPassword()
        {
            this.WaitForElementToBeVisible(passwordLocator).SendKeys(Keys.LeftControl + "a" + Keys.Delete);
        }
        public void EnterDisplayName()
        {
            this.WaitForElementToBeVisible(displayNameLocator).SendKeys(FakeData.RandomFullName());
        }
        public void EnterSortName()
        {
            this.WaitForElementToBeVisible(sortNameLocator).SendKeys(FakeData.RandomFirstName());
        }
        public void EnterEmail()
        {
            this.WaitForElementToBeVisible(emailLocator).SendKeys(FakeData.RandomEmailId());
        }
        public void SelectTrustee()
        {
            this.Pause(1);
            ScrollDown();
            this.WaitForElementToBePresent(By.XPath("//span[@class='Select-arrow-zone']//span[@class='Select-arrow']")).Click();
            IList<IWebElement> trusteeList = this.WaitForElementsToBeVisible(By.XPath("//div[@class='Select-menu-outer']//div[1]//div")).ToList();
            trusteeList[0].Click();
        }
        public void SelectRole(string role)
        {
            Pause(1);
            string roleXpath = String.Format("//div[@class='row epiq-user-role-list-header']//div[div[text()='{0}']]/div[1]", role);
            var addRole = driver.FindElement(By.XPath(roleXpath));
            Pause(1);
            addRole.Click();
            this.WaitForElementToBePresent(roleAddButtonLocator).Click();
        }
        public void SelectPermission(string permission)
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(permissionsButtonLocator).Click();
            Pause(1);
            string permissionXpath = String.Format("//div[text()='{0}']//div[contains(@class,'epiq-input-styled-checkbox')]", permission);
            var permissionslist = driver.FindElements(By.XPath(permissionXpath));
            foreach (IWebElement pageList in permissionslist)
            {
                if (pageList.Displayed == false)
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", pageList);
                else
                    pageList.Click();
            }
            this.WaitForElementToBePresent(permissionsAddButtonLocator).Click();
        }
        public void ClickOnSaveButton()
        {
            this.Pause(3);
            ScrollDownToPageBottom();
            this.WaitForElementToBeVisible(saveButtonOnAdduserLocator).Click();
            //var c = driver.FindElement(SAVE_BUTTON_ON_ADDUSER_LOCATOR);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();",c);
        }
        public void VerifyToastMessage()
        {
            this.WaitForElementToBeVisible(toastrLocator).Displayed.Equals(1);
        }
        public void ClickOnRoleButton()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(roleButtonLocator).Click();
        }
        public bool IsEditPage()
        {
            return this.WaitForElementToBeVisible(activeLabelLocator).Displayed;
        }
        public void EditEmail_Id()
        {
            Pause(1);
            this.WaitForElementToBePresent(emailLocator).Clear();
            EnterEmail();
        }
        public void ClickonEpiqEmpCheckbox()
        {
            this.WaitForElementToBePresent(epiqEmployeeCheckboxLocator).Click();
        }
        public void ClickOnActiveToggle()
        {
            this.WaitForElementToBePresent(activeToggle).Click();
        }
        public bool VerifyDangerExist()
        {
            try
            {
                IList<IWebElement> dangerIconlist = driver.FindElements(By.XPath("//ul[@class='epiq-list-unbulleted']/li/i[contains(@class,'text-danger')]"));
                if (dangerIconlist.Count > 0)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }
        public void VerifyUserName_NonEditable()
        {
            this.WaitForElementToBeVisible(editUserNameLocator).Displayed.Should().BeTrue();
        }
        public bool Is_Password_displayed()
        {
            if (GetElementExists(By.XPath("//label[text()='PASSWORD']")))
            {
                return true;
            }
            else return false;
        }
        private bool GetElementExists(By loc)
        {
            try
            {
                this.WaitForElementToBeVisible(loc, 5);
                return true;
            }
            catch { return false; }
        }
        public void VerifyLable_UserLevelPermission()
        {
            ScrollDownToPageBottom();
            WaitForElementToBeVisible(userLevelPermissionLabel).Displayed.Should().BeTrue();
        }
        public void ClickOnPermissionButton()
        {
            ScrollDownToPageBottom();
            this.WaitForElementToBePresent(permissionsButtonLocator).Click();
        }
        public void Verify_Permissions_Headers(string Cat,string Name,string Desc)
        {
            Assert.AreEqual(Cat, WaitForElementToBeVisible(By.XPath("(//div[@class='epiq-user-permission-headings row']//h5)[1]")).Text);
            Assert.AreEqual(Name, WaitForElementToBeVisible(By.XPath("(//div[@class='epiq-user-permission-headings row']//h5)[2]")).Text);
            Assert.AreEqual(Desc, WaitForElementToBeVisible(By.XPath("(//div[@class='epiq-user-permission-headings row']//h5)[3]")).Text);
        }
        public void SelectRandomPermissions()
        {
           IList<IWebElement> PermissonCheckBox =this.WaitForElementsToBeVisible(By.XPath("//div[@class='epiq-user-role-list-checkbox']")).ToList();
            for (int pagePermission = 1; pagePermission < 3; pagePermission++)
            {
                PermissonCheckBox[pagePermission].Click();
            }           
            this.WaitForElementToBePresent(permissionsAddButtonLocator).Click();
        }
        public void ValidatePemissionDeletion()
        {
            ScrollDownToPageBottom();
          IList<IWebElement> DeletePermission =  WaitForElementsToBeVisible(permissionDeleteRedCircle).ToList();
            for (int pagePermission = 0; pagePermission < DeletePermission.Count(); pagePermission++)
            {
                DeletePermission[0].Click();                
            }
        }
        public void Is_NoSelectedPermissions_Displayed()
        {
            WaitForElementToBeVisible(By.XPath("//div[text()='No selected permission']")).Displayed.Should().BeTrue();
        }
        public void ClickOnCircleArrow()
        {
            this.Pause(4);
            WaitForElementToBeVisible(By.XPath("(//div[@class='toggle-icon'])[1]")).Click();
        }
        public void VerifyPermissionList_UnderRole_onAddRole()
        {
            this.Pause(3);
            WaitForElementToBeVisible(By.XPath("//ul[@class='epiq-user-role-permission-list']//li")).Displayed.Should().BeTrue();
        }
        public void ClickOnRoleAddButton()
        {
            this.WaitForElementToBePresent(roleAddButtonLocator).Click();
        }
        public void ClickOnArrow_for_Role_onUserPage()
        {
            WaitForElementToBeVisible(By.XPath("(//div[@class='epiq-user-role-list-toggle-icon']//i)[1]")).Click();
        }
        public void VerifyPermissionList_UnderRole_onUserPage()
        {
            WaitForElementToBeVisible(By.XPath("//div[@class='permission-details']")).Displayed.Should().BeTrue();
        }
        public bool IsDisplayed_inAddPermission(string permission)
        {
           string permissionXpath = String.Format("//div[@class='epiq-user-role-list-header row']//div[text()='{0}']", permission);
            if (GetElementExists(By.XPath(permissionXpath)))
            {
                return true;
            }
            else { return false; }         

        }
        public void ClickOnCancelButton()
        {
            WaitForElementToBePresent(By.XPath("(//button[text()='CANCEL'])[2]")).Click();
        }
        public void SelectAllPermissions()
        {
            Pause(1);
            WaitForElementToBeVisible(allPermissionCheckbox).Click();
            WaitForElementToBePresent(permissionsAddButtonLocator).Click();
        }
        public string GetTextFromAddPermission()
        {
           return WaitForElementToBeVisible(allPermissionAppliedLocator).Text;
        }
        public void GoToTopOfSection_N_ClickOnPermissionButton()
        {
            ScrollUpToPageTop();
            ScrollWindowBy(0,500);
            this.WaitForElementToBePresent(permissionsButtonLocator).Click();
        }
        public bool IsDisplayed_inAddRole(string role)
        {
            Pause(1);
            string roleXpath = String.Format("//div[@class='modal-lg modal-dialog']//div[@class='row epiq-user-role-list-header']//div[div[text()='{0}']]/div[2]", role);
            if (GetElementExists(By.XPath(roleXpath)))
            {
                return true;
            }
            else { return false; }
        }
        public void FilterPermission(string Permission)
        {
            Pause(1);
            this.WaitForElementToBeVisible(permissionsFilterArrow).Click();
            IList<IWebElement> PermissionList = WaitForElementsToBeVisible(permissionsFilterOptionsDropdownValues).ToList();
            foreach (var permission in PermissionList)
            {
                if (permission.Text == Permission)
                {
                    permission.Click();
                    break;
                }
            }
        }
        public void PermissionFilterResult(string Permission)
        {
            IList<IWebElement> SearchResult = WaitForElementsToBeVisible(permissionFilterResult).ToList();
            foreach (var permission in SearchResult)
            {
                permission.Text.Equals(Permission).Should().BeTrue();
            }
        }
    }
}
