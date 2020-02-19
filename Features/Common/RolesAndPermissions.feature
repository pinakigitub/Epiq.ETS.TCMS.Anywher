@Ignore @DoNotExecute
Feature: Roles And Permissions - Roles
	In order for users cannot perform functions in Unity that they do not have permissions for in TNET
	As the Product Owner of Unity
	I want the Permissions from TNET to flow into Unity

	Users without Banking Role cannot create new transactions (option greyed out for new check and deposit) 
	Users with Banking Role can create transactions (option highlighted for new check and deposit)
	Users without Asset Role cannot create new assets(option greyed out for new check and deposit)
	Users with Asset Role can create new assets (option highlighted for new)
	Users without Distribution Role cannot create new distribution (option greyed out for + new distribution)
	Users with Distribution Role can create new distributions (option highlighted for new)
	Users with Trustee Role can do all functions.
	Users with "only" the View Only role can not do any functions, options greyed out.

	If user does not have permissions, link will be grey and disabled.


#@RolesAndPermissions
#@Regression
#Scenario Outline: Roles And Permissions
#	Given I Login to Unity With Credentials '<username>', '<password>' and '<office>' And Roles '<roles>'
#	And I Enter to Case Detail page for Case with Case Number '03-30103'
#	Then User Can Only Create Assets If Having Assets or Trustee Role
#	And User Can Only Create Transactions If Having Banking or Trustee Role	
#	#And User Can Only Create Distributions If Having Distributions or Trustee Role
#	And User Can Only Create Claims If Having Claims or Trustee Role
#	Examples:
#	| username       | password   | office | roles                                            |
#	| jassets        | conversion | crose  | Assets                                           |
#	| jclaims        | conversion | crose  | Claims                                           |
#	| jsuper         | conversion | crose  | Assets,Banking,Distributions,Claims,Trustee Role |
#	| Jcool          | conversion | crose  | Assets,Banking,Distributions,Claims              |
#	| jbanking       | conversion | crose  | Banking                                          |
#	| jdistributions | conversion | crose  | Distributions                                    |
#	| JTrustee       | conversion | crose  | Trustee Role                                     |  