@Regression
@Ignore @DoNotExecute
@ReactJS
Feature: Universal Search On Dashboard
	In order to search for any resource on the application
	As a user of Unity 
	I want the ability on my Landing Page to perform a search across the database

@Sanity
#@Dashboard 
#@UniversalSearch
#@US96820 @TC100855 @TC10855 @TC101119 @TC101122
#Scenario: Dashboard - Display Universal Search on Dashboard
#Given I enter to 341 Meeting page as superuser
#Then I See The Universal Search Section
#And Search Title is 'Let's Get Started...'
#And DropDown Label is 'Cases'
#And Search Input Placeholder is 'Search...'
#And Magnifying Glass Icon Is Present
#And I Enter '' On The Universal Search Input
#And The Search Unfolds and Displays The Message 'Please enter 2 or more characters'

@Dashboard 
@UniversalSearch
@US97301 @TC101270
Scenario: Dashboard - Universal Search With One Character
Given I enter to Dashboard page as superuser
When I Enter 'bc' On The Universal Search Section Input
Then The Search Unfolds and Displays The Message as 'No results available'
And I SignOut from the Unity Application

@Dashboard 
@UniversalSearch
@US97301 @TC101272
Scenario Outline: Dashboard - Universal Search - No Results
Given I enter to Dashboard page as superuser
When I Enter '<Search Text>' On The Universal Search Section Input
Then The Search Unfolds and Displays The Message as 'No results available'
And I SignOut from the Unity Application

Examples:
| Search Text |
| abc123      |
| &&%$$       |

@Sanity
@Dashboard 
@UniversalSearch
@US97301 @TC101269 @TC101271 @TC101273
Scenario Outline: Dashboard - Universal Search With Two Characters And More Than Five Results
Given I enter to Dashboard page as superuser
When I Enter '<Search Text>' On The Universal Search Section Input
Then I See Only Cases Matching the '<Search Text>' on the Result List
And I SignOut from the Unity Application
Examples:
| Search Text     |
| MULTICONSULTANT |
| 0:W36           |
| 6V-XXX          |
| 01-             |
| 13-17275		  |

@Dashboard 
@UniversalSearch
@US97301 @TC101276 
@US102350 @TC102405
Scenario: Dashboard - Universal Search - Navigate to Case Detail
Given I enter to 341 Meeting page as superuser
When I Enter '13-17275' On The Universal Search Input
And I Click on the Case Result '13-17275'
Then I See The Case Detail Page Displays For Case Number '13-17275' With Case Name 'NICOLE FOXX REID'
And I SignOut from the Unity Application