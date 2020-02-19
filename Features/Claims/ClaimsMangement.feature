@Regression	
@ReactJS
@FailureCasesClaims	
Feature: ClaimsMangement
		Navigating to the different sections under Claims Mangement Page
		Adding and editing of claims	

	
@US#259326@US#197601
Scenario: 001 - ClaimsMangement Page BreadCrumb Verification
	Given I enter to Claims page as superuser
	Then 'Claims Management' page should be display
	Then 'DashboardClaims' Breadcrumb should display
	And Table data should be present
	And 'DEBTOR' should be able sorted
	And Page count should be display
	And pagination shouold be display
	And I SignOut from the Unity Application

@US#199846@US#199846
Scenario: 002 - Claims filters funnel Search and Clear
	Given I enter to Claims page as superuser
	When I click on filter button
	When I enter Creditor 'BRENT'
	And I select Class 'Unsecured'
	And I select Claim status 'Valid To Pay'
	And I enter Balance from '0.00'
	And I enter Balance to '0.00'
	And I select Case status 'All'
	And I click on close
	Then Selected result should contains 'BRENT' 'Unsecured' '0.00' '0.00'
	When I click on filter button
	And Click on reset
	And I click on close
	Then default data should be present
	And I SignOut from the Unity Application
	
@US199848
Scenario:003- Add Claim:Existing claimant
	Given I enter to Claims page as superuser
	When I click on Add Claim
	Then I see subheader as 'Add Claim' 	
	Then I input case/debtor details as 'CASE # / DEBTOR NAME@11-18811 / EXECUTIVE DRYWALL, INC.;CATEGORY@Creditor;CLAIM #@123'
    When I select Participant Type as 'Existing Claimant'
	Then I search claim 'SEARCH CLAIM / CREDITOR NAME@ALBAN TRACTOR CO., INC.'
	Then I input codesvalues information 'STATUS@Valid To Pay;OBJECTION CODE@Duplicate;UTC CODE@2100 Other Trustee'
	Then I input codesvalues Amounts information 'SCHEDULED AMOUNT@100;CLAIMED AMOUNT@200;ALLOWED AMOUNT@300;RESERVED AMOUNT@400'
	Then I input Payment Options & Additional Creditor Info 'CREDITOR ACCOUNT #@123456;CHECK DESCRIPTION@DESCRPTION;DATE FILED@01/30/19;AMENDS@TEST;VERSION@12;AMENDED BY@TEST;AMENDED VERSION@12'
	And I input Payment Options & Additional Creditor Checkboxes info 'Non-Compensible@YES;Exclude From UFR@YES;Non-discharged@YES;Reaffirmed@YES'
	And I input Notes information 'CLAIMS REGISTER NOTE@TEST;INTERNAL CLAIM NOTE@NOTE2;OBJECTION NOTES@NOTE3;RETAINER NOTES FOR TFR@NOTE4'
	When I save claim
	Then I SignOut from the Unity Application

@US199848
Scenario:004- Add Claim:New claimant-Individual
	Given I enter to Claims page as superuser
	When I click on Add Claim
	Then I see subheader as 'Add Claim' 	
	Then I input case/debtor details as 'CASE # / DEBTOR NAME@12-22319 / MIGU;CATEGORY@Creditor;CLAIM #@123'
    When I select Participant Type as 'New Claimant'
	When I select Participant Type as 'Individual'
	Then I input details as 'TITLE@Miss;FIRST NAME@PAUL;MIDDLE NAME@KEVIN;LAST NAME@BR;GENDER@Male;STATE BAR ID@56780;SSN@123-45-6789;DRIVER'S LICENSE@9898123456'
	And I input Contact details as 'EMAIL@aeries123gmail.com;Address@TELANGANA;PHONE@9912053369;City@Chennai;State / Province@AL;Zip@500055'	      	      			  
	Then I input codesvalues information 'STATUS@Superseded;OBJECTION CODE@Allow as Tardy;UTC CODE@2300 Bond Payments'
	Then I input codesvalues Amounts information 'SCHEDULED AMOUNT@1000;CLAIMED AMOUNT@2000;ALLOWED AMOUNT@3000;RESERVED AMOUNT@4000'
	Then I input Payment Options & Additional Creditor Info 'CREDITOR ACCOUNT #@123456;CHECK DESCRIPTION@DESCRPTION;DATE FILED@01/30/19;AMENDS@ADDCLAIM;VERSION@12;AMENDED BY@ADDCLAIM;AMENDED VERSION@20'
	And I input Payment Options & Additional Creditor Checkboxes info 'Non-Compensible@YES;Exclude From UFR@YES;Non-discharged@YES;Reaffirmed@YES'
	And I input Notes information 'CLAIMS REGISTER NOTE@ADDCLAIM;INTERNAL CLAIM NOTE@ADDCLAIM;OBJECTION NOTES@ADDCLAIM;RETAINER NOTES FOR TFR@ADDCLAIM'
	When I save claim
	Then I SignOut from the Unity Application

@US199848
Scenario:005- Add Claim:New claimant-Corporation
	Given I enter to Claims page as superuser
	When I click on Add Claim
	Then I see subheader as 'Add Claim' 	
	Then I input case/debtor details as 'CASE # / DEBTOR NAME@12-22319 / MIGU;CATEGORY@Wage Claim;CLAIM #@555'
    When I select Participant Type as 'New Claimant'
	When I select Participant Type as 'Corporation'
	Then I input details as 'DISPLAY NAME@LOUIS;STATE BAR ID@12345;TAX ID@12-3456789'
	Then I input Contact details as 'EMAIL@aeries123@gmail.com;Address@Mumbai;PHONE@9505616939;City@Mumbai;State / Province@AL;Zip@507111'	      	      			  
	Then I input codesvalues information 'STATUS@Valid To Pay;OBJECTION CODE@Duplicate;UTC CODE@2100 Other Trustee'
	Then I input codesvalues Amounts information 'SCHEDULED AMOUNT@900;CLAIMED AMOUNT@100;ALLOWED AMOUNT@200;RESERVED AMOUNT@600'
	Then I input Payment Options & Additional Creditor Info 'CREDITOR ACCOUNT #@123456;CHECK DESCRIPTION@DESCRPTION;DATE FILED@01/30/19;AMENDS@TEST;VERSION@13;AMENDED BY@TEST;AMENDED VERSION@14'
	And I input Payment Options & Additional Creditor Checkboxes info 'Non-Compensible@YES;Exclude From UFR@YES;Non-discharged@YES;Reaffirmed@YES'
	And I input Notes information 'CLAIMS REGISTER NOTE@NEWCLAIM;INTERNAL CLAIM NOTE@NEWCLAIM;OBJECTION NOTES@NEWCLAIM;RETAINER NOTES FOR TFR@NEWCLAIM'
	When I save claim
	Then I SignOut from the Unity Application

@US219897
Scenario:006- Edit Claim
	Given I enter to Claims page as superuser
	When I click on Edit Claim	      
    Then I input case/debtor details as 'CATEGORY@Investor;CLAIM #@123'
	Then I input codesvalues information 'STATUS@Withdrawn;OBJECTION CODE@Allow as Tardy;UTC CODE@3711 Appraiser forTrustee Fees'
	Then I input codesvalues Amounts information 'SCHEDULED AMOUNT@5000;CLAIMED AMOUNT@1000;ALLOWED AMOUNT@2000;RESERVED AMOUNT@6000'
	Then I input Payment Options & Additional Creditor Info 'CREDITOR ACCOUNT #@90876;CHECK DESCRIPTION@editclaim;DATE FILED@01/30/19;AMENDS@editclaim;VERSION@10;AMENDED BY@editclaim;AMENDED VERSION@11'
	And I input Payment Options & Additional Creditor Checkboxes info 'Non-Compensible@YES;Exclude From UFR@YES;Non-discharged@YES;Reaffirmed@YES'
	And I input Notes information 'CLAIMS REGISTER NOTE@editclaim;INTERNAL CLAIM NOTE@editclaim;OBJECTION NOTES@editclaim;RETAINER NOTES FOR TFR@editclaim'
	When I save claim
	Then I SignOut from the Unity Application

@US217825
Scenario:007- Claims:Case Level-Claims ADD
Given I enter to Unity Login page
Given I enter to Claims page as superuser
And I see the Search box under All Cases Section
	      When I Enter '99-11188' On The Universal Search Section Input
          And I Click on the Case Result '99-11188'
		      Then verify the count on Grid
          When I click on Add Claim	        
	          Then I input case/debtor details as 'CASE # / DEBTOR NAME@12-22319 / MIGU;CATEGORY@Wage Claim;CLAIM #@555'
        When I select Participant Type as 'New Claimant'
	    And I select Participant Type as 'Corporation'
		     Then I input Display name as 'LOUIS9100'
	         Then I input details as 'STATE BAR ID@12345;TAX ID@12-3456789'
			And I input Contact details as 'EMAIL@aeries123@gmail.com;Address@Mumbai;PHONE@9505616939;City@Mumbai;Zip@507111'
			And I enter state as 'AL'      	      			  
	         And I input codesvalues information 'STATUS@Valid To Pay;OBJECTION CODE@Duplicate;UTC CODE@2100 Other Trustee'
			 And I input codesvalues Amounts information 'SCHEDULED AMOUNT@900;CLAIMED AMOUNT@100;ALLOWED AMOUNT@200;RESERVED AMOUNT@600'
			 And I input Payment Options & Additional Creditor Info 'CREDITOR ACCOUNT #@123456;CHECK DESCRIPTION@DESCRPTION;DATE FILED@01/30/19;AMENDS@TEST;VERSION@13;AMENDED BY@TEST;AMENDED VERSION@14'
			 And I input Payment Options & Additional Creditor Checkboxes info 'Non-Compensible@YES;Exclude From UFR@YES;Non-discharged@YES;Reaffirmed@YES'
	         And I input Notes information 'CLAIMS REGISTER NOTE@new claim;INTERNAL CLAIM NOTE@new claim;OBJECTION NOTES@new claim;RETAINER NOTES FOR TFR@new claim'      
	  When I save claim
	  Then verify the after count on Grid
	  Then I SignOut from the Unity Application

@US217826
Scenario:008- Claims:Case Level-Claims Edit
Given I enter to Unity Login page
Given I enter to Claims page as superuser
And I see the Search box under All Cases Section
	      When I Enter '17-90000' On The Universal Search Section Input
          And I Click on the Case Result '17-90000'
          When I click on Edit Claim	      
	            Then I input case/debtor details as 'CATEGORY@Investor;CLAIM #@123'
	            Then I input codesvalues information 'STATUS@Withdrawn;OBJECTION CODE@Allow as Tardy;UTC CODE@3711 Appraiser forTrustee Fees'
			    Then I input codesvalues Amounts information 'SCHEDULED AMOUNT@5000;CLAIMED AMOUNT@1000;ALLOWED AMOUNT@2000;RESERVED AMOUNT@6000'
			    Then I input Payment Options & Additional Creditor Info 'CREDITOR ACCOUNT #@90876;CHECK DESCRIPTION@editclaim;DATE FILED@01/30/19;AMENDS@editclaim;VERSION@10;AMENDED BY@editclaim;AMENDED VERSION@11'
			    And I input Payment Options & Additional Creditor Checkboxes info 'Non-Compensible@YES;Exclude From UFR@YES;Non-discharged@YES;Reaffirmed@YES'
	            And I input Notes information 'CLAIMS REGISTER NOTE@editclaim;INTERNAL CLAIM NOTE@editclaim;OBJECTION NOTES@editclaim;RETAINER NOTES FOR TFR@editclaim'
	      When I save claim
	        Then I SignOut from the Unity Application

@US235859
Scenario: 009_Claims - SaveInLineEdit and Verify
	Given I enter to Claims page as superuser
	And I click on filter button
	When I enter Creditor 'JEANNE'
	And I click on close
	And I click on Arrow Icon to see all sections
	Then I edit 'CLAIMED', '13', '60000'
	And I edit 'ALLOWED', '14', '20000'
	#And I edit 'CLAIM #', '0', '168'
	And I edit 'SEQUENCE', '11', '75'
	#And I edit 'SCHEDULED', '19', '10000'
	#And I edit 'RESERVED', '22', '15000'
	Then the 'CLAIMED', '13' should contain '$60,000.00'
	And the 'ALLOWED', '14' should contain '$20,000.00'
	#And the 'CLAIM #', contains '168'
	#And the 'SEQUENCE', contains '75'
	#And the 'SCHEDULED', contains '$10,000.00'
	#And the 'RESERVED', contains '$15,000.00'
	Then I SignOut from the Unity Application

@US235859
Scenario: 010_Claims - CancelInLineEdit and Verify
	Given I enter to Claims page as superuser
	And I click on filter button
	When I enter Creditor 'JEANNE'
	And I click on close
	Then I edit the 'CLAIMED', '13', '67890'
	And I edit the 'ALLOWED', '14', '34560'
	And I edit the 'CLAIM #', '5', '345'
	And I edit the 'SEQUENCE', '11', '69'
	And I edit the 'SCHEDULED', '0', '34000'
	And I edit the 'RESERVED', '0', '12345'
	Then the 'CLAIMED', '13' should contain '$60,000.00'
	And the 'ALLOWED', '14' should contain '$20,000.00'
	And the 'CLAIM #', contains '55'
	And the 'SEQUENCE', contains '75'
	#And the 'SCHEDULED', contains '$744.00'
	#And the 'RESERVED', contains '$855.00'
	Then I SignOut from the Unity Application

@US235859
	# It's an invalid scenario as we cannot view claims page with view permissions.
	#Scenario: 011_Claims - Verify InLineEdit View only
	#Given I enter to Claims page as user AutomationView with password Welcome456Epiq! and office crose
	#And I click on filter button
	#When I enter Creditor 'JEANNE'
	#And I click on close
	#Then I SignOut from the Unity Application


@US255998@US255998@US264012
Scenario: 012_Claims - Export List Cancel Verification-Export Permission
		Given I enter to Claims page as superuser
		When I click On the EXPORT BUTTON
		Then Validate the Text in the pop up.
		And Click on the CANCEL BUTTON on the pop up
		And I validate the Pop Up is not appearaing
		And I SignOut from the Unity Application

@US255998@US227039@US256009@US249370@US266867@US266866
Scenario: 013_Claim - EXPORT List button Disabled-View Permission
		Given I enter to Unity Login page
		Given I enter to Claims page as user vandita1 with password Welcome444Epiq! and office crose
		Then Validate that export button is disabled
		And I SignOut from the Unity Application

@US256011
Scenario: 014 - Claim Page-Delete funtionality verification in Claim page
	 Given I enter to Claims page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I can select all option in the header
	 And I can Deselect all option in the header
     And I can select first record in dso page
	 Then I can click on delete button in the Claims Page
	 Then verify the Text in the pop up as 'Cannot delete if any selected claim has linked payments. Select claims without payments and try again.'
	 And I click on Delete button in pop up
	 Then I SignOut from the Unity Application

@US256011
Scenario: 015 - Claim Page-Delete funtionality verification in Claim page with out selecting the record
	 Given I enter to Claims page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I can see delete button is not clickcable until select the case
	 Then I SignOut from the Unity Application

@US256011
Scenario: 016 - Claim Page-Cancel funtionality verification in Claim page
	 Given I enter to Claims page as superuser
     And I can select first record in Claim page
	 Then I can click on delete button in the Claim Page
	 Then verify the Text in the pop up as 'Confirm that you want to delete the selected claims.'
	 And I click on Cancel button in pop up
	 Then I SignOut from the Unity Application

@US256006@US247346
Scenario: 017 - Claim Page-View Payments Linked to Claim - On Claim List
	 Given I enter to Claims page as superuser
	 When I click on PAID column '$0.00'
	 Then verify the label 'Transactions Linked to Claim'
	 Then verify the columns from '3' to '7' displayed on 'modal-body' as 'ACCOUNT #;TYPE;DATE;NAME;AMOUNT' in Transactions Linked to Claim page
	 Then verify the notification message 'No transactions linked to this claim.'
     Then I click 'CLOSE' Button
	 Then I SignOut from the Unity Application

@US256006@US247346
Scenario: 018 - Claim Page-View Payments Linked to Claim - On Claim List
	 Given I enter to Claims page as superuser
	 When I click on filter button
	 When I enter Creditor 'BERNHEIM'
	 And I select Class 'Secured'
	 And I click on close
	 When I click on PAID column '$120,000,000.00'
	 Then verify the label 'Transactions Linked to Claim'
	 Then verify the columns from '3' to '7' displayed on 'modal-body' as 'ACCOUNT #;TYPE;DATE;NAME;AMOUNT' in Transactions Linked to Claim page
	 Then click on expand symbol and verify the columns as 'BANK'
     Then I click 'CLOSE' Button
	 Then I SignOut from the Unity Application

@US256008@US249367
Scenario: 019 - Claim Page-View Payments Linked to Claim - On Edit Claim List
	 Given I enter to Claims page as superuser
	 When I click on filter button
	 When I enter Creditor 'BERNHEIM'
	 And I select Class 'Secured'
	 And I click on close
	 When I click on PAID column '$120,000,000.00'
	 Then verify the label 'Transactions Linked to Claim'
	 Then verify the columns from '3' to '7' displayed on 'modal-body' as 'ACCOUNT #;TYPE;DATE;NAME;AMOUNT' in Transactions Linked to Claim page
	 Then 'AMOUNT' should be able sorted
	 Then click on expand symbol and verify the columns as 'BANK'
     Then I click 'CLOSE' Button
	 Then click Edit Icon
	 Then I SignOut from the Unity Application

@US259310
Scenario: 020 - Schedule to Claim Reconciliation Page-All Cases
	 Given I enter to Schedule to Claim Reconciliation page as superuser
	 Then verify the page header 'Schedule to Claim Management'
	 Then Schedule to Claim Management Breadcrumbs should be displayed
	 Then I see the fields in Schedule to Claim Management page as CaseNumber 'CASE #', Debtor 'DEBTOR', Claims 'CLAIMS',Schedules 'SCHEDULES',Unreconciled 'UNRECONCILED',Status 'STATUS',Case 'CASE'
	 Then verify the Schedule to Claim Management page UI count
	 Then verify the Schedule to Claim Management page count from Database
	 Then I SignOut from the Unity Application

@US259310
Scenario: 021 - Schedule to Claim Reconciliation Page-Specific Case
	 Given I enter to Schedule to Claim Reconciliation page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '01-21039' On The Universal Search Section Input
     And I Click on the Case Result '01-21039'
	Then Schedule to Claim Management Breadcrumbs should be displayed
    Then I see the fields in Schedule to Claim Management page as CaseNumber 'CASE #', Debtor 'DEBTOR', Claims 'CLAIMS',Schedules 'SCHEDULES',Unreconciled 'UNRECONCILED',Status 'STATUS',Case 'CASE'
    Then I SignOut from the Unity Application

@US259310
Scenario: 022 - Schedule to Claim Reconciliation Page- Filter options
	 Given I enter to Schedule to Claim Reconciliation page as superuser
	 And I click on filter in Schedule to Claim Reconciliation page
	 Then I verify default data in filter options as AllClaimsReconciled 'No', AssetStatus 'Asset', CaseStaus 'All'
	 Then I verify data in filter options in Schedule to Claim Reconciliation page
	 Then I select  AllClaimsReconciled 'Yes', AssetStatus 'All', CaseStaus 'Open'
	 Then I verify Table Header when AllClaimsReconciled 'Yes'
	 Then I verify Table Header when AllClaimsReconciled as 'No'
	 Then I verify message when there are no results to display in the grid 'No results to display per selections'
	 Then I click Reset in filter
	 Then I SignOut from the Unity Application

@US259310
Scenario: 023 - Schedule to Claim Reconciliation Page- Without Permissions - All cases
	 Given I enter to Schedule to Claim Reconciliation page as user AutomationView2 with password Welcome123Epiq! and office crose
	 Then I verify message 'Please contact your Office Administrator and request permission to view this content. You are missing one of the following permissions: Schedules Reconcile'
	 Then I SignOut from the Unity Application

@US259310
Scenario: 024 - Schedule to Claim Reconciliation Page- Without Permissions - Specific case
	 Given I enter to Schedule to Claim Reconciliation page as user AutomationView2 with password Welcome123Epiq! and office crose
	 And I see the Search box under All Cases Section
	 When I Enter '01-21039' On The Universal Search Section Input
     And I Click on the Case Result '01-21039'
	 Then I verify message 'Please contact your Office Administrator and request permission to view this content. You are missing one of the following permissions: Schedules Reconcile'
	 Then I SignOut from the Unity Application

@US266866@US#266865@US#273999@US#270469
#Scenario:025- Claims:Case Level-Claims Edit- Verify Document
#	Given I enter to Unity Login page
#	Given I enter to Claims page as superuser
#	And I see the Search box under All Cases Section
#	When I Enter '17-90000' On The Universal Search Section Input
#	And I Click on the Case Result '17-90000'
#	When I click on Edit Claim	      
#	Then I click 'LINK CASE DOCUMENTS'
#	When I select document
#	Then I click LINK in Link Case Documents page
#	When I save claim
#	Then I click on Document view
#	And I see the document details 'Microsoft Word Document'
#	Then I SignOut from the Unity Application

@US266867@US#266865
Scenario:026- Claims:Case Level-Claims Edit- Delete Document
	Given I enter to Unity Login page
	Given I enter to Claims page as superuser
	And I see the Search box under All Cases Section
	When I Enter '17-90000' On The Universal Search Section Input
	And I Click on the Case Result '17-90000'
	When I click on Edit Claim	 
	And I click on delete button
	When I save claim
	Then I SignOut from the Unity Application

@US#266884@US#266885
Scenario: 027 - Schedule to Claim Reconciliation Page- Reconcilation
	 Given I enter to Schedule to Claim Reconciliation page as superuser
     And I see the Search box under All Cases Section
	 When I Enter '01-21039' On The Universal Search Section Input
     And I Click on the Case Result '01-21039'
	 And I Click on Unreconciled option
	 When I click on Filter on Banking Activity page
     Then I click on close button
	 When I click on Radio Button of schedules and claims
	 And I Add link and unlink transactions
     Then I SignOut from the Unity Application

@US266886
Scenario: 028 - Schedule to Claim Reconciliation Page- Link and Unlink Transactions
 Given I enter to Schedule to Claim Reconciliation page as superuser
 Then I click on Unreconciled link for case number '01-21039'
 And I select Schedules in Claim Reconciliation page    
 And I verify Schedules Link button and X button at the bottom of the screen 
 And I select Claims in Claim Reconciliation page    
 And I verify Claims Link button and X button at the bottom of the screen 
 Then I select schedule and claim in Claim Reconciliation page
 And I click LINK button in Claim Reconciliation page
 And I click UNLINK button in Claim Reconciliation page
 Then I SignOut from the Unity Application
	    