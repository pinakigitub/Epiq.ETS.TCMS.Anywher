@Regression	
@ReactJS	
@FailureCases
Feature: Documents 
	Navigating to the different sections 
		under Documents page

@CasesTab
Scenario: 001 - Cases- Documents page verification
	Given I enter to Documents page as superuser
	Then 'Document Management' header should be displayed on Document Page
	When I click on Filter on Documents page
	Then Documents 'FILTER OPTIONS' should be displayed
	When I click on close on Documents page
	Then Documents 'FILTER OPTIONS' should be closed
	And I SignOut from the Unity Application

#Scenario: 002 - Cases- Documents Breadcrumb and sorting verification
#   Given I enter to Documents page as superuser
#    Then 'DashboardDocuments List' Breadcrumb should display
#    And 'DEBTOR' should be able sorted
#   #And 'CURRENT 341 DATE' should be able to sort on Document Page
#   And 'SOURCE' should be able sorted
#   And I SignOut from the Unity Application

Scenario: 003 - Cases- Documents Expand row for more columns
   Given I enter to Documents page as superuser
   When I click on Row Expand button on Document page
	Then I should be able to see column CASE STATUS
	#Then I should be able to see column TRUSTEE
	#Then I should be able to see column DISTRICTyes
	#Then I should be able to see column CASE TYPE
	#Then I should be able to see column ASSET STATUS
	#Then I should be able to see column FILE NAME
	Then I should  be able to see column CASE #
	Then I should  be able to see column CURRENT 341 DATE
	Then I should  be able to see column HISTORY
	And I SignOut from the Unity Application

Scenario: 004 - Cases- Documents Filter Options Validation
   Given I enter to Documents page as superuser
   When I click on Filter on Documents page
   #And I search '01-21039' and click on '01-21039 / FINAL ANALYSIS INC.' on Documents Filter
   And I select CaseStatus 'Open'
   And I click on close on Documents page
   Then Document records should be displayed
   And I SignOut from the Unity Application

Scenario: 005 - Cases- Documents- Filter search and clear validation
	Given I enter to Documents page as superuser
	When I click on Filter on Documents page 
	#And I search '01-21039' and click on '01-21039 / FINAL ANALYSIS INC.' on Documents Filter
	And I select Tag '341 Meeting'
	#And I select date '08/06/2014' from DATE FILED FROM field
	#And I select date '08/15/2014' from DATE FILED TO field
    And I click on close on Documents page  
	#Then Document result should contains '01-21039' 'FINAL ANALYSIS INC.'
	Then Document result should contain Tag '341 Meeting'
	When I click on Filter on Documents page 
	And I click on reset button of documents filter
	Then default Documents result should be present
	And I SignOut from the Unity Application
   

Scenario: 006 - Cases- Documents- Filter dropdown X validation
	Given I enter to Documents page as superuser
	When I click on Filter on Documents page
	And I click on X button of case Status dropdown 
	Then case status filter value should be All
	When I click on close on Documents page
	Then I SignOut from the Unity Application
	


#
#Scenario: 007- Documents-Add New Document- Save Button
#Given I enter to Documents page as superuser
#When User clicks on the add document button
#And user selects the Case Number or Debtor Name on new window
#And User Uploads the Document in new window
#Then User clicks on save button on the current window
#When I click on Filter on Documents page 
#And I search '01-21039' and click on '01-21039 / FINAL ANALYSIS INC.' on Documents Filter
#And I click on close on Documents page
#Then Document records should be displayed
#Then I SignOut from the Unity Application

@229001
Scenario Outline: 008_Documents - Verify PageSize under Pagination
	Given I enter to Documents page as superuser
	When I Select the PageSize as <PageSize> under Pagination Section
	And I see the CaseList Table Contains the Same Number of Rows as per Selected <PageSize>
	Then I SignOut from the Unity Application
	Examples: 
	| PageSize | 
	| 10       | 
	| 25       | 
	| 50       | 
	| 100      | 

@229001
Scenario: 009_Documents-Add Tags- Verify Tags as Multiple
	Given I enter to Documents page as superuser
	And I click on filter search Icon
	#When I Perform the Search of Cases with '17-90001' Case Number
	When I enter Description 'Automation.pdf'
	Then I Click on Close Button 
	And I Edit Tags and Description 'Automation.pdf'
	And I Add Tags '341 Meeting', 'Batch Tag QA Test' and 'test' to that Case
	And I save the Added tags
	#Given I click on filter search Icon
	#When I Perform the Search of Cases with '17-90001' Case Number
	#Then I Click on Close Button 
	#Then I see Records should contain 'TAGS-Multiple'
	And I SignOut from the Unity Application

@229001
Scenario: 010_Documents- Documents View Permission
	Given I enter to Documents page as user Manaswi3 with password Welcome456Epiq! and office crose
	Then I see the Security Warning Icon in Orange
	And Security Warning msg as 'Please contact your Office Administrator and request permission to view this content. You are missing one of the following permissions: Document View'
	When I see the text 'Contact Office Administrator' and Select Administrator 'AutoTest1'
	Then an Email 'QA@auot.com' and Admin Name 'AutoTest1' are Populated below
	And I SignOut from the Unity Application

Scenario: 011_Documents-In Line Edit
	Given I enter to Documents page as superuser
	When I Click on Description button on Documents Page
	Then I Sould be able to edit description in line
	When I Click on Tag button on Documents Page
	Then I Sould be able to edit Tag in line - '341 Meeting' or Blank
	When I click on Row Expand button on Document page
	#And I click on File Name button on document Page
	#Then Should be able to edit File Name in line
	Then I SignOut from the Unity Application

@US195065
Scenario: 012_Documents-Validation for View only
	Given I enter to Documents page as user AutomationView with password Welcome456Epiq! and office crose 
	Then I see eye button for all records
	When I clik on Eye Button of Document
	Then I should not be able to edit the documents details
	And I SignOut from the Unity Application

@US195065
Scenario: 013_Documents-Validation for Edit Document
	Given I enter to Documents page as superuser
	Then I see edit-pencil button for all records
	When I clik on pencil Button of Document
	Then I should be able to edit the documents details
	And I SignOut from the Unity Application

@US235433
Scenario: 014_Documents-Edit Pencil -Validate Editing of the Document
	Given I enter to Documents page as superuser
	Then I see edit-pencil button for all records
	When I clik on pencil Button of Document
	And I Click on Header of Document Viewer Page
	When I click on File Name button on Document Viewer Page
	  Then Should be able to edit File Name in line
	When I click on Description button on Document Viewer Page
	  Then I Should be able to edit Description in line on Document Viewer Page
	When I click on Assigned To button on Document Viewer Page
	 Then I Should be able to edit Assigned To in line on Document Viewer Page
	#When I click on Doc button on Document Viewer Page
	#When I click on Source button on Document Viewer Page
	When I click on TAG button on Document Viewer Page
	  Then I Sould be able to edit Tag in line - '341 Meeting' or Blank
	And I SignOut from the Unity Application


@US256012
Scenario: 015 - Dcouments Page-Delete funtionality verification in Dcouments page
	 Given I enter to Documents page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I can select all option in the header
	 And I can Deselect all option in the header
     And I can select first record in dso page
	 Then I can click on delete button in the Dcouments Page
	 Then verify the Text in the pop up as 'Confirm deletion of selected documents.'
	 And I click on Delete button in pop up
	 Then I SignOut from the Unity Application

@US256012
Scenario: 016 - Dcouments Page-Delete funtionality verification in Dcouments page with out selecting the record
	 Given I enter to Documents page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I can see delete button is not clickcable until select the case
	 Then I SignOut from the Unity Application

@US256012
Scenario: 017 - Dcouments Page-Cancel funtionality verification in Dcouments page
	 Given I enter to Documents page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
     And I can select first record in dso page
	 Then I can click on delete button in the Dcouments Page
	 Then verify the Text in the pop up as 'Confirm deletion of selected documents.'
	 And I click on Cancel button in pop up
	 Then I SignOut from the Unity Application