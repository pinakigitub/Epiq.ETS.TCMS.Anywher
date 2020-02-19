@Regression
@Smoke
@ReactJS	
Feature: login
	In order to access the system
	As a user of Unity
	I want to be able to see the login page and login to the system with my credentials: user, password and office

@login @US10882 @TC11537 
Scenario Outline: Login button should not be active until all fields are data filled
	Given I enter to Unity Login page
	When I fill in all fields with <username>, <password> and <office>
	#Then I see the login button is <active_inactive>
	Examples:
	|	username	|	password 	|	office	|	active_inactive |
	|	Automation	|				|			|	inactive	|
	|				|	Automation@1 	|			|	inactive	|
	#|				|				|	crose	|	inactive	|
	|	Automation	|	Automation@1	|			|	inactive	|
	#|	conversion	|				|	crose	|	inactive	|
	#|				|	conversion	|	crose	|	inactive	|
	#|	conversion	|	1-Password	|	crose	|	active		|



@login @US10882 @TC11537 
Scenario Outline: Login button should become inactive if I fill all fields and then remove one
	Given I enter to Unity Login page
	When I fill in all fields with <username>, <password> and <office>
	And I remove the value from <field>
	#Then I see the login button is <active_inactive>
	Examples:
	| username   | password   | office | field    | active_inactive |
	| Automation | Automation1!  | crose  | username | inactive        |
	#| conversion | 1-Password | crose  | password | inactive        |
	#| conversion | 1-Password | crose  | office   | inactive        |


@Regression @Sanity
@login @US10882 @TC11538 
Scenario Outline: Failed login - Try to login with <username>, <password> and <office> and verify access is denied
	Given I enter to Unity Login page
	When I try to login with credentials <username>, <password> and <office>
	Then Login Page displays an error message reading 'Login Failed. Either the username or password was incorrect or the user doesn't have access to this office'
	#And I see the 'username' field input value is ''
	#And I see the 'password' field input value is ''
	#And I see the 'office' field input value is ''
	Examples:
	| username	| password 	| office	|
	| wronguser	| anything 	| anything	|
	| Automation	| wrongpassword 	| crose	|
	#| conversion	| conversion 	| wrongofficename	|
	#| conversion	| wrongpassword 	| wrongofficename	|


@Regression @Sanity
@login 
@US10882 @TC11545 
@US10886 @TC11573 
@US36895 @TC41272
@US78063 @TC86537
Scenario Outline: Login Page - Successful login
	Given I enter to Unity Login page
	When I try to login with credentials <username>, <password> and <office>
	Then I see the Dashboard page
	#And I can see the Universal App Bar and the Main Nav Region
	Examples:
	| username	|	password	    |	office	 |
	|Automation	|	Automation1! 	|	crose	 |
	

Scenario: Login with view permission - Successful login
	Given I enter to Unity Login page
	When I try to login with view credentials 'AutomationView', 'Welcome456Epiq!' and 'crose'
	Then I see the Dashboard page


@login @US10882 @TC11549 
Scenario: Login Page - Succesful login after 3 failed attempts
	Given I enter to Unity Login page
	When I try to login with credentials Automation, wrongpassword and conversion
	#And I try to login with credentials conversion, wrongpassword and conversion
	#And I try to login with credentials conversion, wrongpassword and conversion
	And I try to login with credentials Automation, Automation1! and crose
	Then I see the Dashboard page
	#TODO REVIEW EXECUTION TIME

@login @US10882 @TC11550
Scenario: Login Page - Succesful login after 3 failed attempts, followed by a failed attempt
	Given I enter to Unity Login page
	When I try to login with credentials Automation, wrongpassword and crose
	#And I try to login with credentials conversion, wrongpassword and crose
	#And I try to login with credentials conversion, wrongpassword and crose
	And I try to login with credentials Automation, Automation1! and crose
	And I do Logout
	And I try to login with credentials Automation, wrongpassword and crose
	Then Login Page displays an error message reading 'Login Failed. Either the username or password was incorrect or the user doesn't have access to this office'
	#TODO REVIEW EXECUTION TIME

@login @US10882 @TC11554 
Scenario: Login Page - Successful Login after 4 failed login attempts with a valid username but wrong office
	Given I enter to Unity Login page
	When I try to login with credentials Automation, wrongpassword and wrongoffice
	#And I try to login with credentials conversion, wrongpassword and wrongoffice
	#And I try to login with credentials conversion, wrongpassword and wrongoffice
	##And I try to login with credentials conversion, wrongpassword and wrongoffice
	And I try to login with credentials Automation, Automation1! and crose
	Then I see the Dashboard page
	#TODO REVIEW EXECUTION TIME

@login @US10882 @TC11555 
Scenario: Login Page - Successful Login after 4 failed login attempts with the same user but different office
	Given I enter to Unity Login page
	When I try to login with credentials Automation, wrongpassword and crose
	#And I try to login with credentials conversion, wrongpassword and crose
	#TODO for now using an incorrect office name, but should be a correct one
	And I try to login with credentials Automation, wrongpassword and wrongoffice
	#And I try to login with credentials conversion, wrongpassword and wrongoffice
	And I try to login with credentials Automation, Automation1! and crose
	Then I see the Dashboard page
	#TODO REVIEW EXECUTION TIME

@login @US10882 @TC11854 
Scenario: Login Page - Successful Login after 4 failed login attempts with the same user but different office (2)
	Given I enter to Unity Login page
	When I try to login with credentials Automation, wrongpassword and crose
	#And I try to login with credentials conversion, wrongpassword and crose
	#TODO for now using an incorrect office name, but should be a correct one
	#And I try to login with credentials conversion, wrongpassword and wrongoffice
	#And I try to login with credentials conversion, wrongpassword and wrongoffice
	And I try to login with credentials Automation, Automation1! and crose
	Then I see the Dashboard page


#ignoring this test until locked message is correct (will fail otherwise) and to not lock the user.
#@DoNotExecute @login @US10882 @TC11544
#@Ignore @DoNotExecute
#Scenario: Login Page - After 4 failed login attempts, the user account becomes locked
#	Given I enter to Unity Login page
#	When I try to login with credentials conversion, wrongpassword and crose
#	And Login Page displays an error message reading 'Login Failed.'
#	And I try to login with credentials conversion, wrongpassword and crose
#	And Login Page displays an error message reading 'Login Failed.'
#	And I try to login with credentials conversion, wrongpassword and crose
#	And Login Page displays an error message reading 'Login Failed.'
#	And I try to login with credentials conversion, wrongpassword and crose	
#	And Login Page displays an error message reading 'Login Failed. Your credentials are incorrect or your account is locked. Please contact support for assistance'
#	And I try to login with credentials conversion, wrongpassword and crose
#	Then Login Page displays an error message reading 'Login Failed. Your credentials are incorrect or your account is locked. Please contact support for assistance'