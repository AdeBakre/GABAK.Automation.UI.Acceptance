Feature: TestScenarios
	In order to get an interview with UMG
	As a job seeking person
	I need to write all these scenarios

@UI
Scenario: User signs up
	Given a user is on the offline homepage
	When the user signs up
	| username | email              | password  |
	| jorandom | random@email.com | p@ssword1 |
	Then the user is automatically logged in
	And the user's name is displayed
@UI
Scenario: User signs in
	Given a user is on the offline homepage
	When the user signs in
	| email              | password |
	| giggus01@email.com | password |
	Then the user is logged in
	And the user's name is displayed 
@UI
Scenario: Verify items displayed on homepage for offline user
	Given a user is on the offline homepage
	Then the global feeds and popular tags are displayed
@UI
Scenario: User likes article but not signed in
	Given a user is on the offline homepage
	When a user tries to like an article
	Then the user is directed to the sign up area
@UI
Scenario Outline: Verify validation errors for invalid details
	Given a user is on the offline homepage
	When the user clicks on the sign up link
	And the user enters "<username>" as username on sign up page
	And the user enters "<email_address>" as email on sign up page
	And the user enters "<password>" as password on sign up page
	And the user clicks on the sign up button
	Then a validation error is displayed
	Examples: 
	| username | email_address      | password |
	| giggus   | random             | password |
	| random   | giggus01@email.com | password |
	| random   | random             | short    |
@UI@Fail
Scenario: User signs up and your feed is displayed
	Given a user is on the offline homepage
	When the user signs up
	| username | email              | password  |
	| jorandom | jb@randomemail.com | p@ssword1 |
	Then the Your Feeds section should be displayed by default
	And the Your Feeds section should be empty
@UI
Scenario: Signed in user creates new article
	Given a user is on the logged in homepage
	When the user creates a new article
	| Title         | About      | Description              | Tags |
	| TestArticle11 | QA Article | Just another description | qa   |
	Then the article section is displayed with the article information
	And the comment section is displayed