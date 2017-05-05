Feature: Feature2
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Add two numbers
	Given I have entered <first> into the calculator
	And I have entered <second> into the calculator
	When I press add
	Then the result should be <result> on the screen

	Examples: 
	| first | second | result |
	| 10    | 20     | 30     |
	| 20    | 30     | 50     |
	| 30    | 40     | 70     |
	| 40    | 50     | 90     |
	| 50    | 10     | 60     |
