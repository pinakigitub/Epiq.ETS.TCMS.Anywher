@Regression	
@ReactJS	
@FailureCases
Feature: Emails 
	Navigating to the different sections 
		under Emails page

@CasesTab
@US197587
Scenario: 001 - Cases- Emails page verification for All Cases Level
    Given I enter to Emails page as superuser
	Then 'Email Management' header should be displayed on Email Page
	Then 'DashboardEmails' Breadcrumb should display
	Then I see all Expected headers on Emails Page
	Then I SignOut from the Unity Application

@US197587
Scenario: 002 - Cases- Emails page verification for Case Level
    Given I enter to Emails page as superuser
	When I search and select case '12-19993' from Top search
	Then 'DashboardEmails' Breadcrumb should display
	Then I see all Case level Expected headers on Emails Page
	Then I SignOut from the Unity Application

@US197589
Scenario: 003 - Cases- Emails Filter Validation
    Given I enter to Emails page as superuser
	Then 'Email Management' header should be displayed on Email Page
	When I Click On Filter Icon on Emails Page
	And I select date '07/31/17' from DATE(FROM) on Emails filter
	And I select date '07/31/17' from DATE(TO) on Emails filter
	And I click on Close button of email filter
	Then I see filter result has date '07/31/17' only on Email page
	And I SignOut from the Unity Application

#@US197589
#Scenario: 004 - Cases- Filter Funnel Count Validation
#    Given I enter to Emails page as superuser
#	Then 'Email Management' header should be displayed on Email Page
#	When I Click On Filter Icon on Emails Page
#	And I select date '04/08/2015' from DATE(FROM) on Emails filter
#	And I select date '06/25/2015' from DATE(TO) on Emails filter
#	And I click on Close button of email filter
#	Then I See Filter Funnel displaying the count of filter Result
#	And I SignOut from the Unity Application
