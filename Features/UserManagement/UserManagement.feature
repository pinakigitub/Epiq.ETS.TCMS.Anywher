@Regression	
@ReactJS	
Feature: UserManagement 
	Navigating to the different sections 
		under User Management page

@mytag
Scenario: 001 - User Management page Validation
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	Then Users result should be present
	When I click on Add User Button on User Management
	Then 'Add User' header should be displayed on AddUser Page
	And I SignOut from the Unity Application

Scenario: 002 - Add User - back to User Management link validation
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	Then I should be on Add User page
	Then I click on BreadCrumb 'User Management'
	Then Then I should be on User Management page
	And I SignOut from the Unity Application

Scenario: 003 - Add User - Add user validation
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	Then I should be on Add User page
	When I enter User Name
	And I enter Password 'TestUser@1'
	And I enter Email
	And I enter Display Name
	And I enter Sort Name
	And I select Trustee
	Then record should be created on Save 
	Then I SignOut from the Unity Application

@US232439 @US214368
Scenario: 004 - Add User - Add user with Role and permission
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	Then I should be on Add User page
	When I enter User Name
	And I enter Password 'TestUser@1'
	And I enter Email 
	And I enter Display Name
	And I enter Sort Name
	And I select Trustee
	And I click on Role Button on Add User Page
	And I Select Role 'Assets' on Add role page
	And I select Permission 'Asset'
	Then record should be created on Save 
	Then I SignOut from the Unity Application

	
Scenario: 005 - Edit the user details validation
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on edit button of User
	Then I should be on User Edit page
	When I click on Active toggle 
	When I edit email Id of user
	Then record should be updated on Save 
	Then I SignOut from the Unity Application

Scenario: 006 - Password validation on Add User with correct format
	Given I enter to UserManagement page as superuser
	     Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	     Then I should be on Add User page
	When I enter User Name
	And I enter Password 'TestUser@1'
	    Then Validate all password conditions are satisfied on add user
	Then I SignOut from the Unity Application

Scenario: 007 - Password validation on Add User with Incorrect format
	Given I enter to UserManagement page as superuser
	     Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	     Then I should be on Add User page
	When I enter User Name
	And I enter Password 'Pwd123#'
	    Then Validate password conditions are not satisfied completly on add user
		And I clear the Password on Add User
	When I enter Password '123456789'
	    Then Validate password conditions are not satisfied completly on add user
		And I clear the Password on Add User
	When I enter Password 'ABCDEFGHI'
	    Then Validate password conditions are not satisfied completly on add user
		And I clear the Password on Add User
	When I enter Password 'abcdefghi'
	    Then Validate password conditions are not satisfied completly on add user
		And I clear the Password on Add User
	When I enter Password '@#$%&@#!#'
	    Then Validate password conditions are not satisfied completly on add user
	    And I SignOut from the Unity Application

@US199377
Scenario: 008 - Edit a user - In Office
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on edit button of User
	Then UserName should be non editable
	And Password should not be display on editing user  
	And I SignOut from the Unity Application

@US199707
Scenario: 009- Make the user Locked Out
    Given I enter to Unity Login page
	When I try to login with credentials TestuserA, WrongPwdA and crose
	And I try to login with credentials TestuserA, WrongPwdB and crose
	And I try to login with credentials TestuserA, WrongPwdC and crose
	And I try to login with credentials TestuserA, WrongPwdD and crose
	And I try to login with credentials Automation, Automation1! and crose
	Then I SignOut from the Unity Application

#Bug has been raised for sorting feature which is the root cause for failure of this scenario
#@US199707
#Scenario: 010 - Validation on Unlock a User 
#	Given I enter to UserManagement page as superuser
#	Then 'User Management' header should be displayed on User Management Page
#	When I click on Sorting of Locked Out Column
#	Then I Click on Locked Out link and see Success Toastr message displayed
#	And I SignOut from the Unity Application

@US232439
Scenario: 011 - Add User - Verify Permission Section
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	And I see label User Level Permission on top of Perimission Button
	When I Click On Permission Button on User Page
	Then I see 'CATEGORY','NAME','DESCRIPTION' headers on add permisson
	Then I select few permissions
	When I click on all red circle button of added permissions
	Then all Pemissions should be deleted
	And I SignOut from the Unity Application

@US214368
Scenario: 012 - Add User - Verify Role Section
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	And I click on Role Button on Add User Page
	When I Click On Circle Arrow
	Then I See assigned permission to the role on Add Role
	When I Click On Circle Arrow	 
	And I Select Role 'Assets' on Add role page
	And I click on Expand Arrow for one Role
	Then I See permissions assigned to the role on Add User Page
	And I SignOut from the Unity Application

@US214371
Scenario: 013 - Add User -Verification on Permission in list after adding on User
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	And I select Permission 'Asset'
	When I Click On Permission Button on User Page
	Then I See 'Asset' not listed in Permission list
	And I Click on Cancel Button on Add Permission
	And I SignOut from the Unity Application

@US214371
Scenario: 014 - Add User -Verification on Permission List after adding ALL on User
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	And I Click On Permission Button on User Page
	And I select and add all permissions from List to user
	And I go to top of permission section and Click on permission Button
	Then I see no list of pemission displaying on Add Permission
	And I Click on Cancel Button on Add Permission
	And I SignOut from the Unity Application

@US232434
Scenario: 015 - Add User - Verification on Role in list after adding on User
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	And I click on Role Button on Add User Page
	And I Select Role 'Assets' on Add role page
	And I click on Role Button on Add User Page
	Then I See 'Assets' not listed in Role list
	And I Click on Cancel Button on Add Role
	And I SignOut from the Unity Application

@US213868
Scenario: 016 - Add Permissions Modal - Filter Option Validation
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I click on Add User Button on User Management
	And I see label User Level Permission on top of Perimission Button
	When I Click On Permission Button on User Page
	When I filter permission 'Admin'
	Then I see filter result showing 'Admin' Permissions only
	And I Click on Cancel Button on Add Permission
	And I SignOut from the Unity Application

@US199844
Scenario: 017 - Roles - Add Roles Page Validation
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
	When I Click on Roles Icon on User Management
	Then I should be on Role Page
	Then I see Coulmns on Roles Page 'NAME','DESCRIPTION','TYPE'
	When I Click on Add Roles Button on Role Page
	Then I See the Add-role page
	Then I SignOut from the Unity Application

@US199844
Scenario: 018 - Roles - Creating Roles Validation
	Given I enter to UserManagement page as superuser
	When I Click on Roles Icon on User Management
	When I Click on Add Roles Button on Role Page
	Then I Add Role Name on Add Role Page
	And I add description on Add Role Page
	And I select permission 'Admin' on Add Role Page
	And Role should be created on Save 
	Then I SignOut from the Unity Application

@US199844
Scenario: 019 - Roles - Cancel on Editing Role
	Given I enter to UserManagement page as superuser
	When I Click on Roles Icon on User Management
	When I Click on Edit button of role
	Then I Edit and click on Cancel Button and validate Edit Name is not changed
	Then I SignOut from the Unity Application

Scenario: 020 - Roles - Verify Roles Page and edit the roles
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
    When I Click on Roles Icon on User Management
	When I Click on Edit button of role
    Then I select permission 'Asset' on edit Role Page
	Then I SignOut from the Unity Application

Scenario: 021 - Roles - Edit the roles after removing the data
	Given I enter to UserManagement page as superuser
	Then 'User Management' header should be displayed on User Management Page
    When I Click on Roles Icon on User Management
	When I Click on Edit button of role
	Then I Add Role Name on edit Role Page
	And I add description on edit Role Page
	And I select permission 'Task' on edit Role Page
	Then I SignOut from the Unity Application

 @US237089
Scenario: 022 - Roles Enhancement in User Management
       Given I enter to UserManagement page as superuser
       When I Click on Roles Icon on User Management
       When I Click on Edit button of role
       Then I Edit and click on Cancel Button and validate Edit Name is not changed
       Then I SignOut from the Unity Application

 @237089
Scenario: 023 - Roles Enhancement in User Management
       Given I enter to UserManagement page as superuser
       When I Click on Roles Icon on User Management
       When I Click on Add Roles Button on Role Page
       Then I Add Role Name on Add Role Page
       And I add description on Add Role Page
       And I select permission 'Admin' on Add Role Page
       And Role should be created on Save 
       Then I SignOut from the Unity Application