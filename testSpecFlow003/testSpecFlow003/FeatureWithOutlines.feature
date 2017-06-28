Feature: Feature with outlines
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@outlines
Scenario Outline: Example tables
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

	Examples:
	| description | data 1 | data 2 | result |
	| test 01     | 1      | 3      | 4      |
	| test 02     | 2      | 4      | 6      |

	Examples: other ones
	| description | data 1 | data 2 | result |
	| test 01     | 3      | 5      | 8      |
	| test 02     | 4      | 6      | 10     |
