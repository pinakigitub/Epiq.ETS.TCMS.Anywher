@Regression	
@ReactJS
Feature: SuperAdmin
In order to be able to delete Assets, Dockets, Documents and make additional data updates

@US248195
Scenario:001_SuperAdmin - Document Tab, Restore, Delete, Filter
	Given I enter to Dashboard page as superuser
	And I select 'Super Admin' under User icon
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I select tab 'DOCUMENTS'
	When I click on filter search Icon
	When I Select 'Document Status' as 'Not Deleted'
	Then I Click on Close Button 
	And I select the document with Description 'Automation Documents Testing'
	And I see DELETE button in Enabled State
	Then I Select '2','DELETE'
	And I click 'YES'
	When I click on filter search Icon
	When I Select 'Document Status' as 'Deleted'
	Then I Click on Close Button 
	Then I see the Records should contain '01-21039 - Aronson 9th Fee App.pdf'
	And I see Restore button in 'Disabled' state
	And I select the document with Description '[1].pdf'
	And I see Restore button in 'Enabled' state
	And I Select '2','RESTORE'
	And I click 'YES'
	When I click on filter search Icon
	And I click on reset button of documents filter
	Then I Click on Close Button 
	And I see the Records should contain 'DESCRIPTION-01-21039 - Aronson 9th Fee App.pdff'
	Then I SignOut from the Unity Application

@US236897
Scenario: 002_SuperAdmin - No permissions of Super Admin
	Given I enter to Dashboard page as user Vandita1 with password Welcome444Epiq! and office crose
	And I should not be able to see 'Super Admin' under User icon
	Then I SignOut from the Unity Application

@US236897
Scenario: 003_SuperAdmin - Non Epiq Super Admin
	Given I enter to Dashboard page as user SuperAdmin with password Welcome123Epiq! and office crose
	And I should be able to see 'Super Admin' under User icon
	And I select 'Super Admin' under User icon
	And I see internal message '404: Page Not Found' and 'We did not find the requested page, please use the navigation menu at the top.'
	Then I SignOut from the Unity Application

@US236897
Scenario: 004_SuperAdmin - Page Structure
	Given I enter to Dashboard page as superuser
	And I select 'Super Admin' under User icon
	And I see message 'Please select a case above.'
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I see office as 'OFFICE: CRose' 
	Then I see the DebtorName 'FINAL ANALYSIS INC.' and CaseNum '01-21039'
	And I see Admin Tab 'ASSETS'
	And I see Admin Tab 'DOCKETS'
	And I see Admin Tab 'DOCUMENTS'
	Then I SignOut from the Unity Application

@US248195
Scenario: 005_SuperAdmin - Documents Tab table columns
	Given I enter to Dashboard page as superuser
	And I select 'Super Admin' under User icon
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I select tab 'DOCUMENTS'
	And I see SuperAdmin Table header contains '#;DESCRIPTION;FILE NAME;FILED DATE'
	Then I SignOut from the Unity Application

@US248194
Scenario: 006_SuperAdmin - Assets Tab
Given I enter to Dashboard page as superuser
	And I select 'Super Admin' under User icon
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I select tab 'ASSETS'
	And I see SuperAdmin Table header contains 'ASSET #;DESCRIPTION;SALES;TRUSTEE'
	And I verify '1' caution header 'CAUTION THIS IS A HARD DELETE'
	And I see 'DELETE' button '1' in 'Disabled' state
	And I select selection column '3' when sales of Asset is null
	And I see 'DELETE' button '1' in 'Enabled' state
	Then I Select '1','DELETE'
	And I clicked on 'NO'
	#And I click on 'NO'
	Then I see Asset# in Ascending order
	Then I SignOut from the Unity Application

@US248199
Scenario:007_SuperAdmin - Dockets Tab
Given I enter to Dashboard page as superuser
	And I select 'Super Admin' under User icon
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I select tab 'DOCKETS'
	And I see SuperAdmin Table header contains '#;DOCKET NAME;FILED ON DATE;DOCUMENT COUNT'
	And I verify '2' caution header 'CAUTION THIS IS A HARD DELETE'
	And I see 'DELETE' button '2' in 'Disabled' state
	And I select Tab '2' Selection Column of row '3'
	And I see 'DELETE' button '2' in 'Enabled' state 
	Then I Select '2','DELETE'
	And I clicked on 'NO'
	Then I see Docket# in Ascending order
	Then I SignOut from the Unity Application

@US251107
Scenario:008_Setting Management - Page Verification
	Given I enter to Dashboard page as superuser
	And I select 'Settings Management' under User icon
	Then 'Settings Management' Breadcrumb should display
	When I click on meeting link in the page
	When I click on AssetsLink on the page
	When I should able to click on ClaminsLink in the page
	Then I SignOut from the Unity Application

@US251108
Scenario:009_Setting Management - Assets Page verification and selection from Import
	Given I enter to Dashboard page as superuser
	And I select 'Settings Management' under User icon
	Then 'Settings Management' Breadcrumb should display
	When I click on AssetsLink on the page
	When I click on Imports section to select the options
	When I click on Batch options to see list 
	Then I SignOut from the Unity Application
	
@US251108
Scenario:010_Setting Management - Assets Page Opions Selection from Import and Batch
	Given I enter to Dashboard page as superuser
	And I select 'Settings Management' under User icon
	Then 'Settings Management' Breadcrumb should display
	When I click on AssetsLink on the page
	When I click on Imports section to select the options
	#When I can able to select the options from the menu
	When I can able to select the options from the Batch Settings
    When I can save the selected seetings
	Then I SignOut from the Unity Application

@US259336
Scenario:011_Setting Management - 341Meeting Settings
	Given I enter to Dashboard page as superuser
	And I select 'Settings Management' under User icon
	Then 'Settings Management' Breadcrumb should display
	When I select tab '341 MEETINGS'
	Then select data from 'ORDER' section 'SELECT TRUSTEE;SORT BY;THEN BY;PRO SE' as 'CHERYL E. ROSE;Attorney;Case;First;'
	Then I Select '2','SAVE'
	Then verify the notification title 'Success'
	Then verify the notification message 'Changes to settings have been saved.'
	Then I SignOut from the Unity Application

@US259323 @US259324 @259325
Scenario:012_Setting Management - Import Claims Settings
	Given I enter to Dashboard page as superuser
	And I select 'Settings Management' under User icon
	Then 'Settings Management' Breadcrumb should display
	When I select tab 'CLAIMS'
	Then I Verify the General Import Defaults Pane
	Then I Verify for Import Claim in UpperCase
	Then I Verify for Import Creditor Matrix Data
	Then I Verify Import Creditor Data on Demand
	Then I SignOut from the Unity Application
