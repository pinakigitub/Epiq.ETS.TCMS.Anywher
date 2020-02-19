@Regression	
@ReactJS

@Regression 
Feature: Dashboard
	As a Unity user
	To view office data
	I want to be able to see a Dashboard page

@Sanity
@Dashboard
Scenario: 001 - Change Password Required field Verification
Given I enter to Dashboard page as user Vandita1 with password Welcome444Epiq! and office crose
   Then I see Dashboard header 'Banking Summary'
When I Click on Top User Icon
And I click on change password
   Then Verify all fields are required
   And I click on Cancel Button of Change password
   And I SignOut from the Unity Application

Scenario: 002 - Change Password validation with correct format
Given I enter to Dashboard page as user Vandita1 with password Welcome444Epiq! and office crose
Then I see Dashboard header 'Banking Summary'
When I Click on Top User Icon
And I click on change password
And I Enter the Old Password 'Welcome5678Epiq!'
And I Enter the New Password 'Welcome456Epiq!'
Then Validate all password conditions are satisfied
And I click on Cancel Button of Change password
Then I SignOut from the Unity Application

Scenario: 003 - Change Password validation with Incorrect format
Given I enter to Dashboard page as user Vandita1 with password Welcome444Epiq! and office crose
   Then I see Dashboard header 'Banking Summary'
When I Click on Top User Icon
And I click on change password
And I Enter the Old Password 'Welcome5678Epiq!'
And I Enter the New Password 'Pwd123#'
   Then Validate password conditions are not satisfied completly
   And I clear the New Password Field
When I Enter the New Password '123456789'
   Then Validate password conditions are not satisfied completly
   And I clear the New Password Field
When I Enter the New Password 'ABCDEFGHI'
   Then Validate password conditions are not satisfied completly
   And I clear the New Password Field
When I Enter the New Password 'abcdefghi'
   Then Validate password conditions are not satisfied completly
   And I clear the New Password Field
When I Enter the New Password '@#$%&@#!#'
   Then Validate password conditions are not satisfied completly
    And I click on Cancel Button of Change password
    And I SignOut from the Unity Application

