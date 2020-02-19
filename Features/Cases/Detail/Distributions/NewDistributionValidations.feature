@Ignore
Feature: Case Detail - Distribution New - Validations
	In order to make money distributions for my Case
	As a user of Unity
	I need to be able to create a new Distribution

@Regression
@CaseDetail @CaseDistribution 
@NewDistribution @NewDistributionValidations
@US102298 @TC102925 @TC102926 @TC102927 @TC102928 @TC102929 
Scenario Outline: Case Detail - New Distribution - Step 1 - Name and Amount Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	When I Enter '<AmountToDistribute>' And '<Name>' Values On Step One
	And I Click on Next Button
	Then I See Validations On Amount If Not '<IsValidAmount>' And On Name If Not '<IsValidName>'
	And I See Step Two Is Not Displayed On Validation Errors
	And Entering Valid Values For Amount and Distribution Name Makes The Validation Messages Dissapear
	Examples:
	| AmountToDistribute | IsValidAmount | Name                               | IsValidName |
	|                    | False         |                                    | False       |
	| 100                | True          |                                    | False       |
	|                    | False         | Automatic Test of New Distribution | True        |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US103046 @TC103761 @TC103775
Scenario Outline: Case Detail - New Distribution - Step 2 - Percentage and Amount Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter '<Percentage>' And '<Amount>' On Step Two	
	And I Click on Next Button
	Then I See Validations On Percentage If Not '<IsValidPercentage>' And On Amount If Not '<IsValidAmount>'
	And Entering Valid Values For Percentage and Amount Makes The Validation Messages Dissapear
	Examples:
	| Percentage | IsValidPercentage | AmountToDistribute | IsValidAmount |
	|            | False             |                    | False         |
	#This one fails because clicking on Next does not validate. See if this is fixed on it13 changes
	# 50         | False             | 0                  | False         |	

#TODO: these scenario is failing because tab does not trigger validations on Step 1
#@Ignored
#@Regression
#@CaseDetail @CaseDistribution
#@NewDistribution @NewDistributionValidations
#@US102298 @TC102930 
#Scenario Outline: Case Detail - New Distribution - Step 1 - Tab Triggers Validations
#	Given I enter to Dashboard page as superuser
#	And I Enter to Case Detail page for Case with Case Number '10-14868'
#	And I Go to Distribution
#	And I Click on New Distribution Button on Summary Card
#	When I Enter '<InvalidValue>' on Field '<Field>' for New Distribution And Press Tab
#	Then I See A Validation Error On '<Field>' Reading '<ValidationMessage>'
#	Examples:
#	| Field          | InvalidValue | ValidationMessage                                   |
#	| ProposedAmount |     0        | The AMOUNT TO DISTRIBUTE needs to be greater than 0 |
#	| Name           |              | DISTRIBUTION NAME is required                       |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US102298 @TC102930 
Scenario Outline: Case Detail - New Distribution - Step 2 - Tab Triggers Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter '<InvalidValue>' on Field '<Field>' for New Distribution And Press Tab
	Then I See A Validation Error On '<Field>' Reading '<ValidationMessage>'
	Examples:
	| Field            | InvalidValue | ValidationMessage                             |
	| Percentage       |              | The percentage needs to be greater than 0.00% |
	| Percentage       | 0            | The percentage needs to be greater than 0.00% |
	#| CalculatedAmount |              | The amount needs to be greater than $ 0.00    |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US102298 @TC102931 
Scenario Outline: Case Detail - New Distribution - Step 1 - Enter Triggers Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	When I Enter '<InvalidValue>' on Field '<Field>' for New Distribution And Press Enter Key
	Then I See A Validation Error On '<Field>' Reading '<ValidationMessage>'
	Examples:
	| Field          | InvalidValue | ValidationMessage                                   |
	| ProposedAmount |              | The AMOUNT TO DISTRIBUTE needs to be greater than 0 |
	| Name           |              | DISTRIBUTION NAME is required                       |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US102298 @TC102931 
Scenario Outline: Case Detail - New Distribution - Step 2 - Enter Triggers Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter '<InvalidValue>' on Field '<Field>' for New Distribution And Press Enter Key
	Then I See A Validation Error On '<Field>' Reading '<ValidationMessage>'
	Examples:
	| Field            | InvalidValue     | ValidationMessage                                                            |
	| Percentage       |                  | The percentage is required                                                   |
	| Percentage       | 0                | The percentage needs to be greater than 0.00%                                |
	#Fails when it shouldn't - check with QA
	| CalculatedAmount |				  | The amount needs to be greater than $ 0.00 |
	| CalculatedAmount | 6264625          | The amount needs to be equals or lower than $ 100.00 the distribution amount |


@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US103046 @TC103735 @TC103738 @TC103741 @TC103742 @TC103734 @TC103744
Scenario Outline: Case Detail - New Distribution - Step 2 - Percentage Value Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter Percentage '<Percentage>' On Step Two
	Then I See Percentage Field Value Is '<ExpectedDisplayValue>'
	Examples:
	| Percentage | ExpectedDisplayValue |
	| 15         | 15%                  |
	| &25.1 abc  | 25.1%                |
	| 25.1       | 25.1%                |
	| 25.325     | 25.325%              |
	| 25.6543    | 25.6543%             |
	| 25.12345   | 25.1234%             |
	| 25.123456  | 25.1234%             |
	| 100.00     | 100.00%              |
	| 105.00     | 10.00%               |
	| 200        | 20%                  |
	| -45        | 45%                  |
	| 25         | 25%                  |
	| 25.04      | 25.04%               |
	| 25%        | 25%                  |
	| 25.0589    | 25.0589%             |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US103046 @TC103751
Scenario Outline: Case Detail - New Distribution - Step 2 - Calculated Amount Value Validations
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter Amount '<Amount>' On Step Two
	Then I See Calculated Amount Field Value Is '<ExpectedDisplayValue>'
	Examples:
	| Amount         | ExpectedDisplayValue |
	| 13,456,789.00% | $13,456,789.00       |
	| 789.57         | $789.57              |
	| 1.00           | $1.00                |

@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US103046 @TC103753 @TC103754
Scenario Outline: Case Detail - New Distribution - Step 2 - Calculated Amount Updates on Percentage Update
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter Percentage '<Percentage>' On Step Two
	Then I See Calculated Amount Field Value Corresponds to Percentage and Is Rounded
	Examples:
	| Percentage |
	| 25.0585%   |
	| 30%        |
	| 100%       |


@Regression
@CaseDetail @CaseDistribution
@NewDistribution @NewDistributionValidations
@US103046 @TC??????
Scenario Outline: Case Detail - New Distribution - Step 2 - Percentage Updates on Calculated Amount Update
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '10-14868'
	And I Go to Distribution
	And I Click on New Distribution Button on Summary Card
	And I Enter Valid Values on Mandatory Fields for New Distribution
	And I Click on Next Button
	When I Enter Amount '<Amount>' On Step Two
	Then I See Calculated Amount Field Value Corresponds to Percentage and Is Rounded
	Examples:
	| Amount     |
	| 10.00       |