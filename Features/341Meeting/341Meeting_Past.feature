@Regression	
@ReactJS
@341MeetingsReact
Feature: 341Meeting_Past
	To check and validate the past 341 Metting dates

@US248203
Scenario: 001 - Past 341 Meeting Card - Past Meetings and Filter Validation on overview page
		Given I enter to Dashboard page as superuser
		And I see 'Past 341 Meetings' contains 'Cases Without Disposition'
		When I click on the Past Meeting date link 
		Then I see 341Meeting header has same date 
		Then I see 341Meeting overview page
		When I click on filter search Icon
		#Then I see Default value of 'CASE DISPOSITION' as 'Unexamined Chapter 7 Cas'
		Then I Click on Close Button
		Then I SignOut from the Unity Application

@US235893
@US235892
@US235894
Scenario: 002_Past341Meeting - verify Past & Future Meeting Dates, MeetingDatesOrder, Expand & Collapse, DA
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '04/08/14' and '04/08/14'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		#Then I Verify the No.of Cases tied to date
		#Then I see dropdown of Meeting dates in Descending order
		#And I verify the cases displayed in Meeting Time order
		Then I click on Expand and Collapse button
		When I click on filter search Icon
		And I enter 'DEBTOR ATTORNEY' field 'DAVIES'
		Then I Click on Close Button
		And I see Debtor Attorney name 'DAVIES' with an Envelope	
		And I SignOut from the Unity Application

@US235893
@US235894@BUG268816
Scenario: 003_Past341Meeting - verify MeetingTime Section, Drag Cases
		Given I enter to 341 Meeting page as superuser
		And I click on filter search Icon
		And I enter the Date fields '04/08/14' and '04/08/14'
		And I Click on Close Button
		Then I click on the View 341_Meeting date link
		And I select Case as '341 Meeting Held Report'
		And I see the successful Toast message 'Filing Type Code for BARCELO, EDUARDO L. updated to 341 Meeting Held Report.'
		#When I change the MeetingTime of '14-11557' from '10:00 AM' to '09:00 AM'
		#Then I see the case '12-31672' under TimeOrder of '08:00 AM (1)'
		And I drag the Case '14-12944' to position of Case '14-11557'
		And I revert the position of Case '14-11557' to Case '14-12944'
		And I SignOut from the Unity Application

# Sceanrio is no more valid as we don't have multiple options to select on the Case Disposition
#@US251089
#Scenario: 004_341MeetingDayOverview - Select case Disposition, Alert, Status of Case, DSO
#	Given I enter to 341 Meeting page as superuser
#	And I click on filter search Icon
#	And I enter the Date fields '04/08/14' and '04/08/14'
#	And I Click on Close Button
#	Then I click on the View 341_Meeting date link
#		When I click on filter search Icon	
#		And I enter 'CASE DISPOSITION' field 'Open - Asset Case'
#	Then I select the Case Disposition 'Open - Asset Case'
#	#Then I see the toast message on 341 Past Meeting
#	#And I select the Case Disposition 'Unexamined Chapter 7 Case'
#	#Then I see the toast message on 341 Past Meeting
#	When I enter 'CASE DISPOSITION' field 'Unexamined Chapter 7 Case'
#	Then I mouseover on Alert icon
#	And I see the Case '14-11557' Asset Status as 'ASSET'
#	And I see the Case '14-11745' status as 'CLOSED'
#	Then I see the Case '14-12944', '1' as 'DSO' Case
#	And I SignOut from the Unity Application