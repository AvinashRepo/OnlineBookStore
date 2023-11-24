Feature: User Registration on Online Bookstore

Background:
    Given the user is on the registration page

  Scenario Outline: New user registration on the online bookstore
    When user enters valid registration details username as "<username>", password is "<password>" and confirm password as "<confirm_password>"
    And clicks the Register button
    Then the user should be able to view registration success message

 Examples:
      |    username    | password | confirm_password |
      |   testUser1    | Pwd@123  | Pwd@123          |
      |   testUser2    | Pwd@456  | Pwd@456          |

  Scenario Outline: User registration with invalid information
    When the user provides invalid registration details username as "<username>", password is "<password>" and confirm password as "<confirm_password>"
    And clicks the Register button
    Then an error message should be displayed
    And the user should remain on the registration page

  Examples:
      |  username   | password | confirm_password |
      |  testUser3  | Pwd@124  | pwd@123          |


  Scenario Outline: User registration with existing username
    When the user provides registration details with the existing username as "<username>"
    And clicks the Register button
    Then an error message should be displayed
    And the user should remain on the registration page
  
  Examples:
      |    username    | password | confirm_password |
      |   testUser1    | Pwd@123  | Pwd@123          |


  Scenario Outline: User registration with mismatched passwords
    Given the user is on the registration page
    When the user provides passwords as "<password>" and "<confirm_password>"
    Then an error message should be displayed, indicating that the passwords do not match

  Examples:
      | password   | confirm_password |
      | pwd123     | Pwd123           |

   


