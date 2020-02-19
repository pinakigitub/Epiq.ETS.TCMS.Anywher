@Regression	
@ReactJS	
Feature: CaseListFilter
	
@CaseFilter 

Scenario: 001_Case List Filtering - Filter Cases with MeetingDates
	Given I enter to Case List page as superuser
	And I click on filter search Icon
	When I enter Dates '341 MEETING DATE (FROM)' as '12/15/17' and '341 MEETING DATE (TO)' as '01/03/18'
	And I close the Filter Options
	Then I see the Cases between the given '341 MEETING DATE','3', '12/15/17' and '01/03/18'
	And I SignOut from the Unity Application

Scenario: 002_Case List Filtering - Filter Cases with PetitionDates
	Given I enter to Case List page as superuser
	And I click on filter search Icon
	When I enter Dates 'PETITION DATE (FROM)' as '11/10/2017' and 'PETITION DATE (TO)' as '11/30/2017'
	And I close the Filter Options
	Then I see the Cases between the given 'PETITION DATE','6', '11/10/2017' and '11/30/2017'
	And I SignOut from the Unity Application

Scenario: 003_Case List Filtering - Filter Cases with Claims Bar Dates
	Given I enter to Case List page as superuser
	And I click on filter search Icon
	When I enter Dates 'CLAIMS BAR DATE (FROM)' as '06/15/2015' and 'CLAIMS BAR DATE (TO)' as '10/19/2017'
	And I close the Filter Options
	Then I see the Cases between the given Claims Bar Dates
	Then I SignOut from the Unity Application

Scenario: 004_Case List Filtering - Filter Cases by Type, Status and FeePaid
	Given I enter to Case List page as superuser
	And I click on filter search Icon
	When I select ASSETStatus as 'Asset'
	And I select CASE Status as 'Closed'
	And I select FeePaid as 'No'
	And I close the Filter Options
	Then I see the ASSETStatus column as 'Asset'
	And CASEStatus column as 'Closed'
	Then I SignOut from the Unity Application

Scenario: 005_Case List Filtering - Reset and close funtionality verification
    Given I enter to Case List page as superuser
	And I click on filter search Icon
	When I select ASSETStatus as 'Asset'
	And I select CASE Status as 'Closed'
	And I select FeePaid as 'Yes'
	And I Click Reset Button
	Then I Click on Close Button 
	And I SignOut from the Unity Application

Scenario: 006_mousehover on debtor column
	Given I enter to Case List page as superuser
	Then mouseover on the debtor column in case lists
	And I SignOut from the Unity Application

Scenario: 007_Case List - Verify Updating Fee Paid by Editing Case Access
	Given I enter to Case List page as superuser
	When I click on Case Expand Button to see all columns
	And I click on Fee Paid Checkbox
	Then Save Button Should be displayed on Case Fee
	Then Cancel Button Should be displayed Case Fee
	Then  I Click on Cancel button of Case Fee
	Then I SignOut from the Unity Application

Scenario: 008_Case List - Updating Fee Paid by Editing Case Access
	Given I enter to Case List page as superuser
	When I click on Case Expand Button to see all columns
	And I click on Fee Paid Checkbox
	Then I enter Fee Amount'18'
	Then I enter Fee Paid '9'
	Then I enter Date Paid '02/13/18'
	Then I Click On Save Button on Case Fee
	When I click on Case Expand Button to see all columns
	And I click on Fee Paid Checkbox
	Then I enter Fee Amount'0'
	And I enter Fee Paid '0'
	And I enter Date Paid ''
	And I Click On Save Button on Case Fee
	And I SignOut from the Unity Application

Scenario: 009_Case List - Updating Fee Paid by View Only Case Access
	Given I enter to Case List page as user SubbuCase with password Welcome123Epiq! and office crose
	When I click on Case Expand Button to see all columns
	And I click on Fee Paid Checkbox
	Then Close Button Should be displayed
	And I Click on Close button of Case Fee
	And I SignOut from the Unity Application