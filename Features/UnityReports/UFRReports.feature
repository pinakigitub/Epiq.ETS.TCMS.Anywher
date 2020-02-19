@Regression	
@ReactJS
Feature: UFRReports
	Generate Trustee Reports.

@US279721@US293867@US274008@US274009@US279720@US279719@US293869@US293868
Scenario Outline: 001-UFR-Generate Reprt - PDF Format
	Given I enter to Reports page as user UFRReports with password Welcome456Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '10-22769' On The Universal Search Section Input
	And I Click on the Case Result '10-22769'
	Given I Go to '<reportName>'
	Then verify the report header '<headerName>'
	Then verify the report sub header '<subHeader>'
	Then click '<Button>'
	And click 'REPORT QUEUE'
	And I search report '<report>' under Report Queue
	And I '<Type>' report '<report>' in queue with current date 
	And click on ReportQueue close button
	Given I Go to 341 Meeting page
	When I click on the View 341_Meeting date link
	And I Click on View button on Meeting management
	When I Click on Case Documents Tab Meeting View Page
	Then I click on Expand button 341 Meeting
	Then I select All Cases in the Global Case Navigation
	Given I Go to Import Assets page
	When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on View Documents Tab are 'DOC #' 'SOURCE' and 'DESCRIPTION'
	Then I SignOut from the Unity Application
Examples: 
	   | reportName                        | headerName							| subHeader                                                                                                                              | report                      | Button          | Type     |
	   | Trustee Distribution Report (TDR) | Trustee Distribution Report (TDR)  | Provides the final account of the administration of the estate.                                                                        | Trustee Distribution Report | GENERATE REPORT | Download |
	   | Notice of Final Report (NFR)      | NOTICE OF FINAL REPORT (NFR)       | Provides the final report and applications for compensation.                                                                           | Notice of Final Report      | GENERATE REPORT | Download |
	  

@US279718
Scenario Outline: 002-UFR-Save to Queue- XML Format
	Given I enter to Reports page as user UFRReports with password Welcome456Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '10-22769' On The Universal Search Section Input
	And I Click on the Case Result '10-22769'
	Given I Go to '<reportName>'
	Then verify the report header '<headerName>'
	Then verify the report sub header '<subHeader>'
	And I click on Checkbox for Export as XML
	Then click '<Button>'
	And click 'REPORT QUEUE'
	And I search report '<report>' under Report Queue
	And I '<Type>' report '<report>' in queue with current date 
	And click on ReportQueue close button
	Then I SignOut from the Unity Application

Examples: 
		| reportName                        | headerName						 | subHeader                                                                                                                              | report                      | Button          | Type      |
		| Trustee Distribution Report (TDR) | Trustee Distribution Report (TDR)  | Provides the final account of the administration of the estate.                                                                        | Trustee Distribution Report | SAVE TO QUEUE   |  Delete   |
		| Notice of Final Report (NFR)      |  NOTICE OF FINAL REPORT (NFR)      |Provides the final report and applications for compensation.                                                                            | Notice of Final Report      | SAVE TO QUEUE   |  Delete   |


@US293913@US293871@US293866@US293870
Scenario: 003-TFR Inline Date edit functionality and banking service
Given I enter to Reports page as user UFRReports with password Welcome456Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '10-22769' On The Universal Search Section Input
	And I Click on the Case Result '10-22769'
	Given I Go to 'Trustee Final Report (TFR)'
	Then verify the report header 'Trustee Final Report (TFR)'
	Then Click on Include Claim Register button
	Then I inline date fields under Case Dates section
	Then user click 'GENERATE REPORT'
	Then user Verify the pop header as 'Stop Bank Fees confirmation'
	Then user verify the pop up body message as 'Would you like to activate the date to stop bank service fees for this case?'
	Then user click 'NO'
		And click 'REPORT QUEUE'
	And I search report 'Trustee Final Report' under Report Queue
	And click on ReportQueue close button
	Given I Go to 341 Meeting page
	When I click on the View 341_Meeting date link
	And I Click on View button on Meeting management
	When I Click on Case Documents Tab Meeting View Page
	Then I click on Expand button 341 Meeting
	Then I select All Cases in the Global Case Navigation
	Given I Go to Import Assets page
	When I Click on one AssetToImport link of listed cases
	Then I see the Visible headers on View Documents Tab are 'DOC #' 'SOURCE' and 'DESCRIPTION'
	Then I SignOut from the Unity Application

@US293872@US293911
Scenario Outline: 004-UFR-Trustee Compensation
Given I enter to Reports page as user UFRReports with password Welcome456Epiq! and office Jwalsh
	Given I Go to '<reportName>'
	Then verify the report header '<headerName>'
	Then Enter the Trustee Compensation values and freeze the compensation
	Then I SignOut from the Unity Application
Examples:
		| reportName                        | headerName						 |
		| Trustee Final Report (TFR)        | Trustee Final Report (TFR)         |
		| Notice of Final Report (NFR)      |  NOTICE OF FINAL REPORT (NFR)      |

@US293910
Scenario: 005-TFR Trustee Compensation error message validation
Given I enter to Reports page as user UFRReports with password Welcome456Epiq! and office Jwalsh
	And I see the Search box under All Cases Section
	When I Enter '15-70235' On The Universal Search Section Input
	And I Click on the Case Result '15-70235'
	Given I Go to 'Trustee Final Report (TFR)'
	Then verify the report header 'Trustee Final Report (TFR)'
	Then Click on Include Claim Register button
	Then I inline date fields under Case Dates section
	Then user click 'GENERATE REPORT'
	Then validate the Compensation Section error message as 'Case does not have a Trustee Compensation claim.'
	Then I SignOut from the Unity Application