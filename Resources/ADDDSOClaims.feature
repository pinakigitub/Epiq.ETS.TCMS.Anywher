@Regression	
@ReactJS

Feature: AddDSOClaimant
	In order to verify DSO Page functionality an Add DSO Claimants in DSO Page

 Scenario: 001 - DSO Page-Verify header,Bread crumb and sub header
 # using existing DSO Management header function defined in GlobalExtendnNoData feature
 Given I enter to DSO page as superuser
	   Then  I see DSO Management header   
	   And I see breadcrumb DashboardDSO Claimants and subheader DSO Claimants 
	   Then I SignOut from the Unity Application


Scenario Outline: 002 - DSO Page- Case/debtor claimants Filter and Sort
Given I enter to DSO page as superuser
		 Then Verify sorting on Grid 'CLAIMANT NAME'
     When I click on filter search Icon         
         Then I input all the fields data <Fromdate> and <ToDate> and <CaseStatus> and <DsoInitial> and <DsoNotice> 
		 Then verify the filtered data on Grid '01/01/17' and '12/12/18 '
	     Then I SignOut from the Unity Application
	 
	 Examples:

	| Fromdate | ToDate   | CaseStatus | DsoInitial | DsoNotice |
	| 01/01/17 | 12/12/18 | Open       | Completed  | Active    |
	

@US226485
Scenario: 003 - DSO Page- Input all filter fields and Reset
Given I enter to DSO page as superuser
    When I click on filter search Icon	  
	   Then I input all the fields data 11/11/17 and 12/12/17 and All and All and All
	   Then I click Reset
	   Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 004 - DSO Page-Add DSO claimant with Existing Debtor&Joint Debtor Employer 
Given I enter to DSO page as superuser
   When I click DSO claimant on DSO Page
        Then I see Add DSO Claimants header on Claimants page 
        Then Input 'LOUIS' and I select debtorname '12-32267 / LOUIS SCHOSSLER' 
	    And I input 'TEST' and 'TEST' and '9505616939' text fields information
	    Then I input 'Both' and 'AL' and 'Sushma' and 'mpike' dropdown fields information
	    Then I Save claimant
	    Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 005 - DSO Page-Add DSO claimant with New Debtor-Individual&New Joint Debtor Employer-Individual
Given I enter to DSO page as superuser
 When I click DSO claimant on DSO Page
       Then I see Add DSO Claimants header on Claimants page
       Then I input 'LOUIS' and I select debtorname '12-32267 / LOUIS SCHOSSLER' 
       Then I input 'TEST' and 'TEST' and '9505616939' text fields information
	   Then I input 'Both' and 'AK' and 'mpike' and 'Sushma' dropdown fields information
 When I select 'New Debtor Employer' type 
 When I select 'Individual' 
       Then I input Debtor title as 'Miss' for 'Individual'
	   Then I input Debtor Firstname as 'Paul' and MiddleName as 'Kristy' and Lastname as 'BRAIN' for 'Individual'
 When I select 'New Joint Debtor Employer' type 
 When I select Joint debtor 'Individual'  
	   Then I input Joint Debtor title as 'Mr.' for 'Individual'
	   Then I input Joint Debtor Firstname as 'Brain' and MiddleName as 'heather' and Lastname as 'Iravanne' for 'Individual'
	   Then I Save claimant
	   Then I SignOut from the Unity Application


@DSOClaimsAdd
@US226486
 Scenario: 006 - DSO Page-Add DSO claimant with New Debtor-Corporation&New Joint Debtor Employer-Corporation 
 Given I enter to DSO page as superuser
    When I click DSO claimant on DSO Page
        Then I see Add DSO Claimants header on Claimants page
        Then I input 'LOUIS' and I select debtorname '12-32267 / LOUIS SCHOSSLER' 
        Then I input 'TEST' and 'TEST' and '9505616939' text fields information
	    Then I input 'Both' and 'AL' and 'mpike' and 'Sushma' dropdown fields information
 When I select 'New Debtor Employer' type 
 When I select 'Corporation' 
 When I input Debtor displayname as 'paul' for 'Corporation'
 When I select 'New Joint Debtor Employer' type 
 When I select Joint debtor 'Corporation'  
 When I input Joint Debtor displayname as 'paul' for 'Corporation'
      Then I Save claimant
	  Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 007 - DSO Page-Add DSO claimant with New Debtor-Idividual&New Joint Debtor Employer-Corporation 
 Given I enter to DSO page as superuser
   When I click DSO claimant on DSO Page
        Then I see Add DSO Claimants header on Claimants page
        Then I input 'LOUIS' and I select debtorname '12-32267 / LOUIS SCHOSSLER' 
        Then I input 'TEST' and 'TEST' and '9505616939' text fields information
	    Then I input 'Both' and 'AK' and 'mpike' and 'Sushma' dropdown fields information
 When I select 'New Debtor Employer' type 
 When I select 'Individual' 
       Then I input Debtor title as 'Miss' for 'Individual'
	   Then I input Debtor Firstname as 'Paul' and MiddleName as 'Kristy' and Lastname as 'BRAIN' for 'Individual'
 When I select 'New Joint Debtor Employer' type 
 When I select Joint debtor 'Corporation'  
 When I input Joint Debtor displayname as 'paul' for 'Corporation'
      Then I Save claimant
	  Then I SignOut from the Unity Application

@DSOClaimsAdd
@US226486
 Scenario: 008 - DSO Page-Add DSO claimant with only New Debtor-Corporation
 Given I enter to DSO page as superuser
     When I click DSO claimant on DSO Page
      Then I see Add DSO Claimants header on Claimants page
      Then I input '17-90000' and I select debtorname '17-90000 / NareshRaj QATest1' 
      Then I input 'Automation' and 'TEST' and '9505616939' text fields information
	  Then I input 'Both' and 'AL' and 'mpike' and 'Sushma' dropdown fields information
  When I select 'New Debtor Employer' type 
  When I select 'Corporation' 
  When I input Debtor displayname as 'paul' for 'Corporation'
	 Then I Save claimant
	 Then I SignOut from the Unity Application

 @DSOClaimsAdd
 @US226486
 Scenario: 009 - DSO Page-Verify Added Record -DSO claimant with only New Debtor-Corporation
 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
     Then Verify the added record on Grid using climant name'Automation'
	 Then I SignOut from the Unity Application

@DSOClaimsEdit
 @US226487
 Scenario: 010 - DSO Page-Verify Edit Record -DSO claimant with only New Debtor-Corporation
 Given I enter to DSO page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 Then Verify the added record on Grid using climant name'Automation'
     Then input Edit fields information Address 'AutomationTest' and Phone '1234567890'
	 Then I Save claimant
	 Then I SignOut from the Unity Application

 @View DSO Permission
 @US226487
 Scenario: 011 - DSO Page-Verify View Permission on DSO Page
 Given I enter to Unity Login page
	When I try to login with credentials vandita1, Welcome123Epiq! and crose
	Given I Go to DSO page
 Then Verify for View icon symbol 
  Then I SignOut from the Unity Application