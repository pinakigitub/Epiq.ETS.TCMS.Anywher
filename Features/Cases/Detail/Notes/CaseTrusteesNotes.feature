@Regression
@Ignore @DoNotExecute
Feature: Case Detail - Case Notes Trustees
	In order to be able to add, review, edit, and delete notes for a case.
	As a user of Unity
	I need to have a window for Trustee Notes that is active on all screens and tied back to the case I am viewing

@CaseDetail @CaseNotes
@Sanity
@US46454 @TC617723 @TC61773
Scenario Outline: 001 - Case Notes Trustees - Show Trustee Notes on Trustees Tab
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Trustee Tab
	Then I See a Note with Text '<NoteText>'
	Examples:
	| NoteText               | NoteType |
	| This is a Trustee Note | Trustee  |

# New Trustee Notes (US 46457)
@CaseDetail @CaseNotes
@Sanity
@US46457 @TC72794 @TC72798 @TC61772
Scenario: 002 - Case Notes Trustees - Create New Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'	
	When I Create a Trustee Note with Random Text
	Then I See the New Note at the Top of Notes Historical View Displaying Correct Data

@CaseDetail @CaseNotes
@US46457 @TC72799 
Scenario: 003 - Case Notes Trustees - Cancel New Note
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Trustee Tab
	And I Click on New Notes Button
	And I Enter a Random Text on the Notes Text Area and Click On Cancel
	Then I See New Note Form has Dissapeared
	And I See the Canceled Note is not Present

@CaseDetail @CaseNotes
@US46457 @TC72808
Scenario: 004 - Case Notes Trustees - Save Button Becomes Active with One Character
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Trustee Tab
	And I Click on New Notes Button
	And I See the Save Note Button is Inactive
	And I Enter 'a' Text on the Notes Text Area
	Then I See the Save Note Button Is Active

 # Historical View
@CaseDetail @CaseNotes
@Sanity
@US46454 @TC61770 @TC61771
Scenario: 005 - Case Notes Trustees - Historical View Display and Order
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Open Notes Window
	And I Go To Trustee Tab
	And I See Notes With Some Data and Ordered By Edited Date on the Historical View

@CaseDetail @CaseNotes
@Sanity
@US52686 @TC72460 @TC72455 @TC61774
@Fix @Ignore @DoNotExecute
#TODO use resources to load the note text from step
Scenario Outline: 006 - Case Notes Trustees - Z Read More Wrapping
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Create A Trustee Note with Text '<NoteText>'
	Then I See the Note Displays with Wrapped Text and the Read More Link
	And Clicking on Read More Expands the view And Read Less Link Displays
	And Clicking on Read Less Closes the Expanded View
	Examples:
	| NoteText                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
	| Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per. Ius id vidit volumus mandamus, vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei. Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit. |

@CaseDetail @CaseNotes
@Sanity
@US52686 @TC72464
@Fix @Ignore @DoNotExecute
#TODO use resources to load the note text from step
Scenario Outline: 007 - Case Notes Trustees - Z Read More Not Sticky
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Create A Trustee Note with Text '<NoteText>'	
	And I See the Note Displays with Wrapped Text and the Read More Link
	And Clicking on Read More Expands the view And Read Less Link Displays
	And I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	And I Go To Trustee Tab
	Then I See the Note Displays with Wrapped Text and the Read More Link
	Examples:
	| NoteText                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
	| Lorem ipsum ad his scripta blandit partiendo, eum fastidii accumsan euripidis in, eum liber hendrerit an. Qui ut wisi vocibus suscipiantur, quo dicit ridens inciderint id. Quo mundi lobortis reformidans eu, legimus senserit definiebas an eos. Eu sit tincidunt incorrupte definitionem, vis mutat affert percipit cu, eirmod consectetuer signiferumque eu per. In usu latine equidem dolores. Quo no falli viris intellegam, ut fugit veritus placerat per. Ius id vidit volumus mandamus, vide veritus democritum te nec, ei eos debet libris consulatu. No mei ferri graeco dicunt, ad cum veri accommodare. Sed at malis omnesque delicata, usu et iusto zzril meliore. Dicunt maiorum eloquentiam cum cu, sit summo dolor essent te. Ne quodsi nusquam legendos has, ea dicit voluptua eloquentiam pro, ad sit quas qualisque. Eos vocibus deserunt quaestio ei. Blandit incorrupte quaerendum in quo, nibh impedit id vis, vel no nullam semper audiam. Ei populo graeci consulatu mei, has ea stet modus phaedrum. Inani oblique ne has, duo et veritus detraxit. |


@CaseDetail @CaseNotes
@Sanity
@US36802 @TC76133
#AfterScenario restores original note's text
Scenario: 008 - Case Notes Trustees - Edit Historical
	Given I enter to 341 Meeting page as superuser
	And I Enter to Case Detail page for Case with Case Number '09-13569'
	When I Edit Trustee Note with Text 'This is a Note for Edition Test' to Have Text 'Note has been edited. Need to restore it later.'
	#Then I See the Note Displays At Top Of The List With the Correct Edited Text and Date	