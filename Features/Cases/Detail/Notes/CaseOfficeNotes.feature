@Regression
@Ignore @DoNotExecute
Feature: Case Detail - Case Office Notes
	In order to be able to add, review, edit, and delete notes for a case.
	As a user of Unity
	I need to have a window  for Notesthat is active on all screens and tied back to the case I am viewing

# Notes Window Diplay and Sticky Settings (US 46455)
@CaseDetail @CaseNotes
@US46455 @TC61633
Scenario: 001 - Case Notes - Display Notes Window Closed on First Login
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Notes Window is Closed

@CaseDetail @CaseNotes
@US46455 @TC61633 @TC61673
Scenario: 002 - Case Notes - Open Notes Window and Verify Display
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'	
	When I Click on the Notes Icon
	Then I See the Notes Window is Open
	And I See Note Type Title is 'Note Type'
	And I See Staff Notes Tab Title is 'Office'
	And I See At Least '1' Notes for the Case
	

@CaseDetail @CaseNotes
@US46455 @TC61633 @TC61673
Scenario: 003 - Case Notes - Open Notes Window and Verify Display of No Notes
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '11-14933'	
	When I Click on the Notes Icon
	Then I See Exactly '0' Notes for the Case

@CaseDetail @CaseNotes
@US46455 @TC61673
Scenario: 004 - Case Notes - Close Notes Window
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Click on the Notes Icon
	And I Click on the Notes Icon
	Then I See the Notes Window is Closed


@CaseDetail @CaseNotes
@US46455 @TC61693
@BugToReviewWithDev
@Fix @Ignore @DoNotExecute
Scenario: 005 - REVIEW_FOR_BUG_Case Notes - Remember Notes Window Open Status (Desktop Only)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Click on the Notes Icon
	And I See the Notes Window is Open
	And I Go to Case List page	
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Notes Window is Open

@CaseDetail @CaseNotes
@US46455 @TC61693
Scenario: 006 - Case Notes - Remember Notes Window Closed Status (Desktop Only)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Close Notes Window
	And I Go to 341 Meeting page
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Notes Window is Closed

@CaseDetail @CaseNotes
@US46455 @TC61693
Scenario: 007 - Case Notes - Forget Notes Window Status On Logout (Desktop Only)
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Click on the Notes Icon
	And I See the Notes Window is Open
	And I do Logout
	And I enter to 341 Meeting page as superuser	
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Notes Window is Closed

# New Notes (US 46457)
@CaseDetail @CaseNotes
@Sanity
@US46457 @TC72794 @TC72798 @TC61772
Scenario: 008 - Case Notes - Create New Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Create a Note with Random Text
	Then I See the New Note at the Top of Notes Historical View Displaying Correct Data

@CaseDetail @CaseNotes
@US46457 @TC72799 
Scenario: 009 - Case Notes - Cancel New Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Click on New Notes Button
	And I Enter a Random Text on the Notes Text Area and Click On Cancel
	Then I See New Note Form has Dissapeared
	And I See the Canceled Note is not Present

@CaseDetail @CaseNotes
@US46457 @TC72808
Scenario: 010 - Case Notes - Save Button Becomes Active with One Character
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Click on New Notes Button
	And I See the Save Note Button is Inactive
	And I Enter 'a' Text on the Notes Text Area
	Then I See the Save Note Button Is Active


# Historical View
@CaseDetail @CaseNotes
@Sanity
@US46454 @TC61770 @TC61771
Scenario: 011 - Case Notes - Historical View Display and Order
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I See Notes With Some Data and Ordered By Edited Date on the Historical View

@CaseDetail @CaseNotes
@Regression @Sanity
@US46454 @TC617723 @TC61773
Scenario Outline: Case Notes - Show Staff Notes on Office Tab
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	Then I See a Note with Text '<NoteText>'
	Examples:
	| NoteText               | NoteType |
	| This is an Staff Note  | Staff    |

@Ignore @DoNotExecute
@CaseDetail @CaseNotes
@Sanity
@US52686 @TC72460 @TC72455 @TC61774
Scenario Outline: 012 - Case Notes - Z Read More Wrapping
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Create A Note with Text '<NoteText>'
	Then I See the Note Displays with Wrapped Text and the Read More Link
	And Clicking on Read More Expands the view And Read Less Link Displays
	And Clicking on Read Less Closes the Expanded View
	Examples:
	| NoteText            |
	| Very Long Note Text |

@CaseDetail @CaseNotes
@Sanity
@US52686 @TC72464
@Fix @Ignore @DoNotExecute
Scenario Outline: 013 - Case Notes - Z Read More Not Sticky
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Create A Note with Text '<NoteText>'
	And I See the Note Displays with Wrapped Text and the Read More Link
	And Clicking on Read More Expands the view And Read Less Link Displays
	And I Go to Dashboard page
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	Then I See the Note Displays with Wrapped Text and the Read More Link
	Examples:
	| NoteText            |
	| Very Long Note Text |


@CaseDetail @CaseNotes
@Sanity
@US36802 @TC76133
#AfterScenario restores original note's text
Scenario:014 - Case Notes - Edit Historical
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Edit Note with Text 'This is a Note for Edition Test' to Have Text 'Note has been edited. Need to restore it later.'
	#Then I See the Note Displays At Top Of The List With the Correct Edited Text and Date	