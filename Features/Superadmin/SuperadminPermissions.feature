@Superadmin
Feature: Super Admin Permission
	In order to be able to delete Assets, Dockets, Documents and make additional data updates as they become requested within
			 Unity, so they do not need to have the ETS team do updated scripts to perform these commonly requested functions
	As a user of TNET and Unity in Operations,
	I need to have a new permission added to the available list of Epiq Users of "SUPER ADMIN"
		     and a new "Super Admin" page on Unity

##Access and layout verificantions
#@US170219
#Scenario: Super Admin - Permission allows to access SUPERADMIN Page
#	Given I login to Unity as Super Admin user
#	Then I Can see Super Admin link 
#	And I Navigate to Super Admin page	
#
#@US170219 @US170063 @US170131 @US170137
#Scenario: Super Admin - Super Admin Page Layout
#	Given I login to Unity as Super Admin user
#	When I Navigate to Super Admin page
#	And I Search for a Case to add Items that will be deleted
#	Then I See Super Admin page with correct layout
#
#@US170219
#Scenario: Superadmin - Without Permission cannot see SUPERADMIN Link
#	Given I login to Unity as NON Super Admin user
#	Then I Cannot see Super Admin link
#
#@US170219
#Scenario: Superadmin - Without Permission cannot access SUPERADMIN Page through URL
#	Given I login to Unity as NON Super Admin user
#	When I replace the URL with Super Admin link
#	Then I Cannot see Super Admin page
#	And I See Unauthorized Access Message reading 'Oops.. it seems you don't have permission to go there! Try again or go back home.'
#
##Delete Items
#@US170067 @US170133 @170139
#@DeleteSuperadmin
#Scenario Outline: Super Admin - Delete One Item
#	Given I login to Unity as Super Admin user
#	And I Navigate to Super Admin page
#	And I Search for a Case to add Items that will be deleted
#	And I Add '1' Items of type '<Item Type>' in the Case on database
#	When I Click on Superadmin <Item Type> button
#	Then I See an Alert Message that reads '<Expected Message >'
#	And I Select all created <Item Type> items
#	And I Click On Super Admin Delete Button
#	And I See a confirmation dialog reading 'Are you sure you want to delete the selected 1 <Item Type>(s)'
#	And I Click Yes to delete
#	And I See the records are gone
#	Examples:
#	| Item Type | Expected Message                       |
#	| Asset     | CAUTION THIS IS A HARD DELETE          |
#	| Docket    | CAUTION THIS IS A HARD DELETE          |
#	| Document  | SHOW ONLY DELETED DOCUMENT(S) FOR CASE |
#
#@US170067 @US170133 @170139
#@DeleteSuperadmin
#Scenario Outline: Super Admin - Delete Multiple Items
#	Given I login to Unity as Super Admin user
#	And I Navigate to Super Admin page
#	And I Search for a Case to add Items that will be deleted
#	And I Add '3' Items of type '<Item Type>' in the Case on database
#	When I Click on Superadmin <Item Type> button
#	And I Select all created <Item Type> items
#	When I Click On Super Admin Delete Button
#	Then I See a confirmation dialog reading 'Are you sure you want to delete the selected 3 <Item Type>(s)'
#	And I Click Yes to delete
#	And I See the records are gone
#	Examples:
#	| Item Type |
#	| Asset     |
#	| Docket    |
#	| Document  |