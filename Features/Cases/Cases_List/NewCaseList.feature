@Regression	
@ReactJS	
@FailureCases
@CaseListPage

Feature: NewCaseList
@CaseSearch 
Scenario: 001_Case List - Verify CaseList page Layout 
	Given I enter to Case List page as superuser
	And I see Table header contains 'DEBTOR;PETITION DATE;DEBTOR ATTORNEY;ASSET STATUS;CASE STATUS'
	When I click on Dashboard Link under Case Management
	Then I see the Dashboard page
	And I SignOut from the Unity Application

Scenario: 002_Case List - Verify CaseList Reset Filters functionality
	Given I enter to Case List page as superuser
	When I click on 341 Meeting Date Sorting Controls
	And I see the 341 Meeting Date column details in Ascending Order
	And I Click Reset Button
	Then I see the 341 Meeting Date column details reverted to default
	And I SignOut from the Unity Application

Scenario: 003_Case List - Verify different Sorting Sections of CaseList Table
	Given I enter to Case List page as superuser
	When I click on 341 Meeting Date Sorting Controls
	And I see the 341 Meeting Date column details in Ascending Order
	And I click on Debtor Sorting Controls
	And I see the Debtor column details in Ascending Order
	Then I see the 341 Meeting Date column details reverted to default
	And I click on Petition Date Sorting Controls
	And I see the Petition Date column details in Ascending Order
	And I see the Debtor column details reverted to default
	Then I SignOut from the Unity Application

Scenario: 004_Case List - Verify Double Click Sorting Sections of CaseList Table 
	Given I enter to Case List page as superuser
	When I click on 341 Meeting Date Sorting Controls
	And I see the 341 Meeting Date column details in Ascending Order
	And I Click again on 341 Meeting Date Sorting Controls
	Then I see the 341 Meeting Date column details in Descending Order
	And I SignOut from the Unity Application

Scenario: 005_Case List - Verify Pagination in CaseList Page
	Given I enter to Case List page as superuser
	And I select page '4' under Pagination Section
	Then I see the CaseList details for the Selected Page
	And I SignOut from the Unity Application

Scenario Outline: 006_Case List - Verify PageSize under Pagination in CaseList Page
	Given I enter to Case List page as superuser
	When I Select the PageSize as <PageSize> under Pagination Section
	And I see the CaseList Table Contains the Same Number of Rows as per Selected <PageSize>
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize | 
	| 10       | 
	| 25       | 
	| 50       | 
	| 100      | 

Scenario: 007_Case List - Verify Expand And Collapse Button in Case Table
	Given I enter to Case List page as superuser
	When I click on Expand button I see few more fields under Case Table
	And I click on Collapse button
	Then I SignOut from the Unity Application

Scenario: 008_Case List - Verify All Sorting Controls in Case Table
	Given I enter to Case List page as superuser
	And I click on Sorting Controls of All fields
	Then I SignOut from the Unity Application
	
@US235858
Scenario: 009_Case List - CaseListCount and Favorite Case InLineEdit
	Given I enter to Case List page as superuser
	And I see the CasesCount
	And I click on filter search Icon
	When I enter Dates '341 MEETING DATE (FROM)' as '06/04/17' and '341 MEETING DATE (TO)' as '06/04/17'
	Then I Click on Close Button 
	When I select the case 'QA Subbu 30' as Favorite
	Then the Case 'QA Subbu 30' marked as Favorite with Yellow Star
	And I Go to Dashboard page
	Then I verify the Case 'QA Subbu 30' in Favorites tile
	And I Go to Case List page
	When I click on filter search Icon
	And I enter Dates '341 MEETING DATE (FROM)' as '06/04/17' and '341 MEETING DATE (TO)' as '06/04/17'
	Then I Click on Close Button 
	And I deselect the Favorite case 'QA Subbu 30'
	Then I see the Case 'QA Subbu 30' is no more Favorite Case
	And I Go to Dashboard page
	Then I verify the Case 'QA Subbu 30' in Favorites tile
	And I SignOut from the Unity Application

@US235858	
Scenario:  010_Case List - CaseList Favorite case as View
	Given I enter to Case List page as user AutomationView with password Welcome456Epiq! and office crose
	And I click on filter search Icon
	When I enter Dates '341 MEETING DATE (FROM)' as '06/04/17' and '341 MEETING DATE (TO)' as '06/04/17'
	Then I Click on Close Button 
	Then I see the Cases with CaseName same as 'QA Subbu 30'
	And the Marking Case as Favorite should be view only
	And I SignOut from the Unity Application

@US279717
Scenario: 011_Case List - Add the new Case- Save Button
Given I enter to Case List page as superuser
And I see the CasesCount
And I create the new Case
	Then I click 'SAVE'
When I click on filter search Icon
Then I input peition Date in the Fields
		And I Click on Close Button
	Then the Records should contain 'CASE STATUS-Open'
	And I SignOut from the Unity Application

@US279717
Scenario: 012_Case List - Add the new case - Save_New Button
Given I enter to Case List page as superuser
And I see the CasesCount
And I create the new Case
	Then I click 'SAVE + ADD NEW'
Then 'Case ListAdd Case' Breadcrumb should display
	And I SignOut from the Unity Application

@US279717
Scenario: 013_Case List - Add the new case - Cancel Button
	Given I enter to Case List page as superuser
	And I see the CasesCount
	And I create the new Case
	Then I click 'CANCEL'
	Then 'DashboardCase List' Breadcrumb should display
	And I SignOut from the Unity Application


