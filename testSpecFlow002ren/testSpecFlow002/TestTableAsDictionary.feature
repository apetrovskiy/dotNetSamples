Feature: TestTableAsDictionary
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have a test
	# EndOfDayDate=22jul2016
	When User enter credentials
	| Key      | Value      |
	| Username | testuser_1 |
	| Password | Test@123   |
	Then the result should be 'testuser_1' and 'Test@123' returned
