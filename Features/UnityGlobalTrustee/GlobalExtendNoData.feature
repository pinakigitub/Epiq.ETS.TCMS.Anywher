@Regression	
@ReactJS	
Feature: GlobalExtendNoData
	In order to Verify Extend No Data Display message for New page

Background: 
When I login to Unity as NON Super Admin user

@202711
 Scenario Outline: 001 - Unity Pages- Global NavBar:Extend No Data Display validation
	When I Go to <selection> page 
	Then  I see <Header> header
	And I see <SubHeader> subheader
	And I see <Message> message
	Then I SignOut from the Unity Application

	Examples: 
	| selection                | Header                  | SubHeader                  | Message                   |
	| Case List                | Case Management         | Cases                      | No matching cases         |
	| Assets                   | Asset Management        | Assets                     | No matching assets        |
	| Bank Accounts            | Banking Center          | Bank Accounts              | No matching accounts      |
	| Banking Activity         | Banking Center          | Unreconciled Bank Accounts | No matching activity      |
	| Banking ReceiptLog       | Banking Center          | Receipts                   | No matching receipts      |
	| Banking ChecksOrDeposits | Banking Center          | Print Checks/Deposits      | No matching transactions  |
	| Claims                   | Claims Management       | Claims                     | No matching claims        |
	| Dates                    | Date Management         | Dates                     | No Dates Available Matching Current View         |
	| Distributions            | Distribution Management | Distributions             | No matching distributions |
	| Documents                | Document Management     | Documents                | No matching documents   |
	| DSO                      | DSO Management          | DSO Claimants            | No matching claimants |
	#| Participants             | Participant Management  | Participants             | No Participants Available Matching Current View  |
	| Tasks                    | Task Management         | Tasks                 | No matching tasks                   |
	
@220246
 Scenario Outline: 002 - Unity Pages- Dashboard:Extend No Data Display validation
	Then I see Dashboard header '<selection>' 
	Then  I see '<DashboardMessage>' dashboardmessage
	Then I SignOut from the Unity Application

	Examples: 
	| selection             | DashboardMessage                                                 |
	| Upcoming 341 Meetings | No Upcoming 341 Meetings Matching Current View                   |
	| Past 341 Meetings     | No Past 341 Meetings Matching Current View                       |
	| This Week's Tasks     | No current tasks                                   |
	| DSO Summary           | No upcoming claimants |
	| Favorites             | No current favorites               |
		






