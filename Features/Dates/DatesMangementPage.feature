@Regression	
@ReactJS
@FailureCases	

Feature: DatesManagementPage
Navigating to the different sections 
		under Dates page

@CasesTab
Scenario: 001 - Cases- Dates page verification
	Given I enter to Dates page as superuser
	Then  I see Date Management header
	When User click on Filter on Dates page
	Then Dates 'FILTER OPTIONS' should be displayed
	When User click on close on Dates page
	Then Dates 'FILTER OPTIONS' should be closed
	#And User click on Refresh Button on Dates Page
	And I SignOut from the Unity Application

Scenario: 002 - Cases- Dates Page Breadcrumb and sorting verification
   Given I enter to Dates page as superuser
   	Then 'DashboardDates List' Breadcrumb should display
   #And 'CASE #' Should be able to sort on Dates page
   #And 'DEBTOR NAME' Should be able to sort on Dates page
   #And User click on Refresh Button on Dates Page
 # And 'CASE TYPE' Should be able to sort on Dates page
  #And 'CASE STATUS' Should be able to sort on Dates page
  # And 'CATEGORY' Should be able to sort on Dates page
   #And 'ASSET STATUS' Should be able to sort on Dates page 
   And I SignOut from the Unity Application

Scenario: 003 - Cases- Dates Filter Options Validation with Open Case Status
   Given I enter to Dates page as superuser
   When User click on Filter on Dates page
   #And Enter Case Number '17-10001' in Dates filter option
   #And I select case Status'Open' in Dates filter option
   Then Dates records should be displayed
   And User click on the reset button on Dates filter option
   And user click on close button on Dates filter option
   And I SignOut from the Unity Application

#
#Scenario: 004 - Cases- Dates Expand row for more columns
#   Given I enter to Dates page as superuser
#   When User click on Row Expand button on Dates page
#   Then User should be able to see column CASE # on dates page
#   And User should be able to see column ASSET STATUS on dates page
#   And I SignOut from the Unity Application

Scenario: 005 - Cases- Dates Page Pagination
    Given I enter to Dates page as superuser
	When User displays the page count on dates page
	Then the selected page records should be  in dates page
    And I SignOut from the Unity Application

# The below scenario for closed functionality is covered in other scenario
#Scenario: 006 - Cases- Dates Filter Options Validation with Closed Status
#   Given I enter to Dates page as superuser
#   When User click on Filter on Dates page
#   And I select case Status'Closed' in Dates filter option
#   Then Dates records should be displayed
#   And User click on the reset button on Dates filter option
#   And user click on close button on Dates filter option
#   And I SignOut from the Unity Application


Scenario: 007-Cases-Add Dates for Converted to Chapter 7
	Given I enter to Dates page as superuser
	When User clicks on the Add Dates Button
	And Enter Case Number '17-90000 / QATest1, NareshRaj' in Dates filter option
	And User Enter the Date for Convert to chapter
	Then User Clicks on tick button on add page
	And I SignOut from the Unity Application

Scenario: 008-Cases-Add Dates for NDR
	Given I enter to Dates page as superuser
	When User clicks on the Add Dates Button
	And Enter Case Number '02-10340 / KOHLHEIM, ELLA M' in Dates filter option
	And User Enter the Date for NDR
	Then User Clicks on tick button on add page
	And I SignOut from the Unity Application

Scenario: 009- Dates -Add and Edit Closing Date for Converted form
	Given I enter to Dates page as superuser
	  When User clicks on the Add Dates Button
	  And Enter Case Number '17-90001' in Dates filter option
	  And User Edit and Enter the Date '01/18/17' to Converted
	    Then Click on tick and validate Toastr message 
	  #When User Edit and Enter the Date '02/12/18' to Converted - Duplicate step
	  #  Then Click on tick and validate Toastr message - Duplicate step
	    And I SignOut from the Unity Application

Scenario: 010- Dates -Add and Edit Closing Date for Dismissal Date
	Given I enter to Dates page as superuser
	  When User clicks on the Add Dates Button
	  And Enter Case Number '11-18956' in Dates filter option
	  And User Edit and Enter the Date '01/18/17' to Dismissal
	    Then Click on tick and validate Toastr message 
	  #When User Edit and Enter the Date '02/12/18' to Dismissal - Duplicate step
	  #  Then Click on tick and validate Toastr message - Duplicate step
	    And I SignOut from the Unity Application

Scenario: 011- Dates -Verify Closing Date for case with open Bank Account
	Given I enter to Dates page as superuser
	  When User clicks on the Add Dates Button
	  And Enter Case Number '07-10767' in Dates filter option
	     Then validate message is displaying in Case Closing Date section
	     And I SignOut from the Unity Application


# Add View Permission

Scenario: 012_Validate the View permission
	Given I enter to Unity Login page
	When I try to login with view credentials 'AutomationView', 'Welcome456Epiq!' and 'crose'
	Given I enter to Dates page as superuser
	Then User try to clicks on the Add Dates Button
	And I SignOut from the Unity Application