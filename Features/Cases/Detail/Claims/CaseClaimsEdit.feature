@Regression
@Ignore @DoNotExecute
Feature: Case Detail - Claim - Claims Edit
	In order to manage Claims for a Case
	As a user of Unity with Claim Permissions
	I need to be able to edit existing Claims

####EDIT CLAIM
@CaseDetail @EditClaim
@US? @TC?
Scenario: 001 - Case Detail - Claims - Edit Claim Basic Form
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On Edit For Claim With Claim Number '123AutoEdit'
	And I Enter These Values On Basic Claim Form
	| Number      | Name                                                 | Status            | Category               | Code | Sub Code | Pay Sequence | Scheduled | Claimed | Allowed  | Reserved |
	| 321AutoEdit | Automated DO NOT DELETE Test Edited Claim Basic Form | Objection Pending | Administrative Expense | 2100 |          | 100          | $ 10.00   | $ 50.00 | $ 150.00 | $ 0.00   | 
	When I Click On Save Button
	Then I Verify On DB That Verified Field Is True For This Claim
	And I Click On Edit For Claim With Claim Number '321AutoEdit'
	And I See Edited Values Appear On Edit Claim Basic Form
	And I See Calculated Values Update to 'Administrative' '$0.00' '$0.00' And '$150.00'
	And I Click On Cancel Button

	
@CaseDetail @EditClaim
@Bug174792
Scenario: BUG_174792- 002 - Case Detail - Claims - Edit Claim (More Options)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On Edit For Claim With Claim Number '123AutoEdit'
	And I Click On More Options
	And I Enter These Values On More Options Claim Form
	| Check Description        | Creditor Acc Number        | Wage Deduction | Non-Compensable | Exclude from UFR | Non-discharged | Reaffirmed | Date Filed | Amends | Amends Version | Amended By | Amended By Version |
	| Check Description Edited | Creditor Acc Number Edited | false          | true            | false            | true           | false      | 09/26/2016 | ABC    | 123            | DEF        | 456                |
	And I Enter These Values For Claim Notes
	| Register Note              | Internal Note              |
	| Edited Claim Register Note | Edited Claim Internal Note |	
	When I Click On Save Button
	And I Click On Edit For Claim With Claim Number '123AutoEdit'
	And I Click On More Options
	Then I See Edited Values Appear On Edit Claim Form Under More Options
	And I Click On Cancel Button

#### Value/Money Fields Format
@Ignore @DoNotExecute
@CaseDetail @EditCLaim
@ValueFieldsFormat
@Sanity
@US112035 @TC?
Scenario Outline: 003 - Case Detail -  Claims - Edit Claim - Value Money Fields Format
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On Edit For Claim With Claim Number '123AutoEdit'
	And I See Claim '<Field>' Field Placeholder is ''
	When I Click On Claim Field '<Field>'
	Then I See Claim Cursor Position Is '<Field>' Field
	And I Enter Claim '<Field>' Field Value '<Set Value>'
	And I See Claim '<Field>' Field Value is '<Expected Value>'
	And I Can Select Two Digits From Claim '<Field>' Value '<Set Value>' And Delete With DELETE Key Getting '<Expected On Delete>'	
	And I Can Select Two Digits From Claim '<Field>' Value '<Set Value>' And Delete With BACKSPACE Key Getting '<Expected On Delete>'
	And I Can Select All Digits From Claim '<Field>' Value '<Set Value>' And Delete With DELETE Key
	And I Can Select All Digits From Claim '<Field>' Value '<Set Value>' And Delete With BACKSPACE Key
	And I Click On Cancel Button
Examples:
	| Field            | Set Value | Expected Value | Expected On Delete |
	| Scheduled Amount | 507223    | $ 507,223.00   | $ 7,223.00         |
	| Scheduled Amount | 5072.23   | $ 5,072.23     | $ 072.23           |
	| Scheduled Amount | 50.00     | $ 50.00        | $ 0.00             |
	| Scheduled Amount | 120       | $ 120.00       | $ 0.00             |
	| Claimed Amount   | 507223    | $ 507,223.00   | $ 7,223.00         |
	| Claimed Amount   | 5072.23   | $ 5,072.23     | $ 072.23           |
	| Claimed Amount   | 50.00     | $ 50.00        | $ 0.00             |
	| Claimed Amount   | 120       | $ 120.00       | $ 0.00             |
	| Allowed Amount   | 507223    | $ 507,223.00   | $ 7,223.00         |
	| Allowed Amount   | 5072.23   | $ 5,072.23     | $ 072.23           |
	| Allowed Amount   | 50.00     | $ 50.00        | $ 0.00             |
	| Allowed Amount   | 120       | $ 120.00       | $ 0.00             |
	| Reserved Amount  | 507223    | $ 507,223.00   | $ 7,223.00         |
	| Reserved Amount  | 5072.23   | $ 5,072.23     | $ 072.23           |
	| Reserved Amount  | 50.00     | $ 50.00        | $ 0.00             |
	| Reserved Amount  | 120       | $ 120.00       | $ 0.00             |

####EDIT CLAIM
@CaseDetail @EditClaim
@US? @TC? @US118916
Scenario Outline: 004 - Case Detail - Claims - Asset Description dropdown new behavior
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	And I Go to Claims Detail
	When I Click On Edit For Claim With Claim Number '123AutoEdit'
	Then Select value with text 'Changing Description' typing at position '<position>' on field 'Description' using 'Click' for Transaction
	And I Click On Cancel Button
	Examples:
	| position    |
	| Beginning   |
	| End         |
	| Middle      |
	| Highlighted |

####EDIT CLAIM
@CaseDetail @EditClaim
@US? @TC? @US118916
Scenario Outline: 005 - Case Detail - Claims Code - Dropdown new behavior
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	And I Go to Claims Detail
	When I Click On Edit For Claim With Claim Number '123AutoEdit'
	Then Select value with text '<text>' typing at position '<position>' on field 'Code' using 'Click' for Transaction
	And I Click On Cancel Button
	Examples:
	| position    | text |
	| Beginning   | 2420 |
	| End         | 2420 |
	| Highlighted | 2420 |

####EDIT CLAIM
@CaseDetail @EditClaim
@US? @TC? @US118916
Scenario Outline: 006 - Case Detail - Claims Sub Code- Dropdown new behavior
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Banking Detail
	And I Go to Claims Detail
	When I Click On Edit For Claim With Claim Number '123AutoEdit'
	And Select value with text '2420' typing at position 'End' on field 'Code' using 'Click' for Transaction
	Then Select value with text '<text>' typing at position '<position>' on field 'Sub Code' using 'Click' for Transaction
	And I Click On Cancel Button
	Examples:
	| position    | text |
	| Beginning   | 75   |
	| End         | 75   |
	| Highlighted | 75   |

#### TABBING
## Tabbing - Edit Claim- Basic option
#@CaseDetail
#@EditClaim @FormTabbing @Ignore @DoNotExecute
#@Regression
#@US113284 @TC?
#@Fix @Bug?
#Scenario: NEEDS_UPDATE_Case Detail -  Claims - Edit Claim - Tab Clockwise
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On Edit For Claim With Claim Number '123AutoEdit'
#	And I See Claim Default Cursor Position Is Claim Number Field
#	When I Press Tab Key
#	Then I See Claim Cursor Position Is 'Name' Field
#	And I Press Tab Key	
#	And I See Claim Cursor Position Is 'Status' Field
#	And I Press Tab Key	
#	And I See Claim Cursor Position Is 'Category' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Code' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Pay Sequence' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Scheduled Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Claimd Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Allowed Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Reserved Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'More Options' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Save And Add Another' Button
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Save' Button
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Cancel' Button
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Serial #' Field	
#
#
#@CaseDetail 
#@BankingTransactions
#@EditClaim @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Fix @Bug?
#Scenario: NEEDS_UPDATE_Case Detail -  Claims - Edit Claim - Tab Counterclockwise
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On Edit For Claim With Claim Number '123AutoEdit'
#	And I See Claim Default Cursor Position Is Claim Number Field	
#	When I Press Shift Tab Keys
#	Then I See Claim Cursor Position Is 'Cancel' Button
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Save' Button
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Save And Add Another' Button
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'More Options' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Reserved Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Allowed Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Claimd Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Scheduled Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Pay Sequence' Field
#	And I Press Shift Tab Keys	
#	And I See Claim Cursor Position Is 'Code' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Category' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Status' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Name' Field
#
#
##Tabbing - Edit Claim- More options
#@CaseDetail 
#@BankingTransactions
#@EditClaim @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Fix @Bug?
#Scenario: NEEDS_UPDATE_Case Detail -  Claims - Edit Claim (More Options) - Tab Clockwise
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On Edit For Claim With Claim Number '123AutoEdit'
#	And I See Claim Default Cursor Position Is Claim Number Field
#	When I Press Tab Key
#	Then I See Claim Cursor Position Is 'Name' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Status' Field	
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Category' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Code' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Pay Sequence' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Scheduled Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Claimd Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Allowed Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Reserved Amount' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'More Options' Field	
#	And I Press Space Bar
#	And I See Claim More Options Is Open
#	And I See Claim Cursor Position Is 'Payment Options Bar' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Creditor Acc number' Field	
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Check Description' Field
#	And I Press Tab Key	
#	And I See Claim Cursor Position Is 'Date Filed' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Bar Date' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Amends' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Amends Version' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Amended' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Amended Version' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Notes Bar' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Register Note' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Internal Note' Field
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Less Options' Field
#	And I Press Space Bar
#	And I See Claim More Options Is Closed
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Save And Add Another' Button
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Save' Button
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Cancel' Button
#	And I Press Tab Key	
#	And I See Claim Cursor Position Is 'Serial #' Field	
#
#
#
#@CaseDetail 
#@BankingTransactions
#@EditClaim @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Fix @Bug?
#Scenario: NEEDS_UPDATE_Case Detail -  Claims - Edit Claim (More Options) - Tab Counterclockwise
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On Edit For Claim With Claim Number '123AutoEdit'
#	And I See Claim Default Cursor Position Is Claim Number Field
#	When I Press Shift Tab Keys	
#	Then I See Claim Cursor Position Is 'Cancel' Button
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Save' Button
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Save And Add Another' Button
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'More Options' Field
#	And I Press Space Bar
#	And I See Claim More Options Is Open
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Internal Note' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Register Note' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Notes Bar' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Amended Version' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Amended' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Amends Version' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Amends' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Bar Date' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Date Filed' Field
#	And I Press Shift Tab Keys	
#	And I See Claim Cursor Position Is 'Check Description' Field
#	And I Press Shift Tab Keys	
#	And I See Claim Cursor Position Is 'Creditor Acc number' Field	
#	And I Press Shift Tab Keys	
#	And I See Claim Cursor Position Is 'Payment Options Bar' Field
#	And I Press Shift Tab Keys	
#	And I See Claim Cursor Position Is 'Reserved Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Allowed Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Claimd Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Scheduled Amount' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Pay Sequence' Field	
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Code' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Category' Field	
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Status' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Name' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Serial #' Field