@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: CaseBanking_Deposits - Add Asset Link

@AssetsPage
#@US125192 @US121900
#@US121901 @US124735
#@US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 001_"BalancedDeposit" Verify Deposit is balanced if no Assets are linked
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '10'
#	When Verify Deposit message with text 'Deposit is balanced' is displayed
#	Then Verify SAVE button format when in state 'Balanced'

@AssetsPage
#@US125192 @US121900
#@US121901 @US124735
#@US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 002_"OutOfBalanceDeposit" Verify Not equal to Sum of Allocation message if 1 Asset is linked
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '10'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Enter Linked Amount value '200' for Asset Number '8'
#	When Verify Deposit message with text 'Gross Deposit Does Not Equal Sum of Allocation(s)' is displayed
#	Then Verify SAVE button format when in state 'Out Of Balance'

@AssetsPage
#@US125192 @US121900 @US121901 @US124735 @US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 003_"OutOfBalanceDeposit" Verify Not equal to Sum of Allocation message if several Assets are linked
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '10'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Enter Linked Amount value '5' for Asset Number '8'
#	And Click on Add Additional Asset Link button
#	And Search and Select Asset Link with value '9999' in column 'Asset Number'
#	And Enter Linked Amount value '1' for Asset Number '9999'
#	When Verify Deposit message with text 'Gross Deposit Does Not Equal Sum of Allocation(s)' is displayed
#	Then Verify SAVE button format when in state 'Out Of Balance'

@AssetsPage
#@US125192 @US121900 @US121901 @US124735 @US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 004_"OutOfBalanceDeposit" Verify Gross message if 1 Asset Link remains after removing several Assets Linked
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '10'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Enter Linked Amount value '5' for Asset Number '8'
#	And Click on Add Additional Asset Link button
#	And Search and Select Asset Link with value '9999' in column 'Asset Number'
#	And Enter Linked Amount value '1' for Asset Number '9999'
#	And Remove Asset Link with Asset Number '9999'
#	When Verify Deposit message with text 'Gross Deposit Does Not Equal Sum of Allocation(s)' is displayed
#	Then Verify SAVE button format when in state 'Out Of Balance'

@AssetsPage
#@US125192 @US121900 @US121901 @US12190
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 005_"BalancedDeposit" Verify Deposit Balanced message if all Asset Link are reomoved
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '10'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Enter Linked Amount value '5' for Asset Number '8'
#	And Click on Add Additional Asset Link button
#	And Search and Select Asset Link with value '9999' in column 'Asset Number'
#	And Enter Linked Amount value '1' for Asset Number '9999'
#	And Remove Asset Link with Asset Number '8'
#	Then Remove Asset Link with Asset Number '9999'
#	When Verify Deposit message with text 'Deposit is balanced' is displayed
#	Then Verify SAVE button format when in state 'Balanced'

@AssetsPage
#@US125192 @US121900 @US121901 @US124735 @US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 006_"BalancedDeposit" Verify Deposit Balanced message if Assets Linked equal Sum of Allocation
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '10'
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Enter Linked Amount value '5' for Asset Number '8'
#	And Click on Add Additional Asset Link button
#	And Search and Select Asset Link with value '9999' in column 'Asset Number'
#	And Enter Linked Amount value '5' for Asset Number '9999'
#	When Verify Deposit message with text 'Deposit is balanced' is displayed
#	Then Verify SAVE button format when in state 'Balanced'

@AssetsPage
#@US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 007_"OutOfBalanceDeposit" Verify Gross message appears if Gross Deposit not equal to Net Deposit
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Net Deposit value '100'
#	And Enter Gross Deposit value '50'
#	And Verify Deposit message with text 'Gross Deposit Less Closing Costs Does Not Equal Net Deposit' is displayed
#	And Verify SAVE button format when in state 'Disabled'
#	When Enter Gross Deposit value '100'
#	Then Verify SAVE button format when in state 'Balanced'
	
@AssetsPage @deleteDepositForCase1960
#@US125192 @US121901 @US121900
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 008_"SavingOutOfBalanceDeposit" Verify Deposit can be saved when is Out of Balance
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	And Enter Deposit Received From value 'My New Deposit'
#	And Select day '' in CLEARED datepicker for new Deposit
#	And Enter Net Deposit value '10'
#	And Select Code by text 'Liquidation of Real Property (Schedule A)' using 'Click' for Transaction
#	And I save Deposit Received From value
#	And I save New Deposit Number value
#	And Click on Add Asset Link button
#	And Search and Select Asset Link with value '8' in column 'Asset Number'
#	And Enter Linked Amount value '5' for Asset Number '8'
#	And Search and Select Code with text '1110' for Asset Link with Asset number '8'
#	And Click on Add Additional Asset Link button
#	And Search and Select Asset Link with value '3' in column 'Asset Number'
#	And Enter Linked Amount value '2' for Asset Number '3'
#	And Search and Select Code with text '1110' for Asset Link with Asset number '3'
#	And Verify Deposit message with text 'Gross Deposit Does Not Equal Sum of Allocation(s)' is displayed
#	And Verify SAVE button format when in state 'Out Of Balance'
#	When Click on Save Transaction button
#	Then Verify New Deposit is displayed on Ledger
#	And I save Transaction ID for Transaction Type 'Deposit' with Number ''
#	And Verify Assets Link information is displayed on Ledger
	
@AssetsPage
#@US121340
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#Scenario: 009_"GrossDepositField" Verify Gross Deposit field behavior when entering Net Deposit value
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
#	And I Go to Banking Detail
#	And Click to open Transaction with name 'Deposit'
#	When Enter Net Deposit value '100'
#	Then Verify Gross Deposit field value is equal to entered Net Deposit

@AssetsPage
@US121340
@DoNotExecute @RegressionFixesNeeded @Ignore 
Scenario: 010_"GrossDepositField" Verify Gross Deposit field can be edited
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Net Deposit value '100'
	When Enter Gross Deposit value '50'
	Then Verify Gross Deposit field value is not equal to entered Net Deposit

@AssetsPage
@US121340
Scenario: 011_"GrossDepositField" Verify Gross Deposit field can be filled before Net Deposit field
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	When Enter Gross Deposit value '50'
	Then Verify Gross Deposit field value is not equal to entered Net Deposit

@AssetsPage
@US121340
Scenario: 012_"GrossDepositField" Verify Gross Deposit field is not updated
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '50'
	And Enter Net Deposit value '100'
	Then Verify Gross Deposit field value is not equal to entered Net Deposit

@AssetsPage
@US121340
Scenario: 013_"GrossDepositField" Verify Gross Deposit field is not updated
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '0'
	When Enter Net Deposit value '100'
	#Then Verify Gross Deposit field value is equal to entered Net Deposit

@AssetsPage
@US121341
Scenario: 014_"SumOfAllocation" Verify Sum Of Allocation label is updated with Linked Amount values
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '50' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '9' in column 'Asset Number'
	And Enter Linked Amount value '50' for Asset Number '9'
	And Verify SUM OF ALLOCATION displays correct value '$100.00'
	And Remove Asset Link with Asset Number '8'
	When Remove Asset Link with Asset Number '9'
	Then Verify SUM OF ALLOCATION displays correct value '$0.00'

@AssetsPage
@US126982
Scenario: 015_"LinkedAmountGrossDeposit" Verify first asset link Linked amount is equal to Gross Deposit
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '500'
	And Click on Add Asset Link button
	When Search and Select Asset Link with value '8' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '$ 500.00' for Asset Number '8'

@AssetsPage
@US126982
Scenario: 016_"LinkedAmountGrossDeposit" Verify linked amount is not updated if Gross Deposit is updated
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	When Enter Gross Deposit value '250'
	Then Verify Linked Amount value displayed is '$ 500.00' for Asset Number '8'

@AssetsPage
@US126982
@RegressionFixesIt34
Scenario: 017_"LinkedAmountGrossDeposit" Verify if 2 asset link linked amount is Gross Deposit less linked amounts 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '250' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '$ 250.00' for Asset Number '1'

@AssetsPage
@US126982
Scenario: 018_"LinkedAmountGrossDeposit" Verify if equation is negative then next asset link linked amount is 0 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '600' for Asset Number '8'
	And Click on Add Additional Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '$ 0.00' for Asset Number '1'

@AssetsPage
@US126982
Scenario: 019_"LinkedAmountGrossDeposit" Verify first asset link behavior when removing and adding it or different Gross Deposit
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I Go to Banking Detail
	And Click to open Transaction with name 'Deposit'
	And Enter Gross Deposit value '500'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Verify Linked Amount value displayed is '$ 500.00' for Asset Number '8'
	And Remove Asset Link with Asset Number '8'
	And Enter Gross Deposit value '1200'
	And Click on Add Asset Link button
	And Search and Select Asset Link with value '1' in column 'Asset Number'
	Then Verify Linked Amount value displayed is '$ 1,200.00' for Asset Number '1'

