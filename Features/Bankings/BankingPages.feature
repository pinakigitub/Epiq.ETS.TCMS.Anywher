@Regression	
@ReactJS	
Feature: BankingManagementPage
 Navigating to the different sections 
		under Banking  page

#Banking Activity Scenarios

@CasesTab
Scenario: 001 - Cases- Banking Activity page verification
	Given I enter to Banking Activity page as superuser
	Then 'Banking Center' header should be displayed on Banking Activity Page
	Then 'DashboardBanking Activity' Breadcrumb should display
	When User click on Filter on Banking Activity page
	Then Banking Activity 'FILTER OPTIONS' should be displayed
	When User click on close on Banking Activity page
	Then I SignOut from the Unity Application

##Bug is present
#Scenario: 002 - Cases- Banking Activity Breadcrumb and sorting verification
#	Given I enter to Banking Activity page as superuser
#	Then 'DashboardBanking Activity' Breadcrumb should display
#   And 'Case #' Should be able to sort on Banking Activity page
#   And 'DEBTOR' Should be able to sort on Banking Activity page
#   And 'ISSUE' Should be able to sort on Banking Activity page
#   And I SignOut from the Unity Application


Scenario: 002 - Cases- Banking Activity Filter Options Validation
	Given I enter to Banking Activity page as superuser
   When User click on Filter on Banking Activity page
   And Enter Account Number '99' in Banking Activity filter option
   Then Banking Activity records should be displayed
   And User click on the reset button on Banking Activity filter option
   And user click on close button on Banking Activity option
   And I SignOut from the Unity Application


 Scenario: 003 - Cases- Banking Activity Page Pagination
	Given I enter to Banking Activity page as superuser
	When User displays the page count on Banking Activity page
	Then the selected page records should be  in Banking Activity page
    And I SignOut from the Unity Application

Scenario: 004 - Cases-Mousehover on Debtor column- BANKING ACTIVITY
	Given I enter to Banking Activity page as superuser
	Then perform mouse over on debotor column
	 And I SignOut from the Unity Application

Scenario: 005 - Banking Activity - Balances Listed on Account Activity Validation
	Given I enter to Banking Activity page as superuser
   When User click on Filter on Banking Activity page
   And Enter Account Number '9000074121' in Banking Activity filter option
  #And I Select  Issue 'Unlinked Activity' in Banking Activity filter option
   And I click on Close on Banking Activity Filter
   Then Banking Activity records should be displayed
   When I Click on 'Unlinked Activity' link in 'ISSUE'
     When User click on Filter on Issue Reconcilation page
	    Then user click on close button on Banking Activity option
   Then 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should  defalut sorted to 'Unlinked;Unlinked'
		And BANK TRANSACTION Value should be displayed
		And LEDGER TRANSACTION Value should be displayed
   And I SignOut from the Unity Application

@US266863@266862
Scenario: 006 - Banking Activity - Ignore - Marking a Bank File Transaction Validation-filter options
	Given I enter to Banking Activity page as superuser
   When User click on Filter on Banking Activity page
   And Enter Account Number '9000024036' in Banking Activity filter option
   And I click on Close on Banking Activity Filter
   Then Banking Activity records should be displayed
   When I Click on 'Unlinked Deposit Correcting Check' link in 'ISSUE'
   When User click on Filter on Issue Reconcilation page
   Then user click on close button on Banking Activity option
   #Then 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should  defalut sorted to 'Unlinked;Unlinked'
   Then 'BANK TRANSACTIONS' should have 'Clear Date;Serial #;Amount;Ignore' columns
     When User click on Filter on Issue Reconcilation page
   When I Filter Transaction with Ignored
		Then Records should filtered with Ignored
   Then Record Ignore Button should be green
   When I Filter Transaction with Unlinked
   Then Records should filtered with Unlinked
   Then user click on close button on Banking Activity option
        Then I SignOut from the Unity Application


Scenario: 007 - Banking Activity - Selected Item displaying on Footer and removing from Red X button Validation
	Given I enter to Banking Activity page as superuser
    When User click on Filter on Banking Activity page
   And Enter Account Number '9000024036' in Banking Activity filter option
   #And I Select  Issue 'Unlinked Activity' in Banking Activity filter option
   And I click on Close on Banking Activity Filter
     Then Banking Activity records should be displayed
   When I Click on 'Unlinked Deposit Correcting Check' link in 'ISSUE'
     #Then 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should  defalut sorted to 'Unlinked;Unlinked'
     #And 'BANK TRANSACTIONS' should have 'Clear Date;Serial #;Amount;Ignore' columns
   When I click on Radio Button of Bank Transaction
	 Then Bank Record should display on footer
   When I click on Radio Button of Ledger Transaction
	 Then Ledger Record should display on footer
   When I click on Close Button of Bank Transaction on Footer
   And I click on Close Button of Ledger Transaction on Footer
	 Then Bank Record should not display on footer   
	 And Ledger Record should not display on footer
     Then I SignOut from the Unity Application
  
Scenario: 008 - Banking Activity - Un-reconciled Bank Activity filter
	Given I enter to Bank Accounts page as superuser
	And I Go to Dashboard page
	 When I Click on Unreconciled Bank Activity Link
	 And User click on Filter buton on Banking Activity page
	   Then Banking Activity 'FILTER OPTIONS' should be displayed
	 When Enter Account Number '9000074121' in Banking Activity filter option
	 And I click on Close on Banking Activity Filter
       Then Banking Activity records should be displayed
	 Then I SignOut from the Unity Application

#Banking Accounts Scenarios
Scenario: 009 - Cases- Banking Accounts page verification
	Given I enter to Bank Accounts page as superuser
	Then 'Banking Center' header should be displayed on Banking Accounts Page
	Then 'DashboardBank Accounts' Breadcrumb should display
	When User click on Filter on Banking Accounts page
	Then Banking Activity 'FILTER OPTIONS' should be displayed
	When User click on close on Banking Activity page
	Then I SignOut from the Unity Application

# has the bug for the same
#Scenario: 011 - Cases- Banking Accounts Breadcrumb and sorting verification
#	Given I enter to Bank Accounts page as superuser
#	Then 'DashboardBank Accounts' Breadcrumb should display
#   And 'Case #' Should be able to sort on Banking Activity page
#   And 'DEBTOR' Should be able to sort on Banking Activity page
#   And 'ACCOUNT #' Should be able to sort on Banking Activity page
#   And I SignOut from the Unity Application

# see secanrio 52
#Scenario: 012 - Cases- Banking Accounts Filter Options Validation
#	Given I enter to Bank Accounts page as superuser
#   When User click on Filter on Banking Accounts page
#   And Enter Account Number '99' in Banking Activity filter option
#   Then Banking Activity records should be displayed
#   And User click on the reset button on Banking Activity filter option
#   And user click on close button on Banking Activity option
#   And I SignOut from the Unity Application

 Scenario: 010 - Cases- Banking Accounts Page Pagination
	Given I enter to Bank Accounts page as superuser
	When User displays the page count on Banking Accounts page
	Then the selected page records should be  in Banking Activity page
    And I SignOut from the Unity Application

Scenario: 011 - Cases-Mousehover on Debtor column- BANKING ACCOUNTS
	Given I enter to Bank Accounts page as superuser
	Then perform mouse over on debotor column On bankings
	 And I SignOut from the Unity Application


Scenario: 012 - Cases-Mousehover on Debtor column- BANKING receipts
	Given I enter to Banking ReceiptLog page as superuser
	Then perform mouse over on debotor column On receiptlog
	 And I SignOut from the Unity Application

Scenario: 013 - Cases-Mousehover on Debtor column- checks
	Given I enter to Banking ChecksOrDeposits page as superuser
	Then perform mouse over on debotor column On checks
	 And I SignOut from the Unity Application


Scenario: 014 - Cases- Banking ReceiptLog page verification
	Given I enter to Banking ReceiptLog page as superuser
	Then 'Banking Center' header should be displayed on Banking ReceiptLog Page
	Then 'DashboardReceipt Log' Breadcrumb should display
	When User click on Filter on Banking ReceiptLog page
	Then Banking Activity 'FILTER OPTIONS' should be displayed
	When User click on close on Banking Activity page
	Then I SignOut from the Unity Application

# Has Bug for the sorting
#Scenario: 018 - Cases- Banking ReceiptLog Breadcrumb and sorting verification
#  Given I enter to Banking ReceiptLog page as superuser
#	Then 'DashboardReceipt Log' Breadcrumb should display
#  #And 'DEBTOR NAME' Should be able to sort on Banking Activity page
#  #And 'AMOUNT' Should be able to sort on Banking Activity page
#  And I SignOut from the Unity Application

Scenario: 015 - Cases- Banking ReceiptLog Filter Options Validation
	 Given I enter to Banking ReceiptLog page as superuser
	 When User click on Filter on Banking ReceiptLog page
	 When User select Linked 'Yes' on Banking Receipt filter
	 And I click on close button on Banking Receipt filter
	 Then Banking Receipt Log records should be displayed
	 When User click on Filter on Banking ReceiptLog page
	 And User click on the reset button Banking Receipt filter
	 And I click on close button on Banking Receipt filter
	 Then Banking Receipt Log records should be displayed
	 And I SignOut from the Unity Application

Scenario: 016 - Cases- Banking ReceiptLog Page Pagination
   Given I enter to Banking ReceiptLog page as superuser
	When User displays the page count on Banking ReceiptLog page
	Then the selected page records should be  in Banking Activity page
    And I SignOut from the Unity Application

Scenario: 017 - Cases- Banking PrintsOrDeposit page verification
	Given I enter to Banking ChecksOrDeposits page as superuser
	Then 'Banking Center' header should be displayed on Banking ChecksOrDeposits Page
	 Then 'DashboardPrint Checks/Deposits' Breadcrumb should display
	When User click on Filter on Banking ChecksOrDeposits page
	Then Banking Activity 'FILTER OPTIONS' should be displayed
	When User click on close on Banking Activity page
	Then I SignOut from the Unity Application

#Has bug for the sorting
#Scenario: 022 - Cases- Banking ChecksOrDeposits Breadcrumb and sorting verification
#  Given I enter to Banking ChecksOrDeposits page as superuser
#  Then 'DashboardPrint Checks/Deposits' Breadcrumb should display
#  #And 'DEBTOR NAME' Should be able to sort on Banking Activity page
#  #And 'PAYEE NAME' Should be able to sort on Banking Activity pag
#  And I SignOut from the Unity Application

#Not required as we have covered many scenario with same functionality
#Scenario: 023 - Cases- Banking ChecksOrDeposits Filter Options Validation
#	 Given I enter to Banking ChecksOrDeposits page as superuser
#	 When User click on Filter on Banking ChecksOrDeposits page
#	 #And Enter Case Number '99-18189' in Banking Activity filter option
#	 # And Enter Secondary Type 'Check' in banking printing filter option
#	 Then Banking Activity records should be displayed
#	 And User click on the reset button on Banking Activity filter option
#	 And user click on close button on Banking Activity option
#	 And I SignOut from the Unity Application

Scenario: 018 - Cases- Banking ChecksOrDeposits Page Pagination
   Given I enter to Banking ChecksOrDeposits page as superuser
	When User displays the page count on Banking ChecksOrDeposits page
	Then the selected page records should be  in Banking Activity page
    And I SignOut from the Unity Application

#Scenario: 017 - Cases- Banking Activity Filter Options Validation with ACCOUNT NUMBER
#   Given I enter to Dashboard page as superuser
#	And I Go to Banking Activity page
#   When User click on Filter on Banking Activity page
#   And Enter Account Number '9996666666' in Banking Activity filter option
#   Then Banking Activity records should be displayed
#   And User click on the reset button on Banking Activity filter option
#   And user click on close button on Banking Activity option
#   And I SignOut from the Unity Application


#Scenario: 025 - Cases- Banking Activity Filter Options Validation with ISSUE
  # Given I enter to Dashboard page as superuser
	##And I Go to Banking Activity page
 #  When User click on Filter on Banking Activity page
 #  And I Select  Issue 'Deposit' in Banking Activity filter option
 #  Then Banking Activity records should be displayed
 #  And User click on the reset button on Banking Activity filter option
 #  And user click on close button on Banking Activity option
 #  And I SignOut from the Unity Application

 @US293936
Scenario: 019 - Cases- Banking Accounts Filter Options Validation with Bank Balance
   Given I enter to Bank Accounts page as superuser
	When User click on Filter on Banking Accounts page
	And I enter Balance from '0.00'
	And I enter Balance to '0.00'
	And I enter Bank Balance other as 'No'
   Then Banking Activity records should be displayed
   And User click on the reset button on Banking Activity filter option
   And user click on close button on Banking Activity option
   And I SignOut from the Unity Application

Scenario: 020- Cases- Printing Button and printing queue message validation
	Given I enter to Banking ChecksOrDeposits page as superuser
	When user select the checkbox from the result gird
	And Clicks on the print button
	Then Validate that print queue message appears
	And Click on the close button button
	And I SignOut from the Unity Application

# bug for Sorting is raised	
#Scenario: 028 - Banking Activity - Issue Reconciliation validation
#	Given I enter to Banking Activity page as superuser
#	And I Go to Dashboard page
#		When I Click on Unreconciled Bank Activity Link
#		Then 'ISSUE' Column should contain 'Unlinked' list
#	When I Click on 'Unlinked' link in 'ISSUE'
#		#Then 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should  defalut sorted to 'Unlinked;Unlinked'
#		Then 'BANK TRANSACTIONS' should have 'Clear Date;Serial #;Amount;Ignore' columns
#		And 'LEDGER TRANSACTIONS' should have 'Date;Serial #;Amount' columns
#		#And Case Name should Followed by veritical line and Bank Account Transaction should linked
#		And I click on BreadCrumb 'Banking Activity'
#		When I Click on 'Unlinked' link in 'ISSUE'
#		Then I SignOut from the Unity Application

@US293901
# This functionality is been removed
#Scenario: 029 - Banking Activity - Activity Rows
#	Given I enter to Banking Activity page as superuser
#		Then 'Banking Center' header should be displayed on Banking Activity Page
#		And Banking Activity records should be displayed	
#	When Get Records by column 'CASE #'
#	And I Click on 'Unlinked' link in 'ISSUE'
#		Then 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should  defalut sorted to 'Unlinked;Unlinked'
#	When I click on Arrow '<'
#		Then Case Should navigate to previous case
#	When I click on Arrow '>'
#		Then Case Should navigate to next case
#		And I SignOut from the Unity Application

#functionality is been removed of  filtering the issue on transaction tables to link/unlink transaction
#Scenario: 030 - Banking Activity - Thirtd panel LINK and UNLINK TRANSACTION verification
#	Given I enter to Banking Activity page as superuser
#	When User click on Filter on Banking Activity page
#	And Enter Account Number '9000024036' in Banking Activity filter option
#	And I Click on 'Unlinked' link in 'ISSUE'
#		Then Records Should not selected by detault
#	When I Link Transaction Serial# 000105
#	And I click on LINK TRANSACTIONS button and verify Toast message
#		Then  Serial# 101 Should false dispaly in Unlinked Transactions
#	When I Filter Transaction with Linked
#		Then Serial# 101 Should true dispaly Linked Transactions
#	When I Unlink Transaction Serial# 101
#	And I click on UNLINK TRANSACTIONS button and verify Toast message
#		Then  Serial# 101 Should true dispaly in Unlinked Transactions
#	When I Filter Transaction with Linked
#		Then Serial# 101 Should false dispaly Linked Transactions
#		And I SignOut from the Unity Application

# already covered
#Scenario: 031 - Banking Activity - Banking Filter DropDown 
#	Given I enter to Banking Activity page as superuser
#	When User click on Filter on Banking Activity page
#	And Enter Account Number '9000024036' in Banking Activity filter option
#	And I Click on 'Unlinked Deposit Correcting Check' link in 'ISSUE'
#		#Then 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should  defalut sorted to 'Unlinked;Unlinked'
#		#And 'BANK TRANSACTIONS;LEDGER TRANSACTIONS' Tables should have filters 'Linked,Ignored;Linked,Manually Posted'
#		 When User click on Filter on Issue Reconcilation page
#	When I Filter Transaction with Linked
#		#Then Records should filtered with Linked
#	 When User click on Filter on Issue Reconcilation page
#	When I Filter Transaction with Ignored
#		#Then Records should filtered with Ignored
#	When I Filter Transaction with Manually Posted
#			#Then Records should filtered with Manually Posted
#	When I Filter Transaction with Unlinked
#		#Then Records should filtered with Unlinked
#		  #Then user click on close button on Banking Activity option
#		Then I SignOut from the Unity Application

@US293944
# not a vlaid sceanrio has we don't have header buttons
#Scenario: 032 - Banking Activity - Balance Loaing in Banking Center
#	Given I enter to Bank Accounts page as superuser
#	Then 'DashboardBank Accounts' Breadcrumb should display
#		And BANK ACCOUNTS button should hilghlight 
#	When Get Records by column 'BALANCE'
#	And I click ACTIVITY Button
#		Then ACTIVITY button should hilghlight 
#	Then 'DashboardBanking Activity' Breadcrumb should display
#		And I SignOut from the Unity Application


Scenario: 021 - Edit Receipt Log- Link Transaction
Given I enter to Banking ReceiptLog page as superuser
	 Then Click on the edit option for records
	 And 'Edit Receipt Log' header should be displayed on Edit Receipt Log
	 And Link Transaction button should be enable on edit receipt log
	 When select and link transaction for a case
	 Then click on the save to link the transaction and also validate the row is present	 
	And I SignOut from the Unity Application

Scenario: 022 - Edit Receipt Log- UnLink Transaction
Given I enter to Banking ReceiptLog page as superuser
	 When User click on Filter on Banking ReceiptLog page
	  And I click on close button on Banking Receipt filter
	 Then Click on the edit option for records
	 Then 'Edit Receipt Log' header should be displayed on Edit Receipt Log
	 And Link Transaction button should be enable on edit receipt log
	 When select and link transaction for a case
	 Then UnLink Transaction button should be enable on edit receipt log
	 And Validate the cancel button is enabled on edit receipt log
	And click on the save to link the transaction and also validate the row is  not present
	And I SignOut from the Unity Application

Scenario: 023 - Verfiy the Receipt log is verified
	Given I enter to Banking ReceiptLog page as superuser
	When User Select the result from grid and click on verified
	Then Verified record appears in green tick mark
	And Mousehover on the verified column
	And I SignOut from the Unity Application

# Adding Scenarios for the View Permission
Scenario: 024 - Validate the Account Management Page
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	When User clicks on the account number
	#Then 'Bank AccountsAccount Management' Breadcrumb should displayed
	Then 'Account Summary - Checking' is displayed as header
	And 'Transactions' is displayed as subheader
	And Check button is not enabled
	And I SignOut from the Unity Application


Scenario: 025 - Validate the Receipt Log View Permission
	Given I enter to Banking ReceiptLog page as user AutomationView with password Welcome456Epiq! and office crose
	When User Select the result from grid
	And try to click on add receipt , void, deposit and verify
	Then I Click the View button from the result grid
	And Header should display as'View Receipt Log'
	And I SignOut from the Unity Application
	
Scenario: 026 - Validate the Print/Deposit View Permission
	Given I enter to Banking ChecksOrDeposits page as user AutomationView with password Welcome456Epiq! and office crose
	Then Validate the No Access message on the page as 'Please contact your Office Administrator and request permission to view this content. You are missing the following permissions: Check Print, Check Reprint, Deposit Slip Print, Deposit Slip Reprint, Transaction Print'
	And I SignOut from the Unity Application

@US206974
Scenario: 027 - Validate the Bank Accounts In Line editing with View Only Access
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	When I click on Account Number link 
	Then I should not be able to edit CLEARED field value	
	And I SignOut from the Unity Application

@US206974
Scenario: 028 - Cases- Banking Accounts - Inline Editing
   Given I enter to Bank Accounts page as superuser
	When I click on Account Number link 
     Then I should be able to edit CLEARED field value with current date
	 Then I should be able to edit CLEARED field value with current date
     And I SignOut from the Unity Application

@US235539@US235302
Scenario: 029 - Case Level- Banking Accounts - Case Level Banking Accounts
   Given I enter to Bank Accounts page as superuser
	When I Select one case from Bank Accounts page
	When I Go to Bank Accounts page
	Then I select one Account from Bank Account list
	Then I see Bank Name and Account Name and Account Number Under Case header details
	Then I See the Account Summary Section
	Then I See the TRansactions Section
	Then I See the Check Button enabled in Transactions Section
    Then I SignOut from the Unity Application

@US235539
# Merged the sceanrio into AccountGearDetails.feature file with Sc#11
#Scenario: 042 -Case Level- Banking Accounts with Partial Account Number View Access
#	Given I enter to Bank Accounts page as user partialview with password PartialView1! and office crose
#	When I Select one case from Bank Accounts page
#	When I Go to Bank Accounts page
#	Then I see partial Account number  
#	And I SignOut from the Unity Application

@US235539
Scenario: 030 - Case Level- Banking Accounts with View Only Access
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	#	When I Select one case from Bank Accounts page
	#When I Go to Bank Accounts page
    Then I see Full Account number is hidden
	And I SignOut from the Unity Application

#covered in the sc#41
#@US235302
#Scenario: 044 - Case Level- Navigate Case from Top Search and validate Bank Accounts Detail
#	Given I enter to Bank Accounts page as superuser
#	And I Go to Dashboard page
#	When I search and select case '15-16186' from Top search
#	When I Go to Bank Accounts page
#	#And I enter to Bank Accounts page as superuser
#	Then I select one Account from Bank Account list
#	Then I see Bank Name and Account Name and Account Number Under Case header details
#	Then I See the Account Summary Section
#	Then I See the TRansactions Section
#	Then I See the Check Button enabled in Transactions Section
#	Then I SignOut from the Unity Application

@US243099
Scenario: 031 - Deposit Outstandings Dashboard Navigation
	Given I enter to Bank Accounts page as superuser
	And I Go to Dashboard page
	When I Click on Quantity displaying for Deposits Outstanding in Bank Summary tile
	#Then I should be on Bank Activity Page
	When I click on Filter on Banking Activity page
	Then I see Unlinked Type value is Deposit 
	Then I see HAS BANK TRANSACTIONS value is All
	Then I see CASE STATUS value is Open
	Then user click on close button on Banking Activity option
	Then I SignOut from the Unity Application

@US266864
Scenario Outline: 032 - Bank Accounts - Check view with Full Account view permission
	Given I enter to Bank Accounts page as user AutomationView1 with password Welcome123Epiq! and office crose
	When I click filter icon
   Then I Filter with Account No '9000074143'
   When I Close Filter pop up I should see data on grid
	When I click on Account# '9000074143'
	When I Select the PageSize as <PageSize> under Pagination Section
	Then I Click the Transaction 'Swetha'
	Then I verify View Check page header
	Then View Check Breadcrumbs should be displayed
	Then I see the fields in Check Details section BANKNAME 'EagleBank' , ACCOUNT '9000074143', SERIAL # '108' , CLEAR DATE '06/20/18'
	Then I see the fields in Pay To Section PAYEE NAME 'Swetha', DESCRIPTION 'DATECHANGE', REMARKS 'CREATION OF CHECK'
	Then I see the fields in Amounts Section AMOUNT '$342.00', SUM OF ALLOCATIONS '$342.00', DISTRIBUTION TYPE 'Interim Payment To Creditor'
	Then I see the fields in Claim Links Section NAME 'CHERYL E. ROSE', LINKED AMOUNT '$0.00', UTC '2200'
	When User click on close on Check View page
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize |
	| 100      |

	
#@US266864
#Scenario: 047 - Bank Accounts - Check view with No Account view permission
#	Given I enter to Bank Accounts page as user AutomationView2 with password Welcome123Epiq! and office crose
#	#When User click on Filter on Banking Accounts page
#	#When I click filter icon
# #  Then I Filter with Account No '9000074143'
# #  When I Close Filter pop up I should see data on grid
#	##When I click on Account# '9000074143'
#	When I click on Accountnumber 'Ellis, Thomas Edward'
#	Then I Click the Transaction 'Swetha'
#	Then I verify View Check page header
#	Then View Check Breadcrumbs should be displayed
#	Then I see the fields in Check Details section BANKNAME 'EagleBank' , ACCOUNT 'XXXXXXXXXX', SERIAL # '108' , CLEAR DATE '06/20/18'
#	Then I see the fields in Pay To Section PAYEE NAME 'Swetha', DESCRIPTION 'DATECHANGE', REMARKS 'CREATION OF CHECK'
#	Then I see the fields in Amounts Section AMOUNT '$342.00', SUM OF ALLOCATIONS '$342.00', DISTRIBUTION TYPE 'Interim Payment To Creditor'
#	Then I see the fields in Claim Links Section NAME 'CHERYL E. ROSE', LINKED AMOUNT '$0.00', UTC '2200'
#	When User click on close on Check View page
#	Then I Click the Transaction 'Swetha'
#	Then I click Account Management in Breadcrumb
#	Then I SignOut from the Unity Application

#@US266864
#Scenario: 048 - Bank Accounts - Check view with Partial Account view permission
#	Given I enter to Bank Accounts page as user Automationview3 with password Welcome1234567! and office crose
#	When User click on Filter on Banking Accounts page
#When I click filter icon
# Then I Filter with Account No 'XXXXXX4143'
#  When I Close Filter pop up I should see data on grid
#	When I click on Account# 'XXXXXX4143'
#	Then I Click the Transaction 'Swetha'
#	Then I verify View Check page header
#	Then View Check Breadcrumbs should be displayed
#	Then I see the fields in Check Details section BANKNAME 'EagleBank' , ACCOUNT 'XXXXXX4143', SERIAL # '108' , CLEAR DATE '06/20/18'
#	Then I see the fields in Pay To Section PAYEE NAME 'Swetha', DESCRIPTION 'DATECHANGE', REMARKS 'CREATION OF CHECK'
#	Then I see the fields in Amounts Section AMOUNT '$342.00', SUM OF ALLOCATIONS '$342.00', DISTRIBUTION TYPE 'Interim Payment To Creditor'
#	Then I see the fields in Claim Links Section NAME 'CHERYL E. ROSE', LINKED AMOUNT '$0.00', UTC '2200'
#	When User click on close on Check View page
#	Then I Click the Transaction 'Swetha'
#	Then I click Account Management in Breadcrumb
#	Then I SignOut from the Unity Application

@US266861
Scenario Outline: 033 - Bank Accounts - Check edit 
	Given I enter to Bank Accounts page as superuser
		#When User click on Filter on Banking Accounts page
When I click filter icon
 Then I Filter with Account No '9000074143'
  When I Close Filter pop up I should see data on grid
	When I click on Account# '9000074143'
	When I Select the PageSize as <PageSize> under Pagination Section
	Then I Click the Transaction 'Swetha'
	Then I verify Write Check page header
	Then Write Check Breadcrumbs should be displayed
	Then I see the fields in Edit Check page as BANKNAME 'EagleBank' , ACCOUNT '9000074143', SERIAL # '108', PAYEE NAME 'Swetha', ADDRESSLINEONE 'Hyderabad', ADDRESSLINETWO 'Hyderabad, AL 588667', AMOUNT '342.00', SUM OF ALLOCATIONS '$342.00'
	Then I edit the fields CLEAR DATE '06/21/18', DESCRIPTION 'DATECHANGE', REMARKS 'CREATION OF CHECK', DISTRIBUTION TYPE 'Interim Payment To Creditor'
	Then I add Claim links
	Then I edit Claim links NAME 'CHERYL E. ROSE', DESCRIPTION 'DESC', UTC '2100 Trustee Compensation', LINKED AMOUNT '0.00'
	Then I delete Claim link
	Then I add Unlinked allocations PAYEE NAME 'Test', UTC '2200 Trustee Expenses', AMOUNT '20.00'
	Then I edit Unlinked allocations NAME 'Test', DESCRIPTION 'DESC', UTC '2200 Trustee Expenses', LINKED AMOUNT '30.00'
	Then I validate SUM OF ALLOCATIONS 
	Then I delete Unlinked allocations
	When User click on Save on Write Check page
		When I Select the PageSize as <PageSize> under Pagination Section
	Then I Click the Transaction 'Swetha'
	Then I click Cancel on Write Check page
	#Then I Click the Transaction 'Swetha'
	#Then I click Account Management in Breadcrumb
	Then I SignOut from the Unity Application
		Examples: 
	| PageSize |
	| 100      |
	
@US266861
Scenario Outline: 034 - Bank Accounts - Check Edit with No Account view permission
	Given I enter to Bank Accounts page as user AutomationView4 with password Welcome1234567! and office crose
	When I click filter icon
 Then I Filter with Account No '9000074143'
    When I Close Filter pop up I should see data on grid
	When I click on Accountnumber 'Ellis, Thomas Edward'
	When I Select the PageSize as <PageSize> under Pagination Section
	Then I Click the Transaction 'Swetha'
	Then I see the fields in Check Details section ACCOUNT 'XXXXXXXXXX'
	Then I click Cancel on Write Check page
	Then I SignOut from the Unity Application
		Examples: 
	| PageSize |
	| 100      |

@US266861
Scenario Outline: 035 - Bank Accounts - Check Edit with No Account view permission
	Given I enter to Bank Accounts page as user AutomationView5 with password Welcome1234567! and office crose
	When I click filter icon
 Then I Filter with Account No '9000074143'
    When I Close Filter pop up I should see data on grid
	When I click on Accountnumber 'Ellis, Thomas Edward'
	When I Select the PageSize as <PageSize> under Pagination Section
	Then I Click the Transaction 'Swetha'
	Then I see the fields in Check Details section ACCOUNT 'XXXXXX4143'
	Then I click Cancel on Write Check page
	Then I SignOut from the Unity Application
		Examples: 
	| PageSize |
	| 100      |

	@US254350
Scenario: 036 - Banking Activity - Unreconciled Activity Page Consolidated Filter Options - Remove Unlinked Receipt Log
	Given I enter to Banking Activity page as superuser
	Then 'Banking Center' header should be displayed on Banking Activity Page
	When User click on Filter on Banking Activity page
	Then I Verify for Receipt Log		
	Then I SignOut from the Unity Application

@US26684@US293930
Scenario: 037 - Void Transaction- Bank Accounts
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
   Then I Filter with Account No '3339999999'
   When I Close Filter pop up I should see data on grid
   When I click on Account# '3339999999'
   When I Click on Create Check Button
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
	Then Input Description 'DATECHANGE' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
	Then I Input amount as '250'
	When I click Link Claim 'LINK CLAIM'
	Then Select any claim and Add
	Then I See Interest Amount field is Displayed
	And I should update the Interest Amount value '250'
	And I should update amount as '500' 
	When I save the Check
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'Yes'
	Then I click on close button in the filter
	When I select the any transaction
	Then I click on dots and select 'VOID / REVERSAL'
	Then Verify the pop header as 'Transaction Selection Errors for Void'
	Then verify the pop up body message as 'Transactions cannot have already cleared the bank or have a stop payment pending or already been reversed. Review list and deselect transactions that do not meet criteria.'
	Then Click on OK Button of the pop up modal
	#Then I clear cleared date field
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'No' 
	Then I click on close button in the filter
	When I select the any transaction
	Then I click on dots and select 'VOID / REVERSAL'
	Then Verify the pop header as 'Void Transactions'
	Then verify the pop up body message as 'Selected transactions will be voided, please confirm and enter a remark you would like applied to all of the selected transactions'
	When I enter the text for Remarks
	Then Click on OK Button of the pop up modal
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'Yes' 
	Then I click on close button in the filter
	Then I click on Edit pencil Icon
	Then 'Account ManagementEdit Check Reversal' Breadcrumb should display
	Then I verify Interest Amount field is non editible field
	When I save the Check
	#When User click on Filter on Banking AccountsSummary page
	#Then I click on reset button
	#Then I click on close button in the filter
	#Then verfiy the red button is appeared next to cleared date column
	Then I SignOut from the Unity Application

@US266876@US266877@US266878@US266875
Scenario: 038 - Void Transaction- Create, Reject and Accept stop payement
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
   Then I Filter with Account No '3339999999'
   When I Close Filter pop up I should see data on grid
	When I click on Account# '3339999999'
	 When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'No'
	Then I click on close button in the filter
	When I select the any transaction
	Then I click on dots and select 'STOP PAYMENT CREATE'
	Then Verify the pop header as 'Confirm Stop Payment Transactions'
	Then verify the pop up body message as 'This action sets the selected transactions to Stop Payment Pending. Do you want to complete this action?'
	Then I click 'OK'
	When User click on Filter on Banking AccountsSummary page
	Then I select Stop Payement as 'Stop Payments Pending'
	Then I click on close button in the filter
	Then verfiy the red button is appeared next to cleared date column
	When I select the any transaction
	Then I click on dots and select 'STOP PAYMENT REJECT'
	Then Verify the pop header as 'Stop Payment Reject Transactions'
	Then verify the pop up body message as 'This step completes the stop payment reject process. Verify that you received confirmation from the bank that the stop payment has been rejected. Do you want to continue?'
	Then I click 'CANCEL'
	When I click on Reset Filters Buttons
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'No'
	Then I click on close button in the filter
	When I select the any transaction
	Then I click on dots and select 'STOP PAYMENT CREATE'
	Then Verify the pop header as 'Confirm Stop Payment Transactions'
	Then verify the pop up body message as 'This action sets the selected transactions to Stop Payment Pending. Do you want to complete this action?'
	Then I click 'OK'
	When User click on Filter on Banking AccountsSummary page
	Then I select Stop Payement as 'Stop Payments Pending'
	Then I click on close button in the filter
	When I select the any transaction
	Then I click on dots and select 'STOP PAYMENT ACCEPT'
	Then Verify the pop header as 'Stop Payment Accept Transactions'
	Then verify the pop up body message as 'This step completes the stop payment process and creates a reversing entry for this check. Verify that you received confirmation from the bank that the stop payment has been accepted. Do you want to continue?'
	Then I click 'YES'
	Then I SignOut from the Unity Application

@US266879
Scenario: 039 - Bank Account Transactions - Filter
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
	Then I enter Account# '9000074143'
	Then I click on close button in the filter
	When I click on Account# '9000074143'
	When I click filter icon
    Then I verify default data in filter options as ClearedDate 'All', StopPayment 'All', PermitAssetImbalance 'All'
	Then I verify data in filter options in Account Management page
	Then I select  ClearedDate 'Yes', StopPayment 'Stop Payments Pending', PermitAssetImbalance 'No'
	Then I verify message when there are no results to display in the grid 'No Account Transactions Matching Current View'
	Then I click Reset in filter
	Then I SignOut from the Unity Application

@US266868@US266870@US266871
Scenario: 040 - Banking Service Calls on Deposits
	Given I enter to Bank Accounts page as superuser
	 When I click on Account# '3339999999'
	 Then I click ' DEPOSIT'
	   Then 'Account ManagementAdd Deposit' Breadcrumb should display
	   And I enter the Name Field in the Received Form
	   And I enter the amounts fields and validate the error message
	   And I Click Link Asset
       And I select Asset 'Subbu test asset villa at Newyork city'
       And I click on Add Button
	   Then I click ' CLOSING COST (NON-CLAIM)'
	 When I Enter All Feilds in non closing cost claim
	  Then I click on Add Button
	   And I click on Save Button
	 Then Verify the error message on mismatch of the amount
	 Then I SignOut from the Unity Application

@US274004@US293956@US293958@US279728@US293900@US293899
Scenario: 041 - Bank Account - Transaction Button
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
	Then I enter Account# '3339999999'
	Then I click on close button in the filter
	When I click on Account# '3339999999'
	Then I click Add Transaction button
	And I verify 'Add Transaction' Header
	And I verify 'RECEIPT TRANSACTIONS' and 'DISBURSEMENT TRANSACTIONS' sub-headers
	#And I click on 'DEPOSIT' button
	#Then I verify 'Add Deposit' in Breadcrumb
	#And I click on Cancel button
	#Then I click Add Transaction button
	#And I click on 'DEPOSIT CORRECTING CHECK' button
	#Then I verify 'Add Deposit Correcting Check' in Breadcrumb
	#And I click on Cancel button
	#Then I click Add Transaction button
	#And I click on 'DEPOSIT CORRECTING DEBIT' button
	#Then I verify 'Add Deposit Correcting Debit' in Breadcrumb
	#And I click on Cancel button
	#Then I click Add Transaction button
	#And I click on 'WIRE CREDIT' button
	#Then I verify 'Add Wire Credit' in Breadcrumb
	#And I click on Cancel button
	#Then I click Add Transaction button
	#And I click on 'CHECK' button
	#Then I verify 'Write Check' in Breadcrumb
	#And I click on Cancel button
	Then I click Add Transaction button
	And I click on 'RETURNED FUNDS' button
	Then I verify 'Add Returned Funds' in Breadcrumb
	And I click on LinkReceipt button in Received from Accordion
	And I Select any receipt from unlinked Receipt Log Entries
	Then I click on 'LINK INTEREST ASSET' button in InterestAssetLinks Accordion
	And I Select any Asset from LinkInterestAsset
	And I click on 'ADD' button
	And I click on 'SAVE' button
	Then I click on Edit pencil Icon
	Then Input Description 'Edit Returned Funds' in Received from Accordion
	And I Update the ClearDate as '12/20/19'
	And I click on 'SAVE' button
	#Then I click Add Transaction button
	#And I click on 'WIRE DEBIT' button
	#Then I verify 'Add Wire Debit' in Breadcrumb
	#Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
	#Then Input Description 'ADDWIREDEBIT' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF WIRE DEBIT'
	#When I click Link Claim 'LINK CLAIM'
	#Then Select any claim and Add
	#Then I add Unlinked allocations PAYEE NAME 'Test', UTC '2200 Trustee Expenses', AMOUNT '20'
	#Then I click and Input Linked Amount as '20' 
	#Then I Input amount as '40'
	#Then I click on 'SAVE' button
	#When User click on Filter on Banking AccountsSummary page
	#Then I select Cleared date as 'No'
	#Then I click on close button in the filter
	#Then I Select transaction type from 'Outgoing Wire Transfer' in Bank Accounts page
	#Then I click on Edit pencil Icon of the selected 'Outgoing Wire Transfer' Transaction type
	#Then I verify 'Edit Wire Debit' in Breadcrumb
	#Then I edit the fields DESCRIPTION 'Edit Wire Debit Transaction', REMARKS 'edit Wire Debit Transaction'
	#Then I click on 'SAVE' button
	#When User click on Filter on Banking AccountsSummary page
	#Then I select Cleared date as 'No'
	#Then I click on close button in the filter
	#Then I Select transaction type from 'Outgoing Wire Transfer' in Bank Accounts page
	#Then I click on dots and select 'VOID / REVERSAL'
	#Then Verify the pop header as 'Void Transactions'
	#Then verify the pop up body message as 'Selected transactions will be voided, please confirm and enter a remark you would like applied to all of the selected transactions'
	#When I enter the text for Remarks
	#Then Click on OK Button of the pop up modal
	#When User click on Filter on Banking AccountsSummary page
	#Then I select Cleared date as 'Yes'
	#Then I click on close button in the filter
	#Then I Select transaction type from 'Outgoing Wire Transfer Reversal' in Bank Accounts page
	#Then I click on Edit pencil Icon of the selected 'Outgoing Wire Transfer Reversal' Transaction type
	#Then I verify 'Edit Wire Debit Reversal' in Breadcrumb
	#Then I edit the fields DESCRIPTION 'Edit Reversed Wire Transaction', REMARKS 'edit Wire Debit Reversal'
	#Then I click on 'SAVE' button
	#When User click on Filter on Banking AccountsSummary page
	#Then I select Cleared date as 'Yes'
	#Then I click on close button in the filter
	#Then I Select transaction type from 'Outgoing Wire Transfer' in Bank Accounts page
	#Then I click on eye ball Icon of the selected 'Outgoing Wire Transfer' Transaction type
	#Then I verify deposit is non editible field
	#Then I click on close button on view page
	Then I SignOut from the Unity Application

@US270467
Scenario: 042 - Bank Account - Export Button
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
	Then I enter Account# '9000074143'
	Then I click on close button in the filter
	When I click on Account# '9000074143'
	Then I click on Export Button in Transaction page
	Then Verify the pop header as 'Export Transactions'
	Then verify the pop up body message as 'This action creates a spreadsheet of the Transactions listed on all pages of this table: '
	And I click on Cancel button
	Then I SignOut from the Unity Application

@US293968
Scenario: 043 - Bank Accounts - Next Check and Deposit Number enabled when no transaction tied to account 
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
	Then I enter Account# '1833333399999'
	Then I click on close button in the filter
	And I click on EditBank Account icon
	And I enter checknumber Description '150'
	And I enter nextDepositnumber Description '160'
	And I click on button SAVE
	Then I SignOut from the Unity Application
	

@US293968
Scenario: 044 - Bank Accounts - Next Check and Deposit Number disabled when no transaction tied to account 
	Given I enter to Bank Accounts page as superuser
	When I click filter icon
	Then I enter Account# '3339999999'
	Then I click on close button in the filter
	And I click on EditBank Account icon
	And I able to see disable icon for nextcheck Number
	And I able to see disable icon for nextDeposit Number
	And I click on button SAVE
	Then I SignOut from the Unity Application


@US293950@US293949@US293948
Scenario: 045 -Bank Account- Deposit Correcting Debit Reversal
Given I enter to Bank Accounts page as superuser
When I click filter icon
 Then I Filter with Account No '9000074143'
  When I Close Filter pop up I should see data on grid
	When I click on Account# '9000074143'
	Then I click on eye ball Icon
	Then I verify deposit is non editible field
	Then I click on close button on view page
	Then I click on Edit pencil Icon
	Then I edit the values and save the new values
	Then I SignOut from the Unity Application

@US293942
Scenario: 046 -Bank Account- Deposit Correcting check Reversals
Given I enter to Bank Accounts page as superuser
When I click filter icon
 Then I Filter with Account No '3339999999'
  When I Close Filter pop up I should see data on grid
	When I click on Account# '3339999999'
	Then I click on eye ball Icon
	Then I verify deposit is non editible field
	Then I click on close button on view page
	Then I click on Edit pencil Icon
	Then I edit the values and save the new values
	Then I SignOut from the Unity Application

@US293957
Scenario: 047 - Validate the Bank Accounts- Returned Funds with View Only Access
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	When I click on Account Number link 
	Then I click on eye ball Icon
	Then 'Account ManagementView Returned Funds' Breadcrumb should display
	And I click on 'CLOSE' button
	Then I SignOut from the Unity Application

@US293939@US293938@US293937
Scenario: 048 -Bank Accounts-Add/View/Edit Deposit Correcting check
    Given I enter to Bank Accounts page as superuser
    When I click filter icon
    Then I Filter with Account No '3339999999'
    When I Close Filter pop up I should see data on grid
	When I click on Account# '3339999999'
	When I select the any transaction
	Then I click Add Transaction button
	And I click on 'DEPOSIT CORRECTING CHECK' button
	Then I verify 'Add Deposit Correcting Check' in Breadcrumb
	Then Input 'Subhash' and select debtorname 'Subhash' 
    Then Input Description 'DATECHANGE' Distribution Type 'Other Payment To Creditor' Remarks 'Deposit reversing'
    Then I Input amount as '200'
    When I click Link Claim 'LINK CLAIM'
    Then Select any claim and Add
    When I save the Check
	When I select the any transaction
	Then I click on dots and select 'VOID / REVERSAL'
	Then Verify the pop header as 'Void Transactions'
	Then verify the pop up body message as 'Selected transactions will be voided, please confirm and enter a remark you would like applied to all of the selected transactions'
	When I enter the text for Remarks
	Then Click on OK Button of the pop up modal
    Then I SignOut from the Unity Application

@US293941@US293940
Scenario: 049 -Bank Accounts-View/Edit Reversed Deposit Correcting check
    Given I enter to Bank Accounts page as superuser
    When I click filter icon
    Then I Filter with Account No '3339999999'
    When I Close Filter pop up I should see data on grid
	When I click on Account# '3339999999'
	When I select the any transaction
	And I select the first record to edit the transaction
	When I save the Check
	Then I SignOut from the Unity Application

@US279727@US293898
	Scenario Outline: 050 - Validate the Bank Accounts- Wire Debit with View Only Access
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	And I select the Account with Case Number 'SU-99999'
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'No'
	Then I click on close button in the filter
	When I Select the PageSize as <PageSize> under Pagination Section
	Then I Select transaction type from 'Outgoing Wire Transfer' in Bank Accounts page
	Then I click on eye ball Icon of the selected 'Outgoing Wire Transfer' Transaction type
	Then 'Account ManagementView Wire Debit' Breadcrumb should display
	And I click on 'CLOSE' button
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'Yes'
	Then I click on close button in the filter
	When I Select the PageSize as <PageSize> under Pagination Section
	Then I Select transaction type from 'Outgoing Wire Transfer Reversal' in Bank Accounts page
	Then I click on eye ball Icon of the selected 'Outgoing Wire Transfer Reversal' Transaction type
	Then 'Account ManagementView Wire Debit Reversal' Breadcrumb should display
	And I click on 'CLOSE' button
	Then I SignOut from the Unity Application
		Examples: 
	| PageSize |
	| 50     |

	@US279725
	Scenario Outline: 051 - Validate the Bank Accounts- Wire Credit with View Only Access
	Given I enter to Bank Accounts page as user AutomationView with password Welcome456Epiq! and office crose
	And I select the Account with Case Number 'SU-99999'
	When I Select the PageSize as <PageSize> under Pagination Section
	When User click on Filter on Banking AccountsSummary page
	Then I select Cleared date as 'No'
	Then I click on close button in the filter 
	Then I Select transaction type from 'Incoming Wire Transfer' in Bank Accounts page
	Then I click on eye ball Icon of the selected 'Incoming Wire Transfer' Transaction type
	Then 'Account ManagementView Wire Credit' Breadcrumb should display
	And I click on 'CLOSE' button
	Then I SignOut from the Unity Application
		Examples: 
	| PageSize |
	| 100      |

	
