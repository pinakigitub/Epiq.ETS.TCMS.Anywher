@Regression	
@ReactJS	
Feature: Participants 
	Navigating to the different sections 
		under Participants page


Scenario: 001 - Cases- Participants page verification
	Given I enter to Participants page as superuser
	Then 'Participant Management' header should be displayed
	When I click on Filter	
	Then 'FILTER OPTIONS' should be displayed
	When I click on close 
	Then 'FILTER OPTIONS' should be closed
		And I SignOut from the Unity Application

	
#Scenario: 002 - Cases- Participants Breadcrumb and sorting verification
#	Given I enter to Participants page as superuser
#	Then Breadcrumb should be displayed
#	And 'ROLE' Should be able to sort
#	And 'TYPE' Should be able to sort
#	And 'NAME' Should be able to sort
#	    And I SignOut from the Unity Application


Scenario: 003 - Cases- Participants Expand row for more columns
	Given I enter to Participants page as superuser
	When I click on Row Expand button
	Then I should be able to see column ADDRESS
	Then I should be able to see column SSN
	Then I should be able to see column DRIVERS LICENSE
	Then I should be able to see column TAX ID
		And I SignOut from the Unity Application

Scenario: 004 - Cases- Participants Filter Options Validation
	Given I enter to Participants page as superuser
	Then 'Participant Management' header should be displayed
	When I click on Filter 
	#And I search '09-28278' and click on '09-28278 / 201 ST. LOUIS AVENUE, LLC'
	And Enter Participant Name 'ROSE'
	And I click on close
		Then Participants records should be displayed
		And I SignOut from the Unity Application


Scenario: 005 -  Cases- verify Participants Pagination
	Given I enter to Participants page as superuser
	Then  Page Count should be displayed
	And pagination should be displayed
	And I SignOut from the Unity Application
		


Scenario: 006 - Cases- Participant filters funnel Search and Clear
	Given I enter to Participants page as superuser
	When I click on Filter 
	#And I search '09-28278' and click on '09-28278 / 201 ST. LOUIS AVENUE, LLC'
	And Enter Participant Name 'Rose'
	And I select Role 'Trustee'	
	And I click on close
	Then Participant result should contains 'ROSE' 'Trustee' 
	When I click on Filter
	And Click on reset button on participant filter
	And I click on close
	Then default participant result should be present
		And I SignOut from the Unity Application


Scenario: 007 - Cases- Participant filters dropdown X validation
	Given I enter to Participants page as superuser
	When I click on Filter 
	#And I search '09-28278' and click on '09-28278 / 201 ST. LOUIS AVENUE, LLC'
	And Enter Participant Name 'ROSE'
	And I select Role 'Trustee'	
	And I click on close
	Then Participant result should contains 'ROSE' 'Trustee'
	When I click on Filter
	When I Click on x button of Role
	And I click on close
	Then Participant result should contains 'ROSE' ''
		And I SignOut from the Unity Application

Scenario: 008 - Cases- Participant - SSN Full View Permission validation
	Given I enter to Participants page as superuser
	When I click on Filter 
	#And I search '09-28278' and click on '09-28278 / 201 ST. LOUIS AVENUE, LLC'
	And Enter Participant Name 'ROSE'
	And I select Role 'Trustee'	
	And I click on close
	And I click on Row Expand button
	Then I should be able to view Full SSN 
		And I SignOut from the Unity Application


Scenario: 009 - Cases- Participant - No SSN View Permission validation
	Given I enter to Participants page as user NoSSNUser1 with password Welcome678Epiq! and office crose
	When I click on Filter 
	#And I search '09-28278' and click on '09-28278 / 201 ST. LOUIS AVENUE, LLC'
	And Enter Participant Name 'ROSE'
	And I select Role 'Trustee'	
	And I click on close
	And I click on Row Expand button
	Then I should not be able to view SSN No
	    And I SignOut from the Unity Application

Scenario: 010 - Cases- Participant - Partial SSN View Permission validation
	Given I enter to Participants page as user PartialSSNUser1 with password Welcome345Epiq! and office crose
	When I click on Filter 
	#And I search '09-28278' and click on '09-28278 / 201 ST. LOUIS AVENUE, LLC'
	And Enter Participant Name 'ROSE'
	And I select Role 'Trustee'	
	And I click on close
	And I click on Row Expand button
	Then I should be able to view Partial SSN No
	    And I SignOut from the Unity Application
