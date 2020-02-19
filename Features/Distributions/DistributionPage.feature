@Regression	
@ReactJS	
Feature: Distribution ManagementPage 
	Navigating to the different sections 
		of the Distribution Management page

@CasesTab
Scenario: 001 - Cases- Distributions page verification
	Given I enter to Distributions page as superuser
	Then 'Distribution Management' header should be displayed on Distribution Page
	When User click on Filter on Distribution page
	Then Distribution 'FILTER OPTIONS' should be displayed
	When User click on close on Distribution page
	Then Distribution 'FILTER OPTIONS' should be closed
	#And User click on Refresh Button
	And I SignOut from the Unity Application


Scenario: 002 - Cases- Distributions Breadcrumb and sorting verification
   Given I enter to Distributions page as superuser
   	Then 'DashboardDistribution List' Breadcrumb should display
   #And 'DEBTOR' Should be able to sort on Distributions page
   #And 'Distribution' Should be able to sort on Distributions page
   #And 'STATUS' Should be able to sort on Distributions page
   And History has mouseover
   And I SignOut from the Unity Application
#
#No more required as filter are used in other scenarios.
#Scenario: 003 - Cases- Distributions Filter Options Validation
#   Given I enter to Distributions page as superuser
#   When User click on Filter on Distribution page
#   And I select CaseStatus 'All'
#   #And Enter Case Number '17-98985' in Distribution filter option
#   Then Distribution records should be displayed
#   And User click on the reset button on Distribution filter option
#   And user click on close button on Distribution filter option
#   And I SignOut from the Unity Application

Scenario: 004 - Cases- Distribution Page Pagination and all filter options
		Given I enter to Distributions page as superuser
	    When User click on Filter on Distribution page
		Then Table data should be present on distribution page
		#When I enter Debtor 'TestDev29-1' on distribution page	
		When I select DistributionStatus 'Posted'
		Then user click on close button on Distribution filter option
		And Selected result should contains 'Posted' on distribution page
		When User displays the page count on distribution page
		#Then the selected page records should be displayed on distribution page
		Then I SignOut from the Unity Application

@US220363
Scenario: 005 - Cases- Distribution In Line Editing
		Given I enter to Distributions page as superuser
		When I click on one Distribution in line edit button
		Then I should be able to edit the distribution
		And I SignOut from the Unity Application

@US220363
Scenario: 006 - Cases- Distribution - Validation for View only
		Given I enter to Distributions page as user AutomationView with password Welcome456Epiq! and office crose
		Then I should not be able to edit the distribution
		And I SignOut from the Unity Application

@US293954
Scenario Outline: 007- Distribution - View Permission- with different status
		Given I enter to Distributions page as user AutomationView with password Welcome456Epiq! and office crose
		When User click on Filter on Distribution page
		When I select DistributionStatus '<Statused>'
		Then user click on close button on Distribution filter option
		And Selected result should contains '<Statused>' on distribution page
		Then Click on the View Icon for one of case from distribution lists
		Then 'DistributionsView Distribution' Breadcrumb should display
		And user clicks on close button on view pages
		And I SignOut from the Unity Application
Examples: 
| Statused  |
| Posted    |
| Proposed  |

@US293921
Scenario: 008-Verify History Icon on Distribution Summary page
	Given I enter to Distributions page as superuser
	Then Click on the View Icon for one of case from distribution lists
	And I click and view the History Icon
	And I SignOut from the Unity Application

@US#293920
Scenario: 009 - Cases- Distributions- Proposed Distribution Report
   Given I enter to Distributions page as superuser
   And I see the Search box under All Cases Section
   When I Enter '01-21039' On The Universal Search Section Input
   And I Click on the Case Result '01-21039'
   And I select the record for the selected
   And I select the report from final distribution page
   Then 'Proposed Distribution Report' should display in the popup
   Then I SignOut from the Unity Application

@US293959US293955
Scenario: 010-Add Distribution and Generate Distribution
		Given I enter to Distributions page as superuser
		 And I see the Search box under All Cases Section
		 When I Enter '01-21039' On The Universal Search Section Input
		And I Click on the Case Result '01-21039'
		And I click On The Add Distribution
		Then 'DistributionsAdd Distribution' Breadcrumb should display
		When Enter the distribution name
		And  I click on Generate Distribution
		Then I SignOut from the Unity Application

@US293960US293961
Scenario: 011-Edit Distibution-Remit to Court and Modify interest
Given I enter to Distributions page as superuser
		 And I see the Search box under All Cases Section
		 When I Enter '01-21039' On The Universal Search Section Input
		And I Click on the Case Result '01-21039'
		And I click On The Add Distribution
		Then 'DistributionsAdd Distribution' Breadcrumb should display
		When Enter the distribution name
		Then I click Remit to Court Accordion
		And I click on check box for remit to court and enter the amount
			When  I click on Generate Distribution
		Then 'DistributionsEdit Distribution' Breadcrumb should display
		And user clicks on close button on view pages
		When User click on Filter on Distribution page
		Then I select the current distribution date
		Then user click on close button on Distribution filter option
		Then Click on the View Icon for one of case from distribution lists
		Then 'DistributionsEdit Distribution' Breadcrumb should display
		Then Click on Modify Amount button
	Then Verify the pop header as 'Estate Balance = Distribution'
	Then I click on Cancel button in pop up distribution
		Then I SignOut from the Unity Application
	

