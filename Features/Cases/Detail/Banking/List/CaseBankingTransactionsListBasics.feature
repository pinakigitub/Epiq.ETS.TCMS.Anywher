@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: Case Detail - Banking - Transactions List Basics
	In order to review my data, make any edits, or create new banking transactions
	As a user of Unity
	I need to be able to see correctly a list of my case transactions for each bank account

## TRANSACTIONS LIST
@CaseDetail @BankingTransactions
@US52695 @TC73677
Scenario: Case Detail - Banking - Transactions List - "No Results Available" Message
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '0:000-XXX'
	When I Go to Banking Detail
	Then I See No Transactions Display on the List And a Message Shows Reading 'No Results Available'

@CaseDetail 
@BankingTransactions
@Sanity
@US98645 @TC101136
Scenario: Case Detail -  Banking - New Transactions Disabled on Closed Bank Accounts
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '11-29627'
	And I Go to Banking Detail
	When I Select Bank Account By Number '9999999965'
	Then I See New Transaction Buttons Are Disabled
	#TODO Add this:
	#And I See New Transaction Buttons Under More Menu Are Disabled
	#TODO Add selection of case and Bank Account by DB query to avoid data failures

@CaseDetail @BankingTransactions
@Sanity
@US41215 @TC78059
@US74950 @TC85403
@US86095 @US114662
Scenario Outline: Case Detail -  Banking - Transactions List - Stat And Order
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '<Case Number>'
	When I Go to Banking Detail
	Then I See Transactions Display on the List With Valid Data In Order
	Examples:
	| Case Number |
	| 11-29627    |
	| 09-13569    |
	
#@CaseDetail 
#@BankingTransactions @PrintChecks
#@Sanity
#@US76085
#@Bug150708 
#@Ignore @DoNotExecute @CR154255
##BUG here failing scenarios - text doesnt change to 'reprint' on click
#Scenario Outline: BUG150708_Case Detail -  Banking - Transactions List - Print Checks
#	Given I Login to Unity With Credentials '<Username>', '<Password>' and 'crose' And Roles ''
#	And I Enter to Case Detail page for Case with Case Number '09-13569'
#	And I Go to Banking Detail
#	When I See Check With Serial # '<Serial # Print>' Print Link Text Is '<Text Print Step>' And Is Active '<Active Print Step>'
#	And I Click On Print Link For Check With Serial # '<Serial # Print>'
#	Then I See Check With Serial # '<Serial # Reprint>' Print Link Text Is '<Text Reprint Step>' And Is Active '<Active Reprint Step>'
#	And I Click On Print Link For Check With Serial # '<Serial # Reprint>'
#	And I See Check With Serial # '<Serial # Reprint>' Print Link Text Is '<Text After Reprint>' And Is Active '<Active After Reprint>'
#	Examples:
#	| Username       | Password  | Print Permission | Reprint Permission | Serial # Print | Text Print Step | Active Print Step | Serial # Reprint | Text Reprint Step | Active Reprint Step | Text After Reprint | Active After Reprint |
#	| TAPrint        | usrprint0 | Yes              | No                 | 1030           | Print           | True              | 1030             | Reprint           | False               | Reprint            | False                |
#	| TAReprint      | usrprint0 | No               | Yes                | 1030           | Print           | False             | 1029             | Reprint           | True                | Reprint            | True                 |
#	| TAprintreprint | usrprint0 | Yes              | Yes                | 1030           | Print           | True              | 1030             | Reprint           | True                | Reprint            | True                 |
#	| TAnoprint      | usrprint0 | No               | No                 | 1030           | Print           | False             | 1030             | Print             | False               | Print              | False                |
