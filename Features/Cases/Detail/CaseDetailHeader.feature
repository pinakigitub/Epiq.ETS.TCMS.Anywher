@Regression
@Ignore @DoNotExecute
Feature: Case Detail - Header
	In order to reference important case information.
	As a user of Unity 
	I want to be able to see the data of a Case on the Case Detail page

@CaseDetail
@Sanity
@US44750 @TC61594 @TC61605 @TC61606 @TC61608 @TC61610 @TC61613
@CaseStatus @US41190 @TC61629 @TC61628
@CaseBalanceIcon @US36805 @TC72364
@CaseClaimsIcon @US36803 @TC72741
@CaseDistributionsIcon @US36804 @TC72734
Scenario Outline: 001 - Case Detail - Header - Case Information is Correct
	Given I enter to Case List page as superuser
	And I Navigate to Case Detail page for the '<Status>' Case with Case Number '<CaseNumber>'
	Then I See Case Detail Page Displays the Correct Case Data
	#Already tested on new automated tests for 122977
	#And Tax Id is '<TaxId>'
	And Claims Icon Displays with Description 'Claims' and Correct Value
	And Distributions to Date Icon Displays with Description 'Dist. to Date' and Value '<Distributions>'
	And Bank Balance Icon Displays with Description 'Balance' and Value '<BankBalance>'
	Examples:
	| CaseNumber    | Status | TaxId      | Distributions | Claims | BankBalance |
	# Open case with Tax ID and Est. Dist. Date (CaseId=397)
	| 09-13569      | Open   | 49-0962900 | $80.3K        | 32     | -$100       |
	# Closed case with Tax ID and Est. Dist. Date (CaseId=1107)
	#| 11-14933      | Closed | 21-5579968 | $12.5K        | 15     | $0.00       |
	# Open Case with blank Est. Dist. date (CaseId=1076)
	| 0:V327646-XXX | Open   | 87-0341794 | $0            | 258    | $0          |
	# Open Case with blank Tax ID (CaseId=16)
	#| 03-30382      | Open   |            | $0            | 18     | $7.8K       |

@CaseDetail
@Sanity
@US81550 @TC113908
Scenario Outline: 002 - Case Detail - Header - Header Is Sticky On Top Of Page
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '<Case Number>'
	When I Scroll All The Way Down On The Page
	Then I See Header Bar Sticks Visible On Top
Examples:
	| Case Number |
	| 10-14418    |
	| 09-13569    |
	| 11-14933    |

@CaseDetail
@Sanity
@US113309 @TC113626
Scenario Outline: 003 - Case Detail - Browser Refresh Stays on Same Tab
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14418'
	And Go To '<Tab>' Tab
	When I Refresh The Page
	Then I Still See '<Tab>' Tab
Examples:
	| Tab     |
	| Assets  |
	| Banking |
	| Claims  |