@Ignore
Feature: Case Detail - Distribution Summary
	In order to manage the payments on a Case
	As a user of Unity
	I need to be able to see the distributions I have on that case

@CaseDetail
@Regression @Sanity
@CaseDistribution
@CaseDistributionsSummary 
@US36887 @TC100946
Scenario: Case Detail - Distributions Tab - Sections Display (Desktop)
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '06-15658'
	And I Go to Distribution
	Then I See the Distribution Page Displays and Tab Title is 'Distribution'
	And I See the Distribution Summary Section With Title 'Summary'

@CaseDetail
@Regression
@CaseDistribution
@CaseDistributionsSummary 
@US102299 @TC102633
@US105314 @TC105418 @TC105422
Scenario: Case Detail - Distributions Summary - No Distributions And No Claims
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '0:000-XXX'
	And I Go to Distribution
	Then I See No Distribution Summary Items And a Message Shows Reading 'No Results Available - Please Add Claims for this Case'
	And  I See New Distribution Button is Disabled

@CaseDetail
@Regression
@CaseDistribution
@CaseDistributionsSummary 
@US102299 @TC102633
@US105314 @TC105418 @TC105422
Scenario: Case Detail - Distributions Summary - Case With No Distributions But Having Claims
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '13-18946'
	And I Go to Distribution
	Then I See No Distribution Summary Items And a Message Shows Reading 'No Results Available'
	And  I See New Distribution Button is Enabled

@CaseDetail 
@Regression
@CaseDistribution
@CaseDistributionsSummary
@US36887 @TC101093 @TC101094 @TC101095 @TC101096 @TC101097 @TC101098 @TC101090 @TC101100 @TC101101
@US102299 @TC102761
@US77736 @TC102828 @TC102829 @TC102830 @TC102831 @TC102833
Scenario: Case Detail - Distributions Summary - Cards Content And Selection
	Given I enter to Dashboard page as superuser
	And I Enter to Case Detail page for Case with Case Number '03-30103'
	And I Go to Distribution
	Then I See Distribution Summary Cards and All Values are Correct
	#Preserve table rows order, positions should match
	| Distribution Name    | Status   | Modified Payment | Calculated Payment | Difference | Updated Date |
	| Final Distribution   | EDITABLE | $30,302.04       | $30,302.04         | $0.00      | 02-23-2015    |
	| Final Distribution 2 | EDITABLE | $30,302.04       | $30,302.04         | $0.00      | 12-10-2014   |
	| Final Distribution   | POSTED   | $30,302.04       | $30,302.04         | $0.00      | 02-23-2015    |	
	And First Card is Selected By Default And Selecting Each Card Displays Distribution Detail