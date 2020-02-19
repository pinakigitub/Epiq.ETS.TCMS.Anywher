@Regression
@Ignore @DoNotExecute
@BankingTransactions
@EditTransactions
Feature: CaseBanking_Transactions_EditTransactions

@AssetsPage @deleteAllTransactionsForCase1960
#@US127778
#@Ignore @DoNotExecute
#Scenario Outline: 001_"EditTransaction_MandatoryFields" Validate Edit Transaction Mandatory and Dates Fields
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
#	And I Go to Banking Detail
#	And Click on More transactions button '<moreTrx>'
#	And Click to open Transaction with name '<transactionType>'
#	And Enter Transaction Name value '<trxName>'
#	And Enter Transaction Amount value '500'
#	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
#	And Click on Save New Transaction button
#	And Click Edit button for Transaction with Description '<trxName>'
#	When I Enter These Values for an Edit Transaction '<Transaction>','<Cleared>'
#	And I Click On Transaction Save Button
#	Then I See The Validation Messages for each Invalid Edit Transaction Field '<ValidReceived>','<ValidTransaction>','<ValidAmount>','<ValidCleared>'
#	And I See the Form is Still Open and the Transaction has NOT Been Saved 
#	And If I Enter valid Values for the Transaction Messages Dissapear One at a Time
#	And I Click On Transaction Save Button
#	And I See the Transaction has been Saved
#	Examples:
#| transactionType                  | Cleared       | ValidCleared  | moreTrx | codeToSelect | trxName                                    | ValidReceived | Transaction | ValidTransaction | ValidAmount |
#| Check                            | 01/30/2013    | LessThanTrx   | No      | 2420         | Franco Check 01                            | false         | default     | None             | False       |
#| Check                            | invalidFormat | InvalidFormat | No      | 2420         | Franco Check 01                            | false         | default     | None             | False       |
#| Check                            | invalidDate   | InvalidDate   | No      | 2420         | Franco Check 01                            | false         | default     | None             | False       |
#| Deposit                          | 01/30/2013    | LessThanTrx   | No      | 1290         | Franco Deposit 01                          | false         | default     | None             | False       |
#| Deposit                          | invalidFormat | InvalidFormat | No      | 1290         | Franco Deposit 01                          | false         | default     | None             | False       |
#| Deposit                          | invalidDate   | InvalidDate   | No      | 1290         | Franco Deposit 01                          | false         | default     | None             | False       |
#| Bank Service Charge              | 01/30/2013    | LessThanTrx   | Yes     | 2420         | Franco Bank Service Charge 01              | false         | default     | None             | False       |
#| Bank Service Charge              | invalidFormat | InvalidFormat | Yes     | 2420         | Franco Bank Service Charge 01              | false         | default     | None             | False       |
#| Bank Service Charge              | invalidDate   | InvalidDate   | Yes     | 2420         | Franco Bank Service Charge 01              | false         | default     | None             | False       |
#| Bank Service Charge Refund (Neg) | 01/30/2013    | LessThanTrx   | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | false         | default     | None             | False       |
#| Bank Service Charge Refund (Neg) | invalidFormat | InvalidFormat | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | false         | default     | None             | False       |
#| Bank Service Charge Refund (Neg) | invalidDate   | InvalidDate   | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | false         | default     | None             | False       |
#| Deposit Correcting Check         | 01/30/2013    | LessThanTrx   | Yes     | 1290         | Franco Deposit Correcting Check 01         | false         | default     | None             | False       |
#| Deposit Correcting Check         | invalidFormat | InvalidFormat | Yes     | 1290         | Franco Deposit Correcting Check 01         | false         | default     | None             | False       |
#| Deposit Correcting Check         | invalidDate   | InvalidDate   | Yes     | 1290         | Franco Deposit Correcting Check 01         | false         | default     | None             | False       |
##| Deposit Correcting Debit         | 10/30/2013    | LessThanTrx   | Yes     | 1290         | Franco Deposit Correcting Debit 01         | false         | default     | None             | False       |
##| Deposit Correcting Debit         | invalidFormat | InvalidFormat | Yes     | 1290         | Franco Deposit Correcting Debit 01         | false         | default     | None             | False       |
##| Deposit Correcting Debit         | invalidDate   | InvalidDate   | Yes     | 1290         | Franco Deposit Correcting Debit 01         | false         | default     | None             | False       |

@AssetsPage @deleteAllTransactionsForCase1960
#@US127778
#@Ignore @DoNotExecute
#Scenario Outline: 002_"EditTransaction_DatesManually" Add Transaction - Dates Manual Entry
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
#	And I Go to Banking Detail
#	And Click on More transactions button '<moreTrx>'
#	And Click to open Transaction with name '<transactionType>'
#	And Enter Transaction Name value '<trxName>'
#	And Enter Transaction Amount value '500'
#	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
#	And Click on Save New Transaction button
#	And Click Edit button for Transaction with Description '<trxName>'
#	When I Enter These Values for an Edit Transaction '<Transaction>','<Cleared>'
#	Then I See Dates Values Are Converted To '<Expected Transaction>' and '<Expected Cleared>'
#	Examples: 
#	| transactionType                  | Transaction | Expected Transaction | Cleared    | Expected Cleared | moreTrx | codeToSelect | trxName                                    |
#	| Check                            | default     | current              | 02/12/2029 | 02/12/2029       | No      | 2420         | Franco Check 01                            |
#	| Check                            | default     | current              | 02-12-2027 | 02/12/2027       | No      | 2420         | Franco Check 01                            |
#	| Check                            | default     | current              | 02122025   | 02/12/2025       | No      | 2420         | Franco Check 01                            |
#	| Deposit                          | default     | current              | 02/12/2029 | 02/12/2029       | No      | 1290         | Franco Deposit 01                          |
#	| Deposit                          | default     | current              | 02-12-2027 | 02/12/2027       | No      | 1290         | Franco Deposit 01                          |
#	| Deposit                          | default     | current              | 02122025   | 02/12/2025       | No      | 1290         | Franco Deposit 01                          |
#	| Bank Service Charge              | default     | current              | 02/12/2029 | 02/12/2029       | Yes     | 2420         | Franco Bank Service Charge 01              |
#	| Bank Service Charge              | default     | current              | 02-12-2027 | 02/12/2027       | Yes     | 2420         | Franco Bank Service Charge 01              |
#	| Bank Service Charge              | default     | current              | 02122025   | 02/12/2025       | Yes     | 2420         | Franco Bank Service Charge 01              |
#	| Bank Service Charge Refund (Neg) | default     | current              | 02/12/2029 | 02/12/2029       | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
#	| Bank Service Charge Refund (Neg) | default     | current              | 02-12-2027 | 02/12/2027       | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
#	| Bank Service Charge Refund (Neg) | default     | current              | 02122025   | 02/12/2025       | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
#    | Deposit Correcting Check         | default     | current              | 02/12/2029 | 02/12/2029       | Yes     | 1290         | Franco Deposit Correcting Check 01         |
#    | Deposit Correcting Check         | default     | current              | 02-12-2027 | 02/12/2027       | Yes     | 1290         | Franco Deposit Correcting Check 01         |
#    | Deposit Correcting Check         | default     | current              | 02122025   | 02/12/2025       | Yes     | 1290         | Franco Deposit Correcting Check 01         |
######| Deposit Correcting Debit         | default     | current              | 02/12/2029 | 02/12/2029       | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
######| Deposit Correcting Debit         | default     | current              | 02-12-2027 | 02/12/2027       | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
######| Deposit Correcting Debit         | default     | current              | 02122025   | 02/12/2025       | Yes     | 1290         | Franco Deposit Correcting Debit 01         |

@deleteAllTransactionsForCase1960
@AssetsPage @118916
Scenario Outline: 003A_"EditTransaction_Codes" Verify Code selection by different ways
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	When Click Edit button for Transaction with Name '<trxName>'
	Then Select Code by text '<codeToSelect>' using '<selectMethod>' for Transaction
	Examples:
	| selectMethod | transactionType                  | moreTrx | codeToSelect | trxName                                    |
	#| Click        | Check                            | No      | 2420         | Franco Check 01                            |
	#| Enter        | Check                            | No      | 2420         | Franco Check 01                            |
	#| Tab          | Check                            | No      | 2420         | Franco Check 01                            |
	#| Click        | Deposit                          | No      | 1290         | Franco Deposit 01                          |
	#| Enter        | Deposit                          | No      | 1290         | Franco Deposit 01                          |
	#| Tab          | Deposit                          | No      | 1290         | Franco Deposit 01                          |
    | Click        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         |
    | Enter        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         |
    | Tab          | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         |
####| Click        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
####| Enter        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
####| Tab          | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
	| Click        | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              |
	| Enter        | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              |
	| Tab          | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              |
	| Click        | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
	| Enter        | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
	| Tab          | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |

@deleteAllTransactionsForCase1960
@AssetsPage @118916
Scenario Outline: 003B_"EditTransaction_SubCodes" Verify Sub Code selection by different ways
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'	
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	When Click Edit button for Transaction with Name '<trxName>'
	Then Select Sub Code by text '<subCodeToSelect>' using '<selectMethod>' for Transaction
	Examples:
	| selectMethod | transactionType                  | moreTrx | codeToSelect | trxName                                    | subCodeToSelect |
	#| Click        | Check                            | No      | 2420         | Franco Check 01                            | 75              |
	#| Enter        | Check                            | No      | 2420         | Franco Check 01                            | 75              |
	#| Tab          | Check                            | No      | 2420         | Franco Check 01                            | 75              |
	#| Click        | Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              |
	#| Enter        | Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              |
	#| Tab          | Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              |
    | Click        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              |
    | Enter        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              |
    | Tab          | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              |
####| Click        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              |
####| Enter        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              |
####| Tab          | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              |
	| Click        | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              | 75              |
	| Enter        | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              | 75              |
	| Tab          | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              | 75              |
	| Click        | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | 75              |
	| Enter        | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | 75              |
	| Tab          | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | 75              |

@AssetsPage @deleteAllTransactionsForCase1960
@US127778
Scenario Outline: 004_"EditTransaction_SubCodes" Code and Sub Code Behaviors
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	When Select Code by text '<codeToSelect>' using 'Click' for Transaction
	Then Verify Transaction input field with Name 'Sub Code' has state 'Enabled'
	And Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
	And Verify Transaction input field with Name 'Sub Code' has state 'Enabled'
	And Verify Transaction input field with Name 'Code' has state 'Enabled'
	Examples:
	| transactionType                  | moreTrx | codeToSelect | trxName                                    | subCodeToSelect |
	#| Check                            | No      | 2420         | Franco Check 01                            | 75              |
	#| Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              |
    | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              |
####| Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              |
	| Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              | 75              |
	| Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 | 75              |

@AssetsPage @deleteAllTransactionsForCase1960
@US128020 @US126968
Scenario Outline: 005_"EditTransaction_SubCodes" Verify Code and Sub Code fields hide when adding Asset Link
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And Click on Add Asset Link button
	And Verify Transaction field with Name 'Code' is not visible
	And Verify Transaction field with Name 'Sub Code' is not visible
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	When Remove Asset Link with Asset Number '8'
	Then Verify Transaction field with Name 'Code' is visible
	And Verify Transaction field with Name 'Sub Code' is visible
	Examples:
	| selectMethod | transactionType                  | moreTrx | codeToSelect | trxName                                    | subCodeToSelect |
	#| Click        | Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              |
    | Click        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              |
####| Click        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              |

@AssetsPage @deleteLastGeneratedTransactionForCase1378
@US128020
Scenario Outline: 006_"EditTransaction_AssetLink" Verify Add Assets selection behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '<value>' in column '<columnName>'
	When Enter Linked Amount value '500' for Asset Number '<assetNumber>' 
	Then Verify Assets List shows correct data for linked Assets
	Examples:
	| selectMethod | transactionType                  | moreTrx | codeToSelect | trxName                                    | subCodeToSelect | value | columnName   | assetNumber |
	#| Click        | Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              | 8     | Asset Number | 8           |
	#| Click        | Deposit                          | No      | 1290         | Franco Deposit 01                          | 01              | 1270  | Code         | 9999        |
    | Click        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              | 8     | Asset Number | 8           |
    | Click        | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         | 01              | 1270  | Code         | 9999        |
####| Click        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              | 8     | Asset Number | 8           |
####| Click        | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         | 01              | 1270  | Code         | 9999        |


##### From here on, scenarios for Edit Deposit, Closing Costs ###################

@CaseDetail @BankingTransactions
@AddDeposits @Regression
@DepositsClaimslinks
@AssetsPage @deleteAllTransactionsForCase1960
@US128022
Scenario Outline: 007_"EditTransaction_ClosingCost" Cannot Select Repeated Claims
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '0'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And I Click On ADD Claim Link
	When I Search And Select Claim To Link On Row '1' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	And I Click On ADD Claim Link
	And I Click On Claim Search Box For Row '2'	
	And I Enter Text '<Claim Name>' on Claim Search Box Filter For Row '2'
	Then I See No Claim Result On Row '2' Has Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	Examples:
	# With Claim # full and empty
	| Claim # | Claim Name                  | Claim Code | transactionType                  | moreTrx | codeToSelect | trxName                                    |
	| 3       | COMPTROLLER OF THE TREASURY | 5800       | Check                            | No      | 2420         | Franco Check 01                            |
	|         | Trustee, Regression QA      | 2200       | Check                            | No      | 2420         | Franco Check 01                            |
	| 3       | COMPTROLLER OF THE TREASURY | 5800       | Deposit                          | No      | 1290         | Franco Deposit 01                          |
	|         | Trustee, Regression QA      | 2200       | Deposit                          | No      | 1290         | Franco Deposit 01                          |

#Save for asset links
#Intentar crear este scenario para Deposits y otros
@RegressionFixesIt34
@AssetsPage @deleteLastGeneratedTransactionForCase1378
@US128022
Scenario Outline: 008A_"EditTransaction_AssetLinks" Save With Assets Links And verify Assets Display on Ledger
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '300'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '1' By Asset Number '<Asset # 1>' And Asset Name '<Asset Name 1>' And Asset Code '<Asset Code 1>'
	And I Enter Asset Linked Amount '<Asset Amount 1>' On Row '1'
	And I Enter Asset Fully Administered Date 'Today' On Row '1' 
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '2' By Asset Number '<Asset # 2>' And Asset Name '<Asset Name 2>' And Asset Code ''
	And I Enter Asset Linked Amount '<Asset Amount 2>' On Row '2'
	When I Click On Save Deposit For Save With Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','<Asset # 2>','<Asset Name 2>','<Asset Amount 2>','<Asset # 1>','<Asset Name 1>','<Asset Amount 1>'
	And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	And I Verify Assets Links For Deposit Were Correctly Saved On DB
	Examples:
	| transactionType          | moreTrx | codeToSelect | trxName                            | Pay To                             | Net Deposit | Gross Deposit | Asset # 1 | Asset Name 1                          | Asset Code 1 | Asset Amount 1 | Asset # 2 | Asset Name 2                                       | Asset Code 2 | Asset Amount 2 |
	#| Deposit                  | No      | 1290         | Franco Deposit 01                  | Franco Deposit 01                  | $300.00     | $300.00       | 8         | 2003 DODGE PICKUP 45K MILES EXCELLENT | 1110         | $100.00        | 4         | COUCH/CHAIR/LOVE SEAT/2 END TABLES/2 TVS/COMPUTER/ |      1290    | $200.00        |
    | Deposit Correcting Check | Yes     | 1290         | Franco Deposit Correcting Check 01 | Franco Deposit Correcting Check 01 | $300.00     | $300.00       | 8         | 2003 DODGE PICKUP 45K MILES EXCELLENT | 1110         | $100.00        | 4         | COUCH/CHAIR/LOVE SEAT/2 END TABLES/2 TVS/COMPUTER/ |      1290    | $200.00        |
####| Deposit Correcting Debit | Yes     | 1290         | Franco Deposit Correcting Debit 01 | Franco Deposit Correcting Debit 01 | $300.00     | $300.00       | 8         | 2003 DODGE PICKUP 45K MILES EXCELLENT | 1110         | $100.00        | 4         | COUCH/CHAIR/LOVE SEAT/2 END TABLES/2 TVS/COMPUTER/ |      1290    | $200.00        |

@deleteAllTransactionsForCase1960
@AssetsPage @118916
Scenario Outline: 009_"EditTransaction_Code" Dropdown new behavior
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And Click on More transactions button '<moreTrx>'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And Click on Save New Transaction button
	When Click Edit button for Transaction with Name '<trxName>'
	Then Select value with text '<text>' typing at position '<position>' on field 'Code' using 'Click' for Transaction
	Examples:
	| position    | text | transactionType                  | moreTrx | codeToSelect | trxName                                    |
	| Beginning   | 2420 | Check                            | No      | 2420         | Franco Check 01                            |
	| End         | 2420 | Check                            | No      | 2420         | Franco Check 01                            |
	| Highlighted | 2420 | Check                            | No      | 2420         | Franco Check 01                            |
	| Beginning   | 1290 | Deposit                          | No      | 1290         | Franco Deposit 01                          |
	| End         | 1290 | Deposit                          | No      | 1290         | Franco Deposit 01                          |
	| Highlighted | 1290 | Deposit                          | No      | 1290         | Franco Deposit 01                          |
    | Beginning   | 1290 | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         |
    | End         | 1290 | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         |
    | Highlighted | 1290 | Deposit Correcting Check         | Yes     | 1290         | Franco Deposit Correcting Check 01         |
	#| Beginning   | 1290 | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
	#| End         | 1290 | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
	#| Highlighted | 1290 | Deposit Correcting Debit         | Yes     | 1290         | Franco Deposit Correcting Debit 01         |
	| Beginning   | 2420 | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              |
	| End         | 2420 | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              |
	| Highlighted | 2420 | Bank Service Charge              | Yes     | 2420         | Franco Bank Service Charge 01              |
	| Beginning   | 2420 | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
	| End         | 2420 | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |
	| Highlighted | 2420 | Bank Service Charge Refund (Neg) | Yes     | 2420         | Franco Bank Service Charge Refund (Neg) 01 |

@deleteAllTransactionsForCase1960
#@AssetsPage @118916
#@Ignore @DoNotExecute
#Scenario Outline: 010_"EditTransaction_SubCode" Dropdown new behavior
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
#	And I Go to Banking Detail
#	And Click on More transactions button '<moreTrx>'
#	And Click to open Transaction with name '<transactionType>'
#	And Enter Transaction Name value '<trxName>'
#	And Enter Transaction Amount value '500'
#	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
#	And Select Sub Code by text '<subCodeToSelect>' using 'Click' for Transaction
#	And Click on Save New Transaction button
#	When Click Edit button for Transaction with Name '<trxName>'
#	Then Select value with text '<text>' typing at position '<position>' on field 'Sub Code' using 'Click' for Transaction
#	Examples:
#	| position    | text | transactionType                  | moreTrx | codeToSelect | subCodeToSelect | trxName                                    |
#	| Beginning   | 75   | Check                            | No      | 2420         | 75              | Franco Check 01                            |
#	| End         | 75   | Check                            | No      | 2420         | 75              | Franco Check 01                            |
#	| Highlighted | 75   | Check                            | No      | 2420         | 75              | Franco Check 01                            |
#	| Beginning   | 01   | Deposit                          | No      | 1290         | 01              | Franco Deposit 01                          |
#	| End         | 01   | Deposit                          | No      | 1290         | 01              | Franco Deposit 01                          |
#	| Highlighted | 01   | Deposit                          | No      | 1290         | 01              | Franco Deposit 01                          |
#	| Beginning   | 1290 | Deposit Correcting Check         | Yes     | 1290         | 01              | Franco Deposit Correcting Check 01         |
#	| End         | 1290 | Deposit Correcting Check         | Yes     | 1290         | 01              | Franco Deposit Correcting Check 01         |
#	| Highlighted | 1290 | Deposit Correcting Check         | Yes     | 1290         | 01              | Franco Deposit Correcting Check 01         |
#	####| Beginning   | 1290 | Deposit Correcting Debit         | Yes     | 1290         | 01              | Franco Deposit Correcting Debit 01         |
#	####| End         | 1290 | Deposit Correcting Debit         | Yes     | 1290         | 01              | Franco Deposit Correcting Debit 01         |
#	####| Highlighted | 1290 | Deposit Correcting Debit         | Yes     | 1290         | 01              | Franco Deposit Correcting Debit 01         |
#	| Beginning   | 75   | Bank Service Charge              | Yes     | 2420         | 75              | Franco Bank Service Charge 01              |
#	| End         | 75   | Bank Service Charge              | Yes     | 2420         | 75              | Franco Bank Service Charge 01              |
#	| Highlighted | 75   | Bank Service Charge              | Yes     | 2420         | 75              | Franco Bank Service Charge 01              |
#	| Beginning   | 75   | Bank Service Charge Refund (Neg) | Yes     | 2420         | 75              | Franco Bank Service Charge Refund (Neg) 01 |
#	| End         | 75   | Bank Service Charge Refund (Neg) | Yes     | 2420         | 75              | Franco Bank Service Charge Refund (Neg) 01 |
#	| Highlighted | 75   | Bank Service Charge Refund (Neg) | Yes     | 2420         | 75              | Franco Bank Service Charge Refund (Neg) 01 |

@deleteLastGeneratedTransactionForCase1378
@CaseDetail @BankingTransactions
@ChecksClaimsLink
@TransactionSaving
@Regression 
Scenario Outline: 011A_"EditTransaction_ClaimLinks" Add Claim Link - Save Edit Check (2 Links)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'No'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '5000'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '1' By Claim Number '<Claim # 1>' And Claim Name '<Claim Name 1>' And Claim Code '<Claim Code 1>'	
	And I Enter Claim Link Amount '<Amount 1>' On Row '1'
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And I Click On ADD Claim Link
	And I See Claim Link Row '1' With Claim # '<Claim # 1>' Name '<Claim Name 1>' Code '<Claim Code 1>' Allocation Description '' Non-Compensable 'False' And Amount '<Amount 1>'
	And I Search And Select Claim To Link On Row '2' By Claim Number '<Claim # 2>' And Claim Name '<Claim Name 2>' And Claim Code '<Claim Code 2>'
	And I See Claim Link Row '2' With Claim # '<Claim # 2>' Name '<Claim Name 2>' Code '<Claim Code 2>' Allocation Description '' Non-Compensable 'False' And Amount ''
	And I Enter Claim Link Amount '<Amount 2>' On Row '2'
	And I See Claim Link Row '2' With Claim # '<Claim # 2>' Name '<Claim Name 2>' Code '<Claim Code 2>' Allocation Description '' Non-Compensable 'False' And Amount '<Amount 2>'
	And I Enter Pay To The Order Of '<Pay To>'
	When I Click On Save Check For Claim Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Check Amount>','<Claim # 1>','<Claim Name 1>','<Amount 1>','<Claim # 2>','<Claim Name 2>','<Amount 2>'
	And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Check Amount>'
	And I Verify Claim Links For Check Were Correctly Saved on DB
	Examples:
	# With Claim # full and empty
	| transactionType          | trxName         | moreTrx | codeToSelect | Pay To          | Check Amount | Claim # 1 | Claim Name 1                 | Claim Code 1 | Amount 1  | Claim # 2 | Claim Name 2  | Claim Code 2 | Amount 2 |
	| Deposit Correcting Check | Franco Check 01 | No      | 2420         | Franco Check 01 | $5,000.00    | 6         | CAPITAL ONE BANK (USA) N. A. | 7100         | $5,000.00 | 1         | DISCOVER BANK | 7100         | $0.00    |

@RegressionFixesIt34
@deleteLastGeneratedTransactionForCase1378
@CaseDetail @BankingTransactions
@ChecksClaimsLink
@TransactionSaving
@Regression 
Scenario Outline: 011B_"EditTransaction_ClaimLinks" Add Claim Link - Save Edit Check (2 Links)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'No'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '5000'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '1' By Claim Number '<Claim # 1>' And Claim Name '<Claim Name 1>' And Claim Code '<Claim Code 1>'	
	And I Enter Claim Link Amount '<Amount 1>' On Row '1'
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And I Click On ADD Claim Link
	And I See Claim Link Row '1' With Claim # '<Claim # 1>' Name '<Claim Name 1>' Code '<Claim Code 1>' Allocation Description '' Non-Compensable 'False' And Amount '<Amount 1>'
	And I Search And Select Claim To Link On Row '2' By Claim Number '<Claim # 2>' And Claim Name '<Claim Name 2>' And Claim Code '<Claim Code 2>'
	And I See Claim Link Row '2' With Claim # '<Claim # 2>' Name '<Claim Name 2>' Code '<Claim Code 2>' Allocation Description '' Non-Compensable 'False' And Amount ''
	And I Enter Claim Link Amount '<Amount 2>' On Row '2'
	And I See Claim Link Row '2' With Claim # '<Claim # 2>' Name '<Claim Name 2>' Code '<Claim Code 2>' Allocation Description '' Non-Compensable 'False' And Amount '<Amount 2>'
	And I Enter Pay To The Order Of '<Pay To>'
	When I Click On Save Deposit For Save With Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Check Amount>','<Claim # 1>','<Claim Name 1>','<Amount 1>','<Claim # 2>','<Claim Name 2>','<Amount 2>'
	And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Check Amount>'
	And I Verify Claim Links For Deposit Were Correctly Saved on DB
	#And I Verify Assets Links For Deposit Were Correctly Saved On DB
	#And I Verify Non Claim Payee Link For Deposit Were Correctly Saved On DB
	Examples:
	# With Claim # full and empty
	| transactionType               | trxName           | moreTrx | codeToSelect | Pay To            | Check Amount | Claim # 1 | Claim Name 1                 | Claim Code 1 | Amount 1 | Claim # 2 | Claim Name 2  | Claim Code 2 | Amount 2 |
	| Deposit Correcting Check      | Franco Deposit 01 | No      | 1290         | Franco Deposit 01 | $5,000.00    | 6         | CAPITAL ONE BANK (USA) N. A. | 7100         | $0.00    | 1         | DISCOVER BANK | 7100         | $0.00    |

@deleteLastGeneratedTransactionForCase1378
@CaseDetail @BankingTransactions
@ChecksClaimsLink
@Regression 
@US113140 @TC?
Scenario Outline: 012_"EditTransaction_ClaimLinks" Add Claim Link - Remove
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'No'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '500'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And I Click On ADD Claim Link
	And I Select The First Claim To Link On Row '1'
	And I Enter Claim Link Amount '<claimAmount>' On Row '1'
	And Click on Save New Transaction button
	#And Click Edit button for Transaction with Name '<trxName>'
	#And I Click On ADD Claim Link
	#When I Click On Remove Icon For Row '2'
	#Then I See '1' Claim Link Rows
	#And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'	
	#And I Click On Remove Icon For Row '1'
	#And I See '0' Claim Link Rows
	#And I See Add Claim Link Now Reads '<claimLinkLbl>'
	Examples:
	| transactionType | trxName           | moreTrx | codeToSelect | claimLinkLbl   | claimAmount |
	#| Deposit         | Franco Deposit 01 | No      | 1290         | ADD CLAIM      | $0.00       |
	| Check           | Franco Check 01   | No      | 2420         | ADD CLAIM LINK | $500.00     |


@deleteLastGeneratedTransactionForCase1378
@CaseDetail 
@BankingTransactions
@TransactionSaving
@Regression 
@US111938 @TC118489
@Bug127761Fixed
@Bug154406
Scenario Outline: 013_"EditTransaction_ClaimLinks" Save With Claim Link & Split UTC
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'No'
	And Click to open Transaction with name '<transactionType>'
	And Enter Transaction Name value '<trxName>'
	And Enter Transaction Amount value '400'
	And Select Code by text '<codeToSelect>' using 'Click' for Transaction
	And I Click On ADD UTC Link
	And I Set UTC Row Number '1' Name 'UTC Split Name # 1'
	And I Set UTC Row Number '1' Code '2300'
	And I Set UTC Row Number '1' Allocation Description 'Allocation Description # 1'
	And I Set UTC Row Number '1' Non-Compensable 'True'
	And I Set UTC Row Number '1' Amount '200.00'
	And I Set UTC Row Number '2' Name 'UTC Split Name # 2'
	And I Set UTC Row Number '2' Code '2200'
	And I Set UTC Row Number '2' Allocation Description 'Allocation Description # 2'
	And I Set UTC Row Number '2' Non-Compensable 'False'
	And I Set UTC Row Number '2' Amount '200.00'
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Name '<trxName>'
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '1' By Claim Number '8' And Claim Name 'CAPITAL RECOVERY V, LLC' And Claim Code '7100'	
	And I Enter Claim Link Amount '$0.00' On Row '1'
	When I Click On Save Check For UTC Split And Claim Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<trxName>','SPLIT','$400.00','8','CAPITAL RECOVERY V, LLC','','','',''
	And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<trxName>' Code 'SPLIT' And Amount '$400.00'
	And I Verify on DB That UTC Splits Have Been Saved
	And I Verify Claim Links For Check Were Correctly Saved on DB
	Examples:
	| transactionType | trxName           | moreTrx | codeToSelect |
	| Check           | Franco Check 01   | No      | 2420         |