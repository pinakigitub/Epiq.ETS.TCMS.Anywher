@Regression	
@ReactJS
@341MeetingsReact
Feature: 341Meeting_Upcoming
	To check and validate the upcoming 341 meeting dates

@US224527
Scenario: 001 - 341 Meeting Management Page and Date Sorting Validation
	Given I enter to 341 Meeting page as superuser
		Then I see number of cases in parentheses
		#Then Meeting dates should be in Ascending order
		When I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		Then I SignOut from the Unity Application

@US224527
Scenario: 002 - 341 Meeting - Time Blocks Validation
	Given I enter to 341 Meeting page as superuser
		When I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		Then I see Unique Time Blocks are available 
		Then I see Unique Time Blocks are in Blue Oval
		Then I see all time blocks arrow are open
		When I click on Time Block Arrow
		Then I see Time Block Arror is down and closed 
		And I SignOut from the Unity Application

@US224527
Scenario: 003 - 341 Meeting - Card view Ready and Not-Ready Validation
	Given I enter to 341 Meeting page as superuser
		When I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		And I click on the View 341_Meeting date link
		And I click on toggle and success toastr message should be displayed
		Then I SignOut from the Unity Application

@US224427
Scenario: 004 - 341 Meeting Tile - Edit Upcoming Meeting Date Status
		Given I enter to 341 Meeting page as superuser
		And I Go to Dashboard page
		When I click on Upcoming Meeting date link 
		Then I click on toggle and success toastr message should be displayed
		And I SignOut from the Unity Application

@US224470@US293902@US293903
#PreReq:There should be upcoming 341 Meeting with 'Total Cases' > 1
# Reason: Ui got changed and US is no more valid.
#Scenario: 005 - 341 Meeting - Viewing Case Details - Carousel Validation
#	Given I enter to 341 Meeting page as superuser
#	And I click on filter search Icon
#		And I enter the Date fields '05/06/18' and '05/06/18'
#		And I Click on Close Button
#		Then I click on the View 341_Meeting date link
#		Then I Click on View button on Meeting management
#		#When I Click on Meeting date View Button that have more than one cases 
#		Then I see Date and Time displayed header of Meeting View
#		Then I see the arrows for view of next case
#		When I click on Right Arrow of Case Header
#		Then page refreshed with Selected case
#		When I click on Left Arrow of Case Header
#		Then page refreshed with Selected case
#		And I SignOut from the Unity Application

@US248860
Scenario: 006 - 341 Meeting Tile- Validate Trustee Dropdown for Upcoming Meeting
		Given I enter to 341 Meeting page as superuser
		And I Go to Dashboard page
		When I select 'CHERYL E. ROSE' from trustee dropdown on UpcomingMeeting Tile
		Then I see Data for selected trustee on Tile
		And I SignOut from the Unity Application

@US248860
Scenario: 007 - 341 Meeting Tile- Validate Trustee Dropdown for Past Meeting
		Given I enter to 341 Meeting page as superuser
		And I Go to Dashboard page
		When I select 'CHERYL E. ROSE' from trustee dropdown on Past Meeting Tile 
		Then I see Data for selected trustee on Past Meeting Tile
		And I SignOut from the Unity Application

@US231657@US264015
Scenario: 008 - 341 Meeting - Continue Case Validation
	Given I enter to 341 Meeting page as superuser
		When I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		When I click on the View 341_Meeting date link
		And I Click on View button on Meeting management
		Then I see Continued Details Section of Meeting View Page
		Then I edit Continued Date on Continued Details Section
		Then I edit Continued Time on Continued Details Section
		Then I edit and select Continued Reason on Continued Details Section
		When I Click On Save Changes Button
		Then I see changes are saved and blue color info icon appeared
		#Then I MouseHouver on the history icon at Continued Details Section
		And I SignOut from the Unity Application

@US236697
Scenario: 009 - 341 Meeting - Outcome Payout Layout Verification
	Given I enter to 341 Meeting page as superuser
		When I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		When I click on the View 341_Meeting date link
		And I Click on View button on Meeting management
		Then I see Continued Details Section of Meeting View Page
		Then I see Verification Status Section on Meeting View Page
		Then I see Case Disposition field on Meeting View Page
		Then I see One Click Filing Task field on Meeting View Page		
		And I SignOut from the Unity Application

@US235394
Scenario: 010 - 341 Meeting -  Verification of Document List in table
	Given I enter to 341 Meeting page as superuser
		When I click on filter search Icon
		Then I input Current Date in the Fields 
		And I Click on Close Button
		When I click on the View 341_Meeting date link
		And I Click on View button on Meeting management
		When I Click on Case Documents Tab Meeting View Page
		Then I see three columns on case documents tab	
		And I SignOut from the Unity Application

@US240608
Scenario: 011_341Meeting - Drag cases
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '03/11/18' and '03/11/18'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		When I drag case '17-23017' to time slot 06:00 PM
		Then I SignOut from the Unity Application

@US245009
Scenario:0012-Viewing of documents in 341Meeting- Prizm Docx.
Given I enter to 341 Meeting page as user Manaswi with password Welcome789Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '15-70235' On The Universal Search Section Input
	And I Click on the Case Result '15-70235'
	When I click on the View 341_Meeting date link
	And I Click on View button on Meeting management
	When I Click on Case Documents Tab Meeting View Page
	Then I click on Expand button 341 Meeting
	Then I SignOut from the Unity Application



