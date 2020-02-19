@Regression	
@ReactJS	
Feature: BondPremiumDisbursementPage
 Navigating to the different sections 
		under Bond Premium Disbursement page

@US293952@US293951@293953@271950
Scenario: 001 - Bond List Page Filter
	Given I enter to Bond Premium Disbursement page as superuser
	Then  I see Bond Premium Disbursement header
	Then 'DashboardBond Premium Disbursement' Breadcrumb should display
	When User click on Filter on Bond Distribution page
	When I Select a Status 'Posted' from Drop Down
	When I Select a Status 'Editable' from Drop Down
	And they should click on reset button on filter options pane
	And the user should click on close button on filter option pane
	When the user clicks on the Add Bond Button
	When the user clicks on cancel button
	Then I SignOut from the Unity Application
	
	@US293979
Scenario: 002 - Bond Premium Table Alerts
	Given I enter to Bond Premium Disbursement page as superuser
	When the user clicks on edit Bond Premium button
	Then Verify the Alerts message on the Table
	Then I SignOut from the Unity Application

@US293977@US293978
Scenario: 003 - Create Bond - Calculate Validations - Check Payment
	Given I enter to Bond Premium Disbursement page as superuser
	When the user clicks on the Add Bond Button
	Then Verify for Calculate Button is displayed at bottom of the page
	Then Verify for Mandatory Columns to be Filled
	Then I SignOut from the Unity Application

@US293977
Scenario: 004 - Create Bond - Calculate Validations - Expense Payment
	Given I enter to Bond Premium Disbursement page as superuser
	When the user clicks on the Add Bond Button
	Then I Select 'Expense' from the Payment Method Dropdown
	Then Verify for Calculate Button is displayed at bottom of the page
	Then Verify for Mandatory Columns to be Filled
	Then I SignOut from the Unity Application