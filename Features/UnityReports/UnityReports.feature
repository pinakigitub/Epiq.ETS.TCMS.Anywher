@Regression	
@ReactJS	
@Reports

Feature: Reports
	verifying Reports functionality and generation of reports

@US229031
Scenario:001: Reports-Form1 Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Form 1'
Then verify the report header 'Form 1'
Then verify the report sub header 'Displays the asset details for selected cases.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then select option as 'Search Add'
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '17-10012 / 295TestRecon3, KNRAJ' for 'Search Add'
Then select 'ORIENTATION' as 'Portrait' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US229031
Scenario:002: Reports-Form1 Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Form 1'
Then verify the report header 'Form 1'
Then verify the report sub header 'Displays the asset details for selected cases.'
Then select option as 'Search Add'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '17-10010' for 'Search Add'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then select 'ORIENTATION' as 'Landscape' 
Then click 'SAVE TO QUEUE'
#Then close notification
#Then click 'REPORT QUEUE'
#Then I search report 'Form 1' under Report Queue
#Then I 'Delete' report 'Form 1' in queue with current date 
#Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US228239
Scenario:003: Reports-341 Calendar Generate Report
Given I enter to Reports page as superuser
Given I Go to '341 Calendar'
Then verify the report header '341 Calendar'
Then verify the report sub header '341 Calendar'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ORDER BY' as '341 meeting date time, case #' 
Then select 'SSN OPTION' as 'Masked' 
Then select 'CALENDAR DATE' as '12/12/2018' 
Then select 'TIME FRAME' as '06:30 AM' 
Then select Report Options To Include as 'Trustee Notes'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US228239
Scenario:004: Reports- 341 Calendar Report- Save to Queue
Given I enter to Reports page as superuser
Given I Go to '341 Calendar'
Then verify the report header '341 Calendar'
Then verify the report sub header '341 Calendar'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Baltimore' 
Then select 'ORDER BY' as '341 meeting date time, case #' 
Then select 'SSN OPTION' as 'Masked' 
Then select 'CALENDAR DATE' as '12/12/2018' 
Then select 'TIME FRAME' as '06:30 AM' 
Then select Report Options To Include as 'Trustee Notes'
Then click 'SAVE TO QUEUE'
Then click 'REPORT QUEUE'
Then I search report '341 Calendar Report' under Report Queue
Then I 'Delete' report '341 Calendar Report' in queue with current date 
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US229029
Scenario:005: Reports- Case Import Report- Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Cases Imported'
Then verify the report header 'Cases Imported'
Then verify the report sub header 'List cases imported or added for the specified date range.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'ORDER BY' as 'Debtor Name' 
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US229027
Scenario:006: Reports- 341 Post Meeting Outcome Report - Save to Queue
Given I enter to Reports page as superuser
Given I Go to '341 Post Meeting Outcome'
Then verify the report header '341 Post Meeting Outcome'
Then verify the report sub header '341 Calendar - Post Meeting Outcome'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ORDER BY' as '341 meeting date time, case #' 
Then select 'SSN OPTION' as 'Masked' 
Then select 'CALENDAR DATE' as '12/12/2018' 
Then select 'TIME FRAME' as '06:30 AM' 
And I click 'SAVE TO QUEUE'
Then click 'REPORT QUEUE'
Then I SignOut from the Unity Application
	
@US229030
Scenario:007: Reports-Deposit Transmittal Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Deposit Transmittal'
Then verify the report header 'Deposit Transmittal'
Then verify the report sub header 'List deposits for the specified date range.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'BANK' as 'Bank of America' 
Then select option as 'Deposit print date'
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then click 'GENERATE REPORT'
Then click 'REPORT QUEUE'
Then I search report 'Deposit Transmittal' under Report Queue
Then I 'Download' report 'Deposit Transmittal Monthly Report' in queue with current date 
Then I SignOut from the Unity Application

@US229030
Scenario:008: Reports-Deposit Transmittal Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Deposit Transmittal'
Then verify the report header 'Deposit Transmittal'
Then verify the report sub header 'List deposits for the specified date range.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'BANK' as 'Bank of America' 
Then select option as 'Deposit print date'
Then select date 'START DATE' as '02/02/17'
Then select date 'END DATE' as '06/30/20'
Then click 'SAVE TO QUEUE'
Then click 'REPORT QUEUE'
Then I search report 'Deposit Transmittal' under Report Queue
Then I 'Delete' report 'Deposit Transmittal Monthly Report' in queue with current date 
Then I SignOut from the Unity Application

@US229026
Scenario:009: Reports-341 Docket Generate Report
Given I enter to Reports page as superuser
Given I Go to '341 Docket'
Then verify the report header '341 Docket'
Then verify the report sub header '341 Docket'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ORDER BY' as '341 meeting date time, case #' 
Then select 'CALENDAR DATE' as '12/12/2018' 
Then select 'TIME FRAME' as '08:30 AM'
Then select Report Options To Include as 'Exclude future continued meetings' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application


@US229026
Scenario:010: Reports-341 Docket Save to Queue
Given I enter to Reports page as superuser
Given I Go to '341 Docket'
Then verify the report header '341 Docket'
Then verify the report sub header '341 Docket'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'All Divisions' 
Then select 'ORDER BY' as '341 meeting date time, case #' 
Then select 'CALENDAR DATE' as '12/12/2018' 
Then select 'TIME FRAME' as '08:30 AM'
Then select Report Options To Include as 'Exclude future continued meetings' 
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application


@US209028
Scenario:011: Reports-Form2 Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Form 2'
Then verify the report header 'Form 2'
Then verify the report sub header 'Form 2 displays the financial ledger for each case with a running balance.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then select option as 'Manual Add'
Then select date 'START DATE' as '05/28/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '02-06699' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click Clear All to clear the cases data in Report Parameters Grid
Then select Search Add
Then select date 'START DATE' as '05/28/17'
Then select date 'END DATE' as '05/31/19'
Then input case number as '02-06699'
Then verify the added cases information in Report Parameters Grid
Then select Interim TimePeriod
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then select 'ORIENTATION' as 'Portrait' 
Then click 'GENERATE REPORT'
Then click 'REPORT QUEUE'
Then I search report 'Form 2' under Report Queue
Then I 'Download' report 'Form 2' in queue with current date 
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US209028
Scenario:012: Reports-Form2 - Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Form 2'
Then verify the report header 'Form 2'
Then verify the report sub header 'Form 2 displays the financial ledger for each case with a running balance.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then select option as 'Search Add'
Then select date 'START DATE' as '05/28/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '17-30010 / 29312AB KNRAJ' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then select 'ORIENTATION' as 'Portrait' 
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application


@US259306
Scenario:013: Reports-Form3 Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Form 3'
Then verify the report header 'Form 3'
Then verify the report sub header 'Form 3 displays a list of active cases and the status of each case.'
Then select option as 'Search Add'
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '17-10010' for 'Search Add'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then select 'ORIENTATION' as 'Portrait' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US259306
Scenario:014: Reports-Form3 Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Form 3'
Then verify the report header 'Form 3'
Then verify the report sub header 'Form 3 displays a list of active cases and the status of each case.'
Then select option as 'Search Add'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '17-10010' for 'Search Add'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then select 'ORIENTATION' as 'Landscape' 
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US229472@US229028
Scenario:015: Reports-341 Schedule Data Review Report - Save to Queue And ReportQueue Pagination
Given I enter to Reports page as superuser
Given I Go to '341 Schedule Data Review'
Then verify the report header '341 Schedule Data Review'
Then verify the report sub header 'Provides Schedule details for selected cases'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ORDER BY' as '341 meeting date time, case #' 
Then select 'TIME FRAME' as '08:00 AM'
#Then click 'SAVE TO QUEUE'
#Then close notification
Then click 'REPORT QUEUE'
When I Select the PageSize as 50 under Pagination Section
Then I see the same number of records as per the selected PageSize '50'
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US229028
Scenario:016: Reports-341 Schedule Data Review Report - Generate Report
Given I enter to Reports page as superuser
Given I Go to '341 Schedule Data Review'
Then verify the report header '341 Schedule Data Review'
Then verify the report sub header 'Provides Schedule details for selected cases'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'All Divisions' 
Then select 'ORDER BY' as 'Sequence #' 
Then select 'TIME FRAME' as '06:00 AM'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US266889
Scenario:017: Reports-Bond Status Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Bond Status'
Then verify the report header 'Bond Status'
Then verify the report sub header 'Show the estate balance and bond information for a specified date.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select 'BOND STATUS' as 'Individual Bond'
Then select date 'BALANCE AS OF' as '06/13/18'
Then select date 'EXCLUDE CASES CLOSED BEFORE' as '06/30/18'
Then select 'ORDER BY' as 'Case #'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US266889
Scenario:018: Reports-Bond Status - Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Bond Status'
Then verify the report header 'Bond Status'
Then verify the report sub header 'Show the estate balance and bond information for a specified date.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select 'BOND STATUS' as 'Individual Bond'
Then select date 'BALANCE AS OF' as '06/13/18'
Then select date 'EXCLUDE CASES CLOSED BEFORE' as '06/30/18'
Then select 'ORDER BY' as 'Case #'
Then input PERCENTOFMARGIN as '50'
Then click option as 'Exclude Zero Balance Cases (by as of date)'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US264010
Scenario:019: Reports-Staled Dated Check Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Stale Dated Check'
Then verify the report header 'Stale Dated Check'
Then verify the report sub header 'This report will list Stale Dated Checks per trustee and case.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then input DAYSOUTSTANDING as '10'
And I enter 'CASE # / DEBTOR NAME' as '01-01929'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US264010
Scenario:020: Reports-Staled Dated Check - Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Stale Dated Check'
Then verify the report header 'Stale Dated Check'
Then verify the report sub header 'This report will list Stale Dated Checks per trustee and case.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select date 'AS OF DATE' as '06/13/18'
And I enter 'CASE # / DEBTOR NAME' as '01-01929'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US264008
Scenario:021: Reports-WagesAndDeduction - Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Wages & Deduction Summary'
Then verify the report header 'Wages & Deduction Summary'
Then verify the report sub header 'Provides details of payments for case.'
And I enter 'CASE # / DEBTOR NAME' as '17-00001'
Then select date 'START DATE' as '06/06/18'
Then select date 'END DATE' as '01/07/19'
Then click 'SAVE TO QUEUE'
Then click 'REPORT QUEUE'
Then I search report 'Wages & Deduction Summary' under Report Queue
Then I 'Print' report 'Wages & Deduction Summary' in queue with current date 
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US264008
Scenario:022: Reports-WagesAndDeduction - Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Wages & Deduction Summary'
Then verify the report header 'Wages & Deduction Summary'
Then verify the report sub header 'Provides details of payments for case.'
And I enter 'CASE # / DEBTOR NAME' as '17-00001'
Then select date 'START DATE' as '06/06/18'
Then select date 'END DATE' as '01/07/19'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US259302
Scenario:023: Reports-Form1 Paperless Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Form 1 - Paperless'
Then verify the report header 'Form 1 - Paperless'
Then verify the report sub header 'Form 1 displays the assets in each case and their remaining values in Excel.'
Then select option as 'Manual Add'
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '17-10010' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click Clear All to clear the cases data in Report Parameters Grid
Then input case information as '17-10010' for 'Manual Add'
Then click 'ADD CASES'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US259302
Scenario:024: Reports-Form1 Paperless Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Form 1 - Paperless'
Then verify the report header 'Form 1 - Paperless'
Then verify the report sub header 'Form 1 displays the assets in each case and their remaining values in Excel.'
Then select option as 'Search Add'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '17-10010' for 'Search Add'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US259302
Scenario:025: Reports-Form1 Paperless Generate Report with Interim period
Given I enter to Reports page as superuser
Given I Go to 'Form 1 - Paperless'
Then verify the report header 'Form 1 - Paperless'
Then verify the report sub header 'Form 1 displays the assets in each case and their remaining values in Excel.'
Then select date 'START DATE' as '10/10/17'
Then select date 'END DATE' as '01/01/19'
Then click option as 'Include Cases with TDR dates'
Then click option as 'Include Cases with TFR dates'
Then click 'ADD CASES'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US248183
Scenario:026: Reports- AddCases Validation Message
Given I enter to Reports page as superuser
Given I Go to 'Form 1'
Then verify the report header 'Form 1'
Then verify the report sub header 'Displays the asset details for selected cases.'
Then select date 'START DATE' as '01/01/00'
Then select date 'END DATE' as '01/01/00'
Then click 'ADD CASES'
And Validate the message as 'No cases in date range'
Then I SignOut from the Unity Application

@US248182 @US248184
Scenario:027: Reports- SearchAdd- AddCases Validation Message 
Given I enter to Reports page as superuser
Given I Go to 'Form 1'
Then verify the report header 'Form 1'
Then verify the report sub header 'Displays the asset details for selected cases.'
Then select option as 'Search Add'
Then input case information as '17-10010' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then input case information as '17-10010' for 'Search Add'
Then message 'No matches found' should not be visible
And Validate the message as 'Case already selected'
Then I SignOut from the Unity Application


@US264011
Scenario:028: Reports-Stop Payment Tracking Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Stop Payment Tracking'
Then verify the report header 'Stop Payment Tracking'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
And I enter 'CASE # / DEBTOR NAME' as '01-01929'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US264011
Scenario:029: Reports-Stop Payment Tracking Report - Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Stop Payment Tracking'
Then verify the report header 'Stop Payment Tracking'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
And I enter 'CASE # / DEBTOR NAME' as '01-01929'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US229466
Scenario:030: Reports- Verify Create Report Center
Given I enter to Reports page as superuser
And I see Reports text center 'CREATE A REPORT' and sub text 'Select a report from the list to begin'
Then I see Reports List in Alphabetical Order
And I SignOut from the Unity Application

@US264009
Scenario:031: Reports- Receipt log Report-Save To Queue
Given I enter to Reports page as superuser
Given I Go to 'Receipt Log'
Then verify the report header 'Receipt Log'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select 'ORDER BY' as 'Date Received' 
Then select date 'LOGGED FROM' as '01/01/17'
Then select date 'LOGGED TO' as '01/01/19'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US229034
Scenario:032: Reports- DSO Report-DSO Initial Notice-Generate Report
Given I enter to Reports page as superuser
Given I Go to 'DSO Report'
Then verify the report header 'DSO Report'
Then verify the report sub header 'Create DSO Initial and Discharge Notices with envelopes.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE'
Then select 'DIVISION' as 'Greenbelt' 
Then select 'TASK TYPE' as 'DSO Initial Notice'
Then select 'STATUS' as 'Due'
Then click 'ADD CASES OF CURRENT STATUS'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
#Then close notification
Then I SignOut from the Unity Application


@US229034
Scenario:033: Reports- DSO Report-DSO Discharge Notice-Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'DSO Report'
Then verify the report header 'DSO Report'
Then verify the report sub header 'Create DSO Initial and Discharge Notices with envelopes.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select 'DIVISION' as 'Baltimore' 
Then select 'TASK TYPE' as 'DSO Discharge Notice'
Then select 'STATUS' as 'Done'
Then click 'ADD CASES OF CURRENT STATUS'
Then verify the added cases information in Report Parameters Grid
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US248186
Scenario:034: Reports-End Date Validation Message
Given I enter to Reports page as superuser
Given I Go to 'Form 1'
Then verify the report header 'Form 1'
Then verify the report sub header 'Displays the asset details for selected cases.'
Then select option as 'Manual Add'
Then select date 'START DATE' as '05/31/19'
Then select date 'END DATE' as '05/31/17'
And Validate the message as 'End date cannot be earlier than start date' 
Then I SignOut from the Unity Application

@US259302
Scenario:035: Reports-Form2 Paperless Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Form 2 - Paperless'
Then verify the report header 'Form 2 - Paperless'
Then verify the report sub header 'Form 2 displays the financial ledger for each case with a running balance in Excel.'
Then select option as 'Manual Add'
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '17-10010' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click Clear All to clear the cases data in Report Parameters Grid
Then input case information as '17-10010' for 'Manual Add'
Then click 'ADD CASES'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US259302
Scenario:036: Reports-Form2 Paperless Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Form 2 - Paperless'
Then verify the report header 'Form 2 - Paperless'
Then verify the report sub header 'Form 2 displays the financial ledger for each case with a running balance in Excel.'
Then select option as 'Search Add'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '17-10010' for 'Search Add'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'SAVE TO QUEUE'
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US259302
Scenario:037: Reports-Form2 Paperless Generate Report with Interim period
Given I enter to Reports page as superuser
Given I Go to 'Form 2 - Paperless'
Then verify the report header 'Form 2 - Paperless'
Then verify the report sub header 'Form 2 displays the financial ledger for each case with a running balance in Excel.'
Then select date 'START DATE' as '10/10/17'
Then select date 'END DATE' as '01/01/19'
Then click option as 'Include Cases with TDR dates'
Then click option as 'Include Cases with TFR dates'
Then click 'ADD CASES'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US259302
Scenario:038: Reports-Form3 Paperless Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Form 3 - Paperless'
Then verify the report header 'Form 3 - Paperless'
Then verify the report sub header 'Form 3 displays a list of active case and the status of each case in Excel.'
Then select option as 'Manual Add'
Then select date 'START DATE' as '05/31/17'
Then select date 'END DATE' as '05/31/19'
Then input case information as '17-10010' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click Clear All to clear the cases data in Report Parameters Grid
Then input case information as '17-10010' for 'Manual Add'
Then click 'ADD CASES'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'Asset' 
Then click 'GENERATE REPORT'
Then click 'REPORT QUEUE'
Then I search report 'Form 3 - Paperless' under Report Queue
Then I 'Download' report 'Form 3 - Paperless' in queue with current date 
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US259302
Scenario:039: Reports-Form3 Paperless Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Form 3 - Paperless'
Then verify the report header 'Form 3 - Paperless'
Then verify the report sub header 'Form 3 displays a list of active case and the status of each case in Excel.'
Then select option as 'Search Add'
Then select date 'START DATE' as '01/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '17-10010' for 'Search Add'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US259302
Scenario:040: Reports-Form3 Paperless Generate Report with Interim period
Given I enter to Reports page as superuser
Given I Go to 'Form 3 - Paperless'
Then verify the report header 'Form 3 - Paperless'
Then verify the report sub header 'Form 3 displays a list of active case and the status of each case in Excel.'
Then select date 'START DATE' as '10/10/17'
Then select date 'END DATE' as '01/01/19'
Then click option as 'Form 1 Notes'
Then click option as 'Debtor AKA/DBA'
Then click option as 'Form 3 Notes'
Then click 'ADD CASES'
Then select 'TRUSTEE' as 'CHERYL E. ROSE' 
Then select 'DIVISION' as 'Greenbelt' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270479
Scenario:041: Reports-Form1&2(BA) Generate Report with Interim period
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 1 & 2 (BA)'
Then verify the report header 'FORM 1 & 2 (BA)'
Then verify the report sub header 'Prepares collated Form 1 and Form 2'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select date 'START DATE' as '06/22/17'
Then select date 'END DATE' as '06/22/18'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270479
Scenario:042: Reports-Form1&2(BA) Generate Report with Manual Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 1 & 2 (BA)'
Then verify the report header 'FORM 1 & 2 (BA)'
Then verify the report sub header 'Prepares collated Form 1 and Form 2'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select option as 'Manual Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270479
Scenario:043: Reports-Form1&2(BA) Save to Queue with Search Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 1 & 2 (BA)'
Then verify the report header 'FORM 1 & 2 (BA)'
Then verify the report sub header 'Prepares collated Form 1 and Form 2'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select option as 'Search Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then click 'SAVE TO QUEUE'
#Then close notification
Then click 'REPORT QUEUE'
Then I search report 'Form 1 & 2 Combined (BA)' under Report Queue
Then I 'Delete' report 'Form 1 & 2 Combined (BA)' in queue with current date 
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US266890
Scenario:044: Reports-Form1(BA) Generate Report with Interim period
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 1 - Paperless (BA)'
Then verify the report header 'Form 1 - Paperless (BA)'
Then verify the report sub header 'Form 1 displays the assets in each case and their remaining values in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select date 'START DATE' as '06/22/17'
Then select date 'END DATE' as '06/22/18'
Then click option as 'Include Cases with TDR dates'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US266890
Scenario:045: Reports-Form1(BA) Generate Report with Manual Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 1 - Paperless (BA)'
Then verify the report header 'Form 1 - Paperless (BA)'
Then verify the report sub header 'Form 1 displays the assets in each case and their remaining values in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select option as 'Manual Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US266890
Scenario:046: Reports-Form1(BA) Save to Queue with Search Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 1 - Paperless (BA)'
Then verify the report header 'Form 1 - Paperless (BA)'
Then verify the report sub header 'Form 1 displays the assets in each case and their remaining values in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select option as 'Search Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

 @US237089  @US237089 
Scenario:047: Reports-Form1&2 Generate Report Mandatory Fields - Interim Time Period
Given I enter to Reports page as superuser
Given I Go to 'Form 1 & 2'
Then verify the report header 'Form 1 & 2'
Then verify the report sub header 'Prepares collated Form 1 and Form 2'
Then select date 'START DATE' as '07/01/17'
Then select date 'END DATE' as '07/01/17'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click Clear All to clear the cases data in Report Parameters Grid
Then select 'TRUSTEE' as 'CHERYL E. ROSE'
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'ADD CASES'
Then select 'ORIENTATION' as 'Portrait' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US202590 @US237089
Scenario:048: Reports-Form1&2 Generate Report Mandatory Fields - Manual Add
Given I enter to Reports page as superuser
Given I Go to 'Form 1 & 2'
Then verify the report header 'Form 1 & 2'
Then verify the report sub header 'Prepares collated Form 1 and Form 2'
Then select option as 'Manual Add'
Then select date 'START DATE' as '08/27/17'
Then select date 'END DATE' as '08/27/18'
Then input case information as '17-90001' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click Clear All to clear the cases data in Report Parameters Grid
Then select 'TRUSTEE' as 'CHERYL E. ROSE'
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then click 'ADD CASES'
Then select 'ORIENTATION' as 'Portrait' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US202590 @US237089
Scenario:049: Reports-Form1&2 Generate Report Mandatory Fields - Search Add
Given I enter to Reports page as superuser
Given I Go to 'Form 1 & 2'
Then verify the report header 'Form 1 & 2'
Then verify the report sub header 'Prepares collated Form 1 and Form 2'
Then select 'TRUSTEE' as 'CHERYL E. ROSE'
Then select 'DIVISION' as 'Baltimore' 
Then select 'ASSET STATUS' as 'No Asset' 
Then select option as 'Search Add'
Then select date 'START DATE' as '08/27/17'
Then select date 'END DATE' as '08/27/18'
Then input case information as '12-20186' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then select 'ORIENTATION' as 'Portrait' 
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US266888
Scenario:050: Reports-Account Reconciliation Report - Generate Report
Given I enter to Reports page as superuser
Given I Go to 'Account Reconciliation'
Then verify the report header 'Account Reconciliation'
Then verify the report sub header 'Shows the book balance, bank balance, and reconciliation status for each account.'
Then select option as 'Single Case'
Then I enter 'CASE # / DEBTOR NAME' as '01-01929 / Test, QA'
Then select Bank 
Then select date 'Balance as of' as '06/13/18'
Then select option as 'All balances'
Then select 'Sort Order' as 'Case #'
Then select option as 'Detail Start Date'
Then select Report Options as 'Outstanding Transaction Detail'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US266888
Scenario:051: Reports-Account Reconciliation Report - Save to Queue
Given I enter to Reports page as superuser
Given I Go to 'Account Reconciliation'
Then verify the report header 'Account Reconciliation'
Then verify the report sub header 'Shows the book balance, bank balance, and reconciliation status for each account.'
Then select option as 'Multiple Cases'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE' 
Then select Bank as 'Bank of America' 
Then select date 'Balance as of' as '06/13/18'
Then select option as 'Out of balance'
Then select 'Sort Order' as 'Case Name'
Then select option as 'Summary'
Then select Report Options as 'Closed Accounts'
Then select Report Options as 'Zero Balance Accounts'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US270483
Scenario:052: Reports-Quarterly possible Asset Case Report - Generate Report
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Quarterly Possible Asset Case Report (BA)'
Then verify the report header 'Quarterly Possible Asset Case Report (BA)'
Then verify the report sub header 'Quarterly Possible Asset Case Report (BA)'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select date 'REPORTING PERIOD' as '06/14/18'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270483
Scenario:053: Reports-Quarterly possible Asset Case Report - Save to Queue
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Quarterly Possible Asset Case Report (BA)'
Then verify the report header 'Quarterly Possible Asset Case Report (BA)'
Then verify the report sub header 'Quarterly Possible Asset Case Report (BA)'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select date 'REPORTING PERIOD' as '06/14/18'
Then click 'SAVE TO QUEUE'
Then I SignOut from the Unity Application

@US270480
Scenario:054: Reports-Form2Paperless(BA) Generate Report with Interim period
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 2 - Paperless (BA)'
Then verify the report header 'Form 2 - Paperless (BA)'
Then verify the report sub header 'Displays the financial ledger for each case with a running balance in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select date 'START DATE' as '06/22/17'
Then select date 'END DATE' as '06/22/18'
Then click option as 'Include Cases with TFR dates'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270480
Scenario:055: Reports-Form2 Paperless(BA) Generate Report with Manual Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 2 - Paperless (BA)'
Then verify the report header 'Form 2 - Paperless (BA)'
Then verify the report sub header 'Displays the financial ledger for each case with a running balance in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select option as 'Manual Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270480
Scenario:056: Reports-Form2 Paperless(BA) Save to Queue with Search Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 2 - Paperless (BA)'
Then verify the report header 'Form 2 - Paperless (BA)'
Then verify the report sub header 'Displays the financial ledger for each case with a running balance in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select option as 'Search Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then click 'SAVE TO QUEUE'
#Then close notification
Then I SignOut from the Unity Application

@US270480
Scenario:057: Reports-Form3Paperless(BA) Generate Report with Interim period
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 3 - Paperless (BA)'
Then verify the report header 'Form 3 - Paperless (BA)'
Then verify the report sub header 'Displays a list of active case and the status of each case in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select date 'START DATE' as '06/22/17'
Then select date 'END DATE' as '06/22/18'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click option as 'Form 1 Notes'
Then click option as 'Debtor AKA/DBA'
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270480
Scenario:058: Reports-Form3 Paperless(BA) Generate Report with Manual Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 3 - Paperless (BA)'
Then verify the report header 'Form 3 - Paperless (BA)'
Then verify the report sub header 'Displays a list of active case and the status of each case in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select option as 'Manual Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then I SignOut from the Unity Application

@US270480
Scenario:059: Reports-Form3 Paperless(BA) Save to Queue with Search Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 3 - Paperless (BA)'
Then verify the report header 'Form 3 - Paperless (BA)'
Then verify the report sub header 'Displays a list of active case and the status of each case in Excel.'
Then select 'TRUSTEE' as 'Walter Hinson' 
Then select 'DIVISION' as 'Raleigh' 
Then select 'ASSET STATUS' as 'All' 
Then select option as 'Search Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000 / QA Test1' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then click 'SAVE TO QUEUE'
Then close notification
#Then close notification
Then click 'REPORT QUEUE'
Then I search report 'Form 3 - Paperless (BA)' under Report Queue
Then I 'Delete' report 'Form 3 - Paperless (BA)' in queue with current date 
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US270482@US270482
Scenario:060: Reports-Form3(BA)-Generate Report with Manual Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 3 (BA)'
Then verify the report header 'Form 3 (BA)'
Then verify the report sub header 'Displays a list of active cases and their status.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select option as 'Manual Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000 / QA Test1' for 'Manual Add'
Then click 'ADD CASES'
Then verify the added cases information in Report Parameters Grid
Then click 'GENERATE REPORT'
Then click 'REPORT QUEUE'
Then I search report 'Form 3 (BA)' under Report Queue
Then I 'Delete' report 'Form 3 (BA)' in queue with current date
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US270482
Scenario:061: Reports-Form3(BA) Save to Queue with Search Add
Given I enter to Reports page as user aeriestest with password Password1! and office whinson
Given I Go to 'Form 3 (BA)'
Then verify the report header 'Form 3 (BA)'
Then verify the report sub header 'Displays a list of active cases and their status.'
Then select 'TRUSTEE' as 'Walter Hinson'
Then select 'DIVISION' as 'Raleigh'
Then select 'ASSET STATUS' as 'All'
Then select option as 'Search Add'
Then select date 'START DATE' as '10/01/17'
Then select date 'END DATE' as '01/01/19'
Then input case information as '18-10000 / QA Test1' for 'Search Add'
Then verify the added cases information in Report Parameters Grid
Then click 'SAVE TO QUEUE'
Then close notification
Then click 'REPORT QUEUE'
Then I search report 'Form 3 (BA)' under Report Queue
Then I 'Delete' report 'Form 3 (BA)' in queue with current date
Then click on ReportQueue close button
Then I SignOut from the Unity Application

@US293970
Scenario:062: Reports-W-2 Report- View Report
Given I enter to Reports page as superuser
Given I Go to 'W-2 Report'
Then verify the report header 'W-2 Report'
Then verify the report sub header 'Print W-2 Wage and Tax Statements'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select date 'START DATE' as '06/06/18'
Then select date 'END DATE' as '01/07/19'
Then click 'VIEW REPORT'
Then I SignOut from the Unity Application

@US293969
Scenario:063: Reports-1099 Report- View Report
Given I enter to Reports page as superuser
Given I Go to '1099 Report'
Then verify the report header '1099 Report'
Then verify the report sub header 'Print 1099-MISC Miscellaneous Income Forms.'
Then select 'TRUSTEE' as 'CHERYL E. ROSE, CHAPTER 11 TRUSTEE'
Then select date 'START DATE' as '06/06/18'
Then select date 'END DATE' as '01/07/19'
Then click 'VIEW REPORT'
Then I SignOut from the Unity Application

@US#286296
Scenario:064: Reports-Logged into different office
Given I enter to Reports page as user Subbash with password Password1 and office Whuisinga
And I Go to '1099 Report'
And I Go to 'Form 1'
And I Go to '341 Calendar'
And I Go to 'Cases Imported'
And I Go to '341 Post Meeting Outcome'
And I Go to 'Deposit Transmittal'
And I Go to '341 Docket'
And I Go to 'Form 2'
Then I SignOut from the Unity Application