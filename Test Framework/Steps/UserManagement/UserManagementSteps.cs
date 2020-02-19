using Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Data;
using FluentAssertions;
using System.Threading;
using UserMgmt = Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages.User;
using TechTalk.SpecFlow;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Steps.UserManagement
{
    public class UserManagementSteps : StepBase
    {
        UserMgmt.UserManagement userManagement;
        UserMgmt.AddUser addUser;
        UserMgmt.AddUser editUser;
        UserMgmt.AddRole addRole;
        UserMgmt.AddRole editRole;

        DataTable randomUsersRecords;

        [Then(@"'(.*)' header should be displayed on User Management Page")]
        public void ThenHeaderShouldBeDisplayedOnUserManagementPage(string header)
        {
            userManagement = ((UserMgmt.UserManagement)GetSharedPageObjectFromContext("UserManagement"));
            userManagement.GetHeaderName().Should().Contain(header);
        }
         [When(@"I click on Add User Button on User Management")]
        public void WhenIClickOnAddUserButtonOnUserManagement()
        {
            addUser = userManagement.ClickOnAddUserButton();
        }
        [Then(@"'(.*)' header should be displayed on AddUser Page")]
        public void ThenHeaderShouldBeDisplayedOnAddUserPage(string header)
        {
            addUser.GetAddUserHeaderName().Should().Contain(header);
        }
        [Then(@"Users result should be present")]
        public void ThenUsersResultShouldBePresent()
        {
            System.Threading.Thread.Sleep(2000);
            userManagement.GetUsersRecords().Should().Equals(randomUsersRecords);
        }
        [Then(@"I should be on Add User page")]
        public void ThenIShouldBeOnAddUserPage()
        {
            addUser.IsUserPage().Should().BeTrue();
        }
        [Then(@"Then I should be on User Management page")]
        public void ThenThenIShouldBeOnUserManagementPage()
        {
            userManagement.IsUserManagementPage().Should().BeTrue();
        }
        [When(@"I enter User Name")]
        public void WhenIEnterUserName()
        {
            addUser.EnterUserName();
        }
        [When(@"I enter Password '(.*)'")]
        public void WhenIEnterPassword(string pw)
        {
            addUser.EnterPassword(pw);
        }
        [When(@"I enter Email")]
        public void WhenIEnterEmail()
        {
            addUser.EnterEmail();
        }
        [When(@"I enter Display Name")]
        public void WhenIEnterDisplayName()
        {
            addUser.EnterDisplayName();
        }
        [When(@"I enter Sort Name")]
        public void WhenIEnterSortName()
        {
            addUser.EnterSortName();
        }
        [When(@"I select Trustee")]
        public void WhenISelectTrustee()
        {
            addUser.SelectTrustee();
        }
        [When(@"I Click on Epiq Employee Checkbox")]
        public void WhenIClickOnEpiqEmployeeCheckbox()
        {
            addUser.ClickonEpiqEmpCheckbox();
        }
        [When(@"I select Permission '(.*)'")]
        public void WhenISelectPermission(string permission)
        {
            addUser.SelectPermission(permission);
        }
        [When(@"I click on save button on Add User page")]
        public void WhenIClickOnSaveButtonOnAddUserPage()
        {
            addUser.ClickOnSaveButton();
        }
        [When(@"I click on Role Button on Add User Page")]
        public void WhenIClickOnRoleButtonOnAddUserPage()
        {
            addUser.ClickOnRoleButton();
        }
        [When(@"I Select Role '(.*)' on Add role page")]
        public void WhenISelectRoleOnAddRolePage(string role)
        {
            addUser.SelectRole(role);
        }
        [Then(@"I should be on User Edit page")]
        public void ThenIShouldBeOnUserEditPage()
        {
            editUser.IsEditPage().Should().BeTrue();
        }
        [When(@"I click on edit button of User")]
        public void WhenIClickOnEditButtonOfUser()
        {
            editUser = userManagement.ClickOnEditUser();
        }
        [When(@"I edit email Id of user")]
        public void WhenIEditEmailIdOfUser()
        {
            editUser.EditEmail_Id();
        }
        [When(@"I click on Active toggle")]
        public void WhenIClickOnActiveToggle()
        {
            editUser.ClickOnActiveToggle();
        }
        [When(@"I click on save button on Edit User page")]
        public void WhenIClickOnSaveButtonOnEditUserPage()
        {
            editUser.ClickOnSaveButton();
        }
        [Then(@"Validate all password conditions are satisfied on add user")]
        public void ThenValidateAllPasswordConditionsAreSatisfiedOnAddUser()
        {
            addUser.VerifyDangerExist().Should().BeFalse();
        }
        [Then(@"Validate password conditions are not satisfied completly on add user")]
        public void ThenValidatePasswordConditionsAreNotSatisfiedCompletlyOnAddUser()
        {
            addUser.VerifyDangerExist().Should().BeTrue();
        }
        [Then(@"I clear the Password on Add User")]
        public void ThenIClearThePasswordOnAddUser()
        {
            addUser.ClearPassword();
        }

        [Then(@"record should be created on Save")]
        public void ThenRecordShouldBeCreatedOnSave()
        {
            addUser.ClickOnSaveButton();
            addUser.VerifyToastMessage();
        }
        [Then(@"record should be updated on Save")]
        public void ThenRecordShouldBeUpdatedOnSave()
        {
            editUser.ClickOnSaveButton();
            editUser.VerifyToastMessage();
        }
        [Then(@"UserName should be non editable")]
        public void ThenUserNameShouldBeNonEditable()
        {
            editUser.VerifyUserName_NonEditable();
        }

        [Then(@"Password should not be display on editing user")]
        public void ThenPasswordShouldNotBeDisplayOnEditingUser()
        {
            editUser.Is_Password_displayed().Should().BeFalse();
        }
        [When(@"I click on Sorting of Locked Out Column")]
        public void WhenIClickOnSortingOfLockedOutColumn()
        {
            userManagement.ClickOnSoringOfLockedOut();
        }
        [Then(@"I Click on Locked Out link and see Success Toastr message displayed")]
        public void ThenIClickOnLockedOutLinkAndSeeSuccessToastrMessageDispalyed()
        {
            userManagement.ClickOnLockedOutLinkAndValidateToastrMessage();
        }
        [When(@"I see label User Level Permission on top of Perimission Button")]
        public void WhenISeeLabelUserLevelPermissionOnTopOfPerimissionButton()
        {
            addUser.VerifyLable_UserLevelPermission();
        }
        [When(@"I Click On Permission Button on User Page")]
        public void WhenIClickOnPermissionButtonOnUserPage()
        {
            addUser.ClickOnPermissionButton();
        }
        [Then(@"I see '(.*)','(.*)','(.*)' headers on add permisson")]
        public void ThenISeeHeadersOnAddPermisson(string cat, string name, string desc)
        {
            addUser.Verify_Permissions_Headers(cat,name,desc);
        }
        [Then(@"I select few permissions")]
        public void ThenISelectFewPermissions()
        {
            addUser.SelectRandomPermissions();
        }
        [When(@"I click on all red circle button of added permissions")]
        public void WhenIClickOnAllRedCircleButtonOfAddedPermissions()
        {
            addUser.ValidatePemissionDeletion();
        }
        [Then(@"all Pemissions should be deleted")]
        public void ThenAllPemissionsShouldBeDeleted()
        {
            addUser.Is_NoSelectedPermissions_Displayed();
        }
        [When(@"I Click On Circle Arrow")]
        public void WhenIClickOnCircleArrow()
        {
            addUser.ClickOnCircleArrow();
        }
        [Then(@"I See assigned permission to the role on Add Role")]
        public void ThenISeeAssignedPermissionToTheRoleOnAddRole()
        {
            addUser.VerifyPermissionList_UnderRole_onAddRole();
        }
        [When(@"I click on Expand Arrow for one Role")]
        public void WhenIClickOnExpandArrowForOneRole()
        {
            addUser.ClickOnArrow_for_Role_onUserPage();
        }
        [Then(@"I See permissions assigned to the role on Add User Page")]
        public void ThenISeePermissionsAssignedToTheRoleOnAddUserPage()
        {
            addUser.VerifyPermissionList_UnderRole_onUserPage();
        }
        [Then(@"I See '(.*)' not listed in Permission list")]
        public void ThenISeeNotListedInPermissionList(string permission)
        {
            addUser.IsDisplayed_inAddPermission(permission).Should().BeFalse();
        }
        [Then(@"I Click on Cancel Button on Add Permission")]
        public void ThenIClickOnCancelButtonOnAddPermission()
        {
            addUser.ClickOnCancelButton();
        }
        [Then(@"I Click on Cancel Button on Add Role")]
        public void ThenIClickOnCancelButtonOnAddRole()
        {
            addUser.ClickOnCancelButton();
        }
        [When(@"I select and add all permissions from List to user")]
        public void WhenISelectAndAddAllPermissionsFromListToUser()
        {
            addUser.SelectAllPermissions();
        }
        [Then(@"I see no list of pemission displaying on Add Permission")]
        public void ThenISeeNoListOfPemissionDisplayingOnAddPermission()
        {
            addUser.GetTextFromAddPermission().Should().Be("All available permissions have been applied");
        }
        [When(@"I go to top of permission section and Click on permission Button")]
        public void WhenIGoToTopOfPermissionSectionAndClickOnPermissionButton()
        {
            addUser.GoToTopOfSection_N_ClickOnPermissionButton();
        }
        [Then(@"I See '(.*)' not listed in Role list")]
        public void ThenISeeNotListedInRoleList(string role)
        {
            addUser.IsDisplayed_inAddRole(role).Should().BeFalse();
        }
        [When(@"I filter permission '(.*)'")]
        public void ThenIFilterPermission(string permission)
        {
            addUser.FilterPermission(permission);
        }
        [Then(@"I see filter result showing '(.*)' Permissions only")]
        public void ThenISeeFilterResultShowingPermissionsOnly(string permission)
        {
            addUser.PermissionFilterResult(permission);
        }
        [When(@"I Click on Roles Icon on User Management")]
        public void WhenIClickOnRolesIconOnUserManagement()
        {
            userManagement = ((UserMgmt.UserManagement)GetSharedPageObjectFromContext("UserManagement"));
            userManagement.ClickOnRolesIcon();
        }
        [Then(@"I should be on Role Page")]
        public void ThenIShouldBeOnRolePage()
        {
            userManagement.IsDisplay_RolesPage();
        }
        [Then(@"I see Coulmns on Roles Page '(.*)','(.*)','(.*)'")]
        public void ThenISeeCoulmnsOnRolesPage(string h1, string h2, string h3)
        {
            userManagement.ValidateHeadersOnRolesPage(h1,h2,h3);
        }
        [When(@"I Click on Add Roles Button on Role Page")]
        public void WhenIClickOnAddRolesButtonOnRolePage()
        {
            addRole = userManagement.ClickOnAddRoleButton();
        }
        [Then(@"I See the Add-role page")]
        public void ThenISeeTheAdd_RolePage()
        {
            addRole.GetPageHeader().Should().Be("Add Security Role");
        }
        [Then(@"I Add Role Name on Add Role Page")]
        public void ThenIAddRoleNameOnAddRolePage()
        {
            addRole.AddRoleName();
        }
        [Then(@"I add description on Add Role Page")]
        public void ThenIAddDescriptionOnAddRolePage()
        {
            addRole.AddDescription();
        }
        [Then(@"I select permission '(.*)' on Add Role Page")]
        public void ThenISelectPermissionOnAddRolePage(string permisson)
        {
            addRole.SelectPermission(permisson);
        }
        [Then(@"I select permission '(.*)' on edit Role Page")]
        public void ThenISelectPermissionOnEditRolePage(string permisson)
        {
            editRole.SelectPermission(permisson);
        }
        [Then(@"Role should be created on Save")]
        public void ThenRoleShouldBeCreatedOnSave()
        {
            addRole.ClickOnSaveButton();
            addRole.VerifyToastMessage();
        }
        [When(@"I Click on Edit button of role")]
        public void WhenIClickOnEditButtonOfRole()
        {
           editRole = userManagement.ClickOnEditRoleButton();
        }
        [Then(@"I edit role Name on Edit Security Role")]
        public void ThenIEditRoleNameOnEditSecurityRole()
        {
            editRole.EditRoleName();
        }
        [Then(@"I Edit and click on Cancel Button and validate Edit Name is not changed")]
        public void ThenIEditAndClickOnCancelButtonAndValidateEditNameIsNotChanged()
        {
            editRole.ClickCancelAndVerifyRoleName();
        }
        [Then(@"I click on remove for the permissions")]
        public void ThenIClickOnRemoveForThePermissions()
        {
            editRole.DeletePermissions();
        }
        [Then(@"I Add Role Name on edit Role Page")]
        public void ThenIAddRoleNameOnEditRolePage()
        {
            editRole.AddRoleName();
        }
        [Then(@"I add description on edit Role Page")]
        public void ThenIAddDescriptionOnEditRolePage()
        {
            editRole.AddDescription();
        }
    }
}
