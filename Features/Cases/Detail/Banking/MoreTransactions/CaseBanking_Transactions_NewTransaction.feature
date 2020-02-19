@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: CaseBanking_Transactions_NewTransaction

@AssetsPage
@US127983
Scenario Outline: 001_"NewTransaction_SubCodes" Verify Code and Sub Code selection by different ways
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	When Select Code by text '<codeToSelect>' using '<selectMethod>' for Transaction
	Then Select Sub Code by text '<subCodeToSelect>' using '<selectMethod>' for Transaction
	Examples:
	| selectMethod | codeToSelect | subCodeToSelect | transactionName                  | moreTrx |
	| Click        | 1290         | 01              | Deposit Correcting Check         | Yes     |
	| Tab          | 1290         | 01              | Deposit Correcting Check         | Yes     |
	| Enter        | 1290         | 01              | Deposit Correcting Check         | Yes     |
	| Click        | 1290         | 01              | Deposit Correcting Debit         | Yes     |
	| Tab          | 1290         | 01              | Deposit Correcting Debit         | Yes     |
	| Enter        | 1290         | 01              | Deposit Correcting Debit         | Yes     |
	| Click        | 2420         | 75              | Bank Service Charge              | Yes     |
	| Tab          | 2420         | 75              | Bank Service Charge              | Yes     |
	| Enter        | 2420         | 75              | Bank Service Charge              | Yes     |
	| Click        | 9999         |                 | Transfer Out                     | Yes     |
	| Tab          | 9999         |                 | Transfer Out                     | Yes     |
	| Enter        | 9999         |                 | Transfer Out                     | Yes     |
	| Click        | 2420         | 75              | Bank Service Charge Refund (Neg) | Yes     |
	| Tab          | 2420         | 75              | Bank Service Charge Refund (Neg) | Yes     |
	| Enter        | 2420         | 75              | Bank Service Charge Refund (Neg) | Yes     |
	| Click        | 1290         | 01              | Deposit                          | No      |
	| Tab          | 1290         | 01              | Deposit                          | No      |
	| Enter        | 1290         | 01              | Deposit                          | No      |

@RegressionFixesIt34
@AssetsPage
@US127983
Scenario Outline: 001DepositCorrectingDebit_"NewTransaction_SubCodes" Verify Code and Sub Code selection by different ways
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	When Select Code by text '<codeToSelect>' using '<selectMethod>' for Transaction
	Then Select Sub Code by text '<subCodeToSelect>' using '<selectMethod>' for Transaction
	Examples:
	| selectMethod | codeToSelect | subCodeToSelect | transactionName                  | moreTrx |
	| Click        | 1290         | 01              | Deposit Correcting Debit         | Yes     |


@AssetsPage
@US127983
Scenario Outline: 002_"NewTransaction_SubCodes" Verify message for not found Sub Codes predictive results
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Select Code by text '<codeToSelect>' using '<selectMethod>' for Transaction
	When Search Sub Code by text '<subCodeToSelect>' for Transaction
	Then Verify error message for Not Matching Predictive results
	Examples:
	| transactionName                  | moreTrx | selectMethod | codeToSelect | subCodeToSelect |
	| Deposit Correcting Debit         | Yes     | Click        | 1290         | jhwdbcjhdck     |
	| Deposit Correcting Check         | Yes     | Click        | 1290         | jhwdbcjhdck     |
	| Bank Service Charge              | Yes     | Click        | 2420         | jhwdbcjhdck     |
	| Bank Service Charge Refund (Neg) | Yes     | Click        | 2420         | jhwdbcjhdck     |
	#| Deposit                          | No      | Click        | 1290         | jhwdbcjhdck     |

@AssetsPage
@US127983
Scenario Outline: 003_"NewTransaction_SubCodes" Code - Subcode Not enabled for no selection
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	Then Verify Transaction input field with Name 'Sub Code' has state '<subCodeState>'
	Examples:
	| transactionName                  | subCodeState |
	| Deposit Correcting Debit         | Disabled     |
	| Deposit Correcting Check         | Disabled     |
	| Bank Service Charge              | Enabled      |
	| Bank Service Charge Refund (Neg) | Enabled      |

@AssetsPage
@US127983
Scenario Outline: 004_"NewTransaction_SubCodes" Code and Sub Code Behaviors
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Verify Transaction input field with Name 'Sub Code' has state '<subCodeState1>'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	When Verify Transaction input field with Name 'Sub Code' has state '<subCodeState2>'
	Then Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
	Examples:
	| transactionName                  | moreTrx | codeToSelect | subCodeToSelect | subCodeState1 | subCodeState2 |
	| Deposit Correcting Check         | Yes     | 1290         | 01              | Disabled      | Enabled       |
	| Deposit Correcting Debit         | Yes     | 1290         | 01              | Disabled      | Enabled       |
	| Bank Service Charge              | Yes     | 2420         | 75              | Enabled       | Enabled       |
	| Bank Service Charge Refund (Neg) | Yes     | 2420         | 75              | Enabled       | Enabled       |
	#| Deposit                          | No      | 1290         | 01              | Disabled      | Enabled       |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@AssetsPage
#@US127983
#Scenario Outline: 005_"NewTransaction_Codes" Verify listed Codes are correct
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click on More transactions button '<clickMore>'
#	And Click to open Transaction with name '<transactionName>'
#	When Search Code by text '' for Transaction
#	Then Verify Codes list displayed is correct
#	Examples:
#	| transactionName                  | clickMore |
#	#| Deposit                          | No        |
#	| Check                            | No        |
#	| Deposit Correcting Check         | Yes       |
#	| Deposit Correcting Debit         | Yes       |
#	| Bank Service Charge              | Yes       |
#	| Bank Service Charge Refund (Neg) | Yes       |
#	| Transfer Out                     | Yes       |

	@DoNotExecute @RegressionFixesNeeded @Ignore 
@AssetsPage
@US127983
Scenario Outline: 006_"NewTransaction_SubCodes" Verify listed Sub Codes are correct
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	When Search Sub Code by text '' for Transaction
	Then Verify Sub Codes list displayed is correct
	Examples:
	| transactionName                  | codeToSelect |
	| Deposit Correcting Check         | 1290         |
	| Deposit Correcting Check         | 1290         |
	| Bank Service Charge              | 2420         |
	| Bank Service Charge Refund (Neg) | 2420         |


@AssetsPage
@US121341
Scenario Outline: 007_"NewTransaction_SumOfAllocation" Verify Sum Of Allocation label is updated with Linked Amount values
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '50' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '9999' in column 'Asset Number'
	And Enter Linked Amount value '50' for Asset Number '9999'
	And Verify SUM OF ALLOCATION displays correct value '$100.00'
	When Remove Asset Link with Asset Number '8'
	Then Verify SUM OF ALLOCATION displays correct value '$50.00'
	And Remove Asset Link with Asset Number '9999'
	And Verify SUM OF ALLOCATION displays correct value '$0.00'
	Examples:
	| transactionName                  |
	| Deposit Correcting Check         |
	| Deposit Correcting Debit         |

@AssetsPage
@US121341
Scenario Outline: 008_"NewTransaction_SumOfAllocation" Verify Sum Of Allocation label displayed only if Asset Links are added
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Verify SUM OF ALLOCATION label is not displayed
	And Click on Add Asset Link button
	Then Verify SUM OF ALLOCATION displays correct value '$0.00'
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '50' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '9999' in column 'Asset Number'
	And Enter Linked Amount value '50' for Asset Number '9999'
	And Verify SUM OF ALLOCATION displays correct value '$100.00'
	When Remove Asset Link with Asset Number '8'
	Then Verify SUM OF ALLOCATION displays correct value '$50.00'
	And Remove Asset Link with Asset Number '9999'
	And Verify SUM OF ALLOCATION displays correct value '$0.00'
	Examples:
	| transactionName                  |
	| Deposit Correcting Check         |
	| Deposit Correcting Debit         |

@AssetsPage
@US126982
Scenario Outline: 009_"NewTransaction_SumOfAllocation" Verify first asset link Linked amount is equal to entered Amount
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '<amount>'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '1' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '<linkedAmount>' for Asset Number '1'
	Examples:
	| transactionName          | amount | linkedAmount |
	| Deposit Correcting Check |        | $ 0.00       |
	| Deposit Correcting Debit |        | $ 0.00       |
	| Deposit Correcting Check | 500    | $ 500.00     |
	| Deposit Correcting Debit | 500    | $ 500.00     |

@RegressionFixesIt34
@AssetsPage
@US126982
Scenario Outline: 010_"NewTransaction_SumOfAllocation" Verify first asset link Linked amount is equal to entered Amount
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	And Verify Linked Amount value displayed is '$ 500.00' for Asset Number '1'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '2' in column 'Asset Number'
	And Verify Linked Amount value displayed is '$ 0.00' for Asset Number '2'
	And Remove Asset Link with Asset Number '1'
	And Enter Linked Amount value '250' for Asset Number '2'
	And Click on Add Additional Asset Link button
	When Search and Select Asset Link with value '5' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '$ 250.00' for Asset Number '5'
	Examples:
	| transactionName          |
	| Deposit Correcting Check |
	| Deposit Correcting Debit |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@AssetsPage
#@US126982
#Scenario Outline: 011_"NewTransaction_SumOfAllocation" Verify linked amount is not updated if Amount is updated
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click on More transactions button 'Yes'
#	And Click to open Transaction with name '<transactionName>'
#	And Enter Transaction Amount value '500'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '1' in column 'Asset Number'
#	And Verify Linked Amount value displayed is '$ 500.00' for Asset Number '1'
#	And Enter Transaction Amount value '250'
#	And Verify Linked Amount value displayed is '$ 500.00' for Asset Number '1'
#	Examples:
#	| transactionName          |
#	| Deposit Correcting Check |
#	| Deposit Correcting Debit |

@AssetsPage
@US126982
Scenario Outline: 012_"NewTransaction_SumOfAllocation" Verify Transaction Amount does not get cleared if removing asset link 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	And Verify Linked Amount value displayed is '$ 500.00' for Asset Number '1'
	When Remove Asset Link with Asset Number '1'
	Then Verify Transaction Amount value is '$ 500.00'
	Examples:
	| transactionName          |
	| Deposit Correcting Check |
	| Deposit Correcting Debit |

@AssetsPage
@US126982
Scenario Outline: 013_"NewTransaction_SumOfAllocation" Verify if equation is negative then next asset link linked amount is 0 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'Yes'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	And Enter Linked Amount value '600' for Asset Number '1'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '2' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '$ 0.00' for Asset Number '2'
	Examples:
	| transactionName          |
	| Deposit Correcting Check |
	| Deposit Correcting Debit |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@AssetsPage
#@US126982
#Scenario Outline: 014_"NewTransaction_SumOfAllocation" Verify first asset link behavior when removing and adding it or different Amounts
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click on More transactions button 'Yes'
#	And Click to open Transaction with name '<transactionName>'
#	And Enter Transaction Amount value '500'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Verify Linked Amount value displayed is '$ 500.00' for Asset Number '8'
#	And Remove Asset Link with Asset Number '8'
#	And Enter Transaction Amount value '1200'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '1' in column 'Asset Number'
#	Then Verify Linked Amount value displayed is '$ 1,200.00' for Asset Number '1'
#	Examples:
#	| transactionName          |
#	| Deposit Correcting Check |
#	| Deposit Correcting Debit |

@US152096
Scenario Outline: 015_"NewTransaction_SumOfAllocation" Check Out of Balance Message Disbursement Transactions
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '500'
	And I Click On ADD UTC Link
	And I See SUM OF ALLOCATION Is '$0.00' In a 'RED' Box
	And Verify Disbursement Transactions message when Out of Balance
	And I Set UTC Row Number '1' Amount '100.00'
	And I See SUM OF ALLOCATION Is '$100.00' In a 'RED' Box
	And Verify Disbursement Transactions message when Out of Balance
	And I Set UTC Row Number '1' Amount '500.00'
	And I See SUM OF ALLOCATION Is '$500.00' In a 'GREEN' Box
	And Verify Disbursement Transactions message not displayed when Balanced
	And I Set UTC Row Number '1' Amount '600.00'
	And I See SUM OF ALLOCATION Is '$600.00' In a 'RED' Box
	And Verify Disbursement Transactions message when Out of Balance
	Examples:
	| transactionName                                | moreTrx |
	| Check                                          | No      |
	#| Wire Debit                                     | Yes     |
	#| Record Funds Returned from a Payee or Creditor | Yes     |
	#| Adjustment Debit                               | Yes     |

@RegressionFixesIt34
@US154994
Scenario Outline: 016_"NewTransaction_SumOfAllocation" Check Out of Balance Message Receipt Transactions
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '500'
	And Click on Add Asset Link button
	And I See SUM OF ALLOCATION Is '$500.00' In a 'GREEN' Box
	And Verify Receipt Transactions message not displayed when Balanced
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	And Enter Linked Amount value '$500.00' for Asset Number '1'
	And I See SUM OF ALLOCATION Is '$500.00' In a 'GREEN' Box
	#And Verify Receipt Transactions message when Out of Balance
	#And Enter Linked Amount value '$500.00' for Asset Number '1'
	#And I See SUM OF ALLOCATION Is '$500.00' In a 'GREEN' Box
	#And Verify Receipt Transactions message not displayed when Balanced
	#And Enter Linked Amount value '600' for Asset Number '1'
	#And I See SUM OF ALLOCATION Is '$600.00' In a 'RED' Box
	#And Verify Receipt Transactions message when Out of Balance	
	Examples:
	| transactionName          | moreTrx |
	| Deposit Correcting Check | Yes     |
	| Deposit Correcting Debit | Yes     |
	#| Wire Credit              | Yes     |
	#| Adjustment Credit        | Yes     |

@US152096
Scenario Outline: 017_"NewTransaction_SumOfAllocation" Check Out of Balance Message Disbursement Transactions
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionName>'
	And Enter Transaction Amount value '500'
	And I Click On ADD UTC Link
	And I See SUM OF ALLOCATION Is '$0.00' In a 'RED' Box
	And Verify Disbursement Transactions message when Out of Balance
	And I Set UTC Row Number '1' Amount '100.00'
	And I See SUM OF ALLOCATION Is '$100.00' In a 'RED' Box
	And Verify Disbursement Transactions message when Out of Balance
	And I Set UTC Row Number '1' Amount '500.00'
	And I See SUM OF ALLOCATION Is '$500.00' In a 'GREEN' Box
	And Verify Disbursement Transactions message not displayed when Balanced
	And I Set UTC Row Number '1' Amount '600.00'
	And I See SUM OF ALLOCATION Is '$600.00' In a 'RED' Box
	And Verify Disbursement Transactions message when Out of Balance
	Examples:
	| transactionName                                | moreTrx |
	| Check                                          | No      |
	#| Wire Debit                                     | Yes     |
	#| Record Funds Returned from a Payee or Creditor | Yes     |
	#| Adjustment Debit                               | Yes     |