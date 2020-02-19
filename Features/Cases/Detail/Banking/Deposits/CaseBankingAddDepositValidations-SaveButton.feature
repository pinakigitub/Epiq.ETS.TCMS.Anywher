@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: Case Detail - Banking - Add Deposits Validations - Save button
	In order to create new deposits and validate entries
	As a user of Unity
	I need to be able to see validation errors and correct them when adding a deposit by clicking on Save button

## ADD TRANSACTIONS VALIDATIONS - DEPOSITS
# Validations triggered when clicking on Save button
#@CaseDetail 
#@BankingTransactions @AddDeposit
#@TransactionSaving
#@AddDepositValidations @Validations
#@Sanity
#@US95535 @TC98704
#@US95596 @TC101452 @TC101455 @TC101456 @TC101457 @TC101458 @TC101459 @TC101462
#Scenario Outline: Case Detail -  Banking - Validate New Deposit Mandatory and Dates Fields
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	And I Click on Deposit Button
#	When I Enter These Values for a New Transaction '<Received>','<Transaction>','<Amount>','<Cleared>'
#	And I Click On Transaction Save Button
#	Then I See The Validation Messages for each Invalid Transaction Field '<ValidReceived>','<ValidTransaction>','<ValidAmount>','<ValidCleared>'
#	And I See the Form is Still Open and the Transaction has NOT Been Saved 
#	And If I Enter valid Values for the Transaction Messages Dissapear One at a Time
#	And I Click On Transaction Save Button
#	And I See the Transaction has been Saved
#	Examples:
#		#Now is just the mandatory fields Scenarios, will try add the other fields later
#		| Received                          | ValidReceived | Transaction   | ValidTransaction   | Amount | ValidAmount | Cleared       | ValidCleared  |
#		|                                   | False         |               | Empty              |        | False       | default       | None          |
#		|                                   | False         |               | Empty              | 150000 | True        | default       | None          |
#		|                                   | False         | current       | None               |        | False       | default       | None          |
#		|                                   | False         | current       | None               | 150000 | True        | default       | None          |
#		| Test Automation Validations       | True          | current       | None               |        | False       | default       | None          |
#		| Test Automation Validations       | True          |               | Empty              |        | False       | default       | None          |
#		| Test Automation Validations       | True          |               | Empty              | 150000 | True        | default       | None          |
#		# Transaction > Cleared
#		| Test Automation Dates Validations | True          | future        | GreaterThanCleared | 130    | True        | current       | LessThanTrx   |
#		# Clear < current
#		| Test Automation Dates Validations | True          | current       | GreaterThanCleared | 130    | True        | past          | LessThanTrx   |
#		# Transaction < current
#		| Test Automation Dates Validations | True          | past          | Past               | 130    | True        | default       | None          |
#		# Transaction < current and Clear < current
#		| Test Automation Dates Validations | True          | past          | Past               | 130    | True        | past          | None          |
#		# Only Cleared < current
#		| Test Automation Dates Validations | True          | default       | GreaterThanCleared | 130    | True        | past          | LessThanTrx   |
#		# Invalid Format Trx and Cleared
#		| Test Automation Dates Validations | True          | invalidFormat | InvalidFormat      | 130    | True        | invalidFormat | InvalidFormat |
#		# Invalid Date Trx
#		| Test Automation Dates Validations | True          | invalidDate   | InvalidDate        | 130    | True        | default       | None          |
#		# Invalid Date Cleared		
#		| Test Automation Dates Validations | True          | default       | GreaterThanCleared | 130    | True        | invalidDate   | LessThanTrx   |

# DATES MANUAL ENTRY ABILITY + VALIDATIONS
#@CaseDetail 
#@BankingTransactions @AddDeposits
#@AddDepositValidations @Validations
#@Sanity
#@US95596 @TC101453 @TC101454 @TC102794
#Scenario Outline: Case Detail -  Banking - Add Deposit - Dates Manual Entry
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	And I Click on Deposit Button
#	When I Enter These Values for a New Transaction '<ReceivedFrom>','<Transaction>','<Amount>','<Cleared>'
#	Then I See Dates Values Are Converted To '<Expected Transaction>' and '<Expected Cleared>'
#	Examples: 
#	| ReceivedFrom                         | Amount | Transaction | Expected Transaction | Cleared    | Expected Cleared |
#	| Test Automation Dates Manual Entry 1 | 0      | 02/12/2029  | 02/12/2029           | 02/12/2029 | 02/12/2029       |
#	| Test Automation Dates Manual Entry 2 | 0      | 02-12-2027  | 02/12/2027           | 02-12-2027 | 02/12/2027       |