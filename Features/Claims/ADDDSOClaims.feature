@Regression	
@ReactJS

Feature: DSOClaimants
	In order to verify DSO Page functionality an Add DSO Claimants in DSO Page

 Scenario: 001 - DSO Page-Verify header,Bread crumb and sub header
 # using existing DSO Management header function defined in GlobalExtendnNoData feature
 Given I enter to DSO page as superuser
	   Then  I see DSO Management header   
	   And I see breadcrumb DashboardDSO Claimants and subheader DSO Claimants 
	   Then I SignOut from the Unity Application


Scenario: 002 - DSO Page- Case/debtor claimants Filter and Sort
		Given I enter to DSO page as superuser
		Then  I see DSO Management header 
		#Then Verify sorting on Grid 'CLAIMANT NAME'
		When I click on filter search Icon         
         Then I input all the fields data '01/01/17' and '11/11/18' and 'Open' and 'Completed' and 'Active' 
		 Then verify the filtered data on Grid '01/01/17' and '11/11/18 '
	     Then I SignOut from the Unity Application	
		  

@US226485
Scenario: 003 - DSO Page- Input all filter fields and Reset
Given I enter to DSO page as superuser
    When I click on filter search Icon	  
	   Then I input all the fields data '11/11/17' and '12/12/18' and 'Open' and 'All' and 'All'
	   Then I click Reset
	   Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 004 - DSO Page-Add DSO claimant with Existing Debtor&Joint Debtor Employer 
Given I enter to DSO page as superuser
   When I click DSO claimant on DSO Page
        Then I see Add DSO Claimants header on Claimants page 
        Then Input 'ALLEN' and I select debtorname '14-15657 / ALLEN, ANTOINETTE K' 
	    And I input 'TEST' and 'TEST' and '9505616939' text fields information
	    Then I input 'Both' and 'AL' and 'Sushma' and 'mpike' dropdown fields information
	    Then I Save claimant
		Then check Dso claimant on DSO Page
	    Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 005 - DSO Page-Add DSO claimant with New Debtor-Individual&New Joint Debtor Employer-Individual
Given I enter to DSO page as superuser
 When I click DSO claimant on DSO Page
       Then I see Add DSO Claimants header on Claimants page
        Then Input 'ALLEN' and I select debtorname '14-15657 / ALLEN, ANTOINETTE K' 
       Then I input 'TEST' and 'TEST' and '9505616939' text fields information
	   Then I input 'Both' and 'AK' and 'mpike' and 'Sushma' dropdown fields information
 When I select 'New Debtor Employer' type 
 When I select 'Individual' 
       Then I input Debtor title as 'Miss'
	   Then Input 'debtorEmployer' Debtor Firstname as 'Paul' and MiddleName as 'Kristy' and Lastname as 'BRAIN' for Individual
 When I select 'New Joint Debtor Employer' type 
When I select Joint debtor 'Individual'   
	   Then I input Joint Debtor title as 'Mr.'
	   Then Input 'jointDebtorEmployer' Joint Debtor Firstname as 'Brain' and MiddleName as 'heather' and Lastname as 'Iravanne' for Individual
	   Then I Save claimant
	   Then check Dso claimant on DSO Page
	   Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 006 - DSO Page-Add DSO claimant with New Debtor-Corporation&New Joint Debtor Employer-Corporation 
 Given I enter to DSO page as superuser
    When I click DSO claimant on DSO Page
        Then I see Add DSO Claimants header on Claimants page
        Then Input 'ALLEN' and I select debtorname '14-15657 / ALLEN, ANTOINETTE K' 
        Then I input 'TEST' and 'TEST' and '9505616939' text fields information
	    Then I input 'Both' and 'AL' and 'mpike' and 'Sushma' dropdown fields information
 When I select 'New Debtor Employer' type 
 When I select 'Corporation' 
 When I input 'debtorEmployer' Debtor displayname as 'paul' for Corporation
 When I select 'New Joint Debtor Employer' type 
 When I select Joint debtor 'Corporation' 
 When I input Joint Debtor displayname as 'paul' for Corporation
      Then I Save claimant
	  Then check Dso claimant on DSO Page
	  Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 007 - DSO Page-Add DSO claimant with New Debtor-Idividual&New Joint Debtor Employer-Corporation 
 Given I enter to DSO page as superuser
   When I click DSO claimant on DSO Page
        Then I see Add DSO Claimants header on Claimants page
        Then Input 'ALLEN' and I select debtorname '14-15657 / ALLEN, ANTOINETTE K' 
        Then I input 'TEST' and 'TEST' and '9505616939' text fields information
	    Then I input 'Both' and 'AK' and 'mpike' and 'Sushma' dropdown fields information
 When I select 'New Debtor Employer' type 
 When I select 'Individual' 
       Then I input Debtor title as 'Miss'
	   Then Input 'debtorEmployer' Debtor Firstname as 'Paul' and MiddleName as 'Kristy' and Lastname as 'BRAIN' for Individual
 When I select 'New Joint Debtor Employer' type 
 When I select Joint debtor 'Corporation' 
 When I input Joint Debtor displayname as 'paul' for Corporation
      Then I Save claimant
	  Then check Dso claimant on DSO Page
	  Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 008 - DSO Page-Add DSO claimant with only New Debtor-Corporation
 Given I enter to DSO page as superuser
     When I click DSO claimant on DSO Page
      Then I see Add DSO Claimants header on Claimants page
      Then Input '17-90000' and I select debtorname '17-90000 / QATest1, NareshRaj' 
      Then I input 'ETSAutomation' and 'TEST' and '9505616939' text fields information
	  Then I input 'Both' and 'AL' and 'mpike' and 'Sushma' dropdown fields information
  When I select 'New Debtor Employer' type 
  When I select 'Corporation' 
  When I input 'debtorEmployer' Debtor displayname as 'paul' for Corporation
	 Then I Save claimant
	  Then check Dso claimant on DSO Page
	 Then I SignOut from the Unity Application

 @DSOClaimsAdd
 @US226486
 Scenario: 009 - DSO Page-Verify Added Record -DSO claimant with only New Debtor-Corporation
 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
     Then Verify the added record on Grid using climant name'ETSAUTOMATION'
	 Then I SignOut from the Unity Application

@DSOClaimsEdit
 @US226487
 Scenario: 010 - DSO Page-Verify Edit Record -DSO claimant with only New Debtor-Corporation
 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	     Then Verify the added record on Grid using climant name'ETSAUTOMATION'
         Then input Edit fields information Address 'AutomationTest' and Phone '1234567890'
	     Then I Save claimant
	     Then I SignOut from the Unity Application

 #@View DSO Permission
 @US226487
 Scenario: 011 - DSO Page-Verify View Permission on DSO Page
 Given I enter to Unity Login page
	When I try to login with credentials Vandita1, Welcome444Epiq! and crose
	 Given I Go to DSO page
         Then Verify for View icon symbol '10' 
         Then I SignOut from the Unity Application
 
 @US235855@Bug278992
Scenario: 012 - DSO Page- Save InlineEdit and Verify
	Given I enter to DSO page as superuser
	When I click on filter search Icon	  
	Then I input all the fields data '02/18/18' and '02/19/18' and 'All' and 'All' and 'All'
		Then I Click On Close Button on DSO Filter
	And I edit 'CLAIMANT NAME', '4', 'DSO QA AUTOMATION'
	And I edit 'ADDRESS', '5', 'Hyderabad'
	And I edit 'INITIAL NOTICE PRINTED', '7', '02/18/18'
	#And I edit 'DISCHARGE NOTICE PRINTED', '8', '02/18/18'
	And the 'CLAIMANT NAME', '4' should contain 'DSO QA AUTOMATION'
	And the 'ADDRESS', '5' should contain 'Hyderabad'
	And the 'INITIAL NOTICE PRINTED', '7' should contain '02/18/18'
	#And the 'DISCHARGE NOTICE PRINTED', '8' should contain '02/18/18'
	Then I SignOut from the Unity Application
 
 @US235855@Bug278992
Scenario: 013- DSO Page- Cancel InlineEdit and Verify
	Given I enter to DSO page as superuser
	When I click on filter search Icon	  
	Then I input all the fields data '02/18/18' and '02/19/18' and 'All' and 'All' and 'All'
	Then I Click On Close Button on DSO Filter
	And I edit the 'CLAIMANT NAME', '4', 'DSO QA Automation Testing'
	And I edit the 'ADDRESS', '5', 'BanjaraHills,Hyderabad'
	And I edit the 'INITIAL NOTICE PRINTED', '7', '06/12/18'
	#And I edit the 'DISCHARGE NOTICE PRINTED', '8', '06/12/18'
	And the 'CLAIMANT NAME', '4' should contain 'DSO QA AUTOMATION'
	And the 'ADDRESS', '5' should contain 'Hyderabad'
	And the 'INITIAL NOTICE PRINTED', '7' should contain '02/18/18'
	#And the 'DISCHARGE NOTICE PRINTED', '8' should contain '02/18/18'
	Then I SignOut from the Unity Application
 
 @US235855
Scenario: 014- DSO Page- Verify InlineEdit Fields are non editable
	Given I enter to DSO page as user AutomationView with password Welcome456Epiq! and office crose
	When I click on filter search Icon	  
	Then I input all the fields data '02/18/18' and '02/19/18' and 'All' and 'All' and 'All'
	And I Click on Close Button
	And I see InLineEdit Fields are No more Editable
		Then I SignOut from the Unity Application

@US240995
Scenario: 015- DSO Page- Verify DSO Summary Tile from dashboard 
	Given I enter to Dashboard page as superuser
	When I click on DSO Summary record link
	And I click on filter search Icon	  
	Then I See dates are filled in filter
	Then I SignOut from the Unity Application

@US256013
Scenario: 016 - DSO Page-Delete funtionality verification in DSO page
	 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'	
	And I can select all option in the header
	And I can Deselect all option in the header
     And I can select first record in dso page
	 Then I can click on delete button in the DSO Page
	 Then verify the Text in the pop up as 'Confirm deletion of selected DSO Claimants'
	 And I click on Delete button in pop up
	 Then I SignOut from the Unity Application

@US256013
Scenario: 017 - DSO Page-Delete funtionality verification in DSO page with out selecting the record
	 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '18-00054' On The Universal Search Section Input
	 And I Click on the Case Result '18-00054'
	 And I can see delete button is not clickcable until select the case
	 Then I SignOut from the Unity Application

@US256013
Scenario: 018 - DSO Page-Cancel funtionality verification in DSO page
	 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '18-00054' On The Universal Search Section Input
	 And I Click on the Case Result '18-00054'
     And I can select first record in dso page
	 Then I can click on delete button in the DSO Page
	 Then verify the Text in the pop up as 'Confirm deletion of selected DSO Claimants'
	 And I click on Cancel button in pop up
	 Then I SignOut from the Unity Application

@US293963
Scenario: 019 - DSO Page-verified Hover is Enabled in DSO page
	 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '18-00054' On The Universal Search Section Input
	 And I Click on the Case Result '18-00054'
	 Then I see Verified button Enabled
	 And I SignOut from the Unity Application   
	 