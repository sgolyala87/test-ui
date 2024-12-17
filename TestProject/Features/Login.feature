Feature: Login
As a user I want to log into the app to access my account


Scenario: Id_01 Successful login with valid credentials
	Given I navigate to login page
	When I enter valid credentials
	And I click on Submit button
	Then I should redirected to the dashboard


Scenario Outline: Id_02 Failed Login with invalid credentials - Verify error messages
	Given I navigate to login page
	When I enter invalid <Username>  <Password>
	And I click on Submit button
	Then I should see an <Errormessage>

Examples:
	| Username      | Password          | Errormessage              |
	| incorrectUser | Password123       | Your username is invalid! |
	| student       | incorrectpassword | Your password is invalid! |

