#@Ignore @DoNotExecute
Feature: Case Detail - Banking - Check and Deposits Tabbing and Money Fields
	In order to create new banking transactions
	As a user of Unity
	I need to be able to add checks and deposits for each bank account

#### Tabbing
## Tabbing - Add Check
#@CaseDetail 
#@BankingTransactions
#@AddChecks @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Bug
##BUG: After "Cancel" button, tabbing does not move focus to "Name" - going to OPEN DATE instead
#Scenario: BUG_007 - Case Detail -  Banking - Add Check - Tab Clockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	And I Click on Check Button
#	When I Press Tab Key
#	Then I See Cursor Position Is 'Name' Field
#	And I Press Tab Key
#	And I See Cursor Position Is 'Amount' Field
#	And I Press Tab Key
#	And I See Cursor Position Is 'Description' Field		
#	And I Press Tab Key
#	And I See Cursor Position Is 'Cleared' Field
#	And I Press Tab Key
#	And I See Cursor Position Is 'Code' Field
#	And I Press Tab Key
#	#TODO  Add step to verify focus on + UTC Split link
#	And I Press Tab Key
#	#TODO  Add step to verify focus on + Claim link
#	And I Press Tab Key			
#	And I See Cursor Position Is 'Save And Add Another' Button
#	And I Press Tab Key
#	And I See Cursor Position Is 'Save' Button
#	And I Press Tab Key
#	And I See Cursor Position Is 'Cancel' Button
#	And I Press Tab Key
#	And I See Cursor Position Is 'Name' Field
#
#@CaseDetail 
#@BankingTransactions
#@AddChecks @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Bug
##BUG: first shift tab does not move focus to "Cancel" button - goes to CLaim Tab instead
#Scenario: BUG_008 - Case Detail -  Banking - Add Check - Tab Counterclockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	When I Click on Check Button	
#	When I Press Shift Tab Keys
#	Then I See Cursor Position Is 'Cancel' Button
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Save' Button
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Save And Add Another' Button	
#	And I Press Shift Tab Keys
#	#TODO  Add step to verify focus on + Claim link
#	And I Press Shift Tab Keys
#	#TODO  Add step to verify focus on + UTC Split link
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Code' Field
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Cleared' Field
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Description' Field
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Name' Field
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Amount' Field
#
## Tabbing - Add Deposit
#@CaseDetail 
#@BankingTransactions 
#@AddDeposits @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Bug
##BUG: After Cancel button, tabbing does not move focus to Name field.
##Also, is this a bug? Claim links not visited on tabbing - goes directly from Asset links to "Save and add another" button
#Scenario: BUG_009 - Case Detail -  Banking - Add Deposit - Tab Clockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	When I Click on Deposit Button	
#	Then I See Cursor Position Is 'Name' Field
#	And I Press Tab Key
#	And I See Cursor Position Is 'Amount' Field
#	And I Press Tab Key
#	And I See Cursor Position Is 'Description' Field	
#	And I Press Tab Key
#	#TODO Add step to verify focus on GROSS DEPOSIT
#	And I Press Tab Key
#	And I See Cursor Position Is 'Cleared' Field
#	And I Press Tab Key
#	And I See Cursor Position Is 'Code' Field
#	And I Press Tab Key
#	#TODO  Add step to verify focus on + UTC Split link
#	#And I Press Tab Key
#	#TODO  Add step to verify focus on + Claim link
#	And I Press Tab Key	
#	And I See Cursor Position Is 'Save And Add Another' Button	
#	And I Press Tab Key
#	And I See Cursor Position Is 'Save' Button
#	And I Press Tab Key
#	And I See Cursor Position Is 'Cancel' Button
#	And I Press Tab Key
#	And I See Cursor Position Is 'Name' Field
#
#@CaseDetail 
#@BankingTransactions
#@AddDeposits @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Bug
##BUG: first shift tab does not move focus to "Cancel" button - goes to CLaim Tab instead
#Scenario: BUG_010 - Case Detail -  Banking - Add Deposit - Tab Counterclockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	When I Click on Deposit Button
#	Then I See Cursor Position Is 'Name' Field
#	And I Press Shift Tab Keys	
#	And I See Cursor Position Is 'Cancel' Button
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Save' Button
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Save And Add Another' Button
#	And I Press Shift Tab Keys
#	#TODO  Add step to verify focus on + Claim link
#	And I Press Shift Tab Keys
#	#TODO  Add step to verify focus on + UTC Split link
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Amount' Field
#	And I Press Shift Tab Keys	
#	And I See Cursor Position Is 'Code' Field
#	And I Press Shift Tab Keys	
#	And I See Cursor Position Is 'Cleared' Field
#	And I Press Shift Tab Keys	
#	And I See Cursor Position Is 'Description' Field
#	And I Press Shift Tab Keys
#	And I See Cursor Position Is 'Name' Field
#
### Value/Money Fields Format
#@CaseDetail 
#@BankingTransactions
#@AddChecks @ValueFieldsFormat
#@Regression @Sanity
#@US112035 @TC?
#Scenario Outline: 011 - Case Detail -  Banking - Add Check - Value_Money Field Format
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	And I Click on Check Button
#	And I See Transaction Amount Field Placeholder is ''
#	When I Click On Transaction Amount Field
#	Then I See Cursor Position Is 'Amount' Field
#	And I Enter Amount Field Value '<Amount>'
#	And I See Transaction Amount Field Value is '<Expected Value>'
#	And I Can Select Two Digits From Amount Value And Delete With DELETE Key Getting '<Expected On Delete>'
#	And I Enter Amount Field Value '<Amount>'
#	And I Can Select Two Digits From Amount Value And Delete With BACKSPACE Key Getting '<Expected On Delete>'
#	And I Enter Amount Field Value '<Amount>'
#	And I Can Select All Digits From Amount Value And Delete With DELETE Key
#	And I Enter Amount Field Value '<Amount>'
#	And I Can Select All Digits From Amount Value And Delete With BACKSPACE Key
#	Examples:
#	| Amount  | Expected Value | Expected On Delete |
#	| 507223  | $ 507,223.00   | $ 7,223.00         |
#	| 5072.23 | $ 5,072.23     | $ 072.23           |
#	| 50.00   | $ 50.00        | $ 0.00             |
#	| 120     | $ 120.00       | $ 0.00             |  
#
#
#@CaseDetail 
#@BankingTransactions
#@AddDeposits @ValueFieldsFormat
#@Regression @Sanity
#@US112035 @TC?
#Scenario Outline: 012 - Case Detail -  Banking - Add Deposit - Value_Money Field Format
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Banking Detail
#	And I Click on Deposit Button
#	And I See Transaction Amount Field Placeholder is ''
#	And I See Transaction Amount Field Value is ''
#	When I Click On Transaction Amount Field
#	Then I See Cursor Position Is 'Amount' Field
#	And I Enter Amount Field Value '<Amount>'
#	And I See Transaction Amount Field Value is '<Expected Value>'
#	And I Can Select Two Digits From Amount Value And Delete With DELETE Key Getting '<Expected On Delete>'
#	And I Enter Amount Field Value '<Amount>'
#	And I Can Select Two Digits From Amount Value And Delete With BACKSPACE Key Getting '<Expected On Delete>'
#	And I Enter Amount Field Value '<Amount>'
#	And I Can Select All Digits From Amount Value And Delete With DELETE Key
#	And I Enter Amount Field Value '<Amount>'
#	And I Can Select All Digits From Amount Value And Delete With BACKSPACE Key
#	Examples:
#	| Amount  | Expected Value | Expected On Delete |
#	| 507223  | $ 507,223.00   | $ 7,223.00         |
#	| 5072.23 | $ 5,072.23     | $ 072.23           |
#	| 50.00   | $ 50.00        | $ 0.00             |
#	| 120     | $ 120.00       | $ 0.00             |