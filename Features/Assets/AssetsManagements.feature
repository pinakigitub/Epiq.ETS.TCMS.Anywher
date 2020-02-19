@Regression	
@ReactJS	
	
Feature: AssetManagement
		Navigating to the different sections under AssetManagement Mangement Page	

Scenario:  001 - AssetManagement Page verification
	Given I enter to Assets page as superuser
		Then 'AssetManagement' page should be display
		Then 'DashboardAssets' Breadcrumb should display
		And Page Count shoud be display
		And Table data should be present
		And I SignOut from the Unity Application


Scenario:  002 - Add Asset
	Given I enter to Assets page as superuser
		Then 'AssetManagement' page should be display
	When I Click on Add Asset
		Then Add Asset page should be display
	When I enter 'CASE # / DEBTOR NAME-17-19907;DESCRIPTION-AutomationTest;PETITION VALUE STATUS-Scheduled;TRUSTEE VALUE STATUS-Known;ABANDONED-No' fileds
	And I click on save
	And I click on filter button
	And I enter description 'AutomationTest'
		Then Records should contain 'DESCRIPTION-AutomationTest'
		Then I SignOut from the Unity Application

#Bug is logged related to sorting which is root cause for failure of this scenario
#Scenario: 003 - Assets records Sorting
#		Given I enter to Assets page as superuser
#		Then 'AssetManagement' page should be display
#		Then 'DashboardAssets' Breadcrumb should display
#		And 'DEBTOR' should be able sorted
#		And I SignOut from the Unity Application

Scenario: 004 - Assets verify Pagination
		Given I enter to Assets page as superuser
		Then 'AssetManagement' page should be display
		And Page Count shoud be display
		And navigation and pagination should display
		And I SignOut from the Unity Application

Scenario: 005 - Assets filters funnel Search and Clear
	Given I enter to Assets page as superuser
	When I click on filter button
		Then Table data should be present
	When I enter description 'Test'
	And I select fully administered 'No'
	And I select fully abandoned 'No'
	And I select fully reserved 'No'
	And I select fully case status 'Open'
		Then Records should contain 'DESCRIPTION-Test'
		And Fully abandoned should contains 'No'
		And Fully reserved should contains 'No'
	When Click on reset
	And I click on close
		Then default data should be present
		And I SignOut from the Unity Application

Scenario: 006 - Assets clear the filters from the funnel
	Given I enter to Assets page as superuser
	When I click on filter button
		Then Table data should be present
	When I enter description 'Test'
		Then Records should contain 'DESCRIPTION-Test'
	When I clear the description
		Then default data should be present
	When I select fully administered 'Yes'
		Then fully administered should contains 'dd/mm/yy'
	When  I click on fully administered x
		Then default data should be present
	When I select fully abandoned 'No'
		Then Fully abandoned should contains 'No'
	When I click on fully abandoned x
		Then default data should be present 
	When I select fully reserved 'Yes'
		Then Fully reserved should contains 'Yes'
	When I click on fully reserved x
		Then default data should be present 
	When I select fully case status 'Closed' 
		Then Case status should be 'Closed'
		And default data should be present 
		And I SignOut from the Unity Application 

Scenario Outline: 007_ Assets - Verify PageSize under Pagination
	Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I Select the PageSize as <PageSize> under Pagination Section
	And I see the Table Contains the Same Number of Rows as per Selected <PageSize>
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize | 
	| 10       | 
	| 25       | 
	| 50       | 
	| 100      | 

Scenario: 008_ Assets - Edit Asset
	Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I click on filter button
	And I enter description 'QA Automation Test'
	And I click on close
	Then I edit Record containing DESCRIPTION 'QA Automation Test'
	When I enter 'DESCRIPTION-QA Automation Test;PETITION VALUE STATUS-Scheduled;TRUSTEE VALUE STATUS-Known;CODE-1141 Preference/Fraudulent Transfer Litigation' fileds
    When I enter 'PETITION VALUE-1000.00;LIENS-200.00;OWNED VALUE-300.00;EXEMPTIONS-200.00;ESTIMATED COST OF SALE-500.00;PETITION VALUE-1500.00' fileds
	And I enter 'FORM 1 NOTES-QA Automation Testing on Edit Assets;FULLY ADMINISTERED DATE-01/26/18;1ST UST REPORT DATE-06/22/18;SCHEDULE-B25: Aircraft' fileds
	And I enter 'SCHEDULE-106A/B Part 3-Q11;ABANDONED-Yes (OA);OWNERSHIP-Debtor 1 and Debtor 2;RESERVED NOTE-Unity Edit Assets Testing' fileds
	And I click on save
	And I click on filter button
	And I enter description 'QA Automation Test'
	And I click on close
	Then Records should contain 'DESCRIPTION-QA Automation Test'
	And I SignOut from the Unity Application

@US235853
Scenario: 009_ Assets - SaveEdit- InLineEdit and verify
	Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I click on filter button
	And I enter description 'INVENTORY'
	And I click on close
	Then I edit PETITION InLineEdit '300'
	And I edit TRUSTEE '100'
	And I edit EXEMPTIONS '200'
	And I edit FA '06/27/18'
	#And I edit ABANDONED 'Yes'
	And I edit OWNED '300'
	And I edit Reserved
	And I Edit RESERVED NOTE 'Automation Testing'
	Then I see the PETITION value '$300.00'
	And the TRUSTEE value as '$100.00'
	And the EXEMPTIONS value as '$200.00'
	And the FA value as '06/27/18'
	And the ABANDONED value as 'Yes (OA)'
	And the OWNED value as '$300.00'
	And the RESERVED Notes as 'Automation Testing'
	Then I SignOut from the Unity Application

@US235853
Scenario: 010_Assets - CancelEdit- InLineEdit and Verify
Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I click on filter button
	And I enter description 'INVENTORY'
	And I click on close
	Then I edit PETITION '400'
	And edit TRUSTEE '500'
	And edit EXEMPTIONS '600'
	And edit FA '08/09/19'
	#And edit ABANDONED 'No'
	And edit OWNED '800'
	And Edit RESERVED NOTE 'Assets Automation Testing'
	Then I see the PETITION value '$300.00'
	And the TRUSTEE value as '$100.00'
	And the EXEMPTIONS value as '$200.00'
	And the FA value as '06/27/18'
	And the ABANDONED value as 'Yes (OA)'
	And the OWNED value as '$300.00'
	And the RESERVED Notes as 'Automation Testing'
	Then I SignOut from the Unity Application

@US235853@US277535
Scenario: 011_ Assets - NoPermission to InLineEdit
	Given I enter to Assets page as user AutomationView with password Welcome456Epiq! and office crose
	When I click on filter button
	And I enter description 'INVENTORY'
	And I click on close
	Then I see the InLineEdit Fields as Non-Editable Fields
	And I SignOut from the Unity Application

@US#235896
Scenario: 012_ Assets - Verify Fully Administered Cases
	Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I click on filter button
	And I select fully administered 'Yes'
	And I click on close
	Then I verify Fully Administered Cases as Green
	And I SignOut from the Unity Application

@US#235897
Scenario: 013_ Assets - Verify Default values of Filter
	Given I enter to Assets page as superuser
	When I click on filter button
	When I select fully administered 'Yes'
	And I select fully abandoned 'No'
	And I select fully reserved 'Yes'
	And I select fully case status 'Closed' 
	When Click on reset
	Then I see default value 'FULLY ADMINISTERED' as 'All'
	#And I see default value 'ABANDONED' as 'All'
	And I see default value 'RESERVED' as 'All'
	And I see default value 'CASE STATUS' as 'Open'
	Then I SignOut from the Unity Application

@US235900
Scenario: 014_ Assets - Verify Case Level Default values of Filter
	Given I enter to Assets page as superuser
	Given I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	When I click on filter button
	Then I see default value 'FULLY ADMINISTERED' as 'All'
	#And I see default value 'ABANDONED' as 'All'
	And I see default value 'RESERVED' as 'All'
	And I should not be able to see 'CASE STATUS'
	Then I SignOut from the Unity Application

#Bug is logged related to sorting which is root cause for failure of this scenario
#@US235898
#Scenario: 015_ Assets - CaseLevel Assets Table Sorting
#	Given I enter to Assets page as superuser
#	And I see the Search box under All Cases Section
#	When I Enter '17-00001' On The Universal Search Section Input
#	And I Click on the Case Result '17-00001'
#	Then 'DESCRIPTION' should be able sorted
#	And 'UTC' should be able sorted
#	Then I SignOut from the Unity Application

@US235904@US277535
Scenario: 016_ Assets - View Permission of Assets Page
     Given I enter to Assets page as user AutomationView with password Welcome456Epiq! and office crose
     Then Verify for View icon symbol '19'
	 And I SignOut from the Unity Application

@US235904@US277535
Scenario: 017_ Assets - View Tax refund request
	Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I click on filter button
	And I enter description 'QA Automation Test'
	And I click on close
	Then I edit Record containing DESCRIPTION 'QA Automation Test'
	And I click on Tax refund request button
    Then click 'GENERATE REPORT'
	And I SignOut from the Unity Application

@US293966
Scenario: 008_ Assets - Edit Asset-Edit Tax Refund Request
	Given I enter to Assets page as superuser
	Then 'AssetManagement' page should be display
	When I click on filter button
	And I enter description 'Nissan X-Trail Hybrid SUV - Test'
	And I click on close
	Then I edit Record containing DESCRIPTION 'Nissan X-Trail Hybrid SUV - Test'
	And I click on Taxrefund request button
	And I click on button SAVE
	Then I SignOut from the Unity Application