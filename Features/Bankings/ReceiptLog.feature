@Regression   
@ReactJS
Feature: ReceiptLog 
       In order to manage Receipts(Void,Verify,Deposit) in the RECEIPT LOG 

@US#207984
Scenario: 001 - Closing Cost - Add Closing Cost Modal Default Display and verify
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
       And I select trasaction 'not void' 
       When I click on deposit button
       Then Closing Cost table should display with Unlinked Transaction
       When I select closing costs button
       Then Closing Cost Modal should display default
	   When I close add closing cost modal
       Then I SignOut from the Unity Application


Scenario: 002 -  Closing Cost - CLOSING COST TYPE Field
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
	   When I Select the PageSize as 50 under Pagination Section
	   Then I Select transaction Received from 'Sushma' in Receipt Log page 
       #Then I select trasaction 'not void' 
       When I click on deposit button
       And I select closing costs button
       #When I select claim radio button
       Then Claims sholud be in ascending order
       When I enter 'FARID AHMED' in search 
       Then 'FARID AHMED' should be displayed in closing costs
       When I enter 'invalidData' in search
       Then 'No result found...' should be displayed in closing costs(Claim)     
       When I close add closing cost modal
       Then I SignOut from the Unity Application


Scenario:  003 -  Closing Cost - Non-Claim All Fields 
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
       #When I click on filter
       #And I enter case name '16-81016 / Test'
	   When I Select the PageSize as 50 under Pagination Section
	   Then I Select transaction Received from 'Sushma' in Receipt Log page        
       #Then I select trasaction 'not void' 
       When I click on deposit button
       And I select closing costs Non-Claim button
       When I Enter All Feilds
       Then Asterisk should not display
       When I Clear All Fields
       Then All Fields should Empty
       When I close add closing cost modal
       Then I SignOut from the Unity Application

Scenario: 004_ ReceiptLog - CreateReceiptLog
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
       And I Click on Add Receipt
       And I enter CaseNum '17-00001', Recieved From 'Sushma', Bank Received '01/21/18', Address 'Banjara Hills'
       And I enter Amount '10', CheckNum '123456', CheckDate '02/15/18' and CheckReceived '02/10/18' 
       And I enter Transaction Details Description 'QA Testing', Notes 'Creating New Receipt log Page ' and UTC 'Other Litigation'
       Then I 'SAVE' the Receipt Log
       Then I SignOut from the Unity Application

@US#259313@US#259369
Scenario: 005_ReceiptLog - Create a Deposit and Link Asset for saved ReceiptLog
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
       When I click on filter
	   And I select Linked 'No' in Filter
       Then I Click on Close Button 
	   When I Select the PageSize as 50 under Pagination Section
       Then I Select transaction Received from 'Subbu' in Receipt Log page
	   When I click on deposit button
       Then I input 'NAME-Nagarjuna;DESCRIPTION-Testing'
       And I Click Link Asset
       And I select Asset 'Well Fargo Savings A/C' 
	   And I click on button ADD
       And I click on button SAVE
       When I click on filter
	   And I select Linked 'Yes' in Filter
       Then I Click on Close Button 
	   Then I Edit transaction Received from 'Subbu'
       And I click 'UNLINK TRANSACTION'
       And I click on button SAVE
       Then I SignOut from the Unity Application

Scenario: 006 - Closing Cost - Validate Add and Cancel
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
       #When I click on filter
       #And I enter case name '16-81016 / Test' 
	   When I Select the PageSize as 50 under Pagination Section
       Then I Select transaction Received from 'Sushma' in Receipt Log page
       #Then I select trasaction 'not void' 
       When I click on deposit button
       And I select closing costs Non-Claim button
       Then Add Deposit page should display
       When I Enter All Feilds
       Then Asterisk should not display
       When I Click on ADD in Add Closing Cost
       #Then Add Deposit page should display
       Then Added Claim Should display
       When I Click on X in the Closing cost
       Then Closing Cost Should Removed
       When I select closing costs button
       And I close add closing cost modal
	   Then 'Account ManagementAdd Deposit' Breadcrumb should display
       #Then Add Deposit page should display
       And I SignOut from the Unity Application

@US#259314@US#259313@US#266860@US#259369
Scenario: 007_ReceiptLog - Edit a Deposit and Link Non- Closing cost claim
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
       When I click on filter
       And I select Linked 'No' in Filter
       Then I Click on Close Button 
	   When I Select the PageSize as 50 under Pagination Section
       Then I Select transaction Received from 'Sushma' in Receipt Log page
	   When I click on deposit button
       Then I input 'NAME-Subhash;DESCRIPTION-Testing;UTC CODE-1142 Personal Injury Litigation'
       And I Click Link Asset
       And I select Asset 'Well Fargo Savings A/C'                        '
       And I click on button ADD
       And I click on button CLOSING COST(NON-CLAIM)
	   And I click on button CANCEL
       And I SignOut from the Unity Application


@US#259316
Scenario: 008-Permit Asset Imbalance on Deposit
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
	   Then I Select transaction Received from 'Sushma' in Receipt Log page
	   When I click on deposit button
	   Then I input 'NAME-Nick;DESCRIPTION-Testing' 
	   And I enter Net Amount '200.00' and Gross Amount '300.00
	   And I Click Link Asset
       And I select Asset 'Well Fargo Savings A/C'                      
       And I click on button ADD
	   And I select PERMIT ASSET IMBALANCE
       Then I SignOut from the Unity Application       

@US#259369
Scenario: 009_ReceiptLog - Create a Deposit and Link Asset with updated titles
       Given I enter to Banking ReceiptLog page as superuser
       Then Receipts page should be opened
	   When I click on filter
       And I select Linked 'No' in Filter
       Then I Click on Close Button 
	   When I Select the PageSize as 50 under Pagination Section
       Then I Select transaction Received from 'Subbu' in Receipt Log page
	   When I click on deposit button
       Then I input 'RECEIVED FROM-Nagarjuna;DESCRIPTION-Testing;UTC CODE-1142 Personal Injury Litigation'
       And I Click on AssetLinks
	   And I Click on ClosingCostLinks
	   And I Click on Unlinked Allocations
	   And I click on ClaimLinks
       Then I SignOut from the Unity Application
