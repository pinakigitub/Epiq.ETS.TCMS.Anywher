@Regression	
@ReactJS
Feature: Dashboard_Enhancements
	In order to verify Dashboard navigations
	And verify 341 meeting count on Dashboard

@US#199371
@US#186079
Scenario:001- Verify All Dashboard headers
Given I enter to Dashboard page as superuser 
Then I see Dashboard header 'Banking Summary'
Then I see Dashboard header 'Upcoming 341 Meetings'
Then I see Dashboard header 'Past 341 Meetings'
Then I see Dashboard header 'This Week's Tasks'
Then I see Dashboard header 'DSO Summary'
Then I see Dashboard header 'Favorites'
Then I SignOut from the Unity Application


@US#199371
Scenario Outline:002- Verify Navigation from Banking Summary
Given I enter to Dashboard page as superuser
When I click on link <LINK>
Then I see <HEADER> header
Then '<BREADCRUMB>' Breadcrumb should display
Then I SignOut from the Unity Application

Examples:

| LINK         | HEADER         | BREADCRUMB                    |
| 1            | Banking Center | DashboardBank Accounts        |
| 2            | Banking Center | DashboardBanking Activity     |
| 3            | Banking Center | DashboardBanking Activity |
| 4            | Banking Center | DashboardBanking Activity   |
| 5            | Banking Center | DashboardReceipt Log          |
| 6            | Banking Center | DashboardBanking Activity       |

@US#199371
Scenario:003- Verify Navigation from This Week's Tasks
Given I enter to Tasks page as superuser
Given I enter on the office tasks
Then 'DashboardOffice Tasks' Breadcrumb should display
Then I SignOut from the Unity Application

@US#201830
Scenario:004- Verify 341 meeting count on Dashboard
Given I enter to Dashboard page as superuser
Then verify the 341 meetings UI count
Then Verify the 341 meetings count from DB
Then I SignOut from the Unity Application

@US248205
Scenario:005- Verify UpComing341MeetingTile- New Cases 
	Given I enter to Dashboard page as superuser
	Then I see Dashboard header 'Upcoming 341 Meetings'
	When I click on New Cases then cases should be displayed or a message 'No data to display'
	Then I see the Page Header Title as '341 Docket'
	When I click on filter search Icon
	Then I see Default value of 'CONTINUED FROM PRIOR MEETING' as 'No'
	And I Click on Close Button
	Then I SignOut from the Unity Application

@US248207
Scenario:006- Verify UpComing341MeetingTile- Continued Cases 
	Given I enter to Dashboard page as superuser
	Then I see Dashboard header 'Upcoming 341 Meetings'
	When I click on Continued Cases then cases should be displayed or a message 'No data to display'
	Then I see the Page Header Title as '341 Docket'
	When I click on filter search Icon
	Then I see Default value of 'CONTINUED FROM PRIOR MEETING' as 'Yes'
	And I Click on Close Button
	Then I SignOut from the Unity Application

@US248205
Scenario:007- Verify UpComing341MeetingTile
	Given I enter to Dashboard page as superuser
	Then I see Dashboard header 'Upcoming 341 Meetings'
	When I click on New Cases then cases should be displayed or a message 'No data to display'
	Then I see the Page Header Title as '341 Docket'
	When I click on filter search Icon
	Then I see Default value of 'CONTINUED FROM PRIOR MEETING' as 'No'
	And I Click on Close Button
	Then I SignOut from the Unity Application

@US248206
Scenario:008- UpComing341Meeting and Verification "No data to display" In the Page
    Given I enter to Dashboard page as superuser
	Then I see header in the dashboard page as 'Upcoming 341 Meetings'
	When I click on Continued Cases and I should be able to see a message 'No data to display'
	Then I see the Page Header Title as '341 Docket'
    Then I SignOut from the Unity Application

@US248206
Scenario:009- UpComing341Meeting and filter verification in the page
    Given I enter to Dashboard page as superuser
	Then I see header in the dashboard page as 'Upcoming 341 Meetings'
	When I click on Continued Cases then cases should be displayed or a message 'No data to display'
	Then I see the Page Header Title as '341 Docket'
	When I click on filter Icon in the page
	Then I see Default value of 'CONTINUED FROM PRIOR MEETING' as 'Yes'
	Then I SignOut from the Unity Application

@US256014
Scenario:010_ Dashboard Task Tile - Open a Task
	Given I enter to Tasks page as superuser
	Given I enter on the office tasks
	Then 'DashboardEdit Task' Breadcrumb should display
	And I see CaseNumber '08-11555 / NICOL, FRANK E' in CaseNavigation
	And the Page Navigation 'Tasks'
	When I select Task Type 'DSO Initial Notice'
	And I select Status as 'Due'
	And I select Assign as 'Sushma'
	And I enter text in the Notes field 'DSO Initial Notice, testing'
	Then I click 'CANCEL'
	Then 'DashboardMy Tasks' Breadcrumb should display
	And I click on BreadCrumb 'Dashboard'
	Then I see CaseNumber '08-11555 / NICOL, FRANK E' in CaseNavigation
	And the Page Navigation 'Dashboard'
	Then 'Case ListCase Details' Breadcrumb should display
	And I SignOut from the Unity Application

@US256014
Scenario:011_Dashboard Task Tile - View a Task
	Given I enter to Task page as user AutomationView with password Welcome456Epiq! and office crose
   Given I enter on the office tasks
	Then 'TasksView Task' Breadcrumb should display
	And I see CaseNumber '08-11555 / NICOL, FRANK E' in CaseNavigation
	And the Page Navigation 'Tasks'
	And I verify 'CASE # / DEBTOR NAME-0:V327646-XXX / MANN BRACKEN, LLC RECEIVERSHIP ;TASK TYPE-DSO Initial Notice;DUE DATE-12/09/10;STATUS-Due;ASSIGN-Sushma;NOTES-DSO Initial Notice, testing'
	Then I click 'CLOSE'
	Then 'DashboardMy Tasks' Breadcrumb should display
	And I click on BreadCrumb 'Dashboard'
	Then I see CaseNumber '08-11555 / NICOL, FRANK E' in CaseNavigation
	And the Page Navigation 'Dashboard'
	Then 'Case ListCase Details' Breadcrumb should display
	And I SignOut from the Unity Application

@US270473
Scenario:012_Dashboard navigation from Logo in Header
	 Given I enter to Dashboard page as superuser
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Case List page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to 341 Meeting page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Assets page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
     And I Go to Bank Accounts page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Banking Activity page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Banking ReceiptLog page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Banking ChecksOrDeposits page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Claims page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Dates page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Distributions page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Documents page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to DSO page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Emails page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Imports Claims page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Import Assets page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Imports Dates page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Imports Documents page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Participants page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Reports page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Schedule to Claim Reconciliation page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I see the Search box under All Cases Section
	 When I Enter '17-90000' On The Universal Search Section Input
	 And I Click on the Case Result '17-90000'
	 And I Go to Tasks page
	 Then I click on Epiq Unity Logo in Header
	 Then I  redirected to the 'All Cases','Dashboard'page
	 And I SignOut from the Unity Application
