@Regression	
@ReactJS
	

Feature: AccountsGearDetails

@US274000
Scenario: 001_AccountsPage-Verify Account Details
	Given I enter to Bank Accounts page as superuser
	And I select the Account with Case Number 'SU-99999'
	And I see CaseNumber 'SU-99999' and Debtor Name '9, Subbu Test'
	When I click on Account Edit Icon 
	Then 'Account ManagementEdit Bank Account' Breadcrumb should display
	And I click on BreadCrumb 'Account Management'
	And I SignOut from the Unity Application

Scenario: 002_AccountsPage-Verify the Account Gear Details which cannot be editable
	Given I enter to Bank Accounts page as superuser
	And I select the Account with Case Number 'SU-99999'
		When I click on Account Edit Icon
	Then I see the fields CASE 'SU-99999 / 9, Subbu Test' , BANK NAME 'Bank of America' 
	And  ACCOUNT NUMBER '3339999999' , BANK TOTAL '$0.00' and LEDGER TOTAL'$136,850.00'
		And I see Text '' with Red Triangle When BANK TOTAL '$0.00' and LEDGER TOTAL'$136,850.00' are not equal
		And I select STATUS as 'Closed'
	And a message displayed as 'Cannot close bank account, Ledger Balance does not equal $0.00 or some transactions are missing a Cleared Date'
	And I SignOut from the Unity Application

# covered in Scenario2
#Scenario: 003_AccountsPage-Verify Unbalanced state when Bank Total and LedgerTotal are not equal
#	Given I enter to Bank Accounts page as superuser
#		And I select the Account with Case Number 'SU-99999'
#		When I click on Account Edit Icon
#	Then I see the fields CASE 'SU-99999 / 9, Subbu Test' , BANK NAME 'Bank of America'
#	And  ACCOUNT NUMBER '3339999999' , BANK TOTAL '$0.00' and LEDGER TOTAL'$99,100.00'
#	And I see Text '' with Red Triangle When BANK TOTAL '$0.00' and LEDGER TOTAL'$99,100.00' are not equal
#		And I select STATUS as 'Closed'
#	And a message displayed as 'Cannot close bank account, Ledger Balance does not equal $0.00 or some transactions are missing a Cleared Date'
#	And I SignOut from the Unity Application

#Covered in scenario 3
#Scenario: 004_AccountsPage- Select status as Closed When LedgerTotal is not Zero
#	Given I enter to Bank Accounts page as superuser
#	And I select the Account with Case Number '15-16186'
#		When I click on Account Edit Icon 
#	Then I see the fields CASE '15-16186 / Ellis, Thomas Edward' , BANK NAME 'EagleBank' 
#	And  ACCOUNT NUMBER '9000074143' , BANK TOTAL '$328.54' and LEDGER TOTAL'-$13.46'
#	And I select STATUS as 'Closed'
#	And a message displayed as 'Cannot close bank account, Ledger Balance does not equal $0.00 or some transactions are missing a Cleared Date'
#	And I SignOut from the Unity Application

Scenario: 003_AccountsPage- verify CheckBoxes of Checks and Deposits
	Given I enter to Bank Accounts page as superuser
	And I select the Account with Case Number 'SU-99999'
		When I click on Account Edit Icon 
	And I select CheckBox of 'Default for Checks'
	And I select  Deposit CheckBox of 'Default for Deposits'
	And I select the CheckBox 'No Bond Flag' 
	Then I click on Cancel
	Then I SignOut from the Unity Application

Scenario:004_AccountsPage- verify the input fields
	Given I enter to Bank Accounts page as superuser
	And I select the Account with Case Number 'SU-99999'
		When I click on Account Edit Icon 
	And I input the fields TAX ID '12-1321240'
	And I click on Save
	Then I SignOut from the Unity Application

#Scenario:007_AccountsPage- verify TaxID when selecting and De-Selecting Request From Bank CheckBox
#	Given I enter to Bank Accounts page as superuser
#	And I select the Account with Case Number '15-16186'
#		When I click on Account Edit Icon 
#	And I select 'Request From Bank' CheckBox
#	Then I see the TaxId is no more editable
#	When I De-select 'Request From Bank' CheckBox
#	And I input the TAX ID '12-1321240'	
#	And I click on Save
#	Then I SignOut from the Unity Application

Scenario:005_AccountsPage- Editing the Account Name and verifying Account Name
	Given I enter to Bank Accounts page as superuser
	And I select the Account with Case Number 'SU-99999'
		When I click on Account Edit Icon 
	And I Enter Account Name 'Checking QA Testing'
	And I click on Save
	And I verify the Account Name as 'Checking QA Testing' on Account Management Page
	Then I SignOut from the Unity Application

@US259312
Scenario:006_AccountsPage - View Deposit 
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	And I select the Account with Case Number 'SU-99999'
	Then Verify for View icon symbol '15'
	When I Select view icon '15'
	Then 'Account ManagementView Deposit' Breadcrumb should display
	Then I verify Field Values 'CASE # / DEBTOR NAME-SU-99999 /9, Subbu Test;BANK-Bank of America;ACCOUNT NUMBER-XXXXXXXXXX;SERIAL NUMBER-2000;TRANSACTION DATE-03/31/18;CLEAR DATE-'
	And I verify Field Values 'RECEIVED FROM-Subbu and Others;DESCRIPTION-1 Subbu Deposit QA;NET DEPOSIT-$100,000.00;GROSS DEPOSIT-$100,000.00;SUM OF ALLOCATIONS-$100,000.00;CLAIMS/COST-$0.00'
	#And I verify Field Values 'ASSET #-11;DESCRIPTION-Anticipated 2014 Income Tax Refunds;UTC-1129;LINKED AMOUNT-$2,000.00;REMAINING AMOUNT-$2,000.00'
	And I verify 'CLOSE' button
	And I click 'CLOSE' button
	And 'Bank AccountsAccount Management' Breadcrumb should display
	And I SignOut from the Unity Application

@US259312
Scenario:007_AccountsPage - Verify No View to Account Number
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	Then I should not be able to see Full Account Number
	And I SignOut from the Unity Application

@US259312
@US235539
Scenario:008_AccountsPage - Verify Parital View to Account Number
	Given I enter to Bank Accounts page as user PartialAccView with password Welcome123Epiq! and office crose
	Then I should be able to see Partial Account Number 'XXXXXX9999' for case 'SU-99999'
	And I SignOut from the Unity Application

@US259312
Scenario:009_AccountsPage - Verify Full View of Account Number
	Given I enter to Bank Accounts page as superuser
	Then I should be able to see Full Account Number '3339999999' for case 'SU-99999'
	And I SignOut from the Unity Application
 