@Regression
@Ignore @DoNotExecute
Feature: Case Detail - Claims Summary
	In order to be able see the value associated to all claims, and each class.   
	As a user of Unity
	I want to have a summary of my claims. For example Administrative, Secured, Priority, and Unsecured Claims

@CaseDetail
@CaseClaimsSummary @US72373 @TC76149
@CaseClaims 
@US52695 @TC72850
@US97749 @TC100836
@US98816 @TC100817
@US98265 @TC105466
Scenario: Case Detail - Claims Tab Display
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Go to Claims Detail
	Then I See Claims Detail is Selected by Default and Tab Title is 'Claims Detail'
	And I See the Claims Summary Section With Title 'Claims Summary'
	And I See the Selection Summary Section With Title 'Selection Summary'
	And I See the Claims List Section With Title 'Claims'

@CaseDetail
@CaseClaimsSummary @NeedsDBClaimUpdates
@US72373 @TC76149
@US74085 @TC76264
@US97706 @TC98696
@US105577 @TC105663 @TC105664 @TC105665 @TC105666 @TC105667 @TC105668
@US98265 @TC105443 @TC105445 @TC105449 @TC105451 @TC105453 @TC106614
Scenario Outline: Case Detail - Claims Summary - Cards Content And Selection Detail
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '<Case Number>'
	And I Go to Claims Detail
	Then I See Claims Summary Tiles and All Values are Correct	
	And First Tile is Selected By Default And Selecting Each Tile Displays Claim Class Detail
	Examples: 
	| Case Number |
	| 09-13569    |
	| 03-30382    |

@CaseDetail @CaseClaimsSummary 
@US102485 @TC105433 @TC105435 @TC105436 @TC105437 @TC105439 @TC106618
Scenario: Case Detail - Claims Summary - Selecting Tile Filters Results List
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Claims Detail
	Then Selecting Each Tile Displays Only Claims Of That Class