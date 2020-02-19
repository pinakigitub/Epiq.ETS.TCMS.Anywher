@Regression
@Ignore @DoNotExecute
@BankingTransactions
@EditDeposits
Feature: CaseBanking_Deposits_EditDeposit

@AssetsPage
@deleteAllTransactionsForCase1960
@US128020
Scenario: 001_"EditDeposit_SavingOutOfBalanceDeposit" Verify Deposit can be saved when is Out of Balance
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Description 'Franco Deposit 01'
	#And I save Edit Deposit Received From value
	#And I save Edit Deposit Serial Number value
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	And Enter Linked Amount value '7500' for Asset Number '1'
	#And Search and Select Code with text '1290' for Asset Link with Asset number '1'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '3' in column 'Asset Number'
	And Enter Linked Amount value '0' for Asset Number '3'
	And Verify Deposit message with text 'Gross Deposit Does Not Equal Sum of Allocation(s)' is displayed
	And Verify SAVE button format when in state 'Out Of Balance'
	When I Click On Save Deposit For Save With Links
	#And I save Transaction ID for Transaction Type 'Deposit' with Number ''
	#Then Verify Assets Link information is displayed on Ledger
	#And I See The Transaction Displays Data Correctly On Transactions List 'Franco Deposit 01','SPLIT','$15,000.00','1','RESIDENCE: SINGLE FAMILY HOME LOCATION: 4612 VALLE','$7,500.00','3','LOT 8, BLOCK 23, SECTION 1, CAROVA BEACH, CURRITUC','$0.00'

@AssetsPage
@deleteAllTransactionsForCase1960
@US128020
 Scenario: 002_"EditDeposit_EditingAssetLink" Save Deposit after changing Asset Link
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	And Enter Linked Amount value '15000' for Asset Number '1'
	And Search and Select Code with text '1290' for Asset Link with Asset number '1'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '3' in column 'Asset Number'
	And Enter Linked Amount value '0' for Asset Number '3'
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Description 'Franco Deposit 01'
	#And I save Edit Deposit Received From value
	#And I save Edit Deposit Serial Number value
	And Verify Assets List shows correct data for linked Assets
	And Remove Asset Link with Asset Number '3'
	And Remove Asset Link with Asset Number '1'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '13' in column 'Asset Number'
	#And Search and Select Code with text '1290' for Asset Link with Asset number '13'
	When I Click On Save Deposit For Save With Links
	#And I save Transaction ID for Transaction Type 'Deposit' with Number ''
	#Then Verify Assets Link information is displayed on Ledger
	#And I See The Transaction Displays Data Correctly On Transactions List 'Franco Deposit 01','1290','$15,000.00','13','CLOTHES: ATTIRE FOR SELF LOCATION: 4612 VALLEY FOR','$15,000.00','','',''

##### From here on, scenarios for Edit Deposit, Closing Costs ###################

@CaseDetail @BankingTransactions
@AddDeposits @Regression
@DepositsClosingCosts @DepositsClaimslinks
@AssetsPage
@deleteAllTransactionsForCase1960
@US128022
Scenario Outline: 003_"EditDeposit_ClosingCosts" Cannot Select Repeated Claims
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Description 'Franco Deposit 01'
	And I Click On ADD Claim Link
	And I Click On Claim Search Box For Row '1'	
	When I Select Claim To Link On Row '1' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>' Using Method 'Click'
	And I Click On ADD Claim Link	
	And I Click On Claim Search Box For Row '2'	
	And I Enter Text '<Claim Name>' on Claim Search Box Filter For Row '2'
	Then I See No Claim Result On Row '2' Has Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	Examples:
	# With Claim # full and empty
	| Claim # | Claim Name                  | Claim Code |
	| 3       | COMPTROLLER OF THE TREASURY | 5800       |
	| 1       | N. A. Capital One Bank (Usa)| 7100       |

@CaseDetail @BankingTransactions
@AddDeposits @DepositsClaimsLink
@Regression 
@AssetsPage
@deleteAllTransactionsForCase1960
@US128022
Scenario Outline: 004_"EditDeposit_ClosingCosts" SUM OF CLOSING COSTS
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Save New Transaction button
	When Click Edit button for Transaction with Description 'Franco Deposit 01'
	Then I See SUM OF CLOSING COSTS Label is 'SUM OF CLOSING COST(S)'
	And I See SUM OF CLOSING COSTS Is '$0.00'		
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '1' By Claim Number '<Claim # 1>' And Claim Name '<Claim Name 1>' And Claim Code '<Claim Code 1>'
	And I Click On ADD Claim Link
	And I See SUM OF CLOSING COSTS Is '$0.00'
	And I Search And Select Claim To Link On Row '2' By Claim Number '<Claim # 2>' And Claim Name '<Claim Name 2>' And Claim Code '<Claim Code 2>'
	And I See SUM OF CLOSING COSTS Is '$0.00'
	And I Enter Claim Link Amount '$200.00' On Row '1'
	And I See SUM OF CLOSING COSTS Is '$200.00'
	And I Enter Claim Link Amount '$300.00' On Row '1'
	And I See SUM OF CLOSING COSTS Is '$300.00'
	And I Enter Claim Link Amount '$200.00' On Row '2'
	And I See SUM OF CLOSING COSTS Is '$500.00'
	Examples:
	| Claim # 1 | Claim Name 1                 | Claim Code 1 | Claim # 2 | Claim Name 2                 | Claim Code 2 |
	| 1         | N. A. Capital One Bank (Usa) | 7100         | 2         | N. A. Capital One Bank (Usa) | 7100         |

@CaseDetail @BankingTransactions
@AddDeposits 
@DepositsClosingCosts @DepositsClaimslinks
@Regression 
@AssetsPage
@deleteAllTransactionsForCase1960
@US128022
Scenario Outline: 005_"EditDeposit_ClosingCosts" Add Non Claim Payee
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Description 'Franco Deposit 01'
	When I Click On ADD Non Claim Payee Link
	Then I See AdADD Non Claim Payee Link Text Reads 'ADD NON-CLAIM PAYEE'
	And See Non Claim Payee Name Placeholder For Row '1' Is 'Enter Payee Name...'
	And I See Non Claim Payee Code Placeholder For Row '1' Is 'Search...'
	And I See Non Claim Payee Link Row '1' With Name '' Code 'Search...' Allocation Description '' Non-Compensable 'False' And Amount ''
	And I Enter Non Claim Payee Name '<Name>' Code '<Code>' And Amount '<Amount>' On Row '1'
	And I Enter Non Claim Payee Link Allocation Description '<Allocation Description>' On Row '1'
	And I Enter Non Claim Payee Link Non-Compensable '<Non Compensable>' On Row '1'
	And I See Non Claim Payee Link Row '1' With Name '<Name>' Code '<Code>' Allocation Description '<Allocation Description>' Non-Compensable '<Non Compensable>' And Amount '<Amount>'
	And I Click On ADD Non Claim Payee Link
	And See Non Claim Payee Name Placeholder For Row '2' Is 'Enter Payee Name...'
	And I See Non Claim Payee Code Placeholder For Row '2' Is 'Search...'
	And I See Non Claim Payee Link Row '2' With Name '' Code 'Search...' Allocation Description '' Non-Compensable 'False' And Amount ''
	Examples:
	# With Claim # full and empty
	| Name                                                    | Code | Allocation Description         | Non Compensable | Amount  |
	| NON CLAIM PAYEE # 1 TEST                                | 5800 | TEST ALLOCATION description #1 | False           | $123.00 |
	| NON CLAIM PAYEE # 1 TEST VERY LONG NAME WHAT DO YOU SEE | 7100 | Alloc Desc # 2                 | False           |         |

#@CaseDetail @BankingTransactions
#@AddDeposits @TransactionSaving
#@DepositsClosingCosts
@Regression 
@AssetsPage
@deleteAllTransactionsForCase1960
@US128022
Scenario Outline: 006_"EditDeposit_ClosingCosts" Save With Closing Cost Links
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Description 'Franco Deposit 01'
	And I Click On ADD Non Claim Payee Link
	And I Enter Non Claim Payee Name 'Non Claim Payee Save Test' Code '7100' And Amount '$7,500.00' On Row '1'
	And I Enter Non Claim Payee Link Allocation Description 'NonClaim Payee Description' On Row '1'
	And I Enter Non Claim Payee Link Non-Compensable 'True' On Row '1'
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '2' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	And I Enter Claim Link Amount '<Claim Amount>' On Row '2'
	And I Enter Gross Deposit Amount '<Gross Deposit>'
	When I Click On Save Deposit For Save With Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','','','','','',''
	And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	And I Verify Claim Links For Deposit Were Correctly Saved on DB
	And I Verify Non Claim Payee Link For Deposit Were Correctly Saved On DB
	Examples:
	| Pay To            | Net Deposit | Gross Deposit | Claim # | Claim Name                  | Claim Code | Claim Amount |
	| Franco Deposit 01 | $15,000.00  | $30,000.00    | 3       | COMPTROLLER OF THE TREASURY | 5800       | $7,500.00    |

#Save for asset links
#@CaseDetail @BankingTransactions
#@AddDeposits @TransactionSaving
#@DepositsAssets 
@Regression 
@AssetsPage
@deleteAllTransactionsForCase1960
@US128022
Scenario Outline: 007_"EditDeposit_ClosingCosts"_Save With Assets Links And verify Assets Display on Ledger (Enter Assets Disordered)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON'
	And I Go to Banking Detail
	And I save Case ID from 'Banking' tab
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Enter Transaction Name value 'Franco Deposit 01'
	And Enter Transaction Amount value '15000'
	And Select day '' in CLEARED datepicker for new Deposit
	And Select Code by text '1290' using 'Click' for Transaction
	And Click on Save New Transaction button
	And Click Edit button for Transaction with Description 'Franco Deposit 01'
	And I Enter Gross Deposit Amount '<Gross Deposit>'	
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '1' By Asset Number '<Asset # 1>' And Asset Name '<Asset Name 1>' And Asset Code '<Asset Code 1>'
	And I Enter Asset Linked Amount '<Asset Amount 1>' On Row '1'
	And I Enter Asset Fully Administered Date 'Today' On Row '1' 
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '2' By Asset Number '<Asset # 2>' And Asset Name '<Asset Name 2>' And Asset Code '<Asset Code 2>'
	And I Enter Asset Linked Amount '<Asset Amount 2>' On Row '2'
	When I Click On Save Deposit For Save With Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','<Asset # 2>','<Asset Name 2>','<Asset Amount 2>','<Asset # 1>','<Asset Name 1>','<Asset Amount 1>'
	And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	And I Verify Assets Links For Deposit Were Correctly Saved On DB
	Examples:
	| Pay To            | Net Deposit | Gross Deposit | Asset # 1 | Asset Name 1                  | Asset Code 1 | Asset Amount 1 | Asset # 2 | Asset Name 2                                       | Asset Code 2 | Asset Amount 2 |
	| Franco Deposit 01 | $15,000.00  | $15,000.00    | 8         | HOUSEHOLD: CHINA & SILVERWARE |              | $7,500.00      | 1         | RESIDENCE: SINGLE FAMILY HOME LOCATION: 4612 VALLE |              | $7,500.00      |

