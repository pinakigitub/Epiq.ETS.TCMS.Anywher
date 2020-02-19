@Regression	
@ReactJS	
Feature: ImportCaseDateChanges


@US293965
Scenario: 001_ImportCaseDateChanges- Validate Gear Button is Displayed
	Given I enter to Imports Case Data Changes page as superuser
	Then  I see Case Import Reconciliation header
	Then 'Dashboard Case Data Changes' Breadcrumb should display
	Then I see subheader as 'Case Data Changes'
	#Then I see GearButton is Displayed beside to Case Data Changes Header
	When I Click on GearButton
	Then 'Settings Management' Breadcrumb should display
	Then 'CaseDataChangesOffice Settings Management' Breadcrumb should display
	And I SignOut from the Unity Application

@US293943
Scenario: 002_ImportCaseDateChanges- Verify column names and validate for no data display message
	Given I enter to Imports Case Data Changes page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	Then  I see Case Import Reconciliation header
	Then 'Dashboard Case Data Changes' Breadcrumb should display
	Then I see subheader as 'Case Data Changes'
	Then I view column names in ImportCaseData table
	Then I view breifcase icon is displayed
	And I view no data to display message
	And I SignOut from the Unity Application