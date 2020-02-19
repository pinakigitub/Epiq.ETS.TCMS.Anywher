@Regression	
@ReactJS	
Feature: ImportsDocuments

@US264016 @US264017 @US264018
Scenario: 001_ImportDocuments- Validate Breadcrumb, Filters, Header
	Given I enter to Imports Documents page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Documents' Breadcrumb should display
	Then I see subheader as 'Documents to Import'
	#Then verify the columns from '2' to '6' displayed on 'epiq-outer-container' as 'CASE #;DEBTOR;DOCUMENTS;STATUS;CASE'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Waiting to import'
	Then Filter with 'CASE STATUS' as 'All'
	When I 'CLOSE' Filter option
	When I Click on one Document link of listed cases
	#Then I see the Visible headers on Documents In Case are 'DOC #' 'FILE NAME' and 'DESCRIPTION'
	When I Click on one DocumentsToImport Tile
	Then I see Import and Ignore button Disabled
	Then I click on checkbox on tile
	#When I click on one checkbox of listed assets
	Then I see Import and Ignore button Enabled
	And Inline edit the Description as 'Testing automation inline edit for Testing'
	And I SignOut from the Unity Application

	@US270475
Scenario: 002_ImportDocuments- Filtering of 2 Tiles
	Given I enter to Imports Documents page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Documents' Breadcrumb should display
	Then I see subheader as 'Documents to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Waiting to import'
	Then Filter with 'CASE STATUS' as 'All'
	When I 'CLOSE' Filter option
	When I Click on one Document link of listed cases
	When Click on filter option
	Then Filter with 'IMPORT STATUS' as 'Waiting to import'
	And I SignOut from the Unity Application

@US293964
Scenario: 003_ImportDocuments- Validate Gear Button is Displayed
	Given I enter to Imports Documents page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Documents' Breadcrumb should display
	Then I see subheader as 'Documents to Import'
	Then I see GearButton is Displayed beside to Documents to Import Header
	When I Click on GearButton
	Then 'Settings Management' Breadcrumb should display
	Then 'Import DocumentsOffice Settings Management' Breadcrumb should display
	And I SignOut from the Unity Application


