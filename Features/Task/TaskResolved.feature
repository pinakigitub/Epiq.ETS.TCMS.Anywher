@Regression	
@ReactJS
Feature: TaskResolved
	
Scenario: 001_Task Resolved - Add a Task to Edit it
	Given I enter to Tasks page as superuser
	And I Click on Add Task button
	And a Model appears with title as 'Add Task'
	And I Enter Debtor as 'kavitha'
	When I select Task Type '341 Meeting Prep'
	And I select Status as 'Complete'
	And I enter text in the Notes field '341 Meeting Prep, testing'
	Then I click on Save button
	Then I SignOut from the Unity Application

Scenario: 002_Task Resolved - Edit the Added Case and Marking as Resolved
	Given I enter to Tasks page as superuser
	Given I enter on the office tasks
	And I click on filter search Icon
	And I select TASK TYPE '341 Meeting Prep'
	And I select ASSIGNED TO 'Abhi'
	And I Click on Close Button 
	When I Select the PageSize as 100 under Pagination Section
	And I Click Edit of row with Debtor 'kavitha'
	And a Model appears with title as 'Edit Task'
	Then I click on Save button
	And I SignOut from the Unity Application

Scenario: 003_Task Resolved - Verifying Whether the Case marked as Resolved
	Given I enter to Tasks page as superuser
	Given I enter on the office tasks
	When User click on Filter on Tasks page
	And I Select IS RESOLVED as 'Yes'
	And User click on close on Tasks page
	And I see the Debtor 'kavitha' status as Resolved
	Then I SignOut from the Unity Application