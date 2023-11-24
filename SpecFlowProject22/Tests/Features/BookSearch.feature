Feature: Online Book Search
  As a user,
  I want to search for a specific book and select it from the search results
  So that I can purchase it from an online bookstore.

Background:
  Given the user is on the homepage of the online bookstore

@Search
Scenario Outline: Searching for a specific book
  When the user enters "<bookTitle>" into the search bar
  And the user clicks on the search button
  Then the search results should display a list of books related to "<bookTitle>"

Examples:	
| bookTitle  |
| bkTitle1   |
| bkTitle2   |
| bkTitle3   |

@Search
Scenario Outline: Searching for a specific author
  When the user enters "<author>" into the search bar
  And the user clicks on the search button
  Then the search results should display a list of books related to author "<author>"

Examples:
| author      |
| authorName1 |


@Selection
Scenario Outline: Selecting the book from search results
  When the search results for "<bookTitle>" are displayed
  Then the user clicks on the book titled "<bookTitle>" by "<author>" from the search results
  Then the book's detail page should open with the title "<bookTitle>"
  And the author name should be displayed as "<author>".
 
Examples:
| bookTitle	 | author      |
| bkTitle1   | authorName1 |

@Search 
Scenario Outline: Book not found in search results
  When the user enters "<bookTitle>" into the search bar
  And the user clicks on the search button
  Then the page should display a message saying "No results found for" "<bookTitle>"

Examples:
| bookTitle	 |
| bkTitle4   |

@Search 
Scenario: Search without entering a book title
  When the user leaves the search bar empty
  And the user clicks on the search button
  Then the page should display a message saying "Please enter a book title to search."
