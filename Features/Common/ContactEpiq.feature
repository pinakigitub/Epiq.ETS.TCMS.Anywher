@Regression
@ReactJS
Feature: Contact Epiq
	In order to contact Epiq
	As a Unity user
	I want to be able to write an Email to an Epiq contact

@ContactEpic @US34863 @TC38927
Scenario: 001_"ContactEpiq" Write an Email to an Epiq Contact
	Given I enter to Dashboard page as superuser	
	When I Open the User Menu from the Application Bar
	Then I see Help heading 'Have a question?'
	And help text ' We will help you find an answer. '
	And a Email Link with reference'contactepiq@epiqglobal.com'
	And Number to Contant '1-800-444-6666'
	When I Open the User Menu from the Application Bar
	Then I SignOut from the Unity Application
	#And I Should be able to see the link with reference
	#And I Should navigate to home page
	#And I Should be able to see the phone number

