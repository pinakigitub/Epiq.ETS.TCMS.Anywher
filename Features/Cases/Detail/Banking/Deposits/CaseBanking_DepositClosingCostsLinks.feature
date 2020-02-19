@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: Case Detail - Banking - Deposit Closing Costs - Claims Links
	In order to be able to balance transactions
	As a User with Banking or Epiq Admin Role only
	I want to be able to write a deposit with closing costs associated to it

@CaseDetail @BankingTransactions 
@DepositsClosingCosts @DepositsClaimslinks
@US121352 @TC?
Scenario: 001 - Case Detail - Banking - Deposits - Add Claim Link - Layout
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I See Deposit Claim Link Section Layout Is Correct
	#claim link title, Add claim link when no links, link icon
	When I Click On ADD Claim Link
	Then I See Labels For Claim Link Columns Are Correct
	#claim link row: delete icon, claim # Claim Name, Code
	And I See '1' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'	
	And I Search And Select Claim To Link On Row '1' By Claim Number '10' And Claim Name 'COMPTROLLER OF MARYLAND' And Claim Code '5800'
	#Add more than one claim link
	And I Click On ADD Claim Link
	And I See '2' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'


@CaseDetail @BankingTransactions
@DepositsClosingCosts @DepositsClaimslinks
@US121352 @TC?
Scenario: 002 - Case Detail - Banking - Deposits - Add Claim Link - List Of Claims
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button	
	When I Click On ADD Claim Link
	Then I See Claim Name Search Box Placeholder For Row '1' Is 'Find claim by claim #, claim Name, or code...'
	And I Click On Claim Search Box For Row '1'
	And I See The List Of Claims Displays With Correct Layout On Row '1'
	#And I See The List Of Claims Has Correct Data
	And I Search And Select Claim To Link On Row '1' By Claim Number '10A' And Claim Name 'COMPTROLLER OF MARYLAND' And Claim Code '5800' 
	#Add A second row and try to search
	And I Click On ADD Claim Link
	And I See Claim Name Search Box Placeholder For Row '2' Is 'Find claim by claim #, claim Name, or code...'
	And I Click On Claim Search Box For Row '2'
	And I See The List Of Claims Displays With Correct Layout On Row '2'


@CaseDetail @BankingTransactions 
@DepositsClosingCosts @DepositsClaimslinks
@US121352 @TC?
Scenario Outline: 003 - Case Detail - Banking - Deposits - Add Claim Link - Filter Claims List Results
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button	
	And I Click On ADD Claim Link
	When I Click On Claim Search Box For Row '1'
	And I Enter Text '<text>' on Claim Search Box Filter For Row '1'
	Then I See Filtered Results Match Search Text '<text>'
	Examples:
	| text                              |
	#Claim Number
	| 10                                |
	| 5                                 |
	# Claim Name
	| LICENSING MARYLAND DEPT. OF LABOR |
	| STINSON MORRISON HECKER LLP       |
	# Code
	| 2100                              |
	| 5800                              |
	| 7100                              |


@CaseDetail @BankingTransactions
@DepositsClosingCosts @DepositsClaimslinks
@US121352 @TC?
Scenario: 004 - Case Detail - Banking - Deposits - Add Deposits Link - Claims Filter With No Results
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Click On ADD Claim Link
	When I Click On Claim Search Box For Row '1'
	And I Enter Text 'Non Existent Claim' on Claim Search Box Filter For Row '1'
	Then I See No Claims Results On The Grid And a Message Reading 'No Results Available'

#Apparently, no case will have active BAs and no Claims

@CaseDetail @BankingTransactions
@DepositsClosingCosts @DepositsClaimslinks
@US121352 @TC?
Scenario Outline: 005 - Case Detail - Banking - Deposits - Add Claim Link - Claim Selection
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Click On ADD Claim Link
	And I Click On Claim Search Box For Row '1'
	When I Select Claim To Link On Row '1' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>' Using Method '<Method>'
	Then I See Claim Link Grid Closes
	And I See Claim Link Row '1' With Claim # '<Claim #>' Name '<Claim Name>' Code '<Claim Code>' Allocation Description '<Allocation Descr>' Non-Compensable '<Non Compensable>' And Amount '<Amount>'
	Examples:
	# With Claim # full and empty
	| Claim # | Claim Name              | Claim Code | Method | Allocation Descr | Non Compensable | Amount |
	| 10A     | COMPTROLLER OF MARYLAND | 5800       | Tab    |                  | False           |        |
	| 10A     | COMPTROLLER OF MARYLAND | 5800       | Click  |                  | False           |        |
	|         | ROSE, CHERYL E.         | 3110       | Tab    |                  | False           |        |
	|         | ROSE, CHERYL E.         | 3110       | Click  |                  | False           |        |
	#Removing following scenarios from resolution of BUG 152373	
	#| 10A     | COMPTROLLER OF MARYLAND | 5800       | Enter  |                  | False           |        |
	#|         | JAMES H. BRANDON, CPA   | 3410       | Enter  |                  | False           |        |  

	
@CaseDetail @BankingTransactions
@DepositsClosingCosts @DepositsClaimslinks
@US121352 @TC?
Scenario Outline: 006 - Case Detail - Banking - Deposits - Add Claim Link - Cannot Select Repeated Claims
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button	
	And I Click On ADD Claim Link
	And I Click On Claim Search Box For Row '1'	
	When I Select Claim To Link On Row '1' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>' Using Method 'Click'
	And I Click On ADD Claim Link	
	And I Click On Claim Search Box For Row '2'	
	And I Enter Text '<Claim Name>' on Claim Search Box Filter For Row '2'
	Then I See No Claim Result On Row '2' Has Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	Examples:
	# With Claim # full and empty
	| Claim # | Claim Name               | Claim Code |
	| 10B     | COMPTROLLER OF MARYLAND  | 7100       |
	| 16A     | INTERNAL REVENUE SERVICE | 5800       |

#Closing cost links sorted - FEATURE REMOVED BY PO
#@CaseDetail @BankingTransactions
#@DepositsClosingCosts @DepositsClaimslinks
#
#@US124994 @TC?
#Scenario: 007 - Case Detail - Banking - Deposits - Add Claim Link - Links Sorting
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '09-13569'
#	And I Go to Banking Detail
#	And I Click on Deposit Button
#	And I Click On ADD Claim Link	
#	And I Search And Select Claim To Link On Row '1' By Claim Number '10' And Claim Name 'COMPTROLLER OF MARYLAND' And Claim Code '7100'		
#	And I Click On ADD Claim Link	
#	And I Search And Select Claim To Link On Row '2' By Claim Number '5' And Claim Name 'STINSON MORRISON HECKER LLP' And Claim Code '7100'
#	And I Click On ADD Claim Link	
#	And I Search And Select Claim To Link On Row '3' By Claim Number '' And Claim Name 'JohnQ' And Claim Code '2100'
#	And I Click On ADD Claim Link
#	And I Search And Select Claim To Link On Row '4' By Claim Number '12' And Claim Name 'LICENSING MARYLAND DEPT. OF LABOR' And Claim Code '5800'
#	And I Click On ADD Claim Link
#	And I Search And Select Claim To Link On Row '5' By Claim Number '10' And Claim Name 'COMPTROLLER OF MARYLAND' And Claim Code '5800'
#	When I Click On ADD Claim Link
#	Then I See Claim Link Row '2' With Claim # '' Name 'JohnQ' Code '2100' Allocation Description '' Non-Compensable 'False' And Amount '$ 0.00'
#	And I See Claim Link Row '3' With Claim # '5' Name 'STINSON MORRISON HECKER LLP' Code '7100' Allocation Description '' Non-Compensable 'False' And Amount '$ 0.00'
#	And I See Claim Link Row '4' With Claim # '10' Name 'COMPTROLLER OF MARYLAND' Code '7100' Allocation Description '' Non-Compensable 'False' And Amount '$ 0.00'
#	And I See Claim Link Row '5' With Claim # '10' Name 'COMPTROLLER OF MARYLAND' Code '5800' Allocation Description '' Non-Compensable 'False' And Amount '$ 0.00'
#	And I See Claim Link Row '6' With Claim # '12' Name 'LICENSING MARYLAND DEPT. OF LABOR' Code '5800' Allocation Description '' Non-Compensable 'False' And Amount '$ 0.00'
#	#| Claim Name                        | Claim Code |
#	#| JohnQ                             | 2100       |
#	#| STINSON MORRISON HECKER LLP       | 7100       |
#	#| COMPTROLLER OF MARYLAND           | 5800       |
#	#| COMPTROLLER OF MARYLAND           | 7100       |
#	#| LICENSING MARYLAND DEPT. OF LABOR | 5800       |

@CaseDetail @BankingTransactions
@DepositsClaimslinks
@US121398 @TC?
Scenario: 008 - Case Detail - Banking - Deposits - Add Closing Costs Link - Remove In Order
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Click On ADD Claim Link
	And I Select The First Claim To Link On Row '1'
	And I Click On ADD Claim Link
	When I Click On Remove Icon For Row '2'
	Then I See '1' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'	
	And I Click On Remove Icon For Row '1'
	And I See '0' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD CLAIM'

@CaseDetail @BankingTransactions
@DepositsClaimslinks
@US121398 @TC?
Scenario: 009 - Case Detail - Banking - Deposits - Add Closing Costs Link - Remove From Middle
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Click On ADD Claim Link
	And I Select The First Claim To Link On Row '1'
	And I Click On ADD Claim Link
	And I Select The First Claim To Link On Row '2'
	And I Click On ADD Claim Link
	And I Select The First Claim To Link On Row '3'	
	And I Click On ADD Claim Link
	And I See '4' Claim Link Rows
	When I Click On Remove Icon For Row '2'
	Then I See '3' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'
	And I Click On Remove Icon For Row '2'
	And I See '2' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'
	And I Click On Remove Icon For Row '2'
	And I See '1' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD ADDITIONAL CLAIM LINK'	
	And I Click On Remove Icon For Row '1'
	And I See '0' Claim Link Rows
	And I See Add Claim Link Now Reads 'ADD CLAIM'

@CaseDetail @BankingTransactions
@DepositsClaimsLink
@US121386
Scenario Outline: 010 - Case Detail - Banking - Deposits - Add Closing Cost Link - SUM OF CLOSING COSTS
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	When I Click on Deposit Button	
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
	| Pay To                                        | Claim # 1 | Claim Name 1 | Claim Code 1 | Claim # 2 | Claim Name 2      | Claim Code 2 |
	| Test Automation Claim Links Sum Of Allocation | 13        | VERIZON      | 7100         | 3         | CHASE BANK USA NA | 7100         |

@CaseDetail @BankingTransactions
@DepositsClosingCosts @DepositsClaimslinks
@US121388 @TC?
Scenario Outline: 011 - Case Detail - Banking - Deposits - Add Non Claim Payee
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
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

@CaseDetail @BankingTransactions
@DepositsClaimsLink
@US123058 @CR121900
Scenario Outline: 012 - Case Detail - Banking - Deposits - Add Closing Cost Link - Gross Deposit vs Net Deposit Validation
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Click On ADD Non Claim Payee Link
	And I Enter Non Claim Payee Name '' Code '' And Amount '<Amount>' On Row '1'
	And I Enter Net Deposit Amount '<Net Deposit>'
	When I Enter Gross Deposit Amount '<Gross Deposit>'
	Then I See Save Buttons Are Disabled
	And I See an Alert Validation Message Reading 'Gross Deposit Does Not Equal Sum of Allocation(s)'
	Examples:
	#Different values to generate the same condition
	| Net Deposit | Gross Deposit | Amount		 |
	| $700.00     | $500.00       | $100.00      |
	| $700.00     | $700.00       | $100.00      |
	| $400.00     | $800.00       | $200.00      |


### SAVE TEST SCENARIOS
#Save for no links - run already existent test to add deposits

#Save for closing cost links
@CaseDetail @BankingTransactions
@TransactionSaving
@DepositsClosingCosts
@US123038 @US110761 @TC?
Scenario Outline: 014 - Case Detail - Banking - Deposits - Save With Closing Cost Links
	Given I enter to 341 Meeting page as superuser
	#Go to case with CaseId=1029
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Enter Deposit Received From Value '<Pay To>'	
	And I Click On ADD Non Claim Payee Link
	And I Enter Non Claim Payee Name 'Non Claim Payee Save Test' Code '7100' And Amount '$100.00' On Row '1'
	And I Enter Non Claim Payee Link Allocation Description 'NonClaim Payee Description' On Row '1'
	And I Enter Non Claim Payee Link Non-Compensable 'True' On Row '1'
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '2' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	And I Enter Claim Link Amount '<Claim Amount>' On Row '2'
	And I Enter Net Deposit Amount '<Net Deposit>'
	And I Enter Gross Deposit Amount '<Gross Deposit>'	
	When I Click On Save Deposit For Save With Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','','','','','',''	
	#And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	#And I Verify Claim Links For Deposit Were Correctly Saved on DB
	#And I Verify Non Claim Payee Link For Deposit Were Correctly Saved On DB
	Examples:
	| Pay To                                        | Net Deposit | Gross Deposit | Claim # | Claim Name                | Claim Code | Claim Amount |
	| Test Automation For Saving With Closing Costs | $250.00     | $500.00       | 7       | R&R PROFESSIONAL RECOVERY | 7100       | $150.00      |


#Save for asset links
@CaseDetail @BankingTransactions
@TransactionSaving
@DepositsAssets
@US123038 @US110761 @TC?
Scenario Outline: 013 - Case Detail - Banking - Deposits - Save With Assets Links And verify Assets Display on Ledger (Enter Assets Disordered)
	Given I enter to 341 Meeting page as superuser
	#Go to case with CaseId=1029
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Enter Deposit Received From Value '<Pay To>'
	And I Enter Net Deposit Amount '<Net Deposit>'
	And I Enter Gross Deposit Amount '<Gross Deposit>'	
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '1' By Asset Number '<Asset # 1>' And Asset Name '<Asset Name 1>' And Asset Code '<Asset Code 1>'
	And I Enter Asset Linked Amount '<Asset Amount 1>' On Row '1'
	And I Enter Asset Fully Administered Date 'Today' On Row '1' 
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '2' By Asset Number '<Asset # 2>' And Asset Name '<Asset Name 2>' And Asset Code '<Asset Code 2>'
	And I Enter Asset Linked Amount '<Asset Amount 2>' On Row '2'
	When I Click On Save Deposit For Save With Links
	#Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','<Asset # 2>','<Asset Name 2>','<Asset Amount 2>','<Asset # 1>','<Asset Name 1>','<Asset Amount 1>'
	#And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	#And I Verify Assets Links For Deposit Were Correctly Saved On DB
	Examples:
	| Pay To                                   | Net Deposit | Gross Deposit | Asset # 1 | Asset Name 1                                       | Asset Code 1 | Asset Amount 1 | Asset # 2 | Asset Name 2         | Asset Code 2 | Asset Amount 2 |
	| Test Automation Saving With Assets Links | $300.00     | $300.00       | 8         | BUSINESS CHECKING ACCOUNT (NEWWAVE SOLUTIONS, LLC) | 1121         | $100.00        | 1         | Adv. Proc. #07-00402 |              | $200.00        |

@CaseDetail @BankingTransactions
@TransactionSaving
@DepositsAssets
@US123038 @US110761 @TC?
Scenario Outline: 013 - Case Detail - Banking - Deposits - Save With Assets Links And verify Assets Display on Ledger (Enter Assets Ordered)
	Given I enter to 341 Meeting page as superuser
	#Go to case with CaseId=1029
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Enter Deposit Received From Value '<Pay To>'
	And I Enter Net Deposit Amount '<Net Deposit>'
	And I Enter Gross Deposit Amount '<Gross Deposit>'	
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '1' By Asset Number '<Asset # 1>' And Asset Name '<Asset Name 1>' And Asset Code '<Asset Code 1>'
	And I Enter Asset Linked Amount '<Asset Amount 1>' On Row '1'
	And I Enter Asset Fully Administered Date '10/27/2016' On Row '1' 
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '2' By Asset Number '<Asset # 2>' And Asset Name '<Asset Name 2>' And Asset Code '<Asset Code 2>'
	And I Enter Asset Linked Amount '<Asset Amount 2>' On Row '2'
	When I Click On Save Deposit For Save With Links
	#Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','<Asset # 1>','<Asset Name 1>','<Asset Amount 1>','<Asset # 2>','<Asset Name 2>','<Asset Amount 2>'
	#And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	#And I Verify Assets Links For Deposit Were Correctly Saved On DB
	Examples:
	| Pay To                                                    | Net Deposit | Gross Deposit | Asset # 1 | Asset Name 1         | Asset Code 1 | Asset Amount 1 | Asset # 2 | Asset Name 2                                       | Asset Code 2 | Asset Amount 2 |
	| Test Automation Saving With Assets Links Entered In Order | $300.00     | $300.00       | 1         | Adv. Proc. #07-00402 |              | $200.00        | 8         | BUSINESS CHECKING ACCOUNT (NEWWAVE SOLUTIONS, LLC) | 1121         | $100.00        |

#Save for closing costs and assets links
@CaseDetail @BankingTransactions
@TransactionSaving
@DepositsClosingCosts @DepositsAssets
@US123038 @US110761 @TC?
Scenario Outline: 015 - Case Detail - Banking - Deposits - Save With Assets And Closing Costs Links
	Given I enter to 341 Meeting page as superuser
	#Go to case with CaseId=1029
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Banking Detail
	And I Click on Deposit Button
	And I Enter Deposit Received From Value '<Pay To>'
	And I Enter Net Deposit Amount '<Net Deposit>'
	And I Enter Gross Deposit Amount '<Gross Deposit>'	
	And I Click On ADD Asset Link	
	And I Search And Select Asset To Link On Row '1' By Asset Number '<Asset # 1>' And Asset Name '<Asset Name 1>' And Asset Code '<Asset Code 1>'
	And I Enter Asset Linked Amount '<Asset Amount 1>' On Row '1'
	#put today date so we verify it changes everytime
	And I Enter Asset Fully Administered Date '10/27/2016' On Row '1' 
	And I Click On ADD Asset Link
	And I Search And Select Asset To Link On Row '2' By Asset Number '<Asset # 2>' And Asset Name '<Asset Name 2>' And Asset Code '<Asset Code 2>'
	And I Enter Asset Linked Amount '<Asset Amount 2>' On Row '2'
	And I Click On ADD Non Claim Payee Link
	And I Enter Non Claim Payee Name 'Non Claim Payee Save Test' Code '7100' And Amount '<Non Claim Amount>' On Row '1'
	And I Enter Non Claim Payee Link Allocation Description 'NonClaim Payee Description' On Row '1'
	And I Enter Non Claim Payee Link Non-Compensable 'True' On Row '1'
	And I Click On ADD Claim Link
	And I Search And Select Claim To Link On Row '2' By Claim Number '<Claim #>' And Claim Name '<Claim Name>' And Claim Code '<Claim Code>'
	And I Enter Claim Link Amount '<Claim Amount>' On Row '2'
	When I Click On Save Deposit For Save With Links
	Then I See The Transaction Displays Data Correctly On Transactions List '<Pay To>','SPLIT','<Net Deposit>','<Asset # 2>','<Asset Name 2>','<Asset Amount 2>','<Asset # 1>','<Asset Name 1>','<Asset Amount 1>'
	#And I Verify Transaction Basic Data Was Correctly Saved On DB As Pay To '<Pay To>' Code 'SPLIT' And Amount '<Net Deposit>'
	#And I Verify Assets Links For Deposit Were Correctly Saved On DB
	#And I Verify Claim Links For Deposit Were Correctly Saved on DB
	#And I Verify Non Claim Payee Link For Deposit Were Correctly Saved On DB
	Examples:
	| Pay To                                   | Net Deposit | Gross Deposit | Asset # 1 | Asset Name 1                                       | Asset Code 1 | Asset Amount 1 | Asset # 2 | Asset Name 2         | Asset Code 2 | Asset Amount 2 | Claim # | Claim Name       | Claim Code | Claim Amount | Non Claim Amount |
	| Test Automation Saving With Assets Links | $950.00     | $1200.00      | 8         | BUSINESS CHECKING ACCOUNT (NEWWAVE SOLUTIONS, LLC) | 1121         | $1,000.00      | 1         | Adv. Proc. #07-00402 |              | $200.00        | 2       | AMERICAN GENERAL | 4110       | $100.00      | $150.00          |