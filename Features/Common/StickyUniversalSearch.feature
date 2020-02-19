@Regression
@ReactJS
@Ignore @DoNotExecute
@UniversalSearch
Feature: Universal Search Sticky Bar
	In order to search for any resource on the application
	As a user of Unity 
	I want the ability to perform a search across the database on any page using a Sticky Bar Search Tool

Scenario: 001_New Sticky Bar Universal Search On Sticky Bar on Dashboard Page
Given I enter to Dashboard page as superuser
And I see the Magnifying Glass Icon Is Present
When I Enter 'bc' On The Universal Search Section Input
Then The Search Unfolds and Displays The Message as 'No results available'
And I SignOut from the Unity Application

Scenario Outline: 002_New Sticky Bar Universal Search - Search With Cases on ActivityPage
Given I enter to Dashboard page as superuser
And I select Activity under BankingCenter
When I Enter '<Search Text>' On The Universal Search Section Input
Then I See Only Cases Matching the '<Search Text>' on the Result List
And I SignOut from the Unity Application
Examples:
|Search Text|
| 6V-XXX      |
| 01-       |
| 13-17275  |

Scenario Outline: 003_New Sticky Bar Universal Search - Search With Cases on CaseListPage
Given I enter to Dashboard page as superuser
And I click on CaseList under Cases
When I Enter '<Search Text>' On The Universal Search Section Input
Then I See Only Cases Matching the '<Search Text>' on the Result List
And I SignOut from the Unity Application
Examples:
|Search Text|
| MULTICONSULTANT |
| 0:W36           |

Scenario: 004_New Sticky Bar Universal Search - Search With Two Character on ReportsPage
Given I enter to Dashboard page as superuser
And I Navigate to ReactReports
When I Enter 'abcdefg' On The Universal Search Section Input
Then The Search Unfolds and Displays The Message as 'No results available'
And I SignOut from the Unity Application


@Sanity
@UniversalSearch
@US123287
Scenario: 005 - Sticky Bar Universal Search - Not Display Universal Search On Sticky Bar on Dashboard or Case List Page
Given I enter to Dashboard page as superuser
Then I DO NOT See The Universal Search As A Sticky Bar
And I Go to Case List page
And I DO NOT See The Universal Search As A Sticky Bar
And I SignOut from the Unity Application

@Sanity
#@UniversalSearch
#@US123287
#Scenario Outline: 002 - Sticky Bar Universal Search - Display Universal Search As Sticky Bar
#Given I enter to 341 Meeting page as superuser
#When I Go to <Target Page> page
##sticky property - scroll down nd verify is still visible
#Then I See The Universal Search As A Sticky Bar
#And DropDown Label is 'Cases'
#And Search Input Placeholder is 'Search...'
#And Magnifying Glass Icon Is Present
#And I Enter '' On The Universal Search Input
#And The Search Unfolds and Displays The Message 'Please enter 2 or more characters'
#Examples:
#| Target Page |
#| Reports     |

@Sanity
#@UniversalSearch
#@US123287
#Scenario: 003 - Sticky Bar Universal Search - Display Universal Search Sticky On Case Detail
#Given I enter to 341 Meeting page as superuser
#When I Enter to Case Detail page for Case with Case Number '10-14868'
#Then I See The Universal Search As A Sticky Bar

@Sanity
#@UniversalSearch
#@US123287
#Scenario Outline: 004 - Sticky Bar Universal Search - Display Universal Search Sticky On Case Detail Tabs
#Given I enter to 341 Meeting page as superuser
#And I Enter to Case Detail page for Case with Case Number '10-14868'
#When I Go to <Detail Tab>
#Then I See The Universal Search As A Sticky Bar
#And DropDown Label is 'Cases'
#And Search Input Placeholder is 'Search...'
#And Magnifying Glass Icon Is Present
#And I Enter '' On The Universal Search Input
#And The Search Unfolds and Displays The Message 'Please enter 2 or more characters'
#Examples:
#| Detail Tab     |
#| Assets Detail  |
#| Banking Detail |
#| Claims Detail  |



@Regression
@UniversalSearch
@US123287
Scenario: 006 - Sticky Bar Universal Search - Search With One Character
Given I enter to 341 Meeting page as superuser
And I Enter to Case Detail page for Case with Case Number '10-14868'
#When I Enter '(((' On The Universal Search Input
#Then The Search Unfolds and Displays The Message 'No results available'
#And I SignOut from the Unity Application


#@Regression
#@UniversalSearch
#@US123287
#Scenario Outline: 007 - Sticky Bar Universal Search - Search No Results
#Given I enter to 341 Meeting page as superuser
#And I Enter to Case Detail page for Case with Case Number '10-14868'
#When I Enter '<Search Text>' On The Universal Search Input
#Then The Search Unfolds and Displays The Message 'No results available'
#And I SignOut from the Unity Application
#Examples:
#| Search Text |
#| >>>>>>>     |
#| &&%$$       |

#@Sanity
#@UniversalSearch
#@US123287
#Scenario Outline: 008 - Sticky Bar Universal Search - Search With Two Characters And More Than Five Results
#Given I enter to 341 Meeting page as superuser
#And I Enter to Case Detail page for Case with Case Number '10-14868'
#When I Enter '<Search Text>' On The Universal Search Input
#Then I See Only Cases Matching '<Search Text>' on the Result List
#And I SignOut from the Unity Application
#Examples:
#| Search Text     |
#| MULTICONSULTANT |
#| 0:W36           |
#| -XXX            |
#| 01-             |
#| 0:13-17275-WIL  |
#
#@Regression
#@UniversalSearch
#@US123287
#Scenario: 009 - Sticky Bar Universal Search - Navigate to Case Detail
#Given I enter to 341 Meeting page as superuser
#And I Enter to Case Detail page for Case with Case Number '10-14868'
#When I Enter '0:13-17275-WIL' On The Universal Search Input
#And I Click on the Case Result '0:13-17275-WIL'
#Then I See The Case Detail Page Displays For Case Number '13-17275' With Case Name 'NICOLE FOXX REID'
#And I SignOut from the Unity Application