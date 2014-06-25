Feature: Table support in nbehave
Scenario: a table
  Given a list of books:
    | Title | Isbn |
    | aaa   | 1234 |
    | bbb   | 2233 |
    | ccc   | 8899 |
    | ccaa  | 9999 |
  When I search for books that have 'a' in their title
  Then I should find:
    | Title | Isbn |
    | aaa   | 1234 |
    | ccaa  | 9999 |