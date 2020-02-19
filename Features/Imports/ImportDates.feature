@Regression	
@ReactJS

Feature: ImportDates
	Verify the functionality of Importing Dates

# Please refer scenario 11...that covers all the below functionality
#@US274010@US269265
#Scenario:001:Import Dates- Verify UI functionality on Import Dates Page
#	Given I enter to Imports Dates page as superuser
#	Then  I see Import Management header
#	Then 'DashboardImport Dates' Breadcrumb should display
#	Then I see subheader as 'Dates to Import'
#	Then verify the columns from '2' to '6' displayed on 'epiq-outer-container' as 'CASE #;DEBTOR;DATES;STATUS;CASE'
#	Then I SignOut from the Unity Application

@US274012@US269266
Scenario:002:Import Dates- Verify filter functionality and data on Import Dates page
	Given I enter to Imports Dates page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'   
	When I 'CLOSE' Filter option
	Then I see subheader as 'Imported Dates'
    Then verify the data on the grid with default page size '10' with status 'Open'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'   
	Then Filter with 'CASE STATUS' as 'Closed' 
	When I 'CLOSE' Filter option
	Then verify the data on the grid with default page size '10' with status 'Closed'
		Then I SignOut from the Unity Application

@US274012@US269266
Scenario:003: Import Dates-Verify Reset filter functionality on Import Dates page
	Given I enter to Imports Dates page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported' 
	Then I see subheader as 'Imported Dates'  
	Then Filter with 'IMPORTED' as 'Ignored' 
	Then I see subheader as 'Ignored Dates'  
	When I 'RESET' Filter option	
	Then I see subheader as 'Dates to Import'  
	When I click 'xi' Filter option  
		Then I SignOut from the Unity Application

@US274012@US269266
Scenario Outline: 004:Import Dates-Verify Import Dates PageSize
	Given I enter to Imports Dates page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'
	Then Filter with 'CASE STATUS' as 'Closed' 
	When I 'CLOSE' Filter option
	When I Select the PageSize as '<PageSize>' under Pagination Section in import dates page 'epiq-outer-container' in table '1'
	And I see the Assets Table Contains the Same Number of Rows as per Selected <PageSize>
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize |
	| 10       |
	| 25       |
	| 50       |
	| 100      |

#Currently a Bug has been raised related to Sorting. Once fixed, we will run the scenario.
#@US274010@US269265
#Scenario:005:Import Dates- Verify Column sorting functionality
#	Given I enter to Imports Dates page as superuser
#	Then  I see Import Management header
#	Then 'DashboardImport Dates' Breadcrumb should display
#	Then I see subheader as 'Dates to Import'
#	When Click on filter option
#	Then Filter with 'IMPORTED' as 'Imported'
#	And 'DEBTOR' should be able sorted
#	Then I SignOut from the Unity Application

@US213252@US248192
Scenario:006:Import Dates- Verify Pagination and Navigation functionality
	Given I enter to Imports Dates page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'
	When I 'CLOSE' Filter option
	Then Verify Navigation and Pagination display
    Then I SignOut from the Unity Application

# The Assets Tab on Import Page has been removed.
#@US274010@US269265@US293946
#Scenario:007:Import Dates- Verify navigation to Assets page with view permission
#	Given I enter to Imports Dates page as user Automation with password Automation1! and office crose
#	Then  I see Import Management header
#	Then 'DashboardImport Dates' Breadcrumb should display
#	Then I see subheader as 'Dates to Import'
#	Then verify the display and navigation to Assets tab on Claims page
#	Then verify the data on Assets Import Page
#		Then I SignOut from the Unity Application

# The Assets Tab on Import Page has been removed.
#@US274010@US269265@US293946
#Scenario:008:Import Dates- Verify navigation to Assets page without view permission
#	Given I enter to Imports Dates page as user AutomationView with password Welcome456Epiq! and office crose
#	Then  I see Import Management header
#	Then 'DashboardImport Dates' Breadcrumb should display
#	Then I see subheader as 'Dates to Import'
#	Then verify the display of Assets button on Import Management page
#		Then I SignOut from the Unity Application

@US274010@US269265
Scenario:009:Import Dates- without view Permission
	Given I enter to Imports Dates page as user AutomationView with password Welcome456Epiq! and office crose	
	Then I see the Security Warning Icon in Orange
		Then I SignOut from the Unity Application

@US274010@US269265
Scenario:010:Import Dates- Verify table messages when no data displayed
	Given I enter to Imports Dates page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	Then verify the message displayed on table as 'No dates to import'
	Then I SignOut from the Unity Application

	@US274010@US269265@279746
Scenario:011:Import Dates- Alert and Tile View for Dates To Import for Closing Dates
	Given I enter to Imports Dates page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	Then verify the columns from '2' to '6' displayed on 'epiq-outer-container' as 'CASE #;DEBTOR;DATES;STATUS;CASE'
	Then verify the message displayed on table as 'No dates to import'
	Given I click on filter search Icon
	Then Filter with 'IMPORTED' as 'Imported'
	When I 'CLOSE' Filter option
	When I Click on Date Link Under Imported Dates
	Then I SignOut from the Unity Application

	@US279745@279744@279747
Scenario:012:Import Dates- Ignoring and Importing Selected Dates
	Given I enter to Imports Dates page as user nareshraj with password Welcome123Epiq! and office dbirdsell
	Then  I see Import Management header
	Then 'DashboardImport Dates' Breadcrumb should display
	Then I see subheader as 'Dates to Import'
	Given I click on filter search Icon
	Then Filter with 'IMPORTED' as 'Waiting to import'
	When I 'CLOSE' Filter option
	When I Click on one Dates Link on Dates to Import Page
	Then I see Import and Ignore Buttons as Disabled
	When I click on one checkbox of listed assets
	Then I see Import and Ignore button Enabled	
	Then I SignOut from the Unity Application