@Regression
@Ignore @DoNotExecute
@BankingTransactions
@AddTransactionsBasics
#deposit correcting check
@US100915
#deposit correcting debit
@US100916
#Trasfer Founds (transfer out)
@US100909
#Bank service charge
@US100910
#Bank service charge refund
@US100911
Feature: Case Detail - Banking - Add All Transactions Basics
	In order to create new banking transactions
	As a user of Unity
	I need to be able to add Transactions for each bank account

## DEPOSIT CORRECTING CHECK - LAYOUT, ADD AND CANCEL CHECKS

@CaseDetail 
@BankingTransactions @AddReceiptTransactions
@Sanity
@US97337 @TC97668
@US111938 @TC118470 @TC118471 @TC118472
@US112468 @TC119569
Scenario Outline: 001 - Case Detail -  Banking - Add Transaction - Labels and Placeholders
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	When I Go To Create Transaction '<Transaction>'
	Then I See All Fields Contain Correct Labels And Placeholders
	And I See SUM OF ALLOCATION Field Is Not Present Except For Deposits
	And Entering A Negative Value On Amount Field Is Not Posible
Examples:
	| Transaction                      |
	| Check                            |
	| Deposit                          |
	| Deposit Correcting Check         |
	| Deposit Correcting Debit         |
	| Bank Service Charge Refund (Neg) |
	| Bank Service Charge              |
	| Transfer Out                     |


@CaseDetail 
@BankingTransactions @AddChecksC:\Users\abaquero\Source\Repos\ETS-TCMS.E2E\Epiq.ETS.TCMS.Anywhere.Testing.E2ETest\Test Framework\Steps\Login\
@TransactionSaving
@ChecksSaving
@Sanity
@US36860 @TC85421
@Bug157286Fixed
#Bug157286 All Under More Transactions, except from Transfer Out:cannot be saved on very long name
@Bug157287Fixed
#Bug157287 Checks - Pay to The Order Of value cropped on Save
@Bug157525Fixed
#Bug157525 Deposit Correcting Debit - Amount is not correctly saved on DB
@Bug157526Fixed
#Bug157526 Amount decimals on Bank Service Charge are rounded when saving
#Scenario Outline: 002 - Case Detail -  Banking - Add Transaction Save
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	And I Go To Create Transaction '<Transaction>'
#	When I Create a New Transaction As '<Pay to The Order Of>','<Description>','<Default Transaction Date>','<Default Cleared Date>','<Code>','<Non Compensable>','<Amount>'
#	Then I See Transaction Displays on Transactions List With '<Pay to The Order Of>','<Description>','<Default Transaction Date>','<Default Cleared Date>','<Code>','<Expected Amount>'
#Examples: 
#	| Transaction                      | Pay to The Order Of                                                           | Description           | Default Transaction Date | Default Cleared Date | Code | Non Compensable | Amount  | Expected Amount |
#	| Check                            | Test Automation Check 1                                                       | Automation Services   | True                     | True                 | 2100 | False           | 1500.00 | $1,500.00       |
#	| Check                            | Test Automation Check 2                                                       | Automation Services 2 | False                    | True                 | 2300 | False           | 500.35  | $500.35         |
#####| Check                            | Test Automation Check 3 - Very Long Name to Fit on Card                       | Automation Services 1 | True                     | True                 | 2810 | True            | 2300.98 | $2,300.98       |
#	| Deposit                          | Test Automation Deposit 1                                                     | Automation Services   | True                     | True                 | 2100 | False           | 1500.00 | $1,500.00       |
#	| Deposit                          | Test Automation Deposit 2                                                     | Automation Services 2 | False                    | True                 | 2300 | False           | 500.35  | $500.35         |
#####| Deposit                          | Test Automation Deposit 3 - Very Long Name to Fit on Card                     | Automation Services 1 | True                     | True                 | 2810 | True            | 2300.98 | $2,300.98       |
#	| Deposit Correcting Check         | Test Automation Deposit Correcting Check 1                                    | Automation Services   | True                     | True                 | 2100 | False           | 1500.00 | ($1,500.00)     |
#	| Deposit Correcting Check         | Test Automation Deposit Correcting Check 2                                    | Automation Services 2 | False                    | True                 | 2300 | False           | 500.35  | ($500.35)       |
#####| Deposit Correcting Check         | Test Automation Deposit Correcting Check 3 - Very Long Name to Fit on Card    | Automation Services 1 | True                     | True                 | 2810 | True            | 2300.98 | ($2,300.98)     |
#	| Deposit Correcting Debit         | Test Automation Deposit Correcting Debit 1                                    | Automation Services   | True                     | True                 | 2100 | False           | 1500.00 | ($1,500.00)     |
#	| Deposit Correcting Debit         | Test Automation Deposit Correcting Debit 2                                    | Automation Services 2 | False                    | True                 | 2300 | False           | 500.35  | ($500.35)       |
#####| Deposit Correcting Debit         | Test Automation Deposit Correcting Debit 3 - Very Long Name to Fit on Card    | Automation Services 1 | True                     | True                 | 2810 | True            | 2300.98 | ($2,300.98)     |
#	| Bank Service Charge              | Test Automation Deposit Bank Service Charge 1                                 | Automation Services   | True                     | True                 | 2100 | False           | 1500.00 | $1,500.00       |
#	| Bank Service Charge              | Test Automation Deposit Bank Service Charge 2                                 | Automation Services 2 | False                    | True                 | 2300 | False           | 500.35  | $500.35         |
#####| Bank Service Charge              | Test Automation Deposit Bank Service Charge 3 - Very Long Name to Fit on Card | Automation Services 1 | True                     | True                 | 2810 | True            | 2300.98 | $2,300.98       |
#	| Bank Service Charge Refund (Neg) | Test Automation Bank Service Charge Refund 1                                  | Automation Services   | True                     | True                 | 2100 | False           | 1500.00 | ($1,500.00)     |
#	| Bank Service Charge Refund (Neg) | Test Automation Bank Service Charge Refund 2                                  | Automation Services 2 | False                    | True                 | 2300 | False           | 500.35  | ($500.35)       |
#####| Bank Service Charge Refund (Neg) | Test Automation Bank Service Charge Refund 3 - Very Long Name to Fit on Card  | Automation Services 1 | True                     | True                 | 2810 | True            | 2300.98 | ($2,300.98)     |

@Ignore @DoNotExecute
@CaseDetail 
@BankingTransactions @AddChecks
@TransactionSaving
@Sanity
@US36859 @TC85410
Scenario Outline: 003 - Case Detail -  Banking - Cancel Transaction Creation
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	And I Go To Create Transaction '<Transaction>'
	When I Enter Valid Data for a New Transaction And Click on the Cancel Button
	Then I Do NOT See The Transaction on the Transactions List
Examples:
	| Transaction                      |
	| Check                            |
	| Deposit                          |
	| Deposit Correcting Check         |
	| Deposit Correcting Debit         |
	| Bank Service Charge Refund (Neg) |
	| Bank Service Charge              |
	| Transfer Out                     |