@Regression
@Smoke
@ReactJS	

Feature: GlobalNavigation
		Navigating to the different sections 
		under Dashboard Page


Scenario: 001_GlobalNavigation_Dashboard_List_Container
Given I enter to DSO page as superuser
Then I SignOut from the Unity Application

Scenario: 002_GlobalNavigation - Navigate To Different Sections Under DashboardList
Given I enter to Case List page as superuser
Given I Go to 341 Meeting page
Given I Go to Assets page
Given I Go to Bank Accounts page
Given I Go to Banking Activity page
Given I Go to Banking ReceiptLog page
Given I Go to Banking ChecksOrDeposits page
Given I Go to Bond Premium Disbursement page
Given I Go to Claims page
Given I Go to Dates page
Given I Go to Distributions page
Given I Go to Documents page
Given I Go to Participants page
Given I Go to Reports page
Given I Go to Tasks page
Given I Go to Dashboard page
Given I Go to Imports Claims page