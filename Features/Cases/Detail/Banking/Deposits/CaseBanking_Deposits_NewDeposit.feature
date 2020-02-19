@Regression
@Ignore @DoNotExecute
@BankingTransactions
Feature: CaseBanking_Deposits_NewDeposit

@AssetsPage
@US127983
Scenario: 003_"NewDeposit_SubCodes" Code - Subcode Not enabled for no selection
	#Given I go to Unity login page
	#And I login Unity site with username conversion, password conversion and office crose
	Given I enter to 341 Meeting page as superuser
	#And Search and select Case by text JOHN WAYNE MYERS
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And Click on Banking tab
	And Click on Deposit button
	Then Verify Deposit input field with Name 'Sub Code' has state 'Disabled'

@AssetsPage
@US127983
Scenario: 005_"NewDeposit_SubCodes" Verify Code and Sub Code fields hide when adding Asset Link
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	And Click on More transactions button 'No'
	And Click to open Transaction with name 'Deposit'
	And Select Code by text '1290' using 'Click' for Transaction
	And Select Sub Code by text '01' using 'Click' for Transaction
	And Click on Add Asset Link button
	And Verify Transaction field with Name 'Code' is not visible
	And Verify Transaction field with Name 'Sub Code' is not visible
	And Search and Select Asset Link with value '8' in column 'Asset Number'
	And Enter Linked Amount value '150' for Asset Number '8'
	When Remove Asset Link with Asset Number '8'
	Then Verify Transaction field with Name 'Code' is visible
	And Verify Transaction field with Name 'Sub Code' is visible

@AssetsPage
@US127978
Scenario: 006_"NewDeposit_SerialN" Verify New Deposit Serial Number is not Editable
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	When Click on Deposit button
	Then Verify Serial Number for transaction with name 'Deposit' is not editable

@AssetsPage
@US127978
Scenario: 007_"NewCheck_SerialN" Verify New Check Serial Number is not Editable
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JOHN WAYNE MYERS'
	And I Go to Banking Detail
	When Click on Check button
	Then Verify Serial Number for transaction with name 'Check' is not editable