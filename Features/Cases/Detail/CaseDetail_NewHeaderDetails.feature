@Regression
@Ignore @DoNotExecute
Feature: CaseLevelDetail_NewHeaderDetails
#@DoNotExecute @Ignore 
#@US44043 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122978 @TC12651
#@AssetsPage
#Scenario Outline: 001_"CaseLevelDetails" Verify Case Level Details layout in Claims Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And I save Case ID from 'Claims' tab
#	Then Verify Case Level Details section layout
#	Examples: 
#	| caseToSearch                     |
#	| AMY DANIELLE POORE               |
#	| CENTER FOR HOLISTIC MEDICINE LLC |
#	| THERESA J. WOODARD               |
#	| THE ESTATE OF RALPH GATES        |
#	| REX D. GARCIA-HIDALGO            |
#	| Karen M Butterfield              |
#
#@DoNotExecute @Ignore 
#@RegressionFixesIt34
#Scenario Outline: 001Failing_"CaseLevelDetails" Verify Case Level Details layout in Claims Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And I save Case ID from 'Claims' tab
#	Then Verify Case Level Details section layout
#	Examples: 
#	| caseToSearch                     |	
#	| REX D. GARCIA-HIDALGO            |
#
#@DoNotExecute @Ignore 
#@US44043 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122978 @TC12651
#@AssetsPage
#Scenario Outline: 002_"CaseLevelDetails" Verify Case Level Details layout in Assets Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And Click on Assets tab
#	And I save Case ID from 'Assets' tab
#	Then Verify Case Level Details section layout
#	Examples: 
#	| caseToSearch                     |
#	| AMY DANIELLE POORE               |
#	| CENTER FOR HOLISTIC MEDICINE LLC |
#	| THERESA J. WOODARD               |
#	| THE ESTATE OF RALPH GATES        |
#	| REX D. GARCIA-HIDALGO            |
#	| Karen M Butterfield              |
#
#@DoNotExecute @Ignore 
#@RegressionFixesIt34
#Scenario Outline: 002Failing_"CaseLevelDetails" Verify Case Level Details layout in Assets Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And Click on Assets tab
#	And I save Case ID from 'Assets' tab
#	Then Verify Case Level Details section layout
#	Examples: 
#	| caseToSearch                     |
#	| REX D. GARCIA-HIDALGO            |
#	| Karen M Butterfield              |
#
#
#@DoNotExecute @Ignore 
#@US44043 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122978 @TC12651
#@AssetsPage
#Scenario Outline: 003_"CaseLevelDetails" Verify Case Level Details layout in Banking Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And Click on Banking tab
#	And I save Case ID from 'Banking' tab
#	Then Verify Case Level Details section layout
#	Examples: 
#	| caseToSearch                     |
#	| AMY DANIELLE POORE               |
#	| CENTER FOR HOLISTIC MEDICINE LLC |
#	| THERESA J. WOODARD               |
#	| THE ESTATE OF RALPH GATES        |
#	| REX D. GARCIA-HIDALGO            |
#	| Karen M Butterfield              |
#
#@DoNotExecute @Ignore 
#@RegressionFixesIt34
#Scenario Outline: 003Failing_"CaseLevelDetails" Verify Case Level Details layout in Banking Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And Click on Banking tab
#	And I save Case ID from 'Banking' tab
#	Then Verify Case Level Details section layout
#	Examples: 
#	| caseToSearch                     |
#	| REX D. GARCIA-HIDALGO            |
#
#@DoNotExecute @Ignore 
#@US44043 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122978 @TC12651
#@AssetsPage
#Scenario: 004_"CaseLevelDetails" Verify Case Level Details sticky behavior in Assets tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text CENTER FOR HOLISTIC MEDICINE LLC
#	When Click on Assets tab
#	Then Verify Case level Details section is Sticky in 'Assets' tab
#
#@DoNotExecute @Ignore 
#@US44043 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122978 @TC12651
#@AssetsPage
#Scenario: 005_"CaseLevelDetails" Verify Case Level Details sticky behavior in Banking tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text CENTER FOR HOLISTIC MEDICINE LLC
#	When Click on Banking tab
#	Then Verify Case level Details section is Sticky in 'Banking' tab
#
#@DoNotExecute @Ignore 
#@US44043 @TC126510 @TC126511 @TC126512 @TC126513 @TC126514 @TC126515 @TC126516 @TC126517 @TC126518
#@US122978 @TC12651
#@AssetsPage
#Scenario: 006_"CaseLevelDetails" Verify Case Level Details sticky behavior in Claims tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	When Search and select Case by text CENTER FOR HOLISTIC MEDICINE LLC
#	Then Verify Case level Details section is Sticky in 'Claims' tab
#
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US122977
#@AssetsPage
#Scenario Outline: 007_"AdditionalDebtorInformation" Verify Additional Debtor Information section layout in Claims Tab
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text <caseToSearch>
#	And I save Case ID from 'Claims' tab
#	And Expand Additional Debtor Information section
#	Then Verify Additional Debtor Information section layout
#	Examples: 
#	| caseToSearch                     |
#	| AMY DANIELLE POORE               |
#	| CENTER FOR HOLISTIC MEDICINE LLC |
#	| THERESA J. WOODARD               |
#	| THE ESTATE OF RALPH GATES        |
#	| REX D. GARCIA-HIDALGO            |
#	| Karen M Butterfield              |
#
#@US122977 @TC
#@AssetsPage
#Scenario: 008_"AdditionalDebtorInformation" Verify Additional Debtor Information close action behavior
#	Given I go to Unity login page
#	And I login Unity site with username conversion, password conversion and office crose
#	And Search and select Case by text REX D. GARCIA-HIDALGO
#	And I save Case ID from 'Claims' tab
#	And Expand Additional Debtor Information section
#	And Collapse Additional Debtor Information section
#	When Expand Additional Debtor Information section
#	Then Close Additional Debtor Information section
#
#@DoNotExecute @RegressionFixesNeeded @Ignore 
#@US122977
#@AssetsPage
#Scenario Outline: 009_"AdditionalDebtorInformation" Verify SSN format for different user Permissions
#	Given I go to Unity login page
#	And I login Unity site with username <userName>, password <password> and office <office>
#	And Search and select Case by text REX D. GARCIA-HIDALGO
#	And I save Case ID from 'Claims' tab
#	And Expand Additional Debtor Information section
#	Then Verify Additional Debtor Information section layout
#	Examples: 
#	| userName       | password   | office |
#	| conversion     | conversion | crose  |
#	| viewpartialssn | conversion | crose  |
#	| noviewssn      | conversion | crose  |