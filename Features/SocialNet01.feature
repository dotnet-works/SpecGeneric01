@web
Feature: SocialNet01

A short summary of the feature

Scenario: Test1 Create New User Account
	Given user navigates to "https://www.opensource-socialnetwork.org/demo"
	When navigate to socialnetwork page
	And wait for 5000
	Then switch to window "Welcome:Open Source Social Network" with title
	When verify user "zulu1133@yopmail.com" not exist
	When enter new user data
	#And wait for 5000
	#When verify yopmail
	#When login with new user to social network
	#And wait for 15000
	##Then verify title should "News Feed : Open Source Social Network"

Scenario: Test2 Login with new user
   Given user navigates to "https://www.opensource-socialnetwork.org/demo"    
   When navigate to socialnetwork page
   And switch to window "Welcome:Open Source Social Network" with title
   #  "https://demo.opensource-socialnetwork.org/"
   When enter user credentails:
         | Label         | Value                |
         | Email         | zulu1122@yopmail.com |
		 | Password      | Test@1234            |
   #Then verify user logged in
   When logout from account
   #Then verify user looged out





