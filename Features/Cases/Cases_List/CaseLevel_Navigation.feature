@Regression	
@ReactJS	

Feature: CaseLevel_Navigation
		 Navigating to different sections using a case Number

@US#235885
Scenario:001_CaseLevelNavigation-Verify Search Section
	Given I enter to Case List page as superuser
	And I see the search box in Darker blue
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	And I see the box in LightBlue
	When I clear the box and I see text 'All Cases'	
	Then I SignOut from the Unity Application

@US235899
Scenario:002_CaseLevelNavigation-AssetsPage
	Given I enter to Case List page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	And I Go to Assets page
	And I see the Summary header in LightBlue
	And I see table header in LightBlue
	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
	And I see case as 'open' in green
	And CaseType as 'Asset' in Orange
	And I see the table with title 'ASSETS SUMMARY'
	And I see the value under 'Scheduled/Unscheduled' as '$200,000.00'
	And I see 'Net Value' as '$200,000.00'
	And I see 'Abandoned' value as '0'
	And I see the value of 'Sales' as '$200,000.00'
	And I see 'Remaining' with value '$0.00'
	Then I verify Asset Details Description 'Wells Fargo Savings A/C' and Petition '$150,000.00'
	And I SignOut from the Unity Application

Scenario:003_CaseLevelNavigation-ClaimsPage
	Given I enter to Case List page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	And I Go to Claims page
	Then I see the table with title 'CLAIMS SUMMARY'
	And I see the value 'Estate Balance' as '$200,000.00'
	And 'Valid to Pay' as '$1,000.00' 
	And I see 'Paid' details as '$0.00'
	And I See the 'Reserved' value '$0.00'
	And the 'Claims Balance' value as '$1,000.00'
	Then I verify Claims Details Creditor 'CHERYL E. ROSE' and Class 'Administrative'
	And I SignOut from the Unity Application

Scenario:004_CaseLevelNavigation-DSOPage
	Given I enter to Case List page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-30004' On The Universal Search Section Input
	And I Click on the Case Result '17-30004'
	And I Go to DSO page
	Then I verify DSO Claimants details Name 'QA Naresh Raj K' and Address 'QA Naresh Raj K'
	And I SignOut from the Unity Application

Scenario:005_CaseLevelNavigation-TasksPage
	Given I enter to Tasks page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-30004' On The Universal Search Section Input
	And I Click on the Case Result '17-30004'
	Given I enter on the office tasks
	#And I select Tasks as 'OFFICE TASKS'
	Then I verify Task Details Type 'Bank Reconciliations', Notes 'Bank Reconciliations' and Assigned To 'Naresh Raj K'  
	And I SignOut from the Unity Application

Scenario:006_CaseLevelNavigation-BankingReceiptLog
	Given I enter to Case List page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I Go to Banking ReceiptLog page
	And I see Received From 'Sushma' and Amount '$6,000.00'
	Then I SignOut from the Unity Application

@US270474
Scenario:007_CaseLevel - Navigating to 341Meeting Page
Given I enter to 341 Meeting page as superuser
And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then 'Dashboard341 Meeting Dates' Breadcrumb should display
	Then I click on the View 341_Meeting date link	
Then I SignOut from the Unity Application

@207012
Scenario:008-CaseList DEBTOR Navigatiton to 341Meeting Page
Given I enter to Case List page as superuser
When I click on DEBTOR NAME link    
Then I SignOut from the Unity Application

  @207012
Scenario:009-CaseList CASE# Navigatiton to 341Meeting Page
Given I enter to Case List page as superuser
When I click on expand link
And I click on CASE# link	
Then I SignOut from the Unity Application

  Scenario: 010_CaseLevel-ClaimsSummary
	Given I enter to Claims page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000' 
	And I validate the Count of 'Valid to Pay'
	When I Select the PageSize as 50 under Pagination Section
	And I validate the 'Paid' Count
	Then I SignOut from the Unity Application

@US244136
Scenario: 011_CaseLevelNavigation- AddAsset Page
	Given I enter to Assets page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	When I click on Add Asset on specific case level
	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
	And I see case as 'open' in green
	And CaseType as 'Asset' in Orange
	When I select NOTES
	Then I see Notes header contains Case# '17-00001' and Debtor Name 'KNRAJ Zero Claim1'
	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
	Then I see the Page Header Title as 'Add Asset'
	When I Click on Back To Assets
	Then I SignOut from the Unity Application

#@US244139
#Scenario: 012_CaseLevelNavigation- EditAsset Page
#	Given I enter to Assets page as superuser
#	And I see the Search box under All Cases Section
#	When I Enter '17-00001' On The Universal Search Section Input
#	And I Click on the Case Result '17-00001'
#	When I click on Edit Assset button on a specific case level
#	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
#	And I see case as 'open' in green
#	And CaseType as 'Asset' in Orange
#	When I select NOTES
#	Then I see Notes header contains Case# '17-00001' and Debtor Name 'KNRAJ Zero Claim1'
#	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
#	Then I see the Page Header Title as 'Edit Asset'
#	When I Click on Back To Assets
#	Then I SignOut from the Unity Application

@US240609
Scenario: 013_CaseLevel- ReceiptLogPage
	Given I enter to Banking ReceiptLog page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then I see the DebtorName 'QATest1, NareshRaj ' and CaseNum '17-90000'
	And the Receipts count should display
	And I should not be able to see 'CASE #' and 'DEBTOR NAME' in Case Level View
	And I mark the debtor 'QATest1, NareshRaj ', '1' as verified
	And I see case 'QATest1, NareshRaj ' as Verified
	Then I SignOut from the Unity Application

@US240609
@US240613
Scenario: 014_CaseLevel - ReceiptLog View Permission
	Given I enter to Banking ReceiptLog page as user AutomationView with password Welcome456Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I See the Add Receipt is in Disabled State
	Then I see 'VOID' in disabled state
	And I see 'VERIFY' in disabled state
	And I see 'DEPOSIT' in disabled state
	Then Verify for View icon symbol '10'
	Then I SignOut from the Unity Application

@US240610
@US240611
Scenario: 015_CaseLevel - Verify ReceiptLog FilterSection
	Given I enter to Banking ReceiptLog page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
	When I click on filter
	And I select Linked 'Yes' in Filter
	And I select Voided 'No' in Filter
	Then I Click on Close Button 
	When I verify Transaction Link of Received From 'Sushma' 
	Then I SignOut from the Unity Application

@US240611
Scenario: 016_CaseLevel - Add ReceiptLog Verify
	Given I enter to Banking ReceiptLog page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then I Click on Add Receipt
	And I see CaseNumber is ReadOnly Field 
	And I enter CaseNum '', Recieved From 'Sushma', Bank Received '01/21/18', Address 'Banjara Hills'
	And I enter Amount '10', CheckNum '123456', CheckDate '02/15/18' and CheckReceived '02/10/18' 
	And I enter Transaction Details Description 'QA Testing', Notes 'Creating New Receipt log Page ' and UTC 'Other Litigation'
	Then I 'CANCEL' the Receipt Log
	Then I SignOut from the Unity Application
@US240612
@US240614
Scenario: 017_CaseLevel - Void ReceiptLog
	Given I enter to Banking ReceiptLog page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	Then I Click on Add Receipt
	And I enter CaseNum '', Recieved From 'Sampath10', Bank Received '01/21/18', Address 'Banjara Hills'
	And I enter Amount '100', CheckNum '456123', CheckDate '02/16/18' and CheckReceived '02/14/18' 
	And I enter Transaction Details Description 'QA Testing', Notes 'Creating New Receipt log Page ' and UTC 'Other Litigation'
	Then I 'SAVE' the Receipt Log
	And I see 'VOID' in disabled state
	And I Select transaction Received from 'Sampath10'
	And I see 'VOID' In Enabled state
	And I click on 'VOID'
	And I click 'OK'
	When I click on filter
	And I select Voided 'Yes'
	Then I Click on Close Button 
	Then I should not be able to see Pencil Icon
	When I click on filter
	And I select Voided 'Yes'
	Then I Click on Close Button 
	Then I Select transaction Received from 'Subbu'
	And I see 'VOID' in disabled state
	And I see 'DEPOSIT' in disabled state
	And I SignOut from the Unity Application

@US240614
Scenario: 018_CaseLevel - ReceiptLog - Edit Entry with Permissions
	Given I enter to Banking ReceiptLog page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	When I Select the PageSize as 50 under Pagination Section
	And I Edit Received From 'Sushma'
	Then I enter CaseNum '', Recieved From 'Sushma', Bank Received '01/21/18', Address 'Banjara Hills'
	And I enter Amount '100', CheckNum '121121', CheckDate '02/15/18' and CheckReceived '02/10/18' 
	And I enter Transaction Details Description 'QA Automation Testing', Notes 'Editing Receipt' and UTC 'Other Litigation'
	And I click on Link Transaction
	And I link transaction 'NAGARJUNA'
	Then I 'SAVE' the Receipt Log
	When I click on filter
	And I select Linked 'Yes' in Filter
	And I verify Transaction Link of Received From 'Sushma' 
	Then I unlink the transaction
	Then I 'SAVE' the Receipt Log
	And I SignOut from the Unity Application

@US240614
Scenario: 019_CaseLevel - ReceiptLog - Verify View Bank AccountNumber
	Given I enter to Banking ReceiptLog page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	And I Edit Received From 'Sushma'
	Then I click on Link Transaction
	And I see partial AccountNum for 'NAGARJUNA' as '8547458456'
	And I Cancel the Link Transaction
	And I 'CANCEL' the Receipt Log
	When I click on filter
	And I select Linked 'Yes' in Filter
	When I verify Transaction Link of Received From 'Sushma' 
	And I verify Linked Details 'LINKED TO ACCOUNT #-8547458456'
	Then I SignOut from the Unity Application

@US240614
Scenario: 020_CaseLevel - ReceiptLog - Verify Partial Bank AccountNumber
	Given I enter to Banking ReceiptLog page as user partialBankAcc with password Welcome123Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	And I Edit Received From 'Sushma'
	Then I click on Link Transaction
	And I see partial AccountNum for 'NAGARJUNA' as 'XXXXXX8456'
	And I Cancel the Link Transaction
	And I 'CANCEL' the Receipt Log
	When I click on filter
	And I select Linked 'Yes' in Filter
	When I verify Transaction Link of Received From 'Sushma' 
	And I verify Linked Details 'LINKED TO ACCOUNT #-XXXXXX8456'
	Then I SignOut from the Unity Application

@US240614
Scenario: 021_CaseLevel - ReceiptLog - Verify No Permissions to view Bank AccountNumber
Given I enter to Banking ReceiptLog page as user NoBankAccView with password Welcome123Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	And I Edit Received From 'Sushma'
	Then I click on Link Transaction
	And I see partial AccountNum for 'NAGARJUNA' as 'XXXXXXXXXX'
	And I Cancel the Link Transaction
	And I 'CANCEL' the Receipt Log
	When I click on filter
	And I select Linked 'Yes' in Filter
	When I verify Transaction Link of Received From 'Sushma' 
	And I verify Linked Details 'LINKED TO ACCOUNT #-XXXXXXXXXX'
	Then I SignOut from the Unity Application

@US245012
Scenario: 022_Specific_CaseNavigation - BankAccounts - Write Check
	Given I enter to Bank Accounts page as superuser
	And I see the Search box under All Cases Section
	When I Enter '15-16657' On The Universal Search Section Input
	And I Click on the Case Result '15-16657'
	And the Select the Account Num '9000074144'
	When I Click on Create Check Button
	Then 'Account ManagementWrite Check' Breadcrumb should display
	Then I input Clear Date as '10/04/18' 
    When I select 'Existing Payee' type 
	Then I enter Payee 'kavitha'
    #Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
    Then Input Description 'DATECHANGE' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
    Then I Input amount as '200'
	And I click on Link Claim
	And I link Claim
	When I save the Check
	When I clear the box and I see text 'All Cases'
	Then I click on Bank Accounts in Breadcrumb
	Then I see Banking Center header
	Then I SignOut from the Unity Application

@US245013
Scenario: 023_Specific_CaseNavigation - Banking Activity
	Given I enter to Banking Activity page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
	And I see 'Unreconciled Bank Accounts' Table header contains 'ISSUE;BANK;ACCOUNT #;ACCOUNT NAME;ACCOUNT TYPE'
	And I SignOut from the Unity Application

@US245016
Scenario: 024_Specific_CaseNavigation - Banking Activity- Issue Link- Issue Reconciliation
	Given I enter to Banking Activity page as superuser
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I click on Issue Link 'Unlinked Deposit'
	#Then I see 'Issue Reconciliation' page is displayed
	#And I Select the Bank Transactions SerialNum '000150' and Ledger Transactions SerialNum '21'
	#Then I click 'LINK TRANSACTIONS'
	Given I click on filter search Icon
	Then I select 'Linked' under 'BANK TRANSACTIONS' dropdown
	And I select 'Linked' under LEDGER TRANSACTIONS dropdown in Issue Reconciliation
	And I select PageSize '10' for BANK TRANSACTIONS
	And I select PageSize '10' for LEDGER TRANSACTIONS
	#And I sort 'BANK TRANSACTIONS' serialNo
	Then I Select the Bank Transactions SerialNum '000162' and Ledger Transactions SerialNum '114'
	And I click 'UNLINK TRANSACTIONS'
	And I SignOut from the Unity Application

#@US244137
#Scenario: 025_CaseLevelNavigation- ViewAsset Page
#	Given I enter to Assets page as user AutomationView with password Welcome123Epiq! and office crose
#	And I see the Search box under All Cases Section
#	When I Enter '17-00001' On The Universal Search Section Input
#	And I Click on the Case Result '17-00001'
#	When I click on View Assset button on a specific case level
#	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
#	And I see case as 'open' in green
#	And CaseType as 'Asset' in Orange
#	When I select NOTES
#	Then I see Notes header contains Case# '17-00001' and Debtor Name 'KNRAJ Zero Claim1'
#	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
#	Then I see the Page Header Title as 'View Asset'
#	When I Click on Back To Assets
#	Then I SignOut from the Unity Application

Scenario: 026_CaseLevel - ReceiptLog - View Only Fields
	Given I enter to Banking ReceiptLog page as user AutomationView with password Welcome456Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	And I Edit Received From 'Subbu'
	And I see the Fields as ReadOnly
	Then I SignOut from the Unity Application

@US250053
Scenario: 027_CaseLevel - Documents
Given I enter to Documents page as superuser
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	Then Document records should be displayed
	And I should not be able to see 'CASE #' and 'DEBTOR' in Case Level View
	When I click on Filter on Documents page
	Then I should not be able to see 'CASE # / DEBTOR NAME' and 'CaseStatus' in CaseLevel
	When I click on close on Documents page
	Then I Sould be able to edit '1' description 'Documents Automation Testing'
	Then I edit '1' Tag '341 Meeting' 
	And I see the Description '1' contains 'DOCUMENTS AUTOMATION TESTING' and '1' Tag '341 MEETING'
	Then I SignOut from the Unity Application

@US250055
Scenario: 028_CaseLevel - Edit Documents
Given I enter to Documents page as superuser
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	When I click on Filter on Documents page
	And I enter Description 'DOCUMENTS AUTOMATION TESTING1'
	When I click on close on Documents page
	And I Edit row with Description 'DOCUMENTS AUTOMATION TESTING1'
	And I expand the Document
	Then I edit 'DESCRIPTION' as 'DOCUMENTS AUTOMATION TESTING1'
	And I input the 'DOC #' as '12345' and Source 'Asset'
	#And I edit input 'DOC #' as '67890' and Source 'Claim'
	And I edit the ASSIGNED TO as 'Subhash'
	And I edit the TAGS as 'test'
	When I click on breadcrumb 'Documents'
	Then 'Documents' page should be displayed
	And I SignOut from the Unity Application

@US250057
Scenario: 029_Caselevel - View Documents
Given I enter to Documents page as user AutomationView with password Welcome456Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	Then I see eye button for all records
	When I clik on Eye Button of Document
	Then I should not be able to edit the documents details
	And I SignOut from the Unity Application

@US250061
Scenario: 030_CaseLevel - CaseList
Given I enter to Case List page as superuser
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	Then I see the DebtorName 'FINAL ANALYSIS INC.' and CaseNum '01-21039'
	And I see Debtor Attorney 'SCHMITT, ANN E.'
	And I see the History Column
	Then the Records should contain 'LEDGER BALANCE-$280,950.29'
	And I should not be able to see 'CASE #' and 'DEBTOR' in Case Level View
	When I click on filter search Icon
	Then I should not be able to see 'CASE # / DEBTOR NAME' and 'CaseStatus' in CaseLevel
	And I close the Filter Options
	And I SignOut from the Unity Application

@US255992
Scenario: 031_Caselevel - Banking Print Checks/Deposits
	Given I enter to Banking ChecksOrDeposits page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then I see the DebtorName 'QATest1, NareshRaj ' and CaseNum '17-90000'
	And I see Debtor Attorney 'DAttorney_QA1, Naresh Raj'
	And I see 'Print Checks/Deposits' Table header contains 'BANK NAME;ACCOUNT NAME;ACCOUNT #;PAYEE NAME;TRANSACTION TYPE;TRANSACTION DATE;SERIAL #;PRINT DATE;AMOUNT'
	And I see the Print in Disabled State
	When I select the transaction and I see Print in Enabled State 
	When I click on filter search Icon
	Then I should not be able to see 'CASE # / DEBTOR NAME' and '' in CaseLevel
	And I SignOut from the Unity Application

@US255993
Scenario: 032_Caselevel - Banking Print Checks/Deposits - History Icon
Given I enter to Banking ChecksOrDeposits page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I click on History button
	Then I see table header text 'Office Transaction Print History'
	And I see 'Office Transaction Print History' Table header contains 'TYPE;STATUS;USER;DATE'
	And I see the Print Icon
	And I SignOut from the Unity Application

#@US250056
#Scenario: 033_CaseLevel - AddDocuments
#	Given I enter to Documents page as superuser
#	And I see the Search box under All Cases Section
#	When I Enter '01-21039' On The Universal Search Section Input
#	And I Click on the Case Result '01-21039'
#	When User clicks on the add document button
#	And User Uploads the Document in new window
#	And I enter the Description 'Automation Testing'
#	Then User clicks on save button on the current window
#	When I click on filter search Icon
#	And I enter Description 'Automation Testing'
#	Then I Click on Close Button 
#	Then the Records should contain 'DESCRIPTION-Automation Testing'
#	Then I SignOut from the Unity Application

@US255993
Scenario: 033_Caselevel:Distributions Specific Case Navigation
Given I enter to Distributions page as superuser
	And I see the Search box under All Cases Section
	When I Enter '01-21039' On The Universal Search Section Input
	And I Click on the Case Result '01-21039'
	Then 'DashboardDistribution List' Breadcrumb should display
	Then verify the columns '2' to '6' displayed on 'epiq-page-body' as 'NAME;STATUS;CALCULATED;MODIFIED;HISTORY'
	When User click on Filter on Distribution page
	Then I SignOut from the Unity Application

@US259315
Scenario: 034_Specific_CaseNavigation - Dates Management Page
	Given I enter to Dates page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	Then I see the DebtorName 'Claim1, KNRAJ Zero' and CaseNum '17-00001'
	And I SignOut from the Unity Application

@US270465@US293945
Scenario: 035_Specific_CaseNavigation - Trustee Expenses page
	 Given I enter to Dashboard page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'
	 Then I Click on Comp/Expense Details button
	 And I Click  on Expenses
	 Then I verify the number of expenses in the grid
	 Then I verify 'Total Expenses','Paid', 'Balance Due', 'Update Allowed and Claimed Amounts' in Expenses Summary
	 Then I Verify columns 'DATE', 'TYPE', 'UOM', 'UNIT PRICE', 'QTY', 'TOTAL','NOTES' in Expenses
	 And I verify default data in filter options as ExpenseType 'All'
	 Then I edit expenses DATE OF EXPENSE '06/30/15', EXPENSE TYPE 'Bond Premium', UNIT OF MEASURE 'EACH', REMARKS 'Prepare, revise,  Notice of Assets and Application to Employ Cheryl E Rose as Attorney, Non-exempt equity in tax refunds.', QTY '304', UNIT PRICE '0.20'
	 And I SignOut from the Unity Application

@US270465@US293945
Scenario: 036_Specific_CaseNavigation - Trustee Expenses page - Dashboard Navigation
	 Given I enter to Dashboard page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'	
	 Then I Click on Comp/Expense Details button
	 And I Click  on Expenses
	 Then I select X in the Global Case Navigation
	 Then I  redirected to the 'All Cases','Dashboard'page     
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'	
	 Then I Click on Comp/Expense Details button
	 And I Click  on Expenses
	 Then I select All Cases in the Global Case Navigation
	 Then I  redirected to the 'All Cases','Dashboard'page   
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'	
	 Then I Click on Comp/Expense Details button
	 And I Click  on Expenses
	 And I see the Search box under All Cases Section
	 When I Enter '15-16186' On The Universal Search Section Input
	 And I Click on the Case Result '15-16186'	
	 Then user will be navigated to the Case they selected '15-16186' and the Page Navigation will read Trustee 'Expenses'
	 And I see the Search box under All Cases Section
	 When I Enter '99-11188' On The Universal Search Section Input
	 And I Click on the Case Result '99-11188'	
	 Then I verify message 'No expenses to display'
	 And I SignOut from the Unity Application

@US293973@US293972
Scenario: 037_Trustee Compensation-Calulator-calulated and forecast tab
 Given I enter to Dashboard page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'
	 Then I Click on Comp/Expense Details button
	 When I Cilck on calculator button in header
	 Then I enter the additional compensation amount under Calulated and forecast tab
	 Then I click freeze compensesation and enter the value into it
	 Then I click on Close button on pop up
	 Then I SignOut from the Unity Application

@US293973@US293972
Scenario: 038_Trustee Compensation-Calulator-By Date tab
 Given I enter to Dashboard page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'
	 Then I Click on Comp/Expense Details button
	 When I Cilck on calculator button in header
	 Then I click on By Date Tab
	 And I enter the transaction dates
	 And I click on Close button on pop up
	 And I SignOut from the Unity Application

@US270468
Scenario: 039_Trustee Compensation Export Button
	  Given I enter to Dashboard page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '15-16657' On The Universal Search Section Input
	 And I Click on the Case Result '15-16657'
	 Then I Click on Comp/Expense Details button
	 And I Click  on Expenses
	 And I Click on Export button
	 Then Verify the pop header as 'Export Expenses'
	Then verify the pop up body message as 'This action creates a spreadsheet of the Expenses listed on all pages of this table: '
	And I click on Cancel button
	 And I SignOut from the Unity Application