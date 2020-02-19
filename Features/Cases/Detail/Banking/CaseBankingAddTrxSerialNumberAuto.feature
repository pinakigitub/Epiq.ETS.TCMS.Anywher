@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: Case Detail - Banking - Add transaction Serial Number Autocomplete
	In order to create new banking transactions with auto completed serial numbers
	As a user of Unity
	I need to be able to see the serial number autocompletes to the next on series for checks and deposits

## Default Serial Number to Next on Series
@CaseDetail 
@BankingTransactions
@Sanity
@US96815 @TC101352
Scenario Outline: Case Detail -  Banking - Add Transaction - Serial Number Default
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	When I Go To Create Transaction '<Transaction>'	
	Then I See Serial Number Autocompletes
Examples:
	| Transaction                      |
	| Check                            |
	| Deposit                          |
	| Deposit Correcting Check         |

@CaseDetail 
@BankingTransactions
@TransactionSaving
@Sanity
@US96815 @TC101353
Scenario Outline: Case Detail -  Banking - Add Check - Serial Number Increment
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	And I Go To Create Transaction '<Transaction>'	
	When I Create A Transaction With The Default Serial Number
	And I See the Transaction has been Saved
	Then If I Open The Form Again I See The Default Serial Number Is Higher Than The Previous One
	Examples:
	| Transaction                      |
	| Check                            |
	| Deposit                          |
	| Deposit Correcting Check         |