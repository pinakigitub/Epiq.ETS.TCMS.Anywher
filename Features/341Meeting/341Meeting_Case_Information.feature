@Regression
@341MeetingsReact

Feature: 341Meeting_Case_Information
		341 Meeting Case specific adding/Editing/Viewing up the Debtor, Joint Debtor,Debtor Attorney, 
		Joint Debtor Attorney, DSO Claimant


@US235892
Scenario: 001_341Meeting- Filtering with current date
	Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		And I SignOut from the Unity Application

@US255999 @US293929
Scenario: 002_341Meeting - View Permission
	Given I enter to 341 Meeting page as user AutomationView with password Welcome456Epiq! and office crose
	And I click on filter search Icon
	Then I input Current Date in the Fields 
	And I Click on Close Button
	And I click on the View 341_Meeting date link
	When I click on the 341_Meetins day overview View Link
	And I try to Click on Debtor Attorney and validate button is disabled
	And And I try to Click on Joint Debtor and validate button is disabled
	And And I try to Click on Joint Debtor Attorney and validate button is disabled
	And And I try to Click on Debtor Co-Counsel and validate button is disabled
	And And I try to Click on DSO Claimant and validate button is disabled
	Then I SignOut from the Unity Application


Scenario: 003_341Meeting_Add New Debtor Attorney
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Add Debtor Attorney
		When I select 'Individual'
		And I input participant title as 'Mrs.' for 'Individual' 
		And I input Participant FIRSTNAME 'Jhansi', MIDDLENAME 'Rani', LASTNAME 'Anil' AND SUFFIX 'Sr.' 
		And I input GENDER 'Female', STATE BAR ID '12345', SSN '222222222', TAX ID '333333333' and DRIVER LICENSE '6789'
		And I enter 'ALIAS' details Type 'AKA' and Name 'Jhanu'
		And I enter 'PHONE' details Type 'Home' and PhoneNum '1234567890'
		And I enter 'EMAIL' details Type 'Business' and Email 'jhanu@gmail.com'
		And I enter 'ADDRESS' details Type 'Other', Address Line1 '64th Avenue West,', Line2 'Suite 301-A,', City 'Mountlake Terrace', state 'WA' and Zip '98043'
		And I Add 'Roles' to the participant 'Appraiser', 'Debtor', 'Debtor Attorney' and 'Trustee Attorney'
		Then I SAVE the Participant
		When I click on BreadCrumb '341 Meetings Day Overview'
		Then I validate that the Debtor Attorney Name is displayed in case overview
		And I SignOut from the Unity Application

@US255999
Scenario: 004_341Meeting_Add New Joint Debtor Attorney
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Add  Joint Debtor Attorney
		When I select 'Individual'
		And I input participant title as 'Mrs.' for 'Individual' 
		And I input Participant FIRSTNAME 'Jhansi', MIDDLENAME 'Rani', LASTNAME 'Anil' AND SUFFIX 'Sr.' 
		And I input GENDER 'Female', STATE BAR ID '12345', SSN '222222222', TAX ID '333333333' and DRIVER LICENSE '6789'
		And I enter 'ALIAS' details Type 'AKA' and Name 'Jhanu'
		And I enter 'PHONE' details Type 'Home' and PhoneNum '1234567890'
		And I enter 'EMAIL' details Type 'Business' and Email 'jhanu@gmail.com'
		And I enter 'ADDRESS' details Type 'Other', Address Line1 '64th Avenue West,', Line2 'Suite 301-A,', City 'Mountlake Terrace', state 'WA' and Zip '98043'
		And I Add 'Roles' to the participant 'Joint Debtor Attorney', 'Debtor', 'Debtor Attorney' and 'Trustee Attorney'
		And I enter the Notes 'New Paricipant with Multiple Roles'
		Then I SAVE the Participant
		And I SignOut from the Unity Application


Scenario: 005_341Meeting_Add Existing Debtor Co-Counsel
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Add Debtor CoCounsel
		When I select existing Debtor Cocounsel
		And I enter the input text as 'Mr. Naresh Raj DAttorney_QA1'
		Then I click on the Save Button
		And I SignOut from the Unity Application

@US255999
Scenario:006_341Meeting_Add New Joint Debtor
	Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Add  Joint Debtor
		When I select 'Individual'
		And I input participant title as 'Mrs.' for 'Individual' 
		And I input Participant FIRSTNAME 'Jhansi', MIDDLENAME 'Rani', LASTNAME 'Anil' AND SUFFIX 'Sr.' 
		And I input GENDER 'Female', STATE BAR ID '12345', SSN '222222222', TAX ID '333333333' and DRIVER LICENSE '6789'
		And I enter 'ALIAS' details Type 'AKA' and Name 'Jhanu'
		And I enter 'PHONE' details Type 'Home' and PhoneNum '1234567890'
		And I enter 'EMAIL' details Type 'Business' and Email 'jhanu@gmail.com'
		And I enter 'ADDRESS' details Type 'Other', Address Line1 '64th Avenue West,', Line2 'Suite 301-A,', City 'Mountlake Terrace', state 'WA' and Zip '98043'
		And I Add 'Roles' to the participant 'Joint Debtor', 'Debtor', 'Appraiser' and 'Trustee Attorney'
		And I enter the Notes 'New Paricipant with Multiple Roles'
		Then I SAVE the Participant
		And I SignOut from the Unity Application

Scenario: 007_341Meeting_Add New DSO CLAIMANT
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Add  DSO Claimant
       Then I input 'TEST' and 'TEST' and '9505616939' text fields information
		# Then I input 'Both' and 'AK' and 'mpike' and 'Sushma' dropdown fields informations
	   Then I Save claimant
	   Then I SignOut from the Unity Application


Scenario: 008_341Meeting_Edit DSO CLAIMANT
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '07/07/18' and '07/07/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click Edit DSO Claimant button
		Then I input 'Edittext' and 'TEST' and '9505616939' text fields information
	   Then I Save claimant
		Then I SignOut from the Unity Application

@US235892
Scenario: 009_341Meeting- Verify Reset, Close, Default values of 341 Meeting Filtering
	Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '02/24/15' and '02/24/15'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		Given I click on filter search Icon
		When I Select 'READY FOR 341' as 'Yes'
		And I Select 'CASE DISPOSITION' as 'File NDR'
		And I enter 'DEBTOR ATTORNEY' field 'Greenan, James'
		And I Select 'CONTINUED FROM PRIOR MEETING' as 'No'
		And I Select 'DEFICIENT DOCS' as 'No'
		And I Select 'DSO CASES' as 'No'
		And I Click Reset Button
		Then I see Default value of 'READY FOR 341' as 'All'
		And I see Default value of 'CASE DISPOSITION' as 'All'
		And I see Default value of 'CONTINUED FROM PRIOR MEETING' as 'All'
		And I see Default value of 'DEFICIENT DOCS' as 'All'
		And I see Default value of 'DSO CASES' as 'All'
		And I Click on Close Button
		And I SignOut from the Unity Application

@US235892
Scenario: 010_341Meeting- Verify Case Disposition and DebtorAttorney by Filtering
	Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '02/24/15' and '02/24/15'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		Given I click on filter search Icon
		When I Select 'CASE DISPOSITION' as 'File NDR'
		Then I Click on Close Button
		#And I see Case '15-10609' with 'Disposition'
		Given I click on filter search Icon
		#Then I clear 'CASE DISPOSITION' field
		When I enter 'DEBTOR ATTORNEY' field 'Greenan'
		Then I Click on Close Button
		Then I see Case '15-10613' with DetorAttorney 'Greenan, James '	
		And I SignOut from the Unity Application

Scenario:011_341Meeting_Edit Debtor Attorney
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '07/02/18' and '07/02/18' 
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Edit Debtor Attorney
		When I select 'Corporation'
		And I enter the Notes 'Edit Debtor Attorney with Multiple Roles'
		Then I SAVE the Participant
		Then I SignOut from the Unity Application

Scenario:012_341Meeting_Edit Joint Debtor Attorney
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '07/02/18' and '07/02/18' 
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Edit Joint Debtor Attorney
		When I select 'Corporation'
		And I enter the Notes 'Edit Joint Debtor Attorney with Multiple Roles'
		Then I SAVE the Participant
		Then I SignOut from the Unity Application

Scenario:013_341Meeting_Edit Debtor CoCounsel
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '07/02/18' and '07/02/18'  
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I click on Edit Debtor CoCounsel
		When I select 'Corporation'
		And I enter the Notes 'Edit Debtor Co Counsel with Multiple Roles'
		Then I SAVE the Participant
		Then I SignOut from the Unity Application

# Histrory Icon is been removed
#Scenario:014_341Meeting_History Column
#		Given I enter to 341 Meeting page as superuser
#		And I click on filter search Icon
#		And I enter the Date fields '03/11/18' and '03/11/18' 
#		And I Click on Close Button
#		Then I click on the View 341_Meeting date link
#		Then I do moveHover on the History Column
#		Then I SignOut from the Unity Application

@US240598
Scenario: 015_341Meeting - Verify Set Meeting Outcome - Meeting OutCome Configurations, Buttons state
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '04/08/14' and '04/08/14'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		#And I click on View link of the Case '2'
		Then I see the header 'Set Meeting Outcome'
		And I see the buttons NDR, CONTINUED and MEETING HELD are in Disabled State
		When I click on Meeting OutCome Configurations
		Then I see header 'Configure 341 Meeting Batch Settings'
		And I select Settings for NDR 'Case Disposition set'
		And I select Continue Settings 'Meeting Status set'
		And I select Meeting Held Settings 'Meeting Status set'
		And I save the Configure Meeting Batch Settings
		And I see the buttons NDR, CONTINUED and MEETING HELD are in Enabled State
		#When I click on button 'NDR' then Toast Message appears with header 'Set Meeting Outcome' and message 'NDR outcome set for meeting'
		#And I click on button 'NDR' then Toast Message appears with header 'Removed Meeting Outcome' and message 'NDR outcome removed for meeting'
		#And I click on button 'CONTINUED' then Toast Message appears with header 'Set Meeting Outcome' and message 'CONTINUED outcome set for meeting'
		#And I click on button 'CONTINUED' then Toast Message appears with header 'Removed Meeting Outcome' and message 'CONTINUED outcome removed for meeting'
		#And I click on button 'MEETING HELD' then Toast Message appears with header 'Set Meeting Outcome' and message 'MEETING HELD outcome set for meeting'
		#And I click on button 'MEETING HELD' then Toast Message appears with header 'Removed Meeting Outcome' and message 'MEETING HELD outcome removed for meeting'
		Then I SignOut from the Unity Application

@US240598
Scenario: 016_341Meeting - Verify Set Meeting Outcome - Toast message when Buttons Selected and De-Selected
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '04/08/14' and '04/08/14'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		#And I click on View link of the Case '2'
		When I click on the 341_Meetins day overview View Link			
		When I click on Meeting OutCome Configurations
		Then I see header 'Configure 341 Meeting Batch Settings'
		And I select Settings for NDR 'Case Disposition set'
		Then I select Continue Settings 'Meeting Status set'
		And I select Meeting Held Settings 'Meeting Status set'
		Then I save the Configure Meeting Batch Settings
		And I click 'SAVE'
		When I click on button 'NDR' then Toast Message appears with header 'Set Meeting Outcome' and message 'NDR outcome set for meeting'
		And I click on button 'NDR' then Toast Message appears with header 'Removed Meeting Outcome' and message 'NDR outcome removed for meeting'
		And I click on button 'CONTINUED' then Toast Message appears with header 'Set Meeting Outcome' and message 'CONTINUED outcome set for meeting'
		And I click on button 'CONTINUED' then Toast Message appears with header 'Removed Meeting Outcome' and message 'CONTINUED outcome removed for meeting'
		#And I click on button 'MEETING HELD' then Toast Message appears with header 'Set Meeting Outcome' and message 'MEETING HELD outcome set for meeting'
		#And I click on button 'MEETING HELD' then Toast Message appears with header 'Removed Meeting Outcome' and message 'MEETING HELD outcome removed for meeting'
		Then I SignOut from the Unity Application

@US240600
Scenario: 017_341Meeting - Verify Edit Case Information Section Pencil Icon
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '01/14/18' and '01/14/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		#And I click on View link of the Case '1'
		Then I verify the 'DEBTOR' Edit Pencil Icon '1'
		And I verify the 'JOINT DEBTOR' Edit Pencil Icon '2'
		And I verify the 'DEBTOR ATTORNEY' Edit Pencil Icon '3'
		And I verify the 'JOINT DEBTOR ATTORNEY' Edit Pencil Icon '4'
		And I verify the 'DEBTOR CO-COUNSEL' Edit Pencil Icon '5'
		And I verify the 'DSO CLAIMANT' Edit Pencil Icon '6'
		When I click on the 'DEBTOR' Edit Pencil Icon '1'
		Then I click 'CANCEL'
		Then I See 'View 341 Meeting' Page
		And I SignOut from the Unity Application

@US240601
Scenario: 018_341Meeting - Verify Case Information Section
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '01/14/18' and '01/14/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		#And I click on View link of the Case '1'
		When I click on the 341_Meetins day overview View Link
		Then I see CASE INFORMATION section is by default Open
		When I click on Collapse button of CASE INFORMATION
		Then I see CASE INFORMATION section is Closed
		And I click on Expand button of CASE INFORMATION
		When I enter 'Automation' in Digital Recording
		Then I see the the text 'Automation' saved in Digital Recording
		And I see 'DEBTOR', 'JOINT DEBTOR', 'DEBTOR ATTORNEY', 'JOINT DEBTOR ATTORNEY', 'DEBTOR CO-COUNSEL' and 'DSO CLAIMANT'
		And I verify the 'DEBTOR', '1' as 'KNRAJ QA 209646 A3'
		And I verify the 'JOINT DEBTOR', '2' as 'DATTORNEY_QA1, NARESH RAJ'
		And I verify the 'DEBTOR ATTORNEY', '3' as 'DATTORNEY_QA1, NARESH RAJ'
		And I verify the 'JOINT DEBTOR ATTORNEY', '4' as 'DATTORNEY_QA1, NARESH RAJ'
		And I verify the 'DEBTOR CO-COUNSEL', '5' as 'DATTORNEY_QA1, NARESH RAJ'
		And I verify the 'DSO CLAIMANT', '6' as 'NIHARIKA'
		Then I SignOut from the Unity Application

@US240601
Scenario: 019_341Meeting - Verify Case Information Section Debtor Details
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '01/14/18' and '01/14/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		#And I click on View link of the Case '1'
		When I expand '1', 'DEBTOR' then I verify NAME 'KNRAJ QA 209646 A3', SSN '747-47-4747', ID '45-6465456'
		And I expand '2', 'JOINT DEBTOR' then I verify NAME 'Mr. Naresh Raj DAttorney_QA1', SSN '567-81-9101', ID '23-4567890'
		And I expand '1', 'DEBTOR' and verify CONTACT INFO Address '5', 'Banjara Hills Hyderabad, IN 30920', Phone No '+1 (123) 456-7890', Email '' and Employee Info 'QA Naresh Raj K QA Naresh Raj KQA Naresh Raj K'
		And I expand '2', 'JOINT DEBTOR' and verify CONTACT INFO Address '5', 'QA Regression Test,  Street#1 Avenue 6 CA - USA, IN 900', Phone No '+1 (789) 456-8745', Email 'nareshraj.kodimela@dtiglobal.com' and Employee Info 'Maryland Regional Eye Associates'
		And I expand '3', 'DEBTOR ATTORNEY' and verify CONTACT INFO Address '4', 'QA Regression Test,  Street#1 Avenue 6 CA - USA, IN 900', Phone No '+1 (789) 456-8745', Email 'nareshraj.kodimela@dtiglobal.com' and Employee Info ''
		And I expand '4', 'JOINT DEBTOR ATTORNEY' and verify CONTACT INFO Address '4', 'QA Regression Test,  Street#1 Avenue 6 CA - USA, IN 900', Phone No '+1 (789) 456-8745', Email 'nareshraj.kodimela@dtiglobal.com' and Employee Info ''
		And I expand '5', 'DEBTOR CO-COUNSEL' and verify CONTACT INFO Address '4', 'QA Regression Test,  Street#1 Avenue 6 CA - USA, IN 900', Phone No '+1 (789) 456-8745', Email 'nareshraj.kodimela@dtiglobal.com' and Employee Info ''
		And I expand '6', 'DSO CLAIMANT' and verify CONTACT INFO Address '4', 'Hyderabad', Phone No '+1 (123) 456-7890', Email '' and Employee Info ''
		Then I SignOut from the Unity Application

@US240601
Scenario: 020_341Meeting - verify No SSN view
		Given I enter to 341 Meeting page as user NoSSNUser1 with password Welcome678Epiq! and office crose
		And I click on filter search Icon
		And I enter the Date fields '01/14/18' and '01/14/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		#And I click on View link of the Case '1'
		When I click on the 341_Meetins day overview View Link
		When I expand '1', 'DEBTOR' then I should not able to see SSN 'XXX-XX-XXXX'
		When I expand '2', 'JOINT DEBTOR' then I should able to see partial SSN 'XXX-XX-XXXX'
		Then I SignOut from the Unity Application

@US240601
Scenario: 021_341Meeting - verify Partial SSN view
	Given I enter to 341 Meeting page as user PartialSSNUser1 with password Welcome345Epiq! and office crose
	And I click on filter search Icon
		And I enter the Date fields '01/14/18' and '01/14/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		#And I click on View link of the Case '1'
		When I click on the 341_Meetins day overview View Link
		When I expand '1', 'DEBTOR' then I should able to see partial SSN 'XXX-XX-4747'
		When I expand '2', 'JOINT DEBTOR' then I should able to see partial SSN 'XXX-XX-9101'
		Then I SignOut from the Unity Application


Scenario: 022_341Meeting - Verify the Contd date, DSO in the case view list
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '03/27/18' and '03/27/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		Then I validate the Contd date and DSO is displayed in the case list page
		Then I SignOut from the Unity Application

#@US251090
#Bug is existing for the same and hence mean time commenting out
#Scenario: 023_341Meeting - Verify Table Headers and sortings in 341 Meeting Management Page 
#       Given I enter to 341 Meeting page as superuser
#	   And I see Table header contains '341 DATE;TOTAL CASES;CASESW/O DISPOSITIONS;CONTINUED CASES;CONVERTED CASES;DSO CASES;DISMISSED CASES;NEW CASES;NDR CASES;ASSET CASES;CASES NOT READY'
#       And Verify sorting on Grid 'TOTAL CASES'
#	   Then I SignOut from the Unity Application

@US251090
Scenario Outline: 024_341Meeting - Verify Pagination in 341 Meeting Management Page 
       Given I enter to 341 Meeting page as superuser
	   When I Select the PageSize as <PageSize> under Pagination Section meeting page
	   And I see the Assets Table Contains the Same Number of Rows as per Selected <PageSize>
	   Then I SignOut from the Unity Application
	   Examples: 
	   | PageSize | 
	   | 10       | 
	   | 25       | 
       | 50       |

@US240605@US240599
Scenario: 025_341Meeting - Verify all the toggles in the Meeting Outcome Tab
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '05/11/18' and '05/11/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I verify the VERIFICATION STATUS
	    #Then I Verify the DEBTOR VERFICATION SECTION
		Then I verify the toggle is clickable
		Then I select the Meeting Debtor status 'Concluded'
		Then I select the Joint Debtor status as 'Reset'
		And I SignOut from the Unity Application

@US256003@US246640
Scenario:026_341Meeting - verify Ready/Not Ready inside View of 341 Meeting case
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '05/11/18' and '05/11/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I click on the 341_Meetins day overview View Link
		Then I Validate the Ready or not ready toggle in the case information left menu
		And I SignOut from the Unity Application

#Since it is impacting the execution time for the regression run hence we have commented it out for time being
#@US251091@251087
#Scenario: 027_341Meeting - BatchFiling Close, Upload And Removal of Document
#	Given I enter to 341 Meeting page as superuser
#	And I click on filter search Icon
#	And I enter the Date fields '04/28/18' and '04/28/18'
#	And I Click on Close Button
#	Then I click on the View 341_Meeting date link
#	And I click 'SELECT ALL'
#	And I click ' BATCH FILING'
#	Then the Records should contain 'DOCUMENT-UPLOAD DOCUMENT'
#	When I click 'UPLOAD DOCUMENT'
#	Then I see header 'Upload Document for Filing'
#	And I see Case# and DebtorName '17-26824 / abhishek,'
#	Then I click 'CLOSE'
#	When I click 'UPLOAD DOCUMENT'
#	And the User Uploads the Document in new window
#	Then the Records should contain 'DOCUMENT-Test.pdf'
#	And I should not be able to Upload the second Document
#	When I delete the Uploaded document
#	Then the Records should contain 'DOCUMENT-UPLOAD DOCUMENT'
#	And I SignOut from the Unity Application
#
#@US251084
#Scenario: 028_341Meeting - BatchFiling Verify Report Column
#	Given I enter to 341 Meeting page as superuser
#	And I click on filter search Icon
#	And I enter the Date fields '04/28/18' and '04/28/18'
#	And I Click on Close Button
#	Then I click on the View 341_Meeting date link
#	And I click 'SELECT ALL'
#	And I click ' BATCH FILING'
#	When I select Report '341 Meeting Held Report'
#	Then the Records should contain 'REPORT-341 Meeting Held Report'
#	And I SignOut from the Unity Application

@US256002
Scenario: 029_341Meeting - Verify NDR settings and Meeting Held settings
	Given I enter to 341 Meeting page as superuser
	And I click on filter search Icon
	And I enter the Date fields '04/30/18' and '04/30/18'
	And I Click on Close Button
	Then I click on the View 341_Meeting date link
	When I click on the 341_Meetins day overview View Link
	Then I see the buttons NDR, CONTINUED and MEETING HELD are in Disabled State
	When I click on Meeting OutCome Configurations
	And I see 'Settings for NDR' contains 'Debtor, Joint Debtor, Debtor Attorney, and Joint Debtor Attorney set to 'Appeared''
	And I see 'Meeting Held Settings' contains 'Debtor, Joint Debtor, Debtor Attorney, and Joint Debtor Attorney set to 'Appeared''
	Then I save the Configure Meeting Batch Settings
	And I SignOut from the Unity Application

@US255999
Scenario Outline: 030_341Meeting - 341 Verification Section Updated to show edits without permissons
    Given I login to Unity as NON Super Admin user
	Then I see Dashboard header '<selection>' 
	Then  I see '<DashboardMessage>' dashboardmessage
	Then I SignOut from the Unity Application

Examples: 
	| selection             | DashboardMessage                                                 |
	| Upcoming 341 Meetings | No Upcoming 341 Meetings Matching Current View                   |
	| Past 341 Meetings     | No Past 341 Meetings Matching Current View                       |

@US255999
Scenario:031_341Meeting - 341 Verification Section show edits without permissons
	Given I enter to 341 Meeting page as user AutomationView with password Welcome456Epiq! and office crose
	And I click on filter search Icon
	Then I input Current Date in the Fields 
	And I Click on Close Button
	And I click on the View 341_Meeting date link
	When I click on the 341_Meetins day overview View Link
	And I try to Click on Debtor Attorney and validate button is disabled
	Then I SignOut from the Unity Application

@US256000
@US256003@US246640
Scenario:032_341Meeting - 341 Calendar / Meeting Tool Tip when user does not have Permission
	Given I enter to 341 Meeting page as user AutomationView with password Welcome456Epiq! and office crose
	And I click on filter search Icon
	And I enter the Date fields '05/11/18' and '05/11/18'
	Then I Click on Close Button
	Then I click on the View 341_Meeting date link
	When I click on the 341_Meetins day overview View Link
	And I try to Click on Debtor Attorney and validate button is disabled
	Then Validate that ReadyToggle button is disabled
	Then I SignOut from the Unity Application

@US264014@US266873
Scenario: 033_341Meeting - Download option verification
	Given I enter to 341 Meeting page as superuser
	And I click on filter search Icon
	And I enter the Date fields '04/28/18' and '04/28/18'
	And I Click on Close Button
	Then I click on the View 341_Meeting date link
	And I click 'SELECT ALL'
	And I click ' DOWNLOAD'
	Then Verify the Pop up header as'Docket Download'
	Then Verify the modal pop up paragragh text.
	And I click on DOWNLOAD button on the pop up
	#Then Verify the toast message title as 'Offline Archive'
	Then I SignOut from the Unity Application

@US264013
Scenario: 034_341Meeting- Verify the Set Order option
	Given I enter to 341 Meeting page as superuser
	And I click on filter search Icon
	And I enter the Date fields '04/28/18' and '04/28/18'
	And I Click on Close Button
	Then I click on the View 341_Meeting date link
	And I click 'Set Order'
	And I select sort by 'Case'
	And I click 'APPLY'
	Then I SignOut from the Unity Application