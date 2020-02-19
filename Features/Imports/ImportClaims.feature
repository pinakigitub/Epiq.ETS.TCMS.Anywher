@Regression	
@ReactJS

Feature: ImportClaims
	Verify the functionality of Importing claims

@US213252@US248192
Scenario:001:Import Claims- Verify UI functionality on Import Claims Page
	Given I enter to Imports Claims page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	Then verify the columns from '2' to '8' displayed on 'epiq-outer-container' as 'CASE #;DEBTOR;CLAIMS;ESTIMATED TFR;CLAIM BAR DATE;STATUS;CASE'
	Then I SignOut from the Unity Application

@US213253@US248193@US293918
Scenario:002:Import Claims- Verify filter functionality and data on Import claims page
	Given I enter to Imports Claims page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'   
	When I 'CLOSE' Filter option
	Then I see subheader as 'Imported Claims'
    Then verify the data on the grid with default page size '10' with status 'Open'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'   
	Then Filter with 'CASE STATUS' as 'Closed' 
	When I 'CLOSE' Filter option
	Then verify the data on the grid with default page size '10' with status 'Closed'
		Then I SignOut from the Unity Application

@US213253@US248193@US293918
Scenario:003: Import Claims-Verify Reset filter functionality on Import claims page
	Given I enter to Imports Claims page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported' 
	Then I see subheader as 'Imported Claims'  
	Then Filter with 'IMPORTED' as 'Ignored' 
	Then I see subheader as 'Ignored Claims'  
	When I 'RESET' Filter option	
	Then I see subheader as 'Claims to Import'  
	When I click 'xi' Filter option  
		Then I SignOut from the Unity Application

@US213252@US248192
Scenario Outline: 004:Import Claims-Verify Import Claims PageSize
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'
	When I 'CLOSE' Filter option
	When I Select the PageSize as '<PageSize>' under Pagination Section in import claims page 'epiq-outer-container' in table '1'
	And I see the Assets Table Contains the Same Number of Rows as per Selected <PageSize>
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize |
	| 10       |
	| 25       |
	| 50       |

# There is an existing defect related to sorting functionality. Once fixed, we will run the same.
#@US213252@US248192
#Scenario:005:Import Claims- Verify Column sorting functionality
#	Given I enter to Imports Claims page as superuser
#	Then  I see Import Management header
#	Then 'DashboardImport Claims' Breadcrumb should display
#	Then I see subheader as 'Claims to Import'
#	When Click on filter option
#	Then Filter with 'IMPORTED' as 'Imported'
#	And 'DEBTOR' should be able sorted
#	Then I SignOut from the Unity Application

@US213252@US248192
Scenario:006:Import Claims- Verify Pagination and Navigation functionality
	Given I enter to Imports Claims page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Imported'
	When I 'CLOSE' Filter option
	When I Select the PageSize as '10' under Pagination Section in import claims page 'epiq-outer-container' in table '1'
    Then I SignOut from the Unity Application

@US213252@US248192@US293946
#Scenario:007:Import Claims- Verify navigation to Assets page with view permission
#	Given I enter to Imports Claims page as user Automation with password Automation1! and office crose
#	Then  I see Import Management header
#	Then 'DashboardImport Claims' Breadcrumb should display
#	Then I see subheader as 'Claims to Import'
#	#Then verify the display and navigation to Assets tab on Claims page
#	#Then verify the data on Assets Import Page
#		Then I SignOut from the Unity Application

# Functionality of Assets Button removed. Not required to run the test
#@US213252@US248192
#Scenario:008:Import Claims- Verify navigation to Assets page without view permission
#	Given I enter to Imports Claims page as user AutomationView with password Welcome456Epiq! and office crose
#	Then  I see Import Management header
#	Then 'DashboardImport Claims' Breadcrumb should display
#	Then I see subheader as 'Claims to Import'
#	Then verify the display of Assets button on Import Management page
#		Then I SignOut from the Unity Application

@US213252@US248192
Scenario:009:Import Claims- without view Permission
	Given I enter to Imports Claims page as user AutomationView with password Welcome456Epiq! and office crose	
	Then I see the Security Warning Icon in Orange
		Then I SignOut from the Unity Application

@US236906@US251096
Scenario:010:Import Claims- Delete claims on Grid
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on claims for case '08-12064'
	When I select claim to delete for creditor 'Fedex National LTL' 
	When I click delete
		Then I SignOut from the Unity Application

@US236904@US251095@293918
Scenario:011:Import Claims- Import claims on Grid
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on claims for case '08-12064'
	When I select claim to Import for creditor 'Hubbard Supply Co' 
	Then I see 'IMPORT' and 'IGNORE' options in Enabled
	When I click import 'IMPORT'
		Then I SignOut from the Unity Application

@US236905@US251097@US293916@US293925@293918
Scenario:012:Import Claims- Ignore,restore,2 tile filter claims on Grid
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on claims for case '08-12064'
	When I select claim to Ignore for creditor 'Hubbard Supply Co' 
	Then I see 'IMPORT' and 'IGNORE' options in Enabled
	When I click ignore 'IGNORE'
	When Click on filter option on tile page
	Then Filter with 'IMPORTED' as 'Ignored'
	When I 'CLOSE' Filter option
	Then I click on checkbox on tile
	Then I click Restore 'RESTORE'
		Then I SignOut from the Unity Application

@US243686@US251094
Scenario:013:Import Claims- Verify Claims to Import section 
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on claims for case '08-12645'
	Then verify the header '08-12645'
	Then verify the case header 'ACE MORTGAGE FUNDING, LLC/08-12645'
	Then 'DashboardImport ClaimsClaims' Breadcrumb should display
	Then verify the columns from '4' to '6' displayed on 'claims-to-import-tabs-pane-1' as '#;CREDITOR;CLAIMED'
	And click on expand symbol and verify the columns on 'claims-to-import-tabs-pane-1' as 'CLASS;ALLOWED' in table '1'
	Then verify the pagination and navigation '1' and 'claims-to-import-tabs-pane-1'
	When I Select the PageSize as '25' under Pagination Section in import claims page 'claims-to-import-tabs-pane-1' in table '1'
	And I see the Claims Table Rows as per Selected 25 and 'claims-to-import-tabs-pane-1' in table '1'
	Then I SignOut from the Unity Application

@US243686@US251094
Scenario:014:Import Claims- Verify Claims in Case Tiles section
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on claims for case '08-12645'
	Then verify the header '08-12645'
	Then verify the case header 'ACE MORTGAGE FUNDING, LLC/08-12645'
	Then 'DashboardImport ClaimsClaims' Breadcrumb should display
	Then verify the columns from '3' to '5' displayed on 'claims-view-tabs-pane-1' as '#;CREDITOR;PAID'
	And click on expand symbol and verify the columns on 'claims-view-tabs-pane-1' as 'UTC;CLAIMED;ALLOWED;BALANCE;CLASS;STATUS;PAY SEQUENCE' in table '2'
	Then verify the pagination and navigation '2' and 'claims-view-tabs-pane-1'
	When I Select the PageSize as '50' under Pagination Section in import claims page 'claims-view-tabs-pane-1' in table '2'
	And I see the Claims Table Rows as per Selected 50 and 'claims-view-tabs-pane-1' in table '2'
	Then I SignOut from the Unity Application

@US251098@US243901
Scenario:015:Import Claims- Verify View Documents section
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on claims for case '08-12645'
	Then verify the header '08-12645'
	Then verify the case header 'ACE MORTGAGE FUNDING, LLC/08-12645'
	Then 'DashboardImport ClaimsClaims' Breadcrumb should display
	Then select View Documents Tab
	Then verify the columns from '2' to '4' displayed on 'claims-view-tabs-pane-2' as 'DOC #;SOURCE;DESCRIPTION'
	#And click on expand symbol and verify the columns on 'claims-view-tabs-pane-2' as '' in table '2'
	Then verify the pagination and navigation '2' and 'claims-view-tabs-pane-2'
	When I Select the PageSize as '25' under Pagination Section in import claims page 'claims-view-tabs-pane-2' in table '2'
	And I see the Claims Table Rows as per Selected 25 and 'claims-view-tabs-pane-2' in table '2'
	Then I SignOut from the Unity Application

@US255997@US244772
Scenario:016:Import Claims- Settings
	Given I enter to Imports Claims page as user conversion with password conversion and office GMiller
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	When I click on settings icon
	Then verify the subheader 'Settings Management'
	Then verify the sections displayed 'GENERAL IMPORT DEFAULTS;IMPORT CHAPTER 7 CASES;IMPORT CHAPTER 7 CASES PRE BAPCPA;IMPORT NON CHAPTER 7 CASES'
	Then verify the options displayed in 'GENERAL IMPORT DEFAULTS' section as 'Create 'New' Activity;Import claim in UPPERCASE;Import Creditor Matrix Data;Import Creditor Matrix Data ONLY on demand;Remove Address Codes from Matrix Data'
	Then verify the expand functionality on 'GENERAL IMPORT DEFAULTS;IMPORT CHAPTER 7 CASES;IMPORT CHAPTER 7 CASES PRE BAPCPA;IMPORT NON CHAPTER 7 CASES' section 'DEFAULT STATUS;ADMIN;PRIORITY;SECURED;UNSECURED;OTHER\UNKNOWN'
	Then verify the labels displayed on 'IMPORT CHAPTER 7 CASES;IMPORT CHAPTER 7 CASES PRE BAPCPA;IMPORT NON CHAPTER 7 CASES' section 'ADMIN;PRIORITY;SECURED;UNSECURED;OTHER\UNKNOWN'
	Then select data from 'IMPORT CHAPTER 7 CASES' section 'ADMIN;PRIORITY;SECURED;UNSECURED;OTHER\UNKNOWN' as '2810;5500;4220;7300;'
	Then select data from 'IMPORT CHAPTER 7 CASES PRE BAPCPA' section 'ADMIN;PRIORITY;SECURED;UNSECURED;OTHER\UNKNOWN' as '2200;5700;4220;7990;'
	Then select data from 'IMPORT NON CHAPTER 7 CASES' section 'ADMIN;PRIORITY;SECURED;UNSECURED;OTHER\UNKNOWN' as '2500;5300;4210;7300;'
	Then I save the settings
	Then I SignOut from the Unity Application

@US256005@US244653
Scenario:017:Import Claims- Verify table messages when no data displayed
	Given I enter to Imports Claims page as superuser
	Then  I see Import Management header
	Then 'DashboardImport Claims' Breadcrumb should display
	Then I see subheader as 'Claims to Import'
	Then verify the message displayed on table as 'No claims to import'
	When Click on filter option
	Then Filter with 'IMPORTED' as 'Ignored' 
	Then verify the message displayed on table as 'No claims to import'
	Then I SignOut from the Unity Application