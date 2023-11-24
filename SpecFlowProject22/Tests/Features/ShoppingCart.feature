Feature: Online Book Shopping
  As a book lover,
  I want to buy books online,
  So that I can read my favorite books at home

  Background:
    Given the user is on the homepage of the online bookstore

  Scenario Outline: Shopping for a book and adding it to the shopping cart
    Given the user has searched for "<bookTitle>"
    When the user clicks on the book "<bookTitle>" from the search results
    Then the book details page for "<bookTitle>" should be displayed
    When the user clicks on Add to Cart button
    Then "<bookTitle>" should be added to the shopping cart
    And the shopping cart should contain 1 item

  Examples: 
    | bookTitle |
    | bkname1   |

  Scenario Outline: Checking out the shopping cart
    Given the user has "<bookTitle>" in the shopping cart
    When the user clicks on Shopping Cart button
    Then the shopping cart page should be displayed
    And the shopping cart should contain ""<bookTitle>"
    When the user clicks on Proceed to Checkout button
    Then the checkout page should be displayed
    And "<bookTitle>" should be listed in the order summary

  Examples:  
    | bookTitle |
    | bkname1   |

