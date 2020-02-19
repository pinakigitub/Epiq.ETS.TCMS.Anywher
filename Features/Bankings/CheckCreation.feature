@Regression	
@ReactJS

Feature: CheckCreation
	In order to create CHECK

Background: 
Given I enter to Bank Accounts page as superuser

@US208612
Scenario:001-Check Creation- Existing Payee

  # When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074143'
   When I Close Filter pop up I should see data on grid  
   When I click on Account # on Grid
   Then 'Bank AccountsAccount Management' Breadcrumb should display
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   When I select 'Existing Payee' type 
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
   Then Input Description 'DATECHANGE' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   When I save the Check
   Then I SignOut from the Unity Application

@US208612@US264019
Scenario:002- Linking claims to Check-Existing Payee

#When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074143'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
   Then Input Description 'DATECHANGE' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   When I click Link Claim 'LINK CLAIM'
   Then Select any claim and Add
   When I save the Check
   Then I SignOut from the Unity Application

@US208744
Scenario:003-Split Utc Check Creation- when no claims linked with Existing Payee

 #  When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074119'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
   Then Input Description 'Regression' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   Then Verify the message displayed 'No Claims Linked'
   When I click Link Claim 'UNLINKED ALLOCATION (UTC)'
   Then Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','0'
   Then I click button 'ADD'
   When I save the Check
   Then I SignOut from the Unity Application

@US208744
Scenario:004-Split Utc Check Creation-when claims already linked with Existing Payee

  # When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074119'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
   Then Input Description 'RegressionTEST' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   When I click Link Claim 'LINK CLAIM'
   Then Select any claim and Add
   When I click Link Claim 'UNLINKED ALLOCATION (UTC)'
   Then Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','100'
   Then I select Non Compensable as 'YES' for row '1'
   Then I click button 'ADD'
   When I save the Check
   Then I SignOut from the Unity Application

@US255988@US247566
Scenario:005-Split Utc Check Creation-when claims already linked with New Payee

   #When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074119'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   When I select 'New Payee' type 
   When I select 'Individual' 
   Then I input Debtor title as 'Miss' for '1'
   Then Input 'payee' Debtor Firstname as 'Paul' and MiddleName as 'Kristy' and Lastname as 'BRAIN' for Individual
   Then Input Description 'RegressionTEST' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   When I click Link Claim 'LINK CLAIM'
   Then Select any claim and Add
   When I click Link Claim 'UNLINKED ALLOCATION (UTC)'
   Then Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','0'
  Then I select Non Compensable as 'YES' for row '1'
   Then I click button 'ADD'
   When I save the Check
   Then I SignOut from the Unity Application

@US208744
Scenario:006-Split Utc Check Creation-When add multiple line items in Split Utc with Existing Payee

   #When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074119'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
   Then Input Description 'Regressionlinks' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   Then Verify the message displayed 'No Claims Linked'
   When I click Link Claim 'UNLINKED ALLOCATION (UTC)'
   Then Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','200'
   Then I select Non Compensable as 'YES' for row '1'
   Then I click Add Line Item
   Then Input UTC split fields information for row '1','SAMPLE','SAMPLE','8100 Exemptions','100'
   Then I select Non Compensable as 'YES' for row '2'
   Then I click button 'ADD'
   When I save the Check
   Then I SignOut from the Unity Application

@US255988@US247566
Scenario:007-Split Utc Check Creation-When add multiple line items in Split Utc with New Payee

   #When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074119'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   When I select 'New Payee' type 
   When I select 'Corporation' 
   When I input 'payee' Payee displayname as 'paul' for Corporation
   Then Input Description 'Regressionlinks' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   Then Verify the message displayed 'No Claims Linked'
   When I click Link Claim 'UNLINKED ALLOCATION (UTC)'
   Then Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','200'
  Then I select Non Compensable as 'YES' for row '1'
   Then I click Add Line Item
   Then Input UTC split fields information for row '1','SAMPLE','SAMPLE','8100 Exemptions','100'
   Then I select Non Compensable as 'YES' for row '2'
   Then I click button 'ADD'
   When I save the Check
   Then I SignOut from the Unity Application


@US208744
Scenario:008-Split Utc Check Creation-Cancel the Split Utc Creation after adding Line Items
   #When I select Bank Accounts
   When I click filter icon
   Then I Filter with Account No '9000074119'
   When I Close Filter pop up I should see data on grid
   When I click on Account # on Grid
   When I Click on Create Check Button
   Then 'Account ManagementWrite Check' Breadcrumb should display
   Then I input Clear Date as '01/20/19' 
   Then Input 'LOUIS' and select debtorname '2956 TestRecon, KNRAJ' 
   Then Input Description 'Regressionlinks' Distribution Type 'Other Payment To Creditor' Remarks 'CREATION OF CHECK'
   Then I Input amount as '200'
   Then Verify the message displayed 'No Claims Linked'
   When I click Link Claim 'UNLINKED ALLOCATION (UTC)'
   Then Input UTC split fields information for row '0','SAMPLE','SAMPLE','8100 Exemptions','200'
   Then I select Non Compensable as 'YES' for row '1'
   Then I click Add Line Item
   Then Input UTC split fields information for row '1','SAMPLE','SAMPLE','8100 Exemptions','100'
   Then I select Non Compensable as 'YES' for row '2'
   Then I click button 'CANCEL'
   When I save the Check
   Then I SignOut from the Unity Application