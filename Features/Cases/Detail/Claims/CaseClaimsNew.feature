@NewClaimsFeature
@Ignore @DoNotExecute
@RegressionFixesIt34
#fixes correspond to new modal window, need to add cancel step at the end of cases failing 1 por medio
Feature: Case Detail - Claim - Claims New
	In order to manage Claims for a Case
	As a user of Unity with Claim Permissions
	I need to be able to create a New Claim

@CaseDetail @NewClaim
@Regression
@US110905 @TC112342 @TC112344 @TC112346 @TC112347 
@US110864 @TC112037 
@US110866 @TC112207 @TC112208 @TC112209 @TC112210
@US110867 @TC112110 @TC112111 @TC112112 @TC112118 @TC112055
@US110870 @TC112826
@US110871 @TC112810
@US110873 @TC112856 @TC112857
@US110874 @TC112813
@US110875 @TC112845 @TC112848
@US110879 @TC112495 @TC112496 @TC112497 @TC112498 @TC112499 @TC112500
Scenario: 001 - Case Detail - Claims - New Claim - Form Layout
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I See New Claim Button Displays on Summary Card
	When I Click On New Claim Button
	Then I See New Claim Form Displays With Correct Layout
	And I Click On Cancel Button
	#Verifies also More Options link functionality @US110879

@CaseDetail @NewClaim
@Regression
@US110905 @TC112038 @TC112039 @TC112040 @TC112041 @TC112042
Scenario: 002 - Case Detail - Claims - New Claim - Status Dropdown Selection Updates Corner Tag
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I See New Claim Button Displays on Summary Card
	And I Click On New Claim Button
	When I Select Each Status The Corner Tag Color Updates
	| Status            | Color  |
	| Valid To Pay      | GREEN  |
	#| Objection Pending | ORANGE |
	| Invalid           | RED    |
	| Withdrawn         | RED    |
	| Superseded        | RED    |
	And I Click On Cancel Button

@CaseDetail @NewClaim
@Regression @Validations
@US110905 @TC112352
@US110870 @TC112832
@US110875 @TC112849
Scenario Outline: 003 - Case Detail - Claims - New Claim - Required Fields Validation Chapter 7
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '<Case Number>'
	And I Go to Claims Detail
	And I Click On New Claim Button
	And I See Save Button is inactive
	When I Enter Valid Data For <Mandatory Fields> And I See Validation Messages Dissapear One At A Time
	And I Click On Save Button
	Then I See Claim Form Has Been Closed
	And I See Claim Displays On The List
	Examples:
	| Case Type        | Case Number | Mandatory Fields         |
	| Chapter 7        | 03-30382    | Name,Code,Pay Sequence   |
	#| Disbursing Agent | 10-14868    | Name                     |
	| Chapter 7        | 17-10001    | Name,Code,Pay Sequence   |

	

@CaseDetail @NewClaim
@Regression
@US110905 @TC112354 @TC112357  @TC112361 @TC112362
Scenario Outline: 004 - Case Detail - Claims - New Claim - Name Is Predictive
Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button
	When I Type '<Name Text>' on Name Search Field
	Then I See Claim Name Results Match Predictive Search
	And I Click On Cancel Button
	Examples: 
	| Name Text |
	| ABBY      |
	| 12        |
	| DIANA     |


@CaseDetail @NewClaim
@US110905 @TC112355 @TC112363 @TC112364 @TC112365
Scenario Outline: 005 - Case Detail - Claims - New Claim - Name Add New Claimant
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button
	And I Type '<Name Text>' on Name Search Field
	And I Select Add Claimant Result
	And I Click On Save Button
	And I Click On New Claim Button
	When I Type '<Name Text>' on Name Search Field
	Then I See The Exact Result '<Name Text>' As An Existent Name
	And I Click On Cancel Button
Examples:
	| Name Text              |
	| Test Adding a Claimant |

@CaseDetail @NewClaim
@Regression 
@US110905 @TC112348 @TC112349 @TC112350 @TC112351 @TC112353 @TC112367 @TC112369
#Some scenarios fail due to BUG 118734
Scenario Outline: 006 - Case Detail - Claims - New Claim Save
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Enter These Values On Basic Claim Form
	| Number   | Name   | Status   | Category   | Code   | Sub Code   | Pay Sequence   | Scheduled   | Claimed   | Allowed   | Reserved   |
	| <Number> | <Name> | <Status> | <Category> | <Code> | <Sub Code> | <Pay Sequence> | <Scheduled> | <Claimed> | <Allowed> | <Reserved> |
	And I See Calculated Values Update to '<Class>' '<Interest>' '<Paid>' And '<Balance>'
	When I Click On Save Button
	#Then I Verify On DB That Verified Field Is True For This Claim
	#And I See Claim Displays On The List	
	#And I See Claim Form Has Been Closed
Examples:
	| Number       | Name                            | Status            | Objection Code                              | Category                 | Code | Class          | Sub Code | Pay Sequence | Scheduled | Claimed | Allowed | Reserved | Interest | Paid  | Balance |
	#Vary values of Claim Number 
	|              | Test Automation Claims Creation |                   |                                             |                          |      | --             |          | 100          |           |         |         | $0.00    | $0.00    | $0.00 | $0.00   |
	| 369547       | Test Automation Claims Creation |                   |                                             |                          |      | --             |          | 100          |           |         |         | $0.00    | $0.00    | $0.00 | $0.00   |
	| Automation   | Test Automation Claims Creation |                   |                                             |                          |      | --             |          | 100          |           |         |         | $0.00    | $0.00    | $0.00 | $0.00   |
	| Automated 12 | Test Automation Claims Creation |                   |                                             |                          |      | --             |          | 100          |           |         |         | $0.00    | $0.00    | $0.00 | $0.00   |
	| AUTO987651   | Test Automation Claims Creation |                   |                                             |                          |      | --             |          | 100          |           |         |         | $0.00    | $0.00    | $0.00 | $0.00   |
	#Vary Status & Category
	#| AUTO123452   | Test Automation Claims Creation | Dismissed         |                                             | Administrative Expense   | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123453   | Test Automation Claims Creation | Invalid           |                                             | Convenience Claim        | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123454   | Test Automation Claims Creation | Objection Pending |                                             | Creditor                 | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123455   | Test Automation Claims Creation | Superseded        |                                             | Investor                 | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123456   | Test Automation Claims Creation | Valid To Pay      |                                             | Professional Fee\Expense | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123457   | Test Automation Claims Creation | Withdrawn         |                                             | Secured Class One        | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	##Vary Objection Code & Category
	#| AUTO123458   | Test Automation Claims Creation | Objection Pending | Allow As Tardy                              | Secured Class Two        | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123459   | Test Automation Claims Creation | Objection Pending | Amount Claimed Incorrect                    | Unsecured Class One      | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123460   | Test Automation Claims Creation | Objection Pending | Duplicate                                   | Unsecured Class Two      | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123461   | Test Automation Claims Creation | Objection Pending | Not Debtor's Obligation                     | Security Interest        | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123462   | Test Automation Claims Creation | Objection Pending | Previously Paid                             | Wage Claim               | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123463   | Test Automation Claims Creation | Objection Pending | Priority - Wrong Class \ Allow as Unsecured |                          | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123464   | Test Automation Claims Creation | Objection Pending | Secured                                     |                          | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123465   | Test Automation Claims Creation | Objection Pending | Undocumented Deficiency                     |                          | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |
	#| AUTO123466   | Test Automation Claims Creation | Objection Pending | Unsubstantiated                             |                          | 2690 | Administrative | 72       | 100          | 120       | 100     | 100     | $0.00    | $0.00    | $0.00 | $100.00 |


@CaseDetail @NewClaim
@Regression 
@US110905 @TC112366
Scenario: REVIEW_FOR_APP_BUG_007 - Case Detail - Claims - New Claim - Save And Add Another
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Enter A Valid Claim Number
	And I Enter A Valid Name Value For Test 'Save And Add Another'
	When I Click On Save And Add Another Button
	Then I See Claim Displays On The List
	And I See New Claim Form Displays With Correct Layout
	And I Click On Cancel Button

@CaseDetail @NewClaim
@Regression 
@US110905 @TC112368
Scenario: 008 - Case Detail - Claims - New Claim - Cancel
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Enter A Valid Claim Number
	And I Enter A Valid Name Value For Test 'Cancel'
	When I Click On Cancel Button
	Then I See Claim Does Not Display On The List
	And I See Claim Form Has Been Closed

@CaseDetail @NewClaim
@Regression 
@US110867 @TC112113 @TC112114 @TC112115 @TC112116
Scenario Outline: 009 - Case Detail - Claims - New Claim - Code Input Is Predictive
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	When I Type '<Code>' on Code Field
	Then I See Code Results Match Predictive Search And Display Correctly
	And I Click On Cancel Button
Examples:
	| Code                   |
	| 2100                   |
	| 2200                   |
	| Bond                   |
	| accountant for trustee |
	| Chapter 7              |

@CaseDetail @NewClaim
@Regression 
@US110867 @TC112118 @TC118119 @TC112121
Scenario Outline: 010 - Case Detail - Claims - New Claim - Code Selection Updates Class
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14418'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Type '<Exact Code>' on Code Field
	When I Select The First Result On Code Dropdown
	Then I See Code Input Displays Selected Code And Description '<Expected Text>'
	And I See Class Autocompletes To '<Class>'
	And I Click On Cancel Button
Examples:
	| Exact Code | Expected Text                                                                                                     | Class          |
	| 2100       | 2100 Chapter 7 - Other Trustee                                                                                    | Administrative |
	| 3721       | 3721 Chapter 7 - Arbitrator/Mediator for Trustee Fees                                                             | Administrative |
	| 4300       | 4300 Chapter 7 - Internal Revenue Service Tax Liens (pre-petition)                                                | Secured        |
	| 5200       | 5200 Chapter 7 - Unsecured Claims Allowed Under 502(f) to 507(a)(2)                                               | Priority       |
	| 6101       | 6101 Chapter 7 - Trustee Compensation (Chapter 11)                                                                | Administrative |
	| 7300       | 7300 Chapter 7 - Fines, Penalties726(a)(4)                                                                        | Unsecured      |
	| 8200       | 8200 Chapter 7 - Surplus Funds Paid to Debtor 726 (a)(6) (includes Payments to shareholders and limited partners) | Unsecured      |


@CaseDetail @NewClaim
@Regression 
@US110867 @TC112056
Scenario Outline: 011 - Case Detail - Claims - New Claim Subcode Input Is Predictive
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Type '2690' on Code Field
	And I Select The First Result On Code Dropdown
	And I Type '<Subcode>' on Subcode Field
	And I See Subcode Results Match Predictive Search And Display Correctly
	When I Select The First Result On Subcode Dropdown
	Then I See Subcode Input Displays Selected Subcode And Description '<Expected Text>'
	And I Click On Cancel Button
Examples:
	| Subcode | Expected Text                                                       |
	| 46      | 46 Management Company Fees (Chapter 7 , Operating 7, or 11)         |
	| 72      | 72 Administrative Post-Petition Wages (Operating 7 or Chapter 11)   |

@CaseDetail @NewClaim
@Regression 
@US? @TC?
Scenario: 012 - Case Detail - Claims - New Claim - Code List Sorting
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	When I Type '' on Code Field
	Then I See Code Results Display Sorted Descending
	And I See Subcode Input Is Inactive
	And I Click On Cancel Button
		

@CaseDetail @NewClaim
@Regression 
@US? @TC?
Scenario: 012 - Case Detail - Claims - New Claim - Subcode List Sorting
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	When I Type '2690' on Code Field
	And I Select The First Result On Code Dropdown
	And I Type '11' on Subcode Field
	Then I See Subcode Results Display Sorted Descending
	And I Click On Cancel Button

@CaseDetail @NewClaim
@Regression 
@US110875 @TC112846 @TC112847
Scenario: 013 - Case Detail - Claims - New Claim - Claimed Amount Updates Allowed Amount
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button
	And I See Allowed Amount Field Value Is ''
	And I See Balance Value Is '$0.00'	
	When I Enter '54.75' on Claimed Amount Field
	Then I See Allowed Amount Field Value Is '$ 54.75'
	And I See Balance Value Is '$54.75'
	And I Click On Cancel Button

@CaseDetail @NewClaim
@Regression 
@US110870 @TC112829 @TC112830 @TC112831
Scenario Outline: 014 - Case Detail - Claims - New Claim - Pay Sequence Validations
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button
	When I Enter '<Entered>' on Pay Sequence Field
	Then I See Pay Sequence Value is '<Expected>'
	And I Click On Cancel Button
Examples:
	| Entered | Expected |
	| 01      |  01      |
	| 123     | 123      |
	| 154     | 154      |
	| 1234    | 1234     |
	| 9000    | 9000     |



### More Options
#Creditor Payment Options
@CaseDetail @NewClaim
@Regression 
@US110882 @TC112516
@US110879 @TC112503
@US110893 @TC112550
@US110894 @TC112557
@US110896 @TC112562
@US110899 @TC112568
@US110891 @TC112545
@US110889 @TC112542
Scenario: 015 - Case Detail - Claims - New Claim (More Options) - Payment Options And Notes Layout
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	When I Click On More Options
	#Then I See Creditor Payment Options Layout Is Correct
	#And I Click On Cancel Button
	#Verifies All fields under Payment Options & Notes with labels, inputs and default values

@CaseDetail @NewClaim
@Regression 
@US110891 @TC112545 @TC112546
Scenario Outline: 016 - Case Detail - Claims - New Claim (More Options) - Bar Date Values	
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '<Case Number>'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	When I Click On More Options
	Then I See Bar Date Value Is '<Expected Bar Date>'
	#Bar Date query DB and verify value for different cases - if no value display  blank
	And I Click On Cancel Button
	Examples:
	#With values
	| Case Number | Expected Bar Date |
	| 10-14868    | 12/27/2010        |
	| 08-21226    | 04/21/2010        |
	#No value
	| 0:000-XXX   | 01/16/2017   	  |



@CaseDetail @NewClaim
@Regression 
@US110882 @TC112517 
@US110879 @TC112504
@US110893 @TC112551
@US110894 @TC112558
@US110896 @TC112563
@US110899 @TC112567
Scenario: 017 - Case Detail - Claims - New Claim (More Options) - Payment Options Max Chars
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	When I Click On More Options
	Then I Can Enter A Max Of Fifty Characters on Creditor Account Number Field	
	And I Can Enter A Max Of Characters on Check Description Field
	And I Can Enter A Max Of Three Alphanumeric Chars on Amended By
	And I Can Enter A Max Of Three Numeric Chars on Amended By Version
	And I Can Enter A Max Of Three Alphanumeric Chars on Amends
	And I Can Enter A Max Of Three Numeric Chars on Amends Version
	And I Click On Cancel Button
	

@CaseDetail @NewClaim
@Regression 
@US110879 @TC112501 @TC112501
Scenario: 018 - Case Detail - Claims - New Claim (More Options) - Payment Options Fold And Unfold 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Click On More Options
	When I Click on Payment Options Title Bar
	Then I See Payment Options Section Is Hidden
	And I Click on Payment Options Title Bar
	Then I See Payment Options Section Is Open
	And I Click On Cancel Button

@CaseDetail @NewClaim
@Regression 
@US110886 @TC112523 @TC112524 @TC112525 @TC112526 @TC112527 @TC112528 @TC112529 @TC112530 @TC112531
Scenario: 019 - Case Detail - Claims - New Claim (More Options) - Claim Options
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Type '5200' on Code Field
	And I Select The First Result On Code Dropdown
	When I Click On More Options
	Then I Can Select And Unselect All Options Except For Wage Deduction
	And I Click On Cancel Button
	
#Wage claim selection depends on selected Code
@CaseDetail @NewClaim
@Regression 
@US110886 @TC112525
Scenario Outline: 020 - Case Detail - Claims - New Claim (More Options) - Wage Deduction Selection
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Type '<Exact Code>' on Code Field
	And I Select The First Result On Code Dropdown
	And I Click On More Options
	#When I Try To Select Wage Deduction From Claim Options
	#Then I See Wage Deduction Selection Is '<Selected>'
	And I Click On Cancel Button
	Examples:
		| Exact Code | Selected |
		| 2690       | True     |
		| 5300       | True     |
		| 6950       | True     |
		| 7100       | True     |
		| 7200       | True     |
		|            | False    |
		| 3711       | False    |
		| 5200       | False    |

#TODO: change hard coded codes for query
#SELECT c.*
#FROM dbo.ChartOfAccount c
#JOIN dbo.ChartOfAccountChartOfAccountType ct ON ct.ChartOfAccountId = c.ChartOfAccountId
#JOIN dbo.ChartOfAccountType t ON t.ChartOfAccountTypeId = ct.ChartOfAccountTypeId
#WHERE t.ChartOfAccountTypeId = 16 -- wage claim type


### NOTES
@CaseDetail @NewClaim
@Regression 
@US110901 @TC112575
Scenario: 021 - Case Detail - Claims - New Claim (More Options) - Notes Fold And Unfold 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Click On More Options
	When I Click on Notes Title Bar
	Then I See Notes Section Is Hidden
	And I Click on Notes Title Bar
	And I See Notes Section Is Open
	And I Click On Cancel Button


@CaseDetail @NewClaim
@Regression 
@US110901 @TC112575
Scenario: 022 - Case Detail - Claims - New Claim (More Options) - Register Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button	
	And I Enter A Valid Claim Number
	And I Enter A Valid Name Value For Test 'Register Note'
	And I Click On More Options
	When I Enter Claim Register Note Text 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt.'
	And I Click On Save Button
	And I Click On Edit For The Created Claim
	And I Click On More Options
	Then I See Note Displays on Claims Register Note Field
	And I Click On Cancel Button

@CaseDetail @NewClaim
@Regression 
@US110901 @TC112575
Scenario: 023 - Case Detail - Claims - New Claim (More Options) - Internal Claim Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button
	And I Enter A Valid Claim Number
	And I Enter A Valid Name Value For Test 'Internal Claim Note'
	And I Click On More Options
	When I Enter Internal Claim Note Text 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt.'
	And I Click On Save Button
	And I Click On Edit For The Created Claim
	And I Click On More Options
	Then I See Note Displays on Internal Claim Note Field
	And I Click On Cancel Button

### SAVE MORE OPTIONS - ALL VALUES
@CaseDetail @NewClaim
@Regression 
@US? @TC?
Scenario: 024 - Case Detail - Claims - New Claim Save (More Options)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Claims Detail
	And I Click On New Claim Button
	And I Enter A Valid Claim Number
	And I Enter A Valid Name Value For Test 'Internal Claim Note'
	And I Type '2690' on Code Field
	And I Select The First Result On Code Dropdown
	And I Click On More Options
	And I Enter These Values On More Options Claim Form
	| Check Description | Creditor Acc Number | Wage Deduction | Non-Compensable | Exclude from UFR | Non-discharged | Reaffirmed | Date Filed | Amends | Amends Version | Amended By | Amended By Version |
	| Check Description | Creditor Acc Number | true           | true            | false            | true           | false      | 09/26/2016 | ABC    | 123            | DEF        | 456                |
	And I Enter These Values For Claim Notes
	| Register Note           | Internal Note           |
	| New Claim Register Note | New Claim Internal Note |
	When I Click On Save Button
	Then I See Claim Displays On The List
	And I See Claim Form Has Been Closed

	
##More For codes and subcodes
#@CaseDetail @NewClaim
#@Regression 
#@US? @TC?
#Scenario Outline: 027 - Case Detail - Claims - New Claim - Code Input No Results
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button	
#	When I Type '<Unexistent Code>' on Code Field
#	Then I See No Code And A Message That Reads 'No Results Matching Search Criteria'
	#And I Click On Cancel Button
#Examples:
#	| Unexistent Code         |
#	| accountant for trustees |
#	| &%$^                    |

#@CaseDetail @NewClaim
#@Regression 
#@US? @TC?
#Scenario Outline: 028 - Case Detail - Claims - New Claim Subcode Input No Results
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button	
#	When I Type '<Subcode>' on Subcode Field
#	Then I See No Subcode And A Message That Reads 'No Results Available Matching Search Criteria'
	#And I Click On Cancel Button
#Examples:
#	| Subcode |
#	| 25      |


#### TABBING
## Tabbing - Add Claim- Basic options
#@CaseDetail
#@NewClaim @FormTabbing @Ignore @DoNotExecute
#@Regression
#@US113284?
#@Fix
#Scenario: NEEDS_UPDATE_025 - Case Detail -  Claims - New Claim - Tab Clockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button	
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
#	And I See Claim Cursor Position Is 'Claimed Amount' Field
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
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Name' Field
	#And I Click On Cancel Button
#
#
#@CaseDetail 
#@NewClaim
#@AddClaim @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Fix
#Scenario: NEEDS_UPDATE_026 - Case Detail -  Claims - New Claim  - Tab Counterclockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button
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
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Serial #' Field
	#And I Click On Cancel Button
#
#
##Tabbing - Add Claim- More options
#@CaseDetail 
#@NewClaim
#@AddClaim @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Fix
#Scenario: NEEDS_UPDATE_027 - Case Detail -  Claims - New Claim (More Options) - Tab Clockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button	
#	And I See Claim Default Cursor Position Is Claim Number Field
#	When I Press Tab Key
#	Then I See Claim Cursor Position Is 'Name' Field
#	When I Press Tab Key
#	Then I See Claim Cursor Position Is 'Status' Field	
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
#	And I Press Tab Key
#	And I See Claim Cursor Position Is 'Name' Field
	#And I Click On Cancel Button
#
#
#
#@CaseDetail 
#@NewClaim
#@NewClaim @FormTabbing @Ignore @DoNotExecute
#@Regression @Sanity
#@US113284 @TC?
#@Bug
#Scenario: BUG_028 - Case Detail -  Claims - New Claim (More Options) - Tab Counterclockwise
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button
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
#	And I See Claim Cursor Position Is 'Status' Field
#	And I Press Shift Tab Keys
#	And I See Claim Cursor Position Is 'Serial #' Field
	#And I Click On Cancel Button

#### Value/Money Fields Format
#@Ignore @DoNotExecute
#@CaseDetail @NewCLaim
#@ValueFieldsFormat
#@Regression
#@US112035 @TC?
#Scenario Outline: 029 - Case Detail -  Claims - New Claim Value_Money Fields Format
#	Given I enter to 341 Meeting page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Claims Detail
#	And I Click On New Claim Button
#	And I See Claim '<Field>' Field Placeholder is ''
#	When I Click On Claim Field '<Field>'
#	Then I See Claim Cursor Position Is '<Field>' Field
#	And I Enter Claim '<Field>' Field Value '<Set Value>'
#	And I See Claim '<Field>' Field Value is '<Expected Value>'
#	And I Can Select Two Digits From Claim '<Field>' Value '<Set Value>' And Delete With DELETE Key Getting '<Expected On Delete>'	
#	And I Can Select Two Digits From Claim '<Field>' Value '<Set Value>' And Delete With BACKSPACE Key Getting '<Expected On Delete>'
#	And I Can Select All Digits From Claim '<Field>' Value '<Set Value>' And Delete With DELETE Key
#	And I Can Select All Digits From Claim '<Field>' Value '<Set Value>' And Delete With BACKSPACE Key
#	And I Click On Cancel Button
#Examples:
#	| Field            | Set Value | Expected Value | Expected On Delete |
#	| Scheduled Amount | 507223    | $ 507,223.00   | $ 7,223.00         |
#	| Scheduled Amount | 5072.23   | $ 5,072.23     | $ 072.23           |
#	| Scheduled Amount | 50.00     | $ 50.00        | $ 0.00             |
#	| Scheduled Amount | 120       | $ 120.00       | $ 0.00             |
#	| Claimed Amount   | 507223    | $ 507,223.00   | $ 7,223.00         |
#	| Claimed Amount   | 5072.23   | $ 5,072.23     | $ 072.23           |
#	| Claimed Amount   | 50.00     | $ 50.00        | $ 0.00             |
#	| Claimed Amount   | 120       | $ 120.00       | $ 0.00             |
#	| Allowed Amount   | 507223    | $ 507,223.00   | $ 7,223.00         |
#	| Allowed Amount   | 5072.23   | $ 5,072.23     | $ 072.23           |
#	| Allowed Amount   | 50.00     | $ 50.00        | $ 0.00             |
#	| Allowed Amount   | 120       | $ 120.00       | $ 0.00             |
#	| Reserved Amount  | 507223    | $ 507,223.00   | $ 7,223.00         |
#	| Reserved Amount  | 5072.23   | $ 5,072.23     | $ 072.23           |
#	| Reserved Amount  | 50.00     | $ 50.00        | $ 0.00             |
#	| Reserved Amount  | 120       | $ 120.00       | $ 0.00             |