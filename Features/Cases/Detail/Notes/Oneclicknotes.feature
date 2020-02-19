@Regression
@Smoke
@Ignore @DoNotExecute
@OneClickNotes
Feature: OneClickNotes
@171631
@169681

#Verify oneclick notes
Scenario: 001 - Oneclicknotes - Display Notes Window Closed on First Login
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Notes Window is Closed

Scenario: 002 - Oneclicknotes- Open Notes Window and Verify Display
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'	
	When I Click on the Notes Icon
	Then I See the Notes Window is Open
	And I See Note Type Title is 'Note Type'
	And I See Staff Notes Tab Title is 'One Click Notes'
	And I See At Least '1' Notes for the Case

Scenario: 003 - Oneclicknotes - Remember Notes Window Closed Status
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Close Notes Window
	And I Go to 341 Meeting page
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Notes Window is Closed

Scenario: 004 - Oneclicknotes - Create New Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Create a Note with Random Text
	Then I See the New Note at the Top of Notes Historical View Displaying Correct Data

Scenario: 005 - Oneclicknotes - Cancel New Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Click on New Notes Button
	And I Enter a Random Text on the Notes Text Area and Click On Cancel
	Then I See New Note Form has Dissapeared
	And I See the Canceled Note is not Present

Scenario: 006 - Oneclicknotes - Create a New Oneclicknote
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window

Scenario: 007 - Oneclicknotes - Show Oneclicknotes Tab
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	#Then I See a Note with Text '<NoteText>'
	Examples:
	| NoteText               | NoteType |
	| This is a Trustee Note | Trustee  |

Scenario: 008 - Oneclicknotes - click on NewOneclicknote tab in notes section
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Click on New Notes Button

Scenario: 009 - Oneclicknotes - Save Button Becomes is inActive 
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Click on New Notes Button
	And I See the Save Note Button is Inactive

#Adding Oneclick notes
Scenario: 010 - Oneclicknotes - Save Oneclick notes with Label 341 meeting is the type and content
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Click on New Notes Button
	And I Enter the Label text in the Label menu
	And Oneclick type is 341 meeting in the list
	And I Enter the content text in content area
	And I Click on Save button in the Oneclicknote
	And I got to know
     

Scenario: 011 - Oneclicknotes - Save Oneclick notes with Label Trustee is the type and content
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Click on New Notes Button
	And I Enter the Label text in the Label menu
	And Oneclick type is Trustee in the list
	And I Enter the content text in content area
	And I Click on Save button in the Oneclicknote

Scenario: 012 - Oneclicknotes - Save Oneclick notes with Label Office is the type and content
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Click on New Notes Button
	And I Enter the Label text in the Label menu
	And Oneclick type is office in the list
	And I Enter the content text in content area
	And I Click on Save button in the Oneclicknote

Scenario: 013 - Oneclicknotes - Cancel Oneclick notes with Label Office is the type and content
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Click on New Notes Button
	And I Enter the Label text in the Label menu
	And Oneclick type is office in the list
	And I Enter the content text in content area
	And I Click on Cancel button in the Oneclicknote
 
 #View one click notes sections
Scenario: 014 - Oneclicknotes - Able to see Manage one click notes	
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	Then I could see Manage one click notes on the header
	And I could able to see Label in view section
	And I Could able to see Type section
    And I Could able to see Content section

#Edit One click notes
Scenario: 015 - Oneclicknotes - Edit One click notes on Label menu
    Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Clcik on Edit button on the window
	And I Clear the text in the Label area
	And I Enter the Label text in the Label menu
	And I Click on Save button in the Oneclicknote

Scenario: 016 - Oneclicknotes - Edit One click notes on Type Menu and content area
    Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Clcik on Edit button on the window
	And I change the type to Trustee in the type section
	And I clear the text in content area
	And I Enter the content text in content area
	And I Click on Save button in the Oneclicknote

Scenario: 017 - Oneclicknotes - Edit One click notes verify cancel button and save button 
    Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Oneclicknotes Tab
	And I Clcik on Edit button on the window
	And I Click on Cancel button in the Oneclicknote
	