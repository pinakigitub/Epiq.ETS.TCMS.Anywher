@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: Case Detail - Banking - Summary
	In order to be able to enter future banking transactions
	As a user of Unity
	I need to be able to navigate and see the Bank Accounts associated to each case

@CaseDetail
@Sanity
@CaseBankingSummary 
@US74626 @TC77120
@US97749 @TC100834
@US98816 @TC100816
Scenario: 001 - Case Detail - Banking Tab - Sections Display (Desktop)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Banking Detail
	Then I See Banking Detail Page Displays and Tab Title is 'Banking Detail'
	And I See the Banking Summary Section With Title 'Banking Summary'
	And I See the Bank Account Summary Section With Title 'Account Summary'
	And I See the Ledger Section With Title 'Ledger Summary'

@CaseDetail
@Sanity
@CaseClaimsSummary @US74626 @TC77122
Scenario: 002 - Case Detail - Banking Summary - No Bank Accounts
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '0:000-XXX'
	And I Go to Banking Detail
	Then I See No Banking Summary Items And a Message Shows Reading 'No Results Available'

@CaseDetail
@Sanity
@CaseClaimsSummary @US74626 @TC77121
@US36857 @TC77863
@US97706 @TC98697
@RegressionFixesIt34
Scenario: 003 - Case Detail - Banking Summary - Cards Content And Selection
	Given I enter to 341 Meeting page as superuser	
	And I Enter to Case Detail page for Case with Case Number '11-29627'
	And I Go to Banking Detail
	Then I See Banking Summary Cards and All Values are Correct
	#Preserve table rows order, positions should match
	| BankAccountName                 | Status | BankAccountNumber | BankName                      | Ledger     | Bank       |
	| Checking - Non Interest         | OPEN   | 9999974139        | EagleBank                     | $9,291.88  | $11,129.88 |
	| Money Market - Interest Bearing | OPEN   | 9999924076        | Bank of America               | $12,952.12 | $0.00      |
	And First Card is Selected By Default And Selecting Each Card Displays BA Detail

@CaseDetail 
@Sanity
@CaseClaimsSummary @US36857 @TC77862
@RegressionFixesIt34
Scenario: 004 - Case Detail - Banking Summary - Negative Values
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	Then I See Banking Summary Cards and All Values are Correct
	#Preserve table rows order, positions should match
	| BankAccountName         | Status | BankAccountNumber | BankName  | Ledger     | Bank     |
	| Checking - Non Interest | OPEN   | 9999974127        | EagleBank | -$1,015.89 | $409.16  |

@CaseDetail
@Sanity
@CaseBankingSummary @US74626 @TC98515
Scenario: 005 - Case Detail - Banking Summary - Navigate Back to Claims Detail
	Given I enter to 341 Meeting page as superuser	
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Banking Detail
	And I Go to Claims Detail
	Then  I See Claims Detail is Selected by Default and Tab Title is 'Claims Detail'
