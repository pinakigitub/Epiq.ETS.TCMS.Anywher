@Regression
Feature: Application Bar and Navigation
	As a Unity user
	To have common tools on the header section
	I want to be able to see a Common Region on all pages

@Common @UniversalAppBar
@US10886 @TC11575 @US36895
Scenario: Display Universal App Bar
 Given I enter to Case List page as superuser
	Then I see the Universal App Bar container
	And I see the User Profile link and its content is correct
#
#@Common @NavigationAppBar
#@US10886 @TC11575 @US36895
#Scenario: Display Main Navigation Menu
# Given I enter to 341 Meeting page as superuser
#	Then I see the Main Navigation Menu and it is correct
#	#And I see 'cases' menu item text is 'CASES'
#	And I see 'dashboard' menu item text is 'DASHBOARD'