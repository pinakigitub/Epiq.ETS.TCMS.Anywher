@Regression
@Smoke
@ReactJS	

Feature: DashboardNewUniversalSearch
	In order to search for any resource on the application
	As a user of Unity 
	I want the ability on my Landing Page to perform a search across the database

@Dashboard 
@UniversalSearch
#Scenario: 001_NewDashboard - Universal Search - SearchBox Layout
#Given I enter to Dashboard page as superuser
#And I see the Search box under All Cases Section
#And I see the Magnifying Glass Icon Is Present
#And I see the text 'SELECT A CASE' under Search Section
#Then I SignOut from the Unity Application
#
#Scenario: 002_NewDashboard - Universal Search - SelectingCase using CaseNumber
#Given I enter to DSO page as superuser
#And I see the Search box under All Cases Section
#When I Enter '13-17275' On The Universal Search Section Input
#And I Click on the Case Result '13-17275'
#Then I SignOut from the Unity Application
#
#Scenario: 003_NewDashboard - Universal Search - SelectingCase using CaseName
#Given I enter to Case List page as superuser
#And I see the Search box under All Cases Section
#When I Enter 'MULTICONSULTANT' On The Universal Search Section Input
#And I Click on the Case Result 'MULTICONSULTANT'
#Then I SignOut from the Unity Application
#
#Scenario: 004_NewDashboard - Universal Search - Selecting CaseNumber and Navigate to ClaimsPage
#Given I enter to Assets page as superuser
#And I see the Search box under All Cases Section
#When I Enter '17-90000' On The Universal Search Section Input
#And I Click on the Case Result '17-90000'
#Then I Go to Claims page
#And I SignOut from the Unity Application

#Scenario: 005_Mouseover on the debtor name -favorite tile
#Given I enter to Dashboard page as superuser
#When user perform mouseover on debtor name
#Then I SignOut from the Unity Application


Scenario: 006_Mouseover on the debtor name-task tile
Given I enter to Dashboard page as superuser
#When user perform mouseover on debtor name on task tile
Then I SignOut from the Unity Application