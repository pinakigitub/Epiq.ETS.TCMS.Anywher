@Regression	
@ReactJS
Feature:ImportAssets
		Navigating to the different sections 
		under Imports
#password changed on June 11th 2018
Scenario: 001 - Imports- Asset Page Header and Count Validation
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When I Click on one AssetToImport link of listed cases
	Then I see header on Import Assets Page
	And I see the count for Assets to Import
	And I see the count for Assets in case
	Then I SignOut from the Unity Application

Scenario: 002 - Imports- Asset To Import Tab Columns Header Validation
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on Assets to Import are 'DESCRIPTION' 'FA' and 'UTC'
	When I click on Row Expand Button of Assets to Import
	Then I see all Hidden coulumns hearder
	Then I SignOut from the Unity Application

Scenario: 003 - Imports- Asset In Case Tab - Columns Header Validation
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on Assets In Case are 'DESCRIPTION' 'UTC' and 'REMAINING'
	When I click on Row Expand Button of Assets in Case
	Then I see all Hidden coulumns hearder for Assets in case
	Then I SignOut from the Unity Application

#@US230561 
#Scenario: 004 - Imports- Asset To Import  Tab- Import and Rejection button validation
#	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
#	When I Click on one AssetToImport link of listed cases
#	Then I see Import and Ignore button Disabled
#	#When I click on one checkbox of listed assets
#	Then I click on checkbox on tile
#	Then I see Import and Ignore button Enabled
#	And I SignOut from the Unity Application

#@US230561-- covered in sceanrio 18-20
#Scenario: 005 - Imports- Asset To Import Tab- Import Validation
#	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
#	When I Click on one AssetToImport link of listed cases
#	#And I click on one checkbox of listed assets
#	Then I click on checkbox on tile
#	Then I should be able to Import Assets and get Success Message
#	And Same Asset should not be listed in Asset to import Tab
#	And I see same Asset in Asset in Case Tab
#	And I SignOut from the Unity Application
#
#@US230565
#Scenario: 006 - Imports- Asset To Import Tab- Ignore Validation
#	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
#	When I Click on one AssetToImport link of listed cases
#	#And I click on one checkbox of listed assets
#	Then I click on checkbox on tile
#	Then I should be able to click on Ignore Assets and get Success Message
#	And Same Asset should not be listed in Asset to import Tab
#	And Same Asset should not be listed in Asset in Case Tab
#	And I SignOut from the Unity Application

Scenario: 007 - Imports-Asset Page Filter Options-Default Values
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When User clicks on the filter options of Import Asset Page
	And Validate by default the imports text is'Waiting to import'
	And Validate by default the Case status is 'Open'
	Then User clicks on cross button of the filter option
	And Validate the Header title of Import Page
	Then 'DashboardImport Assets' Breadcrumb should display
	Then I SignOut from the Unity Application

Scenario: 008 - Imports-Asset Page Filter Options-All values
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When User clicks on the filter options of Import Asset Page
	And Enter imports text as'imported'
	And Enter the Case status as 'Closed'
	And User clicks on Close button of the filter option
	When User clicks on the filter options of Import Asset Page
	Then Clicks on the reset button of the filter options
	When User clicks on Close button of the filter option
	Then I SignOut from the Unity Application

Scenario: 009-Imports-Assets-Inline Editing
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on Assets to Import are 'DESCRIPTION' 'FA' and 'UTC'
	Then 'DashboardImport AssetsAssets' Breadcrumb should display
	#And I see header on Import Assets Page
	And Inline edit the Description as 'Testing automation inline edit'
	#And Inline edit the FA as '03/23/2018'
	And I SignOut from the Unity Application

Scenario: 010-Imports-Assets-View Permission
	Given I enter to Import Assets page as user AutomationView with password Welcome456Epiq! and office crose
	Then I see the Security Warning Icon in Orange
	And I SignOut from the Unity Application

Scenario Outline: 011_IMPORT_ASSETS - Verify PageSize under Pagination
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When I Select the PageSize as <PageSize> under Pagination Section in import asset page
	And I see the Assets Table Contains the Same Number of Rows as per Selected <PageSize>
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize | 
	| 10       | 
	| 25       | 
	| 50       |

Scenario: 012 - Imports- View Documents-Import Assets Tab Columns Header Validation and count
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on View Documents Tab are 'DOC #' 'SOURCE' and 'DESCRIPTION'
	And Validate the count of the documents in the view document tab
	And I SignOut from the Unity Application

Scenario: 013 - Imports-Description Inline Edit Count length.
		Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
		When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on Assets to Import are 'DESCRIPTION' 'FA' and 'UTC'
	Then 'DashboardImport AssetsAssets' Breadcrumb should display
	#And I see header on Import Assets Page
	And Inline edit the Description as 'The length of the characters enter is greaterthan sixty count testing the US'
		Then I SignOut from the Unity Application

@US256003
Scenario Outline: 014 - Imports- Validate the Header Title 
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	Then Validate the Record Default Count on the Page
	Then Validate the header tilte 'Assets to Import '
	When User clicks on the filter options of Import Asset Page
	And Enter imports text as '<Imports>'
	And Enter the Case status as 'Open'
	And User clicks on Close button of the filter option
	Then Validate the count after filter applied
	Then Validate the header tilte '<Header> '
	Then I SignOut from the Unity Application
	Examples:
	| Imports			 | Header            |
	| Imported			 | Imported Assets   |			                                             
	| Ignored			 | Ignored Assets    |
	
@US256004	
Scenario: 015 - Imports- Redirection of caselevel navigation
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '12-70476' On The Universal Search Section Input
	And I Click on the Case Result '12-70476'
	Then Validate the Record Default Count on the Page
	And Validate the header tilte 'Assets to Import '
	And I see case as 'open' in green
	And CaseType as 'Asset' in Orange
	Then Validate the message as 'No assets to import'
	And I Click on Cross Button on Universal search box
	And Validate the Record Default Count on the Page
	And Validate the header tilte 'Assets to Import '
	And I SignOut from the Unity Application

@US230558	
Scenario: 016 - Import Assets:Settings Functionality
	Given I enter to Import Assets page as superuser
	Then I see header on Import Assets Page
	When I click on settings icon
	Then verify the subheader 'Settings Management'
	Then verify the expand functionality on 'IMPORT;BATCH OPTIONS' section
    Then verify the displayed options in 'IMPORT' section as 'Set the Trustee Value to the Schedule's Market Value / Owned Value;Set the Abandonment status to "Yes";Set the Fully Administered date to import date;Import Assets in UPPERCASE'
	Then verify the displayed options in 'BATCH OPTIONS' section as 'Set the Abandonment status to "Yes";Set the Remaining value to 0.00;Do not set the Fully Administered date;Set the Fully Administered date to import date;Prompt for a date to set the Fully Administered date to when the batch is processed'
    Then I save the settings
	Then I SignOut from the Unity Application


@US245005
Scenario: 017 - Viewing of Documents-Import to Asset
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '15-70235' On The Universal Search Section Input
	And I Click on the Case Result '15-70235'
	When I Click on one AssetToImport link of listed cases
	Then I click on View Documents Tab
	And I click on Expand button
	Then I SignOut from the Unity Application	

@US293919@US230561
Scenario: 018 - Import Assets - Validate state of Import option at case level
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '15-70235' On The Universal Search Section Input
	And I Click on the Case Result '15-70235'
	When I Click on one AssetToImport link of listed cases
	And I View that Import Option is Disabled
	#When I click on one checkbox of listed assets
	Then I click on checkbox on tile
	Then I see Import and Ignore button Enabled
	And I SignOut from the Unity Application

@US293919@US293917
Scenario: 019 - Import Assets - Verify filter functionality and data on Import assets page
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	Then  I see Import Management header
	Then 'DashboardImport Assets' Breadcrumb should display
	And I see subheader as 'Assets to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'
	When I 'CLOSE' Filter option
	Then I see subheader as 'Imported Assets'
	When Click on filter option on tile page
	Then Filter with 'IMPORTED' as 'Ignored'
	When I 'CLOSE' Filter option
	Then I see subheader as 'Ignored Assets'
	And I SignOut from the Unity Application

@US293919
Scenario: 020 - Import Assets - Filter Ignored Assets and perform import action
	Given I enter to Import Assets page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '15-21754' On The Universal Search Section Input
	And I Click on the Case Result '15-21754'
	When I Click on one AssetToImport link of listed cases
	Then I click on checkbox on tile
	When I click import 'IMPORT' in Assets to import tile
	Then I SignOut from the Unity Application