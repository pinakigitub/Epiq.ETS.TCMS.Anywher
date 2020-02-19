@Regression	
@ReactJS
@123

Feature: Case_General
		Veifying Case General Info and Edit user permissions

Scenario: 001_CaseGeneral-Edit Case Additional Info
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	Then I click on Case Info button
	And I input 'DEBTOR TYPE-Partnership;FILE NUMBER-123;TRUSTEE ATTORNEY-HOWARD N. MADRIS;JUDGE-Thomas J. Catliota;BOND TYPE-Individual Bond;BOND AMOUNT-2000.00'
	And I save the Info
	Then I click on Case Info button
	And I verify 'DEBTOR TYPE-Partnership;TRUSTEE ATTORNEY-HOWARD N. MADRIS;JUDGE-Thomas J. Catliota;BOND TYPE-Individual Bond'
	And I input 'DEBTOR TYPE-Corporation;FILE NUMBER-10;TRUSTEE ATTORNEY-RICHARD J. PARKER;JUDGE-E. Stephen Derby;BOND TYPE-N/A;BOND AMOUNT-4000.00'
	When I Click on Cancel
	Then I SignOut from the Unity Application

Scenario: 002_CaseGeneral-User Doesn't have permission to Edit Case - Read Only
	Given I enter to Dashboard page as user AutomationView with password Welcome456Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '17-00001' On The Universal Search Section Input
	And I Click on the Case Result '17-00001'
	Then I click on Case Info button
	And I see Editable Fields as ReadOnlyFields 'DEBTOR TYPE', 'JUDGE' and 'BOND AMOUNT'
	And I Close the Case Additional Info
	Then I SignOut from the Unity Application

Scenario: 003_CaseGeneral-Verify KeyDates
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '09-28101' On The Universal Search Section Input
	And I Click on the Case Result '09-28101'
	Then I see KeyDates 'CURRENT 341 MEETING-06/20/11;Petition Date-09/24/09;Current 341 Date-06/20/11'
	And I see KeyDates 'Current 341 Date-10:30 AM;Original 341 Date-06/07/11;Original 341 Date-9:30 AM;Date Case Converted to Chapter 7-04/28/11'
	And I see KeyDates 'Discharge Date-11/22/11;Claims Bar Date-09/27/11;Government Claims Bar Date-03/23/10;Initial Estimated TFR-06/30/13'
	And I see KeyDates 'Estimated TFR-06/30/13;Final Decree-02/01/13;Disposition Date-02/11/13'
	Then I SignOut from the Unity Application

Scenario: 004_CaseGeneral-Verify Header Layout
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then I see Case Number '17-90000'
	And Debtor Name 'QATest1, NareshRaj'
	And Debtor Attorney 'DAttorney_QA1, Naresh Raj'
	And I see Case Status 'Open' in Green
	And I see CaseType 'Asset' in Orange
	And I SignOut from the Unity Application

Scenario: 005_CaseGeneral-Verify UI of Header Notes Section
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I select NOTES
	Then I see Notes header contains Case# '17-90000' and Debtor Name 'NareshRaj QATest1'
	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
	When I click on cases
	Then 'Case List' page should be displayed
	And I SignOut from the Unity Application

@US188531
@BugID:267265
Scenario: 006_CaseGeneral-NOTES:Verify Adding Notes
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I select NOTES
	Then I see Notes header contains Case# '17-90000' and Debtor Name 'NareshRaj QATest1'
	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
	And Verify the Notes count of type 'Office'
	And Add Notes of type 'Office' and 'Create Office Note'
	And I SignOut from the Unity Application

@US190213
Scenario: 007_CaseGeneralES:Verify Edit Notes
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I select NOTES
	Then I see Notes header contains Case# '17-90000' and Debtor Name 'NareshRaj QATest1'
	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
	And Edit Notes of type 'Office'
	And I SignOut from the Unity Application

@US190197
Scenario: 008_CaseGeneral-NOTES:Read Only View Of Notes
	Given I enter to Dashboard page as user AutomationView with password Welcome456Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	And I select NOTES
	Then I see Notes header contains Case# '17-90000' and Debtor Name 'NareshRaj QATest1'
	And I see Note Types 'Office', 'Trustee', 'Form 1', 'Form 3' and '341 Meeting'
	And Verify view Permission 'Office' and 'READ ONLY'
	And I SignOut from the Unity Application


Scenario: 009_CaseGeneral-Verify General Info
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then I see the DEBTOR ATTORNEY 'DAttorney_QA1, Naresh Raj'
	And I see Case Status 'Open' and ASSETStatus 'Asset'
	And I see CaseType 'Chapter 7'
	And I see an Envelope after Debtor Attorney
	And Case has Tags 'DSO Case'
	Then I SignOut from the Unity Application

Scenario: 010_CaseGeneral-Pariticipants-Verify Pariticipants
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '09-28101' On The Universal Search Section Input
	And I Click on the Case Result '09-28101'
	Then 'Participants' section should display 
	And I see participants 'Debtor-KARVOUNIS, GEORGE J.;Joint Debtor-KARVOUNIS, ARTEMIS;Debtor Attorney-RUSSACK, TATE'
	And I see the 'Debtor Attorney' Phone Link 
	And I click on 'Debtor Attorney' Expand button
	And I able to view 'Debtor Attorney' Details 'PHONE #-(913) 555-2222'
	Then I SignOut from the Unity Application

Scenario: 011_CaseGeneral-Participants-SSN Full View Permission validation
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '09-28101' On The Universal Search Section Input
	And I Click on the Case Result '09-28101'
	Then 'Participants' section should display 
	And I click on 'Debtor' Expand button
	And I able to view 'Debtor' Full SSN '900-33-5483'
	And I click on 'Debtor Attorney' Expand button
	And I able to view 'Debtor Attorney' Full SSN '900-33-4022'
	Then I SignOut from the Unity Application

Scenario: 012_CaseGeneral-Participants-SSN Partial View Permission validation
	Given I enter to Dashboard page as user PartialSSNUser1 with password Welcome345Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '09-28101' On The Universal Search Section Input
	And I Click on the Case Result '09-28101'
	Then 'Participants' section should display 
	And I click on 'Debtor' Expand button
	And I able to view 'Debtor' Partial SSN 'XXX-XX-5483'
	And I click on 'Debtor Attorney' Expand button
	And I able to view 'Debtor Attorney' Partial SSN 'XXX-XX-4022'
	Then I SignOut from the Unity Application

Scenario: 013-CaseGeneral-Participants-No SSN View Permission validation
	Given I enter to Dashboard page as user NoSSNUser1 with password Welcome678Epiq! and office crose
	And I see the Search box under All Cases Section
	When I Enter '09-28101' On The Universal Search Section Input
	And I Click on the Case Result '09-28101'
	Then 'Participants' section should display 
	And I click on 'Debtor' Expand button
	And I should not able to view 'Debtor' SSN No 'XXX-XX-XXXX'
	And I click on 'Debtor Attorney' Expand button
	And I should not able to view 'Debtor Attorney' SSN No 'XXX-XX-XXXX'
	Then I SignOut from the Unity Application

Scenario: 014_CaseGeneral-Participants-Verify Details of participants
	Given I enter to Dashboard page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	Then 'Participants' section should display 
	And I click on 'Debtor' Expand button
	And I able to view 'Debtor' Details 'SSN-908-97-1293;TAX ID #-74-8578794'
	And I click on 'Debtor Attorney' Expand button
	And I able to view 'Debtor Attorney' Details 'EMAIL-nareshraj.kodimela@dtiglobal.com;ADDRESS-QA Regression Test,  Street#1 Avenue 6, CA - USA;PHONE #-(789) 456-8745'
	Then I SignOut from the Unity Application

@US270477
Scenario: 015 - Schedule to Claim Reconciliation Page- Filter
 Given I enter to Schedule to Claim Reconciliation page as superuser
 Then I click on Unreconciled link for case number '01-21039'
 When I click filter icon
 Then I verify default data in filter options as Schedules Tile Linked 'All', Claims Tile Linked 'All'
 Then I verify data in filter options in Claim Reconciliation page
 Then I select  ScheduleTileLinked 'No', ClaimsTileLinked 'No'
 Then I click Reset in filter in Claim Reconciliation page
 Then I SignOut from the Unity Application
