@Regression
@Ignore @DoNotExecute
Feature: Case Detail - Claims List	CAF
	In order to manage my claims for the case
	As a user of Unity
	I need the claims linked to my case to appear on the Case Claims Screen

@CaseDetail @ClaimsList
@Sanity
@US52695 @TC72850 @TC72746
Scenario Outline: Case Detail - Claims List CAF Display (Desktop)
	Given I enter to 341 Meeting page as superuser
	When I Enter to Case Detail page for Case with Case Number '<Case Number>'
	And I Go to Claims Detail
	Then I See Claims Icon Count Matches the Total of Claims on the List
Examples: 
	| Case Number |
	| 09-13569    |
	| 03-30382    |

@CaseDetail @ClaimsList
@Regression
@US52695 @TC73677
Scenario: Case Detail - Claims List CAF - "No Results Available" Message
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '17-15569'
	When I Go to Claims Detail
	Then I See No Claims Display on the List And a Message Shows Reading 'No Results Available'

@CaseDetail 
@ClaimsList @NeedsDBClaimUpdates
@Sanity
@US52695 @TC73676 
@US74453 @TC97452
@US72578 @TC73722 @TC73724 @TC73725
@US72891 @TC97676 
@US72898 @TC72741 @TC75999
@US113306 @TC113507
Scenario: Case Detail - Claims List CAF - Claims Stat And Order
# Test all values for Case #, Status, Class, Category; claims order , corner tags and claim colored circles
	Given I enter to 341 Meeting page as superuser
	When I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Claims Detail
	Then I See Claims Display on the List With Valid Data In Order