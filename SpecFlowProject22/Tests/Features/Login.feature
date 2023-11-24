Feature: User Login

  As a user,
  I want to be able to log into my account
  So I can access my account.

@ValidCredentials
Scenario Outline: Successful Login with Valid Username and Password
  Given the user is on the login page
  When user enter a valid username as "<username>" and password as "<password>"
  Then user clicks on login button
  And user should see a welcome message with their username

Examples:
| username  | password |
| testUser1 | pwd@123  |

@InvalidCredentials
Scenario Outline: Unsuccessful Login with Invalid Username and Password
  Given the user is on the login page
  When user enter an invalid username as "<username>" and password as "<password>"
  Then user clicks on login button
  Then user should see an error message indicating invalid credentials

Examples:
| username  | password |
| testUser1 | pwd@pwd  |

@EmptyCredentials
Scenario: Unsuccessful Login with Empty Username and/or Password
  Given the user is on the login page
  When user leave the username and password field empty
  Then user clicks on login button
  Then user should see an error message for the required fields

