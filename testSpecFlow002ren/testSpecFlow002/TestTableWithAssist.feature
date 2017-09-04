Feature: TestTableWithAssist
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: test 01
	Given I entered the following data into the new account form:
	| Field              | Value      |
	| Name               | John Galt  |
	| Birthdate          | 2/2/1902   |
	| HeightInInches     | 72         |
	| BankAccountBalance | 1234.56    |
	When I do test
	Then the result should be displayed

@mytag
Scenario: test 02
	Given I entered the following data into the new account form:
	| Name      | Birthdate | HeightInInches | BankAccountBalance |
	| John Galt | 2/2/1902  | 72             | 1234.56            |
	When I do test
	Then the result should be displayed