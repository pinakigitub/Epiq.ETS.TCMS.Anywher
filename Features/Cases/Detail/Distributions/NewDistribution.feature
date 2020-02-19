@Ignore
Feature: Case Detail - Distribution New
	In order to make money distributions for my Case
	As a user of Unity
	I need to be able to create a new Distribution

@Regression @Sanity
@CaseDetail @CaseDistribution
@NewDistribution
@US102100 @TC102801 @TC102801 @TC102802 @TC102805 @TC102806 @TC102807 @TC102808 
@US102294 @TC102879 @TC102880 @TC102881 @TC102883 @TC102884 @TC102887 @TC102888 @TC102891
@US102296 @TC102906 @TC102907
@US105505 @TC105645
#CaseId=397
Scenario: Case Detail - New Distribution - Step 1 Form Display (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	Then I See New Distribution Form Displays Fields Labels and Placeholders Correctly For Step One
	And I See New Distribution Form Displays Calculated Balances With Correct Format For Step One
	And I See New Distribution Form Displays Next and Cancel Button
			
@Regression @Sanity
@CaseDetail @CaseDistribution
@NewDistribution
@US102296 @TC102906 @TC102907
Scenario: Case Detail - New Distribution - Step 2 Form Display (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	Then I See New Distribution Form Locks Down Step One Section And Title is Distributions Name
	And I See Step Two Message Displays Reading 'First, lets set the distribution amount. Please enter either a percentage OR a dollar amount.'
	And I See New Distribution Form Displays Fields Labels and Placeholders Correctly For Step Two

@Regression @Sanity
@CaseDetail @CaseDistribution
@NewDistribution
@US102100 @TC102810
Scenario: Case Detail - New Distribution - Cancel
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Distribution Cancel Button
	Then I See New Distribution Form Dissappear
	And I See Distribution Has Not Been Saved

@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102294 @TC105094
Scenario: Case Detail - New Distribution - Remaining Balance Calculation (Positive)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	And I Enter An Amount to Distribute Lower Than the Available Amount
	Then I See Remaining Balance Calculation Is Correct
	And I See Remainig Balance Displays Correctly As Positive Value


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102294 @TC105096
Scenario: Case Detail - New Distribution - Remaining Balance Calculation (Negative)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	And I Enter An Amount to Distribute Higher Than the Available Amount
	Then I See Remaining Balance Calculation Is Correct
	And I See Remainig Balance Displays Correctly As Negative Value

## Case Detail - New Distribution - Step 3 and more
@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US106565 @TC104209 @TC104210 @TC104211 @TC104212 
@US102629 @TC104363 @TC104364
@US102775 @TC104431
Scenario: Case Detail - New Distribution - Step 3 Form Display (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	When I Go To Step Three Of New Distribution
	Then I See Distribution Methods Are Displayed Correctly
	And I See Distribution Methods Default Selection is 'Pro Rata'
	And I See Payees Message Reading 'Next, let's filter the payees. Please select the classes and categories you would like to be included in this group.'
	And I See Claims Class Header And Some Class Displays
	And I See Claim Class Select All Option Is Active By Default
	And I See Claim Category Header And Some Category Displays
	And I See Claim Category Select All Option Is Active By Default
	And I See Confirm Selections Message Reads 'Lastly, let's confirm your selections.'
	And I See Confirm Selections Description Reads 'Please note that claims with a status of "Objection Pending" are automatically included and proposed amounts will update as reserved funds when the distribution is posted. If you do not want to include these claims, please unselect them below.'
	And I See Some Claims Display for the Selected Classes and Categories
	

@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US106565 @TC1042013
Scenario: Case Detail - New Distribution - Step 3 - Distribution Method Selections (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution	
	When I Select Method 'Pay Each Claim Equally'
	Then I See Method Pro Rata Is Unselected and Pay Each Claim Equally Is Selected
	And I Can Select Pro Rata Again After Selecting Pay Each Claim Equally


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102629 @TC104365 @TC104366
@US102775 @TC104432 @TC104433 @TC104434
Scenario: Case Detail - New Distribution - Step 3 Claim Class Select All Functionality (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution	
	When I Unselect 'Select All' Option From Claim Class
	Then I See All Claim Classes Are Unselected
	And I See 'Select All' Option From Claim Class Is Unselected
	And I Select 'Select All' Option From Claim Class
	And I See 'Select All' Option From Claim Class Is Selected
	And I See All Claim Classes Are Selected
	And I Unselect One Option From Claim Class
	And I See 'Select All' Option From Claim Class Is Unselected


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102775 @TC104448
Scenario: Case Detail - New Distribution - Step 3 Claim Category Select All Functionality (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution
	When I Unselect 'Select All' Option From Claim Category
	Then I See All Claim Categories Are Unselected
	And I See 'Select All' Option From Claim Category Is Unselected
	And I Select 'Select All' Option From Claim Category
	And I See 'Select All' Option From Claim Category Is Selected
	And I See All Claim Categories Are Selected
	And I Unselect One Option From Claim Category
	And I See 'Select All' Option From Claim Category Is Unselected


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102629 @TC104367 @TC104377
Scenario: Case Detail - New Distribution - Step 3 Claim Class Select Option Functionality (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution
	When I Unselect 'Unsecured' Option From Claim Class
	Then I See 'Unsecured' Option From Claim Class Is Unselected
	And I Select 'Unsecured' Option From Claim Class
	And I See 'Unsecured' Option From Claim Class Is Selected


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102775 @TC104445
Scenario: Case Detail - New Distribution - Step 3 Claim Category Select Option Functionality (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution	
	When I Unselect 'Unsecured Class One' Option From Claim Category
	Then I See 'Unsecured Class One' Option From Claim Category Is Unselected
	And I Select 'Unsecured Class One' Option From Claim Category
	And I See 'Unsecured Class One' Option From Claim Category Is Selected	


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102629 @TC104369 @TC104370 @TC104371 @TC104372 @TC104374 @TC104375
Scenario: Case Detail - New Distribution - Step 3 Claim Class List Data (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	When I Go To Step Three Of New Distribution
	Then I See All Claim Classes Display Correctly
	| Claim Class    | Count | Selected | Balance           | Reserved |
	| Administrative | 1     | True     | $2.00             | 1        |
	| Secured        | 1     | True     | $1,855.28         | 0        |
	| Unsecured      | 13    | True     | $1,002,071,135.81 | 1        |


@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102775 @TC104435 @TC104436 @TC104437 @TC104439 @TC104440 @TC104441 @TC104443
Scenario: Case Detail - New Distribution - Step 3 Claim Category List Data (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	When I Go To Step Three Of New Distribution
	Then I See All Claim Categories Display Correctly
	| Claim Category      | Count | Selected | Balance     | Reserved |
	| Convenience Claim   | 1     | True     | $2.00       | 1        |
	| Secured Class Two   | 1     | True     | $1,855.28   | 0        |
	| Unsecured Class One | 1     | True     | $429,289.01 | 1        |
	

#Claims Display and Selection
@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102775 @TC104435 @TC104436 @TC104437 @TC104439 @TC104440 @TC104441 @TC104443
Scenario: Case Detail - New Distribution - Step 3 Claim List Display (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	When I Click on New Distribution Button on Summary Card
	When I Go To Step Three Of New Distribution
	Then I See These 'Objection Pending' Claims Under 'Unsecured' With Count Of '13'
	| Claim Name               | Category            | Balance     | Number    |
	| INTERNAL REVENUE SERVICE | Unsecured Class One | $429,289.01 | Claim # 3 |
	And I See These 'Valid To Pay' Claims Under 'Unsecured' With Count Of '13'
	| Claim Name                          | Category | Balance     | Number     |
	| PEPCO                               |          | $2,403.59   | Claim # 20 |
	| INTERNAL REVENUE SERVICE            |          | $1,470.34   | Claim # 16 |
	| ERNA MUELLER                        |          | $69,727.58  | Claim # 17 |
	| ERNA MUELLER                        |          | $127,168.51 | Claim # 18 |
	| GENERAL ELECTRIC CAPITAL CORP       |          | $1,450.13   | Claim # 15 |
	| GOVERNMENT OF THE DISTRICT OF COLUM |          | $1,624.16   | Claim # 14 |
	| COMPTROLLER OF MARYLAND             |          | $5,038.75   | Claim # 10 |
	| U. S. SMALL BUSINESS ADMINISTRATION |          | $934,532.82 | Claim # 13 |
	| 8120, LLC                           |          | $471,585.42 | Claim # 11 |
	| WASHINGTON GAS                      |          | $5,095.88   | Claim # 8  |
	| CIT TECHNOLOGY FINANCING SRVCS, INC |          | $21,749.62  | Claim # 7  |
	| COMMERCIAL LIGHTING COMPANY         |          | MAX         | Claim # 6  |
	#Check that it hasn't dissapeared
	And I See These 'Objection Pending' Claims Under 'Administrative' With Count Of '1'
	| Claim Name                      | Category          | Balance | Number |
	| INSURANCE PARTNERS AGENCY, INC. | Convenience Claim | $2.00   |        |
	And I See These 'Valid To Pay' Claims Under 'Secured' With Count Of '1'
	| Claim Name                       | Category          | Balance   | Number    |
	| GUARDIAN FIRE PROTECTION SERVICE | Secured Class Two | $1,855.28 | Claim # 2 |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102629 @TC104367
Scenario: Case Detail - New Distribution - Step 3 Claims Select Option Functionality (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution
	When I Unselect 'PEPCO' Option From Claims List
	Then I See 'PEPCO' Option From Claims List Is Unselected
	And I Select 'PEPCO' Option From Claims List
	And I See 'PEPCO' Option From Claims List Is Selected

#Claims Display and Update from Class and Category selections
@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102631 @TC104569 @TC104570 @TC104571
Scenario: Case Detail - New Distribution - Step 3 Claim Class Selection Updates Claims List
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Go To Step Three Of New Distribution
	# Clean all selections to start
	And I Unselect 'Select All' Option From Claim Class
	And I Unselect 'Select All' Option From Claim Category
	When I Select 'Unsecured' Option From Claim Class
	And I Select 'Administrative' Option From Claim Class
	Then I See Claims Class 'Administrative' Does Not Display On Claims List Section	
	And I See These 'Valid To Pay' Claims Under 'Unsecured' With Count Of '12'
	| Claim Name                          | Category | Balance     | Number     |
	| PEPCO                               |          | $2,403.59   | Claim # 20 |
	| INTERNAL REVENUE SERVICE            |          | $1,470.34   | Claim # 16 |
	| ERNA MUELLER                        |          | $69,727.58  | Claim # 17 |
	| ERNA MUELLER                        |          | $127,168.51 | Claim # 18 |
	| GENERAL ELECTRIC CAPITAL CORP       |          | $1,450.13   | Claim # 15 |
	| GOVERNMENT OF THE DISTRICT OF COLUM |          | $1,624.16   | Claim # 14 |
	| COMPTROLLER OF MARYLAND             |          | $5,038.75   | Claim # 10 |
	| U. S. SMALL BUSINESS ADMINISTRATION |          | $934,532.82 | Claim # 13 |
	| 8120, LLC                           |          | $471,585.42 | Claim # 11 |
	| WASHINGTON GAS                      |          | $5,095.88   | Claim # 8  |
	| CIT TECHNOLOGY FINANCING SRVCS, INC |          | $21,749.62  | Claim # 7  |
	| COMMERCIAL LIGHTING COMPANY         |          | MAX         | Claim # 6  |
	And I Select 'Convenience Claim' Option From Claim Category	
	And I See These 'Objection Pending' Claims Under 'Administrative' With Count Of '1'
	| Claim Name                      | Category          | Balance | Number |
	| INSURANCE PARTNERS AGENCY, INC. | Convenience Claim | $2.00   |        |
	And I Select 'Unsecured Class One' Option From Claim Category	
	And I See These 'Objection Pending' Claims Under 'Unsecured' With Count Of '13'
	| Claim Name               | Category            | Balance     | Number    |
	| INTERNAL REVENUE SERVICE | Unsecured Class One | $429,289.01 | Claim # 3 |
	And I See These 'Valid To Pay' Claims Under 'Unsecured' With Count Of '13'
	| Claim Name                          | Category | Balance     | Number     |
	| PEPCO                               |          | $2,403.59   | Claim # 20 |
	| INTERNAL REVENUE SERVICE            |          | $1,470.34   | Claim # 16 |
	| ERNA MUELLER                        |          | $69,727.58  | Claim # 17 |
	| ERNA MUELLER                        |          | $127,168.51 | Claim # 18 |
	| GENERAL ELECTRIC CAPITAL CORP       |          | $1,450.13   | Claim # 15 |
	| GOVERNMENT OF THE DISTRICT OF COLUM |          | $1,624.16   | Claim # 14 |
	| COMPTROLLER OF MARYLAND             |          | $5,038.75   | Claim # 10 |
	| U. S. SMALL BUSINESS ADMINISTRATION |          | $934,532.82 | Claim # 13 |
	| 8120, LLC                           |          | $471,585.42 | Claim # 11 |
	| WASHINGTON GAS                      |          | $5,095.88   | Claim # 8  |
	| CIT TECHNOLOGY FINANCING SRVCS, INC |          | $21,749.62  | Claim # 7  |
	| COMMERCIAL LIGHTING COMPANY         |          | MAX         | Claim # 6  |
	#Check that it hasn't dissapeared
	And I See These 'Objection Pending' Claims Under 'Administrative' With Count Of '1'
	| Claim Name                      | Category          | Balance | Number |
	| INSURANCE PARTNERS AGENCY, INC. | Convenience Claim | $2.00   |        |


#Another Selection Required USs
@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102651 @TC104676 @TC104679 @TC104680 @TC104681 @TC104682 @TC104684 @TC104685 @TC104686
@TC104687 @TC104688 @TC104690 @TC104691 @TC104692 @TC104693 @TC104694 @TC104695 @TC104696
@US103038 @TC105061 @TC105062 @TC105063 @TC105064 @TC105065 @TC105066 @TC105067 @TC105068 @TC105069 @TC105070
@US102650 @TC105086 @TC105087 @TC105088 @TC105089
Scenario Outline: Case Detail - New Distribution - Another Selection Required - Amount Equal To Sum of Groups
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '13-18946'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter '<Amount To Distribute>' And 'Automated Test for Another Selection Required' Values On Step One
	And I Click on Next Button
	And I Select Method '<Method>'	
	And I Enter '<Percentage>' And '' On Step Two
	When I Click on Next Button
	Then I See No Message For Another Selection
	Then I See Grouping Title Reads '{ Distribution Grouping(s) }'
	And I See Grouping Box With Correct Data Displays
	#Add Distributing, Claims Included and Includes Objection Pending/ Reserved Claims legend
	| Group Number | Percentage   | Amount Sum             | Method   | Reserved          | Claims Included # | Claims Included List |
	| 1            | <Percentage> | <Amount To Distribute> | <Method> | 0				  | 1                 | 1 Unsecured          |	
	#Verify all the form displays again
	And I See Step Two Message Displays Reading 'First, lets set the distribution amount. Please enter either a percentage OR a dollar amount.'
	And I See New Distribution Form Displays Correctly For Step Two On Grouping With '<Percentage Step 2>' And '<Amount To Distribute>'
	And I See Distribution Methods Are Displayed Correctly
	And I See Distribution Methods Default Selection is '<Method>'
	And I See Payees Message Reading 'Next, let's filter the payees. Please select the classes and categories you would like to be included in this group.'
	And I See Claims Class Header And Some Class Displays
	And I See Claim Class Select All Option Is Active By Default
	And I See Claim Category Header And '0' Category Displays
	And I See Claim Category Select All Option Is Active By Default
	And I See Confirm Selections Message Reads 'Lastly, let's confirm your selections.'
	And I See Confirm Selections Description Reads 'Please note that claims with a status of "Objection Pending" are automatically included and proposed amounts will update as reserved funds when the distribution is posted. If you do not want to include these claims, please unselect them below.'
	And I See Some Claims Display for the Selected Classes and Categories
	#Verify now the button reads "Save" instead of "Next"
	And I See Save Button Displays
	And I See Cancel Button Displays
	Examples:
	| Amount To Distribute | Method                 | Percentage | Percentage Step 2 | Remaining Balance | Groups Number |
	| $141.35              | Pro Rata               | 100%       | 100.0000%         | 0                 | 1             |
	| $141.35              | Pay Each Claim Equally | 100%       | 100.0000%         | 0                 | 1             |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102651 @TC104677
Scenario Outline: Case Detail - New Distribution - Another Selection Required - Amount Less Than Sum of Groups
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '13-18946'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter '<Amount To Distribute>' And 'Automated Test for Another Selection Required' Values On Step One
	And I Click on Next Button
	And I Select Method '<Method>'
	And I Enter '<Percentage>' And '' On Step Two
	And I Click on Next Button
	And I See Message For Another Selection Reads 'Looks like you have $<Remaining Balance> remaining. Let's create another distribution group.'
	And I See Grouping Title Reads '{ Distribution Grouping(s) }'
	And I See Grouping Box With Correct Data Displays
	#Add Distributing, Claims Included and Includes Objection Pending/ Reserved Claims legend
	| Group Number | Percentage   | Amount Sum | Method   | Reserved | Claims Included # | Claims Included List |
	| 1            | <Percentage> | $70.67     | <Method> | 0        | 1                 | 1 Unsecured          |
	And I Enter '<Percentage>' And '' On Step Two
	When I Click on Next Button
	Then I See Message For Another Selection Reads 'Looks like you have $0.01 remaining. Let's create another distribution group.'
	And I See Grouping Title Reads '{ Distribution Grouping(s) }'
	And I See Grouping Box With Correct Data Displays
	#Add Distributing, Claims Included and Includes Objection Pending/ Reserved Claims legend
	| Group Number | Percentage   | Amount Sum | Method   | Reserved | Claims Included # | Claims Included List |
	| 1            | <Percentage> | $70.67     | <Method> | 0        | 1                 | 1 Unsecured          |
	| 2            | <Percentage> | $70.67     | <Method> | 0        | 1                 | 1 Unsecured          |  
	And I Enter '0.0071%' And '' On Step Two
	When I Click on Next Button
	Then I See No Message For Another Selection
	And I See Grouping Title Reads '{ Distribution Grouping(s) }'
	And I See Grouping Box With Correct Data Displays
	#Add Distributing, Claims Included and Includes Objection Pending/ Reserved Claims legend
	| Group Number | Percentage   | Amount Sum | Method   | Reserved | Claims Included # | Claims Included List |
	| 1            | <Percentage> | $70.67     | <Method> | 0        | 1                 | 1 Unsecured          |
	| 2            | <Percentage> | $70.67     | <Method> | 0        | 1                 | 1 Unsecured          |
	| 3            | 0.0071%      | $0.01      | <Method> | 0        | 1                 | 1 Unsecured          |
	And I See Save Button Displays
	Examples:
	| Amount To Distribute | Method                 | Percentage | Remaining Balance | Groups Number |
	| $141.35              | Pro Rata               | 50%        | 70.68             | 1             |
	| $141.35              | Pay Each Claim Equally | 50%        | 70.68             | 1             |

@Ignore
@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@US102651 @TC104678
Scenario Outline: Case Detail - New Distribution - Another Selection Required - Claim Selection
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '13-18946'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter '<Amount To Distribute>' And 'Automated Test for Another Selection Required' Values On Step One
	And I Click on Next Button
	And I Select Method '<Method>'
	And I Enter '<Percentage>' And '' On Step Two
	When I Unselect 'JohnQ' Option From Claims List
	Then I See Next Button Dissapears
	Examples:
	| Amount To Distribute | Method                 | Percentage | Remaining Balance | Groups Number |
	| $141.35              | Pro Rata               | 100%       | 0                 | 1             |
	| $141.35              | Pay Each Claim Equally | 100%       | 0                 | 1             |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution
@U102651 @TC104675
Scenario Outline: Case Detail - New Distribution - Another Selection Required - Amount Higher Than Distribution Amount
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '13-18946'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter '<Amount To Distribute>' And 'Automated Test for Another Selection Required' Values On Step One
	And I Click on Next Button
	And I Select Method '<Method>'
	When I Enter '' And '15000' On Step Two
	And I Click on Next Button
	Then I See A Validation Message on Amount Reading 'The amount needs to be equals or lower than <Amount To Distribute> the distribution amount'
	Examples:
	| Amount To Distribute | Method                 | Percentage | Remaining Balance | Groups Number |
	| $ 141.35              | Pro Rata               | 100%       | 0                 | 1             |
	| $ 141.35              | Pay Each Claim Equally | 100%       | 0                 | 1             |