Feature: Test mix features

@web
Scenario: Test 1
	Given user navigates to "https://www.google.com"
	When search "cucumber"
	And wait for 2000
	
@web
Scenario: Test 2
	Given user navigates to "https://www.opensource-socialnetwork.org/demo"
	When login to socialnetwork
	And wait for 15000

Scenario: Test 3
    Given user navigates to "https://yopmail.com"
	When verify yopmail

Scenario: Test 3 write to json file
    Given write data to json file
	When  read data from json file


#First Name: Jim
#Last Name: joe
#Username: jim123
#Email: jim123@yopmail.com
#Password: Test@1234

#max1122@yopmail.com/Test@1234
#max1122

#"zulu1111@yopmail.com",;zulu1112@yopmail.com; zulu1113@yopmail.com,zulu1115@yopmail.com,zulu1116@yopmail.com,zulu1117@yopmail.com
