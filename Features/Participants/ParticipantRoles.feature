@Regression	
@ReactJS	

Feature: ParticipantRoles
	Adding the participant and editing the saved participant
	And verify the order of Multiple Roles 

Scenario: 001_ParticipantRoles- verify pariticipants page flow
	Given I enter to Participants page as superuser
	And I click on Add Paritipant
	When I click on BreadCrumb 'Dashboard'
	#Then I navigate back to the 'Participant Management' Page
	Then I SignOut from the Unity Application

Scenario:  002_ParticipantRoles- Create New Participant - Individual
	Given I enter to Participants page as superuser
	Then I click 'Participant'
	When I select 'Individual'
	And I input participant title as 'Mrs.' for 'Individual' 
	And I input Participant FIRSTNAME 'Jhansi', MIDDLENAME 'Rani', LASTNAME 'Anil' AND SUFFIX 'Sr.' 
	And I input GENDER 'Female', STATE BAR ID '12345', SSN '222222222', TAX ID '333333333' and DRIVER LICENSE '6789'
	And I enter 'ALIAS' details Type 'AKA' and Name 'Jhanu'
	And I enter 'PHONE' details Type 'Home' and PhoneNum '1234567890'
	And I enter 'EMAIL' details Type 'Business' and Email 'jhanu@gmail.com'
	And I enter 'ADDRESS' details Type 'Other', Address Line1 '64th Avenue West,', Line2 'Suite 301-A,', City 'Mountlake Terrace', state 'WA' and Zip '98043'
	And I Add 'Roles' to the participant 'Appraiser', 'Debtor', 'Joint Debtor AKA' and 'Trustee Attorney'
	And I enter the Notes 'New Paricipant with Multiple Roles'
	Then I SAVE the Participant
	And I SignOut from the Unity Application

Scenario: 003_Participant- Verify saved Participant
	Given I enter to Participants page as superuser
	And I click on filter search Icon
	And I Enter Participant Name 'Jhansi Rani'
	And I select type 'Individual'
	Then I Click on Close Button 
	And I See the Participant Name saved with Name 'Anil, Jhansi Rani'
	And I SignOut from the Unity Application

Scenario: 004_Participant-Edit: Change Participant Type- Corporation
	Given I enter to Participants page as superuser
	And I click on filter search Icon
	And I Enter Participant Name 'Jhansi Rani'
	And I select type 'Individual'
	And I Click on Close Button 
	And I Edit the participant 'Anil, Jhansi Rani' 
	When I select 'Corporation'
	And I remove Alias and Email Details
	Then I SAVE the Participant
	Then I SignOut from the Unity Application

Scenario: 005_ParticipantRoles- Paritipant with Multiple Roles
	Given I enter to Participants page as superuser
	When I Select the PageSize as 50 under Pagination Section
	Given I select participant '1891899, QA Subbu' containing Role 'Multiple'
	And I verify header title 'Participant Roles'
	And I verify the Alphabetical Order of Roles
	And I close the modal Roles
	Then I SignOut from the Unity Application