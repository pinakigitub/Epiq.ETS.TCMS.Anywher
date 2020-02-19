@Regression
@Ignore @DoNotExecute
@RegressionFixesIt34
Feature: CaseDetail_DatesSection

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122985 @TC12651
#@AssetsPage
#Scenario Outline: 001_"CaseLevelDetailsDates" Verify All Dates selected layout
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '<caseToSearch>'
#	And I save Case ID from 'Claims' tab
#	And Click on Add Dates button
#	And Perform action 'Select' Date with text 'All' from list
#	And Click on Add button inside Key Dates modal
#	Then Verify All Dates selected layout
#	Examples: 
#	| caseToSearch               |
#	| HAMPTON JAMES JACKSON, Jr. |
#	| RABIE RABIEE               |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122985 @TC12651
#@AssetsPage
#Scenario Outline: 002_"CaseLevelDetailsDates" Verify All Dates deselected layout
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '<caseToSearch>'
#	And I save Case ID from 'Claims' tab
#	And Click on Add Dates button
#	And Perform action 'Unselect' Date with text 'All' from list
#	And Click on Add button inside Key Dates modal
#	Then Verify All Dates selected layout
#	Examples: 
#	| caseToSearch               |
#	| HAMPTON JAMES JACKSON, Jr. |
#	| RABIE RABIEE               |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122985 @TC12651
#@AssetsPage
#Scenario Outline: 003_"CaseLevelDetailsDates" Verify Key Dates layout when selecting particular date
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '<caseToSearch>'
#	And I save Case ID from 'Claims' tab
#	And Click on Add Dates button
#	And Perform action 'Unselect' Date with text 'All' from list
#	And Perform action 'Select' Date with text 'Checks Cut' from list
#	And Click on Add button inside Key Dates modal
#	Then Verify All Dates selected layout
#	Examples: 
#	| caseToSearch               |
#	| HAMPTON JAMES JACKSON, Jr. |
#	| RABIE RABIEE               |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122985 @TC12651
#@AssetsPage
#Scenario Outline: 004_"CaseLevelDetailsDates" Verify Key Dates layout when typing particular date
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
#	And I save Case ID from 'Claims' tab
#	And Click on Add Dates button
#	And Perform action 'Unselect' Date with text 'All' from list
#	And Perform action 'Select' Date with text '<dateToSelect>' from list
#	And Click on Add button inside Key Dates modal
#	When Enter Date with text '<dateToType>' for Ky Date '<keyDateInput>'
#	Then Verify All Dates selected layout
#	Examples: 
#	| dateToType | dateToSelect                     | keyDateInput                     |
#	| 11/30/2040 | 341 Date                         | CURRENT 341 DATE                 |
#	| 11/29/2040 | 341 Date                         | ORIGINAL 341 DATE                |
#	| 11/28/2040 | Actual TFR (Form 3)              | ACTUAL TFR (FORM 3)              |
#	| 11/27/2040 | Appointment Date                 | APPOINTMENT DATE                 |
#	| 11/26/2040 | Checks Cut                       | CHECKS CUT                       |
#	| 11/25/2040 | Claims Bar Date                  | CLAIMS BAR DATE                  |
#	| 11/24/2040 | Converted from 7                 | CONVERTED FROM 7                 |
#	| 11/23/2040 | Date Case Converted to Chapter 7 | DATE CASE CONVERTED TO CHAPTER 7 |
#	| 11/22/2040 | Discharge Date                   | DISCHARGE DATE                   |
#	| 11/21/2040 | Dismissal Date                   | DISMISSAL DATE                   |
#	| 11/20/2040 | Estimated TFR                    | ESTIMATED TFR                    |
#	| 11/19/2040 | Final Decree                     | FINAL DECREE                     |
#	| 11/18/2040 | Government Claims Bar Date       | GOVERNMENT CLAIMS BAR DATE       |
#	| 11/17/2040 | Initial Estimated TFR            | INITIAL ESTIMATED TFR            |
#	| 11/16/2040 | NDR                              | NDR                              |
#	| 11/15/2040 | Petition Date                    | PETITION DATE                    |
#	| 11/14/2040 | Reassigned                       | REASSIGNED                       |
#	| 11/13/2040 | Stop Bank Fees                   | STOP BANK FEES                   |
#	| 11/12/2040 | TDR \ Final Account (Form 3)     | TDR \ FINAL ACCOUNT (FORM 3)     |

#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122985 @TC12651
#@AssetsPage
#Scenario Outline: 005_"CaseLevelDetailsDates" Verify Key Dates layout when selecting particular date
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
#	And I save Case ID from 'Claims' tab
#	And Click on Add Dates button
#	And Perform action 'Unselect' Date with text 'All' from list
#	And Perform action 'Select' Date with text '<dateToSelect>' from list
#	And Click on Add button inside Key Dates modal
#	When Select day '<dayToSelect>' from Key Date datepicker with name '<keyDateInput>'
#	Then Verify All Dates selected layout
#	Examples: 
#	| dayToSelect | dateToSelect                     | keyDateInput                     |
#	| 1           | 341 Date                         | CURRENT 341 DATE                 |
#	| 2           | 341 Date                         | ORIGINAL 341 DATE                |
#	| 3           | Actual TFR (Form 3)              | ACTUAL TFR (FORM 3)              |
#	| 4           | Appointment Date                 | APPOINTMENT DATE                 |
#	| 5           | Checks Cut                       | CHECKS CUT                       |
#	| 6           | Claims Bar Date                  | CLAIMS BAR DATE                  |
#	| 7           | Converted from 7                 | CONVERTED FROM 7                 |
#	| 8           | Date Case Converted to Chapter 7 | DATE CASE CONVERTED TO CHAPTER 7 |
#	| 9           | Discharge Date                   | DISCHARGE DATE                   |
#	| 10          | Dismissal Date                   | DISMISSAL DATE                   |
#	| 11          | Estimated TFR                    | ESTIMATED TFR                    |
#	| 12          | Final Decree                     | FINAL DECREE                     |
#	| 13          | Government Claims Bar Date       | GOVERNMENT CLAIMS BAR DATE       |
#	| 14          | Initial Estimated TFR            | INITIAL ESTIMATED TFR            |
#	| 15          | NDR                              | NDR                              |
#	| 16          | Petition Date                    | PETITION DATE                    |
#	| 17          | Reassigned                       | REASSIGNED                       |
#	| 18          | Stop Bank Fees                   | STOP BANK FEES                   |
#	| 19          | TDR \ Final Account (Form 3)     | TDR \ FINAL ACCOUNT (FORM 3)     |

@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
@US122985 @TC12651
@AssetsPage
Scenario Outline: 006_"CaseLevelDetailsDates" Verify Key Dates error messages
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number 'JAMES CAMERON MARR'
	And I save Case ID from 'Claims' tab
	And Click on Add Dates button
	And Perform action 'Unselect' Date with text 'All' from list
	And Perform action 'Select' Date with text 'Checks Cut' from list
	And Click on Add button inside Key Dates modal
	When Enter Date with text '<dateToType>' for Ky Date 'CHECKS CUT'
	Then Verify error message for invalid Key Date format
	When Enter Date with text '03/28/1953' for Ky Date 'CHECKS CUT'
	Then Verify error message for invalid Key Date format dissapears when correcting value
	Examples: 
	| dateToType |
	| 33/10/2040 |
	| 01/2040/23 |
	| 2040/23/12 |
	| kjdfksdjfj |
	| 11-23-1914 |

@US44053 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
@US122985 @TC12651
@AssetsPage
Scenario Outline: 007_"CaseLevelDetailsDates" Verify Key Dates modal layout
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '<caseToSearch>'
	And I save Case ID from 'Claims' tab
	And Click on Add Dates button
	Then Verify Key Dates modal layout
	Examples: 
	| caseToSearch               |
	| HAMPTON JAMES JACKSON, Jr. |
	| RABIE RABIEE               |