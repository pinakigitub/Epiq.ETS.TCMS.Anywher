@Regression	
@ReactJS	
@FailureCases
Feature: TaskManagementPage
Navigating to the different sections 
		under Task page

@CasesTab
Scenario: 001 - Cases- Tasks page and Filters verification
	Given I enter to Tasks page as superuser
	Then 'Task Management' header should be displayed on Tasks Page
	When User click on Filter on Tasks page
	Then Tasks 'FILTER OPTIONS' should be displayed
	When User click on close on Tasks page
	Then Tasks 'FILTER OPTIONS' should be closed
	When User click on Filter on Tasks page
    And Enter Task Type '341 Meeting Prep' in Tasks filter option
    Then Tasks records should be displayed
    And User click on the reset button on Tasks filter option
    And user click on close button on Tasks filter option
	And I SignOut from the Unity Application

Scenario: 002 - Cases- Tasks Page Pagination and all filter options
    Given I enter to Tasks page as superuser
	Given I enter on the office tasks
	When User click on Filter on Tasks page
	Then Table data should be present on task page
	#//When I select TYPE 'DSO Discharge Notice'
    When Enter Task Type 'DSO Discharge Notice' in Tasks filter option
	#When Enter Assigned to 'Abhi' in Tasks filter option
	#And I select ASSIGNED TO 'Abhi'	
	Then user click on close button on Tasks filter option
	#And Selected result should contains 'AUTOMATION DEBTOR' 'DSO Discharge Notice' 'Abhi'
	When User displays the page count on task page
	Then the selected page records should be displayed
    And I SignOut from the Unity Application

Scenario: 003_cases-Casespecific Navigation on the debtor and Case Number columns
	Given I enter to Tasks page as superuser
	Given I enter on the office tasks
	When I do the mosusehover on debtor column
	And user clicks on the debtor name in task management page
	Then user gets navigate to the case view details
	And I SignOut from the Unity Application

Scenario: 004_Cases-Validate Due Date Color-over due task
	Given I enter to Tasks page as superuser
	Given I enter on the office tasks
	When I do the mosusehover on debtor column
	Then Validate that Due date is in blue color for over due task
	Then Validate that Border is in red color for over due task
	And I SignOut from the Unity Application

@US235861@US235865 
Scenario: 005_Validate the add task is disable and has view button
	Given I enter to Tasks page as user AutomationView with password Welcome456Epiq! and office crose
	Given I enter on the office tasks
	When I try to click on the add task
	Then I click on the view button on the result grid
	And I see all are read only fields on Task View page
	And I SignOut from the Unity Application

@US235863
Scenario: 006_Validate Tasks Create- Save at Case Level
	Given I enter to Tasks page as superuser
	Given I Go to Tasks page
	And I click Add Task Button 
	Then Header should be displayed as - Add Task
    Then Input '17-19895' also I select debtorname '17-19895 / QA-Testing-6,' 
	Then I select 'Document Request' from Task Type
	And I click on Save button on Add Task
	And Task Record should be added and saved
    And I SignOut from the Unity Application

@US235864
Scenario: 007_Validate Tasks Edit at Case Level
	Given I enter to Tasks page as superuser
	Given I enter on the office tasks
    When I Click On Edit of Task
	Then I click on Is Resolved Checkbox on Task Page
	And I click on Save button on Add Task
	And Task Record should be edited and saved
    And I SignOut from the Unity Application

@US235862
Scenario: 008_Validate Tasks Filters at Case Level
	Given I enter to Tasks page as user AutomationView with password Welcome456Epiq! and office crose
	Given I enter on the office tasks
	When User click on Filter on Tasks page
    And Enter Task Type '341 Meeting Prep' in Tasks filter option
	Then user click on close button on Tasks filter option
    Then Tasks records should be displayed
	And I SignOut from the Unity Application

@US235854
Scenario: 009_Validate Tasks In Line Editing
    Given I enter to Tasks page as superuser
		Given I enter on the office tasks
	 When I Click on Notes Button on Task
	    Then I should be able to edit Notes on Task
	 When I Click on Due Date Button on Task
	    Then I should be able to edit Due Date as '02/10/18' on Task
	 When I Click on Due Date Button on Task
	    Then I should be able to edit Due Date as '12/09/10' on Task
	 When I Click on Assigned To Button on Task
        Then I should be able to edit Assigned To on Task
	 When I Click on Status Button on Task
     Then I SignOut from the Unity Application

@US231111
Scenario: 010_Validate Tasks - Create - Save Plus New
	Given I enter to Tasks page as superuser
	And I click Add Task Button 
		And I Enter Debtor as '15-10024'
	     Then I select 'Document Request' from Task Type
	     And I click on SavePlusAddNew button on Add Task
	     And Task Record should be added and saved
		 And I see the Add Task Page for adding new task
	     And I SignOut from the Unity Application

