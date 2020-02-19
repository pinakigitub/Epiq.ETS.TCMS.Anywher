@Regression	
@ReactJS	
Feature: TrusteeVisibility
	In order to verify Trustee Visibility with view permission 
	And verify the data between UI and DB


Background: 
Given I enter to Unity Login page
	When I try to login with credentials autotest1, Welcome789Epiq! and crose
#changed password on 19th Oct

@204500
Scenario: 001 - Unity Pages-TrusteeVisibility- DSO Management Page   
	       Given I Go to DSO page 
	                Then  I see DSO Management header
	                Then I verify the DSO record with Claimant Name as 'KALPANA' and '4'
	                #Then Verify DB count from UI AND DB 'DSO'
	                Then I SignOut from the Unity Application
	
@US204499
Scenario: 002 - Unity Pages-TrusteeVisibility- Tasks Management Page 
	        Given I Go to Tasks page 
	                Then  I see Task Management header
	                Then I see No matching tasks message
	                #Then Verify DB count from UI AND DB 'Tasks'
	                Then I SignOut from the Unity Application

@US228996
Scenario: 003 - Unity Pages-TrusteeVisibility- Banking Print Checks & Deposits   
	          Given I Go to Banking ChecksOrDeposits page 
	                  Then  I see Banking Center header
	                  Then I verify the Checks record with Case# as '17-30005' and '1'
	                  Then I SignOut from the Unity Application
	
@US228999
Scenario: 004 - Unity Pages-TrusteeVisibility- Banking Receipt Log    
	          Given I Go to Banking ReceiptLog page 
	                   Then  I see Banking Center header
	                   Then I verify the ReceiptLog record with Received from as 'Sushma' and '6'
	                   Then I SignOut from the Unity Application

@US228998
Scenario: 005 - Unity Pages-TrusteeVisibility-Dashboard Page - Claims Management Page  
	          Given I Go to Claims page 
	                    Then  I see Claims Management header
	                    Then I verify the Claims record with Received from as 'FINAL ANALYSIS INC.' and ''
			            And I see No matching claims message
	                    Then I SignOut from the Unity Application

@US229003
Scenario: 006 - Unity Pages-TrusteeVisibility-Dashboard Page - Favorite Cases
                    Then I Verify the Favorite record with Case No as '17-90000'
			         #Then Verify DB count from UI AND DB 'CaseFavorites'
                     And I SignOut from the Unity Application

@US229004
Scenario: 007 - Unity Pages-TrusteeVisibility-Dashboard Page -  Header Search
              Given I see the Search box under All Cases Section
                      When I Enter '11-10132' On The Universal Search Section Input
                      And I Verify Case section with Case Num '11-10132'            
                      Then I SignOut from the Unity Application

@US204502
Scenario: 008 - Unity Pages-TrusteeVisibility-Dashboard Page -  Banking Activity
              Given I Go to Banking Activity page 
	                    Then  I see Banking Center header
	                    Then I verify the Activity record with Account#  as '9999924139' and ''
			            And I see No matching activity message
	                    Then I SignOut from the Unity Application




